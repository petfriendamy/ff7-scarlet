using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Sections;

namespace FF7Scarlet
{
    public class Kernel : KernelReader
    {
        public const int SECTION_COUNT = 27, KERNEL_2_START = 9;
        private Dictionary<KernelSection, byte[]> textSectionsUnedited =
            new Dictionary<KernelSection, byte[]> { };

        public Kernel(string file) : base(file, KernelType.KernelBin)
        {
            for (int i = KERNEL_2_START; i < SECTION_COUNT; i++)
            {
                var s = (KernelSection)(i + 1);
                int length = KernelData[s].Length;
                textSectionsUnedited[s] = new byte[length];
                Array.Copy(KernelData[s], textSectionsUnedited[s], length);
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

        public byte[] GetSectionRawData(KernelSection section, bool isKernel2 = false)
        {
            //we do not want to write kernel2 data to kernel.bin
            if ((int)section > KERNEL_2_START && !isKernel2)
            {
                return textSectionsUnedited[section];
            }
            return KernelData[section];
        }
    }
}
