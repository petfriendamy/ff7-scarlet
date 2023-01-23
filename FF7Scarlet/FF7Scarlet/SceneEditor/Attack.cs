using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public class Attack
    {
        public ushort ID { get; }
        public FFText Name { get; }
        private byte[] rawData;

        public Attack(ushort id, FFText name, byte[] data)
        {
            ID = id;
            Name = name;
            rawData = data;
        }

        public byte[] GetRawData()
        {
            return rawData;
        }
    }
}
