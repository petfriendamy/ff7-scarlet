using Shojy.FF7.Elena;

namespace FF7Scarlet.KernelEditor
{
    public partial class KernelChunkExportForm : Form
    {
        private CheckBox[] checkBoxes;
        private Kernel kernel;

        public KernelChunkExportForm(Kernel kernel)
        {
            InitializeComponent();
            this.kernel = kernel;
            checkBoxes =
            [
                checkBoxChunk1, checkBoxChunk2, checkBoxChunk3, checkBoxChunk4,
                checkBoxChunk5, checkBoxChunk6, checkBoxChunk7, checkBoxChunk8,
                checkBoxChunk9, checkBoxChunk10, checkBoxChunk11, checkBoxChunk12,
                checkBoxChunk13, checkBoxChunk14, checkBoxChunk15, checkBoxChunk16,
                checkBoxChunk17, checkBoxChunk18, checkBoxChunk19, checkBoxChunk20,
                checkBoxChunk21, checkBoxChunk22, checkBoxChunk23, checkBoxChunk24,
                checkBoxChunk25, checkBoxChunk26, checkBoxChunk27

            ];
        }

        private void KernelChunkExportForm_Load(object sender, EventArgs e)
        {
            if (!DataManager.BothKernelFilePathsExist)
            {
                groupBoxKernel2Chunks.Enabled = false;
            }
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

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            int max = Kernel.SECTION_COUNT;
            if (!DataManager.BothKernelFilePathsExist) { max = Kernel.KERNEL1_END; }
            for (int i = 0; i < max; ++i)
            {
                checkBoxes[i].Checked = true;
            }
        }

        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (var cb in checkBoxes)
            {
                cb.Checked = false;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPath.Text))
            {
                MessageBox.Show("Please choose a directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!Directory.Exists(textBoxPath.Text))
            {
                MessageBox.Show("Directory is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    for (int i = 0; i < Kernel.SECTION_COUNT; ++i)
                    {
                        if (checkBoxes[i].Checked)
                        {
                            string path = textBoxPath.Text + $"\\kernel.bin.chunk.{i + 1}";
                            File.WriteAllBytes(path, kernel.GetSectionRawData((KernelSection)(i + 1), true));
                        }
                    }
                    MessageBox.Show("Chunks exported successfully.", "Done!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Close();
                }
            }
        }
    }
}
