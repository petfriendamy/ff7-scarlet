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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KernelForm));
            tabControlMain = new TabControl();
            tabPageCommandData = new TabPage();
            labelCommandID = new Label();
            comboBoxCommandInitialCursorAction = new ComboBox();
            labelCommandInitialCursorAction = new Label();
            targetDataControlCommand = new FF7Scarlet.KernelEditor.Controls.TargetDataControl();
            labelCommandCameraMovementIDMulti = new Label();
            comboBoxCommandCamMovementIDMulti = new ComboBox();
            labelCommandCamMovementIDSingle = new Label();
            comboBoxCommandCameraMovementIDSingle = new ComboBox();
            textBoxCommandDescription = new TextBox();
            labelCommandDescription = new Label();
            textBoxCommandName = new TextBox();
            labelCommandName = new Label();
            listBoxCommands = new ListBox();
            tabPageAttackData = new TabPage();
            attackFormControl = new FF7Scarlet.Shared.Controls.AttackFormControl();
            comboBoxAttackType = new ComboBox();
            listBoxAttacks = new ListBox();
            tabPageCharacters = new TabPage();
            tabControlCharacters = new TabControl();
            tabPageInitCharacterStats = new TabPage();
            numericCharacterLevelOffset = new NumericUpDown();
            labelCharacterLevelOffset = new Label();
            groupBoxCharacterMP = new GroupBox();
            numericCharacterMaxMP = new NumericUpDown();
            labelCharacterMaxMP = new Label();
            numericCharacterBaseMP = new NumericUpDown();
            labelCharacterBaseMP = new Label();
            numericCharacterCurrMP = new NumericUpDown();
            labelCharacterCurrMP = new Label();
            groupBoxCharacterHP = new GroupBox();
            numericCharacterMaxHP = new NumericUpDown();
            labelCharacterMaxHP = new Label();
            numericCharacterBaseHP = new NumericUpDown();
            labelCharacterBaseHP = new Label();
            numericCharacterCurrHP = new NumericUpDown();
            labelCharacterCurrHP = new Label();
            numericCharacterEXPtoNext = new NumericUpDown();
            labelCharacterEXPtoNext = new Label();
            numericCharacterKillCount = new NumericUpDown();
            labelCharacterKillCount = new Label();
            comboBoxCharacterFlags = new ComboBox();
            labelCharacterFlags = new Label();
            characterLimitControl = new FF7Scarlet.Shared.Controls.CharacterLimitControl();
            numericCharacterCurrentEXP = new NumericUpDown();
            labelCharacterCurrentEXP = new Label();
            groupBoxCharacterArmor = new GroupBox();
            buttonCharacterArmorChangeMateria = new Button();
            materiaSlotSelectorCharacterArmor = new FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl();
            comboBoxCharacterArmor = new ComboBox();
            groupBoxCharacterWeapon = new GroupBox();
            buttonCharacterWeaponChangeMateria = new Button();
            materiaSlotSelectorCharacterWeapon = new FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl();
            comboBoxCharacterWeapon = new ComboBox();
            characterStatsControl = new FF7Scarlet.Shared.Controls.CharacterStatsControl();
            checkBoxCharacterBackRow = new CheckBox();
            numericCharacterLevel = new NumericUpDown();
            labelCharacterLevel = new Label();
            comboBoxCharacterAccessory = new ComboBox();
            labelCharacterAccessory = new Label();
            numericCharacterID = new NumericUpDown();
            labelCharacterID = new Label();
            textBoxCharacterName = new TextBox();
            labelCharacterName = new Label();
            listBoxInitCharacters = new ListBox();
            tabPageCharacterLimits = new TabPage();
            limitRequirementControl4 = new FF7Scarlet.KernelEditor.Controls.LimitRequirementControl();
            limitRequirementControl3 = new FF7Scarlet.KernelEditor.Controls.LimitRequirementControl();
            limitRequirementControl2 = new FF7Scarlet.KernelEditor.Controls.LimitRequirementControl();
            limitRequirementControl1 = new FF7Scarlet.KernelEditor.Controls.LimitRequirementControl();
            listBoxCharacterLimits = new ListBox();
            tabPageCharacterGrowth = new TabPage();
            groupBoxSelectedCurve = new GroupBox();
            labelCurveMax = new Label();
            labelCurveMin = new Label();
            labelCurveLevel = new Label();
            labelInaccurateCurve = new Label();
            buttonEditBaseCurve = new Button();
            groupBoxCurveBonuses = new GroupBox();
            labelCurveExplanation = new Label();
            numericCurveBonus12 = new NumericUpDown();
            numericCurveBonus11 = new NumericUpDown();
            numericCurveBonus10 = new NumericUpDown();
            numericCurveBonus9 = new NumericUpDown();
            numericCurveBonus8 = new NumericUpDown();
            numericCurveBonus7 = new NumericUpDown();
            numericCurveBonus6 = new NumericUpDown();
            numericCurveBonus5 = new NumericUpDown();
            numericCurveBonus4 = new NumericUpDown();
            numericCurveBonus3 = new NumericUpDown();
            numericCurveBonus2 = new NumericUpDown();
            numericCurveBonus1 = new NumericUpDown();
            numericCurveIndex = new NumericUpDown();
            labelCurveIndex = new Label();
            chartMainCurve = new System.Windows.Forms.DataVisualization.Charting.Chart();
            listBoxStatCurves = new ListBox();
            listBoxCharacterGrowth = new ListBox();
            tabPageCharacterAI = new TabPage();
            scriptControlCharacterAI = new FF7Scarlet.AIEditor.ScriptControl();
            groupBoxCharacterAI = new GroupBox();
            listBoxCharacterAI = new ListBox();
            groupBoxCharacterScripts = new GroupBox();
            listBoxCharacterScripts = new ListBox();
            tabPageInitData = new TabPage();
            numericStartingGil = new NumericUpDown();
            labelStartingGil = new Label();
            groupBoxStartingParty = new GroupBox();
            comboBoxParty3 = new ComboBox();
            comboBoxParty2 = new ComboBox();
            comboBoxParty1 = new ComboBox();
            groupBoxInitMateriaStolen = new GroupBox();
            listBoxInitMateriaStolen = new ListBox();
            buttonInitMateriaStolenEdit = new Button();
            comboBoxInitMateriaStolen = new ComboBox();
            labelInitMateriaStolen = new Label();
            groupBoxInitMateria = new GroupBox();
            buttonInitMateriaEdit = new Button();
            comboBoxInitMateria = new ComboBox();
            labelInitMateria = new Label();
            listBoxInitMateria = new ListBox();
            groupBoxInitInventory = new GroupBox();
            numericInitItemAmount = new NumericUpDown();
            labelInitItemAmount = new Label();
            comboBoxInitItem = new ComboBox();
            labelInitItem = new Label();
            listBoxInitInventory = new ListBox();
            tabPageItemData = new TabPage();
            tabControlItems = new TabControl();
            tabPageItems1 = new TabPage();
            labelItemID = new Label();
            labelItemName = new Label();
            itemRestrictionsItem = new FF7Scarlet.KernelEditor.Controls.ItemRestrictionsControl();
            damageCalculationControlItem = new FF7Scarlet.KernelEditor.Controls.DamageCalculationControl();
            textBoxItemName = new TextBox();
            targetDataControlItem = new FF7Scarlet.KernelEditor.Controls.TargetDataControl();
            labelItemDescription = new Label();
            textBoxItemDescription = new TextBox();
            comboBoxItemAttackEffectID = new ComboBox();
            labelItemCamMovementID = new Label();
            labelItemAttackEffectID = new Label();
            comboBoxItemCamMovementID = new ComboBox();
            tabPageItems2 = new TabPage();
            comboBoxItemStatusChange = new ComboBox();
            labelItemStatusChange = new Label();
            statusesControlItem = new FF7Scarlet.KernelEditor.Controls.StatusesControl();
            elementsControlItem = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            tabPageItems3 = new TabPage();
            specialAttackFlagsControlItem = new FF7Scarlet.Shared.SpecialAttackFlagsControl();
            listBoxItems = new ListBox();
            tabPageWeaponData = new TabPage();
            tabControlWeapons = new TabControl();
            tabPageWeapon1 = new TabPage();
            labelWeaponID = new Label();
            numericWeaponCritChance = new NumericUpDown();
            numericWeaponHitChance = new NumericUpDown();
            elementsControlWeapon = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            comboBoxWeaponStatus = new ComboBox();
            statIncreaseControlWeapon = new FF7Scarlet.KernelEditor.Controls.StatIncreaseControl();
            numericWeaponAnimationIndex = new NumericUpDown();
            labelWeaponAnimationIndex = new Label();
            labelWeaponStatus = new Label();
            numericWeaponModelIndex = new NumericUpDown();
            labelWeaponModelIndex = new Label();
            groupBoxWeaponMateriaSlots = new GroupBox();
            materiaSlotSelectorWeapon = new FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl();
            labelWeaponMateriaGrowth = new Label();
            comboBoxWeaponMateriaGrowth = new ComboBox();
            labelWeaponCritChance = new Label();
            labelWeaponHitChance = new Label();
            textBoxWeaponName = new TextBox();
            labelWeaponName = new Label();
            labelWeaponDescription = new Label();
            textBoxWeaponDescription = new TextBox();
            tabPageWeapon2 = new TabPage();
            groupBoxWeaponSoundIDs = new GroupBox();
            targetDataControlWeapon = new FF7Scarlet.KernelEditor.Controls.TargetDataControl();
            damageCalculationControlWeapon = new FF7Scarlet.KernelEditor.Controls.DamageCalculationControl();
            equipableListWeapon = new FF7Scarlet.KernelEditor.Controls.EquipableListControl();
            itemRestrictionsWeapon = new FF7Scarlet.KernelEditor.Controls.ItemRestrictionsControl();
            listBoxWeapons = new ListBox();
            tabPageArmorData = new TabPage();
            tabControlArmor = new TabControl();
            tabPageArmor1 = new TabPage();
            labelArmorID = new Label();
            labelArmorElementModifier = new Label();
            numericArmorMagicDefensePercent = new NumericUpDown();
            labelArmorMagicDefensePercent = new Label();
            numericArmorMagicDefense = new NumericUpDown();
            comboBoxArmorElementModifier = new ComboBox();
            labelArmorMagicDefense = new Label();
            comboBoxArmorStatus = new ComboBox();
            numericArmorDefensePercent = new NumericUpDown();
            elementsControlArmor = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            labelArmorStatus = new Label();
            labelArmorDefencePercent = new Label();
            numericArmorDefense = new NumericUpDown();
            labelArmorDefense = new Label();
            statIncreaseControlArmor = new FF7Scarlet.KernelEditor.Controls.StatIncreaseControl();
            labelArmorName = new Label();
            textBoxArmorName = new TextBox();
            labelArmorDescription = new Label();
            groupBoxArmorMateriaSlots = new GroupBox();
            materiaSlotSelectorArmor = new FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl();
            labelArmorMateriaGrowth = new Label();
            comboBoxArmorMateriaGrowth = new ComboBox();
            textBoxArmorDescription = new TextBox();
            tabPageArmor2 = new TabPage();
            itemRestrictionsArmor = new FF7Scarlet.KernelEditor.Controls.ItemRestrictionsControl();
            equipableListArmor = new FF7Scarlet.KernelEditor.Controls.EquipableListControl();
            listBoxArmor = new ListBox();
            tabPageAccessoryData = new TabPage();
            tabControlAccessories = new TabControl();
            tabPageAccessory1 = new TabPage();
            labelAccessoryID = new Label();
            labelAccessoryElementModifier = new Label();
            comboBoxAccessoryElementModifier = new ComboBox();
            statusesControlAccessory = new FF7Scarlet.KernelEditor.Controls.StatusesControl();
            elementsControlAccessory = new FF7Scarlet.KernelEditor.Controls.ElementsControl();
            statIncreaseControlAccessory = new FF7Scarlet.KernelEditor.Controls.StatIncreaseControl();
            labelAccessoryName = new Label();
            textBoxAccessoryName = new TextBox();
            labelAccessoryDescription = new Label();
            textBoxAccessoryDescription = new TextBox();
            tabPageAccessory2 = new TabPage();
            comboBoxAccessorySpecialEffects = new ComboBox();
            labelAccessorySpecialEffects = new Label();
            equipableListAccessory = new FF7Scarlet.KernelEditor.Controls.EquipableListControl();
            itemRestrictionsAccessory = new FF7Scarlet.KernelEditor.Controls.ItemRestrictionsControl();
            listBoxAccessories = new ListBox();
            tabPageMateriaData = new TabPage();
            labelMateriaID = new Label();
            buttonMateriaAttributes = new Button();
            comboBoxMateriaEquipAttributes = new ComboBox();
            labelMateriaEquipAttributes = new Label();
            statusesControlMateria = new FF7Scarlet.KernelEditor.Controls.StatusesControl();
            comboBoxMateriaSubtype = new ComboBox();
            labelMateriaSubtype = new Label();
            materiaLevelControl = new FF7Scarlet.KernelEditor.Controls.MateriaLevelControl();
            comboBoxMateriaElement = new ComboBox();
            labelMateriaElement = new Label();
            comboBoxMateriaType = new ComboBox();
            labelMateriaType = new Label();
            textBoxMateriaDescription = new TextBox();
            labelMateriaDescription = new Label();
            textBoxMateriaName = new TextBox();
            labelMateriaName = new Label();
            listBoxMateria = new ListBox();
            tabPageKeyItemText = new TabPage();
            textBoxKeyItemDescription = new TextBox();
            labelKeyItemDescription = new Label();
            textBoxKeyItemName = new TextBox();
            labelKeyItemName = new Label();
            listBoxKeyItems = new ListBox();
            tabPageMisc = new TabPage();
            tabControlMisc = new TabControl();
            tabPageLimitBreaks = new TabPage();
            textBoxLimitDescription = new TextBox();
            labelLimitDescription = new Label();
            textBoxLimitName = new TextBox();
            labelLimitName = new Label();
            listBoxLimitBreaks = new ListBox();
            tabPageBattleText = new TabPage();
            listBoxBattleText = new ListBox();
            textBoxBattleText = new TextBox();
            labelBattleText = new Label();
            tabPageBattleRNGTable = new TabPage();
            rngTableControl = new FF7Scarlet.KernelEditor.Controls.RNGTableControl();
            buttonSave = new Button();
            buttonImport = new Button();
            buttonExport = new Button();
            panelButtons = new Panel();
            toolStripMain = new ToolStrip();
            toolStripDropDownFile = new ToolStripDropDownButton();
            saveKernelFilesToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownEdit = new ToolStripDropDownButton();
            selectedAttackToolStripMenuItem = new ToolStripMenuItem();
            createNewAttackToolStripMenuItem = new ToolStripMenuItem();
            attackCopyToolStripMenuItem = new ToolStripMenuItem();
            attackPasteToolStripMenuItem = new ToolStripMenuItem();
            attackDeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownTools = new ToolStripDropDownButton();
            useKernel2StringsToolStripMenuItem = new ToolStripMenuItem();
            tabControlMain.SuspendLayout();
            tabPageCommandData.SuspendLayout();
            tabPageAttackData.SuspendLayout();
            tabPageCharacters.SuspendLayout();
            tabControlCharacters.SuspendLayout();
            tabPageInitCharacterStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericCharacterLevelOffset).BeginInit();
            groupBoxCharacterMP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericCharacterMaxMP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterBaseMP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterCurrMP).BeginInit();
            groupBoxCharacterHP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericCharacterMaxHP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterBaseHP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterCurrHP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterEXPtoNext).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterKillCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterCurrentEXP).BeginInit();
            groupBoxCharacterArmor.SuspendLayout();
            groupBoxCharacterWeapon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericCharacterLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterID).BeginInit();
            tabPageCharacterLimits.SuspendLayout();
            tabPageCharacterGrowth.SuspendLayout();
            groupBoxSelectedCurve.SuspendLayout();
            groupBoxCurveBonuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveIndex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartMainCurve).BeginInit();
            tabPageCharacterAI.SuspendLayout();
            groupBoxCharacterAI.SuspendLayout();
            groupBoxCharacterScripts.SuspendLayout();
            tabPageInitData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericStartingGil).BeginInit();
            groupBoxStartingParty.SuspendLayout();
            groupBoxInitMateriaStolen.SuspendLayout();
            groupBoxInitMateria.SuspendLayout();
            groupBoxInitInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericInitItemAmount).BeginInit();
            tabPageItemData.SuspendLayout();
            tabControlItems.SuspendLayout();
            tabPageItems1.SuspendLayout();
            tabPageItems2.SuspendLayout();
            tabPageItems3.SuspendLayout();
            tabPageWeaponData.SuspendLayout();
            tabControlWeapons.SuspendLayout();
            tabPageWeapon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericWeaponCritChance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericWeaponHitChance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericWeaponAnimationIndex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericWeaponModelIndex).BeginInit();
            groupBoxWeaponMateriaSlots.SuspendLayout();
            tabPageWeapon2.SuspendLayout();
            tabPageArmorData.SuspendLayout();
            tabControlArmor.SuspendLayout();
            tabPageArmor1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericArmorMagicDefensePercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericArmorMagicDefense).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericArmorDefensePercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericArmorDefense).BeginInit();
            groupBoxArmorMateriaSlots.SuspendLayout();
            tabPageArmor2.SuspendLayout();
            tabPageAccessoryData.SuspendLayout();
            tabControlAccessories.SuspendLayout();
            tabPageAccessory1.SuspendLayout();
            tabPageAccessory2.SuspendLayout();
            tabPageMateriaData.SuspendLayout();
            tabPageKeyItemText.SuspendLayout();
            tabPageMisc.SuspendLayout();
            tabControlMisc.SuspendLayout();
            tabPageLimitBreaks.SuspendLayout();
            tabPageBattleText.SuspendLayout();
            tabPageBattleRNGTable.SuspendLayout();
            panelButtons.SuspendLayout();
            toolStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageCommandData);
            tabControlMain.Controls.Add(tabPageAttackData);
            tabControlMain.Controls.Add(tabPageCharacters);
            tabControlMain.Controls.Add(tabPageInitData);
            tabControlMain.Controls.Add(tabPageItemData);
            tabControlMain.Controls.Add(tabPageWeaponData);
            tabControlMain.Controls.Add(tabPageArmorData);
            tabControlMain.Controls.Add(tabPageAccessoryData);
            tabControlMain.Controls.Add(tabPageMateriaData);
            tabControlMain.Controls.Add(tabPageKeyItemText);
            tabControlMain.Controls.Add(tabPageMisc);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 25);
            tabControlMain.Margin = new Padding(4, 3, 4, 3);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(784, 530);
            tabControlMain.TabIndex = 0;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // tabPageCommandData
            // 
            tabPageCommandData.Controls.Add(labelCommandID);
            tabPageCommandData.Controls.Add(comboBoxCommandInitialCursorAction);
            tabPageCommandData.Controls.Add(labelCommandInitialCursorAction);
            tabPageCommandData.Controls.Add(targetDataControlCommand);
            tabPageCommandData.Controls.Add(labelCommandCameraMovementIDMulti);
            tabPageCommandData.Controls.Add(comboBoxCommandCamMovementIDMulti);
            tabPageCommandData.Controls.Add(labelCommandCamMovementIDSingle);
            tabPageCommandData.Controls.Add(comboBoxCommandCameraMovementIDSingle);
            tabPageCommandData.Controls.Add(textBoxCommandDescription);
            tabPageCommandData.Controls.Add(labelCommandDescription);
            tabPageCommandData.Controls.Add(textBoxCommandName);
            tabPageCommandData.Controls.Add(labelCommandName);
            tabPageCommandData.Controls.Add(listBoxCommands);
            tabPageCommandData.Location = new Point(4, 24);
            tabPageCommandData.Margin = new Padding(4, 3, 4, 3);
            tabPageCommandData.Name = "tabPageCommandData";
            tabPageCommandData.Padding = new Padding(4, 3, 4, 3);
            tabPageCommandData.Size = new Size(776, 502);
            tabPageCommandData.TabIndex = 0;
            tabPageCommandData.Text = "Command";
            tabPageCommandData.UseVisualStyleBackColor = true;
            // 
            // labelCommandID
            // 
            labelCommandID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCommandID.AutoSize = true;
            labelCommandID.Location = new Point(730, 13);
            labelCommandID.Name = "labelCommandID";
            labelCommandID.Size = new Size(34, 15);
            labelCommandID.TabIndex = 36;
            labelCommandID.Text = "ID: ??";
            labelCommandID.TextAlign = ContentAlignment.TopRight;
            // 
            // comboBoxCommandInitialCursorAction
            // 
            comboBoxCommandInitialCursorAction.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCommandInitialCursorAction.FormattingEnabled = true;
            comboBoxCommandInitialCursorAction.Location = new Point(191, 163);
            comboBoxCommandInitialCursorAction.Name = "comboBoxCommandInitialCursorAction";
            comboBoxCommandInitialCursorAction.Size = new Size(459, 23);
            comboBoxCommandInitialCursorAction.TabIndex = 35;
            comboBoxCommandInitialCursorAction.SelectedIndexChanged += CommandDataChanged;
            // 
            // labelCommandInitialCursorAction
            // 
            labelCommandInitialCursorAction.AutoSize = true;
            labelCommandInitialCursorAction.Location = new Point(191, 145);
            labelCommandInitialCursorAction.Name = "labelCommandInitialCursorAction";
            labelCommandInitialCursorAction.Size = new Size(111, 15);
            labelCommandInitialCursorAction.TabIndex = 34;
            labelCommandInitialCursorAction.Text = "Initial cursor action:";
            // 
            // targetDataControlCommand
            // 
            targetDataControlCommand.Location = new Point(190, 192);
            targetDataControlCommand.Name = "targetDataControlCommand";
            targetDataControlCommand.Size = new Size(330, 125);
            targetDataControlCommand.TabIndex = 33;
            targetDataControlCommand.FlagsChanged += CommandDataChanged;
            // 
            // labelCommandCameraMovementIDMulti
            // 
            labelCommandCameraMovementIDMulti.AutoSize = true;
            labelCommandCameraMovementIDMulti.Location = new Point(423, 101);
            labelCommandCameraMovementIDMulti.Name = "labelCommandCameraMovementIDMulti";
            labelCommandCameraMovementIDMulti.Size = new Size(199, 15);
            labelCommandCameraMovementIDMulti.TabIndex = 31;
            labelCommandCameraMovementIDMulti.Text = "Camera movement ID (multi target):";
            // 
            // comboBoxCommandCamMovementIDMulti
            // 
            comboBoxCommandCamMovementIDMulti.FormattingEnabled = true;
            comboBoxCommandCamMovementIDMulti.Location = new Point(423, 119);
            comboBoxCommandCamMovementIDMulti.MaxLength = 4;
            comboBoxCommandCamMovementIDMulti.Name = "comboBoxCommandCamMovementIDMulti";
            comboBoxCommandCamMovementIDMulti.Size = new Size(227, 23);
            comboBoxCommandCamMovementIDMulti.TabIndex = 32;
            comboBoxCommandCamMovementIDMulti.TextUpdate += comboBoxCamMovementIDMulti_TextChanged;
            // 
            // labelCommandCamMovementIDSingle
            // 
            labelCommandCamMovementIDSingle.AutoSize = true;
            labelCommandCamMovementIDSingle.Location = new Point(190, 101);
            labelCommandCamMovementIDSingle.Name = "labelCommandCamMovementIDSingle";
            labelCommandCamMovementIDSingle.Size = new Size(202, 15);
            labelCommandCamMovementIDSingle.TabIndex = 29;
            labelCommandCamMovementIDSingle.Text = "Camera movement ID (single target):";
            // 
            // comboBoxCommandCameraMovementIDSingle
            // 
            comboBoxCommandCameraMovementIDSingle.FormattingEnabled = true;
            comboBoxCommandCameraMovementIDSingle.Location = new Point(191, 119);
            comboBoxCommandCameraMovementIDSingle.MaxLength = 4;
            comboBoxCommandCameraMovementIDSingle.Name = "comboBoxCommandCameraMovementIDSingle";
            comboBoxCommandCameraMovementIDSingle.Size = new Size(226, 23);
            comboBoxCommandCameraMovementIDSingle.TabIndex = 30;
            comboBoxCommandCameraMovementIDSingle.TextUpdate += comboBoxCamMovementIDSingle_TextChanged;
            // 
            // textBoxCommandDescription
            // 
            textBoxCommandDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCommandDescription.Location = new Point(191, 75);
            textBoxCommandDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxCommandDescription.Name = "textBoxCommandDescription";
            textBoxCommandDescription.Size = new Size(573, 23);
            textBoxCommandDescription.TabIndex = 16;
            textBoxCommandDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // labelCommandDescription
            // 
            labelCommandDescription.AutoSize = true;
            labelCommandDescription.Location = new Point(191, 57);
            labelCommandDescription.Margin = new Padding(4, 0, 4, 0);
            labelCommandDescription.Name = "labelCommandDescription";
            labelCommandDescription.Size = new Size(70, 15);
            labelCommandDescription.TabIndex = 15;
            labelCommandDescription.Text = "Description:";
            // 
            // textBoxCommandName
            // 
            textBoxCommandName.Location = new Point(191, 31);
            textBoxCommandName.Margin = new Padding(4, 3, 4, 3);
            textBoxCommandName.Name = "textBoxCommandName";
            textBoxCommandName.Size = new Size(226, 23);
            textBoxCommandName.TabIndex = 14;
            textBoxCommandName.TextChanged += textBoxName_TextChanged;
            // 
            // labelCommandName
            // 
            labelCommandName.AutoSize = true;
            labelCommandName.Location = new Point(191, 13);
            labelCommandName.Margin = new Padding(4, 0, 4, 0);
            labelCommandName.Name = "labelCommandName";
            labelCommandName.Size = new Size(42, 15);
            labelCommandName.TabIndex = 13;
            labelCommandName.Text = "Name:";
            // 
            // listBoxCommands
            // 
            listBoxCommands.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxCommands.FormattingEnabled = true;
            listBoxCommands.Location = new Point(9, 13);
            listBoxCommands.Margin = new Padding(4, 3, 4, 3);
            listBoxCommands.Name = "listBoxCommands";
            listBoxCommands.Size = new Size(174, 469);
            listBoxCommands.TabIndex = 3;
            listBoxCommands.SelectedIndexChanged += listBoxCommands_SelectedIndexChanged;
            // 
            // tabPageAttackData
            // 
            tabPageAttackData.Controls.Add(attackFormControl);
            tabPageAttackData.Controls.Add(comboBoxAttackType);
            tabPageAttackData.Controls.Add(listBoxAttacks);
            tabPageAttackData.Location = new Point(4, 24);
            tabPageAttackData.Margin = new Padding(4, 3, 4, 3);
            tabPageAttackData.Name = "tabPageAttackData";
            tabPageAttackData.Padding = new Padding(4, 3, 4, 3);
            tabPageAttackData.Size = new Size(776, 502);
            tabPageAttackData.TabIndex = 1;
            tabPageAttackData.Text = "Attacks";
            tabPageAttackData.UseVisualStyleBackColor = true;
            // 
            // attackFormControl
            // 
            attackFormControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            attackFormControl.Location = new Point(190, 13);
            attackFormControl.Name = "attackFormControl";
            attackFormControl.Size = new Size(577, 468);
            attackFormControl.TabIndex = 39;
            attackFormControl.DataChanged += AttackDataChanged;
            attackFormControl.NameChanged += textBoxAttackName_TextChanged;
            attackFormControl.DescriptionChanged += textBoxAttackDescription_TextChanged;
            attackFormControl.SummonTextChanged += textBoxSummonText_TextChanged;
            attackFormControl.ChangeIsLimit += checkBoxAttackIsLimit_CheckedChanged;
            attackFormControl.ChangeMagicType += comboBoxMagicType_SelectedIndexChanged;
            attackFormControl.ChangeMagicOrder += buttonSpellPosition_Click;
            // 
            // comboBoxAttackType
            // 
            comboBoxAttackType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAttackType.FormattingEnabled = true;
            comboBoxAttackType.Items.AddRange(new object[] { "Magic", "Summons", "Enemy skills", "Limit breaks" });
            comboBoxAttackType.Location = new Point(9, 13);
            comboBoxAttackType.Name = "comboBoxAttackType";
            comboBoxAttackType.Size = new Size(174, 23);
            comboBoxAttackType.TabIndex = 38;
            comboBoxAttackType.SelectedIndexChanged += comboBoxAttackType_SelectedIndexChanged;
            // 
            // listBoxAttacks
            // 
            listBoxAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxAttacks.FormattingEnabled = true;
            listBoxAttacks.Location = new Point(9, 42);
            listBoxAttacks.Margin = new Padding(4, 3, 4, 3);
            listBoxAttacks.Name = "listBoxAttacks";
            listBoxAttacks.Size = new Size(174, 439);
            listBoxAttacks.TabIndex = 0;
            listBoxAttacks.SelectedIndexChanged += listBoxAttacks_SelectedIndexChanged;
            // 
            // tabPageCharacters
            // 
            tabPageCharacters.Controls.Add(tabControlCharacters);
            tabPageCharacters.Location = new Point(4, 24);
            tabPageCharacters.Margin = new Padding(4, 3, 4, 3);
            tabPageCharacters.Name = "tabPageCharacters";
            tabPageCharacters.Size = new Size(776, 502);
            tabPageCharacters.TabIndex = 2;
            tabPageCharacters.Text = "Characters";
            tabPageCharacters.UseVisualStyleBackColor = true;
            // 
            // tabControlCharacters
            // 
            tabControlCharacters.Controls.Add(tabPageInitCharacterStats);
            tabControlCharacters.Controls.Add(tabPageCharacterLimits);
            tabControlCharacters.Controls.Add(tabPageCharacterGrowth);
            tabControlCharacters.Controls.Add(tabPageCharacterAI);
            tabControlCharacters.Dock = DockStyle.Fill;
            tabControlCharacters.Location = new Point(0, 0);
            tabControlCharacters.Name = "tabControlCharacters";
            tabControlCharacters.SelectedIndex = 0;
            tabControlCharacters.Size = new Size(776, 502);
            tabControlCharacters.TabIndex = 0;
            // 
            // tabPageInitCharacterStats
            // 
            tabPageInitCharacterStats.Controls.Add(numericCharacterLevelOffset);
            tabPageInitCharacterStats.Controls.Add(labelCharacterLevelOffset);
            tabPageInitCharacterStats.Controls.Add(groupBoxCharacterMP);
            tabPageInitCharacterStats.Controls.Add(groupBoxCharacterHP);
            tabPageInitCharacterStats.Controls.Add(numericCharacterEXPtoNext);
            tabPageInitCharacterStats.Controls.Add(labelCharacterEXPtoNext);
            tabPageInitCharacterStats.Controls.Add(numericCharacterKillCount);
            tabPageInitCharacterStats.Controls.Add(labelCharacterKillCount);
            tabPageInitCharacterStats.Controls.Add(comboBoxCharacterFlags);
            tabPageInitCharacterStats.Controls.Add(labelCharacterFlags);
            tabPageInitCharacterStats.Controls.Add(characterLimitControl);
            tabPageInitCharacterStats.Controls.Add(numericCharacterCurrentEXP);
            tabPageInitCharacterStats.Controls.Add(labelCharacterCurrentEXP);
            tabPageInitCharacterStats.Controls.Add(groupBoxCharacterArmor);
            tabPageInitCharacterStats.Controls.Add(groupBoxCharacterWeapon);
            tabPageInitCharacterStats.Controls.Add(characterStatsControl);
            tabPageInitCharacterStats.Controls.Add(checkBoxCharacterBackRow);
            tabPageInitCharacterStats.Controls.Add(numericCharacterLevel);
            tabPageInitCharacterStats.Controls.Add(labelCharacterLevel);
            tabPageInitCharacterStats.Controls.Add(comboBoxCharacterAccessory);
            tabPageInitCharacterStats.Controls.Add(labelCharacterAccessory);
            tabPageInitCharacterStats.Controls.Add(numericCharacterID);
            tabPageInitCharacterStats.Controls.Add(labelCharacterID);
            tabPageInitCharacterStats.Controls.Add(textBoxCharacterName);
            tabPageInitCharacterStats.Controls.Add(labelCharacterName);
            tabPageInitCharacterStats.Controls.Add(listBoxInitCharacters);
            tabPageInitCharacterStats.Location = new Point(4, 24);
            tabPageInitCharacterStats.Name = "tabPageInitCharacterStats";
            tabPageInitCharacterStats.Padding = new Padding(3);
            tabPageInitCharacterStats.Size = new Size(768, 474);
            tabPageInitCharacterStats.TabIndex = 0;
            tabPageInitCharacterStats.Text = "Initial Stats";
            tabPageInitCharacterStats.UseVisualStyleBackColor = true;
            // 
            // numericCharacterLevelOffset
            // 
            numericCharacterLevelOffset.Location = new Point(539, 71);
            numericCharacterLevelOffset.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numericCharacterLevelOffset.Minimum = new decimal(new int[] { 64, 0, 0, int.MinValue });
            numericCharacterLevelOffset.Name = "numericCharacterLevelOffset";
            numericCharacterLevelOffset.Size = new Size(120, 23);
            numericCharacterLevelOffset.TabIndex = 4;
            numericCharacterLevelOffset.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterLevelOffset
            // 
            labelCharacterLevelOffset.AutoSize = true;
            labelCharacterLevelOffset.Location = new Point(539, 53);
            labelCharacterLevelOffset.Name = "labelCharacterLevelOffset";
            labelCharacterLevelOffset.Size = new Size(107, 15);
            labelCharacterLevelOffset.TabIndex = 3;
            labelCharacterLevelOffset.Text = "Recruit level offset:";
            // 
            // groupBoxCharacterMP
            // 
            groupBoxCharacterMP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxCharacterMP.Controls.Add(numericCharacterMaxMP);
            groupBoxCharacterMP.Controls.Add(labelCharacterMaxMP);
            groupBoxCharacterMP.Controls.Add(numericCharacterBaseMP);
            groupBoxCharacterMP.Controls.Add(labelCharacterBaseMP);
            groupBoxCharacterMP.Controls.Add(numericCharacterCurrMP);
            groupBoxCharacterMP.Controls.Add(labelCharacterCurrMP);
            groupBoxCharacterMP.Location = new Point(158, 177);
            groupBoxCharacterMP.Name = "groupBoxCharacterMP";
            groupBoxCharacterMP.Size = new Size(373, 71);
            groupBoxCharacterMP.TabIndex = 30;
            groupBoxCharacterMP.TabStop = false;
            groupBoxCharacterMP.Text = "MP";
            // 
            // numericCharacterMaxMP
            // 
            numericCharacterMaxMP.Location = new Point(248, 37);
            numericCharacterMaxMP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterMaxMP.Name = "numericCharacterMaxMP";
            numericCharacterMaxMP.Size = new Size(115, 23);
            numericCharacterMaxMP.TabIndex = 5;
            numericCharacterMaxMP.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterMaxMP
            // 
            labelCharacterMaxMP.AutoSize = true;
            labelCharacterMaxMP.Location = new Point(248, 19);
            labelCharacterMaxMP.Name = "labelCharacterMaxMP";
            labelCharacterMaxMP.Size = new Size(57, 15);
            labelCharacterMaxMP.TabIndex = 4;
            labelCharacterMaxMP.Text = "Adjusted:";
            // 
            // numericCharacterBaseMP
            // 
            numericCharacterBaseMP.Location = new Point(127, 37);
            numericCharacterBaseMP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterBaseMP.Name = "numericCharacterBaseMP";
            numericCharacterBaseMP.Size = new Size(115, 23);
            numericCharacterBaseMP.TabIndex = 3;
            numericCharacterBaseMP.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterBaseMP
            // 
            labelCharacterBaseMP.AutoSize = true;
            labelCharacterBaseMP.Location = new Point(127, 19);
            labelCharacterBaseMP.Name = "labelCharacterBaseMP";
            labelCharacterBaseMP.Size = new Size(33, 15);
            labelCharacterBaseMP.TabIndex = 2;
            labelCharacterBaseMP.Text = "Max:";
            // 
            // numericCharacterCurrMP
            // 
            numericCharacterCurrMP.Location = new Point(6, 37);
            numericCharacterCurrMP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterCurrMP.Name = "numericCharacterCurrMP";
            numericCharacterCurrMP.Size = new Size(115, 23);
            numericCharacterCurrMP.TabIndex = 1;
            numericCharacterCurrMP.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterCurrMP
            // 
            labelCharacterCurrMP.AutoSize = true;
            labelCharacterCurrMP.Location = new Point(6, 19);
            labelCharacterCurrMP.Name = "labelCharacterCurrMP";
            labelCharacterCurrMP.Size = new Size(50, 15);
            labelCharacterCurrMP.TabIndex = 0;
            labelCharacterCurrMP.Text = "Current:";
            // 
            // groupBoxCharacterHP
            // 
            groupBoxCharacterHP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxCharacterHP.Controls.Add(numericCharacterMaxHP);
            groupBoxCharacterHP.Controls.Add(labelCharacterMaxHP);
            groupBoxCharacterHP.Controls.Add(numericCharacterBaseHP);
            groupBoxCharacterHP.Controls.Add(labelCharacterBaseHP);
            groupBoxCharacterHP.Controls.Add(numericCharacterCurrHP);
            groupBoxCharacterHP.Controls.Add(labelCharacterCurrHP);
            groupBoxCharacterHP.Location = new Point(158, 100);
            groupBoxCharacterHP.Name = "groupBoxCharacterHP";
            groupBoxCharacterHP.Size = new Size(373, 71);
            groupBoxCharacterHP.TabIndex = 29;
            groupBoxCharacterHP.TabStop = false;
            groupBoxCharacterHP.Text = "HP";
            // 
            // numericCharacterMaxHP
            // 
            numericCharacterMaxHP.Location = new Point(248, 37);
            numericCharacterMaxHP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterMaxHP.Name = "numericCharacterMaxHP";
            numericCharacterMaxHP.Size = new Size(115, 23);
            numericCharacterMaxHP.TabIndex = 5;
            numericCharacterMaxHP.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterMaxHP
            // 
            labelCharacterMaxHP.AutoSize = true;
            labelCharacterMaxHP.Location = new Point(248, 19);
            labelCharacterMaxHP.Name = "labelCharacterMaxHP";
            labelCharacterMaxHP.Size = new Size(57, 15);
            labelCharacterMaxHP.TabIndex = 4;
            labelCharacterMaxHP.Text = "Adjusted:";
            // 
            // numericCharacterBaseHP
            // 
            numericCharacterBaseHP.Location = new Point(127, 37);
            numericCharacterBaseHP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterBaseHP.Name = "numericCharacterBaseHP";
            numericCharacterBaseHP.Size = new Size(115, 23);
            numericCharacterBaseHP.TabIndex = 3;
            numericCharacterBaseHP.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterBaseHP
            // 
            labelCharacterBaseHP.AutoSize = true;
            labelCharacterBaseHP.Location = new Point(127, 19);
            labelCharacterBaseHP.Name = "labelCharacterBaseHP";
            labelCharacterBaseHP.Size = new Size(33, 15);
            labelCharacterBaseHP.TabIndex = 2;
            labelCharacterBaseHP.Text = "Max:";
            // 
            // numericCharacterCurrHP
            // 
            numericCharacterCurrHP.Location = new Point(6, 37);
            numericCharacterCurrHP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterCurrHP.Name = "numericCharacterCurrHP";
            numericCharacterCurrHP.Size = new Size(115, 23);
            numericCharacterCurrHP.TabIndex = 1;
            numericCharacterCurrHP.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterCurrHP
            // 
            labelCharacterCurrHP.AutoSize = true;
            labelCharacterCurrHP.Location = new Point(6, 19);
            labelCharacterCurrHP.Name = "labelCharacterCurrHP";
            labelCharacterCurrHP.Size = new Size(50, 15);
            labelCharacterCurrHP.TabIndex = 0;
            labelCharacterCurrHP.Text = "Current:";
            // 
            // numericCharacterEXPtoNext
            // 
            numericCharacterEXPtoNext.Location = new Point(406, 71);
            numericCharacterEXPtoNext.Name = "numericCharacterEXPtoNext";
            numericCharacterEXPtoNext.Size = new Size(115, 23);
            numericCharacterEXPtoNext.TabIndex = 28;
            numericCharacterEXPtoNext.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterEXPtoNext
            // 
            labelCharacterEXPtoNext.AutoSize = true;
            labelCharacterEXPtoNext.Location = new Point(406, 53);
            labelCharacterEXPtoNext.Name = "labelCharacterEXPtoNext";
            labelCharacterEXPtoNext.Size = new Size(75, 15);
            labelCharacterEXPtoNext.TabIndex = 27;
            labelCharacterEXPtoNext.Text = "To next level:";
            // 
            // numericCharacterKillCount
            // 
            numericCharacterKillCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericCharacterKillCount.Location = new Point(401, 269);
            numericCharacterKillCount.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterKillCount.Name = "numericCharacterKillCount";
            numericCharacterKillCount.Size = new Size(128, 23);
            numericCharacterKillCount.TabIndex = 26;
            numericCharacterKillCount.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterKillCount
            // 
            labelCharacterKillCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCharacterKillCount.AutoSize = true;
            labelCharacterKillCount.Location = new Point(401, 251);
            labelCharacterKillCount.Name = "labelCharacterKillCount";
            labelCharacterKillCount.Size = new Size(60, 15);
            labelCharacterKillCount.TabIndex = 25;
            labelCharacterKillCount.Text = "Kill count:";
            // 
            // comboBoxCharacterFlags
            // 
            comboBoxCharacterFlags.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCharacterFlags.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCharacterFlags.FormattingEnabled = true;
            comboBoxCharacterFlags.Location = new Point(158, 269);
            comboBoxCharacterFlags.Name = "comboBoxCharacterFlags";
            comboBoxCharacterFlags.Size = new Size(157, 23);
            comboBoxCharacterFlags.TabIndex = 24;
            comboBoxCharacterFlags.SelectedIndexChanged += InitCharacterDataChanged;
            // 
            // labelCharacterFlags
            // 
            labelCharacterFlags.AutoSize = true;
            labelCharacterFlags.Location = new Point(158, 251);
            labelCharacterFlags.Name = "labelCharacterFlags";
            labelCharacterFlags.Size = new Size(89, 15);
            labelCharacterFlags.TabIndex = 23;
            labelCharacterFlags.Text = "Character flags:";
            // 
            // characterLimitControl
            // 
            characterLimitControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            characterLimitControl.Location = new Point(158, 298);
            characterLimitControl.Name = "characterLimitControl";
            characterLimitControl.Size = new Size(373, 130);
            characterLimitControl.TabIndex = 22;
            characterLimitControl.DataChanged += InitCharacterDataChanged;
            // 
            // numericCharacterCurrentEXP
            // 
            numericCharacterCurrentEXP.Location = new Point(285, 71);
            numericCharacterCurrentEXP.Name = "numericCharacterCurrentEXP";
            numericCharacterCurrentEXP.Size = new Size(115, 23);
            numericCharacterCurrentEXP.TabIndex = 21;
            numericCharacterCurrentEXP.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterCurrentEXP
            // 
            labelCharacterCurrentEXP.AutoSize = true;
            labelCharacterCurrentEXP.Location = new Point(285, 52);
            labelCharacterCurrentEXP.Name = "labelCharacterCurrentEXP";
            labelCharacterCurrentEXP.Size = new Size(30, 15);
            labelCharacterCurrentEXP.TabIndex = 20;
            labelCharacterCurrentEXP.Text = "EXP:";
            // 
            // groupBoxCharacterArmor
            // 
            groupBoxCharacterArmor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxCharacterArmor.Controls.Add(buttonCharacterArmorChangeMateria);
            groupBoxCharacterArmor.Controls.Add(materiaSlotSelectorCharacterArmor);
            groupBoxCharacterArmor.Controls.Add(comboBoxCharacterArmor);
            groupBoxCharacterArmor.Location = new Point(539, 235);
            groupBoxCharacterArmor.Name = "groupBoxCharacterArmor";
            groupBoxCharacterArmor.Size = new Size(223, 128);
            groupBoxCharacterArmor.TabIndex = 17;
            groupBoxCharacterArmor.TabStop = false;
            groupBoxCharacterArmor.Text = "Armor";
            // 
            // buttonCharacterArmorChangeMateria
            // 
            buttonCharacterArmorChangeMateria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonCharacterArmorChangeMateria.Location = new Point(6, 99);
            buttonCharacterArmorChangeMateria.Name = "buttonCharacterArmorChangeMateria";
            buttonCharacterArmorChangeMateria.Size = new Size(211, 23);
            buttonCharacterArmorChangeMateria.TabIndex = 18;
            buttonCharacterArmorChangeMateria.Text = "Change selected materia...";
            buttonCharacterArmorChangeMateria.UseVisualStyleBackColor = true;
            buttonCharacterArmorChangeMateria.Click += buttonCharacterArmorChangeMateria_Click;
            // 
            // materiaSlotSelectorCharacterArmor
            // 
            materiaSlotSelectorCharacterArmor.BackColor = Color.LightSlateGray;
            materiaSlotSelectorCharacterArmor.BorderStyle = BorderStyle.Fixed3D;
            materiaSlotSelectorCharacterArmor.Location = new Point(6, 58);
            materiaSlotSelectorCharacterArmor.Name = "materiaSlotSelectorCharacterArmor";
            materiaSlotSelectorCharacterArmor.Size = new Size(211, 35);
            materiaSlotSelectorCharacterArmor.TabIndex = 15;
            materiaSlotSelectorCharacterArmor.SelectedSlotChanged += materiaSlotSelectorCharacterArmor_SelectedSlotChanged;
            // 
            // comboBoxCharacterArmor
            // 
            comboBoxCharacterArmor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCharacterArmor.FormattingEnabled = true;
            comboBoxCharacterArmor.Location = new Point(6, 21);
            comboBoxCharacterArmor.Name = "comboBoxCharacterArmor";
            comboBoxCharacterArmor.Size = new Size(211, 23);
            comboBoxCharacterArmor.TabIndex = 8;
            comboBoxCharacterArmor.SelectedIndexChanged += comboBoxCharacterArmor_SelectedIndexChanged;
            // 
            // groupBoxCharacterWeapon
            // 
            groupBoxCharacterWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxCharacterWeapon.Controls.Add(buttonCharacterWeaponChangeMateria);
            groupBoxCharacterWeapon.Controls.Add(materiaSlotSelectorCharacterWeapon);
            groupBoxCharacterWeapon.Controls.Add(comboBoxCharacterWeapon);
            groupBoxCharacterWeapon.Location = new Point(539, 101);
            groupBoxCharacterWeapon.Name = "groupBoxCharacterWeapon";
            groupBoxCharacterWeapon.Size = new Size(223, 128);
            groupBoxCharacterWeapon.TabIndex = 16;
            groupBoxCharacterWeapon.TabStop = false;
            groupBoxCharacterWeapon.Text = "Weapon";
            // 
            // buttonCharacterWeaponChangeMateria
            // 
            buttonCharacterWeaponChangeMateria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonCharacterWeaponChangeMateria.Location = new Point(6, 99);
            buttonCharacterWeaponChangeMateria.Name = "buttonCharacterWeaponChangeMateria";
            buttonCharacterWeaponChangeMateria.Size = new Size(211, 23);
            buttonCharacterWeaponChangeMateria.TabIndex = 16;
            buttonCharacterWeaponChangeMateria.Text = "Change selected materia...";
            buttonCharacterWeaponChangeMateria.UseVisualStyleBackColor = true;
            buttonCharacterWeaponChangeMateria.Click += buttonCharacterWeaponChangeMateria_Click;
            // 
            // materiaSlotSelectorCharacterWeapon
            // 
            materiaSlotSelectorCharacterWeapon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materiaSlotSelectorCharacterWeapon.BackColor = Color.LightSlateGray;
            materiaSlotSelectorCharacterWeapon.BorderStyle = BorderStyle.Fixed3D;
            materiaSlotSelectorCharacterWeapon.Location = new Point(6, 58);
            materiaSlotSelectorCharacterWeapon.Name = "materiaSlotSelectorCharacterWeapon";
            materiaSlotSelectorCharacterWeapon.Size = new Size(211, 35);
            materiaSlotSelectorCharacterWeapon.TabIndex = 15;
            materiaSlotSelectorCharacterWeapon.SelectedSlotChanged += materiaSlotSelectorCharacterWeapon_SelectedSlotChanged;
            // 
            // comboBoxCharacterWeapon
            // 
            comboBoxCharacterWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCharacterWeapon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCharacterWeapon.FormattingEnabled = true;
            comboBoxCharacterWeapon.Location = new Point(6, 21);
            comboBoxCharacterWeapon.Name = "comboBoxCharacterWeapon";
            comboBoxCharacterWeapon.Size = new Size(211, 23);
            comboBoxCharacterWeapon.TabIndex = 6;
            comboBoxCharacterWeapon.SelectedIndexChanged += comboBoxCharacterWeapon_SelectedIndexChanged;
            // 
            // characterStatsControl
            // 
            characterStatsControl.Location = new Point(6, 151);
            characterStatsControl.Name = "characterStatsControl";
            characterStatsControl.Size = new Size(146, 295);
            characterStatsControl.TabIndex = 14;
            characterStatsControl.CharacterStatsChanged += InitCharacterDataChanged;
            // 
            // checkBoxCharacterBackRow
            // 
            checkBoxCharacterBackRow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxCharacterBackRow.AutoSize = true;
            checkBoxCharacterBackRow.Location = new Point(321, 271);
            checkBoxCharacterBackRow.Name = "checkBoxCharacterBackRow";
            checkBoxCharacterBackRow.Size = new Size(74, 19);
            checkBoxCharacterBackRow.TabIndex = 13;
            checkBoxCharacterBackRow.Text = "Back row";
            checkBoxCharacterBackRow.UseVisualStyleBackColor = true;
            checkBoxCharacterBackRow.CheckedChanged += InitCharacterDataChanged;
            // 
            // numericCharacterLevel
            // 
            numericCharacterLevel.Location = new Point(164, 71);
            numericCharacterLevel.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericCharacterLevel.Name = "numericCharacterLevel";
            numericCharacterLevel.Size = new Size(115, 23);
            numericCharacterLevel.TabIndex = 12;
            numericCharacterLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericCharacterLevel.ValueChanged += InitCharacterDataChanged;
            // 
            // labelCharacterLevel
            // 
            labelCharacterLevel.AutoSize = true;
            labelCharacterLevel.Location = new Point(164, 52);
            labelCharacterLevel.Name = "labelCharacterLevel";
            labelCharacterLevel.Size = new Size(37, 15);
            labelCharacterLevel.TabIndex = 11;
            labelCharacterLevel.Text = "Level:";
            // 
            // comboBoxCharacterAccessory
            // 
            comboBoxCharacterAccessory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxCharacterAccessory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCharacterAccessory.FormattingEnabled = true;
            comboBoxCharacterAccessory.Location = new Point(545, 384);
            comboBoxCharacterAccessory.Name = "comboBoxCharacterAccessory";
            comboBoxCharacterAccessory.Size = new Size(211, 23);
            comboBoxCharacterAccessory.TabIndex = 10;
            comboBoxCharacterAccessory.SelectedIndexChanged += InitCharacterDataChanged;
            // 
            // labelCharacterAccessory
            // 
            labelCharacterAccessory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCharacterAccessory.AutoSize = true;
            labelCharacterAccessory.Location = new Point(545, 366);
            labelCharacterAccessory.Name = "labelCharacterAccessory";
            labelCharacterAccessory.Size = new Size(63, 15);
            labelCharacterAccessory.TabIndex = 9;
            labelCharacterAccessory.Text = "Accessory:";
            // 
            // numericCharacterID
            // 
            numericCharacterID.Location = new Point(164, 26);
            numericCharacterID.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCharacterID.Name = "numericCharacterID";
            numericCharacterID.Size = new Size(75, 23);
            numericCharacterID.TabIndex = 4;
            numericCharacterID.ValueChanged += numericCharacterID_ValueChanged;
            // 
            // labelCharacterID
            // 
            labelCharacterID.AutoSize = true;
            labelCharacterID.Location = new Point(164, 6);
            labelCharacterID.Name = "labelCharacterID";
            labelCharacterID.Size = new Size(75, 15);
            labelCharacterID.TabIndex = 3;
            labelCharacterID.Text = "Character ID:";
            // 
            // textBoxCharacterName
            // 
            textBoxCharacterName.Location = new Point(245, 26);
            textBoxCharacterName.Name = "textBoxCharacterName";
            textBoxCharacterName.Size = new Size(276, 23);
            textBoxCharacterName.TabIndex = 2;
            textBoxCharacterName.TextChanged += InitCharacterDataChanged;
            // 
            // labelCharacterName
            // 
            labelCharacterName.AutoSize = true;
            labelCharacterName.Location = new Point(245, 6);
            labelCharacterName.Name = "labelCharacterName";
            labelCharacterName.Size = new Size(42, 15);
            labelCharacterName.TabIndex = 1;
            labelCharacterName.Text = "Name:";
            // 
            // listBoxInitCharacters
            // 
            listBoxInitCharacters.FormattingEnabled = true;
            listBoxInitCharacters.Location = new Point(6, 6);
            listBoxInitCharacters.Name = "listBoxInitCharacters";
            listBoxInitCharacters.Size = new Size(146, 139);
            listBoxInitCharacters.TabIndex = 0;
            listBoxInitCharacters.SelectedIndexChanged += listBoxCharacters_SelectedIndexChanged;
            // 
            // tabPageCharacterLimits
            // 
            tabPageCharacterLimits.Controls.Add(limitRequirementControl4);
            tabPageCharacterLimits.Controls.Add(limitRequirementControl3);
            tabPageCharacterLimits.Controls.Add(limitRequirementControl2);
            tabPageCharacterLimits.Controls.Add(limitRequirementControl1);
            tabPageCharacterLimits.Controls.Add(listBoxCharacterLimits);
            tabPageCharacterLimits.Location = new Point(4, 24);
            tabPageCharacterLimits.Name = "tabPageCharacterLimits";
            tabPageCharacterLimits.Size = new Size(768, 474);
            tabPageCharacterLimits.TabIndex = 2;
            tabPageCharacterLimits.Text = "Limits";
            tabPageCharacterLimits.UseVisualStyleBackColor = true;
            // 
            // limitRequirementControl4
            // 
            limitRequirementControl4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            limitRequirementControl4.Enabled = false;
            limitRequirementControl4.Location = new Point(158, 354);
            limitRequirementControl4.Name = "limitRequirementControl4";
            limitRequirementControl4.Size = new Size(605, 110);
            limitRequirementControl4.TabIndex = 5;
            limitRequirementControl4.DataChanged += limitRequirementControl_DataChanged;
            // 
            // limitRequirementControl3
            // 
            limitRequirementControl3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            limitRequirementControl3.Enabled = false;
            limitRequirementControl3.Location = new Point(158, 238);
            limitRequirementControl3.Name = "limitRequirementControl3";
            limitRequirementControl3.Size = new Size(605, 110);
            limitRequirementControl3.TabIndex = 4;
            limitRequirementControl3.DataChanged += limitRequirementControl_DataChanged;
            // 
            // limitRequirementControl2
            // 
            limitRequirementControl2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            limitRequirementControl2.Enabled = false;
            limitRequirementControl2.Location = new Point(158, 122);
            limitRequirementControl2.Name = "limitRequirementControl2";
            limitRequirementControl2.Size = new Size(605, 110);
            limitRequirementControl2.TabIndex = 3;
            limitRequirementControl2.DataChanged += limitRequirementControl_DataChanged;
            // 
            // limitRequirementControl1
            // 
            limitRequirementControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            limitRequirementControl1.Enabled = false;
            limitRequirementControl1.Location = new Point(158, 6);
            limitRequirementControl1.Name = "limitRequirementControl1";
            limitRequirementControl1.Size = new Size(605, 110);
            limitRequirementControl1.TabIndex = 2;
            limitRequirementControl1.DataChanged += limitRequirementControl_DataChanged;
            // 
            // listBoxCharacterLimits
            // 
            listBoxCharacterLimits.FormattingEnabled = true;
            listBoxCharacterLimits.Location = new Point(6, 6);
            listBoxCharacterLimits.Name = "listBoxCharacterLimits";
            listBoxCharacterLimits.Size = new Size(146, 139);
            listBoxCharacterLimits.TabIndex = 1;
            listBoxCharacterLimits.SelectedIndexChanged += listBoxCharacters_SelectedIndexChanged;
            // 
            // tabPageCharacterGrowth
            // 
            tabPageCharacterGrowth.Controls.Add(groupBoxSelectedCurve);
            tabPageCharacterGrowth.Controls.Add(listBoxStatCurves);
            tabPageCharacterGrowth.Controls.Add(listBoxCharacterGrowth);
            tabPageCharacterGrowth.Location = new Point(4, 24);
            tabPageCharacterGrowth.Name = "tabPageCharacterGrowth";
            tabPageCharacterGrowth.Padding = new Padding(3);
            tabPageCharacterGrowth.Size = new Size(768, 474);
            tabPageCharacterGrowth.TabIndex = 0;
            tabPageCharacterGrowth.Text = "Growth Curves";
            tabPageCharacterGrowth.UseVisualStyleBackColor = true;
            // 
            // groupBoxSelectedCurve
            // 
            groupBoxSelectedCurve.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSelectedCurve.Controls.Add(labelCurveMax);
            groupBoxSelectedCurve.Controls.Add(labelCurveMin);
            groupBoxSelectedCurve.Controls.Add(labelCurveLevel);
            groupBoxSelectedCurve.Controls.Add(labelInaccurateCurve);
            groupBoxSelectedCurve.Controls.Add(buttonEditBaseCurve);
            groupBoxSelectedCurve.Controls.Add(groupBoxCurveBonuses);
            groupBoxSelectedCurve.Controls.Add(numericCurveIndex);
            groupBoxSelectedCurve.Controls.Add(labelCurveIndex);
            groupBoxSelectedCurve.Controls.Add(chartMainCurve);
            groupBoxSelectedCurve.Location = new Point(158, 6);
            groupBoxSelectedCurve.Name = "groupBoxSelectedCurve";
            groupBoxSelectedCurve.Size = new Size(604, 462);
            groupBoxSelectedCurve.TabIndex = 3;
            groupBoxSelectedCurve.TabStop = false;
            groupBoxSelectedCurve.Text = "Selected curve";
            // 
            // labelCurveMax
            // 
            labelCurveMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCurveMax.AutoSize = true;
            labelCurveMax.Location = new Point(512, 52);
            labelCurveMax.Name = "labelCurveMax";
            labelCurveMax.Size = new Size(46, 15);
            labelCurveMax.TabIndex = 9;
            labelCurveMax.Text = "Max: ??";
            // 
            // labelCurveMin
            // 
            labelCurveMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCurveMin.AutoSize = true;
            labelCurveMin.Location = new Point(512, 37);
            labelCurveMin.Name = "labelCurveMin";
            labelCurveMin.Size = new Size(44, 15);
            labelCurveMin.TabIndex = 8;
            labelCurveMin.Text = "Min: ??";
            // 
            // labelCurveLevel
            // 
            labelCurveLevel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCurveLevel.AutoSize = true;
            labelCurveLevel.Location = new Point(512, 22);
            labelCurveLevel.Name = "labelCurveLevel";
            labelCurveLevel.Size = new Size(50, 15);
            labelCurveLevel.TabIndex = 7;
            labelCurveLevel.Text = "Level: ??";
            // 
            // labelInaccurateCurve
            // 
            labelInaccurateCurve.AutoSize = true;
            labelInaccurateCurve.Location = new Point(367, 287);
            labelInaccurateCurve.Name = "labelInaccurateCurve";
            labelInaccurateCurve.Size = new Size(231, 15);
            labelInaccurateCurve.TabIndex = 6;
            labelInaccurateCurve.Text = "*Load ff7.exe to display this chart correctly";
            labelInaccurateCurve.Visible = false;
            // 
            // buttonEditBaseCurve
            // 
            buttonEditBaseCurve.Location = new Point(108, 303);
            buttonEditBaseCurve.Name = "buttonEditBaseCurve";
            buttonEditBaseCurve.Size = new Size(186, 23);
            buttonEditBaseCurve.TabIndex = 5;
            buttonEditBaseCurve.Text = "Edit base curve...";
            buttonEditBaseCurve.UseVisualStyleBackColor = true;
            buttonEditBaseCurve.Click += buttonEditBaseCurve_Click;
            // 
            // groupBoxCurveBonuses
            // 
            groupBoxCurveBonuses.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxCurveBonuses.Controls.Add(labelCurveExplanation);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus12);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus11);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus10);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus9);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus8);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus7);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus6);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus5);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus4);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus3);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus2);
            groupBoxCurveBonuses.Controls.Add(numericCurveBonus1);
            groupBoxCurveBonuses.Location = new Point(6, 334);
            groupBoxCurveBonuses.Name = "groupBoxCurveBonuses";
            groupBoxCurveBonuses.Size = new Size(592, 122);
            groupBoxCurveBonuses.TabIndex = 4;
            groupBoxCurveBonuses.TabStop = false;
            groupBoxCurveBonuses.Text = "Random bonus to stat(s)";
            // 
            // labelCurveExplanation
            // 
            labelCurveExplanation.AutoSize = true;
            labelCurveExplanation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCurveExplanation.Location = new Point(6, 77);
            labelCurveExplanation.Name = "labelCurveExplanation";
            labelCurveExplanation.Size = new Size(371, 15);
            labelCurveExplanation.TabIndex = 12;
            labelCurveExplanation.Text = "Note: These bonuses are used for EVERY character. Edit with care!";
            // 
            // numericCurveBonus12
            // 
            numericCurveBonus12.Location = new Point(486, 51);
            numericCurveBonus12.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus12.Name = "numericCurveBonus12";
            numericCurveBonus12.Size = new Size(90, 23);
            numericCurveBonus12.TabIndex = 11;
            numericCurveBonus12.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus11
            // 
            numericCurveBonus11.Location = new Point(390, 51);
            numericCurveBonus11.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus11.Name = "numericCurveBonus11";
            numericCurveBonus11.Size = new Size(90, 23);
            numericCurveBonus11.TabIndex = 10;
            numericCurveBonus11.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus10
            // 
            numericCurveBonus10.Location = new Point(294, 51);
            numericCurveBonus10.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus10.Name = "numericCurveBonus10";
            numericCurveBonus10.Size = new Size(90, 23);
            numericCurveBonus10.TabIndex = 9;
            numericCurveBonus10.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus9
            // 
            numericCurveBonus9.Location = new Point(198, 51);
            numericCurveBonus9.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus9.Name = "numericCurveBonus9";
            numericCurveBonus9.Size = new Size(90, 23);
            numericCurveBonus9.TabIndex = 8;
            numericCurveBonus9.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus8
            // 
            numericCurveBonus8.Location = new Point(102, 51);
            numericCurveBonus8.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus8.Name = "numericCurveBonus8";
            numericCurveBonus8.Size = new Size(90, 23);
            numericCurveBonus8.TabIndex = 7;
            numericCurveBonus8.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus7
            // 
            numericCurveBonus7.Location = new Point(6, 51);
            numericCurveBonus7.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus7.Name = "numericCurveBonus7";
            numericCurveBonus7.Size = new Size(90, 23);
            numericCurveBonus7.TabIndex = 6;
            numericCurveBonus7.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus6
            // 
            numericCurveBonus6.Location = new Point(486, 22);
            numericCurveBonus6.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus6.Name = "numericCurveBonus6";
            numericCurveBonus6.Size = new Size(90, 23);
            numericCurveBonus6.TabIndex = 5;
            numericCurveBonus6.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus5
            // 
            numericCurveBonus5.Location = new Point(390, 22);
            numericCurveBonus5.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus5.Name = "numericCurveBonus5";
            numericCurveBonus5.Size = new Size(90, 23);
            numericCurveBonus5.TabIndex = 4;
            numericCurveBonus5.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus4
            // 
            numericCurveBonus4.Location = new Point(294, 22);
            numericCurveBonus4.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus4.Name = "numericCurveBonus4";
            numericCurveBonus4.Size = new Size(90, 23);
            numericCurveBonus4.TabIndex = 3;
            numericCurveBonus4.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus3
            // 
            numericCurveBonus3.Location = new Point(198, 22);
            numericCurveBonus3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus3.Name = "numericCurveBonus3";
            numericCurveBonus3.Size = new Size(90, 23);
            numericCurveBonus3.TabIndex = 2;
            numericCurveBonus3.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus2
            // 
            numericCurveBonus2.Location = new Point(102, 22);
            numericCurveBonus2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus2.Name = "numericCurveBonus2";
            numericCurveBonus2.Size = new Size(90, 23);
            numericCurveBonus2.TabIndex = 1;
            numericCurveBonus2.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveBonus1
            // 
            numericCurveBonus1.Location = new Point(6, 22);
            numericCurveBonus1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCurveBonus1.Name = "numericCurveBonus1";
            numericCurveBonus1.Size = new Size(90, 23);
            numericCurveBonus1.TabIndex = 0;
            numericCurveBonus1.ValueChanged += numericCurveBonus_ValueChanged;
            // 
            // numericCurveIndex
            // 
            numericCurveIndex.Location = new Point(6, 305);
            numericCurveIndex.Maximum = new decimal(new int[] { 63, 0, 0, 0 });
            numericCurveIndex.Name = "numericCurveIndex";
            numericCurveIndex.Size = new Size(96, 23);
            numericCurveIndex.TabIndex = 2;
            numericCurveIndex.ValueChanged += numericCurveIndex_ValueChanged;
            // 
            // labelCurveIndex
            // 
            labelCurveIndex.AutoSize = true;
            labelCurveIndex.Location = new Point(6, 287);
            labelCurveIndex.Name = "labelCurveIndex";
            labelCurveIndex.Size = new Size(73, 15);
            labelCurveIndex.TabIndex = 1;
            labelCurveIndex.Text = "Curve index:";
            // 
            // chartMainCurve
            // 
            chartMainCurve.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartMainCurve.BackColor = SystemColors.Control;
            chartArea1.AxisX.Interval = 10D;
            chartArea1.AxisX.IntervalOffset = 9D;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.Maximum = 99D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.Name = "ChartArea1";
            chartMainCurve.ChartAreas.Add(chartArea1);
            chartMainCurve.Location = new Point(6, 22);
            chartMainCurve.Name = "chartMainCurve";
            chartMainCurve.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = Color.SteelBlue;
            series1.Name = "Min";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = Color.Firebrick;
            series2.Name = "Max";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chartMainCurve.Series.Add(series1);
            chartMainCurve.Series.Add(series2);
            chartMainCurve.Size = new Size(500, 262);
            chartMainCurve.TabIndex = 0;
            chartMainCurve.Text = "Main curve";
            chartMainCurve.MouseMove += chartMainCurve_MouseMove;
            // 
            // listBoxStatCurves
            // 
            listBoxStatCurves.FormattingEnabled = true;
            listBoxStatCurves.Items.AddRange(new object[] { "Strength", "Vitality", "Magic", "Spirit", "Dexterity", "Luck", "HP", "MP", "EXP" });
            listBoxStatCurves.Location = new Point(6, 151);
            listBoxStatCurves.Name = "listBoxStatCurves";
            listBoxStatCurves.Size = new Size(146, 139);
            listBoxStatCurves.TabIndex = 2;
            listBoxStatCurves.SelectedIndexChanged += StatCurveChanged;
            // 
            // listBoxCharacterGrowth
            // 
            listBoxCharacterGrowth.FormattingEnabled = true;
            listBoxCharacterGrowth.Location = new Point(6, 6);
            listBoxCharacterGrowth.Name = "listBoxCharacterGrowth";
            listBoxCharacterGrowth.Size = new Size(146, 139);
            listBoxCharacterGrowth.TabIndex = 1;
            listBoxCharacterGrowth.SelectedIndexChanged += StatCurveChanged;
            // 
            // tabPageCharacterAI
            // 
            tabPageCharacterAI.Controls.Add(scriptControlCharacterAI);
            tabPageCharacterAI.Controls.Add(groupBoxCharacterAI);
            tabPageCharacterAI.Controls.Add(groupBoxCharacterScripts);
            tabPageCharacterAI.Location = new Point(4, 24);
            tabPageCharacterAI.Name = "tabPageCharacterAI";
            tabPageCharacterAI.Padding = new Padding(3);
            tabPageCharacterAI.Size = new Size(768, 474);
            tabPageCharacterAI.TabIndex = 1;
            tabPageCharacterAI.Text = "Character A.I.";
            tabPageCharacterAI.UseVisualStyleBackColor = true;
            // 
            // scriptControlCharacterAI
            // 
            scriptControlCharacterAI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scriptControlCharacterAI.Enabled = false;
            scriptControlCharacterAI.Location = new Point(187, 6);
            scriptControlCharacterAI.Name = "scriptControlCharacterAI";
            scriptControlCharacterAI.Size = new Size(575, 424);
            scriptControlCharacterAI.TabIndex = 5;
            scriptControlCharacterAI.DataChanged += scriptControlCharacterAI_DataChanged;
            scriptControlCharacterAI.ScriptAdded += scriptControlCharacterAI_DataChanged;
            scriptControlCharacterAI.ScriptRemoved += scriptControlCharacterAI_DataChanged;
            // 
            // groupBoxCharacterAI
            // 
            groupBoxCharacterAI.Controls.Add(listBoxCharacterAI);
            groupBoxCharacterAI.Location = new Point(9, 6);
            groupBoxCharacterAI.Name = "groupBoxCharacterAI";
            groupBoxCharacterAI.Size = new Size(172, 211);
            groupBoxCharacterAI.TabIndex = 4;
            groupBoxCharacterAI.TabStop = false;
            groupBoxCharacterAI.Text = "Characters";
            // 
            // listBoxCharacterAI
            // 
            listBoxCharacterAI.Dock = DockStyle.Fill;
            listBoxCharacterAI.FormattingEnabled = true;
            listBoxCharacterAI.Location = new Point(3, 19);
            listBoxCharacterAI.Name = "listBoxCharacterAI";
            listBoxCharacterAI.Size = new Size(166, 189);
            listBoxCharacterAI.TabIndex = 1;
            listBoxCharacterAI.SelectedIndexChanged += listBoxCharacterAI_SelectedIndexChanged;
            listBoxCharacterAI.KeyDown += listBoxCharacterAI_KeyDown;
            // 
            // groupBoxCharacterScripts
            // 
            groupBoxCharacterScripts.Controls.Add(listBoxCharacterScripts);
            groupBoxCharacterScripts.Enabled = false;
            groupBoxCharacterScripts.Location = new Point(6, 223);
            groupBoxCharacterScripts.Name = "groupBoxCharacterScripts";
            groupBoxCharacterScripts.Size = new Size(175, 238);
            groupBoxCharacterScripts.TabIndex = 3;
            groupBoxCharacterScripts.TabStop = false;
            groupBoxCharacterScripts.Text = "Scripts";
            // 
            // listBoxCharacterScripts
            // 
            listBoxCharacterScripts.Dock = DockStyle.Fill;
            listBoxCharacterScripts.Font = new Font("Segoe UI", 8F);
            listBoxCharacterScripts.FormattingEnabled = true;
            listBoxCharacterScripts.Items.AddRange(new object[] { "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter", "Magic Counter", "Ally Death", "Post-Attack", "Custom Event 1", "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5", "Custom Event 6", "Custom Event 7", "Post-Battle" });
            listBoxCharacterScripts.Location = new Point(3, 19);
            listBoxCharacterScripts.Name = "listBoxCharacterScripts";
            listBoxCharacterScripts.Size = new Size(169, 216);
            listBoxCharacterScripts.TabIndex = 2;
            listBoxCharacterScripts.SelectedIndexChanged += listBoxCharacterScripts_SelectedIndexChanged;
            listBoxCharacterScripts.KeyDown += listBoxCharacterAI_KeyDown;
            // 
            // tabPageInitData
            // 
            tabPageInitData.Controls.Add(numericStartingGil);
            tabPageInitData.Controls.Add(labelStartingGil);
            tabPageInitData.Controls.Add(groupBoxStartingParty);
            tabPageInitData.Controls.Add(groupBoxInitMateriaStolen);
            tabPageInitData.Controls.Add(groupBoxInitMateria);
            tabPageInitData.Controls.Add(groupBoxInitInventory);
            tabPageInitData.Location = new Point(4, 24);
            tabPageInitData.Name = "tabPageInitData";
            tabPageInitData.Padding = new Padding(3);
            tabPageInitData.Size = new Size(776, 502);
            tabPageInitData.TabIndex = 1;
            tabPageInitData.Text = "Initial Data";
            tabPageInitData.UseVisualStyleBackColor = true;
            // 
            // numericStartingGil
            // 
            numericStartingGil.Location = new Point(520, 29);
            numericStartingGil.Name = "numericStartingGil";
            numericStartingGil.Size = new Size(120, 23);
            numericStartingGil.TabIndex = 6;
            numericStartingGil.ValueChanged += numericStartingGil_ValueChanged;
            // 
            // labelStartingGil
            // 
            labelStartingGil.AutoSize = true;
            labelStartingGil.Location = new Point(520, 11);
            labelStartingGil.Name = "labelStartingGil";
            labelStartingGil.Size = new Size(67, 15);
            labelStartingGil.TabIndex = 5;
            labelStartingGil.Text = "Starting gil:";
            // 
            // groupBoxStartingParty
            // 
            groupBoxStartingParty.Controls.Add(comboBoxParty3);
            groupBoxStartingParty.Controls.Add(comboBoxParty2);
            groupBoxStartingParty.Controls.Add(comboBoxParty1);
            groupBoxStartingParty.Location = new Point(6, 6);
            groupBoxStartingParty.Name = "groupBoxStartingParty";
            groupBoxStartingParty.Size = new Size(508, 62);
            groupBoxStartingParty.TabIndex = 4;
            groupBoxStartingParty.TabStop = false;
            groupBoxStartingParty.Text = "Starting party";
            // 
            // comboBoxParty3
            // 
            comboBoxParty3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxParty3.FormattingEnabled = true;
            comboBoxParty3.Location = new Point(338, 22);
            comboBoxParty3.Name = "comboBoxParty3";
            comboBoxParty3.Size = new Size(160, 23);
            comboBoxParty3.TabIndex = 2;
            comboBoxParty3.SelectedIndexChanged += comboBoxParty3_SelectedIndexChanged;
            // 
            // comboBoxParty2
            // 
            comboBoxParty2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxParty2.FormattingEnabled = true;
            comboBoxParty2.Location = new Point(172, 22);
            comboBoxParty2.Name = "comboBoxParty2";
            comboBoxParty2.Size = new Size(160, 23);
            comboBoxParty2.TabIndex = 1;
            comboBoxParty2.SelectedIndexChanged += comboBoxParty2_SelectedIndexChanged;
            // 
            // comboBoxParty1
            // 
            comboBoxParty1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxParty1.FormattingEnabled = true;
            comboBoxParty1.Location = new Point(6, 22);
            comboBoxParty1.Name = "comboBoxParty1";
            comboBoxParty1.Size = new Size(160, 23);
            comboBoxParty1.TabIndex = 0;
            comboBoxParty1.SelectedIndexChanged += comboBoxParty1_SelectedIndexChanged;
            // 
            // groupBoxInitMateriaStolen
            // 
            groupBoxInitMateriaStolen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBoxInitMateriaStolen.Controls.Add(listBoxInitMateriaStolen);
            groupBoxInitMateriaStolen.Controls.Add(buttonInitMateriaStolenEdit);
            groupBoxInitMateriaStolen.Controls.Add(comboBoxInitMateriaStolen);
            groupBoxInitMateriaStolen.Controls.Add(labelInitMateriaStolen);
            groupBoxInitMateriaStolen.Location = new Point(519, 74);
            groupBoxInitMateriaStolen.Name = "groupBoxInitMateriaStolen";
            groupBoxInitMateriaStolen.Size = new Size(251, 411);
            groupBoxInitMateriaStolen.TabIndex = 3;
            groupBoxInitMateriaStolen.TabStop = false;
            groupBoxInitMateriaStolen.Text = "Materia stolen by Yuffie";
            // 
            // listBoxInitMateriaStolen
            // 
            listBoxInitMateriaStolen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxInitMateriaStolen.FormattingEnabled = true;
            listBoxInitMateriaStolen.Location = new Point(6, 22);
            listBoxInitMateriaStolen.Name = "listBoxInitMateriaStolen";
            listBoxInitMateriaStolen.Size = new Size(239, 274);
            listBoxInitMateriaStolen.TabIndex = 7;
            listBoxInitMateriaStolen.SelectedIndexChanged += listBoxInitMateriaStolen_SelectedIndexChanged;
            // 
            // buttonInitMateriaStolenEdit
            // 
            buttonInitMateriaStolenEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonInitMateriaStolenEdit.Enabled = false;
            buttonInitMateriaStolenEdit.Location = new Point(6, 382);
            buttonInitMateriaStolenEdit.Name = "buttonInitMateriaStolenEdit";
            buttonInitMateriaStolenEdit.Size = new Size(239, 23);
            buttonInitMateriaStolenEdit.TabIndex = 6;
            buttonInitMateriaStolenEdit.Text = "Edit details...";
            buttonInitMateriaStolenEdit.UseVisualStyleBackColor = true;
            buttonInitMateriaStolenEdit.Click += buttonInitMateriaStolenEdit_Click;
            // 
            // comboBoxInitMateriaStolen
            // 
            comboBoxInitMateriaStolen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxInitMateriaStolen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInitMateriaStolen.Enabled = false;
            comboBoxInitMateriaStolen.FormattingEnabled = true;
            comboBoxInitMateriaStolen.Location = new Point(6, 338);
            comboBoxInitMateriaStolen.Name = "comboBoxInitMateriaStolen";
            comboBoxInitMateriaStolen.Size = new Size(239, 23);
            comboBoxInitMateriaStolen.TabIndex = 5;
            comboBoxInitMateriaStolen.SelectedIndexChanged += comboBoxInitMateriaStolen_SelectedIndexChanged;
            // 
            // labelInitMateriaStolen
            // 
            labelInitMateriaStolen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelInitMateriaStolen.AutoSize = true;
            labelInitMateriaStolen.Location = new Point(6, 320);
            labelInitMateriaStolen.Name = "labelInitMateriaStolen";
            labelInitMateriaStolen.Size = new Size(50, 15);
            labelInitMateriaStolen.TabIndex = 4;
            labelInitMateriaStolen.Text = "Materia:";
            // 
            // groupBoxInitMateria
            // 
            groupBoxInitMateria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBoxInitMateria.Controls.Add(buttonInitMateriaEdit);
            groupBoxInitMateria.Controls.Add(comboBoxInitMateria);
            groupBoxInitMateria.Controls.Add(labelInitMateria);
            groupBoxInitMateria.Controls.Add(listBoxInitMateria);
            groupBoxInitMateria.Location = new Point(263, 74);
            groupBoxInitMateria.Name = "groupBoxInitMateria";
            groupBoxInitMateria.Size = new Size(251, 411);
            groupBoxInitMateria.TabIndex = 2;
            groupBoxInitMateria.TabStop = false;
            groupBoxInitMateria.Text = "Materia";
            // 
            // buttonInitMateriaEdit
            // 
            buttonInitMateriaEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonInitMateriaEdit.Enabled = false;
            buttonInitMateriaEdit.Location = new Point(6, 382);
            buttonInitMateriaEdit.Name = "buttonInitMateriaEdit";
            buttonInitMateriaEdit.Size = new Size(239, 23);
            buttonInitMateriaEdit.TabIndex = 3;
            buttonInitMateriaEdit.Text = "Edit details...";
            buttonInitMateriaEdit.UseVisualStyleBackColor = true;
            buttonInitMateriaEdit.Click += buttonInitMateriaEdit_Click;
            // 
            // comboBoxInitMateria
            // 
            comboBoxInitMateria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxInitMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInitMateria.Enabled = false;
            comboBoxInitMateria.FormattingEnabled = true;
            comboBoxInitMateria.Location = new Point(6, 338);
            comboBoxInitMateria.Name = "comboBoxInitMateria";
            comboBoxInitMateria.Size = new Size(239, 23);
            comboBoxInitMateria.TabIndex = 2;
            comboBoxInitMateria.SelectedIndexChanged += comboBoxInitMateria_SelectedIndexChanged;
            // 
            // labelInitMateria
            // 
            labelInitMateria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelInitMateria.AutoSize = true;
            labelInitMateria.Location = new Point(6, 320);
            labelInitMateria.Name = "labelInitMateria";
            labelInitMateria.Size = new Size(50, 15);
            labelInitMateria.TabIndex = 1;
            labelInitMateria.Text = "Materia:";
            // 
            // listBoxInitMateria
            // 
            listBoxInitMateria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxInitMateria.FormattingEnabled = true;
            listBoxInitMateria.Location = new Point(6, 22);
            listBoxInitMateria.Name = "listBoxInitMateria";
            listBoxInitMateria.Size = new Size(239, 274);
            listBoxInitMateria.TabIndex = 0;
            listBoxInitMateria.SelectedIndexChanged += listBoxInitMateria_SelectedIndexChanged;
            // 
            // groupBoxInitInventory
            // 
            groupBoxInitInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxInitInventory.Controls.Add(numericInitItemAmount);
            groupBoxInitInventory.Controls.Add(labelInitItemAmount);
            groupBoxInitInventory.Controls.Add(comboBoxInitItem);
            groupBoxInitInventory.Controls.Add(labelInitItem);
            groupBoxInitInventory.Controls.Add(listBoxInitInventory);
            groupBoxInitInventory.Location = new Point(6, 74);
            groupBoxInitInventory.Name = "groupBoxInitInventory";
            groupBoxInitInventory.Size = new Size(251, 411);
            groupBoxInitInventory.TabIndex = 1;
            groupBoxInitInventory.TabStop = false;
            groupBoxInitInventory.Text = "Inventory";
            // 
            // numericInitItemAmount
            // 
            numericInitItemAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericInitItemAmount.Enabled = false;
            numericInitItemAmount.Location = new Point(6, 382);
            numericInitItemAmount.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericInitItemAmount.Name = "numericInitItemAmount";
            numericInitItemAmount.Size = new Size(239, 23);
            numericInitItemAmount.TabIndex = 4;
            numericInitItemAmount.ValueChanged += numericInitItemAmount_ValueChanged;
            // 
            // labelInitItemAmount
            // 
            labelInitItemAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelInitItemAmount.AutoSize = true;
            labelInitItemAmount.Location = new Point(6, 364);
            labelInitItemAmount.Name = "labelInitItemAmount";
            labelInitItemAmount.Size = new Size(54, 15);
            labelInitItemAmount.TabIndex = 3;
            labelInitItemAmount.Text = "Amount:";
            // 
            // comboBoxInitItem
            // 
            comboBoxInitItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxInitItem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInitItem.Enabled = false;
            comboBoxInitItem.FormattingEnabled = true;
            comboBoxInitItem.Location = new Point(6, 338);
            comboBoxInitItem.Name = "comboBoxInitItem";
            comboBoxInitItem.Size = new Size(239, 23);
            comboBoxInitItem.TabIndex = 2;
            comboBoxInitItem.SelectedIndexChanged += comboBoxInitItem_SelectedIndexChanged;
            // 
            // labelInitItem
            // 
            labelInitItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelInitItem.AutoSize = true;
            labelInitItem.Location = new Point(6, 320);
            labelInitItem.Name = "labelInitItem";
            labelInitItem.Size = new Size(34, 15);
            labelInitItem.TabIndex = 1;
            labelInitItem.Text = "Item:";
            // 
            // listBoxInitInventory
            // 
            listBoxInitInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxInitInventory.FormattingEnabled = true;
            listBoxInitInventory.Location = new Point(6, 22);
            listBoxInitInventory.Name = "listBoxInitInventory";
            listBoxInitInventory.Size = new Size(239, 274);
            listBoxInitInventory.TabIndex = 0;
            listBoxInitInventory.SelectedIndexChanged += listBoxInitInventory_SelectedIndexChanged;
            // 
            // tabPageItemData
            // 
            tabPageItemData.Controls.Add(tabControlItems);
            tabPageItemData.Controls.Add(listBoxItems);
            tabPageItemData.Location = new Point(4, 24);
            tabPageItemData.Margin = new Padding(4, 3, 4, 3);
            tabPageItemData.Name = "tabPageItemData";
            tabPageItemData.Size = new Size(776, 502);
            tabPageItemData.TabIndex = 9;
            tabPageItemData.Text = "Items";
            tabPageItemData.UseVisualStyleBackColor = true;
            // 
            // tabControlItems
            // 
            tabControlItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlItems.Controls.Add(tabPageItems1);
            tabControlItems.Controls.Add(tabPageItems2);
            tabControlItems.Controls.Add(tabPageItems3);
            tabControlItems.Location = new Point(190, 13);
            tabControlItems.Name = "tabControlItems";
            tabControlItems.SelectedIndex = 0;
            tabControlItems.Size = new Size(578, 469);
            tabControlItems.TabIndex = 32;
            // 
            // tabPageItems1
            // 
            tabPageItems1.Controls.Add(labelItemID);
            tabPageItems1.Controls.Add(labelItemName);
            tabPageItems1.Controls.Add(itemRestrictionsItem);
            tabPageItems1.Controls.Add(damageCalculationControlItem);
            tabPageItems1.Controls.Add(textBoxItemName);
            tabPageItems1.Controls.Add(targetDataControlItem);
            tabPageItems1.Controls.Add(labelItemDescription);
            tabPageItems1.Controls.Add(textBoxItemDescription);
            tabPageItems1.Controls.Add(comboBoxItemAttackEffectID);
            tabPageItems1.Controls.Add(labelItemCamMovementID);
            tabPageItems1.Controls.Add(labelItemAttackEffectID);
            tabPageItems1.Controls.Add(comboBoxItemCamMovementID);
            tabPageItems1.Location = new Point(4, 24);
            tabPageItems1.Name = "tabPageItems1";
            tabPageItems1.Padding = new Padding(3);
            tabPageItems1.Size = new Size(570, 441);
            tabPageItems1.TabIndex = 0;
            tabPageItems1.Text = "Page 1";
            tabPageItems1.UseVisualStyleBackColor = true;
            // 
            // labelItemID
            // 
            labelItemID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelItemID.AutoSize = true;
            labelItemID.Location = new Point(530, 3);
            labelItemID.Name = "labelItemID";
            labelItemID.Size = new Size(34, 15);
            labelItemID.TabIndex = 45;
            labelItemID.Text = "ID: ??";
            labelItemID.TextAlign = ContentAlignment.TopRight;
            // 
            // labelItemName
            // 
            labelItemName.AutoSize = true;
            labelItemName.Location = new Point(7, 3);
            labelItemName.Margin = new Padding(4, 0, 4, 0);
            labelItemName.Name = "labelItemName";
            labelItemName.Size = new Size(42, 15);
            labelItemName.TabIndex = 9;
            labelItemName.Text = "Name:";
            // 
            // itemRestrictionsItem
            // 
            itemRestrictionsItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            itemRestrictionsItem.Location = new Point(352, 291);
            itemRestrictionsItem.Name = "itemRestrictionsItem";
            itemRestrictionsItem.Size = new Size(211, 125);
            itemRestrictionsItem.TabIndex = 31;
            itemRestrictionsItem.FlagsChanged += ItemDataChanged;
            // 
            // damageCalculationControlItem
            // 
            damageCalculationControlItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            damageCalculationControlItem.Location = new Point(7, 138);
            damageCalculationControlItem.Name = "damageCalculationControlItem";
            damageCalculationControlItem.Size = new Size(553, 147);
            damageCalculationControlItem.TabIndex = 29;
            damageCalculationControlItem.DataChanged += ItemDataChanged;
            // 
            // textBoxItemName
            // 
            textBoxItemName.Location = new Point(7, 21);
            textBoxItemName.Margin = new Padding(4, 3, 4, 3);
            textBoxItemName.Name = "textBoxItemName";
            textBoxItemName.Size = new Size(230, 23);
            textBoxItemName.TabIndex = 10;
            textBoxItemName.TextChanged += textBoxName_TextChanged;
            // 
            // targetDataControlItem
            // 
            targetDataControlItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            targetDataControlItem.Location = new Point(7, 291);
            targetDataControlItem.Name = "targetDataControlItem";
            targetDataControlItem.Size = new Size(339, 125);
            targetDataControlItem.TabIndex = 30;
            targetDataControlItem.FlagsChanged += ItemDataChanged;
            // 
            // labelItemDescription
            // 
            labelItemDescription.AutoSize = true;
            labelItemDescription.Location = new Point(7, 47);
            labelItemDescription.Margin = new Padding(4, 0, 4, 0);
            labelItemDescription.Name = "labelItemDescription";
            labelItemDescription.Size = new Size(70, 15);
            labelItemDescription.TabIndex = 11;
            labelItemDescription.Text = "Description:";
            // 
            // textBoxItemDescription
            // 
            textBoxItemDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxItemDescription.Location = new Point(7, 65);
            textBoxItemDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxItemDescription.Name = "textBoxItemDescription";
            textBoxItemDescription.Size = new Size(556, 23);
            textBoxItemDescription.TabIndex = 12;
            textBoxItemDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // comboBoxItemAttackEffectID
            // 
            comboBoxItemAttackEffectID.FormattingEnabled = true;
            comboBoxItemAttackEffectID.Location = new Point(163, 109);
            comboBoxItemAttackEffectID.Name = "comboBoxItemAttackEffectID";
            comboBoxItemAttackEffectID.Size = new Size(126, 23);
            comboBoxItemAttackEffectID.TabIndex = 28;
            // 
            // labelItemCamMovementID
            // 
            labelItemCamMovementID.AutoSize = true;
            labelItemCamMovementID.Location = new Point(7, 91);
            labelItemCamMovementID.Name = "labelItemCamMovementID";
            labelItemCamMovementID.Size = new Size(126, 15);
            labelItemCamMovementID.TabIndex = 25;
            labelItemCamMovementID.Text = "Camera movement ID:";
            // 
            // labelItemAttackEffectID
            // 
            labelItemAttackEffectID.AutoSize = true;
            labelItemAttackEffectID.Location = new Point(163, 91);
            labelItemAttackEffectID.Name = "labelItemAttackEffectID";
            labelItemAttackEffectID.Size = new Size(91, 15);
            labelItemAttackEffectID.TabIndex = 27;
            labelItemAttackEffectID.Text = "Attack effect ID:";
            // 
            // comboBoxItemCamMovementID
            // 
            comboBoxItemCamMovementID.FormattingEnabled = true;
            comboBoxItemCamMovementID.Location = new Point(7, 109);
            comboBoxItemCamMovementID.Name = "comboBoxItemCamMovementID";
            comboBoxItemCamMovementID.Size = new Size(150, 23);
            comboBoxItemCamMovementID.TabIndex = 26;
            comboBoxItemCamMovementID.TextUpdate += comboBoxCamMovementIDSingle_TextChanged;
            // 
            // tabPageItems2
            // 
            tabPageItems2.Controls.Add(comboBoxItemStatusChange);
            tabPageItems2.Controls.Add(labelItemStatusChange);
            tabPageItems2.Controls.Add(statusesControlItem);
            tabPageItems2.Controls.Add(elementsControlItem);
            tabPageItems2.Location = new Point(4, 24);
            tabPageItems2.Name = "tabPageItems2";
            tabPageItems2.Padding = new Padding(3);
            tabPageItems2.Size = new Size(570, 441);
            tabPageItems2.TabIndex = 1;
            tabPageItems2.Text = "Page 2";
            tabPageItems2.UseVisualStyleBackColor = true;
            // 
            // comboBoxItemStatusChange
            // 
            comboBoxItemStatusChange.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxItemStatusChange.FormattingEnabled = true;
            comboBoxItemStatusChange.Location = new Point(6, 363);
            comboBoxItemStatusChange.Name = "comboBoxItemStatusChange";
            comboBoxItemStatusChange.Size = new Size(185, 23);
            comboBoxItemStatusChange.TabIndex = 33;
            comboBoxItemStatusChange.SelectedIndexChanged += comboBoxStatusChange_SelectedIndexChanged;
            // 
            // labelItemStatusChange
            // 
            labelItemStatusChange.AutoSize = true;
            labelItemStatusChange.Location = new Point(6, 345);
            labelItemStatusChange.Name = "labelItemStatusChange";
            labelItemStatusChange.Size = new Size(84, 15);
            labelItemStatusChange.TabIndex = 32;
            labelItemStatusChange.Text = "Status change:";
            // 
            // statusesControlItem
            // 
            statusesControlItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusesControlItem.Location = new Point(6, 142);
            statusesControlItem.MinimumSize = new Size(500, 200);
            statusesControlItem.Name = "statusesControlItem";
            statusesControlItem.Size = new Size(558, 200);
            statusesControlItem.TabIndex = 31;
            statusesControlItem.StatusesChanged += ItemDataChanged;
            // 
            // elementsControlItem
            // 
            elementsControlItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            elementsControlItem.Location = new Point(6, 6);
            elementsControlItem.MinimumSize = new Size(370, 130);
            elementsControlItem.Name = "elementsControlItem";
            elementsControlItem.Size = new Size(558, 130);
            elementsControlItem.TabIndex = 30;
            elementsControlItem.ElementsChanged += ItemDataChanged;
            // 
            // tabPageItems3
            // 
            tabPageItems3.Controls.Add(specialAttackFlagsControlItem);
            tabPageItems3.Location = new Point(4, 24);
            tabPageItems3.Name = "tabPageItems3";
            tabPageItems3.Size = new Size(570, 441);
            tabPageItems3.TabIndex = 2;
            tabPageItems3.Text = "Page 3";
            tabPageItems3.UseVisualStyleBackColor = true;
            // 
            // specialAttackFlagsControlItem
            // 
            specialAttackFlagsControlItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            specialAttackFlagsControlItem.Location = new Point(3, 3);
            specialAttackFlagsControlItem.Name = "specialAttackFlagsControlItem";
            specialAttackFlagsControlItem.Size = new Size(558, 100);
            specialAttackFlagsControlItem.TabIndex = 44;
            specialAttackFlagsControlItem.FlagsChanged += ItemDataChanged;
            // 
            // listBoxItems
            // 
            listBoxItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxItems.FormattingEnabled = true;
            listBoxItems.Location = new Point(9, 13);
            listBoxItems.Margin = new Padding(4, 3, 4, 3);
            listBoxItems.Name = "listBoxItems";
            listBoxItems.Size = new Size(174, 469);
            listBoxItems.TabIndex = 0;
            listBoxItems.SelectedIndexChanged += listBoxItems_SelectedIndexChanged;
            // 
            // tabPageWeaponData
            // 
            tabPageWeaponData.Controls.Add(tabControlWeapons);
            tabPageWeaponData.Controls.Add(listBoxWeapons);
            tabPageWeaponData.Location = new Point(4, 24);
            tabPageWeaponData.Margin = new Padding(4, 3, 4, 3);
            tabPageWeaponData.Name = "tabPageWeaponData";
            tabPageWeaponData.Size = new Size(776, 502);
            tabPageWeaponData.TabIndex = 4;
            tabPageWeaponData.Text = "Weapons";
            tabPageWeaponData.UseVisualStyleBackColor = true;
            // 
            // tabControlWeapons
            // 
            tabControlWeapons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlWeapons.Controls.Add(tabPageWeapon1);
            tabControlWeapons.Controls.Add(tabPageWeapon2);
            tabControlWeapons.Location = new Point(190, 13);
            tabControlWeapons.Multiline = true;
            tabControlWeapons.Name = "tabControlWeapons";
            tabControlWeapons.SelectedIndex = 0;
            tabControlWeapons.Size = new Size(578, 469);
            tabControlWeapons.TabIndex = 27;
            // 
            // tabPageWeapon1
            // 
            tabPageWeapon1.Controls.Add(labelWeaponID);
            tabPageWeapon1.Controls.Add(numericWeaponCritChance);
            tabPageWeapon1.Controls.Add(numericWeaponHitChance);
            tabPageWeapon1.Controls.Add(elementsControlWeapon);
            tabPageWeapon1.Controls.Add(comboBoxWeaponStatus);
            tabPageWeapon1.Controls.Add(statIncreaseControlWeapon);
            tabPageWeapon1.Controls.Add(numericWeaponAnimationIndex);
            tabPageWeapon1.Controls.Add(labelWeaponAnimationIndex);
            tabPageWeapon1.Controls.Add(labelWeaponStatus);
            tabPageWeapon1.Controls.Add(numericWeaponModelIndex);
            tabPageWeapon1.Controls.Add(labelWeaponModelIndex);
            tabPageWeapon1.Controls.Add(groupBoxWeaponMateriaSlots);
            tabPageWeapon1.Controls.Add(labelWeaponCritChance);
            tabPageWeapon1.Controls.Add(labelWeaponHitChance);
            tabPageWeapon1.Controls.Add(textBoxWeaponName);
            tabPageWeapon1.Controls.Add(labelWeaponName);
            tabPageWeapon1.Controls.Add(labelWeaponDescription);
            tabPageWeapon1.Controls.Add(textBoxWeaponDescription);
            tabPageWeapon1.Location = new Point(4, 24);
            tabPageWeapon1.Name = "tabPageWeapon1";
            tabPageWeapon1.Padding = new Padding(3);
            tabPageWeapon1.Size = new Size(570, 441);
            tabPageWeapon1.TabIndex = 0;
            tabPageWeapon1.Text = "Page 1";
            tabPageWeapon1.UseVisualStyleBackColor = true;
            // 
            // labelWeaponID
            // 
            labelWeaponID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelWeaponID.AutoSize = true;
            labelWeaponID.Location = new Point(530, 3);
            labelWeaponID.Name = "labelWeaponID";
            labelWeaponID.Size = new Size(34, 15);
            labelWeaponID.TabIndex = 45;
            labelWeaponID.Text = "ID: ??";
            labelWeaponID.TextAlign = ContentAlignment.TopRight;
            // 
            // numericWeaponCritChance
            // 
            numericWeaponCritChance.Location = new Point(113, 109);
            numericWeaponCritChance.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericWeaponCritChance.Name = "numericWeaponCritChance";
            numericWeaponCritChance.Size = new Size(100, 23);
            numericWeaponCritChance.TabIndex = 36;
            numericWeaponCritChance.ValueChanged += WeaponDataChanged;
            // 
            // numericWeaponHitChance
            // 
            numericWeaponHitChance.Location = new Point(7, 109);
            numericWeaponHitChance.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericWeaponHitChance.Name = "numericWeaponHitChance";
            numericWeaponHitChance.Size = new Size(100, 23);
            numericWeaponHitChance.TabIndex = 35;
            numericWeaponHitChance.ValueChanged += WeaponDataChanged;
            // 
            // elementsControlWeapon
            // 
            elementsControlWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            elementsControlWeapon.Location = new Point(7, 305);
            elementsControlWeapon.MinimumSize = new Size(370, 130);
            elementsControlWeapon.Name = "elementsControlWeapon";
            elementsControlWeapon.Size = new Size(370, 130);
            elementsControlWeapon.TabIndex = 29;
            elementsControlWeapon.ElementsChanged += WeaponDataChanged;
            // 
            // comboBoxWeaponStatus
            // 
            comboBoxWeaponStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxWeaponStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWeaponStatus.FormattingEnabled = true;
            comboBoxWeaponStatus.Location = new Point(383, 323);
            comboBoxWeaponStatus.Name = "comboBoxWeaponStatus";
            comboBoxWeaponStatus.Size = new Size(177, 23);
            comboBoxWeaponStatus.TabIndex = 28;
            comboBoxWeaponStatus.SelectedIndexChanged += WeaponDataChanged;
            // 
            // statIncreaseControlWeapon
            // 
            statIncreaseControlWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statIncreaseControlWeapon.Location = new Point(7, 157);
            statIncreaseControlWeapon.MinimumSize = new Size(250, 142);
            statIncreaseControlWeapon.Name = "statIncreaseControlWeapon";
            statIncreaseControlWeapon.Size = new Size(327, 142);
            statIncreaseControlWeapon.TabIndex = 34;
            statIncreaseControlWeapon.DataChanged += WeaponDataChanged;
            // 
            // numericWeaponAnimationIndex
            // 
            numericWeaponAnimationIndex.Location = new Point(325, 109);
            numericWeaponAnimationIndex.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericWeaponAnimationIndex.Name = "numericWeaponAnimationIndex";
            numericWeaponAnimationIndex.Size = new Size(100, 23);
            numericWeaponAnimationIndex.TabIndex = 33;
            numericWeaponAnimationIndex.ValueChanged += WeaponDataChanged;
            // 
            // labelWeaponAnimationIndex
            // 
            labelWeaponAnimationIndex.AutoSize = true;
            labelWeaponAnimationIndex.Location = new Point(325, 91);
            labelWeaponAnimationIndex.Name = "labelWeaponAnimationIndex";
            labelWeaponAnimationIndex.Size = new Size(98, 15);
            labelWeaponAnimationIndex.TabIndex = 32;
            labelWeaponAnimationIndex.Text = "Animation index:";
            // 
            // labelWeaponStatus
            // 
            labelWeaponStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelWeaponStatus.AutoSize = true;
            labelWeaponStatus.Location = new Point(383, 305);
            labelWeaponStatus.Name = "labelWeaponStatus";
            labelWeaponStatus.Size = new Size(79, 15);
            labelWeaponStatus.TabIndex = 27;
            labelWeaponStatus.Text = "Inflicts status:";
            // 
            // numericWeaponModelIndex
            // 
            numericWeaponModelIndex.Location = new Point(219, 109);
            numericWeaponModelIndex.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericWeaponModelIndex.Name = "numericWeaponModelIndex";
            numericWeaponModelIndex.Size = new Size(100, 23);
            numericWeaponModelIndex.TabIndex = 31;
            numericWeaponModelIndex.ValueChanged += WeaponDataChanged;
            // 
            // labelWeaponModelIndex
            // 
            labelWeaponModelIndex.AutoSize = true;
            labelWeaponModelIndex.Location = new Point(219, 91);
            labelWeaponModelIndex.Name = "labelWeaponModelIndex";
            labelWeaponModelIndex.Size = new Size(76, 15);
            labelWeaponModelIndex.TabIndex = 30;
            labelWeaponModelIndex.Text = "Model index:";
            // 
            // groupBoxWeaponMateriaSlots
            // 
            groupBoxWeaponMateriaSlots.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxWeaponMateriaSlots.Controls.Add(materiaSlotSelectorWeapon);
            groupBoxWeaponMateriaSlots.Controls.Add(labelWeaponMateriaGrowth);
            groupBoxWeaponMateriaSlots.Controls.Add(comboBoxWeaponMateriaGrowth);
            groupBoxWeaponMateriaSlots.Location = new Point(341, 188);
            groupBoxWeaponMateriaSlots.Name = "groupBoxWeaponMateriaSlots";
            groupBoxWeaponMateriaSlots.Size = new Size(223, 111);
            groupBoxWeaponMateriaSlots.TabIndex = 20;
            groupBoxWeaponMateriaSlots.TabStop = false;
            groupBoxWeaponMateriaSlots.Text = "Materia slots";
            // 
            // materiaSlotSelectorWeapon
            // 
            materiaSlotSelectorWeapon.BackColor = Color.LightSlateGray;
            materiaSlotSelectorWeapon.BorderStyle = BorderStyle.Fixed3D;
            materiaSlotSelectorWeapon.Location = new Point(6, 22);
            materiaSlotSelectorWeapon.Name = "materiaSlotSelectorWeapon";
            materiaSlotSelectorWeapon.Size = new Size(211, 35);
            materiaSlotSelectorWeapon.TabIndex = 3;
            materiaSlotSelectorWeapon.DataChanged += materiaSlotSelectorWeapon_DataChanged;
            materiaSlotSelectorWeapon.MultiLinkEnabled += materiaSlotSelector_MultiLinkEnabled;
            // 
            // labelWeaponMateriaGrowth
            // 
            labelWeaponMateriaGrowth.AutoSize = true;
            labelWeaponMateriaGrowth.Location = new Point(6, 60);
            labelWeaponMateriaGrowth.Name = "labelWeaponMateriaGrowth";
            labelWeaponMateriaGrowth.Size = new Size(49, 15);
            labelWeaponMateriaGrowth.TabIndex = 1;
            labelWeaponMateriaGrowth.Text = "Growth:";
            // 
            // comboBoxWeaponMateriaGrowth
            // 
            comboBoxWeaponMateriaGrowth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxWeaponMateriaGrowth.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWeaponMateriaGrowth.FormattingEnabled = true;
            comboBoxWeaponMateriaGrowth.Location = new Point(6, 78);
            comboBoxWeaponMateriaGrowth.Name = "comboBoxWeaponMateriaGrowth";
            comboBoxWeaponMateriaGrowth.Size = new Size(211, 23);
            comboBoxWeaponMateriaGrowth.TabIndex = 2;
            comboBoxWeaponMateriaGrowth.SelectedIndexChanged += comboBoxWeaponMateriaGrowth_SelectedIndexChanged;
            // 
            // labelWeaponCritChance
            // 
            labelWeaponCritChance.AutoSize = true;
            labelWeaponCritChance.Location = new Point(113, 91);
            labelWeaponCritChance.Name = "labelWeaponCritChance";
            labelWeaponCritChance.Size = new Size(39, 15);
            labelWeaponCritChance.TabIndex = 23;
            labelWeaponCritChance.Text = "Crit%:";
            // 
            // labelWeaponHitChance
            // 
            labelWeaponHitChance.AutoSize = true;
            labelWeaponHitChance.Location = new Point(7, 91);
            labelWeaponHitChance.Name = "labelWeaponHitChance";
            labelWeaponHitChance.Size = new Size(36, 15);
            labelWeaponHitChance.TabIndex = 21;
            labelWeaponHitChance.Text = "Hit%:";
            // 
            // textBoxWeaponName
            // 
            textBoxWeaponName.Location = new Point(7, 21);
            textBoxWeaponName.Margin = new Padding(4, 3, 4, 3);
            textBoxWeaponName.Name = "textBoxWeaponName";
            textBoxWeaponName.Size = new Size(230, 23);
            textBoxWeaponName.TabIndex = 10;
            textBoxWeaponName.TextChanged += textBoxName_TextChanged;
            // 
            // labelWeaponName
            // 
            labelWeaponName.AutoSize = true;
            labelWeaponName.Location = new Point(7, 3);
            labelWeaponName.Margin = new Padding(4, 0, 4, 0);
            labelWeaponName.Name = "labelWeaponName";
            labelWeaponName.Size = new Size(42, 15);
            labelWeaponName.TabIndex = 9;
            labelWeaponName.Text = "Name:";
            // 
            // labelWeaponDescription
            // 
            labelWeaponDescription.AutoSize = true;
            labelWeaponDescription.Location = new Point(7, 47);
            labelWeaponDescription.Margin = new Padding(4, 0, 4, 0);
            labelWeaponDescription.Name = "labelWeaponDescription";
            labelWeaponDescription.Size = new Size(70, 15);
            labelWeaponDescription.TabIndex = 11;
            labelWeaponDescription.Text = "Description:";
            // 
            // textBoxWeaponDescription
            // 
            textBoxWeaponDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxWeaponDescription.Location = new Point(7, 65);
            textBoxWeaponDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxWeaponDescription.Name = "textBoxWeaponDescription";
            textBoxWeaponDescription.Size = new Size(556, 23);
            textBoxWeaponDescription.TabIndex = 12;
            textBoxWeaponDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // tabPageWeapon2
            // 
            tabPageWeapon2.Controls.Add(groupBoxWeaponSoundIDs);
            tabPageWeapon2.Controls.Add(targetDataControlWeapon);
            tabPageWeapon2.Controls.Add(damageCalculationControlWeapon);
            tabPageWeapon2.Controls.Add(equipableListWeapon);
            tabPageWeapon2.Controls.Add(itemRestrictionsWeapon);
            tabPageWeapon2.Location = new Point(4, 24);
            tabPageWeapon2.Name = "tabPageWeapon2";
            tabPageWeapon2.Padding = new Padding(3);
            tabPageWeapon2.Size = new Size(570, 441);
            tabPageWeapon2.TabIndex = 1;
            tabPageWeapon2.Text = "Page 2";
            tabPageWeapon2.UseVisualStyleBackColor = true;
            // 
            // groupBoxWeaponSoundIDs
            // 
            groupBoxWeaponSoundIDs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxWeaponSoundIDs.Location = new Point(340, 156);
            groupBoxWeaponSoundIDs.Name = "groupBoxWeaponSoundIDs";
            groupBoxWeaponSoundIDs.Size = new Size(224, 138);
            groupBoxWeaponSoundIDs.TabIndex = 30;
            groupBoxWeaponSoundIDs.TabStop = false;
            groupBoxWeaponSoundIDs.Text = "Sound IDs";
            // 
            // targetDataControlWeapon
            // 
            targetDataControlWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            targetDataControlWeapon.Location = new Point(6, 156);
            targetDataControlWeapon.Name = "targetDataControlWeapon";
            targetDataControlWeapon.Size = new Size(328, 138);
            targetDataControlWeapon.TabIndex = 29;
            targetDataControlWeapon.FlagsChanged += WeaponDataChanged;
            // 
            // damageCalculationControlWeapon
            // 
            damageCalculationControlWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            damageCalculationControlWeapon.Location = new Point(6, 3);
            damageCalculationControlWeapon.Name = "damageCalculationControlWeapon";
            damageCalculationControlWeapon.Size = new Size(558, 147);
            damageCalculationControlWeapon.TabIndex = 26;
            damageCalculationControlWeapon.DataChanged += WeaponDataChanged;
            // 
            // equipableListWeapon
            // 
            equipableListWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            equipableListWeapon.Location = new Point(6, 300);
            equipableListWeapon.MinimumSize = new Size(280, 125);
            equipableListWeapon.Name = "equipableListWeapon";
            equipableListWeapon.Size = new Size(328, 125);
            equipableListWeapon.TabIndex = 20;
            equipableListWeapon.FlagsChanged += WeaponDataChanged;
            // 
            // itemRestrictionsWeapon
            // 
            itemRestrictionsWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            itemRestrictionsWeapon.Location = new Point(340, 300);
            itemRestrictionsWeapon.Name = "itemRestrictionsWeapon";
            itemRestrictionsWeapon.Size = new Size(224, 125);
            itemRestrictionsWeapon.TabIndex = 25;
            itemRestrictionsWeapon.FlagsChanged += WeaponDataChanged;
            // 
            // listBoxWeapons
            // 
            listBoxWeapons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxWeapons.FormattingEnabled = true;
            listBoxWeapons.Location = new Point(9, 13);
            listBoxWeapons.Margin = new Padding(4, 3, 4, 3);
            listBoxWeapons.Name = "listBoxWeapons";
            listBoxWeapons.Size = new Size(174, 469);
            listBoxWeapons.TabIndex = 1;
            listBoxWeapons.SelectedIndexChanged += listBoxWeapons_SelectedIndexChanged;
            // 
            // tabPageArmorData
            // 
            tabPageArmorData.Controls.Add(tabControlArmor);
            tabPageArmorData.Controls.Add(listBoxArmor);
            tabPageArmorData.Location = new Point(4, 24);
            tabPageArmorData.Margin = new Padding(4, 3, 4, 3);
            tabPageArmorData.Name = "tabPageArmorData";
            tabPageArmorData.Size = new Size(776, 502);
            tabPageArmorData.TabIndex = 5;
            tabPageArmorData.Text = "Armor";
            tabPageArmorData.UseVisualStyleBackColor = true;
            // 
            // tabControlArmor
            // 
            tabControlArmor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlArmor.Controls.Add(tabPageArmor1);
            tabControlArmor.Controls.Add(tabPageArmor2);
            tabControlArmor.Location = new Point(190, 13);
            tabControlArmor.Name = "tabControlArmor";
            tabControlArmor.SelectedIndex = 0;
            tabControlArmor.Size = new Size(578, 469);
            tabControlArmor.TabIndex = 34;
            // 
            // tabPageArmor1
            // 
            tabPageArmor1.Controls.Add(labelArmorID);
            tabPageArmor1.Controls.Add(labelArmorElementModifier);
            tabPageArmor1.Controls.Add(numericArmorMagicDefensePercent);
            tabPageArmor1.Controls.Add(labelArmorMagicDefensePercent);
            tabPageArmor1.Controls.Add(numericArmorMagicDefense);
            tabPageArmor1.Controls.Add(comboBoxArmorElementModifier);
            tabPageArmor1.Controls.Add(labelArmorMagicDefense);
            tabPageArmor1.Controls.Add(comboBoxArmorStatus);
            tabPageArmor1.Controls.Add(numericArmorDefensePercent);
            tabPageArmor1.Controls.Add(elementsControlArmor);
            tabPageArmor1.Controls.Add(labelArmorStatus);
            tabPageArmor1.Controls.Add(labelArmorDefencePercent);
            tabPageArmor1.Controls.Add(numericArmorDefense);
            tabPageArmor1.Controls.Add(labelArmorDefense);
            tabPageArmor1.Controls.Add(statIncreaseControlArmor);
            tabPageArmor1.Controls.Add(labelArmorName);
            tabPageArmor1.Controls.Add(textBoxArmorName);
            tabPageArmor1.Controls.Add(labelArmorDescription);
            tabPageArmor1.Controls.Add(groupBoxArmorMateriaSlots);
            tabPageArmor1.Controls.Add(textBoxArmorDescription);
            tabPageArmor1.Location = new Point(4, 24);
            tabPageArmor1.Name = "tabPageArmor1";
            tabPageArmor1.Padding = new Padding(3);
            tabPageArmor1.Size = new Size(570, 441);
            tabPageArmor1.TabIndex = 0;
            tabPageArmor1.Text = "Page 1";
            tabPageArmor1.UseVisualStyleBackColor = true;
            // 
            // labelArmorID
            // 
            labelArmorID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelArmorID.AutoSize = true;
            labelArmorID.Location = new Point(530, 3);
            labelArmorID.Name = "labelArmorID";
            labelArmorID.Size = new Size(34, 15);
            labelArmorID.TabIndex = 45;
            labelArmorID.Text = "ID: ??";
            labelArmorID.TextAlign = ContentAlignment.TopRight;
            // 
            // labelArmorElementModifier
            // 
            labelArmorElementModifier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelArmorElementModifier.AutoSize = true;
            labelArmorElementModifier.Location = new Point(382, 305);
            labelArmorElementModifier.Name = "labelArmorElementModifier";
            labelArmorElementModifier.Size = new Size(147, 15);
            labelArmorElementModifier.TabIndex = 34;
            labelArmorElementModifier.Text = "Element damage modifier:";
            // 
            // numericArmorMagicDefensePercent
            // 
            numericArmorMagicDefensePercent.Location = new Point(325, 109);
            numericArmorMagicDefensePercent.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericArmorMagicDefensePercent.Name = "numericArmorMagicDefensePercent";
            numericArmorMagicDefensePercent.Size = new Size(100, 23);
            numericArmorMagicDefensePercent.TabIndex = 41;
            numericArmorMagicDefensePercent.ValueChanged += ArmorDataChanged;
            // 
            // labelArmorMagicDefensePercent
            // 
            labelArmorMagicDefensePercent.AutoSize = true;
            labelArmorMagicDefensePercent.Location = new Point(325, 91);
            labelArmorMagicDefensePercent.Name = "labelArmorMagicDefensePercent";
            labelArmorMagicDefensePercent.Size = new Size(76, 15);
            labelArmorMagicDefensePercent.TabIndex = 40;
            labelArmorMagicDefensePercent.Text = "M.Defense%:";
            // 
            // numericArmorMagicDefense
            // 
            numericArmorMagicDefense.Location = new Point(219, 109);
            numericArmorMagicDefense.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericArmorMagicDefense.Name = "numericArmorMagicDefense";
            numericArmorMagicDefense.Size = new Size(100, 23);
            numericArmorMagicDefense.TabIndex = 39;
            numericArmorMagicDefense.ValueChanged += ArmorDataChanged;
            // 
            // comboBoxArmorElementModifier
            // 
            comboBoxArmorElementModifier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxArmorElementModifier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxArmorElementModifier.FormattingEnabled = true;
            comboBoxArmorElementModifier.Location = new Point(382, 323);
            comboBoxArmorElementModifier.Name = "comboBoxArmorElementModifier";
            comboBoxArmorElementModifier.Size = new Size(181, 23);
            comboBoxArmorElementModifier.TabIndex = 35;
            comboBoxArmorElementModifier.SelectedIndexChanged += ArmorDataChanged;
            // 
            // labelArmorMagicDefense
            // 
            labelArmorMagicDefense.AutoSize = true;
            labelArmorMagicDefense.Location = new Point(219, 91);
            labelArmorMagicDefense.Name = "labelArmorMagicDefense";
            labelArmorMagicDefense.Size = new Size(66, 15);
            labelArmorMagicDefense.TabIndex = 38;
            labelArmorMagicDefense.Text = "M.Defense:";
            // 
            // comboBoxArmorStatus
            // 
            comboBoxArmorStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxArmorStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxArmorStatus.FormattingEnabled = true;
            comboBoxArmorStatus.Location = new Point(382, 367);
            comboBoxArmorStatus.Name = "comboBoxArmorStatus";
            comboBoxArmorStatus.Size = new Size(181, 23);
            comboBoxArmorStatus.TabIndex = 30;
            comboBoxArmorStatus.SelectedIndexChanged += ArmorDataChanged;
            // 
            // numericArmorDefensePercent
            // 
            numericArmorDefensePercent.Location = new Point(113, 109);
            numericArmorDefensePercent.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericArmorDefensePercent.Name = "numericArmorDefensePercent";
            numericArmorDefensePercent.Size = new Size(100, 23);
            numericArmorDefensePercent.TabIndex = 37;
            numericArmorDefensePercent.ValueChanged += ArmorDataChanged;
            // 
            // elementsControlArmor
            // 
            elementsControlArmor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            elementsControlArmor.Location = new Point(7, 305);
            elementsControlArmor.MinimumSize = new Size(370, 130);
            elementsControlArmor.Name = "elementsControlArmor";
            elementsControlArmor.Size = new Size(370, 130);
            elementsControlArmor.TabIndex = 33;
            elementsControlArmor.ElementsChanged += ArmorDataChanged;
            // 
            // labelArmorStatus
            // 
            labelArmorStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelArmorStatus.AutoSize = true;
            labelArmorStatus.Location = new Point(382, 349);
            labelArmorStatus.Name = "labelArmorStatus";
            labelArmorStatus.Size = new Size(87, 15);
            labelArmorStatus.TabIndex = 29;
            labelArmorStatus.Text = "Protects status:";
            // 
            // labelArmorDefencePercent
            // 
            labelArmorDefencePercent.AutoSize = true;
            labelArmorDefencePercent.Location = new Point(113, 91);
            labelArmorDefencePercent.Name = "labelArmorDefencePercent";
            labelArmorDefencePercent.Size = new Size(62, 15);
            labelArmorDefencePercent.TabIndex = 36;
            labelArmorDefencePercent.Text = "Defense%:";
            // 
            // numericArmorDefense
            // 
            numericArmorDefense.Location = new Point(7, 109);
            numericArmorDefense.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericArmorDefense.Name = "numericArmorDefense";
            numericArmorDefense.Size = new Size(100, 23);
            numericArmorDefense.TabIndex = 35;
            numericArmorDefense.ValueChanged += ArmorDataChanged;
            // 
            // labelArmorDefense
            // 
            labelArmorDefense.AutoSize = true;
            labelArmorDefense.Location = new Point(7, 91);
            labelArmorDefense.Name = "labelArmorDefense";
            labelArmorDefense.Size = new Size(52, 15);
            labelArmorDefense.TabIndex = 34;
            labelArmorDefense.Text = "Defense:";
            // 
            // statIncreaseControlArmor
            // 
            statIncreaseControlArmor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statIncreaseControlArmor.Location = new Point(7, 157);
            statIncreaseControlArmor.MinimumSize = new Size(250, 142);
            statIncreaseControlArmor.Name = "statIncreaseControlArmor";
            statIncreaseControlArmor.Size = new Size(327, 142);
            statIncreaseControlArmor.TabIndex = 33;
            statIncreaseControlArmor.DataChanged += ArmorDataChanged;
            // 
            // labelArmorName
            // 
            labelArmorName.AutoSize = true;
            labelArmorName.Location = new Point(7, 3);
            labelArmorName.Margin = new Padding(4, 0, 4, 0);
            labelArmorName.Name = "labelArmorName";
            labelArmorName.Size = new Size(42, 15);
            labelArmorName.TabIndex = 9;
            labelArmorName.Text = "Name:";
            // 
            // textBoxArmorName
            // 
            textBoxArmorName.Location = new Point(7, 21);
            textBoxArmorName.Margin = new Padding(4, 3, 4, 3);
            textBoxArmorName.Name = "textBoxArmorName";
            textBoxArmorName.Size = new Size(230, 23);
            textBoxArmorName.TabIndex = 10;
            textBoxArmorName.TextChanged += textBoxName_TextChanged;
            // 
            // labelArmorDescription
            // 
            labelArmorDescription.AutoSize = true;
            labelArmorDescription.Location = new Point(7, 47);
            labelArmorDescription.Margin = new Padding(4, 0, 4, 0);
            labelArmorDescription.Name = "labelArmorDescription";
            labelArmorDescription.Size = new Size(70, 15);
            labelArmorDescription.TabIndex = 11;
            labelArmorDescription.Text = "Description:";
            // 
            // groupBoxArmorMateriaSlots
            // 
            groupBoxArmorMateriaSlots.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxArmorMateriaSlots.Controls.Add(materiaSlotSelectorArmor);
            groupBoxArmorMateriaSlots.Controls.Add(labelArmorMateriaGrowth);
            groupBoxArmorMateriaSlots.Controls.Add(comboBoxArmorMateriaGrowth);
            groupBoxArmorMateriaSlots.Location = new Point(341, 188);
            groupBoxArmorMateriaSlots.Name = "groupBoxArmorMateriaSlots";
            groupBoxArmorMateriaSlots.Size = new Size(223, 111);
            groupBoxArmorMateriaSlots.TabIndex = 23;
            groupBoxArmorMateriaSlots.TabStop = false;
            groupBoxArmorMateriaSlots.Text = "Materia slots";
            // 
            // materiaSlotSelectorArmor
            // 
            materiaSlotSelectorArmor.BackColor = Color.LightSlateGray;
            materiaSlotSelectorArmor.BorderStyle = BorderStyle.Fixed3D;
            materiaSlotSelectorArmor.Location = new Point(6, 22);
            materiaSlotSelectorArmor.Name = "materiaSlotSelectorArmor";
            materiaSlotSelectorArmor.Size = new Size(211, 35);
            materiaSlotSelectorArmor.TabIndex = 4;
            materiaSlotSelectorArmor.DataChanged += materiaSlotSelectorArmor_DataChanged;
            materiaSlotSelectorArmor.MultiLinkEnabled += materiaSlotSelector_MultiLinkEnabled;
            // 
            // labelArmorMateriaGrowth
            // 
            labelArmorMateriaGrowth.AutoSize = true;
            labelArmorMateriaGrowth.Location = new Point(6, 60);
            labelArmorMateriaGrowth.Name = "labelArmorMateriaGrowth";
            labelArmorMateriaGrowth.Size = new Size(49, 15);
            labelArmorMateriaGrowth.TabIndex = 1;
            labelArmorMateriaGrowth.Text = "Growth:";
            // 
            // comboBoxArmorMateriaGrowth
            // 
            comboBoxArmorMateriaGrowth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxArmorMateriaGrowth.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxArmorMateriaGrowth.FormattingEnabled = true;
            comboBoxArmorMateriaGrowth.Location = new Point(6, 78);
            comboBoxArmorMateriaGrowth.Name = "comboBoxArmorMateriaGrowth";
            comboBoxArmorMateriaGrowth.Size = new Size(211, 23);
            comboBoxArmorMateriaGrowth.TabIndex = 2;
            comboBoxArmorMateriaGrowth.SelectedIndexChanged += comboBoxArmorMateriaGrowth_SelectedIndexChanged;
            // 
            // textBoxArmorDescription
            // 
            textBoxArmorDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxArmorDescription.Location = new Point(7, 65);
            textBoxArmorDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxArmorDescription.Name = "textBoxArmorDescription";
            textBoxArmorDescription.Size = new Size(556, 23);
            textBoxArmorDescription.TabIndex = 12;
            textBoxArmorDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // tabPageArmor2
            // 
            tabPageArmor2.Controls.Add(itemRestrictionsArmor);
            tabPageArmor2.Controls.Add(equipableListArmor);
            tabPageArmor2.Location = new Point(4, 24);
            tabPageArmor2.Name = "tabPageArmor2";
            tabPageArmor2.Padding = new Padding(3);
            tabPageArmor2.Size = new Size(570, 441);
            tabPageArmor2.TabIndex = 1;
            tabPageArmor2.Text = "Page 2";
            tabPageArmor2.UseVisualStyleBackColor = true;
            // 
            // itemRestrictionsArmor
            // 
            itemRestrictionsArmor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            itemRestrictionsArmor.Location = new Point(339, 6);
            itemRestrictionsArmor.Name = "itemRestrictionsArmor";
            itemRestrictionsArmor.Size = new Size(224, 125);
            itemRestrictionsArmor.TabIndex = 32;
            itemRestrictionsArmor.FlagsChanged += ArmorDataChanged;
            // 
            // equipableListArmor
            // 
            equipableListArmor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            equipableListArmor.Location = new Point(6, 6);
            equipableListArmor.MinimumSize = new Size(280, 125);
            equipableListArmor.Name = "equipableListArmor";
            equipableListArmor.Size = new Size(327, 125);
            equipableListArmor.TabIndex = 31;
            equipableListArmor.FlagsChanged += ArmorDataChanged;
            // 
            // listBoxArmor
            // 
            listBoxArmor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxArmor.FormattingEnabled = true;
            listBoxArmor.Location = new Point(9, 13);
            listBoxArmor.Margin = new Padding(4, 3, 4, 3);
            listBoxArmor.Name = "listBoxArmor";
            listBoxArmor.Size = new Size(174, 469);
            listBoxArmor.TabIndex = 2;
            listBoxArmor.SelectedIndexChanged += listBoxArmor_SelectedIndexChanged;
            // 
            // tabPageAccessoryData
            // 
            tabPageAccessoryData.Controls.Add(tabControlAccessories);
            tabPageAccessoryData.Controls.Add(listBoxAccessories);
            tabPageAccessoryData.Location = new Point(4, 24);
            tabPageAccessoryData.Margin = new Padding(4, 3, 4, 3);
            tabPageAccessoryData.Name = "tabPageAccessoryData";
            tabPageAccessoryData.Size = new Size(776, 502);
            tabPageAccessoryData.TabIndex = 6;
            tabPageAccessoryData.Text = "Accessories";
            tabPageAccessoryData.UseVisualStyleBackColor = true;
            // 
            // tabControlAccessories
            // 
            tabControlAccessories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlAccessories.Controls.Add(tabPageAccessory1);
            tabControlAccessories.Controls.Add(tabPageAccessory2);
            tabControlAccessories.Location = new Point(190, 13);
            tabControlAccessories.Name = "tabControlAccessories";
            tabControlAccessories.SelectedIndex = 0;
            tabControlAccessories.Size = new Size(578, 469);
            tabControlAccessories.TabIndex = 25;
            // 
            // tabPageAccessory1
            // 
            tabPageAccessory1.Controls.Add(labelAccessoryID);
            tabPageAccessory1.Controls.Add(labelAccessoryElementModifier);
            tabPageAccessory1.Controls.Add(comboBoxAccessoryElementModifier);
            tabPageAccessory1.Controls.Add(statusesControlAccessory);
            tabPageAccessory1.Controls.Add(elementsControlAccessory);
            tabPageAccessory1.Controls.Add(statIncreaseControlAccessory);
            tabPageAccessory1.Controls.Add(labelAccessoryName);
            tabPageAccessory1.Controls.Add(textBoxAccessoryName);
            tabPageAccessory1.Controls.Add(labelAccessoryDescription);
            tabPageAccessory1.Controls.Add(textBoxAccessoryDescription);
            tabPageAccessory1.Location = new Point(4, 24);
            tabPageAccessory1.Name = "tabPageAccessory1";
            tabPageAccessory1.Padding = new Padding(3);
            tabPageAccessory1.Size = new Size(570, 441);
            tabPageAccessory1.TabIndex = 0;
            tabPageAccessory1.Text = "Page 1";
            tabPageAccessory1.UseVisualStyleBackColor = true;
            // 
            // labelAccessoryID
            // 
            labelAccessoryID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAccessoryID.AutoSize = true;
            labelAccessoryID.Location = new Point(530, 3);
            labelAccessoryID.Name = "labelAccessoryID";
            labelAccessoryID.Size = new Size(34, 15);
            labelAccessoryID.TabIndex = 45;
            labelAccessoryID.Text = "ID: ??";
            labelAccessoryID.TextAlign = ContentAlignment.TopRight;
            // 
            // labelAccessoryElementModifier
            // 
            labelAccessoryElementModifier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAccessoryElementModifier.AutoSize = true;
            labelAccessoryElementModifier.Location = new Point(383, 94);
            labelAccessoryElementModifier.Name = "labelAccessoryElementModifier";
            labelAccessoryElementModifier.Size = new Size(147, 15);
            labelAccessoryElementModifier.TabIndex = 36;
            labelAccessoryElementModifier.Text = "Element damage modifier:";
            // 
            // comboBoxAccessoryElementModifier
            // 
            comboBoxAccessoryElementModifier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxAccessoryElementModifier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccessoryElementModifier.FormattingEnabled = true;
            comboBoxAccessoryElementModifier.Location = new Point(383, 112);
            comboBoxAccessoryElementModifier.Name = "comboBoxAccessoryElementModifier";
            comboBoxAccessoryElementModifier.Size = new Size(180, 23);
            comboBoxAccessoryElementModifier.TabIndex = 37;
            comboBoxAccessoryElementModifier.SelectedIndexChanged += AccessoryDataChanged;
            // 
            // statusesControlAccessory
            // 
            statusesControlAccessory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusesControlAccessory.Location = new Point(7, 235);
            statusesControlAccessory.MinimumSize = new Size(500, 200);
            statusesControlAccessory.Name = "statusesControlAccessory";
            statusesControlAccessory.Size = new Size(556, 200);
            statusesControlAccessory.TabIndex = 23;
            statusesControlAccessory.StatusesChanged += AccessoryDataChanged;
            // 
            // elementsControlAccessory
            // 
            elementsControlAccessory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            elementsControlAccessory.Location = new Point(7, 94);
            elementsControlAccessory.MinimumSize = new Size(370, 130);
            elementsControlAccessory.Name = "elementsControlAccessory";
            elementsControlAccessory.Size = new Size(370, 131);
            elementsControlAccessory.TabIndex = 26;
            elementsControlAccessory.ElementsChanged += AccessoryDataChanged;
            // 
            // statIncreaseControlAccessory
            // 
            statIncreaseControlAccessory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statIncreaseControlAccessory.Location = new Point(384, 141);
            statIncreaseControlAccessory.Name = "statIncreaseControlAccessory";
            statIncreaseControlAccessory.Size = new Size(179, 84);
            statIncreaseControlAccessory.TabIndex = 26;
            statIncreaseControlAccessory.DataChanged += AccessoryDataChanged;
            // 
            // labelAccessoryName
            // 
            labelAccessoryName.AutoSize = true;
            labelAccessoryName.Location = new Point(7, 3);
            labelAccessoryName.Margin = new Padding(4, 0, 4, 0);
            labelAccessoryName.Name = "labelAccessoryName";
            labelAccessoryName.Size = new Size(42, 15);
            labelAccessoryName.TabIndex = 9;
            labelAccessoryName.Text = "Name:";
            // 
            // textBoxAccessoryName
            // 
            textBoxAccessoryName.Location = new Point(7, 21);
            textBoxAccessoryName.Margin = new Padding(4, 3, 4, 3);
            textBoxAccessoryName.Name = "textBoxAccessoryName";
            textBoxAccessoryName.Size = new Size(230, 23);
            textBoxAccessoryName.TabIndex = 10;
            textBoxAccessoryName.TextChanged += textBoxName_TextChanged;
            // 
            // labelAccessoryDescription
            // 
            labelAccessoryDescription.AutoSize = true;
            labelAccessoryDescription.Location = new Point(7, 47);
            labelAccessoryDescription.Margin = new Padding(4, 0, 4, 0);
            labelAccessoryDescription.Name = "labelAccessoryDescription";
            labelAccessoryDescription.Size = new Size(70, 15);
            labelAccessoryDescription.TabIndex = 11;
            labelAccessoryDescription.Text = "Description:";
            // 
            // textBoxAccessoryDescription
            // 
            textBoxAccessoryDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAccessoryDescription.Location = new Point(7, 65);
            textBoxAccessoryDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxAccessoryDescription.Name = "textBoxAccessoryDescription";
            textBoxAccessoryDescription.Size = new Size(556, 23);
            textBoxAccessoryDescription.TabIndex = 12;
            textBoxAccessoryDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // tabPageAccessory2
            // 
            tabPageAccessory2.Controls.Add(comboBoxAccessorySpecialEffects);
            tabPageAccessory2.Controls.Add(labelAccessorySpecialEffects);
            tabPageAccessory2.Controls.Add(equipableListAccessory);
            tabPageAccessory2.Controls.Add(itemRestrictionsAccessory);
            tabPageAccessory2.Location = new Point(4, 24);
            tabPageAccessory2.Name = "tabPageAccessory2";
            tabPageAccessory2.Padding = new Padding(3);
            tabPageAccessory2.Size = new Size(570, 441);
            tabPageAccessory2.TabIndex = 1;
            tabPageAccessory2.Text = "Page 2";
            tabPageAccessory2.UseVisualStyleBackColor = true;
            // 
            // comboBoxAccessorySpecialEffects
            // 
            comboBoxAccessorySpecialEffects.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxAccessorySpecialEffects.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccessorySpecialEffects.FormattingEnabled = true;
            comboBoxAccessorySpecialEffects.Items.AddRange(new object[] { "None", "Start battle with Haste", "Start battle with Berserk", "All stats increased, but apply Death Sentence", "Start battle with Reflect", "Increase stealing rate", "Increase manipulation rate", "Start battle with Barrier+MBarrier" });
            comboBoxAccessorySpecialEffects.Location = new Point(6, 21);
            comboBoxAccessorySpecialEffects.Name = "comboBoxAccessorySpecialEffects";
            comboBoxAccessorySpecialEffects.Size = new Size(311, 23);
            comboBoxAccessorySpecialEffects.TabIndex = 27;
            comboBoxAccessorySpecialEffects.SelectedIndexChanged += AccessoryDataChanged;
            // 
            // labelAccessorySpecialEffects
            // 
            labelAccessorySpecialEffects.AutoSize = true;
            labelAccessorySpecialEffects.Location = new Point(6, 3);
            labelAccessorySpecialEffects.Name = "labelAccessorySpecialEffects";
            labelAccessorySpecialEffects.Size = new Size(80, 15);
            labelAccessorySpecialEffects.TabIndex = 26;
            labelAccessorySpecialEffects.Text = "Special effect:";
            // 
            // equipableListAccessory
            // 
            equipableListAccessory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            equipableListAccessory.Location = new Point(6, 50);
            equipableListAccessory.MinimumSize = new Size(280, 125);
            equipableListAccessory.Name = "equipableListAccessory";
            equipableListAccessory.Size = new Size(311, 125);
            equipableListAccessory.TabIndex = 24;
            equipableListAccessory.FlagsChanged += AccessoryDataChanged;
            // 
            // itemRestrictionsAccessory
            // 
            itemRestrictionsAccessory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            itemRestrictionsAccessory.Location = new Point(323, 50);
            itemRestrictionsAccessory.Name = "itemRestrictionsAccessory";
            itemRestrictionsAccessory.Size = new Size(240, 125);
            itemRestrictionsAccessory.TabIndex = 25;
            itemRestrictionsAccessory.FlagsChanged += AccessoryDataChanged;
            // 
            // listBoxAccessories
            // 
            listBoxAccessories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxAccessories.FormattingEnabled = true;
            listBoxAccessories.Location = new Point(9, 13);
            listBoxAccessories.Margin = new Padding(4, 3, 4, 3);
            listBoxAccessories.Name = "listBoxAccessories";
            listBoxAccessories.Size = new Size(174, 469);
            listBoxAccessories.TabIndex = 2;
            listBoxAccessories.SelectedIndexChanged += listBoxAccessories_SelectedIndexChanged;
            // 
            // tabPageMateriaData
            // 
            tabPageMateriaData.Controls.Add(labelMateriaID);
            tabPageMateriaData.Controls.Add(buttonMateriaAttributes);
            tabPageMateriaData.Controls.Add(comboBoxMateriaEquipAttributes);
            tabPageMateriaData.Controls.Add(labelMateriaEquipAttributes);
            tabPageMateriaData.Controls.Add(statusesControlMateria);
            tabPageMateriaData.Controls.Add(comboBoxMateriaSubtype);
            tabPageMateriaData.Controls.Add(labelMateriaSubtype);
            tabPageMateriaData.Controls.Add(materiaLevelControl);
            tabPageMateriaData.Controls.Add(comboBoxMateriaElement);
            tabPageMateriaData.Controls.Add(labelMateriaElement);
            tabPageMateriaData.Controls.Add(comboBoxMateriaType);
            tabPageMateriaData.Controls.Add(labelMateriaType);
            tabPageMateriaData.Controls.Add(textBoxMateriaDescription);
            tabPageMateriaData.Controls.Add(labelMateriaDescription);
            tabPageMateriaData.Controls.Add(textBoxMateriaName);
            tabPageMateriaData.Controls.Add(labelMateriaName);
            tabPageMateriaData.Controls.Add(listBoxMateria);
            tabPageMateriaData.Location = new Point(4, 24);
            tabPageMateriaData.Margin = new Padding(4, 3, 4, 3);
            tabPageMateriaData.Name = "tabPageMateriaData";
            tabPageMateriaData.Size = new Size(776, 502);
            tabPageMateriaData.TabIndex = 7;
            tabPageMateriaData.Text = "Materia";
            tabPageMateriaData.UseVisualStyleBackColor = true;
            // 
            // labelMateriaID
            // 
            labelMateriaID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelMateriaID.AutoSize = true;
            labelMateriaID.Location = new Point(730, 13);
            labelMateriaID.Name = "labelMateriaID";
            labelMateriaID.Size = new Size(34, 15);
            labelMateriaID.TabIndex = 45;
            labelMateriaID.Text = "ID: ??";
            labelMateriaID.TextAlign = ContentAlignment.TopRight;
            // 
            // buttonMateriaAttributes
            // 
            buttonMateriaAttributes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMateriaAttributes.Location = new Point(577, 163);
            buttonMateriaAttributes.Name = "buttonMateriaAttributes";
            buttonMateriaAttributes.Size = new Size(187, 23);
            buttonMateriaAttributes.TabIndex = 23;
            buttonMateriaAttributes.Text = "Change attributes...";
            buttonMateriaAttributes.UseVisualStyleBackColor = true;
            buttonMateriaAttributes.Click += buttonMateriaAttributes_Click;
            // 
            // comboBoxMateriaEquipAttributes
            // 
            comboBoxMateriaEquipAttributes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxMateriaEquipAttributes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMateriaEquipAttributes.FormattingEnabled = true;
            comboBoxMateriaEquipAttributes.Location = new Point(349, 119);
            comboBoxMateriaEquipAttributes.Name = "comboBoxMateriaEquipAttributes";
            comboBoxMateriaEquipAttributes.Size = new Size(415, 23);
            comboBoxMateriaEquipAttributes.TabIndex = 22;
            comboBoxMateriaEquipAttributes.SelectedIndexChanged += MateriaDataChanged;
            // 
            // labelMateriaEquipAttributes
            // 
            labelMateriaEquipAttributes.AutoSize = true;
            labelMateriaEquipAttributes.Location = new Point(349, 101);
            labelMateriaEquipAttributes.Name = "labelMateriaEquipAttributes";
            labelMateriaEquipAttributes.Size = new Size(77, 15);
            labelMateriaEquipAttributes.TabIndex = 21;
            labelMateriaEquipAttributes.Text = "Stat bonuses:";
            // 
            // statusesControlMateria
            // 
            statusesControlMateria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusesControlMateria.Location = new Point(190, 200);
            statusesControlMateria.MinimumSize = new Size(380, 200);
            statusesControlMateria.Name = "statusesControlMateria";
            statusesControlMateria.Size = new Size(380, 200);
            statusesControlMateria.TabIndex = 20;
            statusesControlMateria.StatusesChanged += MateriaDataChanged;
            // 
            // comboBoxMateriaSubtype
            // 
            comboBoxMateriaSubtype.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxMateriaSubtype.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMateriaSubtype.FormattingEnabled = true;
            comboBoxMateriaSubtype.Location = new Point(349, 163);
            comboBoxMateriaSubtype.Name = "comboBoxMateriaSubtype";
            comboBoxMateriaSubtype.Size = new Size(221, 23);
            comboBoxMateriaSubtype.TabIndex = 19;
            comboBoxMateriaSubtype.SelectedIndexChanged += comboBoxMateriaSubtype_SelectedIndexChanged;
            // 
            // labelMateriaSubtype
            // 
            labelMateriaSubtype.AutoSize = true;
            labelMateriaSubtype.Location = new Point(349, 145);
            labelMateriaSubtype.Name = "labelMateriaSubtype";
            labelMateriaSubtype.Size = new Size(53, 15);
            labelMateriaSubtype.TabIndex = 18;
            labelMateriaSubtype.Text = "Subtype:";
            // 
            // materiaLevelControl
            // 
            materiaLevelControl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materiaLevelControl.Location = new Point(577, 200);
            materiaLevelControl.Name = "materiaLevelControl";
            materiaLevelControl.Size = new Size(187, 252);
            materiaLevelControl.TabIndex = 17;
            materiaLevelControl.DataChanged += MateriaDataChanged;
            // 
            // comboBoxMateriaElement
            // 
            comboBoxMateriaElement.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMateriaElement.FormattingEnabled = true;
            comboBoxMateriaElement.Location = new Point(191, 119);
            comboBoxMateriaElement.Name = "comboBoxMateriaElement";
            comboBoxMateriaElement.Size = new Size(152, 23);
            comboBoxMateriaElement.TabIndex = 16;
            comboBoxMateriaElement.SelectedIndexChanged += MateriaDataChanged;
            // 
            // labelMateriaElement
            // 
            labelMateriaElement.AutoSize = true;
            labelMateriaElement.Location = new Point(191, 101);
            labelMateriaElement.Name = "labelMateriaElement";
            labelMateriaElement.Size = new Size(53, 15);
            labelMateriaElement.TabIndex = 15;
            labelMateriaElement.Text = "Element:";
            // 
            // comboBoxMateriaType
            // 
            comboBoxMateriaType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMateriaType.FormattingEnabled = true;
            comboBoxMateriaType.Location = new Point(191, 163);
            comboBoxMateriaType.Name = "comboBoxMateriaType";
            comboBoxMateriaType.Size = new Size(152, 23);
            comboBoxMateriaType.TabIndex = 14;
            comboBoxMateriaType.SelectedIndexChanged += comboBoxMateriaType_SelectedIndexChanged;
            // 
            // labelMateriaType
            // 
            labelMateriaType.AutoSize = true;
            labelMateriaType.Location = new Point(191, 145);
            labelMateriaType.Name = "labelMateriaType";
            labelMateriaType.Size = new Size(76, 15);
            labelMateriaType.TabIndex = 13;
            labelMateriaType.Text = "Materia type:";
            // 
            // textBoxMateriaDescription
            // 
            textBoxMateriaDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMateriaDescription.Location = new Point(191, 75);
            textBoxMateriaDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxMateriaDescription.Name = "textBoxMateriaDescription";
            textBoxMateriaDescription.Size = new Size(573, 23);
            textBoxMateriaDescription.TabIndex = 12;
            textBoxMateriaDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // labelMateriaDescription
            // 
            labelMateriaDescription.AutoSize = true;
            labelMateriaDescription.Location = new Point(191, 57);
            labelMateriaDescription.Margin = new Padding(4, 0, 4, 0);
            labelMateriaDescription.Name = "labelMateriaDescription";
            labelMateriaDescription.Size = new Size(70, 15);
            labelMateriaDescription.TabIndex = 11;
            labelMateriaDescription.Text = "Description:";
            // 
            // textBoxMateriaName
            // 
            textBoxMateriaName.Location = new Point(191, 31);
            textBoxMateriaName.Margin = new Padding(4, 3, 4, 3);
            textBoxMateriaName.Name = "textBoxMateriaName";
            textBoxMateriaName.Size = new Size(226, 23);
            textBoxMateriaName.TabIndex = 10;
            textBoxMateriaName.TextChanged += textBoxName_TextChanged;
            // 
            // labelMateriaName
            // 
            labelMateriaName.AutoSize = true;
            labelMateriaName.Location = new Point(191, 13);
            labelMateriaName.Margin = new Padding(4, 0, 4, 0);
            labelMateriaName.Name = "labelMateriaName";
            labelMateriaName.Size = new Size(42, 15);
            labelMateriaName.TabIndex = 9;
            labelMateriaName.Text = "Name:";
            // 
            // listBoxMateria
            // 
            listBoxMateria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxMateria.FormattingEnabled = true;
            listBoxMateria.Location = new Point(9, 13);
            listBoxMateria.Margin = new Padding(4, 3, 4, 3);
            listBoxMateria.Name = "listBoxMateria";
            listBoxMateria.Size = new Size(174, 469);
            listBoxMateria.TabIndex = 2;
            listBoxMateria.SelectedIndexChanged += listBoxMateria_SelectedIndexChanged;
            // 
            // tabPageKeyItemText
            // 
            tabPageKeyItemText.Controls.Add(textBoxKeyItemDescription);
            tabPageKeyItemText.Controls.Add(labelKeyItemDescription);
            tabPageKeyItemText.Controls.Add(textBoxKeyItemName);
            tabPageKeyItemText.Controls.Add(labelKeyItemName);
            tabPageKeyItemText.Controls.Add(listBoxKeyItems);
            tabPageKeyItemText.Location = new Point(4, 24);
            tabPageKeyItemText.Margin = new Padding(4, 3, 4, 3);
            tabPageKeyItemText.Name = "tabPageKeyItemText";
            tabPageKeyItemText.Size = new Size(776, 502);
            tabPageKeyItemText.TabIndex = 8;
            tabPageKeyItemText.Text = "Key Items";
            tabPageKeyItemText.UseVisualStyleBackColor = true;
            // 
            // textBoxKeyItemDescription
            // 
            textBoxKeyItemDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxKeyItemDescription.Location = new Point(191, 75);
            textBoxKeyItemDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxKeyItemDescription.Name = "textBoxKeyItemDescription";
            textBoxKeyItemDescription.Size = new Size(573, 23);
            textBoxKeyItemDescription.TabIndex = 8;
            textBoxKeyItemDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // labelKeyItemDescription
            // 
            labelKeyItemDescription.AutoSize = true;
            labelKeyItemDescription.Location = new Point(191, 57);
            labelKeyItemDescription.Margin = new Padding(4, 0, 4, 0);
            labelKeyItemDescription.Name = "labelKeyItemDescription";
            labelKeyItemDescription.Size = new Size(70, 15);
            labelKeyItemDescription.TabIndex = 7;
            labelKeyItemDescription.Text = "Description:";
            // 
            // textBoxKeyItemName
            // 
            textBoxKeyItemName.Location = new Point(191, 31);
            textBoxKeyItemName.Margin = new Padding(4, 3, 4, 3);
            textBoxKeyItemName.Name = "textBoxKeyItemName";
            textBoxKeyItemName.Size = new Size(226, 23);
            textBoxKeyItemName.TabIndex = 6;
            textBoxKeyItemName.TextChanged += textBoxName_TextChanged;
            // 
            // labelKeyItemName
            // 
            labelKeyItemName.AutoSize = true;
            labelKeyItemName.Location = new Point(191, 13);
            labelKeyItemName.Margin = new Padding(4, 0, 4, 0);
            labelKeyItemName.Name = "labelKeyItemName";
            labelKeyItemName.Size = new Size(42, 15);
            labelKeyItemName.TabIndex = 5;
            labelKeyItemName.Text = "Name:";
            // 
            // listBoxKeyItems
            // 
            listBoxKeyItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxKeyItems.FormattingEnabled = true;
            listBoxKeyItems.Location = new Point(9, 13);
            listBoxKeyItems.Margin = new Padding(4, 3, 4, 3);
            listBoxKeyItems.Name = "listBoxKeyItems";
            listBoxKeyItems.Size = new Size(174, 469);
            listBoxKeyItems.TabIndex = 1;
            listBoxKeyItems.SelectedIndexChanged += listBoxKeyItems_SelectedIndexChanged;
            // 
            // tabPageMisc
            // 
            tabPageMisc.Controls.Add(tabControlMisc);
            tabPageMisc.Location = new Point(4, 24);
            tabPageMisc.Name = "tabPageMisc";
            tabPageMisc.Size = new Size(776, 502);
            tabPageMisc.TabIndex = 10;
            tabPageMisc.Text = "Misc";
            tabPageMisc.UseVisualStyleBackColor = true;
            // 
            // tabControlMisc
            // 
            tabControlMisc.Controls.Add(tabPageLimitBreaks);
            tabControlMisc.Controls.Add(tabPageBattleText);
            tabControlMisc.Controls.Add(tabPageBattleRNGTable);
            tabControlMisc.Dock = DockStyle.Fill;
            tabControlMisc.Location = new Point(0, 0);
            tabControlMisc.Name = "tabControlMisc";
            tabControlMisc.SelectedIndex = 0;
            tabControlMisc.Size = new Size(776, 502);
            tabControlMisc.TabIndex = 11;
            // 
            // tabPageLimitBreaks
            // 
            tabPageLimitBreaks.Controls.Add(textBoxLimitDescription);
            tabPageLimitBreaks.Controls.Add(labelLimitDescription);
            tabPageLimitBreaks.Controls.Add(textBoxLimitName);
            tabPageLimitBreaks.Controls.Add(labelLimitName);
            tabPageLimitBreaks.Controls.Add(listBoxLimitBreaks);
            tabPageLimitBreaks.Location = new Point(4, 24);
            tabPageLimitBreaks.Name = "tabPageLimitBreaks";
            tabPageLimitBreaks.Size = new Size(768, 474);
            tabPageLimitBreaks.TabIndex = 3;
            tabPageLimitBreaks.Text = "Limit Breaks";
            tabPageLimitBreaks.UseVisualStyleBackColor = true;
            // 
            // textBoxLimitDescription
            // 
            textBoxLimitDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLimitDescription.Enabled = false;
            textBoxLimitDescription.Location = new Point(189, 68);
            textBoxLimitDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxLimitDescription.Name = "textBoxLimitDescription";
            textBoxLimitDescription.Size = new Size(572, 23);
            textBoxLimitDescription.TabIndex = 13;
            textBoxLimitDescription.TextChanged += textBoxLimitDescription_TextChanged;
            // 
            // labelLimitDescription
            // 
            labelLimitDescription.AutoSize = true;
            labelLimitDescription.Enabled = false;
            labelLimitDescription.Location = new Point(189, 50);
            labelLimitDescription.Margin = new Padding(4, 0, 4, 0);
            labelLimitDescription.Name = "labelLimitDescription";
            labelLimitDescription.Size = new Size(70, 15);
            labelLimitDescription.TabIndex = 12;
            labelLimitDescription.Text = "Description:";
            // 
            // textBoxLimitName
            // 
            textBoxLimitName.Enabled = false;
            textBoxLimitName.Location = new Point(189, 24);
            textBoxLimitName.Margin = new Padding(4, 3, 4, 3);
            textBoxLimitName.Name = "textBoxLimitName";
            textBoxLimitName.Size = new Size(226, 23);
            textBoxLimitName.TabIndex = 11;
            textBoxLimitName.TextChanged += textBoxLimitName_TextChanged;
            // 
            // labelLimitName
            // 
            labelLimitName.AutoSize = true;
            labelLimitName.Enabled = false;
            labelLimitName.Location = new Point(189, 6);
            labelLimitName.Margin = new Padding(4, 0, 4, 0);
            labelLimitName.Name = "labelLimitName";
            labelLimitName.Size = new Size(42, 15);
            labelLimitName.TabIndex = 10;
            labelLimitName.Text = "Name:";
            // 
            // listBoxLimitBreaks
            // 
            listBoxLimitBreaks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxLimitBreaks.FormattingEnabled = true;
            listBoxLimitBreaks.Location = new Point(7, 6);
            listBoxLimitBreaks.Margin = new Padding(4, 3, 4, 3);
            listBoxLimitBreaks.Name = "listBoxLimitBreaks";
            listBoxLimitBreaks.Size = new Size(174, 454);
            listBoxLimitBreaks.TabIndex = 9;
            listBoxLimitBreaks.SelectedIndexChanged += listBoxLimitBreaks_SelectedIndexChanged;
            // 
            // tabPageBattleText
            // 
            tabPageBattleText.Controls.Add(listBoxBattleText);
            tabPageBattleText.Controls.Add(textBoxBattleText);
            tabPageBattleText.Controls.Add(labelBattleText);
            tabPageBattleText.Location = new Point(4, 24);
            tabPageBattleText.Name = "tabPageBattleText";
            tabPageBattleText.Padding = new Padding(3);
            tabPageBattleText.Size = new Size(768, 474);
            tabPageBattleText.TabIndex = 0;
            tabPageBattleText.Text = "Battle Text";
            tabPageBattleText.UseVisualStyleBackColor = true;
            // 
            // listBoxBattleText
            // 
            listBoxBattleText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxBattleText.FormattingEnabled = true;
            listBoxBattleText.Location = new Point(7, 6);
            listBoxBattleText.Margin = new Padding(4, 3, 4, 3);
            listBoxBattleText.Name = "listBoxBattleText";
            listBoxBattleText.Size = new Size(300, 454);
            listBoxBattleText.TabIndex = 2;
            listBoxBattleText.SelectedIndexChanged += listBoxBattleText_SelectedIndexChanged;
            // 
            // textBoxBattleText
            // 
            textBoxBattleText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxBattleText.Enabled = false;
            textBoxBattleText.Location = new Point(315, 24);
            textBoxBattleText.Margin = new Padding(4, 3, 4, 3);
            textBoxBattleText.Name = "textBoxBattleText";
            textBoxBattleText.Size = new Size(446, 23);
            textBoxBattleText.TabIndex = 10;
            textBoxBattleText.TextChanged += textBoxBattleText_TextChanged;
            // 
            // labelBattleText
            // 
            labelBattleText.AutoSize = true;
            labelBattleText.Enabled = false;
            labelBattleText.Location = new Point(315, 6);
            labelBattleText.Margin = new Padding(4, 0, 4, 0);
            labelBattleText.Name = "labelBattleText";
            labelBattleText.Size = new Size(31, 15);
            labelBattleText.TabIndex = 9;
            labelBattleText.Text = "Text:";
            // 
            // tabPageBattleRNGTable
            // 
            tabPageBattleRNGTable.Controls.Add(rngTableControl);
            tabPageBattleRNGTable.Location = new Point(4, 24);
            tabPageBattleRNGTable.Name = "tabPageBattleRNGTable";
            tabPageBattleRNGTable.Padding = new Padding(3);
            tabPageBattleRNGTable.Size = new Size(768, 474);
            tabPageBattleRNGTable.TabIndex = 1;
            tabPageBattleRNGTable.Text = "RNG Table";
            tabPageBattleRNGTable.UseVisualStyleBackColor = true;
            // 
            // rngTableControl
            // 
            rngTableControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rngTableControl.Location = new Point(6, 6);
            rngTableControl.Name = "rngTableControl";
            rngTableControl.Size = new Size(757, 340);
            rngTableControl.TabIndex = 0;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSave.Location = new Point(14, 8);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(175, 27);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save kernel file(s)";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonImport
            // 
            buttonImport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonImport.Location = new Point(531, 8);
            buttonImport.Margin = new Padding(4, 3, 4, 3);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(117, 27);
            buttonImport.TabIndex = 2;
            buttonImport.Text = "Import...";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExport.Location = new Point(654, 8);
            buttonExport.Margin = new Padding(4, 3, 4, 3);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(117, 27);
            buttonExport.TabIndex = 3;
            buttonExport.Text = "Export...";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonExport);
            panelButtons.Controls.Add(buttonSave);
            panelButtons.Controls.Add(buttonImport);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 555);
            panelButtons.Margin = new Padding(4, 3, 4, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(784, 46);
            panelButtons.TabIndex = 4;
            // 
            // toolStripMain
            // 
            toolStripMain.GripStyle = ToolStripGripStyle.Hidden;
            toolStripMain.Items.AddRange(new ToolStripItem[] { toolStripDropDownFile, toolStripDropDownEdit, toolStripDropDownTools });
            toolStripMain.Location = new Point(0, 0);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Padding = new Padding(5, 0, 1, 0);
            toolStripMain.Size = new Size(784, 25);
            toolStripMain.TabIndex = 5;
            toolStripMain.Text = "toolStripMain";
            // 
            // toolStripDropDownFile
            // 
            toolStripDropDownFile.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownFile.DropDownItems.AddRange(new ToolStripItem[] { saveKernelFilesToolStripMenuItem, importToolStripMenuItem, exportToolStripMenuItem });
            toolStripDropDownFile.Image = (Image)resources.GetObject("toolStripDropDownFile.Image");
            toolStripDropDownFile.ImageTransparentColor = Color.Magenta;
            toolStripDropDownFile.Name = "toolStripDropDownFile";
            toolStripDropDownFile.ShowDropDownArrow = false;
            toolStripDropDownFile.Size = new Size(29, 22);
            toolStripDropDownFile.Text = "File";
            // 
            // saveKernelFilesToolStripMenuItem
            // 
            saveKernelFilesToolStripMenuItem.Name = "saveKernelFilesToolStripMenuItem";
            saveKernelFilesToolStripMenuItem.Size = new Size(165, 22);
            saveKernelFilesToolStripMenuItem.Text = "Save kernel file(s)";
            saveKernelFilesToolStripMenuItem.Click += buttonSave_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(165, 22);
            importToolStripMenuItem.Text = "Import...";
            importToolStripMenuItem.Click += buttonImport_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(165, 22);
            exportToolStripMenuItem.Text = "Export...";
            exportToolStripMenuItem.Click += buttonExport_Click;
            // 
            // toolStripDropDownEdit
            // 
            toolStripDropDownEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownEdit.DropDownItems.AddRange(new ToolStripItem[] { selectedAttackToolStripMenuItem });
            toolStripDropDownEdit.Image = (Image)resources.GetObject("toolStripDropDownEdit.Image");
            toolStripDropDownEdit.ImageTransparentColor = Color.Magenta;
            toolStripDropDownEdit.Name = "toolStripDropDownEdit";
            toolStripDropDownEdit.ShowDropDownArrow = false;
            toolStripDropDownEdit.Size = new Size(31, 22);
            toolStripDropDownEdit.Text = "Edit";
            // 
            // selectedAttackToolStripMenuItem
            // 
            selectedAttackToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createNewAttackToolStripMenuItem, attackCopyToolStripMenuItem, attackPasteToolStripMenuItem, attackDeleteToolStripMenuItem });
            selectedAttackToolStripMenuItem.Name = "selectedAttackToolStripMenuItem";
            selectedAttackToolStripMenuItem.Size = new Size(162, 22);
            selectedAttackToolStripMenuItem.Text = "Selected attack...";
            // 
            // createNewAttackToolStripMenuItem
            // 
            createNewAttackToolStripMenuItem.Name = "createNewAttackToolStripMenuItem";
            createNewAttackToolStripMenuItem.Size = new Size(168, 22);
            createNewAttackToolStripMenuItem.Text = "Create new attack";
            // 
            // attackCopyToolStripMenuItem
            // 
            attackCopyToolStripMenuItem.Name = "attackCopyToolStripMenuItem";
            attackCopyToolStripMenuItem.Size = new Size(168, 22);
            attackCopyToolStripMenuItem.Text = "Copy";
            attackCopyToolStripMenuItem.Click += attackCopyToolStripMenuItem_Click;
            // 
            // attackPasteToolStripMenuItem
            // 
            attackPasteToolStripMenuItem.Name = "attackPasteToolStripMenuItem";
            attackPasteToolStripMenuItem.Size = new Size(168, 22);
            attackPasteToolStripMenuItem.Text = "Paste";
            attackPasteToolStripMenuItem.Click += attackPasteToolStripMenuItem_Click;
            // 
            // attackDeleteToolStripMenuItem
            // 
            attackDeleteToolStripMenuItem.Name = "attackDeleteToolStripMenuItem";
            attackDeleteToolStripMenuItem.Size = new Size(168, 22);
            attackDeleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStripDropDownTools
            // 
            toolStripDropDownTools.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownTools.DropDownItems.AddRange(new ToolStripItem[] { useKernel2StringsToolStripMenuItem });
            toolStripDropDownTools.Image = (Image)resources.GetObject("toolStripDropDownTools.Image");
            toolStripDropDownTools.ImageTransparentColor = Color.Magenta;
            toolStripDropDownTools.Name = "toolStripDropDownTools";
            toolStripDropDownTools.ShowDropDownArrow = false;
            toolStripDropDownTools.Size = new Size(38, 22);
            toolStripDropDownTools.Text = "Tools";
            // 
            // useKernel2StringsToolStripMenuItem
            // 
            useKernel2StringsToolStripMenuItem.Name = "useKernel2StringsToolStripMenuItem";
            useKernel2StringsToolStripMenuItem.Size = new Size(172, 22);
            useKernel2StringsToolStripMenuItem.Text = "Use kernel2 strings";
            useKernel2StringsToolStripMenuItem.Click += useKernel2StringsToolStripMenuItem_Click;
            // 
            // KernelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 601);
            Controls.Add(tabControlMain);
            Controls.Add(toolStripMain);
            Controls.Add(panelButtons);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(800, 600);
            Name = "KernelForm";
            Text = "Scarlet - Kernel Editor";
            FormClosing += KernelForm_FormClosing;
            tabControlMain.ResumeLayout(false);
            tabPageCommandData.ResumeLayout(false);
            tabPageCommandData.PerformLayout();
            tabPageAttackData.ResumeLayout(false);
            tabPageCharacters.ResumeLayout(false);
            tabControlCharacters.ResumeLayout(false);
            tabPageInitCharacterStats.ResumeLayout(false);
            tabPageInitCharacterStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericCharacterLevelOffset).EndInit();
            groupBoxCharacterMP.ResumeLayout(false);
            groupBoxCharacterMP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericCharacterMaxMP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterBaseMP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterCurrMP).EndInit();
            groupBoxCharacterHP.ResumeLayout(false);
            groupBoxCharacterHP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericCharacterMaxHP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterBaseHP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterCurrHP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterEXPtoNext).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterKillCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterCurrentEXP).EndInit();
            groupBoxCharacterArmor.ResumeLayout(false);
            groupBoxCharacterWeapon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericCharacterLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCharacterID).EndInit();
            tabPageCharacterLimits.ResumeLayout(false);
            tabPageCharacterGrowth.ResumeLayout(false);
            groupBoxSelectedCurve.ResumeLayout(false);
            groupBoxSelectedCurve.PerformLayout();
            groupBoxCurveBonuses.ResumeLayout(false);
            groupBoxCurveBonuses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus12).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus11).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus10).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus9).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveBonus1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurveIndex).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartMainCurve).EndInit();
            tabPageCharacterAI.ResumeLayout(false);
            groupBoxCharacterAI.ResumeLayout(false);
            groupBoxCharacterScripts.ResumeLayout(false);
            tabPageInitData.ResumeLayout(false);
            tabPageInitData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericStartingGil).EndInit();
            groupBoxStartingParty.ResumeLayout(false);
            groupBoxInitMateriaStolen.ResumeLayout(false);
            groupBoxInitMateriaStolen.PerformLayout();
            groupBoxInitMateria.ResumeLayout(false);
            groupBoxInitMateria.PerformLayout();
            groupBoxInitInventory.ResumeLayout(false);
            groupBoxInitInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericInitItemAmount).EndInit();
            tabPageItemData.ResumeLayout(false);
            tabControlItems.ResumeLayout(false);
            tabPageItems1.ResumeLayout(false);
            tabPageItems1.PerformLayout();
            tabPageItems2.ResumeLayout(false);
            tabPageItems2.PerformLayout();
            tabPageItems3.ResumeLayout(false);
            tabPageWeaponData.ResumeLayout(false);
            tabControlWeapons.ResumeLayout(false);
            tabPageWeapon1.ResumeLayout(false);
            tabPageWeapon1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericWeaponCritChance).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericWeaponHitChance).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericWeaponAnimationIndex).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericWeaponModelIndex).EndInit();
            groupBoxWeaponMateriaSlots.ResumeLayout(false);
            groupBoxWeaponMateriaSlots.PerformLayout();
            tabPageWeapon2.ResumeLayout(false);
            tabPageArmorData.ResumeLayout(false);
            tabControlArmor.ResumeLayout(false);
            tabPageArmor1.ResumeLayout(false);
            tabPageArmor1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericArmorMagicDefensePercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericArmorMagicDefense).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericArmorDefensePercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericArmorDefense).EndInit();
            groupBoxArmorMateriaSlots.ResumeLayout(false);
            groupBoxArmorMateriaSlots.PerformLayout();
            tabPageArmor2.ResumeLayout(false);
            tabPageAccessoryData.ResumeLayout(false);
            tabControlAccessories.ResumeLayout(false);
            tabPageAccessory1.ResumeLayout(false);
            tabPageAccessory1.PerformLayout();
            tabPageAccessory2.ResumeLayout(false);
            tabPageAccessory2.PerformLayout();
            tabPageMateriaData.ResumeLayout(false);
            tabPageMateriaData.PerformLayout();
            tabPageKeyItemText.ResumeLayout(false);
            tabPageKeyItemText.PerformLayout();
            tabPageMisc.ResumeLayout(false);
            tabControlMisc.ResumeLayout(false);
            tabPageLimitBreaks.ResumeLayout(false);
            tabPageLimitBreaks.PerformLayout();
            tabPageBattleText.ResumeLayout(false);
            tabPageBattleText.PerformLayout();
            tabPageBattleRNGTable.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabPageCommandData;
        private TabPage tabPageAttackData;
        private Button buttonSave;
        private Button buttonImport;
        private Button buttonExport;
        private Panel panelButtons;
        private TabPage tabPageCharacters;
        private TabPage tabPageWeaponData;
        private TabPage tabPageArmorData;
        private TabPage tabPageAccessoryData;
        private TabPage tabPageMateriaData;
        private TabPage tabPageKeyItemText;
        private TabPage tabPageItemData;
        private ListBox listBoxItems;
        private ListBox listBoxWeapons;
        private ListBox listBoxArmor;
        private ListBox listBoxAccessories;
        private ListBox listBoxMateria;
        private ListBox listBoxCommands;
        private ListBox listBoxAttacks;
        private ListBox listBoxKeyItems;
        private TextBox textBoxKeyItemDescription;
        private Label labelKeyItemDescription;
        private TextBox textBoxKeyItemName;
        private Label labelKeyItemName;
        private TextBox textBoxItemDescription;
        private Label labelItemDescription;
        private TextBox textBoxItemName;
        private Label labelItemName;
        private TextBox textBoxWeaponDescription;
        private Label labelWeaponDescription;
        private TextBox textBoxWeaponName;
        private Label labelWeaponName;
        private TextBox textBoxArmorDescription;
        private Label labelArmorDescription;
        private TextBox textBoxArmorName;
        private Label labelArmorName;
        private TextBox textBoxAccessoryDescription;
        private Label labelAccessoryDescription;
        private TextBox textBoxAccessoryName;
        private Label labelAccessoryName;
        private TextBox textBoxMateriaDescription;
        private Label labelMateriaDescription;
        private TextBox textBoxMateriaName;
        private Label labelMateriaName;
        private TextBox textBoxCommandDescription;
        private Label labelCommandDescription;
        private TextBox textBoxCommandName;
        private Label labelCommandName;
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
        private ComboBox comboBoxItemStatusChange;
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
        private TabPage tabPageItems3;
        private Shared.SpecialAttackFlagsControl specialAttackFlagsControlItem;
        private TabPage tabPageInitCharacterStats;
        private TabPage tabPageInitData;
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
        private FF7Scarlet.Shared.Controls.CharacterStatsControl characterStatsControl;
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
        private FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl materiaSlotSelectorWeapon;
        private FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl materiaSlotSelectorArmor;
        private GroupBox groupBoxCharacterArmor;
        private FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl materiaSlotSelectorCharacterArmor;
        private GroupBox groupBoxCharacterWeapon;
        private FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl materiaSlotSelectorCharacterWeapon;
        private Button buttonCharacterArmorChangeMateria;
        private Button buttonCharacterWeaponChangeMateria;
        private NumericUpDown numericCharacterCurrentEXP;
        private Label labelCharacterCurrentEXP;
        private FF7Scarlet.Shared.Controls.CharacterLimitControl characterLimitControl;
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
        private GroupBox groupBoxInitMateriaStolen;
        private Button buttonInitMateriaStolenEdit;
        private ComboBox comboBoxInitMateriaStolen;
        private Label labelInitMateriaStolen;
        private ListBox listBoxInitMateriaStolen;
        private TabControl tabControlCharacters;
        private TabPage tabPageCharacterGrowth;
        private TabPage tabPageCharacterAI;
        private TabPage tabPageMisc;
        private ListBox listBoxBattleText;
        private TextBox textBoxBattleText;
        private ListBox listBoxCharacterGrowth;
        private ListBox listBoxCharacterAI;
        private ListBox listBoxCharacterScripts;
        private GroupBox groupBoxCharacterScripts;
        private GroupBox groupBoxCharacterAI;
        private AIEditor.ScriptControl scriptControlCharacterAI;
        private Label labelBattleText;
        private TabControl tabControlMisc;
        private TabPage tabPageBattleText;
        private TabPage tabPageBattleRNGTable;
        private Controls.RNGTableControl rngTableControl;
        private ToolStrip toolStripMain;
        private ToolStripDropDownButton toolStripDropDownFile;
        private ToolStripDropDownButton toolStripDropDownEdit;
        private ToolStripMenuItem saveKernelFilesToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem selectedAttackToolStripMenuItem;
        private ToolStripMenuItem createNewAttackToolStripMenuItem;
        private ToolStripMenuItem attackCopyToolStripMenuItem;
        private ToolStripMenuItem attackPasteToolStripMenuItem;
        private ToolStripMenuItem attackDeleteToolStripMenuItem;
        private GroupBox groupBoxStartingParty;
        private ComboBox comboBoxParty3;
        private ComboBox comboBoxParty2;
        private ComboBox comboBoxParty1;
        private Label labelStartingGil;
        private NumericUpDown numericStartingGil;
        private Button buttonMateriaAttributes;
        private TabPage tabPageLimitBreaks;
        private TextBox textBoxLimitDescription;
        private Label labelLimitDescription;
        private TextBox textBoxLimitName;
        private Label labelLimitName;
        private ListBox listBoxLimitBreaks;
        private ListBox listBoxStatCurves;
        private GroupBox groupBoxSelectedCurve;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMainCurve;
        private Label labelCurveIndex;
        private NumericUpDown numericCurveIndex;
        private NumericUpDown numericCharacterLevelOffset;
        private Label labelCharacterLevelOffset;
        private GroupBox groupBoxCurveBonuses;
        private NumericUpDown numericCurveBonus11;
        private NumericUpDown numericCurveBonus10;
        private NumericUpDown numericCurveBonus9;
        private NumericUpDown numericCurveBonus8;
        private NumericUpDown numericCurveBonus7;
        private NumericUpDown numericCurveBonus6;
        private NumericUpDown numericCurveBonus5;
        private NumericUpDown numericCurveBonus4;
        private NumericUpDown numericCurveBonus3;
        private NumericUpDown numericCurveBonus2;
        private NumericUpDown numericCurveBonus1;
        private NumericUpDown numericCurveBonus12;
        private Button buttonEditBaseCurve;
        private Label labelCurveExplanation;
        private Label labelInaccurateCurve;
        private Label labelCommandID;
        private Label labelItemID;
        private Label labelWeaponID;
        private Label labelArmorID;
        private Label labelAccessoryID;
        private Label labelMateriaID;
        private TabPage tabPageCharacterLimits;
        private ListBox listBoxCharacterLimits;
        private Controls.LimitRequirementControl limitRequirementControl1;
        private Controls.LimitRequirementControl limitRequirementControl4;
        private Controls.LimitRequirementControl limitRequirementControl3;
        private Controls.LimitRequirementControl limitRequirementControl2;
        private Label labelCurveMax;
        private Label labelCurveMin;
        private Label labelCurveLevel;
        private ComboBox comboBoxAttackType;
        private ToolStripDropDownButton toolStripDropDownTools;
        private ToolStripMenuItem useKernel2StringsToolStripMenuItem;
        private Shared.Controls.AttackFormControl attackFormControl;
    }
}