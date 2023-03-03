using FF7Scarlet.AIEditor;
using FF7Scarlet.KernelEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Battle;
using System.Globalization;
using System.Media;

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
        private ushort lastAttackID;
        private List<ResistanceRate> resistList;
        private List<ResistRates> resistRateList;
        private List<InventoryItem> itemList = new();
        private List<Enemy> validEnemies = new();
        private List<Attack> validAttacks = new();
        private int prevScene, prevEnemy, prevAttack, prevFormation;
        private bool
            loading = false,
            enemyNeedsSync = false,
            unsavedChanges = false,
            processing = false;

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

        #region Constructor

        public SceneEditorForm(Dictionary<ushort, Attack> syncedAttacks)
        {
            InitializeComponent();

            //set data for various controls
            textBoxEnemyName.MaxLength = Scene.NAME_LENGTH;
            textBoxAttackName.MaxLength = Scene.NAME_LENGTH;
            numericEnemyHP.Maximum = uint.MaxValue;
            numericEnemyEXP.Maximum = uint.MaxValue;
            numericEnemyGil.Maximum = uint.MaxValue;

            comboBoxEnemyResistElement.Items.Add("None");
            resistList = new List<ResistanceRate>();
            foreach (var e in Enum.GetValues<MateriaElements>())
            {
                comboBoxEnemyResistElement.Items.Add(e);
                resistList.Add(new ElementResistanceRate(e, 0));
            }
            foreach (var s in Enum.GetValues<EquipmentStatus>())
            {
                comboBoxEnemyResistElement.Items.Add($"{StringParser.AddSpace(s.ToString())} (status)");
                resistList.Add(new StatusResistanceRate(s, 0));
            }
            resistRateList = Enum.GetValues<ResistRates>().ToList();
            foreach (var r in resistRateList)
            {
                comboBoxEnemyResistRate.Items.Add(StringParser.AddSpace(r.ToString()));
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
            foreach (var l in Enum.GetNames<BattleLocations>())
            {
                comboBoxFormationLocation.Items.Add(l);
            }
            comboBoxFormationNext.Items.Add("None");
            comboBoxFormationBattleArena.Items.Add("None");
            for (int i = 0; i < Scene.ALL_FORMATIONS_COUNT; ++i)
            {
                comboBoxFormationNext.Items.Add($"Battle ID {i}");
                comboBoxFormationBattleArena.Items.Add($"Battle ID {i}");
            }
            foreach (var t in Enum.GetNames<BattleType>())
            {
                comboBoxFormationBattleType.Items.Add(t);
            }

            //synced data
            LoadKernelData();
            LoadModelData();

            //create private version of scene data that can be edited freely
            sceneList = DataManager.CopySceneList();
            this.syncedAttacks = syncedAttacks;
            lastAttackID = 0;
            for (int i = 0; i < DataManager.SCENE_COUNT; ++i)
            {
                comboBoxSceneList.Items.Add($"{i}: {sceneList[i].GetEnemyNames()}");
                foreach (var atk in sceneList[i].AttackList)
                {
                    if (atk != null && atk.ID > lastAttackID && atk.ID != HexParser.NULL_OFFSET_16_BIT)
                    {
                        lastAttackID = atk.ID;
                    }
                }
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
                foreach (var item in DataManager.Kernel.ItemData.Items)
                {
                    comboBoxEnemyDropItemID.Items.Add(item.Name);
                    comboBoxEnemyMorphItem.Items.Add(item.Name);
                    itemList.Add(new InventoryItem((byte)item.Index, 1, ItemType.Item));
                }
                foreach (var wpn in DataManager.Kernel.WeaponData.Weapons)
                {
                    comboBoxEnemyDropItemID.Items.Add(wpn.Name);
                    comboBoxEnemyMorphItem.Items.Add(wpn.Name);
                    itemList.Add(new InventoryItem((byte)wpn.Index, 1, ItemType.Weapon));
                }
                foreach (var armor in DataManager.Kernel.ArmorData.Armors)
                {
                    comboBoxEnemyDropItemID.Items.Add(armor.Name);
                    comboBoxEnemyMorphItem.Items.Add(armor.Name);
                    itemList.Add(new InventoryItem((byte)armor.Index, 1, ItemType.Armor));
                }
                foreach (var acc in DataManager.Kernel.AccessoryData.Accessories)
                {
                    comboBoxEnemyDropItemID.Items.Add(acc.Name);
                    comboBoxEnemyMorphItem.Items.Add(acc.Name);
                    itemList.Add(new InventoryItem((byte)acc.Index, 1, ItemType.Accessory));
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

        private void LoadModelData()
        {
            if (DataManager.BattleLgpIsLoaded && DataManager.BattleLgp != null)
            {
                comboBoxEnemyModelID.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (var m in DataManager.BattleLgp.Models)
                {
                    comboBoxEnemyModelID.Items.Add(m);
                }
            }
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
            comboBoxEnemyAttackCamID.Text = HexParser.NULL_OFFSET_16_BIT.ToString("X4");
            EnableOrDisableGroupBox(groupBoxEnemyAttacks, false, false);

            //get enemies
            validEnemies =
                (from e in scene.Enemies
                 where e != null
                 select e).ToList();

            comboBoxEnemy.Items.Clear();
            comboBoxFormationSelectedEnemy.Items.Clear();
            comboBoxFormationSelectedEnemy.Items.Add("None");
            for (i = 0; i < Scene.ENEMY_COUNT; ++i)
            {
                var enemy = scene.Enemies[i];
                if (enemy == null)
                {
                    comboBoxEnemy.Items.Add("(none)");
                }
                else
                {
                    var name = scene.GetEnemyName(enemy.ModelID);
                    comboBoxEnemy.Items.Add(name);
                    comboBoxFormationSelectedEnemy.Items.Add(name);
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
                        ushort id = 0;
                        while (SelectedScene.GetEnemyByID(id) != null)
                        {
                            id++;
                        }
                        SelectedScene.Enemies[SelectedEnemyIndex] = new Enemy(SelectedScene, id,
                            new FFText(), null);
                        UpdateSelectedEnemyName(SelectedSceneIndex, SelectedEnemyIndex, SelectedFormationIndex);
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
                listBoxEnemyElementResistances.Items.Clear();
                foreach (var e in enemy.ResistanceRates)
                {
                    if (e == null)
                    {
                        listBoxEnemyElementResistances.Items.Add("(blank)");
                    }
                    else
                    {
                        listBoxEnemyElementResistances.Items.Add(e.GetText());
                    }
                }
                EnableOrDisableGroupBox(groupBoxEnemyElementResistances, false, false);
                statusesControlEnemyImmunities.SetStatuses(enemy.StatusImmunities);

                //page 2
                listBoxEnemyAttacks.Items.Clear();
                for (int i = 0; i < 16; ++i)
                {
                    if (enemy.AttackIDs[i] == HexParser.NULL_OFFSET_16_BIT)
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
                            listBoxEnemyItemDropRates.Items.Add(GetItemDropText(item));
                        }
                    }
                    EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, false, false);
                    if (enemy.MorphItemIndex == HexParser.NULL_OFFSET_16_BIT)
                    {
                        comboBoxEnemyMorphItem.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxEnemyMorphItem.SelectedIndex = enemy.MorphItemIndex + 1;
                    }
                }

                //model ID
                if (DataManager.BattleLgpIsLoaded)
                {
                    comboBoxEnemyModelID.SelectedIndex = enemy.ModelID;
                }
                else
                {
                    comboBoxEnemyModelID.Text = enemy.ModelID.ToString("X4");
                }

                //A.I. scripts
                scriptControlEnemyAI.AIContainer = SelectedEnemy;
                UpdateScripts(SelectedEnemy, listBoxEnemyScripts);
            }
            if (clearLoadingWhenDone) { loading = false; }
        }

        private void UpdateSelectedEnemyName(int scene, int enemy, int formation)
        {
            if (scene >= 0 && scene < DataManager.SCENE_COUNT)
            {
                comboBoxSceneList.SelectedIndex = scene;
                if (enemy >= 0 && enemy < Scene.ENEMY_COUNT)
                {
                    var e = sceneList[scene].Enemies[enemy];
                    if (e != null)
                    {
                        comboBoxEnemy.SelectedIndex = enemy;
                        loading = true;
                        comboBoxSceneList.Items[scene] = $"{scene}: {sceneList[scene].GetEnemyNames()}";
                        string name = sceneList[scene].GetEnemyName(e.ModelID);
                        comboBoxEnemy.Items[enemy] = name;

                        //update name in formation data
                        var f = sceneList[scene].Formations[formation];
                        for (int i = 0; i < Formation.ENEMY_COUNT; ++i)
                        {
                            if (f.EnemyLocations[i].EnemyID == e.ModelID)
                            {
                                listBoxFormationEnemies.Items[i] = name;
                            }
                        }
                        int j = validEnemies.IndexOf(e);
                        comboBoxFormationSelectedEnemy.Items[j] = name;
                        loading = false;
                    }
                }
            }
        }

        private string GetItemDropText(ItemDropRate rate)
        {
            //get drop rate
            float percentage = (rate.DropRate / 63F) * 100;
            string text = $"{percentage:N1}% ";

            //get name
            string name = $"Unknown item (ID {rate.ItemID:X4})";
            if (DataManager.KernelFileIsLoaded && DataManager.Kernel != null)
            {
                //get item name
                var item = new InventoryItem(rate.ItemID, 1);
                name = DataManager.Kernel.GetInventoryItemName(item);
            }
            text += name;

            //get steal status
            if (rate.IsSteal) { text += " steal"; }
            else { text += " drop"; }

            return text;
        }

        private void SyncEnemyData(Enemy enemy)
        {
            enemy.Level = (byte)numericEnemyLevel.Value;
            enemy.Speed = (byte)numericEnemySpeed.Value;
            enemy.Luck = (byte)numericEnemyLuck.Value;
            enemy.Evade = (byte)numericEnemyEvade.Value;
            enemy.Strength = (byte)numericEnemyStrength.Value;
            enemy.Defense = (byte)numericEnemyDefense.Value;
            enemy.Magic = (byte)numericEnemyMagic.Value;
            enemy.MDef = (byte)numericEnemyMDef.Value;
            enemy.MP = (ushort)numericEnemyMP.Value;
            enemy.AP = (ushort)numericEnemyAP.Value;
            enemy.BackAttackMultiplier = (byte)numericEnemyBackDamageMultiplier.Value;
            enemy.HP = (uint)numericEnemyHP.Value;
            enemy.EXP = (uint)numericEnemyEXP.Value;
            enemy.Gil = (uint)numericEnemyGil.Value;
            enemy.StatusImmunities = statusesControlEnemyImmunities.GetStatuses();

            if (DataManager.KernelFileIsLoaded && DataManager.Kernel != null)
            {
                if (comboBoxEnemyMorphItem.SelectedIndex == 0)
                {
                    enemy.MorphItemIndex = HexParser.NULL_OFFSET_16_BIT;
                }
                else
                {
                    var item = DataManager.Kernel.GetItemByID(comboBoxEnemyMorphItem.SelectedIndex - 1);
                    if (item != null)
                    {
                        enemy.MorphItemIndex = (ushort)item.Index;
                    }
                }
            }
            enemyNeedsSync = false;
        }

        private void LoadAttackData(Attack? attack, bool clearLoadingWhenDone)
        {
            loading = true;

            if (attack == null)
            {
                var result = MessageBox.Show("There is no attack data in the selected slot. Would you like to create a new attack?",
                    "No Attack Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (SelectedScene != null && SelectedEnemy != null && SelectedAttackIndex != -1)
                    {
                        lastAttackID++;
                        attack = new Attack(lastAttackID);
                        SelectedScene.AttackList[SelectedAttackIndex] = attack;
                        var name = SelectedScene.GetAttackName(lastAttackID);
                        UpdateSelectedAttackName(SelectedScene, SelectedEnemy, SelectedAttackIndex);
                        validAttacks.Add(attack);
                        comboBoxEnemyAttackID.Items.Add(name);
                        SetUnsaved(true);
                        LoadAttackData(SelectedAttack, false);
                    }
                }
                else { tabControlAttackData.Enabled = false; }
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

        private void UpdateSelectedAttackName(Scene scene, Enemy enemy, int attack)
        {
            if (attack >= 0 && attack < Scene.ATTACK_COUNT)
            {
                var atk = scene.AttackList[attack];
                if (atk != null)
                {
                    loading = true;
                    string name = scene.GetAttackName(atk.ID);
                    int i, j;
                    listBoxAttacks.SelectedIndex = attack;
                    listBoxAttacks.Items[attack] = name;

                    //update name in enemy data
                    for (i = 0; i < Enemy.ATTACK_COUNT; ++i)
                    {
                        if (enemy.AttackIDs[i] == atk.ID)
                        {
                            listBoxEnemyAttacks.Items[i] = name;
                            break;
                        }
                    }
                    j = validAttacks.IndexOf(atk);
                    if (j != -1)
                    {
                        comboBoxEnemyAttackID.Items[j] = name;
                    }
                    loading = false;
                }
            }
        }

        private void LoadFormationData(Formation formation, bool clearLoadingWhenDone)
        {
            loading = true;
            var scene = formation.Parent as Scene;
            if (scene == null) { throw new ArgumentNullException(); }
            int i;

            //enemies
            listBoxFormationEnemies.Items.Clear();
            foreach (var e in formation.EnemyLocations)
            {
                listBoxFormationEnemies.Items.Add(scene.GetEnemyName(e.EnemyID));
            }
            EnableOrDisableGroupBox(groupBoxFormationEnemies, false, false);

            //battle setup data
            if ((ushort)formation.BattleSetupData.Location == HexParser.NULL_OFFSET_16_BIT)
            {
                comboBoxFormationLocation.SelectedIndex = -1;
            }
            else
            {
                comboBoxFormationLocation.SelectedIndex = (int)formation.BattleSetupData.Location;
            }
            if (formation.BattleSetupData.NextSceneID == HexParser.NULL_OFFSET_16_BIT)
            {
                comboBoxFormationNext.SelectedIndex = 0;
            }
            else
            {
                comboBoxFormationNext.SelectedIndex = formation.BattleSetupData.NextSceneID + 1;
            }
            numericFormationEscapeCounter.Value = formation.BattleSetupData.EscapeCounter;
            listBoxFormationBattleArena.Items.Clear();
            for (i = 0; i < BattleSetupData.BATTLE_ARENA_ID_COUNT; ++i)
            {
                if (formation.BattleSetupData.BattleArenaIDs[i] == HexParser.NULL_OFFSET_16_BIT)
                {
                    listBoxFormationBattleArena.Items.Add("(none)");
                }
                else
                {
                    listBoxFormationBattleArena.Items.Add($"Battle ID {formation.BattleSetupData.BattleArenaIDs[i]}");
                }
            }
            comboBoxFormationBattleArena.Enabled = false;
            battleFlagsControlFormation.SetFlags(formation.BattleSetupData.BattleFlags);
            if ((byte)formation.BattleSetupData.BattleType == 0xFF)
            {
                comboBoxFormationBattleType.SelectedIndex = -1;
            }
            else
            {
                comboBoxFormationBattleType.SelectedIndex = (int)formation.BattleSetupData.BattleType;
            }
            numericFormationPreBattleCamPosition.Value = formation.BattleSetupData.PreBattleCameraPosition;

            //camera data
            cameraPositionControlMain.SetPosition(formation.CameraPlacementData.CameraPositions[0],
                formation.CameraPlacementData.CameraDirections[0]);
            cameraPositionControlExtra1.SetPosition(formation.CameraPlacementData.CameraPositions[1],
                formation.CameraPlacementData.CameraDirections[1]);
            cameraPositionControlExtra2.SetPosition(formation.CameraPlacementData.CameraPositions[2],
                formation.CameraPlacementData.CameraDirections[2]);

            //A.I. scripts
            scriptControlFormations.AIContainer = formation;
            UpdateScripts(formation, listBoxFormationScripts);

            if (clearLoadingWhenDone) { loading = false; }
        }

        private void UpdateScripts(AIContainer? container, ListBox list)
        {
            for (int i = 0; i < Script.SCRIPT_COUNT; ++i)
            {
                list.Items[i] = SCRIPT_LIST[i];
                if (container != null)
                {
                    var script = container.Scripts[i];
                    if (!script.IsEmpty)
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
            //sync unsaved enemy data
            if (SelectedEnemy != null && enemyNeedsSync)
            {
                SyncEnemyData(SelectedEnemy);
            }
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
                if (enemyNeedsSync) //sync the unsaved enemy data
                {
                    var scene = sceneList[prevScene];
                    var enemy = scene.Enemies[prevEnemy];
                    if (enemy != null)
                    {
                        SyncEnemyData(enemy);
                    }
                }
                prevScene = SelectedSceneIndex;
                LoadSceneData(SelectedScene, true);
            }
        }

        private void comboBoxEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedScene != null)
            {
                if (enemyNeedsSync) //sync the unsaved enemy data
                {
                    var enemy = SelectedScene.Enemies[prevEnemy];
                    if (enemy != null)
                    {
                        SyncEnemyData(enemy);
                    }
                }
                prevEnemy = SelectedEnemyIndex;
                LoadEnemyData(SelectedEnemy, true);
            }
        }

        private void comboBoxFormation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedFormation != null)
            {
                prevFormation = SelectedFormationIndex;
                LoadFormationData(SelectedFormation, true);
            }
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

        private void textBoxEnemyName_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedEnemy != null)
            {
                SelectedEnemy.Name = new FFText(textBoxEnemyName.Text);
                UpdateSelectedEnemyName(SelectedSceneIndex, SelectedEnemyIndex, SelectedFormationIndex);
                SetUnsaved(true);
            }
        }

        private void listBoxEnemyElementResistances_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyElementResistances.SelectedIndex;
            if (!loading && SelectedEnemy != null && i != -1)
            {
                loading = true;
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
                    comboBoxEnemyResistRate.SelectedIndex = resistRateList.IndexOf(resist.Rate);
                }
                loading = false;
            }
        }

        private void comboBoxEnemyResistElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newElement = comboBoxEnemyResistElement.SelectedIndex,
                selectedElement = listBoxEnemyElementResistances.SelectedIndex;

            if (!loading && selectedElement >= 0 && selectedElement < Enemy.ELEMENT_RESISTANCE_COUNT
                && newElement >= 0 && newElement < resistList.Count && SelectedEnemy != null)
            {
                loading = true;
                if (newElement == 0)
                {
                    SelectedEnemy.ResistanceRates[selectedElement] = null;
                    listBoxEnemyElementResistances.Items[selectedElement] = "(blank)";
                    comboBoxEnemyResistRate.Enabled = false;
                }
                else
                {
                    //get rate (if it exists)
                    int rateIndex = comboBoxEnemyResistRate.SelectedIndex;
                    if (rateIndex < 0) { rateIndex = 0; }
                    var rate = resistRateList[rateIndex];
                    comboBoxEnemyResistRate.Enabled = true;
                    comboBoxEnemyResistRate.SelectedIndex = rateIndex;

                    //set element/status
                    if (resistList[newElement] is ElementResistanceRate)
                    {
                        var eresist = resistList[newElement] as ElementResistanceRate;
                        if (eresist != null)
                        {
                            SelectedEnemy.ResistanceRates[selectedElement] = new ElementResistanceRate(eresist.Element, rate);
                        }
                    }
                    else
                    {
                        var sresist = resistList[newElement] as StatusResistanceRate;
                        if (sresist != null)
                        {
                            SelectedEnemy.ResistanceRates[selectedElement] = new StatusResistanceRate(sresist.Status, rate);
                        }
                    }

                    var temp = SelectedEnemy.ResistanceRates[selectedElement];
                    if (temp != null)
                    {
                        listBoxEnemyElementResistances.Items[selectedElement] = temp.GetText();
                    }
                }
                SetUnsaved(true);
                loading = false;
            }
        }

        private void comboBoxEnemyResistRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newRate = comboBoxEnemyResistRate.SelectedIndex,
                selectedRate = listBoxEnemyElementResistances.SelectedIndex;

            if (!loading && selectedRate >= 0 && selectedRate < Enemy.ELEMENT_RESISTANCE_COUNT
                && newRate >= 0 && newRate < resistRateList.Count && SelectedEnemy != null)
            {
                loading = true;
                var resist = SelectedEnemy.ResistanceRates[selectedRate];
                if (resist != null)
                {
                    resist.Rate = resistRateList[newRate];
                    listBoxEnemyElementResistances.Items[selectedRate] = resist.GetText();
                    SetUnsaved(true);
                }
                loading = false;
            }
        }

        private void listBoxEnemyAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyAttacks.SelectedIndex;
            if (!loading && i >= 0 && i < 16 && SelectedScene != null && SelectedEnemy != null)
            {
                loading = true;
                comboBoxEnemyAttackID.Enabled = true;
                var atk = SelectedScene.GetAttackByID(SelectedEnemy.AttackIDs[i]);
                if (atk == null)
                {
                    comboBoxEnemyAttackID.SelectedIndex = 0;
                    comboBoxEnemyAttackCamID.Text = HexParser.NULL_OFFSET_16_BIT.ToString("X4");
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
                loading = false;
            }
        }

        private void comboBoxEnemyAttackID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedAttack = listBoxEnemyAttacks.SelectedIndex,
                newAttack = comboBoxEnemyAttackID.SelectedIndex;
            if (!loading && selectedAttack >= 0 && selectedAttack < Enemy.ATTACK_COUNT && newAttack >= 0
                && newAttack <= validAttacks.Count && SelectedEnemy != null)
            {
                loading = true;
                if (newAttack == 0)
                {
                    SelectedEnemy.AttackIDs[selectedAttack] = HexParser.NULL_OFFSET_16_BIT;
                    listBoxEnemyAttacks.Items[selectedAttack] = "(none)";
                    EnableOrDisableGroupBox(groupBoxEnemyAttacks, false, true, comboBoxEnemyAttackID);
                }
                else
                {
                    var atk = validAttacks[newAttack - 1];
                    SelectedEnemy.AttackIDs[selectedAttack] = atk.ID;
                    listBoxEnemyAttacks.Items[selectedAttack] = atk.GetNameString();
                    EnableOrDisableGroupBox(groupBoxEnemyAttacks, true, false);
                }
                SetUnsaved(true);
                loading = false;
            }
        }

        private void numericAttackAnimationIndex_ValueChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyAttacks.SelectedIndex;
            if (!loading && i >= 0 && i < Enemy.ATTACK_COUNT && SelectedEnemy != null)
            {
                SelectedEnemy.ActionAnimationIndexes[i] = (byte)numericAttackAnimationIndex.Value;
                SetUnsaved(true);
            }
        }

        private void comboBoxEnemyAttackCamID_TextChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyAttacks.SelectedIndex;
            if (!loading && i >= 0 && i < Enemy.ATTACK_COUNT && SelectedEnemy != null)
            {
                if (comboBoxEnemyAttackCamID.Text.Length == 4)
                {
                    ushort value;
                    if (ushort.TryParse(comboBoxEnemyAttackCamID.Text, NumberStyles.HexNumber,
                        HexParser.CultureInfo, out value))
                    {
                        SelectedEnemy.CameraMovementIDs[i] = value;
                        SetUnsaved(true);
                    }
                    else
                    {
                        SystemSounds.Exclamation.Play();
                    }
                }
            }
        }

        private void checkBoxEnemyAttackIsManipable_CheckedChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyAttacks.SelectedIndex, j, n;
            if (!loading && i >= 0 && i < Enemy.ATTACK_COUNT && SelectedEnemy != null && SelectedScene != null)
            {
                loading = true;
                if (checkBoxEnemyAttackIsManipable.Checked) //attempt to add the attack to the manip list
                {
                    for (j = 0; j < Enemy.MANIP_ATTACK_COUNT; ++j)
                    {
                        if (SelectedEnemy.ManipAttackIDs[j] == HexParser.NULL_OFFSET_16_BIT)
                        {
                            SelectedEnemy.ManipAttackIDs[j] = SelectedEnemy.AttackIDs[i];
                            SetUnsaved(true);
                            return;
                        }
                    }

                    //manip list is full, so an attack must be replaced
                    var names = new string[Enemy.MANIP_ATTACK_COUNT];
                    for (n = 0; n < Enemy.MANIP_ATTACK_COUNT; ++n)
                    {
                        names[n] = SelectedScene.GetAttackName(SelectedEnemy.ManipAttackIDs[n]);
                    }
                    DialogResult result;
                    int replace;
                    using (var replaceForm = new ReplaceManipAttackForm(names))
                    {
                        result = replaceForm.ShowDialog();
                        replace = replaceForm.SelectedIndex;
                    }
                    if (result == DialogResult.OK)
                    {
                        SelectedEnemy.ManipAttackIDs[replace] = SelectedEnemy.AttackIDs[i];
                        SetUnsaved(true);
                    }
                    else { checkBoxEnemyAttackIsManipable.Checked = false; }
                }
                else //remove attack from the list
                {
                    for (j = 0; i < Enemy.MANIP_ATTACK_COUNT; ++j)
                    {
                        if (SelectedEnemy.ManipAttackIDs[j] == SelectedEnemy.AttackIDs[i])
                        {
                            for (n = j + 1; n < Enemy.MANIP_ATTACK_COUNT; ++n) //shift attacks up
                            {
                                SelectedEnemy.ManipAttackIDs[n - 1] = SelectedEnemy.ManipAttackIDs[n];
                            }
                            SelectedEnemy.ManipAttackIDs[Enemy.MANIP_ATTACK_COUNT - 1] =
                                HexParser.NULL_OFFSET_16_BIT;
                            SetUnsaved(true);
                            return;
                        }
                    }
                }
                loading = false;
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

        private void comboBoxEnemyDropItemID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = listBoxEnemyItemDropRates.SelectedIndex,
                newItem = comboBoxEnemyDropItemID.SelectedIndex;
            if (!loading && selectedItem >= 0 && selectedItem < Enemy.DROP_ITEM_COUNT && SelectedEnemy != null
                && DataManager.KernelFileIsLoaded && DataManager.Kernel != null)
            {
                loading = true;
                if (newItem == 0)
                {
                    SelectedEnemy.ItemDropRates[selectedItem] = null;
                    EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, false, true, comboBoxEnemyDropItemID);
                }
                else
                {
                    EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, true, false);
                    var item = itemList[newItem - 1];
                    var drop = SelectedEnemy.ItemDropRates[selectedItem];
                    byte rate = (byte)numericEnemyDropRate.Value;

                    if (drop == null)
                    {
                        drop = new ItemDropRate(item.Index, item.Type, rate, false);
                        SelectedEnemy.ItemDropRates[selectedItem] = drop;
                        listBoxEnemyItemDropRates.Items[selectedItem] = GetItemDropText(drop);
                    }
                    else
                    {
                        drop.ItemID = InventoryItem.GetCombinedIndex(item.Type, item.Index);
                        listBoxEnemyItemDropRates.Items[selectedItem] = GetItemDropText(drop);
                    }
                }
                SetUnsaved(true);
                loading = false;
            }
        }

        private void numericEnemyDropRate_ValueChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyItemDropRates.SelectedIndex;
            if (!loading && i >= 0 && i < Enemy.DROP_ITEM_COUNT && SelectedEnemy != null)
            {
                loading = true;
                var drop = SelectedEnemy.ItemDropRates[i];
                byte rate = (byte)numericEnemyDropRate.Value;

                if (drop != null)
                {
                    drop.DropRate = rate;
                    listBoxEnemyItemDropRates.Items[i] = GetItemDropText(drop);
                }
                SetUnsaved(true);
                loading = false;
            }
        }

        private void checkBoxEnemyItemIsSteal_CheckedChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyItemDropRates.SelectedIndex;
            if (!loading && i >= 0 && i < Enemy.DROP_ITEM_COUNT && SelectedEnemy != null)
            {
                loading = true;
                var drop = SelectedEnemy.ItemDropRates[i];

                if (drop != null)
                {
                    drop.IsSteal = checkBoxEnemyItemIsSteal.Checked;
                    listBoxEnemyItemDropRates.Items[i] = GetItemDropText(drop);
                }
                SetUnsaved(true);
                loading = false;
            }
        }

        private void comboBoxEnemyModelID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedEnemy != null && DataManager.BattleLgpIsLoaded
                && DataManager.BattleLgp != null)
            {
                ushort newID = (ushort)comboBoxEnemyModelID.SelectedIndex, oldID = SelectedEnemy.ModelID;
                if (newID >= 0 && newID < DataManager.BattleLgp.Models.Length)
                {
                    loading = true;
                    try
                    {
                        SelectedEnemy.ModelID = newID;
                        SetUnsaved(true);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBoxEnemyModelID.SelectedIndex = oldID;
                    }
                    loading = false;
                }
            }
        }

        private void comboBoxEnemyModelID_TextChanged(object sender, EventArgs e)
        {
            if (!loading && !DataManager.BattleLgpIsLoaded && SelectedEnemy != null)
            {
                string text = comboBoxEnemyModelID.Text;
                if (text.Length == 4)
                {
                    ushort newID, oldID = SelectedEnemy.ModelID;
                    if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        try
                        {
                            SelectedEnemy.ModelID = newID;
                            SetUnsaved(true);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            comboBoxEnemyModelID.Text = oldID.ToString("X4");
                        }
                    }
                    else { SystemSounds.Exclamation.Play(); }
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

        private void EnemyDataChanged(object? sender, EventArgs e)
        {
            if (!loading)
            {
                enemyNeedsSync = true;
                SetUnsaved(true);
            }
        }

        private void listBoxAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                prevAttack = SelectedAttackIndex;
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

        private void listBoxFormationEnemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxFormationEnemies.SelectedIndex;
            if (!loading && i >= 0 && i < Formation.ENEMY_COUNT && SelectedFormation != null && SelectedScene != null)
            {
                loading = true;
                var enemy = SelectedScene.GetEnemyByID(SelectedFormation.EnemyLocations[i].EnemyID);
                if (enemy == null)
                {
                    comboBoxFormationSelectedEnemy.SelectedIndex = 0;
                    EnableOrDisableGroupBox(groupBoxFormationEnemies, false, true, comboBoxFormationSelectedEnemy);
                }
                else
                {
                    comboBoxFormationSelectedEnemy.SelectedIndex = validEnemies.IndexOf(enemy) + 1;
                    EnableOrDisableGroupBox(groupBoxFormationEnemies, true, false);

                    var enemyInfo = SelectedFormation.EnemyLocations[i];
                    numericFormationEnemyX.Value = enemyInfo.Location.X;
                    numericFormationEnemyY.Value = enemyInfo.Location.Y;
                    numericFormationEnemyZ.Value = enemyInfo.Location.Z;
                    numericFormationEnemyRow.Value = enemyInfo.Row;
                    coverFlagsControlFormationEnemy.SetFlags(enemyInfo.CoverFlags);
                    initialConditionControlEnemy.SetConditions(enemyInfo.InitialConditionFlags);
                }
                loading = false;
            }
        }

        private void comboBoxFormationSelectedEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newEnemy = comboBoxFormationSelectedEnemy.SelectedIndex,
                selectedEnemy = listBoxFormationEnemies.SelectedIndex;

            if (!loading && newEnemy >= 0 && newEnemy < Scene.ENEMY_COUNT && selectedEnemy >= 0
                && selectedEnemy < validEnemies.Count && SelectedFormation != null)
            {
                if (newEnemy == 0)
                {
                    SelectedFormation.EnemyLocations[selectedEnemy].EnemyID = HexParser.NULL_OFFSET_16_BIT;
                    listBoxFormationEnemies.Items[selectedEnemy] = "(none)";
                }
                else
                {
                    var enemy = validEnemies[newEnemy - 1];
                    SelectedFormation.EnemyLocations[selectedEnemy].EnemyID = enemy.ModelID;
                    listBoxFormationEnemies.Items[selectedEnemy] = enemy.GetNameString();
                }
                SetUnsaved(true);
            }
        }

        private void listBoxFormationBattleArena_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxFormationBattleArena.SelectedIndex;
            if (!loading && i >= 0 && i < 3 && SelectedFormation != null)
            {
                loading = true;
                comboBoxFormationBattleArena.Enabled = true;
                var id = SelectedFormation.BattleSetupData.BattleArenaIDs[i];
                if (id == HexParser.NULL_OFFSET_16_BIT)
                {
                    comboBoxFormationBattleArena.SelectedIndex = 0;
                }
                else
                {
                    comboBoxFormationBattleArena.SelectedIndex = id + 1;
                }
                loading = false;
            }
        }

        private void comboBoxFormationBattleArena_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newForm = comboBoxFormationBattleArena.SelectedIndex,
                selectedForm = listBoxFormationBattleArena.SelectedIndex;
            if (!loading && newForm >= 0 && newForm <= Scene.ALL_FORMATIONS_COUNT && selectedForm >= 0
                && selectedForm < 3 && SelectedFormation != null)
            {
                if (newForm == 0)
                {
                    SelectedFormation.BattleSetupData.BattleArenaIDs[selectedForm] = HexParser.NULL_OFFSET_16_BIT;
                    listBoxFormationBattleArena.Items[selectedForm] = "(none)";
                }
                else
                {
                    //int i = (int)Math.Floor((decimal)newForm / Scene.FORMATION_COUNT),
                    //    j = newForm % Scene.FORMATION_COUNT;
                    SelectedFormation.BattleSetupData.BattleArenaIDs[selectedForm] = (ushort)(newForm - 1);
                    listBoxFormationBattleArena.Items[selectedForm] = $"Battle ID {newForm - 1}";
                }
                SetUnsaved(true);
            }
        }

        private void listBoxFormationScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            scriptControlFormations.SelectedScriptIndex = listBoxFormationScripts.SelectedIndex;
        }

        private void scriptControlFormations_ScriptAddedOrRemoved(object sender, EventArgs e)
        {
            UpdateScripts(SelectedFormation, listBoxFormationScripts);
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
            //sync unsaved enemy data
            if (SelectedEnemy != null && enemyNeedsSync)
            {
                SyncEnemyData(SelectedEnemy);
            }
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
