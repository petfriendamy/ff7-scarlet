namespace FF7Scarlet.KernelEditor
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
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.checkBoxIsNull = new System.Windows.Forms.CheckBox();
            this.comboBoxDamageFormula = new System.Windows.Forms.ComboBox();
            this.labelDamageFormula = new System.Windows.Forms.Label();
            this.checkBoxCanCrit = new System.Windows.Forms.CheckBox();
            this.comboBoxAccuracyCalculation = new System.Windows.Forms.ComboBox();
            this.labelAccuracyCalculation = new System.Windows.Forms.Label();
            this.labelDamageType = new System.Windows.Forms.Label();
            this.comboBoxDamageType = new System.Windows.Forms.ComboBox();
            this.labelPower = new System.Windows.Forms.Label();
            this.textBoxActualValue = new System.Windows.Forms.TextBox();
            this.labelActualValue = new System.Windows.Forms.Label();
            this.numericAttackPower = new System.Windows.Forms.NumericUpDown();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackPower)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.numericAttackPower);
            this.groupBoxMain.Controls.Add(this.checkBoxIsNull);
            this.groupBoxMain.Controls.Add(this.comboBoxDamageFormula);
            this.groupBoxMain.Controls.Add(this.labelDamageFormula);
            this.groupBoxMain.Controls.Add(this.checkBoxCanCrit);
            this.groupBoxMain.Controls.Add(this.comboBoxAccuracyCalculation);
            this.groupBoxMain.Controls.Add(this.labelAccuracyCalculation);
            this.groupBoxMain.Controls.Add(this.labelDamageType);
            this.groupBoxMain.Controls.Add(this.comboBoxDamageType);
            this.groupBoxMain.Controls.Add(this.labelPower);
            this.groupBoxMain.Controls.Add(this.textBoxActualValue);
            this.groupBoxMain.Controls.Add(this.labelActualValue);
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMain.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMain.MinimumSize = new System.Drawing.Size(520, 140);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(520, 140);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Damage formula";
            // 
            // checkBoxIsNull
            // 
            this.checkBoxIsNull.AutoSize = true;
            this.checkBoxIsNull.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsNull.Location = new System.Drawing.Point(7, 22);
            this.checkBoxIsNull.Name = "checkBoxIsNull";
            this.checkBoxIsNull.Size = new System.Drawing.Size(70, 19);
            this.checkBoxIsNull.TabIndex = 11;
            this.checkBoxIsNull.Text = "IS NULL";
            this.checkBoxIsNull.UseVisualStyleBackColor = true;
            this.checkBoxIsNull.CheckedChanged += new System.EventHandler(this.checkBoxIsNull_CheckedChanged);
            // 
            // comboBoxDamageFormula
            // 
            this.comboBoxDamageFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDamageFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDamageFormula.FormattingEnabled = true;
            this.comboBoxDamageFormula.Location = new System.Drawing.Point(6, 110);
            this.comboBoxDamageFormula.Name = "comboBoxDamageFormula";
            this.comboBoxDamageFormula.Size = new System.Drawing.Size(508, 23);
            this.comboBoxDamageFormula.TabIndex = 10;
            this.comboBoxDamageFormula.SelectedIndexChanged += new System.EventHandler(this.comboBoxDamageFormula_SelectedIndexChanged);
            // 
            // labelDamageFormula
            // 
            this.labelDamageFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDamageFormula.AutoSize = true;
            this.labelDamageFormula.Location = new System.Drawing.Point(6, 92);
            this.labelDamageFormula.Name = "labelDamageFormula";
            this.labelDamageFormula.Size = new System.Drawing.Size(99, 15);
            this.labelDamageFormula.TabIndex = 9;
            this.labelDamageFormula.Text = "Damage formula:";
            // 
            // checkBoxCanCrit
            // 
            this.checkBoxCanCrit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCanCrit.AutoSize = true;
            this.checkBoxCanCrit.Location = new System.Drawing.Point(412, 68);
            this.checkBoxCanCrit.Name = "checkBoxCanCrit";
            this.checkBoxCanCrit.Size = new System.Drawing.Size(102, 19);
            this.checkBoxCanCrit.TabIndex = 8;
            this.checkBoxCanCrit.Text = "Can critical hit";
            this.checkBoxCanCrit.UseVisualStyleBackColor = true;
            this.checkBoxCanCrit.CheckedChanged += new System.EventHandler(this.checkBoxCanCrit_CheckedChanged);
            // 
            // comboBoxAccuracyCalculation
            // 
            this.comboBoxAccuracyCalculation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAccuracyCalculation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccuracyCalculation.FormattingEnabled = true;
            this.comboBoxAccuracyCalculation.Location = new System.Drawing.Point(207, 66);
            this.comboBoxAccuracyCalculation.Name = "comboBoxAccuracyCalculation";
            this.comboBoxAccuracyCalculation.Size = new System.Drawing.Size(199, 23);
            this.comboBoxAccuracyCalculation.TabIndex = 7;
            this.comboBoxAccuracyCalculation.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccuracyCalculation_SelectedIndexChanged);
            // 
            // labelAccuracyCalculation
            // 
            this.labelAccuracyCalculation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelAccuracyCalculation.AutoSize = true;
            this.labelAccuracyCalculation.Location = new System.Drawing.Point(207, 48);
            this.labelAccuracyCalculation.Name = "labelAccuracyCalculation";
            this.labelAccuracyCalculation.Size = new System.Drawing.Size(120, 15);
            this.labelAccuracyCalculation.TabIndex = 6;
            this.labelAccuracyCalculation.Text = "Accuracy calculation:";
            // 
            // labelDamageType
            // 
            this.labelDamageType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDamageType.AutoSize = true;
            this.labelDamageType.Location = new System.Drawing.Point(92, 48);
            this.labelDamageType.Name = "labelDamageType";
            this.labelDamageType.Size = new System.Drawing.Size(80, 15);
            this.labelDamageType.TabIndex = 5;
            this.labelDamageType.Text = "Damage type:";
            // 
            // comboBoxDamageType
            // 
            this.comboBoxDamageType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDamageType.FormattingEnabled = true;
            this.comboBoxDamageType.Location = new System.Drawing.Point(92, 66);
            this.comboBoxDamageType.Name = "comboBoxDamageType";
            this.comboBoxDamageType.Size = new System.Drawing.Size(109, 23);
            this.comboBoxDamageType.TabIndex = 4;
            this.comboBoxDamageType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDamageType_SelectedIndexChanged);
            // 
            // labelPower
            // 
            this.labelPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPower.AutoSize = true;
            this.labelPower.Location = new System.Drawing.Point(6, 48);
            this.labelPower.Name = "labelPower";
            this.labelPower.Size = new System.Drawing.Size(43, 15);
            this.labelPower.TabIndex = 2;
            this.labelPower.Text = "Power:";
            // 
            // textBoxActualValue
            // 
            this.textBoxActualValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxActualValue.Location = new System.Drawing.Point(464, 20);
            this.textBoxActualValue.MaxLength = 2;
            this.textBoxActualValue.Name = "textBoxActualValue";
            this.textBoxActualValue.Size = new System.Drawing.Size(50, 23);
            this.textBoxActualValue.TabIndex = 1;
            this.textBoxActualValue.TextChanged += new System.EventHandler(this.textBoxActualValue_TextChanged);
            // 
            // labelActualValue
            // 
            this.labelActualValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelActualValue.AutoSize = true;
            this.labelActualValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelActualValue.Location = new System.Drawing.Point(383, 23);
            this.labelActualValue.Name = "labelActualValue";
            this.labelActualValue.Size = new System.Drawing.Size(78, 15);
            this.labelActualValue.TabIndex = 0;
            this.labelActualValue.Text = "Actual value:";
            // 
            // numericAttackPower
            // 
            this.numericAttackPower.Location = new System.Drawing.Point(7, 66);
            this.numericAttackPower.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericAttackPower.Name = "numericAttackPower";
            this.numericAttackPower.Size = new System.Drawing.Size(79, 23);
            this.numericAttackPower.TabIndex = 12;
            // 
            // DamageCalculationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxMain);
            this.Name = "DamageCalculationControl";
            this.Size = new System.Drawing.Size(520, 140);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackPower)).EndInit();
            this.ResumeLayout(false);

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
