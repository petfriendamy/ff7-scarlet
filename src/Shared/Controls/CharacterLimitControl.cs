using Shojy.FF7.Elena.Characters;
using System.ComponentModel;
using System.Linq;

namespace FF7Scarlet.Shared.Controls
{
    public partial class CharacterLimitControl : UserControl
    {
        private byte limitLevel, limitBar;
        private LearnedLimits learnedLimits;
        private LearnedLimits[] limitFlags;
        private CheckBox[] checkBoxes;
        public event EventHandler? DataChanged;
        private bool loading;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LearnedLimits LearnedLimits
        {
            get { return learnedLimits; }
            set
            {
                loading = true;
                learnedLimits = value;
                for (int i = 0; i < limitFlags.Length; ++i)
                {
                    checkBoxes[i].Checked = learnedLimits.HasFlag(limitFlags[i]);
                }
                loading = false;
            }
        }

        public CharacterLimitControl()
        {
            InitializeComponent();
            limitFlags = Enum.GetValues<LearnedLimits>();
            checkBoxes = [
                checkBoxCharacterLimit1_1, checkBoxCharacterLimit1_2, checkBoxCharacterLimit2_1,
                checkBoxCharacterLimit2_2, checkBoxCharacterLimit3_1, checkBoxCharacterLimit3_2,
                checkBoxCharacterLimit4
            ];
        }

        private void checkBoxCharacterLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                var list = checkBoxes.ToList();
                var cb = sender as CheckBox;
                if (cb != null)
                {
                    int i = list.IndexOf(cb);
                    if (i >= 0)
                    {
                        LearnedLimits |= limitFlags[i];
                        InvokeDataChanged(sender, e);
                    }
                }
            }
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
