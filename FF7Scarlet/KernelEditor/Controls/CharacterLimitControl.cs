using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class CharacterLimitControl : UserControl
    {
        private byte limitLevel, limitBar;
        private LearnedLimits learnedLimits;

        public byte LimitLevel
        {
            get { return limitLevel; }
            set
            {
                limitLevel = value;
                numericCharacterLimitLevel.Value = limitLevel;
            }
        }
        public byte LimitBar
        {
            get { return limitBar; }
            set
            {
                limitBar = value;
                trackBarCharacterLimitBar.Value = limitBar;
            }
        }

        public LearnedLimits LearnedLimits
        {
            get { return learnedLimits; }
            set
            {
                learnedLimits = value;
                checkBoxCharacterLimit1_1.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv1_1);
                checkBoxCharacterLimit1_2.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv1_2);
                checkBoxCharacterLimit2_1.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv2_1);
                checkBoxCharacterLimit2_2.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv2_2);
                checkBoxCharacterLimit3_1.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv3_1);
                checkBoxCharacterLimit3_2.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv3_2);
                checkBoxCharacterLimit4.Checked = learnedLimits.HasFlag(LearnedLimits.LimitLv4);
            }
        }
        
        public CharacterLimitControl()
        {
            InitializeComponent();
        }
    }
}
