using FF7Scarlet.KernelEditor.Controls;
using System.Windows.Forms;

namespace FF7Scarlet.ExeEditor
{
    partial class ExeEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExeEditorForm));
            buttonSaveEXE = new Button();
            buttonLoadFile = new Button();
            buttonSaveFile = new Button();
            tabControlMain = new TabControl();
            tabPageInitialData = new TabPage();
            comboBoxSelectedCharacter = new ComboBox();
            labelCharacter = new Label();
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
            tabPageLimitBreaks = new TabPage();
            listBoxLimits = new ListBox();
            tabControlLimits = new TabControl();
            tabPageLimits1 = new TabPage();
            labelLimitID = new Label();
            labelLimitHurtActionIndex = new Label();
            comboBoxLimitHurtActionIndex = new ComboBox();
            labelLimitAttackEffectID = new Label();
            elementsControlLimit = new ElementsControl();
            comboBoxLimitAttackEffectID = new ComboBox();
            labelLimitImpactEffectID = new Label();
            comboBoxLimitImpactEffectID = new ComboBox();
            damageCalculationControlLimit = new DamageCalculationControl();
            labelLimitCamMovementIDMulti = new Label();
            comboBoxLimitCamMovementIDMulti = new ComboBox();
            labelLimitCamMovementIDSingle = new Label();
            comboBoxLimitCamMovementIDSingle = new ComboBox();
            labelSummonText = new Label();
            numericLimitAttackPercent = new NumericUpDown();
            textBoxSummonText = new TextBox();
            labelLimitAttackPercent = new Label();
            labelLimitMPCost = new Label();
            numericLimitMPCost = new NumericUpDown();
            tabPageLimits2 = new TabPage();
            specialAttackFlagsControlLimit = new FF7Scarlet.Shared.SpecialAttackFlagsControl();
            numericLimitStatusChangeChance = new NumericUpDown();
            comboBoxLimitConditionSubMenu = new ComboBox();
            labelLimitStatusChangeChance = new Label();
            comboBoxLimitStatusChange = new ComboBox();
            labelLimitConditionSubMenu = new Label();
            labelLimitStatusChange = new Label();
            statusesControlLimit = new StatusesControl();
            tabPageLimits3 = new TabPage();
            targetDataControlLimit = new TargetDataControl();
            tabPageNames = new TabPage();
            textBoxChocobo = new TextBox();
            pictureBoxChocobo = new PictureBox();
            textBoxCid = new TextBox();
            pictureBoxCid = new PictureBox();
            textBoxVincent = new TextBox();
            pictureBoxVincent = new PictureBox();
            textBoxCaitSith = new TextBox();
            pictureBoxCaitSith = new PictureBox();
            textBoxYuffie = new TextBox();
            pictureBoxYuffie = new PictureBox();
            textBoxRedXIII = new TextBox();
            pictureBoxRedXIII = new PictureBox();
            textBoxAeris = new TextBox();
            pictureBoxAeris = new PictureBox();
            textBoxTifa = new TextBox();
            pictureBoxTifa = new PictureBox();
            textBoxBarret = new TextBox();
            pictureBoxBarret = new PictureBox();
            textBoxCloud = new TextBox();
            pictureBoxCloud = new PictureBox();
            tabPageShopData = new TabPage();
            groupBoxShopInventory = new GroupBox();
            comboBoxShopItem10 = new ComboBox();
            comboBoxShopItem9 = new ComboBox();
            comboBoxShopItem8 = new ComboBox();
            comboBoxShopItem7 = new ComboBox();
            comboBoxShopItem6 = new ComboBox();
            comboBoxShopItem5 = new ComboBox();
            comboBoxShopItem4 = new ComboBox();
            comboBoxShopItem3 = new ComboBox();
            comboBoxShopItem2 = new ComboBox();
            comboBoxShopItem1 = new ComboBox();
            labelShopItems = new Label();
            numericShopItemCount = new NumericUpDown();
            labelShopItemCount = new Label();
            comboBoxShopType = new ComboBox();
            labelShopType = new Label();
            comboBoxShopIndex = new ComboBox();
            labelShopIndex = new Label();
            numericMateriaPrice = new NumericUpDown();
            labelMateriaPrice = new Label();
            labelMateriaPrices = new Label();
            listBoxMateriaPrices = new ListBox();
            numericMateriaAPPriceMultiplier = new NumericUpDown();
            labelMateriaAPPriceMultiplier = new Label();
            numericItemPrice = new NumericUpDown();
            labelItemPrice = new Label();
            labelItemPrices = new Label();
            listBoxItemPrices = new ListBox();
            tabPageSortOrder = new TabPage();
            groupBoxMateriaPriority = new GroupBox();
            buttonMateriaMoveDown = new Button();
            buttonMateriaMoveUp = new Button();
            listBoxMateriaPriority = new ListBox();
            groupBoxSortItemName = new GroupBox();
            buttonItemsMoveDown = new Button();
            buttonItemsMoveUp = new Button();
            buttonItemsAutoSort = new Button();
            listBoxSortItemName = new ListBox();
            tabPageMenus = new TabPage();
            tabControlMenus = new TabControl();
            tabPageMainMenu = new TabPage();
            groupBoxQuitMenu = new GroupBox();
            listBoxQuitTexts = new ListBox();
            textBoxQuitText = new TextBox();
            labelQuitText = new Label();
            groupBoxMainMenu = new GroupBox();
            listBoxMainMenu = new ListBox();
            textBoxMainMenuText = new TextBox();
            labelMainMenuText = new Label();
            tabPageItemMagicMenu = new TabPage();
            groupBoxMagicMenu = new GroupBox();
            listBoxMagicMenu = new ListBox();
            labelMagicMenuText = new Label();
            textBoxMagicMenuText = new TextBox();
            groupBoxItemMenu = new GroupBox();
            listBoxItemMenu = new ListBox();
            labelItemMenuText = new Label();
            textBoxItemMenuText = new TextBox();
            tabPageMateriaMenu = new TabPage();
            groupBoxUnequipText = new GroupBox();
            listBoxUnequipText = new ListBox();
            labelUnequipText = new Label();
            textBoxUnequipText = new TextBox();
            groupBoxMateriaText = new GroupBox();
            listBoxMateriaMenu = new ListBox();
            labelMateriaMenuText = new Label();
            textBoxMateriaMenuText = new TextBox();
            tabPageEquipMenu = new TabPage();
            labelEquipMenu = new Label();
            textBoxEquipMenuText = new TextBox();
            listBoxEquipMenu = new ListBox();
            tabPageStatusMenu = new TabPage();
            groupBoxStatusMenu = new GroupBox();
            labelStatusText = new Label();
            textBoxStatusMenuText = new TextBox();
            listBoxStatusMenuText = new ListBox();
            groupBoxElements = new GroupBox();
            labelElements = new Label();
            textBoxElements = new TextBox();
            listBoxElements = new ListBox();
            tabPageLimitMenu = new TabPage();
            labelLimitMenuText = new Label();
            textBoxLimitMenuText = new TextBox();
            listBoxLimitMenu = new ListBox();
            tabPageConfigMenu = new TabPage();
            labelConfigMenuText = new Label();
            textBoxConfigMenuText = new TextBox();
            listBoxConfigMenu = new ListBox();
            tabPageSaveMenu = new TabPage();
            labelSaveMenuText = new Label();
            textBoxSaveMenuText = new TextBox();
            listBoxSaveMenu = new ListBox();
            tabPageOtherText = new TabPage();
            tabControlOtherText = new TabControl();
            tabPageStatusEffects = new TabPage();
            labelStatusEffectMenu = new Label();
            textBoxStatusEffectMenu = new TextBox();
            labelStatusEffectTextBattle = new Label();
            textBoxStatusEffectTextBattle = new TextBox();
            listBoxStatusEffects = new ListBox();
            tabPageL4Limits = new TabPage();
            groupBoxL4Limit = new GroupBox();
            textBoxL4Wrong = new TextBox();
            labelL4Wrong = new Label();
            textBoxL4Fail = new TextBox();
            labelL4Fail = new Label();
            textBoxL4Success = new TextBox();
            labelL4Success = new Label();
            comboBoxL4Char = new ComboBox();
            pictureBoxL4Char = new PictureBox();
            tabPageBattleArena = new TabPage();
            groupBoxBattleArenaMenu = new GroupBox();
            listBoxBizarroMenu = new ListBox();
            labelBizarroMenu = new Label();
            textBoxBizarroMenu = new TextBox();
            groupBoxBattleArenaBattle = new GroupBox();
            listBoxBattleArena = new ListBox();
            labelBattleArena = new Label();
            textBoxBattleArena = new TextBox();
            tabPageShopText = new TabPage();
            groupBoxShopText = new GroupBox();
            labelShopText = new Label();
            textBoxShopText = new TextBox();
            listBoxShopText = new ListBox();
            groupBoxShopNames = new GroupBox();
            labelShopNameText = new Label();
            textBoxShopNameText = new TextBox();
            listBoxShopNames = new ListBox();
            tabPageChocoboRacing = new TabPage();
            groupBoxChocoboRacePrizes = new GroupBox();
            comboBoxChocoboRacePrizes = new ComboBox();
            labelChocoboRacePrizes = new Label();
            listBoxChocoboRacePrizes = new ListBox();
            labelPrizeNote = new Label();
            groupBoxChocoboNames = new GroupBox();
            labelChocoboName = new Label();
            textBoxChocoboName = new TextBox();
            listBoxChocoboNames = new ListBox();
            tabPageAudio = new TabPage();
            groupBoxAudioPan = new GroupBox();
            buttonAudioPanTest = new Button();
            numericAudioPan = new NumericUpDown();
            labelAudioPan = new Label();
            trackBarAudioPan = new TrackBar();
            listBoxAudioPan = new ListBox();
            groupBoxAudioVolume = new GroupBox();
            buttonAudioVolumeTest = new Button();
            numericAudioVolume = new NumericUpDown();
            labelAuidioVolume = new Label();
            trackBarAudioVolume = new TrackBar();
            listBoxAudioVolume = new ListBox();
            tabWorldmapWalkability = new TabPage();
            groupBoxDisembarkTriangleTypes = new GroupBox();
            checkedListBoxDisembarkTriangleTypes = new CheckedListBox();
            groupBoxWalkableTriangleTypes = new GroupBox();
            checkedListBoxWalkableTriangleTypes = new CheckedListBox();
            listBoxModels = new ListBox();
            buttonHext = new Button();
            panelButtons = new Panel();
            tabControlMain.SuspendLayout();
            tabPageInitialData.SuspendLayout();
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
            tabPageLimitBreaks.SuspendLayout();
            tabControlLimits.SuspendLayout();
            tabPageLimits1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericLimitAttackPercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericLimitMPCost).BeginInit();
            tabPageLimits2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericLimitStatusChangeChance).BeginInit();
            tabPageLimits3.SuspendLayout();
            tabPageNames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxChocobo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVincent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaitSith).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxYuffie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRedXIII).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAeris).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTifa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBarret).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCloud).BeginInit();
            tabPageShopData.SuspendLayout();
            groupBoxShopInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericShopItemCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMateriaPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMateriaAPPriceMultiplier).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericItemPrice).BeginInit();
            tabPageSortOrder.SuspendLayout();
            groupBoxMateriaPriority.SuspendLayout();
            groupBoxSortItemName.SuspendLayout();
            tabPageMenus.SuspendLayout();
            tabControlMenus.SuspendLayout();
            tabPageMainMenu.SuspendLayout();
            groupBoxQuitMenu.SuspendLayout();
            groupBoxMainMenu.SuspendLayout();
            tabPageItemMagicMenu.SuspendLayout();
            groupBoxMagicMenu.SuspendLayout();
            groupBoxItemMenu.SuspendLayout();
            tabPageMateriaMenu.SuspendLayout();
            groupBoxUnequipText.SuspendLayout();
            groupBoxMateriaText.SuspendLayout();
            tabPageEquipMenu.SuspendLayout();
            tabPageStatusMenu.SuspendLayout();
            groupBoxStatusMenu.SuspendLayout();
            groupBoxElements.SuspendLayout();
            tabPageLimitMenu.SuspendLayout();
            tabPageConfigMenu.SuspendLayout();
            tabPageSaveMenu.SuspendLayout();
            tabPageOtherText.SuspendLayout();
            tabControlOtherText.SuspendLayout();
            tabPageStatusEffects.SuspendLayout();
            tabPageL4Limits.SuspendLayout();
            groupBoxL4Limit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxL4Char).BeginInit();
            tabPageBattleArena.SuspendLayout();
            groupBoxBattleArenaMenu.SuspendLayout();
            groupBoxBattleArenaBattle.SuspendLayout();
            tabPageShopText.SuspendLayout();
            groupBoxShopText.SuspendLayout();
            groupBoxShopNames.SuspendLayout();
            tabPageChocoboRacing.SuspendLayout();
            groupBoxChocoboRacePrizes.SuspendLayout();
            groupBoxChocoboNames.SuspendLayout();
            tabPageAudio.SuspendLayout();
            groupBoxAudioPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAudioPan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAudioPan).BeginInit();
            groupBoxAudioVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAudioVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAudioVolume).BeginInit();
            tabWorldmapWalkability.SuspendLayout();
            groupBoxDisembarkTriangleTypes.SuspendLayout();
            groupBoxWalkableTriangleTypes.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSaveEXE
            // 
            buttonSaveEXE.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSaveEXE.Location = new Point(650, 7);
            buttonSaveEXE.Margin = new Padding(4, 3, 4, 3);
            buttonSaveEXE.Name = "buttonSaveEXE";
            buttonSaveEXE.Size = new Size(121, 27);
            buttonSaveEXE.TabIndex = 5;
            buttonSaveEXE.Text = "Update EXE";
            buttonSaveEXE.UseVisualStyleBackColor = true;
            buttonSaveEXE.Click += buttonSaveEXE_Click;
            // 
            // buttonLoadFile
            // 
            buttonLoadFile.Location = new Point(13, 7);
            buttonLoadFile.Margin = new Padding(4, 3, 4, 3);
            buttonLoadFile.Name = "buttonLoadFile";
            buttonLoadFile.Size = new Size(121, 27);
            buttonLoadFile.TabIndex = 2;
            buttonLoadFile.Text = "Load from file...";
            buttonLoadFile.UseVisualStyleBackColor = true;
            buttonLoadFile.Click += buttonLoadFile_Click;
            // 
            // buttonSaveFile
            // 
            buttonSaveFile.Location = new Point(142, 7);
            buttonSaveFile.Margin = new Padding(4, 3, 4, 3);
            buttonSaveFile.Name = "buttonSaveFile";
            buttonSaveFile.Size = new Size(121, 27);
            buttonSaveFile.TabIndex = 3;
            buttonSaveFile.Text = "Save to file...";
            buttonSaveFile.UseVisualStyleBackColor = true;
            buttonSaveFile.Click += buttonSaveFile_Click;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageInitialData);
            tabControlMain.Controls.Add(tabPageLimitBreaks);
            tabControlMain.Controls.Add(tabPageNames);
            tabControlMain.Controls.Add(tabPageShopData);
            tabControlMain.Controls.Add(tabPageSortOrder);
            tabControlMain.Controls.Add(tabPageMenus);
            tabControlMain.Controls.Add(tabPageOtherText);
            tabControlMain.Controls.Add(tabPageAudio);
            tabControlMain.Controls.Add(tabWorldmapWalkability);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Margin = new Padding(4, 3, 4, 3);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(784, 555);
            tabControlMain.TabIndex = 1;
            // 
            // tabPageInitialData
            // 
            tabPageInitialData.Controls.Add(comboBoxSelectedCharacter);
            tabPageInitialData.Controls.Add(labelCharacter);
            tabPageInitialData.Controls.Add(groupBoxCharacterMP);
            tabPageInitialData.Controls.Add(groupBoxCharacterHP);
            tabPageInitialData.Controls.Add(numericCharacterEXPtoNext);
            tabPageInitialData.Controls.Add(labelCharacterEXPtoNext);
            tabPageInitialData.Controls.Add(numericCharacterKillCount);
            tabPageInitialData.Controls.Add(labelCharacterKillCount);
            tabPageInitialData.Controls.Add(comboBoxCharacterFlags);
            tabPageInitialData.Controls.Add(labelCharacterFlags);
            tabPageInitialData.Controls.Add(characterLimitControl);
            tabPageInitialData.Controls.Add(numericCharacterCurrentEXP);
            tabPageInitialData.Controls.Add(labelCharacterCurrentEXP);
            tabPageInitialData.Controls.Add(groupBoxCharacterArmor);
            tabPageInitialData.Controls.Add(groupBoxCharacterWeapon);
            tabPageInitialData.Controls.Add(characterStatsControl);
            tabPageInitialData.Controls.Add(checkBoxCharacterBackRow);
            tabPageInitialData.Controls.Add(numericCharacterLevel);
            tabPageInitialData.Controls.Add(labelCharacterLevel);
            tabPageInitialData.Controls.Add(comboBoxCharacterAccessory);
            tabPageInitialData.Controls.Add(labelCharacterAccessory);
            tabPageInitialData.Controls.Add(numericCharacterID);
            tabPageInitialData.Controls.Add(labelCharacterID);
            tabPageInitialData.Controls.Add(textBoxCharacterName);
            tabPageInitialData.Controls.Add(labelCharacterName);
            tabPageInitialData.Location = new Point(4, 24);
            tabPageInitialData.Margin = new Padding(4, 3, 4, 3);
            tabPageInitialData.Name = "tabPageInitialData";
            tabPageInitialData.Padding = new Padding(4, 3, 4, 3);
            tabPageInitialData.Size = new Size(776, 527);
            tabPageInitialData.TabIndex = 0;
            tabPageInitialData.Text = "Cait Sith/Vincent data";
            tabPageInitialData.UseVisualStyleBackColor = true;
            // 
            // comboBoxSelectedCharacter
            // 
            comboBoxSelectedCharacter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectedCharacter.FormattingEnabled = true;
            comboBoxSelectedCharacter.Items.AddRange(new object[] { "Cait Sith", "Vincent" });
            comboBoxSelectedCharacter.Location = new Point(9, 26);
            comboBoxSelectedCharacter.Name = "comboBoxSelectedCharacter";
            comboBoxSelectedCharacter.Size = new Size(144, 23);
            comboBoxSelectedCharacter.TabIndex = 32;
            comboBoxSelectedCharacter.SelectedIndexChanged += comboBoxSelectedCharacter_SelectedIndexChanged;
            // 
            // labelCharacter
            // 
            labelCharacter.AutoSize = true;
            labelCharacter.Location = new Point(7, 6);
            labelCharacter.Name = "labelCharacter";
            labelCharacter.Size = new Size(61, 15);
            labelCharacter.TabIndex = 31;
            labelCharacter.Text = "Character:";
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
            groupBoxCharacterMP.Location = new Point(158, 180);
            groupBoxCharacterMP.Name = "groupBoxCharacterMP";
            groupBoxCharacterMP.Size = new Size(378, 71);
            groupBoxCharacterMP.TabIndex = 30;
            groupBoxCharacterMP.TabStop = false;
            groupBoxCharacterMP.Text = "MP";
            // 
            // numericCharacterMaxMP
            // 
            numericCharacterMaxMP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericCharacterMaxMP.Location = new Point(248, 37);
            numericCharacterMaxMP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterMaxMP.Name = "numericCharacterMaxMP";
            numericCharacterMaxMP.Size = new Size(124, 23);
            numericCharacterMaxMP.TabIndex = 5;
            numericCharacterMaxMP.ValueChanged += numericCharacterMaxMP_ValueChanged;
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
            numericCharacterBaseMP.ValueChanged += numericCharacterBaseMP_ValueChanged;
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
            numericCharacterCurrMP.ValueChanged += numericCharacterCurrMP_ValueChanged;
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
            groupBoxCharacterHP.Location = new Point(158, 103);
            groupBoxCharacterHP.Name = "groupBoxCharacterHP";
            groupBoxCharacterHP.Size = new Size(378, 71);
            groupBoxCharacterHP.TabIndex = 29;
            groupBoxCharacterHP.TabStop = false;
            groupBoxCharacterHP.Text = "HP";
            // 
            // numericCharacterMaxHP
            // 
            numericCharacterMaxHP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericCharacterMaxHP.Location = new Point(248, 37);
            numericCharacterMaxHP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterMaxHP.Name = "numericCharacterMaxHP";
            numericCharacterMaxHP.Size = new Size(124, 23);
            numericCharacterMaxHP.TabIndex = 5;
            numericCharacterMaxHP.ValueChanged += numericCharacterMaxHP_ValueChanged;
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
            numericCharacterBaseHP.ValueChanged += numericCharacterBaseHP_ValueChanged;
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
            numericCharacterCurrHP.ValueChanged += numericCharacterCurrHP_ValueChanged;
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
            numericCharacterEXPtoNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericCharacterEXPtoNext.Location = new Point(648, 74);
            numericCharacterEXPtoNext.Name = "numericCharacterEXPtoNext";
            numericCharacterEXPtoNext.Size = new Size(120, 23);
            numericCharacterEXPtoNext.TabIndex = 28;
            numericCharacterEXPtoNext.ValueChanged += numericCharacterEXPtoNext_ValueChanged;
            // 
            // labelCharacterEXPtoNext
            // 
            labelCharacterEXPtoNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCharacterEXPtoNext.AutoSize = true;
            labelCharacterEXPtoNext.Location = new Point(648, 55);
            labelCharacterEXPtoNext.Name = "labelCharacterEXPtoNext";
            labelCharacterEXPtoNext.Size = new Size(75, 15);
            labelCharacterEXPtoNext.TabIndex = 27;
            labelCharacterEXPtoNext.Text = "To next level:";
            // 
            // numericCharacterKillCount
            // 
            numericCharacterKillCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericCharacterKillCount.Location = new Point(408, 273);
            numericCharacterKillCount.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericCharacterKillCount.Name = "numericCharacterKillCount";
            numericCharacterKillCount.Size = new Size(128, 23);
            numericCharacterKillCount.TabIndex = 26;
            numericCharacterKillCount.ValueChanged += numericCharacterKillCount_ValueChanged;
            // 
            // labelCharacterKillCount
            // 
            labelCharacterKillCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCharacterKillCount.AutoSize = true;
            labelCharacterKillCount.Location = new Point(408, 255);
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
            comboBoxCharacterFlags.Location = new Point(158, 272);
            comboBoxCharacterFlags.Name = "comboBoxCharacterFlags";
            comboBoxCharacterFlags.Size = new Size(164, 23);
            comboBoxCharacterFlags.TabIndex = 24;
            comboBoxCharacterFlags.SelectedIndexChanged += comboBoxCharacterFlags_SelectedIndexChanged;
            // 
            // labelCharacterFlags
            // 
            labelCharacterFlags.AutoSize = true;
            labelCharacterFlags.Location = new Point(158, 254);
            labelCharacterFlags.Name = "labelCharacterFlags";
            labelCharacterFlags.Size = new Size(89, 15);
            labelCharacterFlags.TabIndex = 23;
            labelCharacterFlags.Text = "Character flags:";
            // 
            // characterLimitControl
            // 
            characterLimitControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            characterLimitControl.Location = new Point(158, 301);
            characterLimitControl.Name = "characterLimitControl";
            characterLimitControl.Size = new Size(378, 148);
            characterLimitControl.TabIndex = 22;
            // 
            // numericCharacterCurrentEXP
            // 
            numericCharacterCurrentEXP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericCharacterCurrentEXP.Location = new Point(522, 73);
            numericCharacterCurrentEXP.Name = "numericCharacterCurrentEXP";
            numericCharacterCurrentEXP.Size = new Size(120, 23);
            numericCharacterCurrentEXP.TabIndex = 21;
            numericCharacterCurrentEXP.ValueChanged += numericCharacterCurrentEXP_ValueChanged;
            // 
            // labelCharacterCurrentEXP
            // 
            labelCharacterCurrentEXP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCharacterCurrentEXP.AutoSize = true;
            labelCharacterCurrentEXP.Location = new Point(522, 54);
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
            groupBoxCharacterArmor.Location = new Point(545, 238);
            groupBoxCharacterArmor.Name = "groupBoxCharacterArmor";
            groupBoxCharacterArmor.Size = new Size(223, 128);
            groupBoxCharacterArmor.TabIndex = 17;
            groupBoxCharacterArmor.TabStop = false;
            groupBoxCharacterArmor.Text = "Armor";
            // 
            // buttonCharacterArmorChangeMateria
            // 
            buttonCharacterArmorChangeMateria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonCharacterArmorChangeMateria.Enabled = false;
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
            groupBoxCharacterWeapon.Location = new Point(545, 104);
            groupBoxCharacterWeapon.Name = "groupBoxCharacterWeapon";
            groupBoxCharacterWeapon.Size = new Size(223, 128);
            groupBoxCharacterWeapon.TabIndex = 16;
            groupBoxCharacterWeapon.TabStop = false;
            groupBoxCharacterWeapon.Text = "Weapon";
            // 
            // buttonCharacterWeaponChangeMateria
            // 
            buttonCharacterWeaponChangeMateria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonCharacterWeaponChangeMateria.Enabled = false;
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
            materiaSlotSelectorCharacterWeapon.MultiLinkEnabled += materiaSlotSelectorCharacter_MultiLinkEnabled;
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
            characterStatsControl.Location = new Point(7, 104);
            characterStatsControl.Name = "characterStatsControl";
            characterStatsControl.Size = new Size(146, 295);
            characterStatsControl.TabIndex = 14;
            characterStatsControl.CharacterStatsChanged += characterStatsControl_CharacterStatsChanged;
            // 
            // checkBoxCharacterBackRow
            // 
            checkBoxCharacterBackRow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxCharacterBackRow.AutoSize = true;
            checkBoxCharacterBackRow.Location = new Point(328, 275);
            checkBoxCharacterBackRow.Name = "checkBoxCharacterBackRow";
            checkBoxCharacterBackRow.Size = new Size(74, 19);
            checkBoxCharacterBackRow.TabIndex = 13;
            checkBoxCharacterBackRow.Text = "Back row";
            checkBoxCharacterBackRow.UseVisualStyleBackColor = true;
            checkBoxCharacterBackRow.CheckedChanged += checkBoxCharacterBackRow_CheckedChanged;
            // 
            // numericCharacterLevel
            // 
            numericCharacterLevel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericCharacterLevel.Location = new Point(441, 73);
            numericCharacterLevel.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericCharacterLevel.Name = "numericCharacterLevel";
            numericCharacterLevel.Size = new Size(75, 23);
            numericCharacterLevel.TabIndex = 12;
            numericCharacterLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericCharacterLevel.ValueChanged += numericCharacterLevel_ValueChanged;
            // 
            // labelCharacterLevel
            // 
            labelCharacterLevel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCharacterLevel.AutoSize = true;
            labelCharacterLevel.Location = new Point(441, 53);
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
            comboBoxCharacterAccessory.Location = new Point(551, 387);
            comboBoxCharacterAccessory.Name = "comboBoxCharacterAccessory";
            comboBoxCharacterAccessory.Size = new Size(211, 23);
            comboBoxCharacterAccessory.TabIndex = 10;
            comboBoxCharacterAccessory.SelectedIndexChanged += comboBoxCharacterAccessory_SelectedIndexChanged;
            // 
            // labelCharacterAccessory
            // 
            labelCharacterAccessory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCharacterAccessory.AutoSize = true;
            labelCharacterAccessory.Location = new Point(551, 369);
            labelCharacterAccessory.Name = "labelCharacterAccessory";
            labelCharacterAccessory.Size = new Size(63, 15);
            labelCharacterAccessory.TabIndex = 9;
            labelCharacterAccessory.Text = "Accessory:";
            // 
            // numericCharacterID
            // 
            numericCharacterID.Location = new Point(9, 73);
            numericCharacterID.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericCharacterID.Name = "numericCharacterID";
            numericCharacterID.Size = new Size(75, 23);
            numericCharacterID.TabIndex = 4;
            numericCharacterID.ValueChanged += numericCharacterID_ValueChanged;
            // 
            // labelCharacterID
            // 
            labelCharacterID.AutoSize = true;
            labelCharacterID.Location = new Point(9, 55);
            labelCharacterID.Name = "labelCharacterID";
            labelCharacterID.Size = new Size(75, 15);
            labelCharacterID.TabIndex = 3;
            labelCharacterID.Text = "Character ID:";
            // 
            // textBoxCharacterName
            // 
            textBoxCharacterName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCharacterName.Location = new Point(158, 72);
            textBoxCharacterName.Name = "textBoxCharacterName";
            textBoxCharacterName.Size = new Size(277, 23);
            textBoxCharacterName.TabIndex = 2;
            textBoxCharacterName.TextChanged += textBoxCharacterName_TextChanged;
            // 
            // labelCharacterName
            // 
            labelCharacterName.AutoSize = true;
            labelCharacterName.Location = new Point(158, 53);
            labelCharacterName.Name = "labelCharacterName";
            labelCharacterName.Size = new Size(42, 15);
            labelCharacterName.TabIndex = 1;
            labelCharacterName.Text = "Name:";
            // 
            // tabPageLimitBreaks
            // 
            tabPageLimitBreaks.Controls.Add(listBoxLimits);
            tabPageLimitBreaks.Controls.Add(tabControlLimits);
            tabPageLimitBreaks.Location = new Point(4, 24);
            tabPageLimitBreaks.Name = "tabPageLimitBreaks";
            tabPageLimitBreaks.Size = new Size(776, 527);
            tabPageLimitBreaks.TabIndex = 3;
            tabPageLimitBreaks.Text = "Limit breaks";
            tabPageLimitBreaks.UseVisualStyleBackColor = true;
            // 
            // listBoxLimits
            // 
            listBoxLimits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxLimits.FormattingEnabled = true;
            listBoxLimits.Location = new Point(4, 7);
            listBoxLimits.Margin = new Padding(4, 3, 4, 3);
            listBoxLimits.Name = "listBoxLimits";
            listBoxLimits.Size = new Size(174, 514);
            listBoxLimits.TabIndex = 39;
            listBoxLimits.SelectedIndexChanged += listBoxLimits_SelectedIndexChanged;
            // 
            // tabControlLimits
            // 
            tabControlLimits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlLimits.Controls.Add(tabPageLimits1);
            tabControlLimits.Controls.Add(tabPageLimits2);
            tabControlLimits.Controls.Add(tabPageLimits3);
            tabControlLimits.Enabled = false;
            tabControlLimits.Location = new Point(185, 7);
            tabControlLimits.Name = "tabControlLimits";
            tabControlLimits.SelectedIndex = 0;
            tabControlLimits.Size = new Size(582, 514);
            tabControlLimits.TabIndex = 38;
            // 
            // tabPageLimits1
            // 
            tabPageLimits1.Controls.Add(labelLimitID);
            tabPageLimits1.Controls.Add(labelLimitHurtActionIndex);
            tabPageLimits1.Controls.Add(comboBoxLimitHurtActionIndex);
            tabPageLimits1.Controls.Add(labelLimitAttackEffectID);
            tabPageLimits1.Controls.Add(elementsControlLimit);
            tabPageLimits1.Controls.Add(comboBoxLimitAttackEffectID);
            tabPageLimits1.Controls.Add(labelLimitImpactEffectID);
            tabPageLimits1.Controls.Add(comboBoxLimitImpactEffectID);
            tabPageLimits1.Controls.Add(damageCalculationControlLimit);
            tabPageLimits1.Controls.Add(labelLimitCamMovementIDMulti);
            tabPageLimits1.Controls.Add(comboBoxLimitCamMovementIDMulti);
            tabPageLimits1.Controls.Add(labelLimitCamMovementIDSingle);
            tabPageLimits1.Controls.Add(comboBoxLimitCamMovementIDSingle);
            tabPageLimits1.Controls.Add(labelSummonText);
            tabPageLimits1.Controls.Add(numericLimitAttackPercent);
            tabPageLimits1.Controls.Add(textBoxSummonText);
            tabPageLimits1.Controls.Add(labelLimitAttackPercent);
            tabPageLimits1.Controls.Add(labelLimitMPCost);
            tabPageLimits1.Controls.Add(numericLimitMPCost);
            tabPageLimits1.Location = new Point(4, 24);
            tabPageLimits1.Name = "tabPageLimits1";
            tabPageLimits1.Padding = new Padding(3);
            tabPageLimits1.Size = new Size(574, 486);
            tabPageLimits1.TabIndex = 0;
            tabPageLimits1.Text = "Page 1";
            tabPageLimits1.UseVisualStyleBackColor = true;
            // 
            // labelLimitID
            // 
            labelLimitID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelLimitID.AutoSize = true;
            labelLimitID.Location = new Point(534, 6);
            labelLimitID.Name = "labelLimitID";
            labelLimitID.Size = new Size(34, 15);
            labelLimitID.TabIndex = 43;
            labelLimitID.Text = "ID: ??";
            labelLimitID.TextAlign = ContentAlignment.TopRight;
            // 
            // labelLimitHurtActionIndex
            // 
            labelLimitHurtActionIndex.AutoSize = true;
            labelLimitHurtActionIndex.Location = new Point(382, 142);
            labelLimitHurtActionIndex.Name = "labelLimitHurtActionIndex";
            labelLimitHurtActionIndex.Size = new Size(102, 15);
            labelLimitHurtActionIndex.TabIndex = 42;
            labelLimitHurtActionIndex.Text = "Hurt action index:";
            // 
            // comboBoxLimitHurtActionIndex
            // 
            comboBoxLimitHurtActionIndex.FormattingEnabled = true;
            comboBoxLimitHurtActionIndex.Location = new Point(379, 157);
            comboBoxLimitHurtActionIndex.Name = "comboBoxLimitHurtActionIndex";
            comboBoxLimitHurtActionIndex.Size = new Size(180, 23);
            comboBoxLimitHurtActionIndex.TabIndex = 41;
            comboBoxLimitHurtActionIndex.TextChanged += comboBoxLimitHurtActionIndex_TextChanged;
            // 
            // labelLimitAttackEffectID
            // 
            labelLimitAttackEffectID.AutoSize = true;
            labelLimitAttackEffectID.Location = new Point(221, 9);
            labelLimitAttackEffectID.Name = "labelLimitAttackEffectID";
            labelLimitAttackEffectID.Size = new Size(91, 15);
            labelLimitAttackEffectID.TabIndex = 40;
            labelLimitAttackEffectID.Text = "Attack effect ID:";
            // 
            // elementsControlLimit
            // 
            elementsControlLimit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            elementsControlLimit.Location = new Point(6, 53);
            elementsControlLimit.MinimumSize = new Size(370, 130);
            elementsControlLimit.Name = "elementsControlLimit";
            elementsControlLimit.Size = new Size(370, 130);
            elementsControlLimit.TabIndex = 0;
            elementsControlLimit.ElementsChanged += LimitDataChanged;
            // 
            // comboBoxLimitAttackEffectID
            // 
            comboBoxLimitAttackEffectID.FormattingEnabled = true;
            comboBoxLimitAttackEffectID.Location = new Point(218, 24);
            comboBoxLimitAttackEffectID.Name = "comboBoxLimitAttackEffectID";
            comboBoxLimitAttackEffectID.Size = new Size(100, 23);
            comboBoxLimitAttackEffectID.TabIndex = 39;
            comboBoxLimitAttackEffectID.SelectedIndexChanged += comboBoxLimitAttackEffectID_SelectedIndexChanged;
            // 
            // labelLimitImpactEffectID
            // 
            labelLimitImpactEffectID.AutoSize = true;
            labelLimitImpactEffectID.Location = new Point(327, 9);
            labelLimitImpactEffectID.Name = "labelLimitImpactEffectID";
            labelLimitImpactEffectID.Size = new Size(94, 15);
            labelLimitImpactEffectID.TabIndex = 38;
            labelLimitImpactEffectID.Text = "Impact effect ID:";
            // 
            // comboBoxLimitImpactEffectID
            // 
            comboBoxLimitImpactEffectID.FormattingEnabled = true;
            comboBoxLimitImpactEffectID.Location = new Point(324, 24);
            comboBoxLimitImpactEffectID.Name = "comboBoxLimitImpactEffectID";
            comboBoxLimitImpactEffectID.Size = new Size(100, 23);
            comboBoxLimitImpactEffectID.TabIndex = 37;
            comboBoxLimitImpactEffectID.SelectedIndexChanged += comboBoxLimitImpactEffectID_SelectedIndexChanged;
            // 
            // damageCalculationControlLimit
            // 
            damageCalculationControlLimit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            damageCalculationControlLimit.Location = new Point(6, 189);
            damageCalculationControlLimit.Name = "damageCalculationControlLimit";
            damageCalculationControlLimit.Size = new Size(553, 140);
            damageCalculationControlLimit.TabIndex = 36;
            damageCalculationControlLimit.DataChanged += LimitDataChanged;
            // 
            // labelLimitCamMovementIDMulti
            // 
            labelLimitCamMovementIDMulti.AutoSize = true;
            labelLimitCamMovementIDMulti.Location = new Point(382, 98);
            labelLimitCamMovementIDMulti.Name = "labelLimitCamMovementIDMulti";
            labelLimitCamMovementIDMulti.Size = new Size(183, 15);
            labelLimitCamMovementIDMulti.TabIndex = 35;
            labelLimitCamMovementIDMulti.Text = "Cam movement ID (multi target):";
            // 
            // comboBoxLimitCamMovementIDMulti
            // 
            comboBoxLimitCamMovementIDMulti.FormattingEnabled = true;
            comboBoxLimitCamMovementIDMulti.Location = new Point(379, 113);
            comboBoxLimitCamMovementIDMulti.Name = "comboBoxLimitCamMovementIDMulti";
            comboBoxLimitCamMovementIDMulti.Size = new Size(180, 23);
            comboBoxLimitCamMovementIDMulti.TabIndex = 36;
            comboBoxLimitCamMovementIDMulti.TextChanged += comboBoxLimitCamMovementIDMulti_TextChanged;
            // 
            // labelLimitCamMovementIDSingle
            // 
            labelLimitCamMovementIDSingle.AutoSize = true;
            labelLimitCamMovementIDSingle.Location = new Point(382, 54);
            labelLimitCamMovementIDSingle.Name = "labelLimitCamMovementIDSingle";
            labelLimitCamMovementIDSingle.Size = new Size(186, 15);
            labelLimitCamMovementIDSingle.TabIndex = 33;
            labelLimitCamMovementIDSingle.Text = "Cam movement ID (single target):";
            // 
            // comboBoxLimitCamMovementIDSingle
            // 
            comboBoxLimitCamMovementIDSingle.FormattingEnabled = true;
            comboBoxLimitCamMovementIDSingle.Location = new Point(379, 69);
            comboBoxLimitCamMovementIDSingle.Name = "comboBoxLimitCamMovementIDSingle";
            comboBoxLimitCamMovementIDSingle.Size = new Size(180, 23);
            comboBoxLimitCamMovementIDSingle.TabIndex = 34;
            comboBoxLimitCamMovementIDSingle.TextChanged += comboBoxLimitCamMovementIDSingle_TextChanged;
            // 
            // labelSummonText
            // 
            labelSummonText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelSummonText.AutoSize = true;
            labelSummonText.Location = new Point(609, 6);
            labelSummonText.Margin = new Padding(4, 0, 4, 0);
            labelSummonText.Name = "labelSummonText";
            labelSummonText.Size = new Size(127, 15);
            labelSummonText.TabIndex = 5;
            labelSummonText.Text = "Summon attack name:";
            // 
            // numericLimitAttackPercent
            // 
            numericLimitAttackPercent.Location = new Point(6, 24);
            numericLimitAttackPercent.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericLimitAttackPercent.Name = "numericLimitAttackPercent";
            numericLimitAttackPercent.Size = new Size(100, 23);
            numericLimitAttackPercent.TabIndex = 10;
            numericLimitAttackPercent.ValueChanged += LimitDataChanged;
            // 
            // textBoxSummonText
            // 
            textBoxSummonText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxSummonText.Enabled = false;
            textBoxSummonText.Location = new Point(609, 24);
            textBoxSummonText.Margin = new Padding(4, 3, 4, 3);
            textBoxSummonText.Name = "textBoxSummonText";
            textBoxSummonText.Size = new Size(324, 23);
            textBoxSummonText.TabIndex = 6;
            // 
            // labelLimitAttackPercent
            // 
            labelLimitAttackPercent.AutoSize = true;
            labelLimitAttackPercent.Location = new Point(9, 9);
            labelLimitAttackPercent.Name = "labelLimitAttackPercent";
            labelLimitAttackPercent.Size = new Size(54, 15);
            labelLimitAttackPercent.TabIndex = 9;
            labelLimitAttackPercent.Text = "Attack%:";
            // 
            // labelLimitMPCost
            // 
            labelLimitMPCost.AutoSize = true;
            labelLimitMPCost.Location = new Point(115, 9);
            labelLimitMPCost.Name = "labelLimitMPCost";
            labelLimitMPCost.Size = new Size(53, 15);
            labelLimitMPCost.TabIndex = 7;
            labelLimitMPCost.Text = "MP cost:";
            // 
            // numericLimitMPCost
            // 
            numericLimitMPCost.Location = new Point(112, 24);
            numericLimitMPCost.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericLimitMPCost.Name = "numericLimitMPCost";
            numericLimitMPCost.Size = new Size(100, 23);
            numericLimitMPCost.TabIndex = 8;
            numericLimitMPCost.ValueChanged += LimitDataChanged;
            // 
            // tabPageLimits2
            // 
            tabPageLimits2.Controls.Add(specialAttackFlagsControlLimit);
            tabPageLimits2.Controls.Add(numericLimitStatusChangeChance);
            tabPageLimits2.Controls.Add(comboBoxLimitConditionSubMenu);
            tabPageLimits2.Controls.Add(labelLimitStatusChangeChance);
            tabPageLimits2.Controls.Add(comboBoxLimitStatusChange);
            tabPageLimits2.Controls.Add(labelLimitConditionSubMenu);
            tabPageLimits2.Controls.Add(labelLimitStatusChange);
            tabPageLimits2.Controls.Add(statusesControlLimit);
            tabPageLimits2.Location = new Point(4, 24);
            tabPageLimits2.Name = "tabPageLimits2";
            tabPageLimits2.Padding = new Padding(3);
            tabPageLimits2.Size = new Size(574, 486);
            tabPageLimits2.TabIndex = 1;
            tabPageLimits2.Text = "Page 2";
            tabPageLimits2.UseVisualStyleBackColor = true;
            // 
            // specialAttackFlagsControlLimit
            // 
            specialAttackFlagsControlLimit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            specialAttackFlagsControlLimit.Location = new Point(9, 6);
            specialAttackFlagsControlLimit.Name = "specialAttackFlagsControlLimit";
            specialAttackFlagsControlLimit.Size = new Size(559, 100);
            specialAttackFlagsControlLimit.TabIndex = 43;
            specialAttackFlagsControlLimit.FlagsChanged += LimitDataChanged;
            // 
            // numericLimitStatusChangeChance
            // 
            numericLimitStatusChangeChance.Location = new Point(152, 337);
            numericLimitStatusChangeChance.Maximum = new decimal(new int[] { 63, 0, 0, 0 });
            numericLimitStatusChangeChance.Name = "numericLimitStatusChangeChance";
            numericLimitStatusChangeChance.Size = new Size(108, 23);
            numericLimitStatusChangeChance.TabIndex = 5;
            numericLimitStatusChangeChance.ValueChanged += numericLimitStatusChangeChance_ValueChanged;
            // 
            // comboBoxLimitConditionSubMenu
            // 
            comboBoxLimitConditionSubMenu.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLimitConditionSubMenu.FormattingEnabled = true;
            comboBoxLimitConditionSubMenu.Location = new Point(6, 380);
            comboBoxLimitConditionSubMenu.Name = "comboBoxLimitConditionSubMenu";
            comboBoxLimitConditionSubMenu.Size = new Size(251, 23);
            comboBoxLimitConditionSubMenu.TabIndex = 44;
            comboBoxLimitConditionSubMenu.SelectedIndexChanged += LimitDataChanged;
            // 
            // labelLimitStatusChangeChance
            // 
            labelLimitStatusChangeChance.AutoSize = true;
            labelLimitStatusChangeChance.Location = new Point(152, 318);
            labelLimitStatusChangeChance.Name = "labelLimitStatusChangeChance";
            labelLimitStatusChangeChance.Size = new Size(108, 15);
            labelLimitStatusChangeChance.TabIndex = 4;
            labelLimitStatusChangeChance.Text = "Chance (out of 63):";
            // 
            // comboBoxLimitStatusChange
            // 
            comboBoxLimitStatusChange.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLimitStatusChange.FormattingEnabled = true;
            comboBoxLimitStatusChange.Location = new Point(6, 336);
            comboBoxLimitStatusChange.Name = "comboBoxLimitStatusChange";
            comboBoxLimitStatusChange.Size = new Size(137, 23);
            comboBoxLimitStatusChange.TabIndex = 3;
            comboBoxLimitStatusChange.SelectedIndexChanged += comboBoxLimitStatusChange_SelectedIndexChanged;
            // 
            // labelLimitConditionSubMenu
            // 
            labelLimitConditionSubMenu.AutoSize = true;
            labelLimitConditionSubMenu.Location = new Point(9, 362);
            labelLimitConditionSubMenu.Name = "labelLimitConditionSubMenu";
            labelLimitConditionSubMenu.Size = new Size(121, 15);
            labelLimitConditionSubMenu.TabIndex = 43;
            labelLimitConditionSubMenu.Text = "Condition sub-menu:";
            // 
            // labelLimitStatusChange
            // 
            labelLimitStatusChange.AutoSize = true;
            labelLimitStatusChange.Location = new Point(9, 318);
            labelLimitStatusChange.Name = "labelLimitStatusChange";
            labelLimitStatusChange.Size = new Size(84, 15);
            labelLimitStatusChange.TabIndex = 2;
            labelLimitStatusChange.Text = "Status change:";
            // 
            // statusesControlLimit
            // 
            statusesControlLimit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusesControlLimit.Location = new Point(9, 112);
            statusesControlLimit.MinimumSize = new Size(380, 200);
            statusesControlLimit.Name = "statusesControlLimit";
            statusesControlLimit.Size = new Size(559, 200);
            statusesControlLimit.TabIndex = 1;
            statusesControlLimit.StatusesChanged += LimitDataChanged;
            // 
            // tabPageLimits3
            // 
            tabPageLimits3.Controls.Add(targetDataControlLimit);
            tabPageLimits3.Location = new Point(4, 24);
            tabPageLimits3.Name = "tabPageLimits3";
            tabPageLimits3.Size = new Size(574, 486);
            tabPageLimits3.TabIndex = 2;
            tabPageLimits3.Text = "Page 3";
            tabPageLimits3.UseVisualStyleBackColor = true;
            // 
            // targetDataControlLimit
            // 
            targetDataControlLimit.Location = new Point(6, 6);
            targetDataControlLimit.Name = "targetDataControlLimit";
            targetDataControlLimit.Size = new Size(330, 125);
            targetDataControlLimit.TabIndex = 0;
            targetDataControlLimit.FlagsChanged += LimitDataChanged;
            // 
            // tabPageNames
            // 
            tabPageNames.Controls.Add(textBoxChocobo);
            tabPageNames.Controls.Add(pictureBoxChocobo);
            tabPageNames.Controls.Add(textBoxCid);
            tabPageNames.Controls.Add(pictureBoxCid);
            tabPageNames.Controls.Add(textBoxVincent);
            tabPageNames.Controls.Add(pictureBoxVincent);
            tabPageNames.Controls.Add(textBoxCaitSith);
            tabPageNames.Controls.Add(pictureBoxCaitSith);
            tabPageNames.Controls.Add(textBoxYuffie);
            tabPageNames.Controls.Add(pictureBoxYuffie);
            tabPageNames.Controls.Add(textBoxRedXIII);
            tabPageNames.Controls.Add(pictureBoxRedXIII);
            tabPageNames.Controls.Add(textBoxAeris);
            tabPageNames.Controls.Add(pictureBoxAeris);
            tabPageNames.Controls.Add(textBoxTifa);
            tabPageNames.Controls.Add(pictureBoxTifa);
            tabPageNames.Controls.Add(textBoxBarret);
            tabPageNames.Controls.Add(pictureBoxBarret);
            tabPageNames.Controls.Add(textBoxCloud);
            tabPageNames.Controls.Add(pictureBoxCloud);
            tabPageNames.Location = new Point(4, 24);
            tabPageNames.Margin = new Padding(4, 3, 4, 3);
            tabPageNames.Name = "tabPageNames";
            tabPageNames.Padding = new Padding(4, 3, 4, 3);
            tabPageNames.Size = new Size(776, 527);
            tabPageNames.TabIndex = 1;
            tabPageNames.Text = "Character names";
            tabPageNames.UseVisualStyleBackColor = true;
            // 
            // textBoxChocobo
            // 
            textBoxChocobo.Location = new Point(326, 387);
            textBoxChocobo.Margin = new Padding(4, 3, 4, 3);
            textBoxChocobo.MaxLength = 5;
            textBoxChocobo.Name = "textBoxChocobo";
            textBoxChocobo.Size = new Size(114, 23);
            textBoxChocobo.TabIndex = 10;
            textBoxChocobo.TextChanged += textBoxChocobo_TextChanged;
            // 
            // pictureBoxChocobo
            // 
            pictureBoxChocobo.Image = Properties.Resources.Chocobo;
            pictureBoxChocobo.Location = new Point(234, 314);
            pictureBoxChocobo.Margin = new Padding(4, 3, 4, 3);
            pictureBoxChocobo.Name = "pictureBoxChocobo";
            pictureBoxChocobo.Size = new Size(84, 96);
            pictureBoxChocobo.TabIndex = 18;
            pictureBoxChocobo.TabStop = false;
            // 
            // textBoxCid
            // 
            textBoxCid.Location = new Point(553, 285);
            textBoxCid.Margin = new Padding(4, 3, 4, 3);
            textBoxCid.MaxLength = 9;
            textBoxCid.Name = "textBoxCid";
            textBoxCid.Size = new Size(112, 23);
            textBoxCid.TabIndex = 9;
            textBoxCid.TextChanged += textBoxCid_TextChanged;
            // 
            // pictureBoxCid
            // 
            pictureBoxCid.Image = Properties.Resources.Cid;
            pictureBoxCid.Location = new Point(461, 212);
            pictureBoxCid.Margin = new Padding(4, 3, 4, 3);
            pictureBoxCid.Name = "pictureBoxCid";
            pictureBoxCid.Size = new Size(84, 96);
            pictureBoxCid.TabIndex = 16;
            pictureBoxCid.TabStop = false;
            // 
            // textBoxVincent
            // 
            textBoxVincent.Location = new Point(326, 285);
            textBoxVincent.Margin = new Padding(4, 3, 4, 3);
            textBoxVincent.MaxLength = 9;
            textBoxVincent.Name = "textBoxVincent";
            textBoxVincent.Size = new Size(114, 23);
            textBoxVincent.TabIndex = 8;
            textBoxVincent.TextChanged += textBoxVincent_TextChanged;
            // 
            // pictureBoxVincent
            // 
            pictureBoxVincent.Image = Properties.Resources.Vincent;
            pictureBoxVincent.Location = new Point(234, 212);
            pictureBoxVincent.Margin = new Padding(4, 3, 4, 3);
            pictureBoxVincent.Name = "pictureBoxVincent";
            pictureBoxVincent.Size = new Size(84, 96);
            pictureBoxVincent.TabIndex = 14;
            pictureBoxVincent.TabStop = false;
            // 
            // textBoxCaitSith
            // 
            textBoxCaitSith.Location = new Point(100, 285);
            textBoxCaitSith.Margin = new Padding(4, 3, 4, 3);
            textBoxCaitSith.MaxLength = 9;
            textBoxCaitSith.Name = "textBoxCaitSith";
            textBoxCaitSith.Size = new Size(113, 23);
            textBoxCaitSith.TabIndex = 6;
            textBoxCaitSith.TextChanged += textBoxCaitSith_TextChanged;
            // 
            // pictureBoxCaitSith
            // 
            pictureBoxCaitSith.Image = Properties.Resources.CaitSith;
            pictureBoxCaitSith.Location = new Point(8, 212);
            pictureBoxCaitSith.Margin = new Padding(4, 3, 4, 3);
            pictureBoxCaitSith.Name = "pictureBoxCaitSith";
            pictureBoxCaitSith.Size = new Size(84, 96);
            pictureBoxCaitSith.TabIndex = 12;
            pictureBoxCaitSith.TabStop = false;
            // 
            // textBoxYuffie
            // 
            textBoxYuffie.Location = new Point(553, 183);
            textBoxYuffie.Margin = new Padding(4, 3, 4, 3);
            textBoxYuffie.MaxLength = 9;
            textBoxYuffie.Name = "textBoxYuffie";
            textBoxYuffie.Size = new Size(112, 23);
            textBoxYuffie.TabIndex = 5;
            textBoxYuffie.TextChanged += textBoxYuffie_TextChanged;
            // 
            // pictureBoxYuffie
            // 
            pictureBoxYuffie.Image = Properties.Resources.Yuffie;
            pictureBoxYuffie.Location = new Point(461, 110);
            pictureBoxYuffie.Margin = new Padding(4, 3, 4, 3);
            pictureBoxYuffie.Name = "pictureBoxYuffie";
            pictureBoxYuffie.Size = new Size(84, 96);
            pictureBoxYuffie.TabIndex = 10;
            pictureBoxYuffie.TabStop = false;
            // 
            // textBoxRedXIII
            // 
            textBoxRedXIII.Location = new Point(326, 183);
            textBoxRedXIII.Margin = new Padding(4, 3, 4, 3);
            textBoxRedXIII.MaxLength = 9;
            textBoxRedXIII.Name = "textBoxRedXIII";
            textBoxRedXIII.Size = new Size(114, 23);
            textBoxRedXIII.TabIndex = 4;
            textBoxRedXIII.TextChanged += textBoxRedXIII_TextChanged;
            // 
            // pictureBoxRedXIII
            // 
            pictureBoxRedXIII.Image = Properties.Resources.RedXIII;
            pictureBoxRedXIII.Location = new Point(234, 110);
            pictureBoxRedXIII.Margin = new Padding(4, 3, 4, 3);
            pictureBoxRedXIII.Name = "pictureBoxRedXIII";
            pictureBoxRedXIII.Size = new Size(84, 96);
            pictureBoxRedXIII.TabIndex = 8;
            pictureBoxRedXIII.TabStop = false;
            // 
            // textBoxAeris
            // 
            textBoxAeris.Location = new Point(100, 183);
            textBoxAeris.Margin = new Padding(4, 3, 4, 3);
            textBoxAeris.MaxLength = 9;
            textBoxAeris.Name = "textBoxAeris";
            textBoxAeris.Size = new Size(113, 23);
            textBoxAeris.TabIndex = 3;
            textBoxAeris.TextChanged += textBoxAeris_TextChanged;
            // 
            // pictureBoxAeris
            // 
            pictureBoxAeris.Image = Properties.Resources.Aeris;
            pictureBoxAeris.Location = new Point(8, 110);
            pictureBoxAeris.Margin = new Padding(4, 3, 4, 3);
            pictureBoxAeris.Name = "pictureBoxAeris";
            pictureBoxAeris.Size = new Size(84, 96);
            pictureBoxAeris.TabIndex = 6;
            pictureBoxAeris.TabStop = false;
            // 
            // textBoxTifa
            // 
            textBoxTifa.Location = new Point(553, 81);
            textBoxTifa.Margin = new Padding(4, 3, 4, 3);
            textBoxTifa.MaxLength = 9;
            textBoxTifa.Name = "textBoxTifa";
            textBoxTifa.Size = new Size(112, 23);
            textBoxTifa.TabIndex = 2;
            textBoxTifa.TextChanged += textBoxTifa_TextChanged;
            // 
            // pictureBoxTifa
            // 
            pictureBoxTifa.Image = Properties.Resources.Tifa;
            pictureBoxTifa.Location = new Point(461, 8);
            pictureBoxTifa.Margin = new Padding(4, 3, 4, 3);
            pictureBoxTifa.Name = "pictureBoxTifa";
            pictureBoxTifa.Size = new Size(84, 96);
            pictureBoxTifa.TabIndex = 4;
            pictureBoxTifa.TabStop = false;
            // 
            // textBoxBarret
            // 
            textBoxBarret.Location = new Point(326, 81);
            textBoxBarret.Margin = new Padding(4, 3, 4, 3);
            textBoxBarret.MaxLength = 9;
            textBoxBarret.Name = "textBoxBarret";
            textBoxBarret.Size = new Size(114, 23);
            textBoxBarret.TabIndex = 1;
            textBoxBarret.TextChanged += textBoxBarret_TextChanged;
            // 
            // pictureBoxBarret
            // 
            pictureBoxBarret.Image = Properties.Resources.Barret;
            pictureBoxBarret.Location = new Point(234, 8);
            pictureBoxBarret.Margin = new Padding(4, 3, 4, 3);
            pictureBoxBarret.Name = "pictureBoxBarret";
            pictureBoxBarret.Size = new Size(84, 96);
            pictureBoxBarret.TabIndex = 2;
            pictureBoxBarret.TabStop = false;
            // 
            // textBoxCloud
            // 
            textBoxCloud.Location = new Point(100, 81);
            textBoxCloud.Margin = new Padding(4, 3, 4, 3);
            textBoxCloud.MaxLength = 9;
            textBoxCloud.Name = "textBoxCloud";
            textBoxCloud.Size = new Size(113, 23);
            textBoxCloud.TabIndex = 0;
            textBoxCloud.TextChanged += textBoxCloud_TextChanged;
            // 
            // pictureBoxCloud
            // 
            pictureBoxCloud.Image = Properties.Resources.Cloud;
            pictureBoxCloud.Location = new Point(8, 8);
            pictureBoxCloud.Margin = new Padding(4, 3, 4, 3);
            pictureBoxCloud.Name = "pictureBoxCloud";
            pictureBoxCloud.Size = new Size(84, 96);
            pictureBoxCloud.TabIndex = 0;
            pictureBoxCloud.TabStop = false;
            // 
            // tabPageShopData
            // 
            tabPageShopData.Controls.Add(groupBoxShopInventory);
            tabPageShopData.Controls.Add(numericMateriaPrice);
            tabPageShopData.Controls.Add(labelMateriaPrice);
            tabPageShopData.Controls.Add(labelMateriaPrices);
            tabPageShopData.Controls.Add(listBoxMateriaPrices);
            tabPageShopData.Controls.Add(numericMateriaAPPriceMultiplier);
            tabPageShopData.Controls.Add(labelMateriaAPPriceMultiplier);
            tabPageShopData.Controls.Add(numericItemPrice);
            tabPageShopData.Controls.Add(labelItemPrice);
            tabPageShopData.Controls.Add(labelItemPrices);
            tabPageShopData.Controls.Add(listBoxItemPrices);
            tabPageShopData.Location = new Point(4, 24);
            tabPageShopData.Name = "tabPageShopData";
            tabPageShopData.Size = new Size(776, 527);
            tabPageShopData.TabIndex = 2;
            tabPageShopData.Text = "Shop data";
            tabPageShopData.UseVisualStyleBackColor = true;
            // 
            // groupBoxShopInventory
            // 
            groupBoxShopInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxShopInventory.Controls.Add(comboBoxShopItem10);
            groupBoxShopInventory.Controls.Add(comboBoxShopItem9);
            groupBoxShopInventory.Controls.Add(comboBoxShopItem8);
            groupBoxShopInventory.Controls.Add(comboBoxShopItem7);
            groupBoxShopInventory.Controls.Add(comboBoxShopItem6);
            groupBoxShopInventory.Controls.Add(comboBoxShopItem5);
            groupBoxShopInventory.Controls.Add(comboBoxShopItem4);
            groupBoxShopInventory.Controls.Add(comboBoxShopItem3);
            groupBoxShopInventory.Controls.Add(comboBoxShopItem2);
            groupBoxShopInventory.Controls.Add(comboBoxShopItem1);
            groupBoxShopInventory.Controls.Add(labelShopItems);
            groupBoxShopInventory.Controls.Add(numericShopItemCount);
            groupBoxShopInventory.Controls.Add(labelShopItemCount);
            groupBoxShopInventory.Controls.Add(comboBoxShopType);
            groupBoxShopInventory.Controls.Add(labelShopType);
            groupBoxShopInventory.Controls.Add(comboBoxShopIndex);
            groupBoxShopInventory.Controls.Add(labelShopIndex);
            groupBoxShopInventory.Location = new Point(415, 5);
            groupBoxShopInventory.Name = "groupBoxShopInventory";
            groupBoxShopInventory.Size = new Size(352, 472);
            groupBoxShopInventory.TabIndex = 10;
            groupBoxShopInventory.TabStop = false;
            groupBoxShopInventory.Text = "Shop inventories";
            // 
            // comboBoxShopItem10
            // 
            comboBoxShopItem10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem10.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem10.FormattingEnabled = true;
            comboBoxShopItem10.Location = new Point(6, 443);
            comboBoxShopItem10.Name = "comboBoxShopItem10";
            comboBoxShopItem10.Size = new Size(340, 23);
            comboBoxShopItem10.TabIndex = 16;
            comboBoxShopItem10.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // comboBoxShopItem9
            // 
            comboBoxShopItem9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem9.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem9.FormattingEnabled = true;
            comboBoxShopItem9.Location = new Point(6, 414);
            comboBoxShopItem9.Name = "comboBoxShopItem9";
            comboBoxShopItem9.Size = new Size(340, 23);
            comboBoxShopItem9.TabIndex = 15;
            comboBoxShopItem9.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // comboBoxShopItem8
            // 
            comboBoxShopItem8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem8.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem8.FormattingEnabled = true;
            comboBoxShopItem8.Location = new Point(6, 385);
            comboBoxShopItem8.Name = "comboBoxShopItem8";
            comboBoxShopItem8.Size = new Size(340, 23);
            comboBoxShopItem8.TabIndex = 14;
            comboBoxShopItem8.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // comboBoxShopItem7
            // 
            comboBoxShopItem7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem7.FormattingEnabled = true;
            comboBoxShopItem7.Location = new Point(6, 356);
            comboBoxShopItem7.Name = "comboBoxShopItem7";
            comboBoxShopItem7.Size = new Size(340, 23);
            comboBoxShopItem7.TabIndex = 13;
            comboBoxShopItem7.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // comboBoxShopItem6
            // 
            comboBoxShopItem6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem6.FormattingEnabled = true;
            comboBoxShopItem6.Location = new Point(6, 327);
            comboBoxShopItem6.Name = "comboBoxShopItem6";
            comboBoxShopItem6.Size = new Size(340, 23);
            comboBoxShopItem6.TabIndex = 12;
            comboBoxShopItem6.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // comboBoxShopItem5
            // 
            comboBoxShopItem5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem5.FormattingEnabled = true;
            comboBoxShopItem5.Location = new Point(6, 298);
            comboBoxShopItem5.Name = "comboBoxShopItem5";
            comboBoxShopItem5.Size = new Size(340, 23);
            comboBoxShopItem5.TabIndex = 11;
            comboBoxShopItem5.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // comboBoxShopItem4
            // 
            comboBoxShopItem4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem4.FormattingEnabled = true;
            comboBoxShopItem4.Location = new Point(6, 269);
            comboBoxShopItem4.Name = "comboBoxShopItem4";
            comboBoxShopItem4.Size = new Size(340, 23);
            comboBoxShopItem4.TabIndex = 10;
            comboBoxShopItem4.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // comboBoxShopItem3
            // 
            comboBoxShopItem3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem3.FormattingEnabled = true;
            comboBoxShopItem3.Location = new Point(6, 240);
            comboBoxShopItem3.Name = "comboBoxShopItem3";
            comboBoxShopItem3.Size = new Size(340, 23);
            comboBoxShopItem3.TabIndex = 9;
            comboBoxShopItem3.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // comboBoxShopItem2
            // 
            comboBoxShopItem2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem2.FormattingEnabled = true;
            comboBoxShopItem2.Location = new Point(6, 211);
            comboBoxShopItem2.Name = "comboBoxShopItem2";
            comboBoxShopItem2.Size = new Size(340, 23);
            comboBoxShopItem2.TabIndex = 8;
            comboBoxShopItem2.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // comboBoxShopItem1
            // 
            comboBoxShopItem1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem1.FormattingEnabled = true;
            comboBoxShopItem1.Location = new Point(6, 182);
            comboBoxShopItem1.Name = "comboBoxShopItem1";
            comboBoxShopItem1.Size = new Size(340, 23);
            comboBoxShopItem1.TabIndex = 7;
            comboBoxShopItem1.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // labelShopItems
            // 
            labelShopItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelShopItems.AutoSize = true;
            labelShopItems.Location = new Point(6, 164);
            labelShopItems.Name = "labelShopItems";
            labelShopItems.Size = new Size(39, 15);
            labelShopItems.TabIndex = 6;
            labelShopItems.Text = "Items:";
            // 
            // numericShopItemCount
            // 
            numericShopItemCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericShopItemCount.Location = new Point(6, 127);
            numericShopItemCount.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericShopItemCount.Name = "numericShopItemCount";
            numericShopItemCount.Size = new Size(340, 23);
            numericShopItemCount.TabIndex = 5;
            numericShopItemCount.ValueChanged += numericShopItemCount_ValueChanged;
            // 
            // labelShopItemCount
            // 
            labelShopItemCount.AutoSize = true;
            labelShopItemCount.Location = new Point(6, 108);
            labelShopItemCount.Name = "labelShopItemCount";
            labelShopItemCount.Size = new Size(68, 15);
            labelShopItemCount.TabIndex = 4;
            labelShopItemCount.Text = "Item count:";
            // 
            // comboBoxShopType
            // 
            comboBoxShopType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopType.FormattingEnabled = true;
            comboBoxShopType.Location = new Point(6, 82);
            comboBoxShopType.Name = "comboBoxShopType";
            comboBoxShopType.Size = new Size(340, 23);
            comboBoxShopType.TabIndex = 3;
            // 
            // labelShopType
            // 
            labelShopType.AutoSize = true;
            labelShopType.Location = new Point(6, 63);
            labelShopType.Name = "labelShopType";
            labelShopType.Size = new Size(70, 15);
            labelShopType.TabIndex = 2;
            labelShopType.Text = "Shop name:";
            // 
            // comboBoxShopIndex
            // 
            comboBoxShopIndex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopIndex.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopIndex.FormattingEnabled = true;
            comboBoxShopIndex.Location = new Point(6, 37);
            comboBoxShopIndex.Name = "comboBoxShopIndex";
            comboBoxShopIndex.Size = new Size(340, 23);
            comboBoxShopIndex.TabIndex = 1;
            comboBoxShopIndex.SelectedIndexChanged += comboBoxShopIndex_SelectedIndexChanged;
            // 
            // labelShopIndex
            // 
            labelShopIndex.AutoSize = true;
            labelShopIndex.Location = new Point(6, 19);
            labelShopIndex.Name = "labelShopIndex";
            labelShopIndex.Size = new Size(69, 15);
            labelShopIndex.TabIndex = 0;
            labelShopIndex.Text = "Shop index:";
            // 
            // numericMateriaPrice
            // 
            numericMateriaPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numericMateriaPrice.Enabled = false;
            numericMateriaPrice.Location = new Point(251, 492);
            numericMateriaPrice.Name = "numericMateriaPrice";
            numericMateriaPrice.Size = new Size(158, 23);
            numericMateriaPrice.TabIndex = 9;
            numericMateriaPrice.ValueChanged += numericMateriaPrice_ValueChanged;
            // 
            // labelMateriaPrice
            // 
            labelMateriaPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelMateriaPrice.AutoSize = true;
            labelMateriaPrice.Location = new Point(209, 494);
            labelMateriaPrice.Name = "labelMateriaPrice";
            labelMateriaPrice.Size = new Size(36, 15);
            labelMateriaPrice.TabIndex = 8;
            labelMateriaPrice.Text = "Price:";
            // 
            // labelMateriaPrices
            // 
            labelMateriaPrices.AutoSize = true;
            labelMateriaPrices.Location = new Point(209, 5);
            labelMateriaPrices.Name = "labelMateriaPrices";
            labelMateriaPrices.Size = new Size(84, 15);
            labelMateriaPrices.TabIndex = 7;
            labelMateriaPrices.Text = "Materia prices:";
            // 
            // listBoxMateriaPrices
            // 
            listBoxMateriaPrices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxMateriaPrices.FormattingEnabled = true;
            listBoxMateriaPrices.Location = new Point(209, 23);
            listBoxMateriaPrices.Name = "listBoxMateriaPrices";
            listBoxMateriaPrices.Size = new Size(200, 454);
            listBoxMateriaPrices.TabIndex = 6;
            listBoxMateriaPrices.SelectedIndexChanged += listBoxMateriaPrices_SelectedIndexChanged;
            // 
            // numericMateriaAPPriceMultiplier
            // 
            numericMateriaAPPriceMultiplier.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericMateriaAPPriceMultiplier.Location = new Point(647, 492);
            numericMateriaAPPriceMultiplier.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericMateriaAPPriceMultiplier.Name = "numericMateriaAPPriceMultiplier";
            numericMateriaAPPriceMultiplier.Size = new Size(120, 23);
            numericMateriaAPPriceMultiplier.TabIndex = 5;
            numericMateriaAPPriceMultiplier.ValueChanged += numericMateriaAPPriceMultiplier_ValueChanged;
            // 
            // labelMateriaAPPriceMultiplier
            // 
            labelMateriaAPPriceMultiplier.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelMateriaAPPriceMultiplier.AutoSize = true;
            labelMateriaAPPriceMultiplier.Location = new Point(490, 494);
            labelMateriaAPPriceMultiplier.Name = "labelMateriaAPPriceMultiplier";
            labelMateriaAPPriceMultiplier.Size = new Size(151, 15);
            labelMateriaAPPriceMultiplier.TabIndex = 4;
            labelMateriaAPPriceMultiplier.Text = "Materia AP price multiplier:";
            // 
            // numericItemPrice
            // 
            numericItemPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numericItemPrice.Enabled = false;
            numericItemPrice.Location = new Point(45, 492);
            numericItemPrice.Name = "numericItemPrice";
            numericItemPrice.Size = new Size(158, 23);
            numericItemPrice.TabIndex = 3;
            numericItemPrice.ValueChanged += numericItemPrice_ValueChanged;
            // 
            // labelItemPrice
            // 
            labelItemPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelItemPrice.AutoSize = true;
            labelItemPrice.Location = new Point(3, 494);
            labelItemPrice.Name = "labelItemPrice";
            labelItemPrice.Size = new Size(36, 15);
            labelItemPrice.TabIndex = 2;
            labelItemPrice.Text = "Price:";
            // 
            // labelItemPrices
            // 
            labelItemPrices.AutoSize = true;
            labelItemPrices.Location = new Point(3, 5);
            labelItemPrices.Name = "labelItemPrices";
            labelItemPrices.Size = new Size(68, 15);
            labelItemPrices.TabIndex = 1;
            labelItemPrices.Text = "Item prices:";
            // 
            // listBoxItemPrices
            // 
            listBoxItemPrices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxItemPrices.FormattingEnabled = true;
            listBoxItemPrices.Location = new Point(3, 23);
            listBoxItemPrices.Name = "listBoxItemPrices";
            listBoxItemPrices.Size = new Size(200, 454);
            listBoxItemPrices.TabIndex = 0;
            listBoxItemPrices.SelectedIndexChanged += listBoxItemPrices_SelectedIndexChanged;
            // 
            // tabPageSortOrder
            // 
            tabPageSortOrder.Controls.Add(groupBoxMateriaPriority);
            tabPageSortOrder.Controls.Add(groupBoxSortItemName);
            tabPageSortOrder.Location = new Point(4, 24);
            tabPageSortOrder.Name = "tabPageSortOrder";
            tabPageSortOrder.Size = new Size(776, 527);
            tabPageSortOrder.TabIndex = 5;
            tabPageSortOrder.Text = "Sorting";
            tabPageSortOrder.UseVisualStyleBackColor = true;
            // 
            // groupBoxMateriaPriority
            // 
            groupBoxMateriaPriority.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxMateriaPriority.Controls.Add(buttonMateriaMoveDown);
            groupBoxMateriaPriority.Controls.Add(buttonMateriaMoveUp);
            groupBoxMateriaPriority.Controls.Add(listBoxMateriaPriority);
            groupBoxMateriaPriority.Location = new Point(297, 3);
            groupBoxMateriaPriority.Name = "groupBoxMateriaPriority";
            groupBoxMateriaPriority.Size = new Size(280, 521);
            groupBoxMateriaPriority.TabIndex = 2;
            groupBoxMateriaPriority.TabStop = false;
            groupBoxMateriaPriority.Text = "Materia priority";
            // 
            // buttonMateriaMoveDown
            // 
            buttonMateriaMoveDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonMateriaMoveDown.Enabled = false;
            buttonMateriaMoveDown.Location = new Point(208, 482);
            buttonMateriaMoveDown.Name = "buttonMateriaMoveDown";
            buttonMateriaMoveDown.Size = new Size(66, 23);
            buttonMateriaMoveDown.TabIndex = 5;
            buttonMateriaMoveDown.Text = "Down";
            buttonMateriaMoveDown.UseVisualStyleBackColor = true;
            buttonMateriaMoveDown.Click += buttonMateriaMoveDown_Click;
            // 
            // buttonMateriaMoveUp
            // 
            buttonMateriaMoveUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonMateriaMoveUp.Enabled = false;
            buttonMateriaMoveUp.Location = new Point(136, 482);
            buttonMateriaMoveUp.Name = "buttonMateriaMoveUp";
            buttonMateriaMoveUp.Size = new Size(66, 23);
            buttonMateriaMoveUp.TabIndex = 4;
            buttonMateriaMoveUp.Text = "Up";
            buttonMateriaMoveUp.UseVisualStyleBackColor = true;
            buttonMateriaMoveUp.Click += buttonMateriaMoveUp_Click;
            // 
            // listBoxMateriaPriority
            // 
            listBoxMateriaPriority.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxMateriaPriority.FormattingEnabled = true;
            listBoxMateriaPriority.Location = new Point(6, 22);
            listBoxMateriaPriority.Name = "listBoxMateriaPriority";
            listBoxMateriaPriority.Size = new Size(268, 454);
            listBoxMateriaPriority.TabIndex = 0;
            listBoxMateriaPriority.SelectedIndexChanged += listBoxMateriaPriority_SelectedIndexChanged;
            // 
            // groupBoxSortItemName
            // 
            groupBoxSortItemName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxSortItemName.Controls.Add(buttonItemsMoveDown);
            groupBoxSortItemName.Controls.Add(buttonItemsMoveUp);
            groupBoxSortItemName.Controls.Add(buttonItemsAutoSort);
            groupBoxSortItemName.Controls.Add(listBoxSortItemName);
            groupBoxSortItemName.Location = new Point(8, 3);
            groupBoxSortItemName.Name = "groupBoxSortItemName";
            groupBoxSortItemName.Size = new Size(280, 521);
            groupBoxSortItemName.TabIndex = 1;
            groupBoxSortItemName.TabStop = false;
            groupBoxSortItemName.Text = "Items sorted by name";
            // 
            // buttonItemsMoveDown
            // 
            buttonItemsMoveDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonItemsMoveDown.Enabled = false;
            buttonItemsMoveDown.Location = new Point(208, 482);
            buttonItemsMoveDown.Name = "buttonItemsMoveDown";
            buttonItemsMoveDown.Size = new Size(66, 23);
            buttonItemsMoveDown.TabIndex = 3;
            buttonItemsMoveDown.Text = "Down";
            buttonItemsMoveDown.UseVisualStyleBackColor = true;
            buttonItemsMoveDown.Click += buttonItemsMoveDown_Click;
            // 
            // buttonItemsMoveUp
            // 
            buttonItemsMoveUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonItemsMoveUp.Enabled = false;
            buttonItemsMoveUp.Location = new Point(136, 482);
            buttonItemsMoveUp.Name = "buttonItemsMoveUp";
            buttonItemsMoveUp.Size = new Size(66, 23);
            buttonItemsMoveUp.TabIndex = 2;
            buttonItemsMoveUp.Text = "Up";
            buttonItemsMoveUp.UseVisualStyleBackColor = true;
            buttonItemsMoveUp.Click += buttonItemsMoveUp_Click;
            // 
            // buttonItemsAutoSort
            // 
            buttonItemsAutoSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonItemsAutoSort.Location = new Point(6, 482);
            buttonItemsAutoSort.Name = "buttonItemsAutoSort";
            buttonItemsAutoSort.Size = new Size(124, 23);
            buttonItemsAutoSort.TabIndex = 1;
            buttonItemsAutoSort.Text = "Auto sort";
            buttonItemsAutoSort.UseVisualStyleBackColor = true;
            buttonItemsAutoSort.Click += buttonItemsAutoSort_Click;
            // 
            // listBoxSortItemName
            // 
            listBoxSortItemName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxSortItemName.FormattingEnabled = true;
            listBoxSortItemName.Location = new Point(6, 22);
            listBoxSortItemName.Name = "listBoxSortItemName";
            listBoxSortItemName.Size = new Size(268, 454);
            listBoxSortItemName.TabIndex = 0;
            listBoxSortItemName.SelectedIndexChanged += listBoxSortItemName_SelectedIndexChanged;
            // 
            // tabPageMenus
            // 
            tabPageMenus.Controls.Add(tabControlMenus);
            tabPageMenus.Location = new Point(4, 24);
            tabPageMenus.Name = "tabPageMenus";
            tabPageMenus.Size = new Size(776, 527);
            tabPageMenus.TabIndex = 6;
            tabPageMenus.Text = "Menus";
            tabPageMenus.UseVisualStyleBackColor = true;
            // 
            // tabControlMenus
            // 
            tabControlMenus.Controls.Add(tabPageMainMenu);
            tabControlMenus.Controls.Add(tabPageItemMagicMenu);
            tabControlMenus.Controls.Add(tabPageMateriaMenu);
            tabControlMenus.Controls.Add(tabPageEquipMenu);
            tabControlMenus.Controls.Add(tabPageStatusMenu);
            tabControlMenus.Controls.Add(tabPageLimitMenu);
            tabControlMenus.Controls.Add(tabPageConfigMenu);
            tabControlMenus.Controls.Add(tabPageSaveMenu);
            tabControlMenus.Dock = DockStyle.Fill;
            tabControlMenus.Location = new Point(0, 0);
            tabControlMenus.Name = "tabControlMenus";
            tabControlMenus.SelectedIndex = 0;
            tabControlMenus.Size = new Size(776, 527);
            tabControlMenus.TabIndex = 0;
            // 
            // tabPageMainMenu
            // 
            tabPageMainMenu.Controls.Add(groupBoxQuitMenu);
            tabPageMainMenu.Controls.Add(groupBoxMainMenu);
            tabPageMainMenu.Location = new Point(4, 24);
            tabPageMainMenu.Name = "tabPageMainMenu";
            tabPageMainMenu.Padding = new Padding(3);
            tabPageMainMenu.Size = new Size(768, 499);
            tabPageMainMenu.TabIndex = 0;
            tabPageMainMenu.Text = "Main menu";
            tabPageMainMenu.UseVisualStyleBackColor = true;
            // 
            // groupBoxQuitMenu
            // 
            groupBoxQuitMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxQuitMenu.Controls.Add(listBoxQuitTexts);
            groupBoxQuitMenu.Controls.Add(textBoxQuitText);
            groupBoxQuitMenu.Controls.Add(labelQuitText);
            groupBoxQuitMenu.Location = new Point(5, 376);
            groupBoxQuitMenu.Name = "groupBoxQuitMenu";
            groupBoxQuitMenu.Size = new Size(758, 117);
            groupBoxQuitMenu.TabIndex = 7;
            groupBoxQuitMenu.TabStop = false;
            groupBoxQuitMenu.Text = "Quit Menu";
            // 
            // listBoxQuitTexts
            // 
            listBoxQuitTexts.FormattingEnabled = true;
            listBoxQuitTexts.Location = new Point(6, 22);
            listBoxQuitTexts.Name = "listBoxQuitTexts";
            listBoxQuitTexts.Size = new Size(242, 79);
            listBoxQuitTexts.TabIndex = 3;
            listBoxQuitTexts.SelectedIndexChanged += listBoxQuitTexts_SelectedIndexChanged;
            // 
            // textBoxQuitText
            // 
            textBoxQuitText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxQuitText.Enabled = false;
            textBoxQuitText.Location = new Point(254, 40);
            textBoxQuitText.Name = "textBoxQuitText";
            textBoxQuitText.Size = new Size(496, 23);
            textBoxQuitText.TabIndex = 4;
            textBoxQuitText.TextChanged += textBoxQuitText_TextChanged;
            // 
            // labelQuitText
            // 
            labelQuitText.AutoSize = true;
            labelQuitText.Location = new Point(254, 22);
            labelQuitText.Name = "labelQuitText";
            labelQuitText.Size = new Size(31, 15);
            labelQuitText.TabIndex = 5;
            labelQuitText.Text = "Text:";
            // 
            // groupBoxMainMenu
            // 
            groupBoxMainMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMainMenu.Controls.Add(listBoxMainMenu);
            groupBoxMainMenu.Controls.Add(textBoxMainMenuText);
            groupBoxMainMenu.Controls.Add(labelMainMenuText);
            groupBoxMainMenu.Location = new Point(5, 3);
            groupBoxMainMenu.Name = "groupBoxMainMenu";
            groupBoxMainMenu.Size = new Size(758, 367);
            groupBoxMainMenu.TabIndex = 6;
            groupBoxMainMenu.TabStop = false;
            groupBoxMainMenu.Text = "Main Menu";
            // 
            // listBoxMainMenu
            // 
            listBoxMainMenu.FormattingEnabled = true;
            listBoxMainMenu.Location = new Point(6, 22);
            listBoxMainMenu.Name = "listBoxMainMenu";
            listBoxMainMenu.Size = new Size(242, 334);
            listBoxMainMenu.TabIndex = 0;
            listBoxMainMenu.SelectedIndexChanged += listBoxMainMenu_SelectedIndexChanged;
            // 
            // textBoxMainMenuText
            // 
            textBoxMainMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMainMenuText.Enabled = false;
            textBoxMainMenuText.Location = new Point(254, 40);
            textBoxMainMenuText.Name = "textBoxMainMenuText";
            textBoxMainMenuText.Size = new Size(498, 23);
            textBoxMainMenuText.TabIndex = 1;
            textBoxMainMenuText.TextChanged += textBoxMainMenuText_TextChanged;
            // 
            // labelMainMenuText
            // 
            labelMainMenuText.AutoSize = true;
            labelMainMenuText.Location = new Point(254, 22);
            labelMainMenuText.Name = "labelMainMenuText";
            labelMainMenuText.Size = new Size(31, 15);
            labelMainMenuText.TabIndex = 2;
            labelMainMenuText.Text = "Text:";
            // 
            // tabPageItemMagicMenu
            // 
            tabPageItemMagicMenu.Controls.Add(groupBoxMagicMenu);
            tabPageItemMagicMenu.Controls.Add(groupBoxItemMenu);
            tabPageItemMagicMenu.Location = new Point(4, 24);
            tabPageItemMagicMenu.Name = "tabPageItemMagicMenu";
            tabPageItemMagicMenu.Size = new Size(768, 499);
            tabPageItemMagicMenu.TabIndex = 9;
            tabPageItemMagicMenu.Text = "Item/Magic menu";
            tabPageItemMagicMenu.UseVisualStyleBackColor = true;
            // 
            // groupBoxMagicMenu
            // 
            groupBoxMagicMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMagicMenu.Controls.Add(listBoxMagicMenu);
            groupBoxMagicMenu.Controls.Add(labelMagicMenuText);
            groupBoxMagicMenu.Controls.Add(textBoxMagicMenuText);
            groupBoxMagicMenu.Location = new Point(5, 210);
            groupBoxMagicMenu.Name = "groupBoxMagicMenu";
            groupBoxMagicMenu.Size = new Size(756, 286);
            groupBoxMagicMenu.TabIndex = 10;
            groupBoxMagicMenu.TabStop = false;
            groupBoxMagicMenu.Text = "Magic menu";
            // 
            // listBoxMagicMenu
            // 
            listBoxMagicMenu.FormattingEnabled = true;
            listBoxMagicMenu.Location = new Point(6, 22);
            listBoxMagicMenu.Name = "listBoxMagicMenu";
            listBoxMagicMenu.Size = new Size(242, 214);
            listBoxMagicMenu.TabIndex = 6;
            listBoxMagicMenu.SelectedIndexChanged += listBoxMagicMenu_SelectedIndexChanged;
            // 
            // labelMagicMenuText
            // 
            labelMagicMenuText.AutoSize = true;
            labelMagicMenuText.Location = new Point(254, 22);
            labelMagicMenuText.Name = "labelMagicMenuText";
            labelMagicMenuText.Size = new Size(31, 15);
            labelMagicMenuText.TabIndex = 8;
            labelMagicMenuText.Text = "Text:";
            // 
            // textBoxMagicMenuText
            // 
            textBoxMagicMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMagicMenuText.Enabled = false;
            textBoxMagicMenuText.Location = new Point(254, 40);
            textBoxMagicMenuText.Name = "textBoxMagicMenuText";
            textBoxMagicMenuText.Size = new Size(496, 23);
            textBoxMagicMenuText.TabIndex = 7;
            textBoxMagicMenuText.TextChanged += textBoxMagicMenuText_TextChanged;
            // 
            // groupBoxItemMenu
            // 
            groupBoxItemMenu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxItemMenu.Controls.Add(listBoxItemMenu);
            groupBoxItemMenu.Controls.Add(labelItemMenuText);
            groupBoxItemMenu.Controls.Add(textBoxItemMenuText);
            groupBoxItemMenu.Location = new Point(5, 3);
            groupBoxItemMenu.Name = "groupBoxItemMenu";
            groupBoxItemMenu.Size = new Size(756, 201);
            groupBoxItemMenu.TabIndex = 9;
            groupBoxItemMenu.TabStop = false;
            groupBoxItemMenu.Text = "Item menu";
            // 
            // listBoxItemMenu
            // 
            listBoxItemMenu.FormattingEnabled = true;
            listBoxItemMenu.Location = new Point(6, 22);
            listBoxItemMenu.Name = "listBoxItemMenu";
            listBoxItemMenu.Size = new Size(242, 169);
            listBoxItemMenu.TabIndex = 6;
            listBoxItemMenu.SelectedIndexChanged += listBoxItemMenu_SelectedIndexChanged;
            // 
            // labelItemMenuText
            // 
            labelItemMenuText.AutoSize = true;
            labelItemMenuText.Location = new Point(254, 19);
            labelItemMenuText.Name = "labelItemMenuText";
            labelItemMenuText.Size = new Size(31, 15);
            labelItemMenuText.TabIndex = 8;
            labelItemMenuText.Text = "Text:";
            // 
            // textBoxItemMenuText
            // 
            textBoxItemMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxItemMenuText.Enabled = false;
            textBoxItemMenuText.Location = new Point(254, 40);
            textBoxItemMenuText.Name = "textBoxItemMenuText";
            textBoxItemMenuText.Size = new Size(496, 23);
            textBoxItemMenuText.TabIndex = 7;
            textBoxItemMenuText.TextChanged += textBoxItemMenuText_TextChanged;
            // 
            // tabPageMateriaMenu
            // 
            tabPageMateriaMenu.Controls.Add(groupBoxUnequipText);
            tabPageMateriaMenu.Controls.Add(groupBoxMateriaText);
            tabPageMateriaMenu.Location = new Point(4, 24);
            tabPageMateriaMenu.Name = "tabPageMateriaMenu";
            tabPageMateriaMenu.Size = new Size(768, 499);
            tabPageMateriaMenu.TabIndex = 6;
            tabPageMateriaMenu.Text = "Materia menu";
            tabPageMateriaMenu.UseVisualStyleBackColor = true;
            // 
            // groupBoxUnequipText
            // 
            groupBoxUnequipText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxUnequipText.Controls.Add(listBoxUnequipText);
            groupBoxUnequipText.Controls.Add(labelUnequipText);
            groupBoxUnequipText.Controls.Add(textBoxUnequipText);
            groupBoxUnequipText.Location = new Point(4, 393);
            groupBoxUnequipText.Name = "groupBoxUnequipText";
            groupBoxUnequipText.Size = new Size(756, 103);
            groupBoxUnequipText.TabIndex = 7;
            groupBoxUnequipText.TabStop = false;
            groupBoxUnequipText.Text = "Unequip text";
            // 
            // listBoxUnequipText
            // 
            listBoxUnequipText.FormattingEnabled = true;
            listBoxUnequipText.Location = new Point(6, 22);
            listBoxUnequipText.Name = "listBoxUnequipText";
            listBoxUnequipText.Size = new Size(245, 64);
            listBoxUnequipText.TabIndex = 6;
            listBoxUnequipText.SelectedIndexChanged += listBoxUnequipText_SelectedIndexChanged;
            // 
            // labelUnequipText
            // 
            labelUnequipText.AutoSize = true;
            labelUnequipText.Location = new Point(257, 22);
            labelUnequipText.Name = "labelUnequipText";
            labelUnequipText.Size = new Size(31, 15);
            labelUnequipText.TabIndex = 8;
            labelUnequipText.Text = "Text:";
            // 
            // textBoxUnequipText
            // 
            textBoxUnequipText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxUnequipText.Enabled = false;
            textBoxUnequipText.Location = new Point(257, 40);
            textBoxUnequipText.Name = "textBoxUnequipText";
            textBoxUnequipText.Size = new Size(493, 23);
            textBoxUnequipText.TabIndex = 7;
            textBoxUnequipText.TextChanged += textBoxUnequipText_TextChanged;
            // 
            // groupBoxMateriaText
            // 
            groupBoxMateriaText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMateriaText.Controls.Add(listBoxMateriaMenu);
            groupBoxMateriaText.Controls.Add(labelMateriaMenuText);
            groupBoxMateriaText.Controls.Add(textBoxMateriaMenuText);
            groupBoxMateriaText.Location = new Point(4, 3);
            groupBoxMateriaText.Name = "groupBoxMateriaText";
            groupBoxMateriaText.Size = new Size(756, 384);
            groupBoxMateriaText.TabIndex = 6;
            groupBoxMateriaText.TabStop = false;
            groupBoxMateriaText.Text = "Main text";
            // 
            // listBoxMateriaMenu
            // 
            listBoxMateriaMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxMateriaMenu.FormattingEnabled = true;
            listBoxMateriaMenu.Location = new Point(6, 22);
            listBoxMateriaMenu.Name = "listBoxMateriaMenu";
            listBoxMateriaMenu.Size = new Size(245, 349);
            listBoxMateriaMenu.TabIndex = 3;
            listBoxMateriaMenu.SelectedIndexChanged += listBoxMateriaMenu_SelectedIndexChanged;
            // 
            // labelMateriaMenuText
            // 
            labelMateriaMenuText.AutoSize = true;
            labelMateriaMenuText.Location = new Point(257, 22);
            labelMateriaMenuText.Name = "labelMateriaMenuText";
            labelMateriaMenuText.Size = new Size(31, 15);
            labelMateriaMenuText.TabIndex = 5;
            labelMateriaMenuText.Text = "Text:";
            // 
            // textBoxMateriaMenuText
            // 
            textBoxMateriaMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMateriaMenuText.Enabled = false;
            textBoxMateriaMenuText.Location = new Point(257, 40);
            textBoxMateriaMenuText.Name = "textBoxMateriaMenuText";
            textBoxMateriaMenuText.Size = new Size(493, 23);
            textBoxMateriaMenuText.TabIndex = 4;
            textBoxMateriaMenuText.TextChanged += textBoxMateriaMenuText_TextChanged;
            // 
            // tabPageEquipMenu
            // 
            tabPageEquipMenu.Controls.Add(labelEquipMenu);
            tabPageEquipMenu.Controls.Add(textBoxEquipMenuText);
            tabPageEquipMenu.Controls.Add(listBoxEquipMenu);
            tabPageEquipMenu.Location = new Point(4, 24);
            tabPageEquipMenu.Name = "tabPageEquipMenu";
            tabPageEquipMenu.Size = new Size(768, 499);
            tabPageEquipMenu.TabIndex = 7;
            tabPageEquipMenu.Text = "Equip menu";
            tabPageEquipMenu.UseVisualStyleBackColor = true;
            // 
            // labelEquipMenu
            // 
            labelEquipMenu.AutoSize = true;
            labelEquipMenu.Location = new Point(261, 6);
            labelEquipMenu.Name = "labelEquipMenu";
            labelEquipMenu.Size = new Size(31, 15);
            labelEquipMenu.TabIndex = 8;
            labelEquipMenu.Text = "Text:";
            // 
            // textBoxEquipMenuText
            // 
            textBoxEquipMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxEquipMenuText.Enabled = false;
            textBoxEquipMenuText.Location = new Point(261, 24);
            textBoxEquipMenuText.Name = "textBoxEquipMenuText";
            textBoxEquipMenuText.Size = new Size(501, 23);
            textBoxEquipMenuText.TabIndex = 7;
            textBoxEquipMenuText.TextChanged += textBoxEquipMenu_TextChanged;
            // 
            // listBoxEquipMenu
            // 
            listBoxEquipMenu.FormattingEnabled = true;
            listBoxEquipMenu.Location = new Point(6, 6);
            listBoxEquipMenu.Name = "listBoxEquipMenu";
            listBoxEquipMenu.Size = new Size(249, 349);
            listBoxEquipMenu.TabIndex = 6;
            listBoxEquipMenu.SelectedIndexChanged += listBoxEquipMenu_SelectedIndexChanged;
            // 
            // tabPageStatusMenu
            // 
            tabPageStatusMenu.Controls.Add(groupBoxStatusMenu);
            tabPageStatusMenu.Controls.Add(groupBoxElements);
            tabPageStatusMenu.Location = new Point(4, 24);
            tabPageStatusMenu.Name = "tabPageStatusMenu";
            tabPageStatusMenu.Size = new Size(768, 499);
            tabPageStatusMenu.TabIndex = 8;
            tabPageStatusMenu.Text = "Status menu";
            tabPageStatusMenu.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatusMenu
            // 
            groupBoxStatusMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxStatusMenu.Controls.Add(labelStatusText);
            groupBoxStatusMenu.Controls.Add(textBoxStatusMenuText);
            groupBoxStatusMenu.Controls.Add(listBoxStatusMenuText);
            groupBoxStatusMenu.Location = new Point(5, 3);
            groupBoxStatusMenu.Name = "groupBoxStatusMenu";
            groupBoxStatusMenu.Size = new Size(758, 316);
            groupBoxStatusMenu.TabIndex = 7;
            groupBoxStatusMenu.TabStop = false;
            groupBoxStatusMenu.Text = "Menu text";
            // 
            // labelStatusText
            // 
            labelStatusText.AutoSize = true;
            labelStatusText.Location = new Point(254, 22);
            labelStatusText.Name = "labelStatusText";
            labelStatusText.Size = new Size(31, 15);
            labelStatusText.TabIndex = 4;
            labelStatusText.Text = "Text:";
            // 
            // textBoxStatusMenuText
            // 
            textBoxStatusMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxStatusMenuText.Enabled = false;
            textBoxStatusMenuText.Location = new Point(254, 40);
            textBoxStatusMenuText.Name = "textBoxStatusMenuText";
            textBoxStatusMenuText.Size = new Size(498, 23);
            textBoxStatusMenuText.TabIndex = 3;
            textBoxStatusMenuText.TextChanged += textBoxStatusMenuText_TextChanged;
            // 
            // listBoxStatusMenuText
            // 
            listBoxStatusMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxStatusMenuText.FormattingEnabled = true;
            listBoxStatusMenuText.Location = new Point(6, 22);
            listBoxStatusMenuText.Name = "listBoxStatusMenuText";
            listBoxStatusMenuText.Size = new Size(242, 274);
            listBoxStatusMenuText.TabIndex = 0;
            listBoxStatusMenuText.SelectedIndexChanged += listBoxStatusMenuText_SelectedIndexChanged;
            // 
            // groupBoxElements
            // 
            groupBoxElements.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxElements.Controls.Add(labelElements);
            groupBoxElements.Controls.Add(textBoxElements);
            groupBoxElements.Controls.Add(listBoxElements);
            groupBoxElements.Location = new Point(5, 325);
            groupBoxElements.Name = "groupBoxElements";
            groupBoxElements.Size = new Size(758, 171);
            groupBoxElements.TabIndex = 6;
            groupBoxElements.TabStop = false;
            groupBoxElements.Text = "Elements";
            // 
            // labelElements
            // 
            labelElements.AutoSize = true;
            labelElements.Location = new Point(254, 22);
            labelElements.Name = "labelElements";
            labelElements.Size = new Size(31, 15);
            labelElements.TabIndex = 4;
            labelElements.Text = "Text:";
            // 
            // textBoxElements
            // 
            textBoxElements.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxElements.Enabled = false;
            textBoxElements.Location = new Point(254, 40);
            textBoxElements.Name = "textBoxElements";
            textBoxElements.Size = new Size(498, 23);
            textBoxElements.TabIndex = 3;
            textBoxElements.TextChanged += textBoxElements_TextChanged;
            // 
            // listBoxElements
            // 
            listBoxElements.FormattingEnabled = true;
            listBoxElements.Location = new Point(6, 22);
            listBoxElements.Name = "listBoxElements";
            listBoxElements.Size = new Size(242, 139);
            listBoxElements.TabIndex = 0;
            listBoxElements.SelectedIndexChanged += listBoxElements_SelectedIndexChanged;
            // 
            // tabPageLimitMenu
            // 
            tabPageLimitMenu.Controls.Add(labelLimitMenuText);
            tabPageLimitMenu.Controls.Add(textBoxLimitMenuText);
            tabPageLimitMenu.Controls.Add(listBoxLimitMenu);
            tabPageLimitMenu.Location = new Point(4, 24);
            tabPageLimitMenu.Name = "tabPageLimitMenu";
            tabPageLimitMenu.Size = new Size(768, 499);
            tabPageLimitMenu.TabIndex = 10;
            tabPageLimitMenu.Text = "Limit menu";
            tabPageLimitMenu.UseVisualStyleBackColor = true;
            // 
            // labelLimitMenuText
            // 
            labelLimitMenuText.AutoSize = true;
            labelLimitMenuText.Location = new Point(261, 6);
            labelLimitMenuText.Name = "labelLimitMenuText";
            labelLimitMenuText.Size = new Size(31, 15);
            labelLimitMenuText.TabIndex = 7;
            labelLimitMenuText.Text = "Text:";
            // 
            // textBoxLimitMenuText
            // 
            textBoxLimitMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLimitMenuText.Enabled = false;
            textBoxLimitMenuText.Location = new Point(261, 24);
            textBoxLimitMenuText.Name = "textBoxLimitMenuText";
            textBoxLimitMenuText.Size = new Size(501, 23);
            textBoxLimitMenuText.TabIndex = 6;
            textBoxLimitMenuText.TextChanged += textBoxLimitMenuText_TextChanged;
            // 
            // listBoxLimitMenu
            // 
            listBoxLimitMenu.FormattingEnabled = true;
            listBoxLimitMenu.Location = new Point(6, 6);
            listBoxLimitMenu.Name = "listBoxLimitMenu";
            listBoxLimitMenu.Size = new Size(249, 214);
            listBoxLimitMenu.TabIndex = 5;
            listBoxLimitMenu.SelectedIndexChanged += listBoxLimitMenu_SelectedIndexChanged;
            // 
            // tabPageConfigMenu
            // 
            tabPageConfigMenu.Controls.Add(labelConfigMenuText);
            tabPageConfigMenu.Controls.Add(textBoxConfigMenuText);
            tabPageConfigMenu.Controls.Add(listBoxConfigMenu);
            tabPageConfigMenu.Location = new Point(4, 24);
            tabPageConfigMenu.Name = "tabPageConfigMenu";
            tabPageConfigMenu.Padding = new Padding(3);
            tabPageConfigMenu.Size = new Size(768, 499);
            tabPageConfigMenu.TabIndex = 1;
            tabPageConfigMenu.Text = "Config menu";
            tabPageConfigMenu.UseVisualStyleBackColor = true;
            // 
            // labelConfigMenuText
            // 
            labelConfigMenuText.AutoSize = true;
            labelConfigMenuText.Location = new Point(261, 6);
            labelConfigMenuText.Name = "labelConfigMenuText";
            labelConfigMenuText.Size = new Size(31, 15);
            labelConfigMenuText.TabIndex = 4;
            labelConfigMenuText.Text = "Text:";
            // 
            // textBoxConfigMenuText
            // 
            textBoxConfigMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxConfigMenuText.Enabled = false;
            textBoxConfigMenuText.Location = new Point(261, 24);
            textBoxConfigMenuText.Name = "textBoxConfigMenuText";
            textBoxConfigMenuText.Size = new Size(501, 23);
            textBoxConfigMenuText.TabIndex = 3;
            textBoxConfigMenuText.TextChanged += textBoxConfigMenuText_TextChanged;
            // 
            // listBoxConfigMenu
            // 
            listBoxConfigMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxConfigMenu.FormattingEnabled = true;
            listBoxConfigMenu.Location = new Point(6, 6);
            listBoxConfigMenu.Name = "listBoxConfigMenu";
            listBoxConfigMenu.Size = new Size(249, 484);
            listBoxConfigMenu.TabIndex = 1;
            listBoxConfigMenu.SelectedIndexChanged += listBoxConfigMenu_SelectedIndexChanged;
            // 
            // tabPageSaveMenu
            // 
            tabPageSaveMenu.Controls.Add(labelSaveMenuText);
            tabPageSaveMenu.Controls.Add(textBoxSaveMenuText);
            tabPageSaveMenu.Controls.Add(listBoxSaveMenu);
            tabPageSaveMenu.Location = new Point(4, 24);
            tabPageSaveMenu.Name = "tabPageSaveMenu";
            tabPageSaveMenu.Size = new Size(768, 499);
            tabPageSaveMenu.TabIndex = 11;
            tabPageSaveMenu.Text = "Save menu";
            tabPageSaveMenu.UseVisualStyleBackColor = true;
            // 
            // labelSaveMenuText
            // 
            labelSaveMenuText.AutoSize = true;
            labelSaveMenuText.Location = new Point(261, 6);
            labelSaveMenuText.Name = "labelSaveMenuText";
            labelSaveMenuText.Size = new Size(31, 15);
            labelSaveMenuText.TabIndex = 7;
            labelSaveMenuText.Text = "Text:";
            // 
            // textBoxSaveMenuText
            // 
            textBoxSaveMenuText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSaveMenuText.Enabled = false;
            textBoxSaveMenuText.Location = new Point(261, 24);
            textBoxSaveMenuText.Name = "textBoxSaveMenuText";
            textBoxSaveMenuText.Size = new Size(501, 23);
            textBoxSaveMenuText.TabIndex = 6;
            textBoxSaveMenuText.TextChanged += textBoxSaveMenuText_TextChanged;
            // 
            // listBoxSaveMenu
            // 
            listBoxSaveMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxSaveMenu.FormattingEnabled = true;
            listBoxSaveMenu.Location = new Point(6, 6);
            listBoxSaveMenu.Name = "listBoxSaveMenu";
            listBoxSaveMenu.Size = new Size(249, 484);
            listBoxSaveMenu.TabIndex = 5;
            listBoxSaveMenu.SelectedIndexChanged += listBoxSaveMenu_SelectedIndexChanged;
            // 
            // tabPageOtherText
            // 
            tabPageOtherText.Controls.Add(tabControlOtherText);
            tabPageOtherText.Location = new Point(4, 24);
            tabPageOtherText.Name = "tabPageOtherText";
            tabPageOtherText.Size = new Size(776, 527);
            tabPageOtherText.TabIndex = 4;
            tabPageOtherText.Text = "Other text";
            tabPageOtherText.UseVisualStyleBackColor = true;
            // 
            // tabControlOtherText
            // 
            tabControlOtherText.Controls.Add(tabPageStatusEffects);
            tabControlOtherText.Controls.Add(tabPageL4Limits);
            tabControlOtherText.Controls.Add(tabPageBattleArena);
            tabControlOtherText.Controls.Add(tabPageShopText);
            tabControlOtherText.Controls.Add(tabPageChocoboRacing);
            tabControlOtherText.Dock = DockStyle.Fill;
            tabControlOtherText.Location = new Point(0, 0);
            tabControlOtherText.Name = "tabControlOtherText";
            tabControlOtherText.SelectedIndex = 0;
            tabControlOtherText.Size = new Size(776, 527);
            tabControlOtherText.TabIndex = 0;
            // 
            // tabPageStatusEffects
            // 
            tabPageStatusEffects.Controls.Add(labelStatusEffectMenu);
            tabPageStatusEffects.Controls.Add(textBoxStatusEffectMenu);
            tabPageStatusEffects.Controls.Add(labelStatusEffectTextBattle);
            tabPageStatusEffects.Controls.Add(textBoxStatusEffectTextBattle);
            tabPageStatusEffects.Controls.Add(listBoxStatusEffects);
            tabPageStatusEffects.Location = new Point(4, 24);
            tabPageStatusEffects.Name = "tabPageStatusEffects";
            tabPageStatusEffects.Size = new Size(768, 499);
            tabPageStatusEffects.TabIndex = 2;
            tabPageStatusEffects.Text = "Status effects";
            tabPageStatusEffects.UseVisualStyleBackColor = true;
            // 
            // labelStatusEffectMenu
            // 
            labelStatusEffectMenu.AutoSize = true;
            labelStatusEffectMenu.Location = new Point(261, 6);
            labelStatusEffectMenu.Name = "labelStatusEffectMenu";
            labelStatusEffectMenu.Size = new Size(99, 15);
            labelStatusEffectMenu.TabIndex = 6;
            labelStatusEffectMenu.Text = "Status menu text:";
            // 
            // textBoxStatusEffectMenu
            // 
            textBoxStatusEffectMenu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxStatusEffectMenu.Enabled = false;
            textBoxStatusEffectMenu.Location = new Point(261, 24);
            textBoxStatusEffectMenu.Name = "textBoxStatusEffectMenu";
            textBoxStatusEffectMenu.Size = new Size(501, 23);
            textBoxStatusEffectMenu.TabIndex = 5;
            textBoxStatusEffectMenu.TextChanged += textBoxStatusEffectMenu_TextChanged;
            // 
            // labelStatusEffectTextBattle
            // 
            labelStatusEffectTextBattle.AutoSize = true;
            labelStatusEffectTextBattle.Location = new Point(261, 50);
            labelStatusEffectTextBattle.Name = "labelStatusEffectTextBattle";
            labelStatusEffectTextBattle.Size = new Size(78, 15);
            labelStatusEffectTextBattle.TabIndex = 4;
            labelStatusEffectTextBattle.Text = "In-battle text:";
            // 
            // textBoxStatusEffectTextBattle
            // 
            textBoxStatusEffectTextBattle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxStatusEffectTextBattle.Enabled = false;
            textBoxStatusEffectTextBattle.Location = new Point(261, 68);
            textBoxStatusEffectTextBattle.Name = "textBoxStatusEffectTextBattle";
            textBoxStatusEffectTextBattle.Size = new Size(501, 23);
            textBoxStatusEffectTextBattle.TabIndex = 3;
            textBoxStatusEffectTextBattle.TextChanged += textBoxStatusEffectTextBattle_TextChanged;
            // 
            // listBoxStatusEffects
            // 
            listBoxStatusEffects.FormattingEnabled = true;
            listBoxStatusEffects.Location = new Point(6, 6);
            listBoxStatusEffects.Name = "listBoxStatusEffects";
            listBoxStatusEffects.Size = new Size(249, 409);
            listBoxStatusEffects.TabIndex = 1;
            listBoxStatusEffects.SelectedIndexChanged += listBoxStatusEffects_SelectedIndexChanged;
            // 
            // tabPageL4Limits
            // 
            tabPageL4Limits.Controls.Add(groupBoxL4Limit);
            tabPageL4Limits.Controls.Add(comboBoxL4Char);
            tabPageL4Limits.Controls.Add(pictureBoxL4Char);
            tabPageL4Limits.Location = new Point(4, 24);
            tabPageL4Limits.Name = "tabPageL4Limits";
            tabPageL4Limits.Size = new Size(768, 499);
            tabPageL4Limits.TabIndex = 4;
            tabPageL4Limits.Text = "L4 Limits";
            tabPageL4Limits.UseVisualStyleBackColor = true;
            // 
            // groupBoxL4Limit
            // 
            groupBoxL4Limit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxL4Limit.Controls.Add(textBoxL4Wrong);
            groupBoxL4Limit.Controls.Add(labelL4Wrong);
            groupBoxL4Limit.Controls.Add(textBoxL4Fail);
            groupBoxL4Limit.Controls.Add(labelL4Fail);
            groupBoxL4Limit.Controls.Add(textBoxL4Success);
            groupBoxL4Limit.Controls.Add(labelL4Success);
            groupBoxL4Limit.Location = new Point(6, 108);
            groupBoxL4Limit.Name = "groupBoxL4Limit";
            groupBoxL4Limit.Size = new Size(757, 347);
            groupBoxL4Limit.TabIndex = 2;
            groupBoxL4Limit.TabStop = false;
            groupBoxL4Limit.Text = "Text when teaching a L4 limit";
            // 
            // textBoxL4Wrong
            // 
            textBoxL4Wrong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxL4Wrong.Location = new Point(6, 125);
            textBoxL4Wrong.Name = "textBoxL4Wrong";
            textBoxL4Wrong.Size = new Size(745, 23);
            textBoxL4Wrong.TabIndex = 5;
            textBoxL4Wrong.TextChanged += textBoxL4Wrong_TextChanged;
            // 
            // labelL4Wrong
            // 
            labelL4Wrong.AutoSize = true;
            labelL4Wrong.Location = new Point(6, 107);
            labelL4Wrong.Name = "labelL4Wrong";
            labelL4Wrong.Size = new Size(89, 15);
            labelL4Wrong.TabIndex = 4;
            labelL4Wrong.Text = "Wrong manual:";
            // 
            // textBoxL4Fail
            // 
            textBoxL4Fail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxL4Fail.Location = new Point(6, 81);
            textBoxL4Fail.Name = "textBoxL4Fail";
            textBoxL4Fail.Size = new Size(745, 23);
            textBoxL4Fail.TabIndex = 3;
            textBoxL4Fail.TextChanged += textBoxL4Fail_TextChanged;
            // 
            // labelL4Fail
            // 
            labelL4Fail.AutoSize = true;
            labelL4Fail.Location = new Point(6, 63);
            labelL4Fail.Name = "labelL4Fail";
            labelL4Fail.Size = new Size(62, 15);
            labelL4Fail.TabIndex = 2;
            labelL4Fail.Text = "Not ready:";
            // 
            // textBoxL4Success
            // 
            textBoxL4Success.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxL4Success.Location = new Point(6, 37);
            textBoxL4Success.Name = "textBoxL4Success";
            textBoxL4Success.Size = new Size(745, 23);
            textBoxL4Success.TabIndex = 1;
            textBoxL4Success.TextChanged += textBoxL4Success_TextChanged;
            // 
            // labelL4Success
            // 
            labelL4Success.AutoSize = true;
            labelL4Success.Location = new Point(6, 19);
            labelL4Success.Name = "labelL4Success";
            labelL4Success.Size = new Size(51, 15);
            labelL4Success.TabIndex = 0;
            labelL4Success.Text = "Success:";
            // 
            // comboBoxL4Char
            // 
            comboBoxL4Char.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxL4Char.FormattingEnabled = true;
            comboBoxL4Char.Items.AddRange(new object[] { "Cloud", "Barret", "Tifa", "Aerith", "Red XIII", "Yuffie", "Vincent", "Cid", "Cait Sith" });
            comboBoxL4Char.Location = new Point(96, 79);
            comboBoxL4Char.Name = "comboBoxL4Char";
            comboBoxL4Char.Size = new Size(121, 23);
            comboBoxL4Char.TabIndex = 1;
            comboBoxL4Char.SelectedIndexChanged += comboBoxL4Char_SelectedIndexChanged;
            // 
            // pictureBoxL4Char
            // 
            pictureBoxL4Char.Location = new Point(6, 6);
            pictureBoxL4Char.Name = "pictureBoxL4Char";
            pictureBoxL4Char.Size = new Size(84, 96);
            pictureBoxL4Char.TabIndex = 0;
            pictureBoxL4Char.TabStop = false;
            // 
            // tabPageBattleArena
            // 
            tabPageBattleArena.Controls.Add(groupBoxBattleArenaMenu);
            tabPageBattleArena.Controls.Add(groupBoxBattleArenaBattle);
            tabPageBattleArena.Location = new Point(4, 24);
            tabPageBattleArena.Name = "tabPageBattleArena";
            tabPageBattleArena.Size = new Size(768, 499);
            tabPageBattleArena.TabIndex = 7;
            tabPageBattleArena.Text = "Battle arena + Bizarro";
            tabPageBattleArena.UseVisualStyleBackColor = true;
            // 
            // groupBoxBattleArenaMenu
            // 
            groupBoxBattleArenaMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxBattleArenaMenu.Controls.Add(listBoxBizarroMenu);
            groupBoxBattleArenaMenu.Controls.Add(labelBizarroMenu);
            groupBoxBattleArenaMenu.Controls.Add(textBoxBizarroMenu);
            groupBoxBattleArenaMenu.Location = new Point(5, 367);
            groupBoxBattleArenaMenu.Name = "groupBoxBattleArenaMenu";
            groupBoxBattleArenaMenu.Size = new Size(758, 129);
            groupBoxBattleArenaMenu.TabIndex = 9;
            groupBoxBattleArenaMenu.TabStop = false;
            groupBoxBattleArenaMenu.Text = "Menu text";
            // 
            // listBoxBizarroMenu
            // 
            listBoxBizarroMenu.FormattingEnabled = true;
            listBoxBizarroMenu.Location = new Point(6, 22);
            listBoxBizarroMenu.Name = "listBoxBizarroMenu";
            listBoxBizarroMenu.Size = new Size(244, 94);
            listBoxBizarroMenu.TabIndex = 5;
            listBoxBizarroMenu.SelectedIndexChanged += listBoxBizarroMenu_SelectedIndexChanged;
            // 
            // labelBizarroMenu
            // 
            labelBizarroMenu.AutoSize = true;
            labelBizarroMenu.Location = new Point(256, 22);
            labelBizarroMenu.Name = "labelBizarroMenu";
            labelBizarroMenu.Size = new Size(31, 15);
            labelBizarroMenu.TabIndex = 7;
            labelBizarroMenu.Text = "Text:";
            // 
            // textBoxBizarroMenu
            // 
            textBoxBizarroMenu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxBizarroMenu.Enabled = false;
            textBoxBizarroMenu.Location = new Point(256, 40);
            textBoxBizarroMenu.Name = "textBoxBizarroMenu";
            textBoxBizarroMenu.Size = new Size(496, 23);
            textBoxBizarroMenu.TabIndex = 6;
            textBoxBizarroMenu.TextChanged += textBoxBizarroMenu_TextChanged;
            // 
            // groupBoxBattleArenaBattle
            // 
            groupBoxBattleArenaBattle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxBattleArenaBattle.Controls.Add(listBoxBattleArena);
            groupBoxBattleArenaBattle.Controls.Add(labelBattleArena);
            groupBoxBattleArenaBattle.Controls.Add(textBoxBattleArena);
            groupBoxBattleArenaBattle.Location = new Point(5, 3);
            groupBoxBattleArenaBattle.Name = "groupBoxBattleArenaBattle";
            groupBoxBattleArenaBattle.Size = new Size(758, 358);
            groupBoxBattleArenaBattle.TabIndex = 8;
            groupBoxBattleArenaBattle.TabStop = false;
            groupBoxBattleArenaBattle.Text = "Battle text";
            // 
            // listBoxBattleArena
            // 
            listBoxBattleArena.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxBattleArena.FormattingEnabled = true;
            listBoxBattleArena.Location = new Point(6, 22);
            listBoxBattleArena.Name = "listBoxBattleArena";
            listBoxBattleArena.Size = new Size(244, 319);
            listBoxBattleArena.TabIndex = 5;
            listBoxBattleArena.SelectedIndexChanged += listBoxBattleArena_SelectedIndexChanged;
            // 
            // labelBattleArena
            // 
            labelBattleArena.AutoSize = true;
            labelBattleArena.Location = new Point(256, 22);
            labelBattleArena.Name = "labelBattleArena";
            labelBattleArena.Size = new Size(31, 15);
            labelBattleArena.TabIndex = 7;
            labelBattleArena.Text = "Text:";
            // 
            // textBoxBattleArena
            // 
            textBoxBattleArena.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxBattleArena.Enabled = false;
            textBoxBattleArena.Location = new Point(256, 40);
            textBoxBattleArena.Name = "textBoxBattleArena";
            textBoxBattleArena.Size = new Size(496, 23);
            textBoxBattleArena.TabIndex = 6;
            textBoxBattleArena.TextChanged += textBoxBattleArena_TextChanged;
            // 
            // tabPageShopText
            // 
            tabPageShopText.Controls.Add(groupBoxShopText);
            tabPageShopText.Controls.Add(groupBoxShopNames);
            tabPageShopText.Location = new Point(4, 24);
            tabPageShopText.Name = "tabPageShopText";
            tabPageShopText.Size = new Size(768, 499);
            tabPageShopText.TabIndex = 5;
            tabPageShopText.Text = "Shop text";
            tabPageShopText.UseVisualStyleBackColor = true;
            // 
            // groupBoxShopText
            // 
            groupBoxShopText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxShopText.Controls.Add(labelShopText);
            groupBoxShopText.Controls.Add(textBoxShopText);
            groupBoxShopText.Controls.Add(listBoxShopText);
            groupBoxShopText.Location = new Point(5, 180);
            groupBoxShopText.Name = "groupBoxShopText";
            groupBoxShopText.Size = new Size(758, 316);
            groupBoxShopText.TabIndex = 2;
            groupBoxShopText.TabStop = false;
            groupBoxShopText.Text = "Shop text";
            // 
            // labelShopText
            // 
            labelShopText.AutoSize = true;
            labelShopText.Location = new Point(256, 22);
            labelShopText.Name = "labelShopText";
            labelShopText.Size = new Size(31, 15);
            labelShopText.TabIndex = 6;
            labelShopText.Text = "Text:";
            // 
            // textBoxShopText
            // 
            textBoxShopText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxShopText.Enabled = false;
            textBoxShopText.Location = new Point(256, 40);
            textBoxShopText.Name = "textBoxShopText";
            textBoxShopText.Size = new Size(496, 23);
            textBoxShopText.TabIndex = 5;
            textBoxShopText.TextChanged += textBoxShopText_TextChanged;
            // 
            // listBoxShopText
            // 
            listBoxShopText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxShopText.FormattingEnabled = true;
            listBoxShopText.Location = new Point(6, 22);
            listBoxShopText.Name = "listBoxShopText";
            listBoxShopText.Size = new Size(244, 274);
            listBoxShopText.TabIndex = 0;
            listBoxShopText.SelectedIndexChanged += listBoxShopText_SelectedIndexChanged;
            // 
            // groupBoxShopNames
            // 
            groupBoxShopNames.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxShopNames.Controls.Add(labelShopNameText);
            groupBoxShopNames.Controls.Add(textBoxShopNameText);
            groupBoxShopNames.Controls.Add(listBoxShopNames);
            groupBoxShopNames.Location = new Point(5, 3);
            groupBoxShopNames.Name = "groupBoxShopNames";
            groupBoxShopNames.Size = new Size(758, 171);
            groupBoxShopNames.TabIndex = 1;
            groupBoxShopNames.TabStop = false;
            groupBoxShopNames.Text = "Shop names";
            // 
            // labelShopNameText
            // 
            labelShopNameText.AutoSize = true;
            labelShopNameText.Location = new Point(256, 22);
            labelShopNameText.Name = "labelShopNameText";
            labelShopNameText.Size = new Size(31, 15);
            labelShopNameText.TabIndex = 4;
            labelShopNameText.Text = "Text:";
            // 
            // textBoxShopNameText
            // 
            textBoxShopNameText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxShopNameText.Enabled = false;
            textBoxShopNameText.Location = new Point(256, 40);
            textBoxShopNameText.Name = "textBoxShopNameText";
            textBoxShopNameText.Size = new Size(496, 23);
            textBoxShopNameText.TabIndex = 3;
            textBoxShopNameText.TextChanged += textBoxShopNameText_TextChanged;
            // 
            // listBoxShopNames
            // 
            listBoxShopNames.FormattingEnabled = true;
            listBoxShopNames.Location = new Point(6, 22);
            listBoxShopNames.Name = "listBoxShopNames";
            listBoxShopNames.Size = new Size(244, 139);
            listBoxShopNames.TabIndex = 0;
            listBoxShopNames.SelectedIndexChanged += listBoxShopNames_SelectedIndexChanged;
            // 
            // tabPageChocoboRacing
            // 
            tabPageChocoboRacing.Controls.Add(groupBoxChocoboRacePrizes);
            tabPageChocoboRacing.Controls.Add(groupBoxChocoboNames);
            tabPageChocoboRacing.Location = new Point(4, 24);
            tabPageChocoboRacing.Name = "tabPageChocoboRacing";
            tabPageChocoboRacing.Size = new Size(768, 499);
            tabPageChocoboRacing.TabIndex = 6;
            tabPageChocoboRacing.Text = "Chocobo racing";
            tabPageChocoboRacing.UseVisualStyleBackColor = true;
            // 
            // groupBoxChocoboRacePrizes
            // 
            groupBoxChocoboRacePrizes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxChocoboRacePrizes.Controls.Add(comboBoxChocoboRacePrizes);
            groupBoxChocoboRacePrizes.Controls.Add(labelChocoboRacePrizes);
            groupBoxChocoboRacePrizes.Controls.Add(listBoxChocoboRacePrizes);
            groupBoxChocoboRacePrizes.Controls.Add(labelPrizeNote);
            groupBoxChocoboRacePrizes.Location = new Point(374, 3);
            groupBoxChocoboRacePrizes.Name = "groupBoxChocoboRacePrizes";
            groupBoxChocoboRacePrizes.Size = new Size(389, 493);
            groupBoxChocoboRacePrizes.TabIndex = 42;
            groupBoxChocoboRacePrizes.TabStop = false;
            groupBoxChocoboRacePrizes.Text = "Prize list";
            // 
            // comboBoxChocoboRacePrizes
            // 
            comboBoxChocoboRacePrizes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxChocoboRacePrizes.Enabled = false;
            comboBoxChocoboRacePrizes.FormattingEnabled = true;
            comboBoxChocoboRacePrizes.Location = new Point(200, 40);
            comboBoxChocoboRacePrizes.Name = "comboBoxChocoboRacePrizes";
            comboBoxChocoboRacePrizes.Size = new Size(183, 23);
            comboBoxChocoboRacePrizes.TabIndex = 43;
            comboBoxChocoboRacePrizes.TextChanged += comboBoxChocoboPrizes_TextChanged;
            // 
            // labelChocoboRacePrizes
            // 
            labelChocoboRacePrizes.AutoSize = true;
            labelChocoboRacePrizes.Location = new Point(200, 22);
            labelChocoboRacePrizes.Name = "labelChocoboRacePrizes";
            labelChocoboRacePrizes.Size = new Size(34, 15);
            labelChocoboRacePrizes.TabIndex = 42;
            labelChocoboRacePrizes.Text = "Item:";
            // 
            // listBoxChocoboRacePrizes
            // 
            listBoxChocoboRacePrizes.FormattingEnabled = true;
            listBoxChocoboRacePrizes.Location = new Point(7, 22);
            listBoxChocoboRacePrizes.Margin = new Padding(4, 3, 4, 3);
            listBoxChocoboRacePrizes.Name = "listBoxChocoboRacePrizes";
            listBoxChocoboRacePrizes.Size = new Size(186, 364);
            listBoxChocoboRacePrizes.TabIndex = 41;
            listBoxChocoboRacePrizes.SelectedIndexChanged += listBoxChocoboRacePrizes_SelectedIndexChanged;
            // 
            // labelPrizeNote
            // 
            labelPrizeNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPrizeNote.Location = new Point(6, 389);
            labelPrizeNote.Name = "labelPrizeNote";
            labelPrizeNote.Size = new Size(376, 38);
            labelPrizeNote.TabIndex = 24;
            labelPrizeNote.Text = "*Note: These affect the names only. Actual prize giving is handled in flevel.";
            // 
            // groupBoxChocoboNames
            // 
            groupBoxChocoboNames.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxChocoboNames.Controls.Add(labelChocoboName);
            groupBoxChocoboNames.Controls.Add(textBoxChocoboName);
            groupBoxChocoboNames.Controls.Add(listBoxChocoboNames);
            groupBoxChocoboNames.Location = new Point(8, 3);
            groupBoxChocoboNames.Name = "groupBoxChocoboNames";
            groupBoxChocoboNames.Size = new Size(360, 493);
            groupBoxChocoboNames.TabIndex = 41;
            groupBoxChocoboNames.TabStop = false;
            groupBoxChocoboNames.Text = "Chocobo names";
            // 
            // labelChocoboName
            // 
            labelChocoboName.AutoSize = true;
            labelChocoboName.Location = new Point(200, 22);
            labelChocoboName.Name = "labelChocoboName";
            labelChocoboName.Size = new Size(42, 15);
            labelChocoboName.TabIndex = 42;
            labelChocoboName.Text = "Name:";
            // 
            // textBoxChocoboName
            // 
            textBoxChocoboName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxChocoboName.Enabled = false;
            textBoxChocoboName.Location = new Point(200, 40);
            textBoxChocoboName.Name = "textBoxChocoboName";
            textBoxChocoboName.Size = new Size(154, 23);
            textBoxChocoboName.TabIndex = 41;
            textBoxChocoboName.TextChanged += textBoxChocoboName_TextChanged;
            // 
            // listBoxChocoboNames
            // 
            listBoxChocoboNames.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxChocoboNames.FormattingEnabled = true;
            listBoxChocoboNames.Location = new Point(7, 22);
            listBoxChocoboNames.Margin = new Padding(4, 3, 4, 3);
            listBoxChocoboNames.Name = "listBoxChocoboNames";
            listBoxChocoboNames.Size = new Size(186, 454);
            listBoxChocoboNames.TabIndex = 40;
            listBoxChocoboNames.SelectedIndexChanged += listBoxChocoboNames_SelectedIndexChanged;
            // 
            // tabPageAudio
            // 
            tabPageAudio.Controls.Add(groupBoxAudioPan);
            tabPageAudio.Controls.Add(groupBoxAudioVolume);
            tabPageAudio.Location = new Point(4, 24);
            tabPageAudio.Name = "tabPageAudio";
            tabPageAudio.Size = new Size(776, 527);
            tabPageAudio.TabIndex = 7;
            tabPageAudio.Text = "Audio";
            tabPageAudio.UseVisualStyleBackColor = true;
            // 
            // groupBoxAudioPan
            // 
            groupBoxAudioPan.Controls.Add(buttonAudioPanTest);
            groupBoxAudioPan.Controls.Add(numericAudioPan);
            groupBoxAudioPan.Controls.Add(labelAudioPan);
            groupBoxAudioPan.Controls.Add(trackBarAudioPan);
            groupBoxAudioPan.Controls.Add(listBoxAudioPan);
            groupBoxAudioPan.Location = new Point(295, 4);
            groupBoxAudioPan.Name = "groupBoxAudioPan";
            groupBoxAudioPan.Size = new Size(280, 521);
            groupBoxAudioPan.TabIndex = 1;
            groupBoxAudioPan.TabStop = false;
            groupBoxAudioPan.Text = "Audio pan";
            // 
            // buttonAudioPanTest
            // 
            buttonAudioPanTest.Enabled = false;
            buttonAudioPanTest.Location = new Point(199, 438);
            buttonAudioPanTest.Name = "buttonAudioPanTest";
            buttonAudioPanTest.Size = new Size(75, 23);
            buttonAudioPanTest.TabIndex = 7;
            buttonAudioPanTest.Text = "Test";
            buttonAudioPanTest.UseVisualStyleBackColor = true;
            buttonAudioPanTest.Click += buttonAudioPanTest_Click;
            // 
            // numericAudioPan
            // 
            numericAudioPan.Enabled = false;
            numericAudioPan.Location = new Point(62, 440);
            numericAudioPan.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericAudioPan.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericAudioPan.Name = "numericAudioPan";
            numericAudioPan.Size = new Size(131, 23);
            numericAudioPan.TabIndex = 6;
            numericAudioPan.ValueChanged += numericAudioPan_ValueChanged;
            // 
            // labelAudioPan
            // 
            labelAudioPan.AutoSize = true;
            labelAudioPan.Enabled = false;
            labelAudioPan.Location = new Point(26, 442);
            labelAudioPan.Name = "labelAudioPan";
            labelAudioPan.Size = new Size(30, 15);
            labelAudioPan.TabIndex = 5;
            labelAudioPan.Text = "Pan:";
            // 
            // trackBarAudioPan
            // 
            trackBarAudioPan.BackColor = Color.White;
            trackBarAudioPan.Enabled = false;
            trackBarAudioPan.LargeChange = 1000;
            trackBarAudioPan.Location = new Point(6, 469);
            trackBarAudioPan.Maximum = 10000;
            trackBarAudioPan.Minimum = -10000;
            trackBarAudioPan.Name = "trackBarAudioPan";
            trackBarAudioPan.Size = new Size(268, 45);
            trackBarAudioPan.TabIndex = 4;
            trackBarAudioPan.TickFrequency = 2000;
            // 
            // listBoxAudioPan
            // 
            listBoxAudioPan.FormattingEnabled = true;
            listBoxAudioPan.Location = new Point(6, 22);
            listBoxAudioPan.Name = "listBoxAudioPan";
            listBoxAudioPan.Size = new Size(268, 409);
            listBoxAudioPan.TabIndex = 0;
            listBoxAudioPan.SelectedIndexChanged += listBoxAudioPan_SelectedIndexChanged;
            // 
            // groupBoxAudioVolume
            // 
            groupBoxAudioVolume.Controls.Add(buttonAudioVolumeTest);
            groupBoxAudioVolume.Controls.Add(numericAudioVolume);
            groupBoxAudioVolume.Controls.Add(labelAuidioVolume);
            groupBoxAudioVolume.Controls.Add(trackBarAudioVolume);
            groupBoxAudioVolume.Controls.Add(listBoxAudioVolume);
            groupBoxAudioVolume.Location = new Point(9, 3);
            groupBoxAudioVolume.Name = "groupBoxAudioVolume";
            groupBoxAudioVolume.Size = new Size(280, 521);
            groupBoxAudioVolume.TabIndex = 0;
            groupBoxAudioVolume.TabStop = false;
            groupBoxAudioVolume.Text = "Audio volume";
            // 
            // buttonAudioVolumeTest
            // 
            buttonAudioVolumeTest.Enabled = false;
            buttonAudioVolumeTest.Location = new Point(199, 439);
            buttonAudioVolumeTest.Name = "buttonAudioVolumeTest";
            buttonAudioVolumeTest.Size = new Size(75, 23);
            buttonAudioVolumeTest.TabIndex = 4;
            buttonAudioVolumeTest.Text = "Test";
            buttonAudioVolumeTest.UseVisualStyleBackColor = true;
            buttonAudioVolumeTest.Click += buttonVolumeTest_Click;
            // 
            // numericAudioVolume
            // 
            numericAudioVolume.Enabled = false;
            numericAudioVolume.Location = new Point(62, 441);
            numericAudioVolume.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numericAudioVolume.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericAudioVolume.Name = "numericAudioVolume";
            numericAudioVolume.Size = new Size(131, 23);
            numericAudioVolume.TabIndex = 3;
            numericAudioVolume.ValueChanged += numericAudioVolume_ValueChanged;
            // 
            // labelAuidioVolume
            // 
            labelAuidioVolume.AutoSize = true;
            labelAuidioVolume.Enabled = false;
            labelAuidioVolume.Location = new Point(6, 443);
            labelAuidioVolume.Name = "labelAuidioVolume";
            labelAuidioVolume.Size = new Size(50, 15);
            labelAuidioVolume.TabIndex = 2;
            labelAuidioVolume.Text = "Volume:";
            // 
            // trackBarAudioVolume
            // 
            trackBarAudioVolume.BackColor = Color.White;
            trackBarAudioVolume.Enabled = false;
            trackBarAudioVolume.LargeChange = 1000;
            trackBarAudioVolume.Location = new Point(6, 470);
            trackBarAudioVolume.Maximum = 0;
            trackBarAudioVolume.Minimum = -10000;
            trackBarAudioVolume.Name = "trackBarAudioVolume";
            trackBarAudioVolume.Size = new Size(268, 45);
            trackBarAudioVolume.TabIndex = 1;
            trackBarAudioVolume.TickFrequency = 1000;
            // 
            // listBoxAudioVolume
            // 
            listBoxAudioVolume.FormattingEnabled = true;
            listBoxAudioVolume.Location = new Point(6, 22);
            listBoxAudioVolume.Name = "listBoxAudioVolume";
            listBoxAudioVolume.Size = new Size(268, 409);
            listBoxAudioVolume.TabIndex = 0;
            listBoxAudioVolume.SelectedIndexChanged += listBoxAudioVolume_SelectedIndexChanged;
            // 
            // tabWorldmapWalkability
            // 
            tabWorldmapWalkability.Controls.Add(groupBoxDisembarkTriangleTypes);
            tabWorldmapWalkability.Controls.Add(groupBoxWalkableTriangleTypes);
            tabWorldmapWalkability.Controls.Add(listBoxModels);
            tabWorldmapWalkability.Location = new Point(4, 24);
            tabWorldmapWalkability.Name = "tabWorldmapWalkability";
            tabWorldmapWalkability.Padding = new Padding(3);
            tabWorldmapWalkability.Size = new Size(776, 527);
            tabWorldmapWalkability.TabIndex = 8;
            tabWorldmapWalkability.Text = "Worldmap Walkability";
            tabWorldmapWalkability.UseVisualStyleBackColor = true;
            // 
            // groupBoxDisembarkTriangleTypes
            // 
            groupBoxDisembarkTriangleTypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxDisembarkTriangleTypes.Controls.Add(checkedListBoxDisembarkTriangleTypes);
            groupBoxDisembarkTriangleTypes.Enabled = false;
            groupBoxDisembarkTriangleTypes.Location = new Point(185, 202);
            groupBoxDisembarkTriangleTypes.Name = "groupBoxDisembarkTriangleTypes";
            groupBoxDisembarkTriangleTypes.Size = new Size(585, 190);
            groupBoxDisembarkTriangleTypes.TabIndex = 43;
            groupBoxDisembarkTriangleTypes.TabStop = false;
            groupBoxDisembarkTriangleTypes.Text = "Can disembark to:";
            // 
            // checkedListBoxDisembarkTriangleTypes
            // 
            checkedListBoxDisembarkTriangleTypes.BorderStyle = BorderStyle.None;
            checkedListBoxDisembarkTriangleTypes.CheckOnClick = true;
            checkedListBoxDisembarkTriangleTypes.ColumnWidth = 140;
            checkedListBoxDisembarkTriangleTypes.Dock = DockStyle.Fill;
            checkedListBoxDisembarkTriangleTypes.FormattingEnabled = true;
            checkedListBoxDisembarkTriangleTypes.Items.AddRange(new object[] { "Grass", "Forest", "Mountain", "Sea", "River Crossing", "River", "Water", "Swamp", "Desert", "Wasteland", "Snow", "Riverside", "Cliff", "Corel Bridge", "Wutai Bridge", "Unused (15)", "Hill side", "Beach", "Sub Pen", "Canyon", "Mountain Pass", "Unknown (21)", "Waterfall", "Unused (23)", "Gold Saucer Desert", "Jungle", "Sea 2", "Northern Cave", "Gold Saucer Border", "Bridgehead", "Back Entrance", "Unused (31)" });
            checkedListBoxDisembarkTriangleTypes.Location = new Point(3, 19);
            checkedListBoxDisembarkTriangleTypes.MultiColumn = true;
            checkedListBoxDisembarkTriangleTypes.Name = "checkedListBoxDisembarkTriangleTypes";
            checkedListBoxDisembarkTriangleTypes.Size = new Size(579, 168);
            checkedListBoxDisembarkTriangleTypes.TabIndex = 42;
            checkedListBoxDisembarkTriangleTypes.ItemCheck += checkedListBoxDisembarkTriangleTypes_ItemCheck;
            // 
            // groupBoxWalkableTriangleTypes
            // 
            groupBoxWalkableTriangleTypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxWalkableTriangleTypes.Controls.Add(checkedListBoxWalkableTriangleTypes);
            groupBoxWalkableTriangleTypes.Enabled = false;
            groupBoxWalkableTriangleTypes.Location = new Point(185, 6);
            groupBoxWalkableTriangleTypes.Name = "groupBoxWalkableTriangleTypes";
            groupBoxWalkableTriangleTypes.Size = new Size(585, 190);
            groupBoxWalkableTriangleTypes.TabIndex = 41;
            groupBoxWalkableTriangleTypes.TabStop = false;
            groupBoxWalkableTriangleTypes.Text = "Can walk/drive on:";
            // 
            // checkedListBoxWalkableTriangleTypes
            // 
            checkedListBoxWalkableTriangleTypes.BorderStyle = BorderStyle.None;
            checkedListBoxWalkableTriangleTypes.CheckOnClick = true;
            checkedListBoxWalkableTriangleTypes.ColumnWidth = 140;
            checkedListBoxWalkableTriangleTypes.Dock = DockStyle.Fill;
            checkedListBoxWalkableTriangleTypes.FormattingEnabled = true;
            checkedListBoxWalkableTriangleTypes.Items.AddRange(new object[] { "Grass", "Forest", "Mountain", "Sea", "River Crossing", "River", "Water", "Swamp", "Desert", "Wasteland", "Snow", "Riverside", "Cliff", "Corel Bridge", "Wutai Bridge", "Unused (15)", "Hill side", "Beach", "Sub Pen", "Canyon", "Mountain Pass", "Unknown (21)", "Waterfall", "Unused (23)", "Gold Saucer Desert", "Jungle", "Sea 2", "Northern Cave", "Gold Saucer Border", "Bridgehead", "Back Entrance", "Unused (31)" });
            checkedListBoxWalkableTriangleTypes.Location = new Point(3, 19);
            checkedListBoxWalkableTriangleTypes.MultiColumn = true;
            checkedListBoxWalkableTriangleTypes.Name = "checkedListBoxWalkableTriangleTypes";
            checkedListBoxWalkableTriangleTypes.Size = new Size(579, 168);
            checkedListBoxWalkableTriangleTypes.TabIndex = 42;
            checkedListBoxWalkableTriangleTypes.ItemCheck += checkedListBoxWalkableTriangleTypes_ItemCheck;
            // 
            // listBoxModels
            // 
            listBoxModels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxModels.FormattingEnabled = true;
            listBoxModels.Location = new Point(4, 7);
            listBoxModels.Margin = new Padding(4, 3, 4, 3);
            listBoxModels.Name = "listBoxModels";
            listBoxModels.Size = new Size(174, 514);
            listBoxModels.TabIndex = 40;
            listBoxModels.SelectedIndexChanged += listBoxModels_SelectedIndexChanged;
            // 
            // buttonHext
            // 
            buttonHext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonHext.Location = new Point(522, 7);
            buttonHext.Margin = new Padding(4, 3, 4, 3);
            buttonHext.Name = "buttonHext";
            buttonHext.Size = new Size(121, 27);
            buttonHext.TabIndex = 4;
            buttonHext.Text = "Create Hext file";
            buttonHext.UseVisualStyleBackColor = true;
            buttonHext.Click += buttonHext_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonLoadFile);
            panelButtons.Controls.Add(buttonHext);
            panelButtons.Controls.Add(buttonSaveFile);
            panelButtons.Controls.Add(buttonSaveEXE);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 555);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(784, 46);
            panelButtons.TabIndex = 6;
            // 
            // ExeEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 601);
            Controls.Add(tabControlMain);
            Controls.Add(panelButtons);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(800, 600);
            Name = "ExeEditorForm";
            Text = "Scarlet - EXE Editor";
            FormClosing += ExeEditorForm_FormClosing;
            tabControlMain.ResumeLayout(false);
            tabPageInitialData.ResumeLayout(false);
            tabPageInitialData.PerformLayout();
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
            tabPageLimitBreaks.ResumeLayout(false);
            tabControlLimits.ResumeLayout(false);
            tabPageLimits1.ResumeLayout(false);
            tabPageLimits1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericLimitAttackPercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericLimitMPCost).EndInit();
            tabPageLimits2.ResumeLayout(false);
            tabPageLimits2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericLimitStatusChangeChance).EndInit();
            tabPageLimits3.ResumeLayout(false);
            tabPageNames.ResumeLayout(false);
            tabPageNames.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxChocobo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCid).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVincent).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaitSith).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxYuffie).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRedXIII).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAeris).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTifa).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBarret).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCloud).EndInit();
            tabPageShopData.ResumeLayout(false);
            tabPageShopData.PerformLayout();
            groupBoxShopInventory.ResumeLayout(false);
            groupBoxShopInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericShopItemCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMateriaPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMateriaAPPriceMultiplier).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericItemPrice).EndInit();
            tabPageSortOrder.ResumeLayout(false);
            groupBoxMateriaPriority.ResumeLayout(false);
            groupBoxSortItemName.ResumeLayout(false);
            tabPageMenus.ResumeLayout(false);
            tabControlMenus.ResumeLayout(false);
            tabPageMainMenu.ResumeLayout(false);
            groupBoxQuitMenu.ResumeLayout(false);
            groupBoxQuitMenu.PerformLayout();
            groupBoxMainMenu.ResumeLayout(false);
            groupBoxMainMenu.PerformLayout();
            tabPageItemMagicMenu.ResumeLayout(false);
            groupBoxMagicMenu.ResumeLayout(false);
            groupBoxMagicMenu.PerformLayout();
            groupBoxItemMenu.ResumeLayout(false);
            groupBoxItemMenu.PerformLayout();
            tabPageMateriaMenu.ResumeLayout(false);
            groupBoxUnequipText.ResumeLayout(false);
            groupBoxUnequipText.PerformLayout();
            groupBoxMateriaText.ResumeLayout(false);
            groupBoxMateriaText.PerformLayout();
            tabPageEquipMenu.ResumeLayout(false);
            tabPageEquipMenu.PerformLayout();
            tabPageStatusMenu.ResumeLayout(false);
            groupBoxStatusMenu.ResumeLayout(false);
            groupBoxStatusMenu.PerformLayout();
            groupBoxElements.ResumeLayout(false);
            groupBoxElements.PerformLayout();
            tabPageLimitMenu.ResumeLayout(false);
            tabPageLimitMenu.PerformLayout();
            tabPageConfigMenu.ResumeLayout(false);
            tabPageConfigMenu.PerformLayout();
            tabPageSaveMenu.ResumeLayout(false);
            tabPageSaveMenu.PerformLayout();
            tabPageOtherText.ResumeLayout(false);
            tabControlOtherText.ResumeLayout(false);
            tabPageStatusEffects.ResumeLayout(false);
            tabPageStatusEffects.PerformLayout();
            tabPageL4Limits.ResumeLayout(false);
            groupBoxL4Limit.ResumeLayout(false);
            groupBoxL4Limit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxL4Char).EndInit();
            tabPageBattleArena.ResumeLayout(false);
            groupBoxBattleArenaMenu.ResumeLayout(false);
            groupBoxBattleArenaMenu.PerformLayout();
            groupBoxBattleArenaBattle.ResumeLayout(false);
            groupBoxBattleArenaBattle.PerformLayout();
            tabPageShopText.ResumeLayout(false);
            groupBoxShopText.ResumeLayout(false);
            groupBoxShopText.PerformLayout();
            groupBoxShopNames.ResumeLayout(false);
            groupBoxShopNames.PerformLayout();
            tabPageChocoboRacing.ResumeLayout(false);
            groupBoxChocoboRacePrizes.ResumeLayout(false);
            groupBoxChocoboRacePrizes.PerformLayout();
            groupBoxChocoboNames.ResumeLayout(false);
            groupBoxChocoboNames.PerformLayout();
            tabPageAudio.ResumeLayout(false);
            groupBoxAudioPan.ResumeLayout(false);
            groupBoxAudioPan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAudioPan).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAudioPan).EndInit();
            groupBoxAudioVolume.ResumeLayout(false);
            groupBoxAudioVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAudioVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAudioVolume).EndInit();
            tabWorldmapWalkability.ResumeLayout(false);
            groupBoxDisembarkTriangleTypes.ResumeLayout(false);
            groupBoxWalkableTriangleTypes.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button buttonSaveEXE;
        private Button buttonLoadFile;
        private Button buttonSaveFile;
        private TabControl tabControlMain;
        private TabPage tabPageInitialData;
        private TabPage tabPageNames;
        private PictureBox pictureBoxCloud;
        private TextBox textBoxTifa;
        private PictureBox pictureBoxTifa;
        private TextBox textBoxBarret;
        private PictureBox pictureBoxBarret;
        private TextBox textBoxCloud;
        private TextBox textBoxCid;
        private PictureBox pictureBoxCid;
        private TextBox textBoxVincent;
        private PictureBox pictureBoxVincent;
        private TextBox textBoxCaitSith;
        private PictureBox pictureBoxCaitSith;
        private TextBox textBoxYuffie;
        private PictureBox pictureBoxYuffie;
        private TextBox textBoxRedXIII;
        private PictureBox pictureBoxRedXIII;
        private TextBox textBoxAeris;
        private PictureBox pictureBoxAeris;
        private TextBox textBoxChocobo;
        private PictureBox pictureBoxChocobo;
        private Button buttonHext;
        private TabPage tabPageShopData;
        private ListBox listBoxItemPrices;
        private Label labelItemPrices;
        private NumericUpDown numericItemPrice;
        private Label labelItemPrice;
        private NumericUpDown numericMateriaAPPriceMultiplier;
        private Label labelMateriaAPPriceMultiplier;
        private NumericUpDown numericMateriaPrice;
        private Label labelMateriaPrice;
        private Label labelMateriaPrices;
        private ListBox listBoxMateriaPrices;
        private GroupBox groupBoxShopInventory;
        private ComboBox comboBoxShopIndex;
        private Label labelShopIndex;
        private Label labelShopItemCount;
        private ComboBox comboBoxShopType;
        private Label labelShopType;
        private ComboBox comboBoxShopItem1;
        private Label labelShopItems;
        private NumericUpDown numericShopItemCount;
        private ComboBox comboBoxShopItem10;
        private ComboBox comboBoxShopItem9;
        private ComboBox comboBoxShopItem8;
        private ComboBox comboBoxShopItem7;
        private ComboBox comboBoxShopItem6;
        private ComboBox comboBoxShopItem5;
        private ComboBox comboBoxShopItem4;
        private ComboBox comboBoxShopItem3;
        private ComboBox comboBoxShopItem2;
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
        private NumericUpDown numericCharacterEXPtoNext;
        private Label labelCharacterEXPtoNext;
        private NumericUpDown numericCharacterKillCount;
        private Label labelCharacterKillCount;
        private ComboBox comboBoxCharacterFlags;
        private Label labelCharacterFlags;
        private FF7Scarlet.Shared.Controls.CharacterLimitControl characterLimitControl;
        private NumericUpDown numericCharacterCurrentEXP;
        private Label labelCharacterCurrentEXP;
        private GroupBox groupBoxCharacterArmor;
        private Button buttonCharacterArmorChangeMateria;
        private FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl materiaSlotSelectorCharacterArmor;
        private ComboBox comboBoxCharacterArmor;
        private GroupBox groupBoxCharacterWeapon;
        private Button buttonCharacterWeaponChangeMateria;
        private FF7Scarlet.Shared.Controls.MateriaSlotSelectorControl materiaSlotSelectorCharacterWeapon;
        private ComboBox comboBoxCharacterWeapon;
        private FF7Scarlet.Shared.Controls.CharacterStatsControl characterStatsControl;
        private CheckBox checkBoxCharacterBackRow;
        private NumericUpDown numericCharacterLevel;
        private Label labelCharacterLevel;
        private ComboBox comboBoxCharacterAccessory;
        private Label labelCharacterAccessory;
        private NumericUpDown numericCharacterID;
        private Label labelCharacterID;
        private TextBox textBoxCharacterName;
        private Label labelCharacterName;
        private Panel panelButtons;
        private ComboBox comboBoxSelectedCharacter;
        private Label labelCharacter;
        private TabPage tabPageLimitBreaks;
        private TabControl tabControlLimits;
        private TabPage tabPageLimits1;
        private Label labelLimitHurtActionIndex;
        private ComboBox comboBoxLimitHurtActionIndex;
        private Label labelLimitAttackEffectID;
        private ElementsControl elementsControlLimit;
        private ComboBox comboBoxLimitAttackEffectID;
        private Label labelLimitImpactEffectID;
        private ComboBox comboBoxLimitImpactEffectID;
        private DamageCalculationControl damageCalculationControlLimit;
        private Label labelLimitCamMovementIDMulti;
        private ComboBox comboBoxLimitCamMovementIDMulti;
        private Label labelLimitCamMovementIDSingle;
        private ComboBox comboBoxLimitCamMovementIDSingle;
        private Label labelSummonText;
        private NumericUpDown numericLimitAttackPercent;
        private TextBox textBoxSummonText;
        private Label labelLimitAttackPercent;
        private Label labelLimitMPCost;
        private NumericUpDown numericLimitMPCost;
        private TabPage tabPageLimits2;
        private Shared.SpecialAttackFlagsControl specialAttackFlagsControlLimit;
        private NumericUpDown numericLimitStatusChangeChance;
        private ComboBox comboBoxLimitConditionSubMenu;
        private Label labelLimitStatusChangeChance;
        private ComboBox comboBoxLimitStatusChange;
        private Label labelLimitConditionSubMenu;
        private Label labelLimitStatusChange;
        private StatusesControl statusesControlLimit;
        private TabPage tabPageLimits3;
        private TargetDataControl targetDataControlLimit;
        private ListBox listBoxLimits;
        private TabPage tabPageOtherText;
        private TabControl tabControlOtherText;
        private TabPage tabPageMainMenu;
        private ListBox listBoxMainMenu;
        private TabPage tabPageConfigMenu;
        private ListBox listBoxConfigMenu;
        private TabPage tabPageStatusEffects;
        private ListBox listBoxStatusEffects;
        private TabPage tabPageL4Limits;
        private GroupBox groupBoxL4Limit;
        private TextBox textBoxL4Fail;
        private Label labelL4Fail;
        private TextBox textBoxL4Success;
        private Label labelL4Success;
        private ComboBox comboBoxL4Char;
        private PictureBox pictureBoxL4Char;
        private TextBox textBoxL4Wrong;
        private Label labelL4Wrong;
        private TabPage tabPageShopText;
        private ListBox listBoxShopNames;
        private GroupBox groupBoxShopNames;
        private GroupBox groupBoxShopText;
        private ListBox listBoxShopText;
        private Label labelMainMenuText;
        private TextBox textBoxMainMenuText;
        private Label labelConfigMenuText;
        private TextBox textBoxConfigMenuText;
        private Label labelStatusEffectTextBattle;
        private TextBox textBoxStatusEffectTextBattle;
        private Label labelShopText;
        private TextBox textBoxShopText;
        private Label labelShopNameText;
        private TextBox textBoxShopNameText;
        private TabPage tabPageSortOrder;
        private ListBox listBoxSortItemName;
        private GroupBox groupBoxSortItemName;
        private Button buttonItemsMoveUp;
        private Button buttonItemsAutoSort;
        private Button buttonItemsMoveDown;
        private GroupBox groupBoxMateriaPriority;
        private ListBox listBoxMateriaPriority;
        private Button buttonMateriaMoveDown;
        private Button buttonMateriaMoveUp;
        private TabPage tabPageChocoboRacing;
        private ListBox listBoxChocoboNames;
        private GroupBox groupBoxChocoboNames;
        private TextBox textBoxChocoboName;
        private Label labelChocoboName;
        private TabPage tabPageMateriaMenu;
        private Label labelMateriaMenuText;
        private TextBox textBoxMateriaMenuText;
        private ListBox listBoxMateriaMenu;
        private GroupBox groupBoxChocoboRacePrizes;
        private Label labelPrizeNote;
        private Label labelChocoboRacePrizes;
        private ListBox listBoxChocoboRacePrizes;
        private ComboBox comboBoxChocoboRacePrizes;
        private TabPage tabPageEquipMenu;
        private Label labelEquipMenu;
        private TextBox textBoxEquipMenuText;
        private ListBox listBoxEquipMenu;
        private TabPage tabPageMenus;
        private TabControl tabControlMenus;
        private Label labelStatusEffectMenu;
        private TextBox textBoxStatusEffectMenu;
        private TabPage tabPageStatusMenu;
        private GroupBox groupBoxStatusMenu;
        private Label labelStatusText;
        private TextBox textBoxStatusMenuText;
        private ListBox listBoxStatusMenuText;
        private GroupBox groupBoxElements;
        private Label labelElements;
        private TextBox textBoxElements;
        private ListBox listBoxElements;
        private TabPage tabPageItemMagicMenu;
        private Label labelItemMenuText;
        private TextBox textBoxItemMenuText;
        private ListBox listBoxItemMenu;
        private Label labelMagicMenuText;
        private TextBox textBoxMagicMenuText;
        private ListBox listBoxMagicMenu;
        private GroupBox groupBoxItemMenu;
        private GroupBox groupBoxMagicMenu;
        private GroupBox groupBoxMateriaText;
        private GroupBox groupBoxUnequipText;
        private ListBox listBoxUnequipText;
        private Label labelUnequipText;
        private TextBox textBoxUnequipText;
        private TabPage tabPageLimitMenu;
        private Label labelLimitMenuText;
        private TextBox textBoxLimitMenuText;
        private ListBox listBoxLimitMenu;
        private TabPage tabPageSaveMenu;
        private Label labelSaveMenuText;
        private TextBox textBoxSaveMenuText;
        private ListBox listBoxSaveMenu;
        private Label labelQuitText;
        private TextBox textBoxQuitText;
        private ListBox listBoxQuitTexts;
        private GroupBox groupBoxMainMenu;
        private GroupBox groupBoxQuitMenu;
        private TabPage tabPageBattleArena;
        private Label labelBattleArena;
        private TextBox textBoxBattleArena;
        private ListBox listBoxBattleArena;
        private GroupBox groupBoxBattleArenaBattle;
        private GroupBox groupBoxBattleArenaMenu;
        private ListBox listBoxBizarroMenu;
        private Label labelBizarroMenu;
        private TextBox textBoxBizarroMenu;
        private TabPage tabPageAudio;
        private GroupBox groupBoxAudioVolume;
        private ListBox listBoxAudioVolume;
        private GroupBox groupBoxAudioPan;
        private ListBox listBoxAudioPan;
        private TrackBar trackBarAudioVolume;
        private NumericUpDown numericAudioVolume;
        private Label labelAuidioVolume;
        private NumericUpDown numericAudioPan;
        private Label labelAudioPan;
        private TrackBar trackBarAudioPan;
        private Button buttonAudioVolumeTest;
        private Button buttonAudioPanTest;
        private Label labelLimitID;

        private TabPage tabWorldmapWalkability;
        private GroupBox groupBoxWalkableTriangleTypes;
        private ListBox listBoxModels;
        private CheckedListBox checkedListBoxWalkableTriangleTypes;
        private GroupBox groupBoxDisembarkTriangleTypes;
        private CheckedListBox checkedListBoxDisembarkTriangleTypes;
    }
}

