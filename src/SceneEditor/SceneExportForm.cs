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
                                groupBoxExport.Enabled = false;
                                buttonExport.Enabled = false;
                                processing = true;
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
                                    groupBoxExport.Enabled = false;
                                    buttonExport.Enabled = false;
                                    processing = true;
                                    var selected = new int[listBoxSceneList.SelectedIndices.Count];
                                    for (int i = 0; i < selected.Length; ++i)
                                    {
                                        selected[i] = listBoxSceneList.SelectedIndices[i];
                                    }
                                    success = await ExportMulti(path, selected);
                                }
                            }
                        }
                        if (success)
                        {
                            MessageBox.Show("Scene(s) exported successfully.", "Done!", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            processing = false;
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex, "exporting scene");
                        groupBoxExport.Enabled = true;
                        buttonExport.Enabled = true;
                        progressBarSaving.Value = 0;
                        processing = false;
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

                    if (result == DialogResult.OK)
                    {
                        processing = true;
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
                        processing = false;
                        Close();
                    }
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

        private async Task<bool> ExportMulti(string folderPath, int[] selected)
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
                ExceptionHandler.Handle(ex, "ExportChunk");
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

        private void SceneExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processing) { e.Cancel = true; }
        }
    }
}
