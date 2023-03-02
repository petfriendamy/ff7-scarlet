using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;

namespace FF7Scarlet.Shared
{
    public class Attack
    {
        public const int BLOCK_SIZE = 28;
        private byte[] rawData;

        public ushort ID { get; }
        public FFText Name { get; set; }
        public byte AccuracyRate { get; set; }
        public byte ImpactEffectID { get; set; } = 0xFF;
        public byte TargetHurtActionIndex { get; set; } = 0xFF;
        public ushort MPCost { get; set; }
        public ushort ImpactSound { get; set; } = HexParser.NULL_OFFSET_16_BIT;
        public ushort CameraMovementIDSingle { get; set; } = HexParser.NULL_OFFSET_16_BIT;
        public ushort CameraMovementIDMulti { get; set; } = HexParser.NULL_OFFSET_16_BIT;
        public TargetData TargetFlags { get; set; }
        public byte AttackEffectID { get; set; } = 0xFF;
        public byte DamageCalculationID { get; set; } = 0xFF;
        public byte AttackStrength { get; set; }
        public AttackConditions AttackConditions { get; set; }
        public StatusChange StatusChange { get; set; } = StatusChange.None;
        public byte StatusChangeChance { get; set; }
        public byte AditionalEffects { get; set; }
        public byte AdditionalEffectsModifier { get; set; }
        public Statuses StatusEffects { get; set; }
        public Elements Elements { get; set; }
        public SpecialEffects SpecialAttackFlags { get; set; }

        public Attack(ushort id)
        {
            ID = id;
            Name = new FFText();
            rawData = new byte[BLOCK_SIZE];
        }

        public Attack(ushort id, FFText name, byte[] data) :this(id)
        {
            Name = name;
            rawData = data;
            ParseData(data);
        }

        public string GetNameString()
        {
            var str = Name.ToString();
            if (str == null) { return $"Unnamed ({ID:X4})"; }
            else { return str; }
        }

        public byte[] GetRawData()
        {
            var copy = new byte[rawData.Length];
            Array.Copy(rawData, copy, rawData.Length);
            return copy;
        }

        private void ParseData(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                AccuracyRate = reader.ReadByte();
                ImpactEffectID = reader.ReadByte();
                TargetHurtActionIndex = reader.ReadByte();
                reader.ReadByte(); //unknown
                MPCost = reader.ReadUInt16();
                ImpactSound = reader.ReadUInt16();
                CameraMovementIDSingle = reader.ReadUInt16();
                CameraMovementIDMulti = reader.ReadUInt16();
                TargetFlags = (TargetData)reader.ReadByte();
                AttackEffectID = reader.ReadByte();
                DamageCalculationID = reader.ReadByte();
                AttackStrength = reader.ReadByte();
                AttackConditions = (AttackConditions)reader.ReadByte();
                SetStatusChange(reader.ReadByte());
                AditionalEffects = reader.ReadByte();
                AdditionalEffectsModifier = reader.ReadByte();
                StatusEffects = (Statuses)reader.ReadUInt32();
                Elements = (Elements)reader.ReadUInt16();
                SpecialAttackFlags = ~(SpecialEffects)reader.ReadUInt16();
            }
        }

        private void SetStatusChange(byte value)
        {
            var flags = (StatusChange)value;
            if (flags == StatusChange.None)
            {
                StatusChange = StatusChange.None;
                StatusChangeChance = 0;
            }
            else if (flags.HasFlag(StatusChange.Cure))
            {
                StatusChange = StatusChange.Cure;
                StatusChangeChance = (byte)(value - StatusChange.Cure);
            }
            else if (flags.HasFlag(StatusChange.Swap))
            {
                StatusChange = StatusChange.Swap;
                StatusChangeChance = (byte)(value - StatusChange.Swap);
            }
            else
            {
                StatusChange = StatusChange.Inflict;
                StatusChangeChance = value;
            }
        }
    }
}
