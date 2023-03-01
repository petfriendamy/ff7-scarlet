using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public static class StringParser
    {
        public static string AddSpace(string str)
        {
            string final = str;
            for (int i = 1; i < str.Length; ++i)
            {
                if (char.IsUpper(str[i]))
                {
                    final = str.Substring(0, i) + ' ' + str.Substring(i);
                    break;
                }
            }
            return final;
        }
    }
}
