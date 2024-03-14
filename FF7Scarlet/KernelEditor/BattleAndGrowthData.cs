using FF7Scarlet.AIEditor;
using FF7Scarlet.SceneEditor;
using FF7Scarlet.Shared;
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
        private ushort[] characterAIoffsets = new ushort[AI_BLOCK_COUNT];
        private readonly CharacterAI[] characterAI = new CharacterAI[AI_BLOCK_COUNT];
        private byte[] rawData;

        public Kernel Parent { get; }
        public CharacterGrowth[] CharGrowth
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

        public BattleAndGrowthData(Kernel parent, byte[] data)
        {
            Parent = parent;
            rawData = data.ToArray();

            int i;
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                for (i = 0; i < Character.PLAYABLE_CHARACTER_COUNT; ++i)
                {
                    CharGrowth[i] = new CharacterGrowth(reader.ReadBytes(CharacterGrowth.DATA_LENGTH));
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

        public byte[] GetRawData()
        {
            int i;
            using (var ms = new MemoryStream(rawData))
            using (var writer = new BinaryWriter(ms))
            {
                for (i = 0; i < Character.PLAYABLE_CHARACTER_COUNT; ++i)
                {
                    writer.Write(CharGrowth[i].GetRawData());
                }
                for (i = 0; i < 12; ++i)
                {
                    writer.Write(RandomBonusToPrimaryStats[i]);
                }
                for (i = 0; i < 12; ++i)
                {
                    writer.Write(RandomBonusToHP[i]);
                }
                for (i = 0; i < 12; ++i)
                {
                    writer.Write(RandomBonusToMP[i]);
                }
                for (i = 0; i < 37; ++i)
                {
                    writer.Write(PrimaryStatCurves[i].GetRawData());
                }
                for (i = 0; i < 9; ++i)
                {
                    writer.Write(HPStatCurves[i].GetRawData());
                }
                for (i = 0; i < 9; ++i)
                {
                    writer.Write(MPStatCurves[i].GetRawData());
                }
                for (i = 0; i < 9; ++i)
                {
                    writer.Write(EXPStatCurves[i].GetRawData());
                }

                //write AI data
                try
                {
                    if (ScriptsLoaded) //don't update scripts if not loaded
                    {
                        Array.Copy(AIContainer.GetGroupedScriptBlock(AI_BLOCK_COUNT, AI_BLOCK_SIZE,
                            characterAI, ref characterAIoffsets), rawAIdata, AI_BLOCK_SIZE);
                    }
                    foreach (var o in characterAIoffsets)
                    {
                        writer.Write(o);
                    }
                    writer.Write(rawAIdata);
                }
                catch (ScriptTooLongException)
                {
                    throw new ScriptTooLongException("Character A.I. block is too long!");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Compiler error in A.I. scripts: {ex.Message}");
                }

                writer.Write(rngTable);
                writer.Write(sceneLookupTable);
            }
            return rawData;
        }

        public void ParseAIScripts()
        {
            int i, j, next;

            for (i = 0; i < AI_BLOCK_COUNT; ++i)
            {
                characterAI[i] = new CharacterAI(Parent);
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

        public byte[] CopyLookupTable()
        {
            var table = new byte[64];
            Array.Copy(sceneLookupTable, table, 64);
            return table;
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
