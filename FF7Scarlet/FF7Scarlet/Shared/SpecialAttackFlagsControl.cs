using Shojy.FF7.Elena.Attacks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet.Shared
{
    public partial class SpecialAttackFlagsControl : UserControl
    {
        public SpecialAttackFlagsControl()
        {
            InitializeComponent();
        }

        public void SetFlags(SpecialEffects effects)
        {
            checkBoxDamageMP.Checked = effects.HasFlag(SpecialEffects.DamageMP);
            checkBoxUnknown1.Checked = ((byte)effects & 0x0002) != 0;
            checkBoxAffectedByDarkness.Checked = effects.HasFlag(SpecialEffects.ForcePhysical);
            checkBoxDrainsDamage.Checked = effects.HasFlag(SpecialEffects.DrainPartialInflictedDamage);
            checkBoxDrainsHPandMP.Checked = effects.HasFlag(SpecialEffects.DrainHPAndMP);
            checkBoxUnknown2.Checked = effects.HasFlag(SpecialEffects.DiffuseAttack);
            checkBoxIgnoreStatusDefense.Checked = effects.HasFlag(SpecialEffects.IgnoreStatusDefense);
            checkBoxMissIfNotDead.Checked = effects.HasFlag(SpecialEffects.MissWhenTargetNotDead);
            checkBoxReflectable.Checked = effects.HasFlag(SpecialEffects.CanReflect);
            checkBoxIgnoreDefense.Checked = effects.HasFlag(SpecialEffects.BypassDefense);
            checkBoxNoRetargetIfDead.Checked = effects.HasFlag(SpecialEffects.DontAutoRetargetWhenOriginalTargetKilled);
            checkBoxAlwaysCrit.Checked = effects.HasFlag(SpecialEffects.AlwaysCritical);
        }
    }
}
