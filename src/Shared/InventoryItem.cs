using Shojy.FF7.Elena.Equipment;
using FF7Scarlet.KernelEditor;

namespace FF7Scarlet.Shared
{
    public enum ItemType
    {
        None, Item, Weapon, Armor, Accessory, Materia
    }

    public class InventoryItem
    {
        #region Properties

        public const ushort WEAPON_START = 128, ARMOR_START = 256, ACCESSORY_START = 288, MATERIA_START = 320, MAX_INDEX = 415,
            ITEM_COUNT = WEAPON_START,
            WEAPON_COUNT = ARMOR_START - WEAPON_START,
            ARMOR_COUNT = ACCESSORY_START - ARMOR_START,
            ACCESSORY_COUNT = MATERIA_START - ACCESSORY_START,
            MATERIA_COUNT = MAX_INDEX - MATERIA_START + 1;

        public byte Index { get; private set; }
        public ItemType Type { get; private set; }

        #endregion

        #region Constructors

        public InventoryItem(ushort itemIndex)
        {
            Index = GetIndex(itemIndex);
            Type = GetType(itemIndex);
        }

        public InventoryItem(byte index, ItemType type)
        {
            Index = index;
            Type = type;
        }

        public InventoryItem(Accessory accessory)
        {
            Type = ItemType.Accessory;
            Index = (byte)accessory.Index;
        }

        public InventoryItem(MateriaExt materia)
        {
            Type = ItemType.Materia;
            Index = (byte)materia.Index;
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
                case ItemType.Materia:
                    return (byte)(value - MATERIA_START);
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
                case ItemType.Materia:
                    return (ushort)(index + MATERIA_START);
                default:
                    return HexParser.NULL_OFFSET_16_BIT;
            }
        }

        public ushort GetCombinedIndex()
        {
            return GetCombinedIndex(Type, Index);
        }

        public static ItemType GetType(ushort value)
        {
            if (value > MAX_INDEX)
            {
                return ItemType.None;
            }
            else if (value < WEAPON_START)
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
            else if(value < MATERIA_START)
            {
                return ItemType.Accessory;
            }
            else
            {
                return ItemType.Materia;
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
