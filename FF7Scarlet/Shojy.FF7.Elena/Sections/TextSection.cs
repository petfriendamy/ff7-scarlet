using System;
using System.Collections.Generic;
using System.Diagnostics;
using Shojy.FF7.Elena.Extensions;

namespace Shojy.FF7.Elena.Sections
{
    public class TextSection
    {
        #region Private Fields

        private const byte Deliminator = 0xFF;
        private const byte LookupCommand = 0xF9;
        private readonly byte[] _sectionData;

        public string[] Strings { get; }

        #endregion Private Fields

        #region Public Constructors

        public TextSection(byte[] sectionData)
        {
            this._sectionData = sectionData;
            var firstItem  = BitConverter.ToUInt16(sectionData, 0);
            var addresses = new List<ushort>();
            for (var index = 0; index < firstItem; index += 2)
            {
                addresses.Add(BitConverter.ToUInt16(sectionData, index));
            }
            
            var bytes = new byte[sectionData.Length - firstItem];
            Array.Copy(sectionData, firstItem, bytes, 0, bytes.Length);
            this.Strings = ExtractStrings(sectionData, addresses);
        }

        private static string[] ExtractStrings(byte[] data, List<ushort> addresses)
        {
            var strings = new List<string>();

            var text = new List<byte>();

            foreach (var address in addresses)
            {

                for (var index = address; index < data.Length && data[index] != 0xFF; ++index)
                {
                    var character = data[index];
                    // This is an encoding technique designed to make the raw data smaller. It is based
                    // on the LZS compression method, but optimized for smaller files with fewer large
                    // similar blocks. A byte following this value will tell the game's memory the location
                    // of, and how much, text to read.
                    // More info at: http://wiki.ffrtt.ru/index.php/FF7/FF_Text
                    if (character == LookupCommand)
                    {
                        var args = data[index + 1];
                        // The args byte is split into length, and offset. The first two bits are
                        // the length of data, and the remaining 6 are how far back to get it from.
                        // Length needs further calculation (L * 2 + 4) to provide the correct value.
                        var lookupLength = ((args & 0b11000000) >> 6) * 2 + 4;
                        var lookupOffset = (args & 0b00111111);

                        for (var i = 0; i < lookupLength; ++i)
                        {
                            var pos = index - 1 - lookupOffset + i;
                            try
                            {
                                if (data[pos] != 0xFF)
                                    text.Add(data[pos]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine($"Out of bounds lookup from index {index}");
                            }
                        }

                        // Skip processing the args byte
                        ++index;
                    }
                    else
                    {
                        text.Add(character);
                    }
                }

                var bytes = text.ToArray();
                strings.Add(bytes.ToFFString());
                text.Clear();
            }

            return strings.ToArray();
        }


        #endregion Public Constructors
    }
}