namespace FF7Scarlet.SceneEditor
{
    [Flags]
    public enum BattleFlags : ushort
    {
        Unknown = 0x02,
        CantEscape = 0x04,
        NoVictoryPoses = 0x08,
        NoPreemptive = 0x10
    }
}
