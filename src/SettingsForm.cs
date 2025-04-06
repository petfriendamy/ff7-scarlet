using System.Configuration;
using System.IO;
using AutoUpdaterDotNET;
using FF7Scarlet.ExeEditor;
using FF7Scarlet.SceneEditor;
using FF7Scarlet.Shared;

namespace FF7Scarlet
{
    public partial class SettingsForm : Form
    {
        private static readonly string[] channelDescriptions =
        {
            "The most tested version with fewest updates. Least likely to cause issues.",
            "The latest and greatest features, but may be unstable. Use at your own risk!"
        };

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
            comboBoxUpdateChannel.SelectedIndex = (int)ScarletUpdater.UpdateChannel;
            checkBoxUpdateOnLaunch.Checked = ScarletUpdater.UpdateOnStartup;
            checkBoxRemeberLastOpened.Checked = DataManager.RememberLastOpened;
            checkBoxPS3Tweaks.Checked = DataManager.PS3TweaksEnabled;

            AutoUpdater.ParseUpdateInfoEvent += GotUpdate;
        }

        private void comboBoxUpdateChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBoxUpdateChannel.SelectedIndex;
            labelUpdateChannelDesc.Text = channelDescriptions[i];
        }

        private void buttonCheckForUpdates_Click(object sender, EventArgs e)
        {
            var channel = (UpdateChannel)comboBoxUpdateChannel.SelectedIndex;
            ScarletUpdater.CheckForUpdates(channel);
            buttonCheckForUpdates.Enabled = false;
            buttonCheckForUpdates.Text = "Checking...";
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
                    DataManager.SetFilePath(FileClass.VanillaExe, vanillaExePath);
                    if (DataManager.VanillaExePathExists) //add the path to the App.config
                    {
                        UpdateSetting(ref settings, ExeData.VANILLA_CONFIG_KEY, vanillaExePath);
                    }
                }

                //check battle.lgp
                if (!string.IsNullOrEmpty(battleLgpPath) && battleLgpPath != DataManager.BattleLgpPath)
                {
                    DataManager.SetFilePath(FileClass.BattleLgp, battleLgpPath);
                    if (DataManager.BattleLgpPathExists) //add the path to App.config
                    {
                        UpdateSetting(ref settings, BattleLgp.CONFIG_KEY, battleLgpPath);
                    }
                }

                //set update channel
                ScarletUpdater.UpdateChannel = (UpdateChannel)comboBoxUpdateChannel.SelectedIndex;
                UpdateSetting(ref settings, ScarletUpdater.UPDATE_CHANNEL_KEY, Enum.GetName(ScarletUpdater.UpdateChannel));

                //enable/disable update on startup
                ScarletUpdater.UpdateOnStartup = checkBoxUpdateOnLaunch.Checked;
                UpdateSetting(ref settings, ScarletUpdater.UPDATE_ON_STARTUP_KEY, $"{ScarletUpdater.UpdateOnStartup}");

                //enable/disable remembering previously opened files
                DataManager.RememberLastOpened = checkBoxRemeberLastOpened.Checked;
                UpdateSetting(ref settings, DataManager.REMEMBER_LAST_OPENED_KEY, $"{DataManager.RememberLastOpened}");

                //enable/disable PS3 tweaks
                DataManager.PS3TweaksEnabled = checkBoxPS3Tweaks.Checked;
                UpdateSetting(ref settings, DataManager.PS3_TWEAKS_KEY, $"{DataManager.PS3TweaksEnabled}");

                config.Save();

            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateSetting(ref KeyValueConfigurationCollection settings, string key, string? value)
        {
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
        }

        private void GotUpdate(ParseUpdateInfoEventArgs args)
        {
            buttonCheckForUpdates.Enabled = true;
        }
    }
}
