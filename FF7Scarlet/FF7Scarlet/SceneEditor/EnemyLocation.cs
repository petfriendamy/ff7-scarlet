using System.Collections;

namespace FF7Scarlet.SceneEditor
{
    public class EnemyLocation
    {
        private bool[] coverFlags = new bool[16];

        public ushort EnemyID { get; set; }
        public Point3D Location { get; set; }
        public ushort Row { get; set; }
        public InitialConditions InitialConditionFlags { get; set; }
        public bool[] CoverFlags
        {
            get { return coverFlags; }
        }

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
                var temp = reader.ReadBytes(2);
                var array = new BitArray(temp);
                array.CopyTo(CoverFlags, 0);
                InitialConditionFlags = (InitialConditions)reader.ReadUInt32();
            }
        }
    }
}
