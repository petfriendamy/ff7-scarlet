namespace FF7Scarlet.SceneEditor
{
    partial class SceneSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneSearchForm));
            panelBottom = new Panel();
            buttonSearch = new Button();
            tabControlMain = new TabControl();
            tabPageEnemy = new TabPage();
            checkBoxEnemyName = new CheckBox();
            checkBoxEnemyOpcode = new CheckBox();
            comboBoxEnemyOpcode = new ComboBox();
            textBoxEnemyName = new TextBox();
            tabPageFormation = new TabPage();
            comboBoxFormationOpcode = new ComboBox();
            checkBoxFormationOpcode = new CheckBox();
            checkBoxFormationNumber = new CheckBox();
            numericFormationNumber = new NumericUpDown();
            panelBottom.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageEnemy.SuspendLayout();
            tabPageFormation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericFormationNumber).BeginInit();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(buttonSearch);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 215);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(264, 46);
            panelBottom.TabIndex = 0;
            // 
            // buttonSearch
            // 
            buttonSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSearch.Location = new Point(174, 11);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 0;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageEnemy);
            tabControlMain.Controls.Add(tabPageFormation);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(264, 215);
            tabControlMain.TabIndex = 1;
            // 
            // tabPageEnemy
            // 
            tabPageEnemy.Controls.Add(checkBoxEnemyName);
            tabPageEnemy.Controls.Add(checkBoxEnemyOpcode);
            tabPageEnemy.Controls.Add(comboBoxEnemyOpcode);
            tabPageEnemy.Controls.Add(textBoxEnemyName);
            tabPageEnemy.Location = new Point(4, 24);
            tabPageEnemy.Name = "tabPageEnemy";
            tabPageEnemy.Padding = new Padding(3);
            tabPageEnemy.Size = new Size(256, 187);
            tabPageEnemy.TabIndex = 0;
            tabPageEnemy.Text = "Enemy";
            tabPageEnemy.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnemyName
            // 
            checkBoxEnemyName.AutoSize = true;
            checkBoxEnemyName.Checked = true;
            checkBoxEnemyName.CheckState = CheckState.Checked;
            checkBoxEnemyName.Location = new Point(6, 6);
            checkBoxEnemyName.Name = "checkBoxEnemyName";
            checkBoxEnemyName.Size = new Size(115, 19);
            checkBoxEnemyName.TabIndex = 5;
            checkBoxEnemyName.Text = "Name contains...";
            checkBoxEnemyName.UseVisualStyleBackColor = true;
            checkBoxEnemyName.CheckedChanged += checkBoxEnemyName_CheckedChanged;
            // 
            // checkBoxEnemyOpcode
            // 
            checkBoxEnemyOpcode.AutoSize = true;
            checkBoxEnemyOpcode.Location = new Point(6, 60);
            checkBoxEnemyOpcode.Name = "checkBoxEnemyOpcode";
            checkBoxEnemyOpcode.Size = new Size(98, 19);
            checkBoxEnemyOpcode.TabIndex = 4;
            checkBoxEnemyOpcode.Text = "Has opcode...";
            checkBoxEnemyOpcode.UseVisualStyleBackColor = true;
            checkBoxEnemyOpcode.CheckedChanged += checkBoxEnemyOpcode_CheckedChanged;
            // 
            // comboBoxEnemyOpcode
            // 
            comboBoxEnemyOpcode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnemyOpcode.Enabled = false;
            comboBoxEnemyOpcode.FormattingEnabled = true;
            comboBoxEnemyOpcode.Location = new Point(8, 85);
            comboBoxEnemyOpcode.Name = "comboBoxEnemyOpcode";
            comboBoxEnemyOpcode.Size = new Size(240, 23);
            comboBoxEnemyOpcode.TabIndex = 2;
            // 
            // textBoxEnemyName
            // 
            textBoxEnemyName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxEnemyName.Location = new Point(6, 31);
            textBoxEnemyName.Name = "textBoxEnemyName";
            textBoxEnemyName.Size = new Size(242, 23);
            textBoxEnemyName.TabIndex = 1;
            // 
            // tabPageFormation
            // 
            tabPageFormation.Controls.Add(comboBoxFormationOpcode);
            tabPageFormation.Controls.Add(checkBoxFormationOpcode);
            tabPageFormation.Controls.Add(checkBoxFormationNumber);
            tabPageFormation.Controls.Add(numericFormationNumber);
            tabPageFormation.Location = new Point(4, 24);
            tabPageFormation.Name = "tabPageFormation";
            tabPageFormation.Padding = new Padding(3);
            tabPageFormation.Size = new Size(256, 187);
            tabPageFormation.TabIndex = 1;
            tabPageFormation.Text = "Formation";
            tabPageFormation.UseVisualStyleBackColor = true;
            // 
            // comboBoxFormationOpcode
            // 
            comboBoxFormationOpcode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormationOpcode.Enabled = false;
            comboBoxFormationOpcode.FormattingEnabled = true;
            comboBoxFormationOpcode.Location = new Point(6, 85);
            comboBoxFormationOpcode.Name = "comboBoxFormationOpcode";
            comboBoxFormationOpcode.Size = new Size(242, 23);
            comboBoxFormationOpcode.TabIndex = 4;
            // 
            // checkBoxFormationOpcode
            // 
            checkBoxFormationOpcode.AutoSize = true;
            checkBoxFormationOpcode.Location = new Point(6, 60);
            checkBoxFormationOpcode.Name = "checkBoxFormationOpcode";
            checkBoxFormationOpcode.Size = new Size(98, 19);
            checkBoxFormationOpcode.TabIndex = 3;
            checkBoxFormationOpcode.Text = "Has opcode...";
            checkBoxFormationOpcode.UseVisualStyleBackColor = true;
            checkBoxFormationOpcode.CheckedChanged += checkBoxFormationOpcode_CheckedChanged;
            // 
            // checkBoxFormationNumber
            // 
            checkBoxFormationNumber.AutoSize = true;
            checkBoxFormationNumber.Checked = true;
            checkBoxFormationNumber.CheckState = CheckState.Checked;
            checkBoxFormationNumber.Location = new Point(6, 6);
            checkBoxFormationNumber.Name = "checkBoxFormationNumber";
            checkBoxFormationNumber.Size = new Size(100, 19);
            checkBoxFormationNumber.TabIndex = 2;
            checkBoxFormationNumber.Text = "Formation #...";
            checkBoxFormationNumber.UseVisualStyleBackColor = true;
            checkBoxFormationNumber.CheckedChanged += checkBoxFormationNumber_CheckedChanged;
            // 
            // numericFormationNumber
            // 
            numericFormationNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericFormationNumber.Location = new Point(6, 31);
            numericFormationNumber.Maximum = new decimal(new int[] { 1023, 0, 0, 0 });
            numericFormationNumber.Name = "numericFormationNumber";
            numericFormationNumber.Size = new Size(244, 23);
            numericFormationNumber.TabIndex = 1;
            // 
            // SceneSearchForm
            // 
            AcceptButton = buttonSearch;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 261);
            Controls.Add(tabControlMain);
            Controls.Add(panelBottom);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SceneSearchForm";
            Text = "Search scene";
            panelBottom.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPageEnemy.ResumeLayout(false);
            tabPageEnemy.PerformLayout();
            tabPageFormation.ResumeLayout(false);
            tabPageFormation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericFormationNumber).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBottom;
        private Button buttonSearch;
        private TabControl tabControlMain;
        private TabPage tabPageEnemy;
        private TabPage tabPageFormation;
        private TextBox textBoxEnemyName;
        private NumericUpDown numericFormationNumber;
        private ComboBox comboBoxEnemyOpcode;
        private CheckBox checkBoxEnemyName;
        private CheckBox checkBoxEnemyOpcode;
        private ComboBox comboBoxFormationOpcode;
        private CheckBox checkBoxFormationOpcode;
        private CheckBox checkBoxFormationNumber;
    }
}