using FF7Scarlet.KernelEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;

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
            NUM_CONFIG_TEXTS = 51,
            NUM_STATUS_EFFECTS = 27,
            NUM_LIMITS = 71,
            NUM_NAMES = 10,
            NUM_SHOPS = 80,
            NUM_SHOP_NAMES = 9,
            NUM_SHOP_TEXTS = 18,
            
            MENU_TEXT_LENGTH = 20,
            SHOP_TEXT_LENGTH = 46;

        private const long
            HEXT_OFFSET_1 = 0x400C00,
            HEXT_OFFSET_2 = 0x401600,

            AP_MULTIPLIER_POS = 0x31F14F,
            AP_MASTER_OFFSET = 0x4F,
            CONFIG_MENU_TEXT_POS = 0x5188A8,
            MAIN_MENU_TEXT_POS = 0x5192C0,
            STATUS_EFFECT_POS = 0x51D228,
            LIMIT_BREAK_POS = 0x51E0D4,
            LIMIT_TEXT_POS = 0x51FBF0,
            NAME_DATA_POS = 0x5206B8,
            CAIT_SITH_DATA_POS = 0x520C10,
            SHOP_NAME_POS = 0x5219C8,
            SHOP_TEXT_POS = 0x521A80,
            SHOP_INVENTORY_POS = 0x521E18,
            ITEM_PRICE_DATA_POS = 0x523858,
            MATERIA_PRICE_DATA_POS = 0x523E58;

        //properties
        public string FilePath { get; private set; } = string.Empty;
        public Language Language { get; private set; }
        public Attack[] Limits { get; } = new Attack[NUM_LIMITS];
        public FFText[] LimitSuccess { get; } = new FFText[Character.PLAYABLE_CHARACTER_COUNT - 1];
        public FFText[] LimitFail { get; } = new FFText[Character.PLAYABLE_CHARACTER_COUNT - 1];
        public FFText[] LimitWrong { get; } = new FFText[Character.PLAYABLE_CHARACTER_COUNT];
        public FFText[] MainMenuTexts { get; } = new FFText[NUM_MENU_TEXTS];
        public FFText[] ConfigMenuTexts { get; } = new FFText[NUM_CONFIG_TEXTS];
        public FFText[] StatusEffects { get; } = new FFText[NUM_STATUS_EFFECTS];
        public FFText[] CharacterNames { get; } = new FFText[NUM_NAMES];
        public Character? CaitSith { get; private set; }
        public Character? Vincent { get; private set; }
        public FFText[] ShopNames { get; } = new FFText[NUM_SHOP_NAMES];
        public FFText[] ShopText { get; } = new FFText[NUM_SHOP_TEXTS];
        public ShopInventory[] Shops { get; } = new ShopInventory[NUM_SHOPS];
        public byte APPriceMultiplier { get; set; }
        public uint[] ItemPrices { get; } = new uint[InventoryItem.ITEM_COUNT];
        public uint[] WeaponPrices { get; } = new uint[InventoryItem.WEAPON_COUNT];
        public uint[] ArmorPrices { get; } = new uint[InventoryItem.ARMOR_COUNT];
        public uint[] AccessoryPrices { get; } = new uint[InventoryItem.ACCESSORY_COUNT];
        public uint[] MateriaPrices { get; } = new uint[Kernel.MATERIA_COUNT];


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

        private long GetEquipOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return 0x777C0;
                case Language.French:
                    return 0x77788;
                case Language.German:
                    return 0x76EF0;
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
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var reader = new BinaryReader(stream))
                {
                    if (unedited) //this should be an unedited EXE, so do a hash check
                    {
                        var lang = GetLanguage(path);
                        if (lang == Language.English) //only English version supported
                        {
                            byte[] compare = SHA1.HashData(stream), hash;

                            if (IsSteamVersion(path)) //Steam version
                            {
                                hash = Convert.FromHexString("1C9A6F4B6F554B1B4ECB38812F9396A026A677D6");
                                return hash.SequenceEqual(compare);
                            }
                            else //1998 version
                            {
                                //1.00
                                hash = Convert.FromHexString("4EECAF14F30E8B0CC87B88C943F1119B567452D7");
                                if (hash.SequenceEqual(compare))
                                {
                                    return true;
                                }

                                //1.02
                                hash = Convert.FromHexString("684A0E87840138B4E02FC8EDB9AE2E2591CE4982");
                                return hash.SequenceEqual(compare);
                            }
                        } 
                    }
                    else
                    {
                        //check if header is correct
                        for (int i = 0; i < EXE_HEADER.Length; ++i)
                        {
                            if (reader.ReadByte() != EXE_HEADER[i])
                            {
                                return false;
                            }
                        }
                        return true;
                    }
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
                            Limits[i] = new Attack((ushort)i, new FFText($"(Limit #{i})"),
                                reader.ReadBytes(Attack.BLOCK_SIZE));
                        }

                        //get L4 limit text
                        stream.Seek(LIMIT_TEXT_POS + GetLimitTextOffset(), SeekOrigin.Begin);
                        for (i = 0; i < Character.PLAYABLE_CHARACTER_COUNT - 1; ++i)
                        {
                            LimitSuccess[i] = new FFText(reader.ReadBytes(GetLimitTextLength()));
                            LimitFail[i] = new FFText(reader.ReadBytes(GetLimitTextLength()));
                            LimitWrong[i] = new FFText(reader.ReadBytes(GetLimitTextLength()));
                        }
                        LimitWrong[Character.PLAYABLE_CHARACTER_COUNT - 1] =
                            new FFText(reader.ReadBytes(GetLimitTextLength()));

                        //get character names
                        stream.Seek(NAME_DATA_POS + GetNameOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_NAMES; ++i)
                        {
                            CharacterNames[i] = new FFText(reader.ReadBytes(Character.NAME_LENGTH));
                        }

                        //get Cait Sith + Vincent data
                        stream.Seek(CAIT_SITH_DATA_POS + GetCaitOffset(), SeekOrigin.Begin);
                        CaitSith = new Character(reader.ReadBytes(Character.CHARACTER_DATA_LENGTH));
                        Vincent = new Character(reader.ReadBytes(Character.CHARACTER_DATA_LENGTH));

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
                            writer.Write(l.GetRawData());
                        }

                        //write L4 limit text
                        stream.Seek(LIMIT_TEXT_POS + GetLimitTextOffset(), SeekOrigin.Begin);
                        for (int i = 0; i < Character.PLAYABLE_CHARACTER_COUNT; ++i)
                        {
                            if (i < Character.PLAYABLE_CHARACTER_COUNT - 1)
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
                            writer.Write(n.GetBytes(Character.NAME_LENGTH));
                        }

                        //write Cait Sith/Vincent data
                        if (CaitSith != null && Vincent != null)
                        {
                            stream.Seek(CAIT_SITH_DATA_POS + GetCaitOffset(), SeekOrigin.Begin);
                            writer.Write(CaitSith.GetRawData());
                            writer.Write(Vincent.GetRawData());
                        }

                        //write shop names
                        stream.Seek(SHOP_NAME_POS + GetShopNameLength(), SeekOrigin.Begin);
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
                    for (i = 0; i < NUM_NAMES; ++i)
                    {
                        CharacterNames[i] = new FFText(reader.ReadBytes(Character.NAME_LENGTH));
                    }

                    //read character data
                    CaitSith = new Character(reader.ReadBytes(Character.CHARACTER_DATA_LENGTH));
                    Vincent = new Character(reader.ReadBytes(Character.CHARACTER_DATA_LENGTH));

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
                        Limits[i] = new Attack((ushort)i, new FFText($"(Limit #{i})"),
                            reader.ReadBytes(Attack.BLOCK_SIZE));
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
                    for (i = 0; i < Character.PLAYABLE_CHARACTER_COUNT - 1; ++i)
                    {
                        LimitSuccess[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetLimitTextLength());
                        stream.Seek(LimitSuccess[i].ToString().Length + 1, SeekOrigin.Current);
                    }

                    //read L4 fail text
                    for (i = 0; i < Character.PLAYABLE_CHARACTER_COUNT - 1; ++i)
                    {
                        LimitFail[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetLimitTextLength());
                        stream.Seek(LimitFail[i].ToString().Length + 1, SeekOrigin.Current);
                    }

                    //read L4 wrong text
                    for (i = 0; i < Character.PLAYABLE_CHARACTER_COUNT; ++i)
                    {
                        LimitWrong[i] = FFText.GetTextFromByteArray(bytes, (int)stream.Position,
                            GetLimitTextLength());
                        stream.Seek(LimitWrong[i].ToString().Length + 1, SeekOrigin.Current);
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
                output.AddRange(n.GetBytes(Character.NAME_LENGTH));
            }

            //write character data
            output.AddRange(CaitSith.GetRawData());
            output.AddRange(Vincent.GetRawData());

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
                output.AddRange(l.GetRawData());
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
                {
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
                            if (Limits[i].HasDifferences(original.Limits[i]))
                            {
                                var temp1 = Limits[i].GetRawData();
                                var temp2 = original.Limits[i].GetRawData();
                                diff = false;

                                writer.WriteLine($"# {original.Limits[i].Name}");
                                for (i = 0; i < Attack.BLOCK_SIZE; ++i)
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

                        //compare limit text
                        j = 0;
                        for (i = 0; i < Character.PLAYABLE_CHARACTER_COUNT; ++i)
                        {
                            string text1, text2;
                            if (i < Character.PLAYABLE_CHARACTER_COUNT - 1)
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

                        //compare names
                        for (i = 0; i < NUM_NAMES; ++i)
                        {
                            string name1 = CharacterNames[i].ToString(),
                                name2 = original.CharacterNames[i].ToString();

                            if (name1 != name2)
                            {
                                checker = true;
                                writer.WriteLine($"# {name2} -> {name1}");
                                var temp = ShopNames[i].GetBytes();
                                pos = NAME_DATA_POS + HEXT_OFFSET_2 + (GetShopNameLength() * i);
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
                            if (CaitSith.HasDifferences(original.CaitSith))
                            {
                                var temp1 = CaitSith.GetRawData();
                                var temp2 = original.CaitSith.GetRawData();
                                diff = false;

                                writer.WriteLine("# Cait Sith's initial data");
                                for (i = 0; i < Character.CHARACTER_DATA_LENGTH; ++i)
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
                            if (Vincent.HasDifferences(original.Vincent))
                            {
                                var temp1 = Vincent.GetRawData();
                                var temp2 = original.Vincent.GetRawData();
                                diff = false;

                                writer.WriteLine("# Vincent's initial data");
                                for (i = 0; i < Character.CHARACTER_DATA_LENGTH; ++i)
                                {
                                    if (temp1[i] != temp2[i])
                                    {
                                        if (!diff)
                                        {
                                            pos = CAIT_SITH_DATA_POS + HEXT_OFFSET_2 + Character.CHARACTER_DATA_LENGTH + i;
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
                            for (i = 0; i < InventoryItem.ITEM_COUNT; ++i)
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
                            for (i = 0; i < InventoryItem.WEAPON_COUNT; ++i)
                            {
                                if (WeaponPrices[i] != original.WeaponPrices[i])
                                {
                                    writer.WriteLine($"# {DataManager.Kernel.WeaponData.Weapons[i].Name} price");
                                    pos = ITEM_PRICE_DATA_POS + HEXT_OFFSET_2 + (InventoryItem.WEAPON_START * 4) + (i * 4);
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
                            for (i = 0; i < InventoryItem.ARMOR_COUNT; ++i)
                            {
                                if (ArmorPrices[i] != original.ArmorPrices[i])
                                {
                                    writer.WriteLine($"# {DataManager.Kernel.ArmorData.Armors[i].Name} price");
                                    pos = ITEM_PRICE_DATA_POS + HEXT_OFFSET_2 + (InventoryItem.ARMOR_START * 4) + (i * 4);
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
                            for (i = 0; i < InventoryItem.ACCESSORY_COUNT; ++i)
                            {
                                if (AccessoryPrices[i] != original.AccessoryPrices[i])
                                {
                                    writer.WriteLine($"# {DataManager.Kernel.AccessoryData.Accessories[i].Name} price");
                                    pos = ITEM_PRICE_DATA_POS + HEXT_OFFSET_2 + (InventoryItem.ACCESSORY_START * 4) + (i * 4);
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
                            for (i = 0; i < DataManager.Kernel.MateriaExt.Length; ++i)
                            {
                                if (MateriaPrices[i] != original.MateriaPrices[i])
                                {
                                    writer.WriteLine($"# {DataManager.Kernel.MateriaExt[i].Name} price");
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
