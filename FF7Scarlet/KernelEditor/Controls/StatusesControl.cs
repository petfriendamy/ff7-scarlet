using Shojy.FF7.Elena.Battle;
using System.ComponentModel;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class StatusesControl : UserControl
    {
        private CheckBox[] checkBoxes;
        private const int FULL_LIST_LENGTH = 31, PARTIAL_LIST_LENGTH = 24;
        private bool fullList = true;

        [Description("The text for the GroupBox.")]
        public string GroupBoxText
        {
            get { return groupBoxMain.Text; }
            set { groupBoxMain.Text = value; }
        }

        [Description("Show the full list of status effects.")]
        public bool FullList
        {
            get { return fullList; }
            set
            {
                fullList = value;
                for (int i = PARTIAL_LIST_LENGTH; i < FULL_LIST_LENGTH; ++i)
                {
                    checkBoxes[i].Visible = value;
                }
            }
        }

        public StatusesControl()
        {
            InitializeComponent();
            checkBoxes = new CheckBox[FULL_LIST_LENGTH]
            {
                checkBoxDeath, checkBoxNearDeath, checkBoxSleep, checkBoxPoison, checkBoxSadness,
                checkBoxFury, checkBoxConfu, checkBoxSilence, checkBoxHaste, checkBoxSlow,
                checkBoxStop, checkBoxFrog, checkBoxSmall, checkBoxSlowNumb, checkBoxPetrify,
                checkBoxRegen, checkBoxBarrier, checkBoxMBarrier, checkBoxReflect, checkBoxDual,
                checkBoxShield, checkBoxDeathSentence, checkBoxManipulate, checkBoxBerserk,
                checkBoxPeerless, checkBoxDarkness, checkBoxDualDrain, checkBoxDeathForce,
                checkBoxResist, checkBoxLuckyGirl, checkBoxImprisoned
            };
        }

        public void SetStatuses(Statuses statuses)
        {
            checkBoxDeath.Checked = statuses.HasFlag(Statuses.Death);
            checkBoxNearDeath.Checked = statuses.HasFlag(Statuses.NearDeath);
            checkBoxSleep.Checked = statuses.HasFlag(Statuses.Sleep);
            checkBoxPoison.Checked = statuses.HasFlag(Statuses.Poison);
            checkBoxSadness.Checked = statuses.HasFlag(Statuses.Sadness);
            checkBoxFury.Checked = statuses.HasFlag(Statuses.Fury);
            checkBoxConfu.Checked = statuses.HasFlag(Statuses.Confusion);
            checkBoxSilence.Checked = statuses.HasFlag(Statuses.Silence);
            checkBoxHaste.Checked = statuses.HasFlag(Statuses.Haste);
            checkBoxSlow.Checked = statuses.HasFlag(Statuses.Slow);
            checkBoxStop.Checked = statuses.HasFlag(Statuses.Stop);
            checkBoxFrog.Checked = statuses.HasFlag(Statuses.Frog);
            checkBoxSmall.Checked = statuses.HasFlag(Statuses.Small);
            checkBoxSlowNumb.Checked = statuses.HasFlag(Statuses.SlowNumb);
            checkBoxPetrify.Checked = statuses.HasFlag(Statuses.Petrify);
            checkBoxRegen.Checked = statuses.HasFlag(Statuses.Regen);
            checkBoxBarrier.Checked = statuses.HasFlag(Statuses.Barrier);
            checkBoxMBarrier.Checked = statuses.HasFlag(Statuses.MBarrier);
            checkBoxReflect.Checked = statuses.HasFlag(Statuses.Reflect);
            checkBoxDual.Checked = statuses.HasFlag(Statuses.Dual);
            checkBoxShield.Checked = statuses.HasFlag(Statuses.Shield);
            checkBoxDeathSentence.Checked = statuses.HasFlag(Statuses.DeathSentence);
            checkBoxManipulate.Checked = statuses.HasFlag(Statuses.Manipulate);
            checkBoxBerserk.Checked = statuses.HasFlag(Statuses.Berserk);
            checkBoxPeerless.Checked = statuses.HasFlag(Statuses.Peerless);
            checkBoxParalysis.Checked = statuses.HasFlag(Statuses.Paralysis);
            checkBoxDarkness.Checked = statuses.HasFlag(Statuses.Darkness);
            checkBoxDualDrain.Checked = statuses.HasFlag(Statuses.DualDrain);
            checkBoxDeathForce.Checked = statuses.HasFlag(Statuses.DeathForce);
            checkBoxResist.Checked = statuses.HasFlag(Statuses.Resist);
            checkBoxLuckyGirl.Checked = statuses.HasFlag(Statuses.LuckyGirl);
            checkBoxImprisoned.Checked = statuses.HasFlag(Statuses.Imprisoned);
        }
    }
}
