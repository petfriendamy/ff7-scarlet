using Shojy.FF7.Elena.Battle;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class ElementsControl : UserControl
    {
        public ElementsControl()
        {
            InitializeComponent();
        }

        public void SetElements(Elements elements)
        {
            checkBoxFire.Checked = elements.HasFlag(Elements.Fire);
            checkBoxIce.Checked = elements.HasFlag(Elements.Ice);
            checkBoxBolt.Checked = elements.HasFlag(Elements.Bolt);
            checkBoxEarth.Checked = elements.HasFlag(Elements.Earth);
            checkBoxPoison.Checked = elements.HasFlag(Elements.Poison);
            checkBoxGravity.Checked = elements.HasFlag(Elements.Gravity);
            checkBoxWater.Checked = elements.HasFlag(Elements.Water);
            checkBoxWind.Checked = elements.HasFlag(Elements.Wind);
            checkBoxHoly.Checked = elements.HasFlag(Elements.Holy);
            checkBoxRestorative.Checked = elements.HasFlag(Elements.Restorative);
            checkBoxCut.Checked = elements.HasFlag(Elements.Cut);
            checkBoxHit.Checked = elements.HasFlag(Elements.Hit);
            checkBoxPunch.Checked = elements.HasFlag(Elements.Punch);
            checkBoxShoot.Checked = elements.HasFlag(Elements.Shoot);
            checkBoxShout.Checked = elements.HasFlag(Elements.Shout);
            checkBoxHidden.Checked = elements.HasFlag(Elements.Hidden);
        }
    }
}
