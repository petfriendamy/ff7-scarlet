namespace FF7Scarlet
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            DataManager.SetStartupForm(this);
            toolTip1.SetToolTip(groupBoxKernel2, "kernel2 cannot be loaded without kernel.bin.");
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
                toolTip1.RemoveAll();
            }

            if (DataManager.KernelFileIsLoaded)
            {
                buttonKernelEditor.Enabled = true;
            }
            if (DataManager.SceneFileIsLoaded)
            {
                buttonBattleDataEditor.Enabled = true;
                buttonAIEditor.Enabled = true;
            }
        }

        public void EnableFormButton(FormType type)
        {
            switch (type)
            {
                case FormType.KernelEditor:
                    buttonKernelEditor.Enabled = true;
                    break;
                case FormType.BattleDataEditor:
                    buttonBattleDataEditor.Enabled = true;
                    break;
                case FormType.BattleAIEditor:
                    buttonAIEditor.Enabled = true;
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

        private void buttonAIEditor_Click(object sender, EventArgs e)
        {
            DataManager.OpenForm(FormType.BattleAIEditor);
            buttonAIEditor.Enabled = false;
        }
    }
}
