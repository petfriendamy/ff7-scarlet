using Shojy.FF7.Elena.Equipment;

namespace FF7Scarlet.KernelEditor
{
    public struct StatIncrease
    {
        public CharacterStat Stat { get; set; }
        public byte Amount { get; set; }

        public StatIncrease(CharacterStat stat, byte amount)
        {
            Stat = stat;
            Amount = amount;
        }
    }
}
