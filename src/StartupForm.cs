using AutoUpdaterDotNET;
using FF7Scarlet.ExeEditor;
using FF7Scarlet.KernelEditor;
using FF7Scarlet.SceneEditor;
using Newtonsoft.Json.Linq;
using SharpDX.DirectSound;
using FF7Scarlet.Shared;
using System.Configuration;
using System.Xml;

namespace FF7Scarlet
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            this.Text = $"{Application.ProductName} v{Application.ProductVersion} - Main Menu";

            DataManager.SetStartupForm(this);
            toolTipHoverText.SetToolTip(groupBoxKernel2, "kernel2 cannot be loaded without kernel.bin.");

            //get Scarlet.config settings
            string filePath = AppContext.BaseDirectory + @"\Scarlet.config";
            if (!File.Exists(filePath))
            {
                var set = new XmlWriterSettings();
                set.Indent = true;
                set.NewLineOnAttributes = true;
                using (var cfg = XmlWriter.Create(filePath, set))
                {
                    cfg.WriteStartDocument();
                    cfg.WriteStartElement("configuration");
                    cfg.WriteStartElement("appSettings");
                    cfg.WriteEndElement();
                    cfg.WriteEndElement();
                }
            }
            DataManager.ConfigFile.ExeConfigFilename = filePath;
            var config = ConfigurationManager.OpenMappedExeConfiguration(DataManager.ConfigFile,
                ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;
            if (settings != null)
            {
                //check for updates
                if (settings[ScarletUpdater.UPDATE_ON_STARTUP_KEY] == null)
                {
                    settings.Add(ScarletUpdater.UPDATE_ON_STARTUP_KEY, $"{ScarletUpdater.UpdateOnStartup}");
                }
                else
                {
                    bool temp;
                    if (bool.TryParse(settings[ScarletUpdater.UPDATE_ON_STARTUP_KEY].Value, out temp))
                    {
                        ScarletUpdater.UpdateOnStartup = temp;
                    }
                }
                if (settings[ScarletUpdater.UPDATE_CHANNEL_KEY] == null)
                {
                    settings.Add(ScarletUpdater.UPDATE_CHANNEL_KEY, Enum.GetName(ScarletUpdater.UpdateChannel));
                }
                else
                {
                    UpdateChannel temp;
                    if (Enum.TryParse(settings[ScarletUpdater.UPDATE_CHANNEL_KEY].Value, out temp))
                    {
                        ScarletUpdater.UpdateChannel = temp;
                    }
                }
                if (ScarletUpdater.UpdateOnStartup)
                {
                    ScarletUpdater.CheckForUpdates(ScarletUpdater.UpdateChannel);
                }

                //check previously loaded files
                if (settings[DataManager.REMEMBER_LAST_OPENED_KEY] == null)
                {
                    settings.Add(DataManager.REMEMBER_LAST_OPENED_KEY, $"{DataManager.RememberLastOpened}");
                }
                else
                {
                    bool temp;
                    if (bool.TryParse(settings[DataManager.REMEMBER_LAST_OPENED_KEY].Value, out temp))
                    {
                        DataManager.RememberLastOpened = temp;
                    }
                }
                if (DataManager.RememberLastOpened)
                {
                    LoadFromConfig(config, FileClass.Exe);
                    LoadFromConfig(config, FileClass.Kernel);
                    LoadFromConfig(config, FileClass.Kernel2);
                    LoadFromConfig(config, FileClass.Scene);
                    UpdateTextBoxes(false);
                }

                //check vanilla EXE
                if (settings[ExeData.VANILLA_CONFIG_KEY] != null)
                {
                    LoadFromConfig(config, FileClass.VanillaExe);
                }

                //check battle.lgp
                if (settings[BattleLgp.CONFIG_KEY] != null)
                {
                    LoadFromConfig(config, FileClass.BattleLgp);
                }

                //check PS3 tweaks
                if (settings[DataManager.PS3_TWEAKS_KEY] != null)
                {
                    bool temp;
                    if (bool.TryParse(settings[DataManager.PS3_TWEAKS_KEY].Value, out temp))
                    {
                        DataManager.PS3TweaksEnabled = temp;
                    }
                }
            }
        }

        private static void LoadFromConfig(Configuration config, FileClass fileClass)
        {
            var settings = config.AppSettings.Settings;
            if (settings != null)
            {
                string configKey = string.Empty;
                switch (fileClass)
                {
                    case FileClass.Exe:
                        configKey = ExeData.CONFIG_KEY;
                        break;
                    case FileClass.VanillaExe:
                        configKey = ExeData.VANILLA_CONFIG_KEY;
                        break;
                    case FileClass.Kernel:
                        configKey = Kernel.KERNEL_CONFIG_KEY;
                        break;
                    case FileClass.Kernel2:
                        configKey = Kernel.KERNEL2_CONFIG_KEY;
                        break;
                    case FileClass.Scene:
                        configKey = Scene.CONFIG_KEY;
                        break;
                    case FileClass.BattleLgp:
                        configKey = BattleLgp.CONFIG_KEY;
                        break;
                }
                string path = string.Empty;
                if (settings[configKey] != null)
                {
                    path = settings[configKey].Value;
                }
                try
                {
                    if (!string.IsNullOrEmpty(path))
                    {
                        DataManager.SetFilePath(fileClass, path, true);
                    }
                }
                catch //if the file can't be loaded, remove it from settings
                {
                    MessageBox.Show($"The file at '{path}' could not be loaded, and has been removed from settings.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    settings[configKey].Value = string.Empty;
                    config.Save();
                }
            }
        }

        private void UpdateTextBoxes(bool updateSettings)
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
            buttonSceneEditor.Enabled = DataManager.SceneFilePathExists;
            buttonExeEditor.Enabled = DataManager.ExePathExists;

            if (DataManager.RememberLastOpened && updateSettings)
            {
                //get Scarlet.config settings
                DataManager.ConfigFile.ExeConfigFilename = AppContext.BaseDirectory + @"\Scarlet.config";
                var config = ConfigurationManager.OpenMappedExeConfiguration(DataManager.ConfigFile,
                    ConfigurationUserLevel.None);
                var settings = config.AppSettings.Settings;
                if (settings != null)
                {
                    //exe
                    if (settings[ExeData.CONFIG_KEY] == null)
                    {
                        settings.Add(ExeData.CONFIG_KEY, DataManager.ExePath);
                    }
                    else
                    {
                        settings[ExeData.CONFIG_KEY].Value = DataManager.ExePath;
                    }

                    //kernel
                    if (settings[Kernel.KERNEL_CONFIG_KEY] == null)
                    {
                        settings.Add(Kernel.KERNEL_CONFIG_KEY, DataManager.KernelPath);
                    }
                    else
                    {
                        settings[Kernel.KERNEL_CONFIG_KEY].Value = DataManager.KernelPath;
                    }

                    //kernel2
                    if (settings[Kernel.KERNEL2_CONFIG_KEY] == null)
                    {
                        settings.Add(Kernel.KERNEL2_CONFIG_KEY, DataManager.Kernel2Path);
                    }
                    else
                    {
                        settings[Kernel.KERNEL2_CONFIG_KEY].Value = DataManager.Kernel2Path;
                    }

                    //scene
                    if (settings[Scene.CONFIG_KEY] == null)
                    {
                        settings.Add(Scene.CONFIG_KEY, DataManager.ScenePath);
                    }
                    else
                    {
                        settings[Scene.CONFIG_KEY].Value = DataManager.ScenePath;
                    }

                    config.Save();
                }
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
                    DataManager.SetFilePath(FileClass.Exe, file);
                    UpdateTextBoxes(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    UpdateTextBoxes(true);
                    CheckLookupTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    UpdateTextBoxes(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    UpdateTextBoxes(true);
                    CheckLookupTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region AutoUpdate functionality

        public enum AppUpdateChannelOptions
        {
            Stable = 0,
            Canary
        }

        private string GetUpdateVersion(string name)
        {
            return name.Replace("FF7Scarlet-v", "");
        }

        private string GetUpdateReleaseUrl(dynamic assets)
        {
            foreach (dynamic asset in assets)
            {
                string url = asset.browser_download_url.Value;

                if (url.Contains("FF7Scarlet-v") && url.EndsWith(".zip"))
                    return url;
            }

            return String.Empty;
        }

        private string GetUpdateChannel(AppUpdateChannelOptions channel)
        {
            switch (channel)
            {
                case AppUpdateChannelOptions.Stable:
                    return "https://github.com/petfriendamy/ff7-scarlet/releases/latest";
                case AppUpdateChannelOptions.Canary:
                    return "https://github.com/petfriendamy/ff7-scarlet/releases/tags/canary";
                default:
                    return "";
            }
        }

        private void AutoUpdaterOnParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
        {
            dynamic release = JValue.Parse(args.RemoteData);

            args.UpdateInfo = new UpdateInfoEventArgs
            {
                CurrentVersion = (new Version(GetUpdateVersion(release.name.Value))).ToString(),
                DownloadURL = GetUpdateReleaseUrl(release.assets),
                ChangelogURL = "https://github.com/petfriendamy/ff7-scarlet/releases/latest"
            };
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            AutoUpdater.HttpUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0";
            AutoUpdater.ParseUpdateInfoEvent += AutoUpdaterOnParseUpdateInfoEvent;

            // Detect which version we are running and propose to auto-update based on the user downloaded channel
            FileVersionInfo appVersion = FileVersionInfo.GetVersionInfo(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            if (appVersion.FilePrivatePart > 0 || appVersion.ProductPrivatePart > 0)
                AutoUpdater.Start(GetUpdateChannel(AppUpdateChannelOptions.Canary));
            else
                AutoUpdater.Start(GetUpdateChannel(AppUpdateChannelOptions.Stable));
        }

        #endregion
    }
}
