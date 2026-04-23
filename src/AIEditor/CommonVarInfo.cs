namespace FF7Scarlet.AIEditor
{
    public class CommonVarInfo
    {
        public static readonly CommonVarInfo[] GLOBALS_LIST = [];
        public static readonly CommonVarInfo[] ACTOR_GLOBALS_LIST = [];

        public Enum Global { get; }
        public Opcodes Type { get; }

        public CommonVarInfo(CommonVars.Globals global, Opcodes type)
        {
            Global = global;
            Type = type;
        }

        public CommonVarInfo(CommonVars.ActorGlobals global, Opcodes type)
        {
            Global = global;
            Type = type;
        }

        public string? GetEnumValueName() => Enum.GetName(Global.GetType(), Global);
    };
}