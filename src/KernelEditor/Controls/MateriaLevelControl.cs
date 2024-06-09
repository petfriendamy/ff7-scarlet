namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class MateriaLevelControl : UserControl
    {
        
        private NumericUpDown[] APSelectors;
        private int[] prevValues = new int[4];
        private bool loading = false;
        public event EventHandler? DataChanged;

        public int Lvl2APValue
        {
            get { return GetAP(2); }
            set { SetAP(2, value); }
        }
        public int Lvl3APValue
        {
            get { return GetAP(3); }
            set { SetAP(3, value); }
        }
        public int Lvl4APValue
        {
            get { return GetAP(4); }
            set { SetAP(4, value); }
        }
        public int Lvl5APValue
        {
            get { return GetAP(5); }
            set { SetAP(5, value); }
        }
        public int MaxLevel
        {
            get { return (int)numericMateriaMaxLevel.Value; }
            set
            {
                if (value < 1 || value > 5) { throw new ArgumentOutOfRangeException(); }
                numericMateriaMaxLevel.Value = value;
                UpdateForMaxLevel();
                InvokeDataChanged(this, EventArgs.Empty);
            }
        }

        public MateriaLevelControl()
        {
            InitializeComponent();
            APSelectors = new NumericUpDown[4]
            {
                numericLvl2AP, numericLvl3AP, numericLvl4AP, numericLvl5AP
            };
        }

        public void SetAPLevels(int lvl2, int lvl3, int lvl4, int lvl5)
        {
            loading = true;
            Lvl5APValue = lvl5;
            Lvl4APValue = lvl4;
            Lvl3APValue = lvl3;
            Lvl2APValue = lvl2;
            loading = false;
            UpdateForMaxLevel();
        }

        private int GetAP(int i)
        {
            return (int)APSelectors[i - 2].Value;
        }

        private void SetAP(int i, int value)
        {
            loading = true;
            int index = i - 2;
            try
            {
                if (value >= MateriaExt.MAX_AP) { MaxLevel = i - 1; }
                else
                {
                    if (value % 100 != 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    if (prevValues[index] == MateriaExt.MAX_AP)
                    {
                        MaxLevel = i;
                    }
                    if(i > MaxLevel)
                    {
                        MaxLevel = i;
                    }
                    APSelectors[index].Value = value;
                    prevValues[index] = value;
                }
                loading = false;
                InvokeDataChanged(this, EventArgs.Empty);
                UpdateForMaxLevel();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Value must be a multiple of 100.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SetAP(i, prevValues[index]);
                loading = false;
            }
        }

        private void UpdateForMaxLevel()
        {
            if (!loading)
            {
                int max = 0;
                if (MaxLevel > 2) { max = GetAP(MaxLevel - 1); }
                for (int i = 1; i < 5; ++i)
                {
                    bool isEnabled = i < MaxLevel;
                    int index = i - 1;
                    if (!isEnabled)
                    {
                        APSelectors[index].Value = MateriaExt.MAX_AP;
                    }
                    else if (APSelectors[index].Value == MateriaExt.MAX_AP)
                    {
                        APSelectors[index].Value = max;
                    }
                    APSelectors[index].Enabled = isEnabled;
                }
            }
        }

        private void numericLvl2AP_ValueChanged(object sender, EventArgs e)
        {
            SetAP(2, GetAP(2));
        }

        private void numericLvl3AP_ValueChanged(object sender, EventArgs e)
        {
            SetAP(3, GetAP(3));
        }

        private void numericLvl4AP_ValueChanged(object sender, EventArgs e)
        {
            SetAP(4, GetAP(4));
        }

        private void numericLvl5AP_ValueChanged(object sender, EventArgs e)
        {
            SetAP(5, GetAP(5));
        }

        private void numericMateriaMaxLevel_ValueChanged(object sender, EventArgs e)
        {
            int value = MaxLevel;
            MaxLevel = value;
        }

        private void InvokeDataChanged(object? sender, EventArgs e)
        {
            DataChanged?.Invoke(sender, e);
        }
    }
}
