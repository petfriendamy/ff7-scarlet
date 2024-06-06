using System.Configuration;
using System.IO;
using FF7Scarlet.ExeEditor;
using FF7Scarlet.SceneEditor;

namespace FF7Scarlet
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            if (DataManager.VanillaExePathExists)
            {
                textBoxVanillaExe.Text = DataManager.VanillaExePath;
            }
            if (DataManager.BattleLgpPathExists)
            {
                textBoxBattleLgp.Text = DataManager.BattleLgpPath;
            }
            checkBoxPS3Tweaks.Checked = DataManager.PS3TweaksEnabled;
        }

        private void buttonVanillaExeBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string path;
            using (var loadFile = new OpenFileDialog())
            {
                loadFile.Filter = "Final Fantasy VII executable|ff7_en.exe;ff7.exe;ff7_en.exe.bak;ff7.exe.bak";
                result = loadFile.ShowDialog();
                path = loadFile.FileName;
            }
            if (result == DialogResult.OK)
            {
                if (File.Exists(path))
                {
                    if (ExeData.ValidateEXE(path, true))
                    {
                        textBoxVanillaExe.Text = path;
                    }
                    else
                    {
                        MessageBox.Show("This doesn't seem to be a valid EXE. Please provide an unmodified English EXE.",
                            "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("File not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBattleLgpBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string path;
            using (var open = new OpenFileDialog())
            {
                open.Filter = "battle.lgp|battle.lgp";
                result = open.ShowDialog();
                path = open.FileName;
            }

            if (result == DialogResult.OK)
            {
                if (File.Exists(path))
                {
                    textBoxBattleLgp.Text = path;
                }
                else
                {
                    MessageBox.Show("File not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string vanillaExePath = textBoxVanillaExe.Text,
                battleLgpPath = textBoxBattleLgp.Text;
            var config = ConfigurationManager.OpenMappedExeConfiguration(DataManager.ConfigFile,
                        ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;

            if (settings == null) //failed to load config file
            {
                MessageBox.Show("Config file could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //check EXE
                if (!string.IsNullOrEmpty(vanillaExePath) && vanillaExePath != DataManager.VanillaExePath)
                {
                    DataManager.SetFilePath(FileClass.EXE, vanillaExePath, true);
                    if (DataManager.VanillaExePathExists) //add the path to the App.config
                    {
                        if (settings[ExeData.CONFIG_KEY] == null)
                        {
                            settings.Add(ExeData.CONFIG_KEY, vanillaExePath);
                        }
                        else
                        {
                            settings[ExeData.CONFIG_KEY].Value = vanillaExePath;
                        }
                    }
                }

                //check battle.lgp
                if (!string.IsNullOrEmpty(battleLgpPath) && battleLgpPath != DataManager.BattleLgpPath)
                {
                    DataManager.SetFilePath(FileClass.BattleLgp, battleLgpPath);
                    if (DataManager.BattleLgpPathExists) //add the path to App.config
                    {
                        if (settings[BattleLgp.CONFIG_KEY] == null)
                        {
                            settings.Add(BattleLgp.CONFIG_KEY, battleLgpPath);
                        }
                        else
                        {
                            settings[BattleLgp.CONFIG_KEY].Value = battleLgpPath;
                        }
                    }
                }

                //enable/disable PS3 tweaks
                DataManager.PS3TweaksEnabled = checkBoxPS3Tweaks.Checked;
                if (settings[DataManager.PS3_TWEAKS_KEY] == null)
                {
                    settings.Add(DataManager.PS3_TWEAKS_KEY, $"{DataManager.PS3TweaksEnabled}");
                }
                else
                {
                    settings[DataManager.PS3_TWEAKS_KEY].Value = $"{DataManager.PS3TweaksEnabled}";
                }
                config.Save();

            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
