namespace FF7Scarlet.SceneEditor.Controls
{
    partial class CameraPositionControl
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
            numericUpAngleZ = new NumericUpDown();
            labelAngleZ = new Label();
            numericAngleY = new NumericUpDown();
            labelAngleY = new Label();
            numericAngleX = new NumericUpDown();
            labelAngleX = new Label();
            numericPositionZ = new NumericUpDown();
            labelPositionZ = new Label();
            numericPositionY = new NumericUpDown();
            labelPositionY = new Label();
            numericPositionX = new NumericUpDown();
            labelPositionX = new Label();
            groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpAngleZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAngleY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAngleX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionX).BeginInit();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(numericUpAngleZ);
            groupBoxMain.Controls.Add(labelAngleZ);
            groupBoxMain.Controls.Add(numericAngleY);
            groupBoxMain.Controls.Add(labelAngleY);
            groupBoxMain.Controls.Add(numericAngleX);
            groupBoxMain.Controls.Add(labelAngleX);
            groupBoxMain.Controls.Add(numericPositionZ);
            groupBoxMain.Controls.Add(labelPositionZ);
            groupBoxMain.Controls.Add(numericPositionY);
            groupBoxMain.Controls.Add(labelPositionY);
            groupBoxMain.Controls.Add(numericPositionX);
            groupBoxMain.Controls.Add(labelPositionX);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(239, 116);
            groupBoxMain.TabIndex = 0;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Position";
            // 
            // numericUpAngleZ
            // 
            numericUpAngleZ.Location = new Point(157, 81);
            numericUpAngleZ.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUpAngleZ.Name = "numericUpAngleZ";
            numericUpAngleZ.Size = new Size(70, 23);
            numericUpAngleZ.TabIndex = 20;
            numericUpAngleZ.ValueChanged += NumericValueChanged;
            // 
            // labelAngleZ
            // 
            labelAngleZ.AutoSize = true;
            labelAngleZ.Location = new Point(157, 63);
            labelAngleZ.Name = "labelAngleZ";
            labelAngleZ.Size = new Size(49, 15);
            labelAngleZ.TabIndex = 19;
            labelAngleZ.Text = "Z angle:";
            // 
            // numericAngleY
            // 
            numericAngleY.Location = new Point(81, 81);
            numericAngleY.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericAngleY.Name = "numericAngleY";
            numericAngleY.Size = new Size(70, 23);
            numericAngleY.TabIndex = 18;
            numericAngleY.ValueChanged += NumericValueChanged;
            // 
            // labelAngleY
            // 
            labelAngleY.AutoSize = true;
            labelAngleY.Location = new Point(81, 63);
            labelAngleY.Name = "labelAngleY";
            labelAngleY.Size = new Size(49, 15);
            labelAngleY.TabIndex = 17;
            labelAngleY.Text = "Y angle:";
            // 
            // numericAngleX
            // 
            numericAngleX.Location = new Point(6, 81);
            numericAngleX.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericAngleX.Name = "numericAngleX";
            numericAngleX.Size = new Size(70, 23);
            numericAngleX.TabIndex = 16;
            numericAngleX.ValueChanged += NumericValueChanged;
            // 
            // labelAngleX
            // 
            labelAngleX.AutoSize = true;
            labelAngleX.Location = new Point(6, 63);
            labelAngleX.Name = "labelAngleX";
            labelAngleX.Size = new Size(49, 15);
            labelAngleX.TabIndex = 15;
            labelAngleX.Text = "X angle:";
            // 
            // numericPositionZ
            // 
            numericPositionZ.Location = new Point(157, 37);
            numericPositionZ.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericPositionZ.Name = "numericPositionZ";
            numericPositionZ.Size = new Size(70, 23);
            numericPositionZ.TabIndex = 14;
            numericPositionZ.ValueChanged += NumericValueChanged;
            // 
            // labelPositionZ
            // 
            labelPositionZ.AutoSize = true;
            labelPositionZ.Location = new Point(157, 19);
            labelPositionZ.Name = "labelPositionZ";
            labelPositionZ.Size = new Size(63, 15);
            labelPositionZ.TabIndex = 13;
            labelPositionZ.Text = "Z position:";
            // 
            // numericPositionY
            // 
            numericPositionY.Location = new Point(81, 37);
            numericPositionY.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericPositionY.Name = "numericPositionY";
            numericPositionY.Size = new Size(70, 23);
            numericPositionY.TabIndex = 12;
            numericPositionY.ValueChanged += NumericValueChanged;
            // 
            // labelPositionY
            // 
            labelPositionY.AutoSize = true;
            labelPositionY.Location = new Point(81, 19);
            labelPositionY.Name = "labelPositionY";
            labelPositionY.Size = new Size(63, 15);
            labelPositionY.TabIndex = 11;
            labelPositionY.Text = "Y position:";
            // 
            // numericPositionX
            // 
            numericPositionX.Location = new Point(6, 37);
            numericPositionX.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericPositionX.Name = "numericPositionX";
            numericPositionX.Size = new Size(70, 23);
            numericPositionX.TabIndex = 10;
            numericPositionX.ValueChanged += NumericValueChanged;
            // 
            // labelPositionX
            // 
            labelPositionX.AutoSize = true;
            labelPositionX.Location = new Point(6, 19);
            labelPositionX.Name = "labelPositionX";
            labelPositionX.Size = new Size(63, 15);
            labelPositionX.TabIndex = 9;
            labelPositionX.Text = "X position:";
            // 
            // CameraPositionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            DoubleBuffered = true;
            Name = "CameraPositionControl";
            Size = new Size(239, 116);
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpAngleZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAngleY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAngleX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionX).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private NumericUpDown numericUpAngleZ;
        private Label labelAngleZ;
        private NumericUpDown numericAngleY;
        private Label labelAngleY;
        private NumericUpDown numericAngleX;
        private Label labelAngleX;
        private NumericUpDown numericPositionZ;
        private Label labelPositionZ;
        private NumericUpDown numericPositionY;
        private Label labelPositionY;
        private NumericUpDown numericPositionX;
        private Label labelPositionX;
    }
}
