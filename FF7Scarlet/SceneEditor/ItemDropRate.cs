using FF7Scarlet.Shared;

namespace FF7Scarlet.SceneEditor
{
    public class ItemDropRate
    {
        public ushort ItemID { get; set; }
        public bool IsSteal { get; set; }
        public byte DropRate { get; set; }

        public ItemDropRate(byte itemID, ItemType type, byte rate, bool isSteal)
        {
            ItemID = InventoryItem.GetCombinedIndex(type, itemID);
            DropRate = rate;
            IsSteal = isSteal;
        }

        public ItemDropRate(ushort itemId, byte rate)
        {
            ItemID = itemId;
            SetDropRateFromFile(rate);
        }

        public void SetDropRateFromFile(byte rate)
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
