using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.Shared
{
    public enum CharacterNames
    {
        Cloud, Barret, Tifa, Aerith, RedXIII, Yuffie, CaitSith, Vincent, Cid, YoungCloud, Sephiroth
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
        public const int CHARACTER_COUNT = 11, PLAYABLE_CHARACTER_COUNT = 9, NAME_LENGTH = 12,
            CHARACTER_DATA_LENGTH = 132;

        private readonly InventoryMateria[] weaponMateria = new InventoryMateria[8];
        private readonly InventoryMateria[] armorMateria = new InventoryMateria[8];
        private int unknown;

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
                Name = new FFText(reader.ReadBytes(NAME_LENGTH));
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
                unknown = reader.ReadInt32(); //unknown
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

        public byte[] GetRawData()
        {
            var data = new byte[CHARACTER_DATA_LENGTH];
            using (var ms = new MemoryStream(data, true))
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(ID);
                writer.Write(Level);
                writer.Write(Strength);
                writer.Write(Vitality);
                writer.Write(Magic);
                writer.Write(Spirit);
                writer.Write(Dexterity);
                writer.Write(Luck);
                writer.Write(StrengthBonus);
                writer.Write(VitalityBonus);
                writer.Write(MagicBonus);
                writer.Write(SpiritBonus);
                writer.Write(DexterityBonus);
                writer.Write(LuckBonus);
                writer.Write(LimitLevel);
                writer.Write(CurrentLimitBar);
                writer.Write(Name.GetBytes(NAME_LENGTH));
                writer.Write(WeaponID);
                writer.Write(ArmorID);
                writer.Write(AccessoryID);
                writer.Write((byte)CharacterFlags);
                if (IsBackRow) { writer.Write((byte)0xFE); }
                else { writer.Write((byte)0xFF); }
                writer.Write(LevelProgressBar);
                writer.Write((ushort)LearnedLimits);
                writer.Write(KillCount);
                writer.Write(Limit1Uses);
                writer.Write(Limit2Uses);
                writer.Write(Limit3Uses);
                writer.Write(CurrentHP);
                writer.Write(BaseHP);
                writer.Write(CurrentMP);
                writer.Write(BaseMP);
                writer.Write(unknown);
                writer.Write(MaxHP);
                writer.Write(MaxMP);
                writer.Write(CurrentEXP);
                foreach (var m in WeaponMateria)
                {
                    writer.Write(m.GetBytes());
                }
                foreach (var m in ArmorMateria)
                {
                    writer.Write(m.GetBytes());
                }
                writer.Write(EXPtoNextLevel);
            }
            return data;
        }

        public bool HasDifferences(Character other)
        {
            var temp1 = GetRawData();
            var temp2 = other.GetRawData();
            return !temp1.SequenceEqual(temp2);
        }
    }
}
