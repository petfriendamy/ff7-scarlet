namespace FF7Scarlet.SceneEditor
{
    partial class SceneEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneEditorForm));
            labelScenes = new Label();
            comboBoxSceneList = new ComboBox();
            tabControlMain = new TabControl();
            tabPageEnemyData = new TabPage();
            tabControlEnemyData = new TabControl();
            tabPageEnemyPage1 = new TabPage();
            statusesControlEnemyImmunities = new KernelEditor.Controls.StatusesControl();
            groupBoxEnemyElementResistances = new GroupBox();
            comboBoxEnemyResistRate = new ComboBox();
            labelEnemyResistRate = new Label();
            comboBoxEnemyResistElement = new ComboBox();
            labelEnemyResistElement = new Label();
            listBoxElementResistances = new ListBox();
            groupBoxEnemyReward = new GroupBox();
            labelEnemyEXP = new Label();
            numericEnemyEXP = new NumericUpDown();
            numericEnemyGil = new NumericUpDown();
            labelEnemyAP = new Label();
            labelEnemyGil = new Label();
            numericEnemyAP = new NumericUpDown();
            groupBoxEnemyStats = new GroupBox();
            numericEnemyLevel = new NumericUpDown();
            labelEnemyLevel = new Label();
            numericEnemyStrength = new NumericUpDown();
            labelEnemyStrength = new Label();
            labelEnemyDefense = new Label();
            numericEnemyMP = new NumericUpDown();
            labelEnemyMP = new Label();
            numericEnemyDefense = new NumericUpDown();
            labelEnemyHP = new Label();
            labelEnemyMagic = new Label();
            numericEnemyHP = new NumericUpDown();
            numericEnemySpeed = new NumericUpDown();
            numericEnemyMagic = new NumericUpDown();
            labelEnemySpeed = new Label();
            labelEnemyMDef = new Label();
            numericEnemyEvade = new NumericUpDown();
            numericEnemyMDef = new NumericUpDown();
            labelEnemyEvade = new Label();
            numericEnemyLuck = new NumericUpDown();
            labelEnemyLuck = new Label();
            textBoxEnemyName = new TextBox();
            labelEnemyName = new Label();
            tabPageEnemyPage2 = new TabPage();
            comboBoxEnemyMorphItem = new ComboBox();
            labelEnemyMorphItem = new Label();
            groupBoxEnemyItemDropRates = new GroupBox();
            checkBoxEnemyItemIsSteal = new CheckBox();
            numericEnemyDropRate = new NumericUpDown();
            labelEnemyItemDropRate = new Label();
            comboBoxEnemyDropItemID = new ComboBox();
            labelEnemyDropItem = new Label();
            listBoxEnemyItemDropRates = new ListBox();
            groupBoxEnemyAttacks = new GroupBox();
            numericAttackAnimationIndex = new NumericUpDown();
            labelEnemyAttackAnimationIndex = new Label();
            checkBoxEnemyAttackIsManipable = new CheckBox();
            comboBoxEnemyAttackCamID = new ComboBox();
            labelEnemyAttackCamID = new Label();
            comboBoxEnemyAttackID = new ComboBox();
            labelEnemyAttackID = new Label();
            listBoxEnemyAttacks = new ListBox();
            numericEnemyBackDamageMultiplier = new NumericUpDown();
            labelEnemyBackDamageMultiplier = new Label();
            tabPageEnemyAI = new TabPage();
            scriptControlEnemyAI = new AIEditor.ScriptControl();
            labelEnemyScripts = new Label();
            listBoxEnemyScripts = new ListBox();
            tabPageAttackData = new TabPage();
            tabControlAttackData = new TabControl();
            tabPageAttackPage1 = new TabPage();
            textBoxAttackID = new TextBox();
            labelAttackID = new Label();
            elementsControlAttack = new KernelEditor.Controls.ElementsControl();
            damageCalculationControlAttack = new KernelEditor.Controls.DamageCalculationControl();
            labelAttackHurtActionIndex = new Label();
            comboBoxAttackHurtActionIndex = new ComboBox();
            labelAttackAttackEffectID = new Label();
            comboBoxAttackAttackEffectID = new ComboBox();
            labelAttackImpactEffectID = new Label();
            comboBoxAttackImpactEffectID = new ComboBox();
            labelAttackCamMovementIDMulti = new Label();
            comboBoxAttackCamMovementIDMulti = new ComboBox();
            labelAttackCamMovementIDSingle = new Label();
            comboBoxAttackCamMovementIDSingle = new ComboBox();
            numericAttackAttackPercent = new NumericUpDown();
            labelAttackAttackPercent = new Label();
            labelAttackMPCost = new Label();
            numericAttackMPCost = new NumericUpDown();
            labelAttackName = new Label();
            textBoxAttackName = new TextBox();
            tabPageAttackPage2 = new TabPage();
            numericAttackStatusChangeChance = new NumericUpDown();
            comboBoxAttackConditionSubMenu = new ComboBox();
            labelAttackStatusChangeChance = new Label();
            comboBoxAttackStatusChange = new ComboBox();
            labelAttackConditionSubMenu = new Label();
            labelAttackStatusChange = new Label();
            statusesControlAttack = new KernelEditor.Controls.StatusesControl();
            specialAttackFlagsControlAttack = new Shared.SpecialAttackFlagsControl();
            listBoxAttacks = new ListBox();
            tabPageFormationData = new TabPage();
            tabControlFormationData = new TabControl();
            tabPageFormation1 = new TabPage();
            tabPageFormationAI = new TabPage();
            scriptControlFormations = new AIEditor.ScriptControl();
            labelFormationScripts = new Label();
            listBoxFormationScripts = new ListBox();
            panelTop = new Panel();
            buttonSearch = new Button();
            comboBoxFormation = new ComboBox();
            labelFormation = new Label();
            comboBoxEnemy = new ComboBox();
            labelEnemy = new Label();
            panelBottom = new Panel();
            progressBarSaving = new ProgressBar();
            buttonExport = new Button();
            buttonImport = new Button();
            buttonSave = new Button();
            tabControlMain.SuspendLayout();
            tabPageEnemyData.SuspendLayout();
            tabControlEnemyData.SuspendLayout();
            tabPageEnemyPage1.SuspendLayout();
            groupBoxEnemyElementResistances.SuspendLayout();
            groupBoxEnemyReward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericEnemyEXP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyGil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyAP).BeginInit();
            groupBoxEnemyStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericEnemyLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyStrength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyMP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyDefense).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyHP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemySpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyMagic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyEvade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyMDef).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyLuck).BeginInit();
            tabPageEnemyPage2.SuspendLayout();
            groupBoxEnemyItemDropRates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericEnemyDropRate).BeginInit();
            groupBoxEnemyAttacks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackAnimationIndex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyBackDamageMultiplier).BeginInit();
            tabPageEnemyAI.SuspendLayout();
            tabPageAttackData.SuspendLayout();
            tabControlAttackData.SuspendLayout();
            tabPageAttackPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackAttackPercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAttackMPCost).BeginInit();
            tabPageAttackPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackStatusChangeChance).BeginInit();
            tabPageFormationData.SuspendLayout();
            tabControlFormationData.SuspendLayout();
            tabPageFormationAI.SuspendLayout();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // labelScenes
            // 
            labelScenes.AutoSize = true;
            labelScenes.Location = new Point(13, 14);
            labelScenes.Margin = new Padding(4, 0, 4, 0);
            labelScenes.Name = "labelScenes";
            labelScenes.Size = new Size(46, 15);
            labelScenes.TabIndex = 9;
            labelScenes.Text = "Scenes:";
            // 
            // comboBoxSceneList
            // 
            comboBoxSceneList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxSceneList.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSceneList.FormattingEnabled = true;
            comboBoxSceneList.Location = new Point(67, 11);
            comboBoxSceneList.Margin = new Padding(4, 3, 4, 3);
            comboBoxSceneList.Name = "comboBoxSceneList";
            comboBoxSceneList.Size = new Size(704, 23);
            comboBoxSceneList.TabIndex = 8;
            comboBoxSceneList.SelectedIndexChanged += comboBoxSceneList_SelectedIndexChanged;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageEnemyData);
            tabControlMain.Controls.Add(tabPageAttackData);
            tabControlMain.Controls.Add(tabPageFormationData);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 73);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(784, 483);
            tabControlMain.TabIndex = 10;
            // 
            // tabPageEnemyData
            // 
            tabPageEnemyData.Controls.Add(tabControlEnemyData);
            tabPageEnemyData.Location = new Point(4, 24);
            tabPageEnemyData.Name = "tabPageEnemyData";
            tabPageEnemyData.Size = new Size(776, 455);
            tabPageEnemyData.TabIndex = 6;
            tabPageEnemyData.Text = "Enemy Data";
            tabPageEnemyData.UseVisualStyleBackColor = true;
            // 
            // tabControlEnemyData
            // 
            tabControlEnemyData.Controls.Add(tabPageEnemyPage1);
            tabControlEnemyData.Controls.Add(tabPageEnemyPage2);
            tabControlEnemyData.Controls.Add(tabPageEnemyAI);
            tabControlEnemyData.Dock = DockStyle.Fill;
            tabControlEnemyData.Location = new Point(0, 0);
            tabControlEnemyData.Name = "tabControlEnemyData";
            tabControlEnemyData.SelectedIndex = 0;
            tabControlEnemyData.Size = new Size(776, 455);
            tabControlEnemyData.TabIndex = 0;
            // 
            // tabPageEnemyPage1
            // 
            tabPageEnemyPage1.Controls.Add(statusesControlEnemyImmunities);
            tabPageEnemyPage1.Controls.Add(groupBoxEnemyElementResistances);
            tabPageEnemyPage1.Controls.Add(groupBoxEnemyReward);
            tabPageEnemyPage1.Controls.Add(groupBoxEnemyStats);
            tabPageEnemyPage1.Controls.Add(textBoxEnemyName);
            tabPageEnemyPage1.Controls.Add(labelEnemyName);
            tabPageEnemyPage1.Location = new Point(4, 24);
            tabPageEnemyPage1.Name = "tabPageEnemyPage1";
            tabPageEnemyPage1.Padding = new Padding(3);
            tabPageEnemyPage1.Size = new Size(768, 427);
            tabPageEnemyPage1.TabIndex = 0;
            tabPageEnemyPage1.Text = "Page 1";
            tabPageEnemyPage1.UseVisualStyleBackColor = true;
            // 
            // statusesControlEnemyImmunities
            // 
            statusesControlEnemyImmunities.FullList = true;
            statusesControlEnemyImmunities.GroupBoxText = "Status immunities";
            statusesControlEnemyImmunities.Location = new Point(267, 170);
            statusesControlEnemyImmunities.MinimumSize = new Size(380, 200);
            statusesControlEnemyImmunities.Name = "statusesControlEnemyImmunities";
            statusesControlEnemyImmunities.Size = new Size(494, 210);
            statusesControlEnemyImmunities.TabIndex = 43;
            // 
            // groupBoxEnemyElementResistances
            // 
            groupBoxEnemyElementResistances.Controls.Add(comboBoxEnemyResistRate);
            groupBoxEnemyElementResistances.Controls.Add(labelEnemyResistRate);
            groupBoxEnemyElementResistances.Controls.Add(comboBoxEnemyResistElement);
            groupBoxEnemyElementResistances.Controls.Add(labelEnemyResistElement);
            groupBoxEnemyElementResistances.Controls.Add(listBoxElementResistances);
            groupBoxEnemyElementResistances.Location = new Point(267, 8);
            groupBoxEnemyElementResistances.Name = "groupBoxEnemyElementResistances";
            groupBoxEnemyElementResistances.Size = new Size(494, 156);
            groupBoxEnemyElementResistances.TabIndex = 42;
            groupBoxEnemyElementResistances.TabStop = false;
            groupBoxEnemyElementResistances.Text = "Element rates";
            // 
            // comboBoxEnemyResistRate
            // 
            comboBoxEnemyResistRate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxEnemyResistRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnemyResistRate.Enabled = false;
            comboBoxEnemyResistRate.FormattingEnabled = true;
            comboBoxEnemyResistRate.Location = new Point(334, 84);
            comboBoxEnemyResistRate.Name = "comboBoxEnemyResistRate";
            comboBoxEnemyResistRate.Size = new Size(154, 23);
            comboBoxEnemyResistRate.TabIndex = 45;
            // 
            // labelEnemyResistRate
            // 
            labelEnemyResistRate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEnemyResistRate.AutoSize = true;
            labelEnemyResistRate.Location = new Point(334, 66);
            labelEnemyResistRate.Name = "labelEnemyResistRate";
            labelEnemyResistRate.Size = new Size(33, 15);
            labelEnemyResistRate.TabIndex = 44;
            labelEnemyResistRate.Text = "Rate:";
            // 
            // comboBoxEnemyResistElement
            // 
            comboBoxEnemyResistElement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxEnemyResistElement.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnemyResistElement.Enabled = false;
            comboBoxEnemyResistElement.FormattingEnabled = true;
            comboBoxEnemyResistElement.Location = new Point(334, 40);
            comboBoxEnemyResistElement.Name = "comboBoxEnemyResistElement";
            comboBoxEnemyResistElement.Size = new Size(154, 23);
            comboBoxEnemyResistElement.TabIndex = 43;
            // 
            // labelEnemyResistElement
            // 
            labelEnemyResistElement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEnemyResistElement.AutoSize = true;
            labelEnemyResistElement.Location = new Point(334, 22);
            labelEnemyResistElement.Name = "labelEnemyResistElement";
            labelEnemyResistElement.Size = new Size(53, 15);
            labelEnemyResistElement.TabIndex = 42;
            labelEnemyResistElement.Text = "Element:";
            // 
            // listBoxElementResistances
            // 
            listBoxElementResistances.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxElementResistances.FormattingEnabled = true;
            listBoxElementResistances.ItemHeight = 15;
            listBoxElementResistances.Location = new Point(6, 22);
            listBoxElementResistances.Name = "listBoxElementResistances";
            listBoxElementResistances.Size = new Size(322, 124);
            listBoxElementResistances.TabIndex = 41;
            listBoxElementResistances.SelectedIndexChanged += listBoxElementResistances_SelectedIndexChanged;
            // 
            // groupBoxEnemyReward
            // 
            groupBoxEnemyReward.Controls.Add(labelEnemyEXP);
            groupBoxEnemyReward.Controls.Add(numericEnemyEXP);
            groupBoxEnemyReward.Controls.Add(numericEnemyGil);
            groupBoxEnemyReward.Controls.Add(labelEnemyAP);
            groupBoxEnemyReward.Controls.Add(labelEnemyGil);
            groupBoxEnemyReward.Controls.Add(numericEnemyAP);
            groupBoxEnemyReward.Location = new Point(9, 226);
            groupBoxEnemyReward.Name = "groupBoxEnemyReward";
            groupBoxEnemyReward.Size = new Size(252, 154);
            groupBoxEnemyReward.TabIndex = 40;
            groupBoxEnemyReward.TabStop = false;
            groupBoxEnemyReward.Text = "Reward for defeat";
            // 
            // labelEnemyEXP
            // 
            labelEnemyEXP.AutoSize = true;
            labelEnemyEXP.Location = new Point(6, 21);
            labelEnemyEXP.Name = "labelEnemyEXP";
            labelEnemyEXP.Size = new Size(30, 15);
            labelEnemyEXP.TabIndex = 33;
            labelEnemyEXP.Text = "EXP:";
            // 
            // numericEnemyEXP
            // 
            numericEnemyEXP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericEnemyEXP.Location = new Point(6, 39);
            numericEnemyEXP.Name = "numericEnemyEXP";
            numericEnemyEXP.Size = new Size(113, 23);
            numericEnemyEXP.TabIndex = 34;
            // 
            // numericEnemyGil
            // 
            numericEnemyGil.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericEnemyGil.Location = new Point(6, 83);
            numericEnemyGil.Name = "numericEnemyGil";
            numericEnemyGil.Size = new Size(232, 23);
            numericEnemyGil.TabIndex = 38;
            // 
            // labelEnemyAP
            // 
            labelEnemyAP.AutoSize = true;
            labelEnemyAP.Location = new Point(125, 21);
            labelEnemyAP.Name = "labelEnemyAP";
            labelEnemyAP.Size = new Size(25, 15);
            labelEnemyAP.TabIndex = 35;
            labelEnemyAP.Text = "AP:";
            // 
            // labelEnemyGil
            // 
            labelEnemyGil.AutoSize = true;
            labelEnemyGil.Location = new Point(6, 65);
            labelEnemyGil.Name = "labelEnemyGil";
            labelEnemyGil.Size = new Size(24, 15);
            labelEnemyGil.TabIndex = 37;
            labelEnemyGil.Text = "Gil:";
            // 
            // numericEnemyAP
            // 
            numericEnemyAP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericEnemyAP.Location = new Point(125, 39);
            numericEnemyAP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericEnemyAP.Name = "numericEnemyAP";
            numericEnemyAP.Size = new Size(113, 23);
            numericEnemyAP.TabIndex = 36;
            // 
            // groupBoxEnemyStats
            // 
            groupBoxEnemyStats.Controls.Add(numericEnemyLevel);
            groupBoxEnemyStats.Controls.Add(labelEnemyLevel);
            groupBoxEnemyStats.Controls.Add(numericEnemyStrength);
            groupBoxEnemyStats.Controls.Add(labelEnemyStrength);
            groupBoxEnemyStats.Controls.Add(labelEnemyDefense);
            groupBoxEnemyStats.Controls.Add(numericEnemyMP);
            groupBoxEnemyStats.Controls.Add(labelEnemyMP);
            groupBoxEnemyStats.Controls.Add(numericEnemyDefense);
            groupBoxEnemyStats.Controls.Add(labelEnemyHP);
            groupBoxEnemyStats.Controls.Add(labelEnemyMagic);
            groupBoxEnemyStats.Controls.Add(numericEnemyHP);
            groupBoxEnemyStats.Controls.Add(numericEnemySpeed);
            groupBoxEnemyStats.Controls.Add(numericEnemyMagic);
            groupBoxEnemyStats.Controls.Add(labelEnemySpeed);
            groupBoxEnemyStats.Controls.Add(labelEnemyMDef);
            groupBoxEnemyStats.Controls.Add(numericEnemyEvade);
            groupBoxEnemyStats.Controls.Add(numericEnemyMDef);
            groupBoxEnemyStats.Controls.Add(labelEnemyEvade);
            groupBoxEnemyStats.Controls.Add(numericEnemyLuck);
            groupBoxEnemyStats.Controls.Add(labelEnemyLuck);
            groupBoxEnemyStats.Location = new Point(9, 56);
            groupBoxEnemyStats.Name = "groupBoxEnemyStats";
            groupBoxEnemyStats.Size = new Size(252, 164);
            groupBoxEnemyStats.TabIndex = 39;
            groupBoxEnemyStats.TabStop = false;
            groupBoxEnemyStats.Text = "Stats";
            // 
            // numericEnemyLevel
            // 
            numericEnemyLevel.Location = new Point(6, 39);
            numericEnemyLevel.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericEnemyLevel.Name = "numericEnemyLevel";
            numericEnemyLevel.Size = new Size(55, 23);
            numericEnemyLevel.TabIndex = 14;
            numericEnemyLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelEnemyLevel
            // 
            labelEnemyLevel.AutoSize = true;
            labelEnemyLevel.Location = new Point(6, 19);
            labelEnemyLevel.Name = "labelEnemyLevel";
            labelEnemyLevel.Size = new Size(37, 15);
            labelEnemyLevel.TabIndex = 13;
            labelEnemyLevel.Text = "Level:";
            // 
            // numericEnemyStrength
            // 
            numericEnemyStrength.Location = new Point(6, 85);
            numericEnemyStrength.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemyStrength.Name = "numericEnemyStrength";
            numericEnemyStrength.Size = new Size(55, 23);
            numericEnemyStrength.TabIndex = 20;
            // 
            // labelEnemyStrength
            // 
            labelEnemyStrength.AutoSize = true;
            labelEnemyStrength.Location = new Point(6, 65);
            labelEnemyStrength.Name = "labelEnemyStrength";
            labelEnemyStrength.Size = new Size(55, 15);
            labelEnemyStrength.TabIndex = 19;
            labelEnemyStrength.Text = "Strength:";
            // 
            // labelEnemyDefense
            // 
            labelEnemyDefense.AutoSize = true;
            labelEnemyDefense.Location = new Point(67, 65);
            labelEnemyDefense.Name = "labelEnemyDefense";
            labelEnemyDefense.Size = new Size(52, 15);
            labelEnemyDefense.TabIndex = 21;
            labelEnemyDefense.Text = "Defense:";
            // 
            // numericEnemyMP
            // 
            numericEnemyMP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericEnemyMP.Location = new Point(161, 39);
            numericEnemyMP.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericEnemyMP.Name = "numericEnemyMP";
            numericEnemyMP.Size = new Size(77, 23);
            numericEnemyMP.TabIndex = 18;
            // 
            // labelEnemyMP
            // 
            labelEnemyMP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEnemyMP.AutoSize = true;
            labelEnemyMP.Location = new Point(161, 18);
            labelEnemyMP.Name = "labelEnemyMP";
            labelEnemyMP.Size = new Size(28, 15);
            labelEnemyMP.TabIndex = 17;
            labelEnemyMP.Text = "MP:";
            // 
            // numericEnemyDefense
            // 
            numericEnemyDefense.Location = new Point(67, 85);
            numericEnemyDefense.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemyDefense.Name = "numericEnemyDefense";
            numericEnemyDefense.Size = new Size(52, 23);
            numericEnemyDefense.TabIndex = 22;
            // 
            // labelEnemyHP
            // 
            labelEnemyHP.AutoSize = true;
            labelEnemyHP.Location = new Point(67, 19);
            labelEnemyHP.Name = "labelEnemyHP";
            labelEnemyHP.Size = new Size(26, 15);
            labelEnemyHP.TabIndex = 15;
            labelEnemyHP.Text = "HP:";
            // 
            // labelEnemyMagic
            // 
            labelEnemyMagic.AutoSize = true;
            labelEnemyMagic.Location = new Point(125, 65);
            labelEnemyMagic.Name = "labelEnemyMagic";
            labelEnemyMagic.Size = new Size(43, 15);
            labelEnemyMagic.TabIndex = 23;
            labelEnemyMagic.Text = "Magic:";
            // 
            // numericEnemyHP
            // 
            numericEnemyHP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericEnemyHP.Location = new Point(67, 39);
            numericEnemyHP.Name = "numericEnemyHP";
            numericEnemyHP.Size = new Size(88, 23);
            numericEnemyHP.TabIndex = 16;
            // 
            // numericEnemySpeed
            // 
            numericEnemySpeed.Location = new Point(6, 131);
            numericEnemySpeed.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemySpeed.Name = "numericEnemySpeed";
            numericEnemySpeed.Size = new Size(55, 23);
            numericEnemySpeed.TabIndex = 32;
            // 
            // numericEnemyMagic
            // 
            numericEnemyMagic.Location = new Point(125, 85);
            numericEnemyMagic.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemyMagic.Name = "numericEnemyMagic";
            numericEnemyMagic.Size = new Size(55, 23);
            numericEnemyMagic.TabIndex = 24;
            // 
            // labelEnemySpeed
            // 
            labelEnemySpeed.AutoSize = true;
            labelEnemySpeed.Location = new Point(6, 111);
            labelEnemySpeed.Name = "labelEnemySpeed";
            labelEnemySpeed.Size = new Size(42, 15);
            labelEnemySpeed.TabIndex = 31;
            labelEnemySpeed.Text = "Speed:";
            // 
            // labelEnemyMDef
            // 
            labelEnemyMDef.AutoSize = true;
            labelEnemyMDef.Location = new Point(186, 65);
            labelEnemyMDef.Name = "labelEnemyMDef";
            labelEnemyMDef.Size = new Size(42, 15);
            labelEnemyMDef.TabIndex = 25;
            labelEnemyMDef.Text = "M.Def:";
            // 
            // numericEnemyEvade
            // 
            numericEnemyEvade.Location = new Point(67, 131);
            numericEnemyEvade.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemyEvade.Name = "numericEnemyEvade";
            numericEnemyEvade.Size = new Size(52, 23);
            numericEnemyEvade.TabIndex = 30;
            // 
            // numericEnemyMDef
            // 
            numericEnemyMDef.Location = new Point(186, 85);
            numericEnemyMDef.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemyMDef.Name = "numericEnemyMDef";
            numericEnemyMDef.Size = new Size(52, 23);
            numericEnemyMDef.TabIndex = 26;
            // 
            // labelEnemyEvade
            // 
            labelEnemyEvade.AutoSize = true;
            labelEnemyEvade.Location = new Point(67, 111);
            labelEnemyEvade.Name = "labelEnemyEvade";
            labelEnemyEvade.Size = new Size(41, 15);
            labelEnemyEvade.TabIndex = 27;
            labelEnemyEvade.Text = "Evade:";
            // 
            // numericEnemyLuck
            // 
            numericEnemyLuck.Location = new Point(125, 131);
            numericEnemyLuck.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemyLuck.Name = "numericEnemyLuck";
            numericEnemyLuck.Size = new Size(55, 23);
            numericEnemyLuck.TabIndex = 28;
            // 
            // labelEnemyLuck
            // 
            labelEnemyLuck.AutoSize = true;
            labelEnemyLuck.Location = new Point(125, 111);
            labelEnemyLuck.Name = "labelEnemyLuck";
            labelEnemyLuck.Size = new Size(35, 15);
            labelEnemyLuck.TabIndex = 29;
            labelEnemyLuck.Text = "Luck:";
            // 
            // textBoxEnemyName
            // 
            textBoxEnemyName.Location = new Point(9, 26);
            textBoxEnemyName.MaxLength = 32;
            textBoxEnemyName.Name = "textBoxEnemyName";
            textBoxEnemyName.Size = new Size(252, 23);
            textBoxEnemyName.TabIndex = 4;
            // 
            // labelEnemyName
            // 
            labelEnemyName.AutoSize = true;
            labelEnemyName.Location = new Point(9, 8);
            labelEnemyName.Name = "labelEnemyName";
            labelEnemyName.Size = new Size(42, 15);
            labelEnemyName.TabIndex = 3;
            labelEnemyName.Text = "Name:";
            // 
            // tabPageEnemyPage2
            // 
            tabPageEnemyPage2.Controls.Add(comboBoxEnemyMorphItem);
            tabPageEnemyPage2.Controls.Add(labelEnemyMorphItem);
            tabPageEnemyPage2.Controls.Add(groupBoxEnemyItemDropRates);
            tabPageEnemyPage2.Controls.Add(groupBoxEnemyAttacks);
            tabPageEnemyPage2.Controls.Add(numericEnemyBackDamageMultiplier);
            tabPageEnemyPage2.Controls.Add(labelEnemyBackDamageMultiplier);
            tabPageEnemyPage2.Location = new Point(4, 24);
            tabPageEnemyPage2.Name = "tabPageEnemyPage2";
            tabPageEnemyPage2.Size = new Size(768, 427);
            tabPageEnemyPage2.TabIndex = 5;
            tabPageEnemyPage2.Text = "Page 2";
            tabPageEnemyPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxEnemyMorphItem
            // 
            comboBoxEnemyMorphItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxEnemyMorphItem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnemyMorphItem.FormattingEnabled = true;
            comboBoxEnemyMorphItem.Location = new Point(378, 169);
            comboBoxEnemyMorphItem.Name = "comboBoxEnemyMorphItem";
            comboBoxEnemyMorphItem.Size = new Size(381, 23);
            comboBoxEnemyMorphItem.TabIndex = 48;
            // 
            // labelEnemyMorphItem
            // 
            labelEnemyMorphItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEnemyMorphItem.AutoSize = true;
            labelEnemyMorphItem.Location = new Point(378, 151);
            labelEnemyMorphItem.Name = "labelEnemyMorphItem";
            labelEnemyMorphItem.Size = new Size(73, 15);
            labelEnemyMorphItem.TabIndex = 47;
            labelEnemyMorphItem.Text = "Morph item:";
            // 
            // groupBoxEnemyItemDropRates
            // 
            groupBoxEnemyItemDropRates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxEnemyItemDropRates.Controls.Add(checkBoxEnemyItemIsSteal);
            groupBoxEnemyItemDropRates.Controls.Add(numericEnemyDropRate);
            groupBoxEnemyItemDropRates.Controls.Add(labelEnemyItemDropRate);
            groupBoxEnemyItemDropRates.Controls.Add(comboBoxEnemyDropItemID);
            groupBoxEnemyItemDropRates.Controls.Add(labelEnemyDropItem);
            groupBoxEnemyItemDropRates.Controls.Add(listBoxEnemyItemDropRates);
            groupBoxEnemyItemDropRates.Location = new Point(378, 8);
            groupBoxEnemyItemDropRates.Name = "groupBoxEnemyItemDropRates";
            groupBoxEnemyItemDropRates.Size = new Size(381, 140);
            groupBoxEnemyItemDropRates.TabIndex = 46;
            groupBoxEnemyItemDropRates.TabStop = false;
            groupBoxEnemyItemDropRates.Text = "Item drop/steal rates";
            // 
            // checkBoxEnemyItemIsSteal
            // 
            checkBoxEnemyItemIsSteal.AutoSize = true;
            checkBoxEnemyItemIsSteal.Location = new Point(324, 109);
            checkBoxEnemyItemIsSteal.Name = "checkBoxEnemyItemIsSteal";
            checkBoxEnemyItemIsSteal.Size = new Size(51, 19);
            checkBoxEnemyItemIsSteal.TabIndex = 7;
            checkBoxEnemyItemIsSteal.Text = "Steal";
            checkBoxEnemyItemIsSteal.UseVisualStyleBackColor = true;
            // 
            // numericEnemyDropRate
            // 
            numericEnemyDropRate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericEnemyDropRate.Location = new Point(251, 108);
            numericEnemyDropRate.Maximum = new decimal(new int[] { 63, 0, 0, 0 });
            numericEnemyDropRate.Name = "numericEnemyDropRate";
            numericEnemyDropRate.Size = new Size(67, 23);
            numericEnemyDropRate.TabIndex = 6;
            // 
            // labelEnemyItemDropRate
            // 
            labelEnemyItemDropRate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEnemyItemDropRate.AutoSize = true;
            labelEnemyItemDropRate.Location = new Point(251, 90);
            labelEnemyItemDropRate.Name = "labelEnemyItemDropRate";
            labelEnemyItemDropRate.Size = new Size(67, 15);
            labelEnemyItemDropRate.TabIndex = 5;
            labelEnemyItemDropRate.Text = "Rate (x/63):";
            // 
            // comboBoxEnemyDropItemID
            // 
            comboBoxEnemyDropItemID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxEnemyDropItemID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnemyDropItemID.FormattingEnabled = true;
            comboBoxEnemyDropItemID.Location = new Point(6, 107);
            comboBoxEnemyDropItemID.Name = "comboBoxEnemyDropItemID";
            comboBoxEnemyDropItemID.Size = new Size(239, 23);
            comboBoxEnemyDropItemID.TabIndex = 2;
            // 
            // labelEnemyDropItem
            // 
            labelEnemyDropItem.AutoSize = true;
            labelEnemyDropItem.Location = new Point(6, 89);
            labelEnemyDropItem.Name = "labelEnemyDropItem";
            labelEnemyDropItem.Size = new Size(34, 15);
            labelEnemyDropItem.TabIndex = 1;
            labelEnemyDropItem.Text = "Item:";
            // 
            // listBoxEnemyItemDropRates
            // 
            listBoxEnemyItemDropRates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxEnemyItemDropRates.FormattingEnabled = true;
            listBoxEnemyItemDropRates.ItemHeight = 15;
            listBoxEnemyItemDropRates.Location = new Point(6, 22);
            listBoxEnemyItemDropRates.Name = "listBoxEnemyItemDropRates";
            listBoxEnemyItemDropRates.Size = new Size(369, 64);
            listBoxEnemyItemDropRates.TabIndex = 0;
            listBoxEnemyItemDropRates.SelectedIndexChanged += listBoxEnemyItemDropRates_SelectedIndexChanged;
            // 
            // groupBoxEnemyAttacks
            // 
            groupBoxEnemyAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxEnemyAttacks.Controls.Add(numericAttackAnimationIndex);
            groupBoxEnemyAttacks.Controls.Add(labelEnemyAttackAnimationIndex);
            groupBoxEnemyAttacks.Controls.Add(checkBoxEnemyAttackIsManipable);
            groupBoxEnemyAttacks.Controls.Add(comboBoxEnemyAttackCamID);
            groupBoxEnemyAttacks.Controls.Add(labelEnemyAttackCamID);
            groupBoxEnemyAttacks.Controls.Add(comboBoxEnemyAttackID);
            groupBoxEnemyAttacks.Controls.Add(labelEnemyAttackID);
            groupBoxEnemyAttacks.Controls.Add(listBoxEnemyAttacks);
            groupBoxEnemyAttacks.Location = new Point(9, 8);
            groupBoxEnemyAttacks.Name = "groupBoxEnemyAttacks";
            groupBoxEnemyAttacks.Size = new Size(363, 365);
            groupBoxEnemyAttacks.TabIndex = 45;
            groupBoxEnemyAttacks.TabStop = false;
            groupBoxEnemyAttacks.Text = "Attacks";
            // 
            // numericAttackAnimationIndex
            // 
            numericAttackAnimationIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericAttackAnimationIndex.Location = new Point(259, 287);
            numericAttackAnimationIndex.Name = "numericAttackAnimationIndex";
            numericAttackAnimationIndex.Size = new Size(98, 23);
            numericAttackAnimationIndex.TabIndex = 7;
            // 
            // labelEnemyAttackAnimationIndex
            // 
            labelEnemyAttackAnimationIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEnemyAttackAnimationIndex.AutoSize = true;
            labelEnemyAttackAnimationIndex.Location = new Point(259, 269);
            labelEnemyAttackAnimationIndex.Name = "labelEnemyAttackAnimationIndex";
            labelEnemyAttackAnimationIndex.Size = new Size(98, 15);
            labelEnemyAttackAnimationIndex.TabIndex = 6;
            labelEnemyAttackAnimationIndex.Text = "Animation index:";
            // 
            // checkBoxEnemyAttackIsManipable
            // 
            checkBoxEnemyAttackIsManipable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxEnemyAttackIsManipable.AutoSize = true;
            checkBoxEnemyAttackIsManipable.Location = new Point(224, 333);
            checkBoxEnemyAttackIsManipable.Name = "checkBoxEnemyAttackIsManipable";
            checkBoxEnemyAttackIsManipable.Size = new Size(133, 19);
            checkBoxEnemyAttackIsManipable.TabIndex = 5;
            checkBoxEnemyAttackIsManipable.Text = "Include in manip list";
            checkBoxEnemyAttackIsManipable.UseVisualStyleBackColor = true;
            // 
            // comboBoxEnemyAttackCamID
            // 
            comboBoxEnemyAttackCamID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxEnemyAttackCamID.FormattingEnabled = true;
            comboBoxEnemyAttackCamID.Location = new Point(6, 331);
            comboBoxEnemyAttackCamID.Name = "comboBoxEnemyAttackCamID";
            comboBoxEnemyAttackCamID.Size = new Size(212, 23);
            comboBoxEnemyAttackCamID.TabIndex = 4;
            // 
            // labelEnemyAttackCamID
            // 
            labelEnemyAttackCamID.AutoSize = true;
            labelEnemyAttackCamID.Location = new Point(6, 313);
            labelEnemyAttackCamID.Name = "labelEnemyAttackCamID";
            labelEnemyAttackCamID.Size = new Size(126, 15);
            labelEnemyAttackCamID.TabIndex = 3;
            labelEnemyAttackCamID.Text = "Camera movement ID:";
            // 
            // comboBoxEnemyAttackID
            // 
            comboBoxEnemyAttackID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxEnemyAttackID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnemyAttackID.FormattingEnabled = true;
            comboBoxEnemyAttackID.Location = new Point(6, 287);
            comboBoxEnemyAttackID.Name = "comboBoxEnemyAttackID";
            comboBoxEnemyAttackID.Size = new Size(247, 23);
            comboBoxEnemyAttackID.TabIndex = 2;
            // 
            // labelEnemyAttackID
            // 
            labelEnemyAttackID.AutoSize = true;
            labelEnemyAttackID.Location = new Point(6, 269);
            labelEnemyAttackID.Name = "labelEnemyAttackID";
            labelEnemyAttackID.Size = new Size(44, 15);
            labelEnemyAttackID.TabIndex = 1;
            labelEnemyAttackID.Text = "Attack:";
            // 
            // listBoxEnemyAttacks
            // 
            listBoxEnemyAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxEnemyAttacks.FormattingEnabled = true;
            listBoxEnemyAttacks.ItemHeight = 15;
            listBoxEnemyAttacks.Location = new Point(6, 22);
            listBoxEnemyAttacks.Name = "listBoxEnemyAttacks";
            listBoxEnemyAttacks.Size = new Size(351, 244);
            listBoxEnemyAttacks.TabIndex = 0;
            listBoxEnemyAttacks.SelectedIndexChanged += listBoxEnemyAttacks_SelectedIndexChanged;
            // 
            // numericEnemyBackDamageMultiplier
            // 
            numericEnemyBackDamageMultiplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericEnemyBackDamageMultiplier.Location = new Point(378, 213);
            numericEnemyBackDamageMultiplier.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemyBackDamageMultiplier.Name = "numericEnemyBackDamageMultiplier";
            numericEnemyBackDamageMultiplier.Size = new Size(135, 23);
            numericEnemyBackDamageMultiplier.TabIndex = 44;
            // 
            // labelEnemyBackDamageMultiplier
            // 
            labelEnemyBackDamageMultiplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEnemyBackDamageMultiplier.AutoSize = true;
            labelEnemyBackDamageMultiplier.Location = new Point(378, 195);
            labelEnemyBackDamageMultiplier.Name = "labelEnemyBackDamageMultiplier";
            labelEnemyBackDamageMultiplier.Size = new Size(135, 15);
            labelEnemyBackDamageMultiplier.TabIndex = 43;
            labelEnemyBackDamageMultiplier.Text = "Back damage multiplier:";
            // 
            // tabPageEnemyAI
            // 
            tabPageEnemyAI.Controls.Add(scriptControlEnemyAI);
            tabPageEnemyAI.Controls.Add(labelEnemyScripts);
            tabPageEnemyAI.Controls.Add(listBoxEnemyScripts);
            tabPageEnemyAI.Location = new Point(4, 24);
            tabPageEnemyAI.Name = "tabPageEnemyAI";
            tabPageEnemyAI.Padding = new Padding(3);
            tabPageEnemyAI.Size = new Size(768, 427);
            tabPageEnemyAI.TabIndex = 1;
            tabPageEnemyAI.Text = "A.I. Scripts";
            tabPageEnemyAI.UseVisualStyleBackColor = true;
            // 
            // scriptControlEnemyAI
            // 
            scriptControlEnemyAI.AIContainer = null;
            scriptControlEnemyAI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scriptControlEnemyAI.Location = new Point(181, 8);
            scriptControlEnemyAI.Name = "scriptControlEnemyAI";
            scriptControlEnemyAI.SelectedScriptIndex = -1;
            scriptControlEnemyAI.Size = new Size(581, 416);
            scriptControlEnemyAI.TabIndex = 5;
            scriptControlEnemyAI.DataChanged += scriptControl_DataChanged;
            scriptControlEnemyAI.ScriptAdded += scriptControlEnemyAI_ScriptAddedOrRemoved;
            // 
            // labelEnemyScripts
            // 
            labelEnemyScripts.AutoSize = true;
            labelEnemyScripts.Location = new Point(9, 8);
            labelEnemyScripts.Name = "labelEnemyScripts";
            labelEnemyScripts.Size = new Size(45, 15);
            labelEnemyScripts.TabIndex = 4;
            labelEnemyScripts.Text = "Scripts:";
            // 
            // listBoxEnemyScripts
            // 
            listBoxEnemyScripts.FormattingEnabled = true;
            listBoxEnemyScripts.ItemHeight = 15;
            listBoxEnemyScripts.Items.AddRange(new object[] { "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter", "Magic Counter", "Battle Victory", "Pre-Action Setup", "Custom Event 1", "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5", "Custom Event 6", "Custom Event 7", "Custom Event 8" });
            listBoxEnemyScripts.Location = new Point(7, 26);
            listBoxEnemyScripts.Margin = new Padding(4, 3, 4, 3);
            listBoxEnemyScripts.Name = "listBoxEnemyScripts";
            listBoxEnemyScripts.Size = new Size(167, 244);
            listBoxEnemyScripts.TabIndex = 3;
            listBoxEnemyScripts.SelectedIndexChanged += listBoxEnemyScripts_SelectedIndexChanged;
            // 
            // tabPageAttackData
            // 
            tabPageAttackData.Controls.Add(tabControlAttackData);
            tabPageAttackData.Controls.Add(listBoxAttacks);
            tabPageAttackData.Location = new Point(4, 24);
            tabPageAttackData.Name = "tabPageAttackData";
            tabPageAttackData.Size = new Size(776, 455);
            tabPageAttackData.TabIndex = 4;
            tabPageAttackData.Text = "Attack Data";
            tabPageAttackData.UseVisualStyleBackColor = true;
            // 
            // tabControlAttackData
            // 
            tabControlAttackData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlAttackData.Controls.Add(tabPageAttackPage1);
            tabControlAttackData.Controls.Add(tabPageAttackPage2);
            tabControlAttackData.Enabled = false;
            tabControlAttackData.Location = new Point(190, 9);
            tabControlAttackData.Name = "tabControlAttackData";
            tabControlAttackData.SelectedIndex = 0;
            tabControlAttackData.Size = new Size(577, 425);
            tabControlAttackData.TabIndex = 39;
            // 
            // tabPageAttackPage1
            // 
            tabPageAttackPage1.Controls.Add(textBoxAttackID);
            tabPageAttackPage1.Controls.Add(labelAttackID);
            tabPageAttackPage1.Controls.Add(elementsControlAttack);
            tabPageAttackPage1.Controls.Add(damageCalculationControlAttack);
            tabPageAttackPage1.Controls.Add(labelAttackHurtActionIndex);
            tabPageAttackPage1.Controls.Add(comboBoxAttackHurtActionIndex);
            tabPageAttackPage1.Controls.Add(labelAttackAttackEffectID);
            tabPageAttackPage1.Controls.Add(comboBoxAttackAttackEffectID);
            tabPageAttackPage1.Controls.Add(labelAttackImpactEffectID);
            tabPageAttackPage1.Controls.Add(comboBoxAttackImpactEffectID);
            tabPageAttackPage1.Controls.Add(labelAttackCamMovementIDMulti);
            tabPageAttackPage1.Controls.Add(comboBoxAttackCamMovementIDMulti);
            tabPageAttackPage1.Controls.Add(labelAttackCamMovementIDSingle);
            tabPageAttackPage1.Controls.Add(comboBoxAttackCamMovementIDSingle);
            tabPageAttackPage1.Controls.Add(numericAttackAttackPercent);
            tabPageAttackPage1.Controls.Add(labelAttackAttackPercent);
            tabPageAttackPage1.Controls.Add(labelAttackMPCost);
            tabPageAttackPage1.Controls.Add(numericAttackMPCost);
            tabPageAttackPage1.Controls.Add(labelAttackName);
            tabPageAttackPage1.Controls.Add(textBoxAttackName);
            tabPageAttackPage1.Location = new Point(4, 24);
            tabPageAttackPage1.Name = "tabPageAttackPage1";
            tabPageAttackPage1.Padding = new Padding(3);
            tabPageAttackPage1.Size = new Size(569, 397);
            tabPageAttackPage1.TabIndex = 0;
            tabPageAttackPage1.Text = "Page 1";
            tabPageAttackPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxAttackID
            // 
            textBoxAttackID.Location = new Point(7, 24);
            textBoxAttackID.MaxLength = 4;
            textBoxAttackID.Name = "textBoxAttackID";
            textBoxAttackID.Size = new Size(62, 23);
            textBoxAttackID.TabIndex = 60;
            // 
            // labelAttackID
            // 
            labelAttackID.AutoSize = true;
            labelAttackID.Location = new Point(7, 6);
            labelAttackID.Name = "labelAttackID";
            labelAttackID.Size = new Size(21, 15);
            labelAttackID.TabIndex = 59;
            labelAttackID.Text = "ID:";
            // 
            // elementsControlAttack
            // 
            elementsControlAttack.Location = new Point(7, 97);
            elementsControlAttack.MinimumSize = new Size(370, 130);
            elementsControlAttack.Name = "elementsControlAttack";
            elementsControlAttack.Size = new Size(370, 130);
            elementsControlAttack.TabIndex = 58;
            // 
            // damageCalculationControlAttack
            // 
            damageCalculationControlAttack.AccuracyCalculation = AccuracyCalculation.NoMiss1;
            damageCalculationControlAttack.ActualValue = 0;
            damageCalculationControlAttack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            damageCalculationControlAttack.AttackPower = 0;
            damageCalculationControlAttack.CanCrit = false;
            damageCalculationControlAttack.DamageFormula = DamageFormulas.NoDamage;
            damageCalculationControlAttack.DamageType = DamageType.Physical;
            damageCalculationControlAttack.Location = new Point(7, 233);
            damageCalculationControlAttack.Name = "damageCalculationControlAttack";
            damageCalculationControlAttack.Size = new Size(556, 143);
            damageCalculationControlAttack.TabIndex = 57;
            // 
            // labelAttackHurtActionIndex
            // 
            labelAttackHurtActionIndex.AutoSize = true;
            labelAttackHurtActionIndex.Location = new Point(383, 186);
            labelAttackHurtActionIndex.Name = "labelAttackHurtActionIndex";
            labelAttackHurtActionIndex.Size = new Size(102, 15);
            labelAttackHurtActionIndex.TabIndex = 56;
            labelAttackHurtActionIndex.Text = "Hurt action index:";
            // 
            // comboBoxAttackHurtActionIndex
            // 
            comboBoxAttackHurtActionIndex.FormattingEnabled = true;
            comboBoxAttackHurtActionIndex.Location = new Point(383, 204);
            comboBoxAttackHurtActionIndex.Name = "comboBoxAttackHurtActionIndex";
            comboBoxAttackHurtActionIndex.Size = new Size(180, 23);
            comboBoxAttackHurtActionIndex.TabIndex = 55;
            // 
            // labelAttackAttackEffectID
            // 
            labelAttackAttackEffectID.AutoSize = true;
            labelAttackAttackEffectID.Location = new Point(219, 50);
            labelAttackAttackEffectID.Name = "labelAttackAttackEffectID";
            labelAttackAttackEffectID.Size = new Size(91, 15);
            labelAttackAttackEffectID.TabIndex = 54;
            labelAttackAttackEffectID.Text = "Attack effect ID:";
            // 
            // comboBoxAttackAttackEffectID
            // 
            comboBoxAttackAttackEffectID.FormattingEnabled = true;
            comboBoxAttackAttackEffectID.Location = new Point(219, 68);
            comboBoxAttackAttackEffectID.Name = "comboBoxAttackAttackEffectID";
            comboBoxAttackAttackEffectID.Size = new Size(100, 23);
            comboBoxAttackAttackEffectID.TabIndex = 53;
            // 
            // labelAttackImpactEffectID
            // 
            labelAttackImpactEffectID.AutoSize = true;
            labelAttackImpactEffectID.Location = new Point(325, 50);
            labelAttackImpactEffectID.Name = "labelAttackImpactEffectID";
            labelAttackImpactEffectID.Size = new Size(94, 15);
            labelAttackImpactEffectID.TabIndex = 52;
            labelAttackImpactEffectID.Text = "Impact effect ID:";
            // 
            // comboBoxAttackImpactEffectID
            // 
            comboBoxAttackImpactEffectID.FormattingEnabled = true;
            comboBoxAttackImpactEffectID.Location = new Point(325, 68);
            comboBoxAttackImpactEffectID.Name = "comboBoxAttackImpactEffectID";
            comboBoxAttackImpactEffectID.Size = new Size(100, 23);
            comboBoxAttackImpactEffectID.TabIndex = 51;
            // 
            // labelAttackCamMovementIDMulti
            // 
            labelAttackCamMovementIDMulti.AutoSize = true;
            labelAttackCamMovementIDMulti.Location = new Point(383, 141);
            labelAttackCamMovementIDMulti.Name = "labelAttackCamMovementIDMulti";
            labelAttackCamMovementIDMulti.Size = new Size(183, 15);
            labelAttackCamMovementIDMulti.TabIndex = 49;
            labelAttackCamMovementIDMulti.Text = "Cam movement ID (multi target):";
            // 
            // comboBoxAttackCamMovementIDMulti
            // 
            comboBoxAttackCamMovementIDMulti.FormattingEnabled = true;
            comboBoxAttackCamMovementIDMulti.Location = new Point(383, 159);
            comboBoxAttackCamMovementIDMulti.Name = "comboBoxAttackCamMovementIDMulti";
            comboBoxAttackCamMovementIDMulti.Size = new Size(180, 23);
            comboBoxAttackCamMovementIDMulti.TabIndex = 50;
            // 
            // labelAttackCamMovementIDSingle
            // 
            labelAttackCamMovementIDSingle.AutoSize = true;
            labelAttackCamMovementIDSingle.Location = new Point(383, 97);
            labelAttackCamMovementIDSingle.Name = "labelAttackCamMovementIDSingle";
            labelAttackCamMovementIDSingle.Size = new Size(186, 15);
            labelAttackCamMovementIDSingle.TabIndex = 47;
            labelAttackCamMovementIDSingle.Text = "Cam movement ID (single target):";
            // 
            // comboBoxAttackCamMovementIDSingle
            // 
            comboBoxAttackCamMovementIDSingle.FormattingEnabled = true;
            comboBoxAttackCamMovementIDSingle.Location = new Point(383, 115);
            comboBoxAttackCamMovementIDSingle.Name = "comboBoxAttackCamMovementIDSingle";
            comboBoxAttackCamMovementIDSingle.Size = new Size(180, 23);
            comboBoxAttackCamMovementIDSingle.TabIndex = 48;
            // 
            // numericAttackAttackPercent
            // 
            numericAttackAttackPercent.Location = new Point(7, 68);
            numericAttackAttackPercent.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericAttackAttackPercent.Name = "numericAttackAttackPercent";
            numericAttackAttackPercent.Size = new Size(100, 23);
            numericAttackAttackPercent.TabIndex = 46;
            // 
            // labelAttackAttackPercent
            // 
            labelAttackAttackPercent.AutoSize = true;
            labelAttackAttackPercent.Location = new Point(7, 50);
            labelAttackAttackPercent.Name = "labelAttackAttackPercent";
            labelAttackAttackPercent.Size = new Size(54, 15);
            labelAttackAttackPercent.TabIndex = 45;
            labelAttackAttackPercent.Text = "Attack%:";
            // 
            // labelAttackMPCost
            // 
            labelAttackMPCost.AutoSize = true;
            labelAttackMPCost.Location = new Point(113, 50);
            labelAttackMPCost.Name = "labelAttackMPCost";
            labelAttackMPCost.Size = new Size(53, 15);
            labelAttackMPCost.TabIndex = 43;
            labelAttackMPCost.Text = "MP cost:";
            // 
            // numericAttackMPCost
            // 
            numericAttackMPCost.Location = new Point(113, 68);
            numericAttackMPCost.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericAttackMPCost.Name = "numericAttackMPCost";
            numericAttackMPCost.Size = new Size(100, 23);
            numericAttackMPCost.TabIndex = 44;
            // 
            // labelAttackName
            // 
            labelAttackName.AutoSize = true;
            labelAttackName.Location = new Point(76, 6);
            labelAttackName.Margin = new Padding(4, 0, 4, 0);
            labelAttackName.Name = "labelAttackName";
            labelAttackName.Size = new Size(42, 15);
            labelAttackName.TabIndex = 3;
            labelAttackName.Text = "Name:";
            // 
            // textBoxAttackName
            // 
            textBoxAttackName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAttackName.Location = new Point(76, 24);
            textBoxAttackName.Margin = new Padding(4, 3, 4, 3);
            textBoxAttackName.Name = "textBoxAttackName";
            textBoxAttackName.Size = new Size(205, 23);
            textBoxAttackName.TabIndex = 4;
            // 
            // tabPageAttackPage2
            // 
            tabPageAttackPage2.Controls.Add(numericAttackStatusChangeChance);
            tabPageAttackPage2.Controls.Add(comboBoxAttackConditionSubMenu);
            tabPageAttackPage2.Controls.Add(labelAttackStatusChangeChance);
            tabPageAttackPage2.Controls.Add(comboBoxAttackStatusChange);
            tabPageAttackPage2.Controls.Add(labelAttackConditionSubMenu);
            tabPageAttackPage2.Controls.Add(labelAttackStatusChange);
            tabPageAttackPage2.Controls.Add(statusesControlAttack);
            tabPageAttackPage2.Controls.Add(specialAttackFlagsControlAttack);
            tabPageAttackPage2.Location = new Point(4, 24);
            tabPageAttackPage2.Name = "tabPageAttackPage2";
            tabPageAttackPage2.Padding = new Padding(3);
            tabPageAttackPage2.Size = new Size(569, 397);
            tabPageAttackPage2.TabIndex = 1;
            tabPageAttackPage2.Text = "Page 2";
            tabPageAttackPage2.UseVisualStyleBackColor = true;
            // 
            // numericAttackStatusChangeChance
            // 
            numericAttackStatusChangeChance.Location = new Point(149, 333);
            numericAttackStatusChangeChance.Maximum = new decimal(new int[] { 63, 0, 0, 0 });
            numericAttackStatusChangeChance.Name = "numericAttackStatusChangeChance";
            numericAttackStatusChangeChance.Size = new Size(108, 23);
            numericAttackStatusChangeChance.TabIndex = 49;
            // 
            // comboBoxAttackConditionSubMenu
            // 
            comboBoxAttackConditionSubMenu.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAttackConditionSubMenu.FormattingEnabled = true;
            comboBoxAttackConditionSubMenu.Location = new Point(263, 333);
            comboBoxAttackConditionSubMenu.Name = "comboBoxAttackConditionSubMenu";
            comboBoxAttackConditionSubMenu.Size = new Size(300, 23);
            comboBoxAttackConditionSubMenu.TabIndex = 51;
            // 
            // labelAttackStatusChangeChance
            // 
            labelAttackStatusChangeChance.AutoSize = true;
            labelAttackStatusChangeChance.Location = new Point(149, 315);
            labelAttackStatusChangeChance.Name = "labelAttackStatusChangeChance";
            labelAttackStatusChangeChance.Size = new Size(108, 15);
            labelAttackStatusChangeChance.TabIndex = 48;
            labelAttackStatusChangeChance.Text = "Chance (out of 63):";
            // 
            // comboBoxAttackStatusChange
            // 
            comboBoxAttackStatusChange.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAttackStatusChange.FormattingEnabled = true;
            comboBoxAttackStatusChange.Location = new Point(6, 333);
            comboBoxAttackStatusChange.Name = "comboBoxAttackStatusChange";
            comboBoxAttackStatusChange.Size = new Size(137, 23);
            comboBoxAttackStatusChange.TabIndex = 47;
            comboBoxAttackStatusChange.SelectedIndexChanged += comboBoxAttackStatusChange_SelectedIndexChanged;
            // 
            // labelAttackConditionSubMenu
            // 
            labelAttackConditionSubMenu.AutoSize = true;
            labelAttackConditionSubMenu.Location = new Point(263, 315);
            labelAttackConditionSubMenu.Name = "labelAttackConditionSubMenu";
            labelAttackConditionSubMenu.Size = new Size(121, 15);
            labelAttackConditionSubMenu.TabIndex = 50;
            labelAttackConditionSubMenu.Text = "Condition sub-menu:";
            // 
            // labelAttackStatusChange
            // 
            labelAttackStatusChange.AutoSize = true;
            labelAttackStatusChange.Location = new Point(6, 315);
            labelAttackStatusChange.Name = "labelAttackStatusChange";
            labelAttackStatusChange.Size = new Size(84, 15);
            labelAttackStatusChange.TabIndex = 46;
            labelAttackStatusChange.Text = "Status change:";
            // 
            // statusesControlAttack
            // 
            statusesControlAttack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusesControlAttack.FullList = true;
            statusesControlAttack.GroupBoxText = "Statuses";
            statusesControlAttack.Location = new Point(6, 112);
            statusesControlAttack.MinimumSize = new Size(380, 200);
            statusesControlAttack.Name = "statusesControlAttack";
            statusesControlAttack.Size = new Size(557, 200);
            statusesControlAttack.TabIndex = 45;
            // 
            // specialAttackFlagsControlAttack
            // 
            specialAttackFlagsControlAttack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            specialAttackFlagsControlAttack.Location = new Point(6, 6);
            specialAttackFlagsControlAttack.Name = "specialAttackFlagsControlAttack";
            specialAttackFlagsControlAttack.Size = new Size(557, 100);
            specialAttackFlagsControlAttack.TabIndex = 44;
            // 
            // listBoxAttacks
            // 
            listBoxAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxAttacks.FormattingEnabled = true;
            listBoxAttacks.ItemHeight = 15;
            listBoxAttacks.Location = new Point(9, 9);
            listBoxAttacks.Margin = new Padding(4, 3, 4, 3);
            listBoxAttacks.Name = "listBoxAttacks";
            listBoxAttacks.Size = new Size(174, 424);
            listBoxAttacks.TabIndex = 38;
            listBoxAttacks.SelectedIndexChanged += listBoxAttacks_SelectedIndexChanged;
            // 
            // tabPageFormationData
            // 
            tabPageFormationData.Controls.Add(tabControlFormationData);
            tabPageFormationData.Location = new Point(4, 24);
            tabPageFormationData.Name = "tabPageFormationData";
            tabPageFormationData.Size = new Size(776, 455);
            tabPageFormationData.TabIndex = 2;
            tabPageFormationData.Text = "Formation Data";
            tabPageFormationData.UseVisualStyleBackColor = true;
            // 
            // tabControlFormationData
            // 
            tabControlFormationData.Controls.Add(tabPageFormation1);
            tabControlFormationData.Controls.Add(tabPageFormationAI);
            tabControlFormationData.Dock = DockStyle.Fill;
            tabControlFormationData.Location = new Point(0, 0);
            tabControlFormationData.Name = "tabControlFormationData";
            tabControlFormationData.SelectedIndex = 0;
            tabControlFormationData.Size = new Size(776, 455);
            tabControlFormationData.TabIndex = 0;
            // 
            // tabPageFormation1
            // 
            tabPageFormation1.Location = new Point(4, 24);
            tabPageFormation1.Name = "tabPageFormation1";
            tabPageFormation1.Padding = new Padding(3);
            tabPageFormation1.Size = new Size(768, 427);
            tabPageFormation1.TabIndex = 0;
            tabPageFormation1.Text = "Data";
            tabPageFormation1.UseVisualStyleBackColor = true;
            // 
            // tabPageFormationAI
            // 
            tabPageFormationAI.Controls.Add(scriptControlFormations);
            tabPageFormationAI.Controls.Add(labelFormationScripts);
            tabPageFormationAI.Controls.Add(listBoxFormationScripts);
            tabPageFormationAI.Location = new Point(4, 24);
            tabPageFormationAI.Name = "tabPageFormationAI";
            tabPageFormationAI.Size = new Size(768, 427);
            tabPageFormationAI.TabIndex = 3;
            tabPageFormationAI.Text = "Formation A.I.";
            tabPageFormationAI.UseVisualStyleBackColor = true;
            // 
            // scriptControlFormations
            // 
            scriptControlFormations.AIContainer = null;
            scriptControlFormations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scriptControlFormations.Location = new Point(181, 8);
            scriptControlFormations.Name = "scriptControlFormations";
            scriptControlFormations.SelectedScriptIndex = -1;
            scriptControlFormations.Size = new Size(581, 416);
            scriptControlFormations.TabIndex = 8;
            scriptControlFormations.DataChanged += scriptControl_DataChanged;
            scriptControlFormations.ScriptAdded += scriptControlFormations_ScriptAddedOrRemoved;
            scriptControlFormations.ScriptRemoved += scriptControlFormations_ScriptAddedOrRemoved;
            // 
            // labelFormationScripts
            // 
            labelFormationScripts.AutoSize = true;
            labelFormationScripts.Location = new Point(9, 8);
            labelFormationScripts.Name = "labelFormationScripts";
            labelFormationScripts.Size = new Size(45, 15);
            labelFormationScripts.TabIndex = 7;
            labelFormationScripts.Text = "Scripts:";
            // 
            // listBoxFormationScripts
            // 
            listBoxFormationScripts.FormattingEnabled = true;
            listBoxFormationScripts.ItemHeight = 15;
            listBoxFormationScripts.Items.AddRange(new object[] { "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter", "Magic Counter", "Battle Victory", "Pre-Action Setup", "Custom Event 1", "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5", "Custom Event 6", "Custom Event 7", "Custom Event 8" });
            listBoxFormationScripts.Location = new Point(7, 26);
            listBoxFormationScripts.Margin = new Padding(4, 3, 4, 3);
            listBoxFormationScripts.Name = "listBoxFormationScripts";
            listBoxFormationScripts.Size = new Size(167, 244);
            listBoxFormationScripts.TabIndex = 6;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(buttonSearch);
            panelTop.Controls.Add(comboBoxFormation);
            panelTop.Controls.Add(labelFormation);
            panelTop.Controls.Add(comboBoxEnemy);
            panelTop.Controls.Add(labelEnemy);
            panelTop.Controls.Add(comboBoxSceneList);
            panelTop.Controls.Add(labelScenes);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(784, 73);
            panelTop.TabIndex = 11;
            // 
            // buttonSearch
            // 
            buttonSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSearch.Location = new Point(681, 40);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(90, 23);
            buttonSearch.TabIndex = 14;
            buttonSearch.Text = "Search...";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // comboBoxFormation
            // 
            comboBoxFormation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormation.FormattingEnabled = true;
            comboBoxFormation.Location = new Point(344, 40);
            comboBoxFormation.Name = "comboBoxFormation";
            comboBoxFormation.Size = new Size(100, 23);
            comboBoxFormation.TabIndex = 13;
            comboBoxFormation.SelectedIndexChanged += comboBoxFormation_SelectedIndexChanged;
            // 
            // labelFormation
            // 
            labelFormation.AutoSize = true;
            labelFormation.Location = new Point(273, 43);
            labelFormation.Name = "labelFormation";
            labelFormation.Size = new Size(65, 15);
            labelFormation.TabIndex = 12;
            labelFormation.Text = "Formation:";
            // 
            // comboBoxEnemy
            // 
            comboBoxEnemy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnemy.FormattingEnabled = true;
            comboBoxEnemy.Location = new Point(67, 40);
            comboBoxEnemy.Name = "comboBoxEnemy";
            comboBoxEnemy.Size = new Size(200, 23);
            comboBoxEnemy.TabIndex = 11;
            comboBoxEnemy.SelectedIndexChanged += comboBoxEnemy_SelectedIndexChanged;
            // 
            // labelEnemy
            // 
            labelEnemy.AutoSize = true;
            labelEnemy.Location = new Point(15, 43);
            labelEnemy.Name = "labelEnemy";
            labelEnemy.Size = new Size(46, 15);
            labelEnemy.TabIndex = 10;
            labelEnemy.Text = "Enemy:";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(progressBarSaving);
            panelBottom.Controls.Add(buttonExport);
            panelBottom.Controls.Add(buttonImport);
            panelBottom.Controls.Add(buttonSave);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 556);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(784, 65);
            panelBottom.TabIndex = 12;
            // 
            // progressBarSaving
            // 
            progressBarSaving.Dock = DockStyle.Bottom;
            progressBarSaving.Location = new Point(0, 42);
            progressBarSaving.Name = "progressBarSaving";
            progressBarSaving.Size = new Size(784, 23);
            progressBarSaving.TabIndex = 6;
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExport.Location = new Point(654, 9);
            buttonExport.Margin = new Padding(4, 3, 4, 3);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(117, 27);
            buttonExport.TabIndex = 5;
            buttonExport.Text = "Export...";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonImport
            // 
            buttonImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonImport.Location = new Point(529, 9);
            buttonImport.Margin = new Padding(4, 3, 4, 3);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(117, 27);
            buttonImport.TabIndex = 4;
            buttonImport.Text = "Import...";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 9);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(175, 27);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save scene.bin";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // SceneEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 621);
            Controls.Add(tabControlMain);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SceneEditorForm";
            Text = "Scarlet - Scene Editor";
            FormClosing += SceneEditorForm_FormClosing;
            tabControlMain.ResumeLayout(false);
            tabPageEnemyData.ResumeLayout(false);
            tabControlEnemyData.ResumeLayout(false);
            tabPageEnemyPage1.ResumeLayout(false);
            tabPageEnemyPage1.PerformLayout();
            groupBoxEnemyElementResistances.ResumeLayout(false);
            groupBoxEnemyElementResistances.PerformLayout();
            groupBoxEnemyReward.ResumeLayout(false);
            groupBoxEnemyReward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericEnemyEXP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyGil).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyAP).EndInit();
            groupBoxEnemyStats.ResumeLayout(false);
            groupBoxEnemyStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericEnemyLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyStrength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyMP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyDefense).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyHP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemySpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyMagic).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyEvade).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyMDef).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyLuck).EndInit();
            tabPageEnemyPage2.ResumeLayout(false);
            tabPageEnemyPage2.PerformLayout();
            groupBoxEnemyItemDropRates.ResumeLayout(false);
            groupBoxEnemyItemDropRates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericEnemyDropRate).EndInit();
            groupBoxEnemyAttacks.ResumeLayout(false);
            groupBoxEnemyAttacks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackAnimationIndex).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEnemyBackDamageMultiplier).EndInit();
            tabPageEnemyAI.ResumeLayout(false);
            tabPageEnemyAI.PerformLayout();
            tabPageAttackData.ResumeLayout(false);
            tabControlAttackData.ResumeLayout(false);
            tabPageAttackPage1.ResumeLayout(false);
            tabPageAttackPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackAttackPercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAttackMPCost).EndInit();
            tabPageAttackPage2.ResumeLayout(false);
            tabPageAttackPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAttackStatusChangeChance).EndInit();
            tabPageFormationData.ResumeLayout(false);
            tabControlFormationData.ResumeLayout(false);
            tabPageFormationAI.ResumeLayout(false);
            tabPageFormationAI.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label labelScenes;
        private ComboBox comboBoxSceneList;
        private TabControl tabControlMain;
        private TabPage tabPageEnemyPage1;
        private TabPage tabPageEnemyAI;
        private Panel panelTop;
        private Panel panelBottom;
        private Button buttonSave;
        private Button buttonExport;
        private Button buttonImport;
        private TabPage tabPageFormationData;
        private TabPage tabPageFormationAI;
        private Label labelEnemyName;
        private ComboBox comboBoxEnemy;
        private Label labelEnemy;
        private TextBox textBoxEnemyName;
        private NumericUpDown numericEnemyLevel;
        private Label labelEnemyLevel;
        private TabPage tabPageAttackData;
        private NumericUpDown numericEnemyHP;
        private Label labelEnemyHP;
        private NumericUpDown numericEnemyMP;
        private Label labelEnemyMP;
        private NumericUpDown numericEnemyStrength;
        private Label labelEnemyStrength;
        private NumericUpDown numericEnemyMagic;
        private Label labelEnemyMagic;
        private NumericUpDown numericEnemyDefense;
        private Label labelEnemyDefense;
        private NumericUpDown numericEnemyMDef;
        private Label labelEnemyMDef;
        private NumericUpDown numericEnemyEvade;
        private Label labelEnemyLuck;
        private NumericUpDown numericEnemyLuck;
        private Label labelEnemyEvade;
        private NumericUpDown numericEnemySpeed;
        private Label labelEnemySpeed;
        private NumericUpDown numericEnemyAP;
        private Label labelEnemyAP;
        private NumericUpDown numericEnemyEXP;
        private Label labelEnemyEXP;
        private GroupBox groupBoxEnemyReward;
        private NumericUpDown numericEnemyGil;
        private Label labelEnemyGil;
        private GroupBox groupBoxEnemyStats;
        private GroupBox groupBoxEnemyElementResistances;
        private ComboBox comboBoxEnemyResistRate;
        private Label labelEnemyResistRate;
        private ComboBox comboBoxEnemyResistElement;
        private Label labelEnemyResistElement;
        private ListBox listBoxElementResistances;
        private Label labelEnemyBackDamageMultiplier;
        private NumericUpDown numericEnemyBackDamageMultiplier;
        private KernelEditor.Controls.StatusesControl statusesControlEnemyImmunities;
        private TabPage tabPageEnemyPage2;
        private GroupBox groupBoxEnemyAttacks;
        private ListBox listBoxEnemyAttacks;
        private Label labelEnemyAttackID;
        private ComboBox comboBoxEnemyAttackID;
        private ComboBox comboBoxEnemyAttackCamID;
        private Label labelEnemyAttackCamID;
        private CheckBox checkBoxEnemyAttackIsManipable;
        private GroupBox groupBoxEnemyItemDropRates;
        private ComboBox comboBoxEnemyDropItemID;
        private Label labelEnemyDropItem;
        private ListBox listBoxEnemyItemDropRates;
        private Label labelEnemyItemDropRate;
        private NumericUpDown numericEnemyDropRate;
        private Label labelEnemyMorphItem;
        private ComboBox comboBoxEnemyMorphItem;
        private CheckBox checkBoxEnemyItemIsSteal;
        private NumericUpDown numericAttackAnimationIndex;
        private Label labelEnemyAttackAnimationIndex;
        private Label labelEnemyScripts;
        private ListBox listBoxEnemyScripts;
        private AIEditor.ScriptControl scriptControlEnemyAI;
        private AIEditor.ScriptControl scriptControlFormations;
        private Label labelFormationScripts;
        private ListBox listBoxFormationScripts;
        private TabPage tabPageEnemyData;
        private TabControl tabControlEnemyData;
        private TabControl tabControlAttackData;
        private TabPage tabPageAttackPage1;
        private TabPage tabPageAttackPage2;
        private ListBox listBoxAttacks;
        private Label labelAttackName;
        private TextBox textBoxAttackName;
        private Label labelAttackHurtActionIndex;
        private ComboBox comboBoxAttackHurtActionIndex;
        private Label labelAttackAttackEffectID;
        private ComboBox comboBoxAttackAttackEffectID;
        private Label labelAttackImpactEffectID;
        private ComboBox comboBoxAttackImpactEffectID;
        private Label labelAttackCamMovementIDMulti;
        private ComboBox comboBoxAttackCamMovementIDMulti;
        private Label labelAttackCamMovementIDSingle;
        private ComboBox comboBoxAttackCamMovementIDSingle;
        private NumericUpDown numericAttackAttackPercent;
        private Label labelAttackAttackPercent;
        private Label labelAttackMPCost;
        private NumericUpDown numericAttackMPCost;
        private KernelEditor.Controls.DamageCalculationControl damageCalculationControlAttack;
        private Shared.SpecialAttackFlagsControl specialAttackFlagsControlAttack;
        private KernelEditor.Controls.ElementsControl elementsControlAttack;
        private NumericUpDown numericAttackStatusChangeChance;
        private ComboBox comboBoxAttackConditionSubMenu;
        private Label labelAttackStatusChangeChance;
        private ComboBox comboBoxAttackStatusChange;
        private Label labelAttackConditionSubMenu;
        private Label labelAttackStatusChange;
        private KernelEditor.Controls.StatusesControl statusesControlAttack;
        private TabControl tabControlFormationData;
        private TabPage tabPageFormation1;
        private ComboBox comboBoxFormation;
        private Label labelFormation;
        private TextBox textBoxAttackID;
        private Label labelAttackID;
        private ProgressBar progressBarSaving;
        private Button buttonSearch;
    }
}