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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            this.buttonKernelEditor = new System.Windows.Forms.Button();
            this.buttonBattleDataEditor = new System.Windows.Forms.Button();
            this.buttonAIEditor = new System.Windows.Forms.Button();
            this.buttonKernelBrowse = new System.Windows.Forms.Button();
            this.groupBoxKernel = new System.Windows.Forms.GroupBox();
            this.textBoxKernel = new System.Windows.Forms.TextBox();
            this.groupBoxKernel2 = new System.Windows.Forms.GroupBox();
            this.textBoxKernel2 = new System.Windows.Forms.TextBox();
            this.buttonKernel2Browse = new System.Windows.Forms.Button();
            this.groupBoxScene = new System.Windows.Forms.GroupBox();
            this.textBoxScene = new System.Windows.Forms.TextBox();
            this.buttonSceneBrowse = new System.Windows.Forms.Button();
            this.toolTipHoverText = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxKernel.SuspendLayout();
            this.groupBoxKernel2.SuspendLayout();
            this.groupBoxScene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonKernelEditor
            // 
            this.buttonKernelEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKernelEditor.Enabled = false;
            this.buttonKernelEditor.Location = new System.Drawing.Point(257, 211);
            this.buttonKernelEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonKernelEditor.Name = "buttonKernelEditor";
            this.buttonKernelEditor.Size = new System.Drawing.Size(314, 27);
            this.buttonKernelEditor.TabIndex = 0;
            this.buttonKernelEditor.Text = "Open Kernel Editor";
            this.buttonKernelEditor.UseVisualStyleBackColor = true;
            this.buttonKernelEditor.Click += new System.EventHandler(this.buttonKernelEditor_Click);
            // 
            // buttonBattleDataEditor
            // 
            this.buttonBattleDataEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBattleDataEditor.Enabled = false;
            this.buttonBattleDataEditor.Location = new System.Drawing.Point(257, 245);
            this.buttonBattleDataEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonBattleDataEditor.Name = "buttonBattleDataEditor";
            this.buttonBattleDataEditor.Size = new System.Drawing.Size(314, 27);
            this.buttonBattleDataEditor.TabIndex = 1;
            this.buttonBattleDataEditor.Text = "Open Battle Data Editor";
            this.buttonBattleDataEditor.UseVisualStyleBackColor = true;
            // 
            // buttonAIEditor
            // 
            this.buttonAIEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAIEditor.Enabled = false;
            this.buttonAIEditor.Location = new System.Drawing.Point(257, 278);
            this.buttonAIEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonAIEditor.Name = "buttonAIEditor";
            this.buttonAIEditor.Size = new System.Drawing.Size(314, 27);
            this.buttonAIEditor.TabIndex = 2;
            this.buttonAIEditor.Text = "Open Battle A.I. Editor";
            this.buttonAIEditor.UseVisualStyleBackColor = true;
            this.buttonAIEditor.Click += new System.EventHandler(this.buttonAIEditor_Click);
            // 
            // buttonKernelBrowse
            // 
            this.buttonKernelBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKernelBrowse.Location = new System.Drawing.Point(218, 21);
            this.buttonKernelBrowse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonKernelBrowse.Name = "buttonKernelBrowse";
            this.buttonKernelBrowse.Size = new System.Drawing.Size(88, 27);
            this.buttonKernelBrowse.TabIndex = 3;
            this.buttonKernelBrowse.Text = "Browse...";
            this.buttonKernelBrowse.UseVisualStyleBackColor = true;
            this.buttonKernelBrowse.Click += new System.EventHandler(this.buttonKernelBrowse_Click);
            // 
            // groupBoxKernel
            // 
            this.groupBoxKernel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxKernel.Controls.Add(this.textBoxKernel);
            this.groupBoxKernel.Controls.Add(this.buttonKernelBrowse);
            this.groupBoxKernel.Location = new System.Drawing.Point(257, 12);
            this.groupBoxKernel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxKernel.Name = "groupBoxKernel";
            this.groupBoxKernel.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxKernel.Size = new System.Drawing.Size(314, 55);
            this.groupBoxKernel.TabIndex = 5;
            this.groupBoxKernel.TabStop = false;
            this.groupBoxKernel.Text = "KERNEL.BIN";
            // 
            // textBoxKernel
            // 
            this.textBoxKernel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKernel.Location = new System.Drawing.Point(7, 24);
            this.textBoxKernel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKernel.Name = "textBoxKernel";
            this.textBoxKernel.Size = new System.Drawing.Size(203, 23);
            this.textBoxKernel.TabIndex = 5;
            // 
            // groupBoxKernel2
            // 
            this.groupBoxKernel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxKernel2.Controls.Add(this.textBoxKernel2);
            this.groupBoxKernel2.Controls.Add(this.buttonKernel2Browse);
            this.groupBoxKernel2.Location = new System.Drawing.Point(257, 74);
            this.groupBoxKernel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxKernel2.Name = "groupBoxKernel2";
            this.groupBoxKernel2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxKernel2.Size = new System.Drawing.Size(314, 55);
            this.groupBoxKernel2.TabIndex = 6;
            this.groupBoxKernel2.TabStop = false;
            this.groupBoxKernel2.Text = "kernel2.bin";
            // 
            // textBoxKernel2
            // 
            this.textBoxKernel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKernel2.Enabled = false;
            this.textBoxKernel2.Location = new System.Drawing.Point(7, 24);
            this.textBoxKernel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKernel2.Name = "textBoxKernel2";
            this.textBoxKernel2.Size = new System.Drawing.Size(204, 23);
            this.textBoxKernel2.TabIndex = 5;
            // 
            // buttonKernel2Browse
            // 
            this.buttonKernel2Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKernel2Browse.Enabled = false;
            this.buttonKernel2Browse.Location = new System.Drawing.Point(219, 20);
            this.buttonKernel2Browse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonKernel2Browse.Name = "buttonKernel2Browse";
            this.buttonKernel2Browse.Size = new System.Drawing.Size(88, 27);
            this.buttonKernel2Browse.TabIndex = 3;
            this.buttonKernel2Browse.Text = "Browse...";
            this.buttonKernel2Browse.UseVisualStyleBackColor = true;
            this.buttonKernel2Browse.Click += new System.EventHandler(this.buttonKernel2Browse_Click);
            // 
            // groupBoxScene
            // 
            this.groupBoxScene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxScene.Controls.Add(this.textBoxScene);
            this.groupBoxScene.Controls.Add(this.buttonSceneBrowse);
            this.groupBoxScene.Location = new System.Drawing.Point(257, 135);
            this.groupBoxScene.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxScene.Name = "groupBoxScene";
            this.groupBoxScene.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxScene.Size = new System.Drawing.Size(314, 55);
            this.groupBoxScene.TabIndex = 7;
            this.groupBoxScene.TabStop = false;
            this.groupBoxScene.Text = "scene.bin";
            // 
            // textBoxScene
            // 
            this.textBoxScene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScene.Location = new System.Drawing.Point(7, 24);
            this.textBoxScene.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxScene.Name = "textBoxScene";
            this.textBoxScene.Size = new System.Drawing.Size(202, 23);
            this.textBoxScene.TabIndex = 5;
            // 
            // buttonSceneBrowse
            // 
            this.buttonSceneBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSceneBrowse.Location = new System.Drawing.Point(217, 21);
            this.buttonSceneBrowse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSceneBrowse.Name = "buttonSceneBrowse";
            this.buttonSceneBrowse.Size = new System.Drawing.Size(88, 27);
            this.buttonSceneBrowse.TabIndex = 3;
            this.buttonSceneBrowse.Text = "Browse...";
            this.buttonSceneBrowse.UseVisualStyleBackColor = true;
            this.buttonSceneBrowse.Click += new System.EventHandler(this.buttonSceneBrowse_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxLogo.Image = global::FF7Scarlet.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(250, 317);
            this.pictureBoxLogo.TabIndex = 8;
            this.pictureBoxLogo.TabStop = false;
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 317);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.groupBoxScene);
            this.Controls.Add(this.groupBoxKernel2);
            this.Controls.Add(this.groupBoxKernel);
            this.Controls.Add(this.buttonAIEditor);
            this.Controls.Add(this.buttonBattleDataEditor);
            this.Controls.Add(this.buttonKernelEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 356);
            this.MinimumSize = new System.Drawing.Size(600, 356);
            this.Name = "StartupForm";
            this.Text = "Scarlet - Main Menu";
            this.groupBoxKernel.ResumeLayout(false);
            this.groupBoxKernel.PerformLayout();
            this.groupBoxKernel2.ResumeLayout(false);
            this.groupBoxKernel2.PerformLayout();
            this.groupBoxScene.ResumeLayout(false);
            this.groupBoxScene.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKernelEditor;
        private System.Windows.Forms.Button buttonBattleDataEditor;
        private System.Windows.Forms.Button buttonAIEditor;
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