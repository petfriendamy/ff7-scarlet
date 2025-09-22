using FF7Scarlet.KernelEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Inventory;

namespace FF7Scarlet.ExeEditor
{
    public enum ShopType { Item, Weapon, Item2, Materia, General, Vegetable, Accessory, Tool, Hotel }

    public class ShopInventory
    {
        public const int SHOP_DATA_LENGTH = 84, SHOP_ITEM_MAX = 10;

        public ShopType ShopType { get; set; }
        public int DialogueSet { get; set; }
        public byte ItemCount { get; private set; }
        public InventoryItem?[] Inventory { get; } = new InventoryItem?[SHOP_ITEM_MAX];

        public ShopInventory(ShopType type, int dialogueSet, InventoryItem[] items)
        {
            ShopType = type;
            DialogueSet = dialogueSet;
            if (items.Length < 1 || items.Length >= SHOP_ITEM_MAX)
            {
                throw new ArgumentOutOfRangeException(nameof(ItemCount));
            }
            ItemCount = (byte)items.Length;
            for (int i = 0; i < ItemCount; ++i)
            {
                Inventory[i] = items[i];
            }
        }

        public ShopInventory(byte[] data)
        {
            if (data.Length != SHOP_DATA_LENGTH)
            {
                throw new ArgumentException("Incorrect data length.");
            }

            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                ShopType = (ShopType)reader.ReadByte();
                DialogueSet = reader.ReadByte();
                ItemCount = reader.ReadByte();
                if (ItemCount > SHOP_ITEM_MAX) { throw new ArgumentOutOfRangeException(nameof(ItemCount)); }
                reader.ReadByte(); //padding

                for (int i = 0; i < ItemCount; ++i)
                {
                    int type = reader.ReadInt32();
                    ushort index = reader.ReadUInt16();
                    reader.ReadUInt16(); //padding

                    InventoryItem? temp = null;
                    if (type == 1) //materia
                    {
                        temp = new InventoryItem();
                        DataParser.SetItem(temp, ItemType.Materia, (byte)index);
                    }
                    else //other item
                    {
                        temp = new InventoryItem();
                        temp.Item = index;
                    }
                    Inventory[i] = temp;
                }
            }
        }

        public void AddItem(InventoryItem item)
        {
            Inventory[ItemCount] = item;
            ItemCount++;
        }

        public void RemoveItem()
        {
            ItemCount--;
            Inventory[ItemCount] = null;
        }

        public byte[] GetByteArray()
        {
            var data = new byte[SHOP_DATA_LENGTH];
            using (var ms = new MemoryStream(data))
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write((byte)ShopType);
                writer.Write((byte)DialogueSet);
                writer.Write((ushort)ItemCount);
                for (int i = 0; i < SHOP_ITEM_MAX; ++i)
                {
                    if (i < ItemCount)
                    {
                        var item = Inventory[i];
                        if (item == null)
                        {
                            writer.Write(0);
                            writer.Write(0);
                        }
                        else
                        {
                            var type = DataParser.GetItemType(item.Item);
                            if (type == ItemType.Materia)
                            {
                                writer.Write(1);
                                writer.Write((int)DataParser.GetItemIndex(item.Item));
                            }
                            else
                            {
                                writer.Write(0);
                                writer.Write((int)item.Item);
                            }
                        }
                    }
                    else
                    {
                        writer.Write(0);
                        writer.Write(0);
                    }
                }
            }
            return data;
        }

        public bool HasDifferences(ShopInventory other)
        {
            var temp1 = GetByteArray();
            var temp2 = other.GetByteArray();
            return !temp1.SequenceEqual(temp2);
        }
    }
}
