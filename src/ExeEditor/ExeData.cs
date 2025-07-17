using FF7Scarlet.KernelEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Characters;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace FF7Scarlet.ExeEditor
{
    public enum Language { English, Spanish, French, German }

    public struct MultiStringLength
    {
        public readonly int Length;
        public readonly int Count;

        public MultiStringLength(int length, int count)
        {
            Length = length;
            Count = count;
        }
    }

    public class ExeData
    {
        //constants
        private static readonly int[] EXE_HEADER = { 0x4D, 0x5A, 0x90 };
        public const string
            CONFIG_KEY = "ExePath",
            VANILLA_CONFIG_KEY = "VanillaExePath";

        public static readonly MultiStringLength[] BATTLE_ARENA_TEXT_LENGTHS =
        {
            new MultiStringLength(16, 1),
            new MultiStringLength(24, 1),
            new MultiStringLength(22, 4),
            new MultiStringLength(32, 25),
            new MultiStringLength(34, 3)
        };
        public const int
            NUM_MENU_TEXTS = 23,
            NUM_ITEM_MENU_TEXTS = 11,
            NUM_MAGIC_MENU_TEXTS = 14,
            NUM_EQUIP_MENU_TEXTS = 23,
            NUM_MATERIA_MENU_TEXTS = 42,
            NUM_UNEQUIP_TEXTS = 4,
            NUM_CONFIG_MENU_TEXTS = 51,
            NUM_QUIT_TEXTS_1 = 3,
            NUM_QUIT_TEXTS_2 = 2,
            NUM_ELEMENTS = 9,
            NUM_STATUS_EFFECTS = 27,
            NUM_STATUS_MENU_TEXTS = 27,
            NUM_LIMIT_MENU_TEXTS = 14,
            NUM_SAVE_MENU_TEXTS = 36,
            NUM_LIMITS = 71,
            NUM_BIZARRO_MENU_TEXTS = 6,
            NUM_CHARACTER_NAMES = 10,
            NUM_SHOPS = 80,
            NUM_SHOP_NAMES = 9,
            NUM_SHOP_TEXTS = 18,
            NUM_CHOCOBO_NAMES = 46,
            NUM_CHOCOBO_RACE_ITEMS = 24,
            NUM_AUDIO_VALUES = 128,
            NUM_WALKABILITY_MODELS = 12,
            
            MENU_TEXT_LENGTH = 20,
            ITEM_MENU_TEXT_LENGTH = 12,
            EQUIP_MENU_TEXT_LENGTH = 12,
            UNEQUIP_TEXT_LENGTH = 36,
            ELEMENT_NAME_LENGTH = 10,
            STATUS_MENU_TEXT_LENGTH = 15,
            LIMIT_MENU_TEXT_LENGTH = 36,
            SAVE_MENU_TEXT_LENGTH = 36,
            QUIT_TEXT_LENGTH_1 = 30,
            QUIT_TEXT_LENGTH_2 = 4,
            SHOP_TEXT_LENGTH = 46,
            BIZARRO_MENU_TEXT_LENGTH = 38,
            CHOCOBO_NAME_LENGTH = 7,
            ITEM_NAME_LENGTH = 16;

        private const long
            HEXT_OFFSET_TEXT = 0x400C00,
            HEXT_OFFSET_DATA = 0x401600,
            DATA_SECTION_START = 0x3B8A00,

            TEST_BYTE_POS = 0x94,
            AP_MULTIPLIER_POS = 0x31F14F,
            AP_MASTER_OFFSET = 0x4F,
            MATERIA_EQUIP_EFFECT_POS = 0x4FD8C8,
            QUIT_TEXT_POS_1 = 0x518370,
            QUIT_TEXT_POS_2 = 0x5183D0,
            CONFIG_MENU_TEXT_POS = 0x5188A8,
            MAIN_MENU_TEXT_POS = 0x5192C0,
            STATUS_EFFECT_BATTLE_POS = 0x51D228,
            BATTLE_ARENA_TEXT_POS = 0x51D588,
            BIZARRO_MENU_TEXT_POS = 0x51DB40,
            LIMIT_MENU_TEXT_POS = 0x51DED8,
            LIMIT_BREAK_POS = 0x51E0D4,
            STATUS_MENU_ELEMENT_POS = 0x51EF40,
            STATUS_MENU_EFFECTS_POS = 0x51EFA0,
            STATUS_MENU_TEXT_POS = 0x51F1C0,
            EQUIP_MENU_TEXT_POS = 0x51F3A8,
            UNEQUIP_TEXT_POS = 0x51F518,
            MATERIA_MENU_TEXT_POS = 0x51F5A8,
            MAGIC_MENU_TEXT_POS = 0x51F9E8,
            ITEM_MENU_TEXT_POS = 0x51FB68,
            LIMIT_TEXT_POS = 0x51FBF0,
            ITEM_SORT_POS = 0x51FF48,
            MATERIA_PRIORITY_POS = 0x5201C8,
            NAME_DATA_POS = 0x5206B8,
            CAIT_SITH_DATA_POS = 0x520C10,
            VINCENT_DATA_POS = CAIT_SITH_DATA_POS + DataParser.CHARACTER_RECORD_LENGTH,
            SHOP_NAME_POS = 0x5219C8,
            SHOP_TEXT_POS = 0x521A80,
            SHOP_INVENTORY_POS = 0x521E18,
            ITEM_PRICE_DATA_POS = 0x523858,
            MATERIA_PRICE_DATA_POS = 0x523E58,
            SAVE_MENU_TEXT_POS = 0x524160,
            AUDIO_VOLUME_POS = 0x566060,
            AUDIO_PAN_POS = 0x566260,
            TEIOH_POS = 0x57B2A8,
            CHOCOBO_RACE_ITEMS_POS = 0x57B3D0,
            CHOCOBO_NAMES_POS = 0x57B658;

        private static readonly int[] MODEL_CAN_WALK_POS = { 0x34c356, 0, 0x34c383, 0x34c4cc, 0x34c57e, 0x34c5c9, 0x568440, 0x568444, 0x568448, 0x56844c, 0x568450, 0x34bbdb };
        private static readonly int[] MODEL_CAN_DISEMBARK_POS = { 0, 0x34c45f, 0x34c3c1, 0x34c518, 0x34c54c, 0x34c59a, 0x34c3ec, 0x34c3ec, 0x34c3ec, 0x34c3ec, 0x34c3ec, 0 };
        private static readonly int[] MODEL_CAN_WALK_TINY_BRONCO_ADDITIONAL_POS = { 0x34c4f3, 0x34c52d };

        //properties
        public string FilePath { get; private set; } = string.Empty;
        public Language Language { get; private set; }
        public Attack[] Limits { get; } = new Attack[NUM_LIMITS];
        public MateriaEquipEffect[] MateriaEquipEffects { get; } = new MateriaEquipEffect[MateriaEquipEffect.COUNT];
        public FFText[] LimitSuccess { get; } = new FFText[Kernel.PLAYABLE_CHARACTER_COUNT - 1];
        public FFText[] LimitFail { get; } = new FFText[Kernel.PLAYABLE_CHARACTER_COUNT - 1];
        public FFText[] LimitWrong { get; } = new FFText[Kernel.PLAYABLE_CHARACTER_COUNT];
        public FFText[] MainMenuTexts { get; } = new FFText[NUM_MENU_TEXTS];
        public FFText[] ItemMenuTexts { get; } = new FFText[NUM_ITEM_MENU_TEXTS];
        public FFText[] MagicMenuTexts { get; } = new FFText[NUM_MAGIC_MENU_TEXTS];
        public FFText[] MateriaMenuTexts { get; } = new FFText[NUM_MATERIA_MENU_TEXTS];
        public FFText[] UnequipTexts { get; } = new FFText[NUM_UNEQUIP_TEXTS];
        public FFText[] EquipMenuTexts { get; } = new FFText[NUM_EQUIP_MENU_TEXTS];
        public FFText[] ElementNames { get; } = new FFText[NUM_ELEMENTS];
        public FFText[] StatusEffectsBattle { get; } = new FFText[NUM_STATUS_EFFECTS];
        public FFText[] StatusEffectsMenu { get; } = new FFText[NUM_STATUS_EFFECTS];
        public FFText[] StatusMenuTexts { get; } = new FFText[NUM_STATUS_MENU_TEXTS];
        public FFText[] LimitMenuTexts { get; } = new FFText[NUM_LIMIT_MENU_TEXTS];
        public FFText[] ConfigMenuTexts { get; } = new FFText[NUM_CONFIG_MENU_TEXTS];
        public FFText[] SaveMenuTexts { get; } = new FFText[NUM_SAVE_MENU_TEXTS];
        public FFText[] QuitMenuTexts { get; } = new FFText[NUM_QUIT_TEXTS_1 + NUM_QUIT_TEXTS_2];
        public FFText[] BattleArenaTexts { get; }
        public FFText[] BizarroMenuTexts { get; } = new FFText[NUM_BIZARRO_MENU_TEXTS];
        public FFText[] CharacterNames { get; } = new FFText[NUM_CHARACTER_NAMES];
        public FFText[] ChocoboNames { get; } = new FFText[NUM_CHOCOBO_NAMES + 1]; //extra slot for Teioh
        public FFText[] ChocoboRacePrizes { get; } = new FFText[NUM_CHOCOBO_RACE_ITEMS];
        public Character? CaitSith { get; private set; }
        public Character? Vincent { get; private set; }
        public FFText[] ShopNames { get; } = new FFText[NUM_SHOP_NAMES];
        public FFText[] ShopText { get; } = new FFText[NUM_SHOP_TEXTS];
        public ShopInventory[] Shops { get; } = new ShopInventory[NUM_SHOPS];
        public byte APPriceMultiplier { get; set; }
        public uint[] ItemPrices { get; } = new uint[DataParser.ITEM_COUNT];
        public uint[] WeaponPrices { get; } = new uint[DataParser.WEAPON_COUNT];
        public uint[] ArmorPrices { get; } = new uint[DataParser.ARMOR_COUNT];
        public uint[] AccessoryPrices { get; } = new uint[DataParser.ACCESSORY_COUNT];
        public uint[] MateriaPrices { get; } = new uint[Kernel.MATERIA_COUNT];
        public Dictionary<ushort, ushort> ItemsSortedByName { get; } = new();
        public Dictionary<byte, byte> MateriaPriority { get; } = new();
        public int[] AudioVolume { get; } = new int[NUM_AUDIO_VALUES];
        public int[] AudioPan { get; } = new int[NUM_AUDIO_VALUES];
        public BitArray[] ModelMoveBitmasks { get; } = new BitArray[NUM_WALKABILITY_MODELS];
        public BitArray[] ModelDisembarkBitmasks{ get; } = new BitArray[NUM_WALKABILITY_MODELS];
        public bool IsUnedited { get; private set; }


        public ExeData(string path)
        {
            BattleArenaTexts = new FFText[GetNumBattleArenaTexts()];
            ReadEXE(path);

            //make chocobos use the same bitmask
            int i = (int)WorldMapModels.YellowChocobo, j = i;
            while (j < (int)WorldMapModels.GoldChocobo)
            {
                ModelDisembarkBitmasks[j] = ModelDisembarkBitmasks[(int)WorldMapModels.WildChocobo];
                j++;
            }
        }

        private long GetAPPriceMultiplierOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x8B6E2;
                case Language.French:
                    return 0x8B365;
                case Language.German:
                    return 0x8B017;
                default:
                    return 0;
            }
        }

        private long GetConfigOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x77240;
                case Language.French:
                    return 0x770B8;
                case Language.German:
                    return 0x76C48;
                default:
                    return 0;
            }
        }

        private long GetMainMenuOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x776D0;
                case Language.French:
                    return 0x774E0;
                case Language.German:
                    return 0x76DA8;
                default:
                    return 0;
            }
        }

        private long GetStatusOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x776E8;
                case Language.French:
                    return 0x775F8;
                case Language.German:
                    return 0x76E68;
                default:
                    return 0;
            }
        }

        private long GetLimitOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x779D8;
                case Language.French:
                    return 0x777C0;
                case Language.German:
                    return 0x76EB8;
                default:
                    return 0;
            }
        }

        private long GetLimitTextOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x78050;
                case Language.French:
                    return 0x77BE8;
                case Language.German:
                    return 0x772E0;
                default:
                    return 0;
            }
        }

        private long GetNameOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x780E0;
                case Language.French:
                    return 0x77E70;
                case Language.German:
                    return 0x77370;
                default:
                    return 0;
            }
        }

        private long GetCaitOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x78110;
                case Language.French:
                    return 0x77E90;
                case Language.German:
                    return 0x77388;
                default:
                    return 0;
            }
        }

        private long GetShopNameOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x783F0;
                case Language.French:
                    return 0x780B8;
                case Language.German:
                    return 0x77650;
                default:
                    return 0;
            }
        }

        private long GetShopTextOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x784A0;
                case Language.French:
                    return 0x78730;
                case Language.German:
                    return 0x77700;
                default:
                    return 0;
            }
        }

        private long GetShopOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x784A0;
                case Language.French:
                    return 0x78A10;
                case Language.German:
                    return 0x77700;
                default:
                    return 0;
            }
        }

        public int GetConfigTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 70;
                case Language.French:
                    return 60;
                case Language.German:
                    return 54;
                default:
                    return 48;
            }
        }

        public int GetStatusEffectBattleLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 12;
                case Language.French:
                    return 20;
                case Language.German:
                    return 14;
                default:
                    return 10;
            }
        }

        public int GetLimitTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                case Language.German:
                    return 40;
                case Language.French:
                    return 60;
                default:
                    return 34;
            }
        }

        public static int GetNumBattleArenaTexts()
        {
            int temp = 0;
            foreach (var l in BATTLE_ARENA_TEXT_LENGTHS)
            {
                temp += l.Count;
            }
            return temp;
        }

        public int GetShopNameLength()
        {
            int length = ShopData.SHOP_NAME_LENGTH;
            if (Language == Language.Spanish || Language == Language.German)
            {
                length *= 2;
            }
            return length;
        }

        public static bool ValidateEXE(string path, bool unedited)
        {
            if (File.Exists(path))
            {
                if (unedited) //this should be an unedited EXE, so do a hash check
                {
                    return HashCheck(path);
                }
                else
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    using (var reader = new BinaryReader(stream))
                    {
                        //check if header is correct
                        for (int i = 0; i < EXE_HEADER.Length; ++i)
                        {
                            if (reader.ReadByte() != EXE_HEADER[i])
                            {
                                return false;
                            }
                        }

                        //test a certain byte (this is different in 1.00)
                        stream.Seek(TEST_BYTE_POS, SeekOrigin.Begin);
                        if (reader.ReadByte() != 5)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool HashCheck(string path)
        {
            byte[] compare = SHA1.HashData(File.ReadAllBytes(path)), hash;

            if (GetLanguage(path) == Language.English) //only English version supported
            {
                if (IsSteamVersion(path)) //Steam version
                {
                    hash = Convert.FromHexString("1C9A6F4B6F554B1B4ECB38812F9396A026A677D6");
                    return hash.SequenceEqual(compare);
                }
                else //1998 version
                {
                    //1.02
                    hash = Convert.FromHexString("684A0E87840138B4E02FC8EDB9AE2E2591CE4982");
                    if (hash.SequenceEqual(compare)) { return true; }

                    //1.02 4GB patch
                    hash = Convert.FromHexString("141822081B3F24EA70BE35D59449E0CA098881E3");
                    return hash.SequenceEqual(compare);
                }
            }
            return false;
        }

        public static Language GetLanguage(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            //check EXE language
            string name = Path.GetFileNameWithoutExtension(path);
            if (name.EndsWith("_es"))
            {
                return Language.Spanish;
            }
            else if (name.EndsWith("_fr"))
            {
                return Language.French;
            }
            else if (name.EndsWith("_de"))
            {
                return Language.German;
            }
            else
            {
                return Language.English;
            }
        }

        public static string GetLanguageCode(string path)
        {
            var lang = GetLanguage(path);
            switch (lang)
            {
                case Language.Spanish:
                    return "es";
                case Language.French:
                    return "fr";
                case Language.German:
                    return "de";
                default:
                    return "en";
            }
        }

        public static bool IsSteamVersion(string path)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            return fileName.Contains('_');
        }

        public void ReadEXE(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    Language = GetLanguage(path);
                    IsUnedited = HashCheck(path);

                    //attempt to open and read the EXE
                    int i;
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    using (var reader = new BinaryReader(stream))
                    {
                        //check if header is correct
                        if (!ValidateEXE(path, false))
                        {
                            throw new FormatException("EXE appears to be invalid.");
                        }

                        //English only stuff (for now)
                        if (Language == Language.English)
                        {
                            //get walkability data
                            for (i = 0; i < NUM_WALKABILITY_MODELS; i++)
                            {
                                if (MODEL_CAN_WALK_POS[i] > 0)
                                {
                                    stream.Seek(MODEL_CAN_WALK_POS[i], SeekOrigin.Begin);
                                    int temp = reader.ReadInt32();
                                    var bytes = BitConverter.GetBytes(temp);
                                    ModelMoveBitmasks[i] = new BitArray(bytes);
                                }
                                if (MODEL_CAN_DISEMBARK_POS[i] > 0 && i < (int)WorldMapModels.YellowChocobo)
                                {
                                    stream.Seek(MODEL_CAN_DISEMBARK_POS[i], SeekOrigin.Begin);
                                    int temp = reader.ReadInt32();
                                    var bytes = BitConverter.GetBytes(temp);
                                    ModelDisembarkBitmasks[i] = new BitArray(bytes);
                                }
                            }

                            //get materia equip effects
                            stream.Seek(MATERIA_EQUIP_EFFECT_POS, SeekOrigin.Begin);
                            for (i = 0; i < MateriaEquipEffect.COUNT; ++i)
                            {
                                MateriaEquipEffects[i] = new MateriaEquipEffect(reader.ReadBytes(MateriaEquipEffect.DATA_LENGTH));
                            }

                            //get quit menu text
                            stream.Seek(QUIT_TEXT_POS_1, SeekOrigin.Begin);
                            for (i = 0; i < NUM_QUIT_TEXTS_1; ++i)
                            {
                                QuitMenuTexts[i] = new FFText(reader.ReadBytes(QUIT_TEXT_LENGTH_1));
                            }
                            stream.Seek(QUIT_TEXT_POS_2, SeekOrigin.Begin);
                            for (i = 0; i < NUM_QUIT_TEXTS_2; ++i)
                            {
                                QuitMenuTexts[i + NUM_QUIT_TEXTS_1] = new FFText(reader.ReadBytes(QUIT_TEXT_LENGTH_2));
                            }

                            //get element names
                            stream.Seek(STATUS_MENU_ELEMENT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_ELEMENTS; ++i)
                            {
                                ElementNames[i] = new FFText(reader.ReadBytes(ELEMENT_NAME_LENGTH));
                            }

                            //get status effects (stats menu)
                            stream.Seek(STATUS_MENU_EFFECTS_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_STATUS_EFFECTS; ++i)
                            {
                                StatusEffectsMenu[i] = new FFText(reader.ReadBytes(MENU_TEXT_LENGTH));
                            }

                            //get battle arena text
                            stream.Seek(BATTLE_ARENA_TEXT_POS, SeekOrigin.Begin);
                            int curr = 0;
                            for (i = 0; i < BATTLE_ARENA_TEXT_LENGTHS.Length; ++i)
                            {
                                for (int j = 0; j < BATTLE_ARENA_TEXT_LENGTHS[i].Count; ++j)
                                {
                                    BattleArenaTexts[curr] = new FFText(reader.ReadBytes(BATTLE_ARENA_TEXT_LENGTHS[i].Length));
                                    curr++;
                                }
                            }

                            //get Bizarro menu text
                            stream.Seek(BIZARRO_MENU_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_BIZARRO_MENU_TEXTS; ++i)
                            {
                                BizarroMenuTexts[i] = new FFText(reader.ReadBytes(BIZARRO_MENU_TEXT_LENGTH));
                            }

                            //get limit menu text
                            stream.Seek(LIMIT_MENU_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_LIMIT_MENU_TEXTS; ++i)
                            {
                                LimitMenuTexts[i] = new FFText(reader.ReadBytes(LIMIT_MENU_TEXT_LENGTH));
                            }

                            //get status menu text
                            stream.Seek(STATUS_MENU_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_STATUS_MENU_TEXTS; ++i)
                            {
                                StatusMenuTexts[i] = new FFText(reader.ReadBytes(STATUS_MENU_TEXT_LENGTH));
                            }

                            //get equip menu text
                            stream.Seek(EQUIP_MENU_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_EQUIP_MENU_TEXTS; ++i)
                            {
                                EquipMenuTexts[i] = new FFText(reader.ReadBytes(EQUIP_MENU_TEXT_LENGTH));
                            }

                            //get unequip text
                            stream.Seek(UNEQUIP_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_UNEQUIP_TEXTS; ++i)
                            {
                                UnequipTexts[i] = new FFText(reader.ReadBytes(UNEQUIP_TEXT_LENGTH));
                            }

                            //get materia menu text
                            stream.Seek(MATERIA_MENU_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_MATERIA_MENU_TEXTS; ++i)
                            {
                                MateriaMenuTexts[i] = new FFText(reader.ReadBytes(MENU_TEXT_LENGTH));
                            }

                            //get magic menu text
                            stream.Seek(MAGIC_MENU_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_MAGIC_MENU_TEXTS; ++i)
                            {
                                MagicMenuTexts[i] = new FFText(reader.ReadBytes(MENU_TEXT_LENGTH));
                            }

                            //get item menu text
                            stream.Seek(ITEM_MENU_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_ITEM_MENU_TEXTS; ++i)
                            {
                                ItemMenuTexts[i] = new FFText(reader.ReadBytes(ITEM_MENU_TEXT_LENGTH));
                            }

                            //get item sort values
                            stream.Seek(ITEM_SORT_POS, SeekOrigin.Begin);
                            for (i = 0; i < DataParser.MATERIA_START; ++i)
                            {
                                ItemsSortedByName.Add((ushort)i, reader.ReadUInt16());
                            }

                            //get materia priority values
                            stream.Seek(MATERIA_PRIORITY_POS, SeekOrigin.Begin);
                            for (i = 0; i < DataParser.MATERIA_COUNT; ++i)
                            {
                                MateriaPriority.Add((byte)i, reader.ReadByte());
                            }

                            //get save menu text
                            stream.Seek(SAVE_MENU_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_SAVE_MENU_TEXTS; ++i)
                            {
                                SaveMenuTexts[i] = new FFText(reader.ReadBytes(SAVE_MENU_TEXT_LENGTH));
                            }

                            //get audio volume
                            stream.Seek(AUDIO_VOLUME_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_AUDIO_VALUES; ++i)
                            {
                                AudioVolume[i] = reader.ReadInt32();
                            }

                            //get audio pan
                            stream.Seek(AUDIO_PAN_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_AUDIO_VALUES; ++i)
                            {
                                AudioPan[i] = reader.ReadInt32();
                            }

                            //get Teioh's name
                            stream.Seek(TEIOH_POS, SeekOrigin.Begin);
                            ChocoboNames[NUM_CHOCOBO_NAMES] = new FFText(reader.ReadBytes(CHOCOBO_NAME_LENGTH));

                            //get chocobo race prizes
                            stream.Seek(CHOCOBO_RACE_ITEMS_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_CHOCOBO_RACE_ITEMS; ++i)
                            {
                                ChocoboRacePrizes[i] = new FFText(reader.ReadBytes(ITEM_NAME_LENGTH));
                            }

                            //get other chocobo names
                            stream.Seek(CHOCOBO_NAMES_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_CHOCOBO_NAMES; ++i)
                            {
                                ChocoboNames[i] = new FFText(reader.ReadBytes(CHOCOBO_NAME_LENGTH));
                            }
                        }

                        //get AP multiplier
                        stream.Seek(AP_MULTIPLIER_POS + GetAPPriceMultiplierOffset(), SeekOrigin.Begin);
                        APPriceMultiplier = reader.ReadByte();

                        //get config menu text
                        stream.Seek(CONFIG_MENU_TEXT_POS + GetConfigOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_CONFIG_MENU_TEXTS; ++i)
                        {
                            ConfigMenuTexts[i] = new FFText(reader.ReadBytes(GetConfigTextLength()));
                        }

                        //get main menu text
                        stream.Seek(MAIN_MENU_TEXT_POS + GetMainMenuOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_MENU_TEXTS; ++i)
                        {
                            MainMenuTexts[i] = new FFText(reader.ReadBytes(MENU_TEXT_LENGTH));
                        }

                        //get status effects (in-battle)
                        stream.Seek(STATUS_EFFECT_BATTLE_POS + GetStatusOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_STATUS_EFFECTS; ++i)
                        {
                            StatusEffectsBattle[i] = new FFText(reader.ReadBytes(GetStatusEffectBattleLength()));
                        }

                        //get limit breaks
                        stream.Seek(LIMIT_BREAK_POS + GetLimitOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_LIMITS; ++i)
                        {
                            Limits[i] = DataParser.ReadAttack((ushort)i, $"(Limit #{i})", reader.ReadBytes(DataParser.ATTACK_BLOCK_SIZE));
                        }

                        //get L4 limit text
                        stream.Seek(LIMIT_TEXT_POS + GetLimitTextOffset(), SeekOrigin.Begin);
                        for (i = 0; i < Kernel.PLAYABLE_CHARACTER_COUNT - 1; ++i)
                        {
                            LimitSuccess[i] = new FFText(reader.ReadBytes(GetLimitTextLength()));
                            LimitFail[i] = new FFText(reader.ReadBytes(GetLimitTextLength()));
                            LimitWrong[i] = new FFText(reader.ReadBytes(GetLimitTextLength()));
                        }
                        LimitWrong[Kernel.PLAYABLE_CHARACTER_COUNT - 1] =
                            new FFText(reader.ReadBytes(GetLimitTextLength()));

                        //get character names
                        stream.Seek(NAME_DATA_POS + GetNameOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_CHARACTER_NAMES; ++i)
                        {
                            CharacterNames[i] = new FFText(reader.ReadBytes(DataParser.CHARACTER_NAME_LENGTH));
                        }

                        //get Cait Sith + Vincent data
                        stream.Seek(CAIT_SITH_DATA_POS + GetCaitOffset(), SeekOrigin.Begin);
                        CaitSith = DataParser.ReadCharacter(reader.ReadBytes(DataParser.CHARACTER_RECORD_LENGTH));
                        Vincent = DataParser.ReadCharacter(reader.ReadBytes(DataParser.CHARACTER_RECORD_LENGTH));

                        //get shop names
                        stream.Seek(SHOP_NAME_POS + GetShopNameOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_SHOP_NAMES; ++i)
                        {
                            ShopNames[i] = new FFText(reader.ReadBytes(GetShopNameLength()));
                        }

                        //get shop texts
                        stream.Seek(SHOP_TEXT_POS + GetShopTextOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_SHOP_TEXTS; ++i)
                        {
                            ShopText[i] = new FFText(reader.ReadBytes(SHOP_TEXT_LENGTH));
                        }

                        //get shop inventories
                        stream.Seek(SHOP_INVENTORY_POS + GetShopOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_SHOPS; ++i)
                        {
                            Shops[i] = new ShopInventory(reader.ReadBytes(ShopInventory.SHOP_DATA_LENGTH));
                        }

                        //get item prices
                        stream.Seek(ITEM_PRICE_DATA_POS + GetShopOffset(), SeekOrigin.Begin);
                        for (i = 0; i < ItemPrices.Length; ++i)
                        {
                            ItemPrices[i] = reader.ReadUInt32();
                        }
                        for (i = 0; i < WeaponPrices.Length; ++i)
                        {
                            WeaponPrices[i] = reader.ReadUInt32();
                        }
                        for (i = 0; i < ArmorPrices.Length; ++i)
                        {
                            ArmorPrices[i] = reader.ReadUInt32();
                        }
                        for (i = 0; i < AccessoryPrices.Length; ++i)
                        {
                            AccessoryPrices[i] = reader.ReadUInt32();
                        }

                        //get materia prices
                        stream.Seek(MATERIA_PRICE_DATA_POS + GetShopOffset(), SeekOrigin.Begin);
                        for (i = 0; i < MateriaPrices.Length; ++i)
                        {
                            MateriaPrices[i] = reader.ReadUInt32();
                        }
                    }
                    FilePath = path;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void WriteEXE(string? path = null)
        {
            if (path == null)
            {
                path = FilePath;
            }

            if (File.Exists(path))
            {
                try
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Write))
                    using (var writer = new BinaryWriter(stream))
                    {
                        //English-only stuff (for now)
                        if (Language == Language.English)
                        {
                            //write walkability data
                            for (int i = 0; i < NUM_WALKABILITY_MODELS; i++)
                            {
                                if (ModelMoveBitmasks[i] != null)
                                {
                                    stream.Seek(MODEL_CAN_WALK_POS[i], SeekOrigin.Begin);
                                    var temp = new byte[4];
                                    ModelMoveBitmasks[i].CopyTo(temp, 0);
                                    writer.Write(temp);

                                    if ((WorldMapModels)i == WorldMapModels.TinyBronco) //additional bitmasks
                                    {
                                        foreach (var p in MODEL_CAN_WALK_TINY_BRONCO_ADDITIONAL_POS)
                                        {
                                            stream.Seek(p, SeekOrigin.Begin);
                                            writer.Write(temp);
                                        }
                                    }
                                }
                                if (ModelDisembarkBitmasks[i] != null)
                                {
                                    stream.Seek(MODEL_CAN_DISEMBARK_POS[i], SeekOrigin.Begin);
                                    var temp = new byte[4];
                                    ModelDisembarkBitmasks[i].CopyTo(temp, 0);
                                    writer.Write(temp);
                                }
                            }

                            //write materia equip effects
                            stream.Seek(MATERIA_EQUIP_EFFECT_POS, SeekOrigin.Begin);
                            foreach (var e in MateriaEquipEffects)
                            {
                                writer.Write(e.GetBytes());
                            }

                            //write quit text
                            stream.Seek(QUIT_TEXT_POS_1, SeekOrigin.Begin);
                            for (int i = 0; i < NUM_QUIT_TEXTS_1; ++i)
                            {
                                writer.Write(QuitMenuTexts[i].GetBytes(QUIT_TEXT_LENGTH_1, false, true));
                            }
                            stream.Seek(QUIT_TEXT_POS_2, SeekOrigin.Begin);
                            for (int i = 0; i < NUM_QUIT_TEXTS_2; ++i)
                            {
                                writer.Write(QuitMenuTexts[i + NUM_QUIT_TEXTS_1].GetBytes(QUIT_TEXT_LENGTH_2,
                                    false, true));
                            }

                            //write element names
                            stream.Seek(STATUS_MENU_ELEMENT_POS, SeekOrigin.Begin);
                            foreach (var n in ElementNames)
                            {
                                writer.Write(n.GetBytes(ELEMENT_NAME_LENGTH, false, true));
                            }

                            //write status effects (menu)
                            stream.Seek(STATUS_MENU_EFFECTS_POS, SeekOrigin.Begin);
                            foreach (var t in StatusEffectsMenu)
                            {
                                writer.Write(t.GetBytes(MENU_TEXT_LENGTH, false, true));
                            }

                            //write battle arena text
                            stream.Seek(BATTLE_ARENA_TEXT_POS, SeekOrigin.Begin);
                            int curr = 0;
                            for (int i = 0; i < BATTLE_ARENA_TEXT_LENGTHS.Length; ++i)
                            {
                                for (int j = 0; j < BATTLE_ARENA_TEXT_LENGTHS[i].Count; ++j)
                                {
                                    writer.Write(BattleArenaTexts[curr].GetBytes(BATTLE_ARENA_TEXT_LENGTHS[i].Length,
                                        false, true));
                                    curr++;
                                }
                            }

                            //write Bizarro menu text
                            stream.Seek(BIZARRO_MENU_TEXT_POS, SeekOrigin.Begin);
                            foreach (var t in BizarroMenuTexts)
                            {
                                writer.Write(t.GetBytes(BIZARRO_MENU_TEXT_LENGTH, false, true));
                            }

                            //write limit menu text
                            stream.Seek(LIMIT_MENU_TEXT_POS, SeekOrigin.Begin);
                            foreach (var t in LimitMenuTexts)
                            {
                                writer.Write(t.GetBytes(LIMIT_MENU_TEXT_LENGTH, false, true));
                            }

                            //write status menu text
                            stream.Seek(STATUS_MENU_TEXT_POS, SeekOrigin.Begin);
                            foreach (var t in StatusMenuTexts)
                            {
                                writer.Write(t.GetBytes(STATUS_MENU_TEXT_LENGTH, false, true));
                            }

                            //write equip menu text
                            stream.Seek(EQUIP_MENU_TEXT_POS, SeekOrigin.Begin);
                            foreach (var t in EquipMenuTexts)
                            {
                                writer.Write(t.GetBytes(EQUIP_MENU_TEXT_LENGTH, false, true));
                            }

                            //write unequip text
                            stream.Seek(UNEQUIP_TEXT_POS, SeekOrigin.Begin);
                            foreach (var t in UnequipTexts)
                            {
                                writer.Write(t.GetBytes(UNEQUIP_TEXT_LENGTH, false, true));
                            }

                            //write materia menu text
                            stream.Seek(MATERIA_MENU_TEXT_POS, SeekOrigin.Begin);
                            foreach (var t in MateriaMenuTexts)
                            {
                                writer.Write(t.GetBytes(MENU_TEXT_LENGTH, false, true));
                            }

                            //write magic menu text
                            stream.Seek(MAGIC_MENU_TEXT_POS, SeekOrigin.Begin);
                            foreach (var t in MagicMenuTexts)
                            {
                                writer.Write(t.GetBytes(MENU_TEXT_LENGTH, false, true));
                            }

                            //write item menu text
                            stream.Seek(ITEM_MENU_TEXT_POS, SeekOrigin.Begin);
                            foreach (var t in ItemMenuTexts)
                            {
                                writer.Write(t.GetBytes(ITEM_MENU_TEXT_LENGTH, false, true));
                            }

                            //write item sort values
                            stream.Seek(ITEM_SORT_POS, SeekOrigin.Begin);
                            foreach (var i in ItemsSortedByName)
                            {
                                writer.Write(i.Value);
                            }

                            //write item sort list
                            stream.Seek(ITEM_SORT_POS, SeekOrigin.Begin);
                            var itemPositions =
                                from item in ItemsSortedByName
                                orderby item.Key
                                select item.Value;
                            foreach (var p in itemPositions)
                            {
                                writer.Write(p);
                            }

                            //write materia priority list
                            stream.Seek(MATERIA_PRIORITY_POS, SeekOrigin.Begin);
                            var materiaPositions =
                                from mat in MateriaPriority
                                orderby mat.Key
                                select mat.Value;
                            foreach (var p in materiaPositions)
                            {
                                writer.Write(p);
                            }

                            //write save menu text
                            stream.Seek(SAVE_MENU_TEXT_POS, SeekOrigin.Begin);
                            foreach (var s in SaveMenuTexts)
                            {
                                writer.Write(s.GetBytes(SAVE_MENU_TEXT_LENGTH, false, true));
                            }

                            //write audio volume
                            stream.Seek(AUDIO_VOLUME_POS, SeekOrigin.Begin);
                            foreach (var a in AudioVolume)
                            {
                                writer.Write(BitConverter.GetBytes(a));
                            }

                            //write audio pan
                            stream.Seek(AUDIO_PAN_POS, SeekOrigin.Begin);
                            foreach (var a in AudioPan)
                            {
                                writer.Write(BitConverter.GetBytes(a));
                            }

                            //write Teioh's name
                            stream.Seek(TEIOH_POS, SeekOrigin.Begin);
                            writer.Write(ChocoboNames[NUM_CHOCOBO_NAMES].GetBytes(CHOCOBO_NAME_LENGTH));

                            //write chocobo race prizes
                            stream.Seek(CHOCOBO_RACE_ITEMS_POS, SeekOrigin.Begin);
                            foreach (var t in ChocoboRacePrizes)
                            {
                                writer.Write(t.GetBytes(ITEM_NAME_LENGTH));
                            }

                            //write chocobo names (besides Teioh)
                            stream.Seek(CHOCOBO_NAMES_POS, SeekOrigin.Begin);
                            for (int i = 0; i < NUM_CHOCOBO_NAMES - 1; ++i)
                            {
                                writer.Write(ChocoboNames[i].GetBytes(CHOCOBO_NAME_LENGTH, true));
                            }
                        }

                        //write AP multiplier
                        stream.Seek(AP_MULTIPLIER_POS + GetAPPriceMultiplierOffset(), SeekOrigin.Begin);
                        writer.Write(APPriceMultiplier);
                        stream.Seek(AP_MULTIPLIER_POS + AP_MASTER_OFFSET + GetAPPriceMultiplierOffset(),
                            SeekOrigin.Begin);
                        writer.Write(APPriceMultiplier);

                        //write config menu text
                        stream.Seek(CONFIG_MENU_TEXT_POS + GetConfigOffset(), SeekOrigin.Begin);
                        foreach (var t in ConfigMenuTexts)
                        {
                            writer.Write(t.GetBytes(GetConfigTextLength(), false, true));
                        }

                        //write main menu text
                        stream.Seek(MAIN_MENU_TEXT_POS + GetMainMenuOffset(), SeekOrigin.Begin);
                        foreach (var t in MainMenuTexts)
                        {
                            writer.Write(t.GetBytes(MENU_TEXT_LENGTH, false, true));
                        }

                        //write status effects
                        stream.Seek(STATUS_EFFECT_BATTLE_POS + GetStatusOffset(), SeekOrigin.Begin);
                        foreach (var s in StatusEffectsBattle)
                        {
                            writer.Write(s.GetBytes(GetStatusEffectBattleLength(), false, true));
                        }

                        //write limit breaks
                        stream.Seek(LIMIT_BREAK_POS + GetLimitOffset(), SeekOrigin.Begin);
                        foreach (var l in Limits)
                        {
                            writer.Write(DataParser.GetAttackBytes(l));
                        }

                        //write L4 limit text
                        stream.Seek(LIMIT_TEXT_POS + GetLimitTextOffset(), SeekOrigin.Begin);
                        for (int i = 0; i < Kernel.PLAYABLE_CHARACTER_COUNT; ++i)
                        {
                            if (i < Kernel.PLAYABLE_CHARACTER_COUNT - 1)
                            {
                                writer.Write(LimitSuccess[i].GetBytes(GetLimitTextLength(), false, true));
                                writer.Write(LimitFail[i].GetBytes(GetLimitTextLength(), false, true));
                            }
                            writer.Write(LimitWrong[i].GetBytes(GetLimitTextLength(), false, true));
                        }

                        //write character names
                        stream.Seek(NAME_DATA_POS + GetNameOffset(), SeekOrigin.Begin);
                        foreach (var n in CharacterNames)
                        {
                            writer.Write(n.GetBytes(DataParser.CHARACTER_NAME_LENGTH, false, true));
                        }

                        //write Cait Sith/Vincent data
                        if (CaitSith != null && Vincent != null)
                        {
                            stream.Seek(CAIT_SITH_DATA_POS + GetCaitOffset(), SeekOrigin.Begin);
                            writer.Write(DataParser.GetCharacterInitialDataBytes(CaitSith));
                            writer.Write(DataParser.GetCharacterInitialDataBytes(Vincent));
                        }

                        //write shop names
                        stream.Seek(SHOP_NAME_POS + GetShopNameOffset(), SeekOrigin.Begin);
                        foreach (var n in ShopNames)
                        {
                            writer.Write(n.GetBytes(GetShopNameLength(), false, true));
                        }

                        //write shop text
                        stream.Seek(SHOP_TEXT_POS + GetShopTextOffset(), SeekOrigin.Begin);
                        foreach (var t in ShopText)
                        {
                            writer.Write(t.GetBytes(SHOP_TEXT_LENGTH, false, true));
                        }

                        if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
                        {
                            //write shop inventories
                            stream.Seek(SHOP_INVENTORY_POS + GetShopOffset(), SeekOrigin.Begin);
                            foreach (var s in Shops)
                            {
                                writer.Write(s.GetByteArray());
                            }

                            //write item prices
                            stream.Seek(ITEM_PRICE_DATA_POS + GetShopOffset(), SeekOrigin.Begin);
                            foreach (var i in ItemPrices)
                            {
                                writer.Write(i);
                            }
                            foreach (var p in WeaponPrices)
                            {
                                writer.Write(p);
                            }
                            foreach (var p in ArmorPrices)
                            {
                                writer.Write(p);
                            }
                            foreach (var p in AccessoryPrices)
                            {
                                writer.Write(p);
                            }

                            //write materia prices
                            stream.Seek(MATERIA_PRICE_DATA_POS + GetShopOffset(), SeekOrigin.Begin);
                            foreach (var p in MateriaPrices)
                            {
                                writer.Write(p);
                            }
                        }
                    }
                    IsUnedited = true;
                }
                catch (Exception ex)
                {
                    throw new IOException("There was a problem editing the EXE.", ex);
                }
            }
        }

        //read data from a byte array
        public void ReadBytes(byte[] bytes)
        {
            try
            {
                int i;
                using (var stream = new MemoryStream(bytes))
                using (var reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);

                    //read character names
                    for (i = 0; i < NUM_CHARACTER_NAMES; ++i)
                    {
                        CharacterNames[i] = new FFText(reader.ReadBytes(DataParser.CHARACTER_NAME_LENGTH));
                    }

                    //read character data
                    CaitSith = DataParser.ReadCharacter(reader.ReadBytes(DataParser.CHARACTER_RECORD_LENGTH));
                    Vincent = DataParser.ReadCharacter(reader.ReadBytes(DataParser.CHARACTER_RECORD_LENGTH));

                    //read item prices
                    APPriceMultiplier = reader.ReadByte();
                    for (i = 0; i < ItemPrices.Length; ++i)
                    {
                        ItemPrices[i] = reader.ReadUInt32();
                    }
                    for (i = 0; i < WeaponPrices.Length; ++i)
                    {
                        WeaponPrices[i] = reader.ReadUInt32();
                    }
                    for (i = 0; i < ArmorPrices.Length; ++i)
                    {
                        ArmorPrices[i] = reader.ReadUInt32();
                    }
                    for (i = 0; i < AccessoryPrices.Length; ++i)
                    {
                        AccessoryPrices[i] = reader.ReadUInt32();
                    }
                    for (i = 0; i < MateriaPrices.Length; ++i)
                    {
                        MateriaPrices[i] = reader.ReadUInt32();
                    }

                    //read shop inventories
                    for (i = 0; i < NUM_SHOPS; ++i)
                    {
                        Shops[i] = new ShopInventory(reader.ReadBytes(ShopInventory.SHOP_DATA_LENGTH));
                    }

                    //read limits
                    for (i = 0; i < NUM_LIMITS; ++i)
                    {
                        DataParser.ReadAttack((ushort)i, $"(Limit #{i})", reader.ReadBytes(DataParser.ATTACK_BLOCK_SIZE));
                    }

                    //read main menu text
                    for (i = 0; i < NUM_MENU_TEXTS; ++i)
                    {
                        MainMenuTexts[i] = new FFText(reader.ReadBytes(MENU_TEXT_LENGTH));
                    }

                    //read config menu text
                    for (i = 0; i < NUM_CONFIG_MENU_TEXTS; ++i)
                    {
                        ConfigMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetConfigTextLength());
                        stream.Seek(ConfigMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                    }

                    //read status effects
                    for (i = 0; i < NUM_STATUS_EFFECTS; ++i)
                    {
                        StatusEffectsBattle[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetStatusEffectBattleLength());
                        stream.Seek(StatusEffectsBattle[i].ToString().Length + 1, SeekOrigin.Current);
                    }

                    //read shop names
                    for (i = 0; i < NUM_SHOP_NAMES; ++i)
                    {
                        ShopNames[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetShopNameLength());
                        stream.Seek(ShopNames[i].ToString().Length + 1, SeekOrigin.Current);
                    }

                    //read shop texts
                    for (i = 0; i < NUM_SHOP_TEXTS; ++i)
                    {
                        ShopText[i] = new FFText(reader.ReadBytes(SHOP_TEXT_LENGTH));
                    }

                    //read L4 success text
                    for (i = 0; i < Kernel.PLAYABLE_CHARACTER_COUNT - 1; ++i)
                    {
                        LimitSuccess[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetLimitTextLength());
                        stream.Seek(LimitSuccess[i].ToString().Length + 1, SeekOrigin.Current);
                    }

                    //read L4 fail text
                    for (i = 0; i < Kernel.PLAYABLE_CHARACTER_COUNT - 1; ++i)
                    {
                        LimitFail[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetLimitTextLength());
                        stream.Seek(LimitFail[i].ToString().Length + 1, SeekOrigin.Current);
                    }

                    //read L4 wrong text
                    for (i = 0; i < Kernel.PLAYABLE_CHARACTER_COUNT; ++i)
                    {
                        LimitWrong[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetLimitTextLength());
                        stream.Seek(LimitWrong[i].ToString().Length + 1, SeekOrigin.Current);
                    }

                    //English-only stuff (for now)
                    if (Language == Language.English)
                    {
                        //read item sort list
                        for (i = 0; i < DataParser.MATERIA_START; ++i)
                        {
                            ItemsSortedByName[(ushort)i] = reader.ReadUInt16();
                        }

                        //read materia priority list
                        for (i = 0; i < DataParser.MATERIA_COUNT; ++i)
                        {
                            MateriaPriority[(byte)i] = reader.ReadByte();
                        }

                        //read materia menu text
                        for (i = 0; i < NUM_MATERIA_MENU_TEXTS; ++i)
                        {
                            MateriaMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                MENU_TEXT_LENGTH);
                            stream.Seek(MateriaMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read equip menu text
                        for (i = 0; i < NUM_EQUIP_MENU_TEXTS; ++i)
                        {
                            EquipMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                EQUIP_MENU_TEXT_LENGTH);
                            stream.Seek(EquipMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read element names
                        for (i = 0; i < NUM_ELEMENTS; ++i)
                        {
                            ElementNames[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                ELEMENT_NAME_LENGTH);
                            stream.Seek(ElementNames[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read status effects (menu)
                        for (i = 0; i < NUM_STATUS_EFFECTS; ++i)
                        {
                            StatusEffectsMenu[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                MENU_TEXT_LENGTH);
                            stream.Seek(StatusEffectsMenu[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read status menu text
                        for (i = 0; i < NUM_STATUS_MENU_TEXTS; ++i)
                        {
                            StatusMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                STATUS_MENU_TEXT_LENGTH);
                            stream.Seek(StatusMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read chocobo names
                        for (i = 0; i < NUM_CHOCOBO_NAMES + 1; ++i)
                        {
                            ChocoboNames[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                CHOCOBO_NAME_LENGTH);
                            stream.Seek(CHOCOBO_NAME_LENGTH, SeekOrigin.Current);
                        }

                        //read item names
                        for (i = 0; i < NUM_CHOCOBO_RACE_ITEMS; ++i)
                        {
                            ChocoboRacePrizes[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                ITEM_NAME_LENGTH);
                            stream.Seek(ITEM_NAME_LENGTH, SeekOrigin.Current);
                        }

                        //read item menu text
                        for (i = 0; i < NUM_ITEM_MENU_TEXTS; ++i)
                        {
                            ItemMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                ITEM_MENU_TEXT_LENGTH);
                            stream.Seek(ItemMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read magic menu text
                        for (i = 0; i < NUM_MAGIC_MENU_TEXTS; ++i)
                        {
                            MagicMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                MENU_TEXT_LENGTH);
                            stream.Seek(MagicMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read unequip text
                        for (i = 0; i < NUM_UNEQUIP_TEXTS; ++i)
                        {
                            UnequipTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                UNEQUIP_TEXT_LENGTH);
                            stream.Seek(UnequipTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read limit menu text
                        for (i = 0; i < NUM_LIMIT_MENU_TEXTS; ++i)
                        {
                            LimitMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                LIMIT_MENU_TEXT_LENGTH);
                            stream.Seek(LimitMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read save menu text
                        for (i = 0; i < NUM_SAVE_MENU_TEXTS; ++i)
                        {
                            SaveMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                SAVE_MENU_TEXT_LENGTH);
                            stream.Seek(SaveMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read quit text
                        for (i = 0; i < NUM_QUIT_TEXTS_1 + NUM_QUIT_TEXTS_2; ++i)
                        {
                            SaveMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                SAVE_MENU_TEXT_LENGTH);
                            stream.Seek(SaveMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read battle arena text
                        int curr = 0;
                        for (i = 0; i < BATTLE_ARENA_TEXT_LENGTHS.Length; ++i)
                        {
                            int len = BATTLE_ARENA_TEXT_LENGTHS[i].Length;
                            for (int j = 0; j < BATTLE_ARENA_TEXT_LENGTHS[i].Count; ++j)
                            {
                                BattleArenaTexts[curr] = FFText.GetTextFromByteArray(bytes, (int)stream.Position, len);
                                stream.Seek(BattleArenaTexts[curr].ToString().Length + 1, SeekOrigin.Current);
                                curr++;
                            }
                        }

                        //read Bizarro menu text
                        for (i = 0; i < NUM_BIZARRO_MENU_TEXTS; ++i)
                        {
                            BizarroMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                BIZARRO_MENU_TEXT_LENGTH);
                            stream.Seek(BizarroMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read audio volume
                        for (i = 0; i < NUM_AUDIO_VALUES; ++i)
                        {
                            AudioVolume[i] = reader.ReadInt32();
                        }

                        //read audio pan
                        for (i = 0; i < NUM_AUDIO_VALUES; ++i)
                        {
                            AudioPan[i] = reader.ReadInt32();
                        }

                        //read walkability data
                        for (i = 0; i < NUM_WALKABILITY_MODELS; i++)
                        {
                            if (MODEL_CAN_WALK_POS[i] > 0)
                            {
                                int temp = reader.ReadInt32();
                                var temp2 = BitConverter.GetBytes(temp);
                                ModelMoveBitmasks[i] = new BitArray(temp2);
                            }
                            if (MODEL_CAN_DISEMBARK_POS[i] > 0 && i < (int)WorldMapModels.YellowChocobo)
                            {
                                int temp = reader.ReadInt32();
                                var temp2 = BitConverter.GetBytes(temp);
                                ModelDisembarkBitmasks[i] = new BitArray(temp2);
                            }
                        }

                        //read materia equip effects
                        for (i = 0; i < MateriaEquipEffect.COUNT; ++i)
                        {
                            MateriaEquipEffects[i] = new MateriaEquipEffect(reader.ReadBytes(MateriaEquipEffect.DATA_LENGTH));
                        }
                    }
                }
            }
            catch (EndOfStreamException)
            {
                throw new EndOfStreamException("The stream ended early. It may be from an older version of the software.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //write data to a byte array
        public byte[] GetBytes()
        {
            if (CaitSith == null) { throw new ArgumentNullException(nameof(CaitSith)); }
            if (Vincent == null) { throw new ArgumentNullException(nameof(Vincent)); }

            var output = new List<byte>();

            //write character names
            foreach (var n in CharacterNames)
            {
                output.AddRange(n.GetBytes(DataParser.CHARACTER_NAME_LENGTH));
            }

            //write character data
            output.AddRange(DataParser.GetCharacterInitialDataBytes(CaitSith));
            output.AddRange(DataParser.GetCharacterInitialDataBytes(Vincent));

            //write item prices
            output.Add(APPriceMultiplier);
            foreach (var i in ItemPrices)
            {
                output.AddRange(BitConverter.GetBytes(i));
            }
            foreach (var p in WeaponPrices)
            {
                output.AddRange(BitConverter.GetBytes(p));
            }
            foreach (var p in ArmorPrices)
            {
                output.AddRange(BitConverter.GetBytes(p));
            }
            foreach (var p in AccessoryPrices)
            {
                output.AddRange(BitConverter.GetBytes(p));
            }
            foreach (var p in MateriaPrices)
            {
                output.AddRange(BitConverter.GetBytes(p));
            }

            //write shop inventories
            foreach (var s in Shops)
            {
                output.AddRange(s.GetByteArray());
            }

            //write limits
            foreach (var l in Limits)
            {
                output.AddRange(DataParser.GetAttackBytes(l));
            }

            //write main menu text
            foreach (var t in MainMenuTexts)
            {
                output.AddRange(t.GetBytes(MENU_TEXT_LENGTH));
            }

            //write config menu text
            foreach (var t in ConfigMenuTexts)
            {
                output.AddRange(t.GetBytesTruncated());
            }

            //write status effects
            foreach (var s in StatusEffectsBattle)
            {
                output.AddRange(s.GetBytesTruncated());
            }

            //write shop names
            foreach (var n in ShopNames)
            {
                output.AddRange(n.GetBytesTruncated());
            }

            //write shop texts
            foreach (var t in ShopText)
            {
                output.AddRange(t.GetBytes(SHOP_TEXT_LENGTH));
            }

            //write L4 success text
            foreach (var t in LimitSuccess)
            {
                output.AddRange(t.GetBytesTruncated());
            }

            //write L4 fail text
            foreach (var t in LimitFail)
            {
                output.AddRange(t.GetBytesTruncated());
            }

            //write L4 wrong text
            foreach (var t in LimitWrong)
            {
                output.AddRange(t.GetBytesTruncated());
            }

            //English-only stuff (for now)
            if (Language == Language.English)
            {
                //write item sort list
                var itemPositions =
                    from item in ItemsSortedByName
                    orderby item.Key
                    select item.Value;
                foreach (var p in itemPositions)
                {
                    output.AddRange(BitConverter.GetBytes(p));
                }

                //write materia priority list
                var materiaPositions =
                    from mat in MateriaPriority
                    orderby mat.Key
                    select mat.Value;
                foreach (var p in materiaPositions)
                {
                    output.Add(p);
                }

                //write materia menu text
                foreach (var m in MateriaMenuTexts)
                {
                    output.AddRange(m.GetBytesTruncated());
                }

                //write equip menu text
                foreach (var e in EquipMenuTexts)
                {
                    output.AddRange(e.GetBytesTruncated());
                }

                //write element names
                foreach (var e in ElementNames)
                {
                    output.AddRange(e.GetBytesTruncated());
                }

                //write status effects (menu)
                foreach (var s in StatusEffectsMenu)
                {
                    output.AddRange(s.GetBytesTruncated());
                }

                //write status menu text
                foreach (var s in StatusMenuTexts)
                {
                    output.AddRange(s.GetBytesTruncated());
                }

                //write chocobo racer names
                foreach (var n in ChocoboNames)
                {
                    output.AddRange(n.GetBytes(CHOCOBO_NAME_LENGTH));
                }

                //write chocobo race prizes
                foreach (var p in ChocoboRacePrizes)
                {
                    output.AddRange(p.GetBytes(ITEM_NAME_LENGTH));
                }

                //write item menu text
                foreach (var i in ItemMenuTexts)
                {
                    output.AddRange(i.GetBytesTruncated());
                }

                //write magic menu text
                foreach (var m in MagicMenuTexts)
                {
                    output.AddRange(m.GetBytesTruncated());
                }

                //write unequip text
                foreach (var u in UnequipTexts)
                {
                    output.AddRange(u.GetBytesTruncated());
                }

                //write limit menu text
                foreach (var l in LimitMenuTexts)
                {
                    output.AddRange(l.GetBytesTruncated());
                }

                //write save menu text
                foreach (var s in SaveMenuTexts)
                {
                    output.AddRange(s.GetBytesTruncated());
                }

                //write quit text
                foreach (var q in QuitMenuTexts)
                {
                    output.AddRange(q.GetBytesTruncated());
                }

                //write battle arena text
                foreach (var b in BattleArenaTexts)
                {
                    output.AddRange(b.GetBytesTruncated());
                }

                //write Bizarro menu text
                foreach (var b in BizarroMenuTexts)
                {
                    output.AddRange(b.GetBytesTruncated());
                }

                //write audio volume
                foreach (var a in AudioVolume)
                {
                    output.AddRange(BitConverter.GetBytes(a));
                }

                //write audio pan
                foreach (var a in AudioPan)
                {
                    output.AddRange(BitConverter.GetBytes(a));
                }

                //write walkability data
                for (int i = 0; i < NUM_WALKABILITY_MODELS; i++)
                {
                    if (ModelMoveBitmasks[i] != null)
                    {
                        var temp = new byte[4];
                        ModelMoveBitmasks[i].CopyTo(temp, 0);
                        output.AddRange(temp);
                    }
                    if (ModelDisembarkBitmasks[i] != null && i < (int)WorldMapModels.YellowChocobo)
                    {
                        var temp = new byte[4];
                        ModelDisembarkBitmasks[i].CopyTo(temp, 0);
                        output.AddRange(temp);
                    }
                }

                //write materia equip effects
                foreach (var e in MateriaEquipEffects)
                {
                    output.AddRange(e.GetBytes());
                }
            }

            return output.ToArray();
        }

        //read data from a file
        public void ReadFile(string path)
        {
            try
            {
                ReadBytes(File.ReadAllBytes(path));
            }
            catch (EndOfStreamException ex)
            {
                throw new EndOfStreamException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new IOException($"There was a problem reading the file.", ex);
            }
        }

        //write data to a file
        public void WriteFile(string path)
        {
            try
            {
                File.WriteAllBytes(path, GetBytes());
            }
            catch (Exception ex)
            {
                throw new IOException("There was a problem writing the file.", ex);
            }
        }

        //private function to get the correct Hext offset for current position
        private long GetHextPosition(long pos)
        {
            if (pos > DATA_SECTION_START)
            {
                return pos + HEXT_OFFSET_DATA;
            }
            else
            {
                return pos + HEXT_OFFSET_TEXT;
            }
        }

        //private function to write bytes to a Hext file
        private string WriteHextBytes(byte[] bytes, byte[] original, string tagline, long position)
        {
            if (!bytes.SequenceEqual(original))
            {
                var str = new StringBuilder();
                bool diff = false;
                str.AppendLine($"# {tagline}");
                for (int i = 0; i < original.Length; ++i)
                {
                    if (bytes[i] != original[i])
                    {
                        if (!diff)
                        {
                            str.Append($"{GetHextPosition(position + i):X2} = ");
                            diff = true;
                        }
                        str.Append($"{bytes[i]:X2} ");
                    }
                    else
                    {
                        if (diff)
                        {
                            str.AppendLine();
                            diff = false;
                        }
                    }
                }
                str.AppendLine();
                return str.ToString();
            }
            return string.Empty;
        }

        //private function to write text for a Hext file
        private string WriteHextStrings(FFText[] strings, FFText[] original, long position, int length, int count,
            int offset = 0)
        {
            var output = new StringBuilder();
            bool checker = false;

            for (int i = 0; i < count; ++i)
            {
                string? text1 = strings[i + offset].ToString(), text2 = original[i + offset].ToString();

                if (text1 != text2)
                {
                    checker = true;
                    output.Append($"# {text2} -> {text1}");
                    output.AppendLine();
                    var temp = strings[i + offset].GetBytes();
                    output.Append($"{GetHextPosition(position + (length * i)):X2} = ");
                    foreach (var x in temp)
                    {
                        output.Append($"{x:X2} ");
                    }
                    output.AppendLine();
                }
            }
            if (checker) { output.AppendLine(); }
            return output.ToString();
        }

        //creates a Hext file
        public void CreateHextFile(string path, ExeData original)
        {
            try
            {
                if (Language != Language.English)
                {
                    throw new NotImplementedException("Currently unavailable for this language.");
                }
                if (original == null)
                {
                    throw new ArgumentNullException(nameof(original));
                }

                using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine(@"..\ff7.exe");
                    writer.WriteLine($"# {Enum.GetName(Language)} version");
                    writer.WriteLine();

                    long pos;
                    bool checker = false, diff;
                    int i, j;

                    //compare AP price multiplier
                    if (APPriceMultiplier != original.APPriceMultiplier)
                    {
                        writer.WriteLine("# AP price multiplier");
                        pos = GetHextPosition(AP_MULTIPLIER_POS);
                        writer.WriteLine($"{pos:X2} = {APPriceMultiplier:X2}");
                        pos += AP_MASTER_OFFSET;
                        writer.WriteLine($"{pos:X2} = {APPriceMultiplier:X2}");
                        writer.WriteLine();
                    }

                    //compare world map walkability
                    for (i = 0; i < NUM_WALKABILITY_MODELS; ++i)
                    {
                        bool moveDiff = false,
                                disembarkDiff = false;

                        byte[] moveBytesNew = new byte[4],
                            moveBytesOriginal = new byte[4],
                            disembarkBytesNew = new byte[4],
                            disembarkBytesOriginal = new byte[4];

                        if (ModelMoveBitmasks[i] != null)
                        {
                            ModelMoveBitmasks[i].CopyTo(moveBytesNew, 0);
                            original.ModelMoveBitmasks[i].CopyTo(moveBytesOriginal, 0);
                        }
                        if (ModelDisembarkBitmasks[i] != null)
                        {
                            ModelDisembarkBitmasks[i].CopyTo(disembarkBytesNew, 0);
                            original.ModelDisembarkBitmasks[i].CopyTo(disembarkBytesOriginal, 0);
                        }

                        for (j = 0; j < 4; ++j)
                        {
                            if (moveBytesNew[j] != moveBytesOriginal[j] || (disembarkBytesNew[j] != disembarkBytesOriginal[j] &&
                                i < (int)WorldMapModels.YellowChocobo))
                            {
                                if (!checker)
                                {
                                    writer.WriteLine("# World map walkability");
                                    checker = true;
                                }
                                if (!moveDiff && !disembarkDiff)
                                {
                                    var str = StringParser.AddSpaces(Enum.GetName((WorldMapModels)i));
                                    writer.WriteLine($"# {str}");
                                }
                                if (moveBytesNew[j] != moveBytesOriginal[j])
                                {
                                    moveDiff = true;
                                }
                                if (disembarkBytesNew[j] != disembarkBytesOriginal[j] &&
                                    i < (int)WorldMapModels.YellowChocobo)
                                {
                                    disembarkDiff = true;
                                }
                            }
                        }

                        if (moveDiff)
                        {
                            writer.Write($"{GetHextPosition(MODEL_CAN_WALK_POS[i]):X2} = ");
                            foreach (var b in moveBytesNew)
                            {
                                writer.Write($"{b:X2} ");
                            }
                            writer.WriteLine();

                            if ((WorldMapModels)i == WorldMapModels.TinyBronco) //additional bitmasks
                            {
                                foreach (var p in MODEL_CAN_WALK_TINY_BRONCO_ADDITIONAL_POS)
                                {
                                    writer.Write($"{GetHextPosition(p):X2} = ");
                                    foreach (var b in moveBytesNew)
                                    {
                                        writer.Write($"{b:X2} ");
                                    }
                                    writer.WriteLine();
                                }
                            }
                        }
                        if (disembarkDiff)
                        {
                            writer.Write($"{GetHextPosition(MODEL_CAN_DISEMBARK_POS[i]):X2} = ");
                            foreach (var b in moveBytesNew)
                            {
                                writer.Write($"{b:X2} ");
                            }
                            writer.WriteLine();
                        }
                        if (moveDiff || disembarkDiff)
                        {
                            writer.WriteLine();
                        }
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

                    //write materia equip effects
                    for (i = 0; i < MateriaEquipEffect.COUNT; ++i)
                    {
                        writer.Write(WriteHextBytes(MateriaEquipEffects[i].GetBytes(),
                            original.MateriaEquipEffects[i].GetBytes(),
                            $"Materia equip effect #{i:X2}",
                            MATERIA_EQUIP_EFFECT_POS + (i * MateriaEquipEffect.DATA_LENGTH)));
                    }

                    //write quit menu text
                    writer.Write(WriteHextStrings(QuitMenuTexts, original.QuitMenuTexts,
                        QUIT_TEXT_POS_1, QUIT_TEXT_LENGTH_1, NUM_QUIT_TEXTS_1));

                    writer.Write(WriteHextStrings(QuitMenuTexts, original.QuitMenuTexts,
                        QUIT_TEXT_POS_2, QUIT_TEXT_LENGTH_2, NUM_QUIT_TEXTS_2, NUM_QUIT_TEXTS_1));

                    //write config menu text
                    writer.Write(WriteHextStrings(ConfigMenuTexts, original.ConfigMenuTexts,
                        CONFIG_MENU_TEXT_POS, GetConfigTextLength(), NUM_CONFIG_MENU_TEXTS));

                    //write main menu text
                    writer.Write(WriteHextStrings(MainMenuTexts, original.MainMenuTexts,
                        MAIN_MENU_TEXT_POS, MENU_TEXT_LENGTH, NUM_MENU_TEXTS));

                    //write status effects (battle)
                    writer.Write(WriteHextStrings(StatusEffectsBattle, original.StatusEffectsBattle,
                        STATUS_EFFECT_BATTLE_POS, GetStatusEffectBattleLength(), NUM_STATUS_EFFECTS));

                    //write battle arena text
                    int offset = 0;
                    pos = BATTLE_ARENA_TEXT_POS;
                    for (i = 0; i < BATTLE_ARENA_TEXT_LENGTHS.Length; ++i)
                    {
                        writer.Write(WriteHextStrings(BattleArenaTexts, original.BattleArenaTexts,
                            pos, BATTLE_ARENA_TEXT_LENGTHS[i].Length, BATTLE_ARENA_TEXT_LENGTHS[i].Count, offset));
                        offset += BATTLE_ARENA_TEXT_LENGTHS[i].Count;
                        pos += (BATTLE_ARENA_TEXT_LENGTHS[i].Length * BATTLE_ARENA_TEXT_LENGTHS[i].Count);
                    }

                    //write Bizarro menu text
                    writer.Write(WriteHextStrings(BizarroMenuTexts, original.BizarroMenuTexts,
                        BIZARRO_MENU_TEXT_POS, BIZARRO_MENU_TEXT_LENGTH, NUM_BIZARRO_MENU_TEXTS));

                    //write limit menu text
                    writer.Write(WriteHextStrings(LimitMenuTexts, original.LimitMenuTexts,
                        LIMIT_MENU_TEXT_POS, LIMIT_MENU_TEXT_LENGTH, NUM_LIMIT_MENU_TEXTS));

                    //compare limits
                    for (i = 0; i < NUM_LIMITS; ++i)
                    {
                        string name = original.Limits[i].Name;
                        if (DataManager.Kernel != null)
                        {
                            name = DataManager.Kernel.GetLimitName(i);
                        }
                        writer.Write(WriteHextBytes(DataParser.GetAttackBytes(Limits[i]),
                            DataParser.GetAttackBytes(original.Limits[i]),
                            name,
                            LIMIT_BREAK_POS + (i * DataParser.ATTACK_BLOCK_SIZE)));
                    }

                    //write element names
                    writer.Write(WriteHextStrings(ElementNames, original.ElementNames,
                        STATUS_MENU_ELEMENT_POS, ELEMENT_NAME_LENGTH, NUM_ELEMENTS));

                    //write status effects (menu)
                    writer.Write(WriteHextStrings(StatusEffectsMenu, original.StatusEffectsMenu,
                        STATUS_MENU_EFFECTS_POS, MENU_TEXT_LENGTH, NUM_STATUS_EFFECTS));

                    //write status menu text
                    writer.Write(WriteHextStrings(StatusMenuTexts, original.StatusMenuTexts,
                        STATUS_MENU_TEXT_POS, STATUS_MENU_TEXT_LENGTH, NUM_STATUS_MENU_TEXTS));

                    //write equip menu text
                    writer.Write(WriteHextStrings(EquipMenuTexts, original.EquipMenuTexts,
                        EQUIP_MENU_TEXT_POS, EQUIP_MENU_TEXT_LENGTH, NUM_EQUIP_MENU_TEXTS));

                    //write unequip text
                    writer.Write(WriteHextStrings(UnequipTexts, original.UnequipTexts,
                        UNEQUIP_TEXT_POS, UNEQUIP_TEXT_LENGTH, NUM_UNEQUIP_TEXTS));

                    //write materia menu text
                    writer.Write(WriteHextStrings(MateriaMenuTexts, original.MateriaMenuTexts,
                        MATERIA_MENU_TEXT_POS, MENU_TEXT_LENGTH, NUM_MATERIA_MENU_TEXTS));

                    //write magic menu text
                    writer.Write(WriteHextStrings(MagicMenuTexts, original.MagicMenuTexts,
                        MAGIC_MENU_TEXT_POS, MENU_TEXT_LENGTH, NUM_MAGIC_MENU_TEXTS));

                    //write item menu text
                    writer.Write(WriteHextStrings(ItemMenuTexts, original.ItemMenuTexts,
                        ITEM_MENU_TEXT_POS, ITEM_MENU_TEXT_LENGTH, NUM_ITEM_MENU_TEXTS));

                    //compare limit text
                    j = 0;
                    for (i = 0; i < Kernel.PLAYABLE_CHARACTER_COUNT; ++i)
                    {
                        string text1, text2;
                        if (i < Kernel.PLAYABLE_CHARACTER_COUNT - 1)
                        {
                            //limit success
                            text1 = LimitSuccess[i].ToString();
                            text2 = original.LimitSuccess[i].ToString();

                            if (text1 != text2)
                            {
                                checker = true;
                                writer.WriteLine($"# {text2} -> {text1}");
                                var temp = LimitSuccess[i].GetBytes();
                                pos = GetHextPosition(LIMIT_TEXT_POS + (GetLimitTextLength() * j));
                                writer.Write($"{pos:X2} = ");
                                foreach (var x in temp)
                                {
                                    writer.Write($"{x:X2} ");
                                }
                                writer.WriteLine();
                            }
                            j++;

                            //limit fail
                            text1 = LimitFail[i].ToString();
                            text2 = original.LimitFail[i].ToString();

                            if (text1 != text2)
                            {
                                checker = true;
                                writer.WriteLine($"# {text2} -> {text1}");
                                var temp = LimitFail[i].GetBytes();
                                pos = GetHextPosition(LIMIT_TEXT_POS + (GetLimitTextLength() * j));
                                writer.Write($"{pos:X2} = ");
                                foreach (var x in temp)
                                {
                                    writer.Write($"{x:X2} ");
                                }
                                writer.WriteLine();
                            }
                            j++;
                        }

                        //limit wrong
                        text1 = LimitWrong[i].ToString();
                        text2 = original.LimitWrong[i].ToString();

                        if (text1 != text2)
                        {
                            checker = true;
                            writer.WriteLine($"# {text2} -> {text1}");
                            var temp = LimitWrong[i].GetBytes();
                            pos = GetHextPosition(LIMIT_TEXT_POS + (GetLimitTextLength() * j));
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }
                        j++;
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

                    //compare item sort order
                    var items1 =
                        (from item in ItemsSortedByName
                            orderby item.Key
                            select item.Value).ToArray();
                    var items2 =
                        (from item in original.ItemsSortedByName
                            orderby item.Key
                            select item.Value).ToArray();
                    diff = false;
                    for (i = 0; i < DataParser.MATERIA_START; ++i)
                    {
                        if (items1[i] != items2[i])
                        {
                            if (!checker)
                            {
                                writer.WriteLine("# Item sort order");
                                checker = true;
                            }
                            if (!diff)
                            {
                                writer.Write($"{GetHextPosition(ITEM_SORT_POS + (i * 2)):X2} = ");
                                diff = true;
                            }
                            var temp = BitConverter.GetBytes(items1[i]);
                            foreach (var b in temp)
                            {
                                writer.Write($"{b:X2} ");
                            }
                        }
                        else
                        {
                            if (checker && diff)
                            {
                                writer.WriteLine();
                                diff = false;
                            }
                        }
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

                    //write character names
                    writer.Write(WriteHextStrings(CharacterNames, original.CharacterNames,
                        NAME_DATA_POS, DataParser.CHARACTER_NAME_LENGTH, NUM_CHARACTER_NAMES));

                    //compare materia priority list
                    var p1 =
                        (from p in MateriaPriority
                         orderby p.Key
                         select p.Value).ToArray();
                    var p2 =
                        (from p in original.MateriaPriority
                         orderby p.Key
                         select p.Value).ToArray();
                    diff = false;
                    for (i = 0; i < DataParser.MATERIA_COUNT; ++i)
                    {
                        if (p1[i] != p2[i])
                        {
                            if (!checker)
                            {
                                writer.WriteLine("# Materia priority");
                                checker = true;
                            }
                            if (!diff)
                            {
                                writer.Write($"{GetHextPosition(MATERIA_PRIORITY_POS + i):X2} = ");
                                diff = true;
                            }
                            writer.Write($"{p1[i]:X2} ");
                        }
                        else
                        {
                            if (checker && diff)
                            {
                                writer.WriteLine();
                                diff = false;
                            }
                        }
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

                    //compare Cait Sith's data
                    if (CaitSith != null && original.CaitSith != null)
                    {
                        writer.Write(WriteHextBytes(DataParser.GetCharacterInitialDataBytes(CaitSith),
                            DataParser.GetCharacterInitialDataBytes(original.CaitSith),
                            "Cait Sith's initial data", CAIT_SITH_DATA_POS));
                    }

                    //compare Vincent's data
                    if (Vincent != null && original.Vincent != null)
                    {
                        writer.Write(WriteHextBytes(DataParser.GetCharacterInitialDataBytes(Vincent),
                            DataParser.GetCharacterInitialDataBytes(original.Vincent),
                            "Vincent's initial data", VINCENT_DATA_POS));
                    }

                    //write shop names
                    writer.Write(WriteHextStrings(ShopNames, original.ShopNames,
                        SHOP_NAME_POS, GetShopNameLength(), NUM_SHOP_NAMES));

                    //write shop text
                    writer.Write(WriteHextStrings(ShopText, original.ShopText,
                        SHOP_TEXT_POS, SHOP_TEXT_LENGTH, NUM_SHOP_TEXTS));

                    //compare shop inventories
                    if (DataManager.Kernel != null)
                    {
                        for (i = 0; i < NUM_SHOPS; ++i)
                        {
                            string name = $"Shop #{i}";
                            if (ShopData.SHOP_NAMES.ContainsKey(i))
                            {
                                name = ShopData.SHOP_NAMES[i];
                            }
                            writer.Write(WriteHextBytes(Shops[i].GetByteArray(),
                                original.Shops[i].GetByteArray(),
                                name, SHOP_INVENTORY_POS + (ShopInventory.SHOP_DATA_LENGTH * i)));
                        }

                        //compare item prices
                        for (i = 0; i < DataParser.ITEM_COUNT; ++i)
                        {
                            if (ItemPrices[i] != original.ItemPrices[i])
                            {
                                writer.WriteLine($"# {DataManager.Kernel.ItemData.Items[i].Name} price");
                                writer.Write($"{GetHextPosition(ITEM_PRICE_DATA_POS + (i * 4)):X2} = ");
                                foreach (var b in BitConverter.GetBytes(ItemPrices[i]))
                                {
                                    writer.Write($"{b:X2} ");
                                }
                                writer.WriteLine();
                                writer.WriteLine();
                            }
                        }

                        //compare weapon prices
                        for (i = 0; i < DataParser.WEAPON_COUNT; ++i)
                        {
                            if (WeaponPrices[i] != original.WeaponPrices[i])
                            {
                                writer.WriteLine($"# {DataManager.Kernel.WeaponData.Weapons[i].Name} price");
                                pos = GetHextPosition(ITEM_PRICE_DATA_POS + (DataParser.WEAPON_START * 4) + (i * 4));
                                writer.Write($"{pos:X2} = ");
                                foreach (var b in BitConverter.GetBytes(WeaponPrices[i]))
                                {
                                    writer.Write($"{b:X2} ");
                                }
                                writer.WriteLine();
                                writer.WriteLine();
                            }
                        }

                        //compare armor prices
                        for (i = 0; i < DataParser.ARMOR_COUNT; ++i)
                        {
                            if (ArmorPrices[i] != original.ArmorPrices[i])
                            {
                                writer.WriteLine($"# {DataManager.Kernel.ArmorData.Armors[i].Name} price");
                                pos = GetHextPosition(ITEM_PRICE_DATA_POS + (DataParser.ARMOR_START * 4) + (i * 4));
                                writer.Write($"{pos:X2} = ");
                                foreach (var b in BitConverter.GetBytes(ArmorPrices[i]))
                                {
                                    writer.Write($"{b:X2} ");
                                }
                                writer.WriteLine();
                                writer.WriteLine();
                            }
                        }

                        //compare accessory prices
                        for (i = 0; i < DataParser.ACCESSORY_COUNT; ++i)
                        {
                            if (AccessoryPrices[i] != original.AccessoryPrices[i])
                            {
                                writer.WriteLine($"# {DataManager.Kernel.AccessoryData.Accessories[i].Name} price");
                                pos = GetHextPosition(ITEM_PRICE_DATA_POS + (DataParser.ACCESSORY_START * 4) + (i * 4));
                                writer.Write($"{pos:X2} = ");
                                foreach (var b in BitConverter.GetBytes(AccessoryPrices[i]))
                                {
                                    writer.Write($"{b:X2} ");
                                }
                                writer.WriteLine();
                                writer.WriteLine();
                            }
                        }

                        //compare materia prices
                        for (i = 0; i < DataManager.Kernel.MateriaData.Materias.Length; ++i)
                        {
                            if (MateriaPrices[i] != original.MateriaPrices[i])
                            {
                                writer.WriteLine($"# {DataManager.Kernel.MateriaData.Materias[i].Name} price");
                                writer.Write($"{GetHextPosition(MATERIA_PRICE_DATA_POS + (i * 4)):X2} = ");
                                foreach (var b in BitConverter.GetBytes(MateriaPrices[i]))
                                {
                                    writer.Write($"{b:X2} ");
                                }
                                writer.WriteLine();
                                writer.WriteLine();
                            }
                        }

                        //write save menu text
                        writer.Write(WriteHextStrings(SaveMenuTexts, original.SaveMenuTexts,
                            SAVE_MENU_TEXT_POS, SAVE_MENU_TEXT_LENGTH, NUM_SAVE_MENU_TEXTS));

                        //compare Teioh's name
                        string name1 = ChocoboNames[NUM_CHOCOBO_NAMES].ToString(),
                            name2 = original.ChocoboNames[NUM_CHOCOBO_NAMES].ToString();

                        if (name1 != name2)
                        {
                            checker = true;
                            writer.WriteLine($"# {name2} -> {name1}");
                            var temp = ChocoboNames[NUM_CHOCOBO_NAMES].GetBytes();
                            writer.Write($"{GetHextPosition(TEIOH_POS):X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }
                        checker = false;

                        //compare audio volume
                        for (i = 0; i < NUM_AUDIO_VALUES; ++i)
                        {
                            if (AudioVolume[i] != original.AudioVolume[i])
                            {
                                if (!checker)
                                {
                                    writer.WriteLine("# Audio volume");
                                    checker = true;
                                }
                                writer.Write($"{GetHextPosition(AUDIO_VOLUME_POS + (i * 4)):X2} = ");
                                var temp = BitConverter.GetBytes(AudioVolume[i]);
                                foreach (var b in temp)
                                {
                                    writer.Write($"{b:X2} ");
                                }
                                writer.WriteLine();
                            }
                        }
                        if (checker)
                        {
                            writer.WriteLine();
                            checker = false;
                        }

                        //compare audio pan
                        for (i = 0; i < NUM_AUDIO_VALUES; ++i)
                        {
                            if (AudioPan[i] != original.AudioPan[i])
                            {
                                if (!checker)
                                {
                                    writer.WriteLine("# Audio pan");
                                    checker = true;
                                }
                                writer.Write($"{GetHextPosition(AUDIO_PAN_POS + (i * 4)):X2} = ");
                                var temp = BitConverter.GetBytes(AudioPan[i]);
                                foreach (var b in temp)
                                {
                                    writer.Write($"{b:X2} ");
                                }
                                writer.WriteLine();
                            }
                        }
                        if (checker)
                        {
                            writer.WriteLine();
                            checker = false;
                        }

                        //write chocobo race prizes
                        writer.Write(WriteHextStrings(ChocoboRacePrizes, original.ChocoboRacePrizes,
                            CHOCOBO_RACE_ITEMS_POS, ITEM_NAME_LENGTH, NUM_CHOCOBO_RACE_ITEMS));

                        //write chocobo racer names (besides Teioh)
                        writer.Write(WriteHextStrings(ChocoboNames, original.ChocoboNames,
                            CHOCOBO_NAMES_POS, CHOCOBO_NAME_LENGTH, NUM_CHOCOBO_NAMES));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException("There was a problem writing the file.", ex);
            }
        }
    }
}
