using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.AIEditor
{
    public enum Opcodes : byte
    {
        PushAddress00 = 0x00, PushAddress01 = 0x01, PushAddress02 = 0x02,
        PushAddress03 = 0x03, PushValue10 = 0x10, PushValue11 = 0x11,
        PushValue12 = 0x12, PushValue13 = 0x13, Add = 0x30, Subtract = 0x31,
        Multiply = 0x32, Divide = 0x33, Modulo = 0x34, BitwiseAnd = 0x35,
        BitwiseOr = 0x36, BitwiseNot = 0x37, Equal = 0x40, NotEqual = 0x41,
        GreaterOrEqual = 0x42, LessThanOrEqual = 0x43, GreaterThan = 0x44,
        LessThan = 0x45, LogicalAnd = 0x50, LogicalOr = 0x51, LogicalNot = 0x52,
        PushConst01 = 0x60, PushConst02 = 0x61, PushConst03 = 0x62, JumpEqual = 0x70,
        JumpNotEqual = 0x71, Jump = 0x72, End = 0x73, PopUnused = 0x74, ShareScripts = 0x75,
        Mask = 0x80, RandomWord = 0x81, RandomByte = 0x82, CountBits = 0x83,
        MaskGreatest = 0x84, MaskLeast = 0x85, MPCost = 0x86, TopBit = 0x87, Assign = 0x90,
        Pop = 0x91, Attack = 0x92, ShowMessage = 0x93, CopyStats = 0x94, Savemap = 0x95,
        ElementalDef = 0x96, DebugMessage = 0xA0, Pop2 = 0xA1, Label = 0xFE
    }
}
