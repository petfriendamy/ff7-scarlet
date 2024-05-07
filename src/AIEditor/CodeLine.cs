using System.Globalization;

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
        public FFText? Parameter { get; set; }
        public byte PopCount { get; set; }

        public CodeLine(Script parent, ushort header, byte opcode, FFText? parameter = null) :base(parent)
        {
            Header = header;
            Opcode = opcode;
            Parameter = parameter;
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

        public override FFText? GetParameter()
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
                    if (Parameter != null)
                    {
                        output += $"Goto Label {Parameter.ToInt()}";
                    }
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
                    output += Enum.GetName((Opcodes)Opcode) + " ";
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
                else if (Opcode == (byte)Opcodes.Label)
                {
                    output += $"{Parameter.ToInt()} --";
                }
                else if (OpcodeInfo?.Group == OpcodeGroups.Jump)
                {
                    output += $"Label {Parameter.ToInt()}";
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
            int param;
            var formatProvider = new CultureInfo("en-US");
            if (int.TryParse(Parameter?.ToString(), NumberStyles.HexNumber, formatProvider, out param))
            {
                if (Opcode == (byte)Opcodes.PushConst01)
                {
                    output += param.ToString("X2");
                }
                else
                {
                    output += param.ToString("X4");
                    if (Enum.IsDefined((CommonVars.Globals)param))
                    {
                        output += $" ({Enum.GetName((CommonVars.Globals)param)})";
                    }
                    else if (Enum.IsDefined((CommonVars.ActorGlobals)param))
                    {
                        output += $" ({Enum.GetName((CommonVars.ActorGlobals)param)})";
                    }
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
            if (length == 0) { return new byte[0]; }

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
                        var temp = BitConverter.GetBytes(Parent.GetLabelPosition(Parameter.ToInt()));
                        Array.Copy(temp, 0, data, 1, temp.Length);
                    }
                    else
                    {
                        //check for parameter data
                        byte[]? pbytes = null;
                        if (Parameter != null)
                        {
                            pbytes = Parameter.GetBytes(OpcodeInfo.ParameterType);
                        }

                        //get data
                        switch (OpcodeInfo.ParameterType)
                        {
                            case ParameterTypes.None:
                                break;
                            case ParameterTypes.Debug:
                                data[1] = PopCount;
                                if (pbytes == null) { throw new ArgumentNullException(); }
                                Array.Copy(pbytes, 0, data, 2, pbytes.Length);
                                data[data.Length - 1] = 0;
                                break;
                            default:
                                if (pbytes == null) { throw new ArgumentNullException(); }
                                Array.Copy(pbytes, 0, data, 1, pbytes.Length);
                                break;
                        }
                    }
                    return data;
                }
                catch (Exception ex)
                {
                    throw new FormatException($"Opcode {OpcodeInfo.Name} did not parse correctly: {ex.Message}");
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
                        if (Parameter != null) { length += Parameter.Length + 2; }
                        break;
                }
            }
            return length;
        }
    }
}
