using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Items;

namespace Shojy.FF7.Elena.Equipment
{
    public class Weapon
    {
        #region Public Constructors

        public Weapon()
        {
            this.MateriaSlots = new MateriaSlot[8];
        }

        #endregion Public Constructors

        #region Public Properties

        public byte AccuracyRate { get; set; }
        public Elements AttackElements { get; set; }
        public byte AttackStrength { get; set; }
        public byte CriticalRate { get; set; }
        public byte DamageCalculationId { get; set; }
        public string Description { get; set; }
        public EquipableBy EquipableBy { get; set; }
        public GrowthRate GrowthRate { get; set; }
        public int Index { get; set; }
        public MateriaSlot[] MateriaSlots { get; set; }
        public string Name { get; set; }
        public Restrictions Restrictions { get; set; }
        public EquipmentStatus Status { get; set; }
        public TargetData Targets { get; set; }
        public byte WeaponModelId { get; set; }

        #endregion Public Properties
    }
}