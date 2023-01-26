using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet
{
    public partial class BattleAIForm : Form
    {
        private const string WINDOW_TITLE = "Scarlet - Battle A.I. Editor";
        private readonly string[] SCRIPT_LIST = new string[Scene.SCRIPT_NUMBER]
        {
            "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter",
            "Magic Counter", "Battle Victory", "Pre-Action Setup", "Custom Event 1",
            "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5",
            "Custom Event 6", "Custom Event 7", "Custom Event 8"
        };
        private Scene currScene;
        private Scene[] sceneList;
        private List<Code> clipboard;
        private bool loading = false, unsavedChanges = false, processing = false;

        private Enemy SelectedEnemy
        {
            get { return currScene.GetEnemyByNumber(SelectedEnemyIndex); }
        }
        private int SelectedEnemyIndex
        {
            get { return listBoxEnemies.SelectedIndex + 1; }
        }
        private Script SelectedScript
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
        private Code SelectedCode
        {
            get
            {
                if (SelectedEnemy == null || SelectedScript == null) { return null; }
                return SelectedScript.GetCodeAtPosition(SelectedCodeIndex);
            }
        }
        private int SelectedCodeIndex
        {
            get { return listBoxCurrScript.SelectedIndex; }
        }

        public BattleAIForm()
        {
            InitializeComponent();
        }

        private void BattleAIForm_Load(object sender, EventArgs e)
        {
            sceneList = DataManager.CopySceneList();
            currScene = sceneList[0];
            for (int i = 0; i < DataManager.SCENE_COUNT; ++i)
            {
                comboBoxSceneList.Items.Add($"{i}: {sceneList[i].GetEnemyNames()}");
            }
            comboBoxSceneList.SelectedIndex = 0;
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
                    listBoxEnemies.Items.Add(enemy.Name.ToString());
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
                for (int i = 0; i < Scene.SCRIPT_NUMBER; ++i)
                {
                    listBoxScripts.Items[i] = SCRIPT_LIST[i];
                    if (enemy != null)
                    {
                        if (enemy.GetScriptAtPosition(i) != null)
                        {
                            if (!enemy.GetScriptAtPosition(i).IsEmpty)
                            {
                                listBoxScripts.Items[i] += "*";
                            }
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
            listBoxCurrScript.Items.Clear();
            if (enemy == null)
            {
                listBoxCurrScript.Enabled = false;
                listBoxCurrScript.Items.Add("(Enemy doesn't exist.)");
            }
            else
            {
                var script = enemy.GetScriptAtPosition(scriptID);
                toolStripScript.Enabled = true;
                if (script == null)
                {
                    listBoxCurrScript.Enabled = false;
                    listBoxCurrScript.Items.Add("(Script is empty)");
                }
                else
                {
                    listBoxCurrScript.Enabled = true;
                    foreach (var line in script.Disassemble())
                    {
                        listBoxCurrScript.Items.Add(line);
                    }
                }
            }
        }

        private void ReloadScript(int selected)
        {
            loading = true;
            DisplayScript(SelectedEnemyIndex, SelectedScriptIndex);
            listBoxCurrScript.SelectedIndex = selected;
            loading = false;
        }

        private void SetUnsaved(bool unsaved)
        {
            unsavedChanges = unsaved;
            Text = $"{(unsaved ? "*" : "")}{WINDOW_TITLE}";
        }

        private void SetClipboard(bool cut)
        {
            //get indices as ints
            var indices = new List<int> { };
            foreach (int i in listBoxCurrScript.SelectedIndices)
            {
                indices.Add(i);
            }
            indices.Sort();

            //if code is selected, copy it to the clipboard
            if (indices.Count > 0)
            {
                clipboard = new List<Code> { };
                foreach (int i in indices)
                {
                    clipboard.Add(SelectedScript.GetCodeAtPosition(i));
                }

                if (cut) //remove code from the script
                {
                    RemoveSelectedLines();
                }
                toolStripButtonPaste.Enabled = true;
            }
        }

        private void RemoveSelectedLines()
        {
            //get indices as ints
            var indices = new List<int> { };
            foreach (int i in listBoxCurrScript.SelectedIndices)
            {
                indices.Add(i);
            }
            indices.Sort();
            indices.Reverse();

            //if code is selected, telete it
            if (indices.Count > 0)
            {
                foreach (int i in indices)
                {
                    SelectedScript.RemoveCodeAtPosition(i);
                    listBoxCurrScript.Items.RemoveAt(i);
                }
                if (listBoxCurrScript.Items.Count == 0)
                {
                    UpdateScripts(SelectedEnemyIndex);
                }
            }
            SetUnsaved(true);
        }

        private void MoveUp()
        {
            if (SelectedCode != null)
            {
                int temp = SelectedCodeIndex;
                loading = true;
                SelectedScript.MoveCodeUp(temp);
                DisplayScript(SelectedEnemyIndex, SelectedScriptIndex);
                listBoxCurrScript.SelectedIndex = temp - 1;
                loading = false;
                SetUnsaved(true);
            }
        }

        private void MoveDown()
        {
            if (SelectedCode != null)
            {
                int temp = SelectedCodeIndex;
                loading = true;
                SelectedScript.MoveCodeDown(temp);
                DisplayScript(SelectedEnemyIndex, SelectedScriptIndex);
                listBoxCurrScript.SelectedIndex = temp + 1;
                loading = false;
                SetUnsaved(true);
            }
        }

        private void EnableOrDisableForm(bool enable)
        {
            processing = !enable;
            comboBoxSceneList.Enabled = enable;
            listBoxEnemies.Enabled = enable;
            listBoxScripts.Enabled = enable;
            listBoxCurrScript.Enabled = enable;
            toolStripScript.Enabled = enable;
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

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            DialogResult result;
            Code newCode;

            using (var codeForm = new CodeForm())
            {
                result = codeForm.ShowDialog();
                newCode = codeForm.Code;
            }

            if (result == DialogResult.OK)
            {
                if (SelectedScript == null)
                {
                    newCode.SetParent(SelectedScript);
                    SelectedEnemy.CreateNewScript(SelectedScriptIndex, newCode);
                    UpdateScripts(SelectedEnemyIndex);
                    listBoxCurrScript.SelectedIndex = 0;
                }
                else
                {
                    int i = SelectedCodeIndex;
                    SelectedScript.InsertCodeAtPosition(i, newCode);
                    ReloadScript(i);
                }
                SetUnsaved(true);
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (SelectedCode != null)
            {
                DialogResult result;
                Code newCode;

                using (var codeForm = new CodeForm(SelectedCode))
                {
                    result = codeForm.ShowDialog();
                    newCode = codeForm.Code;
                }

                if (result == DialogResult.OK)
                {
                    int i = SelectedCodeIndex;
                    newCode.SetParent(SelectedScript);
                    SelectedScript.ReplaceCodeAtPosition(i, newCode);
                    ReloadScript(i);
                    SetUnsaved(true);
                }
            }
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            SetClipboard(true);
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            SetClipboard(false);
        }

        private void toolStripButtonPaste_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonMoveUp_Click(object sender, EventArgs e)
        {
            MoveUp();
        }

        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            MoveDown();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            RemoveSelectedLines();
        }

        private void listBoxCurrScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        SetClipboard(false);
                        break;
                    case Keys.X:
                        SetClipboard(true);
                        break;
                    case Keys.V:
                        //to add
                        break;
                    case Keys.Up:
                        e.SuppressKeyPress = true;
                        MoveUp();
                        break;
                    case Keys.Down:
                        e.SuppressKeyPress = true;
                        MoveDown();
                        break;
                }
            }
            else if (e.Modifiers == Keys.None)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    RemoveSelectedLines();
                }
            }
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
