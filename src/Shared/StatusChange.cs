using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.Shared
{
    /*public enum StatusChangeType
    {
        None, Inflict, Cure, Swap
    }

    public class StatusChange
    {
        public StatusChangeType Type { get; set; }
        public byte Amount { get; set; }

        public StatusChange(byte value)
        {
            if (value == 0xFF)
            {
                Type = StatusChangeType.None;
                Amount = 0;
            }
            else if ((value & 0x40) != 0)
            {
                Type = StatusChangeType.Cure;
                Amount = (byte)(value - 0x40);
            }
            else if ((value & 0x80) != 0)
            {
                Type = StatusChangeType.Swap;
                Amount = (byte)(value - 0x80);
            }
            else
            {
                Type = StatusChangeType.Inflict;
                Amount = value;
            }
        }

        public byte GetValue()
        {
            switch (Type)
            {
                case StatusChangeType.Cure:
                    return (byte)(Amount + 0x40);
                case StatusChangeType.Swap:
                    return (byte)(Amount + 0x80);
                case StatusChangeType.Inflict:
                    return Amount;
                default:
                    return 0xFF;
            }
        }
    }*/
}
