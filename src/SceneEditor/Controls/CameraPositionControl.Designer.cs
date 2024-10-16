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
            groupBoxAngle = new GroupBox();
            numericAngleY = new NumericUpDown();
            labelAngleX = new Label();
            numericUpAngleZ = new NumericUpDown();
            numericAngleX = new NumericUpDown();
            labelAngleZ = new Label();
            labelAngleY = new Label();
            groupBoxPosition = new GroupBox();
            numericPositionX = new NumericUpDown();
            labelPositionX = new Label();
            labelPositionY = new Label();
            numericPositionY = new NumericUpDown();
            labelPositionZ = new Label();
            numericPositionZ = new NumericUpDown();
            groupBoxMain.SuspendLayout();
            groupBoxAngle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAngleY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpAngleZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAngleX).BeginInit();
            groupBoxPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPositionX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionZ).BeginInit();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Controls.Add(groupBoxAngle);
            groupBoxMain.Controls.Add(groupBoxPosition);
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(230, 172);
            groupBoxMain.TabIndex = 0;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Position";
            // 
            // groupBoxAngle
            // 
            groupBoxAngle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAngle.Controls.Add(numericAngleY);
            groupBoxAngle.Controls.Add(labelAngleX);
            groupBoxAngle.Controls.Add(numericUpAngleZ);
            groupBoxAngle.Controls.Add(numericAngleX);
            groupBoxAngle.Controls.Add(labelAngleZ);
            groupBoxAngle.Controls.Add(labelAngleY);
            groupBoxAngle.Location = new Point(6, 97);
            groupBoxAngle.Name = "groupBoxAngle";
            groupBoxAngle.Size = new Size(218, 69);
            groupBoxAngle.TabIndex = 22;
            groupBoxAngle.TabStop = false;
            groupBoxAngle.Text = "Looking at";
            // 
            // numericAngleY
            // 
            numericAngleY.Location = new Point(77, 37);
            numericAngleY.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericAngleY.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            numericAngleY.Name = "numericAngleY";
            numericAngleY.Size = new Size(65, 23);
            numericAngleY.TabIndex = 18;
            numericAngleY.ValueChanged += NumericValueChanged;
            // 
            // labelAngleX
            // 
            labelAngleX.AutoSize = true;
            labelAngleX.Location = new Point(6, 19);
            labelAngleX.Name = "labelAngleX";
            labelAngleX.Size = new Size(17, 15);
            labelAngleX.TabIndex = 15;
            labelAngleX.Text = "X:";
            // 
            // numericUpAngleZ
            // 
            numericUpAngleZ.Location = new Point(148, 37);
            numericUpAngleZ.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericUpAngleZ.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            numericUpAngleZ.Name = "numericUpAngleZ";
            numericUpAngleZ.Size = new Size(65, 23);
            numericUpAngleZ.TabIndex = 20;
            numericUpAngleZ.ValueChanged += NumericValueChanged;
            // 
            // numericAngleX
            // 
            numericAngleX.Location = new Point(6, 37);
            numericAngleX.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericAngleX.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            numericAngleX.Name = "numericAngleX";
            numericAngleX.Size = new Size(65, 23);
            numericAngleX.TabIndex = 16;
            numericAngleX.ValueChanged += NumericValueChanged;
            // 
            // labelAngleZ
            // 
            labelAngleZ.AutoSize = true;
            labelAngleZ.Location = new Point(148, 19);
            labelAngleZ.Name = "labelAngleZ";
            labelAngleZ.Size = new Size(17, 15);
            labelAngleZ.TabIndex = 19;
            labelAngleZ.Text = "Z:";
            // 
            // labelAngleY
            // 
            labelAngleY.AutoSize = true;
            labelAngleY.Location = new Point(77, 19);
            labelAngleY.Name = "labelAngleY";
            labelAngleY.Size = new Size(17, 15);
            labelAngleY.TabIndex = 17;
            labelAngleY.Text = "Y:";
            // 
            // groupBoxPosition
            // 
            groupBoxPosition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxPosition.Controls.Add(numericPositionX);
            groupBoxPosition.Controls.Add(labelPositionX);
            groupBoxPosition.Controls.Add(labelPositionY);
            groupBoxPosition.Controls.Add(numericPositionY);
            groupBoxPosition.Controls.Add(labelPositionZ);
            groupBoxPosition.Controls.Add(numericPositionZ);
            groupBoxPosition.Location = new Point(6, 22);
            groupBoxPosition.Name = "groupBoxPosition";
            groupBoxPosition.Size = new Size(218, 69);
            groupBoxPosition.TabIndex = 21;
            groupBoxPosition.TabStop = false;
            groupBoxPosition.Text = "Position";
            // 
            // numericPositionX
            // 
            numericPositionX.Location = new Point(6, 37);
            numericPositionX.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericPositionX.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            numericPositionX.Name = "numericPositionX";
            numericPositionX.Size = new Size(65, 23);
            numericPositionX.TabIndex = 10;
            numericPositionX.ValueChanged += NumericValueChanged;
            // 
            // labelPositionX
            // 
            labelPositionX.AutoSize = true;
            labelPositionX.Location = new Point(6, 19);
            labelPositionX.Name = "labelPositionX";
            labelPositionX.Size = new Size(17, 15);
            labelPositionX.TabIndex = 9;
            labelPositionX.Text = "X:";
            // 
            // labelPositionY
            // 
            labelPositionY.AutoSize = true;
            labelPositionY.Location = new Point(77, 19);
            labelPositionY.Name = "labelPositionY";
            labelPositionY.Size = new Size(17, 15);
            labelPositionY.TabIndex = 11;
            labelPositionY.Text = "Y:";
            // 
            // numericPositionY
            // 
            numericPositionY.Location = new Point(77, 37);
            numericPositionY.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericPositionY.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            numericPositionY.Name = "numericPositionY";
            numericPositionY.Size = new Size(65, 23);
            numericPositionY.TabIndex = 12;
            numericPositionY.ValueChanged += NumericValueChanged;
            // 
            // labelPositionZ
            // 
            labelPositionZ.AutoSize = true;
            labelPositionZ.Location = new Point(148, 19);
            labelPositionZ.Name = "labelPositionZ";
            labelPositionZ.Size = new Size(17, 15);
            labelPositionZ.TabIndex = 13;
            labelPositionZ.Text = "Z:";
            // 
            // numericPositionZ
            // 
            numericPositionZ.Location = new Point(148, 37);
            numericPositionZ.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericPositionZ.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            numericPositionZ.Name = "numericPositionZ";
            numericPositionZ.Size = new Size(65, 23);
            numericPositionZ.TabIndex = 14;
            numericPositionZ.ValueChanged += NumericValueChanged;
            // 
            // CameraPositionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            DoubleBuffered = true;
            Name = "CameraPositionControl";
            Size = new Size(230, 172);
            groupBoxMain.ResumeLayout(false);
            groupBoxAngle.ResumeLayout(false);
            groupBoxAngle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAngleY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpAngleZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAngleX).EndInit();
            groupBoxPosition.ResumeLayout(false);
            groupBoxPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericPositionX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionZ).EndInit();
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
        private GroupBox groupBoxAngle;
        private GroupBox groupBoxPosition;
    }
}
