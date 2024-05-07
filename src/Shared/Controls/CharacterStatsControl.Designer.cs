namespace FF7Scarlet.Shared.Controls
{
    partial class CharacterStatsControl
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
            groupBoxMain = new GroupBox();
            numericLuckBonus = new NumericUpDown();
            labelLuckBonus = new Label();
            numericLuck = new NumericUpDown();
            labelLuck = new Label();
            numericDexterityBonus = new NumericUpDown();
            labelDexterityBonus = new Label();
            numericDexterity = new NumericUpDown();
            labelDexterity = new Label();
            numericSpiritBonus = new NumericUpDown();
            labelSpiritBonus = new Label();
            numericSpirit = new NumericUpDown();
            labelSpirit = new Label();
            numericMagicBonus = new NumericUpDown();
            labelMagicBonus = new Label();
            numericMagic = new NumericUpDown();
            labelMagic = new Label();
            numericVitalityBonus = new NumericUpDown();
            labelVitalityBonus = new Label();
            numericVitality = new NumericUpDown();
            labelVitality = new Label();
            numericStrengthBonus = new NumericUpDown();
            labelStrengthBonus = new Label();
            numericStrength = new NumericUpDown();
            labelStrength = new Label();
            groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericLuckBonus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericLuck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDexterityBonus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDexterity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSpiritBonus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSpirit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMagicBonus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMagic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericVitalityBonus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericVitality).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStrengthBonus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStrength).BeginInit();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(numericLuckBonus);
            groupBoxMain.Controls.Add(labelLuckBonus);
            groupBoxMain.Controls.Add(numericLuck);
            groupBoxMain.Controls.Add(labelLuck);
            groupBoxMain.Controls.Add(numericDexterityBonus);
            groupBoxMain.Controls.Add(labelDexterityBonus);
            groupBoxMain.Controls.Add(numericDexterity);
            groupBoxMain.Controls.Add(labelDexterity);
            groupBoxMain.Controls.Add(numericSpiritBonus);
            groupBoxMain.Controls.Add(labelSpiritBonus);
            groupBoxMain.Controls.Add(numericSpirit);
            groupBoxMain.Controls.Add(labelSpirit);
            groupBoxMain.Controls.Add(numericMagicBonus);
            groupBoxMain.Controls.Add(labelMagicBonus);
            groupBoxMain.Controls.Add(numericMagic);
            groupBoxMain.Controls.Add(labelMagic);
            groupBoxMain.Controls.Add(numericVitalityBonus);
            groupBoxMain.Controls.Add(labelVitalityBonus);
            groupBoxMain.Controls.Add(numericVitality);
            groupBoxMain.Controls.Add(labelVitality);
            groupBoxMain.Controls.Add(numericStrengthBonus);
            groupBoxMain.Controls.Add(labelStrengthBonus);
            groupBoxMain.Controls.Add(numericStrength);
            groupBoxMain.Controls.Add(labelStrength);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(168, 290);
            groupBoxMain.TabIndex = 0;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Stats";
            // 
            // numericLuckBonus
            // 
            numericLuckBonus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericLuckBonus.Location = new Point(87, 257);
            numericLuckBonus.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericLuckBonus.Name = "numericLuckBonus";
            numericLuckBonus.Size = new Size(75, 23);
            numericLuckBonus.TabIndex = 23;
            numericLuckBonus.ValueChanged += numeric_ValueChanged;
            // 
            // labelLuckBonus
            // 
            labelLuckBonus.AutoSize = true;
            labelLuckBonus.Location = new Point(87, 239);
            labelLuckBonus.Name = "labelLuckBonus";
            labelLuckBonus.Size = new Size(43, 15);
            labelLuckBonus.TabIndex = 22;
            labelLuckBonus.Text = "Bonus:";
            // 
            // numericLuck
            // 
            numericLuck.Location = new Point(6, 257);
            numericLuck.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericLuck.Name = "numericLuck";
            numericLuck.Size = new Size(75, 23);
            numericLuck.TabIndex = 21;
            numericLuck.ValueChanged += numeric_ValueChanged;
            // 
            // labelLuck
            // 
            labelLuck.AutoSize = true;
            labelLuck.Location = new Point(6, 239);
            labelLuck.Name = "labelLuck";
            labelLuck.Size = new Size(35, 15);
            labelLuck.TabIndex = 20;
            labelLuck.Text = "Luck:";
            // 
            // numericDexterityBonus
            // 
            numericDexterityBonus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericDexterityBonus.Location = new Point(87, 213);
            numericDexterityBonus.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDexterityBonus.Name = "numericDexterityBonus";
            numericDexterityBonus.Size = new Size(75, 23);
            numericDexterityBonus.TabIndex = 19;
            numericDexterityBonus.ValueChanged += numeric_ValueChanged;
            // 
            // labelDexterityBonus
            // 
            labelDexterityBonus.AutoSize = true;
            labelDexterityBonus.Location = new Point(87, 195);
            labelDexterityBonus.Name = "labelDexterityBonus";
            labelDexterityBonus.Size = new Size(43, 15);
            labelDexterityBonus.TabIndex = 18;
            labelDexterityBonus.Text = "Bonus:";
            // 
            // numericDexterity
            // 
            numericDexterity.Location = new Point(6, 213);
            numericDexterity.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericDexterity.Name = "numericDexterity";
            numericDexterity.Size = new Size(75, 23);
            numericDexterity.TabIndex = 17;
            numericDexterity.ValueChanged += numeric_ValueChanged;
            // 
            // labelDexterity
            // 
            labelDexterity.AutoSize = true;
            labelDexterity.Location = new Point(6, 195);
            labelDexterity.Name = "labelDexterity";
            labelDexterity.Size = new Size(57, 15);
            labelDexterity.TabIndex = 16;
            labelDexterity.Text = "Dexterity:";
            // 
            // numericSpiritBonus
            // 
            numericSpiritBonus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericSpiritBonus.Location = new Point(87, 169);
            numericSpiritBonus.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericSpiritBonus.Name = "numericSpiritBonus";
            numericSpiritBonus.Size = new Size(75, 23);
            numericSpiritBonus.TabIndex = 15;
            numericSpiritBonus.ValueChanged += numeric_ValueChanged;
            // 
            // labelSpiritBonus
            // 
            labelSpiritBonus.AutoSize = true;
            labelSpiritBonus.Location = new Point(87, 151);
            labelSpiritBonus.Name = "labelSpiritBonus";
            labelSpiritBonus.Size = new Size(43, 15);
            labelSpiritBonus.TabIndex = 14;
            labelSpiritBonus.Text = "Bonus:";
            // 
            // numericSpirit
            // 
            numericSpirit.Location = new Point(6, 169);
            numericSpirit.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericSpirit.Name = "numericSpirit";
            numericSpirit.Size = new Size(75, 23);
            numericSpirit.TabIndex = 13;
            numericSpirit.ValueChanged += numeric_ValueChanged;
            // 
            // labelSpirit
            // 
            labelSpirit.AutoSize = true;
            labelSpirit.Location = new Point(6, 151);
            labelSpirit.Name = "labelSpirit";
            labelSpirit.Size = new Size(37, 15);
            labelSpirit.TabIndex = 12;
            labelSpirit.Text = "Spirit:";
            // 
            // numericMagicBonus
            // 
            numericMagicBonus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericMagicBonus.Location = new Point(87, 125);
            numericMagicBonus.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericMagicBonus.Name = "numericMagicBonus";
            numericMagicBonus.Size = new Size(75, 23);
            numericMagicBonus.TabIndex = 11;
            numericMagicBonus.ValueChanged += numeric_ValueChanged;
            // 
            // labelMagicBonus
            // 
            labelMagicBonus.AutoSize = true;
            labelMagicBonus.Location = new Point(87, 107);
            labelMagicBonus.Name = "labelMagicBonus";
            labelMagicBonus.Size = new Size(43, 15);
            labelMagicBonus.TabIndex = 10;
            labelMagicBonus.Text = "Bonus:";
            // 
            // numericMagic
            // 
            numericMagic.Location = new Point(6, 125);
            numericMagic.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericMagic.Name = "numericMagic";
            numericMagic.Size = new Size(75, 23);
            numericMagic.TabIndex = 9;
            numericMagic.ValueChanged += numeric_ValueChanged;
            // 
            // labelMagic
            // 
            labelMagic.AutoSize = true;
            labelMagic.Location = new Point(6, 107);
            labelMagic.Name = "labelMagic";
            labelMagic.Size = new Size(43, 15);
            labelMagic.TabIndex = 8;
            labelMagic.Text = "Magic:";
            // 
            // numericVitalityBonus
            // 
            numericVitalityBonus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericVitalityBonus.Location = new Point(87, 81);
            numericVitalityBonus.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericVitalityBonus.Name = "numericVitalityBonus";
            numericVitalityBonus.Size = new Size(75, 23);
            numericVitalityBonus.TabIndex = 7;
            numericVitalityBonus.ValueChanged += numeric_ValueChanged;
            // 
            // labelVitalityBonus
            // 
            labelVitalityBonus.AutoSize = true;
            labelVitalityBonus.Location = new Point(87, 63);
            labelVitalityBonus.Name = "labelVitalityBonus";
            labelVitalityBonus.Size = new Size(43, 15);
            labelVitalityBonus.TabIndex = 6;
            labelVitalityBonus.Text = "Bonus:";
            // 
            // numericVitality
            // 
            numericVitality.Location = new Point(6, 81);
            numericVitality.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericVitality.Name = "numericVitality";
            numericVitality.Size = new Size(75, 23);
            numericVitality.TabIndex = 5;
            numericVitality.ValueChanged += numeric_ValueChanged;
            // 
            // labelVitality
            // 
            labelVitality.AutoSize = true;
            labelVitality.Location = new Point(6, 63);
            labelVitality.Name = "labelVitality";
            labelVitality.Size = new Size(46, 15);
            labelVitality.TabIndex = 4;
            labelVitality.Text = "Vitality:";
            // 
            // numericStrengthBonus
            // 
            numericStrengthBonus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericStrengthBonus.Location = new Point(87, 37);
            numericStrengthBonus.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericStrengthBonus.Name = "numericStrengthBonus";
            numericStrengthBonus.Size = new Size(75, 23);
            numericStrengthBonus.TabIndex = 3;
            numericStrengthBonus.ValueChanged += numeric_ValueChanged;
            // 
            // labelStrengthBonus
            // 
            labelStrengthBonus.AutoSize = true;
            labelStrengthBonus.Location = new Point(87, 19);
            labelStrengthBonus.Name = "labelStrengthBonus";
            labelStrengthBonus.Size = new Size(43, 15);
            labelStrengthBonus.TabIndex = 2;
            labelStrengthBonus.Text = "Bonus:";
            // 
            // numericStrength
            // 
            numericStrength.Location = new Point(6, 37);
            numericStrength.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericStrength.Name = "numericStrength";
            numericStrength.Size = new Size(75, 23);
            numericStrength.TabIndex = 1;
            numericStrength.ValueChanged += numeric_ValueChanged;
            // 
            // labelStrength
            // 
            labelStrength.AutoSize = true;
            labelStrength.Location = new Point(6, 19);
            labelStrength.Name = "labelStrength";
            labelStrength.Size = new Size(55, 15);
            labelStrength.TabIndex = 0;
            labelStrength.Text = "Strength:";
            // 
            // CharacterStatsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            DoubleBuffered = true;
            Name = "CharacterStatsControl";
            Size = new Size(168, 290);
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericLuckBonus).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericLuck).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDexterityBonus).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDexterity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSpiritBonus).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSpirit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMagicBonus).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMagic).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericVitalityBonus).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericVitality).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStrengthBonus).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStrength).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private NumericUpDown numericLuckBonus;
        private Label labelLuckBonus;
        private NumericUpDown numericLuck;
        private Label labelLuck;
        private NumericUpDown numericDexterityBonus;
        private Label labelDexterityBonus;
        private NumericUpDown numericDexterity;
        private Label labelDexterity;
        private NumericUpDown numericSpiritBonus;
        private Label labelSpiritBonus;
        private NumericUpDown numericSpirit;
        private Label labelSpirit;
        private NumericUpDown numericMagicBonus;
        private Label labelMagicBonus;
        private NumericUpDown numericMagic;
        private Label labelMagic;
        private NumericUpDown numericVitalityBonus;
        private Label labelVitalityBonus;
        private NumericUpDown numericVitality;
        private Label labelVitality;
        private NumericUpDown numericStrengthBonus;
        private Label labelStrengthBonus;
        private NumericUpDown numericStrength;
        private Label labelStrength;
    }
}
