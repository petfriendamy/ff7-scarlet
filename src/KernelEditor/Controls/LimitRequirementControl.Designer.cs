namespace FF7Scarlet.KernelEditor.Controls
{
    partial class LimitRequirementControl
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
            numericHPDivisor = new NumericUpDown();
            labelHPDivisor = new Label();
            labelUses = new Label();
            numericUses = new NumericUpDown();
            labelKillRequirement = new Label();
            numericKillRequirement = new NumericUpDown();
            comboBoxLimit2 = new ComboBox();
            comboBoxLimit1 = new ComboBox();
            groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericHPDivisor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericKillRequirement).BeginInit();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(numericHPDivisor);
            groupBoxMain.Controls.Add(labelHPDivisor);
            groupBoxMain.Controls.Add(labelUses);
            groupBoxMain.Controls.Add(numericUses);
            groupBoxMain.Controls.Add(labelKillRequirement);
            groupBoxMain.Controls.Add(numericKillRequirement);
            groupBoxMain.Controls.Add(comboBoxLimit2);
            groupBoxMain.Controls.Add(comboBoxLimit1);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(400, 120);
            groupBoxMain.TabIndex = 3;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Limit level ?";
            // 
            // numericHPDivisor
            // 
            numericHPDivisor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericHPDivisor.Location = new Point(76, 80);
            numericHPDivisor.Name = "numericHPDivisor";
            numericHPDivisor.Size = new Size(187, 23);
            numericHPDivisor.TabIndex = 10;
            numericHPDivisor.ValueChanged += numericHPDivisor_ValueChanged;
            // 
            // labelHPDivisor
            // 
            labelHPDivisor.AutoSize = true;
            labelHPDivisor.Location = new Point(6, 82);
            labelHPDivisor.Name = "labelHPDivisor";
            labelHPDivisor.Size = new Size(64, 15);
            labelHPDivisor.TabIndex = 9;
            labelHPDivisor.Text = "HP divisor:";
            // 
            // labelUses
            // 
            labelUses.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelUses.AutoSize = true;
            labelUses.Location = new Point(269, 54);
            labelUses.Name = "labelUses";
            labelUses.Size = new Size(34, 15);
            labelUses.TabIndex = 8;
            labelUses.Text = "Uses:";
            // 
            // numericUses
            // 
            numericUses.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUses.Location = new Point(309, 52);
            numericUses.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUses.Name = "numericUses";
            numericUses.Size = new Size(85, 23);
            numericUses.TabIndex = 7;
            numericUses.ValueChanged += numericUses_ValueChanged;
            // 
            // labelKillRequirement
            // 
            labelKillRequirement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKillRequirement.AutoSize = true;
            labelKillRequirement.Location = new Point(272, 24);
            labelKillRequirement.Name = "labelKillRequirement";
            labelKillRequirement.Size = new Size(31, 15);
            labelKillRequirement.TabIndex = 4;
            labelKillRequirement.Text = "Kills:";
            // 
            // numericKillRequirement
            // 
            numericKillRequirement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericKillRequirement.Location = new Point(309, 22);
            numericKillRequirement.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericKillRequirement.Name = "numericKillRequirement";
            numericKillRequirement.Size = new Size(85, 23);
            numericKillRequirement.TabIndex = 3;
            numericKillRequirement.ValueChanged += numericKillRequirement_ValueChanged;
            // 
            // comboBoxLimit2
            // 
            comboBoxLimit2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxLimit2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLimit2.FormattingEnabled = true;
            comboBoxLimit2.Location = new Point(6, 51);
            comboBoxLimit2.Name = "comboBoxLimit2";
            comboBoxLimit2.Size = new Size(257, 23);
            comboBoxLimit2.TabIndex = 1;
            comboBoxLimit2.SelectedIndexChanged += comboBoxLimit2_SelectedIndexChanged;
            // 
            // comboBoxLimit1
            // 
            comboBoxLimit1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxLimit1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLimit1.FormattingEnabled = true;
            comboBoxLimit1.Location = new Point(6, 22);
            comboBoxLimit1.Name = "comboBoxLimit1";
            comboBoxLimit1.Size = new Size(257, 23);
            comboBoxLimit1.TabIndex = 0;
            comboBoxLimit1.SelectedIndexChanged += comboBoxLimit1_SelectedIndexChanged;
            // 
            // LimitRequirementControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            Name = "LimitRequirementControl";
            Size = new Size(400, 120);
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericHPDivisor).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUses).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericKillRequirement).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private ComboBox comboBoxLimit2;
        private ComboBox comboBoxLimit1;
        private NumericUpDown numericKillRequirement;
        private Label labelKillRequirement;
        private Label labelUses;
        private NumericUpDown numericUses;
        private NumericUpDown numericHPDivisor;
        private Label labelHPDivisor;
    }
}
