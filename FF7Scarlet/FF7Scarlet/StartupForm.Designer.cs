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
            buttonBattleDataEditor = new Button();
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
            groupBoxKernel.SuspendLayout();
            groupBoxKernel2.SuspendLayout();
            groupBoxScene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // buttonKernelEditor
            // 
            buttonKernelEditor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonKernelEditor.Enabled = false;
            buttonKernelEditor.Location = new Point(257, 245);
            buttonKernelEditor.Margin = new Padding(4, 3, 4, 3);
            buttonKernelEditor.Name = "buttonKernelEditor";
            buttonKernelEditor.Size = new Size(314, 27);
            buttonKernelEditor.TabIndex = 0;
            buttonKernelEditor.Text = "Open Kernel Editor";
            buttonKernelEditor.UseVisualStyleBackColor = true;
            buttonKernelEditor.Click += buttonKernelEditor_Click;
            // 
            // buttonBattleDataEditor
            // 
            buttonBattleDataEditor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonBattleDataEditor.Enabled = false;
            buttonBattleDataEditor.Location = new Point(257, 279);
            buttonBattleDataEditor.Margin = new Padding(4, 3, 4, 3);
            buttonBattleDataEditor.Name = "buttonBattleDataEditor";
            buttonBattleDataEditor.Size = new Size(314, 27);
            buttonBattleDataEditor.TabIndex = 1;
            buttonBattleDataEditor.Text = "Open Scene Editor";
            buttonBattleDataEditor.UseVisualStyleBackColor = true;
            buttonBattleDataEditor.Click += buttonBattleDataEditor_Click;
            // 
            // buttonKernelBrowse
            // 
            buttonKernelBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonKernelBrowse.Location = new Point(218, 21);
            buttonKernelBrowse.Margin = new Padding(4, 3, 4, 3);
            buttonKernelBrowse.Name = "buttonKernelBrowse";
            buttonKernelBrowse.Size = new Size(88, 27);
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
            groupBoxKernel.Location = new Point(257, 12);
            groupBoxKernel.Margin = new Padding(4, 3, 4, 3);
            groupBoxKernel.Name = "groupBoxKernel";
            groupBoxKernel.Padding = new Padding(4, 3, 4, 3);
            groupBoxKernel.Size = new Size(314, 55);
            groupBoxKernel.TabIndex = 5;
            groupBoxKernel.TabStop = false;
            groupBoxKernel.Text = "KERNEL.BIN";
            // 
            // textBoxKernel
            // 
            textBoxKernel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxKernel.Location = new Point(7, 24);
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
            groupBoxKernel2.Location = new Point(257, 74);
            groupBoxKernel2.Margin = new Padding(4, 3, 4, 3);
            groupBoxKernel2.Name = "groupBoxKernel2";
            groupBoxKernel2.Padding = new Padding(4, 3, 4, 3);
            groupBoxKernel2.Size = new Size(314, 55);
            groupBoxKernel2.TabIndex = 6;
            groupBoxKernel2.TabStop = false;
            groupBoxKernel2.Text = "kernel2.bin";
            // 
            // textBoxKernel2
            // 
            textBoxKernel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxKernel2.Enabled = false;
            textBoxKernel2.Location = new Point(7, 24);
            textBoxKernel2.Margin = new Padding(4, 3, 4, 3);
            textBoxKernel2.Name = "textBoxKernel2";
            textBoxKernel2.Size = new Size(204, 23);
            textBoxKernel2.TabIndex = 5;
            // 
            // buttonKernel2Browse
            // 
            buttonKernel2Browse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonKernel2Browse.Enabled = false;
            buttonKernel2Browse.Location = new Point(219, 20);
            buttonKernel2Browse.Margin = new Padding(4, 3, 4, 3);
            buttonKernel2Browse.Name = "buttonKernel2Browse";
            buttonKernel2Browse.Size = new Size(88, 27);
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
            groupBoxScene.Location = new Point(257, 135);
            groupBoxScene.Margin = new Padding(4, 3, 4, 3);
            groupBoxScene.Name = "groupBoxScene";
            groupBoxScene.Padding = new Padding(4, 3, 4, 3);
            groupBoxScene.Size = new Size(314, 55);
            groupBoxScene.TabIndex = 7;
            groupBoxScene.TabStop = false;
            groupBoxScene.Text = "scene.bin";
            // 
            // textBoxScene
            // 
            textBoxScene.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxScene.Location = new Point(7, 24);
            textBoxScene.Margin = new Padding(4, 3, 4, 3);
            textBoxScene.Name = "textBoxScene";
            textBoxScene.Size = new Size(202, 23);
            textBoxScene.TabIndex = 5;
            // 
            // buttonSceneBrowse
            // 
            buttonSceneBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSceneBrowse.Location = new Point(217, 21);
            buttonSceneBrowse.Margin = new Padding(4, 3, 4, 3);
            buttonSceneBrowse.Name = "buttonSceneBrowse";
            buttonSceneBrowse.Size = new Size(88, 27);
            buttonSceneBrowse.TabIndex = 3;
            buttonSceneBrowse.Text = "Browse...";
            buttonSceneBrowse.UseVisualStyleBackColor = true;
            buttonSceneBrowse.Click += buttonSceneBrowse_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.logo;
            pictureBoxLogo.Location = new Point(0, 1);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(250, 317);
            pictureBoxLogo.TabIndex = 8;
            pictureBoxLogo.TabStop = false;
            // 
            // StartupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 318);
            Controls.Add(pictureBoxLogo);
            Controls.Add(groupBoxScene);
            Controls.Add(groupBoxKernel2);
            Controls.Add(groupBoxKernel);
            Controls.Add(buttonBattleDataEditor);
            Controls.Add(buttonKernelEditor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "StartupForm";
            Text = "Scarlet - Main Menu";
            groupBoxKernel.ResumeLayout(false);
            groupBoxKernel.PerformLayout();
            groupBoxKernel2.ResumeLayout(false);
            groupBoxKernel2.PerformLayout();
            groupBoxScene.ResumeLayout(false);
            groupBoxScene.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonKernelEditor;
        private System.Windows.Forms.Button buttonBattleDataEditor;
        private System.Windows.Forms.Button buttonKernelBrowse;
        private System.Windows.Forms.GroupBox groupBoxKernel;
        private System.Windows.Forms.TextBox textBoxKernel;
        private System.Windows.Forms.GroupBox groupBoxKernel2;
        private System.Windows.Forms.TextBox textBoxKernel2;
        private System.Windows.Forms.Button buttonKernel2Browse;
        private System.Windows.Forms.GroupBox groupBoxScene;
        private System.Windows.Forms.TextBox textBoxScene;
        private System.Windows.Forms.Button buttonSceneBrowse;
        private System.Windows.Forms.ToolTip toolTipHoverText;
        private PictureBox pictureBoxLogo;
    }
}