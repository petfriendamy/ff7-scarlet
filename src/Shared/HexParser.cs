using FF7Scarlet.AIEditor;
using Shojy.FF7.Elena.Text;
using System.Globalization;
using System.Text;

namespace FF7Scarlet.Shared
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

            return (byte)(upper * 0x10 + lower);
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

        public static byte[] ParameterTextToBytes(ParameterTypes type, string text, bool jpText)
        {
            if (type == ParameterTypes.None) { return []; }
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("Parameter cannot be empty.");
            }

            if (type == ParameterTypes.Label)
            {
                if (int.TryParse(text, out int temp))
                    return BitConverter.GetBytes(temp);
                throw new FormatException("Invalid label.");
            }
            else if (type == ParameterTypes.String)
            {
                return new FFText(text, isJapanese: jpText).GetBytesTruncated();
            }
            else if (type == ParameterTypes.Debug)
            {
                return Encoding.ASCII.GetBytes(text);
            }
            else
            {
                //convert variable names back into numbers
                List<string> globals = Enum.GetNames<CommonVars.Globals>().ToList(),
                    actorGlobals = Enum.GetNames<CommonVars.ActorGlobals>().ToList();

                if (globals.Contains(text))
                {
                    int i = globals.IndexOf(text);
                    var g = Enum.GetValues<CommonVars.Globals>()[i];
                    return BitConverter.GetBytes((ushort)g);
                }
                else if (actorGlobals.Contains(text))
                {
                    int i = actorGlobals.IndexOf(text);
                    var g = Enum.GetValues<CommonVars.ActorGlobals>()[i];
                    return BitConverter.GetBytes((ushort)g);
                }
                else //otherwise, just pass the number back
                {
                    switch (type)
                    {
                        case ParameterTypes.OneByte:
                            if (byte.TryParse(text, NumberStyles.HexNumber, CultureInfo, out byte b))
                                return [b];
                            break;

                        case ParameterTypes.TwoByte:
                            if (ushort.TryParse(text, NumberStyles.HexNumber, CultureInfo, out ushort u))
                                return BitConverter.GetBytes(u);
                            break;
                        case ParameterTypes.ThreeByte:
                            var bytes = new byte[3];
                            if (int.TryParse(text, NumberStyles.HexNumber, CultureInfo, out int i))
                            {
                                Array.Copy(BitConverter.GetBytes(i), bytes, 3);
                                return bytes;
                            }
                            break;
                    }
                }
            }
            throw new ArgumentException("Invalid parameter.");
        }

        public static string HexNumberToText(byte[] bytes)
        {
            var b = BitConverter.ToString(bytes).Split('-');

            var str = new StringBuilder();
            foreach(var bb in b.Reverse())
            {
                str.Append(bb.ToString());
            }
            return str.ToString();
        }
    }
}
