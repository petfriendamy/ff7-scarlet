using System.Collections;

namespace FF7Scarlet.KernelEditor
{
    public enum ItemType
    {
        None, Item, Weapon, Armor, Accessory
    }

    public class InventoryItem
    {
        #region Properties

        public const ushort WEAPON_START = 128, ARMOR_START = 256, ACCESSORY_START = 288, MAX_INDEX = 319;

        public byte Index { get; private set; }
        public int Amount { get; set; }
        public ItemType Type { get; private set; }

        #endregion

        #region Constructors

        public InventoryItem(ushort itemIndex, int amount)
        {
            Index = GetIndex(itemIndex);
            Amount = amount;
            Type = GetType(itemIndex);
        }

        public InventoryItem(byte index, int amount, ItemType type)
        {
            Index = index;
            Amount = amount;
            Type = type;
        }

        public InventoryItem(byte[] data)
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
            Type = GetType(value);
            Index = GetIndex(value);

            converter = new BitArray(amountBits);
            var amountBytes = new byte[1];
            converter.CopyTo(amountBytes, 0);
            Amount = amountBytes[0];
        }

        #endregion

        #region Methods

        public static byte GetIndex(ushort value)
        {
            return GetIndex(GetType(value), value);
        }

        public static byte GetIndex(ItemType type, ushort value)
        {
            switch (type)
            {
                case ItemType.Item:
                    return (byte)value;
                case ItemType.Weapon:
                    return (byte)(value - WEAPON_START);
                case ItemType.Armor:
                    return (byte)(value - ARMOR_START);
                case ItemType.Accessory:
                    return (byte)(value - ACCESSORY_START);
                default:
                    return 0xFF;
            }
        }

        public static ushort GetCombinedIndex(ItemType type, byte index)
        {
            switch (type)
            {
                case ItemType.Item:
                    return index;
                case ItemType.Weapon:
                    return (ushort)(index + WEAPON_START);
                case ItemType.Armor:
                    return (ushort)(index + ARMOR_START);
                case ItemType.Accessory:
                    return (ushort)(index + ACCESSORY_START);
                default:
                    return HexParser.NULL_OFFSET_16_BIT;
            }
        }

        public static ItemType GetType(ushort value)
        {
            if (value > MAX_INDEX)
            {
                return ItemType.None;
            }
            if (value < WEAPON_START)
            {
                return ItemType.Item;
            }
            else if (value < ARMOR_START)
            {
                return ItemType.Weapon;
            }
            else if (value < ACCESSORY_START)
            {
                return ItemType.Armor;
            }
            else
            {
                return ItemType.Accessory;
            }
        }

        public void SetItem(ItemType type, byte index)
        {
            Type = type;
            Index = index;
        }

        #endregion
    }
}
