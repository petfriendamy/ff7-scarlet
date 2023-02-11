namespace FF7Scarlet.Shared
{
    [Flags]
    public enum StatusChange : byte
    {
        Inflict = 0x00,
        Cure = 0x40,
        Swap = 0x80,
        None = 0xFF
    }
}
