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
    public partial class CameraPositionControl : UserControl
    {
        [Description("The text for the GroupBox.")]
        public string GroupBoxText
        {
            get { return groupBoxMain.Text; }
            set { groupBoxMain.Text = value; }
        }

        public CameraPositionControl()
        {
            InitializeComponent();
        }

        public void SetPosition(Point3D position, Point3D angle)
        {
            numericPositionX.Value = position.X;
            numericPositionY.Value = position.Y;
            numericPositionZ.Value = position.Z;
            numericAngleX.Value = angle.X;
            numericAngleY.Value = angle.Y;
            numericUpAngleZ.Value = angle.Z;
        }
    }
}
