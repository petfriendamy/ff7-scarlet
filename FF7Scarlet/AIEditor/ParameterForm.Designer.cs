
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
            panelHeader = new Panel();
            labelParameter = new Label();
            labelType = new Label();
            labelModifier = new Label();
            labelOperand = new Label();
            panelButtons.SuspendLayout();
            panelMain.SuspendLayout();
            panelHeader.SuspendLayout();
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
            panelButtons.Size = new Size(564, 46);
            panelButtons.TabIndex = 7;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(463, 9);
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
            buttonCancel.Location = new Point(368, 9);
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
            panelMain.Location = new Point(0, 28);
            panelMain.Margin = new Padding(4, 3, 4, 3);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(564, 143);
            panelMain.TabIndex = 10;
            // 
            // parameterControl2
            // 
            parameterControl2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parameterControl2.Checked = false;
            parameterControl2.Location = new Point(13, 39);
            parameterControl2.Margin = new Padding(4, 3, 4, 3);
            parameterControl2.Modifier = 55;
            parameterControl2.Name = "parameterControl2";
            parameterControl2.Operand = 255;
            parameterControl2.Size = new Size(538, 27);
            parameterControl2.TabIndex = 18;
            // 
            // parameterControl1
            // 
            parameterControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parameterControl1.Checked = false;
            parameterControl1.Location = new Point(13, 6);
            parameterControl1.Margin = new Padding(4, 3, 4, 3);
            parameterControl1.Modifier = 55;
            parameterControl1.Name = "parameterControl1";
            parameterControl1.Operand = 255;
            parameterControl1.Size = new Size(538, 27);
            parameterControl1.TabIndex = 17;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelParameter);
            panelHeader.Controls.Add(labelType);
            panelHeader.Controls.Add(labelModifier);
            panelHeader.Controls.Add(labelOperand);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(564, 28);
            panelHeader.TabIndex = 11;
            // 
            // labelParameter
            // 
            labelParameter.AutoSize = true;
            labelParameter.Location = new Point(333, 9);
            labelParameter.Name = "labelParameter";
            labelParameter.Size = new Size(64, 15);
            labelParameter.TabIndex = 3;
            labelParameter.Text = "Parameter:";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(196, 9);
            labelType.Name = "labelType";
            labelType.Size = new Size(34, 15);
            labelType.TabIndex = 2;
            labelType.Text = "Type:";
            // 
            // labelModifier
            // 
            labelModifier.AutoSize = true;
            labelModifier.Location = new Point(99, 9);
            labelModifier.Name = "labelModifier";
            labelModifier.Size = new Size(55, 15);
            labelModifier.TabIndex = 1;
            labelModifier.Text = "Modifier:";
            // 
            // labelOperand
            // 
            labelOperand.AutoSize = true;
            labelOperand.Location = new Point(37, 9);
            labelOperand.Name = "labelOperand";
            labelOperand.Size = new Size(56, 15);
            labelOperand.TabIndex = 0;
            labelOperand.Text = "Operand:";
            // 
            // ParameterForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(564, 217);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "ParameterForm";
            Text = "Add/edit parameter";
            panelButtons.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelMain;
        private ParameterControl parameterControl2;
        private ParameterControl parameterControl1;
        private Panel panelHeader;
        private Label labelParameter;
        private Label labelType;
        private Label labelModifier;
        private Label labelOperand;
    }
}