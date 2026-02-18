using FF7Scarlet.AIEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Text;

namespace FF7Scarlet.SceneEditor
{
    public class Enemy : AIContainer
    {
        public const int DATA_BLOCK_SIZE = 152, AI_BLOCK_SIZE = 4090, ELEMENT_RESISTANCE_COUNT = 8,
            ATTACK_COUNT = 16, MANIP_ATTACK_COUNT = 3, DROP_ITEM_COUNT = 4;
        private readonly ResistanceRate?[] resistanceRates = new ResistanceRate?[ELEMENT_RESISTANCE_COUNT];
        private readonly byte[] actionAnimationIndexes = new byte[ATTACK_COUNT];
        private readonly ushort[] attackIDs = new ushort[ATTACK_COUNT];
        private readonly ushort[] cameraMovementIDs = new ushort[ATTACK_COUNT];
        private readonly ushort[] manipAttackIDs = new ushort[MANIP_ATTACK_COUNT];
        private readonly ItemDropRate?[] itemDropRates = new ItemDropRate?[DROP_ITEM_COUNT];
        private ushort modelID, unknown;

        public ushort ModelID
        {
            get { return modelID; }
            set
            {
                if (value != modelID)
                {
                    var scene = Parent as Scene;
                    if (scene != null)
                    {
                        var exists = scene.GetEnemyByID(value);
                        if (exists != null)
                        {
                            throw new ArgumentException("Another enemy in the scene is using this ID.");
                        }
                        modelID = value;
                    }
                }
            }
        }
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

        public Enemy(Scene parent, ushort modelID, FFText name, byte[]? data) :base(parent)
        {
            if (name.Length > Scene.NAME_LENGTH)
            {
                throw new ArgumentException("Enemy name is too long.");
            }
            ModelID = modelID;
            Name = name;

            if (data == null) //initialize data as null
            {
                int i;
                for (i = 0; i < ATTACK_COUNT; ++i)
                {
                    AttackIDs[i] = HexParser.NULL_OFFSET_16_BIT;
                    CameraMovementIDs[i] = HexParser.NULL_OFFSET_16_BIT;
                }
                for (i = 0; i < MANIP_ATTACK_COUNT; ++i)
                {
                    ManipAttackIDs[i] = HexParser.NULL_OFFSET_16_BIT;
                }
                MorphItemIndex = HexParser.NULL_OFFSET_16_BIT;
            }
            else { ParseData(data); }
        }

        public Enemy(Enemy other) :base(other.Parent)
        {
            ModelID = other.ModelID;
            Name = other.Name;
            ParseData(other.GetRawEnemyData(false));
            for (int i = 0; i < SCRIPT_NUMBER; ++i)
            {
                Scripts[i] = new Script(other.Scripts[i]);
            }
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
                for (i = 0; i < ELEMENT_RESISTANCE_COUNT; ++i)
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
                for (i = 0; i < DROP_ITEM_COUNT; ++i) //drop rates
                {
                    temp[i] = reader.ReadByte();
                }
                for (i = 0; i < DROP_ITEM_COUNT; ++i)
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
                for (i = 0; i < MANIP_ATTACK_COUNT; ++i)
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

        public string GetNameString(bool isJapanese)
        {
            var name = Name.ToString(isJapanese);
            if (name == null) { return $"Enemy ID {ModelID:X4}"; }
            else { return name; }
        }

        public bool AttackIsManipable(ushort id)
        {
            return (id != HexParser.NULL_OFFSET_16_BIT && ManipAttackIDs.ToList().Contains(id));
        }

        public bool ManipListIsEmpty()
        {
            foreach (var atk in ManipAttackIDs)
            {
                if (atk != HexParser.NULL_OFFSET_16_BIT) { return false; }
            }
            return true;
        }

        public byte[] GetRawEnemyData(bool includeName)
        {
            int length = DATA_BLOCK_SIZE;
            if (includeName)
            {
                length += Scene.NAME_LENGTH;
            }
            var data = new byte[length];
            using (var ms = new MemoryStream(data, true))
            using (var writer = new BinaryWriter(ms))
            {
                if (includeName)
                {
                    writer.Write(Name.GetBytes(Scene.NAME_LENGTH, addSpace:true));
                }
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
