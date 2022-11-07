using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Xml;

namespace Shojy.FF7.Elena.Extensions
{
    public static class TextExtensions
    {
        public static string ToFFString(this byte[] bytes)
        {
            var length = bytes.Length;
            var text = new List<byte>();

            for (var chr = 0; chr < length; ++chr)
            {
                if (bytes[chr] < 0x60)
                {
                    text.Add((byte)(bytes[chr] + 0x20));
                }
                else if (bytes[chr] == 0xD0)
                {
                    text.Add(0x20);
                }
                else if (bytes[chr] == 0x60)
                {
                    text.Add(0xc3);
                    text.Add(0x84);
                }
                else if (bytes[chr] == 0x61)
                {
                    text.Add(0xc3);
                    text.Add(0x81);
                }
                else if (bytes[chr] == 0x62)
                {
                    text.Add(0xc3);
                    text.Add(0x87);
                }
                else if (bytes[chr] == 0x63)
                {
                    text.Add(0xc3);
                    text.Add(0x89);
                }
                else if (bytes[chr] == 0x64)
                {
                    text.Add(0xc3);
                    text.Add(0x91);
                }
                else if (bytes[chr] == 0x65)
                {
                    text.Add(0xc3);
                    text.Add(0x96);
                }
                else if (bytes[chr] == 0x66)
                {
                    text.Add(0xc3);
                    text.Add(0x9c);
                }
                else if (bytes[chr] == 0x67)
                {
                    text.Add(0xc3);
                    text.Add(0xa1);
                }
                else if (bytes[chr] == 0x68)
                {
                    text.Add(0xc3);
                    text.Add(0xa0);
                }
                else if (bytes[chr] == 0x69)
                {
                    text.Add(0xc3);
                    text.Add(0xa2);
                }
                else if (bytes[chr] == 0x6A)
                {
                    text.Add(0xc3);
                    text.Add(0xa4);
                }
                else if (bytes[chr] == 0x6B)
                {
                    text.Add(0xc3);
                    text.Add(0xa3);
                }
                else if (bytes[chr] == 0x6C)
                {
                    text.Add(0xc3);
                    text.Add(0xa5);
                }
                else if (bytes[chr] == 0x6D)
                {
                    text.Add(0xc3);
                    text.Add(0xa7);
                }
                else if (bytes[chr] == 0x6E)
                {
                    text.Add(0xc3);
                    text.Add(0xa9);
                }
                else if (bytes[chr] == 0x6F)
                {
                    text.Add(0xc3);
                    text.Add(0xa8);
                }
                else if (bytes[chr] == 0x70)
                {
                    text.Add(0xc3);
                    text.Add(0xaa);
                }
                else if (bytes[chr] == 0x71)
                {
                    text.Add(0xc3);
                    text.Add(0xab);
                }
                else if (bytes[chr] == 0x72)
                {
                    text.Add(0xc3);
                    text.Add(0xad);
                }
                else if (bytes[chr] == 0x73)
                {
                    text.Add(0xc3);
                    text.Add(0xac);
                }
                else if (bytes[chr] == 0x74)
                {
                    text.Add(0xc3);
                    text.Add(0xae);
                }
                else if (bytes[chr] == 0x75)
                {
                    text.Add(0xc3);
                    text.Add(0xaf);
                }
                else if (bytes[chr] == 0x76)
                {
                    text.Add(0xc3);
                    text.Add(0xb1);
                }
                else if (bytes[chr] == 0x77)
                {
                    text.Add(0xc3);
                    text.Add(0xb3);
                }
                else if (bytes[chr] == 0x78)
                {
                    text.Add(0xc3);
                    text.Add(0xb2);
                }
                else if (bytes[chr] == 0x79)
                {
                    text.Add(0xc3);
                    text.Add(0xb4);
                }
                else if (bytes[chr] == 0x7A)
                {
                    text.Add(0xc3);
                    text.Add(0xb6);
                }
                else if (bytes[chr] == 0x7B)
                {
                    text.Add(0xc3);
                    text.Add(0xb5);
                }
                else if (bytes[chr] == 0x7C)
                {
                    text.Add(0xc3);
                    text.Add(0xba);
                }
                else if (bytes[chr] == 0x7D)
                {
                    text.Add(0xc3);
                    text.Add(0xb9);
                }
                else if (bytes[chr] == 0x7E)
                {
                    text.Add(0xc3);
                    text.Add(0xbb);
                }
                else if (bytes[chr] == 0x7F)
                {
                    text.Add(0xc3);
                    text.Add(0xbc);
                }
                else if (bytes[chr] == 0x80)
                {
                    text.Add(0xe2);
                    text.Add(0x8c);
                    text.Add(0x98);
                }
                else if (bytes[chr] == 0x81)
                {
                    text.Add(0xc2);
                    text.Add(0xb0);
                }
                else if (bytes[chr] == 0x82)
                {
                    text.Add(0xc2);
                    text.Add(0xa2);
                }
                else if (bytes[chr] == 0x83)
                {
                    text.Add(0xc2);
                    text.Add(0xa3);
                }
                else if (bytes[chr] == 0x84)
                {
                    text.Add(0xc3);
                    text.Add(0x99);
                }
                else if (bytes[chr] == 0x85)
                {
                    text.Add(0xc3);
                    text.Add(0x9b);
                }
                else if (bytes[chr] == 0x86)
                {
                    text.Add(0xc2);
                    text.Add(0xb6);
                }
                else if (bytes[chr] == 0x87)
                {
                    text.Add(0xc3);
                    text.Add(0x9f);
                }
                else if (bytes[chr] == 0x88)
                {
                    text.Add(0xc2);
                    text.Add(0xae);
                }
                else if (bytes[chr] == 0x89)
                {
                    text.Add(0xc2);
                    text.Add(0xa9);
                }
                else if (bytes[chr] == 0x8A)
                {
                    text.Add(0xe2);
                    text.Add(0x84);
                    text.Add(0xa2);
                }
                else if (bytes[chr] == 0x8B)
                {
                    text.Add(0xc2);
                    text.Add(0xb4);
                }
                else if (bytes[chr] == 0x8C)
                {
                    text.Add(0xc2);
                    text.Add(0xa8);
                }
                else if (bytes[chr] == 0x8D)
                {
                    text.Add(0xe2);
                    text.Add(0x89);
                    text.Add(0xa0);
                }
                else if (bytes[chr] == 0x8E)
                {
                    text.Add(0xc3);
                    text.Add(0x86);
                }
                else if (bytes[chr] == 0x8F)
                {
                    text.Add(0xc3);
                    text.Add(0x98);
                }
                else if (bytes[chr] == 0x90)
                {
                    text.Add(0xe2);
                    text.Add(0x88);
                    text.Add(0x9e);
                }
                else if (bytes[chr] == 0x91)
                {
                    text.Add(0xc2);
                    text.Add(0xb1);
                }
                else if (bytes[chr] == 0x92)
                {
                    text.Add(0xe2);
                    text.Add(0x89);
                    text.Add(0xa4);
                }
                else if (bytes[chr] == 0x93)
                {
                    text.Add(0xe2);
                    text.Add(0x89);
                    text.Add(0xa5);
                }
                else if (bytes[chr] == 0x94)
                {
                    text.Add(0xc2);
                    text.Add(0xa5);
                }
                else if (bytes[chr] == 0x95)
                {
                    text.Add(0xc2);
                    text.Add(0xb5);
                }
                else if (bytes[chr] == 0x96)
                {
                    text.Add(0xe2);
                    text.Add(0x88);
                    text.Add(0x82);
                }
                else if (bytes[chr] == 0x97)
                {
                    text.Add(0xce);
                    text.Add(0xa3);
                }
                else if (bytes[chr] == 0x98)
                {
                    text.Add(0xce);
                    text.Add(0xa0);
                }
                else if (bytes[chr] == 0x99)
                {
                    text.Add(0xcf);
                    text.Add(0x80);
                }
                else if (bytes[chr] == 0x9A)
                {
                    text.Add(0xe2);
                    text.Add(0x8c);
                    text.Add(0xa1);
                }
                else if (bytes[chr] == 0x9B)
                {
                    text.Add(0xc2);
                    text.Add(0xaa);
                }
                else if (bytes[chr] == 0x9C)
                {
                    text.Add(0xc2);
                    text.Add(0xba);
                }
                else if (bytes[chr] == 0x9D)
                {
                    text.Add(0xce);
                    text.Add(0xa9);
                }
                else if (bytes[chr] == 0x9E)
                {
                    text.Add(0xc3);
                    text.Add(0xa6);
                }
                else if (bytes[chr] == 0x9F)
                {
                    text.Add(0xc3);
                    text.Add(0xb8);
                }
                else if (bytes[chr] == 0xA0)
                {
                    text.Add(0xc2);
                    text.Add(0xbf);
                }
                else if (bytes[chr] == 0xA1)
                {
                    text.Add(0xc2);
                    text.Add(0xa1);
                }
                else if (bytes[chr] == 0xA2)
                {
                    text.Add(0xc2);
                    text.Add(0xac);
                }
                else if (bytes[chr] == 0xA3)
                {
                    text.Add(0xe2);
                    text.Add(0x88);
                    text.Add(0x9a);
                }
                else if (bytes[chr] == 0xA4)
                {
                    text.Add(0xc6);
                    text.Add(0x92);
                }
                else if (bytes[chr] == 0xA5)
                {
                    text.Add(0xe2);
                    text.Add(0x89);
                    text.Add(0x88);
                }
                else if (bytes[chr] == 0xA6)
                {
                    text.Add(0xe2);
                    text.Add(0x88);
                    text.Add(0x86);
                }
                else if (bytes[chr] == 0xA7)
                {
                    text.Add(0xc2);
                    text.Add(0xab);
                }
                else if (bytes[chr] == 0xA8)
                {
                    text.Add(0xc2);
                    text.Add(0xbb);
                }
                else if (bytes[chr] == 0xA9)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0xa6);
                }
                else if (bytes[chr] == 0xAA) // { { NOTHING} }
                {
                    text.Add(0x3F);
                }
                else if (bytes[chr] == 0xAB)
                {
                    text.Add(0xc3);
                    text.Add(0x80);
                }
                else if (bytes[chr] == 0xAC)
                {
                    text.Add(0xc3);
                    text.Add(0x83);
                }
                else if (bytes[chr] == 0xAD)
                {
                    text.Add(0xc3);
                    text.Add(0x95);
                }
                else if (bytes[chr] == 0xAE)
                {
                    text.Add(0xc5);
                    text.Add(0x92);
                }
                else if (bytes[chr] == 0xAF)
                {
                    text.Add(0xc5);
                    text.Add(0x93);
                }
                else if (bytes[chr] == 0xB0)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0x93);
                }
                else if (bytes[chr] == 0xB1)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0x94);
                }
                else if (bytes[chr] == 0xB2)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0x9c);
                }
                else if (bytes[chr] == 0xB3)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0x9d);
                }
                else if (bytes[chr] == 0xB4)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0x98);
                }
                else if (bytes[chr] == 0xB5)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0x99);
                }
                else if (bytes[chr] == 0xB6)
                {
                    text.Add(0xc3);
                    text.Add(0xb7);
                }
                else if (bytes[chr] == 0xB7)
                {
                    text.Add(0xe2);
                    text.Add(0x97);
                    text.Add(0x8a);
                }
                else if (bytes[chr] == 0xB8)
                {
                    text.Add(0xc3);
                    text.Add(0xbf);
                }
                else if (bytes[chr] == 0xB9)
                {
                    text.Add(0xc5);
                    text.Add(0xb8);
                }
                else if (bytes[chr] == 0xBA)
                {
                    text.Add(0xe2);
                    text.Add(0x81);
                    text.Add(0x84);
                }
                else if (bytes[chr] == 0xBB)
                {
                    text.Add(0xc2);
                    text.Add(0xa4);
                }
                else if (bytes[chr] == 0xBC)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0xb9);
                }
                else if (bytes[chr] == 0xBD)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0xba);
                }
                else if (bytes[chr] == 0xBE)
                {
                    text.Add(0xef);
                    text.Add(0xac);
                    text.Add(0x81);
                }
                else if (bytes[chr] == 0xBF)
                {
                    text.Add(0xef);
                    text.Add(0xac);
                    text.Add(0x82);
                }
                else if (bytes[chr] == 0xC0)
                {
                    text.Add(0xe2);
                    text.Add(0x96);
                    text.Add(0xa0);
                }
                else if (bytes[chr] == 0xC1)
                {
                    text.Add(0xe2);
                    text.Add(0x96);
                    text.Add(0xaa);
                }
                else if (bytes[chr] == 0xC2)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0x9a);
                }
                else if (bytes[chr] == 0xC3)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0x9e);
                }
                else if (bytes[chr] == 0xC4)
                {
                    text.Add(0xe2);
                    text.Add(0x80);
                    text.Add(0xb0);
                }
                else if (bytes[chr] == 0xC5)
                {
                    text.Add(0xc3);
                    text.Add(0x82);
                }
                else if (bytes[chr] == 0xC6)
                {
                    text.Add(0xc3);
                    text.Add(0x8a);
                }
                else if (bytes[chr] == 0xC7)
                {
                    text.Add(0xc3);
                    text.Add(0x8b);
                }
                else if (bytes[chr] == 0xC8)
                {
                    text.Add(0xc3);
                    text.Add(0x81);
                }
                else if (bytes[chr] == 0xC9)
                {
                    text.Add(0xc3);
                    text.Add(0x88);
                }
                else if (bytes[chr] == 0xCA)
                {
                    text.Add(0xc3);
                    text.Add(0xad);
                }
                else if (bytes[chr] == 0xCB)
                {
                    text.Add(0xc3);
                    text.Add(0xae);
                }
                else if (bytes[chr] == 0xCC)
                {
                    text.Add(0xc3);
                    text.Add(0xaf);
                }
                else if (bytes[chr] == 0xCD)
                {
                    text.Add(0xc3);
                    text.Add(0xac);
                }
                else if (bytes[chr] == 0xCE)
                {
                    text.Add(0xc3);
                    text.Add(0x93);
                }
                else if (bytes[chr] == 0xCF)
                {
                    text.Add(0xc3);
                    text.Add(0x94);
                }
                else if (bytes[chr] == 0xD1)
                {
                    text.Add(0xc3);
                    text.Add(0x92);
                }
                else if (bytes[chr] == 0xD2)
                {
                    text.Add(0xc3);
                    text.Add(0x99);
                }
                else if (bytes[chr] == 0xD3)
                {
                    text.Add(0xc3);
                    text.Add(0x9b);
                }
                else if (bytes[chr] == 0xE2)
                {
                    text.Add(0x9);
                }
                else if (bytes[chr] == 0xE3)
                {
                    text.Add(0x2);
                }
                else if (bytes[chr] == 0xEA)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Cloud}"));
                }
                else if (bytes[chr] == 0xEB)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Barret}"));
                }
                else if (bytes[chr] == 0xEC)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Tifa}"));
                }
                else if (bytes[chr] == 0xED)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Aeris}"));
                }
                else if (bytes[chr] == 0xEE)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Red XIII}"));
                }
                else if (bytes[chr] == 0xEF)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Yuffie}"));
                }
                else if (bytes[chr] == 0xF0)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Caith Sith}"));
                }
                else if (bytes[chr] == 0xF1)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Vincent}"));
                }
                else if (bytes[chr] == 0xF2)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Cid}"));
                }
                else if (bytes[chr] == 0xF3)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Party 1}"));
                }
                else if (bytes[chr] == 0xF4)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Party 2}"));
                }
                else if (bytes[chr] == 0xF5)
                {
                    text.AddRange(Encoding.UTF8.GetBytes("{Party 3}"));
                }
                else if (bytes[chr] < 0xFE || bytes[chr] == 0xF8) 
                {
                    // This is a function with a parameter following. We can skip both.
                    ++chr;
                }
                else if (bytes[chr] == 0xFF)
                {
                    // That's all folks!
                    break;
                }
                else
                {
                    text.Add(0x3F);
                }
            }

            return Encoding.UTF8.GetString(text.ToArray());
        }
    }
}