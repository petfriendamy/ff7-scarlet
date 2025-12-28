using FF7Scarlet.Compression;
using FF7Scarlet.SceneEditor.Controls;
using FF7Scarlet.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet.SceneEditor
{
    public partial class SceneImportForm : Form
    {
        private readonly Scene[] scenes;
        private readonly SceneImportControl[] importList;
        public Dictionary<int, Scene> ImportScenes { get; private set; } = new();

        public SceneImportForm(string filePath)
        {
            InitializeComponent();
            scenes = Gzip.GetDecompressedSceneChunk(filePath);
            string name = Path.GetFileName(filePath);

            //get the assumed starting position of this chunk
            int chunk, start = 0;
            if (int.TryParse(name.Substring(name.LastIndexOf('.') + 1), out chunk))
            {
                start = DataManager.GetChunkStart(chunk);
            }

            //load the imported scenes as a list
            importList = new SceneImportControl[scenes.Length];
            labelResults.Text = $"The following scenes were found in {name}:";
            int y = 3;
            for (int i = 0; i < scenes.Length; ++i)
            {
                importList[i] = new SceneImportControl(scenes[i].GetEnemyNames(), i + start);
                importList[i].Location = new Point(3, y);
                importList[i].Size = new Size(416, 30);
                y += 33;
                panelSceneList.Controls.Add(importList[i]);
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            ImportScenes.Clear();
            for (int i = 0; i < scenes.Length; ++i)
            {
                if (importList[i].Checked)
                {
                    if (ImportScenes.ContainsKey(importList[i].ImportAt))
                    {
                        MessageBox.Show("Can't import two scenes at the same location.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ImportScenes.Add(importList[i].ImportAt, scenes[i]);
                    }
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
