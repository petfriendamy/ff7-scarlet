namespace FF7Scarlet.SceneEditor
{
    partial class EnemyCopyForm
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
            labelAlert = new Label();
            comboBoxReplacementEnemy = new ComboBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelAlert
            // 
            labelAlert.Location = new Point(12, 9);
            labelAlert.Name = "labelAlert";
            labelAlert.Size = new Size(320, 35);
            labelAlert.TabIndex = 0;
            labelAlert.Text = "Text goes here";
            // 
            // comboBoxReplacementEnemy
            // 
            comboBoxReplacementEnemy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxReplacementEnemy.FormattingEnabled = true;
            comboBoxReplacementEnemy.Location = new Point(12, 44);
            comboBoxReplacementEnemy.Name = "comboBoxReplacementEnemy";
            comboBoxReplacementEnemy.Size = new Size(320, 23);
            comboBoxReplacementEnemy.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(257, 73);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(176, 73);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // EnemyCopyForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(344, 111);
            ControlBox = false;
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(comboBoxReplacementEnemy);
            Controls.Add(labelAlert);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximumSize = new Size(360, 150);
            MinimumSize = new Size(360, 150);
            Name = "EnemyCopyForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enemy not in formation";
            ResumeLayout(false);
        }

        #endregion

        private Label labelAlert;
        private ComboBox comboBoxReplacementEnemy;
        private Button buttonOK;
        private Button buttonCancel;
    }
}