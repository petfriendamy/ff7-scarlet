using System.Dynamic;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Items;

namespace Shojy.FF7.Elena.Equipment
{
    public class Armor
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DamageModifier ElementDamageModifier { get; set; }
        public byte Defense { get; set; }
        public byte MagicDefense { get; set; }
        public byte Evade { get; set; }
        public byte MagicEvade { get; set; }
        public EquipmentStatus Status { get; set; }
        public MateriaSlot[] MateriaSlots { get; set; }
        public GrowthRate GrowthRate { get; set; }
        public EquipableBy EquipableBy { get; set; }
        public Elements ElementalDefense { get; set; }

        public CharacterStat BoostedStat1 { get; set; }
        public byte BoostedStat1Bonus { get; set; }
        public CharacterStat BoostedStat2 { get; set; }
        public byte BoostedStat2Bonus { get; set; }
        public CharacterStat BoostedStat3 { get; set; }
        public byte BoostedStat3Bonus { get; set; }
        public CharacterStat BoostedStat4 { get; set; }
        public byte BoostedStat4Bonus { get; set; }
        public Restrictions Restrictions { get; set; }

        public Armor()
        {
            this.MateriaSlots = new MateriaSlot[8];
        }
    }
}