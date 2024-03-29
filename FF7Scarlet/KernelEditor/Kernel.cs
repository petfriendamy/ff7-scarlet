﻿using FF7Scarlet.Shared;
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
        public const int SECTION_COUNT = 27, KERNEL1_END = 9, ATTACK_COUNT = 128;
        private Dictionary<KernelSection, byte[]> kernel1TextSections =
            new Dictionary<KernelSection, byte[]> { };
        public readonly MenuCommand[] Commands;
        public readonly Attack[] Attacks;
        public InitialData InitialData { get; }
        public BattleAndGrowthData BattleAndGrowthData { get; }

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
        }

        public byte[] GetLookupTable()
        {
            return BattleAndGrowthData.CopyLookupTable();
        }

        public void UpdateLookupTable(byte[] table)
        {
            BattleAndGrowthData.UpdateLookupTable(table);
            //Array.Copy(table, 0, KernelData[KernelSection.BattleAndGrowthData], 0xF1C, 64);
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
            return new string[0];
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
            return new string[0];
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
                    return new StatIncrease[0];
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
                    return new MateriaSlot[0];
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
            //we do not want to write kernel2 data to kernel.bin
            if ((int)section > KERNEL1_END && !isKernel2)
            {
                return kernel1TextSections[section];
            }

            //update data before writing it
            if (section == KernelSection.BattleAndGrowthData)
            {
                if (BattleAndGrowthData != null)
                {
                    Array.Copy(BattleAndGrowthData.GetRawData(), KernelData[section], KernelData[section].Length);
                }
            }
            return KernelData[section];
        }
    }
}
