using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Shojy.FF7.Elena
{
    public class MemoryKernelReader : KernelReader
    {
        private IMemoryReader MemoryReader { get; set; }
        private const int KernelSegmentIndexPointer = 0x7BA070;

        public MemoryKernelReader(Process ff7)
        {
            this.MemoryReader = new NativeMemoryReader(ff7);

            var index = this.MemoryReader.ReadMemory(new IntPtr(KernelSegmentIndexPointer), 27 * 4);

            var addresses = new Dictionary<KernelSection, int>();
            var sectionLengths = new[]
            {
                256, 3584, 3988, 2876, 3584, 5632, 1152, 512, 1920
            };

            var kernelData = new Dictionary<KernelSection, byte[]>();

            for (var i = 0; i < (int)KernelSection.MateriaData; ++i)
            {
                var loc = BitConverter.ToInt32(index, i * 4);
                addresses.Add((KernelSection)i+1, loc);
                var data = MemoryReader.ReadMemory(new IntPtr(loc), sectionLengths[i]);
                kernelData.Add((KernelSection) 1+i, data);
            }

            this.KernelData = kernelData;
        }
        /*

        the pointer table pointing to the various kernel modules is at 0x7BA070, 
        the function that writes to these pointers from the file segments is at 0x4012DA


#define MATERIA_DATA_PTR                     (void*)0xDBDF60
#define ITEM_DATA_PTR                        (void*)0xDBD160
#define WEAPON_DATA_PTR                      (void*)0xDBE730
#define ARMOR_DATA_PTR                       (void*)0xDBCCE0
#define ACCESSORY_DATA_PTR                   (void*)0xDBCAE0
     
.data:007BA070 gKernelTablesPtr dd offset gCommandDataTable
.data:007BA070                                         ; DATA XREF: LoadKernelBin+6C↑r
.data:007BA070                                         ; LoadKernelBin+7F↑r
.data:007BA074                 dd offset gMagicPlayerData
.data:007BA078                 dd offset unk_99CE10
.data:007BA07C                 dd offset gCharacterData
.data:007BA080                 dd offset gItemDataArray
.data:007BA084                 dd offset gWeaponDataTable
.data:007BA088                 dd offset gArmorDataTable
.data:007BA08C                 dd offset gAccessoryDataTable
.data:007BA090                 dd offset gMateriaDataTable

         *
         */
    }
}