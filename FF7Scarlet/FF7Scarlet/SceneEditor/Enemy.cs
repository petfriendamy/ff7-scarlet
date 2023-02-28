using FF7Scarlet.AIEditor;
using Shojy.FF7.Elena.Battle;

namespace FF7Scarlet.SceneEditor
{
    public class Enemy : AIContainer
    {
        public const int ATTACK_COUNT = 16;
        private readonly ResistanceRate?[] resistanceRates = new ResistanceRate?[8];
        private readonly byte[] actionAnimationIndexes = new byte[ATTACK_COUNT];
        private readonly ushort[] attackIDs = new ushort[ATTACK_COUNT];
        private readonly ushort[] cameraMovementIDs = new ushort[ATTACK_COUNT];
        private readonly ushort[] manipAttackIDs = new ushort[3];
        private readonly ItemDropRate?[] itemDropRates = new ItemDropRate?[4];
        private ushort unknown;

        public ushort ID { get; }
        public FFText Name { get; set; }
        public byte Level { get; set; }
        public byte Speed { get; set; }
        public byte Luck { get; set; }
        public byte Evade { get; set; }
        public byte Strength { get; set; }
        public byte Defense { get; set; }
        public byte Magic { get; set; }
        public byte MDef { get; set; }
        public Statuses StatusImmunities { get; set; }
        public ushort MP { get; set; }
        public ushort AP { get; set; }
        public ushort MorphItemIndex { get; set; }
        public byte BackAttackMultiplier { get; set; }
        public uint HP { get; set; }
        public uint EXP { get; set; }
        public uint Gil { get; set; }
        public ResistanceRate?[] ResistanceRates
        {
            get { return resistanceRates; }
        }
        public byte[] ActionAnimationIndexes
        {
            get { return actionAnimationIndexes; }
        }
        public ushort[] AttackIDs
        {
            get { return attackIDs; }
        }
        public ushort[] CameraMovementIDs
        {
            get { return cameraMovementIDs; }
        }
        public ushort[] ManipAttackIDs
        {
            get { return manipAttackIDs; }
        }
        public ItemDropRate?[] ItemDropRates
        {
            get { return itemDropRates; }
        }

        public Enemy(Scene parent, ushort id, FFText name, byte[]? data)
        {
            if (name.Length > Scene.NAME_LENGTH)
            {
                throw new ArgumentException("Enemy name is too long.");
            }
            Parent = parent;
            ID = id;
            Name = name;

            if (data == null) //initialize data as null
            {
                int i;
                for (i = 0; i < ATTACK_COUNT; ++i)
                {
                    AttackIDs[i] = HexParser.NULL_OFFSET_16_BIT;
                    CameraMovementIDs[i] = HexParser.NULL_OFFSET_16_BIT;
                }
                for (i = 0; i < 3; ++i)
                {
                    ManipAttackIDs[i] = HexParser.NULL_OFFSET_16_BIT;
                }
                MorphItemIndex = HexParser.NULL_OFFSET_16_BIT;
            }
            else { ParseData(data); }
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
                    if (temp[i] == 0xFF && j == 0xFF) //none
                    {
                        ResistanceRates[i] = null;
                    }
                    else if (temp[i] < 0x10) //element
                    {
                        ResistanceRates[i] = new ElementResistanceRate((MateriaElements)temp[i], (ResistRates)j);
                    }
                    else //status effect
                    {
                        ResistanceRates[i] = new StatusResistanceRate((EquipmentStatus)(temp[i] - 0x20), (ResistRates)j);
                    }
                }
                for (i = 0; i < ATTACK_COUNT; ++i)
                {
                    ActionAnimationIndexes[i] = reader.ReadByte();
                }
                for (i = 0; i < ATTACK_COUNT; ++i)
                {
                    AttackIDs[i] = reader.ReadUInt16();
                }
                for (i = 0; i < ATTACK_COUNT; ++i)
                {
                    CameraMovementIDs[i] = reader.ReadUInt16();
                }
                for (i = 0; i < 4; ++i) //drop rates
                {
                    temp[i] = reader.ReadByte();
                }
                for (i = 0; i < 4; ++i)
                {
                    j = reader.ReadUInt16();
                    if (temp[i] == 0xFF && j == HexParser.NULL_OFFSET_16_BIT) //none
                    {
                        ItemDropRates[i] = null;
                    }
                    else
                    {
                        ItemDropRates[i] = new ItemDropRate((ushort)j, temp[i]);
                    }
                }
                for (i = 0; i < 3; ++i)
                {
                    ManipAttackIDs[i] = reader.ReadUInt16();
                }
                unknown = reader.ReadUInt16();
                MP = reader.ReadUInt16();
                AP = reader.ReadUInt16();
                MorphItemIndex = reader.ReadUInt16();
                BackAttackMultiplier = reader.ReadByte();
                reader.ReadByte(); //padding
                HP = reader.ReadUInt32();
                EXP = reader.ReadUInt32();
                Gil = reader.ReadUInt32();
                StatusImmunities = (Statuses)~reader.ReadUInt32();
            }
        }

        public bool AttackIsManipable(ushort id)
        {
            return (id != HexParser.NULL_OFFSET_16_BIT && ManipAttackIDs.ToList().Contains(id));
        }

        public byte[] GetRawEnemyData()
        {
            var data = new byte[Scene.ENEMY_DATA_BLOCK_SIZE + Scene.NAME_LENGTH];
            using (var ms = new MemoryStream(data, true))
            using (var writer = new BinaryWriter(ms))
            {
                var name = Name.GetBytes();
                if (name == null) { writer.Write(HexParser.GetNullBlock(Scene.NAME_LENGTH)); }
                else { writer.Write(name); }
                writer.Write(Level);
                writer.Write(Speed);
                writer.Write(Luck);
                writer.Write(Evade);
                writer.Write(Strength);
                writer.Write(Defense);
                writer.Write(Magic);
                writer.Write(MDef);
                foreach (var r in ResistanceRates)
                {
                    if (r == null) { writer.Write((byte)0xFF); }
                    else
                    {
                        writer.Write(r.GetID());
                    }
                }
                foreach (var r in ResistanceRates)
                {
                    if (r == null) { writer.Write((byte)0xFF); }
                    else
                    {
                        writer.Write((byte)r.Rate);
                    }
                }
                foreach (var a in ActionAnimationIndexes)
                {
                    writer.Write(a);
                }
                foreach (var a in AttackIDs)
                {
                    writer.Write(a);
                }
                foreach (var c in CameraMovementIDs)
                {
                    writer.Write(c);
                }
                foreach (var d in ItemDropRates)
                {
                    if (d == null) { writer.Write((byte)0xFF); }
                    else
                    {
                        writer.Write(d.GetRawDropRate());
                    }
                }
                foreach (var d in ItemDropRates)
                {
                    if (d == null) { writer.Write(HexParser.NULL_OFFSET_16_BIT); }
                    else
                    {
                        writer.Write(d.ItemID);
                    }
                }
                foreach (var m in ManipAttackIDs)
                {
                    writer.Write(m);
                }
                writer.Write(unknown);
                writer.Write(MP);
                writer.Write(AP);
                writer.Write(MorphItemIndex);
                writer.Write(BackAttackMultiplier);
                writer.Write((byte)0xFF);
                writer.Write(HP);
                writer.Write(EXP);
                writer.Write(Gil);
                writer.Write((uint)~StatusImmunities);
                writer.Write(HexParser.NULL_OFFSET_32_BIT);
            }
            return data;
        }
    }
}
