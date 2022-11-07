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
        public KernelForm()
        {
            InitializeComponent();
        }

        private void KernelForm_Load(object sender, EventArgs e)
        {
            foreach (var w in DataManager.KernelReader.WeaponData.Weapons)
            {
                textBox1.AppendText(w.Name + Environment.NewLine);
            }
        }

        private void KernelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataManager.CloseForm(FormType.KernelEditor);
        }
    }
}
