namespace FF7Scarlet.SceneEditor
{
    partial class Formation3DEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formation3DEditorForm));
            glControl = new OpenTK.GLControl.GLControl();
            buttonCommit = new Button();
            buttonCancel = new Button();
            labelCurrCamera = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            cameraPositionControl = new FF7Scarlet.SceneEditor.Controls.CameraPositionControl();
            groupBoxEnemy = new GroupBox();
            numericEnemyX = new NumericUpDown();
            labelEnemyX = new Label();
            labelEnemyY = new Label();
            numericEnemyY = new NumericUpDown();
            labelEnemyZ = new Label();
            numericEnemyZ = new NumericUpDown();
            buttonReset = new Button();
            groupBoxEnemy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericEnemyX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyZ).BeginInit();
            SuspendLayout();
            // 
            // glControl
            // 
            glControl.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl.APIVersion = new Version(3, 3, 0, 0);
            glControl.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl.IsEventDriven = true;
            glControl.Location = new Point(12, 12);
            glControl.Name = "glControl";
            glControl.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            glControl.SharedContext = null;
            glControl.Size = new Size(480, 360);
            glControl.TabIndex = 0;
            glControl.Paint += glControl_Paint;
            glControl.Enter += glControl_Enter;
            glControl.MouseDown += glControl_MouseDown;
            glControl.MouseMove += glControl_MouseMove;
            glControl.MouseUp += glControl_MouseUp;
            glControl.MouseWheel += glControl_MouseWheel;
            // 
            // buttonCommit
            // 
            buttonCommit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCommit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCommit.Location = new Point(12, 386);
            buttonCommit.Name = "buttonCommit";
            buttonCommit.Size = new Size(175, 23);
            buttonCommit.TabIndex = 1;
            buttonCommit.Text = "Commit all changes";
            buttonCommit.UseVisualStyleBackColor = true;
            buttonCommit.Click += buttonCommit_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(657, 386);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelCurrCamera
            // 
            labelCurrCamera.AutoSize = true;
            labelCurrCamera.Location = new Point(498, 12);
            labelCurrCamera.Name = "labelCurrCamera";
            labelCurrCamera.Size = new Size(92, 15);
            labelCurrCamera.TabIndex = 4;
            labelCurrCamera.Text = "Current camera:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(503, 30);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(31, 19);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(540, 30);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(31, 19);
            radioButton2.TabIndex = 6;
            radioButton2.Text = "2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(577, 30);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(31, 19);
            radioButton3.TabIndex = 7;
            radioButton3.Text = "3";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(614, 30);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(31, 19);
            radioButton4.TabIndex = 8;
            radioButton4.Text = "4";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // cameraPositionControl
            // 
            cameraPositionControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cameraPositionControl.Location = new Point(498, 55);
            cameraPositionControl.Name = "cameraPositionControl";
            cameraPositionControl.Size = new Size(234, 203);
            cameraPositionControl.TabIndex = 9;
            cameraPositionControl.DataChanged += cameraPositionControl_DataChanged;
            cameraPositionControl.DataReset += cameraPositionControl_DataReset;
            // 
            // groupBoxEnemy
            // 
            groupBoxEnemy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxEnemy.Controls.Add(numericEnemyX);
            groupBoxEnemy.Controls.Add(labelEnemyX);
            groupBoxEnemy.Controls.Add(labelEnemyY);
            groupBoxEnemy.Controls.Add(numericEnemyY);
            groupBoxEnemy.Controls.Add(labelEnemyZ);
            groupBoxEnemy.Controls.Add(numericEnemyZ);
            groupBoxEnemy.Enabled = false;
            groupBoxEnemy.Location = new Point(498, 303);
            groupBoxEnemy.Name = "groupBoxEnemy";
            groupBoxEnemy.Size = new Size(234, 69);
            groupBoxEnemy.TabIndex = 22;
            groupBoxEnemy.TabStop = false;
            groupBoxEnemy.Text = "Selected Enemy";
            // 
            // numericEnemyX
            // 
            numericEnemyX.Location = new Point(6, 37);
            numericEnemyX.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericEnemyX.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            numericEnemyX.Name = "numericEnemyX";
            numericEnemyX.Size = new Size(68, 23);
            numericEnemyX.TabIndex = 10;
            numericEnemyX.ValueChanged += numericEnemy_ValueChanged;
            // 
            // labelEnemyX
            // 
            labelEnemyX.AutoSize = true;
            labelEnemyX.Location = new Point(6, 19);
            labelEnemyX.Name = "labelEnemyX";
            labelEnemyX.Size = new Size(17, 15);
            labelEnemyX.TabIndex = 9;
            labelEnemyX.Text = "X:";
            // 
            // labelEnemyY
            // 
            labelEnemyY.AutoSize = true;
            labelEnemyY.Location = new Point(80, 19);
            labelEnemyY.Name = "labelEnemyY";
            labelEnemyY.Size = new Size(17, 15);
            labelEnemyY.TabIndex = 11;
            labelEnemyY.Text = "Y:";
            // 
            // numericEnemyY
            // 
            numericEnemyY.Location = new Point(80, 37);
            numericEnemyY.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericEnemyY.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            numericEnemyY.Name = "numericEnemyY";
            numericEnemyY.Size = new Size(68, 23);
            numericEnemyY.TabIndex = 12;
            // 
            // labelEnemyZ
            // 
            labelEnemyZ.AutoSize = true;
            labelEnemyZ.Location = new Point(154, 19);
            labelEnemyZ.Name = "labelEnemyZ";
            labelEnemyZ.Size = new Size(17, 15);
            labelEnemyZ.TabIndex = 13;
            labelEnemyZ.Text = "Z:";
            // 
            // numericEnemyZ
            // 
            numericEnemyZ.Location = new Point(154, 37);
            numericEnemyZ.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericEnemyZ.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            numericEnemyZ.Name = "numericEnemyZ";
            numericEnemyZ.Size = new Size(68, 23);
            numericEnemyZ.TabIndex = 14;
            // 
            // buttonReset
            // 
            buttonReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonReset.Location = new Point(193, 386);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(175, 23);
            buttonReset.TabIndex = 23;
            buttonReset.Text = "Reset all changes";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // Formation3DEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(744, 421);
            Controls.Add(buttonReset);
            Controls.Add(groupBoxEnemy);
            Controls.Add(cameraPositionControl);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(labelCurrCamera);
            Controls.Add(buttonCancel);
            Controls.Add(buttonCommit);
            Controls.Add(glControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(760, 460);
            Name = "Formation3DEditorForm";
            Text = "Edit formation";
            FormClosing += Formation3DEditorForm_FormClosing;
            FormClosed += Formation3DEditorForm_FormClosed;
            Load += Formation3DEditorForm_Load;
            groupBoxEnemy.ResumeLayout(false);
            groupBoxEnemy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericEnemyX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyZ).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenTK.GLControl.GLControl glControl;
        private Button buttonCommit;
        private Button buttonCancel;
        private Label labelCurrCamera;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Controls.CameraPositionControl cameraPositionControl;
        private GroupBox groupBoxEnemy;
        private NumericUpDown numericEnemyX;
        private Label labelEnemyX;
        private Label labelEnemyY;
        private NumericUpDown numericEnemyY;
        private Label labelEnemyZ;
        private NumericUpDown numericEnemyZ;
        private Button buttonReset;
    }
}