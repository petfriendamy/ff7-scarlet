namespace FF7Scarlet.KernelEditor
{
    partial class MateriaEffectScaleForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MateriaEffectScaleForm));
            labelLevel1 = new Label();
            labelLevel2 = new Label();
            labelLevel4 = new Label();
            labelLevel3 = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            groupBoxSpells = new GroupBox();
            numericLevel5 = new NumericUpDown();
            labelLevel5 = new Label();
            numericLevel4 = new NumericUpDown();
            numericLevel3 = new NumericUpDown();
            numericLevel2 = new NumericUpDown();
            numericLevel1 = new NumericUpDown();
            labelStatAffected = new Label();
            comboBoxStatAffected = new ComboBox();
            groupBoxSpells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericLevel5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericLevel4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericLevel3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericLevel2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericLevel1).BeginInit();
            SuspendLayout();
            // 
            // labelLevel1
            // 
            labelLevel1.AutoSize = true;
            labelLevel1.Location = new Point(6, 19);
            labelLevel1.Name = "labelLevel1";
            labelLevel1.Size = new Size(46, 15);
            labelLevel1.TabIndex = 0;
            labelLevel1.Text = "Level 1:";
            // 
            // labelLevel2
            // 
            labelLevel2.AutoSize = true;
            labelLevel2.Location = new Point(133, 19);
            labelLevel2.Name = "labelLevel2";
            labelLevel2.Size = new Size(46, 15);
            labelLevel2.TabIndex = 2;
            labelLevel2.Text = "Level 2:";
            // 
            // labelLevel4
            // 
            labelLevel4.AutoSize = true;
            labelLevel4.Location = new Point(6, 63);
            labelLevel4.Name = "labelLevel4";
            labelLevel4.Size = new Size(46, 15);
            labelLevel4.TabIndex = 6;
            labelLevel4.Text = "Level 4:";
            // 
            // labelLevel3
            // 
            labelLevel3.AutoSize = true;
            labelLevel3.Location = new Point(260, 19);
            labelLevel3.Name = "labelLevel3";
            labelLevel3.Size = new Size(46, 15);
            labelLevel3.TabIndex = 4;
            labelLevel3.Text = "Level 3:";
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(325, 186);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 8;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(245, 186);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxSpells
            // 
            groupBoxSpells.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSpells.Controls.Add(numericLevel5);
            groupBoxSpells.Controls.Add(labelLevel5);
            groupBoxSpells.Controls.Add(numericLevel4);
            groupBoxSpells.Controls.Add(numericLevel3);
            groupBoxSpells.Controls.Add(numericLevel2);
            groupBoxSpells.Controls.Add(numericLevel1);
            groupBoxSpells.Controls.Add(labelLevel1);
            groupBoxSpells.Controls.Add(labelLevel2);
            groupBoxSpells.Controls.Add(labelLevel4);
            groupBoxSpells.Controls.Add(labelLevel3);
            groupBoxSpells.Location = new Point(12, 56);
            groupBoxSpells.Name = "groupBoxSpells";
            groupBoxSpells.Size = new Size(388, 119);
            groupBoxSpells.TabIndex = 10;
            groupBoxSpells.TabStop = false;
            groupBoxSpells.Text = "Effect scale per level";
            // 
            // numericLevel5
            // 
            numericLevel5.Location = new Point(133, 81);
            numericLevel5.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericLevel5.Name = "numericLevel5";
            numericLevel5.Size = new Size(121, 23);
            numericLevel5.TabIndex = 12;
            numericLevel5.ValueChanged += DataChanged;
            // 
            // labelLevel5
            // 
            labelLevel5.AutoSize = true;
            labelLevel5.Location = new Point(133, 63);
            labelLevel5.Name = "labelLevel5";
            labelLevel5.Size = new Size(46, 15);
            labelLevel5.TabIndex = 11;
            labelLevel5.Text = "Level 5:";
            // 
            // numericLevel4
            // 
            numericLevel4.Location = new Point(6, 81);
            numericLevel4.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericLevel4.Name = "numericLevel4";
            numericLevel4.Size = new Size(121, 23);
            numericLevel4.TabIndex = 10;
            numericLevel4.ValueChanged += DataChanged;
            // 
            // numericLevel3
            // 
            numericLevel3.Location = new Point(260, 37);
            numericLevel3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericLevel3.Name = "numericLevel3";
            numericLevel3.Size = new Size(121, 23);
            numericLevel3.TabIndex = 9;
            numericLevel3.ValueChanged += DataChanged;
            // 
            // numericLevel2
            // 
            numericLevel2.Location = new Point(133, 37);
            numericLevel2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericLevel2.Name = "numericLevel2";
            numericLevel2.Size = new Size(121, 23);
            numericLevel2.TabIndex = 8;
            numericLevel2.ValueChanged += DataChanged;
            // 
            // numericLevel1
            // 
            numericLevel1.Location = new Point(6, 37);
            numericLevel1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericLevel1.Name = "numericLevel1";
            numericLevel1.Size = new Size(121, 23);
            numericLevel1.TabIndex = 7;
            numericLevel1.ValueChanged += DataChanged;
            // 
            // labelStatAffected
            // 
            labelStatAffected.AutoSize = true;
            labelStatAffected.Location = new Point(12, 9);
            labelStatAffected.Name = "labelStatAffected";
            labelStatAffected.Size = new Size(103, 15);
            labelStatAffected.TabIndex = 11;
            labelStatAffected.Text = "Affected attribute:";
            // 
            // comboBoxStatAffected
            // 
            comboBoxStatAffected.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatAffected.FormattingEnabled = true;
            comboBoxStatAffected.Location = new Point(12, 27);
            comboBoxStatAffected.Name = "comboBoxStatAffected";
            comboBoxStatAffected.Size = new Size(254, 23);
            comboBoxStatAffected.TabIndex = 12;
            comboBoxStatAffected.SelectedIndexChanged += DataChanged;
            // 
            // MateriaEffectScaleForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(412, 221);
            Controls.Add(comboBoxStatAffected);
            Controls.Add(labelStatAffected);
            Controls.Add(groupBoxSpells);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(428, 260);
            Name = "MateriaEffectScaleForm";
            Text = "Scarlet - Materia attributes";
            groupBoxSpells.ResumeLayout(false);
            groupBoxSpells.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericLevel5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericLevel4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericLevel3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericLevel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericLevel1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLevel1;
        private Label labelLevel2;
        private Label labelLevel4;
        private Label labelLevel3;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBoxSpells;
        private NumericUpDown numericLevel5;
        private Label labelLevel5;
        private NumericUpDown numericLevel4;
        private NumericUpDown numericLevel3;
        private NumericUpDown numericLevel2;
        private NumericUpDown numericLevel1;
        private Label labelStatAffected;
        private ComboBox comboBoxStatAffected;
    }
}