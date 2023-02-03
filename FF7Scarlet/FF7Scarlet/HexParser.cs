using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public static class HexParser
    {
        public static byte GetUpperNybble(byte value)
        {
            return (byte)Math.Floor((double)(value / 0x10));
        }

        public static byte GetLowerNybble(byte value)
        {
            return (byte)(value % 0x10);
        }

        public static byte MergeNybbles(byte upper, byte lower)
        {
            if (upper > 0xF) { throw new ArgumentException("Upper nybble too large to merge."); }
            if (lower > 0xF) { throw new ArgumentException("Lower nybble too large to merge."); }

            return (byte)((upper * 0x10) + lower);
        }
    }
}
