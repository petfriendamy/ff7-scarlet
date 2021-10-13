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
            new CommandInfo(Opcodes.Assign, "Set x to y", "Variable", "Assignment"),
            new CommandInfo(Opcodes.AssignGlobal, "Set global variable to x", "Variable", "Assignment"),
            new CommandInfo(Opcodes.JumpEqual, "If x == y, goto label", "Condition", "Label ID"),
            new CommandInfo(Opcodes.JumpNotEqual, "If 1st in stack != x, goto label", "Value", "Label ID"),
            new CommandInfo(Opcodes.Label, "Create new label", "Label ID"),
            new CommandInfo(Opcodes.Jump, "Goto label", "Label ID"),
            new CommandInfo(Opcodes.Attack, "Perform an attack", "Attack Type", "Attack ID"),
            new CommandInfo(Opcodes.ShowMessage, "Show a message", "String")
        };

        public Opcodes Opcode { get; }
        public string Description { get; }
        public string Parameter1 { get; }
        public string Parameter2 { get; }

        public CommandInfo(Opcodes opcode, string description, string parameter1 = null, string parameter2 = null)
        {
            Opcode = opcode;
            Description = description;
            Parameter1 = parameter1;
            Parameter2 = parameter2;
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
