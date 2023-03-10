using System.ComponentModel;

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
            return new Point3D((ushort)numericPositionX.Value, (ushort)numericPositionY.Value,
                (ushort)numericPositionZ.Value);
        }

        public Point3D GetAngle()
        {
            return new Point3D((ushort)numericAngleX.Value, (ushort)numericAngleY.Value,
                (ushort)numericUpAngleZ.Value);
        }

        private void NumericValueChanged(object? sender, EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }
    }
}
