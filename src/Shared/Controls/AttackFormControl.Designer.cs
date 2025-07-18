namespace FF7Scarlet.Shared.Controls
{
    partial class AttackFormControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControlAttacks = new TabControl();
            tabPageAttacks1 = new TabPage();
            labelAttackId = new Label();
            checkBoxAttackIsLimit = new CheckBox();
            labelAttackHurtActionIndex = new Label();
            comboBoxAttackHurtActionIndex = new ComboBox();
            labelAttackAttackEffectID = new Label();
            elementsControlAttack = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            comboBoxAttackAttackEffectID = new ComboBox();
            labelAttackImpactEffectID = new Label();
            comboBoxAttackImpactEffectID = new ComboBox();
            textBoxAttackDescription = new TextBox();
            damageCalculationControlAttack = new FF7Scarlet.KernelEditor.Controls.DamageCalculationControl();
            labelAttackCamMovementIDMulti = new Label();
            labelAttackName = new Label();
            comboBoxAttackCamMovementIDMulti = new ComboBox();
            textBoxAttackName = new TextBox();
            labelAttackCamMovementIDSingle = new Label();
            labelAttackDescription = new Label();
            comboBoxAttackCamMovementIDSingle = new ComboBox();
            labelSummonText = new Label();
            numericAttackAttackPercent = new NumericUpDown();
            textBoxSummonText = new TextBox();
            labelAttackAttackPercent = new Label();
            labelAttackMPCost = new Label();
            numericAttackMPCost = new NumericUpDown();
            tabPageAttacks2 = new TabPage();
            specialAttackFlagsControlAttack = new SpecialAttackFlagsControl();
            numericAttackStatusChangeChance = new NumericUpDown();
            comboBoxAttackConditionSubMenu = new ComboBox();
            labelAttackStatusChangeChance = new Label();
            comboBoxAttackStatusChange = new ComboBox();
            labelAttackConditionSubMenu = new Label();
            labelAttackStatusChange = new Label();
            statusesControlAttack = new FF7Scarlet.KernelEditor.Controls.StatusesControl();
            tabPageAttacks3 = new TabPage();
            buttonMagicOrder = new Button();
            comboBoxMagicType = new ComboBox();
            labelMagicType = new Label();
            targetDataControlAttack = new FF7Scarlet.KernelEditor.Controls.TargetDataControl();
            groupBoxAttackSpecialActions = new GroupBox();
            buttonAttackSyncAll = new Button();
            checkBoxAttackSyncWithSceneBin = new CheckBox();
            tabControlAttacks.SuspendLayout();
            tabPageAttacks1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackAttackPercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAttackMPCost).BeginInit();
            tabPageAttacks2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackStatusChangeChance).BeginInit();
            tabPageAttacks3.SuspendLayout();
            groupBoxAttackSpecialActions.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlAttacks
            // 
            tabControlAttacks.Controls.Add(tabPageAttacks1);
            tabControlAttacks.Controls.Add(tabPageAttacks2);
            tabControlAttacks.Controls.Add(tabPageAttacks3);
            tabControlAttacks.Dock = DockStyle.Fill;
            tabControlAttacks.Location = new Point(0, 0);
            tabControlAttacks.Name = "tabControlAttacks";
            tabControlAttacks.SelectedIndex = 0;
            tabControlAttacks.Size = new Size(580, 450);
            tabControlAttacks.TabIndex = 38;
            // 
            // tabPageAttacks1
            // 
            tabPageAttacks1.Controls.Add(labelAttackId);
            tabPageAttacks1.Controls.Add(checkBoxAttackIsLimit);
            tabPageAttacks1.Controls.Add(labelAttackHurtActionIndex);
            tabPageAttacks1.Controls.Add(comboBoxAttackHurtActionIndex);
            tabPageAttacks1.Controls.Add(labelAttackAttackEffectID);
            tabPageAttacks1.Controls.Add(elementsControlAttack);
            tabPageAttacks1.Controls.Add(comboBoxAttackAttackEffectID);
            tabPageAttacks1.Controls.Add(labelAttackImpactEffectID);
            tabPageAttacks1.Controls.Add(comboBoxAttackImpactEffectID);
            tabPageAttacks1.Controls.Add(textBoxAttackDescription);
            tabPageAttacks1.Controls.Add(damageCalculationControlAttack);
            tabPageAttacks1.Controls.Add(labelAttackCamMovementIDMulti);
            tabPageAttacks1.Controls.Add(labelAttackName);
            tabPageAttacks1.Controls.Add(comboBoxAttackCamMovementIDMulti);
            tabPageAttacks1.Controls.Add(textBoxAttackName);
            tabPageAttacks1.Controls.Add(labelAttackCamMovementIDSingle);
            tabPageAttacks1.Controls.Add(labelAttackDescription);
            tabPageAttacks1.Controls.Add(comboBoxAttackCamMovementIDSingle);
            tabPageAttacks1.Controls.Add(labelSummonText);
            tabPageAttacks1.Controls.Add(numericAttackAttackPercent);
            tabPageAttacks1.Controls.Add(textBoxSummonText);
            tabPageAttacks1.Controls.Add(labelAttackAttackPercent);
            tabPageAttacks1.Controls.Add(labelAttackMPCost);
            tabPageAttacks1.Controls.Add(numericAttackMPCost);
            tabPageAttacks1.Location = new Point(4, 24);
            tabPageAttacks1.Name = "tabPageAttacks1";
            tabPageAttacks1.Padding = new Padding(3);
            tabPageAttacks1.Size = new Size(572, 422);
            tabPageAttacks1.TabIndex = 0;
            tabPageAttacks1.Text = "Page 1";
            tabPageAttacks1.UseVisualStyleBackColor = true;
            // 
            // labelAttackId
            // 
            labelAttackId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAttackId.Location = new Point(504, 6);
            labelAttackId.Name = "labelAttackId";
            labelAttackId.Size = new Size(62, 15);
            labelAttackId.TabIndex = 44;
            labelAttackId.Text = "ID: ??";
            labelAttackId.TextAlign = ContentAlignment.TopRight;
            // 
            // checkBoxAttackIsLimit
            // 
            checkBoxAttackIsLimit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxAttackIsLimit.AutoSize = true;
            checkBoxAttackIsLimit.Location = new Point(504, 70);
            checkBoxAttackIsLimit.Name = "checkBoxAttackIsLimit";
            checkBoxAttackIsLimit.Size = new Size(61, 19);
            checkBoxAttackIsLimit.TabIndex = 43;
            checkBoxAttackIsLimit.Text = "Is limit";
            checkBoxAttackIsLimit.UseVisualStyleBackColor = true;
            checkBoxAttackIsLimit.CheckedChanged += checkBoxAttackIsLimit_CheckedChanged;
            // 
            // labelAttackHurtActionIndex
            // 
            labelAttackHurtActionIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAttackHurtActionIndex.AutoSize = true;
            labelAttackHurtActionIndex.Location = new Point(413, 230);
            labelAttackHurtActionIndex.Name = "labelAttackHurtActionIndex";
            labelAttackHurtActionIndex.Size = new Size(102, 15);
            labelAttackHurtActionIndex.TabIndex = 42;
            labelAttackHurtActionIndex.Text = "Hurt action index:";
            // 
            // comboBoxAttackHurtActionIndex
            // 
            comboBoxAttackHurtActionIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxAttackHurtActionIndex.FormattingEnabled = true;
            comboBoxAttackHurtActionIndex.Location = new Point(413, 248);
            comboBoxAttackHurtActionIndex.MaxLength = 2;
            comboBoxAttackHurtActionIndex.Name = "comboBoxAttackHurtActionIndex";
            comboBoxAttackHurtActionIndex.Size = new Size(152, 23);
            comboBoxAttackHurtActionIndex.TabIndex = 41;
            comboBoxAttackHurtActionIndex.TextChanged += comboBoxAttackHurtActionIndex_TextChanged;
            // 
            // labelAttackAttackEffectID
            // 
            labelAttackAttackEffectID.AutoSize = true;
            labelAttackAttackEffectID.Location = new Point(222, 97);
            labelAttackAttackEffectID.Name = "labelAttackAttackEffectID";
            labelAttackAttackEffectID.Size = new Size(91, 15);
            labelAttackAttackEffectID.TabIndex = 40;
            labelAttackAttackEffectID.Text = "Attack effect ID:";
            // 
            // elementsControlAttack
            // 
            elementsControlAttack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            elementsControlAttack.Location = new Point(7, 141);
            elementsControlAttack.MinimumSize = new Size(370, 130);
            elementsControlAttack.Name = "elementsControlAttack";
            elementsControlAttack.Size = new Size(400, 130);
            elementsControlAttack.TabIndex = 0;
            elementsControlAttack.ElementsChanged += ValueChanged;
            // 
            // comboBoxAttackAttackEffectID
            // 
            comboBoxAttackAttackEffectID.FormattingEnabled = true;
            comboBoxAttackAttackEffectID.Location = new Point(219, 112);
            comboBoxAttackAttackEffectID.MaxLength = 2;
            comboBoxAttackAttackEffectID.Name = "comboBoxAttackAttackEffectID";
            comboBoxAttackAttackEffectID.Size = new Size(100, 23);
            comboBoxAttackAttackEffectID.TabIndex = 39;
            comboBoxAttackAttackEffectID.TextChanged += ValueChanged;
            // 
            // labelAttackImpactEffectID
            // 
            labelAttackImpactEffectID.AutoSize = true;
            labelAttackImpactEffectID.Location = new Point(328, 97);
            labelAttackImpactEffectID.Name = "labelAttackImpactEffectID";
            labelAttackImpactEffectID.Size = new Size(94, 15);
            labelAttackImpactEffectID.TabIndex = 38;
            labelAttackImpactEffectID.Text = "Impact effect ID:";
            // 
            // comboBoxAttackImpactEffectID
            // 
            comboBoxAttackImpactEffectID.FormattingEnabled = true;
            comboBoxAttackImpactEffectID.Location = new Point(325, 112);
            comboBoxAttackImpactEffectID.MaxLength = 2;
            comboBoxAttackImpactEffectID.Name = "comboBoxAttackImpactEffectID";
            comboBoxAttackImpactEffectID.Size = new Size(100, 23);
            comboBoxAttackImpactEffectID.TabIndex = 37;
            comboBoxAttackImpactEffectID.TextChanged += comboBoxAttackImpactEffectID_TextChanged;
            // 
            // textBoxAttackDescription
            // 
            textBoxAttackDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAttackDescription.Location = new Point(7, 68);
            textBoxAttackDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxAttackDescription.Name = "textBoxAttackDescription";
            textBoxAttackDescription.Size = new Size(490, 23);
            textBoxAttackDescription.TabIndex = 4;
            textBoxAttackDescription.TextChanged += textBoxAttackDescription_TextChanged;
            // 
            // damageCalculationControlAttack
            // 
            damageCalculationControlAttack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            damageCalculationControlAttack.Location = new Point(9, 277);
            damageCalculationControlAttack.Name = "damageCalculationControlAttack";
            damageCalculationControlAttack.Size = new Size(557, 140);
            damageCalculationControlAttack.TabIndex = 36;
            damageCalculationControlAttack.DataChanged += ValueChanged;
            // 
            // labelAttackCamMovementIDMulti
            // 
            labelAttackCamMovementIDMulti.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAttackCamMovementIDMulti.AutoSize = true;
            labelAttackCamMovementIDMulti.Location = new Point(413, 186);
            labelAttackCamMovementIDMulti.Name = "labelAttackCamMovementIDMulti";
            labelAttackCamMovementIDMulti.Size = new Size(149, 15);
            labelAttackCamMovementIDMulti.TabIndex = 35;
            labelAttackCamMovementIDMulti.Text = "Cam movement ID (multi):";
            // 
            // labelAttackName
            // 
            labelAttackName.AutoSize = true;
            labelAttackName.Location = new Point(7, 6);
            labelAttackName.Margin = new Padding(4, 0, 4, 0);
            labelAttackName.Name = "labelAttackName";
            labelAttackName.Size = new Size(42, 15);
            labelAttackName.TabIndex = 1;
            labelAttackName.Text = "Name:";
            // 
            // comboBoxAttackCamMovementIDMulti
            // 
            comboBoxAttackCamMovementIDMulti.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxAttackCamMovementIDMulti.FormattingEnabled = true;
            comboBoxAttackCamMovementIDMulti.Location = new Point(413, 204);
            comboBoxAttackCamMovementIDMulti.MaxLength = 4;
            comboBoxAttackCamMovementIDMulti.Name = "comboBoxAttackCamMovementIDMulti";
            comboBoxAttackCamMovementIDMulti.Size = new Size(152, 23);
            comboBoxAttackCamMovementIDMulti.TabIndex = 36;
            comboBoxAttackCamMovementIDMulti.TextChanged += ValueChanged;
            // 
            // textBoxAttackName
            // 
            textBoxAttackName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAttackName.Location = new Point(7, 24);
            textBoxAttackName.Margin = new Padding(4, 3, 4, 3);
            textBoxAttackName.Name = "textBoxAttackName";
            textBoxAttackName.Size = new Size(226, 23);
            textBoxAttackName.TabIndex = 2;
            textBoxAttackName.TextChanged += textBoxAttackName_TextChanged;
            // 
            // labelAttackCamMovementIDSingle
            // 
            labelAttackCamMovementIDSingle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAttackCamMovementIDSingle.AutoSize = true;
            labelAttackCamMovementIDSingle.Location = new Point(413, 142);
            labelAttackCamMovementIDSingle.Name = "labelAttackCamMovementIDSingle";
            labelAttackCamMovementIDSingle.Size = new Size(152, 15);
            labelAttackCamMovementIDSingle.TabIndex = 33;
            labelAttackCamMovementIDSingle.Text = "Cam movement ID (single):";
            // 
            // labelAttackDescription
            // 
            labelAttackDescription.AutoSize = true;
            labelAttackDescription.Location = new Point(7, 50);
            labelAttackDescription.Margin = new Padding(4, 0, 4, 0);
            labelAttackDescription.Name = "labelAttackDescription";
            labelAttackDescription.Size = new Size(70, 15);
            labelAttackDescription.TabIndex = 3;
            labelAttackDescription.Text = "Description:";
            // 
            // comboBoxAttackCamMovementIDSingle
            // 
            comboBoxAttackCamMovementIDSingle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxAttackCamMovementIDSingle.FormattingEnabled = true;
            comboBoxAttackCamMovementIDSingle.Location = new Point(413, 160);
            comboBoxAttackCamMovementIDSingle.MaxLength = 4;
            comboBoxAttackCamMovementIDSingle.Name = "comboBoxAttackCamMovementIDSingle";
            comboBoxAttackCamMovementIDSingle.Size = new Size(152, 23);
            comboBoxAttackCamMovementIDSingle.TabIndex = 34;
            comboBoxAttackCamMovementIDSingle.TextChanged += ValueChanged;
            // 
            // labelSummonText
            // 
            labelSummonText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelSummonText.AutoSize = true;
            labelSummonText.Location = new Point(241, 6);
            labelSummonText.Margin = new Padding(4, 0, 4, 0);
            labelSummonText.Name = "labelSummonText";
            labelSummonText.Size = new Size(127, 15);
            labelSummonText.TabIndex = 5;
            labelSummonText.Text = "Summon attack name:";
            // 
            // numericAttackAttackPercent
            // 
            numericAttackAttackPercent.Location = new Point(7, 112);
            numericAttackAttackPercent.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericAttackAttackPercent.Name = "numericAttackAttackPercent";
            numericAttackAttackPercent.Size = new Size(100, 23);
            numericAttackAttackPercent.TabIndex = 10;
            numericAttackAttackPercent.ValueChanged += ValueChanged;
            // 
            // textBoxSummonText
            // 
            textBoxSummonText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxSummonText.Enabled = false;
            textBoxSummonText.Location = new Point(241, 24);
            textBoxSummonText.Margin = new Padding(4, 3, 4, 3);
            textBoxSummonText.Name = "textBoxSummonText";
            textBoxSummonText.Size = new Size(256, 23);
            textBoxSummonText.TabIndex = 6;
            textBoxSummonText.TextChanged += textBoxSummonText_TextChanged;
            // 
            // labelAttackAttackPercent
            // 
            labelAttackAttackPercent.AutoSize = true;
            labelAttackAttackPercent.Location = new Point(10, 97);
            labelAttackAttackPercent.Name = "labelAttackAttackPercent";
            labelAttackAttackPercent.Size = new Size(54, 15);
            labelAttackAttackPercent.TabIndex = 9;
            labelAttackAttackPercent.Text = "Attack%:";
            // 
            // labelAttackMPCost
            // 
            labelAttackMPCost.AutoSize = true;
            labelAttackMPCost.Location = new Point(116, 97);
            labelAttackMPCost.Name = "labelAttackMPCost";
            labelAttackMPCost.Size = new Size(53, 15);
            labelAttackMPCost.TabIndex = 7;
            labelAttackMPCost.Text = "MP cost:";
            // 
            // numericAttackMPCost
            // 
            numericAttackMPCost.Location = new Point(113, 112);
            numericAttackMPCost.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericAttackMPCost.Name = "numericAttackMPCost";
            numericAttackMPCost.Size = new Size(100, 23);
            numericAttackMPCost.TabIndex = 8;
            numericAttackMPCost.ValueChanged += ValueChanged;
            // 
            // tabPageAttacks2
            // 
            tabPageAttacks2.Controls.Add(specialAttackFlagsControlAttack);
            tabPageAttacks2.Controls.Add(numericAttackStatusChangeChance);
            tabPageAttacks2.Controls.Add(comboBoxAttackConditionSubMenu);
            tabPageAttacks2.Controls.Add(labelAttackStatusChangeChance);
            tabPageAttacks2.Controls.Add(comboBoxAttackStatusChange);
            tabPageAttacks2.Controls.Add(labelAttackConditionSubMenu);
            tabPageAttacks2.Controls.Add(labelAttackStatusChange);
            tabPageAttacks2.Controls.Add(statusesControlAttack);
            tabPageAttacks2.Location = new Point(4, 24);
            tabPageAttacks2.Name = "tabPageAttacks2";
            tabPageAttacks2.Padding = new Padding(3);
            tabPageAttacks2.Size = new Size(572, 422);
            tabPageAttacks2.TabIndex = 1;
            tabPageAttacks2.Text = "Page 2";
            tabPageAttacks2.UseVisualStyleBackColor = true;
            // 
            // specialAttackFlagsControlAttack
            // 
            specialAttackFlagsControlAttack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            specialAttackFlagsControlAttack.Location = new Point(9, 9);
            specialAttackFlagsControlAttack.Name = "specialAttackFlagsControlAttack";
            specialAttackFlagsControlAttack.Size = new Size(577, 100);
            specialAttackFlagsControlAttack.TabIndex = 43;
            specialAttackFlagsControlAttack.FlagsChanged += ValueChanged;
            // 
            // numericAttackStatusChangeChance
            // 
            numericAttackStatusChangeChance.Location = new Point(149, 333);
            numericAttackStatusChangeChance.Maximum = new decimal(new int[] { 63, 0, 0, 0 });
            numericAttackStatusChangeChance.Name = "numericAttackStatusChangeChance";
            numericAttackStatusChangeChance.Size = new Size(108, 23);
            numericAttackStatusChangeChance.TabIndex = 5;
            numericAttackStatusChangeChance.ValueChanged += numericAttackStatusChangeChance_ValueChanged;
            // 
            // comboBoxAttackConditionSubMenu
            // 
            comboBoxAttackConditionSubMenu.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAttackConditionSubMenu.FormattingEnabled = true;
            comboBoxAttackConditionSubMenu.Location = new Point(6, 377);
            comboBoxAttackConditionSubMenu.Name = "comboBoxAttackConditionSubMenu";
            comboBoxAttackConditionSubMenu.Size = new Size(251, 23);
            comboBoxAttackConditionSubMenu.TabIndex = 44;
            comboBoxAttackConditionSubMenu.SelectedIndexChanged += ValueChanged;
            // 
            // labelAttackStatusChangeChance
            // 
            labelAttackStatusChangeChance.AutoSize = true;
            labelAttackStatusChangeChance.Location = new Point(149, 318);
            labelAttackStatusChangeChance.Name = "labelAttackStatusChangeChance";
            labelAttackStatusChangeChance.Size = new Size(108, 15);
            labelAttackStatusChangeChance.TabIndex = 4;
            labelAttackStatusChangeChance.Text = "Chance (out of 63):";
            // 
            // comboBoxAttackStatusChange
            // 
            comboBoxAttackStatusChange.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAttackStatusChange.FormattingEnabled = true;
            comboBoxAttackStatusChange.Location = new Point(6, 333);
            comboBoxAttackStatusChange.Name = "comboBoxAttackStatusChange";
            comboBoxAttackStatusChange.Size = new Size(137, 23);
            comboBoxAttackStatusChange.TabIndex = 3;
            comboBoxAttackStatusChange.SelectedIndexChanged += comboBoxStatusChange_SelectedIndexChanged;
            // 
            // labelAttackConditionSubMenu
            // 
            labelAttackConditionSubMenu.AutoSize = true;
            labelAttackConditionSubMenu.Location = new Point(9, 362);
            labelAttackConditionSubMenu.Name = "labelAttackConditionSubMenu";
            labelAttackConditionSubMenu.Size = new Size(121, 15);
            labelAttackConditionSubMenu.TabIndex = 43;
            labelAttackConditionSubMenu.Text = "Condition sub-menu:";
            // 
            // labelAttackStatusChange
            // 
            labelAttackStatusChange.AutoSize = true;
            labelAttackStatusChange.Location = new Point(9, 318);
            labelAttackStatusChange.Name = "labelAttackStatusChange";
            labelAttackStatusChange.Size = new Size(84, 15);
            labelAttackStatusChange.TabIndex = 2;
            labelAttackStatusChange.Text = "Status change:";
            // 
            // statusesControlAttack
            // 
            statusesControlAttack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusesControlAttack.Location = new Point(9, 115);
            statusesControlAttack.MinimumSize = new Size(380, 200);
            statusesControlAttack.Name = "statusesControlAttack";
            statusesControlAttack.Size = new Size(577, 200);
            statusesControlAttack.TabIndex = 1;
            statusesControlAttack.StatusesChanged += ValueChanged;
            // 
            // tabPageAttacks3
            // 
            tabPageAttacks3.Controls.Add(buttonMagicOrder);
            tabPageAttacks3.Controls.Add(comboBoxMagicType);
            tabPageAttacks3.Controls.Add(labelMagicType);
            tabPageAttacks3.Controls.Add(targetDataControlAttack);
            tabPageAttacks3.Controls.Add(groupBoxAttackSpecialActions);
            tabPageAttacks3.Location = new Point(4, 24);
            tabPageAttacks3.Name = "tabPageAttacks3";
            tabPageAttacks3.Size = new Size(572, 422);
            tabPageAttacks3.TabIndex = 2;
            tabPageAttacks3.Text = "Page 3";
            tabPageAttacks3.UseVisualStyleBackColor = true;
            // 
            // buttonMagicOrder
            // 
            buttonMagicOrder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonMagicOrder.Location = new Point(329, 53);
            buttonMagicOrder.Name = "buttonMagicOrder";
            buttonMagicOrder.Size = new Size(240, 23);
            buttonMagicOrder.TabIndex = 48;
            buttonMagicOrder.Text = "Set magic order...";
            buttonMagicOrder.UseVisualStyleBackColor = true;
            buttonMagicOrder.Click += buttonMagicOrder_Click;
            // 
            // comboBoxMagicType
            // 
            comboBoxMagicType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxMagicType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMagicType.FormattingEnabled = true;
            comboBoxMagicType.Location = new Point(329, 24);
            comboBoxMagicType.Name = "comboBoxMagicType";
            comboBoxMagicType.Size = new Size(240, 23);
            comboBoxMagicType.TabIndex = 47;
            comboBoxMagicType.SelectedIndexChanged += comboBoxMagicType_SelectedIndexChanged;
            // 
            // labelMagicType
            // 
            labelMagicType.AutoSize = true;
            labelMagicType.Location = new Point(329, 6);
            labelMagicType.Name = "labelMagicType";
            labelMagicType.Size = new Size(69, 15);
            labelMagicType.TabIndex = 46;
            labelMagicType.Text = "Magic type:";
            // 
            // targetDataControlAttack
            // 
            targetDataControlAttack.Location = new Point(6, 6);
            targetDataControlAttack.Name = "targetDataControlAttack";
            targetDataControlAttack.Size = new Size(317, 125);
            targetDataControlAttack.TabIndex = 0;
            targetDataControlAttack.FlagsChanged += ValueChanged;
            // 
            // groupBoxAttackSpecialActions
            // 
            groupBoxAttackSpecialActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAttackSpecialActions.Controls.Add(buttonAttackSyncAll);
            groupBoxAttackSpecialActions.Controls.Add(checkBoxAttackSyncWithSceneBin);
            groupBoxAttackSpecialActions.Enabled = false;
            groupBoxAttackSpecialActions.Location = new Point(6, 137);
            groupBoxAttackSpecialActions.Name = "groupBoxAttackSpecialActions";
            groupBoxAttackSpecialActions.Size = new Size(563, 50);
            groupBoxAttackSpecialActions.TabIndex = 45;
            groupBoxAttackSpecialActions.TabStop = false;
            groupBoxAttackSpecialActions.Text = "Special actions";
            groupBoxAttackSpecialActions.Visible = false;
            // 
            // buttonAttackSyncAll
            // 
            buttonAttackSyncAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAttackSyncAll.Location = new Point(183, 18);
            buttonAttackSyncAll.Name = "buttonAttackSyncAll";
            buttonAttackSyncAll.Size = new Size(374, 23);
            buttonAttackSyncAll.TabIndex = 1;
            buttonAttackSyncAll.Text = "Sync all";
            buttonAttackSyncAll.UseVisualStyleBackColor = true;
            buttonAttackSyncAll.Click += buttonAttackSyncAll_Click;
            // 
            // checkBoxAttackSyncWithSceneBin
            // 
            checkBoxAttackSyncWithSceneBin.AutoSize = true;
            checkBoxAttackSyncWithSceneBin.Location = new Point(6, 21);
            checkBoxAttackSyncWithSceneBin.Name = "checkBoxAttackSyncWithSceneBin";
            checkBoxAttackSyncWithSceneBin.Size = new Size(171, 19);
            checkBoxAttackSyncWithSceneBin.TabIndex = 0;
            checkBoxAttackSyncWithSceneBin.Text = "Keep synced with scene.bin";
            checkBoxAttackSyncWithSceneBin.UseVisualStyleBackColor = true;
            checkBoxAttackSyncWithSceneBin.CheckedChanged += checkBoxAttackSyncWithSceneBin_CheckedChanged;
            // 
            // AttackFormControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlAttacks);
            Name = "AttackFormControl";
            Size = new Size(580, 450);
            tabControlAttacks.ResumeLayout(false);
            tabPageAttacks1.ResumeLayout(false);
            tabPageAttacks1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackAttackPercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAttackMPCost).EndInit();
            tabPageAttacks2.ResumeLayout(false);
            tabPageAttacks2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackStatusChangeChance).EndInit();
            tabPageAttacks3.ResumeLayout(false);
            tabPageAttacks3.PerformLayout();
            groupBoxAttackSpecialActions.ResumeLayout(false);
            groupBoxAttackSpecialActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlAttacks;
        private TabPage tabPageAttacks1;
        private Label labelAttackId;
        private CheckBox checkBoxAttackIsLimit;
        private Label labelAttackHurtActionIndex;
        private ComboBox comboBoxAttackHurtActionIndex;
        private Label labelAttackAttackEffectID;
        private KernelEditor.Controls.ElementsControl elementsControlAttack;
        private ComboBox comboBoxAttackAttackEffectID;
        private Label labelAttackImpactEffectID;
        private ComboBox comboBoxAttackImpactEffectID;
        private TextBox textBoxAttackDescription;
        private KernelEditor.Controls.DamageCalculationControl damageCalculationControlAttack;
        private Label labelAttackCamMovementIDMulti;
        private Label labelAttackName;
        private ComboBox comboBoxAttackCamMovementIDMulti;
        private TextBox textBoxAttackName;
        private Label labelAttackCamMovementIDSingle;
        private Label labelAttackDescription;
        private ComboBox comboBoxAttackCamMovementIDSingle;
        private Label labelSummonText;
        private NumericUpDown numericAttackAttackPercent;
        private TextBox textBoxSummonText;
        private Label labelAttackAttackPercent;
        private Label labelAttackMPCost;
        private NumericUpDown numericAttackMPCost;
        private TabPage tabPageAttacks2;
        private SpecialAttackFlagsControl specialAttackFlagsControlAttack;
        private NumericUpDown numericAttackStatusChangeChance;
        private ComboBox comboBoxAttackConditionSubMenu;
        private Label labelAttackStatusChangeChance;
        private ComboBox comboBoxAttackStatusChange;
        private Label labelAttackConditionSubMenu;
        private Label labelAttackStatusChange;
        private KernelEditor.Controls.StatusesControl statusesControlAttack;
        private TabPage tabPageAttacks3;
        private Button buttonMagicOrder;
        private ComboBox comboBoxMagicType;
        private Label labelMagicType;
        private KernelEditor.Controls.TargetDataControl targetDataControlAttack;
        private GroupBox groupBoxAttackSpecialActions;
        private Button buttonAttackSyncAll;
        private CheckBox checkBoxAttackSyncWithSceneBin;
    }
}
