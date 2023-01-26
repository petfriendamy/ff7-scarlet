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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxKernel.SuspendLayout();
            this.groupBoxKernel2.SuspendLayout();
            this.groupBoxScene.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKernelEditor
            // 
            this.buttonKernelEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKernelEditor.Enabled = false;
            this.buttonKernelEditor.Location = new System.Drawing.Point(12, 183);
            this.buttonKernelEditor.Name = "buttonKernelEditor";
            this.buttonKernelEditor.Size = new System.Drawing.Size(459, 23);
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
            this.buttonBattleDataEditor.Location = new System.Drawing.Point(13, 212);
            this.buttonBattleDataEditor.Name = "buttonBattleDataEditor";
            this.buttonBattleDataEditor.Size = new System.Drawing.Size(459, 23);
            this.buttonBattleDataEditor.TabIndex = 1;
            this.buttonBattleDataEditor.Text = "Open Battle Data Editor";
            this.buttonBattleDataEditor.UseVisualStyleBackColor = true;
            // 
            // buttonAIEditor
            // 
            this.buttonAIEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAIEditor.Enabled = false;
            this.buttonAIEditor.Location = new System.Drawing.Point(13, 241);
            this.buttonAIEditor.Name = "buttonAIEditor";
            this.buttonAIEditor.Size = new System.Drawing.Size(459, 23);
            this.buttonAIEditor.TabIndex = 2;
            this.buttonAIEditor.Text = "Open Battle A.I. Editor";
            this.buttonAIEditor.UseVisualStyleBackColor = true;
            this.buttonAIEditor.Click += new System.EventHandler(this.buttonAIEditor_Click);
            // 
            // buttonKernelBrowse
            // 
            this.buttonKernelBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKernelBrowse.Location = new System.Drawing.Point(379, 19);
            this.buttonKernelBrowse.Name = "buttonKernelBrowse";
            this.buttonKernelBrowse.Size = new System.Drawing.Size(75, 23);
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
            this.groupBoxKernel.Location = new System.Drawing.Point(12, 13);
            this.groupBoxKernel.Name = "groupBoxKernel";
            this.groupBoxKernel.Size = new System.Drawing.Size(460, 48);
            this.groupBoxKernel.TabIndex = 5;
            this.groupBoxKernel.TabStop = false;
            this.groupBoxKernel.Text = "KERNEL.BIN";
            // 
            // textBoxKernel
            // 
            this.textBoxKernel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKernel.Location = new System.Drawing.Point(6, 21);
            this.textBoxKernel.Name = "textBoxKernel";
            this.textBoxKernel.Size = new System.Drawing.Size(367, 20);
            this.textBoxKernel.TabIndex = 5;
            // 
            // groupBoxKernel2
            // 
            this.groupBoxKernel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxKernel2.Controls.Add(this.textBoxKernel2);
            this.groupBoxKernel2.Controls.Add(this.buttonKernel2Browse);
            this.groupBoxKernel2.Location = new System.Drawing.Point(11, 67);
            this.groupBoxKernel2.Name = "groupBoxKernel2";
            this.groupBoxKernel2.Size = new System.Drawing.Size(460, 48);
            this.groupBoxKernel2.TabIndex = 6;
            this.groupBoxKernel2.TabStop = false;
            this.groupBoxKernel2.Text = "kernel2.bin";
            // 
            // textBoxKernel2
            // 
            this.textBoxKernel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKernel2.Enabled = false;
            this.textBoxKernel2.Location = new System.Drawing.Point(6, 21);
            this.textBoxKernel2.Name = "textBoxKernel2";
            this.textBoxKernel2.Size = new System.Drawing.Size(367, 20);
            this.textBoxKernel2.TabIndex = 5;
            // 
            // buttonKernel2Browse
            // 
            this.buttonKernel2Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKernel2Browse.Enabled = false;
            this.buttonKernel2Browse.Location = new System.Drawing.Point(379, 19);
            this.buttonKernel2Browse.Name = "buttonKernel2Browse";
            this.buttonKernel2Browse.Size = new System.Drawing.Size(75, 23);
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
            this.groupBoxScene.Location = new System.Drawing.Point(13, 121);
            this.groupBoxScene.Name = "groupBoxScene";
            this.groupBoxScene.Size = new System.Drawing.Size(460, 48);
            this.groupBoxScene.TabIndex = 7;
            this.groupBoxScene.TabStop = false;
            this.groupBoxScene.Text = "scene.bin";
            // 
            // textBoxScene
            // 
            this.textBoxScene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScene.Location = new System.Drawing.Point(6, 21);
            this.textBoxScene.Name = "textBoxScene";
            this.textBoxScene.Size = new System.Drawing.Size(367, 20);
            this.textBoxScene.TabIndex = 5;
            // 
            // buttonSceneBrowse
            // 
            this.buttonSceneBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSceneBrowse.Location = new System.Drawing.Point(379, 19);
            this.buttonSceneBrowse.Name = "buttonSceneBrowse";
            this.buttonSceneBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonSceneBrowse.TabIndex = 3;
            this.buttonSceneBrowse.Text = "Browse...";
            this.buttonSceneBrowse.UseVisualStyleBackColor = true;
            this.buttonSceneBrowse.Click += new System.EventHandler(this.buttonSceneBrowse_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 276);
            this.Controls.Add(this.groupBoxScene);
            this.Controls.Add(this.groupBoxKernel2);
            this.Controls.Add(this.groupBoxKernel);
            this.Controls.Add(this.buttonAIEditor);
            this.Controls.Add(this.buttonBattleDataEditor);
            this.Controls.Add(this.buttonKernelEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartupForm";
            this.Text = "Scarlet - Main Menu";
            this.groupBoxKernel.ResumeLayout(false);
            this.groupBoxKernel.PerformLayout();
            this.groupBoxKernel2.ResumeLayout(false);
            this.groupBoxKernel2.PerformLayout();
            this.groupBoxScene.ResumeLayout(false);
            this.groupBoxScene.PerformLayout();
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
        private System.Windows.Forms.ToolTip toolTip1;
    }
}