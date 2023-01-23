using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public class CodeLine : Code
    {
        public ushort Header { get; private set; }
        public byte Opcode { get; set; }
        public OpcodeInfo OpcodeInfo
        {
            get { return OpcodeInfo.GetInfo(Opcode); }
        }
        public FFText Parameter { get; set; }
        public byte PopCount { get; set; }

        public CodeLine(Script parent, ushort header, byte opcode, FFText parameter = null)
        {
            Parent = parent;
            Header = header;
            Opcode = opcode;
            Parameter = parameter;
        }

        public override ushort GetHeader()
        {
            return Header;
        }

        public override byte GetPrimaryOpcode()
        {
            return Opcode;
        }

        public override FFText GetParameter()
        {
            return Parameter;
        }

        public override byte GetPopCount()
        {
            return PopCount;
        }

        public override void SetParent(Script parent)
        {
            Parent = parent;
        }

        //set the header and calculate what the next header should be
        public override ushort SetHeader(ushort value)
        {
            Header = value;
            return Convert.ToUInt16(GetDataLength() + value);
        }

        public override string Disassemble(bool verbose)
        {
            string output = "";
            if (verbose)
            {
                if (Opcode <= (byte)Opcodes.PushValue13)
                {
                    output += $"Push {DisassembleSimple()}";
                }
                else if (Opcode >= (byte)Opcodes.PushConst01 && Opcode <= (byte)Opcodes.PushConst03)
                {
                    output += $"Push {DisassembleSimple()}";
                }
                else if (Opcode == (byte)Opcodes.Jump)
                {
                    output += "Goto Label " + Parameter;
                }
                else
                {
                    output += DisassembleSimple();
                }
            }
            else
            {
                output += DisassembleSimple();
            }
            return output;
        }

        private string DisassembleSimple()
        {
            string output = "";
            if (Enum.IsDefined(typeof(Opcodes), Opcode))
            {
                if (Opcode == (byte)Opcodes.Label)
                {
                    output += "--LABEL ";
                }
                else if (Opcode <= (byte)Opcodes.PushValue13)
                {
                    output += "Var:";
                }
                else if (Opcode >= (byte)Opcodes.PushConst01 && Opcode <= (byte)Opcodes.PushConst03)
                {
                    //nothing
                }
                else
                {
                    output += Enum.GetName(typeof(Opcodes), Opcode) + " ";
                }
            }
            else
            {
                output += "Unknown ";
            }

            //if the script has any parameters, show those
            if (Parameter != null)
            {
                if (Opcode == (byte)Opcodes.ShowMessage)
                {
                    output += $"\"{Parameter}\"";
                }
                else if (Opcode == (byte)Opcodes.Jump || Opcode == (byte)Opcodes.JumpEqual
                    || Opcode == (byte)Opcodes.JumpNotEqual)
                {
                    output += $"Label {Parameter}";
                }
                else if (Opcode == (byte)Opcodes.Label)
                {
                    output += Parameter + "--";
                }
                else
                {
                    output += ParseHexParameter();
                }
            }
            return output;
        }

        private string ParseHexParameter()
        {
            string output = "";
            int param = int.Parse(Parameter.ToString(), NumberStyles.HexNumber);

            if (Opcode == (byte)Opcodes.PushConst01)
            {
                output += param.ToString("X2");
            }
            else
            {
                output += param.ToString("X4");
                if (Enum.IsDefined(typeof(CommonVars.Globals), param))
                {
                    output += $" ({Enum.GetName(typeof(CommonVars.Globals), param)})";
                }
                else if (Enum.IsDefined(typeof(CommonVars.ActorGlobals), param))
                {
                    output += $" ({Enum.GetName(typeof(CommonVars.ActorGlobals), param)})";
                }
            }
            return output;
        }

        public override List<CodeLine> BreakDown()
        {
            return new List<CodeLine> { this };
        }

        public override byte[] GetBytes()
        {
            int length = GetDataLength();
            if (length == 0) { return null; }
            var data = new byte[length];
            var temp = Parameter?.GetBytes(OpcodeInfo.ParameterType);
            data[0] = Opcode;
            try
            {
                if (OpcodeInfo.Group == OpcodeGroups.Jump)
                {
                    temp = BitConverter.GetBytes(Parent.GetLabelPosition(Parameter.ToInt()));
                    Array.Copy(temp, 0, data, 1, temp.Length);
                }
                else
                {
                    switch (OpcodeInfo.ParameterType)
                    {
                        case ParameterTypes.None:
                            break;
                        case ParameterTypes.Debug:
                            data[1] = PopCount;
                            Array.Copy(temp, 0, data, 2, temp.Length);
                            data[data.Length - 1] = 0;
                            break;
                        default:
                            Array.Copy(temp, 0, data, 1, temp.Length);
                            break;
                    }
                }
                return data;
            }
            catch (Exception)
            {
                throw new FormatException($"Opcode {OpcodeInfo.Name} did not parse correctly. (Length was {length}, parameter length was {temp.Length})");
            }
        }

        private int GetDataLength()
        {
            int length = 0;
            if (Opcode != (byte)Opcodes.Label)
            {
                length = 1;
                switch (OpcodeInfo.ParameterType)
                {
                    case ParameterTypes.OneByte:
                        length++;
                        break;
                    case ParameterTypes.TwoByte:
                        length += 2;
                        break;
                    case ParameterTypes.ThreeByte:
                        length += 3;
                        break;
                    case ParameterTypes.String:
                        length += Parameter.Length;
                        break;
                    case ParameterTypes.Debug:
                        length += Parameter.Length + 1;
                        break;
                }
            }
            return length;
        }
    }
}
