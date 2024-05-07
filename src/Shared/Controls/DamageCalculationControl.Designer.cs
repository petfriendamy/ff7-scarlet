namespace FF7Scarlet.KernelEditor.Controls
{
    partial class DamageCalculationControl
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
            groupBoxMain = new GroupBox();
            numericAttackPower = new NumericUpDown();
            checkBoxIsNull = new CheckBox();
            comboBoxDamageFormula = new ComboBox();
            labelDamageFormula = new Label();
            checkBoxCanCrit = new CheckBox();
            comboBoxAccuracyCalculation = new ComboBox();
            labelAccuracyCalculation = new Label();
            labelDamageType = new Label();
            comboBoxDamageType = new ComboBox();
            labelPower = new Label();
            textBoxActualValue = new TextBox();
            labelActualValue = new Label();
            groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackPower).BeginInit();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(numericAttackPower);
            groupBoxMain.Controls.Add(checkBoxIsNull);
            groupBoxMain.Controls.Add(comboBoxDamageFormula);
            groupBoxMain.Controls.Add(labelDamageFormula);
            groupBoxMain.Controls.Add(checkBoxCanCrit);
            groupBoxMain.Controls.Add(comboBoxAccuracyCalculation);
            groupBoxMain.Controls.Add(labelAccuracyCalculation);
            groupBoxMain.Controls.Add(labelDamageType);
            groupBoxMain.Controls.Add(comboBoxDamageType);
            groupBoxMain.Controls.Add(labelPower);
            groupBoxMain.Controls.Add(textBoxActualValue);
            groupBoxMain.Controls.Add(labelActualValue);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.MinimumSize = new Size(520, 140);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(520, 140);
            groupBoxMain.TabIndex = 0;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Damage formula";
            // 
            // numericAttackPower
            // 
            numericAttackPower.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numericAttackPower.Location = new Point(7, 66);
            numericAttackPower.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericAttackPower.Name = "numericAttackPower";
            numericAttackPower.Size = new Size(79, 23);
            numericAttackPower.TabIndex = 12;
            numericAttackPower.ValueChanged += numericAttackPower_ValueChanged;
            // 
            // checkBoxIsNull
            // 
            checkBoxIsNull.AutoSize = true;
            checkBoxIsNull.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBoxIsNull.Location = new Point(7, 22);
            checkBoxIsNull.Name = "checkBoxIsNull";
            checkBoxIsNull.Size = new Size(70, 19);
            checkBoxIsNull.TabIndex = 11;
            checkBoxIsNull.Text = "IS NULL";
            checkBoxIsNull.UseVisualStyleBackColor = true;
            checkBoxIsNull.CheckedChanged += checkBoxIsNull_CheckedChanged;
            // 
            // comboBoxDamageFormula
            // 
            comboBoxDamageFormula.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxDamageFormula.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDamageFormula.FormattingEnabled = true;
            comboBoxDamageFormula.Location = new Point(6, 110);
            comboBoxDamageFormula.Name = "comboBoxDamageFormula";
            comboBoxDamageFormula.Size = new Size(508, 23);
            comboBoxDamageFormula.TabIndex = 10;
            comboBoxDamageFormula.SelectedIndexChanged += comboBoxDamageFormula_SelectedIndexChanged;
            // 
            // labelDamageFormula
            // 
            labelDamageFormula.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDamageFormula.AutoSize = true;
            labelDamageFormula.Location = new Point(6, 92);
            labelDamageFormula.Name = "labelDamageFormula";
            labelDamageFormula.Size = new Size(99, 15);
            labelDamageFormula.TabIndex = 9;
            labelDamageFormula.Text = "Damage formula:";
            // 
            // checkBoxCanCrit
            // 
            checkBoxCanCrit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBoxCanCrit.AutoSize = true;
            checkBoxCanCrit.Location = new Point(412, 68);
            checkBoxCanCrit.Name = "checkBoxCanCrit";
            checkBoxCanCrit.Size = new Size(102, 19);
            checkBoxCanCrit.TabIndex = 8;
            checkBoxCanCrit.Text = "Can critical hit";
            checkBoxCanCrit.UseVisualStyleBackColor = true;
            checkBoxCanCrit.CheckedChanged += checkBoxCanCrit_CheckedChanged;
            // 
            // comboBoxAccuracyCalculation
            // 
            comboBoxAccuracyCalculation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxAccuracyCalculation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccuracyCalculation.FormattingEnabled = true;
            comboBoxAccuracyCalculation.Location = new Point(207, 66);
            comboBoxAccuracyCalculation.Name = "comboBoxAccuracyCalculation";
            comboBoxAccuracyCalculation.Size = new Size(199, 23);
            comboBoxAccuracyCalculation.TabIndex = 7;
            comboBoxAccuracyCalculation.SelectedIndexChanged += comboBoxAccuracyCalculation_SelectedIndexChanged;
            // 
            // labelAccuracyCalculation
            // 
            labelAccuracyCalculation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAccuracyCalculation.AutoSize = true;
            labelAccuracyCalculation.Location = new Point(207, 48);
            labelAccuracyCalculation.Name = "labelAccuracyCalculation";
            labelAccuracyCalculation.Size = new Size(120, 15);
            labelAccuracyCalculation.TabIndex = 6;
            labelAccuracyCalculation.Text = "Accuracy calculation:";
            // 
            // labelDamageType
            // 
            labelDamageType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDamageType.AutoSize = true;
            labelDamageType.Location = new Point(92, 48);
            labelDamageType.Name = "labelDamageType";
            labelDamageType.Size = new Size(80, 15);
            labelDamageType.TabIndex = 5;
            labelDamageType.Text = "Damage type:";
            // 
            // comboBoxDamageType
            // 
            comboBoxDamageType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxDamageType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDamageType.FormattingEnabled = true;
            comboBoxDamageType.Location = new Point(92, 66);
            comboBoxDamageType.Name = "comboBoxDamageType";
            comboBoxDamageType.Size = new Size(109, 23);
            comboBoxDamageType.TabIndex = 4;
            comboBoxDamageType.SelectedIndexChanged += comboBoxDamageType_SelectedIndexChanged;
            // 
            // labelPower
            // 
            labelPower.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelPower.AutoSize = true;
            labelPower.Location = new Point(6, 48);
            labelPower.Name = "labelPower";
            labelPower.Size = new Size(43, 15);
            labelPower.TabIndex = 2;
            labelPower.Text = "Power:";
            // 
            // textBoxActualValue
            // 
            textBoxActualValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxActualValue.Location = new Point(464, 20);
            textBoxActualValue.MaxLength = 2;
            textBoxActualValue.Name = "textBoxActualValue";
            textBoxActualValue.Size = new Size(50, 23);
            textBoxActualValue.TabIndex = 1;
            textBoxActualValue.TextChanged += textBoxActualValue_TextChanged;
            // 
            // labelActualValue
            // 
            labelActualValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelActualValue.AutoSize = true;
            labelActualValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelActualValue.Location = new Point(383, 23);
            labelActualValue.Name = "labelActualValue";
            labelActualValue.Size = new Size(78, 15);
            labelActualValue.TabIndex = 0;
            labelActualValue.Text = "Actual value:";
            // 
            // DamageCalculationControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            DoubleBuffered = true;
            Name = "DamageCalculationControl";
            Size = new Size(520, 140);
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackPower).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private TextBox textBoxActualValue;
        private Label labelActualValue;
        private Label labelDamageType;
        private ComboBox comboBoxDamageType;
        private Label labelPower;
        private ComboBox comboBoxAccuracyCalculation;
        private Label labelAccuracyCalculation;
        private CheckBox checkBoxCanCrit;
        private ComboBox comboBoxDamageFormula;
        private Label labelDamageFormula;
        private CheckBox checkBoxIsNull;
        private NumericUpDown numericAttackPower;
    }
}
