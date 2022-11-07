namespace Shojy.FF7.Elena.Equipment
{
    public enum MateriaSlot: byte
    {
        /// <summary>
        /// No materia slot.
        /// </summary>
        None = 0,

        /// <summary>
        /// Unlinked slot without materia growth.
        /// </summary>
        EmptyUnlinkedSlot = 1,

        /// <summary>
        /// Left side of a linked slot without materia growth.
        /// </summary>
        EmptyLeftLinkedSlot = 2,

        /// <summary>
        /// Right side of a linked slot without materia growth.
        /// </summary>
        EmptyRightLinkedSlot = 3,

        /// <summary>
        /// Unlinked slot with materia growth.
        /// </summary>
        NormalUnlinkedSlot = 5,

        /// <summary>
        /// Left side of a linked slot with materia growth.
        /// </summary>
        NormalLeftLinkedSlot = 6,

        /// <summary>
        /// Right side of a linked slot with materia growth.
        /// </summary>
        NormalRightLinkedSlot = 7
    }
}