using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Items;
using System;
using System.Collections.Generic;

namespace Shojy.FF7.Elena.Sections
{
    public class WeaponData
    {
        #region Private Fields

        private const int WeaponSize = 44;
        private readonly byte[] _sectionData;

        #endregion Private Fields

        #region Public Constructors

        public WeaponData(byte[] sectionData, IReadOnlyList<string> names, IReadOnlyList<string> descriptions)
        {
            this._sectionData = sectionData;

            var count = sectionData.Length / WeaponSize;
            var weapons = new Weapon[count];

            for (var wpn = 0; wpn < count; ++wpn)
            {
                var wpnBytes = new byte[WeaponSize];
                Array.Copy(
                    sectionData,
                    wpn * WeaponSize,
                    wpnBytes,
                    0,
                    WeaponSize);
                weapons[wpn] = this.ParseWeaponData(wpnBytes);

                weapons[wpn].Index = wpn;
                weapons[wpn].Name = names[wpn];
                weapons[wpn].Description = descriptions[wpn];
            }
            this.Weapons = weapons;
        }

        #endregion Public Constructors

        #region Public Properties

        public Weapon[] Weapons { get; }

        #endregion Public Properties

        #region Private Methods

        private Weapon ParseWeaponData(byte[] wpnData)
        {
            var wpn = new Weapon();
            wpn.Targets = (TargetData)wpnData[0x0];
            wpn.DamageCalculationId = wpnData[0x2];
            wpn.AttackStrength = wpnData[0x4];
            wpn.Status = (EquipmentStatus)wpnData[0x5];
            wpn.GrowthRate = (GrowthRate)wpnData[0x6];
            wpn.CriticalRate = wpnData[0x7];
            wpn.AccuracyRate = wpnData[0x8];
            wpn.WeaponModelId = wpnData[0x9];
            wpn.EquipableBy = (EquipableBy)BitConverter.ToUInt16(wpnData, 0xE);
            wpn.AttackElements = (Elements)BitConverter.ToUInt16(wpnData, 0x10);

            for (var slot = 0; slot < 8; ++slot)
            {
                wpn.MateriaSlots[slot] = (MateriaSlot)wpnData[0x1C + slot];
            }

            wpn.Restrictions = (Restrictions) ~BitConverter.ToUInt16(wpnData, 0x2A);
            return wpn;
        }

        #endregion Private Methods
    }
}