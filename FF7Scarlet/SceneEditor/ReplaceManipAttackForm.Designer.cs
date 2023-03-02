namespace FF7Scarlet.SceneEditor
{
    partial class ReplaceManipAttackForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplaceManipAttackForm));
            labelError = new Label();
            listBoxAttacks = new ListBox();
            buttonReplace = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.Location = new Point(12, 9);
            labelError.Name = "labelError";
            labelError.Size = new Size(301, 15);
            labelError.TabIndex = 0;
            labelError.Text = "The manip list is full. Please choose an attack to replace:";
            // 
            // listBoxAttacks
            // 
            listBoxAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxAttacks.FormattingEnabled = true;
            listBoxAttacks.ItemHeight = 15;
            listBoxAttacks.Location = new Point(12, 27);
            listBoxAttacks.Name = "listBoxAttacks";
            listBoxAttacks.Size = new Size(340, 49);
            listBoxAttacks.TabIndex = 1;
            // 
            // buttonReplace
            // 
            buttonReplace.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonReplace.Location = new Point(277, 86);
            buttonReplace.Name = "buttonReplace";
            buttonReplace.Size = new Size(75, 23);
            buttonReplace.TabIndex = 2;
            buttonReplace.Text = "Replace";
            buttonReplace.UseVisualStyleBackColor = true;
            buttonReplace.Click += buttonReplace_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(196, 86);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // ReplaceManipAttackForm
            // 
            AcceptButton = buttonReplace;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(364, 121);
            Controls.Add(buttonCancel);
            Controls.Add(buttonReplace);
            Controls.Add(listBoxAttacks);
            Controls.Add(labelError);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReplaceManipAttackForm";
            Text = "Manip list full";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelError;
        private ListBox listBoxAttacks;
        private Button buttonReplace;
        private Button buttonCancel;
    }
}