namespace FF7Scarlet
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            groupBoxBattleLgp = new GroupBox();
            labelBattleLgp = new Label();
            textBoxBattleLgp = new TextBox();
            buttonBattleLgpBrowse = new Button();
            buttonOK = new Button();
            buttonCancel = new Button();
            groupBoxVanillaExe = new GroupBox();
            labelVanillaExe = new Label();
            textBoxVanillaExe = new TextBox();
            buttonVanillaExeBrowse = new Button();
            groupBoxPS3Tweaks = new GroupBox();
            checkBoxPS3Tweaks = new CheckBox();
            labelPS3Tweaks = new Label();
            groupBoxRememberLastOpened = new GroupBox();
            checkBoxRemeberLastOpened = new CheckBox();
            groupBoxCheckForUpdates = new GroupBox();
            buttonCheckForUpdates = new Button();
            checkBoxUpdateOnLaunch = new CheckBox();
            labelUpdateChannelDesc = new Label();
            labelUpdateChannel = new Label();
            comboBoxUpdateChannel = new ComboBox();
            groupBoxBattleLgp.SuspendLayout();
            groupBoxVanillaExe.SuspendLayout();
            groupBoxPS3Tweaks.SuspendLayout();
            groupBoxRememberLastOpened.SuspendLayout();
            groupBoxCheckForUpdates.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxBattleLgp
            // 
            groupBoxBattleLgp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxBattleLgp.Controls.Add(labelBattleLgp);
            groupBoxBattleLgp.Controls.Add(textBoxBattleLgp);
            groupBoxBattleLgp.Controls.Add(buttonBattleLgpBrowse);
            groupBoxBattleLgp.Location = new Point(16, 279);
            groupBoxBattleLgp.Margin = new Padding(4, 3, 4, 3);
            groupBoxBattleLgp.Name = "groupBoxBattleLgp";
            groupBoxBattleLgp.Padding = new Padding(4, 3, 4, 3);
            groupBoxBattleLgp.Size = new Size(458, 98);
            groupBoxBattleLgp.TabIndex = 1;
            groupBoxBattleLgp.TabStop = false;
            groupBoxBattleLgp.Text = "battle.lgp";
            // 
            // labelBattleLgp
            // 
            labelBattleLgp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelBattleLgp.Location = new Point(8, 19);
            labelBattleLgp.Name = "labelBattleLgp";
            labelBattleLgp.Size = new Size(442, 45);
            labelBattleLgp.TabIndex = 6;
            labelBattleLgp.Text = "This file contains the battle models, and will increase accuracy when dealing with model data.";
            // 
            // textBoxBattleLgp
            // 
            textBoxBattleLgp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxBattleLgp.Location = new Point(10, 67);
            textBoxBattleLgp.Margin = new Padding(4, 3, 4, 3);
            textBoxBattleLgp.Name = "textBoxBattleLgp";
            textBoxBattleLgp.Size = new Size(346, 23);
            textBoxBattleLgp.TabIndex = 5;
            // 
            // buttonBattleLgpBrowse
            // 
            buttonBattleLgpBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonBattleLgpBrowse.Location = new Point(364, 67);
            buttonBattleLgpBrowse.Margin = new Padding(4, 3, 4, 3);
            buttonBattleLgpBrowse.Name = "buttonBattleLgpBrowse";
            buttonBattleLgpBrowse.Size = new Size(88, 23);
            buttonBattleLgpBrowse.TabIndex = 3;
            buttonBattleLgpBrowse.Text = "Browse...";
            buttonBattleLgpBrowse.UseVisualStyleBackColor = true;
            buttonBattleLgpBrowse.Click += buttonBattleLgpBrowse_Click;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(397, 466);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 3;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(316, 466);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxVanillaExe
            // 
            groupBoxVanillaExe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxVanillaExe.Controls.Add(labelVanillaExe);
            groupBoxVanillaExe.Controls.Add(textBoxVanillaExe);
            groupBoxVanillaExe.Controls.Add(buttonVanillaExeBrowse);
            groupBoxVanillaExe.Location = new Point(16, 175);
            groupBoxVanillaExe.Margin = new Padding(4, 3, 4, 3);
            groupBoxVanillaExe.Name = "groupBoxVanillaExe";
            groupBoxVanillaExe.Padding = new Padding(4, 3, 4, 3);
            groupBoxVanillaExe.Size = new Size(458, 98);
            groupBoxVanillaExe.TabIndex = 0;
            groupBoxVanillaExe.TabStop = false;
            groupBoxVanillaExe.Text = "Unedited ff7.exe";
            // 
            // labelVanillaExe
            // 
            labelVanillaExe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelVanillaExe.Location = new Point(9, 19);
            labelVanillaExe.Name = "labelVanillaExe";
            labelVanillaExe.Size = new Size(440, 43);
            labelVanillaExe.TabIndex = 6;
            labelVanillaExe.Text = "This should be a completely unedited ff7.exe file, to be referenced when creating Hext files. Currently only English EXEs are supported.";
            // 
            // textBoxVanillaExe
            // 
            textBoxVanillaExe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxVanillaExe.Location = new Point(10, 65);
            textBoxVanillaExe.Margin = new Padding(4, 3, 4, 3);
            textBoxVanillaExe.Name = "textBoxVanillaExe";
            textBoxVanillaExe.Size = new Size(346, 23);
            textBoxVanillaExe.TabIndex = 5;
            // 
            // buttonVanillaExeBrowse
            // 
            buttonVanillaExeBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonVanillaExeBrowse.Location = new Point(364, 65);
            buttonVanillaExeBrowse.Margin = new Padding(4, 3, 4, 3);
            buttonVanillaExeBrowse.Name = "buttonVanillaExeBrowse";
            buttonVanillaExeBrowse.Size = new Size(88, 23);
            buttonVanillaExeBrowse.TabIndex = 3;
            buttonVanillaExeBrowse.Text = "Browse...";
            buttonVanillaExeBrowse.UseVisualStyleBackColor = true;
            buttonVanillaExeBrowse.Click += buttonVanillaExeBrowse_Click;
            // 
            // groupBoxPS3Tweaks
            // 
            groupBoxPS3Tweaks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxPS3Tweaks.Controls.Add(checkBoxPS3Tweaks);
            groupBoxPS3Tweaks.Controls.Add(labelPS3Tweaks);
            groupBoxPS3Tweaks.Location = new Point(16, 383);
            groupBoxPS3Tweaks.Name = "groupBoxPS3Tweaks";
            groupBoxPS3Tweaks.Size = new Size(458, 73);
            groupBoxPS3Tweaks.TabIndex = 4;
            groupBoxPS3Tweaks.TabStop = false;
            groupBoxPS3Tweaks.Text = "Postscriptthree tweaks";
            // 
            // checkBoxPS3Tweaks
            // 
            checkBoxPS3Tweaks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBoxPS3Tweaks.AutoSize = true;
            checkBoxPS3Tweaks.Location = new Point(10, 48);
            checkBoxPS3Tweaks.Name = "checkBoxPS3Tweaks";
            checkBoxPS3Tweaks.Size = new Size(68, 19);
            checkBoxPS3Tweaks.TabIndex = 1;
            checkBoxPS3Tweaks.Text = "Enabled";
            checkBoxPS3Tweaks.UseVisualStyleBackColor = true;
            // 
            // labelPS3Tweaks
            // 
            labelPS3Tweaks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPS3Tweaks.Location = new Point(10, 19);
            labelPS3Tweaks.Name = "labelPS3Tweaks";
            labelPS3Tweaks.Size = new Size(442, 20);
            labelPS3Tweaks.TabIndex = 0;
            labelPS3Tweaks.Text = "Include additional features enabled by the Postscriptthree Tweaks mod.";
            // 
            // groupBoxRememberLastOpened
            // 
            groupBoxRememberLastOpened.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxRememberLastOpened.Controls.Add(checkBoxRemeberLastOpened);
            groupBoxRememberLastOpened.Location = new Point(16, 118);
            groupBoxRememberLastOpened.Name = "groupBoxRememberLastOpened";
            groupBoxRememberLastOpened.Size = new Size(458, 51);
            groupBoxRememberLastOpened.TabIndex = 5;
            groupBoxRememberLastOpened.TabStop = false;
            groupBoxRememberLastOpened.Text = "Remember last opened files";
            // 
            // checkBoxRemeberLastOpened
            // 
            checkBoxRemeberLastOpened.AutoSize = true;
            checkBoxRemeberLastOpened.Location = new Point(9, 22);
            checkBoxRemeberLastOpened.Name = "checkBoxRemeberLastOpened";
            checkBoxRemeberLastOpened.Size = new Size(68, 19);
            checkBoxRemeberLastOpened.TabIndex = 0;
            checkBoxRemeberLastOpened.Text = "Enabled";
            checkBoxRemeberLastOpened.UseVisualStyleBackColor = true;
            // 
            // groupBoxCheckForUpdates
            // 
            groupBoxCheckForUpdates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxCheckForUpdates.Controls.Add(buttonCheckForUpdates);
            groupBoxCheckForUpdates.Controls.Add(checkBoxUpdateOnLaunch);
            groupBoxCheckForUpdates.Controls.Add(labelUpdateChannelDesc);
            groupBoxCheckForUpdates.Controls.Add(labelUpdateChannel);
            groupBoxCheckForUpdates.Controls.Add(comboBoxUpdateChannel);
            groupBoxCheckForUpdates.Location = new Point(16, 12);
            groupBoxCheckForUpdates.Name = "groupBoxCheckForUpdates";
            groupBoxCheckForUpdates.Size = new Size(458, 100);
            groupBoxCheckForUpdates.TabIndex = 6;
            groupBoxCheckForUpdates.TabStop = false;
            groupBoxCheckForUpdates.Text = "Check for updates";
            // 
            // buttonCheckForUpdates
            // 
            buttonCheckForUpdates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCheckForUpdates.Location = new Point(334, 21);
            buttonCheckForUpdates.Name = "buttonCheckForUpdates";
            buttonCheckForUpdates.Size = new Size(116, 23);
            buttonCheckForUpdates.TabIndex = 4;
            buttonCheckForUpdates.Text = "Check now";
            buttonCheckForUpdates.UseVisualStyleBackColor = true;
            buttonCheckForUpdates.Click += buttonCheckForUpdates_Click;
            // 
            // checkBoxUpdateOnLaunch
            // 
            checkBoxUpdateOnLaunch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxUpdateOnLaunch.AutoSize = true;
            checkBoxUpdateOnLaunch.Location = new Point(334, 50);
            checkBoxUpdateOnLaunch.Name = "checkBoxUpdateOnLaunch";
            checkBoxUpdateOnLaunch.Size = new Size(115, 19);
            checkBoxUpdateOnLaunch.TabIndex = 3;
            checkBoxUpdateOnLaunch.Text = "Check on launch";
            checkBoxUpdateOnLaunch.UseVisualStyleBackColor = true;
            // 
            // labelUpdateChannelDesc
            // 
            labelUpdateChannelDesc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelUpdateChannelDesc.Location = new Point(109, 48);
            labelUpdateChannelDesc.Name = "labelUpdateChannelDesc";
            labelUpdateChannelDesc.Size = new Size(219, 49);
            labelUpdateChannelDesc.TabIndex = 2;
            labelUpdateChannelDesc.Text = "(text goes here)";
            // 
            // labelUpdateChannel
            // 
            labelUpdateChannel.AutoSize = true;
            labelUpdateChannel.Location = new Point(10, 25);
            labelUpdateChannel.Name = "labelUpdateChannel";
            labelUpdateChannel.Size = new Size(93, 15);
            labelUpdateChannel.TabIndex = 1;
            labelUpdateChannel.Text = "Update channel:";
            // 
            // comboBoxUpdateChannel
            // 
            comboBoxUpdateChannel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxUpdateChannel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUpdateChannel.FormattingEnabled = true;
            comboBoxUpdateChannel.Items.AddRange(new object[] { "Stable", "Canary" });
            comboBoxUpdateChannel.Location = new Point(109, 22);
            comboBoxUpdateChannel.Name = "comboBoxUpdateChannel";
            comboBoxUpdateChannel.Size = new Size(219, 23);
            comboBoxUpdateChannel.TabIndex = 0;
            comboBoxUpdateChannel.SelectedIndexChanged += comboBoxUpdateChannel_SelectedIndexChanged;
            // 
            // SettingsForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(484, 501);
            Controls.Add(groupBoxCheckForUpdates);
            Controls.Add(groupBoxRememberLastOpened);
            Controls.Add(groupBoxPS3Tweaks);
            Controls.Add(groupBoxVanillaExe);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(groupBoxBattleLgp);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(480, 540);
            Name = "SettingsForm";
            Text = "Scarlet - Settings";
            groupBoxBattleLgp.ResumeLayout(false);
            groupBoxBattleLgp.PerformLayout();
            groupBoxVanillaExe.ResumeLayout(false);
            groupBoxVanillaExe.PerformLayout();
            groupBoxPS3Tweaks.ResumeLayout(false);
            groupBoxPS3Tweaks.PerformLayout();
            groupBoxRememberLastOpened.ResumeLayout(false);
            groupBoxRememberLastOpened.PerformLayout();
            groupBoxCheckForUpdates.ResumeLayout(false);
            groupBoxCheckForUpdates.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxBattleLgp;
        private TextBox textBoxBattleLgp;
        private Button buttonBattleLgpBrowse;
        private Label labelBattleLgp;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBoxVanillaExe;
        private Label labelVanillaExe;
        private TextBox textBoxVanillaExe;
        private Button buttonVanillaExeBrowse;
        private GroupBox groupBoxPS3Tweaks;
        private Label labelPS3Tweaks;
        private CheckBox checkBoxPS3Tweaks;
        private GroupBox groupBoxRememberLastOpened;
        private CheckBox checkBoxRemeberLastOpened;
        private GroupBox groupBoxCheckForUpdates;
        private Label labelUpdateChannel;
        private ComboBox comboBoxUpdateChannel;
        private Label labelUpdateChannelDesc;
        private Button buttonCheckForUpdates;
        private CheckBox checkBoxUpdateOnLaunch;
    }
}