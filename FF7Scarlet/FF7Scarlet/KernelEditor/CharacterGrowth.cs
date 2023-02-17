using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.KernelEditor
{
    public class CharacterGrowth
    {
        private readonly byte[,] limitCommands = new byte[4,3];
        private readonly ushort[,] usesForLimit = new ushort[3,2];
        private readonly uint[] limitHPDivisor = new uint[4];

        public byte StrengthLevelUpCurve { get; set; }
        public byte VitalityLevelUpCurve { get; set; }
        public byte MagicLevelUpCurve { get; set; }
        public byte SpiritLevelUpCurve { get; set; }
        public byte DexterityLevelUpCurve { get; set; }
        public byte LuckLevelUpCurve { get; set; }
        public byte HPLevelUpCurve { get; set; }
        public byte MPLevelUpCurve { get; set; }
        public byte EXPLevelUpCurve { get; set; }
        public byte StartingLevel { get; set; }
        public ushort KillsForLimitLv2 { get; set; }
        public ushort KillsForLimitLv3 { get; set; }
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
                StrengthLevelUpCurve = reader.ReadByte();
                VitalityLevelUpCurve = reader.ReadByte();
                MagicLevelUpCurve = reader.ReadByte();
                SpiritLevelUpCurve = reader.ReadByte();
                DexterityLevelUpCurve = reader.ReadByte();
                LuckLevelUpCurve = reader.ReadByte();
                HPLevelUpCurve = reader.ReadByte();
                MPLevelUpCurve = reader.ReadByte();
                EXPLevelUpCurve = reader.ReadByte();
                reader.ReadByte(); //padding
                StartingLevel = reader.ReadByte();
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
    }
}
