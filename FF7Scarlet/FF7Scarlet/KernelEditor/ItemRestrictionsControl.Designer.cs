namespace FF7Scarlet.KernelEditor
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
            this.groupBoxWeaponRestrictions = new System.Windows.Forms.GroupBox();
            this.checkBoxWeaponIsThrowable = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponIsSellable = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponUsableInMenu = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponUsableInBattle = new System.Windows.Forms.CheckBox();
            this.groupBoxWeaponRestrictions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxWeaponRestrictions
            // 
            this.groupBoxWeaponRestrictions.Controls.Add(this.checkBoxWeaponIsThrowable);
            this.groupBoxWeaponRestrictions.Controls.Add(this.checkBoxWeaponIsSellable);
            this.groupBoxWeaponRestrictions.Controls.Add(this.checkBoxWeaponUsableInMenu);
            this.groupBoxWeaponRestrictions.Controls.Add(this.checkBoxWeaponUsableInBattle);
            this.groupBoxWeaponRestrictions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxWeaponRestrictions.Location = new System.Drawing.Point(0, 0);
            this.groupBoxWeaponRestrictions.Name = "groupBoxWeaponRestrictions";
            this.groupBoxWeaponRestrictions.Size = new System.Drawing.Size(240, 125);
            this.groupBoxWeaponRestrictions.TabIndex = 20;
            this.groupBoxWeaponRestrictions.TabStop = false;
            this.groupBoxWeaponRestrictions.Text = "Item restrictions";
            // 
            // checkBoxWeaponIsThrowable
            // 
            this.checkBoxWeaponIsThrowable.AutoSize = true;
            this.checkBoxWeaponIsThrowable.Location = new System.Drawing.Point(7, 97);
            this.checkBoxWeaponIsThrowable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxWeaponIsThrowable.Name = "checkBoxWeaponIsThrowable";
            this.checkBoxWeaponIsThrowable.Size = new System.Drawing.Size(104, 19);
            this.checkBoxWeaponIsThrowable.TabIndex = 19;
            this.checkBoxWeaponIsThrowable.Text = "Can be thrown";
            this.checkBoxWeaponIsThrowable.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponIsSellable
            // 
            this.checkBoxWeaponIsSellable.AutoSize = true;
            this.checkBoxWeaponIsSellable.Location = new System.Drawing.Point(7, 22);
            this.checkBoxWeaponIsSellable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxWeaponIsSellable.Name = "checkBoxWeaponIsSellable";
            this.checkBoxWeaponIsSellable.Size = new System.Drawing.Size(88, 19);
            this.checkBoxWeaponIsSellable.TabIndex = 16;
            this.checkBoxWeaponIsSellable.Text = "Can be sold";
            this.checkBoxWeaponIsSellable.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponUsableInMenu
            // 
            this.checkBoxWeaponUsableInMenu.AutoSize = true;
            this.checkBoxWeaponUsableInMenu.Location = new System.Drawing.Point(7, 72);
            this.checkBoxWeaponUsableInMenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxWeaponUsableInMenu.Name = "checkBoxWeaponUsableInMenu";
            this.checkBoxWeaponUsableInMenu.Size = new System.Drawing.Size(138, 19);
            this.checkBoxWeaponUsableInMenu.TabIndex = 18;
            this.checkBoxWeaponUsableInMenu.Text = "Can be used in menu";
            this.checkBoxWeaponUsableInMenu.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponUsableInBattle
            // 
            this.checkBoxWeaponUsableInBattle.AutoSize = true;
            this.checkBoxWeaponUsableInBattle.Location = new System.Drawing.Point(7, 47);
            this.checkBoxWeaponUsableInBattle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxWeaponUsableInBattle.Name = "checkBoxWeaponUsableInBattle";
            this.checkBoxWeaponUsableInBattle.Size = new System.Drawing.Size(137, 19);
            this.checkBoxWeaponUsableInBattle.TabIndex = 17;
            this.checkBoxWeaponUsableInBattle.Text = "Can be used in battle";
            this.checkBoxWeaponUsableInBattle.UseVisualStyleBackColor = true;
            // 
            // ItemRestrictionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxWeaponRestrictions);
            this.Name = "ItemRestrictionsControl";
            this.Size = new System.Drawing.Size(240, 125);
            this.groupBoxWeaponRestrictions.ResumeLayout(false);
            this.groupBoxWeaponRestrictions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxWeaponRestrictions;
        private CheckBox checkBoxWeaponIsThrowable;
        private CheckBox checkBoxWeaponIsSellable;
        private CheckBox checkBoxWeaponUsableInMenu;
        private CheckBox checkBoxWeaponUsableInBattle;
    }
}
