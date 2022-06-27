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
        private enum CharacterNames
        {
            Cloud = 0xEA, Barret, Tifa, Aerith, RedXIII, Yuffie, CaitSith, Vincent, Cid
        }

        private readonly byte[] data;

        public FFText(byte[] data)
        {
            this.data = data;
        }

        public FFText(string str, int length = -1)
        {
            if (length == -1)
            {
                length = str.Length;
            }

            data = new byte[length + 1];
            for (int i = 0; i < length; ++i)
            {
                if (i < str.Length)
                {
                    data[i] = (byte)(str[i] - 0x20);
                }
                else
                {
                    data[i] = 0xFF;
                }
            }
        }

        public FFText(object value) : this(value.ToString()) { }

        public bool IsEmpty()
        {
            return (ToString() == null);
        }

        public override string ToString()
        {
            if (data.Length > 0)
            {
                var builder = new StringBuilder();
                for (int i = 0; i < data.Length; ++i)
                {
                    if (data[i] != 0xFF)
                    {
                        if (data[i] >= (int)CharacterNames.Cloud && data[i] <= (int)CharacterNames.Cid)
                        {
                            builder.Append("{" + Enum.GetName(typeof(CharacterNames), data[i]).ToUpper() + "}");
                            i += 2;
                        }
                        else if (data[i] == 0xC1)
                        {
                            builder.Append('▪');
                        }
                        else
                        {
                            builder.Append((char)(data[i] + 0x20));
                        }
                    }
                }
                if (builder.Length == 0) { return null; }
                return builder.ToString().Trim();
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
