namespace FF7Scarlet.KernelEditor
{
    partial class MagicOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagicOrderForm));
            groupBoxSpellList = new GroupBox();
            buttonMoveDown = new Button();
            buttonMoveUp = new Button();
            listBoxSpellList = new ListBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            groupBoxSpellList.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxSpellList
            // 
            groupBoxSpellList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSpellList.Controls.Add(buttonMoveDown);
            groupBoxSpellList.Controls.Add(buttonMoveUp);
            groupBoxSpellList.Controls.Add(listBoxSpellList);
            groupBoxSpellList.Location = new Point(12, 12);
            groupBoxSpellList.Name = "groupBoxSpellList";
            groupBoxSpellList.Size = new Size(260, 258);
            groupBoxSpellList.TabIndex = 0;
            groupBoxSpellList.TabStop = false;
            groupBoxSpellList.Text = "Spell list";
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonMoveDown.Location = new Point(164, 229);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(90, 23);
            buttonMoveDown.TabIndex = 2;
            buttonMoveDown.Text = "Move down";
            buttonMoveDown.UseVisualStyleBackColor = true;
            buttonMoveDown.Click += buttonMoveDown_Click;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonMoveUp.Location = new Point(68, 229);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(90, 23);
            buttonMoveUp.TabIndex = 1;
            buttonMoveUp.Text = "Move up";
            buttonMoveUp.UseVisualStyleBackColor = true;
            buttonMoveUp.Click += buttonMoveUp_Click;
            // 
            // listBoxSpellList
            // 
            listBoxSpellList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxSpellList.FormattingEnabled = true;
            listBoxSpellList.ItemHeight = 15;
            listBoxSpellList.Location = new Point(6, 22);
            listBoxSpellList.Name = "listBoxSpellList";
            listBoxSpellList.Size = new Size(248, 199);
            listBoxSpellList.TabIndex = 0;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(197, 276);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(116, 276);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // MagicOrderForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(284, 311);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(groupBoxSpellList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(240, 280);
            Name = "MagicOrderForm";
            Text = "Set magic order";
            groupBoxSpellList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxSpellList;
        private Button buttonOK;
        private Button buttonCancel;
        private Button buttonMoveDown;
        private Button buttonMoveUp;
        private ListBox listBoxSpellList;
    }
}