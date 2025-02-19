using Shojy.FF7.Elena.Equipment;
using System.ComponentModel;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class StatIncreaseControl : UserControl
    {
        public event EventHandler? DataChanged;
        private bool loading;
        private ComboBox[] comboBoxes;
        private NumericUpDown[] numerics;
        private const int MAX_STAT_COUNT = 4;
        private int count = 4;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            comboBoxes =
            [
                comboBoxStat1, comboBoxStat2, comboBoxStat3, comboBoxStat4
            ];
            numerics =
            [
                numericStat1, numericStat2, numericStat3, numericStat4
            ];
            loading = true;
            for (int i = 0; i < MAX_STAT_COUNT; ++i)
            {
                comboBoxes[i].Items.Add("None");
                foreach (var s in Enum.GetNames<CharacterStat>())
                {
                    if (s != "None") { comboBoxes[i].Items.Add(s); }
                }
            }
            loading = false;
        }

        public void SetStatIncreases(StatIncrease[] stats)
        {
            loading = true;
            Count = Math.Min(stats.Length, MAX_STAT_COUNT);
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
            loading = false;
        }

        public StatIncrease[] GetStatIncreases()
        {
            var increases = new StatIncrease[Count];
            CharacterStat stat;
            for (int i = 0; i < Count; ++i)
            {
                if (comboBoxes[i].SelectedIndex == 0)
                {
                    stat = CharacterStat.None;
                }
                else
                {
                    stat = (CharacterStat)(comboBoxes[i].SelectedIndex - 1);
                }
                increases[i] = new StatIncrease(stat, (byte)numerics[i].Value);
            }
            return increases;
        }

        private void InvokeDataChanged(object? sender, EventArgs e)
        {
            DataChanged?.Invoke(sender, e);
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                InvokeDataChanged(sender, e);
            }
        }
    }
}
