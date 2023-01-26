using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet
{
    public partial class KernelForm : Form
    {
        private Kernel kernel;
        private bool unsavedChanges = false;

        public KernelForm()
        {
            InitializeComponent();
        }

        private void KernelForm_Load(object sender, EventArgs e)
        {
            //create private version of kernel data that can be edited freely
            kernel = new Kernel(DataManager.KernelPath);
            if (DataManager.BothKernelFilesLoaded)
            {
                kernel.MergeKernel2Data(DataManager.Kernel2Path);
            }
        }

        private void KernelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataManager.CloseForm(FormType.KernelEditor);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DataManager.CreateKernel(true);
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            using (var exportDialog = new KernelChunkExportForm(kernel))
            {
                exportDialog.ShowDialog();
            }
        }
    }
}
