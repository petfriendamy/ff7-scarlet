namespace FF7Scarlet.SceneEditor
{
    partial class SceneExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneExportForm));
            buttonExport = new Button();
            radioButtonSelected = new RadioButton();
            radioButtonMultiple = new RadioButton();
            listBoxSceneList = new ListBox();
            buttonSelectAll = new Button();
            buttonUnselectAll = new Button();
            groupBoxExport = new GroupBox();
            progressBarSaving = new ProgressBar();
            tabControlExportType = new TabControl();
            tabPageScenes = new TabPage();
            tabPageChunks = new TabPage();
            labelWarning = new Label();
            checkBoxCalculateFromLookup = new CheckBox();
            labelChunkID = new Label();
            numericChunkID = new NumericUpDown();
            labelStartingAt = new Label();
            numericStartingAt = new NumericUpDown();
            numericNumScenes = new NumericUpDown();
            labelNumScenes = new Label();
            tabPageOther = new TabPage();
            groupBox1 = new GroupBox();
            buttonExportAllEnemyAI = new Button();
            buttonExportSelectedEnemyAI = new Button();
            groupBoxAttacks = new GroupBox();
            buttonExportAllAttacks = new Button();
            buttonExportSelectedAttacks = new Button();
            groupBoxEnemies = new GroupBox();
            buttonExportAllEnemies = new Button();
            buttonExportSelectedEnemies = new Button();
            groupBoxExport.SuspendLayout();
            tabControlExportType.SuspendLayout();
            tabPageScenes.SuspendLayout();
            tabPageChunks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericChunkID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStartingAt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericNumScenes).BeginInit();
            tabPageOther.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxAttacks.SuspendLayout();
            groupBoxEnemies.SuspendLayout();
            SuspendLayout();
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExport.Location = new Point(12, 285);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(460, 27);
            buttonExport.TabIndex = 0;
            buttonExport.Text = "Export";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // radioButtonSelected
            // 
            radioButtonSelected.AutoSize = true;
            radioButtonSelected.Location = new Point(6, 22);
            radioButtonSelected.Name = "radioButtonSelected";
            radioButtonSelected.Size = new Size(102, 19);
            radioButtonSelected.TabIndex = 2;
            radioButtonSelected.TabStop = true;
            radioButtonSelected.Text = "Selected scene";
            radioButtonSelected.UseVisualStyleBackColor = true;
            radioButtonSelected.CheckedChanged += radioButtonMultiple_CheckedChanged;
            // 
            // radioButtonMultiple
            // 
            radioButtonMultiple.AutoSize = true;
            radioButtonMultiple.Location = new Point(6, 47);
            radioButtonMultiple.Name = "radioButtonMultiple";
            radioButtonMultiple.Size = new Size(107, 19);
            radioButtonMultiple.TabIndex = 3;
            radioButtonMultiple.TabStop = true;
            radioButtonMultiple.Text = "Multiple scenes";
            radioButtonMultiple.UseVisualStyleBackColor = true;
            radioButtonMultiple.CheckedChanged += radioButtonMultiple_CheckedChanged;
            // 
            // listBoxSceneList
            // 
            listBoxSceneList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxSceneList.FormattingEnabled = true;
            listBoxSceneList.Location = new Point(6, 72);
            listBoxSceneList.Name = "listBoxSceneList";
            listBoxSceneList.SelectionMode = SelectionMode.MultiSimple;
            listBoxSceneList.Size = new Size(434, 109);
            listBoxSceneList.TabIndex = 4;
            // 
            // buttonSelectAll
            // 
            buttonSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSelectAll.Location = new Point(246, 201);
            buttonSelectAll.Name = "buttonSelectAll";
            buttonSelectAll.Size = new Size(94, 23);
            buttonSelectAll.TabIndex = 7;
            buttonSelectAll.Text = "Select all";
            buttonSelectAll.UseVisualStyleBackColor = true;
            buttonSelectAll.Click += buttonSelectAll_Click;
            // 
            // buttonUnselectAll
            // 
            buttonUnselectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonUnselectAll.Location = new Point(346, 201);
            buttonUnselectAll.Name = "buttonUnselectAll";
            buttonUnselectAll.Size = new Size(94, 23);
            buttonUnselectAll.TabIndex = 6;
            buttonUnselectAll.Text = "Unselect all";
            buttonUnselectAll.UseVisualStyleBackColor = true;
            buttonUnselectAll.Click += buttonUnselectAll_Click;
            // 
            // groupBoxExport
            // 
            groupBoxExport.Controls.Add(radioButtonSelected);
            groupBoxExport.Controls.Add(buttonSelectAll);
            groupBoxExport.Controls.Add(radioButtonMultiple);
            groupBoxExport.Controls.Add(buttonUnselectAll);
            groupBoxExport.Controls.Add(listBoxSceneList);
            groupBoxExport.Dock = DockStyle.Fill;
            groupBoxExport.Location = new Point(3, 3);
            groupBoxExport.Name = "groupBoxExport";
            groupBoxExport.Size = new Size(446, 233);
            groupBoxExport.TabIndex = 8;
            groupBoxExport.TabStop = false;
            groupBoxExport.Text = "Export...";
            // 
            // progressBarSaving
            // 
            progressBarSaving.Dock = DockStyle.Bottom;
            progressBarSaving.Location = new Point(0, 318);
            progressBarSaving.Name = "progressBarSaving";
            progressBarSaving.Size = new Size(484, 23);
            progressBarSaving.TabIndex = 9;
            // 
            // tabControlExportType
            // 
            tabControlExportType.Controls.Add(tabPageScenes);
            tabControlExportType.Controls.Add(tabPageChunks);
            tabControlExportType.Controls.Add(tabPageOther);
            tabControlExportType.Location = new Point(12, 12);
            tabControlExportType.Name = "tabControlExportType";
            tabControlExportType.SelectedIndex = 0;
            tabControlExportType.Size = new Size(460, 267);
            tabControlExportType.TabIndex = 10;
            tabControlExportType.SelectedIndexChanged += tabControlExportType_SelectedIndexChanged;
            // 
            // tabPageScenes
            // 
            tabPageScenes.Controls.Add(groupBoxExport);
            tabPageScenes.Location = new Point(4, 24);
            tabPageScenes.Name = "tabPageScenes";
            tabPageScenes.Padding = new Padding(3);
            tabPageScenes.Size = new Size(452, 239);
            tabPageScenes.TabIndex = 0;
            tabPageScenes.Text = "Scenes";
            tabPageScenes.UseVisualStyleBackColor = true;
            // 
            // tabPageChunks
            // 
            tabPageChunks.Controls.Add(labelWarning);
            tabPageChunks.Controls.Add(checkBoxCalculateFromLookup);
            tabPageChunks.Controls.Add(labelChunkID);
            tabPageChunks.Controls.Add(numericChunkID);
            tabPageChunks.Controls.Add(labelStartingAt);
            tabPageChunks.Controls.Add(numericStartingAt);
            tabPageChunks.Controls.Add(numericNumScenes);
            tabPageChunks.Controls.Add(labelNumScenes);
            tabPageChunks.Location = new Point(4, 24);
            tabPageChunks.Name = "tabPageChunks";
            tabPageChunks.Padding = new Padding(3);
            tabPageChunks.Size = new Size(452, 239);
            tabPageChunks.TabIndex = 1;
            tabPageChunks.Text = "Chunks";
            tabPageChunks.UseVisualStyleBackColor = true;
            // 
            // labelWarning
            // 
            labelWarning.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelWarning.Location = new Point(6, 125);
            labelWarning.Name = "labelWarning";
            labelWarning.Size = new Size(440, 111);
            labelWarning.TabIndex = 7;
            labelWarning.Text = "Important note: These should match the scene lookup table in kernel.bin, or you may get strange results in-game!";
            labelWarning.TextAlign = ContentAlignment.TopCenter;
            // 
            // checkBoxCalculateFromLookup
            // 
            checkBoxCalculateFromLookup.AutoSize = true;
            checkBoxCalculateFromLookup.Checked = true;
            checkBoxCalculateFromLookup.CheckState = CheckState.Checked;
            checkBoxCalculateFromLookup.Location = new Point(130, 91);
            checkBoxCalculateFromLookup.Name = "checkBoxCalculateFromLookup";
            checkBoxCalculateFromLookup.Size = new Size(206, 19);
            checkBoxCalculateFromLookup.TabIndex = 6;
            checkBoxCalculateFromLookup.Text = "Calculate from scene lookup table";
            checkBoxCalculateFromLookup.UseVisualStyleBackColor = true;
            checkBoxCalculateFromLookup.CheckedChanged += checkBoxCalculateFromLookup_CheckedChanged;
            // 
            // labelChunkID
            // 
            labelChunkID.AutoSize = true;
            labelChunkID.Location = new Point(65, 8);
            labelChunkID.Name = "labelChunkID";
            labelChunkID.Size = new Size(59, 15);
            labelChunkID.TabIndex = 5;
            labelChunkID.Text = "Chunk ID:";
            // 
            // numericChunkID
            // 
            numericChunkID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericChunkID.Location = new Point(130, 6);
            numericChunkID.Maximum = new decimal(new int[] { 63, 0, 0, 0 });
            numericChunkID.Name = "numericChunkID";
            numericChunkID.Size = new Size(316, 23);
            numericChunkID.TabIndex = 4;
            numericChunkID.ValueChanged += numericChunkID_ValueChanged;
            // 
            // labelStartingAt
            // 
            labelStartingAt.AutoSize = true;
            labelStartingAt.Enabled = false;
            labelStartingAt.Location = new Point(60, 64);
            labelStartingAt.Name = "labelStartingAt";
            labelStartingAt.Size = new Size(64, 15);
            labelStartingAt.TabIndex = 3;
            labelStartingAt.Text = "Starting at:";
            // 
            // numericStartingAt
            // 
            numericStartingAt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericStartingAt.Enabled = false;
            numericStartingAt.Location = new Point(130, 62);
            numericStartingAt.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericStartingAt.Name = "numericStartingAt";
            numericStartingAt.Size = new Size(316, 23);
            numericStartingAt.TabIndex = 2;
            // 
            // numericNumScenes
            // 
            numericNumScenes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericNumScenes.Enabled = false;
            numericNumScenes.Location = new Point(130, 35);
            numericNumScenes.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericNumScenes.Name = "numericNumScenes";
            numericNumScenes.Size = new Size(316, 23);
            numericNumScenes.TabIndex = 1;
            // 
            // labelNumScenes
            // 
            labelNumScenes.AutoSize = true;
            labelNumScenes.Enabled = false;
            labelNumScenes.Location = new Point(4, 37);
            labelNumScenes.Name = "labelNumScenes";
            labelNumScenes.Size = new Size(120, 15);
            labelNumScenes.TabIndex = 0;
            labelNumScenes.Text = "# of scenes to export:";
            labelNumScenes.TextAlign = ContentAlignment.TopRight;
            // 
            // tabPageOther
            // 
            tabPageOther.Controls.Add(groupBox1);
            tabPageOther.Controls.Add(groupBoxAttacks);
            tabPageOther.Controls.Add(groupBoxEnemies);
            tabPageOther.Location = new Point(4, 24);
            tabPageOther.Name = "tabPageOther";
            tabPageOther.Padding = new Padding(3);
            tabPageOther.Size = new Size(452, 239);
            tabPageOther.TabIndex = 2;
            tabPageOther.Text = "Other";
            tabPageOther.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(buttonExportAllEnemyAI);
            groupBox1.Controls.Add(buttonExportSelectedEnemyAI);
            groupBox1.Location = new Point(6, 124);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(440, 53);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Export enemy A.I...";
            // 
            // buttonExportAllEnemyAI
            // 
            buttonExportAllEnemyAI.Location = new Point(162, 22);
            buttonExportAllEnemyAI.Name = "buttonExportAllEnemyAI";
            buttonExportAllEnemyAI.Size = new Size(130, 23);
            buttonExportAllEnemyAI.TabIndex = 1;
            buttonExportAllEnemyAI.Text = "From all scenes";
            buttonExportAllEnemyAI.UseVisualStyleBackColor = true;
            buttonExportAllEnemyAI.Click += buttonExportAllEnemyAI_Click;
            // 
            // buttonExportSelectedEnemyAI
            // 
            buttonExportSelectedEnemyAI.Location = new Point(6, 22);
            buttonExportSelectedEnemyAI.Name = "buttonExportSelectedEnemyAI";
            buttonExportSelectedEnemyAI.Size = new Size(150, 23);
            buttonExportSelectedEnemyAI.TabIndex = 0;
            buttonExportSelectedEnemyAI.Text = "From selected scene";
            buttonExportSelectedEnemyAI.UseVisualStyleBackColor = true;
            buttonExportSelectedEnemyAI.Click += buttonExportSelectedEnemyAI_Click;
            // 
            // groupBoxAttacks
            // 
            groupBoxAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAttacks.Controls.Add(buttonExportAllAttacks);
            groupBoxAttacks.Controls.Add(buttonExportSelectedAttacks);
            groupBoxAttacks.Location = new Point(6, 65);
            groupBoxAttacks.Name = "groupBoxAttacks";
            groupBoxAttacks.Size = new Size(440, 53);
            groupBoxAttacks.TabIndex = 2;
            groupBoxAttacks.TabStop = false;
            groupBoxAttacks.Text = "Export attacks...";
            // 
            // buttonExportAllAttacks
            // 
            buttonExportAllAttacks.Location = new Point(162, 22);
            buttonExportAllAttacks.Name = "buttonExportAllAttacks";
            buttonExportAllAttacks.Size = new Size(130, 23);
            buttonExportAllAttacks.TabIndex = 1;
            buttonExportAllAttacks.Text = "From all scenes";
            buttonExportAllAttacks.UseVisualStyleBackColor = true;
            buttonExportAllAttacks.Click += buttonExportAllAttacks_Click;
            // 
            // buttonExportSelectedAttacks
            // 
            buttonExportSelectedAttacks.Location = new Point(6, 22);
            buttonExportSelectedAttacks.Name = "buttonExportSelectedAttacks";
            buttonExportSelectedAttacks.Size = new Size(150, 23);
            buttonExportSelectedAttacks.TabIndex = 0;
            buttonExportSelectedAttacks.Text = "From selected scene";
            buttonExportSelectedAttacks.UseVisualStyleBackColor = true;
            buttonExportSelectedAttacks.Click += buttonExportSelectedAttacks_Click;
            // 
            // groupBoxEnemies
            // 
            groupBoxEnemies.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxEnemies.Controls.Add(buttonExportAllEnemies);
            groupBoxEnemies.Controls.Add(buttonExportSelectedEnemies);
            groupBoxEnemies.Location = new Point(6, 6);
            groupBoxEnemies.Name = "groupBoxEnemies";
            groupBoxEnemies.Size = new Size(440, 53);
            groupBoxEnemies.TabIndex = 0;
            groupBoxEnemies.TabStop = false;
            groupBoxEnemies.Text = "Export enemies...";
            // 
            // buttonExportAllEnemies
            // 
            buttonExportAllEnemies.Location = new Point(162, 22);
            buttonExportAllEnemies.Name = "buttonExportAllEnemies";
            buttonExportAllEnemies.Size = new Size(130, 23);
            buttonExportAllEnemies.TabIndex = 1;
            buttonExportAllEnemies.Text = "From all scenes";
            buttonExportAllEnemies.UseVisualStyleBackColor = true;
            buttonExportAllEnemies.Click += buttonExportAllEnemies_Click;
            // 
            // buttonExportSelectedEnemies
            // 
            buttonExportSelectedEnemies.Location = new Point(6, 22);
            buttonExportSelectedEnemies.Name = "buttonExportSelectedEnemies";
            buttonExportSelectedEnemies.Size = new Size(150, 23);
            buttonExportSelectedEnemies.TabIndex = 0;
            buttonExportSelectedEnemies.Text = "From selected scene";
            buttonExportSelectedEnemies.UseVisualStyleBackColor = true;
            buttonExportSelectedEnemies.Click += buttonExportSelectedEnemies_Click;
            // 
            // SceneExportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(tabControlExportType);
            Controls.Add(progressBarSaving);
            Controls.Add(buttonExport);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(500, 380);
            Name = "SceneExportForm";
            Text = "Export scenes";
            FormClosing += SceneExportForm_FormClosing;
            groupBoxExport.ResumeLayout(false);
            groupBoxExport.PerformLayout();
            tabControlExportType.ResumeLayout(false);
            tabPageScenes.ResumeLayout(false);
            tabPageChunks.ResumeLayout(false);
            tabPageChunks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericChunkID).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStartingAt).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericNumScenes).EndInit();
            tabPageOther.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBoxAttacks.ResumeLayout(false);
            groupBoxEnemies.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonExport;
        private RadioButton radioButtonSelected;
        private RadioButton radioButtonMultiple;
        private ListBox listBoxSceneList;
        private Button buttonSelectAll;
        private Button buttonUnselectAll;
        private GroupBox groupBoxExport;
        private ProgressBar progressBarSaving;
        private TabControl tabControlExportType;
        private TabPage tabPageScenes;
        private TabPage tabPageChunks;
        private NumericUpDown numericNumScenes;
        private Label labelNumScenes;
        private Label labelStartingAt;
        private NumericUpDown numericStartingAt;
        private Label labelChunkID;
        private NumericUpDown numericChunkID;
        private CheckBox checkBoxCalculateFromLookup;
        private Label labelWarning;
        private TabPage tabPageOther;
        private GroupBox groupBoxEnemies;
        private Button buttonExportAllEnemies;
        private Button buttonExportSelectedEnemies;
        private GroupBox groupBoxAttacks;
        private Button buttonExportAllAttacks;
        private Button buttonExportSelectedAttacks;
        private GroupBox groupBox1;
        private Button buttonExportAllEnemyAI;
        private Button buttonExportSelectedEnemyAI;
    }
}