namespace FF7Scarlet.SceneEditor.Controls
{
    partial class SceneImportControl
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
            labelText = new Label();
            numericImportAs = new NumericUpDown();
            checkBoxImport = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericImportAs).BeginInit();
            SuspendLayout();
            // 
            // labelText
            // 
            labelText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelText.Location = new Point(3, 5);
            labelText.Name = "labelText";
            labelText.Size = new Size(291, 21);
            labelText.TabIndex = 0;
            labelText.Text = "Text";
            // 
            // numericImportAs
            // 
            numericImportAs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericImportAs.Location = new Point(391, 3);
            numericImportAs.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            numericImportAs.Name = "numericImportAs";
            numericImportAs.Size = new Size(55, 23);
            numericImportAs.TabIndex = 1;
            // 
            // checkBoxImport
            // 
            checkBoxImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxImport.AutoSize = true;
            checkBoxImport.Checked = true;
            checkBoxImport.CheckState = CheckState.Checked;
            checkBoxImport.Location = new Point(300, 5);
            checkBoxImport.Name = "checkBoxImport";
            checkBoxImport.Size = new Size(85, 19);
            checkBoxImport.TabIndex = 2;
            checkBoxImport.Text = "Import as...";
            checkBoxImport.UseVisualStyleBackColor = true;
            checkBoxImport.CheckedChanged += checkBoxImport_CheckedChanged;
            // 
            // SceneImportControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(checkBoxImport);
            Controls.Add(numericImportAs);
            Controls.Add(labelText);
            Name = "SceneImportControl";
            Size = new Size(449, 30);
            ((System.ComponentModel.ISupportInitialize)numericImportAs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelText;
        private NumericUpDown numericImportAs;
        private CheckBox checkBoxImport;
    }
}
