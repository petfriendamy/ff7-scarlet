using Shojy.FF7.Elena.Attacks;

namespace FF7Scarlet
{
    public interface IAttackContainer
    {
        public Attack? GetAttackByID(ushort id);
        public string GetAttackName(ushort id);
    }
}
