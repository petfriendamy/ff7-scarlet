using Shojy.FF7.Elena;

namespace FF7Scarlet.KernelEditor
{
    public class BattleAndGrowthData
    {
        public const int AI_BLOCK_SIZE = 2024, AI_BLOCK_COUNT = 12;
        private readonly CharacterGrowth[] characterGrowth = new CharacterGrowth[Character.PLAYABLE_CHARACTER_COUNT];
        private readonly byte[]
            randomBonusToPrimaryStats = new byte[12],
            randomBonusToHP = new byte[12],
            randomBonusToMP = new byte[12],
            rawAIdata = new byte[AI_BLOCK_SIZE],
            rngTable = new byte[256],
            sceneLookupTable = new byte[64];
        private readonly StatCurve[]
            primaryStatCurves = new StatCurve[37],
            hpStatCurves = new StatCurve[9],
            mpStatCurves = new StatCurve[9],
            expStatCurves = new StatCurve[9];
        private readonly ushort[] characterAIoffsets = new ushort[AI_BLOCK_COUNT];
        private readonly CharacterAI[] characterAI = new CharacterAI[AI_BLOCK_COUNT];

        public CharacterGrowth[] CharacterGrowth
        {
            get { return characterGrowth; }
        }
        public byte[] RandomBonusToPrimaryStats
        {
            get { return randomBonusToPrimaryStats; }
        }
        public byte[] RandomBonusToHP
        {
            get { return randomBonusToHP; }
        }
        public byte[] RandomBonusToMP
        {
            get { return randomBonusToMP; }
        }
        public StatCurve[] PrimaryStatCurves
        {
            get { return primaryStatCurves; }
        }
        public StatCurve[] HPStatCurves
        {
            get { return hpStatCurves; }
        }
        public StatCurve[] MPStatCurves
        {
            get { return mpStatCurves; }
        }
        public StatCurve[] EXPStatCurves
        {
            get { return expStatCurves; }
        }
        public byte[] RNGTable
        {
            get { return rngTable; }
        }
        public CharacterAI[] CharacterAI
        {
            get { return characterAI; }
        }
        public bool ScriptsLoaded { get; private set; } = false;

        public BattleAndGrowthData(byte[] data)
        {
            int i;
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                for (i = 0; i < Character.PLAYABLE_CHARACTER_COUNT; ++i)
                {
                    CharacterGrowth[i] = new CharacterGrowth(reader.ReadBytes(56));
                }
                for (i = 0; i < 12; ++i)
                {
                    RandomBonusToPrimaryStats[i] = reader.ReadByte();
                }
                for (i = 0; i < 12; ++i)
                {
                    RandomBonusToHP[i] = reader.ReadByte();
                }
                for (i = 0; i < 12; ++i)
                {
                    RandomBonusToMP[i] = reader.ReadByte();
                }
                for (i = 0; i < 37; ++i)
                {
                    PrimaryStatCurves[i] = new StatCurve(reader.ReadBytes(16));
                }
                for (i = 0; i < 9; ++i)
                {
                    HPStatCurves[i] = new StatCurve(reader.ReadBytes(16));
                }
                for (i = 0; i < 9; ++i)
                {
                    MPStatCurves[i] = new StatCurve(reader.ReadBytes(16));
                }
                for (i = 0; i < 9; ++i)
                {
                    EXPStatCurves[i] = new StatCurve(reader.ReadBytes(16));
                }
                for (i = 0; i < AI_BLOCK_COUNT; ++i)
                {
                    characterAIoffsets[i] = reader.ReadUInt16();
                }
                rawAIdata = reader.ReadBytes(AI_BLOCK_SIZE);
                rngTable = reader.ReadBytes(256);
                sceneLookupTable = reader.ReadBytes(64);
                //spell order
            }
        }

        public void ParseAIScripts()
        {
            int i, j, next;

            for (i = 0; i < AI_BLOCK_COUNT; ++i)
            {
                characterAI[i] = new CharacterAI();
                if (characterAIoffsets[i] != HexParser.NULL_OFFSET_16_BIT)
                {
                    next = -1;
                    for (j = i + 1; j < AI_BLOCK_COUNT && next == -1; ++j)
                    {
                        if (characterAIoffsets[j] != HexParser.NULL_OFFSET_16_BIT)
                        {
                            next = characterAIoffsets[j];
                        }
                    }
                    characterAI[i].ParseScripts(rawAIdata, AI_BLOCK_COUNT * 2, characterAIoffsets[i], next);
                }
            }
            ScriptsLoaded = true;
        }

        public void UpdateLookupTable(byte[] table)
        {
            if (table.Length != 64)
            {
                throw new ArgumentException("Incorrect table length.");
            }
            for (int i = 0; i < 64; ++i)
            {
                sceneLookupTable[i] = table[i];
            }
        }
    }
}
