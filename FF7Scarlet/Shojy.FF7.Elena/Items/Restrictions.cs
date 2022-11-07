using System;

namespace Shojy.FF7.Elena.Items
{
    [Flags]
    public enum Restrictions : ushort
    {
        CanBeSold = 1,
        CanBeUsedInBattle = 2,
        CanBeUsedInMenu = 4
    }
}