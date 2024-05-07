using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.Shared
{
    public class InventoryMateria
    {
        public byte Index { get; set; }
        public int CurrentAP { get; set; }

        public InventoryMateria(byte index, int currentAP)
        {
            Index = index;
            CurrentAP = currentAP;
        }

        public InventoryMateria(byte[] data)
        {
            Index = data[0];

            var ap = new byte[4];
            Array.Copy(data, 1, ap, 0, 3);
            CurrentAP = BitConverter.ToInt32(ap);
        }

        public InventoryMateria Copy()
        {
            return new InventoryMateria(Index, CurrentAP);
        }

        public byte[] GetBytes()
        {
            var data = new byte[4];
            data[0] = Index;
            Array.Copy(BitConverter.GetBytes(CurrentAP), 0, data, 1, 3);
            return data;
        }
    }
}
