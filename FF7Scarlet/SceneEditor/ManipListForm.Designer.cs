namespace FF7Scarlet.SceneEditor
{
    partial class ManipListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManipListForm));
            buttonOK = new Button();
            buttonCancel = new Button();
            groupBoxAttacks = new GroupBox();
            buttonRemove = new Button();
            buttonMoveDown = new Button();
            buttonMoveUp = new Button();
            listBoxAttacks = new ListBox();
            groupBoxAttacks.SuspendLayout();
            SuspendLayout();
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(277, 134);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(196, 134);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxAttacks
            // 
            groupBoxAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAttacks.Controls.Add(buttonRemove);
            groupBoxAttacks.Controls.Add(buttonMoveDown);
            groupBoxAttacks.Controls.Add(buttonMoveUp);
            groupBoxAttacks.Controls.Add(listBoxAttacks);
            groupBoxAttacks.Location = new Point(12, 12);
            groupBoxAttacks.Name = "groupBoxAttacks";
            groupBoxAttacks.Size = new Size(340, 110);
            groupBoxAttacks.TabIndex = 6;
            groupBoxAttacks.TabStop = false;
            groupBoxAttacks.Text = "Attacks";
            // 
            // buttonRemove
            // 
            buttonRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRemove.Enabled = false;
            buttonRemove.Location = new Point(244, 81);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(90, 23);
            buttonRemove.TabIndex = 3;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonMoveDown.Enabled = false;
            buttonMoveDown.Location = new Point(102, 81);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(90, 23);
            buttonMoveDown.TabIndex = 2;
            buttonMoveDown.Text = "Move down";
            buttonMoveDown.UseVisualStyleBackColor = true;
            buttonMoveDown.Click += buttonMoveDown_Click;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonMoveUp.Enabled = false;
            buttonMoveUp.Location = new Point(6, 81);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(90, 23);
            buttonMoveUp.TabIndex = 1;
            buttonMoveUp.Text = "Move up";
            buttonMoveUp.UseVisualStyleBackColor = true;
            buttonMoveUp.Click += buttonMoveUp_Click;
            // 
            // listBoxAttacks
            // 
            listBoxAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxAttacks.FormattingEnabled = true;
            listBoxAttacks.ItemHeight = 15;
            listBoxAttacks.Location = new Point(6, 22);
            listBoxAttacks.Name = "listBoxAttacks";
            listBoxAttacks.Size = new Size(328, 49);
            listBoxAttacks.TabIndex = 0;
            listBoxAttacks.SelectedIndexChanged += listBoxAttacks_SelectedIndexChanged;
            // 
            // ManipListForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(364, 169);
            Controls.Add(groupBoxAttacks);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ManipListForm";
            Text = "Manipulate list";
            groupBoxAttacks.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBoxAttacks;
        private Button buttonRemove;
        private Button buttonMoveDown;
        private Button buttonMoveUp;
        private ListBox listBoxAttacks;
    }
}