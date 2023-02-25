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
            groupBoxExport.SuspendLayout();
            SuspendLayout();
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            listBoxSceneList.ItemHeight = 15;
            listBoxSceneList.Location = new Point(6, 72);
            listBoxSceneList.Name = "listBoxSceneList";
            listBoxSceneList.SelectionMode = SelectionMode.MultiSimple;
            listBoxSceneList.Size = new Size(448, 154);
            listBoxSceneList.TabIndex = 4;
            // 
            // buttonSelectAll
            // 
            buttonSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSelectAll.Location = new Point(260, 235);
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
            buttonUnselectAll.Location = new Point(360, 235);
            buttonUnselectAll.Name = "buttonUnselectAll";
            buttonUnselectAll.Size = new Size(94, 23);
            buttonUnselectAll.TabIndex = 6;
            buttonUnselectAll.Text = "Unselect all";
            buttonUnselectAll.UseVisualStyleBackColor = true;
            buttonUnselectAll.Click += buttonUnselectAll_Click;
            // 
            // groupBoxExport
            // 
            groupBoxExport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxExport.Controls.Add(radioButtonSelected);
            groupBoxExport.Controls.Add(buttonSelectAll);
            groupBoxExport.Controls.Add(radioButtonMultiple);
            groupBoxExport.Controls.Add(buttonUnselectAll);
            groupBoxExport.Controls.Add(listBoxSceneList);
            groupBoxExport.Location = new Point(12, 12);
            groupBoxExport.Name = "groupBoxExport";
            groupBoxExport.Size = new Size(460, 267);
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
            // SceneExportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(progressBarSaving);
            Controls.Add(groupBoxExport);
            Controls.Add(buttonExport);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(500, 380);
            Name = "SceneExportForm";
            Text = "Export scenes";
            FormClosing += SceneExportForm_FormClosing;
            groupBoxExport.ResumeLayout(false);
            groupBoxExport.PerformLayout();
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
    }
}