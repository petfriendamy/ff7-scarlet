
namespace FF7Scarlet.AIEditor
{
    partial class BattleAIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleAIForm));
            this.groupBoxScripts = new System.Windows.Forms.GroupBox();
            this.listBoxScripts = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.groupBoxEnemies = new System.Windows.Forms.GroupBox();
            this.listBoxEnemies = new System.Windows.Forms.ListBox();
            this.comboBoxSceneList = new System.Windows.Forms.ComboBox();
            this.labelScenes = new System.Windows.Forms.Label();
            this.buttonExportMulti = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBoxScripts.SuspendLayout();
            this.groupBoxEnemies.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxScripts
            // 
            this.groupBoxScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxScripts.Controls.Add(this.listBoxScripts);
            this.groupBoxScripts.Location = new System.Drawing.Point(10, 126);
            this.groupBoxScripts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxScripts.Name = "groupBoxScripts";
            this.groupBoxScripts.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxScripts.Size = new System.Drawing.Size(175, 272);
            this.groupBoxScripts.TabIndex = 2;
            this.groupBoxScripts.TabStop = false;
            this.groupBoxScripts.Text = "Scripts";
            // 
            // listBoxScripts
            // 
            this.listBoxScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxScripts.Enabled = false;
            this.listBoxScripts.FormattingEnabled = true;
            this.listBoxScripts.ItemHeight = 15;
            this.listBoxScripts.Items.AddRange(new object[] {
            "Pre-Battle",
            "Main",
            "General Counter",
            "Death Counter",
            "Physical Counter",
            "Magic Counter",
            "Battle Victory",
            "Pre-Action Setup",
            "Custom Event 1",
            "Custom Event 2",
            "Custom Event 3",
            "Custom Event 4",
            "Custom Event 5",
            "Custom Event 6",
            "Custom Event 7",
            "Custom Event 8"});
            this.listBoxScripts.Location = new System.Drawing.Point(4, 19);
            this.listBoxScripts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxScripts.Name = "listBoxScripts";
            this.listBoxScripts.Size = new System.Drawing.Size(167, 250);
            this.listBoxScripts.TabIndex = 2;
            this.listBoxScripts.SelectedIndexChanged += new System.EventHandler(this.listBoxScripts_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(10, 405);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(175, 27);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save scene.bin";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExport.Location = new System.Drawing.Point(10, 472);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(175, 27);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "Export scene(s)...";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // groupBoxEnemies
            // 
            this.groupBoxEnemies.Controls.Add(this.listBoxEnemies);
            this.groupBoxEnemies.Location = new System.Drawing.Point(10, 46);
            this.groupBoxEnemies.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxEnemies.Name = "groupBoxEnemies";
            this.groupBoxEnemies.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxEnemies.Size = new System.Drawing.Size(175, 73);
            this.groupBoxEnemies.TabIndex = 1;
            this.groupBoxEnemies.TabStop = false;
            this.groupBoxEnemies.Text = "Enemies";
            // 
            // listBoxEnemies
            // 
            this.listBoxEnemies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEnemies.FormattingEnabled = true;
            this.listBoxEnemies.ItemHeight = 15;
            this.listBoxEnemies.Location = new System.Drawing.Point(4, 19);
            this.listBoxEnemies.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxEnemies.Name = "listBoxEnemies";
            this.listBoxEnemies.Size = new System.Drawing.Size(167, 51);
            this.listBoxEnemies.TabIndex = 1;
            this.listBoxEnemies.SelectedIndexChanged += new System.EventHandler(this.listBoxEnemies_SelectedIndexChanged);
            // 
            // comboBoxSceneList
            // 
            this.comboBoxSceneList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSceneList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSceneList.FormattingEnabled = true;
            this.comboBoxSceneList.Location = new System.Drawing.Point(75, 14);
            this.comboBoxSceneList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxSceneList.Name = "comboBoxSceneList";
            this.comboBoxSceneList.Size = new System.Drawing.Size(639, 23);
            this.comboBoxSceneList.TabIndex = 0;
            this.comboBoxSceneList.SelectedIndexChanged += new System.EventHandler(this.comboBoxSceneList_SelectedIndexChanged);
            // 
            // labelScenes
            // 
            this.labelScenes.AutoSize = true;
            this.labelScenes.Location = new System.Drawing.Point(14, 17);
            this.labelScenes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelScenes.Name = "labelScenes";
            this.labelScenes.Size = new System.Drawing.Size(46, 15);
            this.labelScenes.TabIndex = 7;
            this.labelScenes.Text = "Scenes:";
            // 
            // buttonExportMulti
            // 
            this.buttonExportMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExportMulti.Location = new System.Drawing.Point(10, 438);
            this.buttonExportMulti.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonExportMulti.Name = "buttonExportMulti";
            this.buttonExportMulti.Size = new System.Drawing.Size(175, 27);
            this.buttonExportMulti.TabIndex = 4;
            this.buttonExportMulti.Text = "Import scene(s)...";
            this.buttonExportMulti.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 505);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(728, 27);
            this.progressBar1.TabIndex = 9;
            // 
            // BattleAIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 532);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonExportMulti);
            this.Controls.Add(this.labelScenes);
            this.Controls.Add(this.comboBoxSceneList);
            this.Controls.Add(this.groupBoxEnemies);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxScripts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(651, 479);
            this.Name = "BattleAIForm";
            this.Text = "Scarlet - Battle A.I. Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BattleAIForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BattleAIForm_FormClosed);
            this.Load += new System.EventHandler(this.BattleAIForm_Load);
            this.groupBoxScripts.ResumeLayout(false);
            this.groupBoxEnemies.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxScripts;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ListBox listBoxScripts;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.GroupBox groupBoxEnemies;
        private System.Windows.Forms.ListBox listBoxEnemies;
        private System.Windows.Forms.ComboBox comboBoxSceneList;
        private System.Windows.Forms.Label labelScenes;
        private System.Windows.Forms.Button buttonExportMulti;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ScriptControl scriptControl;
    }
}

