namespace FF7Scarlet.KernelEditor.Controls
{
    partial class ItemRestrictionsControl
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
            groupBoxWeaponRestrictions = new GroupBox();
            checkBoxIsThrowable = new CheckBox();
            checkBoxIsSellable = new CheckBox();
            checkBoxUsableInMenu = new CheckBox();
            checkBoxUsableInBattle = new CheckBox();
            groupBoxWeaponRestrictions.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxWeaponRestrictions
            // 
            groupBoxWeaponRestrictions.Controls.Add(checkBoxIsThrowable);
            groupBoxWeaponRestrictions.Controls.Add(checkBoxIsSellable);
            groupBoxWeaponRestrictions.Controls.Add(checkBoxUsableInMenu);
            groupBoxWeaponRestrictions.Controls.Add(checkBoxUsableInBattle);
            groupBoxWeaponRestrictions.Dock = DockStyle.Fill;
            groupBoxWeaponRestrictions.Location = new Point(0, 0);
            groupBoxWeaponRestrictions.Name = "groupBoxWeaponRestrictions";
            groupBoxWeaponRestrictions.Size = new Size(240, 125);
            groupBoxWeaponRestrictions.TabIndex = 20;
            groupBoxWeaponRestrictions.TabStop = false;
            groupBoxWeaponRestrictions.Text = "Item restrictions";
            // 
            // checkBoxWeaponIsThrowable
            // 
            checkBoxIsThrowable.AutoSize = true;
            checkBoxIsThrowable.Location = new Point(7, 97);
            checkBoxIsThrowable.Margin = new Padding(4, 3, 4, 3);
            checkBoxIsThrowable.Name = "checkBoxWeaponIsThrowable";
            checkBoxIsThrowable.Size = new Size(104, 19);
            checkBoxIsThrowable.TabIndex = 19;
            checkBoxIsThrowable.Text = "Can be thrown";
            checkBoxIsThrowable.UseVisualStyleBackColor = true;
            checkBoxIsThrowable.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBoxWeaponIsSellable
            // 
            checkBoxIsSellable.AutoSize = true;
            checkBoxIsSellable.Location = new Point(7, 22);
            checkBoxIsSellable.Margin = new Padding(4, 3, 4, 3);
            checkBoxIsSellable.Name = "checkBoxWeaponIsSellable";
            checkBoxIsSellable.Size = new Size(88, 19);
            checkBoxIsSellable.TabIndex = 16;
            checkBoxIsSellable.Text = "Can be sold";
            checkBoxIsSellable.UseVisualStyleBackColor = true;
            checkBoxIsSellable.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBoxWeaponUsableInMenu
            // 
            checkBoxUsableInMenu.AutoSize = true;
            checkBoxUsableInMenu.Location = new Point(7, 72);
            checkBoxUsableInMenu.Margin = new Padding(4, 3, 4, 3);
            checkBoxUsableInMenu.Name = "checkBoxWeaponUsableInMenu";
            checkBoxUsableInMenu.Size = new Size(138, 19);
            checkBoxUsableInMenu.TabIndex = 18;
            checkBoxUsableInMenu.Text = "Can be used in menu";
            checkBoxUsableInMenu.UseVisualStyleBackColor = true;
            checkBoxUsableInMenu.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBoxWeaponUsableInBattle
            // 
            checkBoxUsableInBattle.AutoSize = true;
            checkBoxUsableInBattle.Location = new Point(7, 47);
            checkBoxUsableInBattle.Margin = new Padding(4, 3, 4, 3);
            checkBoxUsableInBattle.Name = "checkBoxWeaponUsableInBattle";
            checkBoxUsableInBattle.Size = new Size(137, 19);
            checkBoxUsableInBattle.TabIndex = 17;
            checkBoxUsableInBattle.Text = "Can be used in battle";
            checkBoxUsableInBattle.UseVisualStyleBackColor = true;
            checkBoxUsableInBattle.CheckedChanged += checkBox_CheckedChanged;
            // 
            // ItemRestrictionsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxWeaponRestrictions);
            DoubleBuffered = true;
            Name = "ItemRestrictionsControl";
            Size = new Size(240, 125);
            groupBoxWeaponRestrictions.ResumeLayout(false);
            groupBoxWeaponRestrictions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxWeaponRestrictions;
        private CheckBox checkBoxIsThrowable;
        private CheckBox checkBoxIsSellable;
        private CheckBox checkBoxUsableInMenu;
        private CheckBox checkBoxUsableInBattle;
    }
}
