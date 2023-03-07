
namespace FF7Scarlet.AIEditor
{
    partial class CodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeForm));
            buttonOK = new Button();
            buttonCancel = new Button();
            comboBoxOpcodes = new ComboBox();
            tabControlOptions = new TabControl();
            tabPageGenerate = new TabPage();
            groupBoxGeneratedParameters = new GroupBox();
            labelParameter2 = new Label();
            labelParameter1 = new Label();
            buttonParameter2 = new Button();
            textBoxParameter2 = new TextBox();
            buttonParameter1 = new Button();
            textBoxParameter1 = new TextBox();
            comboBoxCommands = new ComboBox();
            labelGenerateCommands = new Label();
            tabPageManual = new TabPage();
            comboBoxManualParameter = new ComboBox();
            groupBoxOpcodes = new GroupBox();
            comboBoxOpcodeGroups = new ComboBox();
            labelManualParameter = new Label();
            panelButtons = new Panel();
            tabControlOptions.SuspendLayout();
            tabPageGenerate.SuspendLayout();
            groupBoxGeneratedParameters.SuspendLayout();
            tabPageManual.SuspendLayout();
            groupBoxOpcodes.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(440, 9);
            buttonOK.Margin = new Padding(4, 3, 4, 3);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(88, 27);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(345, 9);
            buttonCancel.Margin = new Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(88, 27);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxOpcodes
            // 
            comboBoxOpcodes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxOpcodes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOpcodes.FormattingEnabled = true;
            comboBoxOpcodes.Location = new Point(7, 53);
            comboBoxOpcodes.Margin = new Padding(4, 3, 4, 3);
            comboBoxOpcodes.Name = "comboBoxOpcodes";
            comboBoxOpcodes.Size = new Size(495, 23);
            comboBoxOpcodes.TabIndex = 3;
            comboBoxOpcodes.SelectedIndexChanged += comboBoxOpcodes_SelectedIndexChanged;
            // 
            // tabControlOptions
            // 
            tabControlOptions.Controls.Add(tabPageGenerate);
            tabControlOptions.Controls.Add(tabPageManual);
            tabControlOptions.Dock = DockStyle.Fill;
            tabControlOptions.Location = new Point(0, 0);
            tabControlOptions.Margin = new Padding(4, 3, 4, 3);
            tabControlOptions.Name = "tabControlOptions";
            tabControlOptions.SelectedIndex = 0;
            tabControlOptions.Size = new Size(541, 209);
            tabControlOptions.TabIndex = 5;
            // 
            // tabPageGenerate
            // 
            tabPageGenerate.Controls.Add(groupBoxGeneratedParameters);
            tabPageGenerate.Controls.Add(comboBoxCommands);
            tabPageGenerate.Controls.Add(labelGenerateCommands);
            tabPageGenerate.Location = new Point(4, 24);
            tabPageGenerate.Margin = new Padding(4, 3, 4, 3);
            tabPageGenerate.Name = "tabPageGenerate";
            tabPageGenerate.Padding = new Padding(4, 3, 4, 3);
            tabPageGenerate.Size = new Size(533, 181);
            tabPageGenerate.TabIndex = 0;
            tabPageGenerate.Text = "Generate code";
            tabPageGenerate.UseVisualStyleBackColor = true;
            // 
            // groupBoxGeneratedParameters
            // 
            groupBoxGeneratedParameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxGeneratedParameters.Controls.Add(labelParameter2);
            groupBoxGeneratedParameters.Controls.Add(labelParameter1);
            groupBoxGeneratedParameters.Controls.Add(buttonParameter2);
            groupBoxGeneratedParameters.Controls.Add(textBoxParameter2);
            groupBoxGeneratedParameters.Controls.Add(buttonParameter1);
            groupBoxGeneratedParameters.Controls.Add(textBoxParameter1);
            groupBoxGeneratedParameters.Location = new Point(8, 54);
            groupBoxGeneratedParameters.Margin = new Padding(4, 3, 4, 3);
            groupBoxGeneratedParameters.Name = "groupBoxGeneratedParameters";
            groupBoxGeneratedParameters.Padding = new Padding(4, 3, 4, 3);
            groupBoxGeneratedParameters.Size = new Size(514, 118);
            groupBoxGeneratedParameters.TabIndex = 2;
            groupBoxGeneratedParameters.TabStop = false;
            groupBoxGeneratedParameters.Text = "Parameters";
            // 
            // labelParameter2
            // 
            labelParameter2.Location = new Point(7, 60);
            labelParameter2.Margin = new Padding(4, 0, 4, 0);
            labelParameter2.Name = "labelParameter2";
            labelParameter2.Size = new Size(77, 15);
            labelParameter2.TabIndex = 5;
            labelParameter2.Text = "label2";
            labelParameter2.TextAlign = ContentAlignment.TopRight;
            // 
            // labelParameter1
            // 
            labelParameter1.Location = new Point(7, 27);
            labelParameter1.Margin = new Padding(4, 0, 4, 0);
            labelParameter1.Name = "labelParameter1";
            labelParameter1.Size = new Size(77, 15);
            labelParameter1.TabIndex = 4;
            labelParameter1.Text = "label1";
            labelParameter1.TextAlign = ContentAlignment.TopRight;
            // 
            // buttonParameter2
            // 
            buttonParameter2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonParameter2.Location = new Point(420, 54);
            buttonParameter2.Margin = new Padding(4, 3, 4, 3);
            buttonParameter2.Name = "buttonParameter2";
            buttonParameter2.Size = new Size(88, 27);
            buttonParameter2.TabIndex = 3;
            buttonParameter2.Text = "Edit";
            buttonParameter2.UseVisualStyleBackColor = true;
            buttonParameter2.Click += buttonParameter2_Click;
            // 
            // textBoxParameter2
            // 
            textBoxParameter2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxParameter2.Location = new Point(91, 57);
            textBoxParameter2.Margin = new Padding(4, 3, 4, 3);
            textBoxParameter2.Name = "textBoxParameter2";
            textBoxParameter2.ReadOnly = true;
            textBoxParameter2.Size = new Size(321, 23);
            textBoxParameter2.TabIndex = 2;
            // 
            // buttonParameter1
            // 
            buttonParameter1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonParameter1.Location = new Point(420, 21);
            buttonParameter1.Margin = new Padding(4, 3, 4, 3);
            buttonParameter1.Name = "buttonParameter1";
            buttonParameter1.Size = new Size(88, 27);
            buttonParameter1.TabIndex = 1;
            buttonParameter1.Text = "Edit";
            buttonParameter1.UseVisualStyleBackColor = true;
            buttonParameter1.Click += buttonParameter1_Click;
            // 
            // textBoxParameter1
            // 
            textBoxParameter1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxParameter1.Location = new Point(91, 23);
            textBoxParameter1.Margin = new Padding(4, 3, 4, 3);
            textBoxParameter1.Name = "textBoxParameter1";
            textBoxParameter1.ReadOnly = true;
            textBoxParameter1.Size = new Size(321, 23);
            textBoxParameter1.TabIndex = 0;
            // 
            // comboBoxCommands
            // 
            comboBoxCommands.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCommands.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCommands.FormattingEnabled = true;
            comboBoxCommands.Location = new Point(7, 22);
            comboBoxCommands.Margin = new Padding(4, 3, 4, 3);
            comboBoxCommands.Name = "comboBoxCommands";
            comboBoxCommands.Size = new Size(515, 23);
            comboBoxCommands.TabIndex = 1;
            comboBoxCommands.SelectedIndexChanged += comboBoxCommands_SelectedIndexChanged;
            // 
            // labelGenerateCommands
            // 
            labelGenerateCommands.AutoSize = true;
            labelGenerateCommands.Location = new Point(7, 3);
            labelGenerateCommands.Margin = new Padding(4, 0, 4, 0);
            labelGenerateCommands.Name = "labelGenerateCommands";
            labelGenerateCommands.Size = new Size(69, 15);
            labelGenerateCommands.TabIndex = 0;
            labelGenerateCommands.Text = "Commands";
            // 
            // tabPageManual
            // 
            tabPageManual.Controls.Add(comboBoxManualParameter);
            tabPageManual.Controls.Add(groupBoxOpcodes);
            tabPageManual.Controls.Add(labelManualParameter);
            tabPageManual.Location = new Point(4, 24);
            tabPageManual.Margin = new Padding(4, 3, 4, 3);
            tabPageManual.Name = "tabPageManual";
            tabPageManual.Padding = new Padding(4, 3, 4, 3);
            tabPageManual.Size = new Size(533, 181);
            tabPageManual.TabIndex = 1;
            tabPageManual.Text = "Manual";
            tabPageManual.UseVisualStyleBackColor = true;
            // 
            // comboBoxManualParameter
            // 
            comboBoxManualParameter.FormattingEnabled = true;
            comboBoxManualParameter.Location = new Point(91, 106);
            comboBoxManualParameter.Margin = new Padding(4, 3, 4, 3);
            comboBoxManualParameter.Name = "comboBoxManualParameter";
            comboBoxManualParameter.Size = new Size(424, 23);
            comboBoxManualParameter.TabIndex = 6;
            comboBoxManualParameter.TextUpdate += comboBoxManualParameter_TextUpdate;
            // 
            // groupBoxOpcodes
            // 
            groupBoxOpcodes.Controls.Add(comboBoxOpcodeGroups);
            groupBoxOpcodes.Controls.Add(comboBoxOpcodes);
            groupBoxOpcodes.Location = new Point(13, 8);
            groupBoxOpcodes.Margin = new Padding(4, 3, 4, 3);
            groupBoxOpcodes.Name = "groupBoxOpcodes";
            groupBoxOpcodes.Padding = new Padding(4, 3, 4, 3);
            groupBoxOpcodes.Size = new Size(510, 91);
            groupBoxOpcodes.TabIndex = 5;
            groupBoxOpcodes.TabStop = false;
            groupBoxOpcodes.Text = "Opcodes";
            // 
            // comboBoxOpcodeGroups
            // 
            comboBoxOpcodeGroups.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxOpcodeGroups.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOpcodeGroups.FormattingEnabled = true;
            comboBoxOpcodeGroups.Items.AddRange(new object[] { "Push commands", "Mathematical and bitwise operators", "Logical operators and comparisons", "Script jumps", "Bit operations", "Other commands" });
            comboBoxOpcodeGroups.Location = new Point(7, 22);
            comboBoxOpcodeGroups.Margin = new Padding(4, 3, 4, 3);
            comboBoxOpcodeGroups.Name = "comboBoxOpcodeGroups";
            comboBoxOpcodeGroups.Size = new Size(495, 23);
            comboBoxOpcodeGroups.TabIndex = 4;
            comboBoxOpcodeGroups.SelectedIndexChanged += comboBoxOpcodeGroups_SelectedIndexChanged;
            // 
            // labelManualParameter
            // 
            labelManualParameter.AutoSize = true;
            labelManualParameter.Location = new Point(20, 110);
            labelManualParameter.Margin = new Padding(4, 0, 4, 0);
            labelManualParameter.Name = "labelManualParameter";
            labelManualParameter.Size = new Size(61, 15);
            labelManualParameter.TabIndex = 1;
            labelManualParameter.Text = "Parameter";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonOK);
            panelButtons.Controls.Add(buttonCancel);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 209);
            panelButtons.Margin = new Padding(4, 3, 4, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(541, 46);
            panelButtons.TabIndex = 6;
            // 
            // CodeForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(541, 255);
            Controls.Add(tabControlOptions);
            Controls.Add(panelButtons);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "CodeForm";
            Text = "Add/edit code";
            tabControlOptions.ResumeLayout(false);
            tabPageGenerate.ResumeLayout(false);
            tabPageGenerate.PerformLayout();
            groupBoxGeneratedParameters.ResumeLayout(false);
            groupBoxGeneratedParameters.PerformLayout();
            tabPageManual.ResumeLayout(false);
            tabPageManual.PerformLayout();
            groupBoxOpcodes.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxOpcodes;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPageGenerate;
        private System.Windows.Forms.TabPage tabPageManual;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label labelGenerateCommands;
        private System.Windows.Forms.ComboBox comboBoxCommands;
        private System.Windows.Forms.GroupBox groupBoxGeneratedParameters;
        private System.Windows.Forms.Label labelManualParameter;
        private System.Windows.Forms.GroupBox groupBoxOpcodes;
        private System.Windows.Forms.ComboBox comboBoxOpcodeGroups;
        private System.Windows.Forms.ComboBox comboBoxManualParameter;
        private System.Windows.Forms.Button buttonParameter2;
        private System.Windows.Forms.TextBox textBoxParameter2;
        private System.Windows.Forms.Button buttonParameter1;
        private System.Windows.Forms.TextBox textBoxParameter1;
        private System.Windows.Forms.Label labelParameter2;
        private System.Windows.Forms.Label labelParameter1;
    }
}