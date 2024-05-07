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
            this.labelMateriaID = new System.Windows.Forms.Label();
            this.comboBoxMateriaID = new System.Windows.Forms.ComboBox();
            this.labelCurrentAP = new System.Windows.Forms.Label();
            this.numericCurrentAP = new System.Windows.Forms.NumericUpDown();
            this.groupBoxEnemySkills = new System.Windows.Forms.GroupBox();
            this.panelEnemySkills = new System.Windows.Forms.Panel();
            this.checkBoxIsMastered = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericCurrentAP)).BeginInit();
            this.groupBoxEnemySkills.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMateriaID
            // 
            this.labelMateriaID.AutoSize = true;
            this.labelMateriaID.Location = new System.Drawing.Point(12, 9);
            this.labelMateriaID.Name = "labelMateriaID";
            this.labelMateriaID.Size = new System.Drawing.Size(50, 15);
            this.labelMateriaID.TabIndex = 0;
            this.labelMateriaID.Text = "Materia:";
            // 
            // comboBoxMateriaID
            // 
            this.comboBoxMateriaID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMateriaID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateriaID.FormattingEnabled = true;
            this.comboBoxMateriaID.Location = new System.Drawing.Point(12, 27);
            this.comboBoxMateriaID.Name = "comboBoxMateriaID";
            this.comboBoxMateriaID.Size = new System.Drawing.Size(340, 23);
            this.comboBoxMateriaID.TabIndex = 1;
            this.comboBoxMateriaID.SelectedIndexChanged += new System.EventHandler(this.comboBoxMateriaID_SelectedIndexChanged);
            // 
            // labelCurrentAP
            // 
            this.labelCurrentAP.AutoSize = true;
            this.labelCurrentAP.Location = new System.Drawing.Point(12, 53);
            this.labelCurrentAP.Name = "labelCurrentAP";
            this.labelCurrentAP.Size = new System.Drawing.Size(68, 15);
            this.labelCurrentAP.TabIndex = 2;
            this.labelCurrentAP.Text = "Current AP:";
            // 
            // numericCurrentAP
            // 
            this.numericCurrentAP.Location = new System.Drawing.Point(12, 71);
            this.numericCurrentAP.Name = "numericCurrentAP";
            this.numericCurrentAP.Size = new System.Drawing.Size(120, 23);
            this.numericCurrentAP.TabIndex = 3;
            this.numericCurrentAP.ValueChanged += new System.EventHandler(this.numericCurrentAP_ValueChanged);
            // 
            // groupBoxEnemySkills
            // 
            this.groupBoxEnemySkills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEnemySkills.Controls.Add(this.panelEnemySkills);
            this.groupBoxEnemySkills.Location = new System.Drawing.Point(12, 100);
            this.groupBoxEnemySkills.Name = "groupBoxEnemySkills";
            this.groupBoxEnemySkills.Size = new System.Drawing.Size(340, 100);
            this.groupBoxEnemySkills.TabIndex = 4;
            this.groupBoxEnemySkills.TabStop = false;
            this.groupBoxEnemySkills.Text = "Enemy Skills";
            // 
            // panelEnemySkills
            // 
            this.panelEnemySkills.AutoScroll = true;
            this.panelEnemySkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnemySkills.Location = new System.Drawing.Point(3, 19);
            this.panelEnemySkills.Name = "panelEnemySkills";
            this.panelEnemySkills.Size = new System.Drawing.Size(334, 78);
            this.panelEnemySkills.TabIndex = 0;
            // 
            // checkBoxIsMastered
            // 
            this.checkBoxIsMastered.AutoSize = true;
            this.checkBoxIsMastered.Location = new System.Drawing.Point(138, 72);
            this.checkBoxIsMastered.Name = "checkBoxIsMastered";
            this.checkBoxIsMastered.Size = new System.Drawing.Size(75, 19);
            this.checkBoxIsMastered.TabIndex = 5;
            this.checkBoxIsMastered.Text = "Mastered";
            this.checkBoxIsMastered.UseVisualStyleBackColor = true;
            this.checkBoxIsMastered.CheckedChanged += new System.EventHandler(this.checkBoxIsMastered_CheckedChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(277, 206);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(196, 206);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // MateriaAPEditForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(364, 241);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxIsMastered);
            this.Controls.Add(this.groupBoxEnemySkills);
            this.Controls.Add(this.numericCurrentAP);
            this.Controls.Add(this.labelCurrentAP);
            this.Controls.Add(this.comboBoxMateriaID);
            this.Controls.Add(this.labelMateriaID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MateriaAPEditForm";
            this.Text = "Edit Materia";
            ((System.ComponentModel.ISupportInitialize)(this.numericCurrentAP)).EndInit();
            this.groupBoxEnemySkills.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelMateriaID;
        private ComboBox comboBoxMateriaID;
        private Label labelCurrentAP;
        private NumericUpDown numericCurrentAP;
        private GroupBox groupBoxEnemySkills;
        private CheckBox checkBoxIsMastered;
        private Panel panelEnemySkills;
        private Button buttonOK;
        private Button buttonCancel;
    }
}