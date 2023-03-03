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
                        settings[BattleLgp.CONFIG_KEY].Value = string.Empty;
                        config.Save();
                    }
                }
            }
        }

        private void UpdateTextBoxes()
        {
            textBoxKernel.Text = DataManager.KernelPath;
            textBoxKernel2.Text = DataManager.Kernel2Path;
            textBoxScene.Text = DataManager.ScenePath;
            if (!string.IsNullOrEmpty(textBoxKernel.Text))
            {
                textBoxKernel2.Enabled = true;
                buttonKernel2Browse.Enabled = true;
                toolTipHoverText.RemoveAll();
            }

            if (DataManager.KernelFileIsLoaded)
            {
                buttonKernelEditor.Enabled = true;
            }
            if (DataManager.SceneFileIsLoaded)
            {
                buttonBattleDataEditor.Enabled = true;
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
                    buttonBattleDataEditor.Enabled = true;
                    break;
            }
        }

        private void CheckLookupTable()
        {
            //check lookup table
            if (DataManager.KernelFileIsLoaded && DataManager.SceneFileIsLoaded)
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

        private void buttonKernelBrowse_Click(object sender, EventArgs e)
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

        private void buttonKernel2Browse_Click(object sender, EventArgs e)
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

        private void buttonSceneBrowse_Click(object sender, EventArgs e)
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

        private void buttonKernelEditor_Click(object sender, EventArgs e)
        {
            DataManager.OpenForm(FormType.KernelEditor);
            buttonKernelEditor.Enabled = false;
        }

        private void buttonBattleDataEditor_Click(object sender, EventArgs e)
        {
            DataManager.OpenForm(FormType.SceneEditor);
            buttonBattleDataEditor.Enabled = false;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();
            settings.ShowDialog();
        }
    }
}
