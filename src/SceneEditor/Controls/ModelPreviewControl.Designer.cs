namespace FF7Scarlet.SceneEditor.Controls
{
    partial class ModelPreviewControl
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            glControl = new OpenTK.GLControl.GLControl();
            SuspendLayout();
            // 
            // glControl
            // 
            glControl.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl.APIVersion = new Version(3, 3, 0, 0);
            glControl.Dock = DockStyle.Fill;
            glControl.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl.IsEventDriven = true;
            glControl.Location = new Point(0, 0);
            glControl.Name = "glControl";
            glControl.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            glControl.SharedContext = null;
            glControl.Size = new Size(150, 150);
            glControl.TabIndex = 0;
            glControl.MouseDown += GlControl_MouseDown;
            glControl.MouseMove += GlControl_MouseMove;
            glControl.MouseUp += GlControl_MouseUp;
            glControl.MouseWheel += GlControl_MouseWheel;
            glControl.KeyDown += GlControl_KeyDown;
            // 
            // frameCounterLabel
            // 
            frameCounterLabel = new Label();
            frameCounterLabel.Name = "frameCounterLabel";
            frameCounterLabel.Text = "0/0";
            frameCounterLabel.AutoSize = false;
            frameCounterLabel.Size = new Size(50, 20);
            frameCounterLabel.Location = new Point(150, 5);
            frameCounterLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            frameCounterLabel.BackColor = Color.FromArgb(180, Color.FromArgb(102, 102, 166));
            frameCounterLabel.ForeColor = Color.White;
            frameCounterLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            frameCounterLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ModelPreviewControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(glControl);
            Controls.Add(frameCounterLabel);
            Name = "ModelPreviewControl";
            Load += ModelPreviewControl_Load;
            Enter += ModelPreviewControl_Enter;
            Paint += ModelPreviewControl_Paint;
            ResumeLayout(false);
        }

        #endregion

        private OpenTK.GLControl.GLControl glControl;
        private Label frameCounterLabel;
    }
}
