using Shojy.FF7.Elena;
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
    public partial class KernelChunkExportForm : Form
    {
        private CheckBox[] checkBoxes;
        private Kernel kernel;

        public KernelChunkExportForm(Kernel kernel)
        {
            InitializeComponent();
            this.kernel = kernel;
        }

        private void KernelChunkExportForm_Load(object sender, EventArgs e)
        {
            checkBoxes = new CheckBox[9]
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7,
                checkBox8, checkBox9
            };
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            //get file path
            DialogResult result;
            string path;
            using (var exportDialog = new FolderBrowserDialog())
            {
                result = exportDialog.ShowDialog();
                path = exportDialog.SelectedPath;
            }

            if (result == DialogResult.OK)
            {
                textBoxPath.Text = path;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBoxPath.Text))
            {
                MessageBox.Show("Directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool test = false;
                foreach (var cb in checkBoxes)
                {
                    if (cb.Checked) { test = true; }
                }
                if (!test)
                {
                    MessageBox.Show("No chunks selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else //output the files
                {
                    for (int i = 0; i < 9; ++i)
                    {
                        if (checkBoxes[i].Checked)
                        {
                            string path = textBoxPath.Text + $"\\kernel.bin.chunk.{i + 1}";
                            File.WriteAllBytes(path, kernel.GetSectionRawData((KernelSection)(i + 1)));
                        }
                    }
                    MessageBox.Show("Done!");
                    Close();
                }
            }
        }
    }
}
