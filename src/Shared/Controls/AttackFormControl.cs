using FF7Scarlet.KernelEditor;
using FF7Scarlet.SceneEditor;
using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FF7Scarlet.Shared.Controls
{
    public partial class AttackFormControl : UserControl
    {
        public event EventHandler? DataChanged;
        public event EventHandler? NameChanged;
        public event EventHandler? DescriptionChanged;
        public event EventHandler? SummonTextChanged;
        public event EventHandler? ChangeIsLimit;
        public event EventHandler? ChangeMagicType;
        public event EventHandler? ChangeMagicOrder;
        public event EventHandler? ActivateSync;
        public event EventHandler? DeactivateSync;
        public event EventHandler? SyncAll;

        private Attack? attack;
        private bool nameEnabled = true;
        private bool descriptionEnabled = true;
        private bool loading;

        public string AttackName => textBoxAttackName.Text;
        public string AttackDescription => textBoxAttackDescription.Text;
        public string SummonText => textBoxSummonText.Text;
        public bool IsLimit => checkBoxAttackIsLimit.Checked;
        public SpellType SpellType => (SpellType)comboBoxMagicType.SelectedIndex;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NameEnabled
        {
            get { return nameEnabled; }
            set
            {
                nameEnabled = value;
                if (attack != null)
                {
                    textBoxAttackName.Enabled = value;
                    labelAttackName.Enabled = value;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DescriptionEnabled
        {
            get { return descriptionEnabled; }
            set
            {
                descriptionEnabled = value;
                if (attack != null)
                {
                    textBoxAttackDescription.Enabled = value;
                    labelAttackDescription.Enabled = value;
                }
            }
        }

        public AttackFormControl()
        {
            InitializeComponent();

            textBoxAttackName.MaxLength = Scene.NAME_LENGTH - 1;

            //status change
            comboBoxAttackStatusChange.Items.Add("None");
            foreach (var s in DataManager.StatusChangeTypes)
            {
                if (s != StatusChangeType.None)
                {
                    comboBoxAttackStatusChange.Items.Add(s);
                }
            }

            //spell types
            foreach (var t in Enum.GetNames<SpellType>())
            {
                comboBoxMagicType.Items.Add(StringParser.AddSpaces(t));
            }

            //condition sub-menu
            comboBoxAttackConditionSubMenu.Items.Add("None");
            foreach (var c in Enum.GetValues<AttackConditions>())
            {
                if (c != AttackConditions.None)
                {
                    comboBoxAttackConditionSubMenu.Items.Add(c);
                }
            }
            EnableOrDisableControls(false, false);
        }

        public void SetIsKernel(bool isKernel)
        {
            labelSummonText.Visible = isKernel;
            textBoxSummonText.Visible = isKernel;
            checkBoxAttackIsLimit.Visible = isKernel;
            labelMagicType.Visible = isKernel;
            comboBoxMagicType.Visible = isKernel;
            buttonMagicOrder.Visible = isKernel;
            //groupBoxAttackSpecialActions.Visible = isKernel;
        }

        public void UpdateForm(Attack attack, int id, bool isLimit = false, string? summonAttackName = null,
            SpellType spellType = SpellType.Unlisted, bool synced = false)
        {
            if (this.attack != null)
            {
                SyncAttackData(this.attack);
            }
            this.attack = attack;
            EnableOrDisableControls(true, true);
            loading = true;

            //page 1
            labelAttackId.Text = $"ID: {id:X2}";
            textBoxAttackName.Text = attack.Name;
            textBoxAttackDescription.Text = attack.Description;

            if (summonAttackName == null)
            {
                textBoxSummonText.Clear();
                textBoxSummonText.Enabled = false;
            }
            else
            {
                textBoxSummonText.Enabled = true;
                textBoxSummonText.Text = summonAttackName;
            }
            checkBoxAttackIsLimit.Checked = isLimit;
            numericAttackAttackPercent.Value = attack.AccuracyRate;
            numericAttackMPCost.Value = attack.MPCost;
            comboBoxAttackAttackEffectID.Text = attack.AttackEffectID.ToString("X2");
            comboBoxAttackImpactEffectID.Text = attack.ImpactEffectID.ToString("X2");
            elementsControlAttack.SetElements(attack.Elements);
            comboBoxAttackCamMovementIDSingle.Text = attack.CameraMovementIDSingle.ToString("X4");
            comboBoxAttackCamMovementIDMulti.Text = attack.CameraMovementIDMulti.ToString("X4");
            comboBoxAttackHurtActionIndex.Text = attack.TargetHurtActionIndex.ToString("X2");
            damageCalculationControlAttack.Reload(attack.DamageCalculationID, attack.AttackStrength);

            //page 2
            specialAttackFlagsControlAttack.SetFlags(attack.SpecialAttackFlags);
            statusesControlAttack.SetStatuses(attack.Statuses);
            var temp = DataManager.StatusChangeTypes.ToList();
            comboBoxAttackStatusChange.SelectedIndex = temp.IndexOf(attack.StatusChange.Type);
            statusesControlAttack.Enabled = numericAttackStatusChangeChance.Enabled =
                (attack.StatusChange.Type != StatusChangeType.None);
            numericAttackStatusChangeChance.Value = attack.StatusChange.Amount;
            if (attack.ConditionSubmenu == ConditionSubmenu.None)
            {
                comboBoxAttackConditionSubMenu.SelectedIndex = 0;
            }
            else
            {
                comboBoxAttackConditionSubMenu.SelectedIndex = (int)attack.ConditionSubmenu + 1;
            }

            //page 3
            targetDataControlAttack.SetTargetData(attack.TargetFlags);
            if (spellType == SpellType.Unlisted)
            {
                comboBoxMagicType.SelectedIndex = (int)SpellType.Unlisted;
                buttonMagicOrder.Enabled = false;
            }
            else
            {
                comboBoxMagicType.SelectedIndex = (int)spellType + 1;
                buttonMagicOrder.Enabled = true;
            }
            checkBoxAttackSyncWithSceneBin.Checked = synced;

            loading = false;
        }

        public void UpdateForm(Attack attack, int id, string name, string desc)
        {
            UpdateForm(attack, id);
            textBoxAttackName.Text = name;
            textBoxAttackDescription.Text = desc;
        }

        public void UpdateForm(int id, string name, string desc)
        {
            labelAttackId.Text = $"ID: {id:X2}";
            textBoxAttackName.Text = name;
            textBoxAttackDescription.Text = desc;
            EnableOrDisableControls(false, true);
        }

        public void UpdateSummonText(string text)
        {
            loading = true;
            textBoxSummonText.Text = text;
            loading = false;
        }

        public void EnableOrDisableControls(bool enable, bool ignore)
        {
            var ignoreList = new List<Control>();
            if (ignore)
            {
                if (!NameEnabled)
                {
                    ignoreList.Add(labelAttackName);
                    ignoreList.Add(textBoxAttackName);
                }
                if (!DescriptionEnabled)
                {
                    ignoreList.Add(labelAttackDescription);
                    ignoreList.Add(textBoxAttackDescription);
                }
                ignoreList.Add(statusesControlAttack);
            }

            foreach (TabPage tb in tabControlAttacks.TabPages)
            {
                FormFunctions.EnableOrDisableInner(tb, enable, ignoreList.AsReadOnly());
            }
        }

        public void SyncAttackData(Attack attack)
        {
            attack.AccuracyRate = (byte)numericAttackAttackPercent.Value;
            attack.MPCost = (ushort)numericAttackMPCost.Value;
            attack.TargetFlags = targetDataControlAttack.GetTargetData();
            attack.DamageCalculationID = damageCalculationControlAttack.ActualValue;
            attack.AttackStrength = damageCalculationControlAttack.AttackPower;
            if (comboBoxAttackConditionSubMenu.SelectedIndex == 0)
            {
                attack.ConditionSubmenu = ConditionSubmenu.None;
            }
            else
            {
                attack.ConditionSubmenu = (ConditionSubmenu)(comboBoxAttackConditionSubMenu.SelectedIndex - 1);
            }
            attack.Statuses = statusesControlAttack.GetStatuses();
            attack.Elements = elementsControlAttack.GetElements();
            attack.SpecialAttackFlags = specialAttackFlagsControlAttack.GetFlags();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                InvokeDataChanged(sender, e);
            }
        }

        private void textBoxAttackName_TextChanged(object sender, EventArgs e)
        {
            if (!loading && attack != null)
            {
                attack.Name = AttackName;
                InvokeNameChanged(sender, e);
            }
        }

        private void textBoxAttackDescription_TextChanged(object sender, EventArgs e)
        {
            if (!loading && attack != null)
            {
                attack.Description = AttackDescription;
                InvokeDescriptionChanged(sender, e);
            }
        }

        private void textBoxSummonText_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                InvokeSummonTextChanged(sender, e);
            }
        }

        private void checkBoxAttackIsLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                InvokeChangeIsLimit(sender, e);
            }
        }

        private void comboBoxStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = comboBoxAttackStatusChange.SelectedIndex;
                var status = DataManager.StatusChangeTypes[i];
                statusesControlAttack.Enabled = numericAttackStatusChangeChance.Enabled = 
                    (status != StatusChangeType.None);

                if (attack != null)
                {
                    attack.StatusChange.Type = status;
                }
                InvokeDataChanged(sender, e);
            }
        }

        private void comboBoxAttackImpactEffectID_TextChanged(object sender, EventArgs e)
        {
            if (!loading && attack != null)
            {
                var text = comboBoxAttackImpactEffectID.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        attack.ImpactEffectID = newID;
                        InvokeDataChanged(sender, e);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackHurtActionIndex_TextChanged(object sender, EventArgs e)
        {
            if (!loading && attack != null)
            {
                var text = comboBoxAttackHurtActionIndex.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        attack.TargetHurtActionIndex = newID;
                        InvokeDataChanged(sender, e);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void numericAttackStatusChangeChance_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && attack != null)
            {
                attack.StatusChange.Amount = (byte)numericAttackStatusChangeChance.Value;
                InvokeDataChanged(sender, e);
            }
        }

        private void comboBoxMagicType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvokeChangeMagicType(sender, e);
        }

        private void buttonMagicOrder_Click(object sender, EventArgs e)
        {
            InvokeChangeMagicOrder(sender, e);
        }

        private void checkBoxAttackSyncWithSceneBin_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (checkBoxAttackSyncWithSceneBin.Checked)
                {
                    InvokeActivateSync(sender, e);
                }
                else
                {
                    InvokeDectivateSync(sender, e);
                }
            }
        }

        private void buttonAttackSyncAll_Click(object sender, EventArgs e)
        {
            InvokeSyncAll(sender, e);
        }

        private void InvokeDataChanged(object? sender, EventArgs e)
        {
            DataChanged?.Invoke(sender, e);
        }

        private void InvokeNameChanged(object? sender, EventArgs e)
        {
            NameChanged?.Invoke(sender, e);
        }

        private void InvokeDescriptionChanged(object? sender, EventArgs e)
        {
            DescriptionChanged?.Invoke(sender, e);
        }

        private void InvokeSummonTextChanged(object? sender, EventArgs e)
        {
            SummonTextChanged?.Invoke(sender, e);
        }

        private void InvokeChangeIsLimit(object? sender, EventArgs e)
        {
            ChangeIsLimit?.Invoke(sender, e);
        }

        private void InvokeChangeMagicType(object? sender, EventArgs e)
        {
            ChangeMagicType?.Invoke(sender, e);
        }

        private void InvokeChangeMagicOrder(object? sender, EventArgs e)
        {
            ChangeMagicOrder?.Invoke(sender, e);
        }

        private void InvokeActivateSync(object? sender, EventArgs e)
        {
            ActivateSync?.Invoke(sender, e);
        }

        private void InvokeDectivateSync(object? sender, EventArgs e)
        {
            DeactivateSync?.Invoke(sender, e);
        }

        private void InvokeSyncAll(object? sender, EventArgs e)
        {
            SyncAll?.Invoke(sender, e);
        }
    }
}
