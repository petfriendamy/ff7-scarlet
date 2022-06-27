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
        public int Header { get; set; }
        public int Opcode { get; set; }
        public FFText Parameter { get; set; }

        public CodeLine(Script parent, int header, int opcode, FFText parameter = null)
        {
            Parent = parent;
            Header = header;
            Opcode = opcode;
            Parameter = parameter;
        }

        public override int GetHeader()
        {
            return Header;
        }

        public override int GetPrimaryOpcode()
        {
            return Opcode;
        }

        public override FFText GetParameter()
        {
            return Parameter;
        }

        public override string Disassemble(bool verbose)
        {
            string output = "";
            if (verbose)
            {
                if (Opcode <= (int)Opcodes.PushValue13)
                {
                    output += $"Push {DisassembleSimple()}";
                }
                else if (Opcode >= (int)Opcodes.PushConst01 && Opcode <= (int)Opcodes.PushConst03)
                {
                    output += $"Push {DisassembleSimple()}";
                }
                else if (Opcode == (int)Opcodes.Jump)
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
                if (Opcode == (int)Opcodes.Label)
                {
                    output += "--LABEL ";
                }
                else if (Opcode <= (int)Opcodes.PushValue13)
                {
                    output += "Var:";
                }
                else if (Opcode >= (int)Opcodes.PushConst01 && Opcode <= (int)Opcodes.PushConst03)
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
                if (Opcode == (int)Opcodes.ShowMessage)
                {
                    output += $"\"{Parameter}\"";
                }
                else if (Opcode == (int)Opcodes.Jump || Opcode == (int)Opcodes.JumpEqual
                    || Opcode == (int)Opcodes.JumpNotEqual)
                {
                    output += $"Label {Parameter}";
                }
                else if (Opcode == (int)Opcodes.Label)
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

            if (Opcode == (int)Opcodes.PushConst01)
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
    }
}
