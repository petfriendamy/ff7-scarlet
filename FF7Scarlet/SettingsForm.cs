using System.Configuration;
using FF7Scarlet.SceneEditor;

namespace FF7Scarlet
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            if (DataManager.BattleLgpIsLoaded)
            {
                textBoxBattleLgp.Text = DataManager.BattleLgpPath;
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
            string path = textBoxBattleLgp.Text;
            if (!string.IsNullOrEmpty(path) && path != DataManager.BattleLgpPath)
            {
                DataManager.SetFilePath(FileClass.BattleLgp, path);
                if (DataManager.BattleLgpIsLoaded) //add the path to App.config
                {
                    var config = ConfigurationManager.OpenMappedExeConfiguration(DataManager.ConfigFile,
                        ConfigurationUserLevel.None);
                    var settings = config.AppSettings.Settings;
                    if (settings != null)
                    {
                        if (settings[BattleLgp.CONFIG_KEY] == null)
                        {
                            settings.Add(BattleLgp.CONFIG_KEY, path);
                        }
                        else
                        {
                            settings[BattleLgp.CONFIG_KEY].Value = path;
                        }
                        config.Save();
                    }
                }
                else { return; }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
