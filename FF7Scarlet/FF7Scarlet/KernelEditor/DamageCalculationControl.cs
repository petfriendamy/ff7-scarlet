using System.Globalization;
using System.Media;

namespace FF7Scarlet.KernelEditor
{
    public partial class DamageCalculationControl : UserControl
    {
        private DamageCalculationInfo info;
        private byte attackPower;
        private int mainCaller = -1;
        private bool loaded = false, editingTextBox = false;

        public byte ActualValue
        {
            get { return info.ActualValue; }
            set
            {
                if (loaded) { info.ActualValue = value; }
                else
                {
                    loaded = true;
                    info = new DamageCalculationInfo(value);
                }
                TrySetCaller(0);
                UpdateActualValueTextBox(0);

                if (IsValid || IsNull)
                {
                    DamageType = info.DamageType;
                    AccuracyCalculation = info.AccuracyCalculation;
                    CanCrit = info.CanCrit;
                    DamageFormula = info.DamageFormula;
                    IsNull = info.IsNull;
                }
                TryClearCaller(0);
            }
        }
        public byte AttackPower
        {
            get { return attackPower; }
            set
            {
                attackPower = value;
                numericAttackPower.Value = value;
            }
        }
        public DamageType DamageType
        {
            get { return info.DamageType; }
            set
            {
                info.DamageType = value;
                comboBoxDamageType.SelectedIndex = (int)value;
            }
        }
        public AccuracyCalculation AccuracyCalculation
        {
            get { return info.AccuracyCalculation; }
            set
            {
                info.AccuracyCalculation = value;
                comboBoxAccuracyCalculation.SelectedIndex = (int)value;
            }
        }
        public bool CanCrit
        {
            get { return info.CanCrit; }
            set
            {
                info.CanCrit = value;
                checkBoxCanCrit.Checked = value;
            }
        }

        public DamageFormulas DamageFormula
        {
            get { return info.DamageFormula; }
            set
            {
                info.DamageFormula = value;
                comboBoxDamageFormula.SelectedIndex = (int)value;
            }
        }
        public bool IsValid
        {
            get { return info.IsValid; }
        }

        public bool IsNull
        {
            get { return info.IsNull; }
            private set
            {
                TrySetCaller(100);
                info.IsNull = value;
                checkBoxIsNull.Checked = value;
                numericAttackPower.Enabled =  comboBoxDamageType.Enabled = 
                    comboBoxAccuracyCalculation.Enabled = checkBoxCanCrit.Enabled = 
                    comboBoxDamageFormula.Enabled = !value;
                UpdateActualValueTextBox(100);
                TryClearCaller(100);
            }
        }

        public DamageCalculationControl()
        {
            InitializeComponent();

            info = new DamageCalculationInfo(0);
            foreach (var dt in Enum.GetNames<DamageType>())
            {
                comboBoxDamageType.Items.Add(dt);
            }
            foreach (var a in Enum.GetValues<AccuracyCalculation>())
            {
                comboBoxAccuracyCalculation.Items.Add(DamageCalculationInfo.GetAccuracyCalcDesctiption(a));
            }
            foreach (var d in Enum.GetValues<DamageFormulas>())
            {
                comboBoxDamageFormula.Items.Add(DamageCalculationInfo.GetFormulaDescription(d));
            }
        }

        public void Reload(byte actualValue, byte attackPower)
        {
            loaded = false;
            ActualValue = actualValue;
            AttackPower = attackPower;
        }

        private void UpdateActualValueTextBox(int caller)
        {
            if (mainCaller == caller)
            {
                editingTextBox = true;
                if (IsValid || IsNull)
                {
                    textBoxActualValue.Text = ActualValue.ToString("X2");
                }
                else
                {
                    textBoxActualValue.Text = "??";
                }
                editingTextBox = false;
            }
        }

        private void TrySetCaller(int caller)
        {
            if (loaded && mainCaller == -1)
            {
                mainCaller = caller;
            }
        }

        private void TryClearCaller(int caller)
        {
            if (mainCaller == caller)
            {
                mainCaller = -1;
            }
        }

        private void comboBoxDamageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrySetCaller(1);
            info.DamageType = (DamageType)comboBoxDamageType.SelectedIndex;
            checkBoxCanCrit.Enabled = (DamageType == DamageType.Physical);
            if (!checkBoxCanCrit.Enabled ) { CanCrit = false; }
            UpdateActualValueTextBox(1);
            TryClearCaller(1);
        }

        private void comboBoxAccuracyCalculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrySetCaller(2);
            info.AccuracyCalculation = (AccuracyCalculation)comboBoxAccuracyCalculation.SelectedIndex;
            if (AccuracyCalculation >= AccuracyCalculation.HitChanceModTargetLevel)
            {
                DamageType = DamageType.Magical;
                CanCrit = false;
                comboBoxDamageType.Enabled = false;
            }
            else { comboBoxDamageType.Enabled = true; }
            UpdateActualValueTextBox(2);
            TryClearCaller(2);
        }

        private void checkBoxCanCrit_CheckedChanged(object sender, EventArgs e)
        {
            TrySetCaller(3);
            info.CanCrit = checkBoxCanCrit.Checked;
            if (CanCrit) { DamageType = DamageType.Physical; }
            UpdateActualValueTextBox(3);
            TryClearCaller(3);
        }

        private void comboBoxDamageFormula_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrySetCaller(4);
            info.DamageFormula = (DamageFormulas)comboBoxDamageFormula.SelectedIndex;
            if (info.IsSpecialFormula())
            {
                if (info.UsesModifier())
                {
                    DamageType = DamageType.Physical;
                    comboBoxDamageType.Enabled = false;
                }
                CanCrit = DamageType == DamageType.Physical;
                AccuracyCalculation = AccuracyCalculation.Normal;
                comboBoxAccuracyCalculation.Enabled = false;
                checkBoxCanCrit.Enabled = false;
            }
            else
            {
                comboBoxDamageType.Enabled = true;
                comboBoxAccuracyCalculation.Enabled = true;
                checkBoxCanCrit.Enabled = DamageType == DamageType.Physical;
            }
            UpdateActualValueTextBox(4);
            TryClearCaller(4);
        }

        private void checkBoxIsNull_CheckedChanged(object sender, EventArgs e)
        {
            IsNull = checkBoxIsNull.Checked;
        }

        private void textBoxActualValue_TextChanged(object sender, EventArgs e)
        {
            if (!editingTextBox)
            {
                if (textBoxActualValue.Text.Length == 2)
                {
                    var formatProvider = new CultureInfo("en-US");
                    byte value;
                    bool valid = byte.TryParse(textBoxActualValue.Text, NumberStyles.HexNumber,
                        formatProvider, out value);
                    if (valid)
                    {
                        TrySetCaller(5);
                        ActualValue = value;
                        valid = IsValid;
                        TryClearCaller(5);
                    }

                    //if data is incorrect, play an alert
                    if (!valid)
                    {
                        SystemSounds.Exclamation.Play();
                    }
                }
            }
        }
    }
}
