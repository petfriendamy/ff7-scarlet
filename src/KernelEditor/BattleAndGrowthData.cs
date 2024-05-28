using FF7Scarlet.AIEditor;
using FF7Scarlet.Shared;
using static System.Windows.Forms.AxHost;

namespace FF7Scarlet.KernelEditor
{
    public enum CurveStats
    {
        Strength, Vitality, Magic, Spirit, Dexterity, Luck, HP, MP, EXP
    }

    public class BattleAndGrowthData
    {
        public const int AI_BLOCK_SIZE = 2024, AI_BLOCK_COUNT = 12, STAT_CURVE_COUNT = 64,
            RNG_TABLE_SIZE = 256, LOOKUP_TABLE_SIZE = 64,
            MIN_STAT_MODIFIER = 1, MAX_STAT_MODIFIER = 8;
        private readonly CharacterGrowth[] characterGrowth = new CharacterGrowth[Character.PLAYABLE_CHARACTER_COUNT];
        private readonly byte[]
            randomBonusToPrimaryStats = new byte[12],
            randomBonusToHP = new byte[12],
            randomBonusToMP = new byte[12],
            rawAIdata = new byte[AI_BLOCK_SIZE],
            rngTable = new byte[RNG_TABLE_SIZE],
            sceneLookupTable = new byte[LOOKUP_TABLE_SIZE];
        private readonly StatCurve[] statCurves = new StatCurve[STAT_CURVE_COUNT];
        private ushort[] characterAIoffsets = new ushort[AI_BLOCK_COUNT];
        private readonly CharacterAI[] characterAI = new CharacterAI[AI_BLOCK_COUNT];
        private byte[] rawData = [];

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
        public StatCurve[] StatCurves
        {
            get { return statCurves; }
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
            ParseData(data, false);
        }

        public void ParseData(byte[] data, bool ignoreLookupTable)
        {
            rawData = data;
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
                for (i = 0; i < STAT_CURVE_COUNT; ++i)
                {
                    StatCurves[i] = new StatCurve(reader.ReadBytes(16));
                }
                for (i = 0; i < AI_BLOCK_COUNT; ++i)
                {
                    characterAIoffsets[i] = reader.ReadUInt16();
                }
                for (i = 0; i < AI_BLOCK_SIZE; ++i)
                {
                    rawAIdata[i] = reader.ReadByte();
                }
                for (i = 0; i < RNG_TABLE_SIZE; ++i)
                {
                    RNGTable[i] = reader.ReadByte();
                }
                if (ignoreLookupTable) //don't load the lookup table
                {
                    ms.Seek(LOOKUP_TABLE_SIZE, SeekOrigin.Current);
                }
                else
                {
                    for (i = 0; i < LOOKUP_TABLE_SIZE; ++i)
                    {
                        sceneLookupTable[i] = reader.ReadByte();
                    }
                }
                //spell order
            }
        }

        public int[] CalculateMinStats(int chara, int stat)
        {
            return CalcStats(chara, stat, MIN_STAT_MODIFIER);
        }

        public int[] CalculateMaxStats(int chara, int stat)
        {
            return CalcStats(chara, stat, MAX_STAT_MODIFIER);
        }

        private Character? GetCharacter(int chara)
        {
            var charStats = Parent.InitialData.Characters[chara];
            //grab Cait Sith/Vincent data from the EXE
            if (DataManager.ExeData != null)
            {
                if (chara == (int)CharacterNames.CaitSith)
                {
                    charStats = DataManager.ExeData.CaitSith;
                }
                else if (chara == (int)CharacterNames.Vincent)
                {
                    charStats = DataManager.ExeData.Vincent;
                }
            }
            return charStats;
        }

        private int GetBaseStat(Character chara, int stat)
        {
            switch ((CurveStats)stat) //get base stat
            {
                case CurveStats.Strength:
                    return chara.Strength;
                case CurveStats.Vitality:
                    return chara.Vitality;
                case CurveStats.Magic:
                    return chara.Magic;
                case CurveStats.Spirit:
                    return chara.Spirit;
                case CurveStats.Dexterity:
                    return chara.Dexterity;
                case CurveStats.Luck:
                    return chara.Luck;
                case CurveStats.HP:
                    return chara.BaseHP;
                case CurveStats.MP:
                    return chara.BaseMP;
                default:
                    return 0;
            }
        }

        private int GetBracket(int level)
        {
            if (level < 12) { return 0; }
            else if (level < 22) { return 1; }
            else if (level < 32) { return 2; }
            else if (level < 42) { return 3; }
            else if (level < 52) { return 4; }
            else if (level < 62) { return 5; }
            else if (level < 82) { return 6; }
            else { return 7; }
        }

        private int CalcStatGain(int chara, int level, int baseLevel, int stat, int prevStat,
            int rnd)
        {
            //thanks to DLPB for helping with these formulas!

            var s = (CurveStats)stat;
            int bracket = GetBracket(level);
            var curve = StatCurves[CharGrowth[chara].CurveIndex[stat]];

            //calculate the stat gain
            if (level <= baseLevel) //don't calc at start level
            {
                return 0;
            }
            else if (s == CurveStats.EXP) //special calc for EXP
            {
                return curve.Gradients[bracket] * ((level - 1) * (level - 1)) / 10;
            }
            else //everything else
            {
                int baseline = CalcBaseline(s, curve, level),
                    difference = CalcDifference(s, baseline, prevStat, rnd);

                if (s == CurveStats.HP)
                {
                    return (RandomBonusToHP[difference] * curve.Gradients[bracket]) / 100;
                }
                else if (s == CurveStats.MP)
                {
                    return RandomBonusToMP[difference] * ((level * curve.Gradients[bracket] / 10) -
                        ((level - 1) * curve.Gradients[bracket] / 10)) / 100;
                }
                else
                {
                    return RandomBonusToPrimaryStats[difference];
                }
            }
        }

        private int CalcBaseline(CurveStats stat, StatCurve curve, int level)
        {
            int bracket = GetBracket(level);
            if (stat == CurveStats.HP)
            {
                return (curve.Bases[bracket] * 40) + (level - 1) * curve.Gradients[bracket];
            }
            else if (stat == CurveStats.MP)
            {
                return (curve.Bases[bracket] * 2) + ((level - 1) * curve.Gradients[bracket] / 10);
            }
            else
            {
                return curve.Bases[bracket] + (curve.Gradients[bracket] * level / 100);
            }
        }

        private int CalcDifference(CurveStats stat, int baseline, int prevStat, int rnd)
        {
            int difference = 0;
            if (stat == CurveStats.HP || stat == CurveStats.MP)
            {
                difference = rnd + (100 * baseline / prevStat) - 100;
            }
            else
            {
                difference = rnd + baseline - prevStat;
            }
            if (difference < 0) { difference = 0; }
            if (difference > 11) { difference = 11; }
            return difference;
        }

        private int[] CalcStats(int chara, int stat, int modifier)
        {
            var stats = new int[99];
            var charStats = GetCharacter(chara);
            if (charStats == null)
            {
                throw new ArgumentException("Invalid character ID.");
            }
            int currStat = GetBaseStat(charStats, stat);
            var brackets = new int[8];

            for (int i = charStats.Level; i <= 99; ++i)
            {
                if (stat == (int)CurveStats.EXP)
                {
                    for (int j = 0; j < 8; ++j)
                    {
                        brackets[j] += CalcStatGain(chara, i, 1, stat, 0, 0);
                    }
                    currStat = brackets[GetBracket(i)];
                }
                else
                {
                    currStat += CalcStatGain(chara, i, charStats.Level, stat, currStat, modifier);
                    if (stat == (int)CurveStats.HP)
                    {
                        if (currStat > 9999) { currStat = 9999; }
                    }
                    else if (stat == (int)CurveStats.MP)
                    {
                        if (currStat > 999) { currStat = 999; }
                        
                    }
                    else if (currStat > 100) { currStat = 100; }
                }
                stats[i - 1] = currStat;
            }
            return stats;
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
                for (i = 0; i < STAT_CURVE_COUNT; ++i)
                {
                    writer.Write(StatCurves[i].GetRawData());
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
            var copy = new byte[rawData.Length];
            Array.Copy(rawData, copy, rawData.Length);
            return copy;
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
