using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;
using System.Xml.Linq;

namespace FF7Scarlet.Shared
{
    public partial class SpecialAttackFlagsControl : UserControl
    {
        private CheckBox[] checkBoxes;
        private SpecialEffects[] effectList;
        private bool loading = false;
        public event EventHandler? FlagsChanged;

        public SpecialAttackFlagsControl()
        {
            InitializeComponent();

            checkBoxes = new CheckBox[]
            {
                checkBoxDamageMP, checkBoxUnknown1, checkBoxAffectedByDarkness, checkBoxDrainsDamage,
                checkBoxDrainsHPandMP, checkBoxUnknown2, checkBoxIgnoreStatusDefense,checkBoxMissIfNotDead,
                checkBoxReflectable, checkBoxIgnoreDefense, checkBoxNoRetargetIfDead, checkBoxAlwaysCrit
            };
            effectList = new SpecialEffects[]
            {
                SpecialEffects.DamageMP, (SpecialEffects)0x0002, SpecialEffects.ForcePhysical,
                SpecialEffects.DrainPartialInflictedDamage, SpecialEffects.DrainHPAndMP,
                SpecialEffects.DiffuseAttack, SpecialEffects.IgnoreStatusDefense,
                SpecialEffects.MissWhenTargetNotDead, SpecialEffects.CanReflect,
                SpecialEffects.BypassDefense, SpecialEffects.DontAutoRetargetWhenOriginalTargetKilled,
                SpecialEffects.AlwaysCritical
            };
        }

        public void SetFlags(SpecialEffects effects)
        {
            loading = true;
            for (int i = 0; i < effectList.Length; ++i)
            {
                checkBoxes[i].Checked = effects.HasFlag(effectList[i]);
            }
            loading = false;
        }

        public SpecialEffects GetFlags()
        {
            SpecialEffects effects = 0;
            for (int i = 0; i < effectList.Length; ++i)
            {
                if (checkBoxes[i].Checked)
                {
                    effects |= effectList[i];
                }
            }
            return effects;
        }

        private void CheckBoxChanged(object? sender, EventArgs e)
        {
            if (!loading) { FlagsChanged?.Invoke(this, e); }
        }
    }
}
