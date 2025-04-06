namespace FF7Scarlet
{
    partial class StartupForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            buttonKernelEditor = new Button();
            buttonSceneEditor = new Button();
            buttonKernelBrowse = new Button();
            groupBoxKernel = new GroupBox();
            textBoxKernel = new TextBox();
            groupBoxKernel2 = new GroupBox();
            textBoxKernel2 = new TextBox();
            buttonKernel2Browse = new Button();
            groupBoxScene = new GroupBox();
            textBoxScene = new TextBox();
            buttonSceneBrowse = new Button();
            toolTipHoverText = new ToolTip(components);
            pictureBoxLogo = new PictureBox();
            buttonSettings = new Button();
            buttonExeEditor = new Button();
            groupBoxEXE = new GroupBox();
            textBoxEXE = new TextBox();
            buttonEXEbrowse = new Button();
            groupBoxKernel.SuspendLayout();
            groupBoxKernel2.SuspendLayout();
            groupBoxScene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            groupBoxEXE.SuspendLayout();
            SuspendLayout();
            // 
            // buttonKernelEditor
            // 
            buttonKernelEditor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonKernelEditor.Enabled = false;
            buttonKernelEditor.Location = new Point(257, 260);
            buttonKernelEditor.Margin = new Padding(4, 3, 4, 3);
            buttonKernelEditor.Name = "buttonKernelEditor";
            buttonKernelEditor.Size = new Size(153, 24);
            buttonKernelEditor.TabIndex = 4;
            buttonKernelEditor.Text = "Open Kernel Editor";
            buttonKernelEditor.UseVisualStyleBackColor = true;
            buttonKernelEditor.Click += buttonKernelEditor_Click;
            // 
            // buttonSceneEditor
            // 
            buttonSceneEditor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonSceneEditor.Enabled = false;
            buttonSceneEditor.Location = new Point(418, 260);
            buttonSceneEditor.Margin = new Padding(4, 3, 4, 3);
            buttonSceneEditor.Name = "buttonSceneEditor";
            buttonSceneEditor.Size = new Size(153, 24);
            buttonSceneEditor.TabIndex = 5;
            buttonSceneEditor.Text = "Open Scene Editor";
            buttonSceneEditor.UseVisualStyleBackColor = true;
            buttonSceneEditor.Click += buttonSceneEditor_Click;
            // 
            // buttonKernelBrowse
            // 
            buttonKernelBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonKernelBrowse.Location = new Point(219, 21);
            buttonKernelBrowse.Margin = new Padding(4, 3, 4, 3);
            buttonKernelBrowse.Name = "buttonKernelBrowse";
            buttonKernelBrowse.Size = new Size(88, 24);
            buttonKernelBrowse.TabIndex = 3;
            buttonKernelBrowse.Text = "Browse...";
            buttonKernelBrowse.UseVisualStyleBackColor = true;
            buttonKernelBrowse.Click += buttonKernelBrowse_Click;
            // 
            // groupBoxKernel
            // 
            groupBoxKernel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxKernel.Controls.Add(textBoxKernel);
            groupBoxKernel.Controls.Add(buttonKernelBrowse);
            groupBoxKernel.Location = new Point(257, 70);
            groupBoxKernel.Margin = new Padding(4, 3, 4, 3);
            groupBoxKernel.Name = "groupBoxKernel";
            groupBoxKernel.Padding = new Padding(4, 3, 4, 3);
            groupBoxKernel.Size = new Size(314, 55);
            groupBoxKernel.TabIndex = 1;
            groupBoxKernel.TabStop = false;
            groupBoxKernel.Text = "KERNEL.BIN";
            // 
            // textBoxKernel
            // 
            textBoxKernel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxKernel.Location = new Point(7, 22);
            textBoxKernel.Margin = new Padding(4, 3, 4, 3);
            textBoxKernel.Name = "textBoxKernel";
            textBoxKernel.Size = new Size(203, 23);
            textBoxKernel.TabIndex = 5;
            // 
            // groupBoxKernel2
            // 
            groupBoxKernel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxKernel2.Controls.Add(textBoxKernel2);
            groupBoxKernel2.Controls.Add(buttonKernel2Browse);
            groupBoxKernel2.Location = new Point(257, 131);
            groupBoxKernel2.Margin = new Padding(4, 3, 4, 3);
            groupBoxKernel2.Name = "groupBoxKernel2";
            groupBoxKernel2.Padding = new Padding(4, 3, 4, 3);
            groupBoxKernel2.Size = new Size(314, 55);
            groupBoxKernel2.TabIndex = 2;
            groupBoxKernel2.TabStop = false;
            groupBoxKernel2.Text = "kernel2.bin";
            // 
            // textBoxKernel2
            // 
            textBoxKernel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxKernel2.Enabled = false;
            textBoxKernel2.Location = new Point(7, 22);
            textBoxKernel2.Margin = new Padding(4, 3, 4, 3);
            textBoxKernel2.Name = "textBoxKernel2";
            textBoxKernel2.Size = new Size(204, 23);
            textBoxKernel2.TabIndex = 5;
            // 
            // buttonKernel2Browse
            // 
            buttonKernel2Browse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonKernel2Browse.Enabled = false;
            buttonKernel2Browse.Location = new Point(219, 22);
            buttonKernel2Browse.Margin = new Padding(4, 3, 4, 3);
            buttonKernel2Browse.Name = "buttonKernel2Browse";
            buttonKernel2Browse.Size = new Size(88, 23);
            buttonKernel2Browse.TabIndex = 3;
            buttonKernel2Browse.Text = "Browse...";
            buttonKernel2Browse.UseVisualStyleBackColor = true;
            buttonKernel2Browse.Click += buttonKernel2Browse_Click;
            // 
            // groupBoxScene
            // 
            groupBoxScene.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxScene.Controls.Add(textBoxScene);
            groupBoxScene.Controls.Add(buttonSceneBrowse);
            groupBoxScene.Location = new Point(257, 192);
            groupBoxScene.Margin = new Padding(4, 3, 4, 3);
            groupBoxScene.Name = "groupBoxScene";
            groupBoxScene.Padding = new Padding(4, 3, 4, 3);
            groupBoxScene.Size = new Size(314, 55);
            groupBoxScene.TabIndex = 3;
            groupBoxScene.TabStop = false;
            groupBoxScene.Text = "scene.bin";
            // 
            // textBoxScene
            // 
            textBoxScene.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxScene.Location = new Point(7, 22);
            textBoxScene.Margin = new Padding(4, 3, 4, 3);
            textBoxScene.Name = "textBoxScene";
            textBoxScene.Size = new Size(204, 23);
            textBoxScene.TabIndex = 5;
            // 
            // buttonSceneBrowse
            // 
            buttonSceneBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSceneBrowse.Location = new Point(219, 20);
            buttonSceneBrowse.Margin = new Padding(4, 3, 4, 3);
            buttonSceneBrowse.Name = "buttonSceneBrowse";
            buttonSceneBrowse.Size = new Size(88, 24);
            buttonSceneBrowse.TabIndex = 3;
            buttonSceneBrowse.Text = "Browse...";
            buttonSceneBrowse.UseVisualStyleBackColor = true;
            buttonSceneBrowse.Click += buttonSceneBrowse_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBoxLogo.Image = Properties.Resources.logo;
            pictureBoxLogo.Location = new Point(0, 9);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(250, 317);
            pictureBoxLogo.TabIndex = 8;
            pictureBoxLogo.TabStop = false;
            // 
            // buttonSettings
            // 
            buttonSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonSettings.Location = new Point(418, 290);
            buttonSettings.Margin = new Padding(4, 3, 4, 3);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(153, 24);
            buttonSettings.TabIndex = 7;
            buttonSettings.Text = "Settings...";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // buttonExeEditor
            // 
            buttonExeEditor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonExeEditor.Enabled = false;
            buttonExeEditor.Location = new Point(257, 290);
            buttonExeEditor.Margin = new Padding(4, 3, 4, 3);
            buttonExeEditor.Name = "buttonExeEditor";
            buttonExeEditor.Size = new Size(153, 24);
            buttonExeEditor.TabIndex = 6;
            buttonExeEditor.Text = "Open EXE Editor";
            buttonExeEditor.UseVisualStyleBackColor = true;
            buttonExeEditor.Click += buttonEXEeditor_Click;
            // 
            // groupBoxEXE
            // 
            groupBoxEXE.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxEXE.Controls.Add(textBoxEXE);
            groupBoxEXE.Controls.Add(buttonEXEbrowse);
            groupBoxEXE.Location = new Point(257, 9);
            groupBoxEXE.Margin = new Padding(4, 3, 4, 3);
            groupBoxEXE.Name = "groupBoxEXE";
            groupBoxEXE.Padding = new Padding(4, 3, 4, 3);
            groupBoxEXE.Size = new Size(314, 55);
            groupBoxEXE.TabIndex = 0;
            groupBoxEXE.TabStop = false;
            groupBoxEXE.Text = "ff7.exe";
            // 
            // textBoxEXE
            // 
            textBoxEXE.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxEXE.Location = new Point(8, 22);
            textBoxEXE.Margin = new Padding(4, 3, 4, 3);
            textBoxEXE.Name = "textBoxEXE";
            textBoxEXE.Size = new Size(203, 23);
            textBoxEXE.TabIndex = 5;
            // 
            // buttonEXEbrowse
            // 
            buttonEXEbrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEXEbrowse.Location = new Point(219, 21);
            buttonEXEbrowse.Margin = new Padding(4, 3, 4, 3);
            buttonEXEbrowse.Name = "buttonEXEbrowse";
            buttonEXEbrowse.Size = new Size(88, 24);
            buttonEXEbrowse.TabIndex = 3;
            buttonEXEbrowse.Text = "Browse...";
            buttonEXEbrowse.UseVisualStyleBackColor = true;
            buttonEXEbrowse.Click += buttonEXEbrowse_Click;
            // 
            // StartupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 326);
            Controls.Add(groupBoxEXE);
            Controls.Add(buttonExeEditor);
            Controls.Add(buttonSettings);
            Controls.Add(pictureBoxLogo);
            Controls.Add(groupBoxScene);
            Controls.Add(groupBoxKernel2);
            Controls.Add(groupBoxKernel);
            Controls.Add(buttonSceneEditor);
            Controls.Add(buttonKernelEditor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "StartupForm";
            Text = "Scarlet - Main Menu";
            Load += StartupForm_Load;
            groupBoxKernel.ResumeLayout(false);
            groupBoxKernel.PerformLayout();
            groupBoxKernel2.ResumeLayout(false);
            groupBoxKernel2.PerformLayout();
            groupBoxScene.ResumeLayout(false);
            groupBoxScene.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            groupBoxEXE.ResumeLayout(false);
            groupBoxEXE.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonKernelEditor;
        private Button buttonSceneEditor;
        private Button buttonKernelBrowse;
        private GroupBox groupBoxKernel;
        private TextBox textBoxKernel;
        private GroupBox groupBoxKernel2;
        private TextBox textBoxKernel2;
        private Button buttonKernel2Browse;
        private GroupBox groupBoxScene;
        private TextBox textBoxScene;
        private Button buttonSceneBrowse;
        private ToolTip toolTipHoverText;
        private PictureBox pictureBoxLogo;
        private Button buttonSettings;
        private Button buttonExeEditor;
        private GroupBox groupBoxEXE;
        private TextBox textBoxEXE;
        private Button buttonEXEbrowse;
    }
}