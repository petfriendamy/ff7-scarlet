using System.Collections;

namespace FF7Scarlet.KernelEditor
{
    public enum MagicTypes : byte
    {
        Restore, Attack, Indirect, Special, Unlisted
    }

    public class SpellIndex
    {
        public const int INDEXED_SPELL_COUNT = 56;

        public MagicTypes MagicType { get; set; }
        public byte SpellID { get; set; }
        public byte SectionIndex { get; set; }

        public SpellIndex(byte spellID, byte data)
        {
            SpellID = spellID;
            if (data == 0xFF)
            {
                MagicType = MagicTypes.Unlisted;
            }
            else
            {
                var holder = new byte[] { data };
                var source = new BitArray(holder);
                bool[] indexBits = new bool[8], typeBits = new bool[8];

                int i;
                for (i = 0; i < 5; ++i)
                {
                    indexBits[i] = source[i];
                }
                for (i = 0; i < 3; ++i)
                {
                    typeBits[i] = source[i + 5];
                }

                //get index
                var converter = new BitArray(indexBits);
                converter.CopyTo(holder, 0);
                SectionIndex = holder[0];

                //get type
                converter = new BitArray(typeBits);
                converter.CopyTo(holder, 0);
                MagicType = (MagicTypes)holder[0];
            }
        }

        public byte GetByteValue()
        {
            if (MagicType == MagicTypes.Unlisted) { return 0xFF; }
            else
            {
                var temp = new byte[1];
                var holder = new BitArray(8);
                int i;

                //get section index bits
                temp[0] = SectionIndex;
                var converter = new BitArray(temp);
                for (i = 0; i < 5; ++i)
                {
                    holder[i] = converter[i];
                }

                //get magic type bits
                temp[0] = (byte)MagicType;
                converter = new BitArray(temp);
                for (i = 0; i < 3; ++i)
                {
                    holder[i + 5] = converter[i];
                }

                //get and return the byte
                holder.CopyTo(temp, 0);
                return temp[0];
            }
        }
    }
}
