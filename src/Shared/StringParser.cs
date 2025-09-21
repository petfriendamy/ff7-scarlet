using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
