using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            DataManager.SetStartupForm(this);
        }

        private void UpdateTextBoxes()
        {
            textBoxKernel.Text = DataManager.KernelPath;
            textBoxKernel2.Text = DataManager.Kernel2Path;
            textBoxScene.Text = DataManager.ScenePath;

            if (DataManager.KernelFilesLoaded())
            {
                buttonKernelEditor.Enabled = true;
                if (DataManager.SceneFileLoaded())
                {
                    buttonBattleDataEditor.Enabled = true;
                    buttonAIEditor.Enabled = true;
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
                case FormType.BattleDataEditor:
                    buttonBattleDataEditor.Enabled = true;
                    break;
                case FormType.BattleAIEditor:
                    buttonAIEditor.Enabled = true;
                    break;
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
            }
        }

        private void buttonAIEditor_Click(object sender, EventArgs e)
        {
            DataManager.OpenForm(FormType.BattleAIEditor);
            buttonAIEditor.Enabled = false;
        }
    }
}
