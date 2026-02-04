using FF7Scarlet.Shared;
using OpenTK.Mathematics;
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

        public bool ViewMode
        {
            get { return viewMode; }
            private set
            {
                viewMode = value;
                buttonCameraToView.Enabled = value;
                buttonViewToCamera.Enabled = value;

                foreach (var n in numerics)
                {
                    if (value)
                        n.ForeColor = SystemColors.GrayText;
                    else
                        n.ForeColor = SystemColors.WindowText;
                }
            }
        }
        private bool viewMode = false;
        private Point3D storedPosition = new();
        private Point3D storedAngle = new();
        private NumericUpDown[] numerics;
        private bool loading = false;

        public event EventHandler? DataChanged;
        public event EventHandler? DataReset;

        public CameraPositionControl()
        {
            InitializeComponent();

            numerics = [
                numericPositionX, numericPositionY, numericPositionZ,
                numericAngleX, numericAngleY, numericUpAngleZ
                ];

            foreach (var n in numerics)
            {
                n.Minimum = short.MinValue;
                n.Maximum = short.MaxValue;
            }
        }

        public void SetPosition(Point3D position, Point3D angle, bool viewMode = false)
        {
            var pos = position.ToOpenTK();
            var ang = angle.ToOpenTK();
            SetPosition(pos, ang, viewMode);
        }

        public void SetPosition(Vector3 position, Vector3 angle, bool viewMode = false)
        {
            loading = true;
            if (viewMode && !ViewMode)
            {
                ViewMode = true;
                storedPosition = GetPosition();
                storedAngle = GetAngle();
            }
            numericPositionX.Value = (decimal)position.X;
            numericPositionY.Value = (decimal)position.Y;
            numericPositionZ.Value = (decimal)position.Z;
            numericAngleX.Value = (decimal)angle.X;
            numericAngleY.Value = (decimal)angle.Y;
            numericUpAngleZ.Value = (decimal)angle.Z;
            loading = false;
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

        public void CommitChanges()
        {
            //sync camera to the current view camera
            if (ViewMode) ViewMode = false;
        }

        public void ResetChanges()
        {
            //reset camera to its original position
            if (ViewMode)
            {
                SetPosition(storedPosition, storedAngle);
                ViewMode = false;
                
            }
        }

        private void NumericValueChanged(object? sender, EventArgs e)
        {
            if (!loading)
                DataChanged?.Invoke(this, e);
        }

        private void buttonViewToCamera_Click(object sender, EventArgs e)
        {
            if (ViewMode)
            {
                CommitChanges();
                DataChanged?.Invoke(this, e);
            }
        }

        private void buttonCameraToView_Click(object sender, EventArgs e)
        {
            if (ViewMode)
            {
                ResetChanges();
                DataReset?.Invoke(this, e);
            }
        }
    }
}
