using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF7Scarlet.Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FF7Scarlet.KernelEditor
{
    /*public class InitialData
    {
        public const int INVENTORY_SIZE = 320, MATERIA_INVENTORY_SIZE = 200, STOLEN_MATERIA_COUNT = 48;
        private readonly Character[] characters = new Character[Character.PLAYABLE_CHARACTER_COUNT];
        private readonly ItemStack[] inventoryItems = new ItemStack[INVENTORY_SIZE];
        private readonly InventoryMateria[] inventoryMateria = new InventoryMateria[MATERIA_INVENTORY_SIZE];
        private readonly InventoryMateria[] stolenMateria = new InventoryMateria[STOLEN_MATERIA_COUNT];
        private byte[] rawData = [];

        public Character[] Characters
        {
            get { return characters; }
        }
        public ItemStack[] InventoryItems
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
        public uint StartingGil { get; set; }

        public InitialData(byte[] data)
        {
            ParseData(data);
        }

        public void ParseData(byte[] data)
        {
            rawData = data;
            int i;
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                for (i = 0; i < Character.PLAYABLE_CHARACTER_COUNT; ++i)
                {
                    Characters[i] = new Character(reader.ReadBytes(Character.CHARACTER_DATA_LENGTH));
                }
                Party1 = reader.ReadByte();
                Party2 = reader.ReadByte();
                Party3 = reader.ReadByte();
                reader.ReadByte(); //padding

                for (i = 0; i < INVENTORY_SIZE; ++i)
                {
                    InventoryItems[i] = new ItemStack(reader.ReadBytes(2));
                }
                for (i = 0; i < MATERIA_INVENTORY_SIZE; ++i)
                {
                    InventoryMateria[i] = new InventoryMateria(reader.ReadBytes(4));
                }
                for (i = 0; i < STOLEN_MATERIA_COUNT; ++i)
                {
                    StolenMateria[i] = new InventoryMateria(reader.ReadBytes(4));
                }

                reader.ReadBytes(32); //padding
                StartingGil = reader.ReadUInt32();
            }
        }

        public byte[] GetRawData()
        {
            using (var ms = new MemoryStream(rawData))
            using (var writer = new BinaryWriter(ms))
            {
                foreach (var chara in Characters)
                {
                    writer.Write(chara.GetRawData());
                }
                writer.Write(Party1);
                writer.Write(Party2);
                writer.Write(Party3);
                writer.Write((byte)0xFF);

                foreach (var i in InventoryItems)
                {
                    writer.Write(i.GetValue());
                }
                foreach (var m in InventoryMateria)
                {
                    writer.Write(m.GetBytes());
                }
                foreach (var m in StolenMateria)
                {
                    writer.Write(m.GetBytes());
                }
                writer.Write(HexParser.GetNullBlock(32)); //padding
                writer.Write(StartingGil);
            }
            var copy = new byte[rawData.Length];
            Array.Copy(rawData, copy, rawData.Length);
            return copy;
        }
    }*/
}
