using FF7Scarlet.AIEditor;
using FF7Scarlet.KernelEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Battle;

namespace FF7Scarlet.SceneEditor
{
    public partial class SceneEditorForm : Form
    {
        #region Properties

        private const string WINDOW_TITLE = "Scarlet - Scene Editor";
        private readonly string[] SCRIPT_LIST = new string[Script.SCRIPT_COUNT]
        {
            "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter",
            "Magic Counter", "Battle Victory", "Pre-Action Setup", "Custom Event 1",
            "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5",
            "Custom Event 6", "Custom Event 7", "Custom Event 8"
        };
        private Scene[] sceneList;
        private Dictionary<ushort, Attack> syncedAttacks;
        private List<ResistRates> resistList;
        private List<Attack> validAttacks = new();
        private bool loading = false, unsavedChanges = false, processing = false;

        private Scene? SelectedScene
        {
            get
            {
                if (SelectedSceneIndex == -1) { return null; }
                else { return sceneList[SelectedSceneIndex]; }
            }
        }
        private int SelectedSceneIndex
        {
            get { return comboBoxSceneList.SelectedIndex; }
        }
        private Enemy? SelectedEnemy
        {
            get
            {
                if (SelectedEnemyIndex >= 0 && SelectedEnemyIndex < Scene.ENEMY_COUNT)
                {
                    return SelectedScene?.Enemies[SelectedEnemyIndex];
                }
                return null;

            }
        }
        private int SelectedEnemyIndex
        {
            get { return comboBoxEnemy.SelectedIndex; }
        }
        private Attack? SelectedAttack
        {
            get
            {
                if (SelectedAttackIndex >= 0 && SelectedAttackIndex < Scene.ATTACK_COUNT)
                {
                    return SelectedScene?.AttackList[SelectedAttackIndex];
                }
                return null;
            }
        }
        private int SelectedAttackIndex
        {
            get { return listBoxAttacks.SelectedIndex; }
        }
        private Formation? SelectedFormation
        {
            get
            {
                if (SelectedFormationIndex >= 0 && SelectedFormationIndex < Scene.FORMATION_COUNT)
                {
                    return SelectedScene?.Formations[SelectedFormationIndex];
                }
                return null;

            }
        }
        private int SelectedFormationIndex
        {
            get { return comboBoxFormation.SelectedIndex; }
        }

        #endregion

        #region Constructors

        public SceneEditorForm(Dictionary<ushort, Attack> syncedAttacks)
        {
            InitializeComponent();

            //set data for various controls
            numericEnemyHP.Maximum = uint.MaxValue;
            numericEnemyEXP.Maximum = uint.MaxValue;
            numericEnemyGil.Maximum = uint.MaxValue;

            comboBoxEnemyResistElement.Items.Add("None");
            foreach (var e in Enum.GetNames<Elements>())
            {
                comboBoxEnemyResistElement.Items.Add(e);
            }
            foreach (var s in Enum.GetNames<Statuses>())
            {
                comboBoxEnemyResistElement.Items.Add($"{StringParser.AddSpace(s)} (status)");
            }
            resistList = Enum.GetValues<ResistRates>().ToList();
            foreach (var r in resistList)
            {
                comboBoxEnemyResistRate.Items.Add(r);
            }
            comboBoxAttackStatusChange.Items.Add("None");
            foreach (var s in Enum.GetValues<StatusChange>())
            {
                if (s != StatusChange.None)
                {
                    comboBoxAttackStatusChange.Items.Add(s);
                }
            }
            comboBoxAttackConditionSubMenu.Items.Add("None");
            foreach (var c in Enum.GetValues<AttackConditions>())
            {
                if (c != AttackConditions.None)
                {
                    comboBoxAttackConditionSubMenu.Items.Add(c);
                }
            }

            //kernel-synced data
            LoadKernelData();

            //create private version of scene data that can be edited freely
            sceneList = DataManager.CopySceneList();
            this.syncedAttacks = syncedAttacks;
            for (int i = 0; i < DataManager.SCENE_COUNT; ++i)
            {
                comboBoxSceneList.Items.Add($"{i}: {sceneList[i].GetEnemyNames()}");
                if (syncedAttacks.Count > 0)
                {
                    foreach (var a in syncedAttacks.Values)
                    {
                        sceneList[i].SyncAttack(a);
                    }
                }
            }
            comboBoxSceneList.SelectedIndex = 0;
        }

        #endregion

        #region User Methods

        private void SetUnsaved(bool unsaved)
        {
            unsavedChanges = unsaved;
            Text = $"{(unsaved ? "*" : "")}{WINDOW_TITLE}";
        }

        private void LoadKernelData()
        {
            comboBoxEnemyDropItemID.Items.Clear();
            comboBoxEnemyMorphItem.Items.Clear();

            comboBoxEnemyDropItemID.Items.Add("None");
            comboBoxEnemyMorphItem.Items.Add("None");
            if (DataManager.KernelFileIsLoaded && DataManager.Kernel != null)
            {
                foreach (var item in DataManager.Kernel.ItemNames.Strings)
                {
                    comboBoxEnemyDropItemID.Items.Add(item);
                    comboBoxEnemyMorphItem.Items.Add(item);
                }
                foreach (var wpn in DataManager.Kernel.WeaponNames.Strings)
                {
                    comboBoxEnemyDropItemID.Items.Add(wpn);
                    comboBoxEnemyMorphItem.Items.Add(wpn);
                }
                foreach (var armor in DataManager.Kernel.ArmorNames.Strings)
                {
                    comboBoxEnemyDropItemID.Items.Add(armor);
                    comboBoxEnemyMorphItem.Items.Add(armor);
                }
                foreach (var acc in DataManager.Kernel.AccessoryNames.Strings)
                {
                    comboBoxEnemyDropItemID.Items.Add(acc);
                    comboBoxEnemyMorphItem.Items.Add(acc);
                }
            }
            else
            {
                groupBoxEnemyItemDropRates.Enabled = false;
                comboBoxEnemyMorphItem.Enabled = false;
            }
            comboBoxEnemyDropItemID.SelectedIndex = 0;
            EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, false, false);
        }

        private void LoadSceneData(Scene scene, bool clearLoadingWhenDone)
        {
            loading = true;
            scene.ParseAIScripts();
            int i;

            //get attacks
            listBoxAttacks.Items.Clear();
            for (ushort j = 0; j < Scene.ATTACK_COUNT; ++j)
            {
                var a = scene.AttackList[j];
                if (a == null)
                {
                    listBoxAttacks.Items.Add("(empty)");
                }
                else
                {
                    listBoxAttacks.Items.Add(a.GetNameString());
                }
            }

            validAttacks =
                (from a in scene.AttackList
                 where a != null
                 select a).ToList();

            comboBoxEnemyAttackID.Items.Clear();
            comboBoxEnemyAttackID.Items.Add("None");
            foreach (var a in validAttacks)
            {
                comboBoxEnemyAttackID.Items.Add(a.GetNameString());
            }
            comboBoxEnemyAttackID.SelectedIndex = 0;
            comboBoxEnemyAttackCamID.Text = "FFFF";
            EnableOrDisableGroupBox(groupBoxEnemyAttacks, false, false);

            //get enemies
            comboBoxEnemy.Items.Clear();
            for (i = 0; i < Scene.ENEMY_COUNT; ++i)
            {
                var enemy = scene.Enemies[i];
                if (enemy == null)
                {
                    comboBoxEnemy.Items.Add("(none)");
                }
                else
                {
                    var name = enemy.Name.ToString();
                    if (name == null) { comboBoxEnemy.Items.Add("(no name)"); }
                    else { comboBoxEnemy.Items.Add(name); }
                }
            }
            comboBoxEnemy.SelectedIndex = 0;
            LoadEnemyData(scene.Enemies[0], false);

            //get formations
            comboBoxFormation.Items.Clear();
            for (i = 0; i < Scene.FORMATION_COUNT; ++i)
            {
                comboBoxFormation.Items.Add($"Battle ID {(Scene.FORMATION_COUNT * SelectedSceneIndex) + i}");
            }
            comboBoxFormation.SelectedIndex = 0;
            LoadFormationData(scene.Formations[0], false);

            if (clearLoadingWhenDone) { loading = false; }
        }

        private void LoadEnemyData(Enemy? enemy, bool clearLoadingWhenDone)
        {
            loading = true;
            if (enemy == null) //no enemy data to load
            {
                var result = MessageBox.Show("There is no enemy data in the selected slot. Would you like to create a new enemy?",
                    "No Enemy Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (SelectedScene != null && SelectedEnemyIndex != -1)
                    {
                        int id = (SelectedSceneIndex * Scene.ENEMY_COUNT) + SelectedEnemyIndex;
                        SelectedScene.Enemies[SelectedEnemyIndex] = new Enemy(SelectedScene, id,
                            new FFText("New Enemy"), null);
                        UpdateSelectedEnemyName(SelectedSceneIndex, SelectedEnemyIndex);
                        SetUnsaved(true);
                        LoadEnemyData(SelectedEnemy, false);
                    }
                }
                else { tabControlEnemyData.Enabled = false; }
            }
            else //load data
            {
                tabControlEnemyData.Enabled = true;

                //page 1
                textBoxEnemyName.Text = enemy.Name.ToString();
                numericEnemyLevel.Value = enemy.Level;
                numericEnemyHP.Value = enemy.HP;
                numericEnemyMP.Value = enemy.MP;
                numericEnemyStrength.Value = enemy.Strength;
                numericEnemyDefense.Value = enemy.Defense;
                numericEnemyMagic.Value = enemy.Magic;
                numericEnemyMDef.Value = enemy.MDef;
                numericEnemySpeed.Value = enemy.Speed;
                numericEnemyEvade.Value = enemy.Evade;
                numericEnemyLuck.Value = enemy.Luck;
                numericEnemyEXP.Value = enemy.EXP;
                numericEnemyAP.Value = enemy.AP;
                numericEnemyGil.Value = enemy.Gil;
                listBoxElementResistances.Items.Clear();
                foreach (var e in enemy.ResistanceRates)
                {
                    if (e == null)
                    {
                        listBoxElementResistances.Items.Add("(blank)");
                    }
                    else
                    {
                        listBoxElementResistances.Items.Add(e.GetText());
                    }
                }
                EnableOrDisableGroupBox(groupBoxEnemyElementResistances, false, false);
                statusesControlEnemyImmunities.SetStatuses(enemy.StatusImmunities);

                //page 2
                listBoxEnemyAttacks.Items.Clear();
                for (int i = 0; i < 16; ++i)
                {
                    if (enemy.AttackIDs[i] == 0xFFFF)
                    {
                        listBoxEnemyAttacks.Items.Add("(none)");
                    }
                    else if (SelectedScene != null)
                    {
                        listBoxEnemyAttacks.Items.Add(SelectedScene.GetAttackName(enemy.AttackIDs[i]));
                    }
                }
                EnableOrDisableGroupBox(groupBoxEnemyAttacks, false, false);
                numericEnemyBackDamageMultiplier.Value = enemy.BackAttackMultiplier;

                //kernel data
                if (DataManager.KernelFileIsLoaded && DataManager.Kernel != null)
                {
                    listBoxEnemyItemDropRates.Items.Clear();
                    foreach (var item in enemy.ItemDropRates)
                    {
                        if (item == null)
                        {
                            listBoxEnemyItemDropRates.Items.Add("(none)");
                        }
                        else
                        {
                            //get drop rate
                            float percentage = (item.DropRate / 63F) * 100;
                            string text = $"{percentage:N1}% ";

                            //get item name
                            var invItem = new InventoryItem(item.ItemID, 1);
                            bool gotName = false;
                            switch (invItem.Type)
                            {
                                case ItemType.Item:
                                    var itemData = DataManager.Kernel.GetItemByID(invItem.Index);
                                    if (itemData != null)
                                    {
                                        text += itemData.Name;
                                        gotName = true;
                                    }
                                    break;
                                case ItemType.Weapon:
                                    var wpnData = DataManager.Kernel.GetWeaponByID(invItem.Index);
                                    if (wpnData != null)
                                    {
                                        text += wpnData.Name;
                                        gotName = true;
                                    }
                                    break;
                                case ItemType.Armor:
                                    var armorData = DataManager.Kernel.GetArmorByID(invItem.Index);
                                    if (armorData != null)
                                    {
                                        text += armorData.Name;
                                        gotName = true;
                                    }
                                    break;
                                case ItemType.Accessory:
                                    var accData = DataManager.Kernel.GetAccessoryByID(invItem.Index);
                                    if (accData != null)
                                    {
                                        text += accData.Name;
                                        gotName = true;
                                    }
                                    break;
                            }
                            if (!gotName)
                            {
                                text += $"Unknown item (ID {item.ItemID:X4})";
                            }

                            //get steal status
                            if (item.IsSteal) { text += " steal"; }
                            else { text += " drop"; }
                            listBoxEnemyItemDropRates.Items.Add(text);
                        }
                    }
                    EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, false, false);
                    if (enemy.MorphItemIndex == 0xFFFF)
                    {
                        comboBoxEnemyMorphItem.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxEnemyMorphItem.SelectedIndex = enemy.MorphItemIndex + 1;
                    }
                }

                //A.I. scripts
                scriptControlEnemyAI.AIContainer = SelectedEnemy;
                UpdateScripts(SelectedEnemy, listBoxEnemyScripts);
            }
            if (clearLoadingWhenDone) { loading = false; }
        }

        private void LoadAttackData(Attack? attack, bool clearLoadingWhenDone)
        {
            loading = true;

            if (attack == null)
            {
                tabControlAttackData.Enabled = false;
            }
            else
            {
                tabControlAttackData.Enabled = true;

                //page 1
                textBoxAttackID.Text = attack.ID.ToString("X4");
                textBoxAttackName.Text = attack.Name.ToString();
                numericAttackAttackPercent.Value = attack.AccuracyRate;
                numericAttackMPCost.Value = attack.MPCost;
                comboBoxAttackAttackEffectID.Text = attack.AttackEffectID.ToString("X2");
                comboBoxAttackImpactEffectID.Text = attack.ImpactEffectID.ToString("X2");
                elementsControlAttack.SetElements(attack.Elements);
                comboBoxAttackCamMovementIDSingle.Text = attack.CameraMovementIDSingle.ToString("X4");
                comboBoxAttackCamMovementIDMulti.Text = attack.CameraMovementIDMulti.ToString("X4");
                comboBoxAttackHurtActionIndex.Text = attack.TargetHurtActionIndex.ToString("X2");
                damageCalculationControlAttack.AttackPower = attack.AttackStrength;
                damageCalculationControlAttack.ActualValue = attack.DamageCalculationID;

                //page 2
                specialAttackFlagsControlAttack.SetFlags(attack.SpecialAttackFlags);
                statusesControlAttack.SetStatuses(attack.StatusEffects);
                if (attack.AttackConditions == AttackConditions.None)
                {
                    comboBoxAttackConditionSubMenu.SelectedIndex = 0;
                }
                else
                {
                    comboBoxAttackConditionSubMenu.SelectedIndex = (int)attack.AttackConditions + 1;
                }
                numericAttackStatusChangeChance.Value = attack.StatusChangeChance;
                if (attack.StatusChange == StatusChange.None)
                {
                    comboBoxAttackStatusChange.SelectedIndex = 0;
                }
                else
                {
                    var s = Enum.GetValues<StatusChange>().ToList();
                    comboBoxAttackStatusChange.SelectedIndex = s.IndexOf(attack.StatusChange) + 1;
                }
            }

            if (clearLoadingWhenDone) { loading = false; }
        }

        private void LoadFormationData(Formation formation, bool clearLoadingWhenDone)
        {
            loading = true;

            //A.I. scripts
            scriptControlFormations.AIContainer = SelectedFormation;
            UpdateScripts(SelectedFormation, listBoxFormationScripts);

            if (clearLoadingWhenDone) { loading = false; }
        }

        private void UpdateSelectedEnemyName(int scene, int enemy)
        {
            if (scene >= 0 && scene < DataManager.SCENE_COUNT)
            {
                comboBoxSceneList.SelectedIndex = scene;
                if (enemy >= 0 && enemy < Scene.ENEMY_COUNT)
                {
                    comboBoxEnemy.SelectedIndex = enemy;
                    comboBoxSceneList.Items[scene] = $"{scene}: {sceneList[scene].GetEnemyNames()}";
                    comboBoxEnemy.Items[enemy] = sceneList[scene].Enemies[enemy]?.Name.ToString();
                }
            }
        }

        private void UpdateScripts(AIContainer? container, ListBox list)
        {
            for (int i = 0; i < Script.SCRIPT_COUNT; ++i)
            {
                list.Items[i] = SCRIPT_LIST[i];
                if (container != null)
                {
                    var script = container.GetScriptAtPosition(i);
                    if (script != null && !script.IsEmpty)
                    {
                        list.Items[i] += "*";
                    }
                }
            }
        }

        private void EnableOrDisableGroupBox(GroupBox group, bool enable, bool forceLabelsOn,
            Control? ignore = null)
        {
            foreach (Control c in group.Controls)
            {
                if (c != null && !(c is ListBox) && c != ignore)
                {
                    if (forceLabelsOn && c is Label) { c.Enabled = true; }
                    else { c.Enabled = enable; }
                }
            }
        }

        private void EnableOrDisableForm(bool enable)
        {
            processing = !enable;
            comboBoxSceneList.Enabled = enable;
            comboBoxEnemy.Enabled = enable;
            comboBoxFormation.Enabled = enable;
            tabControlMain.Enabled = enable;
            buttonSave.Enabled = enable;
            buttonImport.Enabled = enable;
            buttonExport.Enabled = enable;
        }

        private async void SaveSceneBin()
        {
            EnableOrDisableForm(false);
            int i = 0;
            try
            {
                for (i = 0; i < DataManager.SCENE_COUNT; ++i)
                {
                    await UpdateDataAsync(i);
                    progressBarSaving.Value = ((i + 1) / DataManager.SCENE_COUNT) * 100;
                }
                await Task.Delay(500);

                if (!DataManager.KernelFileIsLoaded)
                {
                    MessageBox.Show("No kernel file is selected, so the lookup table cannot be updated. This scene.bin file may not work correctly in FF7.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DataManager.UpdateAllScenes(this, sceneList);
                DataManager.CreateSceneBin();
                SetUnsaved(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            progressBarSaving.Value = 0;
            EnableOrDisableForm(true);
            buttonSave.Select();
        }

        private Task UpdateDataAsync(int pos)
        {
            return Task.Run(() =>
            {
                try
                {
                    sceneList[pos].UpdateRawData();
                }
                catch (Exception ex)
                {
                    throw new Exception($"An exception was thrown in scene {pos}:\n\n{ex.Message}", ex);
                }
            });
        }

        #endregion

        #region Event Methods

        private void comboBoxSceneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedScene != null)
            {
                LoadSceneData(SelectedScene, true);
            }
        }

        private void comboBoxEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                LoadEnemyData(SelectedEnemy, true);
            }
        }

        private void comboBoxFormation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //stuff
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DialogResult result;
            SceneSearchResult? search;
            using (var form = new SceneSearchForm(sceneList))
            {
                result = form.ShowDialog();
                search = form.SearchResult;
            }
            if (result == DialogResult.OK && search != null)
            {
                comboBoxSceneList.SelectedIndex = search.SceneIndex;
                comboBoxEnemy.SelectedIndex = search.EnemyPosition;
                comboBoxFormation.SelectedIndex = search.FormationPosition;
                if (search.SearchType == SearchType.Enemy)
                {
                    tabControlMain.SelectedTab = tabPageEnemyData;
                }
                else
                {
                    tabControlMain.SelectedTab = tabPageFormationData;
                }
            }
        }

        private void listBoxElementResistances_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxElementResistances.SelectedIndex;
            if (!loading && SelectedEnemy != null && i != -1)
            {
                EnableOrDisableGroupBox(groupBoxEnemyElementResistances, true, false, comboBoxEnemyResistRate);
                var resist = SelectedEnemy.ResistanceRates[i];
                if (resist == null)
                {
                    comboBoxEnemyResistElement.SelectedIndex = 0;
                    comboBoxEnemyResistRate.Enabled = false;
                }
                else
                {
                    comboBoxEnemyResistRate.Enabled = true;
                    if (resist is ElementResistanceRate)
                    {
                        var eresist = resist as ElementResistanceRate;
                        if (eresist != null)
                        {
                            comboBoxEnemyResistElement.SelectedIndex = (int)eresist.Element + 1;
                        }
                    }
                    else
                    {
                        var sresist = resist as StatusResistanceRate;
                        if (sresist != null)
                        {
                            comboBoxEnemyResistElement.SelectedIndex = (int)sresist.Status + 0x11;
                        }
                    }
                    comboBoxEnemyResistRate.SelectedIndex = resistList.IndexOf(resist.Rate);
                }
            }
        }

        private void listBoxEnemyAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyAttacks.SelectedIndex;
            if (!loading && i >= 0 && i < 16 && SelectedScene != null && SelectedEnemy != null)
            {
                comboBoxEnemyAttackID.Enabled = true;
                var atk = SelectedScene.GetAttackByID(SelectedEnemy.AttackIDs[i]);
                if (atk == null)
                {
                    comboBoxEnemyAttackID.SelectedIndex = 0;
                    comboBoxEnemyAttackCamID.Text = "FFFF";
                    EnableOrDisableGroupBox(groupBoxEnemyAttacks, false, true, comboBoxEnemyAttackID);
                }
                else
                {
                    EnableOrDisableGroupBox(groupBoxEnemyAttacks, true, false);
                    comboBoxEnemyAttackID.SelectedIndex = validAttacks.IndexOf(atk) + 1;
                    numericAttackAnimationIndex.Value = SelectedEnemy.ActionAnimationIndexes[i];
                    comboBoxEnemyAttackCamID.Text = SelectedEnemy.CameraMovementIDs[i].ToString("X4");
                    checkBoxEnemyAttackIsManipable.Checked = SelectedEnemy.AttackIsManipable(atk.ID);
                }
            }
        }

        private void listBoxEnemyItemDropRates_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyItemDropRates.SelectedIndex;
            if (!loading && i >= 0 && i < 4 && SelectedEnemy != null && DataManager.KernelFileIsLoaded &
                DataManager.Kernel != null)
            {
                comboBoxEnemyDropItemID.Enabled = true;
                var item = SelectedEnemy.ItemDropRates[i];
                if (item == null)
                {
                    comboBoxEnemyDropItemID.SelectedIndex = 0;
                    EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, false, true, comboBoxEnemyDropItemID);
                }
                else
                {
                    EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, true, false);
                    comboBoxEnemyDropItemID.SelectedIndex = item.ItemID + 1;
                    checkBoxEnemyItemIsSteal.Checked = item.IsSteal;
                    numericEnemyDropRate.Value = item.DropRate;
                }
            }
        }

        private void listBoxEnemyScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            scriptControlEnemyAI.SelectedScriptIndex = listBoxEnemyScripts.SelectedIndex;
        }

        private void scriptControl_DataChanged(object sender, EventArgs e)
        {
            SetUnsaved(true);
        }

        private void scriptControlEnemyAI_ScriptAddedOrRemoved(object sender, EventArgs e)
        {
            UpdateScripts(SelectedEnemy, listBoxEnemyScripts);
        }

        private void scriptControlFormations_ScriptAddedOrRemoved(object sender, EventArgs e)
        {
            UpdateScripts(SelectedFormation, listBoxFormationScripts);
        }

        private void listBoxAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                LoadAttackData(SelectedAttack, true);
            }
        }

        private void comboBoxAttackStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBoxAttackStatusChange.SelectedIndex;
            numericAttackStatusChangeChance.Enabled = (i > 0);
            statusesControlAttack.Enabled = (i > 0);
            if (!loading) { SetUnsaved(true); }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSceneBin();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            //stuff
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            using (var export = new SceneExportForm(sceneList, SelectedSceneIndex))
            {
                export.ShowDialog();
            }
        }

        private void SceneEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processing)
            {
                e.Cancel = true;
            }
            else if (unsavedChanges)
            {
                var result = MessageBox.Show("Unsaved changes will be lost. Are you sure?", "Unsaved changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                e.Cancel = result == DialogResult.No;
            }
        }

        #endregion
    }
}
