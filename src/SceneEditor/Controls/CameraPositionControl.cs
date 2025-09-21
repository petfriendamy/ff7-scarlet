using FF7Scarlet.Shared;
using System.ComponentModel;

namespace FF7Scarlet.SceneEditor.Controls
{
    public partial class CameraPositionControl : UserControl
    {
        [Description("The text for the GroupBox.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string GroupBoxText
        {
            get { return groupBoxMain.Text; }
            set { groupBoxMain.Text = value; }
        }
        public event EventHandler? DataChanged;

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

        public Point3D GetPosition()
        {
            return new Point3D((short)numericPositionX.Value, (short)numericPositionY.Value,
                (short)numericPositionZ.Value);
        }

        public Point3D GetAngle()
        {
            return new Point3D((short)numericAngleX.Value, (short)numericAngleY.Value,
                (short)numericUpAngleZ.Value);
        }

        private void NumericValueChanged(object? sender, EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }
    }
}
