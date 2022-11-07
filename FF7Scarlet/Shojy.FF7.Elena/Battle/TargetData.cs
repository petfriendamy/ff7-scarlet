using System;

namespace Shojy.FF7.Elena.Battle
{
    [Flags]
    public enum TargetData : byte
    {
        /// <summary>
        /// Cursor will move to the battle field and a target can be
        /// selected from valid targets as per additional constraints.
        /// </summary>
        EnableSelection = 0x01,

        /// <summary>
        /// Cursor will start on the first enemy row.
        /// </summary>
        StartCursorOnEnemyRow = 0x02,

        /// <summary>
        /// Cursor will select all targets in a given row.
        /// </summary>
        DefaultMultipleTargets = 0x04,

        /// <summary>
        /// Caster can switch cursor between multiple targets or single
        /// targets. (Also indicates if damage will be split among targets)
        /// </summary>
        ToggleSingleMultiTarget = 0x08,

        /// <summary>
        /// Cursor will only target allies or enemies as defined in
        /// <see cref="StartCursorOnEnemyRow"/> and cannot be moved from the row.
        /// </summary>
        SingleRowOnly = 0x10,

        /// <summary>
        /// If the target or the caster is not in the front of their row, the target
        /// will take half damage.
        /// For every attack this is enabled, they are constrained by the Binary
        /// "Cover Flags"
        /// </summary>
        ShortRange = 0x20,

        /// <summary>
        /// Cursor will select all viable targets
        /// </summary>
        AllRows = 0x40,

        /// <summary>
        /// When multiple targets are selected, one will be selected at random to
        /// be the receiving target. Cursor will cycle among all viable targets.
        /// </summary>
        RandomTarget = 0x80
    }
}