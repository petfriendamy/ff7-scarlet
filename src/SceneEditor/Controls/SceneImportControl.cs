using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet.SceneEditor.Controls
{
    public partial class SceneImportControl : UserControl
    {
        public bool Checked
        {
            get { return checkBoxImport.Checked; }
        }
        public int ImportAt
        {
            get { return (int)numericImportAs.Value; }
        }

        public SceneImportControl(string text, int pos)
        {
            InitializeComponent();
            labelText.Text = text;
            numericImportAs.Value = pos;
        }

        private void checkBoxImport_CheckedChanged(object sender, EventArgs e)
        {
            labelText.Enabled = numericImportAs.Enabled = checkBoxImport.Checked;
        }
    }
}
