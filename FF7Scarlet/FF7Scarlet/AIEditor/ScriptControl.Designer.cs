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
            this.groupBoxCurrScript.SuspendLayout();
            this.toolStripScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCurrScript
            // 
            this.groupBoxCurrScript.Controls.Add(this.listBoxCurrScript);
            this.groupBoxCurrScript.Controls.Add(this.toolStripScript);
            this.groupBoxCurrScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCurrScript.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCurrScript.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxCurrScript.Name = "groupBoxCurrScript";
            this.groupBoxCurrScript.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxCurrScript.Size = new System.Drawing.Size(498, 401);
            this.groupBoxCurrScript.TabIndex = 7;
            this.groupBoxCurrScript.TabStop = false;
            this.groupBoxCurrScript.Text = "Current script";
            // 
            // listBoxCurrScript
            // 
            this.listBoxCurrScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCurrScript.FormattingEnabled = true;
            this.listBoxCurrScript.HorizontalScrollbar = true;
            this.listBoxCurrScript.ItemHeight = 15;
            this.listBoxCurrScript.Location = new System.Drawing.Point(4, 86);
            this.listBoxCurrScript.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxCurrScript.Name = "listBoxCurrScript";
            this.listBoxCurrScript.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCurrScript.Size = new System.Drawing.Size(490, 312);
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
            this.toolStripScript.Location = new System.Drawing.Point(4, 19);
            this.toolStripScript.Name = "toolStripScript";
            this.toolStripScript.Size = new System.Drawing.Size(490, 67);
            this.toolStripScript.TabIndex = 6;
            this.toolStripScript.Text = "toolStripScript";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::FF7Scarlet.Properties.Resources.menu_add;
            this.toolStripButtonAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(64, 64);
            this.toolStripButtonAdd.Text = "Add";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEdit.Image = global::FF7Scarlet.Properties.Resources.menu_edit;
            this.toolStripButtonEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(64, 64);
            this.toolStripButtonEdit.Text = "Edit";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripButtonCut
            // 
            this.toolStripButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCut.Image = global::FF7Scarlet.Properties.Resources.menu_cut;
            this.toolStripButtonCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCut.Name = "toolStripButtonCut";
            this.toolStripButtonCut.Size = new System.Drawing.Size(64, 64);
            this.toolStripButtonCut.Text = "Cut";
            this.toolStripButtonCut.Click += new System.EventHandler(this.toolStripButtonCut_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::FF7Scarlet.Properties.Resources.menu_copy;
            this.toolStripButtonCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(64, 64);
            this.toolStripButtonCopy.Text = "Copy";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonPaste
            // 
            this.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPaste.Enabled = false;
            this.toolStripButtonPaste.Image = global::FF7Scarlet.Properties.Resources.menu_paste;
            this.toolStripButtonPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPaste.Name = "toolStripButtonPaste";
            this.toolStripButtonPaste.Size = new System.Drawing.Size(64, 64);
            this.toolStripButtonPaste.Text = "Paste";
            this.toolStripButtonPaste.Click += new System.EventHandler(this.toolStripButtonPaste_Click);
            // 
            // toolStripButtonMoveUp
            // 
            this.toolStripButtonMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMoveUp.Image = global::FF7Scarlet.Properties.Resources.menu_up;
            this.toolStripButtonMoveUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveUp.Name = "toolStripButtonMoveUp";
            this.toolStripButtonMoveUp.Size = new System.Drawing.Size(64, 64);
            this.toolStripButtonMoveUp.Text = "Move Up";
            this.toolStripButtonMoveUp.Click += new System.EventHandler(this.toolStripButtonMoveUp_Click);
            // 
            // toolStripButtonMoveDown
            // 
            this.toolStripButtonMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMoveDown.Image = global::FF7Scarlet.Properties.Resources.menu_down;
            this.toolStripButtonMoveDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveDown.Name = "toolStripButtonMoveDown";
            this.toolStripButtonMoveDown.Size = new System.Drawing.Size(64, 64);
            this.toolStripButtonMoveDown.Text = "Move Down";
            this.toolStripButtonMoveDown.Click += new System.EventHandler(this.toolStripButtonMoveDown_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = global::FF7Scarlet.Properties.Resources.menu_delete;
            this.toolStripButtonDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(64, 64);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // ScriptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxCurrScript);
            this.Name = "ScriptControl";
            this.Size = new System.Drawing.Size(498, 401);
            this.groupBoxCurrScript.ResumeLayout(false);
            this.groupBoxCurrScript.PerformLayout();
            this.toolStripScript.ResumeLayout(false);
            this.toolStripScript.PerformLayout();
            this.ResumeLayout(false);

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
