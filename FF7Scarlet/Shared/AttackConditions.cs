using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.Shared
{
    public enum AttackConditions : byte
    {
        HP = 0x00,
        MP = 0x01,
        Status = 0x02,
        None = 0xFF
    }
}
