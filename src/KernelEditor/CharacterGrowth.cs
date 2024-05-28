namespace FF7Scarlet.KernelEditor
{
    public class CharacterGrowth
    {
        public const int DATA_LENGTH = 56;
        private readonly byte[] curveIndexes = new byte[9];
        private readonly byte[,] limitCommands = new byte[4,3];
        private readonly ushort[,] usesForLimit = new ushort[3,2];
        private readonly uint[] limitHPDivisor = new uint[4];

        public sbyte RecruitLevelOffset { get; set; }
        public ushort KillsForLimitLv2 { get; set; }
        public ushort KillsForLimitLv3 { get; set; }
        public bool IsYuffie { get; }
        public byte[] CurveIndex
        {
            get { return curveIndexes; }
        }
        public byte[,] LimitCommands
        {
            get { return limitCommands; }
        }
        public ushort[,] UsesForLimit
        {
            get { return usesForLimit; }
        }
        public uint[] LimitHPDivisor
        {
            get { return limitHPDivisor; }
        }

        public CharacterGrowth(byte[] data)
        {
            int i, j;
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                for (i = 0; i < 9; ++i)
                {
                    CurveIndex[i] = reader.ReadByte();
                }
                reader.ReadByte(); //padding
                sbyte temp = reader.ReadSByte();
                RecruitLevelOffset = (sbyte)(temp / 2);
                IsYuffie = (temp % 2 != 0);
                reader.ReadByte(); //more padding

                for (i = 0; i < 4; ++i)
                {
                    for (j = 0; j < 3; ++j)
                    {
                        LimitCommands[i,j] = reader.ReadByte();
                    }
                }

                KillsForLimitLv2 = reader.ReadUInt16();
                KillsForLimitLv3 = reader.ReadUInt16();

                for (i = 0; i < 3; ++i)
                {
                    for (j = 0; j < 2; ++j)
                    {
                        UsesForLimit[i,j] = reader.ReadUInt16();
                    }
                }

                for (i = 0; i < 4; ++i)
                {
                    LimitHPDivisor[i] = reader.ReadUInt32();
                }
            }
        }

        public byte[] GetRawData()
        {
            var bytes = new byte[DATA_LENGTH];
            int i, j;
            using (var ms = new MemoryStream(bytes))
            using (var writer = new BinaryWriter(ms))
            {
                for (i = 0; i < 9; ++i)
                {
                    writer.Write(CurveIndex[i]);
                }
                writer.Write((byte)0xFF);
                if (IsYuffie)
                {
                    writer.Write((byte)1);
                }
                else
                {
                    writer.Write((sbyte)(RecruitLevelOffset * 2));
                }
                writer.Write((byte)0xFF);

                for (i = 0; i < 4; ++i)
                {
                    for (j = 0; j < 3; ++j)
                    {
                        writer.Write(LimitCommands[i, j]);
                    }
                }

                writer.Write(KillsForLimitLv2);
                writer.Write(KillsForLimitLv3);

                for (i = 0; i < 3; ++i)
                {
                    for (j = 0; j < 2; ++j)
                    {
                        writer.Write(UsesForLimit[i, j]);
                    }
                }

                for (i = 0; i < 4; ++i)
                {
                    writer.Write(LimitHPDivisor[i]);
                }
            }
            return bytes;
        }
    }
}
