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
            groupBoxMain = new GroupBox();
            checkBoxRandomTarget = new CheckBox();
            checkBoxAllRows = new CheckBox();
            checkBoxShortRange = new CheckBox();
            checkBoxOneRowOnly = new CheckBox();
            checkBoxSingleMultiToggle = new CheckBox();
            checkBoxMultipleTargetDefault = new CheckBox();
            checkBoxStartOnEnemies = new CheckBox();
            checkBoxEnableSelection = new CheckBox();
            groupBoxMain.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(checkBoxRandomTarget);
            groupBoxMain.Controls.Add(checkBoxAllRows);
            groupBoxMain.Controls.Add(checkBoxShortRange);
            groupBoxMain.Controls.Add(checkBoxOneRowOnly);
            groupBoxMain.Controls.Add(checkBoxSingleMultiToggle);
            groupBoxMain.Controls.Add(checkBoxMultipleTargetDefault);
            groupBoxMain.Controls.Add(checkBoxStartOnEnemies);
            groupBoxMain.Controls.Add(checkBoxEnableSelection);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(330, 125);
            groupBoxMain.TabIndex = 26;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Target flags";
            // 
            // checkBoxRandomTarget
            // 
            checkBoxRandomTarget.AutoSize = true;
            checkBoxRandomTarget.Location = new Point(201, 97);
            checkBoxRandomTarget.Name = "checkBoxRandomTarget";
            checkBoxRandomTarget.Size = new Size(105, 19);
            checkBoxRandomTarget.TabIndex = 7;
            checkBoxRandomTarget.Text = "Random target";
            checkBoxRandomTarget.UseVisualStyleBackColor = true;
            checkBoxRandomTarget.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxAllRows
            // 
            checkBoxAllRows.AutoSize = true;
            checkBoxAllRows.Location = new Point(201, 72);
            checkBoxAllRows.Name = "checkBoxAllRows";
            checkBoxAllRows.Size = new Size(68, 19);
            checkBoxAllRows.TabIndex = 6;
            checkBoxAllRows.Text = "All rows";
            checkBoxAllRows.UseVisualStyleBackColor = true;
            checkBoxAllRows.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxShortRange
            // 
            checkBoxShortRange.AutoSize = true;
            checkBoxShortRange.Location = new Point(201, 47);
            checkBoxShortRange.Name = "checkBoxShortRange";
            checkBoxShortRange.Size = new Size(87, 19);
            checkBoxShortRange.TabIndex = 5;
            checkBoxShortRange.Text = "Short range";
            checkBoxShortRange.UseVisualStyleBackColor = true;
            checkBoxShortRange.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxOneRowOnly
            // 
            checkBoxOneRowOnly.AutoSize = true;
            checkBoxOneRowOnly.Location = new Point(201, 22);
            checkBoxOneRowOnly.Name = "checkBoxOneRowOnly";
            checkBoxOneRowOnly.Size = new Size(97, 19);
            checkBoxOneRowOnly.TabIndex = 4;
            checkBoxOneRowOnly.Text = "One row only";
            checkBoxOneRowOnly.UseVisualStyleBackColor = true;
            checkBoxOneRowOnly.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxSingleMultiToggle
            // 
            checkBoxSingleMultiToggle.AutoSize = true;
            checkBoxSingleMultiToggle.Location = new Point(6, 97);
            checkBoxSingleMultiToggle.Name = "checkBoxSingleMultiToggle";
            checkBoxSingleMultiToggle.Size = new Size(183, 19);
            checkBoxSingleMultiToggle.TabIndex = 3;
            checkBoxSingleMultiToggle.Text = "Toggle single/multiple targets";
            checkBoxSingleMultiToggle.UseVisualStyleBackColor = true;
            checkBoxSingleMultiToggle.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxMultipleTargetDefault
            // 
            checkBoxMultipleTargetDefault.AutoSize = true;
            checkBoxMultipleTargetDefault.Location = new Point(6, 72);
            checkBoxMultipleTargetDefault.Name = "checkBoxMultipleTargetDefault";
            checkBoxMultipleTargetDefault.Size = new Size(160, 19);
            checkBoxMultipleTargetDefault.TabIndex = 2;
            checkBoxMultipleTargetDefault.Text = "Multiple target by default";
            checkBoxMultipleTargetDefault.UseVisualStyleBackColor = true;
            checkBoxMultipleTargetDefault.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxStartOnEnemies
            // 
            checkBoxStartOnEnemies.AutoSize = true;
            checkBoxStartOnEnemies.Location = new Point(6, 47);
            checkBoxStartOnEnemies.Name = "checkBoxStartOnEnemies";
            checkBoxStartOnEnemies.Size = new Size(114, 19);
            checkBoxStartOnEnemies.TabIndex = 1;
            checkBoxStartOnEnemies.Text = "Start on enemies";
            checkBoxStartOnEnemies.UseVisualStyleBackColor = true;
            checkBoxStartOnEnemies.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxEnableSelection
            // 
            checkBoxEnableSelection.AutoSize = true;
            checkBoxEnableSelection.Location = new Point(6, 22);
            checkBoxEnableSelection.Name = "checkBoxEnableSelection";
            checkBoxEnableSelection.Size = new Size(111, 19);
            checkBoxEnableSelection.TabIndex = 0;
            checkBoxEnableSelection.Text = "Enable selection";
            checkBoxEnableSelection.UseVisualStyleBackColor = true;
            checkBoxEnableSelection.CheckedChanged += CheckBoxChanged;
            // 
            // TargetDataControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            DoubleBuffered = true;
            Name = "TargetDataControl";
            Size = new Size(330, 125);
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ResumeLayout(false);
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
