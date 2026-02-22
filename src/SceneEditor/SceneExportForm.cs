using FF7Scarlet.Compression;
using FF7Scarlet.Shared;

#pragma warning disable CA1416
namespace FF7Scarlet.SceneEditor
{
    public partial class SceneExportForm : Form
    {
        private readonly Scene[] scenes;
        private int selectedScene;
        private bool processing = false;

        private bool Processing
        {
            get { return processing; }
            set
            {
                groupBoxExport.Enabled = !value;
                buttonExport.Enabled = !(value && tabControlExportType.SelectedTab != tabPageOther);
                processing = value;
            }
        }

        public SceneExportForm(Scene[] sceneList, int selected, bool jpText)
        {
            InitializeComponent();
            scenes = sceneList;
            selectedScene = selected;

            //scene data
            for (int i = 0; i < Scene.SCENE_COUNT; ++i)
            {
                listBoxSceneList.Items.Add($"{i}: {scenes[i].GetEnemyNames(jpText)}");
            }
            if (selected == -1)
            {
                radioButtonMultiple.Checked = true;
                radioButtonSelected.Enabled = false;
            }
            else
            {
                radioButtonSelected.Checked = true;
                listBoxSceneList.SelectedIndices.Add(selected);
            }

            //chunk data
            if (DataManager.Kernel == null)
            {
                checkBoxCalculateFromLookup.Checked = false;
                checkBoxCalculateFromLookup.Enabled = false;
            }
            else
            {
                UpdateChunkData(0);
            }
        }

        private void radioButtonMultiple_CheckedChanged(object sender, EventArgs e)
        {
            listBoxSceneList.Enabled = radioButtonMultiple.Checked;
            buttonSelectAll.Enabled = radioButtonMultiple.Checked;
            buttonUnselectAll.Enabled = radioButtonMultiple.Checked;
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            listBoxSceneList.SelectedIndices.Clear();
            for (int i = 0; i < Scene.SCENE_COUNT; ++i)
            {
                listBoxSceneList.SelectedIndices.Add(i);
            }
        }

        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {
            listBoxSceneList.SelectedIndices.Clear();
        }

        private void checkBoxCalculateFromLookup_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBoxCalculateFromLookup.Checked;
            labelStartingAt.Enabled = numericStartingAt.Enabled =
                labelNumScenes.Enabled = numericNumScenes.Enabled = !check;
        }

        private void numericChunkID_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxCalculateFromLookup.Checked)
            {
                UpdateChunkData((int)numericChunkID.Value);
            }
        }

        private void UpdateChunkData(int chunk)
        {
            if (DataManager.Kernel != null)
            {
                var lookup = DataManager.Kernel.BattleAndGrowthData.SceneLookupTable;
                int start = lookup[chunk], next = 255, count;
                if (chunk < 63) { next = lookup[chunk + 1]; }
                count = next - start;

                numericStartingAt.Value = start;
                numericNumScenes.Value = count;
            }
        }

        private void tabControlExportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonExport.Enabled = !(tabControlExportType.SelectedTab == tabPageOther);
        }

        private async void buttonExport_Click(object sender, EventArgs e)
        {
            //export scene(s)
            if (tabControlExportType.SelectedTab == tabPageScenes)
            {
                if (listBoxSceneList.SelectedIndices.Count == 0)
                {
                    MessageDialog.ShowError("No scenes selected.");
                }
                else
                {
                    try
                    {
                        DialogResult result;
                        string path;
                        bool success = false;

                        if (radioButtonSelected.Checked) //single scene
                        {
                            using (var save = new SaveFileDialog())
                            {
                                save.FileName = $"scene.{selectedScene}.bin";
                                save.Filter = "Scene file|*.bin";
                                result = save.ShowDialog();
                                path = save.FileName;
                            }

                            if (result == DialogResult.OK)
                            {
                                Processing = true;
                                await ExportScene(selectedScene, path);
                                progressBarSaving.Value = 100;
                                success = true;
                            }
                        }
                        else //multiple scenes
                        {
                            using (var save = new FolderBrowserDialog())
                            {
                                result = save.ShowDialog();
                                path = save.SelectedPath;
                            }

                            if (result == DialogResult.OK)
                            {
                                if (!Directory.Exists(path))
                                {
                                    MessageDialog.ShowError("Invalid path.");
                                }
                                else
                                {
                                    Processing = true;
                                    var selected = new int[listBoxSceneList.SelectedIndices.Count];
                                    for (int i = 0; i < selected.Length; ++i)
                                    {
                                        selected[i] = listBoxSceneList.SelectedIndices[i];
                                    }
                                    success = await ExportMultipleScenes(path, selected);
                                }
                            }
                        }
                        if (success)
                        {
                            MessageBox.Show("Scene(s) exported successfully.", "Done!", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Processing = false;
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex, "exporting scene");
                        progressBarSaving.Value = 0;
                        Processing = false;
                    }
                }
            }
            else //export chunk(s)
            {
                int chunkID = (int)numericChunkID.Value,
                    start = (int)numericStartingAt.Value,
                    count = (int)numericNumScenes.Value;

                if (count == 0)
                {
                    MessageDialog.ShowInfo("Can't export 0 scenes.", "No scenes");
                }
                else
                {
                    DialogResult result;
                    string path;
                    using (var save = new SaveFileDialog())
                    {
                        save.FileName = $"scene.bin.chunk.{chunkID}";
                        save.Filter = "Scene chunk file|scene.bin.chunk.*";
                        result = save.ShowDialog();
                        path = save.FileName;
                    }

                    if (result == DialogResult.OK && Path.Exists(path))
                    {
                        Processing = true;
                        int finalCount = await ExportChunk(scenes, path, start, count);
                        progressBarSaving.Value = 100;
                        if (finalCount < count)
                        {
                            MessageDialog.ShowWarning($"{finalCount} scenes were exported, because compressed {count} scenes were too large.");
                        }
                        else
                        {
                            MessageDialog.ShowInfo("Chunk successfully exported.", "Success");
                        }
                        progressBarSaving.Value = 0;
                        Processing = false;
                        Close();
                    }
                }
            }
        }

        private async void buttonExportSelectedEnemies_Click(object sender, EventArgs e)
        {
            var scene = scenes[selectedScene];
            if (scene.IsEmpty())
            {
                MessageDialog.ShowInfo("Selected scene is empty.", "Scene Empty");
            }
            else
            {
                DialogResult result;
                string path;
                using (var save = new FolderBrowserDialog())
                {
                    result = save.ShowDialog();
                    path = save.SelectedPath;
                }
                if (result == DialogResult.OK && Path.Exists(path))
                {
                    Processing = true;
                    try
                    {
                        await ExportEnemies(scene, path, selectedScene);
                        MessageDialog.ShowInfo("Enemies exported successfully.", "Success");
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.ShowException(ex);
                    }
                    Processing = false;
                }
            }
        }

        private async void buttonExportAllEnemies_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string path;
            using (var save = new FolderBrowserDialog())
            {
                result = save.ShowDialog();
                path = save.SelectedPath;
            }
            if (result == DialogResult.OK && Path.Exists(path))
            {
                Processing = true;
                try
                {
                    for (int i = 0; i < Scene.SCENE_COUNT; ++i)
                    {
                        await ExportEnemies(scenes[i], path, i);
                        progressBarSaving.Value = ((i + 1) / Scene.SCENE_COUNT) * 100;
                    }
                    MessageDialog.ShowInfo("Enemies exported successfully.", "Success");
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowException(ex);
                }
                Processing = false;
            }
        }

        private async void buttonExportSelectedAttacks_Click(object sender, EventArgs e)
        {
            var scene = scenes[selectedScene];
            if (scene.IsEmpty())
            {
                MessageDialog.ShowInfo("Selected scene is empty.", "Scene Empty");
            }
            else
            {
                DialogResult result;
                string path;
                using (var save = new FolderBrowserDialog())
                {
                    result = save.ShowDialog();
                    path = save.SelectedPath;
                }
                if (result == DialogResult.OK && Path.Exists(path))
                {
                    Processing = true;
                    try
                    {
                        await ExportAttacks(scene, path, selectedScene);
                        MessageDialog.ShowInfo("Attacks exported successfully.", "Success");
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.ShowException(ex);
                    }
                    Processing = false;
                }
            }
        }

        private async void buttonExportAllAttacks_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string path;
            using (var save = new FolderBrowserDialog())
            {
                result = save.ShowDialog();
                path = save.SelectedPath;
            }
            if (result == DialogResult.OK && Path.Exists(path))
            {
                Processing = true;
                try
                {
                    for (int i = 0; i < Scene.SCENE_COUNT; ++i)
                    {
                        await ExportAttacks(scenes[i], path, i);
                        progressBarSaving.Value = ((i + 1) / Scene.SCENE_COUNT) * 100;
                    }
                    MessageDialog.ShowInfo("Attacks exported successfully.", "Success");
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowException(ex);
                }
                Processing = false;
            }
        }

        private async void buttonExportSelectedEnemyAI_Click(object sender, EventArgs e)
        {
            var scene = scenes[selectedScene];
            if (scene.IsEmpty())
            {
                MessageDialog.ShowInfo("Selected scene is empty.", "Scene Empty");
            }
            else
            {
                DialogResult result;
                string path;
                using (var save = new SaveFileDialog())
                {
                    save.FileName = $"enemyai.{selectedScene}.bin";
                    save.Filter = "Enemy A.I. chunk|enemyai.*.bin";
                    result = save.ShowDialog();
                    path = save.FileName;
                }
                if (result == DialogResult.OK)
                {
                    Processing = true;
                    try
                    {
                        await ExportEnemyAI(scene, path, selectedScene);
                        MessageDialog.ShowInfo("Enemy A.I. exported successfully.", "Success");
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.ShowException(ex);
                    }
                    Processing = false;
                }
            }
        }

        private async void buttonExportAllEnemyAI_Click(object sender, EventArgs e)
        {
            if (MessageDialog.AskYesNo("This operation may take a while. Are you sure?"))
            {
                DialogResult result;
                string path;
                using (var save = new FolderBrowserDialog())
                {
                    result = save.ShowDialog();
                    path = save.SelectedPath;
                }
                if (result == DialogResult.OK && Path.Exists(path))
                {
                    Processing = true;
                    try
                    {
                        for (int i = 0; i < Scene.SCENE_COUNT; ++i)
                        {
                            string filePath = Path.Combine(path, $"enemyai.{i}.bin");
                            await ExportEnemyAI(scenes[i], filePath, i);
                            progressBarSaving.Value = ((i + 1) / Scene.SCENE_COUNT) * 100;
                        }
                        MessageDialog.ShowInfo("Enemy A.I. exported successfully.", "Success");
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.ShowException(ex);
                    }
                    Processing = false;
                }
            }
        }

        private async Task ExportScene(int scene, string path)
        {
            try
            {
                await Task.Run(() =>
                {
                    var data = scenes[scene].GetRawData();
                    File.WriteAllBytes(path, data);
                });

            }
            catch (AggregateException ex)
            {
                throw new Exception($"An exception was thrown in scene {scene}:\n\n{ex.Message}", ex);
            }
        }

        private async Task<bool> ExportMultipleScenes(string folderPath, int[] selected)
        {
            try
            {
                int index = 0, count = selected.Length;
                for (int i = 0; i < count; ++i)
                {
                    index = selected[i];
                    string filePath = folderPath + $"\\scene.{index}.bin";
                    await ExportScene(index, filePath);
                    progressBarSaving.Value = ((i + 1) / count) * 100;
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex, "ExportMultipleScenes");
            }
            return false;
        }

        private async Task<int> ExportChunk(Scene[] sceneList, string path, int start, int count)
        {
            int result = 0;
            try
            {
                result = await Task.Run(() =>
                {
                    return Gzip.CreateSceneChunk(sceneList, path, start, count, DataManager.CompressionType);
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex, "ExportChunkToFile");
            }
            return result;
        }

        private async Task<bool> ExportEnemies(Scene scene, string folderPath, int sceneID)
        {
            if (Path.Exists(folderPath))
            {
                return await Task.Run(() =>
                {
                    for (int i = 0; i < Scene.ENEMY_COUNT; ++i)
                    {
                        var enemy = scene.Enemies[i];
                        if (enemy != null)
                        {
                            string filePath = Path.Combine(folderPath, $"enemy.{sceneID}.{i}.bin");
                            File.WriteAllBytes(filePath, enemy.GetRawEnemyData(true, true));
                        }
                    }
                    return true;
                });
            }
            return false;
        }

        private async Task<bool> ExportAttacks(Scene scene, string folderPath, int sceneID)
        {
            if (Path.Exists(folderPath))
            {
                return await Task.Run(() =>
                {
                    for (int i = 0; i < Scene.ATTACK_COUNT; ++i)
                    {
                        var attack = scene.AttackList[i];
                        if (attack != null)
                        {
                            string filePath = Path.Combine(folderPath, $"attack.{sceneID}.{i}.bin");
                            using (var fs = new FileStream(filePath, FileMode.Create))
                            using (var writer = new BinaryWriter(fs))
                            {
                                writer.Write((ushort)attack.Index);
                                writer.Write(attack.Name.GetBytes(Scene.NAME_LENGTH, addSpace: true));
                                writer.Write(DataParser.GetAttackBytes(attack));
                            }
                        }
                    }
                    return true;
                });
            }
            return false;
        }

        private async Task<bool> ExportEnemyAI(Scene scene, string filePath, int sceneID)
        {
            return await Task.Run(() =>
            {
                File.WriteAllBytes(filePath, scene.GetEnemyAI());
                return true;
            });
        }

        private void SceneExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = Processing;
        }
    }
}
