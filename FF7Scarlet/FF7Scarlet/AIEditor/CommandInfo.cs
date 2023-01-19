using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public class CommandInfo
    {
        public static readonly CommandInfo[] COMMAND_LIST = new CommandInfo[]
        {
            new CommandInfo(Opcodes.Assign, "Set x to y", "Variable", ParameterTypes.Other, "Assignment", ParameterTypes.Other),
            new CommandInfo(Opcodes.AssignGlobal, "Set global variable to x", "Variable", ParameterTypes.Other, "Assignment", ParameterTypes.Other),
            new CommandInfo(Opcodes.JumpEqual, "If x == y, goto label", "Condition", ParameterTypes.Other, "Label ID", ParameterTypes.Label),
            new CommandInfo(Opcodes.JumpNotEqual, "If 1st in stack != x, goto label", "Value", ParameterTypes.Other, "Label ID", ParameterTypes.Label),
            new CommandInfo(Opcodes.Label, "Create new label", "Label ID", ParameterTypes.Label),
            new CommandInfo(Opcodes.Jump, "Goto label", "Label ID", ParameterTypes.Label),
            new CommandInfo(Opcodes.Attack, "Perform an attack", "Attack Type", ParameterTypes.Other, "Attack ID", ParameterTypes.Other),
            new CommandInfo(Opcodes.ShowMessage, "Show a message", "String", ParameterTypes.String),
            new CommandInfo(Opcodes.DebugMessage, "Send a string to the debug console", "Var Count", ParameterTypes.Debug, "String", ParameterTypes.String)
        };

        public Opcodes Opcode { get; }
        public string Description { get; }
        public string ParameterName1 { get; }
        public string ParameterName2 { get; }
        public ParameterTypes ParameterType1 { get; }
        public ParameterTypes ParameterType2 { get; }
        /*public ParameterTypes ParameterType
        {
            get
            {
                return OpcodeInfo.GetInfo(Opcode).ParameterType;
            }
        }*/

        public CommandInfo(Opcodes opcode, string description, string parameter1, ParameterTypes type1, string parameter2, ParameterTypes type2)
        {
            Opcode = opcode;
            Description = description;
            ParameterName1 = parameter1;
            ParameterName2 = parameter2;
            ParameterType1 = type1;
            ParameterType2 = type2;
        }

        public CommandInfo(Opcodes opcode, string description, string parameter, ParameterTypes type)
            :this(opcode, description, parameter, type, null, ParameterTypes.None)
        {
        }

        public static CommandInfo GetInfo(Opcodes opcode)
        {
            foreach (var c in COMMAND_LIST)
            {
                if (c.Opcode == opcode) { return c; }
            }
            return null;
        }
    }
}
