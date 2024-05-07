using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class RNGTableControl : UserControl
    {
        private TextBox[] textBoxes = new TextBox[256];
        private const int WIDTH = 35, HEIGHT = 20;

        public RNGTableControl()
        {
            InitializeComponent();
            SuspendLayout();
            int i = 0, row = 0, col = 0;
            while (i < 256)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].Size = new Size(WIDTH, HEIGHT);
                textBoxes[i].Font = new Font(textBoxes[i].Font.FontFamily, 8);
                textBoxes[i].MaxLength = 3;
                textBoxes[i].Location = new Point(col * WIDTH, row * HEIGHT);
                textBoxes[i].ReadOnly = true;
                panelMain.Controls.Add(textBoxes[i]);

                col++;
                if (col >= 16)
                {
                    row++;
                    col = 0;
                }
                i++;
            }
            ResumeLayout();
        }

        public void SetValues(byte[] table)
        {
            for (int i = 0; i < 256 && i < table.Length; ++i)
            {
                textBoxes[i].Text = table[i].ToString();
            }
        }
    }
}
