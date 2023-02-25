
namespace FF7Scarlet.AIEditor
{
    partial class ParameterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterForm));
            panelButtons = new Panel();
            buttonOK = new Button();
            buttonCancel = new Button();
            panelMain = new Panel();
            parameterControl2 = new ParameterControl();
            parameterControl1 = new ParameterControl();
            panelButtons.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonOK);
            panelButtons.Controls.Add(buttonCancel);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 171);
            panelButtons.Margin = new Padding(4, 3, 4, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(541, 46);
            panelButtons.TabIndex = 7;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(440, 9);
            buttonOK.Margin = new Padding(4, 3, 4, 3);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(88, 27);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(345, 9);
            buttonCancel.Margin = new Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(88, 27);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.Controls.Add(parameterControl2);
            panelMain.Controls.Add(parameterControl1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(4, 3, 4, 3);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(541, 171);
            panelMain.TabIndex = 10;
            // 
            // parameterControl2
            // 
            parameterControl2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parameterControl2.Checked = false;
            parameterControl2.Location = new Point(13, 45);
            parameterControl2.Margin = new Padding(4, 3, 4, 3);
            parameterControl2.Name = "parameterControl2";
            parameterControl2.Size = new Size(515, 27);
            parameterControl2.TabIndex = 18;
            // 
            // parameterControl1
            // 
            parameterControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parameterControl1.Checked = false;
            parameterControl1.Location = new Point(13, 12);
            parameterControl1.Margin = new Padding(4, 3, 4, 3);
            parameterControl1.Name = "parameterControl1";
            parameterControl1.Size = new Size(515, 27);
            parameterControl1.TabIndex = 17;
            // 
            // ParameterForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(541, 217);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "ParameterForm";
            Text = "Add/edit parameter";
            panelButtons.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelMain;
        private ParameterControl parameterControl2;
        private ParameterControl parameterControl1;
    }
}