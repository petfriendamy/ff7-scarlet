using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.SceneEditor
{
    public class ItemDropRate
    {
        public ushort ItemID { get; set; }
        public bool IsSteal { get; private set; }
        public byte DropRate { get; private set; }

        public ItemDropRate(ushort itemId, byte rate)
        {
            ItemID = itemId;
            SetDropRate(rate);
        }

        public void SetDropRate(byte rate)
        {
            if (rate > 0x80)
            {
                IsSteal = true;
                DropRate = (byte)(rate - 0x80);
            }
            else
            {
                IsSteal = false;
                DropRate = rate;
            }
        }

        public byte GetRawDropRate()
        {
            if (IsSteal) { return (byte)(DropRate + 0x80); }
            else { return DropRate; }
        }
    }
}
