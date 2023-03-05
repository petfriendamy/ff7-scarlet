using System.Globalization;
using FF7Scarlet.AIEditor;
using FF7Scarlet.KernelEditor;

namespace FF7Scarlet
{
    public class FFText : IComparable
    {
        private const string TEXT_MAP = "ÄÁÇÉÑÖÜáàâäãåçéèêëíìîïñóòôöõúùûü⌘°¢£ÙÛ¶ß®©™´¨≠ÆØ∞±≤≥¥µ∂ΣΠπ⌡ªºΩæø¿¡¬√ƒ≈∆«»…?ÀÃÕŒœ–—“”‘’÷◊ÿŸ⁄¤‹›ﬁﬂ■▪‚„‰ÂÊËÁÈíîïìÓÔ ÒÙÛ";
        private const byte MAP_OFFSET = 0x60, CHAR_OFFSET = 0x20;

        private readonly byte[] data;

        public int Length
        {
            get { return data.Length; }
        }

        public FFText(byte[] data)
        {
            this.data = data;
        }

        public FFText(string? str = null, int length = -1)
        {
            int i, j;
            if (str == null) //string is null
            {
                if (length == -1) { data = new byte[0]; }
                else
                {
                    data = new byte[length];
                    for (i = 0; i < length; ++i)
                    {
                        data[i] = 0xFF;
                    }
                }
            }
            else //get string
            {
                if (length == -1)
                {
                    length = str.Length;
                }

                var text = new List<byte> { };
                var nameList = Enum.GetNames<CharacterNames>();
                for (i = 0; i < length; ++i)
                {
                    if (i < str.Length)
                    {
                        byte b = (byte)str[i];

                        if (b == (byte)'{') //check for names
                        {
                            string temp = str.Substring(i);
                            for (j = 0; j < nameList.Length; ++j)
                            {
                                if (temp.StartsWith(nameList[j].ToUpper()))
                                {
                                    text.Add(0xEA);
                                    text.Add(0x00);
                                    text.Add((byte)j);
                                    i += nameList[j].Length + 1;
                                    continue;
                                }
                            }

                            //no matching name found, so assume regular character
                            text.Add((byte)'{' - CHAR_OFFSET);
                        }
                        else if (b < MAP_OFFSET + CHAR_OFFSET)
                        {
                            text.Add((byte)(b - CHAR_OFFSET));
                        }
                        else
                        {
                            int pos = TEXT_MAP.IndexOf(str[i]);
                            if (pos >= 0)
                            {
                                text.Add((byte)(pos + MAP_OFFSET));
                            }
                        }
                    }
                    else
                    {
                        text.Add(0xFF);
                    }
                }
                data = text.ToArray();
            }
        }

        public FFText(object? value) : this(value?.ToString()) { }

        public bool IsEmpty()
        {
            return (ToString() == null);
        }

        public override string? ToString()
        {
            if (data == null)
            {
                return null;
            }
            else if (data.Length > 0)
            {
                var text = new List<char> { };
                for (int i = 0; i < data.Length; ++i)
                {
                    if (data[i] == 0xFF) //end of string
                    {
                        break;
                    }
                    else if (data[i] < MAP_OFFSET) //letters
                    {
                        text.Add((char)(data[i] + CHAR_OFFSET));
                    }
                    else if (data[i] == 0xEA) //character names
                    {
                        int charID = data[i + 2];
                        i += 2;
                        var name = Enum.GetName((CharacterNames)charID);
                        if (name == null) { text.AddRange("{UNKNOWN}"); }
                        else { text.AddRange("{" + name.ToUpper() + "}"); }
                    }
                    else if ((data[i] - MAP_OFFSET + 1) < TEXT_MAP.Length)
                    {
                        text.Add(TEXT_MAP[data[i] - MAP_OFFSET + 1]);
                    }
                    else
                    {
                        text.Add('?');
                    }
                }
                if (text.Count == 0)
                {
                    return null;
                }
                return new string(text.ToArray()).Trim();
            }
            return null;
        }

        public int ToInt()
        {
            int value;
            var provider = new CultureInfo("en-US");
            if (int.TryParse(ToString(), NumberStyles.HexNumber, provider, out value))
            {
                return value;
            }
            return -1;
        }

        public byte[] GetBytes(ParameterTypes type = ParameterTypes.String)
        {
            var singleByte = new byte[1];
            var threeByteInt = new byte[3];
            switch (type)
            {
                case ParameterTypes.OneByte:
                    singleByte[0] = (byte)ToInt();
                    return singleByte;
                case ParameterTypes.TwoByte:
                    return BitConverter.GetBytes((ushort)ToInt());
                case ParameterTypes.ThreeByte:
                    Array.Copy(BitConverter.GetBytes(ToInt()), threeByteInt, 3);
                    return threeByteInt;
                default:
                    return data;
            }
        }

        public byte[] GetBytes(int length)
        {
            var bytes = new byte[length];
            int dataLength = Math.Min(length, data.Length);
            Array.Copy(data, bytes, dataLength);
            for (int i = dataLength; i < length - 1; ++i)
            {
                bytes[i] = 0xFF;
            }
            bytes[length - 1] = 0xFF; //last byte must always be null terminator
            return bytes;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                if (ToString() == null) { return 0; }
                else { throw new ArgumentNullException(); }
            }
            if (obj is FFText)
            {
                var text = obj as FFText;
                if (text == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    return CompareTo(text);
                }
            }
            else if (obj is string)
            {
                var str = ToString();
                if (str == null) { throw new ArgumentNullException(); }
                return str.CompareTo(obj);
            }
            else if (obj is int)
            {
                return CompareTo((int)obj);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int CompareTo(FFText other)
        {
            var str = ToString();
            if (str == null) { throw new ArgumentNullException(); }
            return str.CompareTo(other.ToString());
        }
    }
}
