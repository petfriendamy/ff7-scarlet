using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.KernelEditor
{
    public enum ItemType
    {
        None, Item, Weapon, Armor, Accessory
    }

    public class InventoryItem
    {
        public const ushort WEAPON_START = 128, ARMOR_START = 256, ACCESSORY_START = 288, MAX_INDEX = 319;

        public byte Index { get; private set; }
        public int Amount { get; set; }
        public ItemType Type { get; private set; }

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

        public byte GetIndex(int value)
        {
            return GetIndex(GetType(value), value);
        }

        public byte GetIndex(ItemType type, int value)
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
                    return 0;
            }
        }

        public ItemType GetType(int value)
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
    }
}
