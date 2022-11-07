namespace Shojy.FF7.Elena
{
    internal struct ArchiveFile
    {
        public string Name { get; set; }
        public uint Location { get; set; }
        public byte Options { get; set; }
        public ushort FileVersion { get; set; }
    }
}