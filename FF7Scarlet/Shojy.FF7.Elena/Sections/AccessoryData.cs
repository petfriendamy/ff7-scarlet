using Shojy.FF7.Elena.Equipment;
using System;
using System.Collections.Generic;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Items;

namespace Shojy.FF7.Elena.Sections
{
    public class AccessoryData
    {
        #region Private Fields
        /// <summary>
        /// Size of the accessory data block in bytes
        /// </summary>
        private const int AccessorySize = 16;
        private byte[] _sectionData;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Creates a new instance of the accessory data section
        /// </summary>
        /// <param name="sectionData"></param>
        /// <param name="names"></param>
        /// <param name="descriptions"></param>
        public AccessoryData(byte[] sectionData, IReadOnlyList<string> names, IReadOnlyList<string> descriptions)
        {
            this._sectionData = sectionData;

            var count = sectionData.Length / AccessorySize;
            var accessories = new Accessory[count];

            for (var acc = 0; acc < count; ++acc)
            {
                var bytes = new byte[AccessorySize];
                Array.Copy(
                    sectionData,
                    acc * AccessorySize,
                    bytes,
                    0,
                    AccessorySize);
                accessories[acc] = ParseData(bytes);

                accessories[acc].Index = acc;
                accessories[acc].Name = names[acc];
                accessories[acc].Description = descriptions[acc];
            }

            this.Accessories = accessories;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// A list of all loaded accessories found in the kernel file.
        /// </summary>
        public Accessory[] Accessories { get; set; }

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Creates an accessory object from an individual data block
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static Accessory ParseData(byte[] data)
        {
            var acc = new Accessory
            {
                BoostedStat1 = (CharacterStat) data[0x0],
                BoostedStat2 = (CharacterStat) data[0x1],
                BoostedStat1Bonus = data[0x2],
                BoostedStat2Bonus = data[0x3],
                ElementalDamageModifier = (DamageModifier) data[0x4],
                SpecialEffect = (AccessoryEffect) data[0x5],
                ElementalDefense = (Elements) BitConverter.ToUInt16(data, 0x6),
                StatusDefense = (EquipmentStatus) BitConverter.ToUInt32(data, 0x8),
                EquipableBy = (EquipableBy) BitConverter.ToUInt16(data, 0xC),
                Restrictions = (Restrictions) ~BitConverter.ToUInt16(data, 0xE)
            };


            return acc;
        }

        #endregion Private Methods
    }
}