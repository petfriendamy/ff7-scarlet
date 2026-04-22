namespace FF7Scarlet.AIEditor
{
    public class CommonVarInfo<T>(T global, Opcodes type)
    {
        public static readonly CommonVarInfo<CommonVars.Globals>[] GLOBALS_LIST =
        [
            new CommonVarInfo<CommonVars.Globals>(CommonVars.Globals.Self, Opcodes.PushAddress02),
            new CommonVarInfo<CommonVars.Globals>(CommonVars.Globals.Target, Opcodes.PushValue12),
        ];

        public static readonly CommonVarInfo<CommonVars.ActorGlobals>[] ACTOR_GLOBALS_LIST = [
            new CommonVarInfo<CommonVars.ActorGlobals>(CommonVars.ActorGlobals.Target, Opcodes.PushAddress02),
        ];

        public T EnumValue { get; } = global;
        public Opcodes Type { get; } = type;
    }
}