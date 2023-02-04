namespace FF7Scarlet.KernelEditor
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
            this.tabControlItems = new System.Windows.Forms.TabControl();
            this.tabPageItems1 = new System.Windows.Forms.TabPage();
            this.labelItemName = new System.Windows.Forms.Label();
            this.itemRestrictionsItem = new FF7Scarlet.KernelEditor.ItemRestrictionsControl();
            this.damageCalculationControlItem = new FF7Scarlet.KernelEditor.DamageCalculationControl();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.targetDataControlItem = new FF7Scarlet.KernelEditor.TargetDataControl();
            this.labelItemDescription = new System.Windows.Forms.Label();
            this.textBoxItemDescription = new System.Windows.Forms.TextBox();
            this.comboBoxItemAttackEffectID = new System.Windows.Forms.ComboBox();
            this.labelItemCamMovementID = new System.Windows.Forms.Label();
            this.labelItemAttackEffectID = new System.Windows.Forms.Label();
            this.comboBoxItemCamMovementID = new System.Windows.Forms.ComboBox();
            this.tabPageItems2 = new System.Windows.Forms.TabPage();
            this.comboBoxStatusChange = new System.Windows.Forms.ComboBox();
            this.labelItemStatusChange = new System.Windows.Forms.Label();
            this.statusesControlItem = new FF7Scarlet.KernelEditor.StatusesControl();
            this.elementsControlItem = new FF7Scarlet.KernelEditor.ElementsControl();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.tabPageWeaponData = new System.Windows.Forms.TabPage();
            this.tabControlWeapons = new System.Windows.Forms.TabControl();
            this.tabPageWeapon1 = new System.Windows.Forms.TabPage();
            this.numericWeaponCritChance = new System.Windows.Forms.NumericUpDown();
            this.numericWeaponHitChance = new System.Windows.Forms.NumericUpDown();
            this.elementsControlWeapon = new FF7Scarlet.KernelEditor.ElementsControl();
            this.comboBoxWeaponStatus = new System.Windows.Forms.ComboBox();
            this.statIncreaseControlWeapon = new FF7Scarlet.KernelEditor.StatIncreaseControl();
            this.numericWeaponAnimationIndex = new System.Windows.Forms.NumericUpDown();
            this.labelWeaponAnimationIndex = new System.Windows.Forms.Label();
            this.labelWeaponStatus = new System.Windows.Forms.Label();
            this.numericWeaponModelIndex = new System.Windows.Forms.NumericUpDown();
            this.labelWeaponModelIndex = new System.Windows.Forms.Label();
            this.groupBoxWeaponMateriaSlots = new System.Windows.Forms.GroupBox();
            this.labelWeaponMateriaGrowth = new System.Windows.Forms.Label();
            this.materiaSlotSelectorWeapon = new FF7Scarlet.KernelEditor.MateriaSlotSelectorControl();
            this.comboBoxWeaponMateriaGrowth = new System.Windows.Forms.ComboBox();
            this.labelWeaponCritChance = new System.Windows.Forms.Label();
            this.labelWeaponHitChance = new System.Windows.Forms.Label();
            this.textBoxWeaponName = new System.Windows.Forms.TextBox();
            this.labelWeaponName = new System.Windows.Forms.Label();
            this.labelWeaponDescription = new System.Windows.Forms.Label();
            this.textBoxWeaponDescription = new System.Windows.Forms.TextBox();
            this.tabPageWeapon2 = new System.Windows.Forms.TabPage();
            this.targetDataControlWeapon = new FF7Scarlet.KernelEditor.TargetDataControl();
            this.damageCalculationControlWeapon = new FF7Scarlet.KernelEditor.DamageCalculationControl();
            this.equipableListWeapon = new FF7Scarlet.KernelEditor.EquipableListControl();
            this.itemRestrictionsWeapon = new FF7Scarlet.KernelEditor.ItemRestrictionsControl();
            this.listBoxWeapons = new System.Windows.Forms.ListBox();
            this.tabPageArmorData = new System.Windows.Forms.TabPage();
            this.tabControlArmor = new System.Windows.Forms.TabControl();
            this.tabPageArmor1 = new System.Windows.Forms.TabPage();
            this.labelArmorElementModifier = new System.Windows.Forms.Label();
            this.numericArmorMagicDefensePercent = new System.Windows.Forms.NumericUpDown();
            this.labelArmorMagicDefensePercent = new System.Windows.Forms.Label();
            this.numericArmorMagicDefense = new System.Windows.Forms.NumericUpDown();
            this.comboBoxArmorElementModifier = new System.Windows.Forms.ComboBox();
            this.labelArmorMagicDefense = new System.Windows.Forms.Label();
            this.comboBoxArmorStatus = new System.Windows.Forms.ComboBox();
            this.numericArmorDefensePercent = new System.Windows.Forms.NumericUpDown();
            this.elementsControlArmor = new FF7Scarlet.KernelEditor.ElementsControl();
            this.labelArmorStatus = new System.Windows.Forms.Label();
            this.labelArmorDefencePercent = new System.Windows.Forms.Label();
            this.numericArmorDefense = new System.Windows.Forms.NumericUpDown();
            this.labelArmorDefense = new System.Windows.Forms.Label();
            this.statIncreaseControlArmor = new FF7Scarlet.KernelEditor.StatIncreaseControl();
            this.labelArmorName = new System.Windows.Forms.Label();
            this.textBoxArmorName = new System.Windows.Forms.TextBox();
            this.labelArmorDescription = new System.Windows.Forms.Label();
            this.groupBoxArmorMateriaSlots = new System.Windows.Forms.GroupBox();
            this.labelArmorMateriaGrowth = new System.Windows.Forms.Label();
            this.materiaSlotSelectorArmor = new FF7Scarlet.KernelEditor.MateriaSlotSelectorControl();
            this.comboBoxArmorMateriaGrowth = new System.Windows.Forms.ComboBox();
            this.textBoxArmorDescription = new System.Windows.Forms.TextBox();
            this.tabPageArmor2 = new System.Windows.Forms.TabPage();
            this.itemRestrictionsArmor = new FF7Scarlet.KernelEditor.ItemRestrictionsControl();
            this.equipableListArmor = new FF7Scarlet.KernelEditor.EquipableListControl();
            this.listBoxArmor = new System.Windows.Forms.ListBox();
            this.tabPageAccessoryData = new System.Windows.Forms.TabPage();
            this.tabControlAccessories = new System.Windows.Forms.TabControl();
            this.tabPageAccessory1 = new System.Windows.Forms.TabPage();
            this.labelAccessoryElementModifier = new System.Windows.Forms.Label();
            this.comboBoxAccessoryElementModifier = new System.Windows.Forms.ComboBox();
            this.statusesControlAccessory = new FF7Scarlet.KernelEditor.StatusesControl();
            this.elementsControlAccessory = new FF7Scarlet.KernelEditor.ElementsControl();
            this.statIncreaseControlAccessory = new FF7Scarlet.KernelEditor.StatIncreaseControl();
            this.labelAccessoryName = new System.Windows.Forms.Label();
            this.textBoxAccessoryName = new System.Windows.Forms.TextBox();
            this.labelAccessoryDescription = new System.Windows.Forms.Label();
            this.textBoxAccessoryDescription = new System.Windows.Forms.TextBox();
            this.tabPageAccessory2 = new System.Windows.Forms.TabPage();
            this.comboBoxAccessorySpecialEffects = new System.Windows.Forms.ComboBox();
            this.labelAccessorySpecialEffects = new System.Windows.Forms.Label();
            this.equipableListAccessory = new FF7Scarlet.KernelEditor.EquipableListControl();
            this.itemRestrictionsAccessory = new FF7Scarlet.KernelEditor.ItemRestrictionsControl();
            this.listBoxAccessories = new System.Windows.Forms.ListBox();
            this.tabPageMateriaData = new System.Windows.Forms.TabPage();
            this.comboBoxMateriaEquipAttributes = new System.Windows.Forms.ComboBox();
            this.labelMateriaEquipAttributes = new System.Windows.Forms.Label();
            this.statusesControlMateria = new FF7Scarlet.KernelEditor.StatusesControl();
            this.comboBoxMateriaSubtype = new System.Windows.Forms.ComboBox();
            this.labelMateriaSubtype = new System.Windows.Forms.Label();
            this.materiaLevelControl = new FF7Scarlet.KernelEditor.MateriaLevelControl();
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
            this.tabControlItems.SuspendLayout();
            this.tabPageItems1.SuspendLayout();
            this.tabPageItems2.SuspendLayout();
            this.tabPageWeaponData.SuspendLayout();
            this.tabControlWeapons.SuspendLayout();
            this.tabPageWeapon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeaponCritChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeaponHitChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeaponAnimationIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeaponModelIndex)).BeginInit();
            this.groupBoxWeaponMateriaSlots.SuspendLayout();
            this.tabPageWeapon2.SuspendLayout();
            this.tabPageArmorData.SuspendLayout();
            this.tabControlArmor.SuspendLayout();
            this.tabPageArmor1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericArmorMagicDefensePercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericArmorMagicDefense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericArmorDefensePercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericArmorDefense)).BeginInit();
            this.groupBoxArmorMateriaSlots.SuspendLayout();
            this.tabPageArmor2.SuspendLayout();
            this.tabPageAccessoryData.SuspendLayout();
            this.tabControlAccessories.SuspendLayout();
            this.tabPageAccessory1.SuspendLayout();
            this.tabPageAccessory2.SuspendLayout();
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
            this.listBoxCommands.Size = new System.Drawing.Size(174, 469);
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
            this.listBoxAttacks.Size = new System.Drawing.Size(174, 469);
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
            this.tabPageItemData.Controls.Add(this.tabControlItems);
            this.tabPageItemData.Controls.Add(this.listBoxItems);
            this.tabPageItemData.Location = new System.Drawing.Point(4, 24);
            this.tabPageItemData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageItemData.Name = "tabPageItemData";
            this.tabPageItemData.Size = new System.Drawing.Size(776, 533);
            this.tabPageItemData.TabIndex = 9;
            this.tabPageItemData.Text = "Items";
            this.tabPageItemData.UseVisualStyleBackColor = true;
            // 
            // tabControlItems
            // 
            this.tabControlItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlItems.Controls.Add(this.tabPageItems1);
            this.tabControlItems.Controls.Add(this.tabPageItems2);
            this.tabControlItems.Location = new System.Drawing.Point(190, 13);
            this.tabControlItems.Name = "tabControlItems";
            this.tabControlItems.SelectedIndex = 0;
            this.tabControlItems.Size = new System.Drawing.Size(578, 469);
            this.tabControlItems.TabIndex = 32;
            // 
            // tabPageItems1
            // 
            this.tabPageItems1.Controls.Add(this.labelItemName);
            this.tabPageItems1.Controls.Add(this.itemRestrictionsItem);
            this.tabPageItems1.Controls.Add(this.damageCalculationControlItem);
            this.tabPageItems1.Controls.Add(this.textBoxItemName);
            this.tabPageItems1.Controls.Add(this.targetDataControlItem);
            this.tabPageItems1.Controls.Add(this.labelItemDescription);
            this.tabPageItems1.Controls.Add(this.textBoxItemDescription);
            this.tabPageItems1.Controls.Add(this.comboBoxItemAttackEffectID);
            this.tabPageItems1.Controls.Add(this.labelItemCamMovementID);
            this.tabPageItems1.Controls.Add(this.labelItemAttackEffectID);
            this.tabPageItems1.Controls.Add(this.comboBoxItemCamMovementID);
            this.tabPageItems1.Location = new System.Drawing.Point(4, 24);
            this.tabPageItems1.Name = "tabPageItems1";
            this.tabPageItems1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItems1.Size = new System.Drawing.Size(570, 441);
            this.tabPageItems1.TabIndex = 0;
            this.tabPageItems1.Text = "Page 1";
            this.tabPageItems1.UseVisualStyleBackColor = true;
            // 
            // labelItemName
            // 
            this.labelItemName.AutoSize = true;
            this.labelItemName.Location = new System.Drawing.Point(7, 3);
            this.labelItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(42, 15);
            this.labelItemName.TabIndex = 9;
            this.labelItemName.Text = "Name:";
            // 
            // itemRestrictionsItem
            // 
            this.itemRestrictionsItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemRestrictionsItem.Location = new System.Drawing.Point(352, 310);
            this.itemRestrictionsItem.Name = "itemRestrictionsItem";
            this.itemRestrictionsItem.ShowThrowable = false;
            this.itemRestrictionsItem.Size = new System.Drawing.Size(211, 125);
            this.itemRestrictionsItem.TabIndex = 31;
            // 
            // damageCalculationControlItem
            // 
            this.damageCalculationControlItem.AccuracyCalculation = FF7Scarlet.AccuracyCalculation.NoMiss1;
            this.damageCalculationControlItem.ActualValue = ((byte)(0));
            this.damageCalculationControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.damageCalculationControlItem.AttackPower = ((byte)(0));
            this.damageCalculationControlItem.CanCrit = false;
            this.damageCalculationControlItem.DamageFormula = FF7Scarlet.DamageFormulas.NoDamage;
            this.damageCalculationControlItem.DamageType = FF7Scarlet.DamageType.Physical;
            this.damageCalculationControlItem.Location = new System.Drawing.Point(7, 138);
            this.damageCalculationControlItem.Name = "damageCalculationControlItem";
            this.damageCalculationControlItem.Size = new System.Drawing.Size(553, 147);
            this.damageCalculationControlItem.TabIndex = 29;
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemName.Location = new System.Drawing.Point(7, 21);
            this.textBoxItemName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(230, 23);
            this.textBoxItemName.TabIndex = 10;
            // 
            // targetDataControlItem
            // 
            this.targetDataControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetDataControlItem.Location = new System.Drawing.Point(7, 310);
            this.targetDataControlItem.Name = "targetDataControlItem";
            this.targetDataControlItem.Size = new System.Drawing.Size(339, 125);
            this.targetDataControlItem.TabIndex = 30;
            // 
            // labelItemDescription
            // 
            this.labelItemDescription.AutoSize = true;
            this.labelItemDescription.Location = new System.Drawing.Point(7, 47);
            this.labelItemDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItemDescription.Name = "labelItemDescription";
            this.labelItemDescription.Size = new System.Drawing.Size(70, 15);
            this.labelItemDescription.TabIndex = 11;
            this.labelItemDescription.Text = "Description:";
            // 
            // textBoxItemDescription
            // 
            this.textBoxItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemDescription.Location = new System.Drawing.Point(7, 65);
            this.textBoxItemDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxItemDescription.Name = "textBoxItemDescription";
            this.textBoxItemDescription.Size = new System.Drawing.Size(556, 23);
            this.textBoxItemDescription.TabIndex = 12;
            // 
            // comboBoxItemAttackEffectID
            // 
            this.comboBoxItemAttackEffectID.FormattingEnabled = true;
            this.comboBoxItemAttackEffectID.Location = new System.Drawing.Point(163, 109);
            this.comboBoxItemAttackEffectID.Name = "comboBoxItemAttackEffectID";
            this.comboBoxItemAttackEffectID.Size = new System.Drawing.Size(126, 23);
            this.comboBoxItemAttackEffectID.TabIndex = 28;
            // 
            // labelItemCamMovementID
            // 
            this.labelItemCamMovementID.AutoSize = true;
            this.labelItemCamMovementID.Location = new System.Drawing.Point(7, 91);
            this.labelItemCamMovementID.Name = "labelItemCamMovementID";
            this.labelItemCamMovementID.Size = new System.Drawing.Size(126, 15);
            this.labelItemCamMovementID.TabIndex = 25;
            this.labelItemCamMovementID.Text = "Camera movement ID:";
            // 
            // labelItemAttackEffectID
            // 
            this.labelItemAttackEffectID.AutoSize = true;
            this.labelItemAttackEffectID.Location = new System.Drawing.Point(163, 91);
            this.labelItemAttackEffectID.Name = "labelItemAttackEffectID";
            this.labelItemAttackEffectID.Size = new System.Drawing.Size(91, 15);
            this.labelItemAttackEffectID.TabIndex = 27;
            this.labelItemAttackEffectID.Text = "Attack effect ID:";
            // 
            // comboBoxItemCamMovementID
            // 
            this.comboBoxItemCamMovementID.FormattingEnabled = true;
            this.comboBoxItemCamMovementID.Location = new System.Drawing.Point(7, 109);
            this.comboBoxItemCamMovementID.Name = "comboBoxItemCamMovementID";
            this.comboBoxItemCamMovementID.Size = new System.Drawing.Size(150, 23);
            this.comboBoxItemCamMovementID.TabIndex = 26;
            // 
            // tabPageItems2
            // 
            this.tabPageItems2.Controls.Add(this.comboBoxStatusChange);
            this.tabPageItems2.Controls.Add(this.labelItemStatusChange);
            this.tabPageItems2.Controls.Add(this.statusesControlItem);
            this.tabPageItems2.Controls.Add(this.elementsControlItem);
            this.tabPageItems2.Location = new System.Drawing.Point(4, 24);
            this.tabPageItems2.Name = "tabPageItems2";
            this.tabPageItems2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItems2.Size = new System.Drawing.Size(570, 441);
            this.tabPageItems2.TabIndex = 1;
            this.tabPageItems2.Text = "Page 2";
            this.tabPageItems2.UseVisualStyleBackColor = true;
            // 
            // comboBoxStatusChange
            // 
            this.comboBoxStatusChange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusChange.FormattingEnabled = true;
            this.comboBoxStatusChange.Location = new System.Drawing.Point(6, 363);
            this.comboBoxStatusChange.Name = "comboBoxStatusChange";
            this.comboBoxStatusChange.Size = new System.Drawing.Size(185, 23);
            this.comboBoxStatusChange.TabIndex = 33;
            // 
            // labelItemStatusChange
            // 
            this.labelItemStatusChange.AutoSize = true;
            this.labelItemStatusChange.Location = new System.Drawing.Point(6, 345);
            this.labelItemStatusChange.Name = "labelItemStatusChange";
            this.labelItemStatusChange.Size = new System.Drawing.Size(84, 15);
            this.labelItemStatusChange.TabIndex = 32;
            this.labelItemStatusChange.Text = "Status change:";
            // 
            // statusesControlItem
            // 
            this.statusesControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusesControlItem.FullList = true;
            this.statusesControlItem.GroupBoxText = "Inflicts/cures status...";
            this.statusesControlItem.Location = new System.Drawing.Point(6, 142);
            this.statusesControlItem.MinimumSize = new System.Drawing.Size(500, 200);
            this.statusesControlItem.Name = "statusesControlItem";
            this.statusesControlItem.Size = new System.Drawing.Size(558, 200);
            this.statusesControlItem.TabIndex = 31;
            // 
            // elementsControlItem
            // 
            this.elementsControlItem.Location = new System.Drawing.Point(6, 6);
            this.elementsControlItem.MinimumSize = new System.Drawing.Size(370, 130);
            this.elementsControlItem.Name = "elementsControlItem";
            this.elementsControlItem.Size = new System.Drawing.Size(370, 130);
            this.elementsControlItem.TabIndex = 30;
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
            this.tabPageWeaponData.Controls.Add(this.tabControlWeapons);
            this.tabPageWeaponData.Controls.Add(this.listBoxWeapons);
            this.tabPageWeaponData.Location = new System.Drawing.Point(4, 24);
            this.tabPageWeaponData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageWeaponData.Name = "tabPageWeaponData";
            this.tabPageWeaponData.Size = new System.Drawing.Size(776, 533);
            this.tabPageWeaponData.TabIndex = 4;
            this.tabPageWeaponData.Text = "Weapons";
            this.tabPageWeaponData.UseVisualStyleBackColor = true;
            // 
            // tabControlWeapons
            // 
            this.tabControlWeapons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlWeapons.Controls.Add(this.tabPageWeapon1);
            this.tabControlWeapons.Controls.Add(this.tabPageWeapon2);
            this.tabControlWeapons.Location = new System.Drawing.Point(190, 13);
            this.tabControlWeapons.Multiline = true;
            this.tabControlWeapons.Name = "tabControlWeapons";
            this.tabControlWeapons.SelectedIndex = 0;
            this.tabControlWeapons.Size = new System.Drawing.Size(578, 469);
            this.tabControlWeapons.TabIndex = 27;
            // 
            // tabPageWeapon1
            // 
            this.tabPageWeapon1.Controls.Add(this.numericWeaponCritChance);
            this.tabPageWeapon1.Controls.Add(this.numericWeaponHitChance);
            this.tabPageWeapon1.Controls.Add(this.elementsControlWeapon);
            this.tabPageWeapon1.Controls.Add(this.comboBoxWeaponStatus);
            this.tabPageWeapon1.Controls.Add(this.statIncreaseControlWeapon);
            this.tabPageWeapon1.Controls.Add(this.numericWeaponAnimationIndex);
            this.tabPageWeapon1.Controls.Add(this.labelWeaponAnimationIndex);
            this.tabPageWeapon1.Controls.Add(this.labelWeaponStatus);
            this.tabPageWeapon1.Controls.Add(this.numericWeaponModelIndex);
            this.tabPageWeapon1.Controls.Add(this.labelWeaponModelIndex);
            this.tabPageWeapon1.Controls.Add(this.groupBoxWeaponMateriaSlots);
            this.tabPageWeapon1.Controls.Add(this.labelWeaponCritChance);
            this.tabPageWeapon1.Controls.Add(this.labelWeaponHitChance);
            this.tabPageWeapon1.Controls.Add(this.textBoxWeaponName);
            this.tabPageWeapon1.Controls.Add(this.labelWeaponName);
            this.tabPageWeapon1.Controls.Add(this.labelWeaponDescription);
            this.tabPageWeapon1.Controls.Add(this.textBoxWeaponDescription);
            this.tabPageWeapon1.Location = new System.Drawing.Point(4, 24);
            this.tabPageWeapon1.Name = "tabPageWeapon1";
            this.tabPageWeapon1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeapon1.Size = new System.Drawing.Size(570, 441);
            this.tabPageWeapon1.TabIndex = 0;
            this.tabPageWeapon1.Text = "Page 1";
            this.tabPageWeapon1.UseVisualStyleBackColor = true;
            // 
            // numericWeaponCritChance
            // 
            this.numericWeaponCritChance.Location = new System.Drawing.Point(113, 109);
            this.numericWeaponCritChance.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericWeaponCritChance.Name = "numericWeaponCritChance";
            this.numericWeaponCritChance.Size = new System.Drawing.Size(100, 23);
            this.numericWeaponCritChance.TabIndex = 36;
            // 
            // numericWeaponHitChance
            // 
            this.numericWeaponHitChance.Location = new System.Drawing.Point(7, 109);
            this.numericWeaponHitChance.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericWeaponHitChance.Name = "numericWeaponHitChance";
            this.numericWeaponHitChance.Size = new System.Drawing.Size(100, 23);
            this.numericWeaponHitChance.TabIndex = 35;
            // 
            // elementsControlWeapon
            // 
            this.elementsControlWeapon.Location = new System.Drawing.Point(7, 305);
            this.elementsControlWeapon.MinimumSize = new System.Drawing.Size(370, 130);
            this.elementsControlWeapon.Name = "elementsControlWeapon";
            this.elementsControlWeapon.Size = new System.Drawing.Size(370, 130);
            this.elementsControlWeapon.TabIndex = 29;
            // 
            // comboBoxWeaponStatus
            // 
            this.comboBoxWeaponStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeaponStatus.FormattingEnabled = true;
            this.comboBoxWeaponStatus.Location = new System.Drawing.Point(383, 323);
            this.comboBoxWeaponStatus.Name = "comboBoxWeaponStatus";
            this.comboBoxWeaponStatus.Size = new System.Drawing.Size(177, 23);
            this.comboBoxWeaponStatus.TabIndex = 28;
            // 
            // statIncreaseControlWeapon
            // 
            this.statIncreaseControlWeapon.Count = 4;
            this.statIncreaseControlWeapon.Location = new System.Drawing.Point(7, 157);
            this.statIncreaseControlWeapon.MinimumSize = new System.Drawing.Size(250, 142);
            this.statIncreaseControlWeapon.Name = "statIncreaseControlWeapon";
            this.statIncreaseControlWeapon.Size = new System.Drawing.Size(327, 142);
            this.statIncreaseControlWeapon.TabIndex = 34;
            // 
            // numericWeaponAnimationIndex
            // 
            this.numericWeaponAnimationIndex.Location = new System.Drawing.Point(325, 109);
            this.numericWeaponAnimationIndex.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericWeaponAnimationIndex.Name = "numericWeaponAnimationIndex";
            this.numericWeaponAnimationIndex.Size = new System.Drawing.Size(100, 23);
            this.numericWeaponAnimationIndex.TabIndex = 33;
            // 
            // labelWeaponAnimationIndex
            // 
            this.labelWeaponAnimationIndex.AutoSize = true;
            this.labelWeaponAnimationIndex.Location = new System.Drawing.Point(325, 91);
            this.labelWeaponAnimationIndex.Name = "labelWeaponAnimationIndex";
            this.labelWeaponAnimationIndex.Size = new System.Drawing.Size(98, 15);
            this.labelWeaponAnimationIndex.TabIndex = 32;
            this.labelWeaponAnimationIndex.Text = "Animation index:";
            // 
            // labelWeaponStatus
            // 
            this.labelWeaponStatus.AutoSize = true;
            this.labelWeaponStatus.Location = new System.Drawing.Point(383, 305);
            this.labelWeaponStatus.Name = "labelWeaponStatus";
            this.labelWeaponStatus.Size = new System.Drawing.Size(79, 15);
            this.labelWeaponStatus.TabIndex = 27;
            this.labelWeaponStatus.Text = "Inflicts status:";
            // 
            // numericWeaponModelIndex
            // 
            this.numericWeaponModelIndex.Location = new System.Drawing.Point(219, 109);
            this.numericWeaponModelIndex.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericWeaponModelIndex.Name = "numericWeaponModelIndex";
            this.numericWeaponModelIndex.Size = new System.Drawing.Size(100, 23);
            this.numericWeaponModelIndex.TabIndex = 31;
            // 
            // labelWeaponModelIndex
            // 
            this.labelWeaponModelIndex.AutoSize = true;
            this.labelWeaponModelIndex.Location = new System.Drawing.Point(219, 91);
            this.labelWeaponModelIndex.Name = "labelWeaponModelIndex";
            this.labelWeaponModelIndex.Size = new System.Drawing.Size(76, 15);
            this.labelWeaponModelIndex.TabIndex = 30;
            this.labelWeaponModelIndex.Text = "Model index:";
            // 
            // groupBoxWeaponMateriaSlots
            // 
            this.groupBoxWeaponMateriaSlots.Controls.Add(this.labelWeaponMateriaGrowth);
            this.groupBoxWeaponMateriaSlots.Controls.Add(this.materiaSlotSelectorWeapon);
            this.groupBoxWeaponMateriaSlots.Controls.Add(this.comboBoxWeaponMateriaGrowth);
            this.groupBoxWeaponMateriaSlots.Location = new System.Drawing.Point(341, 188);
            this.groupBoxWeaponMateriaSlots.Name = "groupBoxWeaponMateriaSlots";
            this.groupBoxWeaponMateriaSlots.Size = new System.Drawing.Size(223, 111);
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
            this.materiaSlotSelectorWeapon.Size = new System.Drawing.Size(211, 35);
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
            this.comboBoxWeaponMateriaGrowth.Size = new System.Drawing.Size(211, 23);
            this.comboBoxWeaponMateriaGrowth.TabIndex = 2;
            this.comboBoxWeaponMateriaGrowth.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeaponMateriaGrowth_SelectedIndexChanged);
            // 
            // labelWeaponCritChance
            // 
            this.labelWeaponCritChance.AutoSize = true;
            this.labelWeaponCritChance.Location = new System.Drawing.Point(113, 91);
            this.labelWeaponCritChance.Name = "labelWeaponCritChance";
            this.labelWeaponCritChance.Size = new System.Drawing.Size(39, 15);
            this.labelWeaponCritChance.TabIndex = 23;
            this.labelWeaponCritChance.Text = "Crit%:";
            // 
            // labelWeaponHitChance
            // 
            this.labelWeaponHitChance.AutoSize = true;
            this.labelWeaponHitChance.Location = new System.Drawing.Point(7, 91);
            this.labelWeaponHitChance.Name = "labelWeaponHitChance";
            this.labelWeaponHitChance.Size = new System.Drawing.Size(36, 15);
            this.labelWeaponHitChance.TabIndex = 21;
            this.labelWeaponHitChance.Text = "Hit%:";
            // 
            // textBoxWeaponName
            // 
            this.textBoxWeaponName.Location = new System.Drawing.Point(7, 21);
            this.textBoxWeaponName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxWeaponName.Name = "textBoxWeaponName";
            this.textBoxWeaponName.Size = new System.Drawing.Size(230, 23);
            this.textBoxWeaponName.TabIndex = 10;
            // 
            // labelWeaponName
            // 
            this.labelWeaponName.AutoSize = true;
            this.labelWeaponName.Location = new System.Drawing.Point(7, 3);
            this.labelWeaponName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWeaponName.Name = "labelWeaponName";
            this.labelWeaponName.Size = new System.Drawing.Size(42, 15);
            this.labelWeaponName.TabIndex = 9;
            this.labelWeaponName.Text = "Name:";
            // 
            // labelWeaponDescription
            // 
            this.labelWeaponDescription.AutoSize = true;
            this.labelWeaponDescription.Location = new System.Drawing.Point(7, 47);
            this.labelWeaponDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWeaponDescription.Name = "labelWeaponDescription";
            this.labelWeaponDescription.Size = new System.Drawing.Size(70, 15);
            this.labelWeaponDescription.TabIndex = 11;
            this.labelWeaponDescription.Text = "Description:";
            // 
            // textBoxWeaponDescription
            // 
            this.textBoxWeaponDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWeaponDescription.Location = new System.Drawing.Point(7, 65);
            this.textBoxWeaponDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxWeaponDescription.Name = "textBoxWeaponDescription";
            this.textBoxWeaponDescription.Size = new System.Drawing.Size(556, 23);
            this.textBoxWeaponDescription.TabIndex = 12;
            // 
            // tabPageWeapon2
            // 
            this.tabPageWeapon2.Controls.Add(this.targetDataControlWeapon);
            this.tabPageWeapon2.Controls.Add(this.damageCalculationControlWeapon);
            this.tabPageWeapon2.Controls.Add(this.equipableListWeapon);
            this.tabPageWeapon2.Controls.Add(this.itemRestrictionsWeapon);
            this.tabPageWeapon2.Location = new System.Drawing.Point(4, 24);
            this.tabPageWeapon2.Name = "tabPageWeapon2";
            this.tabPageWeapon2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeapon2.Size = new System.Drawing.Size(570, 441);
            this.tabPageWeapon2.TabIndex = 1;
            this.tabPageWeapon2.Text = "Page 2";
            this.tabPageWeapon2.UseVisualStyleBackColor = true;
            // 
            // targetDataControlWeapon
            // 
            this.targetDataControlWeapon.Location = new System.Drawing.Point(6, 156);
            this.targetDataControlWeapon.Name = "targetDataControlWeapon";
            this.targetDataControlWeapon.Size = new System.Drawing.Size(328, 138);
            this.targetDataControlWeapon.TabIndex = 29;
            // 
            // damageCalculationControlWeapon
            // 
            this.damageCalculationControlWeapon.AccuracyCalculation = FF7Scarlet.AccuracyCalculation.NoMiss1;
            this.damageCalculationControlWeapon.ActualValue = ((byte)(0));
            this.damageCalculationControlWeapon.AttackPower = ((byte)(0));
            this.damageCalculationControlWeapon.CanCrit = false;
            this.damageCalculationControlWeapon.DamageFormula = FF7Scarlet.DamageFormulas.NoDamage;
            this.damageCalculationControlWeapon.DamageType = FF7Scarlet.DamageType.Physical;
            this.damageCalculationControlWeapon.Location = new System.Drawing.Point(6, 3);
            this.damageCalculationControlWeapon.Name = "damageCalculationControlWeapon";
            this.damageCalculationControlWeapon.Size = new System.Drawing.Size(553, 147);
            this.damageCalculationControlWeapon.TabIndex = 26;
            // 
            // equipableListWeapon
            // 
            this.equipableListWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equipableListWeapon.Location = new System.Drawing.Point(6, 300);
            this.equipableListWeapon.MinimumSize = new System.Drawing.Size(280, 125);
            this.equipableListWeapon.Name = "equipableListWeapon";
            this.equipableListWeapon.Size = new System.Drawing.Size(328, 125);
            this.equipableListWeapon.TabIndex = 20;
            // 
            // itemRestrictionsWeapon
            // 
            this.itemRestrictionsWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemRestrictionsWeapon.Location = new System.Drawing.Point(340, 300);
            this.itemRestrictionsWeapon.Name = "itemRestrictionsWeapon";
            this.itemRestrictionsWeapon.ShowThrowable = false;
            this.itemRestrictionsWeapon.Size = new System.Drawing.Size(223, 125);
            this.itemRestrictionsWeapon.TabIndex = 25;
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
            this.listBoxWeapons.Size = new System.Drawing.Size(174, 469);
            this.listBoxWeapons.TabIndex = 1;
            this.listBoxWeapons.SelectedIndexChanged += new System.EventHandler(this.listBoxWeapons_SelectedIndexChanged);
            // 
            // tabPageArmorData
            // 
            this.tabPageArmorData.Controls.Add(this.tabControlArmor);
            this.tabPageArmorData.Controls.Add(this.listBoxArmor);
            this.tabPageArmorData.Location = new System.Drawing.Point(4, 24);
            this.tabPageArmorData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageArmorData.Name = "tabPageArmorData";
            this.tabPageArmorData.Size = new System.Drawing.Size(776, 533);
            this.tabPageArmorData.TabIndex = 5;
            this.tabPageArmorData.Text = "Armor";
            this.tabPageArmorData.UseVisualStyleBackColor = true;
            // 
            // tabControlArmor
            // 
            this.tabControlArmor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlArmor.Controls.Add(this.tabPageArmor1);
            this.tabControlArmor.Controls.Add(this.tabPageArmor2);
            this.tabControlArmor.Location = new System.Drawing.Point(190, 13);
            this.tabControlArmor.Name = "tabControlArmor";
            this.tabControlArmor.SelectedIndex = 0;
            this.tabControlArmor.Size = new System.Drawing.Size(578, 469);
            this.tabControlArmor.TabIndex = 34;
            // 
            // tabPageArmor1
            // 
            this.tabPageArmor1.Controls.Add(this.labelArmorElementModifier);
            this.tabPageArmor1.Controls.Add(this.numericArmorMagicDefensePercent);
            this.tabPageArmor1.Controls.Add(this.labelArmorMagicDefensePercent);
            this.tabPageArmor1.Controls.Add(this.numericArmorMagicDefense);
            this.tabPageArmor1.Controls.Add(this.comboBoxArmorElementModifier);
            this.tabPageArmor1.Controls.Add(this.labelArmorMagicDefense);
            this.tabPageArmor1.Controls.Add(this.comboBoxArmorStatus);
            this.tabPageArmor1.Controls.Add(this.numericArmorDefensePercent);
            this.tabPageArmor1.Controls.Add(this.elementsControlArmor);
            this.tabPageArmor1.Controls.Add(this.labelArmorStatus);
            this.tabPageArmor1.Controls.Add(this.labelArmorDefencePercent);
            this.tabPageArmor1.Controls.Add(this.numericArmorDefense);
            this.tabPageArmor1.Controls.Add(this.labelArmorDefense);
            this.tabPageArmor1.Controls.Add(this.statIncreaseControlArmor);
            this.tabPageArmor1.Controls.Add(this.labelArmorName);
            this.tabPageArmor1.Controls.Add(this.textBoxArmorName);
            this.tabPageArmor1.Controls.Add(this.labelArmorDescription);
            this.tabPageArmor1.Controls.Add(this.groupBoxArmorMateriaSlots);
            this.tabPageArmor1.Controls.Add(this.textBoxArmorDescription);
            this.tabPageArmor1.Location = new System.Drawing.Point(4, 24);
            this.tabPageArmor1.Name = "tabPageArmor1";
            this.tabPageArmor1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArmor1.Size = new System.Drawing.Size(570, 441);
            this.tabPageArmor1.TabIndex = 0;
            this.tabPageArmor1.Text = "Page 1";
            this.tabPageArmor1.UseVisualStyleBackColor = true;
            // 
            // labelArmorElementModifier
            // 
            this.labelArmorElementModifier.AutoSize = true;
            this.labelArmorElementModifier.Location = new System.Drawing.Point(382, 305);
            this.labelArmorElementModifier.Name = "labelArmorElementModifier";
            this.labelArmorElementModifier.Size = new System.Drawing.Size(147, 15);
            this.labelArmorElementModifier.TabIndex = 34;
            this.labelArmorElementModifier.Text = "Element damage modifier:";
            // 
            // numericArmorMagicDefensePercent
            // 
            this.numericArmorMagicDefensePercent.Location = new System.Drawing.Point(325, 109);
            this.numericArmorMagicDefensePercent.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericArmorMagicDefensePercent.Name = "numericArmorMagicDefensePercent";
            this.numericArmorMagicDefensePercent.Size = new System.Drawing.Size(100, 23);
            this.numericArmorMagicDefensePercent.TabIndex = 41;
            // 
            // labelArmorMagicDefensePercent
            // 
            this.labelArmorMagicDefensePercent.AutoSize = true;
            this.labelArmorMagicDefensePercent.Location = new System.Drawing.Point(325, 91);
            this.labelArmorMagicDefensePercent.Name = "labelArmorMagicDefensePercent";
            this.labelArmorMagicDefensePercent.Size = new System.Drawing.Size(76, 15);
            this.labelArmorMagicDefensePercent.TabIndex = 40;
            this.labelArmorMagicDefensePercent.Text = "M.Defense%:";
            // 
            // numericArmorMagicDefense
            // 
            this.numericArmorMagicDefense.Location = new System.Drawing.Point(219, 109);
            this.numericArmorMagicDefense.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericArmorMagicDefense.Name = "numericArmorMagicDefense";
            this.numericArmorMagicDefense.Size = new System.Drawing.Size(100, 23);
            this.numericArmorMagicDefense.TabIndex = 39;
            // 
            // comboBoxArmorElementModifier
            // 
            this.comboBoxArmorElementModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArmorElementModifier.FormattingEnabled = true;
            this.comboBoxArmorElementModifier.Location = new System.Drawing.Point(382, 323);
            this.comboBoxArmorElementModifier.Name = "comboBoxArmorElementModifier";
            this.comboBoxArmorElementModifier.Size = new System.Drawing.Size(181, 23);
            this.comboBoxArmorElementModifier.TabIndex = 35;
            // 
            // labelArmorMagicDefense
            // 
            this.labelArmorMagicDefense.AutoSize = true;
            this.labelArmorMagicDefense.Location = new System.Drawing.Point(219, 91);
            this.labelArmorMagicDefense.Name = "labelArmorMagicDefense";
            this.labelArmorMagicDefense.Size = new System.Drawing.Size(66, 15);
            this.labelArmorMagicDefense.TabIndex = 38;
            this.labelArmorMagicDefense.Text = "M.Defense:";
            // 
            // comboBoxArmorStatus
            // 
            this.comboBoxArmorStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArmorStatus.FormattingEnabled = true;
            this.comboBoxArmorStatus.Location = new System.Drawing.Point(382, 367);
            this.comboBoxArmorStatus.Name = "comboBoxArmorStatus";
            this.comboBoxArmorStatus.Size = new System.Drawing.Size(181, 23);
            this.comboBoxArmorStatus.TabIndex = 30;
            // 
            // numericArmorDefensePercent
            // 
            this.numericArmorDefensePercent.Location = new System.Drawing.Point(113, 109);
            this.numericArmorDefensePercent.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericArmorDefensePercent.Name = "numericArmorDefensePercent";
            this.numericArmorDefensePercent.Size = new System.Drawing.Size(100, 23);
            this.numericArmorDefensePercent.TabIndex = 37;
            // 
            // elementsControlArmor
            // 
            this.elementsControlArmor.Location = new System.Drawing.Point(7, 305);
            this.elementsControlArmor.MinimumSize = new System.Drawing.Size(370, 130);
            this.elementsControlArmor.Name = "elementsControlArmor";
            this.elementsControlArmor.Size = new System.Drawing.Size(370, 130);
            this.elementsControlArmor.TabIndex = 33;
            // 
            // labelArmorStatus
            // 
            this.labelArmorStatus.AutoSize = true;
            this.labelArmorStatus.Location = new System.Drawing.Point(382, 349);
            this.labelArmorStatus.Name = "labelArmorStatus";
            this.labelArmorStatus.Size = new System.Drawing.Size(87, 15);
            this.labelArmorStatus.TabIndex = 29;
            this.labelArmorStatus.Text = "Protects status:";
            // 
            // labelArmorDefencePercent
            // 
            this.labelArmorDefencePercent.AutoSize = true;
            this.labelArmorDefencePercent.Location = new System.Drawing.Point(113, 91);
            this.labelArmorDefencePercent.Name = "labelArmorDefencePercent";
            this.labelArmorDefencePercent.Size = new System.Drawing.Size(62, 15);
            this.labelArmorDefencePercent.TabIndex = 36;
            this.labelArmorDefencePercent.Text = "Defense%:";
            // 
            // numericArmorDefense
            // 
            this.numericArmorDefense.Location = new System.Drawing.Point(7, 109);
            this.numericArmorDefense.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericArmorDefense.Name = "numericArmorDefense";
            this.numericArmorDefense.Size = new System.Drawing.Size(100, 23);
            this.numericArmorDefense.TabIndex = 35;
            // 
            // labelArmorDefense
            // 
            this.labelArmorDefense.AutoSize = true;
            this.labelArmorDefense.Location = new System.Drawing.Point(7, 91);
            this.labelArmorDefense.Name = "labelArmorDefense";
            this.labelArmorDefense.Size = new System.Drawing.Size(52, 15);
            this.labelArmorDefense.TabIndex = 34;
            this.labelArmorDefense.Text = "Defense:";
            // 
            // statIncreaseControlArmor
            // 
            this.statIncreaseControlArmor.Count = 4;
            this.statIncreaseControlArmor.Location = new System.Drawing.Point(7, 157);
            this.statIncreaseControlArmor.MinimumSize = new System.Drawing.Size(250, 142);
            this.statIncreaseControlArmor.Name = "statIncreaseControlArmor";
            this.statIncreaseControlArmor.Size = new System.Drawing.Size(327, 142);
            this.statIncreaseControlArmor.TabIndex = 33;
            // 
            // labelArmorName
            // 
            this.labelArmorName.AutoSize = true;
            this.labelArmorName.Location = new System.Drawing.Point(7, 3);
            this.labelArmorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArmorName.Name = "labelArmorName";
            this.labelArmorName.Size = new System.Drawing.Size(42, 15);
            this.labelArmorName.TabIndex = 9;
            this.labelArmorName.Text = "Name:";
            // 
            // textBoxArmorName
            // 
            this.textBoxArmorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArmorName.Location = new System.Drawing.Point(7, 21);
            this.textBoxArmorName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxArmorName.Name = "textBoxArmorName";
            this.textBoxArmorName.Size = new System.Drawing.Size(230, 23);
            this.textBoxArmorName.TabIndex = 10;
            // 
            // labelArmorDescription
            // 
            this.labelArmorDescription.AutoSize = true;
            this.labelArmorDescription.Location = new System.Drawing.Point(7, 47);
            this.labelArmorDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArmorDescription.Name = "labelArmorDescription";
            this.labelArmorDescription.Size = new System.Drawing.Size(70, 15);
            this.labelArmorDescription.TabIndex = 11;
            this.labelArmorDescription.Text = "Description:";
            // 
            // groupBoxArmorMateriaSlots
            // 
            this.groupBoxArmorMateriaSlots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxArmorMateriaSlots.Controls.Add(this.labelArmorMateriaGrowth);
            this.groupBoxArmorMateriaSlots.Controls.Add(this.materiaSlotSelectorArmor);
            this.groupBoxArmorMateriaSlots.Controls.Add(this.comboBoxArmorMateriaGrowth);
            this.groupBoxArmorMateriaSlots.Location = new System.Drawing.Point(341, 188);
            this.groupBoxArmorMateriaSlots.Name = "groupBoxArmorMateriaSlots";
            this.groupBoxArmorMateriaSlots.Size = new System.Drawing.Size(223, 111);
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
            this.materiaSlotSelectorArmor.Size = new System.Drawing.Size(211, 35);
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
            this.comboBoxArmorMateriaGrowth.Size = new System.Drawing.Size(211, 23);
            this.comboBoxArmorMateriaGrowth.TabIndex = 2;
            this.comboBoxArmorMateriaGrowth.SelectedIndexChanged += new System.EventHandler(this.comboBoxArmorMateriaGrowth_SelectedIndexChanged);
            // 
            // textBoxArmorDescription
            // 
            this.textBoxArmorDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArmorDescription.Location = new System.Drawing.Point(7, 65);
            this.textBoxArmorDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxArmorDescription.Name = "textBoxArmorDescription";
            this.textBoxArmorDescription.Size = new System.Drawing.Size(556, 23);
            this.textBoxArmorDescription.TabIndex = 12;
            // 
            // tabPageArmor2
            // 
            this.tabPageArmor2.Controls.Add(this.itemRestrictionsArmor);
            this.tabPageArmor2.Controls.Add(this.equipableListArmor);
            this.tabPageArmor2.Location = new System.Drawing.Point(4, 24);
            this.tabPageArmor2.Name = "tabPageArmor2";
            this.tabPageArmor2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArmor2.Size = new System.Drawing.Size(570, 441);
            this.tabPageArmor2.TabIndex = 1;
            this.tabPageArmor2.Text = "Page 2";
            this.tabPageArmor2.UseVisualStyleBackColor = true;
            // 
            // itemRestrictionsArmor
            // 
            this.itemRestrictionsArmor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemRestrictionsArmor.Location = new System.Drawing.Point(339, 6);
            this.itemRestrictionsArmor.Name = "itemRestrictionsArmor";
            this.itemRestrictionsArmor.ShowThrowable = false;
            this.itemRestrictionsArmor.Size = new System.Drawing.Size(224, 125);
            this.itemRestrictionsArmor.TabIndex = 32;
            // 
            // equipableListArmor
            // 
            this.equipableListArmor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equipableListArmor.Location = new System.Drawing.Point(6, 6);
            this.equipableListArmor.MinimumSize = new System.Drawing.Size(280, 125);
            this.equipableListArmor.Name = "equipableListArmor";
            this.equipableListArmor.Size = new System.Drawing.Size(327, 125);
            this.equipableListArmor.TabIndex = 31;
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
            this.listBoxArmor.Size = new System.Drawing.Size(174, 469);
            this.listBoxArmor.TabIndex = 2;
            this.listBoxArmor.SelectedIndexChanged += new System.EventHandler(this.listBoxArmor_SelectedIndexChanged);
            // 
            // tabPageAccessoryData
            // 
            this.tabPageAccessoryData.Controls.Add(this.tabControlAccessories);
            this.tabPageAccessoryData.Controls.Add(this.listBoxAccessories);
            this.tabPageAccessoryData.Location = new System.Drawing.Point(4, 24);
            this.tabPageAccessoryData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageAccessoryData.Name = "tabPageAccessoryData";
            this.tabPageAccessoryData.Size = new System.Drawing.Size(776, 533);
            this.tabPageAccessoryData.TabIndex = 6;
            this.tabPageAccessoryData.Text = "Accessories";
            this.tabPageAccessoryData.UseVisualStyleBackColor = true;
            // 
            // tabControlAccessories
            // 
            this.tabControlAccessories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAccessories.Controls.Add(this.tabPageAccessory1);
            this.tabControlAccessories.Controls.Add(this.tabPageAccessory2);
            this.tabControlAccessories.Location = new System.Drawing.Point(190, 13);
            this.tabControlAccessories.Name = "tabControlAccessories";
            this.tabControlAccessories.SelectedIndex = 0;
            this.tabControlAccessories.Size = new System.Drawing.Size(578, 469);
            this.tabControlAccessories.TabIndex = 25;
            // 
            // tabPageAccessory1
            // 
            this.tabPageAccessory1.Controls.Add(this.labelAccessoryElementModifier);
            this.tabPageAccessory1.Controls.Add(this.comboBoxAccessoryElementModifier);
            this.tabPageAccessory1.Controls.Add(this.statusesControlAccessory);
            this.tabPageAccessory1.Controls.Add(this.elementsControlAccessory);
            this.tabPageAccessory1.Controls.Add(this.statIncreaseControlAccessory);
            this.tabPageAccessory1.Controls.Add(this.labelAccessoryName);
            this.tabPageAccessory1.Controls.Add(this.textBoxAccessoryName);
            this.tabPageAccessory1.Controls.Add(this.labelAccessoryDescription);
            this.tabPageAccessory1.Controls.Add(this.textBoxAccessoryDescription);
            this.tabPageAccessory1.Location = new System.Drawing.Point(4, 24);
            this.tabPageAccessory1.Name = "tabPageAccessory1";
            this.tabPageAccessory1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccessory1.Size = new System.Drawing.Size(570, 441);
            this.tabPageAccessory1.TabIndex = 0;
            this.tabPageAccessory1.Text = "Page 1";
            this.tabPageAccessory1.UseVisualStyleBackColor = true;
            // 
            // labelAccessoryElementModifier
            // 
            this.labelAccessoryElementModifier.AutoSize = true;
            this.labelAccessoryElementModifier.Location = new System.Drawing.Point(383, 94);
            this.labelAccessoryElementModifier.Name = "labelAccessoryElementModifier";
            this.labelAccessoryElementModifier.Size = new System.Drawing.Size(147, 15);
            this.labelAccessoryElementModifier.TabIndex = 36;
            this.labelAccessoryElementModifier.Text = "Element damage modifier:";
            // 
            // comboBoxAccessoryElementModifier
            // 
            this.comboBoxAccessoryElementModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccessoryElementModifier.FormattingEnabled = true;
            this.comboBoxAccessoryElementModifier.Location = new System.Drawing.Point(383, 112);
            this.comboBoxAccessoryElementModifier.Name = "comboBoxAccessoryElementModifier";
            this.comboBoxAccessoryElementModifier.Size = new System.Drawing.Size(180, 23);
            this.comboBoxAccessoryElementModifier.TabIndex = 37;
            // 
            // statusesControlAccessory
            // 
            this.statusesControlAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusesControlAccessory.FullList = true;
            this.statusesControlAccessory.GroupBoxText = "Protects from status...";
            this.statusesControlAccessory.Location = new System.Drawing.Point(7, 235);
            this.statusesControlAccessory.MinimumSize = new System.Drawing.Size(500, 200);
            this.statusesControlAccessory.Name = "statusesControlAccessory";
            this.statusesControlAccessory.Size = new System.Drawing.Size(556, 200);
            this.statusesControlAccessory.TabIndex = 23;
            // 
            // elementsControlAccessory
            // 
            this.elementsControlAccessory.Location = new System.Drawing.Point(7, 94);
            this.elementsControlAccessory.MinimumSize = new System.Drawing.Size(370, 130);
            this.elementsControlAccessory.Name = "elementsControlAccessory";
            this.elementsControlAccessory.Size = new System.Drawing.Size(370, 131);
            this.elementsControlAccessory.TabIndex = 26;
            // 
            // statIncreaseControlAccessory
            // 
            this.statIncreaseControlAccessory.Count = 4;
            this.statIncreaseControlAccessory.Location = new System.Drawing.Point(384, 141);
            this.statIncreaseControlAccessory.Name = "statIncreaseControlAccessory";
            this.statIncreaseControlAccessory.Size = new System.Drawing.Size(179, 84);
            this.statIncreaseControlAccessory.TabIndex = 26;
            // 
            // labelAccessoryName
            // 
            this.labelAccessoryName.AutoSize = true;
            this.labelAccessoryName.Location = new System.Drawing.Point(7, 3);
            this.labelAccessoryName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccessoryName.Name = "labelAccessoryName";
            this.labelAccessoryName.Size = new System.Drawing.Size(42, 15);
            this.labelAccessoryName.TabIndex = 9;
            this.labelAccessoryName.Text = "Name:";
            // 
            // textBoxAccessoryName
            // 
            this.textBoxAccessoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAccessoryName.Location = new System.Drawing.Point(7, 21);
            this.textBoxAccessoryName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAccessoryName.Name = "textBoxAccessoryName";
            this.textBoxAccessoryName.Size = new System.Drawing.Size(230, 23);
            this.textBoxAccessoryName.TabIndex = 10;
            // 
            // labelAccessoryDescription
            // 
            this.labelAccessoryDescription.AutoSize = true;
            this.labelAccessoryDescription.Location = new System.Drawing.Point(7, 47);
            this.labelAccessoryDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccessoryDescription.Name = "labelAccessoryDescription";
            this.labelAccessoryDescription.Size = new System.Drawing.Size(70, 15);
            this.labelAccessoryDescription.TabIndex = 11;
            this.labelAccessoryDescription.Text = "Description:";
            // 
            // textBoxAccessoryDescription
            // 
            this.textBoxAccessoryDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAccessoryDescription.Location = new System.Drawing.Point(7, 65);
            this.textBoxAccessoryDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAccessoryDescription.Name = "textBoxAccessoryDescription";
            this.textBoxAccessoryDescription.Size = new System.Drawing.Size(556, 23);
            this.textBoxAccessoryDescription.TabIndex = 12;
            // 
            // tabPageAccessory2
            // 
            this.tabPageAccessory2.Controls.Add(this.comboBoxAccessorySpecialEffects);
            this.tabPageAccessory2.Controls.Add(this.labelAccessorySpecialEffects);
            this.tabPageAccessory2.Controls.Add(this.equipableListAccessory);
            this.tabPageAccessory2.Controls.Add(this.itemRestrictionsAccessory);
            this.tabPageAccessory2.Location = new System.Drawing.Point(4, 24);
            this.tabPageAccessory2.Name = "tabPageAccessory2";
            this.tabPageAccessory2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccessory2.Size = new System.Drawing.Size(570, 441);
            this.tabPageAccessory2.TabIndex = 1;
            this.tabPageAccessory2.Text = "Page 2";
            this.tabPageAccessory2.UseVisualStyleBackColor = true;
            // 
            // comboBoxAccessorySpecialEffects
            // 
            this.comboBoxAccessorySpecialEffects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccessorySpecialEffects.FormattingEnabled = true;
            this.comboBoxAccessorySpecialEffects.Items.AddRange(new object[] {
            "None",
            "Start battle with Haste",
            "Start battle with Berserk",
            "All stats increased, but apply Death Sentence",
            "Start battle with Reflect",
            "Increase stealing rate",
            "Increase manipulation rate",
            "Start battle with Barrier+MBarrier"});
            this.comboBoxAccessorySpecialEffects.Location = new System.Drawing.Point(6, 21);
            this.comboBoxAccessorySpecialEffects.Name = "comboBoxAccessorySpecialEffects";
            this.comboBoxAccessorySpecialEffects.Size = new System.Drawing.Size(311, 23);
            this.comboBoxAccessorySpecialEffects.TabIndex = 27;
            // 
            // labelAccessorySpecialEffects
            // 
            this.labelAccessorySpecialEffects.AutoSize = true;
            this.labelAccessorySpecialEffects.Location = new System.Drawing.Point(6, 3);
            this.labelAccessorySpecialEffects.Name = "labelAccessorySpecialEffects";
            this.labelAccessorySpecialEffects.Size = new System.Drawing.Size(80, 15);
            this.labelAccessorySpecialEffects.TabIndex = 26;
            this.labelAccessorySpecialEffects.Text = "Special effect:";
            // 
            // equipableListAccessory
            // 
            this.equipableListAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equipableListAccessory.Location = new System.Drawing.Point(6, 50);
            this.equipableListAccessory.MinimumSize = new System.Drawing.Size(280, 125);
            this.equipableListAccessory.Name = "equipableListAccessory";
            this.equipableListAccessory.Size = new System.Drawing.Size(311, 125);
            this.equipableListAccessory.TabIndex = 24;
            // 
            // itemRestrictionsAccessory
            // 
            this.itemRestrictionsAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemRestrictionsAccessory.Location = new System.Drawing.Point(323, 50);
            this.itemRestrictionsAccessory.Name = "itemRestrictionsAccessory";
            this.itemRestrictionsAccessory.ShowThrowable = false;
            this.itemRestrictionsAccessory.Size = new System.Drawing.Size(240, 125);
            this.itemRestrictionsAccessory.TabIndex = 25;
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
            this.listBoxAccessories.Size = new System.Drawing.Size(174, 469);
            this.listBoxAccessories.TabIndex = 2;
            this.listBoxAccessories.SelectedIndexChanged += new System.EventHandler(this.listBoxAccessories_SelectedIndexChanged);
            // 
            // tabPageMateriaData
            // 
            this.tabPageMateriaData.Controls.Add(this.comboBoxMateriaEquipAttributes);
            this.tabPageMateriaData.Controls.Add(this.labelMateriaEquipAttributes);
            this.tabPageMateriaData.Controls.Add(this.statusesControlMateria);
            this.tabPageMateriaData.Controls.Add(this.comboBoxMateriaSubtype);
            this.tabPageMateriaData.Controls.Add(this.labelMateriaSubtype);
            this.tabPageMateriaData.Controls.Add(this.materiaLevelControl);
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
            // comboBoxMateriaEquipAttributes
            // 
            this.comboBoxMateriaEquipAttributes.FormattingEnabled = true;
            this.comboBoxMateriaEquipAttributes.Location = new System.Drawing.Point(191, 163);
            this.comboBoxMateriaEquipAttributes.Name = "comboBoxMateriaEquipAttributes";
            this.comboBoxMateriaEquipAttributes.Size = new System.Drawing.Size(306, 23);
            this.comboBoxMateriaEquipAttributes.TabIndex = 22;
            // 
            // labelMateriaEquipAttributes
            // 
            this.labelMateriaEquipAttributes.AutoSize = true;
            this.labelMateriaEquipAttributes.Location = new System.Drawing.Point(191, 145);
            this.labelMateriaEquipAttributes.Name = "labelMateriaEquipAttributes";
            this.labelMateriaEquipAttributes.Size = new System.Drawing.Size(93, 15);
            this.labelMateriaEquipAttributes.TabIndex = 21;
            this.labelMateriaEquipAttributes.Text = "Equip attributes:";
            // 
            // statusesControlMateria
            // 
            this.statusesControlMateria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusesControlMateria.FullList = true;
            this.statusesControlMateria.GroupBoxText = "Statuses";
            this.statusesControlMateria.Location = new System.Drawing.Point(190, 282);
            this.statusesControlMateria.MinimumSize = new System.Drawing.Size(380, 200);
            this.statusesControlMateria.Name = "statusesControlMateria";
            this.statusesControlMateria.Size = new System.Drawing.Size(380, 200);
            this.statusesControlMateria.TabIndex = 20;
            // 
            // comboBoxMateriaSubtype
            // 
            this.comboBoxMateriaSubtype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMateriaSubtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateriaSubtype.FormattingEnabled = true;
            this.comboBoxMateriaSubtype.Location = new System.Drawing.Point(503, 119);
            this.comboBoxMateriaSubtype.Name = "comboBoxMateriaSubtype";
            this.comboBoxMateriaSubtype.Size = new System.Drawing.Size(261, 23);
            this.comboBoxMateriaSubtype.TabIndex = 19;
            // 
            // labelMateriaSubtype
            // 
            this.labelMateriaSubtype.AutoSize = true;
            this.labelMateriaSubtype.Location = new System.Drawing.Point(503, 101);
            this.labelMateriaSubtype.Name = "labelMateriaSubtype";
            this.labelMateriaSubtype.Size = new System.Drawing.Size(53, 15);
            this.labelMateriaSubtype.TabIndex = 18;
            this.labelMateriaSubtype.Text = "Subtype:";
            // 
            // materiaLevelControl
            // 
            this.materiaLevelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materiaLevelControl.Location = new System.Drawing.Point(577, 230);
            this.materiaLevelControl.Lvl2APValue = 0;
            this.materiaLevelControl.Lvl3APValue = 0;
            this.materiaLevelControl.Lvl4APValue = 0;
            this.materiaLevelControl.Lvl5APValue = 0;
            this.materiaLevelControl.MaxLevel = 5;
            this.materiaLevelControl.Name = "materiaLevelControl";
            this.materiaLevelControl.Size = new System.Drawing.Size(187, 252);
            this.materiaLevelControl.TabIndex = 17;
            // 
            // comboBoxMateriaElement
            // 
            this.comboBoxMateriaElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateriaElement.FormattingEnabled = true;
            this.comboBoxMateriaElement.Location = new System.Drawing.Point(191, 119);
            this.comboBoxMateriaElement.Name = "comboBoxMateriaElement";
            this.comboBoxMateriaElement.Size = new System.Drawing.Size(150, 23);
            this.comboBoxMateriaElement.TabIndex = 16;
            // 
            // labelMateriaElement
            // 
            this.labelMateriaElement.AutoSize = true;
            this.labelMateriaElement.Location = new System.Drawing.Point(191, 101);
            this.labelMateriaElement.Name = "labelMateriaElement";
            this.labelMateriaElement.Size = new System.Drawing.Size(53, 15);
            this.labelMateriaElement.TabIndex = 15;
            this.labelMateriaElement.Text = "Element:";
            // 
            // comboBoxMateriaType
            // 
            this.comboBoxMateriaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateriaType.FormattingEnabled = true;
            this.comboBoxMateriaType.Location = new System.Drawing.Point(347, 119);
            this.comboBoxMateriaType.Name = "comboBoxMateriaType";
            this.comboBoxMateriaType.Size = new System.Drawing.Size(150, 23);
            this.comboBoxMateriaType.TabIndex = 14;
            // 
            // labelMateriaType
            // 
            this.labelMateriaType.AutoSize = true;
            this.labelMateriaType.Location = new System.Drawing.Point(347, 101);
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
            this.listBoxMateria.Size = new System.Drawing.Size(174, 469);
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
            this.listBoxKeyItems.Size = new System.Drawing.Size(174, 469);
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
            this.tabControlItems.ResumeLayout(false);
            this.tabPageItems1.ResumeLayout(false);
            this.tabPageItems1.PerformLayout();
            this.tabPageItems2.ResumeLayout(false);
            this.tabPageItems2.PerformLayout();
            this.tabPageWeaponData.ResumeLayout(false);
            this.tabControlWeapons.ResumeLayout(false);
            this.tabPageWeapon1.ResumeLayout(false);
            this.tabPageWeapon1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeaponCritChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeaponHitChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeaponAnimationIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeaponModelIndex)).EndInit();
            this.groupBoxWeaponMateriaSlots.ResumeLayout(false);
            this.groupBoxWeaponMateriaSlots.PerformLayout();
            this.tabPageWeapon2.ResumeLayout(false);
            this.tabPageArmorData.ResumeLayout(false);
            this.tabControlArmor.ResumeLayout(false);
            this.tabPageArmor1.ResumeLayout(false);
            this.tabPageArmor1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericArmorMagicDefensePercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericArmorMagicDefense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericArmorDefensePercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericArmorDefense)).EndInit();
            this.groupBoxArmorMateriaSlots.ResumeLayout(false);
            this.groupBoxArmorMateriaSlots.PerformLayout();
            this.tabPageArmor2.ResumeLayout(false);
            this.tabPageAccessoryData.ResumeLayout(false);
            this.tabControlAccessories.ResumeLayout(false);
            this.tabPageAccessory1.ResumeLayout(false);
            this.tabPageAccessory1.PerformLayout();
            this.tabPageAccessory2.ResumeLayout(false);
            this.tabPageAccessory2.PerformLayout();
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
        private ComboBox comboBoxMateriaType;
        private Label labelMateriaType;
        private ComboBox comboBoxMateriaElement;
        private Label labelMateriaElement;
        private GroupBox groupBoxWeaponMateriaSlots;
        private MateriaSlotSelectorControl materiaSlotSelectorWeapon;
        private Label labelWeaponMateriaGrowth;
        private ComboBox comboBoxWeaponMateriaGrowth;
        private GroupBox groupBoxArmorMateriaSlots;
        private Label labelArmorMateriaGrowth;
        private MateriaSlotSelectorControl materiaSlotSelectorArmor;
        private ComboBox comboBoxArmorMateriaGrowth;
        private ComboBox comboBoxItemCamMovementID;
        private Label labelItemCamMovementID;
        private ComboBox comboBoxItemAttackEffectID;
        private Label labelItemAttackEffectID;
        private DamageCalculationControl damageCalculationControlItem;
        private DamageCalculationControl damageCalculationControlWeapon;
        private TabControl tabControlWeapons;
        private TabPage tabPageWeapon1;
        private TabPage tabPageWeapon2;
        private ComboBox comboBoxWeaponStatus;
        private Label labelWeaponStatus;
        private ComboBox comboBoxArmorStatus;
        private Label labelArmorStatus;
        private StatusesControl statusesControlAccessory;
        private EquipableListControl equipableListAccessory;
        private EquipableListControl equipableListArmor;
        private EquipableListControl equipableListWeapon;
        private TargetDataControl targetDataControlItem;
        private TargetDataControl targetDataControlWeapon;
        private TabControl tabControlAccessories;
        private TabPage tabPageAccessory1;
        private TabPage tabPageAccessory2;
        private Label labelWeaponCritChance;
        private Label labelWeaponHitChance;
        private ItemRestrictionsControl itemRestrictionsWeapon;
        private ItemRestrictionsControl itemRestrictionsItem;
        private ItemRestrictionsControl itemRestrictionsArmor;
        private ItemRestrictionsControl itemRestrictionsAccessory;
        private ElementsControl elementsControlWeapon;
        private ElementsControl elementsControlArmor;
        private ElementsControl elementsControlAccessory;
        private TabControl tabControlItems;
        private TabPage tabPageItems1;
        private TabPage tabPageItems2;
        private ElementsControl elementsControlItem;
        private TabControl tabControlArmor;
        private TabPage tabPageArmor1;
        private TabPage tabPageArmor2;
        private StatusesControl statusesControlItem;
        private Label labelWeaponModelIndex;
        private NumericUpDown numericWeaponModelIndex;
        private NumericUpDown numericWeaponAnimationIndex;
        private Label labelWeaponAnimationIndex;
        private StatIncreaseControl statIncreaseControlWeapon;
        private StatIncreaseControl statIncreaseControlArmor;
        private StatIncreaseControl statIncreaseControlAccessory;
        private ComboBox comboBoxStatusChange;
        private Label labelItemStatusChange;
        private Label labelArmorElementModifier;
        private ComboBox comboBoxArmorElementModifier;
        private NumericUpDown numericArmorDefense;
        private Label labelArmorDefense;
        private NumericUpDown numericArmorMagicDefensePercent;
        private Label labelArmorMagicDefensePercent;
        private NumericUpDown numericArmorMagicDefense;
        private Label labelArmorMagicDefense;
        private NumericUpDown numericArmorDefensePercent;
        private Label labelArmorDefencePercent;
        private ComboBox comboBoxAccessorySpecialEffects;
        private Label labelAccessorySpecialEffects;
        private Label labelAccessoryElementModifier;
        private ComboBox comboBoxAccessoryElementModifier;
        private NumericUpDown numericWeaponCritChance;
        private NumericUpDown numericWeaponHitChance;
        private MateriaLevelControl materiaLevelControl;
        private ComboBox comboBoxMateriaSubtype;
        private Label labelMateriaSubtype;
        private StatusesControl statusesControlMateria;
        private Label labelMateriaEquipAttributes;
        private ComboBox comboBoxMateriaEquipAttributes;
    }
}