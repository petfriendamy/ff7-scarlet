namespace FF7Scarlet.SceneEditor
{
    partial class InitialConditionControl
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
            checkBoxMainScriptActive = new CheckBox();
            checkBoxTargetable = new CheckBox();
            checkBoxUnknown = new CheckBox();
            checkBoxLeftSide = new CheckBox();
            checkBoxVisible = new CheckBox();
            groupBoxMain.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(checkBoxMainScriptActive);
            groupBoxMain.Controls.Add(checkBoxTargetable);
            groupBoxMain.Controls.Add(checkBoxUnknown);
            groupBoxMain.Controls.Add(checkBoxLeftSide);
            groupBoxMain.Controls.Add(checkBoxVisible);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(319, 75);
            groupBoxMain.TabIndex = 12;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Condition flags";
            // 
            // checkBoxMainScriptActive
            // 
            checkBoxMainScriptActive.AutoSize = true;
            checkBoxMainScriptActive.Location = new Point(92, 47);
            checkBoxMainScriptActive.Name = "checkBoxMainScriptActive";
            checkBoxMainScriptActive.Size = new Size(119, 19);
            checkBoxMainScriptActive.TabIndex = 4;
            checkBoxMainScriptActive.Text = "Main script active";
            checkBoxMainScriptActive.UseVisualStyleBackColor = true;
            checkBoxMainScriptActive.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxTargetable
            // 
            checkBoxTargetable.AutoSize = true;
            checkBoxTargetable.Location = new Point(6, 47);
            checkBoxTargetable.Name = "checkBoxTargetable";
            checkBoxTargetable.Size = new Size(80, 19);
            checkBoxTargetable.TabIndex = 3;
            checkBoxTargetable.Text = "Targetable";
            checkBoxTargetable.UseVisualStyleBackColor = true;
            checkBoxTargetable.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxUnknown
            // 
            checkBoxUnknown.AutoSize = true;
            checkBoxUnknown.Location = new Point(225, 22);
            checkBoxUnknown.Name = "checkBoxUnknown";
            checkBoxUnknown.Size = new Size(77, 19);
            checkBoxUnknown.TabIndex = 2;
            checkBoxUnknown.Text = "Unknown";
            checkBoxUnknown.UseVisualStyleBackColor = true;
            checkBoxUnknown.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxLeftSide
            // 
            checkBoxLeftSide.AutoSize = true;
            checkBoxLeftSide.Location = new Point(92, 22);
            checkBoxLeftSide.Name = "checkBoxLeftSide";
            checkBoxLeftSide.Size = new Size(127, 19);
            checkBoxLeftSide.TabIndex = 1;
            checkBoxLeftSide.Text = "Left side (in pincer)";
            checkBoxLeftSide.UseVisualStyleBackColor = true;
            checkBoxLeftSide.CheckedChanged += CheckBoxChanged;
            // 
            // checkBoxVisible
            // 
            checkBoxVisible.AutoSize = true;
            checkBoxVisible.Location = new Point(6, 22);
            checkBoxVisible.Name = "checkBoxVisible";
            checkBoxVisible.Size = new Size(60, 19);
            checkBoxVisible.TabIndex = 0;
            checkBoxVisible.Text = "Visible";
            checkBoxVisible.UseVisualStyleBackColor = true;
            checkBoxVisible.CheckedChanged += CheckBoxChanged;
            // 
            // InitialConditionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            DoubleBuffered = true;
            Name = "InitialConditionControl";
            Size = new Size(319, 75);
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private CheckBox checkBoxMainScriptActive;
        private CheckBox checkBoxTargetable;
        private CheckBox checkBoxUnknown;
        private CheckBox checkBoxLeftSide;
        private CheckBox checkBoxVisible;
    }
}
