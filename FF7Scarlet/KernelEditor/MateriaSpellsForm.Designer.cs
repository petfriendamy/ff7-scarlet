namespace FF7Scarlet.KernelEditor
{
    partial class MateriaSpellsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MateriaSpellsForm));
            labelLevel1 = new Label();
            comboBoxLevel1 = new ComboBox();
            comboBoxLevel2 = new ComboBox();
            labelLevel2 = new Label();
            comboBoxLevel4 = new ComboBox();
            labelLevel4 = new Label();
            comboBoxLevel3 = new ComboBox();
            labelLevel3 = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            groupBoxSpells = new GroupBox();
            comboBoxLevel5 = new ComboBox();
            labelLevel5 = new Label();
            groupBoxSpells.SuspendLayout();
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
            // comboBoxLevel1
            // 
            comboBoxLevel1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLevel1.FormattingEnabled = true;
            comboBoxLevel1.Location = new Point(6, 37);
            comboBoxLevel1.Name = "comboBoxLevel1";
            comboBoxLevel1.Size = new Size(121, 23);
            comboBoxLevel1.TabIndex = 1;
            comboBoxLevel1.SelectedIndexChanged += comboBoxLevel_SelectedIndexChanged;
            // 
            // comboBoxLevel2
            // 
            comboBoxLevel2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLevel2.FormattingEnabled = true;
            comboBoxLevel2.Location = new Point(133, 37);
            comboBoxLevel2.Name = "comboBoxLevel2";
            comboBoxLevel2.Size = new Size(121, 23);
            comboBoxLevel2.TabIndex = 3;
            comboBoxLevel2.SelectedIndexChanged += comboBoxLevel_SelectedIndexChanged;
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
            // comboBoxLevel4
            // 
            comboBoxLevel4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLevel4.FormattingEnabled = true;
            comboBoxLevel4.Location = new Point(6, 81);
            comboBoxLevel4.Name = "comboBoxLevel4";
            comboBoxLevel4.Size = new Size(121, 23);
            comboBoxLevel4.TabIndex = 7;
            comboBoxLevel4.SelectedIndexChanged += comboBoxLevel_SelectedIndexChanged;
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
            // comboBoxLevel3
            // 
            comboBoxLevel3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLevel3.FormattingEnabled = true;
            comboBoxLevel3.Location = new Point(260, 37);
            comboBoxLevel3.Name = "comboBoxLevel3";
            comboBoxLevel3.Size = new Size(121, 23);
            comboBoxLevel3.TabIndex = 5;
            comboBoxLevel3.SelectedIndexChanged += comboBoxLevel_SelectedIndexChanged;
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
            buttonOK.Location = new Point(325, 141);
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
            buttonCancel.Location = new Point(245, 141);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxSpells
            // 
            groupBoxSpells.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSpells.Controls.Add(comboBoxLevel5);
            groupBoxSpells.Controls.Add(labelLevel5);
            groupBoxSpells.Controls.Add(comboBoxLevel1);
            groupBoxSpells.Controls.Add(labelLevel1);
            groupBoxSpells.Controls.Add(labelLevel2);
            groupBoxSpells.Controls.Add(comboBoxLevel4);
            groupBoxSpells.Controls.Add(comboBoxLevel2);
            groupBoxSpells.Controls.Add(labelLevel4);
            groupBoxSpells.Controls.Add(labelLevel3);
            groupBoxSpells.Controls.Add(comboBoxLevel3);
            groupBoxSpells.Location = new Point(12, 12);
            groupBoxSpells.Name = "groupBoxSpells";
            groupBoxSpells.Size = new Size(388, 118);
            groupBoxSpells.TabIndex = 10;
            groupBoxSpells.TabStop = false;
            groupBoxSpells.Text = "Actions gained per materia level";
            // 
            // comboBoxLevel5
            // 
            comboBoxLevel5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLevel5.FormattingEnabled = true;
            comboBoxLevel5.Location = new Point(133, 81);
            comboBoxLevel5.Name = "comboBoxLevel5";
            comboBoxLevel5.Size = new Size(121, 23);
            comboBoxLevel5.TabIndex = 9;
            // 
            // labelLevel5
            // 
            labelLevel5.AutoSize = true;
            labelLevel5.Location = new Point(133, 63);
            labelLevel5.Name = "labelLevel5";
            labelLevel5.Size = new Size(46, 15);
            labelLevel5.TabIndex = 8;
            labelLevel5.Text = "Level 5:";
            // 
            // MateriaSpellsForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(414, 176);
            Controls.Add(groupBoxSpells);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(430, 215);
            Name = "MateriaSpellsForm";
            Text = "Scarlet - Materia attributes";
            groupBoxSpells.ResumeLayout(false);
            groupBoxSpells.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelLevel1;
        private ComboBox comboBoxLevel1;
        private ComboBox comboBoxLevel2;
        private Label labelLevel2;
        private ComboBox comboBoxLevel4;
        private Label labelLevel4;
        private ComboBox comboBoxLevel3;
        private Label labelLevel3;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBoxSpells;
        private ComboBox comboBoxLevel5;
        private Label labelLevel5;
    }
}