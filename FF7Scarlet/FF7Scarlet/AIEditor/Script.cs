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
        public const ushort NULL_OFFSET = 0xFFFF;
        private List<Code> code;
        private Dictionary<int, ushort> labels;
        private bool headersAreCorrect = false;

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

        public Script(AIContainer parent, Code startingCode)
        {
            Parent = parent;
            startingCode.SetParent(this);
            code = new List<Code> { startingCode };
            if (startingCode.GetPrimaryOpcode() == (byte)Opcodes.Label)
            {
                labels = new Dictionary<int, ushort> { { startingCode.GetParameter().ToInt(), startingCode.GetHeader() } };
            }
            if (startingCode.GetPrimaryOpcode() != (byte)Opcodes.End)
            {
                code.Add(new CodeLine(this, 0xFFFF, (byte)Opcodes.End));
            }
        }

        public void ParseScript(ref byte[] data, int offset, int length)
        {
            //run through the script and idenify all the opcodes
            var firstParse = new List<CodeLine> { };
            byte opcode, temp;
            ushort pos;
            var intParser = new byte[4];
            var stringParser = new List<byte> { };

            labels = new Dictionary<int, ushort> { };

            using (var ms = new MemoryStream(data, offset, length, false))
            using (var reader = new BinaryReader(ms))
            {
                bool endOfStream = false;
                while (!endOfStream)
                {
                    try
                    {
                        pos = (ushort)reader.BaseStream.Position;
                        opcode = reader.ReadByte();
                        if (opcode == (byte)Opcodes.End)
                        {
                            endOfStream = true;
                        }
                        var parsedLine = new CodeLine(this, pos, opcode);
                        if (Enum.IsDefined(typeof(Opcodes), opcode))
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
                where c.Opcode >= (byte)Opcodes.JumpEqual && c.Opcode <= (byte)Opcodes.Jump
                orderby c.Parameter
                select c;

            var newLabels = new List<int> { };
            foreach (var j in jumps)
            {
                int loc = int.Parse(j.Parameter.ToString(), NumberStyles.HexNumber);
                if (!newLabels.Contains(loc))
                {
                    newLabels.Add(loc);
                }
                j.Parameter = new FFText((newLabels.IndexOf(loc) + 1));
            }

            //insert labels into the codelist
            for (int i = 0; i < firstParse.Count; ++i)
            {
                if (newLabels.Contains(firstParse[i].Header))
                {
                    int labelPos = newLabels.IndexOf(firstParse[i].Header) + 1;
                    var newLabel = new CodeLine(this, 0xFFFF, (byte)Opcodes.Label, new FFText(labelPos));
                    firstParse.Insert(i, newLabel);
                    labels.Add(labelPos, firstParse[i + 1].Header);
                    ++i;
                }
            }

            //the final parsing
            code = GetParsedCode(firstParse, this);
            headersAreCorrect = true;
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

        public void InsertCodeAtPosition(int pos, Code newCode)
        {
            if (IsEmpty || pos < 0 || pos >= code.Count)
            {
                code.Add(newCode);
            }
            else
            {
                code.Insert(pos, newCode);
            }
            if (newCode.GetPrimaryOpcode() == (byte)Opcodes.Label)
            {
                labels.Add(newCode.GetParameter().ToInt(), newCode.GetHeader());
            }
            headersAreCorrect = false;
        }

        public void ReplaceCodeAtPosition(int pos, Code newCode)
        {
            if (pos >= 0 && pos < code.Count)
            {
                code[pos] = newCode;
                if (newCode.GetPrimaryOpcode() == (byte)Opcodes.Label)
                {
                    labels.Add(newCode.GetParameter().ToInt(), newCode.GetHeader());
                }
                headersAreCorrect = false;
            }
        }

        public void RemoveCodeAtPosition(int pos)
        {
            if (pos >= 0 && pos < code.Count)
            {
                if (code[pos].GetPrimaryOpcode() == (byte)Opcodes.Label)
                {
                    labels.Remove(code[pos].GetParameter().ToInt());
                }
                code.RemoveAt(pos);
                headersAreCorrect = false;
            }
        }

        public void MoveCodeUp(int pos)
        {
            if (pos > 0 && pos < code.Count)
            {
                code.Reverse(pos - 1, 2);
                headersAreCorrect = false;
            }
        }

        public void MoveCodeDown(int pos)
        {
            if (pos >= 0 && pos < code.Count - 1)
            {
                code.Reverse(pos, 2);
                headersAreCorrect = false;
            }
        }

        public ushort GetLabelPosition(int label)
        {
            if (!headersAreCorrect) { CorrectHeaders(); }
            if (labels.ContainsKey(label)) { return labels[label]; }
            return NULL_OFFSET;
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

        public byte[] GetRawData()
        {
            if (!headersAreCorrect) { CorrectHeaders(); }

            //convert data to bytes
            var data = new List<byte> { };
            foreach (var c in code)
            {
                if (c.GetPrimaryOpcode() != (byte)Opcodes.Label)
                {
                    data.AddRange(c.GetBytes());
                }
            }
            return data.ToArray();
        }

        private void CorrectHeaders()
        {
            ushort currPos = 0;
            foreach (var c in code)
            {
                if (c.GetPrimaryOpcode() == (byte)Opcodes.Label)
                {
                    labels[c.GetParameter().ToInt()] = currPos;
                }
                currPos = c.SetHeader(currPos);
                c.SetParent(this);
            }
            headersAreCorrect = true;
        }
    }
}
