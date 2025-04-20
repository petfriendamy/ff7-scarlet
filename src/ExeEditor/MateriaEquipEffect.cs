using System.Text;

namespace FF7Scarlet.ExeEditor
{
    public class MateriaEquipEffect
    {
        public const int DATA_LENGTH = 16, COUNT = 21;
        public short[] StatChanges { get; } = new short[COUNT];

        public MateriaEquipEffect(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            else if (data.Length != DATA_LENGTH)
            {
                throw new ArgumentException("Data length is incorrect.");
            }

            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                for (int i = 0; i < DATA_LENGTH / 2; ++i)
                {
                    StatChanges[i] = reader.ReadInt16();
                }
            } 
        }

        private string GetStat(int stat)
        {
            switch (stat)
            {
                case 0:
                    return "STR";
                case 1:
                    return "VIT";
                case 2:
                    return "MAG";
                case 3:
                    return "SPR";
                case 4:
                    return "DEX";
                case 5:
                    return "LUCK";
                case 6:
                    return "HP";
                case 7:
                    return "MP";
            }
            return string.Empty;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            for (int i = 0; i < COUNT; ++i)
            {
                if (StatChanges[i] != 0)
                {
                    if (str.Length > 0)
                    {
                        str.Append(", ");
                    }
                    if (StatChanges[i] > 0)
                    {
                        str.Append("+");
                    }
                    str.Append($"{StatChanges[i]:D2} ");
                    str.Append(GetStat(i));
                    if (i > 5) //HP or MP
                    {
                        str.Append("%");
                    }
                }
            }
            if (str.Length == 0) { return "None"; }
            return str.ToString();
        }

        public byte[] GetBytes()
        {
            var bytes = new List<byte>();
            foreach (var stat in StatChanges)
            {
                bytes.AddRange(BitConverter.GetBytes(stat));
            }
            return bytes.ToArray();
        }
    }
}
