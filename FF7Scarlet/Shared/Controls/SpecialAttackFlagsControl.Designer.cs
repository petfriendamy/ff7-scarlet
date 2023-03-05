namespace FF7Scarlet.Shared
{
    partial class SpecialAttackFlagsControl
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
            checkBoxUnknown2 = new CheckBox();
            checkBoxUnknown1 = new CheckBox();
            checkBoxAlwaysCrit = new CheckBox();
            checkBoxNoRetargetIfDead = new CheckBox();
            checkBoxIgnoreDefense = new CheckBox();
            checkBoxReflectable = new CheckBox();
            checkBoxMissIfNotDead = new CheckBox();
            checkBoxIgnoreStatusDefense = new CheckBox();
            checkBoxAffectedByDarkness = new CheckBox();
            checkBoxDrainsHPandMP = new CheckBox();
            checkBoxDrainsDamage = new CheckBox();
            checkBoxDamageMP = new CheckBox();
            groupBoxMain.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(checkBoxUnknown2);
            groupBoxMain.Controls.Add(checkBoxUnknown1);
            groupBoxMain.Controls.Add(checkBoxAlwaysCrit);
            groupBoxMain.Controls.Add(checkBoxNoRetargetIfDead);
            groupBoxMain.Controls.Add(checkBoxIgnoreDefense);
            groupBoxMain.Controls.Add(checkBoxReflectable);
            groupBoxMain.Controls.Add(checkBoxMissIfNotDead);
            groupBoxMain.Controls.Add(checkBoxIgnoreStatusDefense);
            groupBoxMain.Controls.Add(checkBoxAffectedByDarkness);
            groupBoxMain.Controls.Add(checkBoxDrainsHPandMP);
            groupBoxMain.Controls.Add(checkBoxDrainsDamage);
            groupBoxMain.Controls.Add(checkBoxDamageMP);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(580, 100);
            groupBoxMain.TabIndex = 46;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Special attack flags";
            // 
            // checkBoxUnknown2
            // 
            checkBoxUnknown2.AutoSize = true;
            checkBoxUnknown2.Location = new Point(149, 72);
            checkBoxUnknown2.Name = "checkBoxUnknown2";
            checkBoxUnknown2.Size = new Size(77, 19);
            checkBoxUnknown2.TabIndex = 12;
            checkBoxUnknown2.Text = "Unknown";
            checkBoxUnknown2.UseVisualStyleBackColor = true;
            checkBoxUnknown2.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxUnknown1
            // 
            checkBoxUnknown1.AutoSize = true;
            checkBoxUnknown1.Location = new Point(6, 47);
            checkBoxUnknown1.Name = "checkBoxUnknown1";
            checkBoxUnknown1.Size = new Size(77, 19);
            checkBoxUnknown1.TabIndex = 11;
            checkBoxUnknown1.Text = "Unknown";
            checkBoxUnknown1.UseVisualStyleBackColor = true;
            checkBoxUnknown1.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxAlwaysCrit
            // 
            checkBoxAlwaysCrit.AutoSize = true;
            checkBoxAlwaysCrit.Location = new Point(436, 72);
            checkBoxAlwaysCrit.Name = "checkBoxAlwaysCrit";
            checkBoxAlwaysCrit.Size = new Size(83, 19);
            checkBoxAlwaysCrit.TabIndex = 10;
            checkBoxAlwaysCrit.Text = "Always crit";
            checkBoxAlwaysCrit.UseVisualStyleBackColor = true;
            checkBoxAlwaysCrit.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxNoRetargetIfDead
            // 
            checkBoxNoRetargetIfDead.AutoSize = true;
            checkBoxNoRetargetIfDead.Location = new Point(436, 47);
            checkBoxNoRetargetIfDead.Name = "checkBoxNoRetargetIfDead";
            checkBoxNoRetargetIfDead.Size = new Size(125, 19);
            checkBoxNoRetargetIfDead.TabIndex = 9;
            checkBoxNoRetargetIfDead.Text = "No retarget if dead";
            checkBoxNoRetargetIfDead.UseVisualStyleBackColor = true;
            checkBoxNoRetargetIfDead.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxIgnoreDefense
            // 
            checkBoxIgnoreDefense.AutoSize = true;
            checkBoxIgnoreDefense.Location = new Point(436, 22);
            checkBoxIgnoreDefense.Name = "checkBoxIgnoreDefense";
            checkBoxIgnoreDefense.Size = new Size(104, 19);
            checkBoxIgnoreDefense.TabIndex = 8;
            checkBoxIgnoreDefense.Text = "Ignore defense";
            checkBoxIgnoreDefense.UseVisualStyleBackColor = true;
            checkBoxIgnoreDefense.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxReflectable
            // 
            checkBoxReflectable.AutoSize = true;
            checkBoxReflectable.Location = new Point(292, 72);
            checkBoxReflectable.Name = "checkBoxReflectable";
            checkBoxReflectable.Size = new Size(84, 19);
            checkBoxReflectable.TabIndex = 7;
            checkBoxReflectable.Text = "Reflectable";
            checkBoxReflectable.UseVisualStyleBackColor = true;
            checkBoxReflectable.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxMissIfNotDead
            // 
            checkBoxMissIfNotDead.AutoSize = true;
            checkBoxMissIfNotDead.Location = new Point(292, 47);
            checkBoxMissIfNotDead.Name = "checkBoxMissIfNotDead";
            checkBoxMissIfNotDead.Size = new Size(110, 19);
            checkBoxMissIfNotDead.TabIndex = 6;
            checkBoxMissIfNotDead.Text = "Miss if not dead";
            checkBoxMissIfNotDead.UseVisualStyleBackColor = true;
            checkBoxMissIfNotDead.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxIgnoreStatusDefense
            // 
            checkBoxIgnoreStatusDefense.AutoSize = true;
            checkBoxIgnoreStatusDefense.Location = new Point(292, 22);
            checkBoxIgnoreStatusDefense.Name = "checkBoxIgnoreStatusDefense";
            checkBoxIgnoreStatusDefense.Size = new Size(138, 19);
            checkBoxIgnoreStatusDefense.TabIndex = 5;
            checkBoxIgnoreStatusDefense.Text = "Ignore status defense";
            checkBoxIgnoreStatusDefense.UseVisualStyleBackColor = true;
            checkBoxIgnoreStatusDefense.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxAffectedByDarkness
            // 
            checkBoxAffectedByDarkness.AutoSize = true;
            checkBoxAffectedByDarkness.Location = new Point(6, 72);
            checkBoxAffectedByDarkness.Name = "checkBoxAffectedByDarkness";
            checkBoxAffectedByDarkness.Size = new Size(137, 19);
            checkBoxAffectedByDarkness.TabIndex = 4;
            checkBoxAffectedByDarkness.Text = "Affected by Darkness";
            checkBoxAffectedByDarkness.UseVisualStyleBackColor = true;
            checkBoxAffectedByDarkness.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxDrainsHPandMP
            // 
            checkBoxDrainsHPandMP.AutoSize = true;
            checkBoxDrainsHPandMP.Location = new Point(149, 47);
            checkBoxDrainsHPandMP.Name = "checkBoxDrainsHPandMP";
            checkBoxDrainsHPandMP.Size = new Size(122, 19);
            checkBoxDrainsHPandMP.TabIndex = 3;
            checkBoxDrainsHPandMP.Text = "Drains HP and MP";
            checkBoxDrainsHPandMP.UseVisualStyleBackColor = true;
            checkBoxDrainsHPandMP.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxDrainsDamage
            // 
            checkBoxDrainsDamage.AutoSize = true;
            checkBoxDrainsDamage.Location = new Point(149, 22);
            checkBoxDrainsDamage.Name = "checkBoxDrainsDamage";
            checkBoxDrainsDamage.Size = new Size(137, 19);
            checkBoxDrainsDamage.TabIndex = 2;
            checkBoxDrainsDamage.Text = "Drains some damage";
            checkBoxDrainsDamage.UseVisualStyleBackColor = true;
            checkBoxDrainsDamage.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxDamageMP
            // 
            checkBoxDamageMP.AutoSize = true;
            checkBoxDamageMP.Location = new Point(6, 22);
            checkBoxDamageMP.Name = "checkBoxDamageMP";
            checkBoxDamageMP.Size = new Size(96, 19);
            checkBoxDamageMP.TabIndex = 0;
            checkBoxDamageMP.Text = "Damages MP";
            checkBoxDamageMP.UseVisualStyleBackColor = true;
            checkBoxDamageMP.CheckedChanged += CheckBoxChanged;
            // 
            // SpecialAttackFlagsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            Name = "SpecialAttackFlagsControl";
            Size = new Size(580, 100);
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private CheckBox checkBoxAlwaysCrit;
        private CheckBox checkBoxNoRetargetIfDead;
        private CheckBox checkBoxIgnoreDefense;
        private CheckBox checkBoxReflectable;
        private CheckBox checkBoxMissIfNotDead;
        private CheckBox checkBoxIgnoreStatusDefense;
        private CheckBox checkBoxAffectedByDarkness;
        private CheckBox checkBoxDrainsHPandMP;
        private CheckBox checkBoxDrainsDamage;
        private CheckBox checkBoxDamageMP;
        private CheckBox checkBoxUnknown1;
        private CheckBox checkBoxUnknown2;
    }
}
