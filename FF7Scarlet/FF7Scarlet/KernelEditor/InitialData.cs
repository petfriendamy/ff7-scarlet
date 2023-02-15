using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.KernelEditor
{
    public class InitialData
    {
        public const int CHAR_COUNT = 9, INVENTORY_SIZE = 320, MATERIA_INVENTORY_SIZE = 200,
            STOLEN_MATERIA_COUNT = 48;
        private readonly Character[] characters = new Character[CHAR_COUNT];
        private readonly InventoryItem[] inventoryItems = new InventoryItem[INVENTORY_SIZE];
        private readonly InventoryMateria[] inventoryMateria = new InventoryMateria[MATERIA_INVENTORY_SIZE];
        private readonly InventoryMateria[] stolenMateria = new InventoryMateria[STOLEN_MATERIA_COUNT];

        public Character[] Characters
        {
            get { return characters; }
        }
        public InventoryItem[] InventoryItems
        {
            get { return inventoryItems; }
        }
        public InventoryMateria[] InventoryMateria
        {
            get { return inventoryMateria; }
        }
        public InventoryMateria[] StolenMateria
        {
            get { return stolenMateria; }
        }
        public byte Party1 { get; set; }
        public byte Party2 { get; set; }
        public byte Party3 { get; set; }

        public InitialData(byte[] data)
        {
            int i;
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {

                for (i = 0; i < CHAR_COUNT; ++i)
                {
                    Characters[i] = new Character(reader.ReadBytes(132));
                }
                Party1 = reader.ReadByte();
                Party2 = reader.ReadByte();
                Party3 = reader.ReadByte();
                reader.ReadByte(); //padding

                for (i = 0; i < INVENTORY_SIZE; ++i)
                {
                    InventoryItems[i] = new InventoryItem(reader.ReadBytes(2));
                }
                for (i = 0; i < MATERIA_INVENTORY_SIZE; ++i)
                {
                    InventoryMateria[i] = new InventoryMateria(reader.ReadBytes(4));
                }
                for (i = 0; i < STOLEN_MATERIA_COUNT; ++i)
                {
                    StolenMateria[i] = new InventoryMateria(reader.ReadBytes(4));
                }
            }
        }
    }
}
