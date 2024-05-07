using FF7Scarlet.Shared;
using System.Collections;

namespace FF7Scarlet.KernelEditor
{
    public class ItemStack
    {
        public InventoryItem Item;
        public int Amount;

        public ItemStack(InventoryItem item, int amount)
        {
            Item = item;
            Amount = amount;
        }

        public ItemStack(byte[] data)
        {
            var source = new BitArray(data);
            var indexBits = new bool[16];
            var amountBits = new bool[8];

            int i;
            for (i = 0; i < 9; ++i)
            {
                indexBits[i] = source[i];
            }
            for (i = 0; i < 7; ++i)
            {
                amountBits[i] = source[i + 9];
            }

            var converter = new BitArray(indexBits);
            var indexBytes = new byte[2];
            converter.CopyTo(indexBytes, 0);
            ushort value = BitConverter.ToUInt16(indexBytes);
            Item = new InventoryItem(value);

            converter = new BitArray(amountBits);
            var amountBytes = new byte[1];
            converter.CopyTo(amountBytes, 0);
            Amount = amountBytes[0];
        }

        public ushort GetValue()
        {
            var indexBytes = BitConverter.GetBytes(Item.GetCombinedIndex());
            var amountBytes = new byte[1] { (byte)Amount };
            var indexBits = new BitArray(indexBytes);
            var amountBits = new BitArray(amountBytes);

            var combinedBits = new bool[16];
            int i;
            for (i = 0; i < 9; ++i)
            {
                combinedBits[i] = indexBits[i];
            }
            for (i = 0; i < 7; ++i)
            {
                combinedBits[i + 9] = amountBits[i];
            }

            var converter = new BitArray(combinedBits);
            var combinedBytes = new byte[2];
            converter.CopyTo(combinedBytes, 0);

            return BitConverter.ToUInt16(combinedBytes);
        }
    }
}
