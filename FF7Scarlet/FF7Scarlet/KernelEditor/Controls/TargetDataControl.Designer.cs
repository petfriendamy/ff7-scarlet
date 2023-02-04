namespace FF7Scarlet.KernelEditor.Controls
{
    partial class TargetDataControl
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
            this.checkBoxRandomTarget = new System.Windows.Forms.CheckBox();
            this.checkBoxAllRows = new System.Windows.Forms.CheckBox();
            this.checkBoxShortRange = new System.Windows.Forms.CheckBox();
            this.checkBoxOneRowOnly = new System.Windows.Forms.CheckBox();
            this.checkBoxSingleMultiToggle = new System.Windows.Forms.CheckBox();
            this.checkBoxMultipleTargetDefault = new System.Windows.Forms.CheckBox();
            this.checkBoxStartOnEnemies = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableSelection = new System.Windows.Forms.CheckBox();
            this.groupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.checkBoxRandomTarget);
            this.groupBoxMain.Controls.Add(this.checkBoxAllRows);
            this.groupBoxMain.Controls.Add(this.checkBoxShortRange);
            this.groupBoxMain.Controls.Add(this.checkBoxOneRowOnly);
            this.groupBoxMain.Controls.Add(this.checkBoxSingleMultiToggle);
            this.groupBoxMain.Controls.Add(this.checkBoxMultipleTargetDefault);
            this.groupBoxMain.Controls.Add(this.checkBoxStartOnEnemies);
            this.groupBoxMain.Controls.Add(this.checkBoxEnableSelection);
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMain.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(330, 125);
            this.groupBoxMain.TabIndex = 26;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Target flags";
            // 
            // checkBoxWeaponRandomTarget
            // 
            this.checkBoxRandomTarget.AutoSize = true;
            this.checkBoxRandomTarget.Location = new System.Drawing.Point(201, 97);
            this.checkBoxRandomTarget.Name = "checkBoxWeaponRandomTarget";
            this.checkBoxRandomTarget.Size = new System.Drawing.Size(105, 19);
            this.checkBoxRandomTarget.TabIndex = 7;
            this.checkBoxRandomTarget.Text = "Random target";
            this.checkBoxRandomTarget.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponAllRows
            // 
            this.checkBoxAllRows.AutoSize = true;
            this.checkBoxAllRows.Location = new System.Drawing.Point(201, 72);
            this.checkBoxAllRows.Name = "checkBoxWeaponAllRows";
            this.checkBoxAllRows.Size = new System.Drawing.Size(68, 19);
            this.checkBoxAllRows.TabIndex = 6;
            this.checkBoxAllRows.Text = "All rows";
            this.checkBoxAllRows.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponShortRange
            // 
            this.checkBoxShortRange.AutoSize = true;
            this.checkBoxShortRange.Location = new System.Drawing.Point(201, 47);
            this.checkBoxShortRange.Name = "checkBoxWeaponShortRange";
            this.checkBoxShortRange.Size = new System.Drawing.Size(87, 19);
            this.checkBoxShortRange.TabIndex = 5;
            this.checkBoxShortRange.Text = "Short range";
            this.checkBoxShortRange.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponOneRowOnly
            // 
            this.checkBoxOneRowOnly.AutoSize = true;
            this.checkBoxOneRowOnly.Location = new System.Drawing.Point(201, 22);
            this.checkBoxOneRowOnly.Name = "checkBoxWeaponOneRowOnly";
            this.checkBoxOneRowOnly.Size = new System.Drawing.Size(97, 19);
            this.checkBoxOneRowOnly.TabIndex = 4;
            this.checkBoxOneRowOnly.Text = "One row only";
            this.checkBoxOneRowOnly.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponSingleMultiToggle
            // 
            this.checkBoxSingleMultiToggle.AutoSize = true;
            this.checkBoxSingleMultiToggle.Location = new System.Drawing.Point(6, 97);
            this.checkBoxSingleMultiToggle.Name = "checkBoxWeaponSingleMultiToggle";
            this.checkBoxSingleMultiToggle.Size = new System.Drawing.Size(183, 19);
            this.checkBoxSingleMultiToggle.TabIndex = 3;
            this.checkBoxSingleMultiToggle.Text = "Toggle single/multiple targets";
            this.checkBoxSingleMultiToggle.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponMultipleTargetDefault
            // 
            this.checkBoxMultipleTargetDefault.AutoSize = true;
            this.checkBoxMultipleTargetDefault.Location = new System.Drawing.Point(6, 72);
            this.checkBoxMultipleTargetDefault.Name = "checkBoxWeaponMultipleTargetDefault";
            this.checkBoxMultipleTargetDefault.Size = new System.Drawing.Size(160, 19);
            this.checkBoxMultipleTargetDefault.TabIndex = 2;
            this.checkBoxMultipleTargetDefault.Text = "Multiple target by default";
            this.checkBoxMultipleTargetDefault.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponStartOnEnemies
            // 
            this.checkBoxStartOnEnemies.AutoSize = true;
            this.checkBoxStartOnEnemies.Location = new System.Drawing.Point(6, 47);
            this.checkBoxStartOnEnemies.Name = "checkBoxWeaponStartOnEnemies";
            this.checkBoxStartOnEnemies.Size = new System.Drawing.Size(114, 19);
            this.checkBoxStartOnEnemies.TabIndex = 1;
            this.checkBoxStartOnEnemies.Text = "Start on enemies";
            this.checkBoxStartOnEnemies.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponEnableSelection
            // 
            this.checkBoxEnableSelection.AutoSize = true;
            this.checkBoxEnableSelection.Location = new System.Drawing.Point(6, 22);
            this.checkBoxEnableSelection.Name = "checkBoxWeaponEnableSelection";
            this.checkBoxEnableSelection.Size = new System.Drawing.Size(111, 19);
            this.checkBoxEnableSelection.TabIndex = 0;
            this.checkBoxEnableSelection.Text = "Enable selection";
            this.checkBoxEnableSelection.UseVisualStyleBackColor = true;
            // 
            // TargetDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxMain);
            this.Name = "TargetDataControl";
            this.Size = new System.Drawing.Size(330, 125);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxMain;
        private CheckBox checkBoxRandomTarget;
        private CheckBox checkBoxAllRows;
        private CheckBox checkBoxShortRange;
        private CheckBox checkBoxOneRowOnly;
        private CheckBox checkBoxSingleMultiToggle;
        private CheckBox checkBoxMultipleTargetDefault;
        private CheckBox checkBoxStartOnEnemies;
        private CheckBox checkBoxEnableSelection;
    }
}
