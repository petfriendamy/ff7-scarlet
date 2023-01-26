
namespace FF7Scarlet
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
            this.groupBoxCurrScript = new System.Windows.Forms.GroupBox();
            this.listBoxCurrScript = new System.Windows.Forms.ListBox();
            this.toolStripScript = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMoveUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.groupBoxEnemies = new System.Windows.Forms.GroupBox();
            this.listBoxEnemies = new System.Windows.Forms.ListBox();
            this.comboBoxSceneList = new System.Windows.Forms.ComboBox();
            this.labelScenes = new System.Windows.Forms.Label();
            this.buttonExportMulti = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBoxScripts.SuspendLayout();
            this.groupBoxCurrScript.SuspendLayout();
            this.toolStripScript.SuspendLayout();
            this.groupBoxEnemies.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxScripts
            // 
            this.groupBoxScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxScripts.Controls.Add(this.listBoxScripts);
            this.groupBoxScripts.Location = new System.Drawing.Point(9, 109);
            this.groupBoxScripts.Name = "groupBoxScripts";
            this.groupBoxScripts.Size = new System.Drawing.Size(150, 236);
            this.groupBoxScripts.TabIndex = 2;
            this.groupBoxScripts.TabStop = false;
            this.groupBoxScripts.Text = "Scripts";
            // 
            // listBoxScripts
            // 
            this.listBoxScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxScripts.Enabled = false;
            this.listBoxScripts.FormattingEnabled = true;
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
            this.listBoxScripts.Location = new System.Drawing.Point(3, 16);
            this.listBoxScripts.Name = "listBoxScripts";
            this.listBoxScripts.Size = new System.Drawing.Size(144, 217);
            this.listBoxScripts.TabIndex = 2;
            this.listBoxScripts.SelectedIndexChanged += new System.EventHandler(this.listBoxScripts_SelectedIndexChanged);
            // 
            // groupBoxCurrScript
            // 
            this.groupBoxCurrScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCurrScript.Controls.Add(this.listBoxCurrScript);
            this.groupBoxCurrScript.Controls.Add(this.toolStripScript);
            this.groupBoxCurrScript.Location = new System.Drawing.Point(165, 40);
            this.groupBoxCurrScript.Name = "groupBoxCurrScript";
            this.groupBoxCurrScript.Size = new System.Drawing.Size(447, 392);
            this.groupBoxCurrScript.TabIndex = 6;
            this.groupBoxCurrScript.TabStop = false;
            this.groupBoxCurrScript.Text = "Current script";
            // 
            // listBoxCurrScript
            // 
            this.listBoxCurrScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCurrScript.FormattingEnabled = true;
            this.listBoxCurrScript.HorizontalScrollbar = true;
            this.listBoxCurrScript.Location = new System.Drawing.Point(3, 41);
            this.listBoxCurrScript.Name = "listBoxCurrScript";
            this.listBoxCurrScript.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCurrScript.Size = new System.Drawing.Size(441, 348);
            this.listBoxCurrScript.TabIndex = 7;
            this.listBoxCurrScript.DoubleClick += new System.EventHandler(this.toolStripButtonEdit_Click);
            this.listBoxCurrScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxCurrScript_KeyDown);
            // 
            // toolStripScript
            // 
            this.toolStripScript.AllowMerge = false;
            this.toolStripScript.Enabled = false;
            this.toolStripScript.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonEdit,
            this.toolStripButtonCut,
            this.toolStripButtonCopy,
            this.toolStripButtonPaste,
            this.toolStripButtonMoveUp,
            this.toolStripButtonMoveDown,
            this.toolStripButtonDelete});
            this.toolStripScript.Location = new System.Drawing.Point(3, 16);
            this.toolStripScript.Name = "toolStripScript";
            this.toolStripScript.Size = new System.Drawing.Size(441, 25);
            this.toolStripScript.TabIndex = 6;
            this.toolStripScript.Text = "toolStripScript";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(33, 22);
            this.toolStripButtonAdd.Text = "Add";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEdit.Image")));
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(31, 22);
            this.toolStripButtonEdit.Text = "Edit";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripButtonCut
            // 
            this.toolStripButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCut.Image")));
            this.toolStripButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCut.Name = "toolStripButtonCut";
            this.toolStripButtonCut.Size = new System.Drawing.Size(30, 22);
            this.toolStripButtonCut.Text = "Cut";
            this.toolStripButtonCut.Click += new System.EventHandler(this.toolStripButtonCut_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopy.Image")));
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(39, 22);
            this.toolStripButtonCopy.Text = "Copy";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonPaste
            // 
            this.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPaste.Enabled = false;
            this.toolStripButtonPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPaste.Image")));
            this.toolStripButtonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPaste.Name = "toolStripButtonPaste";
            this.toolStripButtonPaste.Size = new System.Drawing.Size(39, 22);
            this.toolStripButtonPaste.Text = "Paste";
            this.toolStripButtonPaste.Click += new System.EventHandler(this.toolStripButtonPaste_Click);
            // 
            // toolStripButtonMoveUp
            // 
            this.toolStripButtonMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMoveUp.Image")));
            this.toolStripButtonMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveUp.Name = "toolStripButtonMoveUp";
            this.toolStripButtonMoveUp.Size = new System.Drawing.Size(59, 22);
            this.toolStripButtonMoveUp.Text = "Move Up";
            this.toolStripButtonMoveUp.Click += new System.EventHandler(this.toolStripButtonMoveUp_Click);
            // 
            // toolStripButtonMoveDown
            // 
            this.toolStripButtonMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMoveDown.Image")));
            this.toolStripButtonMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveDown.Name = "toolStripButtonMoveDown";
            this.toolStripButtonMoveDown.Size = new System.Drawing.Size(75, 22);
            this.toolStripButtonMoveDown.Text = "Move Down";
            this.toolStripButtonMoveDown.Click += new System.EventHandler(this.toolStripButtonMoveDown_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(44, 22);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(9, 351);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save scene.bin";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExport.Location = new System.Drawing.Point(9, 409);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(150, 23);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "Export scene(s)...";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // groupBoxEnemies
            // 
            this.groupBoxEnemies.Controls.Add(this.listBoxEnemies);
            this.groupBoxEnemies.Location = new System.Drawing.Point(9, 40);
            this.groupBoxEnemies.Name = "groupBoxEnemies";
            this.groupBoxEnemies.Size = new System.Drawing.Size(150, 63);
            this.groupBoxEnemies.TabIndex = 1;
            this.groupBoxEnemies.TabStop = false;
            this.groupBoxEnemies.Text = "Enemies";
            // 
            // listBoxEnemies
            // 
            this.listBoxEnemies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEnemies.FormattingEnabled = true;
            this.listBoxEnemies.Location = new System.Drawing.Point(3, 16);
            this.listBoxEnemies.Name = "listBoxEnemies";
            this.listBoxEnemies.Size = new System.Drawing.Size(144, 44);
            this.listBoxEnemies.TabIndex = 1;
            this.listBoxEnemies.SelectedIndexChanged += new System.EventHandler(this.listBoxEnemies_SelectedIndexChanged);
            // 
            // comboBoxSceneList
            // 
            this.comboBoxSceneList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSceneList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSceneList.FormattingEnabled = true;
            this.comboBoxSceneList.Location = new System.Drawing.Point(64, 12);
            this.comboBoxSceneList.Name = "comboBoxSceneList";
            this.comboBoxSceneList.Size = new System.Drawing.Size(548, 21);
            this.comboBoxSceneList.TabIndex = 0;
            this.comboBoxSceneList.SelectedIndexChanged += new System.EventHandler(this.comboBoxSceneList_SelectedIndexChanged);
            // 
            // labelScenes
            // 
            this.labelScenes.AutoSize = true;
            this.labelScenes.Location = new System.Drawing.Point(12, 15);
            this.labelScenes.Name = "labelScenes";
            this.labelScenes.Size = new System.Drawing.Size(46, 13);
            this.labelScenes.TabIndex = 7;
            this.labelScenes.Text = "Scenes:";
            // 
            // buttonExportMulti
            // 
            this.buttonExportMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExportMulti.Location = new System.Drawing.Point(9, 380);
            this.buttonExportMulti.Name = "buttonExportMulti";
            this.buttonExportMulti.Size = new System.Drawing.Size(150, 23);
            this.buttonExportMulti.TabIndex = 4;
            this.buttonExportMulti.Text = "Import scene(s)...";
            this.buttonExportMulti.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 438);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(624, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // BattleAIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 461);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonExportMulti);
            this.Controls.Add(this.labelScenes);
            this.Controls.Add(this.comboBoxSceneList);
            this.Controls.Add(this.groupBoxEnemies);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxCurrScript);
            this.Controls.Add(this.groupBoxScripts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(560, 420);
            this.Name = "BattleAIForm";
            this.Text = "Scarlet - Battle A.I. Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BattleAIForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BattleAIForm_FormClosed);
            this.Load += new System.EventHandler(this.BattleAIForm_Load);
            this.groupBoxScripts.ResumeLayout(false);
            this.groupBoxCurrScript.ResumeLayout(false);
            this.groupBoxCurrScript.PerformLayout();
            this.toolStripScript.ResumeLayout(false);
            this.toolStripScript.PerformLayout();
            this.groupBoxEnemies.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxScripts;
        private System.Windows.Forms.GroupBox groupBoxCurrScript;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ToolStrip toolStripScript;
        private System.Windows.Forms.ListBox listBoxScripts;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.GroupBox groupBoxEnemies;
        private System.Windows.Forms.ListBox listBoxEnemies;
        private System.Windows.Forms.ListBox listBoxCurrScript;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveUp;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveDown;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonCut;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaste;
        private System.Windows.Forms.ComboBox comboBoxSceneList;
        private System.Windows.Forms.Label labelScenes;
        private System.Windows.Forms.Button buttonExportMulti;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

