namespace FF7Scarlet.SceneEditor
{
    [Flags]
    public enum InitialConditions : uint
    {
        Visble = 0x01,
        LeftSide = 0x02,
        Unknown = 0x04,
        Targetable = 0x08,
        MainScriptActive = 0x10
    }
}
