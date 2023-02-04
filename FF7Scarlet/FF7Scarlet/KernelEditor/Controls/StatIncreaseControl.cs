using Shojy.FF7.Elena.Equipment;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class StatIncreaseControl : UserControl
    {
        private ComboBox[] comboBoxes;
        private NumericUpDown[] numerics;
        private const int MAX_STAT_COUNT = 4;
        private int count = 4;

        public int Count
        {
            get { return count; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Count cannot be less than 1. Value was {value}.");
                }
                if (value > MAX_STAT_COUNT)
                {
                    throw new ArgumentException($"Count cannot exceed {MAX_STAT_COUNT}. Value was {value}.");
                }

                count = value;
                for (int i = 0; i < MAX_STAT_COUNT; ++i)
                {
                    comboBoxes[i].Visible = numerics[i].Visible = i < value;
                }
            }
        }

        public StatIncreaseControl()
        {
            InitializeComponent();
            comboBoxes = new ComboBox[MAX_STAT_COUNT]
            {
                comboBoxStat1, comboBoxStat2, comboBoxStat3, comboBoxStat4
            };
            numerics = new NumericUpDown[MAX_STAT_COUNT]
            {
                numericStat1, numericStat2, numericStat3, numericStat4
            };
            for (int i = 0; i < MAX_STAT_COUNT; ++i)
            {
                comboBoxes[i].Items.Add("None");
                foreach (var s in Enum.GetNames<CharacterStat>())
                {
                    if (s != "None") { comboBoxes[i].Items.Add(s); }
                }
            }
        }

        public void SetStatIncreases(StatIncrease[] stats)
        {
            Count = stats.Length;
            for (int i = 0; i < Count; ++i)
            {
                numerics[i].Value = stats[i].Amount;
                if (stats[i].Stat == CharacterStat.None)
                {
                    comboBoxes[i].SelectedIndex = 0;
                    numerics[i].Enabled = false;
                }
                else
                {
                    comboBoxes[i].SelectedIndex = (int)stats[i].Stat + 1;
                    numerics[i].Enabled = true;
                }
            }
        }
    }
}
