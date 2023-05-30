using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.Shared
{
    [Flags]
    public enum EnemySkills
    {
        FrogSong = 0x01,
        L4Suicide = 0x02,
        MagicHammer = 0x04,
        WhiteWind = 0x08,
        BigGuard = 0x10,
        AngelWhisper = 0x20,
        DragonForce = 0x040,
        DeathForce = 0x80,
        FlameThrower = 0x100,
        Laser = 0x200,
        MatraMagic = 0x400,
        BadBreath = 0x800,
        Beta = 0x1000,
        Aqualung = 0x2000,
        Trine = 0x4000,
        MagicBreath = 0x8000,
        QuestionMarks = 0x10000,
        GoblinPunch = 0x20000,
        Chocobuckle = 0x40000,
        L5Death = 0x80000,
        DeathSentence = 0x100000,
        Roulette = 0x200000,
        ShadowFlare = 0x400000,
        PandorasBox = 0x800000
    }
}
