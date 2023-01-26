using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shojy.FF7.Elena;

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
