using FF7Scarlet.AIEditor;
using FF7Scarlet.ExeEditor;
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
using Shojy.FF7.Elena.Text;

using System.Collections;

namespace FF7Scarlet.KernelEditor
{
    public class Kernel : KernelReader, IAttackContainer
    {
        public const int SECTION_COUNT = 27, KERNEL1_END = 9, DESCRIPTIONS_END = 17, NAMES_END = 25,
            ATTACK_COUNT = 128, MATERIA_COUNT = 96, SUMMON_OFFSET = 0x38, ESKILL_OFFSET = 0x48,
            SPECIAL_SUMMON_OFFSET = 0x60, LIMIT_OFFSET = 0x62, CHARACTER_COUNT = 11,
            PLAYABLE_CHARACTER_COUNT = 9, AI_BLOCK_COUNT = 12, AI_BLOCK_SIZE = 2024,
            INVENTORY_SIZE = 320, MATERIA_INVENTORY_SIZE = 200, STOLEN_MATERIA_COUNT = 48,
            INDEXED_SPELL_COUNT = 56,
            ESKILL_COUNT = SPECIAL_SUMMON_OFFSET - ESKILL_OFFSET;
        public bool[] AttackIsLimit = new bool[ATTACK_COUNT];

        public CharacterAI[] CharacterAI { get; } = new CharacterAI[AI_BLOCK_COUNT];
        public bool ScriptsLoaded { get; private set; } = false;
        private bool loaded = false;
        public Character[] CharacterList { get; }
        private ushort[] characterAIoffsets = new ushort[AI_BLOCK_COUNT];
        public const string
            KERNEL_CONFIG_KEY = "KernelPath",
            KERNEL2_CONFIG_KEY = "Kernel2Path";

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
            /*for (int i = 0; i < BattleText.Strings.Length; ++i)
            {
                var temp = BattleText.Strings[i].GetBytes();
                if (temp.Length > 1 && temp[0] == 0xF8 && temp[1] == 0x02)
                {
                    AttackIsLimit[i] = true;
                    var temp2 = new byte[temp.Length - 2];
                    Array.Copy(temp, 2, temp2, 0, temp2.Length);
                    BattleText.Strings[i] = new FFText(temp2);
                }

            }*/
            loaded = true;
        }

        private void ParseTextSectionStrings(KernelSection section, byte[] data)
        {
            var textSection = GetTextSection(section);
            if (textSection != null)
            {
                var strings = textSection.Strings;
                int length = strings.Length;

                using (var ms = new MemoryStream(data))
                using (var reader = new BinaryReader(ms))
                {
                    //get headers
                    var headers = new ushort[length];
                    for (int i = 0; i < length; ++i)
                    {
                        headers[i] = reader.ReadUInt16();
                    }
                    ms.Seek(headers[0], SeekOrigin.Begin);

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
                        if (bytes.Count == 0 || bytes.Last() != 0xFF) //make sure there's a null terminator
                        {
                            bytes.Add(0xFF);
                        }
                        strings[i] = new FFText(bytes.ToArray());
                        bytes.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Compresses text section data using FF7's 0xF9 LZS-style compression.
        /// This reduces the size of text sections by referencing repeated byte sequences.
        /// </summary>
        private static byte[] CompressTextSection(byte[] data)
        {
            var output = new List<byte>();
            var isLiteral = new List<bool>();
            int i = 0;

            while (i < data.Length)
            {
                byte b = data[i];

                // Don't compress null terminators or if too early in the stream
                if (b == 0xFF || output.Count < 4)
                {
                    output.Add(b);
                    isLiteral.Add(true);
                    i++;
                    continue;
                }

                // Find best match in the output buffer (only in literal positions)
                int bestLength = 0;
                int bestMatchStart = 0;

                // Max lookback is 64 bytes (offset 0-63 encoded in 6 bits)
                int minMatchStart = Math.Max(0, output.Count - 64);

                for (int matchStart = minMatchStart; matchStart < output.Count; matchStart++)
                {
                    // Skip non-literal positions
                    if (!isLiteral[matchStart]) continue;

                    int matchLen = 0;

                    // Count matching bytes (max 10, all must be literals, stop at 0xFF)
                    while (matchLen < 10 &&
                           i + matchLen < data.Length &&
                           matchStart + matchLen < output.Count &&
                           isLiteral[matchStart + matchLen] &&
                           data[i + matchLen] != 0xFF &&
                           output[matchStart + matchLen] == data[i + matchLen])
                    {
                        matchLen++;
                    }

                    // Valid lengths are 4, 6, 8, 10 only
                    int validLen = (matchLen / 2) * 2;
                    if (validLen > 10) validLen = 10;
                    if (validLen < 4) validLen = 0;

                    if (validLen > bestLength)
                    {
                        bestLength = validLen;
                        bestMatchStart = matchStart;
                    }
                }

                if (bestLength >= 4)
                {
                    // Encode the reference
                    // Length bits: ((L/2 - 2) << 6) encodes 4,6,8,10 as 0,1,2,3
                    // Offset bits: distance from current position - 1
                    byte lengthBits = (byte)(((bestLength / 2) - 2) << 6);
                    byte offsetBits = (byte)(output.Count - bestMatchStart - 1);
                    byte args = (byte)(lengthBits | offsetBits);

                    output.Add(0xF9);
                    isLiteral.Add(false);
                    output.Add(args);
                    isLiteral.Add(false);
                    i += bestLength;
                }
                else
                {
                    output.Add(b);
                    isLiteral.Add(true);
                    i++;
                }
            }

            return output.ToArray();
        }

        public void CopyAllText(Kernel other)
        {
            int i;

            //data sections
            for (i = 0; i < KERNEL1_END; ++i)
            {
                var s = (KernelSection)i;
                int count = GetCount(s);
                if (s == KernelSection.AttackData)
                {
                    count = MagicNames.Strings.Length;
                }
                var otherNames = other.GetAssociatedNames(s, true);
                var otherDescs = other.GetAssociatedDescriptions(s);

                for (int j = 0; j < count; ++j)
                {
                    UpdateName(s, otherNames[j], j);
                    if (j < GetCount(s))
                    {
                        UpdateDescription(s, otherDescs[j], j);
                    }
                }
            }

            //key items
            for (i = 0; i < GetCount(KernelSection.KeyItemNames); ++i)
            {
                KeyItemNames.Strings[i] = other.KeyItemNames.Strings[i];
                KeyItemDescriptions.Strings[i] = other.KeyItemDescriptions.Strings[i];
            }

            //summon attack names
            for (i = 0; i < SummonAttackNames.Strings.Length; ++i)
            {
                SummonAttackNames.Strings[i] = other.SummonAttackNames.Strings[i];
            }
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
                if ((int)section > KERNEL1_END)
                {
                    var temp = GetTextSection(section);
                    if (temp != null)
                    {
                        return temp.Strings.Length;
                    }
                }
                else
                {
                    var temp = GetAssociatedNames(section);
                    if (temp != null)
                    {
                        return temp.Length;
                    }
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

        public string GetAttackName(ushort id, bool jpText)
        {
            var atk = GetAttackByID(id);
            if (atk != null)
            {
                return DataParser.GetAttackNameString(atk, jpText);
            }
            return new FFText($"Unknown ({id:X4})");
        }

        public FFText[] GetEnemySkillNames()
        {
            var names = new FFText[ESKILL_COUNT];
            Array.Copy(MagicNames.Strings, ESKILL_OFFSET, names, 0, ESKILL_COUNT);
            return names;
        }

        public FFText GetLimitName(int index)
        {
            if (index >= 0 && index < ExeData.NUM_LIMITS)
            {
                return MagicNames.Strings[index + ATTACK_COUNT];
            }
            return new FFText();
        }

        public FFText[] GetLimitNames()
        {
            var names = new FFText[ExeData.NUM_LIMITS];
            Array.Copy(MagicNames.Strings, ATTACK_COUNT, names, 0, ExeData.NUM_LIMITS);
            return names;
        }

        public FFText GetLimitDescription(int index)
        {
            if (index >= 0 && index < ExeData.NUM_LIMITS)
            {
                return MagicDescriptions.Strings[index + ATTACK_COUNT];
            }
            return new FFText();
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

        public FFText[] GetAssociatedNames(KernelSection section, bool fullList = false)
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
                        var temp = new FFText[ATTACK_COUNT];
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
            return Array.Empty<FFText>();
        }

        public FFText[] GetAssociatedDescriptions(KernelSection section)
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
            return Array.Empty<FFText>();
        }

        public void UpdateName(KernelSection section, string? name, int pos)
        {
            var ds = GetDataSection(section);
            var names = GetAssociatedNames(ds, true);
            string n = string.Empty;
            if (name != null) { n = name; }
            if (names.Length > 0)
            {
                names[pos] = new FFText(n);
                /*switch (ds) //update associated item name (if it exists)
                {
                    case KernelSection.AttackData:
                        if (pos < ATTACK_COUNT)
                        {
                            AttackData.Attacks[pos].Name = n;
                        }
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
                }*/
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
                descs[pos] = new FFText(d);
                /*switch (ds) //update associated item description (if it exists)
                {
                    case KernelSection.AttackData:
                        if (pos < ATTACK_COUNT)
                        {
                            AttackData.Attacks[pos].Description = d;
                        }
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
                }*/
            }
        }

        public void UpdateString(KernelSection section, string? value, int pos)
        {
            var ts = GetTextSection(section);
            if (ts != null)
            {
                if ((int)section <= DESCRIPTIONS_END)
                {
                    UpdateDescription(section, value, pos);
                }
                else if ((int)section <= NAMES_END)
                {
                    UpdateName(section, value, pos);
                }
                else
                {
                    if (value == null) { ts.Strings[pos] = new FFText(); }
                    else { ts.Strings[pos] = new FFText(value); }
                }
            }
        }

        public string GetInventoryItemName(ushort id)
        {
            var type = DataParser.GetItemType(id);
            byte index = DataParser.GetItemIndex(id);
            switch (type)
            {
                case ItemType.Item:
                    var i = GetItemByID(index);
                    if (i == null || string.IsNullOrEmpty(i.Name))
                    {
                        return $"(Item ID {index})";
                    }
                    else { return i.Name; }
                case ItemType.Weapon:
                    var w = GetWeaponByID(index);
                    if (w == null || string.IsNullOrEmpty(w.Name))
                    {
                        return $"(Weapon ID {index})";
                    }
                    else { return w.Name; }
                case ItemType.Armor:
                    var ar = GetArmorByID(index);
                    if (ar == null || string.IsNullOrEmpty(ar.Name))
                    {
                        return $"(Armor ID {index})";
                    }
                    else { return ar.Name; }
                case ItemType.Accessory:
                    var acc = GetAccessoryByID(index);
                    if (acc == null || string.IsNullOrEmpty(acc.Name))
                    {
                        return $"(Accessory ID {index})";
                    }
                    else { return acc.Name; }
                case ItemType.Materia:
                    var m = GetMateriaByID(index);
                    if (m == null || string.IsNullOrEmpty(m.Name))
                    {
                        return $"(Materia ID {index})";
                    }

                    else { return m.Name; }
                default:
                    return "(none)";
            }
        }

        public string GetInventoryItemName(InventoryItem item)
        {
            return GetInventoryItemName(item.Item);
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

        public StatusChange GetStatusChange(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.AttackData:
                    return AttackData.Attacks[pos].StatusChange;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].StatusChange;
                default:
                    return new StatusChange(0xFF);
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


        public bool ImportChunk(KernelSection section, string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    var fileData = File.ReadAllBytes(filePath);
                    switch (section)
                    {
                        case KernelSection.CommandData:
                            CommandData = new CommandData(fileData,
                                CommandNames.Strings, CommandDescriptions.Strings);
                            break;

                        case KernelSection.AttackData:
                            AttackData = new AttackData(fileData,
                                MagicNames.Strings, MagicDescriptions.Strings);
                            break;

                        case KernelSection.BattleAndGrowthData:
                            byte[] lookup = GetLookupTable(),
                                initData = GetSectionRawData(KernelSection.InitData);

                            ScriptsLoaded = false;
                            BattleAndGrowthData = new BattleAndGrowthData(fileData);
                            CharacterData = new CharacterData(initData, fileData);
                            UpdateLookupTable(lookup);
                            break;

                        case KernelSection.InitData:
                            var growthData = GetSectionRawData(KernelSection.BattleAndGrowthData);

                            InitialData = new InitialData(fileData);
                            CharacterData = new CharacterData(fileData, growthData);
                            break;

                        case KernelSection.ItemData:
                            ItemData = new ItemData(fileData,
                                ItemNames.Strings, ItemDescriptions.Strings);
                            break;

                        case KernelSection.WeaponData:
                            WeaponData = new WeaponData(fileData,
                                WeaponNames.Strings, WeaponDescriptions.Strings);
                            break;

                        case KernelSection.ArmorData:
                            ArmorData = new ArmorData(fileData,
                                ArmorNames.Strings, ArmorDescriptions.Strings);
                            break;

                        case KernelSection.AccessoryData:
                            AccessoryData = new AccessoryData(fileData,
                                AccessoryNames.Strings, AccessoryDescriptions.Strings);
                            break;

                        case KernelSection.MateriaData:
                            MateriaData = new MateriaData(fileData,
                                MateriaNames.Strings, MateriaDescriptions.Strings);
                            break;

                        default:
                            ParseTextSectionStrings(section, fileData);
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
                    FFText[] strings;

                    if (section == KernelSection.SummonAttackNames)
                    {
                        strings = SummonAttackNames.Strings;
                    }
                    else if (section == KernelSection.BattleText)
                    {
                        strings = BattleText.Strings;
                    }
                    else if ((int)section > DESCRIPTIONS_END) //names
                    {
                        strings = GetAssociatedNames(section, true);
                    }
                    else //descriptions
                    {
                        strings = GetAssociatedDescriptions(section);
                    }

                    //build compressed strings first to calculate correct offsets
                    var compressedStrings = new List<byte[]>();
                    for (i = 0; i < strings.Length; ++i)
                    {
                        var stringBytes = new List<byte>();

                        //add limit function marker if needed
                        /*if (isAttacks && strings[i].Length > 1)
                        {
                            if ((i < ATTACK_COUNT && AttackIsLimit[i]) || i >= ATTACK_COUNT)
                            {
                                stringBytes.Add(0xF8);
                                stringBytes.Add(0x02);
                            }
                        }*/

                        //add the string bytes
                        if (strings[i].Length > 1 || i == 0)
                        {
                            stringBytes.AddRange(strings[i].GetBytes());
                            stringBytes.Add(0xFF);
                        }

                        //compress and store
                        compressedStrings.Add(CompressTextSection(stringBytes.ToArray()));
                    }

                    //generate headers using compressed lengths
                    var offset = (ushort)(strings.Length * 2); //starts just after headers
                    ushort length;
                    bool empty = false;
                    for (i = 0; i < strings.Length; ++i)
                    {
                        length = (ushort)compressedStrings[i].Length;
                        if (i > 0) //offset for empty strings
                        {
                            if (strings[i].Length > 1)
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
                        bytes.AddRange(BitConverter.GetBytes(offset));
                        offset += length;
                    }

                    //write the compressed strings
                    for (i = 0; i < compressedStrings.Count; ++i)
                    {
                        if (strings[i].Length > 1 || i == 0) //don't add empty strings
                        {
                            bytes.AddRange(compressedStrings[i]);
                        }
                    }

                    //must be a multiple of 2
                    if (bytes.Count % 2 != 0) { bytes.Add(0xFF); }

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
                                    writer.Write(HexParser.GetNullBlock(8));
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
                                writer.Write((byte)0xFF); //padding
                                if (c.ID == (byte)CharacterNames.Yuffie)
                                {
                                    writer.Write((byte)1);
                                }
                                else
                                {
                                    writer.Write((sbyte)(c.RecruitLevelOffset * 2));
                                }
                                writer.Write((byte)0xFF); //padding
                                writer.Write(c.Limit1_1Index);
                                writer.Write(c.Limit1_2Index);
                                writer.Write((byte)0xFF); //limit 1-3
                                writer.Write(c.Limit2_1Index);
                                writer.Write(c.Limit2_2Index);
                                writer.Write((byte)0xFF); //limit 2-3
                                writer.Write(c.Limit3_1Index);
                                writer.Write(c.Limit3_2Index);
                                writer.Write((byte)0xFF); //limit 3-3
                                writer.Write(c.Limit4Index);
                                writer.Write((ushort)0xFFFF); //limits 4-2 and 4-3
                                writer.Write(c.KillsForLimitLv2);
                                writer.Write(c.KillsForLimitLv3);
                                writer.Write(c.UsesForLimit1_2);
                                writer.Write((ushort)0xFFFF); //limit 1-3
                                writer.Write(c.UsesForLimit2_2);
                                writer.Write((ushort)0xFFFF); //limit 2-3
                                writer.Write(c.UsesForLimit3_2);
                                writer.Write((ushort)0xFFFF); //limit 3-3
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
                                    i = 0;
                                    foreach (var o in characterAIoffsets)
                                    {
                                        var temp = BitConverter.GetBytes(o);
                                        Array.Copy(temp, 0, CharacterData.CharacterAIBlock, i, 2);
                                        i += 2;
                                    }
                                    Array.Copy(AIContainer.GetGroupedScriptBlock(AI_BLOCK_COUNT, AI_BLOCK_SIZE,
                                        CharacterAI, ref characterAIoffsets), 0, CharacterData.CharacterAIBlock,
                                        AI_BLOCK_COUNT * 2, AI_BLOCK_SIZE);
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
                                    writer.Write((byte)0xFF); //attack effect ID
                                    writer.Write(w.DamageCalculationId);
                                    writer.Write((byte)0xFF); //unused
                                    writer.Write(w.AttackStrength);
                                    writer.Write((byte)w.Status);
                                    writer.Write((byte)w.GrowthRate);
                                    writer.Write(w.CriticalRate);
                                    writer.Write(w.AccuracyRate);
                                    writer.Write(w.WeaponModelId);
                                    writer.Write((byte)0xFF); //padding
                                    writer.Write(w.HighSoundIDMask);
                                    writer.Write((ushort)0xFFFF); //camera movement ID
                                    writer.Write((ushort)w.EquipableBy);
                                    writer.Write((ushort)w.AttackElements);
                                    writer.Write((ushort)0xFFFF); //padding
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
                                    writer.Write((ushort)0xFFFF); //special attack flags
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
