using System;

namespace Shojy.FF7.Elena
{
    public interface IMemoryReader
    {
        byte[] ReadMemory(IntPtr memoryAddress, int count);
    }
}