using Shojy.FF7.Elena.Battle;
using System.ComponentModel;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class StatusesControl : UserControl
    {
        private CheckBox[] checkBoxes;
        private Statuses[] statusList;
        private const int FULL_LIST_LENGTH = 32, PARTIAL_LIST_LENGTH = 24;
        private bool fullList = true, loading = false;

        [Description("The text for the GroupBox.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string GroupBoxText
        {
            get { return groupBoxMain.Text; }
            set { groupBoxMain.Text = value; }
        }

        [Description("Show the full list of status effects.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        public event EventHandler? StatusesChanged;

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
                checkBoxPeerless, checkBoxParalysis, checkBoxDarkness, checkBoxDualDrain,
                checkBoxDeathForce, checkBoxResist, checkBoxLuckyGirl, checkBoxImprisoned
            };
            statusList = Enum.GetValues<Statuses>();
        }

        public void SetStatuses(Statuses statuses)
        {
            loading = true;
            for (int i = 0; i < FULL_LIST_LENGTH; ++i)
            {
                checkBoxes[i].Checked = statuses.HasFlag(statusList[i]);
            }
            loading = false;
        }

        public Statuses GetStatuses()
        {
            Statuses status = 0;
            for (int i = 0; i < FULL_LIST_LENGTH; ++i)
            {
                if (checkBoxes[i].Checked)
                {
                    status |= statusList[i];
                }
            }
            return status;
        }

        private void CheckBoxChanged(object? sender, EventArgs e)
        {
            if (!loading) { StatusesChanged?.Invoke(this, e); }
        }
    }
}
