namespace FF7Scarlet.Shared
{
    partial class MateriaAPEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MateriaAPEditForm));
            labelMateriaID = new Label();
            comboBoxMateriaID = new ComboBox();
            labelCurrentAP = new Label();
            numericCurrentAP = new NumericUpDown();
            groupBoxEnemySkills = new GroupBox();
            checkedListBoxESkills = new CheckedListBox();
            checkBoxIsMastered = new CheckBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericCurrentAP).BeginInit();
            groupBoxEnemySkills.SuspendLayout();
            SuspendLayout();
            // 
            // labelMateriaID
            // 
            labelMateriaID.AutoSize = true;
            labelMateriaID.Location = new Point(12, 9);
            labelMateriaID.Name = "labelMateriaID";
            labelMateriaID.Size = new Size(50, 15);
            labelMateriaID.TabIndex = 0;
            labelMateriaID.Text = "Materia:";
            // 
            // comboBoxMateriaID
            // 
            comboBoxMateriaID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxMateriaID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMateriaID.FormattingEnabled = true;
            comboBoxMateriaID.Location = new Point(12, 27);
            comboBoxMateriaID.Name = "comboBoxMateriaID";
            comboBoxMateriaID.Size = new Size(340, 23);
            comboBoxMateriaID.TabIndex = 1;
            comboBoxMateriaID.SelectedIndexChanged += comboBoxMateriaID_SelectedIndexChanged;
            // 
            // labelCurrentAP
            // 
            labelCurrentAP.AutoSize = true;
            labelCurrentAP.Location = new Point(12, 53);
            labelCurrentAP.Name = "labelCurrentAP";
            labelCurrentAP.Size = new Size(68, 15);
            labelCurrentAP.TabIndex = 2;
            labelCurrentAP.Text = "Current AP:";
            // 
            // numericCurrentAP
            // 
            numericCurrentAP.Location = new Point(12, 71);
            numericCurrentAP.Name = "numericCurrentAP";
            numericCurrentAP.Size = new Size(120, 23);
            numericCurrentAP.TabIndex = 3;
            numericCurrentAP.ValueChanged += numericCurrentAP_ValueChanged;
            // 
            // groupBoxEnemySkills
            // 
            groupBoxEnemySkills.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxEnemySkills.Controls.Add(checkedListBoxESkills);
            groupBoxEnemySkills.Location = new Point(12, 100);
            groupBoxEnemySkills.Name = "groupBoxEnemySkills";
            groupBoxEnemySkills.Size = new Size(340, 100);
            groupBoxEnemySkills.TabIndex = 4;
            groupBoxEnemySkills.TabStop = false;
            groupBoxEnemySkills.Text = "Enemy Skills";
            // 
            // checkedListBoxESkills
            // 
            checkedListBoxESkills.CheckOnClick = true;
            checkedListBoxESkills.Dock = DockStyle.Fill;
            checkedListBoxESkills.FormattingEnabled = true;
            checkedListBoxESkills.Location = new Point(3, 19);
            checkedListBoxESkills.Name = "checkedListBoxESkills";
            checkedListBoxESkills.Size = new Size(334, 78);
            checkedListBoxESkills.TabIndex = 0;
            checkedListBoxESkills.ItemCheck += checkedListBoxESkills_ItemCheck;
            // 
            // checkBoxIsMastered
            // 
            checkBoxIsMastered.AutoSize = true;
            checkBoxIsMastered.Location = new Point(138, 72);
            checkBoxIsMastered.Name = "checkBoxIsMastered";
            checkBoxIsMastered.Size = new Size(75, 19);
            checkBoxIsMastered.TabIndex = 5;
            checkBoxIsMastered.Text = "Mastered";
            checkBoxIsMastered.UseVisualStyleBackColor = true;
            checkBoxIsMastered.CheckedChanged += checkBoxIsMastered_CheckedChanged;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(277, 206);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 6;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(196, 206);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // MateriaAPEditForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(364, 241);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(checkBoxIsMastered);
            Controls.Add(groupBoxEnemySkills);
            Controls.Add(numericCurrentAP);
            Controls.Add(labelCurrentAP);
            Controls.Add(comboBoxMateriaID);
            Controls.Add(labelMateriaID);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MateriaAPEditForm";
            Text = "Edit Materia";
            ((System.ComponentModel.ISupportInitialize)numericCurrentAP).EndInit();
            groupBoxEnemySkills.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label labelMateriaID;
        private ComboBox comboBoxMateriaID;
        private Label labelCurrentAP;
        private NumericUpDown numericCurrentAP;
        private GroupBox groupBoxEnemySkills;
        private CheckBox checkBoxIsMastered;
        private Button buttonOK;
        private Button buttonCancel;
        private CheckedListBox checkedListBoxESkills;
    }
}