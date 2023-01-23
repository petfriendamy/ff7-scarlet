using FF7Scarlet.SceneEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shojy.FF7.Elena.Battle;
using System.Configuration;

namespace FF7Scarlet
{
    public class Enemy : AIContainer
    {
        private ResistanceRate[] resistRates = new ResistanceRate[8];
        private byte[] animationIndexes = new byte[16];
        private ushort[] attackIDs = new ushort[16];
        private ushort[] camIDs = new ushort[16];
        private ushort[] manipAttacks = new ushort[3];
        private ItemDropRate[] dropRates = new ItemDropRate[4];
        private ushort morphItem, unknown;
        private byte[] statusImmunities = new byte[4];
        private byte alignFF;

        public int ID { get; }
        public FFText Name { get; set; }
        public byte Level { get; set; }
        public byte Speed { get; set; }
        public byte Luck { get; set; }
        public byte Evade { get; set; }
        public byte Strength { get; set; }
        public byte Defense { get; set; }
        public byte Magic { get; set; }
        public byte MDef { get; set; }
        public ushort MP { get; set; }
        public ushort AP { get; set; }
        public byte BackAttackMultiplier { get; set; }
        public int HP { get; set; }
        public int EXP { get; set; }
        public int Gil { get; set; }

        public Enemy(Scene parent, int id, FFText name, byte[] data)
        {
            Parent = parent;
            ID = id;
            Name = name;
            ParseData(data);
        }

        private void ParseData(byte[] data)
        {
            var temp = new byte[8];
            int i, j;
            using (var ms = new MemoryStream(data, false))
            using (var reader = new BinaryReader(ms))
            {
                Level = reader.ReadByte();
                Speed = reader.ReadByte();
                Luck = reader.ReadByte();
                Evade = reader.ReadByte();
                Strength = reader.ReadByte();
                Defense = reader.ReadByte();
                Magic = reader.ReadByte();
                MDef = reader.ReadByte();
                for (i = 0; i < 8; ++i) //resist data
                {
                    temp[i] = reader.ReadByte();
                }
                for (i = 0; i < 8; ++i)
                {
                    j = reader.ReadByte();
                    if (temp[i] != 0xFF)
                    {
                        if (temp[i] < 0x10) //element
                        {
                            resistRates[i] = new ElementResistanceRate((MateriaElements)temp[i], (ResistRates)j);
                        }
                        else //status effect
                        {
                            resistRates[i] = new StatusResistanceRate((EquipmentStatus)(temp[i] - 0x20), (ResistRates)j);
                        }
                    }
                }
                for (i = 0; i < 16; ++i)
                {
                    animationIndexes[i] = reader.ReadByte();
                }
                for (i = 0; i < 16; ++i)
                {
                    attackIDs[i] = reader.ReadUInt16();
                }
                for (i = 0; i < 16; ++i)
                {
                    camIDs[i] = reader.ReadUInt16();
                }
                for (i = 0; i < 4; ++i) //drop rates
                {
                    temp[i] = reader.ReadByte();
                }
                for (i = 0; i < 4; ++i)
                {
                    dropRates[i] = new ItemDropRate(reader.ReadUInt16(), temp[i]);
                }
                for (i = 0; i < 3; ++i)
                {
                    manipAttacks[i] = reader.ReadUInt16();
                }
                unknown = reader.ReadUInt16();
                MP = reader.ReadUInt16();
                AP = reader.ReadUInt16();
                morphItem = reader.ReadUInt16();
                BackAttackMultiplier = reader.ReadByte();
                alignFF = reader.ReadByte();
                HP = reader.ReadInt32();
                EXP = reader.ReadInt32();
                Gil = reader.ReadInt32();
                for (i = 0; i < 4; ++i)
                {
                    statusImmunities[i] = reader.ReadByte();
                }
            }
        }

        public byte[] GetRawEnemyData()
        {
            var data = new byte[Scene.ENEMY_DATA_BLOCK_SIZE + Scene.NAME_LENGTH];
            using (var ms = new MemoryStream(data, true))
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(Name.GetBytes());
                writer.Write(Level);
                writer.Write(Speed);
                writer.Write(Luck);
                writer.Write(Evade);
                writer.Write(Strength);
                writer.Write(Defense);
                writer.Write(Magic);
                writer.Write(MDef);
                foreach (var r in resistRates)
                {
                    if (r == null) { writer.Write((byte)0xFF); }
                    else
                    {
                        writer.Write(r.GetID());
                    }
                }
                foreach (var r in resistRates)
                {
                    if (r == null) { writer.Write((byte)0xFF); }
                    else
                    {
                        writer.Write((byte)r.Rate);
                    }
                }
                foreach (var a in animationIndexes)
                {
                    writer.Write(a);
                }
                foreach (var a in attackIDs)
                {
                    writer.Write(a);
                }
                foreach (var c in camIDs)
                {
                    writer.Write(c);
                }
                foreach (var d in dropRates)
                {
                    if (d == null) { writer.Write((byte)0xFF); }
                    else
                    {
                        writer.Write(d.GetRawDropRate());
                    }
                }
                foreach (var d in dropRates)
                {
                    if (d == null) { writer.Write((ushort)0xFFFF); }
                    else
                    {
                        writer.Write(d.ItemID);
                    }
                }
                foreach (var m in manipAttacks)
                {
                    writer.Write(m);
                }
                writer.Write(unknown);
                writer.Write(MP);
                writer.Write(AP);
                writer.Write(morphItem);
                writer.Write(BackAttackMultiplier);
                writer.Write(alignFF);
                writer.Write(HP);
                writer.Write(EXP);
                writer.Write(Gil);
                foreach (var s in statusImmunities)
                {
                    writer.Write(s);
                }
                writer.Write(0xFFFFFFFF);
            }
            return data;
        }
    }
}
