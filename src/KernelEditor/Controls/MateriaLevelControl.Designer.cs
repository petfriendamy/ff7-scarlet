namespace FF7Scarlet.KernelEditor.Controls
{
    partial class MateriaLevelControl
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
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.numericMateriaMaxLevel = new System.Windows.Forms.NumericUpDown();
            this.labelMateriaMaxLevel = new System.Windows.Forms.Label();
            this.numericLvl5AP = new System.Windows.Forms.NumericUpDown();
            this.labelMateriaLvl5AP = new System.Windows.Forms.Label();
            this.numericLvl4AP = new System.Windows.Forms.NumericUpDown();
            this.labelMateriaLvl4AP = new System.Windows.Forms.Label();
            this.numericLvl3AP = new System.Windows.Forms.NumericUpDown();
            this.labelMateriaLvl3AP = new System.Windows.Forms.Label();
            this.numericLvl2AP = new System.Windows.Forms.NumericUpDown();
            this.labelMateriaLvl2AP = new System.Windows.Forms.Label();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMateriaMaxLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLvl5AP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLvl4AP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLvl3AP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLvl2AP)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.numericMateriaMaxLevel);
            this.groupBoxMain.Controls.Add(this.labelMateriaMaxLevel);
            this.groupBoxMain.Controls.Add(this.numericLvl5AP);
            this.groupBoxMain.Controls.Add(this.labelMateriaLvl5AP);
            this.groupBoxMain.Controls.Add(this.numericLvl4AP);
            this.groupBoxMain.Controls.Add(this.labelMateriaLvl4AP);
            this.groupBoxMain.Controls.Add(this.numericLvl3AP);
            this.groupBoxMain.Controls.Add(this.labelMateriaLvl3AP);
            this.groupBoxMain.Controls.Add(this.numericLvl2AP);
            this.groupBoxMain.Controls.Add(this.labelMateriaLvl2AP);
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMain.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(120, 250);
            this.groupBoxMain.TabIndex = 20;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "AP to level up";
            // 
            // numericMateriaMaxLevel
            // 
            this.numericMateriaMaxLevel.Location = new System.Drawing.Point(6, 37);
            this.numericMateriaMaxLevel.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericMateriaMaxLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMateriaMaxLevel.Name = "numericMateriaMaxLevel";
            this.numericMateriaMaxLevel.Size = new System.Drawing.Size(64, 23);
            this.numericMateriaMaxLevel.TabIndex = 26;
            this.numericMateriaMaxLevel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericMateriaMaxLevel.ValueChanged += new System.EventHandler(this.numericMateriaMaxLevel_ValueChanged);
            // 
            // labelMateriaMaxLevel
            // 
            this.labelMateriaMaxLevel.AutoSize = true;
            this.labelMateriaMaxLevel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMateriaMaxLevel.Location = new System.Drawing.Point(6, 19);
            this.labelMateriaMaxLevel.Name = "labelMateriaMaxLevel";
            this.labelMateriaMaxLevel.Size = new System.Drawing.Size(64, 15);
            this.labelMateriaMaxLevel.TabIndex = 25;
            this.labelMateriaMaxLevel.Text = "Max level:";
            // 
            // numericLvl5AP
            // 
            this.numericLvl5AP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericLvl5AP.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericLvl5AP.Location = new System.Drawing.Point(6, 221);
            this.numericLvl5AP.Maximum = new decimal(new int[] {
            6553500,
            0,
            0,
            0});
            this.numericLvl5AP.Name = "numericLvl5AP";
            this.numericLvl5AP.Size = new System.Drawing.Size(108, 23);
            this.numericLvl5AP.TabIndex = 24;
            this.numericLvl5AP.ValueChanged += new System.EventHandler(this.numericLvl5AP_ValueChanged);
            // 
            // labelMateriaLvl5AP
            // 
            this.labelMateriaLvl5AP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMateriaLvl5AP.AutoSize = true;
            this.labelMateriaLvl5AP.Location = new System.Drawing.Point(6, 203);
            this.labelMateriaLvl5AP.Name = "labelMateriaLvl5AP";
            this.labelMateriaLvl5AP.Size = new System.Drawing.Size(48, 15);
            this.labelMateriaLvl5AP.TabIndex = 23;
            this.labelMateriaLvl5AP.Text = "To Lvl 5:";
            // 
            // numericLvl4AP
            // 
            this.numericLvl4AP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericLvl4AP.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericLvl4AP.Location = new System.Drawing.Point(6, 177);
            this.numericLvl4AP.Maximum = new decimal(new int[] {
            6553500,
            0,
            0,
            0});
            this.numericLvl4AP.Name = "numericLvl4AP";
            this.numericLvl4AP.Size = new System.Drawing.Size(108, 23);
            this.numericLvl4AP.TabIndex = 22;
            this.numericLvl4AP.ValueChanged += new System.EventHandler(this.numericLvl4AP_ValueChanged);
            // 
            // labelMateriaLvl4AP
            // 
            this.labelMateriaLvl4AP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMateriaLvl4AP.AutoSize = true;
            this.labelMateriaLvl4AP.Location = new System.Drawing.Point(6, 159);
            this.labelMateriaLvl4AP.Name = "labelMateriaLvl4AP";
            this.labelMateriaLvl4AP.Size = new System.Drawing.Size(48, 15);
            this.labelMateriaLvl4AP.TabIndex = 21;
            this.labelMateriaLvl4AP.Text = "To Lvl 4:";
            // 
            // numericLvl3AP
            // 
            this.numericLvl3AP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericLvl3AP.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericLvl3AP.Location = new System.Drawing.Point(6, 133);
            this.numericLvl3AP.Maximum = new decimal(new int[] {
            6553500,
            0,
            0,
            0});
            this.numericLvl3AP.Name = "numericLvl3AP";
            this.numericLvl3AP.Size = new System.Drawing.Size(108, 23);
            this.numericLvl3AP.TabIndex = 20;
            this.numericLvl3AP.ValueChanged += new System.EventHandler(this.numericLvl3AP_ValueChanged);
            // 
            // labelMateriaLvl3AP
            // 
            this.labelMateriaLvl3AP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMateriaLvl3AP.AutoSize = true;
            this.labelMateriaLvl3AP.Location = new System.Drawing.Point(6, 115);
            this.labelMateriaLvl3AP.Name = "labelMateriaLvl3AP";
            this.labelMateriaLvl3AP.Size = new System.Drawing.Size(48, 15);
            this.labelMateriaLvl3AP.TabIndex = 19;
            this.labelMateriaLvl3AP.Text = "To Lvl 3:";
            // 
            // numericLvl2AP
            // 
            this.numericLvl2AP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericLvl2AP.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericLvl2AP.Location = new System.Drawing.Point(6, 89);
            this.numericLvl2AP.Maximum = new decimal(new int[] {
            6553500,
            0,
            0,
            0});
            this.numericLvl2AP.Name = "numericLvl2AP";
            this.numericLvl2AP.Size = new System.Drawing.Size(108, 23);
            this.numericLvl2AP.TabIndex = 18;
            this.numericLvl2AP.ValueChanged += new System.EventHandler(this.numericLvl2AP_ValueChanged);
            // 
            // labelMateriaLvl2AP
            // 
            this.labelMateriaLvl2AP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMateriaLvl2AP.AutoSize = true;
            this.labelMateriaLvl2AP.Location = new System.Drawing.Point(6, 71);
            this.labelMateriaLvl2AP.Name = "labelMateriaLvl2AP";
            this.labelMateriaLvl2AP.Size = new System.Drawing.Size(48, 15);
            this.labelMateriaLvl2AP.TabIndex = 17;
            this.labelMateriaLvl2AP.Text = "To Lvl 2:";
            // 
            // MateriaLevelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxMain);
            this.DoubleBuffered = true;
            this.Name = "MateriaLevelControl";
            this.Size = new System.Drawing.Size(120, 250);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMateriaMaxLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLvl5AP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLvl4AP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLvl3AP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLvl2AP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxMain;
        private NumericUpDown numericMateriaMaxLevel;
        private Label labelMateriaMaxLevel;
        private NumericUpDown numericLvl5AP;
        private Label labelMateriaLvl5AP;
        private NumericUpDown numericLvl4AP;
        private Label labelMateriaLvl4AP;
        private NumericUpDown numericLvl3AP;
        private Label labelMateriaLvl3AP;
        private NumericUpDown numericLvl2AP;
        private Label labelMateriaLvl2AP;
    }
}
