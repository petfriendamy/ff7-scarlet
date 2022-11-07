using System;

namespace Shojy.FF7.Elena.Compression
{
    /*
     * The methods in this file are based on fantastic work by NFITC1 for Wall Market,
     * and has been ported to run in C#. 
     */
    public class LzsCompression
    {

        public static byte[] UnLzs(ref byte[] compressedFileData)
        {
            var compressedData = new byte[18];
            uint position = 4;
            var unCompressedFileData = new byte[checked(compressedFileData.Length * 9 + 1)];
            uint uncompressedPosition = 0;
            while (position < compressedFileData.Length)
            {
                byte num1 = 0;
                byte num2 = 0;
                do
                {
                    if ((compressedFileData[checked((int)position)] & 1U << num2) > 0U)
                        checked { ++num1; }
                    else
                        checked { num1 += 2; }
                    checked { ++num2; }
                }
                while (num2 <= 7);
                if (compressedFileData.Length < checked(position + num1))
                    num1 = checked((byte)(compressedFileData.Length - position - 1L));
                compressedData = new byte[checked(num1 + 1)];
                var num3 = checked((byte)Math.Min(num1, compressedFileData.Length - position - 1L));
                byte num4 = 0;
                while (num4 <= (uint)num3)
                {
                    compressedData[num4] = compressedFileData[checked((int)(position + num4))];
                    checked { ++num4; }
                }
                DecodeLzsBlock(ref compressedData, ref unCompressedFileData, ref position, ref uncompressedPosition);

            }
            byte num5 = 1;
            byte num6 = 0;
            do
            {
                if ((compressedData[0] & 1U << num6) > 0U)
                    checked { ++num5; }
                else
                    checked { num5 += 2; }
                checked { ++num6; }
            }
            while (num6 <= 7);
            if (num5 == compressedData.Length)
                uncompressedPosition = checked((uint)(uncompressedPosition - 1L));
            var temp = new byte[checked((int) uncompressedPosition + 1)];
            Array.Copy(
                unCompressedFileData, 
                temp, 
                uncompressedPosition
                );
            unCompressedFileData = temp;

            return unCompressedFileData;
        }

        private static void DecodeLzsBlock(
          ref byte[] compressedData,
          ref byte[] unCompressedFileData,
          ref uint position,
          ref uint uncompressedPosition)
        {
            var num1 = compressedData[0];
            uint num2 = 1;
            byte num3 = 0;
            while (num2 != compressedData.Length)
            {
                if ((num1 & 1U << num3) > 0U)
                {
                    unCompressedFileData[checked((int)uncompressedPosition)] = compressedData[checked((int)num2)];
                    num2 = checked((uint)(num2 + 1L));
                    uncompressedPosition = checked((uint)(uncompressedPosition + 1L));
                }
                else
                {
                    var num4 = checked((int)(uncompressedPosition - (uncompressedPosition - 18L - (compressedData[(int)num2] + 256 * unchecked((byte)((uint)compressedData[checked((int)(num2 + 1L))] >> 4))) & 4095L)));
                    var num5 = checked((short)((short)(3 + (compressedData[(int)(num2 + 1L)] & 15)) - 1));
                    short num6 = 0;
                    while (num6 <= num5)
                    {
                        unCompressedFileData[checked((int)uncompressedPosition)] = checked(num4 + (int)num6) >= 0 ? unCompressedFileData[checked(num4 + num6)] : (byte)0;
                        uncompressedPosition = checked((uint)(uncompressedPosition + 1L));
                        checked { ++num6; }
                    }
                    num2 = checked((uint)(num2 + 2L));
                }
                checked { ++num3; }
                if (num3 > 7)
                {
                    checked { position += num2; }
                    return;
                }
            }
            uncompressedPosition = checked((uint)(uncompressedPosition - 1L));
            checked { position += num2; }
        }

    }
}