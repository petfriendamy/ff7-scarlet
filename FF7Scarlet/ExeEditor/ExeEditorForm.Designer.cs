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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExeEditorForm));
            buttonSaveEXE = new Button();
            buttonLoadFile = new Button();
            buttonSaveFile = new Button();
            tabControlMain = new TabControl();
            tabPageInitialData = new TabPage();
            comboBoxSelectedCharacter = new ComboBox();
            label1 = new Label();
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
            characterLimitControl = new Shared.Controls.CharacterLimitControl();
            numericCharacterCurrentEXP = new NumericUpDown();
            labelCharacterCurrentEXP = new Label();
            groupBoxCharacterArmor = new GroupBox();
            buttonCharacterArmorChangeMateria = new Button();
            materiaSlotSelectorCharacterArmor = new Shared.Controls.MateriaSlotSelectorControl();
            comboBoxCharacterArmor = new ComboBox();
            groupBoxCharacterWeapon = new GroupBox();
            buttonCharacterWeaponChangeMateria = new Button();
            materiaSlotSelectorCharacterWeapon = new Shared.Controls.MateriaSlotSelectorControl();
            comboBoxCharacterWeapon = new ComboBox();
            characterStatsControl = new Shared.Controls.CharacterStatsControl();
            checkBoxCharacterBackRow = new CheckBox();
            numericCharacterLevel = new NumericUpDown();
            labelCharacterLevel = new Label();
            comboBoxCharacterAccessory = new ComboBox();
            labelCharacterAccessory = new Label();
            numericCharacterID = new NumericUpDown();
            labelCharacterID = new Label();
            textBoxCharacterName = new TextBox();
            labelCharacterName = new Label();
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
            buttonHext = new Button();
            toolTip = new ToolTip(components);
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
            tabControlMain.Controls.Add(tabPageNames);
            tabControlMain.Controls.Add(tabPageShopData);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Margin = new Padding(4, 3, 4, 3);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(784, 601);
            tabControlMain.TabIndex = 1;
            // 
            // tabPageInitialData
            // 
            tabPageInitialData.Controls.Add(comboBoxSelectedCharacter);
            tabPageInitialData.Controls.Add(label1);
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
            tabPageInitialData.Size = new Size(776, 573);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 6);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 31;
            label1.Text = "Character:";
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
            characterLimitControl.LimitBar = 0;
            characterLimitControl.LimitLevel = 0;
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
            buttonCharacterArmorChangeMateria.Location = new Point(6, 99);
            buttonCharacterArmorChangeMateria.Name = "buttonCharacterArmorChangeMateria";
            buttonCharacterArmorChangeMateria.Size = new Size(211, 23);
            buttonCharacterArmorChangeMateria.TabIndex = 18;
            buttonCharacterArmorChangeMateria.Text = "Change selected materia...";
            buttonCharacterArmorChangeMateria.UseVisualStyleBackColor = true;
            // 
            // materiaSlotSelectorCharacterArmor
            // 
            materiaSlotSelectorCharacterArmor.BackColor = Color.LightSlateGray;
            materiaSlotSelectorCharacterArmor.BorderStyle = BorderStyle.Fixed3D;
            materiaSlotSelectorCharacterArmor.GrowthRate = Shojy.FF7.Elena.Equipment.GrowthRate.None;
            materiaSlotSelectorCharacterArmor.Location = new Point(6, 58);
            materiaSlotSelectorCharacterArmor.Name = "materiaSlotSelectorCharacterArmor";
            materiaSlotSelectorCharacterArmor.SelectedSlot = -1;
            materiaSlotSelectorCharacterArmor.Size = new Size(211, 35);
            materiaSlotSelectorCharacterArmor.SlotSelectorType = Shared.Controls.SlotSelectorType.Slots;
            materiaSlotSelectorCharacterArmor.TabIndex = 15;
            // 
            // comboBoxCharacterArmor
            // 
            comboBoxCharacterArmor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCharacterArmor.FormattingEnabled = true;
            comboBoxCharacterArmor.Location = new Point(6, 21);
            comboBoxCharacterArmor.Name = "comboBoxCharacterArmor";
            comboBoxCharacterArmor.Size = new Size(211, 23);
            comboBoxCharacterArmor.TabIndex = 8;
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
            buttonCharacterWeaponChangeMateria.Location = new Point(6, 99);
            buttonCharacterWeaponChangeMateria.Name = "buttonCharacterWeaponChangeMateria";
            buttonCharacterWeaponChangeMateria.Size = new Size(211, 23);
            buttonCharacterWeaponChangeMateria.TabIndex = 16;
            buttonCharacterWeaponChangeMateria.Text = "Change selected materia...";
            buttonCharacterWeaponChangeMateria.UseVisualStyleBackColor = true;
            // 
            // materiaSlotSelectorCharacterWeapon
            // 
            materiaSlotSelectorCharacterWeapon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materiaSlotSelectorCharacterWeapon.BackColor = Color.LightSlateGray;
            materiaSlotSelectorCharacterWeapon.BorderStyle = BorderStyle.Fixed3D;
            materiaSlotSelectorCharacterWeapon.GrowthRate = Shojy.FF7.Elena.Equipment.GrowthRate.None;
            materiaSlotSelectorCharacterWeapon.Location = new Point(6, 58);
            materiaSlotSelectorCharacterWeapon.Name = "materiaSlotSelectorCharacterWeapon";
            materiaSlotSelectorCharacterWeapon.SelectedSlot = -1;
            materiaSlotSelectorCharacterWeapon.Size = new Size(211, 35);
            materiaSlotSelectorCharacterWeapon.SlotSelectorType = Shared.Controls.SlotSelectorType.Slots;
            materiaSlotSelectorCharacterWeapon.TabIndex = 15;
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
            // 
            // characterStatsControl
            // 
            characterStatsControl.Location = new Point(7, 104);
            characterStatsControl.Name = "characterStatsControl";
            characterStatsControl.Size = new Size(146, 295);
            characterStatsControl.TabIndex = 14;
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
            tabPageNames.Size = new Size(776, 573);
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
            tabPageShopData.Size = new Size(776, 573);
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
            groupBoxShopInventory.Size = new Size(352, 491);
            groupBoxShopInventory.TabIndex = 10;
            groupBoxShopInventory.TabStop = false;
            groupBoxShopInventory.Text = "Shop inventories";
            // 
            // comboBoxShopItem10
            // 
            comboBoxShopItem10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxShopItem10.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShopItem10.FormattingEnabled = true;
            comboBoxShopItem10.Location = new Point(6, 462);
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
            comboBoxShopItem9.Location = new Point(6, 433);
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
            comboBoxShopItem8.Location = new Point(6, 404);
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
            comboBoxShopItem7.Location = new Point(6, 375);
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
            comboBoxShopItem6.Location = new Point(6, 346);
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
            comboBoxShopItem5.Location = new Point(6, 317);
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
            comboBoxShopItem4.Location = new Point(6, 288);
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
            comboBoxShopItem3.Location = new Point(6, 259);
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
            comboBoxShopItem2.Location = new Point(6, 230);
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
            comboBoxShopItem1.Location = new Point(6, 201);
            comboBoxShopItem1.Name = "comboBoxShopItem1";
            comboBoxShopItem1.Size = new Size(340, 23);
            comboBoxShopItem1.TabIndex = 7;
            comboBoxShopItem1.SelectedIndexChanged += comboBoxShopItem_SelectedIndexChanged;
            // 
            // labelShopItems
            // 
            labelShopItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelShopItems.AutoSize = true;
            labelShopItems.Location = new Point(6, 183);
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
            labelShopType.Size = new Size(63, 15);
            labelShopType.TabIndex = 2;
            labelShopType.Text = "Shop type:";
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
            numericMateriaPrice.Location = new Point(251, 502);
            numericMateriaPrice.Name = "numericMateriaPrice";
            numericMateriaPrice.Size = new Size(158, 23);
            numericMateriaPrice.TabIndex = 9;
            numericMateriaPrice.ValueChanged += numericMateriaPrice_ValueChanged;
            // 
            // labelMateriaPrice
            // 
            labelMateriaPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelMateriaPrice.AutoSize = true;
            labelMateriaPrice.Location = new Point(209, 504);
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
            listBoxMateriaPrices.ItemHeight = 15;
            listBoxMateriaPrices.Location = new Point(209, 23);
            listBoxMateriaPrices.Name = "listBoxMateriaPrices";
            listBoxMateriaPrices.Size = new Size(200, 469);
            listBoxMateriaPrices.TabIndex = 6;
            listBoxMateriaPrices.SelectedIndexChanged += listBoxMateriaPrices_SelectedIndexChanged;
            // 
            // numericMateriaAPPriceMultiplier
            // 
            numericMateriaAPPriceMultiplier.Location = new Point(646, 502);
            numericMateriaAPPriceMultiplier.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericMateriaAPPriceMultiplier.Name = "numericMateriaAPPriceMultiplier";
            numericMateriaAPPriceMultiplier.Size = new Size(120, 23);
            numericMateriaAPPriceMultiplier.TabIndex = 5;
            // 
            // labelMateriaAPPriceMultiplier
            // 
            labelMateriaAPPriceMultiplier.AutoSize = true;
            labelMateriaAPPriceMultiplier.Location = new Point(489, 504);
            labelMateriaAPPriceMultiplier.Name = "labelMateriaAPPriceMultiplier";
            labelMateriaAPPriceMultiplier.Size = new Size(151, 15);
            labelMateriaAPPriceMultiplier.TabIndex = 4;
            labelMateriaAPPriceMultiplier.Text = "Materia AP price multiplier:";
            // 
            // numericItemPrice
            // 
            numericItemPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numericItemPrice.Enabled = false;
            numericItemPrice.Location = new Point(45, 502);
            numericItemPrice.Name = "numericItemPrice";
            numericItemPrice.Size = new Size(158, 23);
            numericItemPrice.TabIndex = 3;
            numericItemPrice.ValueChanged += numericItemPrice_ValueChanged;
            // 
            // labelItemPrice
            // 
            labelItemPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelItemPrice.AutoSize = true;
            labelItemPrice.Location = new Point(3, 504);
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
            listBoxItemPrices.ItemHeight = 15;
            listBoxItemPrices.Location = new Point(3, 23);
            listBoxItemPrices.Name = "listBoxItemPrices";
            listBoxItemPrices.Size = new Size(200, 469);
            listBoxItemPrices.TabIndex = 0;
            listBoxItemPrices.SelectedIndexChanged += listBoxItemPrices_SelectedIndexChanged;
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
            Controls.Add(panelButtons);
            Controls.Add(tabControlMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(800, 600);
            Name = "ExeEditorForm";
            Text = "Scarlet - EXE Editor";
            MouseMove += MainForm_MouseMove;
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
        private ToolTip toolTip;
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
        private Label label1;
    }
}

