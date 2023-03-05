using Shojy.FF7.Elena.Battle;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class ElementsControl : UserControl
    {
        private CheckBox[] checkBoxes;
        private Elements[] elementList;
        private bool loading = false;
        public event EventHandler? ElementsChanged;

        public ElementsControl()
        {
            InitializeComponent();
            elementList = Enum.GetValues<Elements>();
            checkBoxes = new CheckBox[]
            {
                checkBoxFire, checkBoxIce, checkBoxBolt, checkBoxEarth, checkBoxPoison,
                checkBoxGravity, checkBoxWater, checkBoxWind, checkBoxHoly, checkBoxRestorative,
                checkBoxCut, checkBoxHit, checkBoxPunch, checkBoxShoot, checkBoxShout,
                checkBoxHidden
            };
        }

        public void SetElements(Elements elements)
        {
            loading = true;
            for (int i = 0; i < elementList.Length; ++i)
            {
                checkBoxes[i].Checked = elements.HasFlag(elementList[i]);
            }
            loading = false;
        }

        public Elements GetElements()
        {
            Elements element = 0;
            for (int i = 0; i < elementList.Length; ++i)
            {
                if (checkBoxes[i].Checked)
                {
                    element |= elementList[i];
                }
            }
            return element;
        }

        private void CheckBoxChanged(object? sender, EventArgs e)
        {
            if (!loading) { ElementsChanged?.Invoke(this, e); }
        }
    }
}
