using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public static class HexParser
    {
        public const ushort NULL_OFFSET_16_BIT = 0xFFFF;
        public const short NULL_OFFSET_16_BIT_SIGNED = -1;
        public const uint NULL_OFFSET_32_BIT = 0xFFFFFFFF;
        public static CultureInfo CultureInfo { get; } = new CultureInfo("en-US");

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

        public static byte[] GetNullBlock(int size)
        {
            var data = new byte[size];
            for (int i = 0; i < size; ++i)
            {
                data[i] = 0xFF;
            }
            return data;
        }
    }
}
