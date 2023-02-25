
namespace FF7Scarlet.AIEditor
{
    partial class ParameterControl
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
            checkBoxEnabled = new CheckBox();
            comboBoxParameter = new ComboBox();
            comboBoxType = new ComboBox();
            comboBoxOperand = new ComboBox();
            SuspendLayout();
            // 
            // checkBoxEnabled
            // 
            checkBoxEnabled.AutoSize = true;
            checkBoxEnabled.Location = new Point(4, 7);
            checkBoxEnabled.Margin = new Padding(4, 3, 4, 3);
            checkBoxEnabled.Name = "checkBoxEnabled";
            checkBoxEnabled.Size = new Size(15, 14);
            checkBoxEnabled.TabIndex = 20;
            checkBoxEnabled.UseVisualStyleBackColor = true;
            checkBoxEnabled.CheckedChanged += checkBoxEnabled_CheckedChanged;
            // 
            // comboBoxParameter
            // 
            comboBoxParameter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxParameter.Enabled = false;
            comboBoxParameter.FormattingEnabled = true;
            comboBoxParameter.Location = new Point(257, 3);
            comboBoxParameter.Margin = new Padding(4, 3, 4, 3);
            comboBoxParameter.Name = "comboBoxParameter";
            comboBoxParameter.Size = new Size(233, 23);
            comboBoxParameter.TabIndex = 19;
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.Enabled = false;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(133, 3);
            comboBoxType.Margin = new Padding(4, 3, 4, 3);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(116, 23);
            comboBoxType.TabIndex = 18;
            // 
            // comboBoxOperand
            // 
            comboBoxOperand.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperand.Enabled = false;
            comboBoxOperand.FormattingEnabled = true;
            comboBoxOperand.Location = new Point(28, 3);
            comboBoxOperand.Margin = new Padding(4, 3, 4, 3);
            comboBoxOperand.Name = "comboBoxOperand";
            comboBoxOperand.Size = new Size(97, 23);
            comboBoxOperand.TabIndex = 17;
            // 
            // ParameterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBoxEnabled);
            Controls.Add(comboBoxParameter);
            Controls.Add(comboBoxType);
            Controls.Add(comboBoxOperand);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ParameterControl";
            Size = new Size(493, 31);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.ComboBox comboBoxParameter;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxOperand;
    }
}
