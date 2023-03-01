using Shojy.FF7.Elena.Items;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class ItemRestrictionsControl : UserControl
    {
        public bool ShowThrowable
        {
            get { return checkBoxWeaponIsThrowable.Visible; }
            set { checkBoxWeaponIsThrowable.Visible = value; }
        }

        public ItemRestrictionsControl()
        {
            InitializeComponent();
        }

        public void SetItemRestrictions(Restrictions restrictions)
        {
            checkBoxWeaponIsSellable.Checked = restrictions.HasFlag(Restrictions.CanBeSold);
            checkBoxWeaponUsableInBattle.Checked = restrictions.HasFlag(Restrictions.CanBeUsedInBattle);
            checkBoxWeaponUsableInMenu.Checked = restrictions.HasFlag(Restrictions.CanBeUsedInMenu);
            checkBoxWeaponIsThrowable.Checked = restrictions.HasFlag(Restrictions.CanBeThrown);
        }
    }
}
