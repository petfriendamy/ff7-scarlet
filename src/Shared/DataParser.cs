using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Characters;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Inventory;
using Shojy.FF7.Elena.Items;
using Shojy.FF7.Elena.Materias;
using System.Buffers.Text;
using System.Collections;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace FF7Scarlet.Shared
{
    public static class DataParser
    {
        public static int ATTACK_BLOCK_SIZE = 28, CHARACTER_NAME_LENGTH = 12, CHARACTER_RECORD_LENGTH = 132;
        public const ushort
            WEAPON_START = 128,
            ARMOR_START = 256,
            ACCESSORY_START = 288,
            MATERIA_START = 320,
            MAX_INDEX = 415,
            ITEM_COUNT = WEAPON_START,
            WEAPON_COUNT = ARMOR_START - WEAPON_START,
            ARMOR_COUNT = ACCESSORY_START - ARMOR_START,
            ACCESSORY_COUNT = MATERIA_START - ACCESSORY_START,
            MATERIA_COUNT = MAX_INDEX - MATERIA_START + 1;

        public static Character ReadCharacter(byte[] data)
        {
            var c = new Character();
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                c.ID = reader.ReadByte();
                c.Level = reader.ReadByte();
                c.Strength = reader.ReadByte();
                c.Vitality = reader.ReadByte();
                c.Magic = reader.ReadByte();
                c.Spirit = reader.ReadByte();
                c.Dexterity = reader.ReadByte();
                c.Luck = reader.ReadByte();
                c.StrengthBonus = reader.ReadByte();
                c.VitalityBonus = reader.ReadByte();
                c.MagicBonus = reader.ReadByte();
                c.SpiritBonus = reader.ReadByte();
                c.DexterityBonus = reader.ReadByte();
                c.LuckBonus = reader.ReadByte();
                c.LimitLevel = reader.ReadByte();
                c.CurrentLimitBar = reader.ReadByte();
                c.Name = new FFText(reader.ReadBytes(CHARACTER_NAME_LENGTH)).ToString();
                c.WeaponID = reader.ReadByte();
                c.ArmorID = reader.ReadByte();
                c.AccessoryID = reader.ReadByte();
                c.CharacterFlags = (CharacterFlags)reader.ReadByte();
                c.IsBackRow = reader.ReadByte() == 0xFE;
                c.LevelProgressBar = reader.ReadByte();
                c.LearnedLimits = (LearnedLimits)reader.ReadUInt16();
                c.KillCount = reader.ReadUInt16();
                c.Limit1Uses = reader.ReadUInt16();
                c.Limit2Uses = reader.ReadUInt16();
                c.Limit3Uses = reader.ReadUInt16();
                c.CurrentHP = reader.ReadUInt16();
                c.BaseHP = reader.ReadUInt16();
                c.CurrentMP = reader.ReadUInt16();
                c.BaseMP = reader.ReadUInt16();
                reader.ReadInt32(); //unknown
                c.MaxHP = reader.ReadUInt16();
                c.MaxMP = reader.ReadUInt16();
                c.CurrentEXP = reader.ReadUInt32();
                for (int i = 0; i < 8; ++i)
                {
                    var mat = new InventoryMateria();
                    mat.ParseData(reader.ReadBytes(4));
                    c.WeaponMateria[i] = mat;
                }
                for (int i = 0; i < 8; ++i)
                {
                    var mat = new InventoryMateria();
                    mat.ParseData(reader.ReadBytes(4));
                    c.ArmorMateria[i] = mat;
                }
                c.EXPtoNextLevel = reader.ReadUInt32();
            }
            return c;
        }

        public static byte[] GetCharacterInitialDataBytes(Character c)
        {
            var data = new byte[CHARACTER_RECORD_LENGTH];
            using (var ms = new MemoryStream(data))
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(c.ID);
                writer.Write(c.Level);
                writer.Write(c.Strength);
                writer.Write(c.Vitality);
                writer.Write(c.Magic);
                writer.Write(c.Spirit);
                writer.Write(c.Dexterity);
                writer.Write(c.Luck);
                writer.Write(c.StrengthBonus);
                writer.Write(c.VitalityBonus);
                writer.Write(c.MagicBonus);
                writer.Write(c.SpiritBonus);
                writer.Write(c.DexterityBonus);
                writer.Write(c.LuckBonus);
                writer.Write(c.LimitLevel);
                writer.Write(c.CurrentLimitBar);
                writer.Write(new FFText(c.Name, CHARACTER_NAME_LENGTH).GetBytes());
                writer.Write(c.WeaponID);
                writer.Write(c.ArmorID);
                writer.Write(c.AccessoryID);
                writer.Write((byte)c.CharacterFlags);
                if (c.IsBackRow) { writer.Write((byte)0xFE); }
                else { writer.Write((byte)0xFF); }
                writer.Write(c.LevelProgressBar);
                writer.Write((ushort)c.LearnedLimits);
                writer.Write(c.KillCount);
                writer.Write(c.Limit1Uses);
                writer.Write(c.Limit2Uses);
                writer.Write(c.Limit3Uses);
                writer.Write(c.CurrentHP);
                writer.Write(c.BaseHP);
                writer.Write(c.CurrentMP);
                writer.Write(c.BaseMP);
                writer.Seek(4, SeekOrigin.Current); //unknown
                writer.Write(c.MaxHP);
                writer.Write(c.MaxMP);
                writer.Write(c.CurrentEXP);
                foreach (var m in c.WeaponMateria)
                {
                    writer.Write(GetMateriaBytes(m));
                }
                foreach (var m in c.ArmorMateria)
                {
                    writer.Write(GetMateriaBytes(m));
                }
                writer.Write(c.EXPtoNextLevel);
            }
            return data;
        }

        public static bool CharacterDataIsIdentical(Character c1, Character c2)
        {
            byte[] array1 = GetCharacterInitialDataBytes(c1),
                array2 = GetCharacterInitialDataBytes(c2);
            return array1.SequenceEqual(array2);
        }

        public static Attack ReadAttack(ushort index, string name, byte[] data)
        {
            var atk = new Attack();
            atk.Index = index;
            atk.Name = name;
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                atk.AccuracyRate = reader.ReadByte();
                atk.ImpactEffectID = reader.ReadByte();
                atk.TargetHurtActionIndex = reader.ReadByte();
                reader.ReadByte(); //unknown
                atk.MPCost = reader.ReadUInt16();
                atk.ImpactSound = reader.ReadUInt16();
                atk.CameraMovementIDSingle = reader.ReadUInt16();
                atk.CameraMovementIDMulti = reader.ReadUInt16();
                atk.TargetFlags = (TargetData)reader.ReadByte();
                atk.AttackEffectID = reader.ReadByte();
                atk.DamageCalculationID = reader.ReadByte();
                atk.AttackStrength = reader.ReadByte();
                atk.ConditionSubmenu = (ConditionSubmenu)reader.ReadByte();
                atk.StatusChange = new StatusChange(reader.ReadByte());
                atk.AditionalEffects = reader.ReadByte();
                atk.AdditionalEffectsModifier = reader.ReadByte();
                atk.Statuses = (Statuses)reader.ReadUInt32();
                atk.Elements = (Elements)reader.ReadUInt16();
                atk.SpecialAttackFlags = ~(SpecialEffects)reader.ReadUInt16();
            }
            return atk;
        }

        public static byte[] GetAttackBytes(Attack? atk)
        {
            var data = new byte[ATTACK_BLOCK_SIZE];
            if (atk == null)
            {
                data = HexParser.GetNullBlock(ATTACK_BLOCK_SIZE);
            }
            else
            {
                using (var ms = new MemoryStream(data))
                using (var writer = new BinaryWriter(ms))
                {
                    writer.Write(atk.AccuracyRate);
                    writer.Write(atk.ImpactEffectID);
                    writer.Write(atk.TargetHurtActionIndex);
                    writer.Write((byte)0xFF);
                    writer.Write(atk.MPCost);
                    writer.Write(atk.ImpactSound);
                    writer.Write(atk.CameraMovementIDSingle);
                    writer.Write(atk.CameraMovementIDMulti);
                    writer.Write((byte)atk.TargetFlags);
                    writer.Write(atk.AttackEffectID);
                    writer.Write(atk.DamageCalculationID);
                    writer.Write(atk.AttackStrength);
                    writer.Write((byte)atk.ConditionSubmenu);
                    writer.Write(GetStatusChangeValue(atk.StatusChange));
                    writer.Write(atk.AditionalEffects);
                    writer.Write(atk.AdditionalEffectsModifier);
                    if (atk.StatusChange.Type == StatusChangeType.None)
                    {
                        writer.Write(HexParser.NULL_OFFSET_32_BIT);
                    }
                    else
                    {
                        writer.Write((uint)atk.Statuses);
                    }
                    writer.Write((ushort)atk.Elements);
                    writer.Write((ushort)~atk.SpecialAttackFlags);
                }
            }
            return data;
        }

        public static byte GetStatusChangeValue(StatusChange status)
        {
            switch (status.Type)
            {
                case StatusChangeType.Cure:
                    return (byte)(status.Amount + 0x40);
                case StatusChangeType.Swap:
                    return (byte)(status.Amount + 0x80);
                case StatusChangeType.Inflict:
                    return (byte)status.Amount;
                default:
                    return 0xFF;
            }
        }

        public static string GetAttackNameString(Attack atk)
        {
            if (string.IsNullOrEmpty(atk.Name)) { return $"Unnamed ({atk.Index:X4})"; }
            else { return atk.Name; }
        }

        public static Attack CopyAttack(Attack atk)
        {
            return ReadAttack((ushort)atk.Index, atk.Name, GetAttackBytes(atk));
        }

        public static bool AttacksAreIdentical(Attack atk1, Attack atk2)
        {
            byte[] array1 = GetAttackBytes(atk1), array2 = GetAttackBytes(atk2);
            return array1.SequenceEqual(array2);
        }

        public static ushort GetCombinedItemIndex(ItemType type, byte index)
        {
            switch (type)
            {
                case ItemType.Item:
                    return index;
                case ItemType.Weapon:
                    return (ushort)(index + WEAPON_START);
                case ItemType.Armor:
                    return (ushort)(index + ARMOR_START);
                case ItemType.Accessory:
                    return (ushort)(index + ACCESSORY_START);
                case ItemType.Materia:
                    return (ushort)(index + MATERIA_START);
                default:
                    return HexParser.NULL_OFFSET_16_BIT;
            }
        }

        public static ushort GetCombinedItemIndex(Item item)
        {
            return GetCombinedItemIndex(ItemType.Item, (byte)item.Index);
        }

        public static ushort GetCombinedItemIndex(Weapon wpn)
        {
            return GetCombinedItemIndex(ItemType.Weapon, (byte)wpn.Index);
        }

        public static ushort GetCombinedItemIndex(Armor armor)
        {
            return GetCombinedItemIndex(ItemType.Armor, (byte)armor.Index);
        }

        public static ushort GetCombinedItemIndex(Accessory acc)
        {
            return GetCombinedItemIndex(ItemType.Accessory, (byte)acc.Index);
        }

        public static ushort GetCombinedItemIndex(Materia mat)
        {
            return GetCombinedItemIndex(ItemType.Materia, (byte)mat.Index);
        }

        public static ItemType GetItemType(ushort value)
        {
            if (value > MAX_INDEX)
            {
                return ItemType.None;
            }
            else if (value < WEAPON_START)
            {
                return ItemType.Item;
            }
            else if (value < ARMOR_START)
            {
                return ItemType.Weapon;
            }
            else if (value < ACCESSORY_START)
            {
                return ItemType.Armor;
            }
            else if (value < MATERIA_START)
            {
                return ItemType.Accessory;
            }
            else
            {
                return ItemType.Materia;
            }
        }

        public static byte GetItemIndex(ushort value)
        {
            return GetItemIndex(GetItemType(value), value);
        }

        public static byte GetItemIndex(ItemType type, ushort value)
        {
            switch (type)
            {
                case ItemType.Item:
                    return (byte)value;
                case ItemType.Weapon:
                    return (byte)(value - WEAPON_START);
                case ItemType.Armor:
                    return (byte)(value - ARMOR_START);
                case ItemType.Accessory:
                    return (byte)(value - ACCESSORY_START);
                case ItemType.Materia:
                    return (byte)(value - MATERIA_START);
                default:
                    return 0xFF;
            }
        }

        public static ushort GetItemValue(InventoryItem item)
        {
            var indexBytes = BitConverter.GetBytes(item.Item);
            var amountBytes = new byte[1] { (byte)item.Amount };
            var indexBits = new BitArray(indexBytes);
            var amountBits = new BitArray(amountBytes);

            var combinedBits = new bool[16];
            int i;
            for (i = 0; i < 9; ++i)
            {
                combinedBits[i] = indexBits[i];
            }
            for (i = 0; i < 7; ++i)
            {
                combinedBits[i + 9] = amountBits[i];
            }

            var converter = new BitArray(combinedBits);
            var combinedBytes = new byte[2];
            converter.CopyTo(combinedBytes, 0);

            return BitConverter.ToUInt16(combinedBytes);
        }

        public static void SetItem(InventoryItem item, ItemType type, byte index)
        {
            item.Item = GetCombinedItemIndex(type, index);
        }

        public static void SetItem(InventoryItem item, Materia mat)
        {
            item.Item = GetCombinedItemIndex(ItemType.Materia, (byte)mat.Index);
        }

        public static byte[] GetMateriaBytes(InventoryMateria? mat)
        {
            if (mat == null) { return HexParser.GetNullBlock(4); }
            else
            {
                var data = new byte[4];
                data[0] = mat.Index;
                Array.Copy(BitConverter.GetBytes(mat.CurrentAP), 0, data, 1, 3);
                return data;
            }
        }

        public static InventoryMateria CopyMateria(InventoryMateria mat)
        {
            var newMat = new InventoryMateria();
            newMat.ParseData(GetMateriaBytes(mat));
            return newMat;
        }
    }
}
