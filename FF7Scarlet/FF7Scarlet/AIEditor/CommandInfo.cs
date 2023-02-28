using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.AIEditor
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
            new CommandInfo(Opcodes.DebugMessage, "Send a string to the debug console", "Var Count", ParameterTypes.Debug, "String", ParameterTypes.String),
            new CommandInfo((Opcodes)0xFF, "Push a value to the stack", "Value", ParameterTypes.Other)
        };

        public Opcodes Opcode { get; }
        public OpcodeInfo? OpcodeInfo
        {
            get { return OpcodeInfo.GetInfo(Opcode); }
        }
        public string Description { get; }
        public string ParameterName1 { get; }
        public string? ParameterName2 { get; }
        public ParameterTypes ParameterType1 { get; }
        public ParameterTypes ParameterType2 { get; }

        public CommandInfo(Opcodes opcode, string description, string parameter1, ParameterTypes type1, string? parameter2, ParameterTypes type2)
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

        public static CommandInfo? GetInfo(byte opcode)
        {
            return GetInfo((Opcodes)opcode);
        }

        public static CommandInfo? GetInfo(Opcodes opcode)
        {
            foreach (var c in COMMAND_LIST)
            {
                if (c.Opcode == opcode) { return c; }
            }
            return null;
        }

        public CodeBlock GenerateCode(CodeBlock? old = null)
        {
            var op = OpcodeInfo.GetInfo(Opcode);
            if (op == null) { throw new ArgumentNullException(); }
            FFText? p = null;
            CodeBlock block;
            if (old == null)
            {
                if (op.ParameterType != ParameterTypes.None)
                {
                    p = new FFText("");
                }
                block = new CodeBlock(null, new CodeLine(null, 0xFFFF, (byte)Opcode, p));
                for (int i = 0; i < op.PopCount; ++i)
                {
                    block.AddToTop(new CodeLine(null, 0xFFFF, (byte)Opcodes.PushConst01, new FFText("0")));
                }
            }
            else
            {
                p = old.GetParameter();
                block = new CodeBlock(null, old.GetCodeAtPosition(0));
                for (int i = 1; i < op.PopCount; ++i)
                {
                    block.AddToTop(old.GetCodeAtPosition(i));
                }
            }
            return block;
        }
    }
}
