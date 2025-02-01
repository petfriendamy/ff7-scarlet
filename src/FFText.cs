using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using FF7Scarlet.AIEditor;
using FF7Scarlet.Shared;

namespace FF7Scarlet
{
    public class FFText : IComparable
    {
        private ReadOnlyCollection<char> TEXT_MAP = list.AsReadOnly();


        private readonly byte[] data;

        public int Length
        {
            get { return data.Length; }
        }

        private static readonly char[] list = [
            ' ', '!', '\"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?',
            '@', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
            'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[', '\\', ']', '^', '_',
            '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
            'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '?', '}', '~', '?',
            'Ä', 'Á', 'Ç', 'É', 'Ñ', 'Ö', 'Ü', 'á', 'à', 'â', 'ä', 'ã', 'å', 'ç', 'é', 'è',
            'ê', 'ë', 'í', 'ì', 'î', 'ï', 'ñ', 'ó', 'ò', 'ô', 'ö', 'õ', 'ú', 'ù', 'û', 'ü',
            '⌘', '°', '¢', '£', 'Ù', 'Û', '¶', 'ß', '®', '©', '™', '´', '¨', '≠', 'Æ', 'Ø',
            '∞', '±', '≤', '≥', '¥', 'µ', '∂', 'Σ', 'Π', 'π', '⌡', 'ª', 'º', 'Ω', 'æ', 'ø',
            '¿', '¡', '¬', '√', 'ƒ', '≈', '∆', '«', '»', '…', '?', 'À', 'Ã', 'Õ', 'Œ', 'œ',
            '–', '—', '“', '”', '‘', '’', '÷', '◊', 'ÿ', 'Ÿ', '⁄', '¤', '‹', '›', 'ﬁ', 'ﬂ',
            '■', '▪', '‚', '„', '‰', 'Â', 'Ê', 'Ë', 'Á', 'È', 'Í', 'Î', 'Ï', 'Ì', 'Ó', 'Ô',
            ' ', 'Ò', 'Ù', 'Û'
        ];

        public FFText(byte[] data)
        {
            this.data = data;
        }

        public FFText(byte[] data, int length)
        {
            if (length < 1)
            {
                this.data = data;
            }
            else
            {
                this.data = new byte[length];
                Array.Copy(data, this.data, Math.Min(length, data.Length));
            }
        }

        public FFText(string? str = null, int length = -1)
        {
            int i, j;
            if (str == null) //string is null
            {
                if (length == -1) { data = [0xFF]; }
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
                    length = str.Length + 1;
                }

                var text = new List<byte> { };
                var nameList = Enum.GetNames<CharacterNames>();
                for (i = 0; i < length; ++i)
                {
                    if (i < str.Length)
                    {
                        byte b = (byte)str[i];

                        if (b == (byte)'{') //variable
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
                            text.Add((byte)TEXT_MAP.IndexOf('{'));
                        }
                        else //search text map
                        {
                            int pos = TEXT_MAP.IndexOf(str[i]);
                            if (pos >= 0)
                            {
                                text.Add((byte)pos);
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
            return (ToString() == string.Empty);
        }

        public override string ToString()
        {
            if (data == null)
            {
                return string.Empty;
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
                    else if (data[i] == 0xF8) //function, ignore this
                    {
                        i++;
                    }
                    else if (data[i] == 0xEA) //names
                    {
                        int charID = data[i + 2];
                        i += 2;
                        var name = Enum.GetName((CharacterNames)charID);
                        if (name == null) { text.AddRange("{UNKNOWN}"); }
                        else { text.AddRange("{" + name.ToUpper() + "}"); }
                    }
                    else if (data[i] == 0xEB) //item
                    {
                        text.AddRange("{ITEM}");
                        i++;
                    }
                    else if (data[i] == 0xEC) //number
                    {
                        text.AddRange("{NUMBER}");
                        i++;
                    }
                    else if (data[i] == 0xED) //target
                    {
                        text.AddRange("{TARGET}");
                        i++;
                    }
                    else if (data[i] == 0xEF) //attack
                    {
                        text.AddRange("{ATTACK}");
                        i++;
                    }
                    else if (data[i] < TEXT_MAP.Count) //regular text
                    {
                        text.Add(TEXT_MAP[data[i]]);
                    }
                    else
                    {
                        text.Add('?');
                    }
                }
                if (text.Count == 0)
                {
                    return string.Empty;
                }
                return new string(text.ToArray()).Trim();
            }
            return string.Empty;
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
                case ParameterTypes.ReadWrite:
                    singleByte[0] = (byte)ToInt();
                    return singleByte;
                case ParameterTypes.TwoByte:
                    return BitConverter.GetBytes((ushort)ToInt());
                case ParameterTypes.ThreeByte:
                    Array.Copy(BitConverter.GetBytes(ToInt()), threeByteInt, 3);
                    return threeByteInt;
                case ParameterTypes.Debug:
                    var temp = ToString();
                    if (temp == string.Empty) { return Array.Empty<byte>(); }
                    return Encoding.ASCII.GetBytes(temp);
                default:
                    var copy = new byte[data.Length];
                    Array.Copy(data, copy, data.Length);
                    return copy;
            }
        }

        public byte[] GetBytes(int length, bool terminatedWithZero = false, bool padWithZero = false)
        {
            var bytes = new byte[length];
            if (!terminatedWithZero && !padWithZero) //pad with null terminators
            {
                for (int i = 0; i < length; ++i)
                {
                    bytes[i] = 0xFF;
                }
            }
            var temp = GetBytesTruncated();
            int maxLength = Math.Min(length - 1, temp.Length - 1);
            Array.Copy(temp, bytes, maxLength);
            if (!terminatedWithZero)
            {
                bytes[maxLength] = 0xFF;
            }
            return bytes;
        }

        public byte[] GetBytesTruncated()
        {
            var str = ToString();
            var copy = new FFText(str);
            return copy.GetBytes();
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
            return str.CompareTo(other.ToString());
        }

        public static FFText GetTextFromByteArray(byte[] data, int pos, int length = -1)
        {
            var bytes = new List<byte>();
            using (var stream = new MemoryStream(data))
            using (var reader = new BinaryReader(stream))
            {
                stream.Seek(pos, SeekOrigin.Begin);
                byte b;
                do
                {
                    b = reader.ReadByte();
                    bytes.Add(b);
                } while (b != 0xFF);
            }
            return new FFText(bytes.ToArray(), length);
        }
    }
}
