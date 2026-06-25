using Shojy.FF7.Elena.Equipment;

namespace FF7Scarlet.KernelEditor
{
    public static class MateriaSlotExt
    {
        public const MateriaSlot
            DOUBLE_LINKED_EMPTY = (MateriaSlot)8,
            DOUBLE_LINKED_NORMAL = (MateriaSlot)9;

        public static byte GetSlotByte(MateriaSlot slot)
        {
            if (slot == DOUBLE_LINKED_EMPTY) { return (byte)MateriaSlot.EmptyRightLinkedSlot; }
            else if (slot == DOUBLE_LINKED_NORMAL) { return (byte)MateriaSlot.NormalRightLinkedSlot; }
            else { return (byte)slot; }
        }
    }
}
