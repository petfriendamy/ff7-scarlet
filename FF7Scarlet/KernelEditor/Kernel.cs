using FF7Scarlet.Shared;
using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Items;
using Shojy.FF7.Elena.Materias;
using Shojy.FF7.Elena.Sections;

namespace FF7Scarlet.KernelEditor
{


    public class Kernel : KernelReader, IAttackContainer
    {
        public const int SECTION_COUNT = 27, KERNEL1_END = 9, DESCRIPTIONS_END = 17,
            ATTACK_COUNT = 128;
        private Dictionary<KernelSection, byte[]> kernel1TextSections =
            new Dictionary<KernelSection, byte[]> { };
        public readonly MenuCommand[] Commands;
        public readonly Attack[] Attacks;
        public InitialData InitialData { get; }
        public BattleAndGrowthData BattleAndGrowthData { get; }
        private bool loaded = false;

        public Kernel(string file) : base(file, KernelType.KernelBin)
        {
            for (int i = KERNEL1_END; i < SECTION_COUNT; i++)
            {
                var s = (KernelSection)(i + 1);
                int length = KernelData[s].Length;
                kernel1TextSections[s] = new byte[length];
                Array.Copy(KernelData[s], kernel1TextSections[s], length);
            }

            //get menu commands
            Commands = new MenuCommand[GetCount(KernelSection.CommandData)];
            using (var ms = new MemoryStream(GetSectionRawData(KernelSection.CommandData)))
            using (var reader = new BinaryReader(ms))
            {
                for (int i = 0; i < Commands.Length; ++i)
                {
                    Commands[i] = new MenuCommand(reader.ReadBytes(8));
                }
            }

            //get attack data
            Attacks = new Attack[ATTACK_COUNT];
            using (var ms = new MemoryStream(GetSectionRawData(KernelSection.AttackData)))
            using (var reader = new BinaryReader(ms))
            {
                for (int i = 0; i < ATTACK_COUNT; ++i)
                {
                    Attacks[i] = new Attack((ushort)i, new FFText(MagicNames.Strings[i]),
                        reader.ReadBytes(Attack.BLOCK_SIZE));
                    Attacks[i].Description = new FFText(MagicDescriptions.Strings[i]);
                }
            }

            //get battle and growth data
            BattleAndGrowthData = new BattleAndGrowthData(this, GetSectionRawData(KernelSection.BattleAndGrowthData));

            //get initial data
            InitialData = new InitialData(GetSectionRawData(KernelSection.InitData));

            loaded = true;
        }

        public byte[] GetLookupTable()
        {
            return BattleAndGrowthData.CopyLookupTable();
        }

        public void UpdateLookupTable(byte[] table)
        {
            BattleAndGrowthData.UpdateLookupTable(table);
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

        public Attack? GetAttackByID(ushort id)
        {
            foreach (var atk in Attacks)
            {
                if (atk.ID == id) { return atk; }
            }
            return null;
        }

        public string GetAttackName(ushort id)
        {
            var atk = GetAttackByID(id);
            if (atk != null)
            {
                return atk.GetNameString();
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

        private KernelSection GetDataSection(KernelSection section)
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

        public string[] GetAssociatedNames(KernelSection section)
        {
            var ds = GetDataSection(section);
            switch (ds)
            {
                case KernelSection.CommandData:
                    return CommandNames.Strings;

                case KernelSection.AttackData:
                    var temp = new string[ATTACK_COUNT];
                    Array.Copy(MagicNames.Strings, temp, ATTACK_COUNT);
                    return temp;

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

        public void UpdateName(KernelSection section, string name, int pos)
        {
            var ds = GetDataSection(section);
            var names = GetAssociatedNames(ds);
            if (names.Length > 0)
            {
                names[pos] = name;
                switch (ds) //update associated item name (if it exists)
                {
                    case KernelSection.AttackData:
                        Attacks[pos].Name = new FFText(name);
                        break;

                    case KernelSection.ItemData:
                        ItemData.Items[pos].Name = name;
                        break;

                    case KernelSection.WeaponData:
                        WeaponData.Weapons[pos].Name = name;
                        break;

                    case KernelSection.ArmorData:
                        ArmorData.Armors[pos].Name = name;
                        break;

                    case KernelSection.AccessoryData:
                        AccessoryData.Accessories[pos].Name = name;
                        break;

                    case KernelSection.MateriaData:
                        MateriaData.Materias[pos].Name = name;
                        break;
                }
            }
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

        public string GetInventoryItemName(InventoryItem item)
        {
            switch (item.Type)
            {
                case ItemType.Item:
                    var i = GetItemByID(item.Index);
                    if (i == null) { return $"(Item ID {item.Index})"; }
                    else { return i.Name; }
                case ItemType.Weapon:
                    var w = GetWeaponByID(item.Index);
                    if (w == null) { return $"(Weapon ID {item.Index})"; }
                    else { return w.Name; }
                case ItemType.Armor:
                    var ar = GetArmorByID(item.Index);
                    if (ar == null) { return $"(Armor ID {item.Index})"; }
                    else { return ar.Name; }
                case ItemType.Accessory:
                    var acc = GetAccessoryByID(item.Index);
                    if (acc == null) { return $"(Accessory ID {item.Index})"; }
                    else { return acc.Name; }
                case ItemType.Materia:
                    var m = GetMateriaByID(item.Index);
                    if (m == null) { return $"(Materia ID {item.Index})"; }
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
                    return Commands[pos].CameraMovementIDSingle;
                case KernelSection.AttackData:
                    return Attacks[pos].CameraMovementIDSingle;
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
                    return Commands[pos].CameraMovementIDMulti;
                case KernelSection.AttackData:
                    return Attacks[pos].CameraMovementIDMulti;
                default:
                    return HexParser.NULL_OFFSET_16_BIT;
            }
        }

        public byte GetAttackEffectID(KernelSection section, int pos)
        {
            switch (section)
            {
                case KernelSection.AttackData:
                    return Attacks[pos].AttackEffectID;
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
                    return Commands[pos].TargetFlags;
                case KernelSection.AttackData:
                    return Attacks[pos].TargetFlags;
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
                    return Attacks[pos].DamageCalculationID;
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
                    return Attacks[pos].AttackStrength;
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
                    return Attacks[pos].Elements;
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
                    return Attacks[pos].StatusEffects;
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
                    return Attacks[pos].SpecialAttackFlags;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].Special;
                default:
                    return 0;
            }
        }

        public byte[] GetSectionRawData(KernelSection section, bool isKernel2 = false)
        {
            //update data before writing it
            if ((int)section > KERNEL1_END) //text sections
            {
                if (!isKernel2) //we do not want to write kernel2 data to kernel.bin
                {
                    return kernel1TextSections[section];
                }
                else if (loaded)
                {
                    //get strings associated with this section
                    var bytes = new List<byte>();
                    string[] strings;
                    int i;
                    if ((int)section > DESCRIPTIONS_END) //names
                    {
                        strings = GetAssociatedNames(section);
                    }
                    else //descriptions
                    {
                        strings = GetAssociatedDescriptions(section);
                    }

                    //converts strings to FFText and generates headers
                    var text = new FFText[strings.Length];
                    var offset = (ushort)(strings.Length * 2);
                    ushort length;
                    bool isBlank = false;
                    for (i = 0; i < strings.Length; ++i)
                    {
                        text[i] = new FFText(strings[i]);
                        length = (ushort)text[i].Length;
                        if (length == 0) //empty strings are offset by 1
                        {
                            if (!isBlank)
                            {
                                offset--;
                                isBlank = true;
                            }
                        }
                        else
                        {
                            if (isBlank)
                            {
                                offset++;
                                isBlank = false;
                            }
                            length++;
                        }
                        bytes.AddRange(BitConverter.GetBytes(offset));
                        offset += length;
                    }

                    //write the strings
                    for (i = 0; i < strings.Length; ++i)
                    {
                        if (text[i].Length > 0)
                        {
                            bytes.AddRange(text[i].GetBytes());
                            bytes.Add(0xFF);
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
                            foreach (var c in Commands)
                            {
                                if (c == null)
                                {
                                    writer.Write(HexParser.GetNullBlock(MenuCommand.DATA_LENGTH));
                                }
                                else { writer.Write(c.GetBytes()); }
                            }
                            break;

                        case KernelSection.AttackData:
                            foreach (var a in Attacks)
                            {
                                if (a == null)
                                {
                                    writer.Write(HexParser.GetNullBlock(Attack.BLOCK_SIZE));
                                }
                                else { writer.Write(a.GetRawData()); }
                            }
                            break;

                        case KernelSection.BattleAndGrowthData:
                            writer.Write(BattleAndGrowthData.GetRawData());
                            break;

                        case KernelSection.InitData:
                            writer.Write(InitialData.GetRawData());
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
                                    writer.Seek(4, SeekOrigin.Current); //missing data
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
                                    writer.Seek(4, SeekOrigin.Current); //missing data
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
                                    for (int i = 0; i < 8; ++i)
                                    {
                                        writer.Write((byte)w.MateriaSlots[i]);
                                    }
                                    writer.Seek(6, SeekOrigin.Current); //more missing data
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
                                for (int i = 0; i < 8; ++i)
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
                                writer.Write((byte)m.MateriaType);
                                writer.Seek(6, SeekOrigin.Current); //attributes
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
