
namespace FF7Scarlet
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxOpcodes = new System.Windows.Forms.ComboBox();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPageGenerate = new System.Windows.Forms.TabPage();
            this.groupBoxGeneratedParameters = new System.Windows.Forms.GroupBox();
            this.labelParameter2 = new System.Windows.Forms.Label();
            this.labelParameter1 = new System.Windows.Forms.Label();
            this.buttonParameter2 = new System.Windows.Forms.Button();
            this.textBoxParameter2 = new System.Windows.Forms.TextBox();
            this.buttonParameter1 = new System.Windows.Forms.Button();
            this.textBoxParameter1 = new System.Windows.Forms.TextBox();
            this.comboBoxCommands = new System.Windows.Forms.ComboBox();
            this.labelGenerateCommands = new System.Windows.Forms.Label();
            this.tabPageManual = new System.Windows.Forms.TabPage();
            this.comboBoxManualParameter = new System.Windows.Forms.ComboBox();
            this.groupBoxOpcodes = new System.Windows.Forms.GroupBox();
            this.comboBoxOpcodeGroups = new System.Windows.Forms.ComboBox();
            this.labelManualParameter = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.tabControlOptions.SuspendLayout();
            this.tabPageGenerate.SuspendLayout();
            this.groupBoxGeneratedParameters.SuspendLayout();
            this.tabPageManual.SuspendLayout();
            this.groupBoxOpcodes.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(377, 8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(296, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxOpcodes
            // 
            this.comboBoxOpcodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOpcodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOpcodes.FormattingEnabled = true;
            this.comboBoxOpcodes.Location = new System.Drawing.Point(6, 46);
            this.comboBoxOpcodes.Name = "comboBoxOpcodes";
            this.comboBoxOpcodes.Size = new System.Drawing.Size(425, 21);
            this.comboBoxOpcodes.TabIndex = 3;
            this.comboBoxOpcodes.SelectedIndexChanged += new System.EventHandler(this.comboBoxOpcodes_SelectedIndexChanged);
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.tabPageGenerate);
            this.tabControlOptions.Controls.Add(this.tabPageManual);
            this.tabControlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOptions.Location = new System.Drawing.Point(0, 0);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(464, 181);
            this.tabControlOptions.TabIndex = 5;
            // 
            // tabPageGenerate
            // 
            this.tabPageGenerate.Controls.Add(this.groupBoxGeneratedParameters);
            this.tabPageGenerate.Controls.Add(this.comboBoxCommands);
            this.tabPageGenerate.Controls.Add(this.labelGenerateCommands);
            this.tabPageGenerate.Location = new System.Drawing.Point(4, 22);
            this.tabPageGenerate.Name = "tabPageGenerate";
            this.tabPageGenerate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGenerate.Size = new System.Drawing.Size(456, 155);
            this.tabPageGenerate.TabIndex = 0;
            this.tabPageGenerate.Text = "Generate code";
            this.tabPageGenerate.UseVisualStyleBackColor = true;
            // 
            // groupBoxGeneratedParameters
            // 
            this.groupBoxGeneratedParameters.Controls.Add(this.labelParameter2);
            this.groupBoxGeneratedParameters.Controls.Add(this.labelParameter1);
            this.groupBoxGeneratedParameters.Controls.Add(this.buttonParameter2);
            this.groupBoxGeneratedParameters.Controls.Add(this.textBoxParameter2);
            this.groupBoxGeneratedParameters.Controls.Add(this.buttonParameter1);
            this.groupBoxGeneratedParameters.Controls.Add(this.textBoxParameter1);
            this.groupBoxGeneratedParameters.Location = new System.Drawing.Point(7, 47);
            this.groupBoxGeneratedParameters.Name = "groupBoxGeneratedParameters";
            this.groupBoxGeneratedParameters.Size = new System.Drawing.Size(441, 102);
            this.groupBoxGeneratedParameters.TabIndex = 2;
            this.groupBoxGeneratedParameters.TabStop = false;
            this.groupBoxGeneratedParameters.Text = "Parameters";
            // 
            // labelParameter2
            // 
            this.labelParameter2.Location = new System.Drawing.Point(6, 52);
            this.labelParameter2.Name = "labelParameter2";
            this.labelParameter2.Size = new System.Drawing.Size(66, 13);
            this.labelParameter2.TabIndex = 5;
            this.labelParameter2.Text = "label2";
            this.labelParameter2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelParameter1
            // 
            this.labelParameter1.Location = new System.Drawing.Point(6, 23);
            this.labelParameter1.Name = "labelParameter1";
            this.labelParameter1.Size = new System.Drawing.Size(66, 13);
            this.labelParameter1.TabIndex = 4;
            this.labelParameter1.Text = "label1";
            this.labelParameter1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonParameter2
            // 
            this.buttonParameter2.Location = new System.Drawing.Point(360, 47);
            this.buttonParameter2.Name = "buttonParameter2";
            this.buttonParameter2.Size = new System.Drawing.Size(75, 23);
            this.buttonParameter2.TabIndex = 3;
            this.buttonParameter2.Text = "Edit";
            this.buttonParameter2.UseVisualStyleBackColor = true;
            this.buttonParameter2.Click += new System.EventHandler(this.buttonParameter2_Click);
            // 
            // textBoxParameter2
            // 
            this.textBoxParameter2.Location = new System.Drawing.Point(78, 49);
            this.textBoxParameter2.Name = "textBoxParameter2";
            this.textBoxParameter2.ReadOnly = true;
            this.textBoxParameter2.Size = new System.Drawing.Size(276, 20);
            this.textBoxParameter2.TabIndex = 2;
            // 
            // buttonParameter1
            // 
            this.buttonParameter1.Location = new System.Drawing.Point(360, 18);
            this.buttonParameter1.Name = "buttonParameter1";
            this.buttonParameter1.Size = new System.Drawing.Size(75, 23);
            this.buttonParameter1.TabIndex = 1;
            this.buttonParameter1.Text = "Edit";
            this.buttonParameter1.UseVisualStyleBackColor = true;
            this.buttonParameter1.Click += new System.EventHandler(this.buttonParameter1_Click);
            // 
            // textBoxParameter1
            // 
            this.textBoxParameter1.Location = new System.Drawing.Point(78, 20);
            this.textBoxParameter1.Name = "textBoxParameter1";
            this.textBoxParameter1.ReadOnly = true;
            this.textBoxParameter1.Size = new System.Drawing.Size(276, 20);
            this.textBoxParameter1.TabIndex = 0;
            // 
            // comboBoxCommands
            // 
            this.comboBoxCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCommands.FormattingEnabled = true;
            this.comboBoxCommands.Location = new System.Drawing.Point(6, 19);
            this.comboBoxCommands.Name = "comboBoxCommands";
            this.comboBoxCommands.Size = new System.Drawing.Size(442, 21);
            this.comboBoxCommands.TabIndex = 1;
            // 
            // labelGenerateCommands
            // 
            this.labelGenerateCommands.AutoSize = true;
            this.labelGenerateCommands.Location = new System.Drawing.Point(6, 3);
            this.labelGenerateCommands.Name = "labelGenerateCommands";
            this.labelGenerateCommands.Size = new System.Drawing.Size(59, 13);
            this.labelGenerateCommands.TabIndex = 0;
            this.labelGenerateCommands.Text = "Commands";
            // 
            // tabPageManual
            // 
            this.tabPageManual.Controls.Add(this.comboBoxManualParameter);
            this.tabPageManual.Controls.Add(this.groupBoxOpcodes);
            this.tabPageManual.Controls.Add(this.labelManualParameter);
            this.tabPageManual.Location = new System.Drawing.Point(4, 22);
            this.tabPageManual.Name = "tabPageManual";
            this.tabPageManual.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManual.Size = new System.Drawing.Size(456, 155);
            this.tabPageManual.TabIndex = 1;
            this.tabPageManual.Text = "Manual";
            this.tabPageManual.UseVisualStyleBackColor = true;
            // 
            // comboBoxManualParameter
            // 
            this.comboBoxManualParameter.FormattingEnabled = true;
            this.comboBoxManualParameter.Location = new System.Drawing.Point(78, 92);
            this.comboBoxManualParameter.Name = "comboBoxManualParameter";
            this.comboBoxManualParameter.Size = new System.Drawing.Size(364, 21);
            this.comboBoxManualParameter.TabIndex = 6;
            // 
            // groupBoxOpcodes
            // 
            this.groupBoxOpcodes.Controls.Add(this.comboBoxOpcodeGroups);
            this.groupBoxOpcodes.Controls.Add(this.comboBoxOpcodes);
            this.groupBoxOpcodes.Location = new System.Drawing.Point(11, 7);
            this.groupBoxOpcodes.Name = "groupBoxOpcodes";
            this.groupBoxOpcodes.Size = new System.Drawing.Size(437, 79);
            this.groupBoxOpcodes.TabIndex = 5;
            this.groupBoxOpcodes.TabStop = false;
            this.groupBoxOpcodes.Text = "Opcodes";
            // 
            // comboBoxOpcodeGroups
            // 
            this.comboBoxOpcodeGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOpcodeGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOpcodeGroups.FormattingEnabled = true;
            this.comboBoxOpcodeGroups.Items.AddRange(new object[] {
            "Push commands",
            "Mathematical and bitwise operators",
            "Logical operators and comparisons",
            "Script jumps",
            "Bit operations",
            "Other commands"});
            this.comboBoxOpcodeGroups.Location = new System.Drawing.Point(6, 19);
            this.comboBoxOpcodeGroups.Name = "comboBoxOpcodeGroups";
            this.comboBoxOpcodeGroups.Size = new System.Drawing.Size(425, 21);
            this.comboBoxOpcodeGroups.TabIndex = 4;
            this.comboBoxOpcodeGroups.SelectedIndexChanged += new System.EventHandler(this.comboBoxOpcodeGroups_SelectedIndexChanged);
            // 
            // labelManualParameter
            // 
            this.labelManualParameter.AutoSize = true;
            this.labelManualParameter.Location = new System.Drawing.Point(17, 95);
            this.labelManualParameter.Name = "labelManualParameter";
            this.labelManualParameter.Size = new System.Drawing.Size(55, 13);
            this.labelManualParameter.TabIndex = 1;
            this.labelManualParameter.Text = "Parameter";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonOK);
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 181);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(464, 40);
            this.panelButtons.TabIndex = 6;
            // 
            // CodeForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(464, 221);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CodeForm";
            this.Text = "Add/edit code";
            this.Load += new System.EventHandler(this.CodeForm_Load);
            this.tabControlOptions.ResumeLayout(false);
            this.tabPageGenerate.ResumeLayout(false);
            this.tabPageGenerate.PerformLayout();
            this.groupBoxGeneratedParameters.ResumeLayout(false);
            this.groupBoxGeneratedParameters.PerformLayout();
            this.tabPageManual.ResumeLayout(false);
            this.tabPageManual.PerformLayout();
            this.groupBoxOpcodes.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

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