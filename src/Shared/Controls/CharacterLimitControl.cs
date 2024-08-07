using Shojy.FF7.Elena.Characters;

namespace FF7Scarlet.Shared.Controls
{
    public partial class CharacterLimitControl : UserControl
    {
        private byte limitLevel, limitBar;
        private LearnedLimits learnedLimits;
        public event EventHandler? DataChanged;
        private bool loading;

        public byte LimitLevel
        {
            get { return limitLevel; }
            set
            {
                loading = true;
                limitLevel = value;
                numericCharacterLimitLevel.Value = limitLevel;
                loading = false;
            }
        }
        public byte LimitBar
        {
            get { return limitBar; }
            set
            {
                loading = true;
                limitBar = value;
                trackBarCharacterLimitBar.Value = limitBar;
                loading = false;
            }
        }

        public LearnedLimits LearnedLimits
        {
            get { return learnedLimits; }
            set
            {
                loading = true;
                learnedLimits = value;
                checkBoxCharacterLimit1_1.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv1_1);
                checkBoxCharacterLimit1_2.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv1_2);
                checkBoxCharacterLimit2_1.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv2_1);
                checkBoxCharacterLimit2_2.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv2_2);
                checkBoxCharacterLimit3_1.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv3_1);
                checkBoxCharacterLimit3_2.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv3_2);
                checkBoxCharacterLimit4.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv4);
                loading = false;
            }
        }
        
        public CharacterLimitControl()
        {
            InitializeComponent();
        }

        private void InvokeDataChanged(object? sender, EventArgs e)
        {
            DataChanged?.Invoke(sender, e);
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                InvokeDataChanged(sender, e);
            }
        }
    }
}
