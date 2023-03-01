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
            textBoxEnemyName = new TextBox();
            labelEnemyName = new Label();
            tabPageFormation = new TabPage();
            numericFormationNumber = new NumericUpDown();
            labelFormationNumber = new Label();
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
            panelBottom.Location = new Point(0, 95);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(267, 46);
            panelBottom.TabIndex = 0;
            // 
            // buttonSearch
            // 
            buttonSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSearch.Location = new Point(177, 11);
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
            tabControlMain.Size = new Size(267, 95);
            tabControlMain.TabIndex = 1;
            // 
            // tabPageEnemy
            // 
            tabPageEnemy.Controls.Add(textBoxEnemyName);
            tabPageEnemy.Controls.Add(labelEnemyName);
            tabPageEnemy.Location = new Point(4, 24);
            tabPageEnemy.Name = "tabPageEnemy";
            tabPageEnemy.Padding = new Padding(3);
            tabPageEnemy.Size = new Size(259, 67);
            tabPageEnemy.TabIndex = 0;
            tabPageEnemy.Text = "Enemy";
            tabPageEnemy.UseVisualStyleBackColor = true;
            // 
            // textBoxEnemyName
            // 
            textBoxEnemyName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxEnemyName.Location = new Point(8, 25);
            textBoxEnemyName.Name = "textBoxEnemyName";
            textBoxEnemyName.Size = new Size(240, 23);
            textBoxEnemyName.TabIndex = 1;
            // 
            // labelEnemyName
            // 
            labelEnemyName.AutoSize = true;
            labelEnemyName.Location = new Point(8, 7);
            labelEnemyName.Name = "labelEnemyName";
            labelEnemyName.Size = new Size(96, 15);
            labelEnemyName.TabIndex = 0;
            labelEnemyName.Text = "Name contains...";
            // 
            // tabPageFormation
            // 
            tabPageFormation.Controls.Add(numericFormationNumber);
            tabPageFormation.Controls.Add(labelFormationNumber);
            tabPageFormation.Location = new Point(4, 24);
            tabPageFormation.Name = "tabPageFormation";
            tabPageFormation.Padding = new Padding(3);
            tabPageFormation.Size = new Size(259, 67);
            tabPageFormation.TabIndex = 1;
            tabPageFormation.Text = "Formation";
            tabPageFormation.UseVisualStyleBackColor = true;
            // 
            // numericFormationNumber
            // 
            numericFormationNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericFormationNumber.Location = new Point(8, 25);
            numericFormationNumber.Maximum = new decimal(new int[] { 1023, 0, 0, 0 });
            numericFormationNumber.Name = "numericFormationNumber";
            numericFormationNumber.Size = new Size(240, 23);
            numericFormationNumber.TabIndex = 1;
            // 
            // labelFormationNumber
            // 
            labelFormationNumber.AutoSize = true;
            labelFormationNumber.Location = new Point(8, 7);
            labelFormationNumber.Name = "labelFormationNumber";
            labelFormationNumber.Size = new Size(81, 15);
            labelFormationNumber.TabIndex = 0;
            labelFormationNumber.Text = "Formation #...";
            // 
            // SceneSearchForm
            // 
            AcceptButton = buttonSearch;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 141);
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
        private Label labelEnemyName;
        private NumericUpDown numericFormationNumber;
        private Label labelFormationNumber;
    }
}