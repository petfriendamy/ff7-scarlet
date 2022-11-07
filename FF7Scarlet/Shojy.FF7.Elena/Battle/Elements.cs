using System;

namespace Shojy.FF7.Elena.Battle
{
    [Flags]
    public enum Elements
    {
        Fire = 0x0001,
        Ice = 0x0002,
        Bolt = 0x0004,
        Earth = 0x0008,
        Poison = 0x0010,
        Gravity = 0x0020,
        Water = 0x0040,
        Wind = 0x0080,
        Holy = 0x0100,
        Restorative = 0x0200,
        Cut = 0x0400,
        Hit = 0x0800,
        Punch = 0x1000,
        Shoot = 0x2000,
        Shout = 0x4000,
        Hidden = 0x8000,
    }

    public enum MateriaElements
    {
        Fire = 0x00,
        Ice = 0x01,
        Bolt = 0x02,
        Earth = 0x03,
        Poison = 0x04,
        Gravity = 0x05,
        Water = 0x06,
        Wind = 0x07,
        Holy = 0x08,
        Restorative = 0x09,
        Cut = 0x0A,
        Hit = 0x0B,
        Punch = 0x0C,
        Shoot = 0x0D,
        Shout = 0x0E,
        Hidden = 0x0F,
    }
}