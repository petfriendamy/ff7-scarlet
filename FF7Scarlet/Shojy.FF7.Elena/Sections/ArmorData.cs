using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Items;
using System;
using System.Collections.Generic;

namespace Shojy.FF7.Elena.Sections
{
    public class ArmorData
    {
        #region Private Fields

        private const int ArmorSize = 36;
        private byte[] _sectionData;

        #endregion Private Fields

        #region Public Constructors

        public ArmorData(byte[] sectionData, IReadOnlyList<string> names, IReadOnlyList<string> descriptions)
        {
            this._sectionData = sectionData;

            var count = sectionData.Length / ArmorSize;
            var armors = new Armor[count];

            for (var arm = 0; arm < count; ++arm)
            {
                var armBytes = new byte[ArmorSize];
                Array.Copy(
                    sectionData,
                    arm * ArmorSize,
                    armBytes,
                    0,
                    ArmorSize);
                armors[arm] = ParseArmorData(armBytes);

                armors[arm].Index = arm;
                armors[arm].Name = names[arm];
                armors[arm].Description = descriptions[arm];
            }
            this.Armors = armors;
        }

        #endregion Public Constructors

        #region Public Properties

        public Armor[] Armors { get; set; }

        #endregion Public Properties

        #region Private Methods

        private static Armor ParseArmorData(byte[] data)
        {
            var armor = new Armor();

            armor.ElementDamageModifier = (DamageModifier)data[0x1];
            armor.Defense = data[0x2];
            armor.MagicDefense = data[0x3];
            armor.Evade = data[0x4];
            armor.MagicEvade = data[0x5];
            armor.Status = (EquipmentStatus)data[0x6];

            for (var slot = 0; slot < 8; ++slot)
            {
                armor.MateriaSlots[slot] = (MateriaSlot)data[0x09 + slot];
            }

            armor.GrowthRate = (GrowthRate)data[0x11];
            armor.EquipableBy = (EquipableBy)BitConverter.ToUInt16(data, 0x12);
            armor.ElementalDefense = (Elements)BitConverter.ToUInt16(data, 0x14);
            armor.BoostedStat1 = (CharacterStat)data[0x18];
            armor.BoostedStat2 = (CharacterStat)data[0x19];
            armor.BoostedStat3 = (CharacterStat)data[0x1A];
            armor.BoostedStat4 = (CharacterStat)data[0x1B];
            armor.BoostedStat1Bonus = data[0x1C];
            armor.BoostedStat2Bonus = data[0x1D];
            armor.BoostedStat3Bonus = data[0x1E];
            armor.BoostedStat4Bonus = data[0x1F];

            armor.Restrictions = (Restrictions) ~BitConverter.ToUInt16(data, 0x20);

            return armor;
        }

        #endregion Private Methods
    }
}