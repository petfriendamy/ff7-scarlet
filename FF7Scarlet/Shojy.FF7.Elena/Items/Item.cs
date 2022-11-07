using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;

namespace Shojy.FF7.Elena.Items
{
    public class Item
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Restrictions Restrictions { get; set; }
        public ushort CameraMovementId { get; set; }
        public TargetData TargetData { get; set; }
        public byte AttackEffectId { get; set; }
        public byte DamageCalculationId { get; set; }
        public byte AttackPower { get; set; }
        public Statuses Status { get; set; }
        public Elements Element { get; set; }
        public SpecialEffects Special { get; set; }
    }
}