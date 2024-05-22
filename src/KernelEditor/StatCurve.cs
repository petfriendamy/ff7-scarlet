using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.KernelEditor
{
    public class StatCurve
    {
        private readonly byte[] gradients = new byte[8];
        private readonly sbyte[] bases = new sbyte[8];

        public byte[] Gradients
        {
            get { return gradients; }
        }
        public sbyte[] Bases
        {
            get { return bases; }
        }

        public StatCurve(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                for (int i = 0; i < 8; ++i)
                {
                    Gradients[i] = reader.ReadByte();
                    Bases[i] = reader.ReadSByte();
                }
            }
        }

        public byte[] GetRawData()
        {
            var bytes = new byte[16];
            using (var ms = new MemoryStream(bytes))
            using (var writer = new BinaryWriter(ms))
            {
                for (int i = 0; i < 8; ++i)
                {
                    writer.Write(Gradients[i]);
                    writer.Write(Bases[i]);
                }
            }
            return bytes;
        }
    }
}
