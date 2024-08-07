using FF7Scarlet.AIEditor;
using FF7Scarlet.Shared;

using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Characters;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Inventory;
using Shojy.FF7.Elena.Items;
using Shojy.FF7.Elena.Materias;
using Shojy.FF7.Elena.Sections;

using System.Collections;

namespace FF7Scarlet.KernelEditor
{


    public class Kernel : KernelReader, IAttackContainer
    {
        public const int SECTION_COUNT = 27, KERNEL1_END = 9, DESCRIPTIONS_END = 17, NAMES_END = 25,
            ATTACK_COUNT = 128, MATERIA_COUNT = 96, SUMMON_OFFSET = 0x38, ESKILL_OFFSET = 0x48,
            CHARACTER_COUNT = 11, PLAYABLE_CHARACTER_COUNT = 9, AI_BLOCK_COUNT = 12, AI_BLOCK_SIZE = 2024,
            INVENTORY_SIZE = 320, MATERIA_INVENTORY_SIZE = 200, STOLEN_MATERIA_COUNT = 48,
            INDEXED_SPELL_COUNT = 56;
        public bool[] AttackIsLimit = new bool[ATTACK_COUNT];

        public CharacterAI[] CharacterAI { get; } = new CharacterAI[AI_BLOCK_COUNT];
        public bool ScriptsLoaded { get; private set; } = false;
        public FFText[] BattleTextFF { get; }
        private bool loaded = false;
        public Character[] CharacterList { get; }
        private ushort[] characterAIoffsets = new ushort[AI_BLOCK_COUNT];

        public Kernel(string file) : base(file, KernelType.KernelBin)
        {
            //get characters as a list
            CharacterList =
            [
                CharacterData.Cloud, CharacterData.Barret, CharacterData.Tifa, CharacterData.Aerith,
                CharacterData.RedXIII, CharacterData.Yuffie, CharacterData.CaitSithYoungCloud,
                CharacterData.VincentSephiroth, CharacterData.Cid
            ];

            //get AI offsets
            using (var ms = new MemoryStream(CharacterData.CharacterAIBlock, false))
            using (var reader = new BinaryReader(ms))
            {
                for (int i = 0; i < AI_BLOCK_COUNT; ++i)
                {
                    characterAIoffsets[i] = reader.ReadUInt16();
                }
            }

            //mark limits as limits (this adds a special function to attack names/descriptions)
            using (var ms = new MemoryStream(GetSectionRawData(KernelSection.MagicNames, false)))
            using (var reader = new BinaryReader(ms))
            {
                //get headers
                var headers = new ushort[ATTACK_COUNT];
                for (int i = 0; i < ATTACK_COUNT; ++i)
                {
                    headers[i] = reader.ReadUInt16();
                }

                //check the first two characters of each name
                for (int i = 0; i < ATTACK_COUNT; ++i)
                {
                    ms.Seek(headers[i], SeekOrigin.Begin);
                    var temp = reader.ReadBytes(2);
                    if (temp[0] == 0xF8 && temp[1] == 0x02)
                    {
                        AttackIsLimit[i] = true;
                    }
                }
            }

            //get battle text as FFText
            BattleTextFF = new FFText[BattleText.Strings.Length];
            ReloadBattleText();

            loaded = true;
        }

        private void ParseTextSectionStrings(KernelSection section, byte[] data)
        {
            int length = GetCount(section);
            var strings = new FFText[length];

            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                //get headers
                var headers = new ushort[length];
                for (int i = 0; i < length; ++i)
                {
                    headers[i] = reader.ReadUInt16();
                }

                //read each line
                var bytes = new List<byte>();
                byte b;
                int l;
                for (int i = 0; i < length; ++i)
                {
                    if (i == length - 1)
                    {
                        l = data.Length - headers[i];
                    }
                    else
                    {
                        l = headers[i + 1] - headers[i];
                    }
                    for (int j = 0; j < l; ++j)
                    {
                        b = reader.ReadByte();
                        // This is an encoding technique designed to make the raw data smaller. It is based
                        // on the LZS compression method, but optimized for smaller files with fewer large
                        // similar blocks. A byte following this value will tell the game's memory the location
                        // of, and how much, text to read.
                        // More info at: http://wiki.ffrtt.ru/index.php/FF7/FF_Text
                        if (b == 0xF9)
                        {
                            long currPos = ms.Position;
                            var args = reader.ReadByte();
                            // The args byte is split into length, and offset. The first two bits are
                            // the length of data, and the remaining 6 are how far back to get it from.
                            // Length needs further calculation (L * 2 + 4) to provide the correct value.
                            var lookupLength = ((args & 0b11000000) >> 6) * 2 + 4;
                            var lookupOffset = -(args & 0b00111111);

                            ms.Seek(lookupOffset - 3, SeekOrigin.Current);
                            for (int n = 0; n < lookupLength; ++n)
                            {
                                b = reader.ReadByte();
                                if (b != 0xFF)
                                {
                                    bytes.Add(b);
                                }
                            }
                            ms.Seek(currPos + 1, SeekOrigin.Begin);
                            j++;
                        }
                        else
                        {
                            bytes.Add(b);
                        }
                    }
                    strings[i] = new FFText(bytes.ToArray());
                    bytes.Clear();
                }
            }

            //update the strings for the section
            if (section == KernelSection.BattleText)
            {
                for (int i = 0; i < strings.Length; ++i)
                {
                    BattleTextFF[i] = strings[i];
                }
            }
            else
            {
                string? str;
                for (int i = 0; i < strings.Length; ++i)
                {
                    str = strings[i].ToString();
                    UpdateString(section, str, i);
                }
            }
        }

        public void ReloadBattleText()
        {
            loaded = false;
            ParseTextSectionStrings(KernelSection.BattleText,
                GetSectionRawData(KernelSection.BattleText, true));
            loaded = true;
        }

        public byte[] GetLookupTable()
        {
            var copy = new byte[BattleAndGrowthData.SceneLookupTable.Length];
            Array.Copy(BattleAndGrowthData.SceneLookupTable, copy, copy.Length);
            return copy;
        }

        public void UpdateLookupTable(byte[] table)
        {
            Array.Copy(table, BattleAndGrowthData.SceneLookupTable, BattleAndGrowthData.SceneLookupTable.Length);
        }

        public void ParseAIScripts()
        {
            int i, j, next;
            var blockWithoutHeaders = new byte[AI_BLOCK_SIZE];
            Array.Copy(CharacterData.CharacterAIBlock, 24, blockWithoutHeaders, 0, AI_BLOCK_SIZE);

            for (i = 0; i < AI_BLOCK_COUNT; ++i)
            {
                CharacterAI[i] = new CharacterAI(this);
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
                    CharacterAI[i].ParseScripts(blockWithoutHeaders, AI_BLOCK_COUNT * 2,
                        characterAIoffsets[i], next);
                }
            }
            ScriptsLoaded = true;
        }

        public int GetCount(KernelSection section)
        {
            if (section == KernelSection.AttackData) { return ATTACK_COUNT; }
            else if (section == KernelSection.BattleText) { return BattleText.Strings.Length; }
            else
            {
                var temp = GetAssociatedNames(section);
                if (temp != null)
                {
                    return GetAssociatedNames(section).Length;
                }
            }
            return 0;
        }

        public static bool SectionIsItems(KernelSection section)
        {
            var s = GetDataSection(section);
            return (s == KernelSection.ItemData || s == KernelSection.WeaponData
                || s == KernelSection.ArmorData || s == KernelSection.AccessoryData
                || s == KernelSection.MateriaData);
        }

        public Attack? GetAttackByID(ushort id)
        {
            foreach (var atk in AttackData.Attacks)
            {
                if (atk.Index == id) { return atk; }
            }
            return null;
        }

        public string GetAttackName(ushort id)
        {
            var atk = GetAttackByID(id);
            if (atk != null)
            {
                return DataParser.GetAttackNameString(atk);
            }
            return $"Unknown ({id:X4})";
        }

        public Item? GetItemByID(int id)
        {
            foreach (var item in ItemData.Items)
            {
                if (item.Index == id) { return item; }
            }
            return null;
        }

        public Weapon? GetWeaponByID(byte id)
        {
            foreach (var wpn in WeaponData.Weapons)
            {
                if (wpn.Index == id) { return wpn; }
            }
            return null;
        }

        public Armor? GetArmorByID(byte id)
        {
            foreach (var armor in ArmorData.Armors)
            {
                if (armor.Index == id) { return armor; }
            }
            return null;
        }

        public Accessory? GetAccessoryByID(byte id)
        {
            foreach (var acc in AccessoryData.Accessories)
            {
                if (acc.Index == id) { return acc; }
            }
            return null;
        }

        public Materia? GetMateriaByID(byte id)
        {
            foreach (var mat in MateriaData.Materias)
            {
                if (mat.Index == id) { return mat; }
            }
            return null;
        }

        public static KernelSection GetDataSection(KernelSection section)
        {
            switch (section)
            {
                case KernelSection.CommandData:
                case KernelSection.CommandNames:
                case KernelSection.CommandDescriptions:
                    return KernelSection.CommandData;

                case KernelSection.AttackData:
                case KernelSection.MagicNames:
                case KernelSection.MagicDescriptions:
                    return KernelSection.AttackData;

                case KernelSection.ItemData:
                case KernelSection.ItemNames:
                case KernelSection.ItemDescriptions:
                    return KernelSection.ItemData;

                case KernelSection.WeaponData:
                case KernelSection.WeaponNames:
                case KernelSection.WeaponDescriptions:
                    return KernelSection.WeaponData;

                case KernelSection.ArmorData:
                case KernelSection.ArmorNames:
                case KernelSection.ArmorDescriptions:
                    return KernelSection.ArmorData;

                case KernelSection.AccessoryData:
                case KernelSection.AccessoryNames:
                case KernelSection.AccessoryDescriptions:
                    return KernelSection.AccessoryData;

                case KernelSection.MateriaData:
                case KernelSection.MateriaNames:
                case KernelSection.MateriaDescriptions:
                    return KernelSection.MateriaData;
            }
            return section;
        }

        public TextSection? GetTextSection(KernelSection section)
        {
            switch (section)
            {
                case KernelSection.CommandNames:
                    return CommandNames;

                case KernelSection.CommandDescriptions:
                    return CommandDescriptions;

                case KernelSection.MagicNames:
                    return MagicNames;

                case KernelSection.MagicDescriptions:
                    return MagicDescriptions;

                case KernelSection.ItemNames:
                    return ItemNames;

                case KernelSection.ItemDescriptions:
                    return ItemDescriptions;

                case KernelSection.WeaponNames:
                    return WeaponNames;

                case KernelSection.WeaponDescriptions:
                    return WeaponDescriptions;

                case KernelSection.ArmorNames:
                    return ArmorNames;

                case KernelSection.ArmorDescriptions:
                    return ArmorDescriptions;

                case KernelSection.AccessoryNames:
                    return AccessoryNames;

                case KernelSection.AccessoryDescriptions:
                    return AccessoryDescriptions;

                case KernelSection.MateriaNames:
                    return MateriaNames;

                case KernelSection.MateriaDescriptions:
                    return MateriaDescriptions;

                case KernelSection.KeyItemNames:
                    return KeyItemNames;

                case KernelSection.KeyItemDescriptions:
                    return KeyItemDescriptions;

                case KernelSection.BattleText:
                    return BattleText;

                case KernelSection.SummonAttackNames:
                    return SummonAttackNames;
                default:
                    return null;
            }
        }

        public string[] GetAssociatedNames(KernelSection section, bool fullList = false)
        {
            var ds = GetDataSection(section);
            switch (ds)
            {
                case KernelSection.CommandData:
                    return CommandNames.Strings;

                case KernelSection.AttackData:
                    if (fullList) { return MagicNames.Strings; }
                    else
                    {
                        var temp = new string[ATTACK_COUNT];
                        Array.Copy(MagicNames.Strings, temp, ATTACK_COUNT);
                        return temp;
                    }

                case KernelSection.ItemData:
                    return ItemNames.Strings;

                case KernelSection.WeaponData:
                    return WeaponNames.Strings;

                case KernelSection.ArmorData:
                    return ArmorNames.Strings;

                case KernelSection.AccessoryData:
                    return AccessoryNames.Strings;

                case KernelSection.MateriaData:
                    return MateriaNames.Strings;

                case KernelSection.KeyItemNames:
                case KernelSection.KeyItemDescriptions:
                    return KeyItemNames.Strings;
            }
            return Array.Empty<string>();
        }

        public string[] GetAssociatedDescriptions(KernelSection section)
        {
            var ds = GetDataSection(section);
            switch (ds)
            {
                case KernelSection.CommandData:
                    return CommandDescriptions.Strings;

                case KernelSection.AttackData:
                    return MagicDescriptions.Strings;

                case KernelSection.ItemData:
                    return ItemDescriptions.Strings;

                case KernelSection.WeaponData:
                    return WeaponDescriptions.Strings;

                case KernelSection.ArmorData:
                    return ArmorDescriptions.Strings;

                case KernelSection.AccessoryData:
                    return AccessoryDescriptions.Strings;

                case KernelSection.MateriaData:
                    return MateriaDescriptions.Strings;

                case KernelSection.KeyItemNames:
                case KernelSection.KeyItemDescriptions:
                    return KeyItemDescriptions.Strings;
            }
            return Array.Empty<string>();
        }

        public void UpdateName(KernelSection section, string? name, int pos)
        {
            var ds = GetDataSection(section);
            var names = GetAssociatedNames(ds);
            string n = string.Empty;
            if (name != null) { n = name; }
            if (names.Length > 0)
            {
                names[pos] = n;
                switch (ds) //update associated item name (if it exists)
                {
                    case KernelSection.AttackData:
                        AttackData.Attacks[pos].Name = n;
                        break;

                    case KernelSection.ItemData:
                        ItemData.Items[pos].Name = n;
                        break;

                    case KernelSection.WeaponData:
                        WeaponData.Weapons[pos].Name = n;
                        break;

                    case KernelSection.ArmorData:
                        ArmorData.Armors[pos].Name = n;
                        break;

                    case KernelSection.AccessoryData:
                        AccessoryData.Accessories[pos].Name = n;
                        break;

                    case KernelSection.MateriaData:
                        MateriaData.Materias[pos].Name = n;
                        break;
                }
            }
        }

        public void UpdateDescription(KernelSection section, string? desc, int pos)
        {
            var ds = GetDataSection(section);
            var descs = GetAssociatedDescriptions(ds);
            string d = string.Empty;
            if (desc != null) { d = desc; }
            if (descs.Length > 0)
            {
                descs[pos] = d;
                switch (ds) //update associated item description (if it exists)
                {
                    case KernelSection.AttackData:
                        AttackData.Attacks[pos].Description = d;
                        break;

                    case KernelSection.ItemData:
                        ItemData.Items[pos].Description = d;
                        break;

                    case KernelSection.WeaponData:
                        WeaponData.Weapons[pos].Description = d;
                        break;

                    case KernelSection.ArmorData:
                        ArmorData.Armors[pos].Description = d;
                        break;

                    case KernelSection.AccessoryData:
                        AccessoryData.Accessories[pos].Description = d;
                        break;

                    case KernelSection.MateriaData:
                        MateriaData.Materias[pos].Description = d;
                        break;
                }
            }
        }

        public void UpdateString(KernelSection section, string? value, int pos)
        {
            var ts = GetTextSection(section);
            if (ts != null)
            {
                if ((int)section < DESCRIPTIONS_END)
                {
                    UpdateDescription(section, value, pos);
                }
                else if ((int)section < NAMES_END)
                {
                    UpdateName(section, value, pos);
                }
                else
                {
                    if (value == null) { ts.Strings[pos] = string.Empty; }
                    else { ts.Strings[pos] = value; }
                }
            }
        }

        public string GetInventoryItemName(InventoryItem item)
        {
            byte index = DataParser.GetItemIndex(item.Item);
            switch (DataParser.GetItemType(item.Item))
            {
                case ItemType.Item:
                    var i = GetItemByID(index);
                    if (i == null) { return $"(Item ID {index})"; }
                    else { return i.Name; }
                case ItemType.Weapon:
                    var w = GetWeaponByID(index);
                    if (w == null) { return $"(Weapon ID {index})"; }
                    else { return w.Name; }
                case ItemType.Armor:
                    var ar = GetArmorByID(index);
                    if (ar == null) { return $"(Armor ID {index})"; }
                    else { return ar.Name; }
                case ItemType.Accessory:
                    var acc = GetAccessoryByID(index);
                    if (acc == null) { return $"(Accessory ID {index})"; }
                    else { return acc.Name; }
                case ItemType.Materia:
                    var m = GetMateriaByID(index);
                    if (m == null) { return $"(Materia ID {index})"; }
                    else { return m.Name; }
                default:
                    return "(none)";
            }
        }

        public ushort GetCameraMovementIDSingle(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.CommandData:
                    return CommandData.Commands[pos].CameraMovementIDSingle;
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].CameraMovementIDSingle;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].CameraMovementId;
                default:
                    return HexParser.NULL_OFFSET_16_BIT;
            }
        }

        public ushort GetCameraMovementIDMulti(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.CommandData:
                    return CommandData.Commands[pos].CameraMovementIDMulti;
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].CameraMovementIDMulti;
                default:
                    return HexParser.NULL_OFFSET_16_BIT;
            }
        }

        public byte GetAttackEffectID(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].AttackEffectID;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].AttackEffectId;
                default:
                    return 0xFF;
            }
        }

        public StatIncrease[] GetStatIncreases(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.WeaponData:
                    var weapon = WeaponData.Weapons[pos];
                    return new StatIncrease[4]
                    {
                        new StatIncrease(weapon.BoostedStat1, weapon.BoostedStat1Bonus),
                        new StatIncrease(weapon.BoostedStat2, weapon.BoostedStat2Bonus),
                        new StatIncrease(weapon.BoostedStat3, weapon.BoostedStat3Bonus),
                        new StatIncrease(weapon.BoostedStat4, weapon.BoostedStat4Bonus)
                    };
                case KernelSection.ArmorData:
                    var armor = ArmorData.Armors[pos];
                    return new StatIncrease[4]
                    {
                        new StatIncrease(armor.BoostedStat1, armor.BoostedStat1Bonus),
                        new StatIncrease(armor.BoostedStat2, armor.BoostedStat2Bonus),
                        new StatIncrease(armor.BoostedStat3, armor.BoostedStat3Bonus),
                        new StatIncrease(armor.BoostedStat4, armor.BoostedStat4Bonus)
                    };
                case KernelSection.AccessoryData:
                    var accessory = AccessoryData.Accessories[pos];
                    return new StatIncrease[2]
                    {
                        new StatIncrease(accessory.BoostedStat1, accessory.BoostedStat1Bonus),
                        new StatIncrease(accessory.BoostedStat2, accessory.BoostedStat2Bonus)
                    };
                default:
                    return Array.Empty<StatIncrease>();
            }
        }

        public TargetData GetTargetData(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.CommandData:
                    return CommandData.Commands[pos].TargetFlags;
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].TargetFlags;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].TargetData;
                case KernelSection.WeaponData:
                    return WeaponData.Weapons[pos].Targets;
                default:
                    return 0;
            }
        }

        public byte GetDamageCalculationID(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].DamageCalculationID;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].DamageCalculationId;
                case KernelSection.WeaponData:
                    return WeaponData.Weapons[pos].DamageCalculationId;
                default:
                    return 0;
            }
        }

        public byte GetAttackPower(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].AttackStrength;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].AttackPower;
                case KernelSection.WeaponData:
                    return WeaponData.Weapons[pos].AttackStrength;
                default:
                    return 0;
            }
        }

        public Restrictions GetItemRestrictions(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.ItemData:
                    return ItemData.Items[pos].Restrictions;
                case KernelSection.WeaponData:
                    return WeaponData.Weapons[pos].Restrictions;
                case KernelSection.ArmorData:
                    return ArmorData.Armors[pos].Restrictions;
                case KernelSection.AccessoryData:
                    return AccessoryData.Accessories[pos].Restrictions;
        }
            return 0;
        }

        public EquipableBy GetEquipableFlags(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.WeaponData:
                    return WeaponData.Weapons[pos].EquipableBy;
                case KernelSection.ArmorData:
                    return ArmorData.Armors[pos].EquipableBy;
                case KernelSection.AccessoryData:
                    return AccessoryData.Accessories[pos].EquipableBy;
                default:
                    return 0;
            }
        }

        public MateriaSlot[] GetMateriaSlots(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.WeaponData:
                    return WeaponData.Weapons[pos].MateriaSlots;
                case KernelSection.ArmorData:
                    return ArmorData.Armors[pos].MateriaSlots;
                default:
                    return Array.Empty<MateriaSlot>();
            }
        }

        public GrowthRate GetGrowthRate(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.WeaponData:
                    return WeaponData.Weapons[pos].GrowthRate;
                case KernelSection.ArmorData:
                    return ArmorData.Armors[pos].GrowthRate;
                default:
                    return GrowthRate.None;
            }
        }

        public Elements GetElement(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].Elements;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].Element;
                case KernelSection.WeaponData:
                    return WeaponData.Weapons[pos].AttackElements;
                case KernelSection.ArmorData:
                    return ArmorData.Armors[pos].ElementalDefense;
                case KernelSection.AccessoryData:
                    return AccessoryData.Accessories[pos].ElementalDefense;
                default:
                    return 0;
            }
        }

        public DamageModifier GetDamageModifier(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.ArmorData:
                    return ArmorData.Armors[pos].ElementDamageModifier;
                case KernelSection.AccessoryData:
                    return AccessoryData.Accessories[pos].ElementalDamageModifier;
                default:
                    return 0;
            }
        }

        public Statuses GetStatuses(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].Statuses;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].Status;
                case KernelSection.AccessoryData:
                    return AccessoryData.Accessories[pos].StatusDefense;
                case KernelSection.MateriaData:
                    return MateriaData.Materias[pos].Status;
                default:
                    return 0;
            }
        }

        public EquipmentStatus GetEquipmentStatus(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.WeaponData:
                    return WeaponData.Weapons[pos].Status;
                case KernelSection.ArmorData:
                    return ArmorData.Armors[pos].Status;
                default:
                    return EquipmentStatus.None;
            }
        }

        public SpecialEffects GetSpecialEffects(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].SpecialAttackFlags;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].Special;
                default:
                    return 0;
            }
        }

        public byte GetCurveIndex(int chara, int stat)
        {
            switch ((CurveStats)stat)
            {
                case CurveStats.Strength:
                    return CharacterList[chara].StrengthCurveIndex;
                case CurveStats.Vitality:
                    return CharacterList[chara].VitalityCurveIndex;
                case CurveStats.Magic:
                    return CharacterList[chara].MagicCurveIndex;
                case CurveStats.Spirit:
                    return CharacterList[chara].SpiritCurveIndex;
                case CurveStats.Dexterity:
                    return CharacterList[chara].DexterityCurveIndex;
                case CurveStats.Luck:
                    return CharacterList[chara].LuckCurveIndex;
                case CurveStats.HP:
                    return CharacterList[chara].HPCurveIndex;
                case CurveStats.MP:
                    return CharacterList[chara].MPCurveIndex;
                case CurveStats.EXP:
                    return CharacterList[chara].EXPCurveIndex;
            }
            return 0;
        }

        public void SetCurveIndex(int chara, int stat, byte value)
        {
            switch ((CurveStats)stat)
            {
                case CurveStats.Strength:
                    CharacterList[chara].StrengthCurveIndex = value;
                    break;
                case CurveStats.Vitality:
                    CharacterList[chara].VitalityCurveIndex = value;
                    break;
                case CurveStats.Magic:
                    CharacterList[chara].MagicCurveIndex = value;
                    break;
                case CurveStats.Spirit:
                    CharacterList[chara].SpiritCurveIndex = value;
                    break;
                case CurveStats.Dexterity:
                    CharacterList[chara].DexterityCurveIndex = value;
                    break;
                case CurveStats.Luck:
                    CharacterList[chara].LuckCurveIndex = value;
                    break;
                case CurveStats.HP:
                    CharacterList[chara].HPCurveIndex = value;
                    break;
                case CurveStats.MP:
                    CharacterList[chara].MPCurveIndex = value;
                    break;
                case CurveStats.EXP:
                    CharacterList[chara].EXPCurveIndex = value;
                    break;
            }
        }

        private byte GetSpellIndexByte(SpellIndex index)
        {
            if (index.SpellType == SpellType.Unlisted) { return 0xFF; }
            else
            {
                var temp = new byte[1];
                var holder = new BitArray(8);
                int i;

                //get section index bits
                temp[0] = index.SectionIndex;
                var converter = new BitArray(temp);
                for (i = 0; i < 5; ++i)
                {
                    holder[i] = converter[i];
                }

                //get magic type bits
                temp[0] = (byte)index.SpellType;
                converter = new BitArray(temp);
                for (i = 0; i < 3; ++i)
                {
                    holder[i + 5] = converter[i];
                }

                //get and return the byte
                holder.CopyTo(temp, 0);
                return temp[0];
            }
        }


        public bool ImportChunk (KernelSection section, string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    switch (section)
                    {
                        case KernelSection.CommandData:
                            CommandData = new CommandData(File.ReadAllBytes(filePath),
                                CommandNames.Strings, CommandDescriptions.Strings);
                            break;

                        case KernelSection.AttackData:
                            AttackData = new AttackData(File.ReadAllBytes(filePath),
                                MagicNames.Strings, MagicDescriptions.Strings);
                            break;

                        case KernelSection.BattleAndGrowthData:
                            var temp = GetLookupTable();
                            BattleAndGrowthData = new BattleAndGrowthData(File.ReadAllBytes(filePath));
                            UpdateLookupTable(temp);
                            break;

                        case KernelSection.InitData:
                            InitialData = new InitialData(File.ReadAllBytes(filePath));
                            break;

                        case KernelSection.ItemData:
                            ItemData = new ItemData(File.ReadAllBytes(filePath),
                                ItemNames.Strings, ItemDescriptions.Strings);
                            break;

                        case KernelSection.WeaponData:
                            WeaponData = new WeaponData(File.ReadAllBytes(filePath),
                                WeaponNames.Strings, WeaponDescriptions.Strings);
                            break;

                        case KernelSection.ArmorData:
                            ArmorData = new ArmorData(File.ReadAllBytes(filePath),
                                ArmorNames.Strings, ArmorDescriptions.Strings);
                            break;

                        case KernelSection.AccessoryData:
                            AccessoryData = new AccessoryData(File.ReadAllBytes(filePath),
                                AccessoryNames.Strings, AccessoryDescriptions.Strings);
                            break;

                        case KernelSection.MateriaData:
                            MateriaData = new MateriaData(File.ReadAllBytes(filePath),
                                MateriaNames.Strings, MateriaDescriptions.Strings);
                            break;

                        default:
                            ParseTextSectionStrings(section, File.ReadAllBytes(filePath));
                            break;
                    }
                    return true;
                }
                catch { return false; }
            }    
            return false;
        }

        public byte[] GetSectionRawData(KernelSection section, bool isKernel2 = false)
        {
            //update data before writing it
            int i;
            if ((int)section > KERNEL1_END) //text sections
            {
                if (loaded)
                {
                    var bytes = new List<byte>();
                    FFText[] text;
                    bool isAttacks = GetDataSection(section) == KernelSection.AttackData;
                    
                    if (section == KernelSection.BattleText) //write the BattleTextFFs
                    {
                        text = BattleTextFF;
                    }
                    else
                    {
                        //get strings associated with this section
                        string[] strings;

                        if (section == KernelSection.SummonAttackNames)
                        {
                            strings = SummonAttackNames.Strings;
                        }
                        else if ((int)section > DESCRIPTIONS_END) //names
                        {
                            strings = GetAssociatedNames(section, true);
                        }
                        else //descriptions
                        {
                            strings = GetAssociatedDescriptions(section);
                        }

                        //converts strings to FFText
                        text = new FFText[strings.Length];
                        for (i = 0; i < strings.Length; ++i)
                        {
                            text[i] = new FFText(strings[i]);
                        }
                        
                    }

                    //generate headers
                    var offset = (ushort)(text.Length * 2); //starts just after headers
                    ushort length;
                    bool empty = false;
                    for (i = 0; i < text.Length; ++i)
                    {
                        length = (ushort)text[i].Length;
                        if (i > 0) //offset for empty strings
                        {
                            if (length > 1)
                            {
                                if (empty) { offset++; }
                                empty = false;
                            }
                            else
                            {
                                length = 0;
                                if (!empty)
                                {
                                    offset--;
                                    empty = true;
                                }
                            }
                        }
                        if (isAttacks && length > 1) //offset for limit header
                        {
                            if ((i < ATTACK_COUNT && AttackIsLimit[i]) || i >= ATTACK_COUNT)
                            {
                                length += 2;
                            }
                        }
                        bytes.AddRange(BitConverter.GetBytes(offset));
                        offset += length;
                    }

                    //write the strings
                    for (i = 0; i < text.Length; ++i)
                    {
                        if (isAttacks && text[i].Length > 1) //add limit function
                        {
                            if ((i < ATTACK_COUNT && AttackIsLimit[i]) || i >= ATTACK_COUNT)
                            {
                                bytes.Add(0xF8);
                                bytes.Add(0x02);
                            }
                        }
                        if (text[i].Length > 1 || i == 0) //don't add empty strings
                        {
                            bytes.AddRange(text[i].GetBytes());
                        }
                    }

                    //copy the newly converted strings to the KernelData array
                    KernelData[section] = bytes.ToArray();
                }
            }
            else if (loaded) //data sections
            {
                using (var ms = new MemoryStream(KernelData[section]))
                using (var writer = new BinaryWriter(ms))
                {
                    switch (section)
                    {
                        case KernelSection.CommandData:
                            foreach (var c in CommandData.Commands)
                            {
                                if (c == null)
                                {
                                    writer.Write(HexParser.GetNullBlock(MenuCommand.DATA_LENGTH));
                                }
                                else
                                {
                                    writer.Write(c.InitialCursorAction);
                                    writer.Write((byte)c.TargetFlags);
                                    writer.Write(HexParser.NULL_OFFSET_16_BIT); //unknown
                                    writer.Write(c.CameraMovementIDSingle);
                                    writer.Write(c.CameraMovementIDMulti);
                                }
                            }
                            break;

                        case KernelSection.AttackData:
                            foreach (var a in AttackData.Attacks)
                            {
                                if (a == null)
                                {
                                    writer.Write(HexParser.GetNullBlock(DataParser.ATTACK_BLOCK_SIZE));
                                }
                                else { writer.Write(DataParser.GetAttackBytes(a)); }
                            }
                            break;

                        case KernelSection.BattleAndGrowthData:
                            foreach (var c in CharacterList)
                            {
                                writer.Write(c.StrengthCurveIndex);
                                writer.Write(c.VitalityCurveIndex);
                                writer.Write(c.MagicCurveIndex);
                                writer.Write(c.SpiritCurveIndex);
                                writer.Write(c.DexterityCurveIndex);
                                writer.Write(c.LuckCurveIndex);
                                writer.Write(c.HPCurveIndex);
                                writer.Write(c.MPCurveIndex);
                                writer.Write(c.EXPCurveIndex);
                                writer.Write((byte)0xFF);
                                if (c == CharacterData.Yuffie)
                                {
                                    writer.Write((byte)1);
                                }
                                else
                                {
                                    writer.Write((sbyte)(c.RecruitLevelOffset * 2));
                                }
                                writer.Write((byte)0xFF);
                                writer.Write(c.Limit1_1Index);
                                writer.Write(c.Limit1_2Index);
                                writer.Write(c.Limit2_1Index);
                                writer.Write(c.Limit2_2Index);
                                writer.Write(c.Limit3_1Index);
                                writer.Write(c.Limit3_2Index);
                                writer.Write(c.Limit4Index);
                                writer.Write(c.KillsForLimitLv2);
                                writer.Write(c.KillsForLimitLv3);
                                writer.Write(c.UsesForLimit1_2);
                                writer.Write(c.UsesForLimit2_2);
                                writer.Write(c.UsesForLimit3_2);
                                writer.Write(c.LimitLv1HPDivisor);
                                writer.Write(c.LimitLv2HPDivisor);
                                writer.Write(c.LimitLv3HPDivisor);
                                writer.Write(c.LimitLv4HPDivisor);
                            }
                            foreach (byte b in BattleAndGrowthData.RandomBonusToPrimaryStats)
                            {
                                writer.Write(b);
                            }
                            foreach (byte b in BattleAndGrowthData.RandomBonusToHP)
                            {
                                writer.Write(b);
                            }
                            foreach (byte b in BattleAndGrowthData.RandomBonusToMP)
                            {
                                writer.Write(b);
                            }
                            foreach (var c in BattleAndGrowthData.StatCurves)
                            {
                                for (i = 0; i < 8; ++i)
                                {
                                    writer.Write(c.Gradients[i]);
                                    writer.Write(c.Bases[i]);
                                }
                            }

                            //write AI data
                            try
                            {
                                if (ScriptsLoaded) //don't update scripts if not loaded
                                {
                                    Array.Copy(AIContainer.GetGroupedScriptBlock(AI_BLOCK_COUNT, AI_BLOCK_SIZE,
                                        CharacterAI, ref characterAIoffsets), CharacterData.CharacterAIBlock,
                                        AI_BLOCK_SIZE);
                                }
                                foreach (var o in characterAIoffsets)
                                {
                                    writer.Write(BitConverter.GetBytes(o));
                                }
                                writer.Write(CharacterData.CharacterAIBlock);
                            }
                            catch (ScriptTooLongException)
                            {
                                throw new ScriptTooLongException("Character A.I. block is too long!");
                            }
                            catch (Exception ex)
                            {
                                throw new Exception($"Compiler error in A.I. scripts: {ex.Message}");
                            }

                            writer.Write(BattleAndGrowthData.RNGTable);
                            writer.Write(BattleAndGrowthData.SceneLookupTable);

                            foreach (var index in BattleAndGrowthData.SpellIndexes)
                            {
                                writer.Write(GetSpellIndexByte(index));
                            }
                            break;

                        case KernelSection.InitData:
                            foreach (var c in CharacterList)
                            {
                                writer.Write(DataParser.GetCharacterInitialDataBytes(c));
                            }
                            writer.Write(InitialData.Party1);
                            writer.Write(InitialData.Party2);
                            writer.Write(InitialData.Party3);
                            writer.Write((byte)0xFF);

                            foreach (var item in InitialData.Inventory)
                            {
                                writer.Write(DataParser.GetItemValue(item));
                            }
                            foreach (var mat in InitialData.Materia)
                            {
                                writer.Write(DataParser.GetMateriaBytes(mat));
                            }
                            foreach (var mat in InitialData.StolenMateria)
                            {
                                writer.Write(DataParser.GetMateriaBytes(mat));
                            }
                            writer.Write(HexParser.GetNullBlock(32)); //padding
                            writer.Write(InitialData.Gil);
                            break;

                        case KernelSection.ItemData:
                            foreach (var item in ItemData.Items)
                            {
                                if (item == null)
                                {
                                    writer.Write(HexParser.GetNullBlock(28));
                                }
                                else
                                {
                                    writer.Write(HexParser.GetNullBlock(8)); //padding
                                    writer.Write(item.CameraMovementId);
                                    writer.Write((ushort)~item.Restrictions);
                                    writer.Write((byte)item.TargetData);
                                    writer.Write(item.AttackEffectId);
                                    writer.Write(item.DamageCalculationId);
                                    writer.Write(item.AttackPower);
                                    writer.Write((byte)item.ConditionSubmenu);
                                    writer.Write(DataParser.GetStatusChangeValue(item.StatusChange));
                                    writer.Write(item.AdditionalEffects);
                                    writer.Write(item.AdditionalEffectsModifier);
                                    writer.Write((uint)item.Status);
                                    writer.Write((ushort)item.Element);
                                    writer.Write((ushort)~item.Special);
                                }
                            }
                            break;

                        case KernelSection.WeaponData:
                            foreach (var w in WeaponData.Weapons)
                            {
                                if (w == null)
                                {
                                    writer.Write(HexParser.GetNullBlock(44));
                                }
                                else
                                {
                                    writer.Write((byte)w.Targets);
                                    writer.Seek(1, SeekOrigin.Current); //attack effect ID
                                    writer.Write(w.DamageCalculationId);
                                    writer.Seek(1, SeekOrigin.Current); //unused
                                    writer.Write(w.AttackStrength);
                                    writer.Write((byte)w.Status);
                                    writer.Write((byte)w.GrowthRate);
                                    writer.Write(w.CriticalRate);
                                    writer.Write(w.AccuracyRate);
                                    writer.Write(w.WeaponModelId);
                                    writer.Write(w.HighSoundIDMask);
                                    writer.Write((ushort)w.EquipableBy);
                                    writer.Write((ushort)w.AttackElements);
                                    writer.Seek(2, SeekOrigin.Current); //padding
                                    writer.Write((byte)w.BoostedStat1);
                                    writer.Write((byte)w.BoostedStat2);
                                    writer.Write((byte)w.BoostedStat3);
                                    writer.Write((byte)w.BoostedStat4);
                                    writer.Write(w.BoostedStat1Bonus);
                                    writer.Write(w.BoostedStat2Bonus);
                                    writer.Write(w.BoostedStat3Bonus);
                                    writer.Write(w.BoostedStat4Bonus);
                                    for (i = 0; i < 8; ++i)
                                    {
                                        writer.Write((byte)w.MateriaSlots[i]);
                                    }
                                    writer.Write(w.NormalHitSoundID);
                                    writer.Write(w.CriticalHitSoundID);
                                    writer.Write(w.MissedAttackSoundID);
                                    writer.Write(w.ImpactEffectID);
                                    writer.Write((ushort)~w.Restrictions);
                                }
                            }
                            break;

                        case KernelSection.ArmorData:
                            foreach (var a in ArmorData.Armors)
                            {
                                writer.Seek(1, SeekOrigin.Current); //unknown
                                writer.Write((byte)a.ElementDamageModifier);
                                writer.Write(a.Defense);
                                writer.Write(a.MagicDefense);
                                writer.Write(a.Evade);
                                writer.Write(a.MagicEvade);
                                writer.Write((byte)a.Status);
                                writer.Seek(2, SeekOrigin.Current); //unknown
                                for (i = 0; i < 8; ++i)
                                {
                                    writer.Write((byte)a.MateriaSlots[i]);
                                }
                                writer.Write((byte)a.GrowthRate);
                                writer.Write((ushort)a.EquipableBy);
                                writer.Write((ushort)a.ElementalDefense);
                                writer.Seek(2, SeekOrigin.Current); //unknown
                                writer.Write((byte)a.BoostedStat1);
                                writer.Write((byte)a.BoostedStat2);
                                writer.Write((byte)a.BoostedStat3);
                                writer.Write((byte)a.BoostedStat4);
                                writer.Write(a.BoostedStat1Bonus);
                                writer.Write(a.BoostedStat2Bonus);
                                writer.Write(a.BoostedStat3Bonus);
                                writer.Write(a.BoostedStat4Bonus);
                                writer.Write((ushort)~a.Restrictions);
                                writer.Seek(2, SeekOrigin.Current); //unknown
                            }
                            break;

                        case KernelSection.AccessoryData:
                            foreach (var a in AccessoryData.Accessories)
                            {
                                writer.Write((byte)a.BoostedStat1);
                                writer.Write((byte)a.BoostedStat2);
                                writer.Write(a.BoostedStat1Bonus);
                                writer.Write(a.BoostedStat2Bonus);
                                writer.Write((byte)a.ElementalDamageModifier);
                                writer.Write((byte)a.SpecialEffect);
                                writer.Write((ushort)a.ElementalDefense);
                                writer.Write((uint)a.StatusDefense);
                                writer.Write((ushort)a.EquipableBy);
                                writer.Write((ushort)~a.Restrictions);
                            }
                            break;

                        case KernelSection.MateriaData:
                            foreach (var m in MateriaData.Materias)
                            {
                                writer.Write((ushort)(m.Level2AP / 100));
                                writer.Write((ushort)(m.Level3AP / 100));
                                writer.Write((ushort)(m.Level4AP / 100));
                                writer.Write((ushort)(m.Level5AP / 100));
                                writer.Write(m.EquipEffect);
                                var status = BitConverter.GetBytes((uint)m.Status);
                                writer.Write(status[0]);
                                writer.Write(status[1]);
                                writer.Write(status[2]);
                                writer.Write((byte)m.Element);
                                writer.Write(m.MateriaTypeByte);
                                foreach (var a in m.Attributes)
                                {
                                    writer.Write(a);
                                }
                            }
                            break;
                    }
                }
            }
            var copy = new byte[KernelData[section].Length];
            Array.Copy(KernelData[section], copy, copy.Length);
            return copy;
        }
    }
}
