namespace FF7Scarlet.AIEditor
{
    partial class ScriptControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxCurrScript = new GroupBox();
            listBoxCurrScript = new ListBox();
            toolStripScript = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonCut = new ToolStripButton();
            toolStripButtonCopy = new ToolStripButton();
            toolStripButtonPaste = new ToolStripButton();
            toolStripButtonMoveUp = new ToolStripButton();
            toolStripButtonMoveDown = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            groupBoxCurrScript.SuspendLayout();
            toolStripScript.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxCurrScript
            // 
            groupBoxCurrScript.Controls.Add(listBoxCurrScript);
            groupBoxCurrScript.Controls.Add(toolStripScript);
            groupBoxCurrScript.Dock = DockStyle.Fill;
            groupBoxCurrScript.Location = new Point(0, 0);
            groupBoxCurrScript.Margin = new Padding(4, 3, 4, 3);
            groupBoxCurrScript.Name = "groupBoxCurrScript";
            groupBoxCurrScript.Padding = new Padding(4, 3, 4, 3);
            groupBoxCurrScript.Size = new Size(498, 401);
            groupBoxCurrScript.TabIndex = 7;
            groupBoxCurrScript.TabStop = false;
            groupBoxCurrScript.Text = "Current script";
            // 
            // listBoxCurrScript
            // 
            listBoxCurrScript.Dock = DockStyle.Fill;
            listBoxCurrScript.FormattingEnabled = true;
            listBoxCurrScript.HorizontalScrollbar = true;
            listBoxCurrScript.Location = new Point(4, 44);
            listBoxCurrScript.Margin = new Padding(4, 3, 4, 3);
            listBoxCurrScript.Name = "listBoxCurrScript";
            listBoxCurrScript.SelectionMode = SelectionMode.MultiExtended;
            listBoxCurrScript.Size = new Size(490, 354);
            listBoxCurrScript.TabIndex = 7;
            listBoxCurrScript.SelectedIndexChanged += listBoxCurrScript_SelectedIndexChanged;
            listBoxCurrScript.DoubleClick += toolStripButtonEdit_Click;
            listBoxCurrScript.KeyDown += listBoxCurrScript_KeyDown;
            // 
            // toolStripScript
            // 
            toolStripScript.AllowMerge = false;
            toolStripScript.Enabled = false;
            toolStripScript.GripStyle = ToolStripGripStyle.Hidden;
            toolStripScript.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonCut, toolStripButtonCopy, toolStripButtonPaste, toolStripButtonMoveUp, toolStripButtonMoveDown, toolStripButtonDelete });
            toolStripScript.Location = new Point(4, 19);
            toolStripScript.Name = "toolStripScript";
            toolStripScript.Size = new Size(490, 25);
            toolStripScript.TabIndex = 6;
            toolStripScript.Text = "toolStripScript";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonAdd.Image = Properties.Resources.menu_add;
            toolStripButtonAdd.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(23, 22);
            toolStripButtonAdd.Text = "Add";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonEdit.Image = Properties.Resources.menu_edit;
            toolStripButtonEdit.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(23, 22);
            toolStripButtonEdit.Text = "Edit";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripButtonCut
            // 
            toolStripButtonCut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCut.Enabled = false;
            toolStripButtonCut.Image = Properties.Resources.menu_cut;
            toolStripButtonCut.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonCut.ImageTransparentColor = Color.Magenta;
            toolStripButtonCut.Name = "toolStripButtonCut";
            toolStripButtonCut.Size = new Size(23, 22);
            toolStripButtonCut.Text = "Cut";
            toolStripButtonCut.Click += toolStripButtonCut_Click;
            // 
            // toolStripButtonCopy
            // 
            toolStripButtonCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCopy.Enabled = false;
            toolStripButtonCopy.Image = Properties.Resources.menu_copy;
            toolStripButtonCopy.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonCopy.ImageTransparentColor = Color.Magenta;
            toolStripButtonCopy.Name = "toolStripButtonCopy";
            toolStripButtonCopy.Size = new Size(23, 22);
            toolStripButtonCopy.Text = "Copy";
            toolStripButtonCopy.Click += toolStripButtonCopy_Click;
            // 
            // toolStripButtonPaste
            // 
            toolStripButtonPaste.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonPaste.Enabled = false;
            toolStripButtonPaste.Image = Properties.Resources.menu_paste;
            toolStripButtonPaste.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonPaste.ImageTransparentColor = Color.Magenta;
            toolStripButtonPaste.Name = "toolStripButtonPaste";
            toolStripButtonPaste.Size = new Size(23, 22);
            toolStripButtonPaste.Text = "Paste";
            toolStripButtonPaste.Click += toolStripButtonPaste_Click;
            // 
            // toolStripButtonMoveUp
            // 
            toolStripButtonMoveUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonMoveUp.Enabled = false;
            toolStripButtonMoveUp.Image = Properties.Resources.menu_up;
            toolStripButtonMoveUp.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonMoveUp.ImageTransparentColor = Color.Magenta;
            toolStripButtonMoveUp.Name = "toolStripButtonMoveUp";
            toolStripButtonMoveUp.Size = new Size(23, 22);
            toolStripButtonMoveUp.Text = "Move Up";
            toolStripButtonMoveUp.Click += toolStripButtonMoveUp_Click;
            // 
            // toolStripButtonMoveDown
            // 
            toolStripButtonMoveDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonMoveDown.Enabled = false;
            toolStripButtonMoveDown.Image = Properties.Resources.menu_down;
            toolStripButtonMoveDown.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonMoveDown.ImageTransparentColor = Color.Magenta;
            toolStripButtonMoveDown.Name = "toolStripButtonMoveDown";
            toolStripButtonMoveDown.Size = new Size(23, 22);
            toolStripButtonMoveDown.Text = "Move Down";
            toolStripButtonMoveDown.Click += toolStripButtonMoveDown_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDelete.Enabled = false;
            toolStripButtonDelete.Image = Properties.Resources.menu_delete;
            toolStripButtonDelete.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(23, 22);
            toolStripButtonDelete.Text = "Delete";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // ScriptControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxCurrScript);
            Name = "ScriptControl";
            Size = new Size(498, 401);
            groupBoxCurrScript.ResumeLayout(false);
            groupBoxCurrScript.PerformLayout();
            toolStripScript.ResumeLayout(false);
            toolStripScript.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxCurrScript;
        private ListBox listBoxCurrScript;
        private ToolStrip toolStripScript;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonCut;
        private ToolStripButton toolStripButtonCopy;
        private ToolStripButton toolStripButtonPaste;
        private ToolStripButton toolStripButtonMoveUp;
        private ToolStripButton toolStripButtonMoveDown;
        private ToolStripButton toolStripButtonDelete;
    }
}
