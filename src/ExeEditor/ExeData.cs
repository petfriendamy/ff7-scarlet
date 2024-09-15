using FF7Scarlet.KernelEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Characters;
using System.Security.Cryptography;

namespace FF7Scarlet.ExeEditor
{
    public enum Language { English, Spanish, French, German }

    public class ExeData
    {
        //constants
        private static readonly int[] EXE_HEADER = { 0x4D, 0x5A, 0x90 };
        public const string CONFIG_KEY = "VanillaExePath";
        public const int
            NUM_MENU_TEXTS = 23,
            NUM_MATERIA_TEXTS = 42,
            NUM_CONFIG_TEXTS = 51,
            NUM_STATUS_EFFECTS = 27,
            NUM_LIMITS = 71,
            NUM_CHARACTER_NAMES = 10,
            NUM_SHOPS = 80,
            NUM_SHOP_NAMES = 9,
            NUM_SHOP_TEXTS = 18,
            NUM_CHOCOBO_NAMES = 46,
            NUM_CHOCOBO_RACE_ITEMS = 24,
            
            MENU_TEXT_LENGTH = 20,
            SHOP_TEXT_LENGTH = 46,
            CHOCOBO_NAME_LENGTH = 7,
            ITEM_NAME_LENGTH = 16;

        private const long
            HEXT_OFFSET_1 = 0x400C00,
            HEXT_OFFSET_2 = 0x401600,

            TEST_BYTE_POS = 0x94,
            AP_MULTIPLIER_POS = 0x31F14F,
            AP_MASTER_OFFSET = 0x4F,
            CONFIG_MENU_TEXT_POS = 0x5188A8,
            MAIN_MENU_TEXT_POS = 0x5192C0,
            MATERIA_PRIORITY_POS = 0x519498,
            STATUS_EFFECT_POS = 0x51D228,
            LIMIT_BREAK_POS = 0x51E0D4,
            MATERIA_MENU_TEXT_POS = 0x51F5A8,
            LIMIT_TEXT_POS = 0x51FBF0,
            ITEM_SORT_POS = 0x51FF48,
            NAME_DATA_POS = 0x5206B8,
            CAIT_SITH_DATA_POS = 0x520C10,
            SHOP_NAME_POS = 0x5219C8,
            SHOP_TEXT_POS = 0x521A80,
            SHOP_INVENTORY_POS = 0x521E18,
            ITEM_PRICE_DATA_POS = 0x523858,
            MATERIA_PRICE_DATA_POS = 0x523E58,
            TEIOH_POS = 0x57B2A8,
            CHOCOBO_RACE_ITEMS_POS = 0x57B3D0,
            CHOCOBO_NAMES_POS = 0x57B658;

        //properties
        public string FilePath { get; private set; } = string.Empty;
        public Language Language { get; private set; }
        public Attack[] Limits { get; } = new Attack[NUM_LIMITS];
        public FFText[] LimitSuccess { get; } = new FFText[Kernel.PLAYABLE_CHARACTER_COUNT - 1];
        public FFText[] LimitFail { get; } = new FFText[Kernel.PLAYABLE_CHARACTER_COUNT - 1];
        public FFText[] LimitWrong { get; } = new FFText[Kernel.PLAYABLE_CHARACTER_COUNT];
        public FFText[] MainMenuTexts { get; } = new FFText[NUM_MENU_TEXTS];
        public FFText[] MateriaMenuTexts { get; } = new FFText[NUM_MATERIA_TEXTS];
        public FFText[] ConfigMenuTexts { get; } = new FFText[NUM_CONFIG_TEXTS];
        public FFText[] StatusEffects { get; } = new FFText[NUM_STATUS_EFFECTS];
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
        public bool IsUnedited { get; private set; }


        public ExeData(string path)
        {
            ReadEXE(path);
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

        public int GetStatusEffectLength()
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
                            //get materia priority values
                            stream.Seek(MATERIA_PRIORITY_POS, SeekOrigin.Begin);
                            for (i = 0; i < DataParser.MATERIA_COUNT; ++i)
                            {
                                MateriaPriority.Add((byte)i, reader.ReadByte());
                            }

                            //get item sort values
                            stream.Seek(ITEM_SORT_POS, SeekOrigin.Begin);
                            for (i = 0; i < DataParser.MATERIA_START; ++i)
                            {
                                ItemsSortedByName.Add((ushort)i, reader.ReadUInt16());
                            }

                            //get materia menu text
                            stream.Seek(MATERIA_MENU_TEXT_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_MATERIA_TEXTS; ++i)
                            {
                                MateriaMenuTexts[i] = new FFText(reader.ReadBytes(MENU_TEXT_LENGTH));
                            }

                            //get chocobo race prizes
                            stream.Seek(CHOCOBO_RACE_ITEMS_POS, SeekOrigin.Begin);
                            for (i = 0; i < NUM_CHOCOBO_RACE_ITEMS; ++i)
                            {
                                ChocoboRacePrizes[i] = new FFText(reader.ReadBytes(ITEM_NAME_LENGTH));
                            }

                            //get Teioh's name
                            stream.Seek(TEIOH_POS, SeekOrigin.Begin);
                            ChocoboNames[NUM_CHOCOBO_NAMES] = new FFText(reader.ReadBytes(CHOCOBO_NAME_LENGTH));

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
                        for (i = 0; i < NUM_CONFIG_TEXTS; ++i)
                        {
                            ConfigMenuTexts[i] = new FFText(reader.ReadBytes(GetConfigTextLength()));
                        }

                        //get main menu text
                        stream.Seek(MAIN_MENU_TEXT_POS + GetMainMenuOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_MENU_TEXTS; ++i)
                        {
                            MainMenuTexts[i] = new FFText(reader.ReadBytes(MENU_TEXT_LENGTH));
                        }

                        //get status effects
                        stream.Seek(STATUS_EFFECT_POS + GetStatusOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_STATUS_EFFECTS; ++i)
                        {
                            StatusEffects[i] = new FFText(reader.ReadBytes(GetStatusEffectLength()));
                        }

                        //get limit breaks
                        stream.Seek(LIMIT_BREAK_POS + GetLimitOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_LIMITS; ++i)
                        {
                            DataParser.ReadAttack((ushort)i, $"(Limit #{i})", reader.ReadBytes(DataParser.ATTACK_BLOCK_SIZE));
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

                            //write config menu text
                            stream.Seek(MATERIA_MENU_TEXT_POS, SeekOrigin.Begin);
                            foreach (var t in MateriaMenuTexts)
                            {
                                writer.Write(t.GetBytes(MENU_TEXT_LENGTH));
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
                            writer.Write(t.GetBytes(GetConfigTextLength()));
                        }

                        //write main menu text
                        stream.Seek(MAIN_MENU_TEXT_POS + GetMainMenuOffset(), SeekOrigin.Begin);
                        foreach (var t in MainMenuTexts)
                        {
                            writer.Write(t.GetBytes(MENU_TEXT_LENGTH));
                        }

                        //write status effects
                        stream.Seek(STATUS_EFFECT_POS + GetStatusOffset(), SeekOrigin.Begin);
                        foreach (var s in StatusEffects)
                        {
                            writer.Write(s.GetBytes(GetStatusEffectLength()));
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
                                writer.Write(LimitSuccess[i].GetBytes(GetLimitTextLength()));
                                writer.Write(LimitFail[i].GetBytes(GetLimitTextLength()));
                            }
                            writer.Write(LimitWrong[i].GetBytes(GetLimitTextLength()));
                        }

                        //write character names
                        stream.Seek(NAME_DATA_POS + GetNameOffset(), SeekOrigin.Begin);
                        foreach (var n in CharacterNames)
                        {
                            writer.Write(n.GetBytes(DataParser.CHARACTER_NAME_LENGTH));
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
                            writer.Write(n.GetBytes(GetShopNameLength()));
                        }

                        //write shop text
                        stream.Seek(SHOP_TEXT_POS + GetShopTextOffset(), SeekOrigin.Begin);
                        foreach (var t in ShopText)
                        {
                            writer.Write(t.GetBytes(SHOP_TEXT_LENGTH));
                        }

                        //write shop inventories
                        stream.Seek(SHOP_INVENTORY_POS + GetShopOffset(), SeekOrigin.Begin);
                        foreach (var s in Shops)
                        {
                            writer.Write(s.GetByteArray());
                        }

                        if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
                        {
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
                    for (i = 0; i < NUM_CONFIG_TEXTS; ++i)
                    {
                        ConfigMenuTexts[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetConfigTextLength());
                        stream.Seek(ConfigMenuTexts[i].ToString().Length + 1, SeekOrigin.Current);
                    }

                    //read status effects
                    for (i = 0; i < NUM_STATUS_EFFECTS; ++i)
                    {
                        StatusEffects[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetStatusEffectLength());
                        stream.Seek(StatusEffects[i].ToString().Length + 1, SeekOrigin.Current);
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

                        //read chocobo names
                        for (i = 0; i < NUM_CHOCOBO_NAMES; ++i)
                        {
                            ChocoboNames[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                CHOCOBO_NAME_LENGTH);
                            stream.Seek(ChocoboNames[i].ToString().Length + 1, SeekOrigin.Current);
                        }

                        //read item names
                        for (i = 0; i < NUM_CHOCOBO_RACE_ITEMS; ++i)
                        {
                            ChocoboRacePrizes[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                                ITEM_NAME_LENGTH);
                            stream.Seek(ChocoboRacePrizes[i].ToString().Length + 1, SeekOrigin.Current);
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
            foreach (var s in StatusEffects)
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
                        pos = AP_MULTIPLIER_POS + HEXT_OFFSET_1;
                        writer.WriteLine($"{pos:X2} = {APPriceMultiplier:X2}");
                        pos += AP_MASTER_OFFSET;
                        writer.WriteLine($"{pos:X2} = {APPriceMultiplier:X2}");
                        writer.WriteLine();
                    }

                    //compare config menu text
                    for (i = 0; i < NUM_CONFIG_TEXTS; ++i)
                    {
                        string text1 = ConfigMenuTexts[i].ToString(),
                            text2 = original.ConfigMenuTexts[i].ToString();

                        if (text1 != text2)
                        {
                            checker = true;
                            writer.WriteLine($"# {text2} -> {text1}");
                            var temp = ConfigMenuTexts[i].GetBytes();
                            pos = CONFIG_MENU_TEXT_POS + HEXT_OFFSET_2 + (GetConfigTextLength() * i);
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

                    //compare main menu text
                    for (i = 0; i < NUM_MENU_TEXTS; ++i)
                    {
                        string text1 = MainMenuTexts[i].ToString(),
                            text2 = original.MainMenuTexts[i].ToString();

                        if (text1 != text2)
                        {
                            checker = true;
                            writer.WriteLine($"# {text2} -> {text1}");
                            var temp = MainMenuTexts[i].GetBytes();
                            pos = MAIN_MENU_TEXT_POS + HEXT_OFFSET_2 + (MENU_TEXT_LENGTH * i);
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

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
                                pos = MATERIA_PRIORITY_POS + HEXT_OFFSET_2 + i;
                                writer.Write($"{pos:X2} = ");
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

                    //compare status effects
                    for (i = 0; i < NUM_STATUS_EFFECTS; ++i)
                    {
                        string text1 = StatusEffects[i].ToString(),
                            text2 = original.StatusEffects[i].ToString();

                        if (text1 != text2)
                        {
                            checker = true;
                            writer.WriteLine($"# {text2} -> {text1}");
                            var temp = StatusEffects[i].GetBytes();
                            pos = STATUS_EFFECT_POS + HEXT_OFFSET_2 + (GetStatusEffectLength() * i);
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

                    //compare limits
                    for (i = 0; i < NUM_LIMITS; ++i)
                    {
                        if (!DataParser.AttacksAreIdentical(Limits[i], original.Limits[i]))
                        {
                            byte[] temp1 = DataParser.GetAttackBytes(Limits[i]),
                                temp2 = DataParser.GetAttackBytes(original.Limits[i]);
                            diff = false;

                            writer.WriteLine($"# {original.Limits[i].Name}");
                            for (i = 0; i < DataParser.ATTACK_BLOCK_SIZE; ++i)
                            {
                                if (temp1[i] != temp2[i])
                                {
                                    if (!diff)
                                    {
                                        pos = LIMIT_BREAK_POS + HEXT_OFFSET_2 + i;
                                        writer.Write($"{pos:X2} = ");
                                        diff = true;
                                    }
                                    writer.Write($"{temp1[i]:X2} ");
                                }
                                else
                                {
                                    if (diff)
                                    {
                                        writer.WriteLine();
                                        diff = false;
                                    }
                                }
                            }
                            writer.WriteLine();
                        }
                    }

                    //compare materia menu text
                    for (i = 0; i < NUM_MATERIA_TEXTS; ++i)
                    {
                        string text1 = MateriaMenuTexts[i].ToString(),
                            text2 = original.MateriaMenuTexts[i].ToString();

                        if (text1 != text2)
                        {
                            checker = true;
                            writer.WriteLine($"# {text2} -> {text1}");
                            var temp = MateriaMenuTexts[i].GetBytes();
                            pos = MATERIA_MENU_TEXT_POS + HEXT_OFFSET_2 + (MENU_TEXT_LENGTH * i);
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

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
                                pos = LIMIT_TEXT_POS + HEXT_OFFSET_2 + (GetLimitTextLength() * j);
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
                                pos = LIMIT_TEXT_POS + HEXT_OFFSET_2 + (GetLimitTextLength() * j);
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
                            pos = LIMIT_TEXT_POS + HEXT_OFFSET_2 + (GetLimitTextLength() * j);
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }
                        j++;
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
                                pos = ITEM_SORT_POS + HEXT_OFFSET_2 + (i * 2);
                                writer.Write($"{pos:X2} = ");
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

                    //compare character names
                    for (i = 0; i < NUM_CHARACTER_NAMES; ++i)
                    {
                        string name1 = CharacterNames[i].ToString(),
                            name2 = original.CharacterNames[i].ToString();

                        if (name1 != name2)
                        {
                            checker = true;
                            writer.WriteLine($"# {name2} -> {name1}");
                            var temp = CharacterNames[i].GetBytes();
                            pos = NAME_DATA_POS + HEXT_OFFSET_2 + (DataParser.CHARACTER_NAME_LENGTH * i);
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
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
                        if (!DataParser.CharacterDataIsIdentical(CaitSith, original.CaitSith))
                        {
                            byte[] temp1 = DataParser.GetCharacterInitialDataBytes(CaitSith),
                                temp2 = DataParser.GetCharacterInitialDataBytes(original.CaitSith);
                            diff = false;

                            writer.WriteLine("# Cait Sith's initial data");
                            for (i = 0; i < DataParser.CHARACTER_RECORD_LENGTH; ++i)
                            {
                                if (temp1[i] != temp2[i])
                                {
                                    if (!diff)
                                    {
                                        pos = CAIT_SITH_DATA_POS + HEXT_OFFSET_2 + i;
                                        writer.Write($"{pos:X2} = ");
                                        diff = true;
                                    }
                                    writer.Write($"{temp1[i]:X2} ");
                                }
                                else
                                {
                                    if (diff)
                                    {
                                        writer.WriteLine();
                                        diff = false;
                                    }
                                }
                            }
                            writer.WriteLine();
                        }
                    }

                    //compare Vincent's data
                    if (Vincent != null && original.Vincent != null)
                    {
                        if (!DataParser.CharacterDataIsIdentical(Vincent, original.Vincent))
                        {
                            byte[] temp1 = DataParser.GetCharacterInitialDataBytes(Vincent),
                                temp2 = DataParser.GetCharacterInitialDataBytes(original.Vincent);
                            diff = false;

                            writer.WriteLine("# Vincent's initial data");
                            for (i = 0; i < DataParser.CHARACTER_RECORD_LENGTH; ++i)
                            {
                                if (temp1[i] != temp2[i])
                                {
                                    if (!diff)
                                    {
                                        pos = CAIT_SITH_DATA_POS + HEXT_OFFSET_2 + DataParser.CHARACTER_RECORD_LENGTH + i;
                                        writer.Write($"{pos:X2} = ");
                                        diff = true;
                                    }
                                    writer.Write($"{temp1[i]:X2} ");
                                }
                                else
                                {
                                    if (diff)
                                    {
                                        writer.WriteLine();
                                        diff = false;
                                    }
                                }
                            }
                            writer.WriteLine();
                        }
                    }

                    //compare shop names
                    for (i = 0; i < NUM_SHOP_NAMES; ++i)
                    {
                        string name1 = ShopNames[i].ToString(),
                            name2 = original.ShopNames[i].ToString();

                        if (name1 != name2)
                        {
                            checker = true;
                            writer.WriteLine($"# {name2} -> {name1}");
                            var temp = ShopNames[i].GetBytes();
                            pos = SHOP_NAME_POS + HEXT_OFFSET_2 + (GetShopNameLength() * i);
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

                    //compare shop text
                    for (i = 0; i < NUM_SHOP_TEXTS; ++i)
                    {
                        string text1 = ShopText[i].ToString(),
                            text2 = original.ShopText[i].ToString();

                        if (text1 != text2)
                        {
                            checker = true;
                            writer.WriteLine($"# {text2} -> {text1}");
                            var temp = ShopText[i].GetBytes();
                            pos = SHOP_TEXT_POS + HEXT_OFFSET_2 + (SHOP_TEXT_LENGTH * i);
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }
                    }
                    if (checker)
                    {
                        writer.WriteLine();
                        checker = false;
                    }

                    //compare shop inventories
                    if (DataManager.Kernel != null)
                    {
                        for (i = 0; i < NUM_SHOPS; ++i)
                        {
                            if (Shops[i].HasDifferences(original.Shops[i]))
                            {
                                writer.WriteLine($"# {ShopData.SHOP_NAMES[i]}");
                                var temp1 = Shops[i].GetByteArray();
                                var temp2 = original.Shops[i].GetByteArray();
                                diff = false;

                                for (j = 0; j < ShopInventory.SHOP_DATA_LENGTH; ++j)
                                {
                                    if (temp1[j] != temp2[j])
                                    {
                                        checker = true;
                                        if (!diff)
                                        {
                                            pos = SHOP_INVENTORY_POS + HEXT_OFFSET_2 + (ShopInventory.SHOP_DATA_LENGTH * i) + j;
                                            writer.Write($"{pos:X2} = ");
                                            diff = true;
                                        }
                                        writer.Write($"{temp1[j]:X2} ");
                                    }
                                    else
                                    {
                                        if (diff)
                                        {
                                            writer.WriteLine();
                                            diff = false;
                                        }
                                    }
                                }
                                writer.WriteLine();
                            }
                        }

                        //compare item prices
                        for (i = 0; i < DataParser.ITEM_COUNT; ++i)
                        {
                            if (ItemPrices[i] != original.ItemPrices[i])
                            {
                                writer.WriteLine($"# {DataManager.Kernel.ItemData.Items[i].Name} price");
                                pos = ITEM_PRICE_DATA_POS + HEXT_OFFSET_2 + (i * 4);
                                writer.Write($"{pos:X2} = ");
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
                                pos = ITEM_PRICE_DATA_POS + HEXT_OFFSET_2 + (DataParser.WEAPON_START * 4) + (i * 4);
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
                                pos = ITEM_PRICE_DATA_POS + HEXT_OFFSET_2 + (DataParser.ARMOR_START * 4) + (i * 4);
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
                                pos = ITEM_PRICE_DATA_POS + HEXT_OFFSET_2 + (DataParser.ACCESSORY_START * 4) + (i * 4);
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
                                pos = MATERIA_PRICE_DATA_POS + HEXT_OFFSET_2 + (i * 4);
                                writer.Write($"{pos:X2} = ");
                                foreach (var b in BitConverter.GetBytes(MateriaPrices[i]))
                                {
                                    writer.Write($"{b:X2} ");
                                }
                                writer.WriteLine();
                                writer.WriteLine();
                            }
                        }

                        //compare Teioh's name
                        string name1 = ChocoboNames[NUM_CHOCOBO_NAMES].ToString(),
                            name2 = original.ChocoboNames[NUM_CHOCOBO_NAMES].ToString();

                        if (name1 != name2)
                        {
                            checker = true;
                            writer.WriteLine($"# {name2} -> {name1}");
                            var temp = ChocoboNames[NUM_CHOCOBO_NAMES].GetBytes();
                            pos = TEIOH_POS + HEXT_OFFSET_2;
                            writer.Write($"{pos:X2} = ");
                            foreach (var x in temp)
                            {
                                writer.Write($"{x:X2} ");
                            }
                            writer.WriteLine();
                        }

                        //compare chocobo race prizes
                        for (i = 0; i < NUM_CHOCOBO_RACE_ITEMS; ++i)
                        {
                            string text1 = ChocoboRacePrizes[i].ToString(),
                                text2 = original.ChocoboRacePrizes[i].ToString();

                            if (text1 != text2)
                            {
                                checker = true;
                                writer.WriteLine($"# {text2} -> {text1}");
                                var temp = ChocoboRacePrizes[i].GetBytes();
                                pos = CHOCOBO_RACE_ITEMS_POS + HEXT_OFFSET_2 + (ITEM_NAME_LENGTH * i);
                                writer.Write($"{pos:X2} = ");
                                foreach (var x in temp)
                                {
                                    writer.Write($"{x:X2} ");
                                }
                                writer.WriteLine();
                            }
                        }
                        if (checker)
                        {
                            writer.WriteLine();
                            checker = false;
                        }

                        //compare chocobo racer names (besides Teioh)
                        for (i = 0; i < NUM_CHOCOBO_NAMES - 1; ++i)
                        {
                            string text1 = ChocoboNames[i].ToString(),
                                text2 = original.ChocoboNames[i].ToString();

                            if (text1 != text2)
                            {
                                checker = true;
                                writer.WriteLine($"# {text2} -> {text1}");
                                var temp = ChocoboNames[i].GetBytes(CHOCOBO_NAME_LENGTH, true);
                                pos = CHOCOBO_NAMES_POS + HEXT_OFFSET_2 + (CHOCOBO_NAME_LENGTH * i);
                                writer.Write($"{pos:X2} = ");
                                foreach (var x in temp)
                                {
                                    writer.Write($"{x:X2} ");
                                }
                                writer.WriteLine();
                            }
                        }
                        if (checker)
                        {
                            writer.WriteLine();
                            checker = false;
                        }
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
