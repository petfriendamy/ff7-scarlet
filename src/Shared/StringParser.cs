using Shojy.FF7.Elena.Text;

namespace FF7Scarlet.Shared
{
    public static class StringParser
    {
        public static string AddSpaces(string? str, bool makeLower = false)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            char curr;
            for (int i = 1; i < str.Length - 1; ++i)
            {
                curr = str[i];
                if (char.IsUpper(curr))
                {
                    if (!(char.IsUpper(str[i - 1]) && char.IsUpper(str[i + 1]))) //ignore full caps words
                    {
                        if (makeLower && !char.IsUpper(str[i + 1]))
                        {
                            curr = char.ToLower(curr);
                        }
                        str = str.Substring(0, i) + ' ' + curr + str.Substring(i + 1);
                        i++;
                    }
                }
            }
            return str;
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
