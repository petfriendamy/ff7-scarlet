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
            this.comboBoxCommandInitialCursorAction = new System.Windows.Forms.ComboBox();
            this.labelCommandInitialCursorAction = new System.Windows.Forms.Label();
            this.targetDataControlCommand = new FF7Scarlet.KernelEditor.Controls.TargetDataControl();
            this.labelCommandCameraMovementIDMulti = new System.Windows.Forms.Label();
            this.comboBoxCommandCamMovementIDMulti = new System.Windows.Forms.ComboBox();
            this.labelCommandCamMovementIDSingle = new System.Windows.Forms.Label();
            this.comboBoxCommandCameraMovementIDSingle = new System.Windows.Forms.ComboBox();
            this.textBoxCommandDescription = new System.Windows.Forms.TextBox();
            this.labelCommandDescription = new System.Windows.Forms.Label();
            this.textBoxCommandName = new System.Windows.Forms.TextBox();
            this.labelCommandName = new System.Windows.Forms.Label();
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.tabPageAttackData = new System.Windows.Forms.TabPage();
            this.tabControlAttacks = new System.Windows.Forms.TabControl();
            this.tabPageAttacks1 = new System.Windows.Forms.TabPage();
            this.specialAttackFlagsControlAttack = new FF7Scarlet.Shared.SpecialAttackFlagsControl();
            this.labelAttackHurtActionIndex = new System.Windows.Forms.Label();
            this.comboBoxAttackHurtActionIndex = new System.Windows.Forms.ComboBox();
            this.labelAttackAttackEffectID = new System.Windows.Forms.Label();
            this.comboBoxAttackAttackEffectID = new System.Windows.Forms.ComboBox();
            this.labelAttackImpactEffectID = new System.Windows.Forms.Label();
            this.comboBoxAttackImpactEffectID = new System.Windows.Forms.ComboBox();
            this.textBoxAttackDescription = new System.Windows.Forms.TextBox();
            this.damageCalculationControlAttack = new FF7Scarlet.KernelEditor.Controls.DamageCalculationControl();
            this.labelAttackCamMovementIDMulti = new System.Windows.Forms.Label();
            this.labelAttackName = new System.Windows.Forms.Label();
            this.comboBoxAttackCamMovementIDMulti = new System.Windows.Forms.ComboBox();
            this.textBoxAttackName = new System.Windows.Forms.TextBox();
            this.labelAttackCamMovementIDSingle = new System.Windows.Forms.Label();
            this.labelAttackDescription = new System.Windows.Forms.Label();
            this.comboBoxAttackCamMovementIDSingle = new System.Windows.Forms.ComboBox();
            this.labelSummonText = new System.Windows.Forms.Label();
            this.numericAttackAttackPercent = new System.Windows.Forms.NumericUpDown();
            this.textBoxSummonText = new System.Windows.Forms.TextBox();
            this.labelAttackAttackPercent = new System.Windows.Forms.Label();
            this.labelAttackMPCost = new System.Windows.Forms.Label();
            this.numericAttackMPCost = new System.Windows.Forms.NumericUpDown();
            this.tabPageAttacks2 = new System.Windows.Forms.TabPage();
            this.groupBoxAttackSpecialActions = new System.Windows.Forms.GroupBox();
            this.buttonAttackSyncAll = new System.Windows.Forms.Button();
            this.checkBoxAttackSyncWithSceneBin = new System.Windows.Forms.CheckBox();
            this.numericAttackStatusChangeChance = new System.Windows.Forms.NumericUpDown();
            this.comboBoxAttackConditionSubMenu = new System.Windows.Forms.ComboBox();
            this.labelAttackStatusChangeChance = new System.Windows.Forms.Label();
            this.comboBoxAttackStatusChange = new System.Windows.Forms.ComboBox();
            this.labelAttackConditionSubMenu = new System.Windows.Forms.Label();
            this.labelAttackStatusChange = new System.Windows.Forms.Label();
            this.statusesControlAttack = new FF7Scarlet.KernelEditor.Controls.StatusesControl();
            this.elementsControlAttack = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            this.listBoxAttacks = new System.Windows.Forms.ListBox();
            this.tabPageBattleData = new System.Windows.Forms.TabPage();
            this.tabPageInitData = new System.Windows.Forms.TabPage();
            this.tabControlInitialData = new System.Windows.Forms.TabControl();
            this.tabPageInitCharacterStats = new System.Windows.Forms.TabPage();
            this.groupBoxCharacterMP = new System.Windows.Forms.GroupBox();
            this.numericCharacterMaxMP = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterMaxMP = new System.Windows.Forms.Label();
            this.numericCharacterBaseMP = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterBaseMP = new System.Windows.Forms.Label();
            this.numericCharacterCurrMP = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterCurrMP = new System.Windows.Forms.Label();
            this.groupBoxCharacterHP = new System.Windows.Forms.GroupBox();
            this.numericCharacterMaxHP = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterMaxHP = new System.Windows.Forms.Label();
            this.numericCharacterBaseHP = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterBaseHP = new System.Windows.Forms.Label();
            this.numericCharacterCurrHP = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterCurrHP = new System.Windows.Forms.Label();
            this.numericCharacterEXPtoNext = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterEXPtoNext = new System.Windows.Forms.Label();
            this.numericCharacterKillCount = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterKillCount = new System.Windows.Forms.Label();
            this.comboBoxCharacterFlags = new System.Windows.Forms.ComboBox();
            this.labelCharacterFlags = new System.Windows.Forms.Label();
            this.characterLimitControl = new FF7Scarlet.KernelEditor.Controls.CharacterLimitControl();
            this.numericCharacterCurrentEXP = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterCurrentEXP = new System.Windows.Forms.Label();
            this.groupBoxCharacterArmor = new System.Windows.Forms.GroupBox();
            this.buttonCharacterArmorChangeMateria = new System.Windows.Forms.Button();
            this.materiaSlotSelectorCharacterArmor = new FF7Scarlet.KernelEditor.Controls.MateriaSlotSelectorControl();
            this.comboBoxCharacterArmor = new System.Windows.Forms.ComboBox();
            this.groupBoxCharacterWeapon = new System.Windows.Forms.GroupBox();
            this.buttonCharacterWeaponChangeMateria = new System.Windows.Forms.Button();
            this.materiaSlotSelectorCharacterWeapon = new FF7Scarlet.KernelEditor.Controls.MateriaSlotSelectorControl();
            this.comboBoxCharacterWeapon = new System.Windows.Forms.ComboBox();
            this.characterStatsControl = new FF7Scarlet.KernelEditor.Controls.CharacterStatsControl();
            this.checkBoxCharacterBackRow = new System.Windows.Forms.CheckBox();
            this.numericCharacterLevel = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterLevel = new System.Windows.Forms.Label();
            this.comboBoxCharacterAccessory = new System.Windows.Forms.ComboBox();
            this.labelCharacterAccessory = new System.Windows.Forms.Label();
            this.numericCharacterID = new System.Windows.Forms.NumericUpDown();
            this.labelCharacterID = new System.Windows.Forms.Label();
            this.textBoxCharacterName = new System.Windows.Forms.TextBox();
            this.labelCharacterName = new System.Windows.Forms.Label();
            this.listBoxInitCharacters = new System.Windows.Forms.ListBox();
            this.tabPageInitInventory = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxInitMateriaStolen = new System.Windows.Forms.ListBox();
            this.buttonInitMateriaStolenEdit = new System.Windows.Forms.Button();
            this.comboBoxInitMateriaStolen = new System.Windows.Forms.ComboBox();
            this.labelInitMateriaStolen = new System.Windows.Forms.Label();
            this.groupBoxInitMateria = new System.Windows.Forms.GroupBox();
            this.buttonInitMateriaEdit = new System.Windows.Forms.Button();
            this.comboBoxInitMateria = new System.Windows.Forms.ComboBox();
            this.labelInitMateria = new System.Windows.Forms.Label();
            this.listBoxInitMateria = new System.Windows.Forms.ListBox();
            this.groupBoxInitInventory = new System.Windows.Forms.GroupBox();
            this.numericInitItemAmount = new System.Windows.Forms.NumericUpDown();
            this.labelInitItemAmount = new System.Windows.Forms.Label();
            this.comboBoxInitItem = new System.Windows.Forms.ComboBox();
            this.labelInitItem = new System.Windows.Forms.Label();
            this.listBoxInitInventory = new System.Windows.Forms.ListBox();
            this.tabPageItemData = new System.Windows.Forms.TabPage();
            this.tabControlItems = new System.Windows.Forms.TabControl();
            this.tabPageItems1 = new System.Windows.Forms.TabPage();
            this.labelItemName = new System.Windows.Forms.Label();
            this.itemRestrictionsItem = new FF7Scarlet.KernelEditor.Controls.ItemRestrictionsControl();
            this.damageCalculationControlItem = new FF7Scarlet.KernelEditor.Controls.DamageCalculationControl();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.targetDataControlItem = new FF7Scarlet.KernelEditor.Controls.TargetDataControl();
            this.labelItemDescription = new System.Windows.Forms.Label();
            this.textBoxItemDescription = new System.Windows.Forms.TextBox();
            this.comboBoxItemAttackEffectID = new System.Windows.Forms.ComboBox();
            this.labelItemCamMovementID = new System.Windows.Forms.Label();
            this.labelItemAttackEffectID = new System.Windows.Forms.Label();
            this.comboBoxItemCamMovementID = new System.Windows.Forms.ComboBox();
            this.tabPageItems2 = new System.Windows.Forms.TabPage();
            this.comboBoxStatusChange = new System.Windows.Forms.ComboBox();
            this.labelItemStatusChange = new System.Windows.Forms.Label();
            this.statusesControlItem = new FF7Scarlet.KernelEditor.Controls.StatusesControl();
            this.elementsControlItem = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            this.tabPageItems3 = new System.Windows.Forms.TabPage();
            this.specialAttackFlagsControlItem = new FF7Scarlet.Shared.SpecialAttackFlagsControl();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.tabPageWeaponData = new System.Windows.Forms.TabPage();
            this.tabControlWeapons = new System.Windows.Forms.TabControl();
            this.tabPageWeapon1 = new System.Windows.Forms.TabPage();
            this.numericWeaponCritChance = new System.Windows.Forms.NumericUpDown();
            this.numericWeaponHitChance = new System.Windows.Forms.NumericUpDown();
            this.elementsControlWeapon = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            this.comboBoxWeaponStatus = new System.Windows.Forms.ComboBox();
            this.statIncreaseControlWeapon = new FF7Scarlet.KernelEditor.Controls.StatIncreaseControl();
            this.numericWeaponAnimationIndex = new System.Windows.Forms.NumericUpDown();
            this.labelWeaponAnimationIndex = new System.Windows.Forms.Label();
            this.labelWeaponStatus = new System.Windows.Forms.Label();
            this.numericWeaponModelIndex = new System.Windows.Forms.NumericUpDown();
            this.labelWeaponModelIndex = new System.Windows.Forms.Label();
            this.groupBoxWeaponMateriaSlots = new System.Windows.Forms.GroupBox();
            this.materiaSlotSelectorWeapon = new FF7Scarlet.KernelEditor.Controls.MateriaSlotSelectorControl();
            this.labelWeaponMateriaGrowth = new System.Windows.Forms.Label();
            this.comboBoxWeaponMateriaGrowth = new System.Windows.Forms.ComboBox();
            this.labelWeaponCritChance = new System.Windows.Forms.Label();
            this.labelWeaponHitChance = new System.Windows.Forms.Label();
            this.textBoxWeaponName = new System.Windows.Forms.TextBox();
            this.labelWeaponName = new System.Windows.Forms.Label();
            this.labelWeaponDescription = new System.Windows.Forms.Label();
            this.textBoxWeaponDescription = new System.Windows.Forms.TextBox();
            this.tabPageWeapon2 = new System.Windows.Forms.TabPage();
            this.groupBoxWeaponSoundIDs = new System.Windows.Forms.GroupBox();
            this.targetDataControlWeapon = new FF7Scarlet.KernelEditor.Controls.TargetDataControl();
            this.damageCalculationControlWeapon = new FF7Scarlet.KernelEditor.Controls.DamageCalculationControl();
            this.equipableListWeapon = new FF7Scarlet.KernelEditor.Controls.EquipableListControl();
            this.itemRestrictionsWeapon = new FF7Scarlet.KernelEditor.Controls.ItemRestrictionsControl();
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
            this.elementsControlArmor = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            this.labelArmorStatus = new System.Windows.Forms.Label();
            this.labelArmorDefencePercent = new System.Windows.Forms.Label();
            this.numericArmorDefense = new System.Windows.Forms.NumericUpDown();
            this.labelArmorDefense = new System.Windows.Forms.Label();
            this.statIncreaseControlArmor = new FF7Scarlet.KernelEditor.Controls.StatIncreaseControl();
            this.labelArmorName = new System.Windows.Forms.Label();
            this.textBoxArmorName = new System.Windows.Forms.TextBox();
            this.labelArmorDescription = new System.Windows.Forms.Label();
            this.groupBoxArmorMateriaSlots = new System.Windows.Forms.GroupBox();
            this.materiaSlotSelectorArmor = new FF7Scarlet.KernelEditor.Controls.MateriaSlotSelectorControl();
            this.labelArmorMateriaGrowth = new System.Windows.Forms.Label();
            this.comboBoxArmorMateriaGrowth = new System.Windows.Forms.ComboBox();
            this.textBoxArmorDescription = new System.Windows.Forms.TextBox();
            this.tabPageArmor2 = new System.Windows.Forms.TabPage();
            this.itemRestrictionsArmor = new FF7Scarlet.KernelEditor.Controls.ItemRestrictionsControl();
            this.equipableListArmor = new FF7Scarlet.KernelEditor.Controls.EquipableListControl();
            this.listBoxArmor = new System.Windows.Forms.ListBox();
            this.tabPageAccessoryData = new System.Windows.Forms.TabPage();
            this.tabControlAccessories = new System.Windows.Forms.TabControl();
            this.tabPageAccessory1 = new System.Windows.Forms.TabPage();
            this.labelAccessoryElementModifier = new System.Windows.Forms.Label();
            this.comboBoxAccessoryElementModifier = new System.Windows.Forms.ComboBox();
            this.statusesControlAccessory = new FF7Scarlet.KernelEditor.Controls.StatusesControl();
            this.elementsControlAccessory = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            this.statIncreaseControlAccessory = new FF7Scarlet.KernelEditor.Controls.StatIncreaseControl();
            this.labelAccessoryName = new System.Windows.Forms.Label();
            this.textBoxAccessoryName = new System.Windows.Forms.TextBox();
            this.labelAccessoryDescription = new System.Windows.Forms.Label();
            this.textBoxAccessoryDescription = new System.Windows.Forms.TextBox();
            this.tabPageAccessory2 = new System.Windows.Forms.TabPage();
            this.comboBoxAccessorySpecialEffects = new System.Windows.Forms.ComboBox();
            this.labelAccessorySpecialEffects = new System.Windows.Forms.Label();
            this.equipableListAccessory = new FF7Scarlet.KernelEditor.Controls.EquipableListControl();
            this.itemRestrictionsAccessory = new FF7Scarlet.KernelEditor.Controls.ItemRestrictionsControl();
            this.listBoxAccessories = new System.Windows.Forms.ListBox();
            this.tabPageMateriaData = new System.Windows.Forms.TabPage();
            this.comboBoxMateriaEquipAttributes = new System.Windows.Forms.ComboBox();
            this.labelMateriaEquipAttributes = new System.Windows.Forms.Label();
            this.statusesControlMateria = new FF7Scarlet.KernelEditor.Controls.StatusesControl();
            this.comboBoxMateriaSubtype = new System.Windows.Forms.ComboBox();
            this.labelMateriaSubtype = new System.Windows.Forms.Label();
            this.materiaLevelControl = new FF7Scarlet.KernelEditor.Controls.MateriaLevelControl();
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
            this.tabControlAttacks.SuspendLayout();
            this.tabPageAttacks1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackAttackPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackMPCost)).BeginInit();
            this.tabPageAttacks2.SuspendLayout();
            this.groupBoxAttackSpecialActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackStatusChangeChance)).BeginInit();
            this.tabPageInitData.SuspendLayout();
            this.tabControlInitialData.SuspendLayout();
            this.tabPageInitCharacterStats.SuspendLayout();
            this.groupBoxCharacterMP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterMaxMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterBaseMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterCurrMP)).BeginInit();
            this.groupBoxCharacterHP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterMaxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterBaseHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterCurrHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterEXPtoNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterKillCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterCurrentEXP)).BeginInit();
            this.groupBoxCharacterArmor.SuspendLayout();
            this.groupBoxCharacterWeapon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterID)).BeginInit();
            this.tabPageInitInventory.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxInitMateria.SuspendLayout();
            this.groupBoxInitInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInitItemAmount)).BeginInit();
            this.tabPageItemData.SuspendLayout();
            this.tabControlItems.SuspendLayout();
            this.tabPageItems1.SuspendLayout();
            this.tabPageItems2.SuspendLayout();
            this.tabPageItems3.SuspendLayout();
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
            this.tabPageCommandData.Controls.Add(this.comboBoxCommandInitialCursorAction);
            this.tabPageCommandData.Controls.Add(this.labelCommandInitialCursorAction);
            this.tabPageCommandData.Controls.Add(this.targetDataControlCommand);
            this.tabPageCommandData.Controls.Add(this.labelCommandCameraMovementIDMulti);
            this.tabPageCommandData.Controls.Add(this.comboBoxCommandCamMovementIDMulti);
            this.tabPageCommandData.Controls.Add(this.labelCommandCamMovementIDSingle);
            this.tabPageCommandData.Controls.Add(this.comboBoxCommandCameraMovementIDSingle);
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
            // comboBoxCommandInitialCursorAction
            // 
            this.comboBoxCommandInitialCursorAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCommandInitialCursorAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCommandInitialCursorAction.FormattingEnabled = true;
            this.comboBoxCommandInitialCursorAction.Location = new System.Drawing.Point(191, 163);
            this.comboBoxCommandInitialCursorAction.Name = "comboBoxCommandInitialCursorAction";
            this.comboBoxCommandInitialCursorAction.Size = new System.Drawing.Size(459, 23);
            this.comboBoxCommandInitialCursorAction.TabIndex = 35;
            // 
            // labelCommandInitialCursorAction
            // 
            this.labelCommandInitialCursorAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCommandInitialCursorAction.AutoSize = true;
            this.labelCommandInitialCursorAction.Location = new System.Drawing.Point(191, 145);
            this.labelCommandInitialCursorAction.Name = "labelCommandInitialCursorAction";
            this.labelCommandInitialCursorAction.Size = new System.Drawing.Size(111, 15);
            this.labelCommandInitialCursorAction.TabIndex = 34;
            this.labelCommandInitialCursorAction.Text = "Initial cursor action:";
            // 
            // targetDataControlCommand
            // 
            this.targetDataControlCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetDataControlCommand.Location = new System.Drawing.Point(190, 192);
            this.targetDataControlCommand.Name = "targetDataControlCommand";
            this.targetDataControlCommand.Size = new System.Drawing.Size(330, 125);
            this.targetDataControlCommand.TabIndex = 33;
            // 
            // labelCommandCameraMovementIDMulti
            // 
            this.labelCommandCameraMovementIDMulti.AutoSize = true;
            this.labelCommandCameraMovementIDMulti.Location = new System.Drawing.Point(423, 101);
            this.labelCommandCameraMovementIDMulti.Name = "labelCommandCameraMovementIDMulti";
            this.labelCommandCameraMovementIDMulti.Size = new System.Drawing.Size(199, 15);
            this.labelCommandCameraMovementIDMulti.TabIndex = 31;
            this.labelCommandCameraMovementIDMulti.Text = "Camera movement ID (multi target):";
            // 
            // comboBoxCommandCamMovementIDMulti
            // 
            this.comboBoxCommandCamMovementIDMulti.FormattingEnabled = true;
            this.comboBoxCommandCamMovementIDMulti.Location = new System.Drawing.Point(423, 119);
            this.comboBoxCommandCamMovementIDMulti.Name = "comboBoxCommandCamMovementIDMulti";
            this.comboBoxCommandCamMovementIDMulti.Size = new System.Drawing.Size(227, 23);
            this.comboBoxCommandCamMovementIDMulti.TabIndex = 32;
            // 
            // labelCommandCamMovementIDSingle
            // 
            this.labelCommandCamMovementIDSingle.AutoSize = true;
            this.labelCommandCamMovementIDSingle.Location = new System.Drawing.Point(190, 101);
            this.labelCommandCamMovementIDSingle.Name = "labelCommandCamMovementIDSingle";
            this.labelCommandCamMovementIDSingle.Size = new System.Drawing.Size(202, 15);
            this.labelCommandCamMovementIDSingle.TabIndex = 29;
            this.labelCommandCamMovementIDSingle.Text = "Camera movement ID (single target):";
            // 
            // comboBoxCommandCameraMovementIDSingle
            // 
            this.comboBoxCommandCameraMovementIDSingle.FormattingEnabled = true;
            this.comboBoxCommandCameraMovementIDSingle.Location = new System.Drawing.Point(191, 119);
            this.comboBoxCommandCameraMovementIDSingle.Name = "comboBoxCommandCameraMovementIDSingle";
            this.comboBoxCommandCameraMovementIDSingle.Size = new System.Drawing.Size(226, 23);
            this.comboBoxCommandCameraMovementIDSingle.TabIndex = 30;
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
            this.tabPageAttackData.Controls.Add(this.tabControlAttacks);
            this.tabPageAttackData.Controls.Add(this.listBoxAttacks);
            this.tabPageAttackData.Location = new System.Drawing.Point(4, 24);
            this.tabPageAttackData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageAttackData.Name = "tabPageAttackData";
            this.tabPageAttackData.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageAttackData.Size = new System.Drawing.Size(776, 533);
            this.tabPageAttackData.TabIndex = 1;
            this.tabPageAttackData.Text = "Attacks";
            this.tabPageAttackData.UseVisualStyleBackColor = true;
            // 
            // tabControlAttacks
            // 
            this.tabControlAttacks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAttacks.Controls.Add(this.tabPageAttacks1);
            this.tabControlAttacks.Controls.Add(this.tabPageAttacks2);
            this.tabControlAttacks.Location = new System.Drawing.Point(191, 13);
            this.tabControlAttacks.Name = "tabControlAttacks";
            this.tabControlAttacks.SelectedIndex = 0;
            this.tabControlAttacks.Size = new System.Drawing.Size(577, 469);
            this.tabControlAttacks.TabIndex = 37;
            // 
            // tabPageAttacks1
            // 
            this.tabPageAttacks1.Controls.Add(this.specialAttackFlagsControlAttack);
            this.tabPageAttacks1.Controls.Add(this.labelAttackHurtActionIndex);
            this.tabPageAttacks1.Controls.Add(this.comboBoxAttackHurtActionIndex);
            this.tabPageAttacks1.Controls.Add(this.labelAttackAttackEffectID);
            this.tabPageAttacks1.Controls.Add(this.comboBoxAttackAttackEffectID);
            this.tabPageAttacks1.Controls.Add(this.labelAttackImpactEffectID);
            this.tabPageAttacks1.Controls.Add(this.comboBoxAttackImpactEffectID);
            this.tabPageAttacks1.Controls.Add(this.textBoxAttackDescription);
            this.tabPageAttacks1.Controls.Add(this.damageCalculationControlAttack);
            this.tabPageAttacks1.Controls.Add(this.labelAttackCamMovementIDMulti);
            this.tabPageAttacks1.Controls.Add(this.labelAttackName);
            this.tabPageAttacks1.Controls.Add(this.comboBoxAttackCamMovementIDMulti);
            this.tabPageAttacks1.Controls.Add(this.textBoxAttackName);
            this.tabPageAttacks1.Controls.Add(this.labelAttackCamMovementIDSingle);
            this.tabPageAttacks1.Controls.Add(this.labelAttackDescription);
            this.tabPageAttacks1.Controls.Add(this.comboBoxAttackCamMovementIDSingle);
            this.tabPageAttacks1.Controls.Add(this.labelSummonText);
            this.tabPageAttacks1.Controls.Add(this.numericAttackAttackPercent);
            this.tabPageAttacks1.Controls.Add(this.textBoxSummonText);
            this.tabPageAttacks1.Controls.Add(this.labelAttackAttackPercent);
            this.tabPageAttacks1.Controls.Add(this.labelAttackMPCost);
            this.tabPageAttacks1.Controls.Add(this.numericAttackMPCost);
            this.tabPageAttacks1.Location = new System.Drawing.Point(4, 24);
            this.tabPageAttacks1.Name = "tabPageAttacks1";
            this.tabPageAttacks1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAttacks1.Size = new System.Drawing.Size(569, 441);
            this.tabPageAttacks1.TabIndex = 0;
            this.tabPageAttacks1.Text = "Page 1";
            this.tabPageAttacks1.UseVisualStyleBackColor = true;
            // 
            // specialAttackFlagsControlAttack
            // 
            this.specialAttackFlagsControlAttack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specialAttackFlagsControlAttack.Location = new System.Drawing.Point(4, 328);
            this.specialAttackFlagsControlAttack.Name = "specialAttackFlagsControlAttack";
            this.specialAttackFlagsControlAttack.Size = new System.Drawing.Size(558, 100);
            this.specialAttackFlagsControlAttack.TabIndex = 43;
            // 
            // labelAttackHurtActionIndex
            // 
            this.labelAttackHurtActionIndex.AutoSize = true;
            this.labelAttackHurtActionIndex.Location = new System.Drawing.Point(428, 91);
            this.labelAttackHurtActionIndex.Name = "labelAttackHurtActionIndex";
            this.labelAttackHurtActionIndex.Size = new System.Drawing.Size(102, 15);
            this.labelAttackHurtActionIndex.TabIndex = 42;
            this.labelAttackHurtActionIndex.Text = "Hurt action index:";
            // 
            // comboBoxAttackHurtActionIndex
            // 
            this.comboBoxAttackHurtActionIndex.FormattingEnabled = true;
            this.comboBoxAttackHurtActionIndex.Location = new System.Drawing.Point(428, 109);
            this.comboBoxAttackHurtActionIndex.Name = "comboBoxAttackHurtActionIndex";
            this.comboBoxAttackHurtActionIndex.Size = new System.Drawing.Size(102, 23);
            this.comboBoxAttackHurtActionIndex.TabIndex = 41;
            // 
            // labelAttackAttackEffectID
            // 
            this.labelAttackAttackEffectID.AutoSize = true;
            this.labelAttackAttackEffectID.Location = new System.Drawing.Point(216, 91);
            this.labelAttackAttackEffectID.Name = "labelAttackAttackEffectID";
            this.labelAttackAttackEffectID.Size = new System.Drawing.Size(91, 15);
            this.labelAttackAttackEffectID.TabIndex = 40;
            this.labelAttackAttackEffectID.Text = "Attack effect ID:";
            // 
            // comboBoxAttackAttackEffectID
            // 
            this.comboBoxAttackAttackEffectID.FormattingEnabled = true;
            this.comboBoxAttackAttackEffectID.Location = new System.Drawing.Point(216, 109);
            this.comboBoxAttackAttackEffectID.Name = "comboBoxAttackAttackEffectID";
            this.comboBoxAttackAttackEffectID.Size = new System.Drawing.Size(100, 23);
            this.comboBoxAttackAttackEffectID.TabIndex = 39;
            // 
            // labelAttackImpactEffectID
            // 
            this.labelAttackImpactEffectID.AutoSize = true;
            this.labelAttackImpactEffectID.Location = new System.Drawing.Point(322, 91);
            this.labelAttackImpactEffectID.Name = "labelAttackImpactEffectID";
            this.labelAttackImpactEffectID.Size = new System.Drawing.Size(94, 15);
            this.labelAttackImpactEffectID.TabIndex = 38;
            this.labelAttackImpactEffectID.Text = "Impact effect ID:";
            // 
            // comboBoxAttackImpactEffectID
            // 
            this.comboBoxAttackImpactEffectID.FormattingEnabled = true;
            this.comboBoxAttackImpactEffectID.Location = new System.Drawing.Point(322, 109);
            this.comboBoxAttackImpactEffectID.Name = "comboBoxAttackImpactEffectID";
            this.comboBoxAttackImpactEffectID.Size = new System.Drawing.Size(100, 23);
            this.comboBoxAttackImpactEffectID.TabIndex = 37;
            // 
            // textBoxAttackDescription
            // 
            this.textBoxAttackDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAttackDescription.Location = new System.Drawing.Point(4, 65);
            this.textBoxAttackDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAttackDescription.Name = "textBoxAttackDescription";
            this.textBoxAttackDescription.Size = new System.Drawing.Size(558, 23);
            this.textBoxAttackDescription.TabIndex = 4;
            // 
            // damageCalculationControlAttack
            // 
            this.damageCalculationControlAttack.AccuracyCalculation = FF7Scarlet.AccuracyCalculation.NoMiss1;
            this.damageCalculationControlAttack.ActualValue = ((byte)(0));
            this.damageCalculationControlAttack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.damageCalculationControlAttack.AttackPower = ((byte)(0));
            this.damageCalculationControlAttack.CanCrit = false;
            this.damageCalculationControlAttack.DamageFormula = FF7Scarlet.DamageFormulas.NoDamage;
            this.damageCalculationControlAttack.DamageType = FF7Scarlet.DamageType.Physical;
            this.damageCalculationControlAttack.Location = new System.Drawing.Point(4, 182);
            this.damageCalculationControlAttack.Name = "damageCalculationControlAttack";
            this.damageCalculationControlAttack.Size = new System.Drawing.Size(558, 140);
            this.damageCalculationControlAttack.TabIndex = 36;
            // 
            // labelAttackCamMovementIDMulti
            // 
            this.labelAttackCamMovementIDMulti.AutoSize = true;
            this.labelAttackCamMovementIDMulti.Location = new System.Drawing.Point(238, 135);
            this.labelAttackCamMovementIDMulti.Name = "labelAttackCamMovementIDMulti";
            this.labelAttackCamMovementIDMulti.Size = new System.Drawing.Size(199, 15);
            this.labelAttackCamMovementIDMulti.TabIndex = 35;
            this.labelAttackCamMovementIDMulti.Text = "Camera movement ID (multi target):";
            // 
            // labelAttackName
            // 
            this.labelAttackName.AutoSize = true;
            this.labelAttackName.Location = new System.Drawing.Point(4, 3);
            this.labelAttackName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAttackName.Name = "labelAttackName";
            this.labelAttackName.Size = new System.Drawing.Size(42, 15);
            this.labelAttackName.TabIndex = 1;
            this.labelAttackName.Text = "Name:";
            // 
            // comboBoxAttackCamMovementIDMulti
            // 
            this.comboBoxAttackCamMovementIDMulti.FormattingEnabled = true;
            this.comboBoxAttackCamMovementIDMulti.Location = new System.Drawing.Point(238, 153);
            this.comboBoxAttackCamMovementIDMulti.Name = "comboBoxAttackCamMovementIDMulti";
            this.comboBoxAttackCamMovementIDMulti.Size = new System.Drawing.Size(227, 23);
            this.comboBoxAttackCamMovementIDMulti.TabIndex = 36;
            // 
            // textBoxAttackName
            // 
            this.textBoxAttackName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAttackName.Location = new System.Drawing.Point(4, 21);
            this.textBoxAttackName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAttackName.Name = "textBoxAttackName";
            this.textBoxAttackName.Size = new System.Drawing.Size(226, 23);
            this.textBoxAttackName.TabIndex = 2;
            // 
            // labelAttackCamMovementIDSingle
            // 
            this.labelAttackCamMovementIDSingle.AutoSize = true;
            this.labelAttackCamMovementIDSingle.Location = new System.Drawing.Point(4, 135);
            this.labelAttackCamMovementIDSingle.Name = "labelAttackCamMovementIDSingle";
            this.labelAttackCamMovementIDSingle.Size = new System.Drawing.Size(202, 15);
            this.labelAttackCamMovementIDSingle.TabIndex = 33;
            this.labelAttackCamMovementIDSingle.Text = "Camera movement ID (single target):";
            // 
            // labelAttackDescription
            // 
            this.labelAttackDescription.AutoSize = true;
            this.labelAttackDescription.Location = new System.Drawing.Point(4, 47);
            this.labelAttackDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAttackDescription.Name = "labelAttackDescription";
            this.labelAttackDescription.Size = new System.Drawing.Size(70, 15);
            this.labelAttackDescription.TabIndex = 3;
            this.labelAttackDescription.Text = "Description:";
            // 
            // comboBoxAttackCamMovementIDSingle
            // 
            this.comboBoxAttackCamMovementIDSingle.FormattingEnabled = true;
            this.comboBoxAttackCamMovementIDSingle.Location = new System.Drawing.Point(4, 153);
            this.comboBoxAttackCamMovementIDSingle.Name = "comboBoxAttackCamMovementIDSingle";
            this.comboBoxAttackCamMovementIDSingle.Size = new System.Drawing.Size(228, 23);
            this.comboBoxAttackCamMovementIDSingle.TabIndex = 34;
            // 
            // labelSummonText
            // 
            this.labelSummonText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSummonText.AutoSize = true;
            this.labelSummonText.Location = new System.Drawing.Point(238, 3);
            this.labelSummonText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSummonText.Name = "labelSummonText";
            this.labelSummonText.Size = new System.Drawing.Size(127, 15);
            this.labelSummonText.TabIndex = 5;
            this.labelSummonText.Text = "Summon attack name:";
            // 
            // numericAttackAttackPercent
            // 
            this.numericAttackAttackPercent.Location = new System.Drawing.Point(4, 109);
            this.numericAttackAttackPercent.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericAttackAttackPercent.Name = "numericAttackAttackPercent";
            this.numericAttackAttackPercent.Size = new System.Drawing.Size(100, 23);
            this.numericAttackAttackPercent.TabIndex = 10;
            // 
            // textBoxSummonText
            // 
            this.textBoxSummonText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSummonText.Enabled = false;
            this.textBoxSummonText.Location = new System.Drawing.Point(238, 21);
            this.textBoxSummonText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSummonText.Name = "textBoxSummonText";
            this.textBoxSummonText.Size = new System.Drawing.Size(324, 23);
            this.textBoxSummonText.TabIndex = 6;
            // 
            // labelAttackAttackPercent
            // 
            this.labelAttackAttackPercent.AutoSize = true;
            this.labelAttackAttackPercent.Location = new System.Drawing.Point(4, 91);
            this.labelAttackAttackPercent.Name = "labelAttackAttackPercent";
            this.labelAttackAttackPercent.Size = new System.Drawing.Size(54, 15);
            this.labelAttackAttackPercent.TabIndex = 9;
            this.labelAttackAttackPercent.Text = "Attack%:";
            // 
            // labelAttackMPCost
            // 
            this.labelAttackMPCost.AutoSize = true;
            this.labelAttackMPCost.Location = new System.Drawing.Point(110, 91);
            this.labelAttackMPCost.Name = "labelAttackMPCost";
            this.labelAttackMPCost.Size = new System.Drawing.Size(53, 15);
            this.labelAttackMPCost.TabIndex = 7;
            this.labelAttackMPCost.Text = "MP cost:";
            // 
            // numericAttackMPCost
            // 
            this.numericAttackMPCost.Location = new System.Drawing.Point(110, 109);
            this.numericAttackMPCost.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericAttackMPCost.Name = "numericAttackMPCost";
            this.numericAttackMPCost.Size = new System.Drawing.Size(100, 23);
            this.numericAttackMPCost.TabIndex = 8;
            // 
            // tabPageAttacks2
            // 
            this.tabPageAttacks2.Controls.Add(this.groupBoxAttackSpecialActions);
            this.tabPageAttacks2.Controls.Add(this.numericAttackStatusChangeChance);
            this.tabPageAttacks2.Controls.Add(this.comboBoxAttackConditionSubMenu);
            this.tabPageAttacks2.Controls.Add(this.labelAttackStatusChangeChance);
            this.tabPageAttacks2.Controls.Add(this.comboBoxAttackStatusChange);
            this.tabPageAttacks2.Controls.Add(this.labelAttackConditionSubMenu);
            this.tabPageAttacks2.Controls.Add(this.labelAttackStatusChange);
            this.tabPageAttacks2.Controls.Add(this.statusesControlAttack);
            this.tabPageAttacks2.Controls.Add(this.elementsControlAttack);
            this.tabPageAttacks2.Location = new System.Drawing.Point(4, 24);
            this.tabPageAttacks2.Name = "tabPageAttacks2";
            this.tabPageAttacks2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAttacks2.Size = new System.Drawing.Size(569, 441);
            this.tabPageAttacks2.TabIndex = 1;
            this.tabPageAttacks2.Text = "Page 2";
            this.tabPageAttacks2.UseVisualStyleBackColor = true;
            // 
            // groupBoxAttackSpecialActions
            // 
            this.groupBoxAttackSpecialActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAttackSpecialActions.Controls.Add(this.buttonAttackSyncAll);
            this.groupBoxAttackSpecialActions.Controls.Add(this.checkBoxAttackSyncWithSceneBin);
            this.groupBoxAttackSpecialActions.Location = new System.Drawing.Point(263, 345);
            this.groupBoxAttackSpecialActions.Name = "groupBoxAttackSpecialActions";
            this.groupBoxAttackSpecialActions.Size = new System.Drawing.Size(300, 85);
            this.groupBoxAttackSpecialActions.TabIndex = 45;
            this.groupBoxAttackSpecialActions.TabStop = false;
            this.groupBoxAttackSpecialActions.Text = "Special actions";
            // 
            // buttonAttackSyncAll
            // 
            this.buttonAttackSyncAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAttackSyncAll.Location = new System.Drawing.Point(183, 18);
            this.buttonAttackSyncAll.Name = "buttonAttackSyncAll";
            this.buttonAttackSyncAll.Size = new System.Drawing.Size(111, 23);
            this.buttonAttackSyncAll.TabIndex = 1;
            this.buttonAttackSyncAll.Text = "Sync all";
            this.buttonAttackSyncAll.UseVisualStyleBackColor = true;
            this.buttonAttackSyncAll.Click += new System.EventHandler(this.buttonAttackSyncAll_Click);
            // 
            // checkBoxAttackSyncWithSceneBin
            // 
            this.checkBoxAttackSyncWithSceneBin.AutoSize = true;
            this.checkBoxAttackSyncWithSceneBin.Location = new System.Drawing.Point(6, 21);
            this.checkBoxAttackSyncWithSceneBin.Name = "checkBoxAttackSyncWithSceneBin";
            this.checkBoxAttackSyncWithSceneBin.Size = new System.Drawing.Size(171, 19);
            this.checkBoxAttackSyncWithSceneBin.TabIndex = 0;
            this.checkBoxAttackSyncWithSceneBin.Text = "Keep synced with scene.bin";
            this.checkBoxAttackSyncWithSceneBin.UseVisualStyleBackColor = true;
            this.checkBoxAttackSyncWithSceneBin.CheckedChanged += new System.EventHandler(this.checkBoxAttackSyncWithSceneBin_CheckedChanged);
            // 
            // numericAttackStatusChangeChance
            // 
            this.numericAttackStatusChangeChance.Location = new System.Drawing.Point(149, 363);
            this.numericAttackStatusChangeChance.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericAttackStatusChangeChance.Name = "numericAttackStatusChangeChance";
            this.numericAttackStatusChangeChance.Size = new System.Drawing.Size(108, 23);
            this.numericAttackStatusChangeChance.TabIndex = 5;
            // 
            // comboBoxAttackConditionSubMenu
            // 
            this.comboBoxAttackConditionSubMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttackConditionSubMenu.FormattingEnabled = true;
            this.comboBoxAttackConditionSubMenu.Location = new System.Drawing.Point(6, 407);
            this.comboBoxAttackConditionSubMenu.Name = "comboBoxAttackConditionSubMenu";
            this.comboBoxAttackConditionSubMenu.Size = new System.Drawing.Size(251, 23);
            this.comboBoxAttackConditionSubMenu.TabIndex = 44;
            // 
            // labelAttackStatusChangeChance
            // 
            this.labelAttackStatusChangeChance.AutoSize = true;
            this.labelAttackStatusChangeChance.Location = new System.Drawing.Point(149, 345);
            this.labelAttackStatusChangeChance.Name = "labelAttackStatusChangeChance";
            this.labelAttackStatusChangeChance.Size = new System.Drawing.Size(108, 15);
            this.labelAttackStatusChangeChance.TabIndex = 4;
            this.labelAttackStatusChangeChance.Text = "Chance (out of 63):";
            // 
            // comboBoxAttackStatusChange
            // 
            this.comboBoxAttackStatusChange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttackStatusChange.FormattingEnabled = true;
            this.comboBoxAttackStatusChange.Location = new System.Drawing.Point(6, 363);
            this.comboBoxAttackStatusChange.Name = "comboBoxAttackStatusChange";
            this.comboBoxAttackStatusChange.Size = new System.Drawing.Size(137, 23);
            this.comboBoxAttackStatusChange.TabIndex = 3;
            // 
            // labelAttackConditionSubMenu
            // 
            this.labelAttackConditionSubMenu.AutoSize = true;
            this.labelAttackConditionSubMenu.Location = new System.Drawing.Point(6, 389);
            this.labelAttackConditionSubMenu.Name = "labelAttackConditionSubMenu";
            this.labelAttackConditionSubMenu.Size = new System.Drawing.Size(121, 15);
            this.labelAttackConditionSubMenu.TabIndex = 43;
            this.labelAttackConditionSubMenu.Text = "Condition sub-menu:";
            // 
            // labelAttackStatusChange
            // 
            this.labelAttackStatusChange.AutoSize = true;
            this.labelAttackStatusChange.Location = new System.Drawing.Point(6, 345);
            this.labelAttackStatusChange.Name = "labelAttackStatusChange";
            this.labelAttackStatusChange.Size = new System.Drawing.Size(84, 15);
            this.labelAttackStatusChange.TabIndex = 2;
            this.labelAttackStatusChange.Text = "Status change:";
            // 
            // statusesControlAttack
            // 
            this.statusesControlAttack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusesControlAttack.FullList = true;
            this.statusesControlAttack.GroupBoxText = "Statuses";
            this.statusesControlAttack.Location = new System.Drawing.Point(6, 142);
            this.statusesControlAttack.MinimumSize = new System.Drawing.Size(380, 200);
            this.statusesControlAttack.Name = "statusesControlAttack";
            this.statusesControlAttack.Size = new System.Drawing.Size(557, 200);
            this.statusesControlAttack.TabIndex = 1;
            // 
            // elementsControlAttack
            // 
            this.elementsControlAttack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementsControlAttack.Location = new System.Drawing.Point(6, 6);
            this.elementsControlAttack.MinimumSize = new System.Drawing.Size(370, 130);
            this.elementsControlAttack.Name = "elementsControlAttack";
            this.elementsControlAttack.Size = new System.Drawing.Size(557, 130);
            this.elementsControlAttack.TabIndex = 0;
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
            this.tabPageInitData.Controls.Add(this.tabControlInitialData);
            this.tabPageInitData.Location = new System.Drawing.Point(4, 24);
            this.tabPageInitData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageInitData.Name = "tabPageInitData";
            this.tabPageInitData.Size = new System.Drawing.Size(776, 533);
            this.tabPageInitData.TabIndex = 3;
            this.tabPageInitData.Text = "Initial Data";
            this.tabPageInitData.UseVisualStyleBackColor = true;
            // 
            // tabControlInitialData
            // 
            this.tabControlInitialData.Controls.Add(this.tabPageInitCharacterStats);
            this.tabControlInitialData.Controls.Add(this.tabPageInitInventory);
            this.tabControlInitialData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInitialData.Location = new System.Drawing.Point(0, 0);
            this.tabControlInitialData.Name = "tabControlInitialData";
            this.tabControlInitialData.SelectedIndex = 0;
            this.tabControlInitialData.Size = new System.Drawing.Size(776, 533);
            this.tabControlInitialData.TabIndex = 0;
            // 
            // tabPageInitCharacterStats
            // 
            this.tabPageInitCharacterStats.Controls.Add(this.groupBoxCharacterMP);
            this.tabPageInitCharacterStats.Controls.Add(this.groupBoxCharacterHP);
            this.tabPageInitCharacterStats.Controls.Add(this.numericCharacterEXPtoNext);
            this.tabPageInitCharacterStats.Controls.Add(this.labelCharacterEXPtoNext);
            this.tabPageInitCharacterStats.Controls.Add(this.numericCharacterKillCount);
            this.tabPageInitCharacterStats.Controls.Add(this.labelCharacterKillCount);
            this.tabPageInitCharacterStats.Controls.Add(this.comboBoxCharacterFlags);
            this.tabPageInitCharacterStats.Controls.Add(this.labelCharacterFlags);
            this.tabPageInitCharacterStats.Controls.Add(this.characterLimitControl);
            this.tabPageInitCharacterStats.Controls.Add(this.numericCharacterCurrentEXP);
            this.tabPageInitCharacterStats.Controls.Add(this.labelCharacterCurrentEXP);
            this.tabPageInitCharacterStats.Controls.Add(this.groupBoxCharacterArmor);
            this.tabPageInitCharacterStats.Controls.Add(this.groupBoxCharacterWeapon);
            this.tabPageInitCharacterStats.Controls.Add(this.characterStatsControl);
            this.tabPageInitCharacterStats.Controls.Add(this.checkBoxCharacterBackRow);
            this.tabPageInitCharacterStats.Controls.Add(this.numericCharacterLevel);
            this.tabPageInitCharacterStats.Controls.Add(this.labelCharacterLevel);
            this.tabPageInitCharacterStats.Controls.Add(this.comboBoxCharacterAccessory);
            this.tabPageInitCharacterStats.Controls.Add(this.labelCharacterAccessory);
            this.tabPageInitCharacterStats.Controls.Add(this.numericCharacterID);
            this.tabPageInitCharacterStats.Controls.Add(this.labelCharacterID);
            this.tabPageInitCharacterStats.Controls.Add(this.textBoxCharacterName);
            this.tabPageInitCharacterStats.Controls.Add(this.labelCharacterName);
            this.tabPageInitCharacterStats.Controls.Add(this.listBoxInitCharacters);
            this.tabPageInitCharacterStats.Location = new System.Drawing.Point(4, 24);
            this.tabPageInitCharacterStats.Name = "tabPageInitCharacterStats";
            this.tabPageInitCharacterStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInitCharacterStats.Size = new System.Drawing.Size(768, 505);
            this.tabPageInitCharacterStats.TabIndex = 0;
            this.tabPageInitCharacterStats.Text = "Character Stats";
            this.tabPageInitCharacterStats.UseVisualStyleBackColor = true;
            // 
            // groupBoxCharacterMP
            // 
            this.groupBoxCharacterMP.Controls.Add(this.numericCharacterMaxMP);
            this.groupBoxCharacterMP.Controls.Add(this.labelCharacterMaxMP);
            this.groupBoxCharacterMP.Controls.Add(this.numericCharacterBaseMP);
            this.groupBoxCharacterMP.Controls.Add(this.labelCharacterBaseMP);
            this.groupBoxCharacterMP.Controls.Add(this.numericCharacterCurrMP);
            this.groupBoxCharacterMP.Controls.Add(this.labelCharacterCurrMP);
            this.groupBoxCharacterMP.Location = new System.Drawing.Point(158, 177);
            this.groupBoxCharacterMP.Name = "groupBoxCharacterMP";
            this.groupBoxCharacterMP.Size = new System.Drawing.Size(373, 71);
            this.groupBoxCharacterMP.TabIndex = 30;
            this.groupBoxCharacterMP.TabStop = false;
            this.groupBoxCharacterMP.Text = "MP";
            // 
            // numericCharacterMaxMP
            // 
            this.numericCharacterMaxMP.Location = new System.Drawing.Point(248, 37);
            this.numericCharacterMaxMP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericCharacterMaxMP.Name = "numericCharacterMaxMP";
            this.numericCharacterMaxMP.Size = new System.Drawing.Size(115, 23);
            this.numericCharacterMaxMP.TabIndex = 5;
            // 
            // labelCharacterMaxMP
            // 
            this.labelCharacterMaxMP.AutoSize = true;
            this.labelCharacterMaxMP.Location = new System.Drawing.Point(248, 19);
            this.labelCharacterMaxMP.Name = "labelCharacterMaxMP";
            this.labelCharacterMaxMP.Size = new System.Drawing.Size(57, 15);
            this.labelCharacterMaxMP.TabIndex = 4;
            this.labelCharacterMaxMP.Text = "Adjusted:";
            // 
            // numericCharacterBaseMP
            // 
            this.numericCharacterBaseMP.Location = new System.Drawing.Point(127, 37);
            this.numericCharacterBaseMP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericCharacterBaseMP.Name = "numericCharacterBaseMP";
            this.numericCharacterBaseMP.Size = new System.Drawing.Size(115, 23);
            this.numericCharacterBaseMP.TabIndex = 3;
            // 
            // labelCharacterBaseMP
            // 
            this.labelCharacterBaseMP.AutoSize = true;
            this.labelCharacterBaseMP.Location = new System.Drawing.Point(127, 19);
            this.labelCharacterBaseMP.Name = "labelCharacterBaseMP";
            this.labelCharacterBaseMP.Size = new System.Drawing.Size(33, 15);
            this.labelCharacterBaseMP.TabIndex = 2;
            this.labelCharacterBaseMP.Text = "Max:";
            // 
            // numericCharacterCurrMP
            // 
            this.numericCharacterCurrMP.Location = new System.Drawing.Point(6, 37);
            this.numericCharacterCurrMP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericCharacterCurrMP.Name = "numericCharacterCurrMP";
            this.numericCharacterCurrMP.Size = new System.Drawing.Size(115, 23);
            this.numericCharacterCurrMP.TabIndex = 1;
            // 
            // labelCharacterCurrMP
            // 
            this.labelCharacterCurrMP.AutoSize = true;
            this.labelCharacterCurrMP.Location = new System.Drawing.Point(6, 19);
            this.labelCharacterCurrMP.Name = "labelCharacterCurrMP";
            this.labelCharacterCurrMP.Size = new System.Drawing.Size(50, 15);
            this.labelCharacterCurrMP.TabIndex = 0;
            this.labelCharacterCurrMP.Text = "Current:";
            // 
            // groupBoxCharacterHP
            // 
            this.groupBoxCharacterHP.Controls.Add(this.numericCharacterMaxHP);
            this.groupBoxCharacterHP.Controls.Add(this.labelCharacterMaxHP);
            this.groupBoxCharacterHP.Controls.Add(this.numericCharacterBaseHP);
            this.groupBoxCharacterHP.Controls.Add(this.labelCharacterBaseHP);
            this.groupBoxCharacterHP.Controls.Add(this.numericCharacterCurrHP);
            this.groupBoxCharacterHP.Controls.Add(this.labelCharacterCurrHP);
            this.groupBoxCharacterHP.Location = new System.Drawing.Point(158, 100);
            this.groupBoxCharacterHP.Name = "groupBoxCharacterHP";
            this.groupBoxCharacterHP.Size = new System.Drawing.Size(373, 71);
            this.groupBoxCharacterHP.TabIndex = 29;
            this.groupBoxCharacterHP.TabStop = false;
            this.groupBoxCharacterHP.Text = "HP";
            // 
            // numericCharacterMaxHP
            // 
            this.numericCharacterMaxHP.Location = new System.Drawing.Point(248, 37);
            this.numericCharacterMaxHP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericCharacterMaxHP.Name = "numericCharacterMaxHP";
            this.numericCharacterMaxHP.Size = new System.Drawing.Size(115, 23);
            this.numericCharacterMaxHP.TabIndex = 5;
            // 
            // labelCharacterMaxHP
            // 
            this.labelCharacterMaxHP.AutoSize = true;
            this.labelCharacterMaxHP.Location = new System.Drawing.Point(248, 19);
            this.labelCharacterMaxHP.Name = "labelCharacterMaxHP";
            this.labelCharacterMaxHP.Size = new System.Drawing.Size(57, 15);
            this.labelCharacterMaxHP.TabIndex = 4;
            this.labelCharacterMaxHP.Text = "Adjusted:";
            // 
            // numericCharacterBaseHP
            // 
            this.numericCharacterBaseHP.Location = new System.Drawing.Point(127, 37);
            this.numericCharacterBaseHP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericCharacterBaseHP.Name = "numericCharacterBaseHP";
            this.numericCharacterBaseHP.Size = new System.Drawing.Size(115, 23);
            this.numericCharacterBaseHP.TabIndex = 3;
            // 
            // labelCharacterBaseHP
            // 
            this.labelCharacterBaseHP.AutoSize = true;
            this.labelCharacterBaseHP.Location = new System.Drawing.Point(127, 19);
            this.labelCharacterBaseHP.Name = "labelCharacterBaseHP";
            this.labelCharacterBaseHP.Size = new System.Drawing.Size(33, 15);
            this.labelCharacterBaseHP.TabIndex = 2;
            this.labelCharacterBaseHP.Text = "Max:";
            // 
            // numericCharacterCurrHP
            // 
            this.numericCharacterCurrHP.Location = new System.Drawing.Point(6, 37);
            this.numericCharacterCurrHP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericCharacterCurrHP.Name = "numericCharacterCurrHP";
            this.numericCharacterCurrHP.Size = new System.Drawing.Size(115, 23);
            this.numericCharacterCurrHP.TabIndex = 1;
            // 
            // labelCharacterCurrHP
            // 
            this.labelCharacterCurrHP.AutoSize = true;
            this.labelCharacterCurrHP.Location = new System.Drawing.Point(6, 19);
            this.labelCharacterCurrHP.Name = "labelCharacterCurrHP";
            this.labelCharacterCurrHP.Size = new System.Drawing.Size(50, 15);
            this.labelCharacterCurrHP.TabIndex = 0;
            this.labelCharacterCurrHP.Text = "Current:";
            // 
            // numericCharacterEXPtoNext
            // 
            this.numericCharacterEXPtoNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericCharacterEXPtoNext.Location = new System.Drawing.Point(642, 72);
            this.numericCharacterEXPtoNext.Name = "numericCharacterEXPtoNext";
            this.numericCharacterEXPtoNext.Size = new System.Drawing.Size(120, 23);
            this.numericCharacterEXPtoNext.TabIndex = 28;
            // 
            // labelCharacterEXPtoNext
            // 
            this.labelCharacterEXPtoNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCharacterEXPtoNext.AutoSize = true;
            this.labelCharacterEXPtoNext.Location = new System.Drawing.Point(642, 53);
            this.labelCharacterEXPtoNext.Name = "labelCharacterEXPtoNext";
            this.labelCharacterEXPtoNext.Size = new System.Drawing.Size(75, 15);
            this.labelCharacterEXPtoNext.TabIndex = 27;
            this.labelCharacterEXPtoNext.Text = "To next level:";
            // 
            // numericCharacterKillCount
            // 
            this.numericCharacterKillCount.Location = new System.Drawing.Point(401, 269);
            this.numericCharacterKillCount.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericCharacterKillCount.Name = "numericCharacterKillCount";
            this.numericCharacterKillCount.Size = new System.Drawing.Size(128, 23);
            this.numericCharacterKillCount.TabIndex = 26;
            // 
            // labelCharacterKillCount
            // 
            this.labelCharacterKillCount.AutoSize = true;
            this.labelCharacterKillCount.Location = new System.Drawing.Point(401, 251);
            this.labelCharacterKillCount.Name = "labelCharacterKillCount";
            this.labelCharacterKillCount.Size = new System.Drawing.Size(60, 15);
            this.labelCharacterKillCount.TabIndex = 25;
            this.labelCharacterKillCount.Text = "Kill count:";
            // 
            // comboBoxCharacterFlags
            // 
            this.comboBoxCharacterFlags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCharacterFlags.FormattingEnabled = true;
            this.comboBoxCharacterFlags.Location = new System.Drawing.Point(158, 269);
            this.comboBoxCharacterFlags.Name = "comboBoxCharacterFlags";
            this.comboBoxCharacterFlags.Size = new System.Drawing.Size(157, 23);
            this.comboBoxCharacterFlags.TabIndex = 24;
            // 
            // labelCharacterFlags
            // 
            this.labelCharacterFlags.AutoSize = true;
            this.labelCharacterFlags.Location = new System.Drawing.Point(158, 251);
            this.labelCharacterFlags.Name = "labelCharacterFlags";
            this.labelCharacterFlags.Size = new System.Drawing.Size(89, 15);
            this.labelCharacterFlags.TabIndex = 23;
            this.labelCharacterFlags.Text = "Character flags:";
            // 
            // characterLimitControl
            // 
            this.characterLimitControl.LimitBar = ((byte)(0));
            this.characterLimitControl.LimitLevel = ((byte)(0));
            this.characterLimitControl.Location = new System.Drawing.Point(158, 298);
            this.characterLimitControl.Name = "characterLimitControl";
            this.characterLimitControl.Size = new System.Drawing.Size(373, 148);
            this.characterLimitControl.TabIndex = 22;
            // 
            // numericCharacterCurrentEXP
            // 
            this.numericCharacterCurrentEXP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericCharacterCurrentEXP.Location = new System.Drawing.Point(516, 71);
            this.numericCharacterCurrentEXP.Name = "numericCharacterCurrentEXP";
            this.numericCharacterCurrentEXP.Size = new System.Drawing.Size(120, 23);
            this.numericCharacterCurrentEXP.TabIndex = 21;
            // 
            // labelCharacterCurrentEXP
            // 
            this.labelCharacterCurrentEXP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCharacterCurrentEXP.AutoSize = true;
            this.labelCharacterCurrentEXP.Location = new System.Drawing.Point(516, 52);
            this.labelCharacterCurrentEXP.Name = "labelCharacterCurrentEXP";
            this.labelCharacterCurrentEXP.Size = new System.Drawing.Size(30, 15);
            this.labelCharacterCurrentEXP.TabIndex = 20;
            this.labelCharacterCurrentEXP.Text = "EXP:";
            // 
            // groupBoxCharacterArmor
            // 
            this.groupBoxCharacterArmor.Controls.Add(this.buttonCharacterArmorChangeMateria);
            this.groupBoxCharacterArmor.Controls.Add(this.materiaSlotSelectorCharacterArmor);
            this.groupBoxCharacterArmor.Controls.Add(this.comboBoxCharacterArmor);
            this.groupBoxCharacterArmor.Location = new System.Drawing.Point(539, 235);
            this.groupBoxCharacterArmor.Name = "groupBoxCharacterArmor";
            this.groupBoxCharacterArmor.Size = new System.Drawing.Size(223, 128);
            this.groupBoxCharacterArmor.TabIndex = 17;
            this.groupBoxCharacterArmor.TabStop = false;
            this.groupBoxCharacterArmor.Text = "Armor";
            // 
            // buttonCharacterArmorChangeMateria
            // 
            this.buttonCharacterArmorChangeMateria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCharacterArmorChangeMateria.Location = new System.Drawing.Point(6, 99);
            this.buttonCharacterArmorChangeMateria.Name = "buttonCharacterArmorChangeMateria";
            this.buttonCharacterArmorChangeMateria.Size = new System.Drawing.Size(211, 23);
            this.buttonCharacterArmorChangeMateria.TabIndex = 18;
            this.buttonCharacterArmorChangeMateria.Text = "Change selected materia...";
            this.buttonCharacterArmorChangeMateria.UseVisualStyleBackColor = true;
            this.buttonCharacterArmorChangeMateria.Click += new System.EventHandler(this.buttonCharacterArmorChangeMateria_Click);
            // 
            // materiaSlotSelectorCharacterArmor
            // 
            this.materiaSlotSelectorCharacterArmor.BackColor = System.Drawing.Color.LightSlateGray;
            this.materiaSlotSelectorCharacterArmor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materiaSlotSelectorCharacterArmor.GrowthRate = Shojy.FF7.Elena.Equipment.GrowthRate.None;
            this.materiaSlotSelectorCharacterArmor.Location = new System.Drawing.Point(6, 58);
            this.materiaSlotSelectorCharacterArmor.Name = "materiaSlotSelectorCharacterArmor";
            this.materiaSlotSelectorCharacterArmor.SelectedSlot = -1;
            this.materiaSlotSelectorCharacterArmor.Size = new System.Drawing.Size(211, 35);
            this.materiaSlotSelectorCharacterArmor.SlotSelectorType = FF7Scarlet.KernelEditor.Controls.SlotSelectorType.Slots;
            this.materiaSlotSelectorCharacterArmor.TabIndex = 15;
            // 
            // comboBoxCharacterArmor
            // 
            this.comboBoxCharacterArmor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCharacterArmor.FormattingEnabled = true;
            this.comboBoxCharacterArmor.Location = new System.Drawing.Point(6, 21);
            this.comboBoxCharacterArmor.Name = "comboBoxCharacterArmor";
            this.comboBoxCharacterArmor.Size = new System.Drawing.Size(211, 23);
            this.comboBoxCharacterArmor.TabIndex = 8;
            // 
            // groupBoxCharacterWeapon
            // 
            this.groupBoxCharacterWeapon.Controls.Add(this.buttonCharacterWeaponChangeMateria);
            this.groupBoxCharacterWeapon.Controls.Add(this.materiaSlotSelectorCharacterWeapon);
            this.groupBoxCharacterWeapon.Controls.Add(this.comboBoxCharacterWeapon);
            this.groupBoxCharacterWeapon.Location = new System.Drawing.Point(539, 101);
            this.groupBoxCharacterWeapon.Name = "groupBoxCharacterWeapon";
            this.groupBoxCharacterWeapon.Size = new System.Drawing.Size(223, 128);
            this.groupBoxCharacterWeapon.TabIndex = 16;
            this.groupBoxCharacterWeapon.TabStop = false;
            this.groupBoxCharacterWeapon.Text = "Weapon";
            // 
            // buttonCharacterWeaponChangeMateria
            // 
            this.buttonCharacterWeaponChangeMateria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCharacterWeaponChangeMateria.Location = new System.Drawing.Point(6, 99);
            this.buttonCharacterWeaponChangeMateria.Name = "buttonCharacterWeaponChangeMateria";
            this.buttonCharacterWeaponChangeMateria.Size = new System.Drawing.Size(211, 23);
            this.buttonCharacterWeaponChangeMateria.TabIndex = 16;
            this.buttonCharacterWeaponChangeMateria.Text = "Change selected materia...";
            this.buttonCharacterWeaponChangeMateria.UseVisualStyleBackColor = true;
            this.buttonCharacterWeaponChangeMateria.Click += new System.EventHandler(this.buttonCharacterWeaponChangeMateria_Click);
            // 
            // materiaSlotSelectorCharacterWeapon
            // 
            this.materiaSlotSelectorCharacterWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materiaSlotSelectorCharacterWeapon.BackColor = System.Drawing.Color.LightSlateGray;
            this.materiaSlotSelectorCharacterWeapon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materiaSlotSelectorCharacterWeapon.GrowthRate = Shojy.FF7.Elena.Equipment.GrowthRate.None;
            this.materiaSlotSelectorCharacterWeapon.Location = new System.Drawing.Point(6, 58);
            this.materiaSlotSelectorCharacterWeapon.Name = "materiaSlotSelectorCharacterWeapon";
            this.materiaSlotSelectorCharacterWeapon.SelectedSlot = -1;
            this.materiaSlotSelectorCharacterWeapon.Size = new System.Drawing.Size(211, 35);
            this.materiaSlotSelectorCharacterWeapon.SlotSelectorType = FF7Scarlet.KernelEditor.Controls.SlotSelectorType.Slots;
            this.materiaSlotSelectorCharacterWeapon.TabIndex = 15;
            // 
            // comboBoxCharacterWeapon
            // 
            this.comboBoxCharacterWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCharacterWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCharacterWeapon.FormattingEnabled = true;
            this.comboBoxCharacterWeapon.Location = new System.Drawing.Point(6, 21);
            this.comboBoxCharacterWeapon.Name = "comboBoxCharacterWeapon";
            this.comboBoxCharacterWeapon.Size = new System.Drawing.Size(211, 23);
            this.comboBoxCharacterWeapon.TabIndex = 6;
            // 
            // characterStatsControl
            // 
            this.characterStatsControl.Location = new System.Drawing.Point(6, 151);
            this.characterStatsControl.Name = "characterStatsControl";
            this.characterStatsControl.Size = new System.Drawing.Size(146, 295);
            this.characterStatsControl.TabIndex = 14;
            // 
            // checkBoxCharacterBackRow
            // 
            this.checkBoxCharacterBackRow.AutoSize = true;
            this.checkBoxCharacterBackRow.Location = new System.Drawing.Point(321, 271);
            this.checkBoxCharacterBackRow.Name = "checkBoxCharacterBackRow";
            this.checkBoxCharacterBackRow.Size = new System.Drawing.Size(74, 19);
            this.checkBoxCharacterBackRow.TabIndex = 13;
            this.checkBoxCharacterBackRow.Text = "Back row";
            this.checkBoxCharacterBackRow.UseVisualStyleBackColor = true;
            // 
            // numericCharacterLevel
            // 
            this.numericCharacterLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericCharacterLevel.Location = new System.Drawing.Point(435, 71);
            this.numericCharacterLevel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericCharacterLevel.Name = "numericCharacterLevel";
            this.numericCharacterLevel.Size = new System.Drawing.Size(75, 23);
            this.numericCharacterLevel.TabIndex = 12;
            this.numericCharacterLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelCharacterLevel
            // 
            this.labelCharacterLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCharacterLevel.AutoSize = true;
            this.labelCharacterLevel.Location = new System.Drawing.Point(435, 51);
            this.labelCharacterLevel.Name = "labelCharacterLevel";
            this.labelCharacterLevel.Size = new System.Drawing.Size(37, 15);
            this.labelCharacterLevel.TabIndex = 11;
            this.labelCharacterLevel.Text = "Level:";
            // 
            // comboBoxCharacterAccessory
            // 
            this.comboBoxCharacterAccessory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCharacterAccessory.FormattingEnabled = true;
            this.comboBoxCharacterAccessory.Location = new System.Drawing.Point(545, 384);
            this.comboBoxCharacterAccessory.Name = "comboBoxCharacterAccessory";
            this.comboBoxCharacterAccessory.Size = new System.Drawing.Size(211, 23);
            this.comboBoxCharacterAccessory.TabIndex = 10;
            // 
            // labelCharacterAccessory
            // 
            this.labelCharacterAccessory.AutoSize = true;
            this.labelCharacterAccessory.Location = new System.Drawing.Point(545, 366);
            this.labelCharacterAccessory.Name = "labelCharacterAccessory";
            this.labelCharacterAccessory.Size = new System.Drawing.Size(63, 15);
            this.labelCharacterAccessory.TabIndex = 9;
            this.labelCharacterAccessory.Text = "Accessory:";
            // 
            // numericCharacterID
            // 
            this.numericCharacterID.Location = new System.Drawing.Point(158, 26);
            this.numericCharacterID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericCharacterID.Name = "numericCharacterID";
            this.numericCharacterID.Size = new System.Drawing.Size(75, 23);
            this.numericCharacterID.TabIndex = 4;
            // 
            // labelCharacterID
            // 
            this.labelCharacterID.AutoSize = true;
            this.labelCharacterID.Location = new System.Drawing.Point(158, 6);
            this.labelCharacterID.Name = "labelCharacterID";
            this.labelCharacterID.Size = new System.Drawing.Size(75, 15);
            this.labelCharacterID.TabIndex = 3;
            this.labelCharacterID.Text = "Character ID:";
            // 
            // textBoxCharacterName
            // 
            this.textBoxCharacterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCharacterName.Location = new System.Drawing.Point(158, 71);
            this.textBoxCharacterName.Name = "textBoxCharacterName";
            this.textBoxCharacterName.Size = new System.Drawing.Size(271, 23);
            this.textBoxCharacterName.TabIndex = 2;
            // 
            // labelCharacterName
            // 
            this.labelCharacterName.AutoSize = true;
            this.labelCharacterName.Location = new System.Drawing.Point(158, 52);
            this.labelCharacterName.Name = "labelCharacterName";
            this.labelCharacterName.Size = new System.Drawing.Size(42, 15);
            this.labelCharacterName.TabIndex = 1;
            this.labelCharacterName.Text = "Name:";
            // 
            // listBoxInitCharacters
            // 
            this.listBoxInitCharacters.FormattingEnabled = true;
            this.listBoxInitCharacters.ItemHeight = 15;
            this.listBoxInitCharacters.Location = new System.Drawing.Point(6, 6);
            this.listBoxInitCharacters.Name = "listBoxInitCharacters";
            this.listBoxInitCharacters.Size = new System.Drawing.Size(146, 139);
            this.listBoxInitCharacters.TabIndex = 0;
            this.listBoxInitCharacters.SelectedIndexChanged += new System.EventHandler(this.listBoxInitCharacters_SelectedIndexChanged);
            // 
            // tabPageInitInventory
            // 
            this.tabPageInitInventory.Controls.Add(this.groupBox1);
            this.tabPageInitInventory.Controls.Add(this.groupBoxInitMateria);
            this.tabPageInitInventory.Controls.Add(this.groupBoxInitInventory);
            this.tabPageInitInventory.Location = new System.Drawing.Point(4, 24);
            this.tabPageInitInventory.Name = "tabPageInitInventory";
            this.tabPageInitInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInitInventory.Size = new System.Drawing.Size(768, 505);
            this.tabPageInitInventory.TabIndex = 1;
            this.tabPageInitInventory.Text = "Inventory";
            this.tabPageInitInventory.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxInitMateriaStolen);
            this.groupBox1.Controls.Add(this.buttonInitMateriaStolenEdit);
            this.groupBox1.Controls.Add(this.comboBoxInitMateriaStolen);
            this.groupBox1.Controls.Add(this.labelInitMateriaStolen);
            this.groupBox1.Location = new System.Drawing.Point(513, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 455);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Materia stolen by Yuffie";
            // 
            // listBoxInitMateriaStolen
            // 
            this.listBoxInitMateriaStolen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxInitMateriaStolen.FormattingEnabled = true;
            this.listBoxInitMateriaStolen.ItemHeight = 15;
            this.listBoxInitMateriaStolen.Location = new System.Drawing.Point(6, 22);
            this.listBoxInitMateriaStolen.Name = "listBoxInitMateriaStolen";
            this.listBoxInitMateriaStolen.Size = new System.Drawing.Size(237, 334);
            this.listBoxInitMateriaStolen.TabIndex = 7;
            this.listBoxInitMateriaStolen.SelectedIndexChanged += new System.EventHandler(this.listBoxInitMateriaStolen_SelectedIndexChanged);
            // 
            // buttonInitMateriaStolenEdit
            // 
            this.buttonInitMateriaStolenEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInitMateriaStolenEdit.Enabled = false;
            this.buttonInitMateriaStolenEdit.Location = new System.Drawing.Point(6, 426);
            this.buttonInitMateriaStolenEdit.Name = "buttonInitMateriaStolenEdit";
            this.buttonInitMateriaStolenEdit.Size = new System.Drawing.Size(237, 23);
            this.buttonInitMateriaStolenEdit.TabIndex = 6;
            this.buttonInitMateriaStolenEdit.Text = "Edit details...";
            this.buttonInitMateriaStolenEdit.UseVisualStyleBackColor = true;
            // 
            // comboBoxInitMateriaStolen
            // 
            this.comboBoxInitMateriaStolen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInitMateriaStolen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInitMateriaStolen.Enabled = false;
            this.comboBoxInitMateriaStolen.FormattingEnabled = true;
            this.comboBoxInitMateriaStolen.Location = new System.Drawing.Point(6, 382);
            this.comboBoxInitMateriaStolen.Name = "comboBoxInitMateriaStolen";
            this.comboBoxInitMateriaStolen.Size = new System.Drawing.Size(237, 23);
            this.comboBoxInitMateriaStolen.TabIndex = 5;
            this.comboBoxInitMateriaStolen.SelectedIndexChanged += new System.EventHandler(this.comboBoxInitMateriaStolen_SelectedIndexChanged);
            // 
            // labelInitMateriaStolen
            // 
            this.labelInitMateriaStolen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInitMateriaStolen.AutoSize = true;
            this.labelInitMateriaStolen.Location = new System.Drawing.Point(6, 364);
            this.labelInitMateriaStolen.Name = "labelInitMateriaStolen";
            this.labelInitMateriaStolen.Size = new System.Drawing.Size(50, 15);
            this.labelInitMateriaStolen.TabIndex = 4;
            this.labelInitMateriaStolen.Text = "Materia:";
            // 
            // groupBoxInitMateria
            // 
            this.groupBoxInitMateria.Controls.Add(this.buttonInitMateriaEdit);
            this.groupBoxInitMateria.Controls.Add(this.comboBoxInitMateria);
            this.groupBoxInitMateria.Controls.Add(this.labelInitMateria);
            this.groupBoxInitMateria.Controls.Add(this.listBoxInitMateria);
            this.groupBoxInitMateria.Location = new System.Drawing.Point(257, 6);
            this.groupBoxInitMateria.Name = "groupBoxInitMateria";
            this.groupBoxInitMateria.Size = new System.Drawing.Size(250, 455);
            this.groupBoxInitMateria.TabIndex = 2;
            this.groupBoxInitMateria.TabStop = false;
            this.groupBoxInitMateria.Text = "Materia";
            // 
            // buttonInitMateriaEdit
            // 
            this.buttonInitMateriaEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInitMateriaEdit.Enabled = false;
            this.buttonInitMateriaEdit.Location = new System.Drawing.Point(6, 426);
            this.buttonInitMateriaEdit.Name = "buttonInitMateriaEdit";
            this.buttonInitMateriaEdit.Size = new System.Drawing.Size(238, 23);
            this.buttonInitMateriaEdit.TabIndex = 3;
            this.buttonInitMateriaEdit.Text = "Edit details...";
            this.buttonInitMateriaEdit.UseVisualStyleBackColor = true;
            // 
            // comboBoxInitMateria
            // 
            this.comboBoxInitMateria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInitMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInitMateria.Enabled = false;
            this.comboBoxInitMateria.FormattingEnabled = true;
            this.comboBoxInitMateria.Location = new System.Drawing.Point(6, 382);
            this.comboBoxInitMateria.Name = "comboBoxInitMateria";
            this.comboBoxInitMateria.Size = new System.Drawing.Size(238, 23);
            this.comboBoxInitMateria.TabIndex = 2;
            this.comboBoxInitMateria.SelectedIndexChanged += new System.EventHandler(this.comboBoxInitMateria_SelectedIndexChanged);
            // 
            // labelInitMateria
            // 
            this.labelInitMateria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInitMateria.AutoSize = true;
            this.labelInitMateria.Location = new System.Drawing.Point(6, 364);
            this.labelInitMateria.Name = "labelInitMateria";
            this.labelInitMateria.Size = new System.Drawing.Size(50, 15);
            this.labelInitMateria.TabIndex = 1;
            this.labelInitMateria.Text = "Materia:";
            // 
            // listBoxInitMateria
            // 
            this.listBoxInitMateria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxInitMateria.FormattingEnabled = true;
            this.listBoxInitMateria.ItemHeight = 15;
            this.listBoxInitMateria.Location = new System.Drawing.Point(6, 22);
            this.listBoxInitMateria.Name = "listBoxInitMateria";
            this.listBoxInitMateria.Size = new System.Drawing.Size(238, 334);
            this.listBoxInitMateria.TabIndex = 0;
            this.listBoxInitMateria.SelectedIndexChanged += new System.EventHandler(this.listBoxInitMateria_SelectedIndexChanged);
            // 
            // groupBoxInitInventory
            // 
            this.groupBoxInitInventory.Controls.Add(this.numericInitItemAmount);
            this.groupBoxInitInventory.Controls.Add(this.labelInitItemAmount);
            this.groupBoxInitInventory.Controls.Add(this.comboBoxInitItem);
            this.groupBoxInitInventory.Controls.Add(this.labelInitItem);
            this.groupBoxInitInventory.Controls.Add(this.listBoxInitInventory);
            this.groupBoxInitInventory.Location = new System.Drawing.Point(6, 6);
            this.groupBoxInitInventory.Name = "groupBoxInitInventory";
            this.groupBoxInitInventory.Size = new System.Drawing.Size(245, 455);
            this.groupBoxInitInventory.TabIndex = 1;
            this.groupBoxInitInventory.TabStop = false;
            this.groupBoxInitInventory.Text = "Inventory";
            // 
            // numericInitItemAmount
            // 
            this.numericInitItemAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericInitItemAmount.Enabled = false;
            this.numericInitItemAmount.Location = new System.Drawing.Point(6, 426);
            this.numericInitItemAmount.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericInitItemAmount.Name = "numericInitItemAmount";
            this.numericInitItemAmount.Size = new System.Drawing.Size(233, 23);
            this.numericInitItemAmount.TabIndex = 4;
            this.numericInitItemAmount.ValueChanged += new System.EventHandler(this.numericInitItemAmount_ValueChanged);
            // 
            // labelInitItemAmount
            // 
            this.labelInitItemAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInitItemAmount.AutoSize = true;
            this.labelInitItemAmount.Location = new System.Drawing.Point(6, 408);
            this.labelInitItemAmount.Name = "labelInitItemAmount";
            this.labelInitItemAmount.Size = new System.Drawing.Size(54, 15);
            this.labelInitItemAmount.TabIndex = 3;
            this.labelInitItemAmount.Text = "Amount:";
            // 
            // comboBoxInitItem
            // 
            this.comboBoxInitItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInitItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInitItem.Enabled = false;
            this.comboBoxInitItem.FormattingEnabled = true;
            this.comboBoxInitItem.Location = new System.Drawing.Point(6, 382);
            this.comboBoxInitItem.Name = "comboBoxInitItem";
            this.comboBoxInitItem.Size = new System.Drawing.Size(233, 23);
            this.comboBoxInitItem.TabIndex = 2;
            this.comboBoxInitItem.SelectedIndexChanged += new System.EventHandler(this.comboBoxInitItem_SelectedIndexChanged);
            // 
            // labelInitItem
            // 
            this.labelInitItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInitItem.AutoSize = true;
            this.labelInitItem.Location = new System.Drawing.Point(6, 364);
            this.labelInitItem.Name = "labelInitItem";
            this.labelInitItem.Size = new System.Drawing.Size(34, 15);
            this.labelInitItem.TabIndex = 1;
            this.labelInitItem.Text = "Item:";
            // 
            // listBoxInitInventory
            // 
            this.listBoxInitInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxInitInventory.FormattingEnabled = true;
            this.listBoxInitInventory.ItemHeight = 15;
            this.listBoxInitInventory.Location = new System.Drawing.Point(6, 22);
            this.listBoxInitInventory.Name = "listBoxInitInventory";
            this.listBoxInitInventory.Size = new System.Drawing.Size(233, 334);
            this.listBoxInitInventory.TabIndex = 0;
            this.listBoxInitInventory.SelectedIndexChanged += new System.EventHandler(this.listBoxInitInventory_SelectedIndexChanged);
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
            this.tabControlItems.Controls.Add(this.tabPageItems3);
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
            this.itemRestrictionsItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.itemRestrictionsItem.Location = new System.Drawing.Point(352, 291);
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
            this.targetDataControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetDataControlItem.Location = new System.Drawing.Point(7, 291);
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
            this.statusesControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.elementsControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementsControlItem.Location = new System.Drawing.Point(6, 6);
            this.elementsControlItem.MinimumSize = new System.Drawing.Size(370, 130);
            this.elementsControlItem.Name = "elementsControlItem";
            this.elementsControlItem.Size = new System.Drawing.Size(558, 130);
            this.elementsControlItem.TabIndex = 30;
            // 
            // tabPageItems3
            // 
            this.tabPageItems3.Controls.Add(this.specialAttackFlagsControlItem);
            this.tabPageItems3.Location = new System.Drawing.Point(4, 24);
            this.tabPageItems3.Name = "tabPageItems3";
            this.tabPageItems3.Size = new System.Drawing.Size(570, 441);
            this.tabPageItems3.TabIndex = 2;
            this.tabPageItems3.Text = "Page 3";
            this.tabPageItems3.UseVisualStyleBackColor = true;
            // 
            // specialAttackFlagsControlItem
            // 
            this.specialAttackFlagsControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specialAttackFlagsControlItem.Location = new System.Drawing.Point(3, 3);
            this.specialAttackFlagsControlItem.Name = "specialAttackFlagsControlItem";
            this.specialAttackFlagsControlItem.Size = new System.Drawing.Size(558, 100);
            this.specialAttackFlagsControlItem.TabIndex = 44;
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
            this.elementsControlWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementsControlWeapon.Location = new System.Drawing.Point(7, 305);
            this.elementsControlWeapon.MinimumSize = new System.Drawing.Size(370, 130);
            this.elementsControlWeapon.Name = "elementsControlWeapon";
            this.elementsControlWeapon.Size = new System.Drawing.Size(370, 130);
            this.elementsControlWeapon.TabIndex = 29;
            // 
            // comboBoxWeaponStatus
            // 
            this.comboBoxWeaponStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWeaponStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeaponStatus.FormattingEnabled = true;
            this.comboBoxWeaponStatus.Location = new System.Drawing.Point(383, 323);
            this.comboBoxWeaponStatus.Name = "comboBoxWeaponStatus";
            this.comboBoxWeaponStatus.Size = new System.Drawing.Size(177, 23);
            this.comboBoxWeaponStatus.TabIndex = 28;
            // 
            // statIncreaseControlWeapon
            // 
            this.statIncreaseControlWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.labelWeaponStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBoxWeaponMateriaSlots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWeaponMateriaSlots.Controls.Add(this.materiaSlotSelectorWeapon);
            this.groupBoxWeaponMateriaSlots.Controls.Add(this.labelWeaponMateriaGrowth);
            this.groupBoxWeaponMateriaSlots.Controls.Add(this.comboBoxWeaponMateriaGrowth);
            this.groupBoxWeaponMateriaSlots.Location = new System.Drawing.Point(341, 188);
            this.groupBoxWeaponMateriaSlots.Name = "groupBoxWeaponMateriaSlots";
            this.groupBoxWeaponMateriaSlots.Size = new System.Drawing.Size(223, 111);
            this.groupBoxWeaponMateriaSlots.TabIndex = 20;
            this.groupBoxWeaponMateriaSlots.TabStop = false;
            this.groupBoxWeaponMateriaSlots.Text = "Materia slots";
            // 
            // materiaSlotSelectorWeapon
            // 
            this.materiaSlotSelectorWeapon.BackColor = System.Drawing.Color.LightSlateGray;
            this.materiaSlotSelectorWeapon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materiaSlotSelectorWeapon.GrowthRate = Shojy.FF7.Elena.Equipment.GrowthRate.None;
            this.materiaSlotSelectorWeapon.Location = new System.Drawing.Point(6, 22);
            this.materiaSlotSelectorWeapon.Name = "materiaSlotSelectorWeapon";
            this.materiaSlotSelectorWeapon.SelectedSlot = -1;
            this.materiaSlotSelectorWeapon.Size = new System.Drawing.Size(211, 35);
            this.materiaSlotSelectorWeapon.SlotSelectorType = FF7Scarlet.KernelEditor.Controls.SlotSelectorType.Slots;
            this.materiaSlotSelectorWeapon.TabIndex = 3;
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
            this.tabPageWeapon2.Controls.Add(this.groupBoxWeaponSoundIDs);
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
            // groupBoxWeaponSoundIDs
            // 
            this.groupBoxWeaponSoundIDs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWeaponSoundIDs.Location = new System.Drawing.Point(340, 156);
            this.groupBoxWeaponSoundIDs.Name = "groupBoxWeaponSoundIDs";
            this.groupBoxWeaponSoundIDs.Size = new System.Drawing.Size(224, 138);
            this.groupBoxWeaponSoundIDs.TabIndex = 30;
            this.groupBoxWeaponSoundIDs.TabStop = false;
            this.groupBoxWeaponSoundIDs.Text = "Sound IDs";
            // 
            // targetDataControlWeapon
            // 
            this.targetDataControlWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetDataControlWeapon.Location = new System.Drawing.Point(6, 156);
            this.targetDataControlWeapon.Name = "targetDataControlWeapon";
            this.targetDataControlWeapon.Size = new System.Drawing.Size(328, 138);
            this.targetDataControlWeapon.TabIndex = 29;
            // 
            // damageCalculationControlWeapon
            // 
            this.damageCalculationControlWeapon.AccuracyCalculation = FF7Scarlet.AccuracyCalculation.NoMiss1;
            this.damageCalculationControlWeapon.ActualValue = ((byte)(0));
            this.damageCalculationControlWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.damageCalculationControlWeapon.AttackPower = ((byte)(0));
            this.damageCalculationControlWeapon.CanCrit = false;
            this.damageCalculationControlWeapon.DamageFormula = FF7Scarlet.DamageFormulas.NoDamage;
            this.damageCalculationControlWeapon.DamageType = FF7Scarlet.DamageType.Physical;
            this.damageCalculationControlWeapon.Location = new System.Drawing.Point(6, 3);
            this.damageCalculationControlWeapon.Name = "damageCalculationControlWeapon";
            this.damageCalculationControlWeapon.Size = new System.Drawing.Size(558, 147);
            this.damageCalculationControlWeapon.TabIndex = 26;
            // 
            // equipableListWeapon
            // 
            this.equipableListWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equipableListWeapon.Location = new System.Drawing.Point(6, 300);
            this.equipableListWeapon.MinimumSize = new System.Drawing.Size(280, 125);
            this.equipableListWeapon.Name = "equipableListWeapon";
            this.equipableListWeapon.Size = new System.Drawing.Size(328, 125);
            this.equipableListWeapon.TabIndex = 20;
            // 
            // itemRestrictionsWeapon
            // 
            this.itemRestrictionsWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.itemRestrictionsWeapon.Location = new System.Drawing.Point(340, 300);
            this.itemRestrictionsWeapon.Name = "itemRestrictionsWeapon";
            this.itemRestrictionsWeapon.ShowThrowable = false;
            this.itemRestrictionsWeapon.Size = new System.Drawing.Size(224, 125);
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
            this.labelArmorElementModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.comboBoxArmorElementModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.comboBoxArmorStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.elementsControlArmor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementsControlArmor.Location = new System.Drawing.Point(7, 305);
            this.elementsControlArmor.MinimumSize = new System.Drawing.Size(370, 130);
            this.elementsControlArmor.Name = "elementsControlArmor";
            this.elementsControlArmor.Size = new System.Drawing.Size(370, 130);
            this.elementsControlArmor.TabIndex = 33;
            // 
            // labelArmorStatus
            // 
            this.labelArmorStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.statIncreaseControlArmor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBoxArmorMateriaSlots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxArmorMateriaSlots.Controls.Add(this.materiaSlotSelectorArmor);
            this.groupBoxArmorMateriaSlots.Controls.Add(this.labelArmorMateriaGrowth);
            this.groupBoxArmorMateriaSlots.Controls.Add(this.comboBoxArmorMateriaGrowth);
            this.groupBoxArmorMateriaSlots.Location = new System.Drawing.Point(341, 188);
            this.groupBoxArmorMateriaSlots.Name = "groupBoxArmorMateriaSlots";
            this.groupBoxArmorMateriaSlots.Size = new System.Drawing.Size(223, 111);
            this.groupBoxArmorMateriaSlots.TabIndex = 23;
            this.groupBoxArmorMateriaSlots.TabStop = false;
            this.groupBoxArmorMateriaSlots.Text = "Materia slots";
            // 
            // materiaSlotSelectorArmor
            // 
            this.materiaSlotSelectorArmor.BackColor = System.Drawing.Color.LightSlateGray;
            this.materiaSlotSelectorArmor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materiaSlotSelectorArmor.GrowthRate = Shojy.FF7.Elena.Equipment.GrowthRate.None;
            this.materiaSlotSelectorArmor.Location = new System.Drawing.Point(6, 22);
            this.materiaSlotSelectorArmor.Name = "materiaSlotSelectorArmor";
            this.materiaSlotSelectorArmor.SelectedSlot = -1;
            this.materiaSlotSelectorArmor.Size = new System.Drawing.Size(211, 35);
            this.materiaSlotSelectorArmor.SlotSelectorType = FF7Scarlet.KernelEditor.Controls.SlotSelectorType.Slots;
            this.materiaSlotSelectorArmor.TabIndex = 4;
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
            this.itemRestrictionsArmor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.itemRestrictionsArmor.Location = new System.Drawing.Point(339, 6);
            this.itemRestrictionsArmor.Name = "itemRestrictionsArmor";
            this.itemRestrictionsArmor.ShowThrowable = false;
            this.itemRestrictionsArmor.Size = new System.Drawing.Size(224, 125);
            this.itemRestrictionsArmor.TabIndex = 32;
            // 
            // equipableListArmor
            // 
            this.equipableListArmor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.labelAccessoryElementModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAccessoryElementModifier.AutoSize = true;
            this.labelAccessoryElementModifier.Location = new System.Drawing.Point(383, 94);
            this.labelAccessoryElementModifier.Name = "labelAccessoryElementModifier";
            this.labelAccessoryElementModifier.Size = new System.Drawing.Size(147, 15);
            this.labelAccessoryElementModifier.TabIndex = 36;
            this.labelAccessoryElementModifier.Text = "Element damage modifier:";
            // 
            // comboBoxAccessoryElementModifier
            // 
            this.comboBoxAccessoryElementModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAccessoryElementModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccessoryElementModifier.FormattingEnabled = true;
            this.comboBoxAccessoryElementModifier.Location = new System.Drawing.Point(383, 112);
            this.comboBoxAccessoryElementModifier.Name = "comboBoxAccessoryElementModifier";
            this.comboBoxAccessoryElementModifier.Size = new System.Drawing.Size(180, 23);
            this.comboBoxAccessoryElementModifier.TabIndex = 37;
            // 
            // statusesControlAccessory
            // 
            this.statusesControlAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.elementsControlAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementsControlAccessory.Location = new System.Drawing.Point(7, 94);
            this.elementsControlAccessory.MinimumSize = new System.Drawing.Size(370, 130);
            this.elementsControlAccessory.Name = "elementsControlAccessory";
            this.elementsControlAccessory.Size = new System.Drawing.Size(370, 131);
            this.elementsControlAccessory.TabIndex = 26;
            // 
            // statIncreaseControlAccessory
            // 
            this.statIncreaseControlAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.comboBoxAccessorySpecialEffects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.equipableListAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equipableListAccessory.Location = new System.Drawing.Point(6, 50);
            this.equipableListAccessory.MinimumSize = new System.Drawing.Size(280, 125);
            this.equipableListAccessory.Name = "equipableListAccessory";
            this.equipableListAccessory.Size = new System.Drawing.Size(311, 125);
            this.equipableListAccessory.TabIndex = 24;
            // 
            // itemRestrictionsAccessory
            // 
            this.itemRestrictionsAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.statusesControlMateria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusesControlMateria.FullList = true;
            this.statusesControlMateria.GroupBoxText = "Statuses";
            this.statusesControlMateria.Location = new System.Drawing.Point(190, 200);
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
            this.materiaLevelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materiaLevelControl.Location = new System.Drawing.Point(576, 148);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KernelForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KernelForm_FormClosed);
            this.Load += new System.EventHandler(this.KernelForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCommandData.ResumeLayout(false);
            this.tabPageCommandData.PerformLayout();
            this.tabPageAttackData.ResumeLayout(false);
            this.tabControlAttacks.ResumeLayout(false);
            this.tabPageAttacks1.ResumeLayout(false);
            this.tabPageAttacks1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackAttackPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackMPCost)).EndInit();
            this.tabPageAttacks2.ResumeLayout(false);
            this.tabPageAttacks2.PerformLayout();
            this.groupBoxAttackSpecialActions.ResumeLayout(false);
            this.groupBoxAttackSpecialActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackStatusChangeChance)).EndInit();
            this.tabPageInitData.ResumeLayout(false);
            this.tabControlInitialData.ResumeLayout(false);
            this.tabPageInitCharacterStats.ResumeLayout(false);
            this.tabPageInitCharacterStats.PerformLayout();
            this.groupBoxCharacterMP.ResumeLayout(false);
            this.groupBoxCharacterMP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterMaxMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterBaseMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterCurrMP)).EndInit();
            this.groupBoxCharacterHP.ResumeLayout(false);
            this.groupBoxCharacterHP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterMaxHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterBaseHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterCurrHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterEXPtoNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterKillCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterCurrentEXP)).EndInit();
            this.groupBoxCharacterArmor.ResumeLayout(false);
            this.groupBoxCharacterWeapon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharacterID)).EndInit();
            this.tabPageInitInventory.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxInitMateria.ResumeLayout(false);
            this.groupBoxInitMateria.PerformLayout();
            this.groupBoxInitInventory.ResumeLayout(false);
            this.groupBoxInitInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInitItemAmount)).EndInit();
            this.tabPageItemData.ResumeLayout(false);
            this.tabControlItems.ResumeLayout(false);
            this.tabPageItems1.ResumeLayout(false);
            this.tabPageItems1.PerformLayout();
            this.tabPageItems2.ResumeLayout(false);
            this.tabPageItems2.PerformLayout();
            this.tabPageItems3.ResumeLayout(false);
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
        private Label labelWeaponMateriaGrowth;
        private ComboBox comboBoxWeaponMateriaGrowth;
        private GroupBox groupBoxArmorMateriaSlots;
        private Label labelArmorMateriaGrowth;
        private ComboBox comboBoxArmorMateriaGrowth;
        private ComboBox comboBoxItemCamMovementID;
        private Label labelItemCamMovementID;
        private ComboBox comboBoxItemAttackEffectID;
        private Label labelItemAttackEffectID;
        private Controls.DamageCalculationControl damageCalculationControlItem;
        private Controls.DamageCalculationControl damageCalculationControlWeapon;
        private TabControl tabControlWeapons;
        private TabPage tabPageWeapon1;
        private TabPage tabPageWeapon2;
        private ComboBox comboBoxWeaponStatus;
        private Label labelWeaponStatus;
        private ComboBox comboBoxArmorStatus;
        private Label labelArmorStatus;
        private Controls.StatusesControl statusesControlAccessory;
        private Controls.EquipableListControl equipableListAccessory;
        private Controls.EquipableListControl equipableListArmor;
        private Controls.EquipableListControl equipableListWeapon;
        private Controls.TargetDataControl targetDataControlItem;
        private Controls.TargetDataControl targetDataControlWeapon;
        private TabControl tabControlAccessories;
        private TabPage tabPageAccessory1;
        private TabPage tabPageAccessory2;
        private Label labelWeaponCritChance;
        private Label labelWeaponHitChance;
        private Controls.ItemRestrictionsControl itemRestrictionsWeapon;
        private Controls.ItemRestrictionsControl itemRestrictionsItem;
        private Controls.ItemRestrictionsControl itemRestrictionsArmor;
        private Controls.ItemRestrictionsControl itemRestrictionsAccessory;
        private Controls.ElementsControl elementsControlWeapon;
        private Controls.ElementsControl elementsControlArmor;
        private Controls.ElementsControl elementsControlAccessory;
        private TabControl tabControlItems;
        private TabPage tabPageItems1;
        private TabPage tabPageItems2;
        private Controls.ElementsControl elementsControlItem;
        private TabControl tabControlArmor;
        private TabPage tabPageArmor1;
        private TabPage tabPageArmor2;
        private Controls.StatusesControl statusesControlItem;
        private Label labelWeaponModelIndex;
        private NumericUpDown numericWeaponModelIndex;
        private NumericUpDown numericWeaponAnimationIndex;
        private Label labelWeaponAnimationIndex;
        private Controls.StatIncreaseControl statIncreaseControlWeapon;
        private Controls.StatIncreaseControl statIncreaseControlArmor;
        private Controls.StatIncreaseControl statIncreaseControlAccessory;
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
        private Controls.MateriaLevelControl materiaLevelControl;
        private ComboBox comboBoxMateriaSubtype;
        private Label labelMateriaSubtype;
        private Controls.StatusesControl statusesControlMateria;
        private Label labelMateriaEquipAttributes;
        private ComboBox comboBoxMateriaEquipAttributes;
        private Label labelCommandCameraMovementIDMulti;
        private ComboBox comboBoxCommandCamMovementIDMulti;
        private Label labelCommandCamMovementIDSingle;
        private ComboBox comboBoxCommandCameraMovementIDSingle;
        private ComboBox comboBoxCommandInitialCursorAction;
        private Label labelCommandInitialCursorAction;
        private Controls.TargetDataControl targetDataControlCommand;
        private GroupBox groupBoxWeaponSoundIDs;
        private Label labelAttackMPCost;
        private NumericUpDown numericAttackMPCost;
        private NumericUpDown numericAttackAttackPercent;
        private Label labelAttackAttackPercent;
        private Label labelAttackCamMovementIDMulti;
        private ComboBox comboBoxAttackCamMovementIDMulti;
        private Label labelAttackCamMovementIDSingle;
        private ComboBox comboBoxAttackCamMovementIDSingle;
        private Controls.DamageCalculationControl damageCalculationControlAttack;
        private TabControl tabControlAttacks;
        private TabPage tabPageAttacks1;
        private TabPage tabPageAttacks2;
        private Controls.StatusesControl statusesControlAttack;
        private Controls.ElementsControl elementsControlAttack;
        private Label labelAttackStatusChange;
        private ComboBox comboBoxAttackStatusChange;
        private NumericUpDown numericAttackStatusChangeChance;
        private Label labelAttackStatusChangeChance;
        private Label labelAttackImpactEffectID;
        private ComboBox comboBoxAttackImpactEffectID;
        private Label labelAttackAttackEffectID;
        private ComboBox comboBoxAttackAttackEffectID;
        private Label labelAttackHurtActionIndex;
        private ComboBox comboBoxAttackHurtActionIndex;
        private ComboBox comboBoxAttackConditionSubMenu;
        private Label labelAttackConditionSubMenu;
        private Shared.SpecialAttackFlagsControl specialAttackFlagsControlAttack;
        private GroupBox groupBoxAttackSpecialActions;
        private CheckBox checkBoxAttackSyncWithSceneBin;
        private Button buttonAttackSyncAll;
        private TabPage tabPageItems3;
        private Shared.SpecialAttackFlagsControl specialAttackFlagsControlItem;
        private TabControl tabControlInitialData;
        private TabPage tabPageInitCharacterStats;
        private TabPage tabPageInitInventory;
        private ListBox listBoxInitCharacters;
        private TextBox textBoxCharacterName;
        private Label labelCharacterName;
        private NumericUpDown numericCharacterID;
        private Label labelCharacterID;
        private CheckBox checkBoxCharacterBackRow;
        private NumericUpDown numericCharacterLevel;
        private Label labelCharacterLevel;
        private ComboBox comboBoxCharacterAccessory;
        private Label labelCharacterAccessory;
        private ComboBox comboBoxCharacterArmor;
        private ComboBox comboBoxCharacterWeapon;
        private Controls.CharacterStatsControl characterStatsControl;
        private GroupBox groupBoxInitInventory;
        private NumericUpDown numericInitItemAmount;
        private Label labelInitItemAmount;
        private ComboBox comboBoxInitItem;
        private Label labelInitItem;
        private ListBox listBoxInitInventory;
        private GroupBox groupBoxInitMateria;
        private ListBox listBoxInitMateria;
        private Button buttonInitMateriaEdit;
        private ComboBox comboBoxInitMateria;
        private Label labelInitMateria;
        private Controls.MateriaSlotSelectorControl materiaSlotSelectorWeapon;
        private Controls.MateriaSlotSelectorControl materiaSlotSelectorArmor;
        private GroupBox groupBoxCharacterArmor;
        private Controls.MateriaSlotSelectorControl materiaSlotSelectorCharacterArmor;
        private GroupBox groupBoxCharacterWeapon;
        private Controls.MateriaSlotSelectorControl materiaSlotSelectorCharacterWeapon;
        private Button buttonCharacterArmorChangeMateria;
        private Button buttonCharacterWeaponChangeMateria;
        private NumericUpDown numericCharacterCurrentEXP;
        private Label labelCharacterCurrentEXP;
        private Controls.CharacterLimitControl characterLimitControl;
        private ComboBox comboBoxCharacterFlags;
        private Label labelCharacterFlags;
        private NumericUpDown numericCharacterKillCount;
        private Label labelCharacterKillCount;
        private NumericUpDown numericCharacterEXPtoNext;
        private Label labelCharacterEXPtoNext;
        private GroupBox groupBoxCharacterMP;
        private NumericUpDown numericCharacterMaxMP;
        private Label labelCharacterMaxMP;
        private NumericUpDown numericCharacterBaseMP;
        private Label labelCharacterBaseMP;
        private NumericUpDown numericCharacterCurrMP;
        private Label labelCharacterCurrMP;
        private GroupBox groupBoxCharacterHP;
        private NumericUpDown numericCharacterMaxHP;
        private Label labelCharacterMaxHP;
        private NumericUpDown numericCharacterBaseHP;
        private Label labelCharacterBaseHP;
        private NumericUpDown numericCharacterCurrHP;
        private Label labelCharacterCurrHP;
        private GroupBox groupBox1;
        private Button buttonInitMateriaStolenEdit;
        private ComboBox comboBoxInitMateriaStolen;
        private Label labelInitMateriaStolen;
        private ListBox listBoxInitMateriaStolen;
    }
}