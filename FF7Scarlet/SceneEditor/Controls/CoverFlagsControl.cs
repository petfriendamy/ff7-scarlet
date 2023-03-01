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
    public partial class CoverFlagsControl : UserControl
    {
        private CheckBox[] checkboxes;

        public CoverFlagsControl()
        {
            InitializeComponent();

            checkboxes = new CheckBox[16]
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8,
                checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16
            };
        }

        public void SetFlags(bool[] flags)
        {
            if (flags.Length < 16)
            {
                throw new ArgumentException("Array is too short.");
            }

            for (int i = 0; i < 16; ++i)
            {
                checkboxes[i].Checked = flags[i];
            }
        }
    }
}
