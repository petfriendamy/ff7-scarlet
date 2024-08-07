﻿using FF7Scarlet.SceneEditor;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;

namespace FF7Scarlet.Shared
{
    public class AttackOld
    {
        public const int BLOCK_SIZE = 28;
        private byte[] rawData;
        private byte unknown = 0xFF;

        public ushort ID { get; }
        public FFText Name { get; set; }
        public FFText? Description { get; set; }
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
        public StatusChange StatusChange { get; set; } = new StatusChange(0xFF);
        public byte AdditionalEffects { get; set; }
        public byte AdditionalEffectsModifier { get; set; }
        public Statuses StatusEffects { get; set; }
        public Elements Elements { get; set; }
        public SpecialEffects SpecialAttackFlags { get; set; }

        public bool IsLimit { get; set; } = false;

        public AttackOld(ushort id)
        {
            ID = id;
            Name = new FFText();
            rawData = new byte[BLOCK_SIZE];
        }

        public AttackOld(ushort id, FFText name, byte[] data)
        {
            ID = id;
            Name = name;
            rawData = data;
            ParseData(data);
        }

        public AttackOld(AttackOld other) : this(other.ID, other) { }

        public AttackOld(ushort id, AttackOld other)
        {
            ID = id;
            Name = other.Name;
            rawData = other.rawData;
            ParseData(rawData);
        }

        public string GetNameString()
        {
            var str = Name.ToString();
            if (str == null) { return $"Unnamed ({ID:X4})"; }
            else { return str; }
        }

        private void ParseData(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                AccuracyRate = reader.ReadByte();
                ImpactEffectID = reader.ReadByte();
                TargetHurtActionIndex = reader.ReadByte();
                unknown = reader.ReadByte();
                MPCost = reader.ReadUInt16();
                ImpactSound = reader.ReadUInt16();
                CameraMovementIDSingle = reader.ReadUInt16();
                CameraMovementIDMulti = reader.ReadUInt16();
                TargetFlags = (TargetData)reader.ReadByte();
                AttackEffectID = reader.ReadByte();
                DamageCalculationID = reader.ReadByte();
                AttackStrength = reader.ReadByte();
                AttackConditions = (AttackConditions)reader.ReadByte();
                StatusChange = new StatusChange(reader.ReadByte());
                AdditionalEffects = reader.ReadByte();
                AdditionalEffectsModifier = reader.ReadByte();
                StatusEffects = (Statuses)reader.ReadUInt32();
                Elements = (Elements)reader.ReadUInt16();
                SpecialAttackFlags = ~(SpecialEffects)reader.ReadUInt16();
            }
        }

        public byte[] GetRawData()
        {
            var copy = new byte[BLOCK_SIZE];
            using (var ms = new MemoryStream(copy))
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(AccuracyRate);
                writer.Write(ImpactEffectID);
                writer.Write(TargetHurtActionIndex);
                writer.Write(unknown);
                writer.Write(MPCost);
                writer.Write(ImpactSound);
                writer.Write(CameraMovementIDSingle);
                writer.Write(CameraMovementIDMulti);
                writer.Write((byte)TargetFlags);
                writer.Write(AttackEffectID);
                writer.Write(DamageCalculationID);
                writer.Write(AttackStrength);
                writer.Write((byte)AttackConditions);
                //writer.Write(StatusChange.GetValue());
                writer.Write(AdditionalEffects);
                writer.Write(AdditionalEffectsModifier);
                if (StatusChange.Type == StatusChangeType.None)
                {
                    writer.Write(HexParser.NULL_OFFSET_32_BIT);
                }
                else
                {
                    writer.Write((uint)StatusEffects);
                }
                writer.Write((ushort)Elements);
                writer.Write((ushort)~SpecialAttackFlags);
            }
            Array.Copy(copy, rawData, BLOCK_SIZE);
            return copy;
        }

        public bool HasDifferences (AttackOld other)
        {
            var temp1 = GetRawData();
            var temp2 = other.GetRawData();
            return !temp1.SequenceEqual(temp2);
        }
    }
}
