using System;

namespace Shojy.FF7.Elena.Equipment
{

    [Flags]
    public enum EquipableBy : ushort
    {
        Cloud = 0x0001,
        Barret = 0x0002,
        Tifa = 0x0004,
        Aeris = 0x0008,
        RedXIII = 0x0010,
        Yuffie = 0x0020,
        CaitSith = 0x0040,
        Vincent = 0x0080,
        Cid = 0x0100,
        YoungCloud = 0x0200,
        Sephiroth = 0x0400
    }
}