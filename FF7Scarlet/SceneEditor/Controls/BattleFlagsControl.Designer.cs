namespace FF7Scarlet.SceneEditor
{
    partial class BattleFlagsControl
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
            checkBoxNoPreemptive = new CheckBox();
            checkBoxCantEscape = new CheckBox();
            checkBoxUnknown = new CheckBox();
            checkBoxNoVictoryPoses = new CheckBox();
            groupBoxMain.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(checkBoxNoVictoryPoses);
            groupBoxMain.Controls.Add(checkBoxNoPreemptive);
            groupBoxMain.Controls.Add(checkBoxCantEscape);
            groupBoxMain.Controls.Add(checkBoxUnknown);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(340, 120);
            groupBoxMain.TabIndex = 0;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Battle flags";
            // 
            // checkBoxNoPreemptive
            // 
            checkBoxNoPreemptive.AutoSize = true;
            checkBoxNoPreemptive.Location = new Point(126, 47);
            checkBoxNoPreemptive.Name = "checkBoxNoPreemptive";
            checkBoxNoPreemptive.Size = new Size(110, 19);
            checkBoxNoPreemptive.TabIndex = 3;
            checkBoxNoPreemptive.Text = "No pre-emptive";
            checkBoxNoPreemptive.UseVisualStyleBackColor = true;
            // 
            // checkBoxCantEscape
            // 
            checkBoxCantEscape.AutoSize = true;
            checkBoxCantEscape.Location = new Point(126, 22);
            checkBoxCantEscape.Name = "checkBoxCantEscape";
            checkBoxCantEscape.Size = new Size(93, 19);
            checkBoxCantEscape.TabIndex = 2;
            checkBoxCantEscape.Text = "Can't escape";
            checkBoxCantEscape.UseVisualStyleBackColor = true;
            // 
            // checkBoxUnknown
            // 
            checkBoxUnknown.AutoSize = true;
            checkBoxUnknown.Location = new Point(6, 22);
            checkBoxUnknown.Name = "checkBoxUnknown";
            checkBoxUnknown.Size = new Size(77, 19);
            checkBoxUnknown.TabIndex = 1;
            checkBoxUnknown.Text = "Unknown";
            checkBoxUnknown.UseVisualStyleBackColor = true;
            // 
            // checkBoxNoVictoryPoses
            // 
            checkBoxNoVictoryPoses.AutoSize = true;
            checkBoxNoVictoryPoses.Location = new Point(6, 47);
            checkBoxNoVictoryPoses.Name = "checkBoxNoVictoryPoses";
            checkBoxNoVictoryPoses.Size = new Size(114, 19);
            checkBoxNoVictoryPoses.TabIndex = 4;
            checkBoxNoVictoryPoses.Text = "No victory poses";
            checkBoxNoVictoryPoses.UseVisualStyleBackColor = true;
            // 
            // BattleFlagsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            DoubleBuffered = true;
            Name = "BattleFlagsControl";
            Size = new Size(340, 120);
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private CheckBox checkBoxUnknown;
        private CheckBox checkBoxCantEscape;
        private CheckBox checkBoxNoPreemptive;
        private CheckBox checkBoxNoVictoryPoses;
    }
}
