namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class MateriaLevelControl : UserControl
    {
        private const int MAX_AP = HexParser.NULL_OFFSET_16_BIT * 100;
        private NumericUpDown[] APSelectors;
        private int[] prevValues = new int[4];
        private bool editing = false;

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
            editing = true;
            Lvl5APValue = lvl5;
            Lvl4APValue = lvl4;
            Lvl3APValue = lvl3;
            Lvl2APValue = lvl2;
            /*if (lvl2 >= MAX_AP) { MaxLevel = 1; }
            else
            {
                Lvl2APValue = lvl2;
                if (lvl3 >= MAX_AP) { MaxLevel = 2; }
                else
                {
                    Lvl3APValue = lvl3;
                    if (lvl4 >= MAX_AP) { MaxLevel = 3; }
                    else
                    {
                        Lvl4APValue = lvl4;
                        if (lvl5 >= MAX_AP) { MaxLevel = 4; }
                        else
                        {
                            MaxLevel = 5;
                            Lvl5APValue = lvl5;
                        }
                    }
                }
            }*/
            editing = false;
            UpdateForMaxLevel();
        }

        private int GetAP(int i)
        {
            return (int)APSelectors[i - 2].Value;
        }

        private void SetAP(int i, int value)
        {
            editing = true;
            int index = i - 2;
            try
            {
                if (value >= MAX_AP) { MaxLevel = i - 1; }
                else
                {
                    if (value % 100 != 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    if (prevValues[index] == MAX_AP)
                    {
                        MaxLevel = i;
                    }
                    APSelectors[index].Value = value;
                    prevValues[index] = value;
                }
                editing = false;
                UpdateForMaxLevel();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Value must be a multiple of 100.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SetAP(i, prevValues[index]);
                editing = false;
            }
        }

        private void UpdateForMaxLevel()
        {
            if (!editing)
            {
                int max = 0;
                if (MaxLevel > 2) { max = GetAP(MaxLevel - 1); }
                for (int i = 1; i < 5; ++i)
                {
                    bool isEnabled = i < MaxLevel;
                    int index = i - 1;
                    if (!isEnabled) { APSelectors[index].Value = MAX_AP; }
                    else if (APSelectors[index].Value == MAX_AP) { APSelectors[index].Value = max; }
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
    }
}
