namespace FF7Scarlet.SceneEditor
{
    public class EnemyLocation
    {
        public ushort EnemyID { get; set; }
        public Point3D Location { get; set; }
        public ushort Row { get; set; }
        public ushort CoverFlags { get; set; }
        public uint InitialConditionFlags { get; set; }

        public EnemyLocation(byte[] data)
        {
            ushort x, y, z;
            using (var ms = new MemoryStream(data, false))
            using (var reader = new BinaryReader(ms))
            {
                EnemyID = reader.ReadUInt16();
                x = reader.ReadUInt16();
                y = reader.ReadUInt16();
                z = reader.ReadUInt16();
                Location = new Point3D(x, y, z);
                Row = reader.ReadUInt16();
                CoverFlags = reader.ReadUInt16();
                InitialConditionFlags = reader.ReadUInt32();
            }
        }
    }
}
