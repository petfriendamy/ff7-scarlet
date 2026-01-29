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
            statusesControlEnemyImmunities = new FF7Scarlet.KernelEditor.Controls.StatusesControl();
            groupBoxEnemyElementResistances = new GroupBox();
            comboBoxEnemyResistRate = new ComboBox();
            labelEnemyResistRate = new Label();
            comboBoxEnemyResistElement = new ComboBox();
            labelEnemyResistElement = new Label();
            listBoxEnemyElementResistances = new ListBox();
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
            enemyModelPreviewControl = new FF7Scarlet.SceneEditor.Controls.ModelPreviewControl();
            comboBoxEnemyModelID = new ComboBox();
            labelEnemyModelID = new Label();
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
            buttonViewManipList = new Button();
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
            scriptControlEnemyAI = new FF7Scarlet.AIEditor.ScriptControl();
            labelEnemyScripts = new Label();
            listBoxEnemyScripts = new ListBox();
            tabPageAttackData = new TabPage();
            attackFormControl = new FF7Scarlet.Shared.Controls.AttackFormControl();
            listBoxAttacks = new ListBox();
            tabPageFormationData = new TabPage();
            tabControlFormationData = new TabControl();
            tabPageFormationDataInner = new TabPage();
            groupBoxFormationSetupData = new GroupBox();
            battleFlagsControlFormation = new BattleFlagsControl();
            labelFormationLocation = new Label();
            comboBoxFormationLocation = new ComboBox();
            labelFormationNext = new Label();
            comboBoxFormationBattleType = new ComboBox();
            comboBoxFormationNext = new ComboBox();
            labelFormationBattleType = new Label();
            labelFormationEscapeCounter = new Label();
            groupBoxFormationBattleArena = new GroupBox();
            comboBoxFormationBattleArena = new ComboBox();
            labelFormationBattleArena = new Label();
            listBoxFormationBattleArena = new ListBox();
            numericFormationEscapeCounter = new NumericUpDown();
            groupBoxFormationEnemies = new GroupBox();
            coverFlagsControlFormationEnemy = new CoverFlagsControl();
            initialConditionControlEnemy = new InitialConditionControl();
            numericFormationEnemyRow = new NumericUpDown();
            labelFormationEnemyRow = new Label();
            numericFormationEnemyZ = new NumericUpDown();
            labelFormationEnemyZ = new Label();
            numericFormationEnemyY = new NumericUpDown();
            labelFormationEnemyY = new Label();
            numericFormationEnemyX = new NumericUpDown();
            labelFormationEnemyX = new Label();
            comboBoxFormationSelectedEnemy = new ComboBox();
            labelFormationSelectedEnemy = new Label();
            listBoxFormationEnemies = new ListBox();
            tabPageCameraData = new TabPage();
            cameraPositionControlExtra3 = new FF7Scarlet.SceneEditor.Controls.CameraPositionControl();
            cameraPositionControlExtra2 = new FF7Scarlet.SceneEditor.Controls.CameraPositionControl();
            cameraPositionControlExtra1 = new FF7Scarlet.SceneEditor.Controls.CameraPositionControl();
            cameraPositionControlMain = new FF7Scarlet.SceneEditor.Controls.CameraPositionControl();
            numericFormationPreBattleCamPosition = new NumericUpDown();
            labelFormationCamPreBattlePosition = new Label();
            tabPageFormationAI = new TabPage();
            scriptControlFormations = new FF7Scarlet.AIEditor.ScriptControl();
            labelFormationScripts = new Label();
            listBoxFormationScripts = new ListBox();
            panelTop = new Panel();
            toolStripMain = new ToolStrip();
            toolStripDropDownFile = new ToolStripDropDownButton();
            saveScenebinToolStripMenuItem = new ToolStripMenuItem();
            importScenesToolStripMenuItem = new ToolStripMenuItem();
            exportScenesToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownEdit = new ToolStripDropDownButton();
            selectedSceneToolStripMenuItem = new ToolStripMenuItem();
            sceneCopyToolStripMenuItem = new ToolStripMenuItem();
            scenePasteToolStripMenuItem = new ToolStripMenuItem();
            sceneClearToolStripMenuItem = new ToolStripMenuItem();
            enemyToolStripMenuItem = new ToolStripMenuItem();
            createNewEnemyToolStripMenuItem = new ToolStripMenuItem();
            enemyCopyToolStripMenuItem = new ToolStripMenuItem();
            enemyPasteToolStripMenuItem = new ToolStripMenuItem();
            enemyDeleteToolStripMenuItem = new ToolStripMenuItem();
            selectedAttackToolStripMenuItem = new ToolStripMenuItem();
            createNewAttackToolStripMenuItem = new ToolStripMenuItem();
            attackCopyToolStripMenuItem = new ToolStripMenuItem();
            attackPasteToolStripMenuItem = new ToolStripMenuItem();
            attackDeleteToolStripMenuItem = new ToolStripMenuItem();
            selectedFormationToolStripMenuItem = new ToolStripMenuItem();
            formationCopyToolStripMenuItem = new ToolStripMenuItem();
            formationPasteToolStripMenuItem = new ToolStripMenuItem();
            formationClearToolStripMenuItem = new ToolStripMenuItem();
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
            tabPageFormationData.SuspendLayout();
            tabControlFormationData.SuspendLayout();
            tabPageFormationDataInner.SuspendLayout();
            groupBoxFormationSetupData.SuspendLayout();
            groupBoxFormationBattleArena.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericFormationEscapeCounter).BeginInit();
            groupBoxFormationEnemies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericFormationEnemyRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericFormationEnemyZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericFormationEnemyY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericFormationEnemyX).BeginInit();
            tabPageCameraData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericFormationPreBattleCamPosition).BeginInit();
            tabPageFormationAI.SuspendLayout();
            panelTop.SuspendLayout();
            toolStripMain.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // labelScenes
            // 
            labelScenes.AutoSize = true;
            labelScenes.Location = new Point(13, 33);
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
            comboBoxSceneList.Location = new Point(67, 30);
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
            tabControlMain.Location = new Point(0, 90);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(784, 506);
            tabControlMain.TabIndex = 10;
            // 
            // tabPageEnemyData
            // 
            tabPageEnemyData.Controls.Add(tabControlEnemyData);
            tabPageEnemyData.Location = new Point(4, 24);
            tabPageEnemyData.Name = "tabPageEnemyData";
            tabPageEnemyData.Size = new Size(776, 478);
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
            tabControlEnemyData.Size = new Size(776, 478);
            tabControlEnemyData.TabIndex = 0;
            tabControlEnemyData.SelectedIndexChanged += tabControlEnemyData_SelectedIndexChanged;
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
            tabPageEnemyPage1.Size = new Size(768, 450);
            tabPageEnemyPage1.TabIndex = 0;
            tabPageEnemyPage1.Text = "Page 1";
            tabPageEnemyPage1.UseVisualStyleBackColor = true;
            // 
            // statusesControlEnemyImmunities
            // 
            statusesControlEnemyImmunities.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusesControlEnemyImmunities.Location = new Point(267, 170);
            statusesControlEnemyImmunities.MinimumSize = new Size(380, 200);
            statusesControlEnemyImmunities.Name = "statusesControlEnemyImmunities";
            statusesControlEnemyImmunities.Size = new Size(494, 210);
            statusesControlEnemyImmunities.TabIndex = 43;
            statusesControlEnemyImmunities.StatusesChanged += EnemyDataChanged;
            // 
            // groupBoxEnemyElementResistances
            // 
            groupBoxEnemyElementResistances.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxEnemyElementResistances.Controls.Add(comboBoxEnemyResistRate);
            groupBoxEnemyElementResistances.Controls.Add(labelEnemyResistRate);
            groupBoxEnemyElementResistances.Controls.Add(comboBoxEnemyResistElement);
            groupBoxEnemyElementResistances.Controls.Add(labelEnemyResistElement);
            groupBoxEnemyElementResistances.Controls.Add(listBoxEnemyElementResistances);
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
            comboBoxEnemyResistRate.SelectedIndexChanged += comboBoxEnemyResistRate_SelectedIndexChanged;
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
            comboBoxEnemyResistElement.SelectedIndexChanged += comboBoxEnemyResistElement_SelectedIndexChanged;
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
            // listBoxEnemyElementResistances
            // 
            listBoxEnemyElementResistances.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxEnemyElementResistances.FormattingEnabled = true;
            listBoxEnemyElementResistances.Location = new Point(6, 22);
            listBoxEnemyElementResistances.Name = "listBoxEnemyElementResistances";
            listBoxEnemyElementResistances.Size = new Size(322, 124);
            listBoxEnemyElementResistances.TabIndex = 41;
            listBoxEnemyElementResistances.SelectedIndexChanged += listBoxEnemyElementResistances_SelectedIndexChanged;
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
            groupBoxEnemyReward.Size = new Size(252, 118);
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
            numericEnemyEXP.ValueChanged += EnemyDataChanged;
            // 
            // numericEnemyGil
            // 
            numericEnemyGil.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericEnemyGil.Location = new Point(6, 83);
            numericEnemyGil.Name = "numericEnemyGil";
            numericEnemyGil.Size = new Size(232, 23);
            numericEnemyGil.TabIndex = 38;
            numericEnemyGil.ValueChanged += EnemyDataChanged;
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
            numericEnemyAP.ValueChanged += EnemyDataChanged;
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
            numericEnemyLevel.ValueChanged += EnemyDataChanged;
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
            numericEnemyStrength.ValueChanged += EnemyDataChanged;
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
            numericEnemyMP.ValueChanged += EnemyDataChanged;
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
            numericEnemyDefense.ValueChanged += EnemyDataChanged;
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
            numericEnemyHP.ValueChanged += EnemyDataChanged;
            // 
            // numericEnemySpeed
            // 
            numericEnemySpeed.Location = new Point(6, 131);
            numericEnemySpeed.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemySpeed.Name = "numericEnemySpeed";
            numericEnemySpeed.Size = new Size(55, 23);
            numericEnemySpeed.TabIndex = 32;
            numericEnemySpeed.ValueChanged += EnemyDataChanged;
            // 
            // numericEnemyMagic
            // 
            numericEnemyMagic.Location = new Point(125, 85);
            numericEnemyMagic.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemyMagic.Name = "numericEnemyMagic";
            numericEnemyMagic.Size = new Size(55, 23);
            numericEnemyMagic.TabIndex = 24;
            numericEnemyMagic.ValueChanged += EnemyDataChanged;
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
            numericEnemyEvade.ValueChanged += EnemyDataChanged;
            // 
            // numericEnemyMDef
            // 
            numericEnemyMDef.Location = new Point(186, 85);
            numericEnemyMDef.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericEnemyMDef.Name = "numericEnemyMDef";
            numericEnemyMDef.Size = new Size(52, 23);
            numericEnemyMDef.TabIndex = 26;
            numericEnemyMDef.ValueChanged += EnemyDataChanged;
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
            numericEnemyLuck.ValueChanged += EnemyDataChanged;
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
            textBoxEnemyName.TextChanged += textBoxEnemyName_TextChanged;
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
            tabPageEnemyPage2.Controls.Add(enemyModelPreviewControl);
            tabPageEnemyPage2.Controls.Add(comboBoxEnemyModelID);
            tabPageEnemyPage2.Controls.Add(labelEnemyModelID);
            tabPageEnemyPage2.Controls.Add(comboBoxEnemyMorphItem);
            tabPageEnemyPage2.Controls.Add(labelEnemyMorphItem);
            tabPageEnemyPage2.Controls.Add(groupBoxEnemyItemDropRates);
            tabPageEnemyPage2.Controls.Add(groupBoxEnemyAttacks);
            tabPageEnemyPage2.Controls.Add(numericEnemyBackDamageMultiplier);
            tabPageEnemyPage2.Controls.Add(labelEnemyBackDamageMultiplier);
            tabPageEnemyPage2.Location = new Point(4, 24);
            tabPageEnemyPage2.Name = "tabPageEnemyPage2";
            tabPageEnemyPage2.Size = new Size(768, 450);
            tabPageEnemyPage2.TabIndex = 5;
            tabPageEnemyPage2.Text = "Page 2";
            tabPageEnemyPage2.UseVisualStyleBackColor = true;
            // 
            // enemyModelPreviewControl
            //
            enemyModelPreviewControl.BorderStyle = BorderStyle.FixedSingle;
            enemyModelPreviewControl.Location = new Point(568, 242);
            enemyModelPreviewControl.MaximumSize = new Size(200, 150);
            enemyModelPreviewControl.MinimumSize = new Size(200, 150);
            enemyModelPreviewControl.Name = "enemyModelPreviewControl";
            enemyModelPreviewControl.Size = new Size(200, 150);
            enemyModelPreviewControl.TabIndex = 51;
            enemyModelPreviewControl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // 
            // comboBoxEnemyModelID
            // 
            comboBoxEnemyModelID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxEnemyModelID.FormattingEnabled = true;
            comboBoxEnemyModelID.Location = new Point(609, 213);
            comboBoxEnemyModelID.MaxLength = 4;
            comboBoxEnemyModelID.Name = "comboBoxEnemyModelID";
            comboBoxEnemyModelID.Size = new Size(150, 23);
            comboBoxEnemyModelID.TabIndex = 50;
            comboBoxEnemyModelID.SelectedIndexChanged += comboBoxEnemyModelID_SelectedIndexChanged;
            comboBoxEnemyModelID.TextChanged += comboBoxEnemyModelID_TextChanged;
            // 
            // labelEnemyModelID
            // 
            labelEnemyModelID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEnemyModelID.AutoSize = true;
            labelEnemyModelID.Location = new Point(609, 195);
            labelEnemyModelID.Name = "labelEnemyModelID";
            labelEnemyModelID.Size = new Size(58, 15);
            labelEnemyModelID.TabIndex = 49;
            labelEnemyModelID.Text = "Model ID:";
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
            comboBoxEnemyMorphItem.SelectedIndexChanged += EnemyDataChanged;
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
            checkBoxEnemyItemIsSteal.CheckedChanged += checkBoxEnemyItemIsSteal_CheckedChanged;
            // 
            // numericEnemyDropRate
            // 
            numericEnemyDropRate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericEnemyDropRate.Location = new Point(251, 108);
            numericEnemyDropRate.Maximum = new decimal(new int[] { 63, 0, 0, 0 });
            numericEnemyDropRate.Name = "numericEnemyDropRate";
            numericEnemyDropRate.Size = new Size(67, 23);
            numericEnemyDropRate.TabIndex = 6;
            numericEnemyDropRate.ValueChanged += numericEnemyDropRate_ValueChanged;
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
            comboBoxEnemyDropItemID.SelectedIndexChanged += comboBoxEnemyDropItemID_SelectedIndexChanged;
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
            listBoxEnemyItemDropRates.Location = new Point(6, 22);
            listBoxEnemyItemDropRates.Name = "listBoxEnemyItemDropRates";
            listBoxEnemyItemDropRates.Size = new Size(369, 64);
            listBoxEnemyItemDropRates.TabIndex = 0;
            listBoxEnemyItemDropRates.SelectedIndexChanged += listBoxEnemyItemDropRates_SelectedIndexChanged;
            // 
            // groupBoxEnemyAttacks
            // 
            groupBoxEnemyAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxEnemyAttacks.Controls.Add(buttonViewManipList);
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
            groupBoxEnemyAttacks.Size = new Size(363, 394);
            groupBoxEnemyAttacks.TabIndex = 45;
            groupBoxEnemyAttacks.TabStop = false;
            groupBoxEnemyAttacks.Text = "Attacks";
            // 
            // buttonViewManipList
            // 
            buttonViewManipList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonViewManipList.Location = new Point(145, 361);
            buttonViewManipList.Name = "buttonViewManipList";
            buttonViewManipList.Size = new Size(212, 23);
            buttonViewManipList.TabIndex = 8;
            buttonViewManipList.Text = "View manip list";
            buttonViewManipList.UseVisualStyleBackColor = true;
            buttonViewManipList.Click += buttonViewManipList_Click;
            // 
            // numericAttackAnimationIndex
            // 
            numericAttackAnimationIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericAttackAnimationIndex.Location = new Point(259, 332);
            numericAttackAnimationIndex.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericAttackAnimationIndex.Name = "numericAttackAnimationIndex";
            numericAttackAnimationIndex.Size = new Size(98, 23);
            numericAttackAnimationIndex.TabIndex = 7;
            numericAttackAnimationIndex.ValueChanged += numericAttackAnimationIndex_ValueChanged;
            // 
            // labelEnemyAttackAnimationIndex
            // 
            labelEnemyAttackAnimationIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEnemyAttackAnimationIndex.AutoSize = true;
            labelEnemyAttackAnimationIndex.Location = new Point(259, 314);
            labelEnemyAttackAnimationIndex.Name = "labelEnemyAttackAnimationIndex";
            labelEnemyAttackAnimationIndex.Size = new Size(98, 15);
            labelEnemyAttackAnimationIndex.TabIndex = 6;
            labelEnemyAttackAnimationIndex.Text = "Animation index:";
            // 
            // checkBoxEnemyAttackIsManipable
            // 
            checkBoxEnemyAttackIsManipable.AutoSize = true;
            checkBoxEnemyAttackIsManipable.Location = new Point(6, 364);
            checkBoxEnemyAttackIsManipable.Name = "checkBoxEnemyAttackIsManipable";
            checkBoxEnemyAttackIsManipable.Size = new Size(133, 19);
            checkBoxEnemyAttackIsManipable.TabIndex = 5;
            checkBoxEnemyAttackIsManipable.Text = "Include in manip list";
            checkBoxEnemyAttackIsManipable.UseVisualStyleBackColor = true;
            checkBoxEnemyAttackIsManipable.CheckedChanged += checkBoxEnemyAttackIsManipable_CheckedChanged;
            // 
            // comboBoxEnemyAttackCamID
            // 
            comboBoxEnemyAttackCamID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxEnemyAttackCamID.FormattingEnabled = true;
            comboBoxEnemyAttackCamID.Location = new Point(6, 331);
            comboBoxEnemyAttackCamID.MaxLength = 4;
            comboBoxEnemyAttackCamID.Name = "comboBoxEnemyAttackCamID";
            comboBoxEnemyAttackCamID.Size = new Size(247, 23);
            comboBoxEnemyAttackCamID.TabIndex = 4;
            comboBoxEnemyAttackCamID.TextChanged += comboBoxEnemyAttackCamID_TextChanged;
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
            comboBoxEnemyAttackID.Size = new Size(351, 23);
            comboBoxEnemyAttackID.TabIndex = 2;
            comboBoxEnemyAttackID.SelectedIndexChanged += comboBoxEnemyAttackID_SelectedIndexChanged;
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
            numericEnemyBackDamageMultiplier.Size = new Size(121, 23);
            numericEnemyBackDamageMultiplier.TabIndex = 44;
            numericEnemyBackDamageMultiplier.ValueChanged += EnemyDataChanged;
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
            tabPageEnemyAI.Size = new Size(768, 450);
            tabPageEnemyAI.TabIndex = 1;
            tabPageEnemyAI.Text = "A.I. Scripts";
            tabPageEnemyAI.UseVisualStyleBackColor = true;
            // 
            // scriptControlEnemyAI
            // 
            scriptControlEnemyAI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scriptControlEnemyAI.Location = new Point(181, 8);
            scriptControlEnemyAI.Name = "scriptControlEnemyAI";
            scriptControlEnemyAI.Size = new Size(581, 439);
            scriptControlEnemyAI.TabIndex = 5;
            scriptControlEnemyAI.DataChanged += scriptControlEnemyAI_DataChanged;
            scriptControlEnemyAI.ScriptAdded += scriptControlEnemyAI_DataChanged;
            scriptControlEnemyAI.ScriptRemoved += scriptControlEnemyAI_DataChanged;
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
            listBoxEnemyScripts.Items.AddRange(new object[] { "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter", "Magic Counter", "Battle Victory", "Pre-Action Setup", "Custom Event 1", "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5", "Custom Event 6", "Custom Event 7", "Custom Event 8" });
            listBoxEnemyScripts.Location = new Point(7, 26);
            listBoxEnemyScripts.Margin = new Padding(4, 3, 4, 3);
            listBoxEnemyScripts.Name = "listBoxEnemyScripts";
            listBoxEnemyScripts.Size = new Size(167, 244);
            listBoxEnemyScripts.TabIndex = 3;
            listBoxEnemyScripts.SelectedIndexChanged += listBoxEnemyScripts_SelectedIndexChanged;
            listBoxEnemyScripts.KeyDown += listBoxEnemyScripts_KeyDown;
            // 
            // tabPageAttackData
            // 
            tabPageAttackData.Controls.Add(attackFormControl);
            tabPageAttackData.Controls.Add(listBoxAttacks);
            tabPageAttackData.Location = new Point(4, 24);
            tabPageAttackData.Name = "tabPageAttackData";
            tabPageAttackData.Size = new Size(776, 478);
            tabPageAttackData.TabIndex = 4;
            tabPageAttackData.Text = "Attack Data";
            tabPageAttackData.UseVisualStyleBackColor = true;
            // 
            // attackFormControl
            // 
            attackFormControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            attackFormControl.Location = new Point(187, 9);
            attackFormControl.Name = "attackFormControl";
            attackFormControl.Size = new Size(581, 454);
            attackFormControl.TabIndex = 39;
            attackFormControl.DataChanged += AttackDataChanged;
            attackFormControl.NameChanged += textBoxEnemyName_TextChanged;
            attackFormControl.DescriptionChanged += AttackDataChanged;
            // 
            // listBoxAttacks
            // 
            listBoxAttacks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxAttacks.FormattingEnabled = true;
            listBoxAttacks.Location = new Point(9, 9);
            listBoxAttacks.Margin = new Padding(4, 3, 4, 3);
            listBoxAttacks.Name = "listBoxAttacks";
            listBoxAttacks.Size = new Size(174, 454);
            listBoxAttacks.TabIndex = 38;
            listBoxAttacks.SelectedIndexChanged += listBoxAttacks_SelectedIndexChanged;
            // 
            // tabPageFormationData
            // 
            tabPageFormationData.Controls.Add(tabControlFormationData);
            tabPageFormationData.Location = new Point(4, 24);
            tabPageFormationData.Name = "tabPageFormationData";
            tabPageFormationData.Size = new Size(776, 478);
            tabPageFormationData.TabIndex = 2;
            tabPageFormationData.Text = "Formation Data";
            tabPageFormationData.UseVisualStyleBackColor = true;
            // 
            // tabControlFormationData
            // 
            tabControlFormationData.Controls.Add(tabPageFormationDataInner);
            tabControlFormationData.Controls.Add(tabPageCameraData);
            tabControlFormationData.Controls.Add(tabPageFormationAI);
            tabControlFormationData.Dock = DockStyle.Fill;
            tabControlFormationData.Location = new Point(0, 0);
            tabControlFormationData.Name = "tabControlFormationData";
            tabControlFormationData.SelectedIndex = 0;
            tabControlFormationData.Size = new Size(776, 478);
            tabControlFormationData.TabIndex = 0;
            // 
            // tabPageFormationDataInner
            // 
            tabPageFormationDataInner.Controls.Add(groupBoxFormationSetupData);
            tabPageFormationDataInner.Controls.Add(groupBoxFormationEnemies);
            tabPageFormationDataInner.Location = new Point(4, 24);
            tabPageFormationDataInner.Name = "tabPageFormationDataInner";
            tabPageFormationDataInner.Padding = new Padding(3);
            tabPageFormationDataInner.Size = new Size(768, 450);
            tabPageFormationDataInner.TabIndex = 0;
            tabPageFormationDataInner.Text = "Formation Data";
            tabPageFormationDataInner.UseVisualStyleBackColor = true;
            // 
            // groupBoxFormationSetupData
            // 
            groupBoxFormationSetupData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxFormationSetupData.Controls.Add(battleFlagsControlFormation);
            groupBoxFormationSetupData.Controls.Add(labelFormationLocation);
            groupBoxFormationSetupData.Controls.Add(comboBoxFormationLocation);
            groupBoxFormationSetupData.Controls.Add(labelFormationNext);
            groupBoxFormationSetupData.Controls.Add(comboBoxFormationBattleType);
            groupBoxFormationSetupData.Controls.Add(comboBoxFormationNext);
            groupBoxFormationSetupData.Controls.Add(labelFormationBattleType);
            groupBoxFormationSetupData.Controls.Add(labelFormationEscapeCounter);
            groupBoxFormationSetupData.Controls.Add(groupBoxFormationBattleArena);
            groupBoxFormationSetupData.Controls.Add(numericFormationEscapeCounter);
            groupBoxFormationSetupData.Location = new Point(6, 182);
            groupBoxFormationSetupData.Name = "groupBoxFormationSetupData";
            groupBoxFormationSetupData.Size = new Size(756, 161);
            groupBoxFormationSetupData.TabIndex = 11;
            groupBoxFormationSetupData.TabStop = false;
            groupBoxFormationSetupData.Text = "Battle setup data";
            // 
            // battleFlagsControlFormation
            // 
            battleFlagsControlFormation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            battleFlagsControlFormation.Location = new Point(6, 66);
            battleFlagsControlFormation.Name = "battleFlagsControlFormation";
            battleFlagsControlFormation.Size = new Size(339, 89);
            battleFlagsControlFormation.TabIndex = 11;
            battleFlagsControlFormation.FlagsChanged += FormationDataChanged;
            // 
            // labelFormationLocation
            // 
            labelFormationLocation.AutoSize = true;
            labelFormationLocation.Location = new Point(6, 19);
            labelFormationLocation.Name = "labelFormationLocation";
            labelFormationLocation.Size = new Size(86, 15);
            labelFormationLocation.TabIndex = 0;
            labelFormationLocation.Text = "Battle location:";
            // 
            // comboBoxFormationLocation
            // 
            comboBoxFormationLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxFormationLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormationLocation.FormattingEnabled = true;
            comboBoxFormationLocation.Location = new Point(6, 37);
            comboBoxFormationLocation.Name = "comboBoxFormationLocation";
            comboBoxFormationLocation.Size = new Size(339, 23);
            comboBoxFormationLocation.TabIndex = 1;
            comboBoxFormationLocation.SelectedIndexChanged += FormationDataChanged;
            // 
            // labelFormationNext
            // 
            labelFormationNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelFormationNext.AutoSize = true;
            labelFormationNext.Location = new Point(351, 19);
            labelFormationNext.Name = "labelFormationNext";
            labelFormationNext.Size = new Size(77, 15);
            labelFormationNext.TabIndex = 2;
            labelFormationNext.Text = "Next fight ID:";
            // 
            // comboBoxFormationBattleType
            // 
            comboBoxFormationBattleType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFormationBattleType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormationBattleType.FormattingEnabled = true;
            comboBoxFormationBattleType.Location = new Point(351, 81);
            comboBoxFormationBattleType.Name = "comboBoxFormationBattleType";
            comboBoxFormationBattleType.Size = new Size(168, 23);
            comboBoxFormationBattleType.TabIndex = 8;
            comboBoxFormationBattleType.SelectedIndexChanged += FormationDataChanged;
            // 
            // comboBoxFormationNext
            // 
            comboBoxFormationNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFormationNext.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormationNext.FormattingEnabled = true;
            comboBoxFormationNext.Location = new Point(351, 37);
            comboBoxFormationNext.Name = "comboBoxFormationNext";
            comboBoxFormationNext.Size = new Size(168, 23);
            comboBoxFormationNext.TabIndex = 3;
            comboBoxFormationNext.SelectedIndexChanged += FormationDataChanged;
            // 
            // labelFormationBattleType
            // 
            labelFormationBattleType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelFormationBattleType.AutoSize = true;
            labelFormationBattleType.Location = new Point(351, 63);
            labelFormationBattleType.Name = "labelFormationBattleType";
            labelFormationBattleType.Size = new Size(66, 15);
            labelFormationBattleType.TabIndex = 7;
            labelFormationBattleType.Text = "Battle type:";
            // 
            // labelFormationEscapeCounter
            // 
            labelFormationEscapeCounter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelFormationEscapeCounter.AutoSize = true;
            labelFormationEscapeCounter.Location = new Point(351, 107);
            labelFormationEscapeCounter.Name = "labelFormationEscapeCounter";
            labelFormationEscapeCounter.Size = new Size(90, 15);
            labelFormationEscapeCounter.TabIndex = 4;
            labelFormationEscapeCounter.Text = "Escape counter:";
            // 
            // groupBoxFormationBattleArena
            // 
            groupBoxFormationBattleArena.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxFormationBattleArena.Controls.Add(comboBoxFormationBattleArena);
            groupBoxFormationBattleArena.Controls.Add(labelFormationBattleArena);
            groupBoxFormationBattleArena.Controls.Add(listBoxFormationBattleArena);
            groupBoxFormationBattleArena.Location = new Point(525, 19);
            groupBoxFormationBattleArena.Name = "groupBoxFormationBattleArena";
            groupBoxFormationBattleArena.Size = new Size(225, 136);
            groupBoxFormationBattleArena.TabIndex = 6;
            groupBoxFormationBattleArena.TabStop = false;
            groupBoxFormationBattleArena.Text = "Possible next fights in battle arena";
            // 
            // comboBoxFormationBattleArena
            // 
            comboBoxFormationBattleArena.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxFormationBattleArena.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormationBattleArena.FormattingEnabled = true;
            comboBoxFormationBattleArena.Location = new Point(6, 106);
            comboBoxFormationBattleArena.Name = "comboBoxFormationBattleArena";
            comboBoxFormationBattleArena.Size = new Size(213, 23);
            comboBoxFormationBattleArena.TabIndex = 5;
            comboBoxFormationBattleArena.SelectedIndexChanged += comboBoxFormationBattleArena_SelectedIndexChanged;
            // 
            // labelFormationBattleArena
            // 
            labelFormationBattleArena.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelFormationBattleArena.AutoSize = true;
            labelFormationBattleArena.Location = new Point(6, 88);
            labelFormationBattleArena.Name = "labelFormationBattleArena";
            labelFormationBattleArena.Size = new Size(96, 15);
            labelFormationBattleArena.TabIndex = 4;
            labelFormationBattleArena.Text = "Selected fight ID:";
            // 
            // listBoxFormationBattleArena
            // 
            listBoxFormationBattleArena.FormattingEnabled = true;
            listBoxFormationBattleArena.Location = new Point(6, 22);
            listBoxFormationBattleArena.Name = "listBoxFormationBattleArena";
            listBoxFormationBattleArena.Size = new Size(213, 64);
            listBoxFormationBattleArena.TabIndex = 0;
            listBoxFormationBattleArena.SelectedIndexChanged += listBoxFormationBattleArena_SelectedIndexChanged;
            // 
            // numericFormationEscapeCounter
            // 
            numericFormationEscapeCounter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericFormationEscapeCounter.Location = new Point(351, 125);
            numericFormationEscapeCounter.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericFormationEscapeCounter.Name = "numericFormationEscapeCounter";
            numericFormationEscapeCounter.Size = new Size(168, 23);
            numericFormationEscapeCounter.TabIndex = 5;
            numericFormationEscapeCounter.ValueChanged += FormationDataChanged;
            // 
            // groupBoxFormationEnemies
            // 
            groupBoxFormationEnemies.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxFormationEnemies.Controls.Add(coverFlagsControlFormationEnemy);
            groupBoxFormationEnemies.Controls.Add(initialConditionControlEnemy);
            groupBoxFormationEnemies.Controls.Add(numericFormationEnemyRow);
            groupBoxFormationEnemies.Controls.Add(labelFormationEnemyRow);
            groupBoxFormationEnemies.Controls.Add(numericFormationEnemyZ);
            groupBoxFormationEnemies.Controls.Add(labelFormationEnemyZ);
            groupBoxFormationEnemies.Controls.Add(numericFormationEnemyY);
            groupBoxFormationEnemies.Controls.Add(labelFormationEnemyY);
            groupBoxFormationEnemies.Controls.Add(numericFormationEnemyX);
            groupBoxFormationEnemies.Controls.Add(labelFormationEnemyX);
            groupBoxFormationEnemies.Controls.Add(comboBoxFormationSelectedEnemy);
            groupBoxFormationEnemies.Controls.Add(labelFormationSelectedEnemy);
            groupBoxFormationEnemies.Controls.Add(listBoxFormationEnemies);
            groupBoxFormationEnemies.Location = new Point(6, 6);
            groupBoxFormationEnemies.Name = "groupBoxFormationEnemies";
            groupBoxFormationEnemies.Size = new Size(756, 170);
            groupBoxFormationEnemies.TabIndex = 2;
            groupBoxFormationEnemies.TabStop = false;
            groupBoxFormationEnemies.Text = "Enemies in formation";
            // 
            // coverFlagsControlFormationEnemy
            // 
            coverFlagsControlFormationEnemy.Location = new Point(531, 19);
            coverFlagsControlFormationEnemy.Name = "coverFlagsControlFormationEnemy";
            coverFlagsControlFormationEnemy.Size = new Size(213, 141);
            coverFlagsControlFormationEnemy.TabIndex = 12;
            coverFlagsControlFormationEnemy.FlagsChanged += FormationEnemyDataChanged;
            // 
            // initialConditionControlEnemy
            // 
            initialConditionControlEnemy.Location = new Point(200, 66);
            initialConditionControlEnemy.Name = "initialConditionControlEnemy";
            initialConditionControlEnemy.Size = new Size(319, 94);
            initialConditionControlEnemy.TabIndex = 11;
            initialConditionControlEnemy.FlagsChanged += FormationEnemyDataChanged;
            // 
            // numericFormationEnemyRow
            // 
            numericFormationEnemyRow.Location = new Point(449, 37);
            numericFormationEnemyRow.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericFormationEnemyRow.Name = "numericFormationEnemyRow";
            numericFormationEnemyRow.Size = new Size(70, 23);
            numericFormationEnemyRow.TabIndex = 10;
            numericFormationEnemyRow.ValueChanged += FormationEnemyDataChanged;
            // 
            // labelFormationEnemyRow
            // 
            labelFormationEnemyRow.AutoSize = true;
            labelFormationEnemyRow.Location = new Point(449, 19);
            labelFormationEnemyRow.Name = "labelFormationEnemyRow";
            labelFormationEnemyRow.Size = new Size(33, 15);
            labelFormationEnemyRow.TabIndex = 9;
            labelFormationEnemyRow.Text = "Row:";
            // 
            // numericFormationEnemyZ
            // 
            numericFormationEnemyZ.Location = new Point(351, 37);
            numericFormationEnemyZ.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericFormationEnemyZ.Name = "numericFormationEnemyZ";
            numericFormationEnemyZ.Size = new Size(70, 23);
            numericFormationEnemyZ.TabIndex = 8;
            numericFormationEnemyZ.ValueChanged += FormationEnemyDataChanged;
            // 
            // labelFormationEnemyZ
            // 
            labelFormationEnemyZ.AutoSize = true;
            labelFormationEnemyZ.Location = new Point(351, 19);
            labelFormationEnemyZ.Name = "labelFormationEnemyZ";
            labelFormationEnemyZ.Size = new Size(17, 15);
            labelFormationEnemyZ.TabIndex = 7;
            labelFormationEnemyZ.Text = "Z:";
            // 
            // numericFormationEnemyY
            // 
            numericFormationEnemyY.Location = new Point(275, 37);
            numericFormationEnemyY.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericFormationEnemyY.Name = "numericFormationEnemyY";
            numericFormationEnemyY.Size = new Size(70, 23);
            numericFormationEnemyY.TabIndex = 6;
            numericFormationEnemyY.ValueChanged += FormationEnemyDataChanged;
            // 
            // labelFormationEnemyY
            // 
            labelFormationEnemyY.AutoSize = true;
            labelFormationEnemyY.Location = new Point(275, 19);
            labelFormationEnemyY.Name = "labelFormationEnemyY";
            labelFormationEnemyY.Size = new Size(17, 15);
            labelFormationEnemyY.TabIndex = 5;
            labelFormationEnemyY.Text = "Y:";
            // 
            // numericFormationEnemyX
            // 
            numericFormationEnemyX.Location = new Point(200, 37);
            numericFormationEnemyX.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericFormationEnemyX.Name = "numericFormationEnemyX";
            numericFormationEnemyX.Size = new Size(70, 23);
            numericFormationEnemyX.TabIndex = 4;
            numericFormationEnemyX.ValueChanged += FormationEnemyDataChanged;
            // 
            // labelFormationEnemyX
            // 
            labelFormationEnemyX.AutoSize = true;
            labelFormationEnemyX.Location = new Point(200, 19);
            labelFormationEnemyX.Name = "labelFormationEnemyX";
            labelFormationEnemyX.Size = new Size(17, 15);
            labelFormationEnemyX.TabIndex = 3;
            labelFormationEnemyX.Text = "X:";
            // 
            // comboBoxFormationSelectedEnemy
            // 
            comboBoxFormationSelectedEnemy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxFormationSelectedEnemy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormationSelectedEnemy.FormattingEnabled = true;
            comboBoxFormationSelectedEnemy.Location = new Point(6, 137);
            comboBoxFormationSelectedEnemy.Name = "comboBoxFormationSelectedEnemy";
            comboBoxFormationSelectedEnemy.Size = new Size(188, 23);
            comboBoxFormationSelectedEnemy.TabIndex = 2;
            comboBoxFormationSelectedEnemy.SelectedIndexChanged += comboBoxFormationSelectedEnemy_SelectedIndexChanged;
            // 
            // labelFormationSelectedEnemy
            // 
            labelFormationSelectedEnemy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelFormationSelectedEnemy.AutoSize = true;
            labelFormationSelectedEnemy.Location = new Point(6, 119);
            labelFormationSelectedEnemy.Name = "labelFormationSelectedEnemy";
            labelFormationSelectedEnemy.Size = new Size(93, 15);
            labelFormationSelectedEnemy.TabIndex = 1;
            labelFormationSelectedEnemy.Text = "Selected enemy:";
            // 
            // listBoxFormationEnemies
            // 
            listBoxFormationEnemies.FormattingEnabled = true;
            listBoxFormationEnemies.Location = new Point(6, 22);
            listBoxFormationEnemies.Name = "listBoxFormationEnemies";
            listBoxFormationEnemies.Size = new Size(188, 94);
            listBoxFormationEnemies.TabIndex = 0;
            listBoxFormationEnemies.SelectedIndexChanged += listBoxFormationEnemies_SelectedIndexChanged;
            // 
            // tabPageCameraData
            // 
            tabPageCameraData.Controls.Add(cameraPositionControlExtra3);
            tabPageCameraData.Controls.Add(cameraPositionControlExtra2);
            tabPageCameraData.Controls.Add(cameraPositionControlExtra1);
            tabPageCameraData.Controls.Add(cameraPositionControlMain);
            tabPageCameraData.Controls.Add(numericFormationPreBattleCamPosition);
            tabPageCameraData.Controls.Add(labelFormationCamPreBattlePosition);
            tabPageCameraData.Location = new Point(4, 24);
            tabPageCameraData.Name = "tabPageCameraData";
            tabPageCameraData.Size = new Size(768, 450);
            tabPageCameraData.TabIndex = 4;
            tabPageCameraData.Text = "Camera Data";
            tabPageCameraData.UseVisualStyleBackColor = true;
            // 
            // cameraPositionControlExtra3
            // 
            cameraPositionControlExtra3.Location = new Point(243, 184);
            cameraPositionControlExtra3.Name = "cameraPositionControlExtra3";
            cameraPositionControlExtra3.Size = new Size(230, 172);
            cameraPositionControlExtra3.TabIndex = 14;
            cameraPositionControlExtra3.DataChanged += FormationDataChanged;
            // 
            // cameraPositionControlExtra2
            // 
            cameraPositionControlExtra2.Location = new Point(7, 184);
            cameraPositionControlExtra2.Name = "cameraPositionControlExtra2";
            cameraPositionControlExtra2.Size = new Size(230, 172);
            cameraPositionControlExtra2.TabIndex = 13;
            cameraPositionControlExtra2.DataChanged += FormationDataChanged;
            // 
            // cameraPositionControlExtra1
            // 
            cameraPositionControlExtra1.Location = new Point(243, 6);
            cameraPositionControlExtra1.Name = "cameraPositionControlExtra1";
            cameraPositionControlExtra1.Size = new Size(230, 172);
            cameraPositionControlExtra1.TabIndex = 12;
            cameraPositionControlExtra1.DataChanged += FormationDataChanged;
            // 
            // cameraPositionControlMain
            // 
            cameraPositionControlMain.Location = new Point(6, 6);
            cameraPositionControlMain.Name = "cameraPositionControlMain";
            cameraPositionControlMain.Size = new Size(230, 172);
            cameraPositionControlMain.TabIndex = 11;
            cameraPositionControlMain.DataChanged += FormationDataChanged;
            // 
            // numericFormationPreBattleCamPosition
            // 
            numericFormationPreBattleCamPosition.Location = new Point(479, 24);
            numericFormationPreBattleCamPosition.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericFormationPreBattleCamPosition.Name = "numericFormationPreBattleCamPosition";
            numericFormationPreBattleCamPosition.Size = new Size(108, 23);
            numericFormationPreBattleCamPosition.TabIndex = 10;
            numericFormationPreBattleCamPosition.ValueChanged += FormationDataChanged;
            // 
            // labelFormationCamPreBattlePosition
            // 
            labelFormationCamPreBattlePosition.AutoSize = true;
            labelFormationCamPreBattlePosition.Location = new Point(479, 6);
            labelFormationCamPreBattlePosition.Name = "labelFormationCamPreBattlePosition";
            labelFormationCamPreBattlePosition.Size = new Size(108, 15);
            labelFormationCamPreBattlePosition.TabIndex = 9;
            labelFormationCamPreBattlePosition.Text = "Pre-battle position:";
            // 
            // tabPageFormationAI
            // 
            tabPageFormationAI.Controls.Add(scriptControlFormations);
            tabPageFormationAI.Controls.Add(labelFormationScripts);
            tabPageFormationAI.Controls.Add(listBoxFormationScripts);
            tabPageFormationAI.Location = new Point(4, 24);
            tabPageFormationAI.Name = "tabPageFormationAI";
            tabPageFormationAI.Size = new Size(768, 450);
            tabPageFormationAI.TabIndex = 3;
            tabPageFormationAI.Text = "Formation A.I.";
            tabPageFormationAI.UseVisualStyleBackColor = true;
            // 
            // scriptControlFormations
            // 
            scriptControlFormations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scriptControlFormations.Location = new Point(181, 8);
            scriptControlFormations.Name = "scriptControlFormations";
            scriptControlFormations.Size = new Size(584, 439);
            scriptControlFormations.TabIndex = 8;
            scriptControlFormations.DataChanged += scriptControlFormations_DataChanged;
            scriptControlFormations.ScriptAdded += scriptControlFormations_DataChanged;
            scriptControlFormations.ScriptRemoved += scriptControlFormations_DataChanged;
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
            listBoxFormationScripts.Items.AddRange(new object[] { "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter", "Magic Counter", "Battle Victory", "Pre-Action Setup", "Custom Event 1", "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5", "Custom Event 6", "Custom Event 7", "Custom Event 8" });
            listBoxFormationScripts.Location = new Point(7, 26);
            listBoxFormationScripts.Margin = new Padding(4, 3, 4, 3);
            listBoxFormationScripts.Name = "listBoxFormationScripts";
            listBoxFormationScripts.Size = new Size(167, 244);
            listBoxFormationScripts.TabIndex = 6;
            listBoxFormationScripts.SelectedIndexChanged += listBoxFormationScripts_SelectedIndexChanged;
            listBoxFormationScripts.KeyDown += listBoxFormationScripts_KeyDown;
            // 
            // panelTop
            // 
            panelTop.BackColor = SystemColors.Window;
            panelTop.Controls.Add(toolStripMain);
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
            panelTop.Size = new Size(784, 90);
            panelTop.TabIndex = 11;
            // 
            // toolStripMain
            // 
            toolStripMain.GripStyle = ToolStripGripStyle.Hidden;
            toolStripMain.Items.AddRange(new ToolStripItem[] { toolStripDropDownFile, toolStripDropDownEdit });
            toolStripMain.Location = new Point(0, 0);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Padding = new Padding(5, 0, 1, 0);
            toolStripMain.Size = new Size(784, 25);
            toolStripMain.TabIndex = 15;
            toolStripMain.Text = "toolStripMain";
            // 
            // toolStripDropDownFile
            // 
            toolStripDropDownFile.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownFile.DropDownItems.AddRange(new ToolStripItem[] { saveScenebinToolStripMenuItem, importScenesToolStripMenuItem, exportScenesToolStripMenuItem });
            toolStripDropDownFile.Image = (Image)resources.GetObject("toolStripDropDownFile.Image");
            toolStripDropDownFile.ImageTransparentColor = Color.Magenta;
            toolStripDropDownFile.Name = "toolStripDropDownFile";
            toolStripDropDownFile.ShowDropDownArrow = false;
            toolStripDropDownFile.Size = new Size(29, 22);
            toolStripDropDownFile.Text = "File";
            // 
            // saveScenebinToolStripMenuItem
            // 
            saveScenebinToolStripMenuItem.Name = "saveScenebinToolStripMenuItem";
            saveScenebinToolStripMenuItem.Size = new Size(165, 22);
            saveScenebinToolStripMenuItem.Text = "Save scene.bin";
            saveScenebinToolStripMenuItem.Click += buttonSave_Click;
            // 
            // importScenesToolStripMenuItem
            // 
            importScenesToolStripMenuItem.Name = "importScenesToolStripMenuItem";
            importScenesToolStripMenuItem.Size = new Size(165, 22);
            importScenesToolStripMenuItem.Text = "Import scene(s)...";
            importScenesToolStripMenuItem.Click += buttonImport_Click;
            // 
            // exportScenesToolStripMenuItem
            // 
            exportScenesToolStripMenuItem.Name = "exportScenesToolStripMenuItem";
            exportScenesToolStripMenuItem.Size = new Size(165, 22);
            exportScenesToolStripMenuItem.Text = "Export scene(s)...";
            exportScenesToolStripMenuItem.Click += buttonExport_Click;
            // 
            // toolStripDropDownEdit
            // 
            toolStripDropDownEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownEdit.DropDownItems.AddRange(new ToolStripItem[] { selectedSceneToolStripMenuItem, enemyToolStripMenuItem, selectedAttackToolStripMenuItem, selectedFormationToolStripMenuItem });
            toolStripDropDownEdit.Image = (Image)resources.GetObject("toolStripDropDownEdit.Image");
            toolStripDropDownEdit.ImageTransparentColor = Color.Magenta;
            toolStripDropDownEdit.Name = "toolStripDropDownEdit";
            toolStripDropDownEdit.ShowDropDownArrow = false;
            toolStripDropDownEdit.Size = new Size(31, 22);
            toolStripDropDownEdit.Text = "Edit";
            // 
            // selectedSceneToolStripMenuItem
            // 
            selectedSceneToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sceneCopyToolStripMenuItem, scenePasteToolStripMenuItem, sceneClearToolStripMenuItem });
            selectedSceneToolStripMenuItem.Name = "selectedSceneToolStripMenuItem";
            selectedSceneToolStripMenuItem.Size = new Size(183, 22);
            selectedSceneToolStripMenuItem.Text = "Selected scene...";
            // 
            // sceneCopyToolStripMenuItem
            // 
            sceneCopyToolStripMenuItem.Name = "sceneCopyToolStripMenuItem";
            sceneCopyToolStripMenuItem.Size = new Size(102, 22);
            sceneCopyToolStripMenuItem.Text = "Copy";
            sceneCopyToolStripMenuItem.Click += sceneCopyToolStripMenuItem_Click;
            // 
            // scenePasteToolStripMenuItem
            // 
            scenePasteToolStripMenuItem.Name = "scenePasteToolStripMenuItem";
            scenePasteToolStripMenuItem.Size = new Size(102, 22);
            scenePasteToolStripMenuItem.Text = "Paste";
            scenePasteToolStripMenuItem.Click += scenePasteToolStripMenuItem_Click;
            // 
            // sceneClearToolStripMenuItem
            // 
            sceneClearToolStripMenuItem.Name = "sceneClearToolStripMenuItem";
            sceneClearToolStripMenuItem.Size = new Size(102, 22);
            sceneClearToolStripMenuItem.Text = "Clear";
            sceneClearToolStripMenuItem.Click += sceneClearToolStripMenuItem_Click;
            // 
            // enemyToolStripMenuItem
            // 
            enemyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createNewEnemyToolStripMenuItem, enemyCopyToolStripMenuItem, enemyPasteToolStripMenuItem, enemyDeleteToolStripMenuItem });
            enemyToolStripMenuItem.Name = "enemyToolStripMenuItem";
            enemyToolStripMenuItem.Size = new Size(183, 22);
            enemyToolStripMenuItem.Text = "Selected enemy...";
            // 
            // createNewEnemyToolStripMenuItem
            // 
            createNewEnemyToolStripMenuItem.Name = "createNewEnemyToolStripMenuItem";
            createNewEnemyToolStripMenuItem.Size = new Size(172, 22);
            createNewEnemyToolStripMenuItem.Text = "Create new enemy";
            createNewEnemyToolStripMenuItem.Click += createNewEnemyToolStripMenuItem_Click;
            // 
            // enemyCopyToolStripMenuItem
            // 
            enemyCopyToolStripMenuItem.Name = "enemyCopyToolStripMenuItem";
            enemyCopyToolStripMenuItem.Size = new Size(172, 22);
            enemyCopyToolStripMenuItem.Text = "Copy";
            enemyCopyToolStripMenuItem.Click += enemyCopyToolStripMenuItem_Click;
            // 
            // enemyPasteToolStripMenuItem
            // 
            enemyPasteToolStripMenuItem.Name = "enemyPasteToolStripMenuItem";
            enemyPasteToolStripMenuItem.Size = new Size(172, 22);
            enemyPasteToolStripMenuItem.Text = "Paste";
            enemyPasteToolStripMenuItem.Click += enemyPasteToolStripMenuItem_Click;
            // 
            // enemyDeleteToolStripMenuItem
            // 
            enemyDeleteToolStripMenuItem.Name = "enemyDeleteToolStripMenuItem";
            enemyDeleteToolStripMenuItem.Size = new Size(172, 22);
            enemyDeleteToolStripMenuItem.Text = "Delete";
            enemyDeleteToolStripMenuItem.Click += enemyDeleteToolStripMenuItem_Click;
            // 
            // selectedAttackToolStripMenuItem
            // 
            selectedAttackToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createNewAttackToolStripMenuItem, attackCopyToolStripMenuItem, attackPasteToolStripMenuItem, attackDeleteToolStripMenuItem });
            selectedAttackToolStripMenuItem.Name = "selectedAttackToolStripMenuItem";
            selectedAttackToolStripMenuItem.Size = new Size(183, 22);
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
            // selectedFormationToolStripMenuItem
            // 
            selectedFormationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { formationCopyToolStripMenuItem, formationPasteToolStripMenuItem, formationClearToolStripMenuItem });
            selectedFormationToolStripMenuItem.Name = "selectedFormationToolStripMenuItem";
            selectedFormationToolStripMenuItem.Size = new Size(183, 22);
            selectedFormationToolStripMenuItem.Text = "Selected formation...";
            // 
            // formationCopyToolStripMenuItem
            // 
            formationCopyToolStripMenuItem.Name = "formationCopyToolStripMenuItem";
            formationCopyToolStripMenuItem.Size = new Size(102, 22);
            formationCopyToolStripMenuItem.Text = "Copy";
            // 
            // formationPasteToolStripMenuItem
            // 
            formationPasteToolStripMenuItem.Name = "formationPasteToolStripMenuItem";
            formationPasteToolStripMenuItem.Size = new Size(102, 22);
            formationPasteToolStripMenuItem.Text = "Paste";
            // 
            // formationClearToolStripMenuItem
            // 
            formationClearToolStripMenuItem.Name = "formationClearToolStripMenuItem";
            formationClearToolStripMenuItem.Size = new Size(102, 22);
            formationClearToolStripMenuItem.Text = "Clear";
            // 
            // buttonSearch
            // 
            buttonSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSearch.Location = new Point(681, 59);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(90, 23);
            buttonSearch.TabIndex = 14;
            buttonSearch.Text = "Search...";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // comboBoxFormation
            // 
            comboBoxFormation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxFormation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormation.FormattingEnabled = true;
            comboBoxFormation.Location = new Point(344, 59);
            comboBoxFormation.Name = "comboBoxFormation";
            comboBoxFormation.Size = new Size(331, 23);
            comboBoxFormation.TabIndex = 13;
            comboBoxFormation.SelectedIndexChanged += comboBoxFormation_SelectedIndexChanged;
            // 
            // labelFormation
            // 
            labelFormation.AutoSize = true;
            labelFormation.Location = new Point(273, 62);
            labelFormation.Name = "labelFormation";
            labelFormation.Size = new Size(65, 15);
            labelFormation.TabIndex = 12;
            labelFormation.Text = "Formation:";
            // 
            // comboBoxEnemy
            // 
            comboBoxEnemy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnemy.FormattingEnabled = true;
            comboBoxEnemy.Location = new Point(67, 59);
            comboBoxEnemy.Name = "comboBoxEnemy";
            comboBoxEnemy.Size = new Size(200, 23);
            comboBoxEnemy.TabIndex = 11;
            comboBoxEnemy.SelectedIndexChanged += comboBoxEnemy_SelectedIndexChanged;
            // 
            // labelEnemy
            // 
            labelEnemy.AutoSize = true;
            labelEnemy.Location = new Point(15, 62);
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
            panelBottom.Location = new Point(0, 596);
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
            ClientSize = new Size(784, 661);
            Controls.Add(tabControlMain);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 600);
            Name = "SceneEditorForm";
            Text = "Scarlet - Scene Editor";
            FormClosing += SceneEditorForm_FormClosing;
            FormClosed += SceneEditorForm_FormClosed;
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
            tabPageFormationData.ResumeLayout(false);
            tabControlFormationData.ResumeLayout(false);
            tabPageFormationDataInner.ResumeLayout(false);
            groupBoxFormationSetupData.ResumeLayout(false);
            groupBoxFormationSetupData.PerformLayout();
            groupBoxFormationBattleArena.ResumeLayout(false);
            groupBoxFormationBattleArena.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericFormationEscapeCounter).EndInit();
            groupBoxFormationEnemies.ResumeLayout(false);
            groupBoxFormationEnemies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericFormationEnemyRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericFormationEnemyZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericFormationEnemyY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericFormationEnemyX).EndInit();
            tabPageCameraData.ResumeLayout(false);
            tabPageCameraData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericFormationPreBattleCamPosition).EndInit();
            tabPageFormationAI.ResumeLayout(false);
            tabPageFormationAI.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
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
        private ListBox listBoxEnemyElementResistances;
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
        private ListBox listBoxAttacks;
        private TabControl tabControlFormationData;
        private TabPage tabPageFormationDataInner;
        private ComboBox comboBoxFormation;
        private Label labelFormation;
        private ProgressBar progressBarSaving;
        private Button buttonSearch;
        private TabPage tabPageCameraData;
        private Label labelFormationLocation;
        private ComboBox comboBoxFormationLocation;
        private Label labelFormationNext;
        private Label labelFormationEscapeCounter;
        private NumericUpDown numericFormationEscapeCounter;
        private ComboBox comboBoxFormationNext;
        private GroupBox groupBoxFormationBattleArena;
        private ComboBox comboBoxFormationBattleArena;
        private Label labelFormationBattleArena;
        private ListBox listBoxFormationBattleArena;
        private ComboBox comboBoxFormationBattleType;
        private Label labelFormationBattleType;
        private NumericUpDown numericFormationPreBattleCamPosition;
        private Label labelFormationCamPreBattlePosition;
        private GroupBox groupBoxFormationSetupData;
        private BattleFlagsControl battleFlagsControlFormation;
        private ListBox listBoxFormationEnemies;
        private GroupBox groupBoxFormationEnemies;
        private Label labelFormationSelectedEnemy;
        private ComboBox comboBoxFormationSelectedEnemy;
        private NumericUpDown numericFormationEnemyZ;
        private Label labelFormationEnemyZ;
        private NumericUpDown numericFormationEnemyY;
        private Label labelFormationEnemyY;
        private NumericUpDown numericFormationEnemyX;
        private Label labelFormationEnemyX;
        private Label labelFormationEnemyRow;
        private NumericUpDown numericFormationEnemyRow;
        private InitialConditionControl initialConditionControlEnemy;
        private CoverFlagsControl coverFlagsControlFormationEnemy;
        private Controls.CameraPositionControl cameraPositionControlExtra2;
        private Controls.CameraPositionControl cameraPositionControlExtra1;
        private Controls.CameraPositionControl cameraPositionControlMain;
        private Button buttonViewManipList;
        private ComboBox comboBoxEnemyModelID;
        private Label labelEnemyModelID;
        private ToolStrip toolStripMain;
        private ToolStripDropDownButton toolStripDropDownFile;
        private ToolStripDropDownButton toolStripDropDownEdit;
        private ToolStripMenuItem enemyToolStripMenuItem;
        private ToolStripMenuItem enemyCopyToolStripMenuItem;
        private ToolStripMenuItem enemyPasteToolStripMenuItem;
        private ToolStripMenuItem selectedAttackToolStripMenuItem;
        private ToolStripMenuItem attackCopyToolStripMenuItem;
        private ToolStripMenuItem attackPasteToolStripMenuItem;
        private ToolStripMenuItem saveScenebinToolStripMenuItem;
        private ToolStripMenuItem importScenesToolStripMenuItem;
        private ToolStripMenuItem exportScenesToolStripMenuItem;
        private ToolStripMenuItem createNewEnemyToolStripMenuItem;
        private ToolStripMenuItem createNewAttackToolStripMenuItem;
        private ToolStripMenuItem enemyDeleteToolStripMenuItem;
        private ToolStripMenuItem attackDeleteToolStripMenuItem;
        private ToolStripMenuItem selectedSceneToolStripMenuItem;
        private ToolStripMenuItem sceneCopyToolStripMenuItem;
        private ToolStripMenuItem scenePasteToolStripMenuItem;
        private ToolStripMenuItem sceneClearToolStripMenuItem;
        private ToolStripMenuItem selectedFormationToolStripMenuItem;
        private ToolStripMenuItem formationCopyToolStripMenuItem;
        private ToolStripMenuItem formationPasteToolStripMenuItem;
        private ToolStripMenuItem formationClearToolStripMenuItem;
        private Controls.CameraPositionControl cameraPositionControlExtra3;
        private Shared.Controls.AttackFormControl attackFormControl;
        private Controls.ModelPreviewControl enemyModelPreviewControl;
    }
}