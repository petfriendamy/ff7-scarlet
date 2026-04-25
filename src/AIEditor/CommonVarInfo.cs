namespace FF7Scarlet.AIEditor
{
    public class CommonVarInfo
    {
        public static readonly CommonVarInfo[] GLOBALS_LIST = [
            new CommonVarInfo(CommonVars.Globals.Self, [Opcodes.PushAddress02, Opcodes.PushValue12])
        ];
        public static readonly CommonVarInfo[] ACTOR_GLOBALS_LIST = [];

        public Enum Global { get; }
        public Opcodes[] Types { get; }

        public CommonVarInfo(CommonVars.Globals global, Opcodes[] types)
        {
            Global = global;
            Types = types;
        }

        public CommonVarInfo(CommonVars.ActorGlobals global, Opcodes[] types)
        {
            Global = global;
            Types = types;
        }

        public string? GetEnumValueName() => Enum.GetName(Global.GetType(), Global);
    };
}