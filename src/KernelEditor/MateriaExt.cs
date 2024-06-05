using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Materias;
using System.Collections.ObjectModel;

namespace FF7Scarlet.KernelEditor
{
    public enum MateriaByteValues : byte
    {
        IndependentFunction = 0x00,
        IndependentStatBoost1 = 0x20,
        IndependentPreEmptive = 0x21,
        IndependentStatBoost2 = 0x41,
        IndependentLongRange = 0x30,
        IndependentMegaAll = 0x34,
        IndependentEXPPlus = 0x40,
        Support1 = 0x25,
        Support2 = 0x35,
        Magic = 0x19,
        Summon = 0x3B,
        CommandReplaceAttack = 0x12,
        CommandAdd = 0x16,
        CommandDouble = 0x33,
        CommandEnemySkill = 0x57,
        MasterMagic = 0x0A,
        MasterSummon = 0x0C,
        MasterCommand = 0x08
    }

    public enum MateriaStats : byte
    {
        Strength, Vitality, Magic, Spirit, Speed, Luck, Attack, Defense,
        MaxHP, MaxMP, EXP, CoverChance, CounterAttackChance = 83
    }

    public enum MateriaSpecialStats : byte
    {
        GilDropped, EncounterRate, ChocoboEncounterChance, PreEmptiveChance, EXPEarned = 10
    }

    public enum SupportMateriaTypes : byte
    {
        All = 0x51,
        CommandCounter = 0x54,
        MagicCounter = 0x55,
        SneakAttack = 0x56,
        FinalAttack = 0x57,
        MPTurbo = 0x58,
        MPAbsorb = 0x59,
        HPAbsorb = 0x5A,
        AddedCut = 0x5C,
        StealAsWell = 0x5D,
        Elemental = 0x5E,
        AddedEffect = 0x5F,
        MorphAsWell = 0x60,
        QuadraMagic = 0x63
    };

    public enum CommandMateriaTypes : byte
    {
        AddCommand,
        ReplaceAttack,
        EnemySkill = 0x0D,
        WMagic = 0x15,
        WSummon = 0x16,
        WItem = 0x17,
        Master
    }

    public enum IndependentMateriaTypes : byte
    {
        StatBonus,
        Underwater = 0x0C,
        LongRange = 0x50,
        MegaAll = 0x51,
        HPtoMP = 0x62
    }

    public class MateriaExt : Materia
    {
        public static ReadOnlyCollection<string> EQUIP_EFFECTS = new string[]
        {
            "None",
            "-2 STR, -1 VIT, +2 MAG, +1 SPR, -5% HP, +5% MP",
            "-4 STR, -2 VIT, +4 MAG, +2 SPR, -10% HP, -10% MP",
            "+2 DEX, -2 LUCK",
            "-1 STR, -1 VIT, +1 MAG, +1 SPR",
            "+1 STR, +1 VIT, -1 MAG, -1 SPR",
            "+1 VIT",
            "+1 LUCK",
            "-1 LUCK",
            "-2 DEX",
            "+2 DEX",
            "-1 STR, +1 MAG, -2% HP, +2% MP",
            "+1 MAG, -2% HP, +2% MP",
            "+1 MAG, +1 SPR, -5% HP, +5% MP",
            "+2 MAG, +2 SPR, -10% HP, +10% MP",
            "+4 MAG, +4 SPR, -10% HP, +15% MP",
            "+8 MAG, +8 SPR, -10% HP, +20% MP",
        }.AsReadOnly();

        public static ReadOnlyDictionary<CommandMateriaTypes, string> COMMAND_TYPES = new Dictionary<CommandMateriaTypes, string>
        {
            { CommandMateriaTypes.AddCommand, "Add a command" },
            { CommandMateriaTypes.ReplaceAttack, "Replace Attack command" },
            { CommandMateriaTypes.EnemySkill, "Enemy Skill" },
            { CommandMateriaTypes.WMagic, "W-Magic" },
            { CommandMateriaTypes.WSummon, "W-Summon" },
            { CommandMateriaTypes.WItem, "W-Item" },
            { CommandMateriaTypes.Master, "Master Command" }
        }.AsReadOnly();

        public const int ATTRIBUTE_COUNT = 6, MAX_AP = HexParser.NULL_OFFSET_16_BIT * 100;
        public new MateriaType MateriaType { get; private set; }
        public byte MateriaTypeByte { get; private set; }
        public byte[] Attributes { get; }


        public byte BaseType
        {
            get
            {
                return HexParser.GetLowerNybble(MateriaTypeByte);
            }
        }

        public byte SubType
        {
            get
            {
                return HexParser.GetUpperNybble(MateriaTypeByte);
            }
        }

        public bool IsMaster
        {
            get
            {
                var type = (MateriaByteValues)MateriaTypeByte;
                return (type == MateriaByteValues.MasterMagic || type == MateriaByteValues.MasterSummon
                    || type == MateriaByteValues.MasterCommand);
            }
        }

        public bool HasEditableAttributes
        {
            get
            {
                if (IsMaster) { return false; }
                else if (MateriaType == MateriaType.Command)
                {
                    if (BaseType != 2 && BaseType != 6) { return false; }
                }
                else if (MateriaType == MateriaType.Independent)
                {
                    if (MateriaTypeByte == 0 || SubType == 3) { return false; }
                }
                return true;
            }
        }

        public MateriaExt(byte[] data)
        {
            Attributes = new byte[ATTRIBUTE_COUNT];
            int i;

            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                Level2AP = reader.ReadUInt16() * 100;
                Level3AP = reader.ReadUInt16() * 100;
                Level4AP = reader.ReadUInt16() * 100;
                Level5AP = reader.ReadUInt16() * 100;
                EquipEffect = reader.ReadByte();

                var temp = reader.ReadBytes(3);
                var convert = new byte[4];
                Array.Copy(temp, convert, 3);
                Status = (Statuses)BitConverter.ToInt32(convert, 0);

                Element = (MateriaElements)reader.ReadByte();
                MateriaTypeByte = reader.ReadByte();
                MateriaType = GetMateriaType(MateriaTypeByte);

                for (i = 0; i < ATTRIBUTE_COUNT; ++i)
                {
                    Attributes[i] = reader.ReadByte();
                }
            }
        }

        public int GetMaxLevel()
        {
            int level = 1;
            if (Level2AP < MAX_AP) { level++; }
            if (Level3AP < MAX_AP) { level++; }
            if (Level4AP < MAX_AP) { level++; }
            if (Level5AP < MAX_AP) { level++; }
            return level;
        }

        public int GetSubtypeIndex()
        {
            var independentTypes = Enum.GetValues<IndependentMateriaTypes>().ToList();
            var commandTypes = COMMAND_TYPES.Keys.ToList();

            switch ((MateriaByteValues)MateriaTypeByte)
            {
                case MateriaByteValues.IndependentFunction:
                    return independentTypes.IndexOf((IndependentMateriaTypes)Attributes[0]);

                case MateriaByteValues.IndependentStatBoost1:
                case MateriaByteValues.IndependentPreEmptive:
                case MateriaByteValues.IndependentStatBoost2:
                    return independentTypes.IndexOf(IndependentMateriaTypes.StatBonus);

                case MateriaByteValues.IndependentLongRange:
                    return independentTypes.IndexOf(IndependentMateriaTypes.LongRange);

                case MateriaByteValues.IndependentMegaAll:
                    return independentTypes.IndexOf(IndependentMateriaTypes.MegaAll);

                case MateriaByteValues.IndependentEXPPlus:
                    return independentTypes.IndexOf(IndependentMateriaTypes.StatBonus);

                case MateriaByteValues.CommandReplaceAttack:
                    return commandTypes.IndexOf(CommandMateriaTypes.ReplaceAttack);

                case MateriaByteValues.CommandAdd:
                    return commandTypes.IndexOf(CommandMateriaTypes.AddCommand);

                case MateriaByteValues.CommandEnemySkill:
                    return commandTypes.IndexOf(CommandMateriaTypes.EnemySkill);

                case MateriaByteValues.CommandDouble:
                    return commandTypes.IndexOf((CommandMateriaTypes)Attributes[0]);

                case MateriaByteValues.MasterCommand:
                    return commandTypes.IndexOf(CommandMateriaTypes.Master);

                case MateriaByteValues.Magic:
                case MateriaByteValues.Summon:
                case MateriaByteValues.Support1:
                case MateriaByteValues.Support2:
                    return 0;

                case MateriaByteValues.MasterMagic:
                case MateriaByteValues.MasterSummon:
                    return 1;
            }

            return -1;
        }

        public void SetMateriaType(MateriaType type)
        {
            if (type != MateriaType)
            {
                //reset all attributes to defaults
                MateriaType = type;
                for (byte i = 0; i < ATTRIBUTE_COUNT; ++i)
                {
                    if (type == MateriaType.Summon && i > 0) //always 1-5
                    {
                        Attributes[i] = i;
                    }
                    else
                    {
                        Attributes[i] = 0xFF;
                    }
                }

                switch (type)
                {
                    case MateriaType.Independent:
                        MateriaTypeByte = (byte)MateriaByteValues.IndependentStatBoost1;
                        break;
                    case MateriaType.Support:
                        MateriaTypeByte = (byte)MateriaByteValues.Support1;
                        break;
                    case MateriaType.Magic:
                        MateriaTypeByte = (byte)MateriaByteValues.Magic;
                        break;
                    case MateriaType.Summon:
                        MateriaTypeByte = (byte)MateriaByteValues.Summon;
                        break;
                    case MateriaType.Command:
                        MateriaTypeByte = (byte)MateriaByteValues.CommandAdd;
                        break;
                }
            }
            
        }

        public void SetMateriaSubtype(MateriaStats stats)
        {
            SetMateriaType(MateriaType.Independent);
            MateriaTypeByte = (byte)MateriaByteValues.IndependentStatBoost1;
            Attributes[0] = (byte)stats;
        }

        public void SetMateriaSubtype(MateriaSpecialStats stats)
        {
            SetMateriaType(MateriaType.Independent);
            switch (stats)
            {
                case MateriaSpecialStats.PreEmptiveChance:
                    MateriaTypeByte = (byte)MateriaByteValues.IndependentPreEmptive;
                    break;

                case MateriaSpecialStats.EXPEarned:
                    MateriaTypeByte = (byte)MateriaByteValues.IndependentEXPPlus;
                    break;

                default:
                    MateriaTypeByte = (byte)MateriaByteValues.IndependentStatBoost2;
                    break;
            }
            Attributes[0] = (byte)stats;
        }

        public void SetMateriaSubtype(SupportMateriaTypes type)
        {
            SetMateriaType(MateriaType.Support);
            if (type == SupportMateriaTypes.All || type == SupportMateriaTypes.FinalAttack ||
                type == SupportMateriaTypes.QuadraMagic)
            {
                MateriaTypeByte = (byte)MateriaByteValues.Support2;
            }
            else
            {
                MateriaTypeByte = (byte)MateriaByteValues.Support1;
            }
            Attributes[0] = (byte)type;
        }

        public void SetMateriaSubtype(CommandMateriaTypes type)
        {
            MateriaType = MateriaType.Command;
            int i;
            for (i = 0; i < ATTRIBUTE_COUNT; ++i) //clear all attributes
            {
                Attributes[i] = 0xFF;
            }

            switch (type)
            {
                case CommandMateriaTypes.AddCommand:
                    MateriaTypeByte = (byte)MateriaByteValues.CommandAdd;
                    break;

                case CommandMateriaTypes.ReplaceAttack:
                    MateriaTypeByte = (byte)MateriaByteValues.CommandReplaceAttack;
                    break;

                case CommandMateriaTypes.EnemySkill:
                    MateriaTypeByte = (byte)MateriaByteValues.CommandEnemySkill;
                    Attributes[0] = (byte)CommandMateriaTypes.EnemySkill;
                    break;

                case CommandMateriaTypes.WMagic:
                case CommandMateriaTypes.WSummon:
                case CommandMateriaTypes.WItem:
                    MateriaTypeByte = (byte)MateriaByteValues.CommandDouble;
                    Attributes[0] = (byte)type;
                    break;

                case CommandMateriaTypes.Master:
                    SetMaster(true);
                    break;
            }
        }

        public void SetMateriaSubtype(IndependentMateriaTypes type)
        {
            MateriaType = MateriaType.Independent;
            Attributes[0] = (byte)type;
            byte i;

            if (type != IndependentMateriaTypes.StatBonus && type != IndependentMateriaTypes.MegaAll)
            {
                for (i = 1; i < ATTRIBUTE_COUNT; ++i) //clear all attributes
                {
                    Attributes[i] = 0xFF;
                }
            }

            switch (type)
            {
                case IndependentMateriaTypes.StatBonus:
                    SetMateriaSubtype((MateriaStats)0xFF);
                    break;

                case IndependentMateriaTypes.Underwater:
                case IndependentMateriaTypes.HPtoMP:
                    MateriaTypeByte = (byte)MateriaByteValues.IndependentFunction;
                    break;

                case IndependentMateriaTypes.LongRange:
                    MateriaTypeByte = (byte)MateriaByteValues.IndependentLongRange;
                    break;

                case IndependentMateriaTypes.MegaAll:
                    MateriaTypeByte = (byte)MateriaByteValues.IndependentMegaAll;
                    for (i = 1; i < ATTRIBUTE_COUNT; ++i) //1-5
                    {
                        Attributes[i] = i;
                    }
                    break;
            }
        }

        public void SetMaster(bool isMaster)
        {
            switch (MateriaType)
            {
                case MateriaType.Command:
                    if (isMaster) { MateriaTypeByte = (byte)MateriaByteValues.MasterCommand; }
                    else { throw new ArgumentException("Unclear command type."); }
                    break;

                case MateriaType.Magic:
                    if (isMaster) { MateriaTypeByte = (byte)MateriaByteValues.MasterMagic; }
                    else { MateriaTypeByte = (byte)MateriaByteValues.Magic; }
                    break;

                case MateriaType.Summon:
                    if (isMaster) { MateriaTypeByte = (byte)MateriaByteValues.MasterSummon; }
                    else { MateriaTypeByte = (byte)MateriaByteValues.Summon; }
                    break;

                default:
                    if (isMaster)
                    {
                        throw new ArgumentException("Invalid materia type.");
                    }
                    break;
            }
        }
    }
}
