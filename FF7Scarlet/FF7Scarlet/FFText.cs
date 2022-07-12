using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public class FFText : IComparable
    {
        private const string TEXT_MAP = "ÄÁÇÉÑÖÜáàâäãåçéèêëíìîïñóòôöõúùûü⌘°¢£ÙÛ¶ß®©™´¨≠ÆØ∞±≤≥¥µ∂ΣΠπ⌡ªºΩæø¿¡¬√ƒ≈∆«»…?ÀÃÕŒœ–—“”‘’÷◊ÿŸ⁄¤‹›ﬁﬂ■▪‚„‰ÂÊËÁÈíîïìÓÔ ÒÙÛ";
        private const byte MAP_OFFSET = 0x60, CHAR_OFFSET = 0x20;

        private enum CharacterNames
        {
            Cloud, Barret, Tifa, Aerith, RedXIII, Yuffie, CaitSith, Vincent, Cid
        }

        private readonly byte[] data;

        public FFText(byte[] data)
        {
            this.data = data;
        }

        public FFText(string str, int length = -1)
        {
            int i, j;
            if (length == -1)
            {
                length = str.Length;
            }

            var text = new List<byte> { };
            var nameList = Enum.GetNames(typeof(CharacterNames));
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

        public FFText(object value) : this(value.ToString()) { }

        public bool IsEmpty()
        {
            return (ToString() == null);
        }

        public override string ToString()
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
                        text.AddRange("{" + Enum.GetName(typeof(CharacterNames), charID).ToUpper() + "}");
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

        public int CompareTo(object obj)
        {
            if (obj is FFText)
            {
                return CompareTo(obj as FFText);
            }
            else if (obj is string)
            {
                return ToString().CompareTo(obj);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int CompareTo(FFText other)
        {
            return ToString().CompareTo(other.ToString());
        }
    }
}
