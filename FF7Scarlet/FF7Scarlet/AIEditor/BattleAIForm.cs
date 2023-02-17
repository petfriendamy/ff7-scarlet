using FF7Scarlet.SceneEditor;
using FF7Scarlet.Shared;

namespace FF7Scarlet.AIEditor
{
    public partial class BattleAIForm : Form
    {
        private const string WINDOW_TITLE = "Scarlet - Battle A.I. Editor";
        private readonly string[] SCRIPT_LIST = new string[Script.SCRIPT_COUNT]
        {
            "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter",
            "Magic Counter", "Battle Victory", "Pre-Action Setup", "Custom Event 1",
            "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5",
            "Custom Event 6", "Custom Event 7", "Custom Event 8"
        };
        private Scene currScene;
        private Scene[] sceneList;
        private Dictionary<ushort, Attack> syncedAttacks;
        private bool loading = false, unsavedChanges = false, processing = false;

        private Enemy SelectedEnemy
        {
            get { return currScene.GetEnemyByNumber(SelectedEnemyIndex); }
        }
        private int SelectedEnemyIndex
        {
            get { return listBoxEnemies.SelectedIndex + 1; }
        }
        private Script? SelectedScript
        {
            get
            {
                if (SelectedEnemy == null) { return null; }
                return SelectedEnemy.GetScriptAtPosition(SelectedScriptIndex);
            }
        }
        private int SelectedScriptIndex
        {
            get { return listBoxScripts.SelectedIndex; }
        }

        public BattleAIForm(Dictionary<ushort, Attack> syncedAttacks)
        {
            InitializeComponent();

            //create private version of scene data that can be edited freely
            sceneList = DataManager.CopySceneList();
            this.syncedAttacks = syncedAttacks;
            currScene = sceneList[0];
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
            scriptControl.DataChanged += new EventHandler(scriptControl_DataChanged);
            scriptControl.ScriptAdded += new EventHandler(scriptControl_ScriptAddedOrRemoved);
            scriptControl.ScriptRemoved += new EventHandler(scriptControl_ScriptAddedOrRemoved);
        }

        private void BattleAIForm_Load(object sender, EventArgs e)
        {
            
            LoadNewEnemyList();
            loading = false;
        }

        private void LoadNewEnemyList()
        {
            loading = true;
            listBoxEnemies.Items.Clear();
            for (int i = 0; i < Scene.ENEMY_COUNT; ++i)
            {
                var enemy = currScene.GetEnemyByNumber(i + 1);
                if (enemy == null)
                {
                    listBoxEnemies.Items.Add("(none)");
                }
                else
                {
                    var name = enemy.Name.ToString();
                    if (name == null) { listBoxEnemies.Items.Add("(no name)"); }
                    else { listBoxEnemies.Items.Add(name); }
                }
            }
            listBoxEnemies.SelectedIndex = 0;
            listBoxScripts.Enabled = true;
            listBoxScripts.SelectedIndex = 0;
            UpdateScripts(1);
            DisplayScript(1, 0);
        }

        private void UpdateScripts(int selectedEnemy)
        {
            try
            {
                if (!currScene.ScriptsLoaded)
                {
                    currScene.ParseAIScripts();
                }
                var enemy = currScene.GetEnemyByNumber(selectedEnemy);
                for (int i = 0; i < Script.SCRIPT_COUNT; ++i)
                {
                    listBoxScripts.Items[i] = SCRIPT_LIST[i];
                    if (enemy != null)
                    {
                        var script = enemy.GetScriptAtPosition(i);
                        if (script != null && !script.IsEmpty)
                        {
                            listBoxScripts.Items[i] += "*";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayScript(int enemyID, int scriptID)
        {
            var enemy = currScene.GetEnemyByNumber(enemyID);
            scriptControl.AIContainer = enemy;
            scriptControl.SelectedScriptIndex = scriptID;
        }

        private void SetUnsaved(bool unsaved)
        {
            unsavedChanges = unsaved;
            Text = $"{(unsaved ? "*" : "")}{WINDOW_TITLE}";
        }

        private void EnableOrDisableForm(bool enable)
        {
            processing = !enable;
            comboBoxSceneList.Enabled = enable;
            listBoxEnemies.Enabled = enable;
            listBoxScripts.Enabled = enable;
            scriptControl.Enabled = enable;
            buttonSave.Enabled = enable;
            buttonExport.Enabled = enable;
            buttonExportMulti.Enabled = enable;
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

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            EnableOrDisableForm(false);
            int i = 0;
            try
            {
                for (i = 0; i < DataManager.SCENE_COUNT; ++i)
                {
                    await UpdateDataAsync(i);
                    progressBar1.Value = ((i + i) / DataManager.SCENE_COUNT) * 100;
                }
                await Task.Delay(500);

                if (!DataManager.KernelFileIsLoaded)
                {
                    MessageBox.Show("No kernel file is selected, so the lookup table cannot be updated. This scene.bin file may not work correctly in FF7.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DataManager.UpdateAllScenes(this, sceneList);
                DataManager.CreateSceneBin();
                unsavedChanges = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            progressBar1.Value = 0;
            EnableOrDisableForm(true);
            buttonSave.Select();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                EnableOrDisableForm(false);
                currScene.UpdateRawData();
                DialogResult result;
                string path;
                int pos = comboBoxSceneList.SelectedIndex;
                using (var save = new SaveFileDialog())
                {
                    save.FileName = $"scene.{pos}.bin";
                    save.Filter = "Scene file|*.bin";
                    result = save.ShowDialog();
                    path = save.FileName;
                }

                if (result == DialogResult.OK)
                {
                    File.WriteAllBytes(path, currScene.GetRawData());
                    DataManager.UpdateScene(this, currScene, pos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EnableOrDisableForm(true);
            buttonExport.Select();
        }

        private void comboBoxSceneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                currScene = sceneList[comboBoxSceneList.SelectedIndex];
                LoadNewEnemyList();
                loading = false;
            }
        }

        private void listBoxEnemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                UpdateScripts(SelectedEnemyIndex);
                DisplayScript(SelectedEnemyIndex, SelectedScriptIndex);
            }
        }

        private void listBoxScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                DisplayScript(SelectedEnemyIndex, SelectedScriptIndex);
            }
        }

        private void scriptControl_DataChanged(object? sender, EventArgs e)
        {
            SetUnsaved(true);
        }

        private void scriptControl_ScriptAddedOrRemoved(object? sender, EventArgs e)
        {
            UpdateScripts(SelectedEnemyIndex);
        }

        private void BattleAIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processing) { e.Cancel = true; }
            else if (unsavedChanges)
            {
                var result = MessageBox.Show("Unsaved changes will be lost. Are you sure?", "Unsaved changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                e.Cancel = result == DialogResult.No;
            }
        }

        private void BattleAIForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataManager.CloseForm(FormType.BattleAIEditor);
        }
    }
}
