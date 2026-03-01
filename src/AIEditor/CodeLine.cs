using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Text;
using System.Diagnostics;
using System.Text;

namespace FF7Scarlet.AIEditor
{
    public class CodeLine : Code
    {
        public ushort Header { get; private set; }
        public byte Opcode { get; set; }
        public OpcodeInfo? OpcodeInfo
        {
            get { return OpcodeInfo.GetInfo(Opcode); }
        }
        public byte[] Parameter { get; set; } = [];
        public byte PopCount { get; set; }

        public CodeLine(Script parent, ushort header, byte opcode, byte[]? parameter = null) :base(parent)
        {
            Header = header;
            Opcode = opcode;
            Parameter = parameter ?? [];
        }

        public CodeLine(CodeLine other) :base(other.Parent)
        {
            Header = other.Header;
            Opcode = other.Opcode;
            Parameter = other.Parameter;
            PopCount = other.PopCount;
        }

        public override ushort GetHeader()
        {
            return Header;
        }

        public override byte GetPrimaryOpcode()
        {
            return Opcode;
        }

        public override byte[] GetParameter()
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

        public override bool HasOpcode(Opcodes op)
        {
            return (byte)op == Opcode;
        }

        public override string Disassemble(bool jpText, bool verbose)
        {
            var sb = new StringBuilder();
            if (verbose)
            {
                if (Opcode <= (byte)Opcodes.PushValue13)
                {
                    sb.Append($"Push {DisassembleSimple(jpText)}");
                }
                else if (Opcode >= (byte)Opcodes.PushConst01 && Opcode <= (byte)Opcodes.PushConst03)
                {
                    sb.Append($"Push {DisassembleSimple(jpText)}");
                }
                else if (Opcode == (byte)Opcodes.Jump)
                {
                    if (Parameter != null)
                    {
                        sb.Append($"Goto Label {BitConverter.ToUInt16(Parameter)}");
                    }
                }
                else
                {
                    sb.Append(DisassembleSimple(jpText));
                }
            }
            else
            {
                sb.Append(DisassembleSimple(jpText));
            }
            return sb.ToString();
        }

        private string DisassembleSimple(bool jpText)
        {
            var sb = new StringBuilder();
            bool isVar = false;
            if (Enum.IsDefined(typeof(Opcodes), Opcode))
            {
                if (Opcode == (byte)Opcodes.Label)
                {
                    sb.Append("--LABEL ");
                }
                else if (Opcode <= (byte)Opcodes.PushValue13)
                {
                    isVar = true;
                }
                else if (Opcode >= (byte)Opcodes.PushConst01 && Opcode <= (byte)Opcodes.PushConst03)
                {
                    //nothing
                }
                else
                {
                    sb.Append(Enum.GetName((Opcodes)Opcode)).Append(' ');
                }
            }
            else
            {
                sb.Append("Unknown ");
            }

            //if the script has any parameters, show those
            if (Parameter != null)
            {
                if (Opcode == (byte)Opcodes.ShowMessage)
                {
                    sb.Append($"\"{new FFText(Parameter).ToString(jpText)}\"");
                }
                else if (Opcode == (byte)Opcodes.Label)
                {
                    sb.Append($"{BitConverter.ToUInt16(Parameter)} --");
                }
                else if (OpcodeInfo.GetInfo(Opcode)?.Group == OpcodeGroups.Jump)
                {
                    sb.Append($"Label {BitConverter.ToUInt16(Parameter)}");
                }
                else if (Parameter.Length > 0)
                {
                    //get variable name (if it exists)
                    ushort u = Parameter[0];
                    if (Parameter.Length > 1)
                    {
                        u = BitConverter.ToUInt16(Parameter);
                    }

                    //append the variable name, or just the number if one doesn't exist
                    if (Enum.IsDefined((CommonVars.Globals)u))
                    {
                        sb.Append(Enum.GetName((CommonVars.Globals)u));
                    }
                    else if (Enum.IsDefined((CommonVars.ActorGlobals)u))
                    {
                        sb.Append(Enum.GetName((CommonVars.ActorGlobals)u));
                    }
                    else
                    {
                        if (isVar)
                        {
                            sb.Append("Var:");
                        }
                        sb.Append(HexParser.HexNumberToText(Parameter));
                    }
                    return sb.ToString();
                }
            }
            return sb.ToString();
        }

        public override List<CodeLine> BreakDown()
        {
            return new List<CodeLine> { this };
        }

        public override byte[] GetBytes()
        {
            int length = GetDataLength();
            if (length == 0) { return []; }

            try
            {
                var data = new byte[length];
                if (OpcodeInfo == null) { throw new ArgumentNullException(); }
                try
                {
                    data[0] = Opcode;

                    if (OpcodeInfo.Group == OpcodeGroups.Jump)
                    {
                        if (Parent == null || Parameter == null) { throw new ArgumentNullException(); }
                        var temp = BitConverter.GetBytes(Parent.GetLabelPosition(BitConverter.ToUInt16(Parameter)));
                        Array.Copy(temp, 0, data, 1, temp.Length);
                    }
                    else
                    {
                        //check for parameter data
                        if (Parameter == null) { throw new ArgumentNullException(); }
                        switch (OpcodeInfo.ParameterType)
                        {
                            case ParameterTypes.None:
                                break;
                            case ParameterTypes.Debug:
                                data[1] = PopCount;
                                Array.Copy(Parameter, 0, data, 2, Parameter.Length);
                                break;
                            default:
                                Array.Copy(Parameter, 0, data, 1, Parameter.Length);
                                break;
                        }
                    }
                    return data;
                }
                catch (FormatException ex)
                {
                    Debug.WriteLine($"Format error parsing opcode: {ex}");
                    throw new FormatException($"Opcode {OpcodeInfo.Name} did not parse correctly: {ex.Message}", ex);
                }
                catch (InvalidOperationException ex)
                {
                    Debug.WriteLine($"Invalid operation parsing opcode: {ex}");
                    throw new FormatException($"Opcode {OpcodeInfo.Name} did not parse correctly: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unexpected error parsing opcode: {ex}");
                    throw new FormatException($"Opcode {OpcodeInfo.Name} did not parse correctly: {ex.Message}", ex);
                }
            }
            catch (ArgumentNullException)
            {
                throw new FormatException("Unknown opcode found.");
            }
        }

        private int GetDataLength()
        {
            int length = 0;
            if (Opcode != (byte)Opcodes.Label && OpcodeInfo != null)
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
                        if (Parameter != null) { length += Parameter.Length; }
                        break;
                    case ParameterTypes.Debug:
                        if (Parameter != null) { length += Parameter.Length + 2; } //pop count + terminator
                        break;
                }
            }
            return length;
        }
    }
}
