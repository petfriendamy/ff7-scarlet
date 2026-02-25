using System.Configuration;
using FF7Scarlet.Compression;
using FF7Scarlet.ExeEditor;
using FF7Scarlet.SceneEditor;
using FF7Scarlet.Shared;

#pragma warning disable CA1416
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
            comboBoxUpdateChannel.SelectedIndex = (int)DataManager.Updater.UpdateChannel;
            checkBoxUpdateOnLaunch.Checked = DataManager.Updater.UpdateOnStartup;
            checkBoxRemeberLastOpened.Checked = DataManager.RememberLastOpened;
            comboBoxCompression.SelectedIndex = (int)DataManager.CompressionType;
            checkBoxPS3Tweaks.Checked = DataManager.PS3TweaksEnabled;
        }

        private void comboBoxUpdateChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBoxUpdateChannel.SelectedIndex;
            labelUpdateChannelDesc.Text = channelDescriptions[i];
        }

        private void buttonCheckForUpdates_Click(object sender, EventArgs e)
        {
            DataManager.Updater.UpdateChannel = (UpdateChannel)comboBoxUpdateChannel.SelectedIndex;
            DataManager.Updater.CheckForUpdates(true);
            comboBoxUpdateChannel.Enabled = buttonCheckForUpdates.Enabled = false;
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
                    int isValid = ExeData.ValidateEXE(path, true);
                    switch (isValid)
                    {
                        case 1:
                            textBoxVanillaExe.Text = path;
                            break;

                        case 2: //unsupported
                            MessageDialog.ShowError("This EXE is unsupported.");
                            break;

                        case 3: //2026 version
                            var newPath = ExeData.Get2026EXEPath(path);
                            if (!string.IsNullOrEmpty(newPath) && File.Exists(newPath))
                            {

                            }
                            else
                            {
                                MessageDialog.ShowError("This EXE is unsupported. Could not locate a valid EXE.");
                            }
                            break;

                        default:
                            MessageDialog.ShowError("This doesn't seem to be a valid EXE. Please provide an unmodified English EXE.");
                            break;
                    }
                }
                else
                {
                    MessageDialog.ShowError("File not found.");
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
                    MessageDialog.ShowError("File not found.");
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                string vanillaExePath = textBoxVanillaExe.Text,
                battleLgpPath = textBoxBattleLgp.Text;
                var config = ConfigurationManager.OpenMappedExeConfiguration(DataManager.ConfigFile,
                            ConfigurationUserLevel.None);
                var settings = config.AppSettings.Settings;

                if (settings == null) //failed to load config file
                {
                    MessageDialog.ShowError("Config file could not be loaded.");
                }
                else
                {
                    //check EXE
                    if (!string.IsNullOrEmpty(vanillaExePath))
                    {
                        if (vanillaExePath != DataManager.VanillaExePath)
                        {
                            DataManager.SetFilePath(FileClass.VanillaExe, vanillaExePath);
                            if (DataManager.VanillaExePathExists) //add the path to the App.config
                            {
                                UpdateSetting(ref settings, ExeData.VANILLA_CONFIG_KEY, vanillaExePath);
                            }
                        }
                    }
                    else if (DataManager.VanillaExePathExists)
                    {
                        var result = MessageDialog.AskYesNoCancel("Invalid EXE path. Keep existing path?", "Invalid Path");

                        switch (result)
                        {
                            case DialogResult.Cancel:
                                return;

                            case DialogResult.No:
                                DataManager.ClearFilePath(FileClass.VanillaExe);
                                UpdateSetting(ref settings, ExeData.VANILLA_CONFIG_KEY, string.Empty);
                                break;
                        }
                    }

                    //check battle.lgp
                    if (!string.IsNullOrEmpty(battleLgpPath))
                    {
                        if (battleLgpPath != DataManager.BattleLgpPath)
                        {
                            DataManager.SetFilePath(FileClass.BattleLgp, battleLgpPath);
                            if (DataManager.BattleLgpPathExists) //add the path to App.config
                            {
                                UpdateSetting(ref settings, BattleLgp.CONFIG_KEY, battleLgpPath);
                            }
                        }

                    }
                    else if (DataManager.BattleLgpPathExists)
                    {
                        var result = MessageDialog.AskYesNoCancel("Invalid battle.lgp path. Keep existing path?", "Invalid Path");

                        switch (result)
                        {
                            case DialogResult.Cancel:
                                return;

                            case DialogResult.No:
                                DataManager.ClearFilePath(FileClass.BattleLgp);
                                UpdateSetting(ref settings, BattleLgp.CONFIG_KEY, string.Empty);
                                break;
                        }
                    }

                    //set update channel
                    DataManager.Updater.UpdateChannel = (UpdateChannel)comboBoxUpdateChannel.SelectedIndex;
                    UpdateSetting(ref settings, ScarletUpdater.UPDATE_CHANNEL_KEY, Enum.GetName(DataManager.Updater.UpdateChannel));

                    //enable/disable update on startup
                    DataManager.Updater.UpdateOnStartup = checkBoxUpdateOnLaunch.Checked;
                    UpdateSetting(ref settings, ScarletUpdater.UPDATE_ON_STARTUP_KEY, $"{DataManager.Updater.UpdateOnStartup}");

                    //enable/disable remembering previously opened files
                    DataManager.RememberLastOpened = checkBoxRemeberLastOpened.Checked;
                    UpdateSetting(ref settings, DataManager.REMEMBER_LAST_OPENED_KEY, $"{DataManager.RememberLastOpened}");

                    //set compression type
                    DataManager.CompressionType = (CompressionType)comboBoxCompression.SelectedIndex;
                    UpdateSetting(ref settings, DataManager.COMPRESSION_TYPE_KEY, Enum.GetName(DataManager.CompressionType));

                    //enable/disable PS3 tweaks
                    DataManager.PS3TweaksEnabled = checkBoxPS3Tweaks.Checked;
                    UpdateSetting(ref settings, DataManager.PS3_TWEAKS_KEY, $"{DataManager.PS3TweaksEnabled}");

                    config.Save();

                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex, "SettingsForm SaveSettings");
            }
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
    }
}
