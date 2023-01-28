using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Items;
using Shojy.FF7.Elena.Sections;

namespace FF7Scarlet
{
    public class Kernel : KernelReader
    {
        public const int SECTION_COUNT = 27, KERNEL1_END = 9;
        private Dictionary<KernelSection, byte[]> kernel1TextSections =
            new Dictionary<KernelSection, byte[]> { };

        public Kernel(string file) : base(file, KernelType.KernelBin)
        {
            for (int i = KERNEL1_END; i < SECTION_COUNT; i++)
            {
                var s = (KernelSection)(i + 1);
                int length = KernelData[s].Length;
                kernel1TextSections[s] = new byte[length];
                Array.Copy(KernelData[s], kernel1TextSections[s], length);
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
            var temp = GetAssociatedNames(section);
            if (temp != null)
            {
                return GetAssociatedNames(section).Length;
            }
            return 0;
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
            return null;
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
            return null;
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
                    return null;
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
