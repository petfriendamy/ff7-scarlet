using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.KernelEditor
{
    public enum CharacterNames
    {
        Cloud, Barret, Tifa, Aerith, RedXIII, Yuffie, CaitSith, Vincent, Cid
    }

    public enum CharacterFlags
    {
        None = 0x00,
        Sadness = 0x10,
        Fury = 0x20
    }

    [Flags]
    public enum LearnedLimits : ushort
    {
        LimitLv1_1 = 0x0001,
        LimitLv1_2 = 0x0002,
        LimitLv2_1 = 0x0008,
        LimitLv2_2 = 0x0010,
        LimitLv3_1 = 0x0040,
        LimitLv3_2 = 0x0080,
        LimitLv4 = 0x2000
    }

    public class Character
    {
        private readonly InventoryMateria[] weaponMateria = new InventoryMateria[8];
        private readonly InventoryMateria[] armorMateria = new InventoryMateria[8];

        public FFText Name { get; set; }
        public byte ID { get; set; }
        public byte Level { get; set; }
        public byte Strength { get; set; }
        public byte Vitality { get; set; }
        public byte Magic { get; set; }
        public byte Spirit { get; set; }
        public byte Dexterity { get; set; }
        public byte Luck { get; set; }
        public byte StrengthBonus { get; set; }
        public byte VitalityBonus { get; set; }
        public byte MagicBonus { get; set; }
        public byte SpiritBonus { get; set; }
        public byte DexterityBonus { get; set; }
        public byte LuckBonus { get; set; }
        public byte LimitLevel { get; set; }
        public byte CurrentLimitBar { get; set; }
        public byte WeaponID { get; set; }
        public byte ArmorID { get; set; }
        public byte AccessoryID { get; set; }
        public CharacterFlags CharacterFlags { get; set; }
        public bool IsBackRow { get; set; }
        public byte LevelProgressBar { get; set; }
        public LearnedLimits LearnedLimits { get; set; }
        public ushort KillCount { get; set; }
        public ushort Limit1Uses { get; set; }
        public ushort Limit2Uses { get; set; }
        public ushort Limit3Uses { get; set; }
        public ushort CurrentHP { get; set; }
        public ushort BaseHP { get; set; }
        public ushort MaxHP { get; set; }
        public ushort CurrentMP { get; set; }
        public ushort BaseMP { get; set; }
        public ushort MaxMP { get; set; }
        public uint CurrentEXP { get; set; }
        public InventoryMateria[] WeaponMateria
        {
            get { return weaponMateria; }
        }
        public InventoryMateria[] ArmorMateria
        {
            get { return armorMateria; }
        }
        public uint EXPtoNextLevel { get; set; }

        public Character(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                ID = reader.ReadByte();
                Level = reader.ReadByte();
                Strength = reader.ReadByte();
                Vitality = reader.ReadByte();
                Magic = reader.ReadByte();
                Spirit = reader.ReadByte();
                Dexterity = reader.ReadByte();
                Luck = reader.ReadByte();
                StrengthBonus = reader.ReadByte();
                VitalityBonus = reader.ReadByte();
                MagicBonus = reader.ReadByte();
                SpiritBonus = reader.ReadByte();
                DexterityBonus = reader.ReadByte();
                LuckBonus = reader.ReadByte();
                LimitLevel = reader.ReadByte();
                CurrentLimitBar = reader.ReadByte();
                Name = new FFText(reader.ReadBytes(12));
                WeaponID = reader.ReadByte();
                ArmorID = reader.ReadByte();
                AccessoryID = reader.ReadByte();
                CharacterFlags = (CharacterFlags)reader.ReadByte();
                IsBackRow = reader.ReadByte() == 0xFE;
                LevelProgressBar = reader.ReadByte();
                LearnedLimits = (LearnedLimits)reader.ReadUInt16();
                KillCount = reader.ReadUInt16();
                Limit1Uses = reader.ReadUInt16();
                Limit2Uses = reader.ReadUInt16();
                Limit3Uses = reader.ReadUInt16();
                CurrentHP = reader.ReadUInt16();
                BaseHP = reader.ReadUInt16();
                CurrentMP = reader.ReadUInt16();
                BaseMP = reader.ReadUInt16();
                reader.ReadInt32(); //unknown
                MaxHP = reader.ReadUInt16();
                MaxMP = reader.ReadUInt16();
                CurrentEXP = reader.ReadUInt32();
                for (int i = 0; i < 8; ++i)
                {
                    WeaponMateria[i] = new InventoryMateria(reader.ReadBytes(4));
                }
                for (int i = 0; i < 8; ++i)
                {
                    ArmorMateria[i] = new InventoryMateria(reader.ReadBytes(4));
                }
                EXPtoNextLevel = reader.ReadUInt32();
            }
        }
    }
}
