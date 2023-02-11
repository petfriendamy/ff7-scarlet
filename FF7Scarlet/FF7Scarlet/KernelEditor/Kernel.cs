using FF7Scarlet.Shared;
using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Items;
using Shojy.FF7.Elena.Sections;

namespace FF7Scarlet.KernelEditor
{
    public struct StatIncrease
    {
        public CharacterStat Stat { get; set; }
        public byte Amount { get; set; }

        public StatIncrease(CharacterStat stat, byte amount)
        {
            Stat = stat;
            Amount = amount;
        }
    }

    public class Kernel : KernelReader
    {
        public const int SECTION_COUNT = 27, KERNEL1_END = 9, ATTACK_COUNT = 128;
        private Dictionary<KernelSection, byte[]> kernel1TextSections =
            new Dictionary<KernelSection, byte[]> { };
        public readonly Attack[] Attacks;

        public Kernel(string file) : base(file, KernelType.KernelBin)
        {
            for (int i = KERNEL1_END; i < SECTION_COUNT; i++)
            {
                var s = (KernelSection)(i + 1);
                int length = KernelData[s].Length;
                kernel1TextSections[s] = new byte[length];
                Array.Copy(KernelData[s], kernel1TextSections[s], length);
            }

            //get attack data
            Attacks = new Attack[ATTACK_COUNT];
            using (var ms = new MemoryStream(GetSectionRawData(KernelSection.AttackData)))
            using (var reader = new BinaryReader(ms))
            {
                try
                {
                    for (int i = 0; i < ATTACK_COUNT; ++i)
                    {
                        Attacks[i] = new Attack((ushort)i, new FFText(MagicNames.Strings[i]),
                            reader.ReadBytes(Attack.BLOCK_SIZE));
                    }
                }
                catch (EndOfStreamException)
                {
                    //nothing
                }
            }
        }

        public byte[] GetLookupTable()
        {
            var table = new byte[64];
            Array.Copy(KernelData[KernelSection.BattleAndGrowthData], 0xF1C, table, 0, 64);
            return table;
        }

        public void UpdateLookupTable(byte[] table)
        {
            if (table.Length != 64)
            {
                throw new ArgumentException("Incorrect table length.");
            }
            Array.Copy(table, 0, KernelData[KernelSection.BattleAndGrowthData], 0xF1C, 64);
        }

        public int GetCount(KernelSection section)
        {
            if (section == KernelSection.AttackData) { return ATTACK_COUNT; }
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

        public string[] GetAssociatedNames(KernelSection section)
        {
            switch (section)
            {
                case KernelSection.CommandData:
                case KernelSection.CommandNames:
                case KernelSection.CommandDescriptions:
                    return CommandNames.Strings;
                case KernelSection.AttackData:
                case KernelSection.MagicNames:
                case KernelSection.MagicDescriptions:
                    return MagicNames.Strings;
                case KernelSection.ItemData:
                case KernelSection.ItemNames:
                case KernelSection.ItemDescriptions:
                    return ItemNames.Strings;
                case KernelSection.WeaponData:
                case KernelSection.WeaponNames:
                case KernelSection.WeaponDescriptions:
                    return WeaponNames.Strings;
                case KernelSection.ArmorData:
                case KernelSection.ArmorNames:
                case KernelSection.ArmorDescriptions:
                    return ArmorNames.Strings;
                case KernelSection.AccessoryData:
                case KernelSection.AccessoryNames:
                case KernelSection.AccessoryDescriptions:
                    return AccessoryNames.Strings;
                case KernelSection.MateriaData:
                case KernelSection.MateriaNames:
                case KernelSection.MateriaDescriptions:
                    return MateriaNames.Strings;
                case KernelSection.KeyItemNames:
                case KernelSection.KeyItemDescriptions:
                    return KeyItemNames.Strings;
            }
            return new string[0];
        }

        public string[] GetAssociatedDescriptions(KernelSection section)
        {
            switch (section)
            {
                case KernelSection.CommandData:
                case KernelSection.CommandNames:
                case KernelSection.CommandDescriptions:
                    return CommandDescriptions.Strings;
                case KernelSection.AttackData:
                case KernelSection.MagicNames:
                case KernelSection.MagicDescriptions:
                    return MagicDescriptions.Strings;
                case KernelSection.ItemData:
                case KernelSection.ItemNames:
                case KernelSection.ItemDescriptions:
                    return ItemDescriptions.Strings;
                case KernelSection.WeaponData:
                case KernelSection.WeaponNames:
                case KernelSection.WeaponDescriptions:
                    return WeaponDescriptions.Strings;
                case KernelSection.ArmorData:
                case KernelSection.ArmorNames:
                case KernelSection.ArmorDescriptions:
                    return ArmorDescriptions.Strings;
                case KernelSection.AccessoryData:
                case KernelSection.AccessoryNames:
                case KernelSection.AccessoryDescriptions:
                    return AccessoryDescriptions.Strings;
                case KernelSection.MateriaData:
                case KernelSection.MateriaNames:
                case KernelSection.MateriaDescriptions:
                    return MateriaDescriptions.Strings;
                case KernelSection.KeyItemNames:
                case KernelSection.KeyItemDescriptions:
                    return KeyItemDescriptions.Strings;
            }
            return new string[0];
        }

        public ushort GetCameraMovementIDSingle(KernelSection section, int pos)
        {
            switch (section)
            {
                //case KernelSection.CommandData:
                case KernelSection.AttackData:
                    return Attacks[pos].CameraMovementIDSingle;
                case KernelSection.ItemData:
                    return ItemData.Items[pos].CameraMovementId;
                default:
                    return DataManager.NULL_OFFSET_16_BIT;
            }
        }

        public ushort GetCameraMovementIDMulti(KernelSection section, int pos)
        {
            switch (section)
            {
                //case KernelSection.CommandData:
                case KernelSection.AttackData:
                    return Attacks[pos].CameraMovementIDMulti;
                default:
                    return DataManager.NULL_OFFSET_16_BIT;
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

        public byte[] GetSectionRawData(KernelSection section, bool isKernel2 = false)
        {
            //we do not want to write kernel2 data to kernel.bin
            if ((int)section > KERNEL1_END && !isKernel2)
            {
                return kernel1TextSections[section];
            }
            return KernelData[section];
        }
    }
}
