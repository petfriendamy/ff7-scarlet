using FF7Scarlet.ExeEditor;
using FF7Scarlet.SceneEditor;
using System.Configuration;

namespace FF7Scarlet
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            DataManager.SetStartupForm(this);
            toolTipHoverText.SetToolTip(groupBoxKernel2, "kernel2 cannot be loaded without kernel.bin.");

            //get Scarlet.config settings
            DataManager.ConfigFile.ExeConfigFilename = AppContext.BaseDirectory + @"\Scarlet.config";
            var config = ConfigurationManager.OpenMappedExeConfiguration(DataManager.ConfigFile,
                ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;
            if (settings != null)
            {
                //check ff7.exe
                if (settings[ExeData.CONFIG_KEY] != null)
                {
                    string path = settings[ExeData.CONFIG_KEY].Value;
                    try
                    {
                        if (!string.IsNullOrEmpty(path))
                        {
                            DataManager.SetFilePath(FileClass.EXE, path, true);
                        }
                    }
                    catch //if the file can't be loaded, remove it from settings
                    {
                        MessageBox.Show($"The file at '{path}' could not be loaded, and has been removed from settings.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        settings[ExeData.CONFIG_KEY].Value = string.Empty;
                        config.Save();
                    }
                }

                //check battle.lgp
                if (settings[BattleLgp.CONFIG_KEY] != null)
                {
                    string path = settings[BattleLgp.CONFIG_KEY].Value;
                    try
                    {
                        if (!string.IsNullOrEmpty(path))
                        {
                            DataManager.SetFilePath(FileClass.BattleLgp, path);
                        }
                    }
                    catch //if the file can't be loaded, remove it from settings
                    {
                        MessageBox.Show($"The file at '{path}' could not be loaded, and has been removed from settings.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        settings[BattleLgp.CONFIG_KEY].Value = string.Empty;
                        config.Save();
                    }
                }
            }
        }

        private void UpdateTextBoxes()
        {
            textBoxEXE.Text = DataManager.ExePath;
            textBoxKernel.Text = DataManager.KernelPath;
            textBoxKernel2.Text = DataManager.Kernel2Path;
            textBoxScene.Text = DataManager.ScenePath;
            if (DataManager.KernelFilePathExists)
            {
                buttonKernelEditor.Enabled = true;
                textBoxKernel2.Enabled = true;
                buttonKernel2Browse.Enabled = true;
                toolTipHoverText.RemoveAll();
            }
            if (DataManager.SceneFilePathExists)
            {
                buttonSceneEditor.Enabled = true;
            }
            if (DataManager.ExePathExists)
            {
                buttonExeEditor.Enabled = true;
            }
        }

        public void EnableFormButton(FormType type)
        {
            switch (type)
            {
                case FormType.KernelEditor:
                    buttonKernelEditor.Enabled = true;
                    break;
                case FormType.SceneEditor:
                    buttonSceneEditor.Enabled = true;
                    break;
                case FormType.ExeEditor:
                    buttonExeEditor.Enabled = true;
                    break;
            }
        }

        private void CheckLookupTable()
        {
            //check lookup table
            if (DataManager.KernelFilePathExists && DataManager.SceneFilePathExists)
            {
                if (!DataManager.LookupTableIsCorrect())
                {
                    var result = MessageBox.Show("The scene lookup table does not match between scene.bin and kernel.bin. Would you like to correct it now?",
                        "Incorrect Lookup Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataManager.SyncLookupTable();
                    }
                }
            }
        }

        private void buttonEXEbrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                string file;
                using (var loadFile = new OpenFileDialog())
                {
                    loadFile.Filter = "Final Fantasy VII executable|ff7_en.exe;ff7_es.exe;ff7_fr.exe;ff7_de.exe;ff7.exe";
                    result = loadFile.ShowDialog();
                    file = loadFile.FileName;
                }
                if (result == DialogResult.OK)
                {
                    DataManager.SetFilePath(FileClass.EXE, file);
                    UpdateTextBoxes();
                }
            }
            catch (FileFormatException ex)
            {
                MessageBox.Show($"An error occurred while reading {ex.Message}.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonKernelBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                string file;
                using (var loadFile = new OpenFileDialog())
                {
                    loadFile.Filter = "kernel.bin|kernel.bin";
                    result = loadFile.ShowDialog();
                    file = loadFile.FileName;
                }
                if (result == DialogResult.OK)
                {
                    DataManager.SetFilePath(FileClass.Kernel, file);
                    UpdateTextBoxes();
                    CheckLookupTable();
                }
            }
            catch (FileFormatException ex)
            {
                MessageBox.Show($"An error occurred while reading {ex.Message}.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonKernel2Browse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                string file;
                using (var loadFile = new OpenFileDialog())
                {
                    loadFile.Filter = "kernel2.bin|kernel2.bin";
                    result = loadFile.ShowDialog();
                    file = loadFile.FileName;
                }
                if (result == DialogResult.OK)
                {
                    DataManager.SetFilePath(FileClass.Kernel2, file);
                    UpdateTextBoxes();
                }
            }
            catch (FileFormatException ex)
            {
                MessageBox.Show($"An error occurred while reading {ex.Message}.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSceneBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                string file;
                using (var loadFile = new OpenFileDialog())
                {
                    loadFile.Filter = "scene.bin|scene.bin";
                    result = loadFile.ShowDialog();
                    file = loadFile.FileName;
                }
                if (result == DialogResult.OK)
                {
                    DataManager.SetFilePath(FileClass.Scene, file);
                    UpdateTextBoxes();
                    CheckLookupTable();
                }
            }
            catch (FileFormatException ex)
            {
                MessageBox.Show($"An error occurred while reading {ex.Message}.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonKernelEditor_Click(object sender, EventArgs e)
        {
            DataManager.OpenForm(FormType.KernelEditor);
            buttonKernelEditor.Enabled = false;
        }

        private void buttonSceneEditor_Click(object sender, EventArgs e)
        {
            DataManager.OpenForm(FormType.SceneEditor);
            buttonSceneEditor.Enabled = false;
        }

        private void buttonEXEeditor_Click(object sender, EventArgs e)
        {
            DataManager.OpenForm(FormType.ExeEditor);
            buttonExeEditor.Enabled = false;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();
            settings.ShowDialog();
        }
    }
}
