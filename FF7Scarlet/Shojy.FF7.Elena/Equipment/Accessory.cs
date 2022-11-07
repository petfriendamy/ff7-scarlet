using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Items;

namespace Shojy.FF7.Elena.Equipment
{
    public class Accessory
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CharacterStat BoostedStat1 { get; set; }
        public CharacterStat BoostedStat2 { get; set; }
        public byte BoostedStat1Bonus { get; set; }
        public byte BoostedStat2Bonus { get; set; }
        public DamageModifier ElementalDamageModifier { get; set; }
        public AccessoryEffect SpecialEffect { get; set; }
        public Elements ElementalDefense { get; set; }
        public EquipmentStatus StatusDefense { get; set; }
        public EquipableBy EquipableBy { get; set; }
        public Restrictions Restrictions { get; set; }
    }
}