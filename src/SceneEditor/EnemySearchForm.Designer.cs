namespace FF7Scarlet.SceneEditor
{
    partial class EnemySearchForm
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
            labelResults = new Label();
            listBoxResults = new ListBox();
            buttonSelect = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.Location = new Point(12, 9);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(82, 15);
            labelResults.TabIndex = 0;
            labelResults.Text = "Results found:";
            // 
            // listBoxResults
            // 
            listBoxResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxResults.FormattingEnabled = true;
            listBoxResults.ItemHeight = 15;
            listBoxResults.Location = new Point(12, 27);
            listBoxResults.Name = "listBoxResults";
            listBoxResults.Size = new Size(322, 124);
            listBoxResults.TabIndex = 1;
            listBoxResults.DoubleClick += buttonSelect_Click;
            // 
            // buttonSelect
            // 
            buttonSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSelect.Location = new Point(259, 161);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.TabIndex = 2;
            buttonSelect.Text = "Select";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(178, 161);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // EnemySearchForm
            // 
            AcceptButton = buttonSelect;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(346, 196);
            ControlBox = false;
            Controls.Add(buttonCancel);
            Controls.Add(buttonSelect);
            Controls.Add(listBoxResults);
            Controls.Add(labelResults);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "EnemySearchForm";
            ShowIcon = false;
            Text = "Search results";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelResults;
        private ListBox listBoxResults;
        private Button buttonSelect;
        private Button buttonCancel;
    }
}