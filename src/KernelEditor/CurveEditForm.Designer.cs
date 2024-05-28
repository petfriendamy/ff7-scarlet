namespace FF7Scarlet.KernelEditor
{
    partial class CurveEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurveEditForm));
            groupBoxUsedBy = new GroupBox();
            labelUsedBy = new Label();
            labelCurveIndex = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            groupBoxBracket1 = new GroupBox();
            numericGradient1 = new NumericUpDown();
            labelGradient1 = new Label();
            numericBase1 = new NumericUpDown();
            labelBase1 = new Label();
            groupBoxBracket2 = new GroupBox();
            numericGradient2 = new NumericUpDown();
            labelGradient2 = new Label();
            numericBase2 = new NumericUpDown();
            labelBase2 = new Label();
            groupBoxBracket4 = new GroupBox();
            numericGradient4 = new NumericUpDown();
            labelGradient4 = new Label();
            numericBase4 = new NumericUpDown();
            labelBase4 = new Label();
            groupBoxBracket3 = new GroupBox();
            numericGradient3 = new NumericUpDown();
            labelGradient3 = new Label();
            numericBase3 = new NumericUpDown();
            labelBase3 = new Label();
            groupBoxBracket8 = new GroupBox();
            numericGradient8 = new NumericUpDown();
            labelGradient8 = new Label();
            numericBase8 = new NumericUpDown();
            labelBase8 = new Label();
            groupBoxBracket7 = new GroupBox();
            numericGradient7 = new NumericUpDown();
            labelGradient7 = new Label();
            numericBase7 = new NumericUpDown();
            labelBase7 = new Label();
            groupBoxBracket6 = new GroupBox();
            numericGradient6 = new NumericUpDown();
            labelGradient6 = new Label();
            numericBase6 = new NumericUpDown();
            labelBase6 = new Label();
            groupBoxBracket5 = new GroupBox();
            numericGradient5 = new NumericUpDown();
            labelGradient5 = new Label();
            numericBase5 = new NumericUpDown();
            labelBase5 = new Label();
            groupBoxUsedBy.SuspendLayout();
            groupBoxBracket1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBase1).BeginInit();
            groupBoxBracket2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBase2).BeginInit();
            groupBoxBracket4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBase4).BeginInit();
            groupBoxBracket3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBase3).BeginInit();
            groupBoxBracket8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBase8).BeginInit();
            groupBoxBracket7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBase7).BeginInit();
            groupBoxBracket6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBase6).BeginInit();
            groupBoxBracket5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBase5).BeginInit();
            SuspendLayout();
            // 
            // groupBoxUsedBy
            // 
            groupBoxUsedBy.Controls.Add(labelUsedBy);
            groupBoxUsedBy.Location = new Point(12, 33);
            groupBoxUsedBy.Name = "groupBoxUsedBy";
            groupBoxUsedBy.Size = new Size(156, 162);
            groupBoxUsedBy.TabIndex = 0;
            groupBoxUsedBy.TabStop = false;
            groupBoxUsedBy.Text = "Currently used by:";
            // 
            // labelUsedBy
            // 
            labelUsedBy.Dock = DockStyle.Fill;
            labelUsedBy.Location = new Point(3, 19);
            labelUsedBy.Name = "labelUsedBy";
            labelUsedBy.Size = new Size(150, 140);
            labelUsedBy.TabIndex = 0;
            labelUsedBy.Text = "-None";
            // 
            // labelCurveIndex
            // 
            labelCurveIndex.AutoSize = true;
            labelCurveIndex.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelCurveIndex.Location = new Point(12, 9);
            labelCurveIndex.Name = "labelCurveIndex";
            labelCurveIndex.Size = new Size(106, 21);
            labelCurveIndex.TabIndex = 2;
            labelCurveIndex.Text = "Curve index:";
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(637, 211);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 10;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(556, 211);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxBracket1
            // 
            groupBoxBracket1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxBracket1.Controls.Add(numericGradient1);
            groupBoxBracket1.Controls.Add(labelGradient1);
            groupBoxBracket1.Controls.Add(numericBase1);
            groupBoxBracket1.Controls.Add(labelBase1);
            groupBoxBracket1.Location = new Point(174, 33);
            groupBoxBracket1.Name = "groupBoxBracket1";
            groupBoxBracket1.Size = new Size(130, 78);
            groupBoxBracket1.TabIndex = 2;
            groupBoxBracket1.TabStop = false;
            groupBoxBracket1.Text = "Lvl 1-11";
            // 
            // numericGradient1
            // 
            numericGradient1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericGradient1.Location = new Point(67, 46);
            numericGradient1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericGradient1.Name = "numericGradient1";
            numericGradient1.Size = new Size(57, 23);
            numericGradient1.TabIndex = 3;
            numericGradient1.ValueChanged += numericGradient_ValueChanged;
            // 
            // labelGradient1
            // 
            labelGradient1.AutoSize = true;
            labelGradient1.Location = new Point(6, 48);
            labelGradient1.Name = "labelGradient1";
            labelGradient1.Size = new Size(55, 15);
            labelGradient1.TabIndex = 2;
            labelGradient1.Text = "Gradient:";
            // 
            // numericBase1
            // 
            numericBase1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericBase1.Location = new Point(67, 17);
            numericBase1.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericBase1.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
            numericBase1.Name = "numericBase1";
            numericBase1.Size = new Size(57, 23);
            numericBase1.TabIndex = 1;
            numericBase1.ValueChanged += numericBase_ValueChanged;
            // 
            // labelBase1
            // 
            labelBase1.AutoSize = true;
            labelBase1.Location = new Point(27, 19);
            labelBase1.Name = "labelBase1";
            labelBase1.Size = new Size(34, 15);
            labelBase1.TabIndex = 0;
            labelBase1.Text = "Base:";
            // 
            // groupBoxBracket2
            // 
            groupBoxBracket2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxBracket2.Controls.Add(numericGradient2);
            groupBoxBracket2.Controls.Add(labelGradient2);
            groupBoxBracket2.Controls.Add(numericBase2);
            groupBoxBracket2.Controls.Add(labelBase2);
            groupBoxBracket2.Location = new Point(310, 33);
            groupBoxBracket2.Name = "groupBoxBracket2";
            groupBoxBracket2.Size = new Size(130, 78);
            groupBoxBracket2.TabIndex = 3;
            groupBoxBracket2.TabStop = false;
            groupBoxBracket2.Text = "Lvl 12-21";
            // 
            // numericGradient2
            // 
            numericGradient2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericGradient2.Location = new Point(67, 46);
            numericGradient2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericGradient2.Name = "numericGradient2";
            numericGradient2.Size = new Size(57, 23);
            numericGradient2.TabIndex = 3;
            numericGradient2.ValueChanged += numericGradient_ValueChanged;
            // 
            // labelGradient2
            // 
            labelGradient2.AutoSize = true;
            labelGradient2.Location = new Point(6, 48);
            labelGradient2.Name = "labelGradient2";
            labelGradient2.Size = new Size(55, 15);
            labelGradient2.TabIndex = 2;
            labelGradient2.Text = "Gradient:";
            // 
            // numericBase2
            // 
            numericBase2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericBase2.Location = new Point(67, 17);
            numericBase2.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericBase2.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
            numericBase2.Name = "numericBase2";
            numericBase2.Size = new Size(57, 23);
            numericBase2.TabIndex = 1;
            numericBase2.ValueChanged += numericBase_ValueChanged;
            // 
            // labelBase2
            // 
            labelBase2.AutoSize = true;
            labelBase2.Location = new Point(27, 19);
            labelBase2.Name = "labelBase2";
            labelBase2.Size = new Size(34, 15);
            labelBase2.TabIndex = 0;
            labelBase2.Text = "Base:";
            // 
            // groupBoxBracket4
            // 
            groupBoxBracket4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxBracket4.Controls.Add(numericGradient4);
            groupBoxBracket4.Controls.Add(labelGradient4);
            groupBoxBracket4.Controls.Add(numericBase4);
            groupBoxBracket4.Controls.Add(labelBase4);
            groupBoxBracket4.Location = new Point(582, 33);
            groupBoxBracket4.Name = "groupBoxBracket4";
            groupBoxBracket4.Size = new Size(130, 78);
            groupBoxBracket4.TabIndex = 5;
            groupBoxBracket4.TabStop = false;
            groupBoxBracket4.Text = "Lvl 32-41";
            // 
            // numericGradient4
            // 
            numericGradient4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericGradient4.Location = new Point(67, 46);
            numericGradient4.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericGradient4.Name = "numericGradient4";
            numericGradient4.Size = new Size(57, 23);
            numericGradient4.TabIndex = 3;
            numericGradient4.ValueChanged += numericGradient_ValueChanged;
            // 
            // labelGradient4
            // 
            labelGradient4.AutoSize = true;
            labelGradient4.Location = new Point(6, 48);
            labelGradient4.Name = "labelGradient4";
            labelGradient4.Size = new Size(55, 15);
            labelGradient4.TabIndex = 2;
            labelGradient4.Text = "Gradient:";
            // 
            // numericBase4
            // 
            numericBase4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericBase4.Location = new Point(67, 17);
            numericBase4.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericBase4.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
            numericBase4.Name = "numericBase4";
            numericBase4.Size = new Size(57, 23);
            numericBase4.TabIndex = 1;
            numericBase4.ValueChanged += numericBase_ValueChanged;
            // 
            // labelBase4
            // 
            labelBase4.AutoSize = true;
            labelBase4.Location = new Point(27, 19);
            labelBase4.Name = "labelBase4";
            labelBase4.Size = new Size(34, 15);
            labelBase4.TabIndex = 0;
            labelBase4.Text = "Base:";
            // 
            // groupBoxBracket3
            // 
            groupBoxBracket3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxBracket3.Controls.Add(numericGradient3);
            groupBoxBracket3.Controls.Add(labelGradient3);
            groupBoxBracket3.Controls.Add(numericBase3);
            groupBoxBracket3.Controls.Add(labelBase3);
            groupBoxBracket3.Location = new Point(446, 33);
            groupBoxBracket3.Name = "groupBoxBracket3";
            groupBoxBracket3.Size = new Size(130, 78);
            groupBoxBracket3.TabIndex = 4;
            groupBoxBracket3.TabStop = false;
            groupBoxBracket3.Text = "Lvl 22-31";
            // 
            // numericGradient3
            // 
            numericGradient3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericGradient3.Location = new Point(67, 46);
            numericGradient3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericGradient3.Name = "numericGradient3";
            numericGradient3.Size = new Size(57, 23);
            numericGradient3.TabIndex = 3;
            numericGradient3.ValueChanged += numericGradient_ValueChanged;
            // 
            // labelGradient3
            // 
            labelGradient3.AutoSize = true;
            labelGradient3.Location = new Point(6, 48);
            labelGradient3.Name = "labelGradient3";
            labelGradient3.Size = new Size(55, 15);
            labelGradient3.TabIndex = 2;
            labelGradient3.Text = "Gradient:";
            // 
            // numericBase3
            // 
            numericBase3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericBase3.Location = new Point(67, 17);
            numericBase3.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericBase3.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
            numericBase3.Name = "numericBase3";
            numericBase3.Size = new Size(57, 23);
            numericBase3.TabIndex = 1;
            numericBase3.ValueChanged += numericBase_ValueChanged;
            // 
            // labelBase3
            // 
            labelBase3.AutoSize = true;
            labelBase3.Location = new Point(27, 19);
            labelBase3.Name = "labelBase3";
            labelBase3.Size = new Size(34, 15);
            labelBase3.TabIndex = 0;
            labelBase3.Text = "Base:";
            // 
            // groupBoxBracket8
            // 
            groupBoxBracket8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxBracket8.Controls.Add(numericGradient8);
            groupBoxBracket8.Controls.Add(labelGradient8);
            groupBoxBracket8.Controls.Add(numericBase8);
            groupBoxBracket8.Controls.Add(labelBase8);
            groupBoxBracket8.Location = new Point(582, 117);
            groupBoxBracket8.Name = "groupBoxBracket8";
            groupBoxBracket8.Size = new Size(130, 78);
            groupBoxBracket8.TabIndex = 9;
            groupBoxBracket8.TabStop = false;
            groupBoxBracket8.Text = "Lvl 82-99";
            // 
            // numericGradient8
            // 
            numericGradient8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericGradient8.Location = new Point(67, 46);
            numericGradient8.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericGradient8.Name = "numericGradient8";
            numericGradient8.Size = new Size(57, 23);
            numericGradient8.TabIndex = 3;
            numericGradient8.ValueChanged += numericGradient_ValueChanged;
            // 
            // labelGradient8
            // 
            labelGradient8.AutoSize = true;
            labelGradient8.Location = new Point(6, 48);
            labelGradient8.Name = "labelGradient8";
            labelGradient8.Size = new Size(55, 15);
            labelGradient8.TabIndex = 2;
            labelGradient8.Text = "Gradient:";
            // 
            // numericBase8
            // 
            numericBase8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericBase8.Location = new Point(67, 17);
            numericBase8.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericBase8.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
            numericBase8.Name = "numericBase8";
            numericBase8.Size = new Size(57, 23);
            numericBase8.TabIndex = 1;
            numericBase8.ValueChanged += numericBase_ValueChanged;
            // 
            // labelBase8
            // 
            labelBase8.AutoSize = true;
            labelBase8.Location = new Point(27, 19);
            labelBase8.Name = "labelBase8";
            labelBase8.Size = new Size(34, 15);
            labelBase8.TabIndex = 0;
            labelBase8.Text = "Base:";
            // 
            // groupBoxBracket7
            // 
            groupBoxBracket7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxBracket7.Controls.Add(numericGradient7);
            groupBoxBracket7.Controls.Add(labelGradient7);
            groupBoxBracket7.Controls.Add(numericBase7);
            groupBoxBracket7.Controls.Add(labelBase7);
            groupBoxBracket7.Location = new Point(446, 117);
            groupBoxBracket7.Name = "groupBoxBracket7";
            groupBoxBracket7.Size = new Size(130, 78);
            groupBoxBracket7.TabIndex = 8;
            groupBoxBracket7.TabStop = false;
            groupBoxBracket7.Text = "Lvl 62-81";
            // 
            // numericGradient7
            // 
            numericGradient7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericGradient7.Location = new Point(67, 46);
            numericGradient7.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericGradient7.Name = "numericGradient7";
            numericGradient7.Size = new Size(57, 23);
            numericGradient7.TabIndex = 3;
            numericGradient7.ValueChanged += numericGradient_ValueChanged;
            // 
            // labelGradient7
            // 
            labelGradient7.AutoSize = true;
            labelGradient7.Location = new Point(6, 48);
            labelGradient7.Name = "labelGradient7";
            labelGradient7.Size = new Size(55, 15);
            labelGradient7.TabIndex = 2;
            labelGradient7.Text = "Gradient:";
            // 
            // numericBase7
            // 
            numericBase7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericBase7.Location = new Point(67, 17);
            numericBase7.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericBase7.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
            numericBase7.Name = "numericBase7";
            numericBase7.Size = new Size(57, 23);
            numericBase7.TabIndex = 1;
            numericBase7.ValueChanged += numericBase_ValueChanged;
            // 
            // labelBase7
            // 
            labelBase7.AutoSize = true;
            labelBase7.Location = new Point(27, 19);
            labelBase7.Name = "labelBase7";
            labelBase7.Size = new Size(34, 15);
            labelBase7.TabIndex = 0;
            labelBase7.Text = "Base:";
            // 
            // groupBoxBracket6
            // 
            groupBoxBracket6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxBracket6.Controls.Add(numericGradient6);
            groupBoxBracket6.Controls.Add(labelGradient6);
            groupBoxBracket6.Controls.Add(numericBase6);
            groupBoxBracket6.Controls.Add(labelBase6);
            groupBoxBracket6.Location = new Point(310, 117);
            groupBoxBracket6.Name = "groupBoxBracket6";
            groupBoxBracket6.Size = new Size(130, 78);
            groupBoxBracket6.TabIndex = 7;
            groupBoxBracket6.TabStop = false;
            groupBoxBracket6.Text = "Lvl 52-61";
            // 
            // numericGradient6
            // 
            numericGradient6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericGradient6.Location = new Point(67, 46);
            numericGradient6.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericGradient6.Name = "numericGradient6";
            numericGradient6.Size = new Size(57, 23);
            numericGradient6.TabIndex = 3;
            numericGradient6.ValueChanged += numericGradient_ValueChanged;
            // 
            // labelGradient6
            // 
            labelGradient6.AutoSize = true;
            labelGradient6.Location = new Point(6, 48);
            labelGradient6.Name = "labelGradient6";
            labelGradient6.Size = new Size(55, 15);
            labelGradient6.TabIndex = 2;
            labelGradient6.Text = "Gradient:";
            // 
            // numericBase6
            // 
            numericBase6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericBase6.Location = new Point(67, 17);
            numericBase6.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericBase6.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
            numericBase6.Name = "numericBase6";
            numericBase6.Size = new Size(57, 23);
            numericBase6.TabIndex = 1;
            numericBase6.ValueChanged += numericBase_ValueChanged;
            // 
            // labelBase6
            // 
            labelBase6.AutoSize = true;
            labelBase6.Location = new Point(27, 19);
            labelBase6.Name = "labelBase6";
            labelBase6.Size = new Size(34, 15);
            labelBase6.TabIndex = 0;
            labelBase6.Text = "Base:";
            // 
            // groupBoxBracket5
            // 
            groupBoxBracket5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxBracket5.Controls.Add(numericGradient5);
            groupBoxBracket5.Controls.Add(labelGradient5);
            groupBoxBracket5.Controls.Add(numericBase5);
            groupBoxBracket5.Controls.Add(labelBase5);
            groupBoxBracket5.Location = new Point(174, 117);
            groupBoxBracket5.Name = "groupBoxBracket5";
            groupBoxBracket5.Size = new Size(130, 78);
            groupBoxBracket5.TabIndex = 6;
            groupBoxBracket5.TabStop = false;
            groupBoxBracket5.Text = "Lvl 42-51";
            // 
            // numericGradient5
            // 
            numericGradient5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericGradient5.Location = new Point(67, 46);
            numericGradient5.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericGradient5.Name = "numericGradient5";
            numericGradient5.Size = new Size(57, 23);
            numericGradient5.TabIndex = 3;
            numericGradient5.ValueChanged += numericGradient_ValueChanged;
            // 
            // labelGradient5
            // 
            labelGradient5.AutoSize = true;
            labelGradient5.Location = new Point(6, 48);
            labelGradient5.Name = "labelGradient5";
            labelGradient5.Size = new Size(55, 15);
            labelGradient5.TabIndex = 2;
            labelGradient5.Text = "Gradient:";
            // 
            // numericBase5
            // 
            numericBase5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericBase5.Location = new Point(67, 17);
            numericBase5.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            numericBase5.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
            numericBase5.Name = "numericBase5";
            numericBase5.Size = new Size(57, 23);
            numericBase5.TabIndex = 1;
            numericBase5.ValueChanged += numericBase_ValueChanged;
            // 
            // labelBase5
            // 
            labelBase5.AutoSize = true;
            labelBase5.Location = new Point(27, 19);
            labelBase5.Name = "labelBase5";
            labelBase5.Size = new Size(34, 15);
            labelBase5.TabIndex = 0;
            labelBase5.Text = "Base:";
            // 
            // CurveEditForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(724, 246);
            Controls.Add(groupBoxBracket8);
            Controls.Add(groupBoxBracket7);
            Controls.Add(groupBoxBracket6);
            Controls.Add(groupBoxBracket5);
            Controls.Add(groupBoxBracket4);
            Controls.Add(groupBoxBracket3);
            Controls.Add(groupBoxBracket2);
            Controls.Add(groupBoxBracket1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(labelCurveIndex);
            Controls.Add(groupBoxUsedBy);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CurveEditForm";
            Text = "Edit base curve";
            groupBoxUsedBy.ResumeLayout(false);
            groupBoxBracket1.ResumeLayout(false);
            groupBoxBracket1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBase1).EndInit();
            groupBoxBracket2.ResumeLayout(false);
            groupBoxBracket2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBase2).EndInit();
            groupBoxBracket4.ResumeLayout(false);
            groupBoxBracket4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBase4).EndInit();
            groupBoxBracket3.ResumeLayout(false);
            groupBoxBracket3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBase3).EndInit();
            groupBoxBracket8.ResumeLayout(false);
            groupBoxBracket8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBase8).EndInit();
            groupBoxBracket7.ResumeLayout(false);
            groupBoxBracket7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBase7).EndInit();
            groupBoxBracket6.ResumeLayout(false);
            groupBoxBracket6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBase6).EndInit();
            groupBoxBracket5.ResumeLayout(false);
            groupBoxBracket5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradient5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBase5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxUsedBy;
        private Label labelCurveIndex;
        private Label labelUsedBy;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBoxBracket1;
        private NumericUpDown numericGradient1;
        private Label labelGradient1;
        private NumericUpDown numericBase1;
        private Label labelBase1;
        private GroupBox groupBoxBracket2;
        private NumericUpDown numericGradient2;
        private Label labelGradient2;
        private NumericUpDown numericBase2;
        private Label labelBase2;
        private GroupBox groupBoxBracket4;
        private NumericUpDown numericGradient4;
        private Label labelGradient4;
        private NumericUpDown numericBase4;
        private Label labelBase4;
        private GroupBox groupBoxBracket3;
        private NumericUpDown numericGradient3;
        private Label labelGradient3;
        private NumericUpDown numericBase3;
        private Label labelBase3;
        private GroupBox groupBoxBracket8;
        private NumericUpDown numericGradient8;
        private Label labelGradient8;
        private NumericUpDown numericBase8;
        private Label labelBase8;
        private GroupBox groupBoxBracket7;
        private NumericUpDown numericGradient7;
        private Label labelGradient7;
        private NumericUpDown numericBase7;
        private Label labelBase7;
        private GroupBox groupBoxBracket6;
        private NumericUpDown numericGradient6;
        private Label labelGradient6;
        private NumericUpDown numericBase6;
        private Label labelBase6;
        private GroupBox groupBoxBracket5;
        private NumericUpDown numericGradient5;
        private Label labelGradient5;
        private NumericUpDown numericBase5;
        private Label labelBase5;
    }
}