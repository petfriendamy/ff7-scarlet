namespace FF7Scarlet.AIEditor
{
    public enum OpcodeGroups
    {
        Push, Mathematical, Logical, Jump, BitOperation, Command
    }

    public class OpcodeInfo
    {
        public static readonly OpcodeInfo[] OPCODE_LIST = new OpcodeInfo[]
        {
            new OpcodeInfo(Opcodes.PushAddress00, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Address Type 0"),
            new OpcodeInfo(Opcodes.PushAddress01, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Address Type 1"),
            new OpcodeInfo(Opcodes.PushAddress02, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Address Type 2"),
            new OpcodeInfo(Opcodes.PushAddress03, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Address Type 3"),

            new OpcodeInfo(Opcodes.PushValue10, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Value Type 0"),
            new OpcodeInfo(Opcodes.PushValue11, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Value Type 1"),
            new OpcodeInfo(Opcodes.PushValue12, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Value Type 2"),
            new OpcodeInfo(Opcodes.PushValue13, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Value Type 3"),

            new OpcodeInfo(Opcodes.Add, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "+"),
            new OpcodeInfo(Opcodes.Subtract, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "-"),
            new OpcodeInfo(Opcodes.Multiply, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "*"),
            new OpcodeInfo(Opcodes.Divide, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "/"),
            new OpcodeInfo(Opcodes.Modulo, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "%"),
            new OpcodeInfo(Opcodes.BitwiseAnd, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "&"),
            new OpcodeInfo(Opcodes.BitwiseOr, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "|"),
            new OpcodeInfo(Opcodes.BitwiseNot, OpcodeGroups.Mathematical, ParameterTypes.None, 1, "~"),

            new OpcodeInfo(Opcodes.Equal, OpcodeGroups.Logical, ParameterTypes.None, 2, "=="),
            new OpcodeInfo(Opcodes.NotEqual, OpcodeGroups.Logical, ParameterTypes.None, 2, "!="),
            new OpcodeInfo(Opcodes.GreaterOrEqual, OpcodeGroups.Logical, ParameterTypes.None, 2, ">="),
            new OpcodeInfo(Opcodes.LessThanOrEqual, OpcodeGroups.Logical, ParameterTypes.None, 2, "<="),
            new OpcodeInfo(Opcodes.GreaterThan, OpcodeGroups.Logical, ParameterTypes.None, 2, ">"),
            new OpcodeInfo(Opcodes.LessThan, OpcodeGroups.Logical, ParameterTypes.None, 2, "<"),

            new OpcodeInfo(Opcodes.LogicalAnd, OpcodeGroups.Logical, ParameterTypes.None, 2, "&&"),
            new OpcodeInfo(Opcodes.LogicalOr, OpcodeGroups.Logical, ParameterTypes.None, 2, "||"),
            new OpcodeInfo(Opcodes.LogicalNot, OpcodeGroups.Logical, ParameterTypes.None, 1, "!"),

            new OpcodeInfo(Opcodes.PushConst01, OpcodeGroups.Push, ParameterTypes.OneByte, 0, "Const Type 1"),
            new OpcodeInfo(Opcodes.PushConst02, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Const Type 2"),
            new OpcodeInfo(Opcodes.PushConst03, OpcodeGroups.Push, ParameterTypes.ThreeByte, 0, "Const Type 3"),

            new OpcodeInfo(Opcodes.JumpEqual, OpcodeGroups.Jump, ParameterTypes.TwoByte, 1),
            new OpcodeInfo(Opcodes.JumpNotEqual, OpcodeGroups.Jump, ParameterTypes.TwoByte, 1),
            new OpcodeInfo(Opcodes.Jump, OpcodeGroups.Jump, ParameterTypes.TwoByte, 0),
            new OpcodeInfo(Opcodes.End, OpcodeGroups.Command, ParameterTypes.None, 0),
            new OpcodeInfo(Opcodes.PopUnused, OpcodeGroups.Command, ParameterTypes.None, 0),
            new OpcodeInfo(Opcodes.ShareScripts, OpcodeGroups.Command, ParameterTypes.None, 1),

            new OpcodeInfo(Opcodes.Mask, OpcodeGroups.BitOperation, ParameterTypes.None, 2, "."),
            new OpcodeInfo(Opcodes.RandomWord, OpcodeGroups.BitOperation, ParameterTypes.None, 0, "Random"),
            new OpcodeInfo(Opcodes.RandomByte, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.CountBits, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.MaskGreatest, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.MaskLeast, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.MPCost, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.TopBit, OpcodeGroups.BitOperation, ParameterTypes.None, 1),

            new OpcodeInfo(Opcodes.Assign, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.Pop, OpcodeGroups.Command, ParameterTypes.None, 0),
            new OpcodeInfo(Opcodes.Attack, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.ShowMessage, OpcodeGroups.Command, ParameterTypes.String, 0),
            new OpcodeInfo(Opcodes.CopyStats, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.Savemap, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.ElementalDef, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.DebugMessage, OpcodeGroups.Command, ParameterTypes.Debug, 1),
            new OpcodeInfo(Opcodes.Pop2, OpcodeGroups.Command, ParameterTypes.None, 0),

            new OpcodeInfo(Opcodes.Label, OpcodeGroups.Jump, ParameterTypes.Label, 0),
        };

        private string? shortName;

        public Opcodes EnumValue { get; }
        public OpcodeGroups Group { get; }
        public ParameterTypes ParameterType { get; }
        public int PopCount { get; }
        public byte Code
        {
            get { return (byte)EnumValue; }
        }
        public string Name
        {
            get
            {
                var name = Enum.GetName(EnumValue);
                if (name == null) { return ""; }
                else { return name; }
            }
        }
        public string ShortName
        {
            get
            {
                if (shortName == null)
                {
                    return Name;
                }
                return shortName;
            }
        }

        public bool IsOperand
        {
            get
            {
                return (Group == OpcodeGroups.Mathematical || Group == OpcodeGroups.Logical
                    || Group == OpcodeGroups.BitOperation) && PopCount > 0;
            }
        }

        public bool IsModifier
        {
            get
            {
                return (IsOperand && PopCount < 2);
            }
        }

        public bool IsParameter
        {
            get
            {
                return Group == OpcodeGroups.Push || Group == OpcodeGroups.Jump
                    || EnumValue == Opcodes.RandomWord || ParameterType == ParameterTypes.String
                    || ParameterType == ParameterTypes.Debug;
            }
        }

        public bool IsVariable
        {
            get
            {
                return Group == OpcodeGroups.Push && !IsConst;
            }
        }

        public bool IsConst
        {
            get
            {
                return Code >= (byte)Opcodes.PushConst01 && Code <= (byte)Opcodes.PushConst03;
            }
        }

        public OpcodeInfo(Opcodes enumValue, OpcodeGroups group, ParameterTypes parameterType, int popCount,
            string? shortName = null)
        {
            EnumValue = enumValue;
            Group = group;
            ParameterType = parameterType;
            PopCount = popCount;
            this.shortName = shortName;
        }

        public static OpcodeInfo? GetInfo(byte opcode)
        {
            for (int i = 0; i < OPCODE_LIST.Length; ++i)
            {
                if (OPCODE_LIST[i].Code == opcode)
                {
                    return OPCODE_LIST[i];
                }
            }
            return null;
        }

        public static OpcodeInfo? GetInfo(Opcodes opcode)
        {
            return GetInfo((byte)opcode);
        }
    }
}
