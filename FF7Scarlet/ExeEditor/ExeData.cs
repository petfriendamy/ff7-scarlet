using FF7Scarlet.Shared;
using Shojy.FF7.Elena;

namespace FF7Scarlet.ExeEditor
{
    public enum Language { English, Spanish, French, German }

    public class ExeData
    {
        //constants
        private static readonly int[] EXE_HEADER = new int[3] { 0x4D, 0x5A, 0x90 };
        public const string CONFIG_KEY = "VanillaExePath";
        public const int NUM_LIMITS = 71, NUM_NAMES = 10, NUM_SHOPS = 80;
        private const long
            HEXT_OFFSET_1 = 0x400C00,
            HEXT_OFFSET_2 = 0x401600,

            AP_MULTIPLIER_POS = 0x31F14F,
            AP_MASTER_OFFSET = 0x4F,
            LIMIT_BREAK_POS = 0x51E0D4,
            NAME_DATA_POS = 0x5206B8,
            CAIT_SITH_DATA_POS = 0x520C10,
            SHOP_NAME_POS = 0x5219C8,
            SHOP_INVENTORY_POS = 0x521E18,
            ITEM_PRICE_DATA_POS = 0x523858,
            MATERIA_PRICE_DATA_POS = 0x523E58,

            AP_MULTIPLIER_ES_OFFSET = 0x8B6E2,
            LIMIT_ES_OFFSET = 0x779D8,
            NAME_ES_OFFSET = 0x780E0,
            CAIT_ES_OFFSET = 0x78110,
            MENU_TEXT_ES_OFFSET = 0x783F0,
            SHOP_ES_OFFSET = 0x784A0,

            AP_MULTIPLIER_FR_OFFSET = 0x8B365,
            LIMIT_FR_OFFSET = 0x777C0,
            NAME_FR_OFFSET = 0x77E70,
            CAIT_FR_OFFSET = 0x77E90,
            MENU_TEXT_FR_OFFSET = 0x780B8,
            SHOP_FR_OFFSET = 0x78A10,

            AP_MULTIPLIER_DE_OFFSET = 0x8B017,
            LIMIT_DE_OFFSET = 0x76EB8,
            NAME_DE_OFFSET = 0x77370,
            CAIT_DE_OFFSET = 0x77388,
            MENU_TEXT_DE_OFFSET = 0x77650,
            SHOP_DE_OFFSET = 0x77700;

        //properties
        public string FilePath { get; private set; } = string.Empty;
        public Language Language { get; private set; }
        public Attack[] Limits { get; } = new Attack[NUM_LIMITS];
        public FFText[] CharacterNames { get; } = new FFText[NUM_NAMES];
        public Character? CaitSith { get; private set; }
        public Character? Vincent { get; private set; }
        public FFText[] ShopNames { get; } = new FFText[9];
        public ShopInventory[] Shops { get; } = new ShopInventory[NUM_SHOPS];
        public byte APPriceMultiplier { get; set; }
        public uint[] ItemPrices { get; } = new uint[InventoryItem.ITEM_COUNT];
        public uint[] WeaponPrices { get; } = new uint[InventoryItem.WEAPON_COUNT];
        public uint[] ArmorPrices { get; } = new uint[InventoryItem.ARMOR_COUNT];
        public uint[] AccessoryPrices { get; } = new uint[InventoryItem.ACCESSORY_COUNT];
        public uint[] MateriaPrices { get; } = Array.Empty<uint>();


        public ExeData(string path)
        {
            if (DataManager.Kernel != null)
            {
                MateriaPrices = new uint[DataManager.Kernel.GetCount(KernelSection.MateriaData)];
            }
            ReadEXE(path);
        }

        private long GetAPPriceMultiplierOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return AP_MULTIPLIER_ES_OFFSET;
                case Language.French:
                    return AP_MULTIPLIER_FR_OFFSET;
                case Language.German:
                    return AP_MULTIPLIER_DE_OFFSET;
                default:
                    return 0;
            }
        }

        private long GetLimitOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return LIMIT_ES_OFFSET;
                case Language.French:
                    return LIMIT_FR_OFFSET;
                case Language.German:
                    return LIMIT_DE_OFFSET;
                default:
                    return 0;
            }
        }

        private long GetNameOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return NAME_ES_OFFSET;
                case Language.French:
                    return NAME_FR_OFFSET;
                case Language.German:
                    return NAME_DE_OFFSET;
                default:
                    return 0;
            }
        }

        private long GetCaitOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return CAIT_ES_OFFSET;
                case Language.French:
                    return CAIT_FR_OFFSET;
                case Language.German:
                    return CAIT_DE_OFFSET;
                default:
                    return 0;
            }
        }

        private long GetMenuTextOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return MENU_TEXT_ES_OFFSET;
                case Language.French:
                    return MENU_TEXT_FR_OFFSET;
                case Language.German:
                    return MENU_TEXT_DE_OFFSET;
                default:
                    return 0;
            }
        }

        private long GetShopOffset()
        {
            switch (Language)
            {
                case Language.Spanish:
                    return SHOP_ES_OFFSET;
                case Language.French:
                    return SHOP_FR_OFFSET;
                case Language.German:
                    return SHOP_DE_OFFSET;
                default:
                    return 0;
            }
        }

        public static bool ValidateEXE(string path)
        {
            if (File.Exists(path))
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
                    return true;
                }
            }
            return false;
        }

        public void ReadEXE(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    //check EXE language
                    string name = Path.GetFileNameWithoutExtension(path);
                    if (name.EndsWith("_es"))
                    {
                        Language = Language.Spanish;
                    }
                    else if (name.EndsWith("_fr"))
                    {
                        Language = Language.French;
                    }
                    else if (name.EndsWith("_de"))
                    {
                        Language = Language.German;
                    }
                    else
                    {
                        Language = Language.English;
                    }

                    //attempt to open and read the EXE
                    int i;
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    using (var reader = new BinaryReader(stream))
                    {
                        //check if header is correct
                        if (!ValidateEXE(path))
                        {
                            throw new FormatException("EXE appears to be invalid.");
                        }

                        //get AP multiplier
                        stream.Seek(AP_MULTIPLIER_POS + GetAPPriceMultiplierOffset(), SeekOrigin.Begin);
                        APPriceMultiplier = reader.ReadByte();

                        //get limit breaks
                        stream.Seek(LIMIT_BREAK_POS + GetLimitOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_LIMITS; ++i)
                        {
                            Limits[i] = new Attack((ushort)i, new FFText($"(Limit #{i})"),
                                reader.ReadBytes(Attack.BLOCK_SIZE));
                        }

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
                        stream.Seek(SHOP_NAME_POS + GetMenuTextOffset(), SeekOrigin.Begin);
                        for (i = 0; i < 9; ++i)
                        {
                            int length = ShopData.SHOP_NAME_LENGTH;
                            if (Language == Language.Spanish || Language == Language.German)
                            {
                                length *= 2; //double-length strings
                            }
                            ShopNames[i] = new FFText(reader.ReadBytes(length));
                        }

                        //get shop inventories
                        stream.Seek(SHOP_INVENTORY_POS + GetShopOffset(), SeekOrigin.Begin);
                        for (i = 0; i < NUM_SHOPS; ++i)
                        {
                            Shops[i] = new ShopInventory(reader.ReadBytes(ShopInventory.SHOP_DATA_LENGTH));
                        }

                        //get item prices
                        if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
                        {
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
                    if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
                    {
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
                    }

                    //read shop inventories
                    for (i = 0; i < NUM_SHOPS; ++i)
                    {
                        var type = (ShopType)reader.ReadByte();
                        byte count = reader.ReadByte();
                        var items = new InventoryItem[count];
                        for (int j = 0; j < ShopInventory.SHOP_ITEM_MAX; ++j)
                        {
                            if (j < count)
                            {
                                byte isMateria = reader.ReadByte();
                                if (isMateria == 1)
                                {
                                    var mat = DataManager.Kernel?.GetMateriaByID((byte)reader.ReadUInt16());
                                    if (mat != null)
                                    {
                                        items[j] = new InventoryItem(mat);
                                    }
                                }
                                else
                                {
                                    items[j] = new InventoryItem(reader.ReadUInt16());
                                }
                            }
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
                if (CaitSith == null) { throw new ArgumentNullException(nameof(CaitSith)); }
                if (Vincent == null) { throw new ArgumentNullException(nameof(Vincent)); }

                using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                using (var writer = new BinaryWriter(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    
                    //write character names
                    foreach (var n in CharacterNames)
                    {
                        writer.Write(n.GetBytes(Character.NAME_LENGTH));
                    }

                    //write character data
                    writer.Write(CaitSith.GetRawData());
                    writer.Write(Vincent.GetRawData());

                    //write item prices
                    writer.Write(APPriceMultiplier);
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
                    foreach (var p in MateriaPrices)
                    {
                        writer.Write(p);
                    }

                    //write shop inventories
                    foreach (var s in Shops)
                    {
                        writer.Write((byte)s.ShopType);
                        writer.Write(s.ItemCount);
                        for (int i = 0; i < ShopInventory.SHOP_ITEM_MAX; ++i)
                        {
                            var item = s.Inventory[i];
                            if (item == null)
                            {
                                writer.Write((byte)0);
                                writer.Write((ushort)0);
                            }
                            else
                            {
                                if (item.Type == ItemType.Materia)
                                {
                                    writer.Write((byte)1);
                                }
                                else
                                {
                                    writer.Write((byte)0);
                                }
                                writer.Write(item.GetCombinedIndex());
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

                        //compare names
                        for (i = 0; i < NUM_NAMES; ++i)
                        {
                            string? name1 = CharacterNames[i].ToString(),
                                name2 = original.CharacterNames[i].ToString();

                            if (name1 != null && name2 != null && name1 != name2)
                            {
                                checker = true;
                                writer.WriteLine($"# {name2} -> {name1}");
                                var temp = CharacterNames[i].GetBytes();
                                pos = NAME_DATA_POS + HEXT_OFFSET_2 + (temp.Length * i);
                                writer.Write($"{pos:X2} = ");
                                foreach (var x in temp)
                                {
                                    writer.Write($"{x:X2} ");
                                }
                                writer.WriteLine();
                            }
                        }
                        if (checker) { writer.WriteLine(); }

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
