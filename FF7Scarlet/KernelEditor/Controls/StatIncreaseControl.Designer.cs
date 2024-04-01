namespace FF7Scarlet.KernelEditor.Controls
{
    partial class StatIncreaseControl
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
            numericStat4 = new NumericUpDown();
            comboBoxStat4 = new ComboBox();
            numericStat3 = new NumericUpDown();
            comboBoxStat3 = new ComboBox();
            numericStat2 = new NumericUpDown();
            comboBoxStat2 = new ComboBox();
            numericStat1 = new NumericUpDown();
            comboBoxStat1 = new ComboBox();
            groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericStat4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStat3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStat2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStat1).BeginInit();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(numericStat4);
            groupBoxMain.Controls.Add(comboBoxStat4);
            groupBoxMain.Controls.Add(numericStat3);
            groupBoxMain.Controls.Add(comboBoxStat3);
            groupBoxMain.Controls.Add(numericStat2);
            groupBoxMain.Controls.Add(comboBoxStat2);
            groupBoxMain.Controls.Add(numericStat1);
            groupBoxMain.Controls.Add(comboBoxStat1);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(250, 142);
            groupBoxMain.TabIndex = 35;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Stat increases";
            // 
            // numericStat4
            // 
            numericStat4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericStat4.Location = new Point(194, 109);
            numericStat4.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericStat4.Name = "numericStat4";
            numericStat4.Size = new Size(50, 23);
            numericStat4.TabIndex = 7;
            numericStat4.ValueChanged += control_ValueChanged;
            // 
            // comboBoxStat4
            // 
            comboBoxStat4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxStat4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStat4.FormattingEnabled = true;
            comboBoxStat4.Location = new Point(6, 109);
            comboBoxStat4.Name = "comboBoxStat4";
            comboBoxStat4.Size = new Size(182, 23);
            comboBoxStat4.TabIndex = 6;
            comboBoxStat4.SelectedIndexChanged += control_ValueChanged;
            // 
            // numericStat3
            // 
            numericStat3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericStat3.Location = new Point(194, 80);
            numericStat3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericStat3.Name = "numericStat3";
            numericStat3.Size = new Size(50, 23);
            numericStat3.TabIndex = 5;
            numericStat3.ValueChanged += control_ValueChanged;
            // 
            // comboBoxStat3
            // 
            comboBoxStat3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxStat3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStat3.FormattingEnabled = true;
            comboBoxStat3.Location = new Point(6, 80);
            comboBoxStat3.Name = "comboBoxStat3";
            comboBoxStat3.Size = new Size(182, 23);
            comboBoxStat3.TabIndex = 4;
            comboBoxStat3.SelectedIndexChanged += control_ValueChanged;
            // 
            // numericStat2
            // 
            numericStat2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericStat2.Location = new Point(194, 51);
            numericStat2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericStat2.Name = "numericStat2";
            numericStat2.Size = new Size(50, 23);
            numericStat2.TabIndex = 3;
            numericStat2.ValueChanged += control_ValueChanged;
            // 
            // comboBoxStat2
            // 
            comboBoxStat2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxStat2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStat2.FormattingEnabled = true;
            comboBoxStat2.Location = new Point(6, 51);
            comboBoxStat2.Name = "comboBoxStat2";
            comboBoxStat2.Size = new Size(182, 23);
            comboBoxStat2.TabIndex = 2;
            comboBoxStat2.SelectedIndexChanged += control_ValueChanged;
            // 
            // numericStat1
            // 
            numericStat1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericStat1.Location = new Point(194, 22);
            numericStat1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericStat1.Name = "numericStat1";
            numericStat1.Size = new Size(50, 23);
            numericStat1.TabIndex = 1;
            numericStat1.ValueChanged += control_ValueChanged;
            // 
            // comboBoxStat1
            // 
            comboBoxStat1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxStat1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStat1.FormattingEnabled = true;
            comboBoxStat1.Location = new Point(6, 22);
            comboBoxStat1.Name = "comboBoxStat1";
            comboBoxStat1.Size = new Size(182, 23);
            comboBoxStat1.TabIndex = 0;
            comboBoxStat1.SelectedIndexChanged += control_ValueChanged;
            // 
            // StatIncreaseControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            DoubleBuffered = true;
            Name = "StatIncreaseControl";
            Size = new Size(250, 142);
            groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericStat4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStat3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStat2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStat1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private NumericUpDown numericStat4;
        private ComboBox comboBoxStat4;
        private NumericUpDown numericStat3;
        private ComboBox comboBoxStat3;
        private NumericUpDown numericStat2;
        private ComboBox comboBoxStat2;
        private NumericUpDown numericStat1;
        private ComboBox comboBoxStat1;
    }
}
