namespace FF7Scarlet
{
    partial class KernelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KernelForm));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageCommandData = new System.Windows.Forms.TabPage();
            this.textBoxCommandDescription = new System.Windows.Forms.TextBox();
            this.labelCommandDescription = new System.Windows.Forms.Label();
            this.textBoxCommandName = new System.Windows.Forms.TextBox();
            this.labelCommandName = new System.Windows.Forms.Label();
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.tabPageAttackData = new System.Windows.Forms.TabPage();
            this.textBoxSummonText = new System.Windows.Forms.TextBox();
            this.labelSummonText = new System.Windows.Forms.Label();
            this.textBoxAttackDescription = new System.Windows.Forms.TextBox();
            this.labelAttackDescription = new System.Windows.Forms.Label();
            this.textBoxAttackName = new System.Windows.Forms.TextBox();
            this.labelAttackName = new System.Windows.Forms.Label();
            this.listBoxAttacks = new System.Windows.Forms.ListBox();
            this.tabPageBattleData = new System.Windows.Forms.TabPage();
            this.tabPageInitData = new System.Windows.Forms.TabPage();
            this.tabPageItemData = new System.Windows.Forms.TabPage();
            this.damageCalculationControlItem = new FF7Scarlet.DamageCalculationControl();
            this.comboBoxItemAttackEffectID = new System.Windows.Forms.ComboBox();
            this.labelItemAttackEffectID = new System.Windows.Forms.Label();
            this.comboBoxItemCamMovementID = new System.Windows.Forms.ComboBox();
            this.labelItemCamMovementID = new System.Windows.Forms.Label();
            this.groupBoxItemTargetFlags = new System.Windows.Forms.GroupBox();
            this.checkBoxItemRandomTarget = new System.Windows.Forms.CheckBox();
            this.checkBoxItemAllRows = new System.Windows.Forms.CheckBox();
            this.checkBoxItemShortRange = new System.Windows.Forms.CheckBox();
            this.checkBoxItemOneRowOnly = new System.Windows.Forms.CheckBox();
            this.checkBoxItemSingleMultiToggle = new System.Windows.Forms.CheckBox();
            this.checkBoxItemMultipleTargetDefault = new System.Windows.Forms.CheckBox();
            this.checkBoxItemStartOnEnemies = new System.Windows.Forms.CheckBox();
            this.checkBoxItemEnableSelection = new System.Windows.Forms.CheckBox();
            this.groupBoxItemRestrictions = new System.Windows.Forms.GroupBox();
            this.checkBoxItemIsSellable = new System.Windows.Forms.CheckBox();
            this.checkBoxItemUsableInMenu = new System.Windows.Forms.CheckBox();
            this.checkBoxItemUsableInBattle = new System.Windows.Forms.CheckBox();
            this.textBoxItemDescription = new System.Windows.Forms.TextBox();
            this.labelItemDescription = new System.Windows.Forms.Label();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.labelItemName = new System.Windows.Forms.Label();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.tabPageWeaponData = new System.Windows.Forms.TabPage();
            this.damageCalculationControlWeapon = new FF7Scarlet.DamageCalculationControl();
            this.groupBoxWeaponTargetFlags = new System.Windows.Forms.GroupBox();
            this.checkBoxWeaponRandomTarget = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponAllRows = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponShortRange = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponOneRowOnly = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponSingleMultiToggle = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponMultipleTargetDefault = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponStartOnEnemies = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponEnableSelection = new System.Windows.Forms.CheckBox();
            this.groupBoxWeaponMateriaSlots = new System.Windows.Forms.GroupBox();
            this.labelWeaponMateriaGrowth = new System.Windows.Forms.Label();
            this.materiaSlotSelectorWeapon = new FF7Scarlet.MateriaSlotSelectorControl();
            this.comboBoxWeaponMateriaGrowth = new System.Windows.Forms.ComboBox();
            this.groupBoxWeaponRestrictions = new System.Windows.Forms.GroupBox();
            this.checkBoxWeaponIsThrowable = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponIsSellable = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponUsableInMenu = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponUsableInBattle = new System.Windows.Forms.CheckBox();
            this.groupBoxWeaponEquipable = new System.Windows.Forms.GroupBox();
            this.checkBoxWeaponSephiroth = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponYCloud = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponCid = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponVincent = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponCaitSith = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponYuffie = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponRed = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponAerith = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponTifa = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponBarret = new System.Windows.Forms.CheckBox();
            this.checkBoxWeaponCloud = new System.Windows.Forms.CheckBox();
            this.textBoxWeaponDescription = new System.Windows.Forms.TextBox();
            this.labelWeaponDescription = new System.Windows.Forms.Label();
            this.textBoxWeaponName = new System.Windows.Forms.TextBox();
            this.labelWeaponName = new System.Windows.Forms.Label();
            this.listBoxWeapons = new System.Windows.Forms.ListBox();
            this.tabPageArmorData = new System.Windows.Forms.TabPage();
            this.groupBoxArmorMateriaSlots = new System.Windows.Forms.GroupBox();
            this.labelArmorMateriaGrowth = new System.Windows.Forms.Label();
            this.materiaSlotSelectorArmor = new FF7Scarlet.MateriaSlotSelectorControl();
            this.comboBoxArmorMateriaGrowth = new System.Windows.Forms.ComboBox();
            this.groupBoxArmorRestrictions = new System.Windows.Forms.GroupBox();
            this.checkBoxArmorIsSellable = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorUsableInMenu = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorUsableInBattle = new System.Windows.Forms.CheckBox();
            this.groupBoxArmorEquipable = new System.Windows.Forms.GroupBox();
            this.checkBoxArmorSephiroth = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorYCloud = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorCid = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorVincent = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorCaitSith = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorYuffie = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorRed = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorAerith = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorTifa = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorBarret = new System.Windows.Forms.CheckBox();
            this.checkBoxArmorCloud = new System.Windows.Forms.CheckBox();
            this.textBoxArmorDescription = new System.Windows.Forms.TextBox();
            this.labelArmorDescription = new System.Windows.Forms.Label();
            this.textBoxArmorName = new System.Windows.Forms.TextBox();
            this.labelArmorName = new System.Windows.Forms.Label();
            this.listBoxArmor = new System.Windows.Forms.ListBox();
            this.tabPageAccessoryData = new System.Windows.Forms.TabPage();
            this.groupBoxAccessoryRestrictions = new System.Windows.Forms.GroupBox();
            this.checkBoxAccessoryIsSellable = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryUsableInMenu = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryUsableInBattle = new System.Windows.Forms.CheckBox();
            this.groupBoxAccessoryEquipable = new System.Windows.Forms.GroupBox();
            this.checkBoxAccessorySephiroth = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryYCloud = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryCid = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryVincent = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryCaitSith = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryYuffie = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryRed = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryAerith = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryTifa = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryBarret = new System.Windows.Forms.CheckBox();
            this.checkBoxAccessoryCloud = new System.Windows.Forms.CheckBox();
            this.textBoxAccessoryDescription = new System.Windows.Forms.TextBox();
            this.labelAccessoryDescription = new System.Windows.Forms.Label();
            this.textBoxAccessoryName = new System.Windows.Forms.TextBox();
            this.labelAccessoryName = new System.Windows.Forms.Label();
            this.listBoxAccessories = new System.Windows.Forms.ListBox();
            this.tabPageMateriaData = new System.Windows.Forms.TabPage();
            this.comboBoxMateriaElement = new System.Windows.Forms.ComboBox();
            this.labelMateriaElement = new System.Windows.Forms.Label();
            this.comboBoxMateriaType = new System.Windows.Forms.ComboBox();
            this.labelMateriaType = new System.Windows.Forms.Label();
            this.textBoxMateriaDescription = new System.Windows.Forms.TextBox();
            this.labelMateriaDescription = new System.Windows.Forms.Label();
            this.textBoxMateriaName = new System.Windows.Forms.TextBox();
            this.labelMateriaName = new System.Windows.Forms.Label();
            this.listBoxMateria = new System.Windows.Forms.ListBox();
            this.tabPageKeyItemText = new System.Windows.Forms.TabPage();
            this.textBoxKeyItemDescription = new System.Windows.Forms.TextBox();
            this.labelKeyItemDescription = new System.Windows.Forms.Label();
            this.textBoxKeyItemName = new System.Windows.Forms.TextBox();
            this.labelKeyItemName = new System.Windows.Forms.Label();
            this.listBoxKeyItems = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.tabControlMain.SuspendLayout();
            this.tabPageCommandData.SuspendLayout();
            this.tabPageAttackData.SuspendLayout();
            this.tabPageItemData.SuspendLayout();
            this.groupBoxItemTargetFlags.SuspendLayout();
            this.groupBoxItemRestrictions.SuspendLayout();
            this.tabPageWeaponData.SuspendLayout();
            this.groupBoxWeaponTargetFlags.SuspendLayout();
            this.groupBoxWeaponMateriaSlots.SuspendLayout();
            this.groupBoxWeaponRestrictions.SuspendLayout();
            this.groupBoxWeaponEquipable.SuspendLayout();
            this.tabPageArmorData.SuspendLayout();
            this.groupBoxArmorMateriaSlots.SuspendLayout();
            this.groupBoxArmorRestrictions.SuspendLayout();
            this.groupBoxArmorEquipable.SuspendLayout();
            this.tabPageAccessoryData.SuspendLayout();
            this.groupBoxAccessoryRestrictions.SuspendLayout();
            this.groupBoxAccessoryEquipable.SuspendLayout();
            this.tabPageMateriaData.SuspendLayout();
            this.tabPageKeyItemText.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageCommandData);
            this.tabControlMain.Controls.Add(this.tabPageAttackData);
            this.tabControlMain.Controls.Add(this.tabPageBattleData);
            this.tabControlMain.Controls.Add(this.tabPageInitData);
            this.tabControlMain.Controls.Add(this.tabPageItemData);
            this.tabControlMain.Controls.Add(this.tabPageWeaponData);
            this.tabControlMain.Controls.Add(this.tabPageArmorData);
            this.tabControlMain.Controls.Add(this.tabPageAccessoryData);
            this.tabControlMain.Controls.Add(this.tabPageMateriaData);
            this.tabControlMain.Controls.Add(this.tabPageKeyItemText);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(784, 561);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageCommandData
            // 
            this.tabPageCommandData.Controls.Add(this.textBoxCommandDescription);
            this.tabPageCommandData.Controls.Add(this.labelCommandDescription);
            this.tabPageCommandData.Controls.Add(this.textBoxCommandName);
            this.tabPageCommandData.Controls.Add(this.labelCommandName);
            this.tabPageCommandData.Controls.Add(this.listBoxCommands);
            this.tabPageCommandData.Location = new System.Drawing.Point(4, 24);
            this.tabPageCommandData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageCommandData.Name = "tabPageCommandData";
            this.tabPageCommandData.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageCommandData.Size = new System.Drawing.Size(776, 533);
            this.tabPageCommandData.TabIndex = 0;
            this.tabPageCommandData.Text = "Command";
            this.tabPageCommandData.UseVisualStyleBackColor = true;
            // 
            // textBoxCommandDescription
            // 
            this.textBoxCommandDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommandDescription.Location = new System.Drawing.Point(191, 75);
            this.textBoxCommandDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxCommandDescription.Name = "textBoxCommandDescription";
            this.textBoxCommandDescription.Size = new System.Drawing.Size(573, 23);
            this.textBoxCommandDescription.TabIndex = 16;
            // 
            // labelCommandDescription
            // 
            this.labelCommandDescription.AutoSize = true;
            this.labelCommandDescription.Location = new System.Drawing.Point(191, 57);
            this.labelCommandDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCommandDescription.Name = "labelCommandDescription";
            this.labelCommandDescription.Size = new System.Drawing.Size(70, 15);
            this.labelCommandDescription.TabIndex = 15;
            this.labelCommandDescription.Text = "Description:";
            // 
            // textBoxCommandName
            // 
            this.textBoxCommandName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommandName.Location = new System.Drawing.Point(191, 31);
            this.textBoxCommandName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxCommandName.Name = "textBoxCommandName";
            this.textBoxCommandName.Size = new System.Drawing.Size(226, 23);
            this.textBoxCommandName.TabIndex = 14;
            // 
            // labelCommandName
            // 
            this.labelCommandName.AutoSize = true;
            this.labelCommandName.Location = new System.Drawing.Point(191, 13);
            this.labelCommandName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCommandName.Name = "labelCommandName";
            this.labelCommandName.Size = new System.Drawing.Size(42, 15);
            this.labelCommandName.TabIndex = 13;
            this.labelCommandName.Text = "Name:";
            // 
            // listBoxCommands
            // 
            this.listBoxCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxCommands.FormattingEnabled = true;
            this.listBoxCommands.ItemHeight = 15;
            this.listBoxCommands.Location = new System.Drawing.Point(9, 13);
            this.listBoxCommands.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(174, 454);
            this.listBoxCommands.TabIndex = 3;
            this.listBoxCommands.SelectedIndexChanged += new System.EventHandler(this.listBoxCommands_SelectedIndexChanged);
            // 
            // tabPageAttackData
            // 
            this.tabPageAttackData.Controls.Add(this.textBoxSummonText);
            this.tabPageAttackData.Controls.Add(this.labelSummonText);
            this.tabPageAttackData.Controls.Add(this.textBoxAttackDescription);
            this.tabPageAttackData.Controls.Add(this.labelAttackDescription);
            this.tabPageAttackData.Controls.Add(this.textBoxAttackName);
            this.tabPageAttackData.Controls.Add(this.labelAttackName);
            this.tabPageAttackData.Controls.Add(this.listBoxAttacks);
            this.tabPageAttackData.Location = new System.Drawing.Point(4, 24);
            this.tabPageAttackData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageAttackData.Name = "tabPageAttackData";
            this.tabPageAttackData.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageAttackData.Size = new System.Drawing.Size(776, 533);
            this.tabPageAttackData.TabIndex = 1;
            this.tabPageAttackData.Text = "Magic/Summons";
            this.tabPageAttackData.UseVisualStyleBackColor = true;
            // 
            // textBoxSummonText
            // 
            this.textBoxSummonText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSummonText.Enabled = false;
            this.textBoxSummonText.Location = new System.Drawing.Point(425, 31);
            this.textBoxSummonText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSummonText.Name = "textBoxSummonText";
            this.textBoxSummonText.Size = new System.Drawing.Size(339, 23);
            this.textBoxSummonText.TabIndex = 6;
            // 
            // labelSummonText
            // 
            this.labelSummonText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSummonText.AutoSize = true;
            this.labelSummonText.Location = new System.Drawing.Point(425, 13);
            this.labelSummonText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSummonText.Name = "labelSummonText";
            this.labelSummonText.Size = new System.Drawing.Size(127, 15);
            this.labelSummonText.TabIndex = 5;
            this.labelSummonText.Text = "Summon attack name:";
            // 
            // textBoxAttackDescription
            // 
            this.textBoxAttackDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAttackDescription.Location = new System.Drawing.Point(191, 75);
            this.textBoxAttackDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAttackDescription.Name = "textBoxAttackDescription";
            this.textBoxAttackDescription.Size = new System.Drawing.Size(573, 23);
            this.textBoxAttackDescription.TabIndex = 4;
            // 
            // labelAttackDescription
            // 
            this.labelAttackDescription.AutoSize = true;
            this.labelAttackDescription.Location = new System.Drawing.Point(191, 57);
            this.labelAttackDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAttackDescription.Name = "labelAttackDescription";
            this.labelAttackDescription.Size = new System.Drawing.Size(70, 15);
            this.labelAttackDescription.TabIndex = 3;
            this.labelAttackDescription.Text = "Description:";
            // 
            // textBoxAttackName
            // 
            this.textBoxAttackName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAttackName.Location = new System.Drawing.Point(191, 31);
            this.textBoxAttackName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAttackName.Name = "textBoxAttackName";
            this.textBoxAttackName.Size = new System.Drawing.Size(226, 23);
            this.textBoxAttackName.TabIndex = 2;
            // 
            // labelAttackName
            // 
            this.labelAttackName.AutoSize = true;
            this.labelAttackName.Location = new System.Drawing.Point(191, 13);
            this.labelAttackName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAttackName.Name = "labelAttackName";
            this.labelAttackName.Size = new System.Drawing.Size(42, 15);
            this.labelAttackName.TabIndex = 1;
            this.labelAttackName.Text = "Name:";
            // 
            // listBoxAttacks
            // 
            this.listBoxAttacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxAttacks.FormattingEnabled = true;
            this.listBoxAttacks.ItemHeight = 15;
            this.listBoxAttacks.Location = new System.Drawing.Point(9, 13);
            this.listBoxAttacks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxAttacks.Name = "listBoxAttacks";
            this.listBoxAttacks.Size = new System.Drawing.Size(174, 454);
            this.listBoxAttacks.TabIndex = 0;
            this.listBoxAttacks.SelectedIndexChanged += new System.EventHandler(this.listBoxAttacks_SelectedIndexChanged);
            // 
            // tabPageBattleData
            // 
            this.tabPageBattleData.Location = new System.Drawing.Point(4, 24);
            this.tabPageBattleData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageBattleData.Name = "tabPageBattleData";
            this.tabPageBattleData.Size = new System.Drawing.Size(776, 533);
            this.tabPageBattleData.TabIndex = 2;
            this.tabPageBattleData.Text = "Battle/Growth";
            this.tabPageBattleData.UseVisualStyleBackColor = true;
            // 
            // tabPageInitData
            // 
            this.tabPageInitData.Location = new System.Drawing.Point(4, 24);
            this.tabPageInitData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageInitData.Name = "tabPageInitData";
            this.tabPageInitData.Size = new System.Drawing.Size(776, 533);
            this.tabPageInitData.TabIndex = 3;
            this.tabPageInitData.Text = "Initial Data";
            this.tabPageInitData.UseVisualStyleBackColor = true;
            // 
            // tabPageItemData
            // 
            this.tabPageItemData.Controls.Add(this.damageCalculationControlItem);
            this.tabPageItemData.Controls.Add(this.comboBoxItemAttackEffectID);
            this.tabPageItemData.Controls.Add(this.labelItemAttackEffectID);
            this.tabPageItemData.Controls.Add(this.comboBoxItemCamMovementID);
            this.tabPageItemData.Controls.Add(this.labelItemCamMovementID);
            this.tabPageItemData.Controls.Add(this.groupBoxItemTargetFlags);
            this.tabPageItemData.Controls.Add(this.groupBoxItemRestrictions);
            this.tabPageItemData.Controls.Add(this.textBoxItemDescription);
            this.tabPageItemData.Controls.Add(this.labelItemDescription);
            this.tabPageItemData.Controls.Add(this.textBoxItemName);
            this.tabPageItemData.Controls.Add(this.labelItemName);
            this.tabPageItemData.Controls.Add(this.listBoxItems);
            this.tabPageItemData.Location = new System.Drawing.Point(4, 24);
            this.tabPageItemData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageItemData.Name = "tabPageItemData";
            this.tabPageItemData.Size = new System.Drawing.Size(776, 533);
            this.tabPageItemData.TabIndex = 9;
            this.tabPageItemData.Text = "Items";
            this.tabPageItemData.UseVisualStyleBackColor = true;
            // 
            // damageCalculationControlItem
            // 
            this.damageCalculationControlItem.AccuracyCalculation = FF7Scarlet.AccuracyCalculation.NoMiss1;
            this.damageCalculationControlItem.ActualValue = ((byte)(0));
            this.damageCalculationControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.damageCalculationControlItem.AttackPower = ((byte)(0));
            this.damageCalculationControlItem.CanCrit = false;
            this.damageCalculationControlItem.DamageType = FF7Scarlet.DamageType.Physical;
            this.damageCalculationControlItem.Location = new System.Drawing.Point(191, 202);
            this.damageCalculationControlItem.Name = "damageCalculationControlItem";
            this.damageCalculationControlItem.Size = new System.Drawing.Size(576, 150);
            this.damageCalculationControlItem.TabIndex = 29;
            // 
            // comboBoxItemAttackEffectID
            // 
            this.comboBoxItemAttackEffectID.FormattingEnabled = true;
            this.comboBoxItemAttackEffectID.Location = new System.Drawing.Point(326, 119);
            this.comboBoxItemAttackEffectID.Name = "comboBoxItemAttackEffectID";
            this.comboBoxItemAttackEffectID.Size = new System.Drawing.Size(126, 23);
            this.comboBoxItemAttackEffectID.TabIndex = 28;
            // 
            // labelItemAttackEffectID
            // 
            this.labelItemAttackEffectID.AutoSize = true;
            this.labelItemAttackEffectID.Location = new System.Drawing.Point(326, 101);
            this.labelItemAttackEffectID.Name = "labelItemAttackEffectID";
            this.labelItemAttackEffectID.Size = new System.Drawing.Size(91, 15);
            this.labelItemAttackEffectID.TabIndex = 27;
            this.labelItemAttackEffectID.Text = "Attack effect ID:";
            // 
            // comboBoxItemCamMovementID
            // 
            this.comboBoxItemCamMovementID.FormattingEnabled = true;
            this.comboBoxItemCamMovementID.Location = new System.Drawing.Point(191, 119);
            this.comboBoxItemCamMovementID.Name = "comboBoxItemCamMovementID";
            this.comboBoxItemCamMovementID.Size = new System.Drawing.Size(126, 23);
            this.comboBoxItemCamMovementID.TabIndex = 26;
            // 
            // labelItemCamMovementID
            // 
            this.labelItemCamMovementID.AutoSize = true;
            this.labelItemCamMovementID.Location = new System.Drawing.Point(191, 101);
            this.labelItemCamMovementID.Name = "labelItemCamMovementID";
            this.labelItemCamMovementID.Size = new System.Drawing.Size(126, 15);
            this.labelItemCamMovementID.TabIndex = 25;
            this.labelItemCamMovementID.Text = "Camera movement ID:";
            // 
            // groupBoxItemTargetFlags
            // 
            this.groupBoxItemTargetFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxItemTargetFlags.Controls.Add(this.checkBoxItemRandomTarget);
            this.groupBoxItemTargetFlags.Controls.Add(this.checkBoxItemAllRows);
            this.groupBoxItemTargetFlags.Controls.Add(this.checkBoxItemShortRange);
            this.groupBoxItemTargetFlags.Controls.Add(this.checkBoxItemOneRowOnly);
            this.groupBoxItemTargetFlags.Controls.Add(this.checkBoxItemSingleMultiToggle);
            this.groupBoxItemTargetFlags.Controls.Add(this.checkBoxItemMultipleTargetDefault);
            this.groupBoxItemTargetFlags.Controls.Add(this.checkBoxItemStartOnEnemies);
            this.groupBoxItemTargetFlags.Controls.Add(this.checkBoxItemEnableSelection);
            this.groupBoxItemTargetFlags.Location = new System.Drawing.Point(191, 358);
            this.groupBoxItemTargetFlags.Name = "groupBoxItemTargetFlags";
            this.groupBoxItemTargetFlags.Size = new System.Drawing.Size(339, 124);
            this.groupBoxItemTargetFlags.TabIndex = 24;
            this.groupBoxItemTargetFlags.TabStop = false;
            this.groupBoxItemTargetFlags.Text = "Target flags";
            // 
            // checkBoxItemRandomTarget
            // 
            this.checkBoxItemRandomTarget.AutoSize = true;
            this.checkBoxItemRandomTarget.Location = new System.Drawing.Point(201, 97);
            this.checkBoxItemRandomTarget.Name = "checkBoxItemRandomTarget";
            this.checkBoxItemRandomTarget.Size = new System.Drawing.Size(105, 19);
            this.checkBoxItemRandomTarget.TabIndex = 7;
            this.checkBoxItemRandomTarget.Text = "Random target";
            this.checkBoxItemRandomTarget.UseVisualStyleBackColor = true;
            // 
            // checkBoxItemAllRows
            // 
            this.checkBoxItemAllRows.AutoSize = true;
            this.checkBoxItemAllRows.Location = new System.Drawing.Point(201, 72);
            this.checkBoxItemAllRows.Name = "checkBoxItemAllRows";
            this.checkBoxItemAllRows.Size = new System.Drawing.Size(68, 19);
            this.checkBoxItemAllRows.TabIndex = 6;
            this.checkBoxItemAllRows.Text = "All rows";
            this.checkBoxItemAllRows.UseVisualStyleBackColor = true;
            // 
            // checkBoxItemShortRange
            // 
            this.checkBoxItemShortRange.AutoSize = true;
            this.checkBoxItemShortRange.Location = new System.Drawing.Point(201, 47);
            this.checkBoxItemShortRange.Name = "checkBoxItemShortRange";
            this.checkBoxItemShortRange.Size = new System.Drawing.Size(87, 19);
            this.checkBoxItemShortRange.TabIndex = 5;
            this.checkBoxItemShortRange.Text = "Short range";
            this.checkBoxItemShortRange.UseVisualStyleBackColor = true;
            // 
            // checkBoxItemOneRowOnly
            // 
            this.checkBoxItemOneRowOnly.AutoSize = true;
            this.checkBoxItemOneRowOnly.Location = new System.Drawing.Point(201, 22);
            this.checkBoxItemOneRowOnly.Name = "checkBoxItemOneRowOnly";
            this.checkBoxItemOneRowOnly.Size = new System.Drawing.Size(97, 19);
            this.checkBoxItemOneRowOnly.TabIndex = 4;
            this.checkBoxItemOneRowOnly.Text = "One row only";
            this.checkBoxItemOneRowOnly.UseVisualStyleBackColor = true;
            // 
            // checkBoxItemSingleMultiToggle
            // 
            this.checkBoxItemSingleMultiToggle.AutoSize = true;
            this.checkBoxItemSingleMultiToggle.Location = new System.Drawing.Point(6, 97);
            this.checkBoxItemSingleMultiToggle.Name = "checkBoxItemSingleMultiToggle";
            this.checkBoxItemSingleMultiToggle.Size = new System.Drawing.Size(183, 19);
            this.checkBoxItemSingleMultiToggle.TabIndex = 3;
            this.checkBoxItemSingleMultiToggle.Text = "Toggle single/multiple targets";
            this.checkBoxItemSingleMultiToggle.UseVisualStyleBackColor = true;
            // 
            // checkBoxItemMultipleTargetDefault
            // 
            this.checkBoxItemMultipleTargetDefault.AutoSize = true;
            this.checkBoxItemMultipleTargetDefault.Location = new System.Drawing.Point(6, 72);
            this.checkBoxItemMultipleTargetDefault.Name = "checkBoxItemMultipleTargetDefault";
            this.checkBoxItemMultipleTargetDefault.Size = new System.Drawing.Size(160, 19);
            this.checkBoxItemMultipleTargetDefault.TabIndex = 2;
            this.checkBoxItemMultipleTargetDefault.Text = "Multiple target by default";
            this.checkBoxItemMultipleTargetDefault.UseVisualStyleBackColor = true;
            // 
            // checkBoxItemStartOnEnemies
            // 
            this.checkBoxItemStartOnEnemies.AutoSize = true;
            this.checkBoxItemStartOnEnemies.Location = new System.Drawing.Point(6, 47);
            this.checkBoxItemStartOnEnemies.Name = "checkBoxItemStartOnEnemies";
            this.checkBoxItemStartOnEnemies.Size = new System.Drawing.Size(114, 19);
            this.checkBoxItemStartOnEnemies.TabIndex = 1;
            this.checkBoxItemStartOnEnemies.Text = "Start on enemies";
            this.checkBoxItemStartOnEnemies.UseVisualStyleBackColor = true;
            // 
            // checkBoxItemEnableSelection
            // 
            this.checkBoxItemEnableSelection.AutoSize = true;
            this.checkBoxItemEnableSelection.Location = new System.Drawing.Point(6, 22);
            this.checkBoxItemEnableSelection.Name = "checkBoxItemEnableSelection";
            this.checkBoxItemEnableSelection.Size = new System.Drawing.Size(111, 19);
            this.checkBoxItemEnableSelection.TabIndex = 0;
            this.checkBoxItemEnableSelection.Text = "Enable selection";
            this.checkBoxItemEnableSelection.UseVisualStyleBackColor = true;
            // 
            // groupBoxItemRestrictions
            // 
            this.groupBoxItemRestrictions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxItemRestrictions.Controls.Add(this.checkBoxItemIsSellable);
            this.groupBoxItemRestrictions.Controls.Add(this.checkBoxItemUsableInMenu);
            this.groupBoxItemRestrictions.Controls.Add(this.checkBoxItemUsableInBattle);
            this.groupBoxItemRestrictions.Location = new System.Drawing.Point(536, 358);
            this.groupBoxItemRestrictions.Name = "groupBoxItemRestrictions";
            this.groupBoxItemRestrictions.Size = new System.Drawing.Size(232, 124);
            this.groupBoxItemRestrictions.TabIndex = 23;
            this.groupBoxItemRestrictions.TabStop = false;
            this.groupBoxItemRestrictions.Text = "Item restrictions";
            // 
            // checkBoxItemIsSellable
            // 
            this.checkBoxItemIsSellable.AutoSize = true;
            this.checkBoxItemIsSellable.Location = new System.Drawing.Point(7, 22);
            this.checkBoxItemIsSellable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxItemIsSellable.Name = "checkBoxItemIsSellable";
            this.checkBoxItemIsSellable.Size = new System.Drawing.Size(88, 19);
            this.checkBoxItemIsSellable.TabIndex = 13;
            this.checkBoxItemIsSellable.Text = "Can be sold";
            this.checkBoxItemIsSellable.UseVisualStyleBackColor = true;
            // 
            // checkBoxItemUsableInMenu
            // 
            this.checkBoxItemUsableInMenu.AutoSize = true;
            this.checkBoxItemUsableInMenu.Location = new System.Drawing.Point(7, 72);
            this.checkBoxItemUsableInMenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxItemUsableInMenu.Name = "checkBoxItemUsableInMenu";
            this.checkBoxItemUsableInMenu.Size = new System.Drawing.Size(138, 19);
            this.checkBoxItemUsableInMenu.TabIndex = 15;
            this.checkBoxItemUsableInMenu.Text = "Can be used in menu";
            this.checkBoxItemUsableInMenu.UseVisualStyleBackColor = true;
            // 
            // checkBoxItemUsableInBattle
            // 
            this.checkBoxItemUsableInBattle.AutoSize = true;
            this.checkBoxItemUsableInBattle.Location = new System.Drawing.Point(7, 47);
            this.checkBoxItemUsableInBattle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxItemUsableInBattle.Name = "checkBoxItemUsableInBattle";
            this.checkBoxItemUsableInBattle.Size = new System.Drawing.Size(137, 19);
            this.checkBoxItemUsableInBattle.TabIndex = 14;
            this.checkBoxItemUsableInBattle.Text = "Can be used in battle";
            this.checkBoxItemUsableInBattle.UseVisualStyleBackColor = true;
            // 
            // textBoxItemDescription
            // 
            this.textBoxItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemDescription.Location = new System.Drawing.Point(191, 75);
            this.textBoxItemDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxItemDescription.Name = "textBoxItemDescription";
            this.textBoxItemDescription.Size = new System.Drawing.Size(576, 23);
            this.textBoxItemDescription.TabIndex = 12;
            // 
            // labelItemDescription
            // 
            this.labelItemDescription.AutoSize = true;
            this.labelItemDescription.Location = new System.Drawing.Point(191, 57);
            this.labelItemDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItemDescription.Name = "labelItemDescription";
            this.labelItemDescription.Size = new System.Drawing.Size(70, 15);
            this.labelItemDescription.TabIndex = 11;
            this.labelItemDescription.Text = "Description:";
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemName.Location = new System.Drawing.Point(191, 31);
            this.textBoxItemName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(226, 23);
            this.textBoxItemName.TabIndex = 10;
            // 
            // labelItemName
            // 
            this.labelItemName.AutoSize = true;
            this.labelItemName.Location = new System.Drawing.Point(191, 13);
            this.labelItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(42, 15);
            this.labelItemName.TabIndex = 9;
            this.labelItemName.Text = "Name:";
            // 
            // listBoxItems
            // 
            this.listBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.ItemHeight = 15;
            this.listBoxItems.Location = new System.Drawing.Point(9, 13);
            this.listBoxItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(174, 469);
            this.listBoxItems.TabIndex = 0;
            this.listBoxItems.SelectedIndexChanged += new System.EventHandler(this.listBoxItems_SelectedIndexChanged);
            // 
            // tabPageWeaponData
            // 
            this.tabPageWeaponData.Controls.Add(this.damageCalculationControlWeapon);
            this.tabPageWeaponData.Controls.Add(this.groupBoxWeaponTargetFlags);
            this.tabPageWeaponData.Controls.Add(this.groupBoxWeaponMateriaSlots);
            this.tabPageWeaponData.Controls.Add(this.groupBoxWeaponRestrictions);
            this.tabPageWeaponData.Controls.Add(this.groupBoxWeaponEquipable);
            this.tabPageWeaponData.Controls.Add(this.textBoxWeaponDescription);
            this.tabPageWeaponData.Controls.Add(this.labelWeaponDescription);
            this.tabPageWeaponData.Controls.Add(this.textBoxWeaponName);
            this.tabPageWeaponData.Controls.Add(this.labelWeaponName);
            this.tabPageWeaponData.Controls.Add(this.listBoxWeapons);
            this.tabPageWeaponData.Location = new System.Drawing.Point(4, 24);
            this.tabPageWeaponData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageWeaponData.Name = "tabPageWeaponData";
            this.tabPageWeaponData.Size = new System.Drawing.Size(776, 533);
            this.tabPageWeaponData.TabIndex = 4;
            this.tabPageWeaponData.Text = "Weapons";
            this.tabPageWeaponData.UseVisualStyleBackColor = true;
            // 
            // damageCalculationControlWeapon
            // 
            this.damageCalculationControlWeapon.AccuracyCalculation = FF7Scarlet.AccuracyCalculation.NoMiss1;
            this.damageCalculationControlWeapon.ActualValue = ((byte)(0));
            this.damageCalculationControlWeapon.AttackPower = ((byte)(0));
            this.damageCalculationControlWeapon.CanCrit = false;
            this.damageCalculationControlWeapon.DamageType = FF7Scarlet.DamageType.Physical;
            this.damageCalculationControlWeapon.Location = new System.Drawing.Point(190, 60);
            this.damageCalculationControlWeapon.Name = "damageCalculationControlWeapon";
            this.damageCalculationControlWeapon.Size = new System.Drawing.Size(577, 147);
            this.damageCalculationControlWeapon.TabIndex = 26;
            // 
            // groupBoxWeaponTargetFlags
            // 
            this.groupBoxWeaponTargetFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWeaponTargetFlags.Controls.Add(this.checkBoxWeaponRandomTarget);
            this.groupBoxWeaponTargetFlags.Controls.Add(this.checkBoxWeaponAllRows);
            this.groupBoxWeaponTargetFlags.Controls.Add(this.checkBoxWeaponShortRange);
            this.groupBoxWeaponTargetFlags.Controls.Add(this.checkBoxWeaponOneRowOnly);
            this.groupBoxWeaponTargetFlags.Controls.Add(this.checkBoxWeaponSingleMultiToggle);
            this.groupBoxWeaponTargetFlags.Controls.Add(this.checkBoxWeaponMultipleTargetDefault);
            this.groupBoxWeaponTargetFlags.Controls.Add(this.checkBoxWeaponStartOnEnemies);
            this.groupBoxWeaponTargetFlags.Controls.Add(this.checkBoxWeaponEnableSelection);
            this.groupBoxWeaponTargetFlags.Location = new System.Drawing.Point(428, 213);
            this.groupBoxWeaponTargetFlags.Name = "groupBoxWeaponTargetFlags";
            this.groupBoxWeaponTargetFlags.Size = new System.Drawing.Size(339, 124);
            this.groupBoxWeaponTargetFlags.TabIndex = 25;
            this.groupBoxWeaponTargetFlags.TabStop = false;
            this.groupBoxWeaponTargetFlags.Text = "Target flags";
            // 
            // checkBoxWeaponRandomTarget
            // 
            this.checkBoxWeaponRandomTarget.AutoSize = true;
            this.checkBoxWeaponRandomTarget.Location = new System.Drawing.Point(201, 97);
            this.checkBoxWeaponRandomTarget.Name = "checkBoxWeaponRandomTarget";
            this.checkBoxWeaponRandomTarget.Size = new System.Drawing.Size(105, 19);
            this.checkBoxWeaponRandomTarget.TabIndex = 7;
            this.checkBoxWeaponRandomTarget.Text = "Random target";
            this.checkBoxWeaponRandomTarget.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponAllRows
            // 
            this.checkBoxWeaponAllRows.AutoSize = true;
            this.checkBoxWeaponAllRows.Location = new System.Drawing.Point(201, 72);
            this.checkBoxWeaponAllRows.Name = "checkBoxWeaponAllRows";
            this.checkBoxWeaponAllRows.Size = new System.Drawing.Size(68, 19);
            this.checkBoxWeaponAllRows.TabIndex = 6;
            this.checkBoxWeaponAllRows.Text = "All rows";
            this.checkBoxWeaponAllRows.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponShortRange
            // 
            this.checkBoxWeaponShortRange.AutoSize = true;
            this.checkBoxWeaponShortRange.Location = new System.Drawing.Point(201, 47);
            this.checkBoxWeaponShortRange.Name = "checkBoxWeaponShortRange";
            this.checkBoxWeaponShortRange.Size = new System.Drawing.Size(87, 19);
            this.checkBoxWeaponShortRange.TabIndex = 5;
            this.checkBoxWeaponShortRange.Text = "Short range";
            this.checkBoxWeaponShortRange.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponOneRowOnly
            // 
            this.checkBoxWeaponOneRowOnly.AutoSize = true;
            this.checkBoxWeaponOneRowOnly.Location = new System.Drawing.Point(201, 22);
            this.checkBoxWeaponOneRowOnly.Name = "checkBoxWeaponOneRowOnly";
            this.checkBoxWeaponOneRowOnly.Size = new System.Drawing.Size(97, 19);
            this.checkBoxWeaponOneRowOnly.TabIndex = 4;
            this.checkBoxWeaponOneRowOnly.Text = "One row only";
            this.checkBoxWeaponOneRowOnly.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponSingleMultiToggle
            // 
            this.checkBoxWeaponSingleMultiToggle.AutoSize = true;
            this.checkBoxWeaponSingleMultiToggle.Location = new System.Drawing.Point(6, 97);
            this.checkBoxWeaponSingleMultiToggle.Name = "checkBoxWeaponSingleMultiToggle";
            this.checkBoxWeaponSingleMultiToggle.Size = new System.Drawing.Size(183, 19);
            this.checkBoxWeaponSingleMultiToggle.TabIndex = 3;
            this.checkBoxWeaponSingleMultiToggle.Text = "Toggle single/multiple targets";
            this.checkBoxWeaponSingleMultiToggle.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponMultipleTargetDefault
            // 
            this.checkBoxWeaponMultipleTargetDefault.AutoSize = true;
            this.checkBoxWeaponMultipleTargetDefault.Location = new System.Drawing.Point(6, 72);
            this.checkBoxWeaponMultipleTargetDefault.Name = "checkBoxWeaponMultipleTargetDefault";
            this.checkBoxWeaponMultipleTargetDefault.Size = new System.Drawing.Size(160, 19);
            this.checkBoxWeaponMultipleTargetDefault.TabIndex = 2;
            this.checkBoxWeaponMultipleTargetDefault.Text = "Multiple target by default";
            this.checkBoxWeaponMultipleTargetDefault.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponStartOnEnemies
            // 
            this.checkBoxWeaponStartOnEnemies.AutoSize = true;
            this.checkBoxWeaponStartOnEnemies.Location = new System.Drawing.Point(6, 47);
            this.checkBoxWeaponStartOnEnemies.Name = "checkBoxWeaponStartOnEnemies";
            this.checkBoxWeaponStartOnEnemies.Size = new System.Drawing.Size(114, 19);
            this.checkBoxWeaponStartOnEnemies.TabIndex = 1;
            this.checkBoxWeaponStartOnEnemies.Text = "Start on enemies";
            this.checkBoxWeaponStartOnEnemies.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponEnableSelection
            // 
            this.checkBoxWeaponEnableSelection.AutoSize = true;
            this.checkBoxWeaponEnableSelection.Location = new System.Drawing.Point(6, 22);
            this.checkBoxWeaponEnableSelection.Name = "checkBoxWeaponEnableSelection";
            this.checkBoxWeaponEnableSelection.Size = new System.Drawing.Size(111, 19);
            this.checkBoxWeaponEnableSelection.TabIndex = 0;
            this.checkBoxWeaponEnableSelection.Text = "Enable selection";
            this.checkBoxWeaponEnableSelection.UseVisualStyleBackColor = true;
            // 
            // groupBoxWeaponMateriaSlots
            // 
            this.groupBoxWeaponMateriaSlots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxWeaponMateriaSlots.Controls.Add(this.labelWeaponMateriaGrowth);
            this.groupBoxWeaponMateriaSlots.Controls.Add(this.materiaSlotSelectorWeapon);
            this.groupBoxWeaponMateriaSlots.Controls.Add(this.comboBoxWeaponMateriaGrowth);
            this.groupBoxWeaponMateriaSlots.Location = new System.Drawing.Point(190, 213);
            this.groupBoxWeaponMateriaSlots.Name = "groupBoxWeaponMateriaSlots";
            this.groupBoxWeaponMateriaSlots.Size = new System.Drawing.Size(233, 124);
            this.groupBoxWeaponMateriaSlots.TabIndex = 20;
            this.groupBoxWeaponMateriaSlots.TabStop = false;
            this.groupBoxWeaponMateriaSlots.Text = "Materia slots";
            // 
            // labelWeaponMateriaGrowth
            // 
            this.labelWeaponMateriaGrowth.AutoSize = true;
            this.labelWeaponMateriaGrowth.Location = new System.Drawing.Point(6, 60);
            this.labelWeaponMateriaGrowth.Name = "labelWeaponMateriaGrowth";
            this.labelWeaponMateriaGrowth.Size = new System.Drawing.Size(49, 15);
            this.labelWeaponMateriaGrowth.TabIndex = 1;
            this.labelWeaponMateriaGrowth.Text = "Growth:";
            // 
            // materiaSlotSelectorWeapon
            // 
            this.materiaSlotSelectorWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materiaSlotSelectorWeapon.BackColor = System.Drawing.Color.LightSlateGray;
            this.materiaSlotSelectorWeapon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materiaSlotSelectorWeapon.GrowthRate = Shojy.FF7.Elena.Equipment.GrowthRate.None;
            this.materiaSlotSelectorWeapon.Location = new System.Drawing.Point(6, 22);
            this.materiaSlotSelectorWeapon.Name = "materiaSlotSelectorWeapon";
            this.materiaSlotSelectorWeapon.Size = new System.Drawing.Size(221, 35);
            this.materiaSlotSelectorWeapon.TabIndex = 0;
            // 
            // comboBoxWeaponMateriaGrowth
            // 
            this.comboBoxWeaponMateriaGrowth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWeaponMateriaGrowth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeaponMateriaGrowth.FormattingEnabled = true;
            this.comboBoxWeaponMateriaGrowth.Location = new System.Drawing.Point(6, 78);
            this.comboBoxWeaponMateriaGrowth.Name = "comboBoxWeaponMateriaGrowth";
            this.comboBoxWeaponMateriaGrowth.Size = new System.Drawing.Size(221, 23);
            this.comboBoxWeaponMateriaGrowth.TabIndex = 2;
            this.comboBoxWeaponMateriaGrowth.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeaponMateriaGrowth_SelectedIndexChanged);
            // 
            // groupBoxWeaponRestrictions
            // 
            this.groupBoxWeaponRestrictions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWeaponRestrictions.Controls.Add(this.checkBoxWeaponIsThrowable);
            this.groupBoxWeaponRestrictions.Controls.Add(this.checkBoxWeaponIsSellable);
            this.groupBoxWeaponRestrictions.Controls.Add(this.checkBoxWeaponUsableInMenu);
            this.groupBoxWeaponRestrictions.Controls.Add(this.checkBoxWeaponUsableInBattle);
            this.groupBoxWeaponRestrictions.Location = new System.Drawing.Point(532, 343);
            this.groupBoxWeaponRestrictions.Name = "groupBoxWeaponRestrictions";
            this.groupBoxWeaponRestrictions.Size = new System.Drawing.Size(235, 124);
            this.groupBoxWeaponRestrictions.TabIndex = 19;
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
            // groupBoxWeaponEquipable
            // 
            this.groupBoxWeaponEquipable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponSephiroth);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponYCloud);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponCid);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponVincent);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponCaitSith);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponYuffie);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponRed);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponAerith);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponTifa);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponBarret);
            this.groupBoxWeaponEquipable.Controls.Add(this.checkBoxWeaponCloud);
            this.groupBoxWeaponEquipable.Location = new System.Drawing.Point(191, 343);
            this.groupBoxWeaponEquipable.Name = "groupBoxWeaponEquipable";
            this.groupBoxWeaponEquipable.Size = new System.Drawing.Size(335, 124);
            this.groupBoxWeaponEquipable.TabIndex = 13;
            this.groupBoxWeaponEquipable.TabStop = false;
            this.groupBoxWeaponEquipable.Text = "Equipable by...";
            // 
            // checkBoxWeaponSephiroth
            // 
            this.checkBoxWeaponSephiroth.AutoSize = true;
            this.checkBoxWeaponSephiroth.Location = new System.Drawing.Point(188, 72);
            this.checkBoxWeaponSephiroth.Name = "checkBoxWeaponSephiroth";
            this.checkBoxWeaponSephiroth.Size = new System.Drawing.Size(77, 19);
            this.checkBoxWeaponSephiroth.TabIndex = 10;
            this.checkBoxWeaponSephiroth.Text = "Sephiroth";
            this.checkBoxWeaponSephiroth.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponYCloud
            // 
            this.checkBoxWeaponYCloud.AutoSize = true;
            this.checkBoxWeaponYCloud.Location = new System.Drawing.Point(188, 47);
            this.checkBoxWeaponYCloud.Name = "checkBoxWeaponYCloud";
            this.checkBoxWeaponYCloud.Size = new System.Drawing.Size(68, 19);
            this.checkBoxWeaponYCloud.TabIndex = 9;
            this.checkBoxWeaponYCloud.Text = "Y.Cloud";
            this.checkBoxWeaponYCloud.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponCid
            // 
            this.checkBoxWeaponCid.AutoSize = true;
            this.checkBoxWeaponCid.Location = new System.Drawing.Point(188, 22);
            this.checkBoxWeaponCid.Name = "checkBoxWeaponCid";
            this.checkBoxWeaponCid.Size = new System.Drawing.Size(44, 19);
            this.checkBoxWeaponCid.TabIndex = 8;
            this.checkBoxWeaponCid.Text = "Cid";
            this.checkBoxWeaponCid.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponVincent
            // 
            this.checkBoxWeaponVincent.AutoSize = true;
            this.checkBoxWeaponVincent.Location = new System.Drawing.Point(96, 97);
            this.checkBoxWeaponVincent.Name = "checkBoxWeaponVincent";
            this.checkBoxWeaponVincent.Size = new System.Drawing.Size(66, 19);
            this.checkBoxWeaponVincent.TabIndex = 7;
            this.checkBoxWeaponVincent.Text = "Vincent";
            this.checkBoxWeaponVincent.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponCaitSith
            // 
            this.checkBoxWeaponCaitSith.AutoSize = true;
            this.checkBoxWeaponCaitSith.Location = new System.Drawing.Point(96, 72);
            this.checkBoxWeaponCaitSith.Name = "checkBoxWeaponCaitSith";
            this.checkBoxWeaponCaitSith.Size = new System.Drawing.Size(70, 19);
            this.checkBoxWeaponCaitSith.TabIndex = 6;
            this.checkBoxWeaponCaitSith.Text = "Cait Sith";
            this.checkBoxWeaponCaitSith.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponYuffie
            // 
            this.checkBoxWeaponYuffie.AutoSize = true;
            this.checkBoxWeaponYuffie.Location = new System.Drawing.Point(96, 47);
            this.checkBoxWeaponYuffie.Name = "checkBoxWeaponYuffie";
            this.checkBoxWeaponYuffie.Size = new System.Drawing.Size(57, 19);
            this.checkBoxWeaponYuffie.TabIndex = 5;
            this.checkBoxWeaponYuffie.Text = "Yuffie";
            this.checkBoxWeaponYuffie.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponRed
            // 
            this.checkBoxWeaponRed.AutoSize = true;
            this.checkBoxWeaponRed.Location = new System.Drawing.Point(96, 22);
            this.checkBoxWeaponRed.Name = "checkBoxWeaponRed";
            this.checkBoxWeaponRed.Size = new System.Drawing.Size(65, 19);
            this.checkBoxWeaponRed.TabIndex = 4;
            this.checkBoxWeaponRed.Text = "Red XIII";
            this.checkBoxWeaponRed.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponAerith
            // 
            this.checkBoxWeaponAerith.AutoSize = true;
            this.checkBoxWeaponAerith.Location = new System.Drawing.Point(6, 97);
            this.checkBoxWeaponAerith.Name = "checkBoxWeaponAerith";
            this.checkBoxWeaponAerith.Size = new System.Drawing.Size(58, 19);
            this.checkBoxWeaponAerith.TabIndex = 3;
            this.checkBoxWeaponAerith.Text = "Aerith";
            this.checkBoxWeaponAerith.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponTifa
            // 
            this.checkBoxWeaponTifa.AutoSize = true;
            this.checkBoxWeaponTifa.Location = new System.Drawing.Point(6, 72);
            this.checkBoxWeaponTifa.Name = "checkBoxWeaponTifa";
            this.checkBoxWeaponTifa.Size = new System.Drawing.Size(45, 19);
            this.checkBoxWeaponTifa.TabIndex = 2;
            this.checkBoxWeaponTifa.Text = "Tifa";
            this.checkBoxWeaponTifa.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponBarret
            // 
            this.checkBoxWeaponBarret.AutoSize = true;
            this.checkBoxWeaponBarret.Location = new System.Drawing.Point(6, 47);
            this.checkBoxWeaponBarret.Name = "checkBoxWeaponBarret";
            this.checkBoxWeaponBarret.Size = new System.Drawing.Size(57, 19);
            this.checkBoxWeaponBarret.TabIndex = 1;
            this.checkBoxWeaponBarret.Text = "Barret";
            this.checkBoxWeaponBarret.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeaponCloud
            // 
            this.checkBoxWeaponCloud.AutoSize = true;
            this.checkBoxWeaponCloud.Location = new System.Drawing.Point(6, 22);
            this.checkBoxWeaponCloud.Name = "checkBoxWeaponCloud";
            this.checkBoxWeaponCloud.Size = new System.Drawing.Size(58, 19);
            this.checkBoxWeaponCloud.TabIndex = 0;
            this.checkBoxWeaponCloud.Text = "Cloud";
            this.checkBoxWeaponCloud.UseVisualStyleBackColor = true;
            // 
            // textBoxWeaponDescription
            // 
            this.textBoxWeaponDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWeaponDescription.Location = new System.Drawing.Point(365, 31);
            this.textBoxWeaponDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxWeaponDescription.Name = "textBoxWeaponDescription";
            this.textBoxWeaponDescription.Size = new System.Drawing.Size(402, 23);
            this.textBoxWeaponDescription.TabIndex = 12;
            // 
            // labelWeaponDescription
            // 
            this.labelWeaponDescription.AutoSize = true;
            this.labelWeaponDescription.Location = new System.Drawing.Point(365, 13);
            this.labelWeaponDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWeaponDescription.Name = "labelWeaponDescription";
            this.labelWeaponDescription.Size = new System.Drawing.Size(70, 15);
            this.labelWeaponDescription.TabIndex = 11;
            this.labelWeaponDescription.Text = "Description:";
            // 
            // textBoxWeaponName
            // 
            this.textBoxWeaponName.Location = new System.Drawing.Point(191, 31);
            this.textBoxWeaponName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxWeaponName.Name = "textBoxWeaponName";
            this.textBoxWeaponName.Size = new System.Drawing.Size(166, 23);
            this.textBoxWeaponName.TabIndex = 10;
            // 
            // labelWeaponName
            // 
            this.labelWeaponName.AutoSize = true;
            this.labelWeaponName.Location = new System.Drawing.Point(191, 13);
            this.labelWeaponName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWeaponName.Name = "labelWeaponName";
            this.labelWeaponName.Size = new System.Drawing.Size(42, 15);
            this.labelWeaponName.TabIndex = 9;
            this.labelWeaponName.Text = "Name:";
            // 
            // listBoxWeapons
            // 
            this.listBoxWeapons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxWeapons.FormattingEnabled = true;
            this.listBoxWeapons.ItemHeight = 15;
            this.listBoxWeapons.Location = new System.Drawing.Point(9, 13);
            this.listBoxWeapons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxWeapons.Name = "listBoxWeapons";
            this.listBoxWeapons.Size = new System.Drawing.Size(174, 454);
            this.listBoxWeapons.TabIndex = 1;
            this.listBoxWeapons.SelectedIndexChanged += new System.EventHandler(this.listBoxWeapons_SelectedIndexChanged);
            // 
            // tabPageArmorData
            // 
            this.tabPageArmorData.Controls.Add(this.groupBoxArmorMateriaSlots);
            this.tabPageArmorData.Controls.Add(this.groupBoxArmorRestrictions);
            this.tabPageArmorData.Controls.Add(this.groupBoxArmorEquipable);
            this.tabPageArmorData.Controls.Add(this.textBoxArmorDescription);
            this.tabPageArmorData.Controls.Add(this.labelArmorDescription);
            this.tabPageArmorData.Controls.Add(this.textBoxArmorName);
            this.tabPageArmorData.Controls.Add(this.labelArmorName);
            this.tabPageArmorData.Controls.Add(this.listBoxArmor);
            this.tabPageArmorData.Location = new System.Drawing.Point(4, 24);
            this.tabPageArmorData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageArmorData.Name = "tabPageArmorData";
            this.tabPageArmorData.Size = new System.Drawing.Size(776, 533);
            this.tabPageArmorData.TabIndex = 5;
            this.tabPageArmorData.Text = "Armor";
            this.tabPageArmorData.UseVisualStyleBackColor = true;
            // 
            // groupBoxArmorMateriaSlots
            // 
            this.groupBoxArmorMateriaSlots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxArmorMateriaSlots.Controls.Add(this.labelArmorMateriaGrowth);
            this.groupBoxArmorMateriaSlots.Controls.Add(this.materiaSlotSelectorArmor);
            this.groupBoxArmorMateriaSlots.Controls.Add(this.comboBoxArmorMateriaGrowth);
            this.groupBoxArmorMateriaSlots.Location = new System.Drawing.Point(191, 224);
            this.groupBoxArmorMateriaSlots.Name = "groupBoxArmorMateriaSlots";
            this.groupBoxArmorMateriaSlots.Size = new System.Drawing.Size(226, 108);
            this.groupBoxArmorMateriaSlots.TabIndex = 23;
            this.groupBoxArmorMateriaSlots.TabStop = false;
            this.groupBoxArmorMateriaSlots.Text = "Materia slots";
            // 
            // labelArmorMateriaGrowth
            // 
            this.labelArmorMateriaGrowth.AutoSize = true;
            this.labelArmorMateriaGrowth.Location = new System.Drawing.Point(6, 60);
            this.labelArmorMateriaGrowth.Name = "labelArmorMateriaGrowth";
            this.labelArmorMateriaGrowth.Size = new System.Drawing.Size(49, 15);
            this.labelArmorMateriaGrowth.TabIndex = 1;
            this.labelArmorMateriaGrowth.Text = "Growth:";
            // 
            // materiaSlotSelectorArmor
            // 
            this.materiaSlotSelectorArmor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materiaSlotSelectorArmor.BackColor = System.Drawing.Color.LightSlateGray;
            this.materiaSlotSelectorArmor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materiaSlotSelectorArmor.GrowthRate = Shojy.FF7.Elena.Equipment.GrowthRate.None;
            this.materiaSlotSelectorArmor.Location = new System.Drawing.Point(6, 22);
            this.materiaSlotSelectorArmor.Name = "materiaSlotSelectorArmor";
            this.materiaSlotSelectorArmor.Size = new System.Drawing.Size(214, 35);
            this.materiaSlotSelectorArmor.TabIndex = 0;
            // 
            // comboBoxArmorMateriaGrowth
            // 
            this.comboBoxArmorMateriaGrowth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxArmorMateriaGrowth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArmorMateriaGrowth.FormattingEnabled = true;
            this.comboBoxArmorMateriaGrowth.Location = new System.Drawing.Point(6, 78);
            this.comboBoxArmorMateriaGrowth.Name = "comboBoxArmorMateriaGrowth";
            this.comboBoxArmorMateriaGrowth.Size = new System.Drawing.Size(214, 23);
            this.comboBoxArmorMateriaGrowth.TabIndex = 2;
            this.comboBoxArmorMateriaGrowth.SelectedIndexChanged += new System.EventHandler(this.comboBoxArmorMateriaGrowth_SelectedIndexChanged);
            // 
            // groupBoxArmorRestrictions
            // 
            this.groupBoxArmorRestrictions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxArmorRestrictions.Controls.Add(this.checkBoxArmorIsSellable);
            this.groupBoxArmorRestrictions.Controls.Add(this.checkBoxArmorUsableInMenu);
            this.groupBoxArmorRestrictions.Controls.Add(this.checkBoxArmorUsableInBattle);
            this.groupBoxArmorRestrictions.Location = new System.Drawing.Point(532, 343);
            this.groupBoxArmorRestrictions.Name = "groupBoxArmorRestrictions";
            this.groupBoxArmorRestrictions.Size = new System.Drawing.Size(232, 124);
            this.groupBoxArmorRestrictions.TabIndex = 22;
            this.groupBoxArmorRestrictions.TabStop = false;
            this.groupBoxArmorRestrictions.Text = "Item restrictions";
            // 
            // checkBoxArmorIsSellable
            // 
            this.checkBoxArmorIsSellable.AutoSize = true;
            this.checkBoxArmorIsSellable.Location = new System.Drawing.Point(7, 22);
            this.checkBoxArmorIsSellable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxArmorIsSellable.Name = "checkBoxArmorIsSellable";
            this.checkBoxArmorIsSellable.Size = new System.Drawing.Size(88, 19);
            this.checkBoxArmorIsSellable.TabIndex = 19;
            this.checkBoxArmorIsSellable.Text = "Can be sold";
            this.checkBoxArmorIsSellable.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorUsableInMenu
            // 
            this.checkBoxArmorUsableInMenu.AutoSize = true;
            this.checkBoxArmorUsableInMenu.Location = new System.Drawing.Point(7, 72);
            this.checkBoxArmorUsableInMenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxArmorUsableInMenu.Name = "checkBoxArmorUsableInMenu";
            this.checkBoxArmorUsableInMenu.Size = new System.Drawing.Size(138, 19);
            this.checkBoxArmorUsableInMenu.TabIndex = 21;
            this.checkBoxArmorUsableInMenu.Text = "Can be used in menu";
            this.checkBoxArmorUsableInMenu.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorUsableInBattle
            // 
            this.checkBoxArmorUsableInBattle.AutoSize = true;
            this.checkBoxArmorUsableInBattle.Location = new System.Drawing.Point(7, 47);
            this.checkBoxArmorUsableInBattle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxArmorUsableInBattle.Name = "checkBoxArmorUsableInBattle";
            this.checkBoxArmorUsableInBattle.Size = new System.Drawing.Size(137, 19);
            this.checkBoxArmorUsableInBattle.TabIndex = 20;
            this.checkBoxArmorUsableInBattle.Text = "Can be used in battle";
            this.checkBoxArmorUsableInBattle.UseVisualStyleBackColor = true;
            // 
            // groupBoxArmorEquipable
            // 
            this.groupBoxArmorEquipable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorSephiroth);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorYCloud);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorCid);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorVincent);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorCaitSith);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorYuffie);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorRed);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorAerith);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorTifa);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorBarret);
            this.groupBoxArmorEquipable.Controls.Add(this.checkBoxArmorCloud);
            this.groupBoxArmorEquipable.Location = new System.Drawing.Point(191, 343);
            this.groupBoxArmorEquipable.Name = "groupBoxArmorEquipable";
            this.groupBoxArmorEquipable.Size = new System.Drawing.Size(335, 124);
            this.groupBoxArmorEquipable.TabIndex = 14;
            this.groupBoxArmorEquipable.TabStop = false;
            this.groupBoxArmorEquipable.Text = "Equipable by...";
            // 
            // checkBoxArmorSephiroth
            // 
            this.checkBoxArmorSephiroth.AutoSize = true;
            this.checkBoxArmorSephiroth.Location = new System.Drawing.Point(188, 72);
            this.checkBoxArmorSephiroth.Name = "checkBoxArmorSephiroth";
            this.checkBoxArmorSephiroth.Size = new System.Drawing.Size(77, 19);
            this.checkBoxArmorSephiroth.TabIndex = 10;
            this.checkBoxArmorSephiroth.Text = "Sephiroth";
            this.checkBoxArmorSephiroth.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorYCloud
            // 
            this.checkBoxArmorYCloud.AutoSize = true;
            this.checkBoxArmorYCloud.Location = new System.Drawing.Point(188, 47);
            this.checkBoxArmorYCloud.Name = "checkBoxArmorYCloud";
            this.checkBoxArmorYCloud.Size = new System.Drawing.Size(68, 19);
            this.checkBoxArmorYCloud.TabIndex = 9;
            this.checkBoxArmorYCloud.Text = "Y.Cloud";
            this.checkBoxArmorYCloud.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorCid
            // 
            this.checkBoxArmorCid.AutoSize = true;
            this.checkBoxArmorCid.Location = new System.Drawing.Point(188, 22);
            this.checkBoxArmorCid.Name = "checkBoxArmorCid";
            this.checkBoxArmorCid.Size = new System.Drawing.Size(44, 19);
            this.checkBoxArmorCid.TabIndex = 8;
            this.checkBoxArmorCid.Text = "Cid";
            this.checkBoxArmorCid.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorVincent
            // 
            this.checkBoxArmorVincent.AutoSize = true;
            this.checkBoxArmorVincent.Location = new System.Drawing.Point(96, 97);
            this.checkBoxArmorVincent.Name = "checkBoxArmorVincent";
            this.checkBoxArmorVincent.Size = new System.Drawing.Size(66, 19);
            this.checkBoxArmorVincent.TabIndex = 7;
            this.checkBoxArmorVincent.Text = "Vincent";
            this.checkBoxArmorVincent.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorCaitSith
            // 
            this.checkBoxArmorCaitSith.AutoSize = true;
            this.checkBoxArmorCaitSith.Location = new System.Drawing.Point(96, 72);
            this.checkBoxArmorCaitSith.Name = "checkBoxArmorCaitSith";
            this.checkBoxArmorCaitSith.Size = new System.Drawing.Size(70, 19);
            this.checkBoxArmorCaitSith.TabIndex = 6;
            this.checkBoxArmorCaitSith.Text = "Cait Sith";
            this.checkBoxArmorCaitSith.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorYuffie
            // 
            this.checkBoxArmorYuffie.AutoSize = true;
            this.checkBoxArmorYuffie.Location = new System.Drawing.Point(96, 47);
            this.checkBoxArmorYuffie.Name = "checkBoxArmorYuffie";
            this.checkBoxArmorYuffie.Size = new System.Drawing.Size(57, 19);
            this.checkBoxArmorYuffie.TabIndex = 5;
            this.checkBoxArmorYuffie.Text = "Yuffie";
            this.checkBoxArmorYuffie.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorRed
            // 
            this.checkBoxArmorRed.AutoSize = true;
            this.checkBoxArmorRed.Location = new System.Drawing.Point(96, 22);
            this.checkBoxArmorRed.Name = "checkBoxArmorRed";
            this.checkBoxArmorRed.Size = new System.Drawing.Size(65, 19);
            this.checkBoxArmorRed.TabIndex = 4;
            this.checkBoxArmorRed.Text = "Red XIII";
            this.checkBoxArmorRed.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorAerith
            // 
            this.checkBoxArmorAerith.AutoSize = true;
            this.checkBoxArmorAerith.Location = new System.Drawing.Point(6, 97);
            this.checkBoxArmorAerith.Name = "checkBoxArmorAerith";
            this.checkBoxArmorAerith.Size = new System.Drawing.Size(58, 19);
            this.checkBoxArmorAerith.TabIndex = 3;
            this.checkBoxArmorAerith.Text = "Aerith";
            this.checkBoxArmorAerith.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorTifa
            // 
            this.checkBoxArmorTifa.AutoSize = true;
            this.checkBoxArmorTifa.Location = new System.Drawing.Point(6, 72);
            this.checkBoxArmorTifa.Name = "checkBoxArmorTifa";
            this.checkBoxArmorTifa.Size = new System.Drawing.Size(45, 19);
            this.checkBoxArmorTifa.TabIndex = 2;
            this.checkBoxArmorTifa.Text = "Tifa";
            this.checkBoxArmorTifa.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorBarret
            // 
            this.checkBoxArmorBarret.AutoSize = true;
            this.checkBoxArmorBarret.Location = new System.Drawing.Point(6, 47);
            this.checkBoxArmorBarret.Name = "checkBoxArmorBarret";
            this.checkBoxArmorBarret.Size = new System.Drawing.Size(57, 19);
            this.checkBoxArmorBarret.TabIndex = 1;
            this.checkBoxArmorBarret.Text = "Barret";
            this.checkBoxArmorBarret.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmorCloud
            // 
            this.checkBoxArmorCloud.AutoSize = true;
            this.checkBoxArmorCloud.Location = new System.Drawing.Point(6, 22);
            this.checkBoxArmorCloud.Name = "checkBoxArmorCloud";
            this.checkBoxArmorCloud.Size = new System.Drawing.Size(58, 19);
            this.checkBoxArmorCloud.TabIndex = 0;
            this.checkBoxArmorCloud.Text = "Cloud";
            this.checkBoxArmorCloud.UseVisualStyleBackColor = true;
            // 
            // textBoxArmorDescription
            // 
            this.textBoxArmorDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArmorDescription.Location = new System.Drawing.Point(191, 75);
            this.textBoxArmorDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxArmorDescription.Name = "textBoxArmorDescription";
            this.textBoxArmorDescription.Size = new System.Drawing.Size(573, 23);
            this.textBoxArmorDescription.TabIndex = 12;
            // 
            // labelArmorDescription
            // 
            this.labelArmorDescription.AutoSize = true;
            this.labelArmorDescription.Location = new System.Drawing.Point(191, 57);
            this.labelArmorDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArmorDescription.Name = "labelArmorDescription";
            this.labelArmorDescription.Size = new System.Drawing.Size(70, 15);
            this.labelArmorDescription.TabIndex = 11;
            this.labelArmorDescription.Text = "Description:";
            // 
            // textBoxArmorName
            // 
            this.textBoxArmorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArmorName.Location = new System.Drawing.Point(191, 31);
            this.textBoxArmorName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxArmorName.Name = "textBoxArmorName";
            this.textBoxArmorName.Size = new System.Drawing.Size(226, 23);
            this.textBoxArmorName.TabIndex = 10;
            // 
            // labelArmorName
            // 
            this.labelArmorName.AutoSize = true;
            this.labelArmorName.Location = new System.Drawing.Point(191, 13);
            this.labelArmorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArmorName.Name = "labelArmorName";
            this.labelArmorName.Size = new System.Drawing.Size(42, 15);
            this.labelArmorName.TabIndex = 9;
            this.labelArmorName.Text = "Name:";
            // 
            // listBoxArmor
            // 
            this.listBoxArmor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxArmor.FormattingEnabled = true;
            this.listBoxArmor.ItemHeight = 15;
            this.listBoxArmor.Location = new System.Drawing.Point(9, 13);
            this.listBoxArmor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxArmor.Name = "listBoxArmor";
            this.listBoxArmor.Size = new System.Drawing.Size(174, 454);
            this.listBoxArmor.TabIndex = 2;
            this.listBoxArmor.SelectedIndexChanged += new System.EventHandler(this.listBoxArmor_SelectedIndexChanged);
            // 
            // tabPageAccessoryData
            // 
            this.tabPageAccessoryData.Controls.Add(this.groupBoxAccessoryRestrictions);
            this.tabPageAccessoryData.Controls.Add(this.groupBoxAccessoryEquipable);
            this.tabPageAccessoryData.Controls.Add(this.textBoxAccessoryDescription);
            this.tabPageAccessoryData.Controls.Add(this.labelAccessoryDescription);
            this.tabPageAccessoryData.Controls.Add(this.textBoxAccessoryName);
            this.tabPageAccessoryData.Controls.Add(this.labelAccessoryName);
            this.tabPageAccessoryData.Controls.Add(this.listBoxAccessories);
            this.tabPageAccessoryData.Location = new System.Drawing.Point(4, 24);
            this.tabPageAccessoryData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageAccessoryData.Name = "tabPageAccessoryData";
            this.tabPageAccessoryData.Size = new System.Drawing.Size(776, 533);
            this.tabPageAccessoryData.TabIndex = 6;
            this.tabPageAccessoryData.Text = "Accessories";
            this.tabPageAccessoryData.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccessoryRestrictions
            // 
            this.groupBoxAccessoryRestrictions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAccessoryRestrictions.Controls.Add(this.checkBoxAccessoryIsSellable);
            this.groupBoxAccessoryRestrictions.Controls.Add(this.checkBoxAccessoryUsableInMenu);
            this.groupBoxAccessoryRestrictions.Controls.Add(this.checkBoxAccessoryUsableInBattle);
            this.groupBoxAccessoryRestrictions.Location = new System.Drawing.Point(532, 343);
            this.groupBoxAccessoryRestrictions.Name = "groupBoxAccessoryRestrictions";
            this.groupBoxAccessoryRestrictions.Size = new System.Drawing.Size(232, 124);
            this.groupBoxAccessoryRestrictions.TabIndex = 22;
            this.groupBoxAccessoryRestrictions.TabStop = false;
            this.groupBoxAccessoryRestrictions.Text = "Item restrictions";
            // 
            // checkBoxAccessoryIsSellable
            // 
            this.checkBoxAccessoryIsSellable.AutoSize = true;
            this.checkBoxAccessoryIsSellable.Location = new System.Drawing.Point(7, 22);
            this.checkBoxAccessoryIsSellable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxAccessoryIsSellable.Name = "checkBoxAccessoryIsSellable";
            this.checkBoxAccessoryIsSellable.Size = new System.Drawing.Size(88, 19);
            this.checkBoxAccessoryIsSellable.TabIndex = 19;
            this.checkBoxAccessoryIsSellable.Text = "Can be sold";
            this.checkBoxAccessoryIsSellable.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryUsableInMenu
            // 
            this.checkBoxAccessoryUsableInMenu.AutoSize = true;
            this.checkBoxAccessoryUsableInMenu.Location = new System.Drawing.Point(7, 72);
            this.checkBoxAccessoryUsableInMenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxAccessoryUsableInMenu.Name = "checkBoxAccessoryUsableInMenu";
            this.checkBoxAccessoryUsableInMenu.Size = new System.Drawing.Size(138, 19);
            this.checkBoxAccessoryUsableInMenu.TabIndex = 21;
            this.checkBoxAccessoryUsableInMenu.Text = "Can be used in menu";
            this.checkBoxAccessoryUsableInMenu.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryUsableInBattle
            // 
            this.checkBoxAccessoryUsableInBattle.AutoSize = true;
            this.checkBoxAccessoryUsableInBattle.Location = new System.Drawing.Point(7, 47);
            this.checkBoxAccessoryUsableInBattle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxAccessoryUsableInBattle.Name = "checkBoxAccessoryUsableInBattle";
            this.checkBoxAccessoryUsableInBattle.Size = new System.Drawing.Size(137, 19);
            this.checkBoxAccessoryUsableInBattle.TabIndex = 20;
            this.checkBoxAccessoryUsableInBattle.Text = "Can be used in battle";
            this.checkBoxAccessoryUsableInBattle.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccessoryEquipable
            // 
            this.groupBoxAccessoryEquipable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessorySephiroth);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryYCloud);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryCid);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryVincent);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryCaitSith);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryYuffie);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryRed);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryAerith);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryTifa);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryBarret);
            this.groupBoxAccessoryEquipable.Controls.Add(this.checkBoxAccessoryCloud);
            this.groupBoxAccessoryEquipable.Location = new System.Drawing.Point(191, 343);
            this.groupBoxAccessoryEquipable.Name = "groupBoxAccessoryEquipable";
            this.groupBoxAccessoryEquipable.Size = new System.Drawing.Size(335, 124);
            this.groupBoxAccessoryEquipable.TabIndex = 14;
            this.groupBoxAccessoryEquipable.TabStop = false;
            this.groupBoxAccessoryEquipable.Text = "Equipable by...";
            // 
            // checkBoxAccessorySephiroth
            // 
            this.checkBoxAccessorySephiroth.AutoSize = true;
            this.checkBoxAccessorySephiroth.Location = new System.Drawing.Point(188, 72);
            this.checkBoxAccessorySephiroth.Name = "checkBoxAccessorySephiroth";
            this.checkBoxAccessorySephiroth.Size = new System.Drawing.Size(77, 19);
            this.checkBoxAccessorySephiroth.TabIndex = 10;
            this.checkBoxAccessorySephiroth.Text = "Sephiroth";
            this.checkBoxAccessorySephiroth.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryYCloud
            // 
            this.checkBoxAccessoryYCloud.AutoSize = true;
            this.checkBoxAccessoryYCloud.Location = new System.Drawing.Point(188, 47);
            this.checkBoxAccessoryYCloud.Name = "checkBoxAccessoryYCloud";
            this.checkBoxAccessoryYCloud.Size = new System.Drawing.Size(68, 19);
            this.checkBoxAccessoryYCloud.TabIndex = 9;
            this.checkBoxAccessoryYCloud.Text = "Y.Cloud";
            this.checkBoxAccessoryYCloud.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryCid
            // 
            this.checkBoxAccessoryCid.AutoSize = true;
            this.checkBoxAccessoryCid.Location = new System.Drawing.Point(188, 22);
            this.checkBoxAccessoryCid.Name = "checkBoxAccessoryCid";
            this.checkBoxAccessoryCid.Size = new System.Drawing.Size(44, 19);
            this.checkBoxAccessoryCid.TabIndex = 8;
            this.checkBoxAccessoryCid.Text = "Cid";
            this.checkBoxAccessoryCid.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryVincent
            // 
            this.checkBoxAccessoryVincent.AutoSize = true;
            this.checkBoxAccessoryVincent.Location = new System.Drawing.Point(96, 97);
            this.checkBoxAccessoryVincent.Name = "checkBoxAccessoryVincent";
            this.checkBoxAccessoryVincent.Size = new System.Drawing.Size(66, 19);
            this.checkBoxAccessoryVincent.TabIndex = 7;
            this.checkBoxAccessoryVincent.Text = "Vincent";
            this.checkBoxAccessoryVincent.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryCaitSith
            // 
            this.checkBoxAccessoryCaitSith.AutoSize = true;
            this.checkBoxAccessoryCaitSith.Location = new System.Drawing.Point(96, 72);
            this.checkBoxAccessoryCaitSith.Name = "checkBoxAccessoryCaitSith";
            this.checkBoxAccessoryCaitSith.Size = new System.Drawing.Size(70, 19);
            this.checkBoxAccessoryCaitSith.TabIndex = 6;
            this.checkBoxAccessoryCaitSith.Text = "Cait Sith";
            this.checkBoxAccessoryCaitSith.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryYuffie
            // 
            this.checkBoxAccessoryYuffie.AutoSize = true;
            this.checkBoxAccessoryYuffie.Location = new System.Drawing.Point(96, 47);
            this.checkBoxAccessoryYuffie.Name = "checkBoxAccessoryYuffie";
            this.checkBoxAccessoryYuffie.Size = new System.Drawing.Size(57, 19);
            this.checkBoxAccessoryYuffie.TabIndex = 5;
            this.checkBoxAccessoryYuffie.Text = "Yuffie";
            this.checkBoxAccessoryYuffie.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryRed
            // 
            this.checkBoxAccessoryRed.AutoSize = true;
            this.checkBoxAccessoryRed.Location = new System.Drawing.Point(96, 22);
            this.checkBoxAccessoryRed.Name = "checkBoxAccessoryRed";
            this.checkBoxAccessoryRed.Size = new System.Drawing.Size(65, 19);
            this.checkBoxAccessoryRed.TabIndex = 4;
            this.checkBoxAccessoryRed.Text = "Red XIII";
            this.checkBoxAccessoryRed.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryAerith
            // 
            this.checkBoxAccessoryAerith.AutoSize = true;
            this.checkBoxAccessoryAerith.Location = new System.Drawing.Point(6, 97);
            this.checkBoxAccessoryAerith.Name = "checkBoxAccessoryAerith";
            this.checkBoxAccessoryAerith.Size = new System.Drawing.Size(58, 19);
            this.checkBoxAccessoryAerith.TabIndex = 3;
            this.checkBoxAccessoryAerith.Text = "Aerith";
            this.checkBoxAccessoryAerith.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryTifa
            // 
            this.checkBoxAccessoryTifa.AutoSize = true;
            this.checkBoxAccessoryTifa.Location = new System.Drawing.Point(6, 72);
            this.checkBoxAccessoryTifa.Name = "checkBoxAccessoryTifa";
            this.checkBoxAccessoryTifa.Size = new System.Drawing.Size(45, 19);
            this.checkBoxAccessoryTifa.TabIndex = 2;
            this.checkBoxAccessoryTifa.Text = "Tifa";
            this.checkBoxAccessoryTifa.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryBarret
            // 
            this.checkBoxAccessoryBarret.AutoSize = true;
            this.checkBoxAccessoryBarret.Location = new System.Drawing.Point(6, 47);
            this.checkBoxAccessoryBarret.Name = "checkBoxAccessoryBarret";
            this.checkBoxAccessoryBarret.Size = new System.Drawing.Size(57, 19);
            this.checkBoxAccessoryBarret.TabIndex = 1;
            this.checkBoxAccessoryBarret.Text = "Barret";
            this.checkBoxAccessoryBarret.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessoryCloud
            // 
            this.checkBoxAccessoryCloud.AutoSize = true;
            this.checkBoxAccessoryCloud.Location = new System.Drawing.Point(6, 22);
            this.checkBoxAccessoryCloud.Name = "checkBoxAccessoryCloud";
            this.checkBoxAccessoryCloud.Size = new System.Drawing.Size(58, 19);
            this.checkBoxAccessoryCloud.TabIndex = 0;
            this.checkBoxAccessoryCloud.Text = "Cloud";
            this.checkBoxAccessoryCloud.UseVisualStyleBackColor = true;
            // 
            // textBoxAccessoryDescription
            // 
            this.textBoxAccessoryDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAccessoryDescription.Location = new System.Drawing.Point(191, 75);
            this.textBoxAccessoryDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAccessoryDescription.Name = "textBoxAccessoryDescription";
            this.textBoxAccessoryDescription.Size = new System.Drawing.Size(573, 23);
            this.textBoxAccessoryDescription.TabIndex = 12;
            // 
            // labelAccessoryDescription
            // 
            this.labelAccessoryDescription.AutoSize = true;
            this.labelAccessoryDescription.Location = new System.Drawing.Point(191, 57);
            this.labelAccessoryDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccessoryDescription.Name = "labelAccessoryDescription";
            this.labelAccessoryDescription.Size = new System.Drawing.Size(70, 15);
            this.labelAccessoryDescription.TabIndex = 11;
            this.labelAccessoryDescription.Text = "Description:";
            // 
            // textBoxAccessoryName
            // 
            this.textBoxAccessoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAccessoryName.Location = new System.Drawing.Point(191, 31);
            this.textBoxAccessoryName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAccessoryName.Name = "textBoxAccessoryName";
            this.textBoxAccessoryName.Size = new System.Drawing.Size(226, 23);
            this.textBoxAccessoryName.TabIndex = 10;
            // 
            // labelAccessoryName
            // 
            this.labelAccessoryName.AutoSize = true;
            this.labelAccessoryName.Location = new System.Drawing.Point(191, 13);
            this.labelAccessoryName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccessoryName.Name = "labelAccessoryName";
            this.labelAccessoryName.Size = new System.Drawing.Size(42, 15);
            this.labelAccessoryName.TabIndex = 9;
            this.labelAccessoryName.Text = "Name:";
            // 
            // listBoxAccessories
            // 
            this.listBoxAccessories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxAccessories.FormattingEnabled = true;
            this.listBoxAccessories.ItemHeight = 15;
            this.listBoxAccessories.Location = new System.Drawing.Point(9, 13);
            this.listBoxAccessories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxAccessories.Name = "listBoxAccessories";
            this.listBoxAccessories.Size = new System.Drawing.Size(174, 454);
            this.listBoxAccessories.TabIndex = 2;
            this.listBoxAccessories.SelectedIndexChanged += new System.EventHandler(this.listBoxAccessories_SelectedIndexChanged);
            // 
            // tabPageMateriaData
            // 
            this.tabPageMateriaData.Controls.Add(this.comboBoxMateriaElement);
            this.tabPageMateriaData.Controls.Add(this.labelMateriaElement);
            this.tabPageMateriaData.Controls.Add(this.comboBoxMateriaType);
            this.tabPageMateriaData.Controls.Add(this.labelMateriaType);
            this.tabPageMateriaData.Controls.Add(this.textBoxMateriaDescription);
            this.tabPageMateriaData.Controls.Add(this.labelMateriaDescription);
            this.tabPageMateriaData.Controls.Add(this.textBoxMateriaName);
            this.tabPageMateriaData.Controls.Add(this.labelMateriaName);
            this.tabPageMateriaData.Controls.Add(this.listBoxMateria);
            this.tabPageMateriaData.Location = new System.Drawing.Point(4, 24);
            this.tabPageMateriaData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageMateriaData.Name = "tabPageMateriaData";
            this.tabPageMateriaData.Size = new System.Drawing.Size(776, 533);
            this.tabPageMateriaData.TabIndex = 7;
            this.tabPageMateriaData.Text = "Materia";
            this.tabPageMateriaData.UseVisualStyleBackColor = true;
            // 
            // comboBoxMateriaElement
            // 
            this.comboBoxMateriaElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMateriaElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateriaElement.FormattingEnabled = true;
            this.comboBoxMateriaElement.Location = new System.Drawing.Point(191, 119);
            this.comboBoxMateriaElement.Name = "comboBoxMateriaElement";
            this.comboBoxMateriaElement.Size = new System.Drawing.Size(226, 23);
            this.comboBoxMateriaElement.TabIndex = 16;
            // 
            // labelMateriaElement
            // 
            this.labelMateriaElement.AutoSize = true;
            this.labelMateriaElement.Location = new System.Drawing.Point(195, 101);
            this.labelMateriaElement.Name = "labelMateriaElement";
            this.labelMateriaElement.Size = new System.Drawing.Size(53, 15);
            this.labelMateriaElement.TabIndex = 15;
            this.labelMateriaElement.Text = "Element:";
            // 
            // comboBoxMateriaType
            // 
            this.comboBoxMateriaType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMateriaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateriaType.FormattingEnabled = true;
            this.comboBoxMateriaType.Location = new System.Drawing.Point(423, 119);
            this.comboBoxMateriaType.Name = "comboBoxMateriaType";
            this.comboBoxMateriaType.Size = new System.Drawing.Size(221, 23);
            this.comboBoxMateriaType.TabIndex = 14;
            // 
            // labelMateriaType
            // 
            this.labelMateriaType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMateriaType.AutoSize = true;
            this.labelMateriaType.Location = new System.Drawing.Point(423, 101);
            this.labelMateriaType.Name = "labelMateriaType";
            this.labelMateriaType.Size = new System.Drawing.Size(76, 15);
            this.labelMateriaType.TabIndex = 13;
            this.labelMateriaType.Text = "Materia type:";
            // 
            // textBoxMateriaDescription
            // 
            this.textBoxMateriaDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMateriaDescription.Location = new System.Drawing.Point(191, 75);
            this.textBoxMateriaDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxMateriaDescription.Name = "textBoxMateriaDescription";
            this.textBoxMateriaDescription.Size = new System.Drawing.Size(573, 23);
            this.textBoxMateriaDescription.TabIndex = 12;
            // 
            // labelMateriaDescription
            // 
            this.labelMateriaDescription.AutoSize = true;
            this.labelMateriaDescription.Location = new System.Drawing.Point(191, 57);
            this.labelMateriaDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMateriaDescription.Name = "labelMateriaDescription";
            this.labelMateriaDescription.Size = new System.Drawing.Size(70, 15);
            this.labelMateriaDescription.TabIndex = 11;
            this.labelMateriaDescription.Text = "Description:";
            // 
            // textBoxMateriaName
            // 
            this.textBoxMateriaName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMateriaName.Location = new System.Drawing.Point(191, 31);
            this.textBoxMateriaName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxMateriaName.Name = "textBoxMateriaName";
            this.textBoxMateriaName.Size = new System.Drawing.Size(226, 23);
            this.textBoxMateriaName.TabIndex = 10;
            // 
            // labelMateriaName
            // 
            this.labelMateriaName.AutoSize = true;
            this.labelMateriaName.Location = new System.Drawing.Point(191, 13);
            this.labelMateriaName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMateriaName.Name = "labelMateriaName";
            this.labelMateriaName.Size = new System.Drawing.Size(42, 15);
            this.labelMateriaName.TabIndex = 9;
            this.labelMateriaName.Text = "Name:";
            // 
            // listBoxMateria
            // 
            this.listBoxMateria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxMateria.FormattingEnabled = true;
            this.listBoxMateria.ItemHeight = 15;
            this.listBoxMateria.Location = new System.Drawing.Point(9, 13);
            this.listBoxMateria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxMateria.Name = "listBoxMateria";
            this.listBoxMateria.Size = new System.Drawing.Size(174, 454);
            this.listBoxMateria.TabIndex = 2;
            this.listBoxMateria.SelectedIndexChanged += new System.EventHandler(this.listBoxMateria_SelectedIndexChanged);
            // 
            // tabPageKeyItemText
            // 
            this.tabPageKeyItemText.Controls.Add(this.textBoxKeyItemDescription);
            this.tabPageKeyItemText.Controls.Add(this.labelKeyItemDescription);
            this.tabPageKeyItemText.Controls.Add(this.textBoxKeyItemName);
            this.tabPageKeyItemText.Controls.Add(this.labelKeyItemName);
            this.tabPageKeyItemText.Controls.Add(this.listBoxKeyItems);
            this.tabPageKeyItemText.Location = new System.Drawing.Point(4, 24);
            this.tabPageKeyItemText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageKeyItemText.Name = "tabPageKeyItemText";
            this.tabPageKeyItemText.Size = new System.Drawing.Size(776, 533);
            this.tabPageKeyItemText.TabIndex = 8;
            this.tabPageKeyItemText.Text = "Key Items";
            this.tabPageKeyItemText.UseVisualStyleBackColor = true;
            // 
            // textBoxKeyItemDescription
            // 
            this.textBoxKeyItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyItemDescription.Location = new System.Drawing.Point(191, 75);
            this.textBoxKeyItemDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKeyItemDescription.Name = "textBoxKeyItemDescription";
            this.textBoxKeyItemDescription.Size = new System.Drawing.Size(573, 23);
            this.textBoxKeyItemDescription.TabIndex = 8;
            // 
            // labelKeyItemDescription
            // 
            this.labelKeyItemDescription.AutoSize = true;
            this.labelKeyItemDescription.Location = new System.Drawing.Point(191, 57);
            this.labelKeyItemDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKeyItemDescription.Name = "labelKeyItemDescription";
            this.labelKeyItemDescription.Size = new System.Drawing.Size(70, 15);
            this.labelKeyItemDescription.TabIndex = 7;
            this.labelKeyItemDescription.Text = "Description:";
            // 
            // textBoxKeyItemName
            // 
            this.textBoxKeyItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyItemName.Location = new System.Drawing.Point(191, 31);
            this.textBoxKeyItemName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKeyItemName.Name = "textBoxKeyItemName";
            this.textBoxKeyItemName.Size = new System.Drawing.Size(226, 23);
            this.textBoxKeyItemName.TabIndex = 6;
            // 
            // labelKeyItemName
            // 
            this.labelKeyItemName.AutoSize = true;
            this.labelKeyItemName.Location = new System.Drawing.Point(191, 13);
            this.labelKeyItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKeyItemName.Name = "labelKeyItemName";
            this.labelKeyItemName.Size = new System.Drawing.Size(42, 15);
            this.labelKeyItemName.TabIndex = 5;
            this.labelKeyItemName.Text = "Name:";
            // 
            // listBoxKeyItems
            // 
            this.listBoxKeyItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxKeyItems.FormattingEnabled = true;
            this.listBoxKeyItems.ItemHeight = 15;
            this.listBoxKeyItems.Location = new System.Drawing.Point(9, 13);
            this.listBoxKeyItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxKeyItems.Name = "listBoxKeyItems";
            this.listBoxKeyItems.Size = new System.Drawing.Size(174, 454);
            this.listBoxKeyItems.TabIndex = 1;
            this.listBoxKeyItems.SelectedIndexChanged += new System.EventHandler(this.listBoxKeyItems_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(14, 8);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(175, 27);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save kernel file(s)";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImport.Location = new System.Drawing.Point(531, 8);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(117, 27);
            this.buttonImport.TabIndex = 2;
            this.buttonImport.Text = "Import...";
            this.buttonImport.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Location = new System.Drawing.Point(654, 8);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(117, 27);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "Export...";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonExport);
            this.panelButtons.Controls.Add(this.buttonSave);
            this.panelButtons.Controls.Add(this.buttonImport);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 515);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(784, 46);
            this.panelButtons.TabIndex = 4;
            // 
            // KernelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(639, 456);
            this.Name = "KernelForm";
            this.Text = "Scarlet - Kernel Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KernelForm_FormClosed);
            this.Load += new System.EventHandler(this.KernelForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCommandData.ResumeLayout(false);
            this.tabPageCommandData.PerformLayout();
            this.tabPageAttackData.ResumeLayout(false);
            this.tabPageAttackData.PerformLayout();
            this.tabPageItemData.ResumeLayout(false);
            this.tabPageItemData.PerformLayout();
            this.groupBoxItemTargetFlags.ResumeLayout(false);
            this.groupBoxItemTargetFlags.PerformLayout();
            this.groupBoxItemRestrictions.ResumeLayout(false);
            this.groupBoxItemRestrictions.PerformLayout();
            this.tabPageWeaponData.ResumeLayout(false);
            this.tabPageWeaponData.PerformLayout();
            this.groupBoxWeaponTargetFlags.ResumeLayout(false);
            this.groupBoxWeaponTargetFlags.PerformLayout();
            this.groupBoxWeaponMateriaSlots.ResumeLayout(false);
            this.groupBoxWeaponMateriaSlots.PerformLayout();
            this.groupBoxWeaponRestrictions.ResumeLayout(false);
            this.groupBoxWeaponRestrictions.PerformLayout();
            this.groupBoxWeaponEquipable.ResumeLayout(false);
            this.groupBoxWeaponEquipable.PerformLayout();
            this.tabPageArmorData.ResumeLayout(false);
            this.tabPageArmorData.PerformLayout();
            this.groupBoxArmorMateriaSlots.ResumeLayout(false);
            this.groupBoxArmorMateriaSlots.PerformLayout();
            this.groupBoxArmorRestrictions.ResumeLayout(false);
            this.groupBoxArmorRestrictions.PerformLayout();
            this.groupBoxArmorEquipable.ResumeLayout(false);
            this.groupBoxArmorEquipable.PerformLayout();
            this.tabPageAccessoryData.ResumeLayout(false);
            this.tabPageAccessoryData.PerformLayout();
            this.groupBoxAccessoryRestrictions.ResumeLayout(false);
            this.groupBoxAccessoryRestrictions.PerformLayout();
            this.groupBoxAccessoryEquipable.ResumeLayout(false);
            this.groupBoxAccessoryEquipable.PerformLayout();
            this.tabPageMateriaData.ResumeLayout(false);
            this.tabPageMateriaData.PerformLayout();
            this.tabPageKeyItemText.ResumeLayout(false);
            this.tabPageKeyItemText.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCommandData;
        private System.Windows.Forms.TabPage tabPageAttackData;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.TabPage tabPageBattleData;
        private System.Windows.Forms.TabPage tabPageInitData;
        private System.Windows.Forms.TabPage tabPageWeaponData;
        private System.Windows.Forms.TabPage tabPageArmorData;
        private System.Windows.Forms.TabPage tabPageAccessoryData;
        private System.Windows.Forms.TabPage tabPageMateriaData;
        private System.Windows.Forms.TabPage tabPageKeyItemText;
        private System.Windows.Forms.TabPage tabPageItemData;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.ListBox listBoxWeapons;
        private System.Windows.Forms.ListBox listBoxArmor;
        private System.Windows.Forms.ListBox listBoxAccessories;
        private System.Windows.Forms.ListBox listBoxMateria;
        private System.Windows.Forms.ListBox listBoxCommands;
        private System.Windows.Forms.ListBox listBoxAttacks;
        private System.Windows.Forms.TextBox textBoxAttackName;
        private System.Windows.Forms.Label labelAttackName;
        private System.Windows.Forms.TextBox textBoxAttackDescription;
        private System.Windows.Forms.Label labelAttackDescription;
        private System.Windows.Forms.TextBox textBoxSummonText;
        private System.Windows.Forms.Label labelSummonText;
        private System.Windows.Forms.ListBox listBoxKeyItems;
        private System.Windows.Forms.TextBox textBoxKeyItemDescription;
        private System.Windows.Forms.Label labelKeyItemDescription;
        private System.Windows.Forms.TextBox textBoxKeyItemName;
        private System.Windows.Forms.Label labelKeyItemName;
        private System.Windows.Forms.TextBox textBoxItemDescription;
        private System.Windows.Forms.Label labelItemDescription;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.TextBox textBoxWeaponDescription;
        private System.Windows.Forms.Label labelWeaponDescription;
        private System.Windows.Forms.TextBox textBoxWeaponName;
        private System.Windows.Forms.Label labelWeaponName;
        private System.Windows.Forms.TextBox textBoxArmorDescription;
        private System.Windows.Forms.Label labelArmorDescription;
        private System.Windows.Forms.TextBox textBoxArmorName;
        private System.Windows.Forms.Label labelArmorName;
        private System.Windows.Forms.TextBox textBoxAccessoryDescription;
        private System.Windows.Forms.Label labelAccessoryDescription;
        private System.Windows.Forms.TextBox textBoxAccessoryName;
        private System.Windows.Forms.Label labelAccessoryName;
        private System.Windows.Forms.TextBox textBoxMateriaDescription;
        private System.Windows.Forms.Label labelMateriaDescription;
        private System.Windows.Forms.TextBox textBoxMateriaName;
        private System.Windows.Forms.Label labelMateriaName;
        private System.Windows.Forms.TextBox textBoxCommandDescription;
        private System.Windows.Forms.Label labelCommandDescription;
        private System.Windows.Forms.TextBox textBoxCommandName;
        private System.Windows.Forms.Label labelCommandName;
        private System.Windows.Forms.CheckBox checkBoxItemUsableInMenu;
        private System.Windows.Forms.CheckBox checkBoxItemUsableInBattle;
        private System.Windows.Forms.CheckBox checkBoxItemIsSellable;
        private ComboBox comboBoxMateriaType;
        private Label labelMateriaType;
        private ComboBox comboBoxMateriaElement;
        private Label labelMateriaElement;
        private GroupBox groupBoxWeaponEquipable;
        private CheckBox checkBoxWeaponSephiroth;
        private CheckBox checkBoxWeaponYCloud;
        private CheckBox checkBoxWeaponCid;
        private CheckBox checkBoxWeaponVincent;
        private CheckBox checkBoxWeaponCaitSith;
        private CheckBox checkBoxWeaponYuffie;
        private CheckBox checkBoxWeaponRed;
        private CheckBox checkBoxWeaponAerith;
        private CheckBox checkBoxWeaponTifa;
        private CheckBox checkBoxWeaponBarret;
        private CheckBox checkBoxWeaponCloud;
        private GroupBox groupBoxArmorEquipable;
        private CheckBox checkBoxArmorSephiroth;
        private CheckBox checkBoxArmorYCloud;
        private CheckBox checkBoxArmorCid;
        private CheckBox checkBoxArmorVincent;
        private CheckBox checkBoxArmorCaitSith;
        private CheckBox checkBoxArmorYuffie;
        private CheckBox checkBoxArmorRed;
        private CheckBox checkBoxArmorAerith;
        private CheckBox checkBoxArmorTifa;
        private CheckBox checkBoxArmorBarret;
        private CheckBox checkBoxArmorCloud;
        private GroupBox groupBoxAccessoryEquipable;
        private CheckBox checkBoxAccessorySephiroth;
        private CheckBox checkBoxAccessoryYCloud;
        private CheckBox checkBoxAccessoryCid;
        private CheckBox checkBoxAccessoryVincent;
        private CheckBox checkBoxAccessoryCaitSith;
        private CheckBox checkBoxAccessoryYuffie;
        private CheckBox checkBoxAccessoryRed;
        private CheckBox checkBoxAccessoryAerith;
        private CheckBox checkBoxAccessoryTifa;
        private CheckBox checkBoxAccessoryBarret;
        private CheckBox checkBoxAccessoryCloud;
        private CheckBox checkBoxWeaponUsableInMenu;
        private CheckBox checkBoxWeaponUsableInBattle;
        private CheckBox checkBoxWeaponIsSellable;
        private CheckBox checkBoxArmorUsableInMenu;
        private CheckBox checkBoxArmorUsableInBattle;
        private CheckBox checkBoxArmorIsSellable;
        private CheckBox checkBoxAccessoryUsableInMenu;
        private CheckBox checkBoxAccessoryUsableInBattle;
        private CheckBox checkBoxAccessoryIsSellable;
        private GroupBox groupBoxAccessoryRestrictions;
        private GroupBox groupBoxArmorRestrictions;
        private GroupBox groupBoxWeaponRestrictions;
        private CheckBox checkBoxWeaponIsThrowable;
        private GroupBox groupBoxItemRestrictions;
        private GroupBox groupBoxWeaponMateriaSlots;
        private MateriaSlotSelectorControl materiaSlotSelectorWeapon;
        private Label labelWeaponMateriaGrowth;
        private ComboBox comboBoxWeaponMateriaGrowth;
        private GroupBox groupBoxArmorMateriaSlots;
        private Label labelArmorMateriaGrowth;
        private MateriaSlotSelectorControl materiaSlotSelectorArmor;
        private ComboBox comboBoxArmorMateriaGrowth;
        private GroupBox groupBoxItemTargetFlags;
        private CheckBox checkBoxItemRandomTarget;
        private CheckBox checkBoxItemAllRows;
        private CheckBox checkBoxItemShortRange;
        private CheckBox checkBoxItemOneRowOnly;
        private CheckBox checkBoxItemSingleMultiToggle;
        private CheckBox checkBoxItemMultipleTargetDefault;
        private CheckBox checkBoxItemStartOnEnemies;
        private CheckBox checkBoxItemEnableSelection;
        private GroupBox groupBoxWeaponTargetFlags;
        private CheckBox checkBoxWeaponRandomTarget;
        private CheckBox checkBoxWeaponAllRows;
        private CheckBox checkBoxWeaponShortRange;
        private CheckBox checkBoxWeaponOneRowOnly;
        private CheckBox checkBoxWeaponSingleMultiToggle;
        private CheckBox checkBoxWeaponMultipleTargetDefault;
        private CheckBox checkBoxWeaponStartOnEnemies;
        private CheckBox checkBoxWeaponEnableSelection;
        private ComboBox comboBoxItemCamMovementID;
        private Label labelItemCamMovementID;
        private ComboBox comboBoxItemAttackEffectID;
        private Label labelItemAttackEffectID;
        private DamageCalculationControl damageCalculationControlItem;
        private DamageCalculationControl damageCalculationControlWeapon;
    }
}