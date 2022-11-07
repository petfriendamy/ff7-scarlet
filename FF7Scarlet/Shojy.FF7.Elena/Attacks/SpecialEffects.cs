using System;

namespace Shojy.FF7.Elena.Attacks
{
    [Flags]
    public enum SpecialEffects
    {
        /// <summary>
        /// Damage is dealt to targets MP instead of HP.
        /// </summary>
        DamageMP = 0x1,

        /// <summary>
        /// The attack is always considered to be physical for damage calculation.
        /// </summary>
        ForcePhysical = 0x4,

        /// <summary>
        /// The user should recover some HP based on the damage dealt.
        /// </summary>
        DrainPartialInflictedDamage = 0x10,

        /// <summary>
        /// The user should recover some HP and MP based on damage dealt.
        /// </summary>
        DrainHPAndMP = 0x20,

        /// <summary>
        /// The attack should diffuse into other targets after hitting. This is no longer used
        /// and is thought to only have been used with Blade Beam.
        /// </summary>
        DiffuseAttack = 0x40,

        /// <summary>
        /// Ignores the target's status defense when calculating infliction chance.
        /// </summary>
        IgnoreStatusDefense = 0x80,

        /// <summary>
        /// For targetting dead or undead characters only. (Phoenix Down/Life/etc)
        /// </summary>
        MissWhenTargetNotDead = 0x100,

        /// <summary>
        /// This ability can be reflected using the Reflect status
        /// </summary>
        CanReflect = 0x200,

        /// <summary>
        /// Piercing damage that ignores the normal damage calculation
        /// </summary>
        BypassDefense = 0x400,

        /// <summary>
        /// The ability should not automatically move to the next viable target if the intended target
        /// is no longer viable.
        /// </summary>
        DontAutoRetargetWhenOriginalTargetKilled = 0x800,

        /// <summary>
        /// This attack is always a critical hit. (Death Blow)
        /// </summary>
        AlwaysCritical = 0x2000
    }
}