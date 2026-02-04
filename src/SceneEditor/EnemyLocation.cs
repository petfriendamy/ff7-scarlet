using FF7Scarlet.Shared;
using System.Collections;

namespace FF7Scarlet.SceneEditor
{
    public class EnemyLocation
    {
        public const int BLOCK_SIZE = 16;
        private bool[] coverFlags = new bool[16];

        public ushort EnemyID { get; set; } = HexParser.NULL_OFFSET_16_BIT;
        public Point3D Location { get; set; }
        public ushort Row { get; set; }
        public InitialConditions InitialConditionFlags { get; set; }
        public bool[] CoverFlags
        {
            get { return coverFlags; }
        }

        public EnemyLocation()
        {
            Location = new Point3D((HexParser.NULL_OFFSET_16_BIT_SIGNED), HexParser.NULL_OFFSET_16_BIT_SIGNED,
                HexParser.NULL_OFFSET_16_BIT_SIGNED);
        }

        public EnemyLocation(byte[] data)
        {
            short x, y, z;
            using (var ms = new MemoryStream(data, false))
            using (var reader = new BinaryReader(ms))
            {
                EnemyID = reader.ReadUInt16();
                x = reader.ReadInt16();
                y = reader.ReadInt16();
                z = reader.ReadInt16();
                Location = new Point3D(x, y, z);
                Row = reader.ReadUInt16();
                var temp = reader.ReadBytes(2);
                var array = new BitArray(temp);
                array.CopyTo(CoverFlags, 0);
                InitialConditionFlags = (InitialConditions)reader.ReadUInt32();
            }
        }

        public EnemyLocation(EnemyLocation other)
        {
            EnemyID = other.EnemyID;
            Location = other.Location;
            Row = other.Row;
            Array.Copy(other.CoverFlags, CoverFlags, CoverFlags.Length);
            InitialConditionFlags = other.InitialConditionFlags;
        }

        public byte[] GetRawData()
        {
            var data = new byte[BLOCK_SIZE];
            using (var ms = new MemoryStream(data, true))
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(EnemyID);
                writer.Write(Location.X);
                writer.Write(Location.Y);
                writer.Write(Location.Z);
                writer.Write(Row);
                var bits = new BitArray(CoverFlags);
                var bytes = new byte[2];
                bits.CopyTo(bytes, 0);
                foreach (var b in bytes)
                {
                    writer.Write(b);
                }
                writer.Write((uint)InitialConditionFlags);
            }
            return data;
        }
    }
}
