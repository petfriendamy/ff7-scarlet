namespace Shojy.FF7.Elena.Materias
{
    /// <summary>
    /// Materia type
    /// </summary>
    public enum MateriaType
    {
        /// <summary>
        /// Purple/Pink materia that has no effect when paired with others.
        /// </summary>
        Independent,

        /// <summary>
        /// Blue materia that only has effect when paired with others.
        /// </summary>
        Support,

        /// <summary>
        /// Green materia that gives access to Magic abilities.
        /// </summary>
        Magic,

        /// <summary>
        /// Red materia that gives access to Summon abilities.
        /// </summary>
        Summon,

        /// <summary>
        /// Yellow materia that provides additional battle actions.
        /// </summary>
        Command
    }
}