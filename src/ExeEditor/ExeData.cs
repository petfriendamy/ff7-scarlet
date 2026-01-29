using FF7Scarlet.KernelEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Characters;
using System.Diagnostics;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace FF7Scarlet.ExeEditor
{
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
        private struct ArrayInfo
        {
            public readonly long Offset;
            public readonly int Count;
            public readonly int Length;
            public readonly bool KernelSynced;

            public ArrayInfo(long offset, int count, int length, bool kernelSynced = false)
            {
                Offset = offset;
                Count = count;
                Length = length;
                KernelSynced = kernelSynced;
            }
        }

        //constants
        private static readonly int[] EXE_HEADER = { 0x4D, 0x5A, 0x90 };
        public const string
            CONFIG_KEY = "ExePath",
            VANILLA_CONFIG_KEY = "VanillaExePath";

        //battle arena texts
        private static readonly MultiStringLength[] BATTLE_ARENA_TEXT_LENGTHS_EN =
        {
            new MultiStringLength(16, 1),
            new MultiStringLength(24, 1),
            new MultiStringLength(22, 4),
            new MultiStringLength(32, 25),
            new MultiStringLength(34, 3)
        };
        private static readonly MultiStringLength[] BATTLE_ARENA_TEXT_LENGTHS_ES =
        {
            new MultiStringLength(8, 1),
            new MultiStringLength(32, 1),
            new MultiStringLength(27, 3),
            new MultiStringLength(31, 1),
            new MultiStringLength(39, 24),
            new MultiStringLength(40, 1),
            new MultiStringLength(36, 3)
        };
        private static readonly MultiStringLength[] BATTLE_ARENA_TEXT_LENGTHS_FR =
        {
            new MultiStringLength(16, 1),
            new MultiStringLength(32, 1),
            new MultiStringLength(36, 4),
            new MultiStringLength(32, 25),
            new MultiStringLength(34, 3)
        };
        private static readonly MultiStringLength[] BATTLE_ARENA_TEXT_LENGTHS_DE =
        {
            new MultiStringLength(8, 1),
            new MultiStringLength(16, 1),
            new MultiStringLength(26, 4),
            new MultiStringLength(31, 24),
            new MultiStringLength(32, 1),
            new MultiStringLength(35, 3)
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
            NUM_CHOCOBO_RACE_ITEMS = 24,
            NUM_AUDIO_VALUES = 128,
            NUM_WALKABILITY_MODELS = 12,

            MENU_TEXT_LENGTH = 20,
            QUIT_TEXT_LENGTH_1 = 30,
            SHOP_TEXT_LENGTH = 46;

        private const long
            HEXT_OFFSET_TEXT = 0x400C00,
            HEXT_OFFSET_DATA = 0x401600,
            DATA_SECTION_START = 0x3B8A00,

            TEST_BYTE_POS = 0x94,
            AP_MULTIPLIER_POS = 0x31F14F,
            AP_MASTER_OFFSET = 0x4E,
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
            STATUS_EFFECTS_MENU_POS = 0x51EFA0,
            STATUS_MENU_TEXT_POS = 0x51F1C0,
            EQUIP_MENU_TEXT_POS = 0x51F3A8,
            UNEQUIP_TEXT_POS = 0x51F518,
            MATERIA_MENU_TEXT_POS = 0x51F5A8,
            MAGIC_MENU_TEXT_POS = 0x51F9E8,
            ITEM_MENU_TEXT_POS = 0x51FB68,
            LIMIT_TEXT_POS = 0x51FBF0,
            ITEM_SORT_POS = 0x51FF48,
            MATERIA_PRIORITY_POS = 0x5201C8,
            CHARACTER_NAMES_POS = 0x5206B8,
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

        private const long MODELS_POS = 0x34c356;
        private static readonly long[] MODEL_CAN_WALK_POS = { MODELS_POS, 0, 0x34c383, 0x34c4cc, 0x34c57e, 0x34c5c9, 0x568440, 0x568444, 0x568448, 0x56844c, 0x568450, 0x34bbdb };
        private static readonly long[] MODEL_CAN_DISEMBARK_POS = { 0, 0x34c45f, 0x34c3c1, 0x34c518, 0x34c54c, 0x34c59a, 0x34c3ec, 0x34c3ec, 0x34c3ec, 0x34c3ec, 0x34c3ec, 0 };
        private static readonly long[] MODEL_CAN_WALK_TINY_BRONCO_ADDITIONAL_POS = { 0x34c4f3, 0x34c52d };

        //properties
        private Dictionary<long, ArrayInfo> ArrayInfoList { get; }

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
        public FFText[] ChocoboNames { get; }
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
            Language = GetLanguage(path);
            BattleArenaTexts = new FFText[GetNumBattleArenaTexts()];
            ChocoboNames = new FFText[GetNumChocoboNames(Language) + 1];

            //get info about arrays within the EXE
            ArrayInfoList = new Dictionary<long, ArrayInfo> {
                { CAIT_SITH_DATA_POS, new ArrayInfo(GetCaitOffset(), 2, DataParser.CHARACTER_RECORD_LENGTH) },
                { LIMIT_BREAK_POS, new ArrayInfo(GetLimitOffset(), NUM_LIMITS, DataParser.ATTACK_BLOCK_SIZE) },
                { MAIN_MENU_TEXT_POS, new ArrayInfo(GetMainMenuOffset(), NUM_MENU_TEXTS, MENU_TEXT_LENGTH) },
                { ITEM_MENU_TEXT_POS, new ArrayInfo(GetItemMenuOffset(), NUM_ITEM_MENU_TEXTS, GetItemMenuTextLength()) },
                { MAGIC_MENU_TEXT_POS, new ArrayInfo(GetMagicMenuOffset(), NUM_MAGIC_MENU_TEXTS, GetMagicMenuTextLength()) },
                { MATERIA_MENU_TEXT_POS, new ArrayInfo(GetMateriaMenuOffset(), NUM_MATERIA_MENU_TEXTS, GetMateriaMenuTextLength()) },
                { UNEQUIP_TEXT_POS, new ArrayInfo(GetUnequipOffset(), NUM_UNEQUIP_TEXTS, GetUnequipTextLength()) },
                { EQUIP_MENU_TEXT_POS, new ArrayInfo(GetEquipMenuOffset(), NUM_EQUIP_MENU_TEXTS, GetEquipMenuTextLength()) },
                { STATUS_MENU_ELEMENT_POS, new ArrayInfo(GetElementOffset(), NUM_ELEMENTS, GetElementNameLength()) },
                { STATUS_EFFECT_BATTLE_POS, new ArrayInfo(GetStatusEffectBattleOffset(), NUM_STATUS_EFFECTS, GetStatusEffectBattleLength()) },
                { STATUS_EFFECTS_MENU_POS, new ArrayInfo(GetStatusEffectMenuOffset(), NUM_STATUS_EFFECTS, MENU_TEXT_LENGTH) },
                { STATUS_MENU_TEXT_POS, new ArrayInfo(GetStatusMenuOffset(), NUM_STATUS_EFFECTS, GetStatusMenuTextLength()) },
                { LIMIT_MENU_TEXT_POS, new ArrayInfo(GetLimitMenuOffset(), NUM_LIMIT_MENU_TEXTS, GetLimitMenuTextLength()) },
                { LIMIT_TEXT_POS, new ArrayInfo(GetLimitTextOffset(), Kernel.PLAYABLE_CHARACTER_COUNT * 3, GetLimitTextLength()) },
                { CONFIG_MENU_TEXT_POS, new ArrayInfo(GetConfigOffset(), NUM_CONFIG_MENU_TEXTS, GetConfigTextLength()) },
                { SAVE_MENU_TEXT_POS, new ArrayInfo(GetSaveOffset(), NUM_SAVE_MENU_TEXTS, GetSaveTextLength()) },
                { QUIT_TEXT_POS_1, new ArrayInfo(GetQuitOffset(), NUM_QUIT_TEXTS_1, QUIT_TEXT_LENGTH_1) },
                { QUIT_TEXT_POS_2, new ArrayInfo(GetQuitOffset(), NUM_QUIT_TEXTS_2, GetQuitTextLength()) },
                { BATTLE_ARENA_TEXT_POS, new ArrayInfo(GetBattleArenaOffset(), GetNumBattleArenaTexts(), -1) },
                { BIZARRO_MENU_TEXT_POS, new ArrayInfo(GetBizarroOffset(), NUM_BIZARRO_MENU_TEXTS, GetBizarroTextLength()) },
                { CHARACTER_NAMES_POS, new ArrayInfo(GetNameOffset(), NUM_CHARACTER_NAMES, DataParser.CHARACTER_NAME_LENGTH) },
                { CHOCOBO_NAMES_POS, new ArrayInfo(GetChocoboNameOffset(), -1, GetChocoboNameLength()) },
                { CHOCOBO_RACE_ITEMS_POS, new ArrayInfo(GetChocoboRaceOffset(), NUM_CHOCOBO_RACE_ITEMS, GetItemNameLength()) },
                { SHOP_NAME_POS, new ArrayInfo(GetShopNameOffset(), NUM_SHOP_NAMES, GetShopNameLength()) },
                { SHOP_TEXT_POS, new ArrayInfo(GetShopTextOffset(), NUM_SHOP_TEXTS, SHOP_TEXT_LENGTH) },
                { SHOP_INVENTORY_POS, new ArrayInfo(GetShopOffset(), NUM_SHOPS, ShopInventory.SHOP_DATA_LENGTH, true) },
                { ITEM_PRICE_DATA_POS, new ArrayInfo(GetShopOffset(), DataParser.MATERIA_START, 4, true) },
                { MATERIA_PRICE_DATA_POS, new ArrayInfo(GetShopOffset(), Kernel.MATERIA_COUNT, 4, true) },
                { MATERIA_PRIORITY_POS, new ArrayInfo(GetMateriaPriorityOffset(), Kernel.MATERIA_COUNT, 1, true) },
                { MATERIA_EQUIP_EFFECT_POS, new ArrayInfo(GetEquipEffectOffset(), MateriaEquipEffect.COUNT, MateriaEquipEffect.DATA_LENGTH) },
                { AUDIO_VOLUME_POS, new ArrayInfo(GetAudioOffset(), NUM_AUDIO_VALUES, 4) },
                { AUDIO_PAN_POS, new ArrayInfo(GetAudioOffset(), NUM_AUDIO_VALUES, 4) }
            };

            //read the data
            ReadEXE(path);

            //make chocobos use the same bitmask
            int i = (int)WorldMapModels.YellowChocobo, j = i;
            while (j < (int)WorldMapModels.GoldChocobo)
            {
                ModelDisembarkBitmasks[j] = ModelDisembarkBitmasks[(int)WorldMapModels.WildChocobo];
                j++;
            }
        }

        private int GetBattleArenaBlockLength()
        {
            int result = 0, curr = 0;
            for (int i = 0; i < GetBattleArenaTextLengths(Language).Length; ++i)
            {
                for (int j = 0; j < GetBattleArenaTextLengths(Language)[i].Count; ++j)
                {
                    result += GetBattleArenaTextLengths(Language)[i].Length;
                    curr++;
                }
            }
            return result;
        }

        #region Offsets

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

        private long GetEquipEffectOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0xA60;
                case Language.French:
                    return 0x860;
                case Language.German:
                    return 0x480;
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

        private long GetItemMenuOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x77FD0;
                case Language.French:
                    return 0x77BB8;
                case Language.German:
                    return 0x772A0;
                default:
                    return 0;
            }
        }

        private long GetMagicMenuOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x77EB8;
                case Language.French:
                    return 0x77B68;
                case Language.German:
                    return 0x77288;
                default:
                    return 0;
            }
        }

        private long GetMateriaMenuOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x77D00;
                case Language.French:
                    return 0x77A68;
                case Language.German:
                    return 0x77138;
                default:
                    return 0;
            }
        }

        private long GetUnequipOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x77CF0;
                case Language.French:
                    return 0x77A70;
                case Language.German:
                    return 0x77138;
                default:
                    return 0;
            }
        }

        private long GetEquipMenuOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x77B58;
                case Language.French:
                    return 0x7782E;
                case Language.German:
                    return 0x76FD8;
                default:
                    return 0;
            }
        }

        private long GetStatusMenuOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x76228;
                case Language.French:
                    return 0x761F0;
                case Language.German:
                    return 0x75958;
                default:
                    return 0;
            }
        }

        private long GetElementOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x779D8;
                case Language.French:
                    return 0x777C0;
                case Language.German:
                    return 0x776A0;
                default:
                    return 0;
            }
        }

        private long GetStatusEffectBattleOffset()
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

        private long GetStatusEffectMenuOffset()
        {
            if (Language == Language.German) { return 0x76EC8; }
            else { return GetElementOffset(); }
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

        private long GetLimitMenuOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x779A0;
                case Language.French:
                    return 0x77788;
                case Language.German:
                    return 0x76EF0;
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

        private long GetSaveOffset()
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

        private long GetQuitOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x77240;
                case Language.French:
                    return 0x770B8;
                case Language.German:
                    return 0x76C40;
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

        private long GetBattleArenaOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x776E8;
                case Language.French:
                    return 0x77738;
                case Language.German:
                    return 0x76EF0;
                default:
                    return 0;
            }
        }

        private long GetBizarroOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x777B8;
                case Language.French:
                    return 0x77788;
                case Language.German:
                    return 0x76EF0;
                default:
                    return 0;
            }
        }

        private long GetMateriaPriorityOffset()
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

        private long GetChocoboRaceOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return -0xBEE8;
                case Language.French:
                    return -0xC0D0;
                case Language.German:
                    return -0xC4E8;
                default:
                    return 0;
            }
        }

        private long GetChocoboNameOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return -0xBED0;
                case Language.French:
                    return -0xC0A0;
                case Language.German:
                    return -0xC4D0;
                default:
                    return 0;
            }
        }

        private long GetAudioOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return -0xBF08;
                case Language.French:
                    return -0xC0F0;
                case Language.German:
                    return -0xC508;
                default:
                    return 0;
            }
        }

        #endregion

        #region Text Length

        public int GetItemMenuTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 20;
                case Language.French:
                    return 14;
                case Language.German:
                    return 18;
                default:
                    return 12;
            }
        }

        public int GetMagicMenuTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 40;
                case Language.French:
                    return 26;
                case Language.German:
                    return 22;
                default:
                    return MENU_TEXT_LENGTH;
            }
        }

        public int GetMateriaMenuTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 30;
                case Language.French:
                    return 26;
                case Language.German:
                    return 28;
                default:
                    return MENU_TEXT_LENGTH;
            }
        }

        public int GetUnequipTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 40;
                case Language.French:
                    return 34;
                default:
                    return 36;
            }
        }

        public int GetEquipMenuTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                case Language.French:
                    return 26;
                case Language.German:
                    return 22;
                default:
                    return 12;
            }
        }

        public int GetStatusMenuTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 40;
                case Language.French:
                case Language.German:
                    return 22;
                default:
                    return 15;
            }
        }

        public int GetElementNameLength()
        {
            if (Language == Language.German) { return 12; }
            else { return 10; }
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

        public int GetLimitMenuTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                case Language.French:
                    return 40;
                case Language.German:
                    return 32;
                default:
                    return 36;
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

        public int GetSaveTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 60;
                case Language.French:
                    return 50;
                case Language.German:
                    return 40;
                default:
                    return 36;
            }
        }

        public int GetQuitTextLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 3;
                case Language.German:
                    return 5;
                default:
                    return 4;
            }
        }

        public MultiStringLength[] GetBattleArenaTextLengths(Language lang)
        {
            switch (lang)
            {
                case Language.Spanish:
                    return BATTLE_ARENA_TEXT_LENGTHS_ES;
                case Language.French:
                    return BATTLE_ARENA_TEXT_LENGTHS_FR;
                case Language.German:
                    return BATTLE_ARENA_TEXT_LENGTHS_DE;
                default:
                    return BATTLE_ARENA_TEXT_LENGTHS_EN;
            }
        }

        public int GetBizarroTextLength()
        {
            if (Language == Language.Spanish) { return 40; }
            else { return 38; }
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

        public int GetItemNameLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                case Language.German:
                    return 17;
                case Language.French:
                    return 18;
                default:
                    return 16;
            }
        }

        public int GetChocoboNameLength()
        {
            switch (Language)
            {
                case Language.Spanish:
                case Language.German:
                    return 8;
                case Language.French:
                    return 10;
                default:
                    return 7;
            }
        }

        #endregion

        public static int GetNumBattleArenaTexts()
        {
            int temp = 0;
            foreach (var l in BATTLE_ARENA_TEXT_LENGTHS_EN)
            {
                temp += l.Count;
            }
            return temp;
        }

        public int GetNumChocoboNames(Language lang)
        {
            switch (lang)
            {
                case Language.Spanish:
                case Language.German:
                    return 41;
                case Language.French:
                    return 40;
                default:
                    return 46;
            }
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

        //private function to read items from an array
        private int ReadArrayItems(byte[] data, long offset, int count, int length, bool isExe, Language lang)
        {
            int result = 0;
            int internalCount = ArrayInfoList[offset].Count;
            if (offset == CHOCOBO_NAMES_POS)
            {
                internalCount = GetNumChocoboNames(Language);
                if (!isExe)
                {
                    internalCount++;
                }
            }
            int maxCount = Math.Min(count, internalCount);

            using (var stream = new MemoryStream(data))
            using (var reader = new BinaryReader(stream))
            {
                if (offset == CAIT_SITH_DATA_POS)
                {
                    CaitSith = DataParser.ReadCharacter(reader.ReadBytes(length));
                    Vincent = DataParser.ReadCharacter(reader.ReadBytes(length));
                }
                else if (offset == LIMIT_BREAK_POS)
                {
                    for (int i = 0; i < maxCount; ++i)
                    {
                        Limits[i] = DataParser.ReadAttack((ushort)i, $"(Limit #{i})", reader.ReadBytes(length));
                    }
                }
                else if (offset == LIMIT_TEXT_POS)
                {
                    for (int i = 0; i < Kernel.PLAYABLE_CHARACTER_COUNT; ++i)
                    {
                        if (i == Kernel.PLAYABLE_CHARACTER_COUNT - 1)
                        {
                            if (!isExe)
                            {
                                stream.Seek(length * 2, SeekOrigin.Current);
                            }
                        }
                        else
                        {
                            LimitSuccess[i] = new FFText(reader.ReadBytes(length));
                            LimitFail[i] = new FFText(reader.ReadBytes(length));
                        }
                        LimitWrong[i] = new FFText(reader.ReadBytes(length));
                    }
                }
                else if (offset == MATERIA_EQUIP_EFFECT_POS)
                {
                    for (int i = 0; i < maxCount; ++i)
                    {
                        MateriaEquipEffects[i] = new MateriaEquipEffect(reader.ReadBytes(length));
                    }
                }
                else if (offset == MATERIA_PRIORITY_POS)
                {
                    MateriaPriority.Clear();
                    for (int i = 0; i < maxCount; ++i)
                    {
                        MateriaPriority.Add((byte)i, reader.ReadByte());
                    }
                }
                else if (offset == SHOP_INVENTORY_POS)
                {
                    for (int i = 0; i < maxCount; ++i)
                    {
                        Shops[i] = new ShopInventory(reader.ReadBytes(ShopInventory.SHOP_DATA_LENGTH));
                    }
                }
                else if (offset == ITEM_PRICE_DATA_POS)
                {
                    int i;
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
                }
                else if (offset == MATERIA_PRICE_DATA_POS)
                {
                    for (int i = 0; i < maxCount; ++i)
                    {
                        MateriaPrices[i] = reader.ReadUInt32();
                    }
                }
                else if (offset == AUDIO_VOLUME_POS)
                {
                    for (int i = 0; i < maxCount; ++i)
                    {
                        AudioVolume[i] = reader.ReadInt32();
                    }
                }
                else if (offset == AUDIO_PAN_POS)
                {
                    for (int i = 0; i < maxCount; ++i)
                    {
                        AudioPan[i] = reader.ReadInt32();
                    }
                }
                else //strings
                {
                    FFText[] str;
                    if (offset == BATTLE_ARENA_TEXT_POS) //special case for battle arena texts
                    {
                        maxCount = GetNumBattleArenaTexts();
                        str = new FFText[maxCount];
                        int i, j;

                        int curr = 0;
                        var lengths = GetBattleArenaTextLengths(lang);
                        while (curr < maxCount)
                        {
                            for (i = 0; i < lengths.Length; ++i)
                            {
                                for (j = 0; j < lengths[i].Count; ++j)
                                {
                                    str[curr] = new FFText(reader.ReadBytes(lengths[i].Length));
                                    curr++;
                                }
                            }
                        }

                        if (lang != Language) //truncate any strings that are too long
                        {
                            curr = 0;
                            lengths = GetBattleArenaTextLengths(Language);
                            while (curr < maxCount)
                            {
                                for (i = 0; i < lengths.Length; ++i)
                                {
                                    for (j = 0; j < lengths[i].Count; ++j)
                                    {
                                        int newLength = lengths[i].Length;
                                        if (str[curr].Length > newLength)
                                        {
                                            result = 1;
                                            var temp = str[curr].GetBytes();
                                            str[curr] = new FFText(temp, newLength);
                                        }
                                        curr++;
                                    }
                                }
                            }
                        }
                    }
                    else //everything else
                    {
                        str = new FFText[count];

                        for (int i = 0; i < count; ++i)
                        {
                            if (isExe && offset == STATUS_EFFECTS_MENU_POS && Language == Language.Spanish && i == 19)
                            {
                                //silly Spanish bug
                                str[i] = new FFText();
                            }
                            else
                            {
                                str[i] = new FFText(reader.ReadBytes(length), ArrayInfoList[offset].Length);
                                if (length > ArrayInfoList[offset].Length)
                                {
                                    result = 1;
                                }
                            }
                        }
                    }

                    //copy them to the associated array
                    switch (offset)
                    {
                        case MAIN_MENU_TEXT_POS:
                            Array.Copy(str, MainMenuTexts, maxCount);
                            break;
                        case ITEM_MENU_TEXT_POS:
                            Array.Copy(str, ItemMenuTexts, maxCount);
                            break;
                        case MAGIC_MENU_TEXT_POS:
                            Array.Copy(str, MagicMenuTexts, maxCount);
                            break;
                        case MATERIA_MENU_TEXT_POS:
                            Array.Copy(str, MateriaMenuTexts, maxCount);
                            break;
                        case UNEQUIP_TEXT_POS:
                            Array.Copy(str, UnequipTexts, maxCount);
                            break;
                        case EQUIP_MENU_TEXT_POS:
                            Array.Copy(str, EquipMenuTexts, maxCount);
                            break;
                        case STATUS_MENU_ELEMENT_POS:
                            Array.Copy(str, ElementNames, maxCount);
                            break;
                        case STATUS_EFFECTS_MENU_POS:
                            Array.Copy(str, StatusEffectsMenu, maxCount);
                            break;
                        case STATUS_EFFECT_BATTLE_POS:
                            Array.Copy(str, StatusEffectsBattle, maxCount);
                            break;
                        case STATUS_MENU_TEXT_POS:
                            Array.Copy(str, StatusMenuTexts, maxCount);
                            break;
                        case LIMIT_MENU_TEXT_POS:
                            Array.Copy(str, LimitMenuTexts, maxCount);
                            break;
                        case CONFIG_MENU_TEXT_POS:
                            Array.Copy(str, ConfigMenuTexts, maxCount);
                            break;
                        case SAVE_MENU_TEXT_POS:
                            Array.Copy(str, SaveMenuTexts, maxCount);
                            break;
                        case QUIT_TEXT_POS_1:
                            Array.Copy(str, QuitMenuTexts, maxCount);
                            break;
                        case QUIT_TEXT_POS_2:
                            Array.Copy(str, 0, QuitMenuTexts, NUM_QUIT_TEXTS_1, maxCount);
                            break;
                        case BATTLE_ARENA_TEXT_POS:
                            Array.Copy(str, BattleArenaTexts, maxCount);
                            break;
                        case BIZARRO_MENU_TEXT_POS:
                            Array.Copy(str, BizarroMenuTexts, maxCount);
                            break;
                        case CHARACTER_NAMES_POS:
                            Array.Copy(str, CharacterNames, maxCount);
                            break;
                        case CHOCOBO_NAMES_POS:
                            if (isExe)
                            {
                                Array.Copy(str, ChocoboNames, maxCount);
                            }
                            else
                            {
                                Array.Copy(str, ChocoboNames, maxCount - 1);
                                ChocoboNames[internalCount - 1] = str[count - 1];
                            }
                            break;
                        case CHOCOBO_RACE_ITEMS_POS:
                            Array.Copy(str, ChocoboRacePrizes, maxCount);
                            break;
                        case SHOP_NAME_POS:
                            Array.Copy(str, ShopNames, maxCount);
                            break;
                        case SHOP_TEXT_POS:
                            Array.Copy(str, ShopText, maxCount);
                            break;
                    }
                }
            }
            return result;
        }

        //private function to write data to an array
        private byte[] WriteData(long pos, bool isExe = false)
        {
            var output = new List<byte>();
            int i;

            switch (pos)
            {
                case AP_MULTIPLIER_POS:
                    output.Add(APPriceMultiplier);
                    break;

                case MATERIA_EQUIP_EFFECT_POS:
                    foreach (var e in MateriaEquipEffects)
                    {
                        output.AddRange(e.GetBytes());
                    }
                    break;

                case QUIT_TEXT_POS_1:
                    for (i = 0; i < NUM_QUIT_TEXTS_1; ++i)
                    {
                        output.AddRange(QuitMenuTexts[i].GetBytes(QUIT_TEXT_LENGTH_1, false, true));
                    }
                    break;

                case QUIT_TEXT_POS_2:
                    for (i = 0; i < NUM_QUIT_TEXTS_2; ++i)
                    {
                        output.AddRange(QuitMenuTexts[i + NUM_QUIT_TEXTS_1].GetBytes(GetQuitTextLength(),
                            false, true));
                    }
                    break;

                case CONFIG_MENU_TEXT_POS:
                    foreach (var t in ConfigMenuTexts)
                    {
                        output.AddRange(t.GetBytes(GetConfigTextLength(), false, true));
                    }
                    break;

                case MAIN_MENU_TEXT_POS:
                    foreach (var t in MainMenuTexts)
                    {
                        output.AddRange(t.GetBytes(MENU_TEXT_LENGTH, false, true));
                    }
                    break;

                case STATUS_EFFECT_BATTLE_POS:
                    foreach (var s in StatusEffectsBattle)
                    {
                        output.AddRange(s.GetBytes(GetStatusEffectBattleLength(), false, true));
                    }
                    break;

                case BATTLE_ARENA_TEXT_POS:
                    int curr = 0;
                    for (i = 0; i < GetBattleArenaTextLengths(Language).Length; ++i)
                    {
                        for (int j = 0; j < GetBattleArenaTextLengths(Language)[i].Count; ++j)
                        {
                            output.AddRange(BattleArenaTexts[curr].GetBytes(GetBattleArenaTextLengths(Language)[i].Length,
                                false, true));
                            curr++;
                        }
                    }
                    break;

                case BIZARRO_MENU_TEXT_POS:
                    foreach (var t in BizarroMenuTexts)
                    {
                        output.AddRange(t.GetBytes(GetBizarroTextLength(), false, true));
                    }
                    break;

                case LIMIT_MENU_TEXT_POS:
                    foreach (var t in LimitMenuTexts)
                    {
                        output.AddRange(t.GetBytes(GetLimitMenuTextLength(), false, true));
                    }
                    break;

                case LIMIT_BREAK_POS:
                    foreach (var l in Limits)
                    {
                        output.AddRange(DataParser.GetAttackBytes(l));
                    }
                    break;

                case LIMIT_TEXT_POS:
                    for (i = 0; i < Kernel.PLAYABLE_CHARACTER_COUNT; ++i)
                    {
                        if (i < Kernel.PLAYABLE_CHARACTER_COUNT - 1)
                        {
                            output.AddRange(LimitSuccess[i].GetBytes(GetLimitTextLength(), false, true));
                            output.AddRange(LimitFail[i].GetBytes(GetLimitTextLength(), false, true));
                        }
                        else if (!isExe) //empty strings
                        {
                            output.AddRange(HexParser.GetNullBlock(GetLimitTextLength() * 2));
                        }
                        output.AddRange(LimitWrong[i].GetBytes(GetLimitTextLength(), false, true));
                    }
                    break;

                case STATUS_MENU_ELEMENT_POS:
                    foreach (var n in ElementNames)
                    {
                        output.AddRange(n.GetBytes(GetElementNameLength(), false, true));
                    }
                    break;

                case STATUS_EFFECTS_MENU_POS:
                    for (i = 0; i < NUM_STATUS_EFFECTS; ++i)
                    {
                        if (!(isExe && Language == Language.Spanish && i == 19))
                        {
                            output.AddRange(StatusEffectsMenu[i].GetBytes(MENU_TEXT_LENGTH, false, true));
                        }
                    }
                    break;

                case STATUS_MENU_TEXT_POS:
                    foreach (var t in StatusMenuTexts)
                    {
                        output.AddRange(t.GetBytes(GetStatusMenuTextLength(), false, true));
                    }
                    break;

                case EQUIP_MENU_TEXT_POS:
                    foreach (var t in EquipMenuTexts)
                    {
                        output.AddRange(t.GetBytes(GetEquipMenuTextLength(), false, true));
                    }
                    break;

                case UNEQUIP_TEXT_POS:
                    foreach (var t in UnequipTexts)
                    {
                        output.AddRange(t.GetBytes(GetUnequipTextLength(), false, true));
                    }
                    break;

                case MATERIA_MENU_TEXT_POS:
                    foreach (var t in MateriaMenuTexts)
                    {
                        output.AddRange(t.GetBytes(GetMateriaMenuTextLength(), false, true));
                    }
                    break;

                case MAGIC_MENU_TEXT_POS:
                    foreach (var t in MagicMenuTexts)
                    {
                        output.AddRange(t.GetBytes(GetMagicMenuTextLength(), false, true));
                    }
                    break;

                case ITEM_MENU_TEXT_POS:
                    foreach (var t in ItemMenuTexts)
                    {
                        output.AddRange(t.GetBytes(GetItemMenuTextLength(), false, true));
                    }
                    break;

                case ITEM_SORT_POS:
                    var itemPositions =
                        from item in ItemsSortedByName
                        orderby item.Key
                        select item.Value;
                    foreach (var p in itemPositions)
                    {
                        output.AddRange(BitConverter.GetBytes(p));
                    }
                    break;

                case MATERIA_PRIORITY_POS:
                    var materiaPositions =
                        from mat in MateriaPriority
                        orderby mat.Key
                        select mat.Value;
                    foreach (var p in materiaPositions)
                    {
                        output.Add(p);
                    }
                    break;

                case CHARACTER_NAMES_POS:
                    foreach (var n in CharacterNames)
                    {
                        output.AddRange(n.GetBytes(DataParser.CHARACTER_NAME_LENGTH, false, true));
                    }
                    break;

                case CAIT_SITH_DATA_POS:
                    if (CaitSith != null && Vincent != null)
                    {
                        output.AddRange(DataParser.GetCharacterInitialDataBytes(CaitSith));
                        output.AddRange(DataParser.GetCharacterInitialDataBytes(Vincent));
                    }
                    break;

                case SHOP_NAME_POS:
                    foreach (var n in ShopNames)
                    {
                        output.AddRange(n.GetBytes(GetShopNameLength(), false, true));
                    }
                    break;

                case SHOP_TEXT_POS:
                    foreach (var t in ShopText)
                    {
                        output.AddRange(t.GetBytes(SHOP_TEXT_LENGTH, false, true));
                    }
                    break;

                case SHOP_INVENTORY_POS:
                    foreach (var s in Shops)
                    {
                        output.AddRange(s.GetByteArray());
                    }
                    break;

                case ITEM_PRICE_DATA_POS:
                    foreach (var p in ItemPrices)
                    {
                        output.AddRange(BitConverter.GetBytes(p));
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
                    break;

                case MATERIA_PRICE_DATA_POS:
                    foreach (var p in MateriaPrices)
                    {
                        output.AddRange(BitConverter.GetBytes(p));
                    }
                    break;

                case SAVE_MENU_TEXT_POS:
                    foreach (var s in SaveMenuTexts)
                    {
                        output.AddRange(s.GetBytes(GetSaveTextLength(), false, true));
                    }
                    break;

                case AUDIO_VOLUME_POS:
                    foreach (var a in AudioVolume)
                    {
                        output.AddRange(BitConverter.GetBytes(a));
                    }
                    break;

                case AUDIO_PAN_POS:
                    foreach (var a in AudioPan)
                    {
                        output.AddRange(BitConverter.GetBytes(a));
                    }
                    break;

                case CHOCOBO_RACE_ITEMS_POS:
                    foreach (var t in ChocoboRacePrizes)
                    {
                        output.AddRange(t.GetBytes(GetItemNameLength()));
                    }
                    break;

                case CHOCOBO_NAMES_POS:
                    int count = GetNumChocoboNames(Language);
                    if (!isExe) { count++; }
                    for (i = 0; i < count; ++i)
                    {
                        output.AddRange(ChocoboNames[i].GetBytes(GetChocoboNameLength(), true));
                    }
                    break;
            }
            return output.ToArray();
        }

        //read data from the EXE
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

                            //get item sort values
                            stream.Seek(ITEM_SORT_POS, SeekOrigin.Begin);
                            for (i = 0; i < DataParser.MATERIA_START; ++i)
                            {
                                ItemsSortedByName.Add((ushort)i, reader.ReadUInt16());
                            }
                        }

                        //get arrays
                        foreach (var arr in ArrayInfoList)
                        {
                            byte[] temp;
                            int count = arr.Value.Count,
                                length = arr.Value.Length;
                            stream.Seek(arr.Key + arr.Value.Offset, SeekOrigin.Begin);
                            if (arr.Key == BATTLE_ARENA_TEXT_POS)
                            {
                                length = GetBattleArenaBlockLength();
                            }
                            else if (arr.Key == CHOCOBO_NAMES_POS)
                            {
                                count = GetNumChocoboNames(Language);
                            }
                            temp = reader.ReadBytes(count * length);
                            ReadArrayItems(temp, arr.Key, count, length, true, Language);
                        }

                        //get AP multiplier
                        stream.Seek(AP_MULTIPLIER_POS + GetAPPriceMultiplierOffset(), SeekOrigin.Begin);
                        APPriceMultiplier = reader.ReadByte();

                        //get Teioh's name
                        stream.Seek(TEIOH_POS + GetChocoboRaceOffset(), SeekOrigin.Begin);
                        ChocoboNames[GetNumChocoboNames(Language)] = new FFText(reader.ReadBytes(GetChocoboNameLength()));
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

                            //write item sort list
                            stream.Seek(ITEM_SORT_POS, SeekOrigin.Begin);
                            writer.Write(WriteData(ITEM_SORT_POS, true));
                        }

                        //write arrays
                        foreach (var str in ArrayInfoList)
                        {
                            if (!str.Value.KernelSynced || (DataManager.KernelFilePathExists && DataManager.Kernel != null))
                            {
                                stream.Seek(str.Key + str.Value.Offset, SeekOrigin.Begin);
                                writer.Write(WriteData(str.Key, true));
                            }
                        }

                        //write AP multiplier
                        stream.Seek(AP_MULTIPLIER_POS + GetAPPriceMultiplierOffset(), SeekOrigin.Begin);
                        writer.Write(APPriceMultiplier);
                        stream.Seek(AP_MASTER_OFFSET, SeekOrigin.Current);
                        writer.Write(APPriceMultiplier);

                        //write Teioh's name
                        stream.Seek(TEIOH_POS - GetChocoboRaceOffset(), SeekOrigin.Begin);
                        writer.Write(ChocoboNames[GetNumChocoboNames(Language)].GetBytes(GetChocoboNameLength()));
                    }
                    IsUnedited = false;
                }
                catch (IOException ex)
                {
                    Debug.WriteLine($"I/O error editing EXE: {ex}");
                    throw new IOException($"I/O error editing EXE: {ex.Message}", ex);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Debug.WriteLine($"Unauthorized access editing EXE: {ex}");
                    throw new UnauthorizedAccessException($"Unauthorized access editing EXE: {ex.Message}", ex);
                }
                catch (FormatException ex)
                {
                    Debug.WriteLine($"Format error editing EXE: {ex}");
                    throw new FormatException($"Format error editing EXE: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unexpected error editing EXE: {ex}");
                    throw new IOException($"Unexpected error editing EXE: {ex.Message}", ex);
                }
            }
        }

        //read data from a byte array
        public int ReadByteArray(byte[] data)
        {
            int result = 0;
            try
            {
                //check header
                var header = new byte[8];
                Array.Copy(data, header, 8);
                var txt = header != null && header.Length > 0 ? new FFText(header).ToString() : string.Empty;
                if (txt != "SCARLET") //invalid header, might be the old format
                {
                    ReadBytesOld(data);
                }
                else
                {
                    int length, count, size;
                    long pos;
                    bool isEnd = false;
                    using (var stream = new MemoryStream(data))
                    using (var reader = new BinaryReader(stream))
                    {
                        stream.Seek(8, SeekOrigin.Begin); //skip header
                        var lang = (Language)reader.ReadByte();

                        while (!isEnd)
                        {
                            try
                            {
                                pos = reader.ReadUInt32();
                                length = reader.ReadInt32();
                                count = reader.ReadInt32();
                                size = length * count;

                                if (ArrayInfoList.ContainsKey(pos)) //strings
                                {
                                    int temp = ReadArrayItems(reader.ReadBytes(size), pos, count, length, false, lang);
                                    if (temp == 1) { result = 1; }
                                }
                                else //other stuff
                                {
                                    switch (pos)
                                    {
                                        case AP_MULTIPLIER_POS:
                                            APPriceMultiplier = reader.ReadByte();
                                            break;

                                        case MODELS_POS:
                                            for (int i = 0; i < NUM_WALKABILITY_MODELS; i++)
                                            {
                                                int temp = reader.ReadInt32();
                                                var bytes = BitConverter.GetBytes(temp);
                                                ModelMoveBitmasks[i] = new BitArray(bytes);

                                                temp = reader.ReadInt32();
                                                bytes = BitConverter.GetBytes(temp);
                                                ModelDisembarkBitmasks[i] = new BitArray(bytes);
                                            }
                                            break;

                                        case ITEM_SORT_POS:
                                            ItemsSortedByName.Clear();
                                            for (int i = 0; i < DataParser.MATERIA_START; ++i)
                                            {
                                                ItemsSortedByName.Add((ushort)i, reader.ReadUInt16());
                                            }
                                            break;

                                        default: //unknown data
                                            stream.Seek(size, SeekOrigin.Current);
                                            break;
                                    }
                                }
                            }
                            catch (EndOfStreamException)
                            {
                                isEnd = true;
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                Debug.WriteLine($"Format error reading byte array: {ex}");
                throw new FormatException($"Format error reading byte array: {ex.Message}", ex);
            }
            catch (EndOfStreamException ex)
            {
                Debug.WriteLine($"Unexpected end of stream reading byte array: {ex}");
                throw new EndOfStreamException($"Unexpected end of stream: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error reading byte array: {ex}");
                throw new Exception($"Unexpected error: {ex.Message}", ex);
            }
            return result;
        }

        //output a header for byte array data
        private byte[] GetDataHeader(long pos, int length, int count)
        {
            var output = new byte[12];
            Array.Copy(BitConverter.GetBytes(pos), output, 4);
            Array.Copy(BitConverter.GetBytes(length), 0, output, 4, 4);
            Array.Copy(BitConverter.GetBytes(count), 0, output, 8, 4);
            return output;
        }

        //write data to a byte array
        public byte[] GetByteArray()
        {
            var output = new List<byte>();
            int i;

            //header
            output.AddRange(new FFText("SCARLET").GetBytes());
            output.Add((byte)Language);

            if (Language == Language.English)
            {
                //write walkability data
                output.AddRange(GetDataHeader(MODEL_CAN_WALK_POS[0], 8, NUM_WALKABILITY_MODELS));
                for (i = 0; i < NUM_WALKABILITY_MODELS; i++)
                {
                    if (ModelMoveBitmasks[i] != null)
                    {
                        var temp = new byte[4];
                        ModelMoveBitmasks[i].CopyTo(temp, 0);
                        output.AddRange(temp);
                    }
                    else { output.AddRange(HexParser.GetNullBlock(4)); }

                    if (ModelDisembarkBitmasks[i] != null)
                    {
                        var temp = new byte[4];
                        ModelDisembarkBitmasks[i].CopyTo(temp, 0);
                        output.AddRange(temp);
                    }
                    else { output.AddRange(HexParser.GetNullBlock(4)); }
                }

                //write item sort values
                output.AddRange(GetDataHeader(ITEM_SORT_POS, 4, DataParser.MATERIA_START));
                output.AddRange(WriteData(ITEM_SORT_POS));
            }

            //write AP multiplier
            output.AddRange(GetDataHeader(AP_MULTIPLIER_POS, 1,1));
            output.Add(APPriceMultiplier);

            //write materia equip effects
            output.AddRange(GetDataHeader(MATERIA_EQUIP_EFFECT_POS, MateriaEquipEffect.DATA_LENGTH,
                MateriaEquipEffect.COUNT));
            output.AddRange(WriteData(MATERIA_EQUIP_EFFECT_POS));

            //write quit text
            output.AddRange(GetDataHeader(QUIT_TEXT_POS_1, QUIT_TEXT_LENGTH_1, NUM_QUIT_TEXTS_1));
            output.AddRange(WriteData(QUIT_TEXT_POS_1));
            output.AddRange(GetDataHeader(QUIT_TEXT_POS_2, GetQuitTextLength(), NUM_QUIT_TEXTS_2));
            output.AddRange(WriteData(QUIT_TEXT_POS_2));

            //write config menu text
            output.AddRange(GetDataHeader(CONFIG_MENU_TEXT_POS, GetConfigTextLength(), NUM_CONFIG_MENU_TEXTS));
            output.AddRange(WriteData(CONFIG_MENU_TEXT_POS));

            //write main menu text
            output.AddRange(GetDataHeader(MAIN_MENU_TEXT_POS, MENU_TEXT_LENGTH, NUM_MENU_TEXTS));
            output.AddRange(WriteData(MAIN_MENU_TEXT_POS));

            //write status effects
            output.AddRange(GetDataHeader(STATUS_EFFECT_BATTLE_POS, GetStatusEffectBattleLength(),
                NUM_STATUS_EFFECTS));
            output.AddRange(WriteData(STATUS_EFFECT_BATTLE_POS));

            //write battle arena text
            output.AddRange(GetDataHeader(BATTLE_ARENA_TEXT_POS, GetBattleArenaBlockLength(), 1));
            output.AddRange(WriteData(BATTLE_ARENA_TEXT_POS));

            //write Bizarro menu text
            output.AddRange(GetDataHeader(BIZARRO_MENU_TEXT_POS, GetBizarroTextLength(),
                NUM_BIZARRO_MENU_TEXTS));
            output.AddRange(WriteData(BIZARRO_MENU_TEXT_POS));

            //write limit menu text
            output.AddRange(GetDataHeader(LIMIT_MENU_TEXT_POS, GetLimitMenuTextLength(), NUM_LIMIT_MENU_TEXTS));
            output.AddRange(WriteData(LIMIT_MENU_TEXT_POS));

            //write limit breaks
            output.AddRange(GetDataHeader(LIMIT_BREAK_POS, DataParser.ATTACK_BLOCK_SIZE, NUM_LIMITS));
            output.AddRange(WriteData(LIMIT_BREAK_POS));

            //write element names
            output.AddRange(GetDataHeader(STATUS_MENU_ELEMENT_POS, GetElementNameLength(), NUM_ELEMENTS));
            output.AddRange(WriteData(STATUS_MENU_ELEMENT_POS));

            //write status effects (menu)
            output.AddRange(GetDataHeader(STATUS_EFFECTS_MENU_POS, MENU_TEXT_LENGTH, NUM_STATUS_EFFECTS));
            output.AddRange(WriteData(STATUS_EFFECTS_MENU_POS));

            //write status menu text
            output.AddRange(GetDataHeader(STATUS_MENU_TEXT_POS, GetStatusMenuTextLength(), NUM_STATUS_MENU_TEXTS));
            output.AddRange(WriteData(STATUS_MENU_TEXT_POS));

            //write equip menu text
            output.AddRange(GetDataHeader(EQUIP_MENU_TEXT_POS, GetEquipMenuTextLength(), NUM_EQUIP_MENU_TEXTS));
            output.AddRange(WriteData(EQUIP_MENU_TEXT_POS));

            //write unequip text
            output.AddRange(GetDataHeader(UNEQUIP_TEXT_POS, GetUnequipTextLength(), NUM_UNEQUIP_TEXTS));
            output.AddRange(WriteData(UNEQUIP_TEXT_POS));

            //write materia menu text
            output.AddRange(GetDataHeader(MATERIA_MENU_TEXT_POS, GetMateriaMenuTextLength(), NUM_MATERIA_MENU_TEXTS));
            output.AddRange(WriteData(MATERIA_MENU_TEXT_POS));

            //write magic menu text
            output.AddRange(GetDataHeader(MAGIC_MENU_TEXT_POS, GetMagicMenuTextLength(), NUM_MAGIC_MENU_TEXTS));
            output.AddRange(WriteData(MAGIC_MENU_TEXT_POS));

            //write item menu text
            output.AddRange(GetDataHeader(ITEM_MENU_TEXT_POS, GetItemMenuTextLength(), NUM_ITEM_MENU_TEXTS));
            output.AddRange(WriteData(ITEM_MENU_TEXT_POS));

            //write L4 limit text
            output.AddRange(GetDataHeader(LIMIT_TEXT_POS, GetLimitTextLength(),
                Kernel.PLAYABLE_CHARACTER_COUNT * 3));
            output.AddRange(WriteData(LIMIT_TEXT_POS));

            //write materia priority list
            output.AddRange(GetDataHeader(MATERIA_PRIORITY_POS, 1, Kernel.MATERIA_COUNT));
            output.AddRange(WriteData(MATERIA_PRIORITY_POS));

            //write character names
            output.AddRange(GetDataHeader(CHARACTER_NAMES_POS, DataParser.CHARACTER_NAME_LENGTH,
                NUM_CHARACTER_NAMES));
            output.AddRange(WriteData(CHARACTER_NAMES_POS));

            //write Cait Sith/Vincent data
            if (CaitSith != null && Vincent != null)
            {
                output.AddRange(GetDataHeader(CAIT_SITH_DATA_POS, DataParser.CHARACTER_RECORD_LENGTH, 2));
                output.AddRange(WriteData(CAIT_SITH_DATA_POS));
            }

            //write shop names
            output.AddRange(GetDataHeader(SHOP_NAME_POS, GetShopNameLength(), NUM_SHOP_NAMES));
            output.AddRange(WriteData(SHOP_NAME_POS));

            //write shop text
            output.AddRange(GetDataHeader(SHOP_TEXT_POS, SHOP_TEXT_LENGTH, NUM_SHOP_TEXTS));
            output.AddRange(WriteData(SHOP_TEXT_POS));

            //write save menu text
            output.AddRange(GetDataHeader(SAVE_MENU_TEXT_POS, GetSaveTextLength(), NUM_SAVE_MENU_TEXTS));
            output.AddRange(WriteData(SAVE_MENU_TEXT_POS));

            //write audio volume
            output.AddRange(GetDataHeader(AUDIO_VOLUME_POS, 4, NUM_AUDIO_VALUES));
            output.AddRange(WriteData(AUDIO_VOLUME_POS));

            //write audio pan
            output.AddRange(GetDataHeader(AUDIO_PAN_POS, 4, NUM_AUDIO_VALUES));
            output.AddRange(WriteData(AUDIO_PAN_POS));

            //write chocobo race prizes
            output.AddRange(GetDataHeader(CHOCOBO_RACE_ITEMS_POS, GetItemNameLength(), NUM_CHOCOBO_RACE_ITEMS));
            output.AddRange(WriteData(CHOCOBO_RACE_ITEMS_POS));

            //write chocobo names
            output.AddRange(GetDataHeader(CHOCOBO_NAMES_POS, GetChocoboNameLength(), GetNumChocoboNames(Language) + 1));
            output.AddRange(WriteData(CHOCOBO_NAMES_POS));

            //kernel-synced stuff
            if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
            {
                //write shop inventories
                output.AddRange(GetDataHeader(SHOP_INVENTORY_POS, ShopInventory.SHOP_DATA_LENGTH,
                    NUM_SHOPS));
                output.AddRange(WriteData(SHOP_INVENTORY_POS));

                //write item prices
                output.AddRange(GetDataHeader(ITEM_PRICE_DATA_POS, 4, DataParser.MATERIA_START));
                output.AddRange(WriteData(ITEM_PRICE_DATA_POS));

                //write materia prices
                output.AddRange(GetDataHeader(MATERIA_PRICE_DATA_POS, 4, Kernel.MATERIA_COUNT));
                output.AddRange(WriteData(MATERIA_PRICE_DATA_POS));
            }
            return output.ToArray();
        }

        //read data from a byte array (old version)
        private void ReadBytesOld(byte[] bytes)
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
                                GetMateriaMenuTextLength());
                            stream.Seek(MateriaMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read equip menu text
                        for (i = 0; i < NUM_EQUIP_MENU_TEXTS; ++i)
                        {
                            EquipMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                GetEquipMenuTextLength());
                            stream.Seek(EquipMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read element names
                        for (i = 0; i < NUM_ELEMENTS; ++i)
                        {
                            ElementNames[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                GetElementNameLength());
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
                                GetStatusMenuTextLength());
                            stream.Seek(StatusMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read chocobo names
                        for (i = 0; i < GetNumChocoboNames(Language) + 1; ++i)
                        {
                            ChocoboNames[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                GetChocoboNameLength());
                            stream.Seek(GetChocoboNameLength(), SeekOrigin.Current);
                        }

                        //read item names
                        for (i = 0; i < NUM_CHOCOBO_RACE_ITEMS; ++i)
                        {
                            ChocoboRacePrizes[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                GetItemNameLength());
                            stream.Seek(GetItemNameLength(), SeekOrigin.Current);
                        }

                        //read item menu text
                        for (i = 0; i < NUM_ITEM_MENU_TEXTS; ++i)
                        {
                            ItemMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                GetItemMenuTextLength());
                            stream.Seek(ItemMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read magic menu text
                        for (i = 0; i < NUM_MAGIC_MENU_TEXTS; ++i)
                        {
                            MagicMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                GetMagicMenuTextLength());
                            stream.Seek(MagicMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read unequip text
                        for (i = 0; i < NUM_UNEQUIP_TEXTS; ++i)
                        {
                            UnequipTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                GetUnequipTextLength());
                            stream.Seek(UnequipTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read limit menu text
                        for (i = 0; i < NUM_LIMIT_MENU_TEXTS; ++i)
                        {
                            LimitMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                GetLimitMenuTextLength());
                            stream.Seek(LimitMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read save menu text
                        for (i = 0; i < NUM_SAVE_MENU_TEXTS; ++i)
                        {
                            SaveMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                GetSaveTextLength());
                            stream.Seek(SaveMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read quit text
                        for (i = 0; i < NUM_QUIT_TEXTS_1 + NUM_QUIT_TEXTS_2; ++i)
                        {
                            SaveMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                QUIT_TEXT_LENGTH_1);
                            stream.Seek(SaveMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read battle arena text
                        int curr = 0;
                        var lengths = GetBattleArenaTextLengths(Language);
                        for (i = 0; i < lengths.Length; ++i)
                        {
                            int len = lengths[i].Length;
                            for (int j = 0; j < lengths[i].Count; ++j)
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
                                GetBizarroTextLength());
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

        //read data from a file
        public int ReadFile(string path)
        {
            try
            {
                var result = ReadByteArray(File.ReadAllBytes(path));
                return result;
            }
            catch (EndOfStreamException ex)
            {
                Debug.WriteLine($"Unexpected end of stream reading file: {ex}");
                throw new EndOfStreamException($"Unexpected end of stream: {ex.Message}", ex);
            }
            catch (IOException ex)
            {
                Debug.WriteLine($"I/O error reading file: {ex}");
                throw new IOException($"I/O error reading file: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error reading file: {ex}");
                throw new IOException($"Unexpected error reading file: {ex.Message}", ex);
            }
        }

        //write data to a file
        public void WriteFile(string path)
        {
            try
            {
                File.WriteAllBytes(path, GetByteArray());
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
                        QUIT_TEXT_POS_2, GetQuitTextLength(), NUM_QUIT_TEXTS_2, NUM_QUIT_TEXTS_1));

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
                    var lengths = GetBattleArenaTextLengths(Language);
                    for (i = 0; i < lengths.Length; ++i)
                    {
                        writer.Write(WriteHextStrings(BattleArenaTexts, original.BattleArenaTexts,
                            pos, lengths[i].Length, lengths[i].Count, offset));
                        offset += lengths[i].Count;
                        pos += (lengths[i].Length * lengths[i].Count);
                    }

                    //write Bizarro menu text
                    writer.Write(WriteHextStrings(BizarroMenuTexts, original.BizarroMenuTexts,
                        BIZARRO_MENU_TEXT_POS, GetBizarroTextLength(), NUM_BIZARRO_MENU_TEXTS));

                    //write limit menu text
                    writer.Write(WriteHextStrings(LimitMenuTexts, original.LimitMenuTexts,
                        LIMIT_MENU_TEXT_POS, GetLimitMenuTextLength(), NUM_LIMIT_MENU_TEXTS));

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
                        STATUS_MENU_ELEMENT_POS, GetElementNameLength(), NUM_ELEMENTS));

                    //write status effects (menu)
                    writer.Write(WriteHextStrings(StatusEffectsMenu, original.StatusEffectsMenu,
                        STATUS_EFFECTS_MENU_POS, MENU_TEXT_LENGTH, NUM_STATUS_EFFECTS));

                    //write status menu text
                    writer.Write(WriteHextStrings(StatusMenuTexts, original.StatusMenuTexts,
                        STATUS_MENU_TEXT_POS, GetStatusMenuTextLength(), NUM_STATUS_MENU_TEXTS));

                    //write equip menu text
                    writer.Write(WriteHextStrings(EquipMenuTexts, original.EquipMenuTexts,
                        EQUIP_MENU_TEXT_POS, GetEquipMenuTextLength(), NUM_EQUIP_MENU_TEXTS));

                    //write unequip text
                    writer.Write(WriteHextStrings(UnequipTexts, original.UnequipTexts,
                        UNEQUIP_TEXT_POS, GetUnequipTextLength(), NUM_UNEQUIP_TEXTS));

                    //write materia menu text
                    writer.Write(WriteHextStrings(MateriaMenuTexts, original.MateriaMenuTexts,
                        MATERIA_MENU_TEXT_POS, GetMateriaMenuTextLength(), NUM_MATERIA_MENU_TEXTS));

                    //write magic menu text
                    writer.Write(WriteHextStrings(MagicMenuTexts, original.MagicMenuTexts,
                        MAGIC_MENU_TEXT_POS, GetMagicMenuTextLength(), NUM_MAGIC_MENU_TEXTS));

                    //write item menu text
                    writer.Write(WriteHextStrings(ItemMenuTexts, original.ItemMenuTexts,
                        ITEM_MENU_TEXT_POS, GetItemMenuTextLength(), NUM_ITEM_MENU_TEXTS));

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
                        CHARACTER_NAMES_POS, DataParser.CHARACTER_NAME_LENGTH, NUM_CHARACTER_NAMES));

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
                            SAVE_MENU_TEXT_POS, GetSaveTextLength(), NUM_SAVE_MENU_TEXTS));

                        //compare Teioh's name
                        string name1 = ChocoboNames[GetNumChocoboNames(Language)].ToString(),
                            name2 = original.ChocoboNames[GetNumChocoboNames(Language)].ToString();

                        if (name1 != name2)
                        {
                            checker = true;
                            writer.WriteLine($"# {name2} -> {name1}");
                            var temp = ChocoboNames[GetNumChocoboNames(Language)].GetBytes();
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
                            CHOCOBO_RACE_ITEMS_POS, GetItemNameLength(), NUM_CHOCOBO_RACE_ITEMS));

                        //write chocobo racer names (besides Teioh)
                        writer.Write(WriteHextStrings(ChocoboNames, original.ChocoboNames,
                            CHOCOBO_NAMES_POS, GetChocoboNameLength(), GetNumChocoboNames(Language)));
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
