using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public class Script
    {
        private List<Code> code;
        public bool IsEmpty
        {
            get { return code.Count == 0; }
        }
        public AIContainer Parent { get; }

        public Script(AIContainer parent, ref byte[] data, int offset, int nextOffset)
        {
            Parent = parent;
            ParseScript(ref data, offset, nextOffset);
        }

        public void ParseScript(ref byte[] data, int offset, int length)
        {
            //run through the script and idenify all the opcodes
            var firstParse = new List<CodeLine> { };
            byte opcode, temp;
            int pos;
            var intParser = new byte[4];
            var stringParser = new List<byte> { };

            using (var ms = new MemoryStream(data, offset, length, false))
            using (var reader = new BinaryReader(ms))
            {
                bool endOfStream = false;
                while (!endOfStream)
                {
                    try
                    {
                        pos = (int)reader.BaseStream.Position;
                        opcode = reader.ReadByte();
                        if (opcode == (byte)Opcodes.End)
                        {
                            endOfStream = true;
                        }
                        var parsedLine = new CodeLine(this, pos, opcode);
                        if (Enum.IsDefined(typeof(Opcodes), (int)opcode))
                        {
                            var type = OpcodeInfo.GetInfo(opcode).ParameterType;
                            switch (type)
                            {
                                case ParameterTypes.OneByte:
                                    parsedLine.Parameter = new FFText(reader.ReadByte().ToString("X2"));
                                    break;
                                case ParameterTypes.TwoByte:
                                    parsedLine.Parameter = new FFText(reader.ReadUInt16().ToString("X4"));
                                    break;
                                case ParameterTypes.ThreeByte:
                                    intParser[0] = reader.ReadByte();
                                    intParser[1] = reader.ReadByte();
                                    intParser[2] = reader.ReadByte();
                                    parsedLine.Parameter = new FFText(BitConverter.ToInt32(intParser, 0).ToString("X6"));
                                    break;
                                case ParameterTypes.String:
                                    stringParser.Clear();
                                    temp = 0;
                                    while (temp != 0xFF)
                                    {
                                        temp = reader.ReadByte();
                                        stringParser.Add(temp);
                                    }
                                    parsedLine.Parameter = new FFText(stringParser.ToArray());
                                    break;
                                case ParameterTypes.Debug:
                                    parsedLine.PopCount = reader.ReadByte();
                                    stringParser.Clear();
                                    temp = 0xFF;
                                    while (temp != 0)
                                    {
                                        temp = reader.ReadByte();
                                        if (temp != 0) { stringParser.Add(temp); }
                                    }
                                    parsedLine.Parameter = new FFText(Encoding.ASCII.GetString(stringParser.ToArray()));
                                    break;

                            }
                        }
                        firstParse.Add(parsedLine);
                    }
                    catch (EndOfStreamException)
                    {
                        endOfStream = true;
                    }
                }
            }

            //check for jumps and create labels
            var jumps =
                from c in firstParse
                where c.Opcode >= (int)Opcodes.JumpEqual && c.Opcode <= (int)Opcodes.Jump
                orderby c.Parameter
                select c;

            var labels = new List<int> { };
            foreach (var j in jumps)
            {
                int loc = int.Parse(j.Parameter.ToString(), NumberStyles.HexNumber);
                if (!labels.Contains(loc))
                {
                    labels.Add(loc);
                }
                j.Parameter = new FFText((labels.IndexOf(loc) + 1));
            }

            //insert labels into the codelist
            for (int i = 0; i < firstParse.Count; ++i)
            {
                if (labels.Contains(firstParse[i].Header))
                {
                    int labelPos = labels.IndexOf(firstParse[i].Header) + 1;
                    var newLabel = new CodeLine(this, -1, (int)Opcodes.Label, new FFText(labelPos));
                    firstParse.Insert(i, newLabel);
                    ++i;
                }
            }

            //the final parsing
            code = GetParsedCode(firstParse, this);
        }

        public static List<Code> GetParsedCode(List<CodeLine> list, Script parent = null)
        {
            //use a stack to combine values
            var stack = new Stack<Code> { };
            foreach (var c in list)
            {
                //look for opcodes to combine
                if (Enum.IsDefined(typeof(Opcodes), c.Opcode))
                {
                    int popCount = OpcodeInfo.GetInfo(c.Opcode).PopCount;
                    if (OpcodeInfo.GetInfo(c.Opcode).ParameterType == ParameterTypes.Debug)
                    {
                        popCount = c.PopCount;
                    }
                    if (popCount > 0)
                    {
                        var block = new CodeBlock(parent, c);
                        for (int i = 0; i < popCount; ++i)
                        {
                            try
                            {
                                block.AddToTop(stack.Pop());
                            }
                            catch (InvalidOperationException ex)
                            {
                                throw new InvalidOperationException($"{ex.Message} (opcode: {OpcodeInfo.GetInfo(c.Opcode).Name})");
                            }
                        }
                        stack.Push(block);
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            //create the final codelist
            var code = new List<Code> { };
            while (stack.Count > 0)
            {
                if (code.Count == 0) { code.Add(stack.Pop()); }
                else { code.Insert(0, stack.Pop()); }
            }
            return code;
        } 

        public Code GetCodeAtPosition(int pos)
        {
            if (pos < 0 || pos >= code.Count)
            {
                return null;
            }
            return code[pos];
        }

        public void RemoveCodeAtPosition(int pos)
        {
            if (pos >= 0 && pos < code.Count)
            {
                code.RemoveAt(pos);
            }
        }

        public void MoveCodeUp(int pos)
        {
            if (pos > 0 && pos < code.Count)
            {
                code.Reverse(pos - 1, 2);
            }
        }

        public void MoveCodeDown(int pos)
        {
            if (pos >= 0 && pos < code.Count - 1)
            {
                code.Reverse(pos, 2);
            }
        }

        public string[] Disassemble()
        {
            var output = new List<string> { };
            if (code.Count == 0) { output.Add("(Script is empty)"); }
            else
            {
                foreach (var c in code)
                {
                    output.Add(c.Disassemble(true));
                }
            }
            return output.ToArray();
        }
    }
}
