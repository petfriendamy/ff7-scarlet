namespace FF7Scarlet
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            groupBoxBattleLgp = new GroupBox();
            labelBattleLgp = new Label();
            textBoxBattleLgp = new TextBox();
            buttonBattleLgpBrowse = new Button();
            buttonOK = new Button();
            buttonCancel = new Button();
            groupBoxBattleLgp.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxBattleLgp
            // 
            groupBoxBattleLgp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxBattleLgp.Controls.Add(labelBattleLgp);
            groupBoxBattleLgp.Controls.Add(textBoxBattleLgp);
            groupBoxBattleLgp.Controls.Add(buttonBattleLgpBrowse);
            groupBoxBattleLgp.Location = new Point(13, 12);
            groupBoxBattleLgp.Margin = new Padding(4, 3, 4, 3);
            groupBoxBattleLgp.Name = "groupBoxBattleLgp";
            groupBoxBattleLgp.Padding = new Padding(4, 3, 4, 3);
            groupBoxBattleLgp.Size = new Size(358, 98);
            groupBoxBattleLgp.TabIndex = 6;
            groupBoxBattleLgp.TabStop = false;
            groupBoxBattleLgp.Text = "battle.lgp";
            // 
            // labelBattleLgp
            // 
            labelBattleLgp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelBattleLgp.Location = new Point(8, 19);
            labelBattleLgp.Name = "labelBattleLgp";
            labelBattleLgp.Size = new Size(342, 45);
            labelBattleLgp.TabIndex = 6;
            labelBattleLgp.Text = "This file contains the battle models, and will increase accuracy when dealing with model data.";
            // 
            // textBoxBattleLgp
            // 
            textBoxBattleLgp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxBattleLgp.Location = new Point(8, 67);
            textBoxBattleLgp.Margin = new Padding(4, 3, 4, 3);
            textBoxBattleLgp.Name = "textBoxBattleLgp";
            textBoxBattleLgp.Size = new Size(246, 23);
            textBoxBattleLgp.TabIndex = 5;
            // 
            // buttonBattleLgpBrowse
            // 
            buttonBattleLgpBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonBattleLgpBrowse.Location = new Point(262, 67);
            buttonBattleLgpBrowse.Margin = new Padding(4, 3, 4, 3);
            buttonBattleLgpBrowse.Name = "buttonBattleLgpBrowse";
            buttonBattleLgpBrowse.Size = new Size(88, 23);
            buttonBattleLgpBrowse.TabIndex = 3;
            buttonBattleLgpBrowse.Text = "Browse...";
            buttonBattleLgpBrowse.UseVisualStyleBackColor = true;
            buttonBattleLgpBrowse.Click += buttonBattleLgpBrowse_Click;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(297, 116);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 7;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(216, 116);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(384, 151);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(groupBoxBattleLgp);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(340, 190);
            Name = "SettingsForm";
            Text = "Scarlet - Settings";
            groupBoxBattleLgp.ResumeLayout(false);
            groupBoxBattleLgp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxBattleLgp;
        private TextBox textBoxBattleLgp;
        private Button buttonBattleLgpBrowse;
        private Label labelBattleLgp;
        private Button buttonOK;
        private Button buttonCancel;
    }
}