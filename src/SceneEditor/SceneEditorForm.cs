using FF7Scarlet.AIEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Inventory;

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
        private List<StatusChangeType> statusChangeTypes = new();
        private List<Enemy> validEnemies = new();
        private List<Attack> validAttacks = new();
        private List<LocationInfo> locationList = new();
        private int prevScene, prevEnemy, prevAttack, prevFormation, prevFormationEnemy;
        private bool
            loading = false,
            enemyNeedsSync = false,
            attackNeedsSync = false,
            formationNeedsSync = false,
            formationEnemyNeedsSync = false,
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
        private EnemyLocation? SelectedFormationEnemy
        {
            get
            {
                if (SelectedFormation != null && SelectedFormationEnemyIndex >= 0 && SelectedFormationEnemyIndex < Formation.ENEMY_COUNT)
                {
                    return SelectedFormation.EnemyLocations[SelectedFormationEnemyIndex];
                }
                return null;
            }
        }
        private int SelectedFormationEnemyIndex
        {
            get { return listBoxFormationEnemies.SelectedIndex; }
        }

        #endregion

        #region Constructor

        public SceneEditorForm(Dictionary<ushort, Attack> syncedAttacks)
        {
            InitializeComponent();
            this.Text = $"{Application.ProductName} v{Application.ProductVersion} - Scene Editor";

            //set max values for various controls
            textBoxEnemyName.MaxLength = Scene.NAME_LENGTH - 1;
            textBoxAttackName.MaxLength = Scene.NAME_LENGTH - 1;
            numericEnemyHP.Maximum = uint.MaxValue;
            numericEnemyEXP.Maximum = uint.MaxValue;
            numericEnemyGil.Maximum = uint.MaxValue;
            numericFormationEnemyX.Minimum = short.MinValue;
            numericFormationEnemyX.Maximum = short.MaxValue;
            numericFormationEnemyY.Minimum = short.MinValue;
            numericFormationEnemyY.Maximum = short.MaxValue;
            numericFormationEnemyZ.Minimum = short.MinValue;
            numericFormationEnemyZ.Maximum = short.MaxValue;

            //populate combo boxes
            comboBoxEnemyResistElement.BeginUpdate();
            comboBoxEnemyResistElement.Items.Add("None");
            resistList = new List<ResistanceRate>();
            foreach (var e in Enum.GetValues<MateriaElements>())
            {
                comboBoxEnemyResistElement.Items.Add(e);
                resistList.Add(new ElementResistanceRate(e, 0));
            }
            foreach (var s in Enum.GetValues<EquipmentStatus>())
            {
                comboBoxEnemyResistElement.Items.Add($"{StringParser.AddSpaces(s.ToString())} (status)");
                resistList.Add(new StatusResistanceRate(s, 0));
            }
            resistRateList = Enum.GetValues<ResistRates>().ToList();
            foreach (var r in resistRateList)
            {
                comboBoxEnemyResistRate.Items.Add(StringParser.AddSpaces(r.ToString()));
            }
            comboBoxEnemyResistElement.EndUpdate();

            comboBoxAttackStatusChange.BeginUpdate();
            comboBoxAttackStatusChange.Items.Add("None");
            foreach (var s in Enum.GetValues<StatusChangeType>())
            {
                if (s != StatusChangeType.None)
                {
                    comboBoxAttackStatusChange.Items.Add(s);
                    statusChangeTypes.Add(s);
                }
            }
            comboBoxAttackStatusChange.EndUpdate();

            comboBoxAttackConditionSubMenu.BeginUpdate();
            comboBoxAttackConditionSubMenu.Items.Add("None");
            foreach (var c in Enum.GetValues<ConditionSubmenu>())
            {
                if (c != ConditionSubmenu.None)
                {
                    comboBoxAttackConditionSubMenu.Items.Add(c);
                }
            }
            comboBoxAttackConditionSubMenu.EndUpdate();

            locationList =
                (from l in LocationInfo.LOCATION_LIST
                 orderby l.Category, l.Name
                 select l).ToList();
            comboBoxFormationLocation.BeginUpdate();
            foreach (var l in locationList)
            {
                if (l.Category == Locations.TempleOfTheAncients)
                {
                    comboBoxFormationLocation.Items.Add(l.Name);
                }
                else
                {
                    var category = Enum.GetName(l.Category);
                    if (category != null)
                    {
                        comboBoxFormationLocation.Items.Add($"{StringParser.AddSpaces(category)} -- {l.Name}");
                    }
                }
            }
            comboBoxFormationLocation.EndUpdate();

            comboBoxFormationNext.BeginUpdate();
            comboBoxFormationBattleArena.BeginUpdate();
            comboBoxFormationNext.Items.Add("None");
            comboBoxFormationBattleArena.Items.Add("None");
            for (int i = 0; i < Scene.ALL_FORMATIONS_COUNT; ++i)
            {
                comboBoxFormationNext.Items.Add($"Battle ID {i}");
                comboBoxFormationBattleArena.Items.Add($"Battle ID {i}");
            }
            comboBoxFormationNext.EndUpdate();
            comboBoxFormationBattleArena.EndUpdate();

            comboBoxFormationBattleType.BeginUpdate();
            foreach (var t in Enum.GetNames<BattleType>())
            {
                comboBoxFormationBattleType.Items.Add(t);
            }
            comboBoxFormationBattleType.EndUpdate();

            //synced data
            LoadKernelData();
            LoadModelData();

            //disable invalid toolstrips
            enemyPasteToolStripMenuItem.Enabled = DataManager.CopiedEnemy != null;

            //create private version of scene data that can be edited freely
            sceneList = DataManager.CopySceneList();
            this.syncedAttacks = syncedAttacks;
            lastAttackID = 0;
            comboBoxSceneList.BeginUpdate();
            for (int i = 0; i < Scene.SCENE_COUNT; ++i)
            {
                comboBoxSceneList.Items.Add($"{i}: {sceneList[i].GetEnemyNames()}");
                foreach (var atk in sceneList[i].AttackList)
                {
                    if (atk != null && atk.Index > lastAttackID && atk.Index != HexParser.NULL_OFFSET_16_BIT)
                    {
                        lastAttackID = (ushort)atk.Index;
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
            comboBoxSceneList.EndUpdate();
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
            int drop = comboBoxEnemyDropItemID.SelectedIndex,
                steal = comboBoxEnemyMorphItem.SelectedIndex;
            if (drop < 0) { drop = 0; }
            comboBoxEnemyDropItemID.BeginUpdate();
            comboBoxEnemyMorphItem.BeginUpdate();
            comboBoxEnemyDropItemID.Items.Clear();
            comboBoxEnemyMorphItem.Items.Clear();
            itemList.Clear();

            comboBoxEnemyDropItemID.Items.Add("None");
            comboBoxEnemyMorphItem.Items.Add("None");
            if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
            {
                foreach (var item in DataManager.Kernel.ItemData.Items)
                {
                    comboBoxEnemyDropItemID.Items.Add(item.Name);
                    comboBoxEnemyMorphItem.Items.Add(item.Name);
                    var inv = new InventoryItem();
                    inv.Item = DataParser.GetCombinedItemIndex(ItemType.Item, (byte)item.Index);
                    itemList.Add(inv);
                }
                foreach (var wpn in DataManager.Kernel.WeaponData.Weapons)
                {
                    comboBoxEnemyDropItemID.Items.Add(wpn.Name);
                    comboBoxEnemyMorphItem.Items.Add(wpn.Name);
                    var inv = new InventoryItem();
                    inv.Item = DataParser.GetCombinedItemIndex(ItemType.Weapon, (byte)wpn.Index);
                    itemList.Add(inv);
                }
                foreach (var armor in DataManager.Kernel.ArmorData.Armors)
                {
                    comboBoxEnemyDropItemID.Items.Add(armor.Name);
                    comboBoxEnemyMorphItem.Items.Add(armor.Name);
                    var inv = new InventoryItem();
                    inv.Item = DataParser.GetCombinedItemIndex(ItemType.Armor, (byte)armor.Index);
                    itemList.Add(inv);
                }
                foreach (var acc in DataManager.Kernel.AccessoryData.Accessories)
                {
                    comboBoxEnemyDropItemID.Items.Add(acc.Name);
                    comboBoxEnemyMorphItem.Items.Add(acc.Name);
                    var inv = new InventoryItem();
                    inv.Item = DataParser.GetCombinedItemIndex(ItemType.Accessory, (byte)acc.Index);
                    itemList.Add(inv);
                }
                if (DataManager.PS3TweaksEnabled)
                {
                    foreach (var mat in DataManager.Kernel.MateriaData.Materias)
                    {
                        comboBoxEnemyDropItemID.Items.Add(mat.Name);
                        comboBoxEnemyMorphItem.Items.Add(mat.Name);
                        var inv = new InventoryItem();
                        inv.Item = DataParser.GetCombinedItemIndex(ItemType.Materia, (byte)mat.Index);
                        itemList.Add(inv);
                    }
                }
            }
            else
            {
                groupBoxEnemyItemDropRates.Enabled = false;
                comboBoxEnemyMorphItem.Enabled = false;
            }
            comboBoxEnemyDropItemID.EndUpdate();
            comboBoxEnemyMorphItem.EndUpdate();
            comboBoxEnemyDropItemID.SelectedIndex = drop;
            comboBoxEnemyMorphItem.SelectedIndex = steal;
            EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, false, false);
        }

        private void LoadModelData()
        {
            if (DataManager.BattleLgpPathExists && DataManager.BattleLgp != null)
            {
                comboBoxEnemyModelID.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (var m in DataManager.BattleLgp.Models)
                {
                    comboBoxEnemyModelID.Items.Add(m);
                }
            }
        }

        private void LoadSceneData(int sceneIndex, bool clearLoadingWhenDone, bool ignoreNull)
        {
            loading = true;
            var scene = sceneList[sceneIndex];
            if (!scene.ScriptsLoaded) { scene.ParseAIScripts(); }
            int i;

            //get attacks
            listBoxAttacks.BeginUpdate();
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
                    listBoxAttacks.Items.Add(DataParser.GetAttackNameString(a));
                }
            }
            listBoxAttacks.EndUpdate();
            selectedAttackToolStripMenuItem.Enabled = false;

            validAttacks =
                (from a in scene.AttackList
                 where a != null
                 select a).ToList();

            comboBoxEnemyAttackID.BeginUpdate();
            comboBoxEnemyAttackID.Items.Clear();
            comboBoxEnemyAttackID.Items.Add("None");
            foreach (var a in validAttacks)
            {
                comboBoxEnemyAttackID.Items.Add(DataParser.GetAttackNameString(a));
            }
            comboBoxEnemyAttackID.EndUpdate();
            comboBoxEnemyAttackID.SelectedIndex = 0;
            comboBoxEnemyAttackCamID.Text = HexParser.NULL_OFFSET_16_BIT.ToString("X4");
            EnableOrDisableGroupBox(groupBoxEnemyAttacks, false, false);

            //get enemies
            validEnemies =
                (from e in scene.Enemies
                 where e != null
                 select e).ToList();

            comboBoxEnemy.BeginUpdate();
            comboBoxFormationSelectedEnemy.BeginUpdate();
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
                    var name = enemy.GetNameString();
                    comboBoxEnemy.Items.Add(name);
                    comboBoxFormationSelectedEnemy.Items.Add(name);
                }
            }
            comboBoxEnemy.EndUpdate();
            comboBoxFormationSelectedEnemy.EndUpdate();
            comboBoxEnemy.SelectedIndex = 0;
            LoadEnemyData(scene.Enemies[0], false, ignoreNull);

            //get formations
            UpdateFormations(sceneIndex, false);
            if (SelectedFormation != null)
            {
                LoadFormationData(SelectedFormation, false);
            }

            if (clearLoadingWhenDone) { loading = false; }
        }

        private void LoadEnemyData(Enemy? enemy, bool clearLoadingWhenDone, bool ignoreNull)
        {
            loading = true;
            if (enemy == null) //no enemy data to load
            {
                var result = DialogResult.None;
                if (!ignoreNull)
                {
                    result = MessageBox.Show("There is no enemy data in the selected slot. Would you like to create a new enemy?",
                        "No Enemy Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (result == DialogResult.Yes)
                {
                    CreateNewEnemy(SelectedSceneIndex, SelectedEnemyIndex, SelectedFormationIndex);
                }
                else
                {
                    tabControlEnemyData.Enabled = false;
                    enemyDeleteToolStripMenuItem.Enabled = false;
                }
            }
            else //load data
            {
                tabControlEnemyData.Enabled = true;
                enemyDeleteToolStripMenuItem.Enabled = true;

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
                listBoxEnemyElementResistances.BeginUpdate();
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
                listBoxEnemyElementResistances.EndUpdate();
                EnableOrDisableGroupBox(groupBoxEnemyElementResistances, false, false);
                statusesControlEnemyImmunities.SetStatuses(enemy.StatusImmunities);

                //page 2
                listBoxEnemyAttacks.BeginUpdate();
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
                listBoxEnemyAttacks.EndUpdate();
                EnableOrDisableGroupBox(groupBoxEnemyAttacks, false, false);
                numericEnemyBackDamageMultiplier.Value = enemy.BackAttackMultiplier;

                //kernel data
                if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
                {
                    listBoxEnemyItemDropRates.BeginUpdate();
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
                    listBoxEnemyItemDropRates.EndUpdate();
                    EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, false, false);
                    if (enemy.MorphItemIndex == HexParser.NULL_OFFSET_16_BIT)
                    {
                        comboBoxEnemyMorphItem.SelectedIndex = 0;
                    }
                    else
                    {
                        if (enemy.MorphItemIndex >= DataParser.MATERIA_START && !DataManager.PS3TweaksEnabled)
                        {
                            var result = MessageBox.Show("This scene file appears to use materia morphs! Would you like to enable Postscriptthree Tweaks?",
                                "Enable Postscriptthree Tweaks?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                DataManager.PS3TweaksEnabled = true;
                                LoadKernelData();
                                comboBoxEnemyMorphItem.SelectedIndex = enemy.MorphItemIndex + 1;
                            }
                            else
                            {
                                comboBoxEnemyMorphItem.SelectedIndex = 0;
                                enemy.MorphItemIndex = HexParser.NULL_OFFSET_16_BIT;
                                SetUnsaved(true);
                            }
                        }
                        else
                        {
                            comboBoxEnemyMorphItem.SelectedIndex = enemy.MorphItemIndex + 1;
                        }
                    }
                }

                //model ID
                if (DataManager.BattleLgpPathExists)
                {
                    comboBoxEnemyModelID.SelectedIndex = enemy.ModelID;
                }
                else
                {
                    comboBoxEnemyModelID.Text = enemy.ModelID.ToString("X4");
                }

                //A.I. scripts
                scriptControlEnemyAI.AIContainer = enemy;
                UpdateScripts(enemy, listBoxEnemyScripts);
            }
            if (clearLoadingWhenDone) { loading = false; }
        }

        private void CreateNewEnemy(int sceneIndex, int enemyIndex, int formationIndex)
        {
            var scene = sceneList[sceneIndex];
            if (scene != null && enemyIndex != -1)
            {
                //get a valid model ID
                ushort id = 0;
                var enemy = scene.Enemies[enemyIndex];
                if (enemy != null)
                {
                    id = enemy.ModelID;
                }
                else
                {
                    while (scene.GetEnemyByID(id) != null)
                    {
                        id++;
                    }
                }

                enemy = new Enemy(scene, id, new FFText(), null);
                scene.Enemies[enemyIndex] = enemy;
                validEnemies.Add(enemy);
                comboBoxFormationSelectedEnemy.Items.Add(enemy.GetNameString());
                tabControlMain.SelectedTab = tabPageEnemyData;
                UpdateSelectedEnemyName(sceneIndex, enemyIndex, formationIndex);
                enemyNeedsSync = false;
                SetUnsaved(true);
                LoadEnemyData(enemy, false, true);
            }
        }

        private void UpdateSelectedEnemyName(int scene, int enemy, int formation)
        {
            if (scene >= 0 && scene < Scene.SCENE_COUNT)
            {
                comboBoxSceneList.SelectedIndex = scene;
                if (enemy >= 0 && enemy < Scene.ENEMY_COUNT)
                {
                    var e = sceneList[scene].Enemies[enemy];
                    comboBoxEnemy.SelectedIndex = enemy;

                    loading = true;
                    comboBoxSceneList.Items[scene] = $"{scene}: {sceneList[scene].GetEnemyNames()}";
                    string name;
                    if (e == null) { name = "(none)"; }
                    else { name = sceneList[scene].GetEnemyName(e.ModelID); }
                    comboBoxEnemy.Items[enemy] = name;

                    //update name in formation data
                    UpdateFormations(scene, false);
                    var f = sceneList[scene].Formations[formation];
                    if (e != null)
                    {
                        for (int i = 0; i < Formation.ENEMY_COUNT; ++i)
                        {
                            if (f.EnemyLocations[i].EnemyID == e.ModelID)
                            {
                                listBoxFormationEnemies.Items[i] = name;
                            }
                        }
                        int j = validEnemies.IndexOf(e);
                        comboBoxFormationSelectedEnemy.Items[j] = name;
                    }
                    loading = false;
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
            if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
            {
                //get item name
                var item = new InventoryItem();
                item.Item = rate.ItemID;
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

            if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
            {
                if (comboBoxEnemyMorphItem.SelectedIndex == 0)
                {
                    enemy.MorphItemIndex = HexParser.NULL_OFFSET_16_BIT;
                }
                else
                {
                    enemy.MorphItemIndex = (ushort)(comboBoxEnemyMorphItem.SelectedIndex - 1);
                }
            }
            enemyNeedsSync = false;
        }

        private void LoadAttackData(Attack? attack, bool clearLoadingWhenDone)
        {
            loading = true;
            selectedAttackToolStripMenuItem.Enabled = true;
            attackPasteToolStripMenuItem.Enabled = DataManager.CopiedAttack != null;

            if (attack == null)
            {
                var result = MessageBox.Show("There is no attack data in the selected slot. Would you like to create a new attack?",
                    "No Attack Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (SelectedScene != null && SelectedAttackIndex != -1)
                    {
                        CreateNewAttack(SelectedScene, SelectedAttackIndex);
                    }
                }
                else
                {
                    tabControlAttackData.Enabled = false;
                    attackDeleteToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                tabControlAttackData.Enabled = true;
                attackDeleteToolStripMenuItem.Enabled = true;

                //page 1
                textBoxAttackID.Text = attack.Index.ToString("X4");
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
                statusesControlAttack.SetStatuses(attack.Statuses);
                if (attack.ConditionSubmenu == ConditionSubmenu.None)
                {
                    comboBoxAttackConditionSubMenu.SelectedIndex = 0;
                }
                else
                {
                    comboBoxAttackConditionSubMenu.SelectedIndex = (int)attack.ConditionSubmenu + 1;
                }
                numericAttackStatusChangeChance.Value = attack.StatusChange.Amount;
                if (attack.StatusChange.Type == StatusChangeType.None)
                {
                    comboBoxAttackStatusChange.SelectedIndex = 0;
                }
                else
                {
                    comboBoxAttackStatusChange.SelectedIndex = statusChangeTypes.IndexOf(attack.StatusChange.Type) + 1;
                }

                //page 3
                targetDataControlAttack.SetTargetData(attack.TargetFlags);
            }

            if (clearLoadingWhenDone) { loading = false; }
        }

        private void CreateNewAttack(Scene scene, int attack)
        {
            lastAttackID++;
            var newAttack = new Attack();
            newAttack.Index = lastAttackID;
            scene.AttackList[attack] = newAttack;
            var name = scene.GetAttackName(lastAttackID);
            UpdateSelectedAttackName(scene, SelectedEnemy, attack);
            validAttacks.Add(newAttack);
            comboBoxEnemyAttackID.Items.Add(name);
            tabControlMain.SelectedTab = tabPageAttackData;
            SetUnsaved(true);
            LoadAttackData(SelectedAttack, false);
        }

        private void UpdateSelectedAttackName(Scene scene, Enemy? enemy, int attack)
        {
            if (attack >= 0 && attack < Scene.ATTACK_COUNT)
            {
                var atk = scene.AttackList[attack];
                if (atk != null)
                {
                    loading = true;
                    string name = scene.GetAttackName((ushort)atk.Index);
                    int i, j;
                    listBoxAttacks.SelectedIndex = attack;
                    listBoxAttacks.Items[attack] = name;

                    //update name in enemy data
                    if (enemy != null)
                    {
                        for (i = 0; i < Enemy.ATTACK_COUNT; ++i)
                        {
                            if (enemy.AttackIDs[i] == atk.Index)
                            {
                                listBoxEnemyAttacks.Items[i] = name;
                                break;
                            }
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

        private void SyncAttackData(Attack attack)
        {
            attack.AccuracyRate = (byte)numericAttackAttackPercent.Value;
            attack.MPCost = (ushort)numericAttackMPCost.Value;
            attack.TargetFlags = targetDataControlAttack.GetTargetData();
            attack.DamageCalculationID = damageCalculationControlAttack.ActualValue;
            attack.AttackStrength = damageCalculationControlAttack.AttackPower;
            if (comboBoxAttackConditionSubMenu.SelectedIndex == 0)
            {
                attack.ConditionSubmenu = ConditionSubmenu.None;
            }
            else
            {
                attack.ConditionSubmenu = (ConditionSubmenu)(comboBoxAttackConditionSubMenu.SelectedIndex - 1);
            }
            attack.Statuses = statusesControlAttack.GetStatuses();
            attack.Elements = elementsControlAttack.GetElements();
            attack.SpecialAttackFlags = specialAttackFlagsControlAttack.GetFlags();

            attackNeedsSync = false;
        }

        private void LoadFormationData(Formation formation, bool clearLoadingWhenDone)
        {
            loading = true;
            var scene = formation.Parent as Scene;
            if (scene == null) { throw new ArgumentNullException(); }
            int i;

            //enemies
            listBoxFormationEnemies.BeginUpdate();
            listBoxFormationEnemies.Items.Clear();
            foreach (var e in formation.EnemyLocations)
            {
                listBoxFormationEnemies.Items.Add(scene.GetEnemyName(e.EnemyID));
            }
            listBoxFormationEnemies.EndUpdate();
            EnableOrDisableGroupBox(groupBoxFormationEnemies, false, false);

            //battle setup data
            if (formation.BattleSetupData.Location == null)
            {
                comboBoxFormationLocation.SelectedIndex = -1;
            }
            else
            {
                comboBoxFormationLocation.SelectedIndex = locationList.IndexOf(formation.BattleSetupData.Location);
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
            listBoxFormationBattleArena.BeginUpdate();
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
            listBoxFormationBattleArena.EndUpdate();
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
            cameraPositionControlExtra3.SetPosition(formation.CameraPlacementData.CameraPositions[3],
                formation.CameraPlacementData.CameraDirections[3]);

            //A.I. scripts
            scriptControlFormations.AIContainer = formation;
            UpdateScripts(formation, listBoxFormationScripts);

            if (clearLoadingWhenDone) { loading = false; }
        }

        private void UpdateFormations(int scene, bool clearLoadingWhenDone)
        {
            loading = true;
            int index = Math.Max(0, comboBoxFormation.SelectedIndex);
            comboBoxFormation.BeginUpdate();
            comboBoxFormation.Items.Clear();
            for (int i = 0; i < Scene.FORMATION_COUNT; ++i)
            {
                comboBoxFormation.Items.Add($"{(Scene.FORMATION_COUNT *
                    SelectedSceneIndex) + i}: {sceneList[scene].GetFormationEnemyNames(i)}");
            }
            comboBoxFormation.EndUpdate();
            comboBoxFormation.SelectedIndex = index;
            if (clearLoadingWhenDone) { loading = false; }
        }

        private void SyncFormationData(Formation formation)
        {
            //battle setup data
            formation.BattleSetupData.Location = locationList[comboBoxFormationLocation.SelectedIndex];
            formation.BattleSetupData.BattleFlags = battleFlagsControlFormation.GetFlags();
            if (comboBoxFormationNext.SelectedIndex == 0)
            {
                formation.BattleSetupData.NextSceneID = HexParser.NULL_OFFSET_16_BIT;
            }
            else
            {
                formation.BattleSetupData.NextSceneID = (ushort)(comboBoxFormationNext.SelectedIndex - 1);
            }
            formation.BattleSetupData.BattleType = (BattleType)comboBoxFormationBattleType.SelectedIndex;
            formation.BattleSetupData.EscapeCounter = (ushort)numericFormationEscapeCounter.Value;
            formation.BattleSetupData.PreBattleCameraPosition = (byte)numericFormationPreBattleCamPosition.Value;

            //camera data
            formation.CameraPlacementData.CameraPositions[0] = cameraPositionControlMain.GetPosition();
            formation.CameraPlacementData.CameraDirections[0] = cameraPositionControlMain.GetAngle();
            formation.CameraPlacementData.CameraPositions[1] = cameraPositionControlExtra1.GetPosition();
            formation.CameraPlacementData.CameraDirections[1] = cameraPositionControlExtra1.GetAngle();
            formation.CameraPlacementData.CameraPositions[2] = cameraPositionControlExtra2.GetPosition();
            formation.CameraPlacementData.CameraDirections[2] = cameraPositionControlExtra2.GetAngle();
            formation.CameraPlacementData.CameraPositions[3] = cameraPositionControlExtra3.GetPosition();
            formation.CameraPlacementData.CameraDirections[3] = cameraPositionControlExtra3.GetAngle();

            formationNeedsSync = false;
        }

        private void SyncFormationEnemyData(EnemyLocation enemy)
        {
            enemy.Location = new Point3D((short)numericFormationEnemyX.Value, (short)numericFormationEnemyY.Value,
                (short)numericFormationEnemyZ.Value);
            enemy.Row = (ushort)numericFormationEnemyRow.Value;
            enemy.InitialConditionFlags = initialConditionControlEnemy.GetFlags();
            Array.Copy(coverFlagsControlFormationEnemy.GetFlags(), enemy.CoverFlags, enemy.CoverFlags.Length);

            formationEnemyNeedsSync = false;
        }

        private void SyncAllUnsavedData(bool prev = false)
        {
            var scene = SelectedScene;
            if (prev) { scene = sceneList[prevScene]; }

            if (scene != null)
            {
                //sync the unsaved enemy data
                if (enemyNeedsSync)
                {
                    var enemy = SelectedEnemy;
                    if (prev) { enemy = scene.Enemies[prevEnemy]; }
                    if (enemy != null)
                    {
                        SyncEnemyData(enemy);
                    }
                }

                //sync unsaved attack data
                if (attackNeedsSync)
                {
                    var attack = SelectedAttack;
                    if (prev) { attack = scene.AttackList[prevAttack]; }
                    if (attack != null)
                    {
                        SyncAttackData(attack);
                    }
                }

                //sync unsaved formation data
                var form = SelectedFormation;
                if (prev) { form = scene.Formations[prevFormation]; }
                if (form != null)
                {
                    if (formationNeedsSync)
                    {
                        SyncFormationData(form);
                    }
                    if (formationEnemyNeedsSync)
                    {
                        int fe = comboBoxFormationSelectedEnemy.SelectedIndex;
                        if (prev) { fe = prevFormationEnemy; }
                        SyncFormationEnemyData(form.EnemyLocations[fe]);
                    }
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
            buttonSearch.Enabled = enable;
            tabControlMain.Enabled = enable;
            buttonSave.Enabled = enable;
            buttonImport.Enabled = enable;
            buttonExport.Enabled = enable;
        }

        private async void SaveSceneBin()
        {
            SyncAllUnsavedData();
            EnableOrDisableForm(false);
            int i = 0;
            try
            {
                for (i = 0; i < Scene.SCENE_COUNT; ++i)
                {
                    await UpdateDataAsync(i);
                    progressBarSaving.Value = ((i + 1) / Scene.SCENE_COUNT) * 100;
                }
                await Task.Delay(500);

                if (!DataManager.KernelFilePathExists)
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

        private async Task UpdateDataAsync(int pos)
        {
            try
            {
                await Task.Run(() => sceneList[pos].GetRawData());
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception was thrown in scene {pos}:\n\n{ex.Message}", ex);
            }
        }

        #endregion

        #region Event Methods

        private void comboBoxSceneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedScene != null)
            {
                SyncAllUnsavedData(true);
                prevScene = SelectedSceneIndex;
                LoadSceneData(SelectedSceneIndex, true, false);
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
                LoadEnemyData(SelectedEnemy, true, false);
            }
        }

        private void listBoxAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedScene != null)
            {
                if (attackNeedsSync) //sync the unsaved attack data
                {
                    var attack = SelectedScene.AttackList[prevAttack];
                    if (attack != null)
                    {
                        SyncAttackData(attack);
                    }
                }
                prevAttack = SelectedAttackIndex;
                LoadAttackData(SelectedAttack, true);
            }
        }

        private void comboBoxFormation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedFormation != null && SelectedScene != null)
            {
                if (formationNeedsSync || formationEnemyNeedsSync) //sync the unsaved formation data
                {
                    var formation = SelectedScene.Formations[prevFormation];
                    if (formation != null)
                    {
                        if (formationNeedsSync)
                        {
                            SyncFormationData(formation);
                        }
                        if (formationEnemyNeedsSync)
                        {
                            SyncFormationEnemyData(formation.EnemyLocations[prevFormationEnemy]);
                        }
                    }
                }
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
                if (atk == null) //no attack selected
                {
                    comboBoxEnemyAttackID.SelectedIndex = 0;
                    comboBoxEnemyAttackCamID.Text = HexParser.NULL_OFFSET_16_BIT.ToString("X4");
                    EnableOrDisableGroupBox(groupBoxEnemyAttacks, false, true, comboBoxEnemyAttackID);
                }
                else //select an attack
                {
                    EnableOrDisableGroupBox(groupBoxEnemyAttacks, true, false);
                    comboBoxEnemyAttackID.SelectedIndex = validAttacks.IndexOf(atk) + 1;
                    numericAttackAnimationIndex.Value = SelectedEnemy.ActionAnimationIndexes[i];
                    comboBoxEnemyAttackCamID.Text = SelectedEnemy.CameraMovementIDs[i].ToString("X4");
                    checkBoxEnemyAttackIsManipable.Checked = SelectedEnemy.AttackIsManipable((ushort)atk.Index);
                    if (SelectedEnemy.ManipListIsEmpty())
                    {
                        buttonViewManipList.Enabled = false;
                    }
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
                if (newAttack == 0) //none
                {
                    SelectedEnemy.AttackIDs[selectedAttack] = HexParser.NULL_OFFSET_16_BIT;
                    listBoxEnemyAttacks.Items[selectedAttack] = "(none)";
                    EnableOrDisableGroupBox(groupBoxEnemyAttacks, false, true, comboBoxEnemyAttackID);
                }
                else //add attack
                {
                    var atk = validAttacks[newAttack - 1];
                    SelectedEnemy.AttackIDs[selectedAttack] = (ushort)atk.Index;
                    listBoxEnemyAttacks.Items[selectedAttack] = DataParser.GetAttackNameString(atk);
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
                            buttonViewManipList.Enabled = true;
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
                    for (j = 0; j < Enemy.MANIP_ATTACK_COUNT; ++j)
                    {
                        if (SelectedEnemy.ManipAttackIDs[j] == SelectedEnemy.AttackIDs[i])
                        {
                            for (n = j + 1; n < Enemy.MANIP_ATTACK_COUNT; ++n) //shift attacks up
                            {
                                SelectedEnemy.ManipAttackIDs[n - 1] = SelectedEnemy.ManipAttackIDs[n];
                            }
                            SelectedEnemy.ManipAttackIDs[Enemy.MANIP_ATTACK_COUNT - 1] =
                                HexParser.NULL_OFFSET_16_BIT;
                            if (SelectedEnemy.ManipListIsEmpty())
                            {
                                buttonViewManipList.Enabled = false;
                            }
                            SetUnsaved(true);
                            return;
                        }
                    }
                }
                loading = false;
            }
        }

        private void buttonViewManipList_Click(object sender, EventArgs e)
        {
            if (SelectedScene != null && SelectedEnemy != null)
            {
                if (SelectedEnemy.ManipListIsEmpty())
                {
                    MessageBox.Show("The manip list is empty.", "No Attacks", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result;
                    ushort[] manipList;
                    using (var form = new ManipListForm(SelectedScene, SelectedEnemyIndex))
                    {
                        result = form.ShowDialog();
                        manipList = form.ManipList;
                    }

                    //update the manip list
                    if (result == DialogResult.OK)
                    {
                        Array.Copy(manipList, SelectedEnemy.ManipAttackIDs, Enemy.MANIP_ATTACK_COUNT);
                        var manipAttack = SelectedScene.GetAttackByID(SelectedEnemy.AttackIDs[listBoxEnemyAttacks.SelectedIndex]);
                        if (manipAttack != null)
                        {
                            loading = true;
                            checkBoxEnemyAttackIsManipable.Checked = SelectedEnemy.AttackIsManipable((ushort)manipAttack.Index);
                            loading = false;
                        }
                        SetUnsaved(true);
                    }
                }
            }
        }

        private void listBoxEnemyItemDropRates_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxEnemyItemDropRates.SelectedIndex;
            if (!loading && i >= 0 && i < 4 && SelectedEnemy != null && DataManager.KernelFilePathExists &
                DataManager.Kernel != null)
            {
                comboBoxEnemyDropItemID.Enabled = true;
                var item = SelectedEnemy.ItemDropRates[i];
                if (item == null)
                {
                    comboBoxEnemyDropItemID.SelectedIndex = 0;
                    EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, false, true, comboBoxEnemyDropItemID);
                }
                else if (item.ItemID >= DataParser.MATERIA_START && !DataManager.PS3TweaksEnabled)
                {
                    var result = MessageBox.Show("This scene file appears to use materia drops! Would you like to enable Postscriptthree Tweaks?",
                                "Enable Postscriptthree Tweaks?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataManager.PS3TweaksEnabled = true;
                        LoadKernelData();
                        EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, true, false);
                        comboBoxEnemyDropItemID.SelectedIndex = item.ItemID + 1;
                        checkBoxEnemyItemIsSteal.Checked = item.IsSteal;
                        numericEnemyDropRate.Value = item.DropRate;
                    }
                    else
                    {
                        comboBoxEnemyDropItemID.SelectedIndex = 0;
                        EnableOrDisableGroupBox(groupBoxEnemyItemDropRates, false, true, comboBoxEnemyDropItemID);
                    }
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
                && DataManager.KernelFilePathExists && DataManager.Kernel != null)
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
                        drop = new ItemDropRate(item.Item, rate, false);
                        SelectedEnemy.ItemDropRates[selectedItem] = drop;
                        listBoxEnemyItemDropRates.Items[selectedItem] = GetItemDropText(drop);
                    }
                    else
                    {
                        drop.ItemID = item.Item;
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
            //this one runs when battle.lgp is loaded
            if (!loading && SelectedEnemy != null && DataManager.BattleLgpPathExists
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
            //this one runs when battle.lgp is NOT loaded
            if (!loading && !DataManager.BattleLgpPathExists && SelectedEnemy != null)
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

        private void textBoxAttackName_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedScene != null && SelectedEnemy != null && SelectedAttack != null)
            {
                SelectedAttack.Name = textBoxAttackName.Text;
                UpdateSelectedAttackName(SelectedScene, SelectedEnemy, SelectedAttackIndex);
                SetUnsaved(true);
            }
        }

        private void comboBoxAttackAttackEffectID_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackAttackEffectID.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.AttackEffectID = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackImpactEffectID_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackImpactEffectID.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.ImpactEffectID = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackCamMovementIDSingle_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackCamMovementIDSingle.Text;
                if (text.Length == 4)
                {
                    ushort newID;
                    if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.CameraMovementIDSingle = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackCamMovementIDMulti_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackCamMovementIDMulti.Text;
                if (text.Length == 4)
                {
                    ushort newID;
                    if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.CameraMovementIDMulti = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackHurtActionIndex_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackHurtActionIndex.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.TargetHurtActionIndex = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBoxAttackStatusChange.SelectedIndex;
            numericAttackStatusChangeChance.Enabled = (i > 0);
            statusesControlAttack.Enabled = (i > 0);
            if (!loading && SelectedAttack != null)
            {
                if (i == 0)
                {
                    SelectedAttack.StatusChange.Type = StatusChangeType.None;
                }
                else
                {
                    SelectedAttack.StatusChange.Type = statusChangeTypes[i - 1];
                }
                SetUnsaved(true);
            }
        }

        private void numericAttackStatusChangeChance_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                SelectedAttack.StatusChange.Amount = (byte)numericAttackStatusChangeChance.Value;
                SetUnsaved(true);
            }
        }

        private void AttackDataChanged(object? sender, EventArgs e)
        {
            if (!loading)
            {
                attackNeedsSync = true;
                SetUnsaved(true);
            }
        }

        private void listBoxFormationEnemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedFormationEnemy != null && SelectedFormation != null && SelectedScene != null)
            {
                loading = true;
                if (formationEnemyNeedsSync) //sync the unsaved formation data
                {
                    SyncFormationEnemyData(SelectedFormation.EnemyLocations[prevFormationEnemy]);
                }
                prevFormationEnemy = SelectedFormationEnemyIndex;
                var enemy = SelectedScene.GetEnemyByID(SelectedFormationEnemy.EnemyID);
                if (enemy == null)
                {
                    comboBoxFormationSelectedEnemy.SelectedIndex = 0;
                    EnableOrDisableGroupBox(groupBoxFormationEnemies, false, true, comboBoxFormationSelectedEnemy);
                }
                else
                {
                    comboBoxFormationSelectedEnemy.SelectedIndex = validEnemies.IndexOf(enemy) + 1;
                    EnableOrDisableGroupBox(groupBoxFormationEnemies, true, false);

                    numericFormationEnemyX.Value = SelectedFormationEnemy.Location.X;
                    numericFormationEnemyY.Value = SelectedFormationEnemy.Location.Y;
                    numericFormationEnemyZ.Value = SelectedFormationEnemy.Location.Z;
                    numericFormationEnemyRow.Value = SelectedFormationEnemy.Row;
                    coverFlagsControlFormationEnemy.SetFlags(SelectedFormationEnemy.CoverFlags);
                    initialConditionControlEnemy.SetConditions(SelectedFormationEnemy.InitialConditionFlags);
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

        private void FormationDataChanged(object? sender, EventArgs e)
        {
            if (!loading)
            {
                formationNeedsSync = true;
                SetUnsaved(true);
            }
        }

        private void FormationEnemyDataChanged(object? sender, EventArgs e)
        {
            if (!loading)
            {
                formationEnemyNeedsSync = true;
                SetUnsaved(true);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSceneBin();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            SyncAllUnsavedData();
            DialogResult result;
            string[] paths;
            using (var import = new OpenFileDialog())
            {
                import.Filter = "Scene files|scene.*.bin";
                import.Multiselect = true;
                result = import.ShowDialog();
                paths = import.FileNames;
            }

            if (result == DialogResult.OK && paths.Length > 0)
            {
                var successfulImports = new List<int>();
                var unsuccessfulImports = new List<int>();

                foreach (var path in paths)
                {
                    //attempt to get the scene's number
                    string temp = Path.GetFileNameWithoutExtension(path);
                    temp = temp.Substring(temp.IndexOf('.') + 1);
                    int sceneIndex;
                    if (!int.TryParse(temp, out sceneIndex))
                    {
                        MessageBox.Show($"Invalid scene file: {Path.GetFileName(path)}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //if only one file is selected, prompt to import into the current scene
                        if (paths.Length == 1 && SelectedSceneIndex != sceneIndex && SelectedSceneIndex >= 0)
                        {
                            result = MessageBox.Show("Import into the currently selected scene? Otherwise, the scene will be imported into the scene matching the file name.",
                                "Import Selected?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            switch (result)
                            {
                                case DialogResult.Cancel:
                                    return;
                                case DialogResult.Yes:
                                    sceneIndex = SelectedSceneIndex;
                                    break;
                            }
                        }

                        //attempt to insert the scene at the correct place
                        try
                        {
                            var newScene = new Scene(path);
                            sceneList[sceneIndex] = newScene;
                            comboBoxSceneList.Items[sceneIndex] = $"{sceneIndex}: {newScene.GetEnemyNames()}";
                            successfulImports.Add(sceneIndex);
                        }
                        catch
                        {
                            unsuccessfulImports.Add(sceneIndex);
                        }
                    }
                }

                //display which scenes imported correctly
                successfulImports.Sort();
                if (successfulImports.Count == 0)
                {
                    MessageBox.Show("Failed to import scene(s).", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    string output = "Successfully imported the following scene(s): ";
                    int i;
                    for (i = 0; i < successfulImports.Count; ++i)
                    {
                        if (i == successfulImports.Count - 1)
                        {
                            output += successfulImports[i].ToString();
                        }
                        else
                        {
                            output += $"{successfulImports[i]}, ";
                        }
                    }

                    //if any scenes failed to import, list those
                    if (unsuccessfulImports.Count > 0)
                    {
                        unsuccessfulImports.Sort();
                        output += "\n\nThe following scene(s) failed to import: ";
                        for (i = 0; i < unsuccessfulImports.Count; ++i)
                        {
                            if (i == unsuccessfulImports.Count - 1)
                            {
                                output += unsuccessfulImports[i].ToString();
                            }
                            else
                            {
                                output += $"{unsuccessfulImports[i]}, ";
                            }
                        }
                    }

                    MessageBox.Show(output, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxSceneList.SelectedIndex = successfulImports[0];
                    if (SelectedScene != null)
                    {
                        LoadSceneData(SelectedSceneIndex, true, true);
                    }
                    SetUnsaved(true);
                }
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SyncAllUnsavedData();
            using (var export = new SceneExportForm(sceneList, SelectedSceneIndex))
            {
                export.ShowDialog();
            }
        }

        private void sceneCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedScene != null)
            {
                DataManager.CopiedScene = new Scene(SelectedScene);
                scenePasteToolStripMenuItem.Enabled = true;
            }
        }

        private void scenePasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedSceneIndex != -1 && DataManager.CopiedScene != null)
            {
                sceneList[SelectedSceneIndex] = new Scene(DataManager.CopiedScene);
                LoadSceneData(SelectedSceneIndex, true, true);
                enemyNeedsSync = false;
                attackNeedsSync = false;
                formationNeedsSync = false;
                formationEnemyNeedsSync = false;
                SetUnsaved(true);
            }
        }

        private void sceneClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedScene != null)
            {
                var result = MessageBox.Show("This will delete ALL enemies, attacks, and formations contained within this scene. Are you sure you want to do this?",
                    "Delete Scene?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    loading = true;
                    sceneList[SelectedSceneIndex] = new Scene();
                    comboBoxSceneList.Items[SelectedSceneIndex] = $"{SelectedSceneIndex}: {sceneList[SelectedSceneIndex].GetEnemyNames()}";
                    LoadSceneData(SelectedSceneIndex, false, true);
                    enemyNeedsSync = false;
                    attackNeedsSync = false;
                    formationNeedsSync = false;
                    formationEnemyNeedsSync = false;
                    loading = false;
                    SetUnsaved(true);
                }
            }
        }

        private void createNewEnemyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedEnemy != null)
            {
                var result = MessageBox.Show("There is already enemy data in the selected slot. Are you sure you want to overwrite it?",
                    "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) { return; }
            }
            CreateNewEnemy(SelectedSceneIndex, SelectedEnemyIndex, SelectedFormationIndex);
        }

        private void enemyCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedEnemy != null)
            {
                DataManager.CopiedEnemy = new Enemy(SelectedEnemy);
                enemyPasteToolStripMenuItem.Enabled = true;
            }
        }

        private void enemyPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedEnemyIndex != -1 && SelectedScene != null && DataManager.CopiedEnemy != null)
            {
                SelectedScene.Enemies[SelectedEnemyIndex] = new Enemy(DataManager.CopiedEnemy);
                LoadEnemyData(SelectedEnemy, true, true);
                UpdateSelectedEnemyName(SelectedSceneIndex, SelectedEnemyIndex, SelectedFormationIndex);
                tabControlMain.SelectedTab = tabPageEnemyData;
                enemyNeedsSync = false;
                SetUnsaved(true);
            }
        }

        private void enemyDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedEnemy != null && SelectedScene != null && SelectedFormation != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected enemy? This can't be undone!",
                    "Delete Enemy?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //remove the enemy from all formations
                    ushort id = SelectedEnemy.ModelID;
                    int i, j;
                    for (i = 0; i < Scene.FORMATION_COUNT; ++i)
                    {
                        for (j = 0; j < Formation.ENEMY_COUNT; ++j)
                        {
                            if (SelectedScene.Formations[i].EnemyLocations[j].EnemyID == id)
                            {
                                SelectedScene.Formations[i].EnemyLocations[j].EnemyID = HexParser.NULL_OFFSET_16_BIT;
                            }
                        }
                    }
                    LoadFormationData(SelectedFormation, true);

                    //remove enemy from valid enemies list
                    i = validEnemies.IndexOf(SelectedEnemy);
                    validEnemies.RemoveAt(i);
                    comboBoxFormationSelectedEnemy.Items.RemoveAt(i);

                    //delete the enemy
                    SelectedScene.Enemies[SelectedEnemyIndex] = null;
                    UpdateSelectedEnemyName(SelectedSceneIndex, SelectedEnemyIndex, SelectedFormationIndex);
                    tabControlEnemyData.Enabled = false;
                    enemyDeleteToolStripMenuItem.Enabled = false;
                    enemyNeedsSync = false;
                    SetUnsaved(true);
                }
            }
        }

        private void attackCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAttack != null)
            {
                DataManager.CopiedAttack = DataParser.CopyAttack(SelectedAttack);
                attackPasteToolStripMenuItem.Enabled = true;
            }
        }

        private void attackPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAttackIndex != -1 && SelectedScene != null && DataManager.CopiedAttack != null)
            {
                //check if this is a synced attack
                bool getSynced = false;
                if (syncedAttacks.ContainsKey((ushort)DataManager.CopiedAttack.Index))
                {
                    var result = MessageBox.Show("The copied enemy is a synced attack. Would you like to sync this one as well?",
                        "Sync Attack?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Cancel) { return; }
                    getSynced = result == DialogResult.Yes;
                }

                //set the new attack data
                if (getSynced)
                {
                    SelectedScene.AttackList[SelectedAttackIndex] = syncedAttacks[(ushort)DataManager.CopiedAttack.Index];
                }
                else
                {
                    SelectedScene.AttackList[SelectedAttackIndex] = DataParser.CopyAttack(DataManager.CopiedAttack);
                }
                LoadAttackData(SelectedAttack, true);
                UpdateSelectedAttackName(SelectedScene, SelectedEnemy, SelectedAttackIndex);
                SetUnsaved(true);
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
