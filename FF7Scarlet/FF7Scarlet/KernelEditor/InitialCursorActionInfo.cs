using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.KernelEditor
{
    public class InitialCursorActionInfo
    {
        public static readonly InitialCursorActionInfo[] ACTION_LIST =
        {
            new InitialCursorActionInfo(0x00, "Perform command using target data"),
            new InitialCursorActionInfo(0x01, "Magic menu"),
            new InitialCursorActionInfo(0x02, "Summon menu"),
            new InitialCursorActionInfo(0x03, "Item menu"),
            new InitialCursorActionInfo(0x04, "Enemy Skill menu"),
            new InitialCursorActionInfo(0x05, "Throw menu"),
            new InitialCursorActionInfo(0x06, "Limit menu"),
            new InitialCursorActionInfo(0x07, "Enable target selection via cursor"),
            new InitialCursorActionInfo(0x08, "W-Magic menu"),
            new InitialCursorActionInfo(0x09, "W-Summon menu"),
            new InitialCursorActionInfo(0x0A, "W-Item menu"),
            new InitialCursorActionInfo(0x0B, "Coin menu")
        };

        public byte Value { get; }
        public string Description { get; }

        public InitialCursorActionInfo(byte value, string description)
        {
            Value = value;
            Description = description;
        }

        public static InitialCursorActionInfo? GetInfo(byte value)
        {
            if (value >= ACTION_LIST.Length) { return null; }
            return ACTION_LIST[value];
        }
    }
}
