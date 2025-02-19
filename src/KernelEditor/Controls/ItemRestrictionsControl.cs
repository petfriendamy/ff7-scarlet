using Shojy.FF7.Elena.Items;
using System.ComponentModel;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class ItemRestrictionsControl : UserControl
    {
        public event EventHandler? FlagsChanged;
        private bool loading;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowThrowable
        {
            get { return checkBoxIsThrowable.Visible; }
            set { checkBoxIsThrowable.Visible = value; }
        }

        public ItemRestrictionsControl()
        {
            InitializeComponent();
        }

        public void SetItemRestrictions(Restrictions restrictions)
        {
            loading = true;
            checkBoxIsSellable.Checked = restrictions.HasFlag(Restrictions.CanBeSold);
            checkBoxUsableInBattle.Checked = restrictions.HasFlag(Restrictions.CanBeUsedInBattle);
            checkBoxUsableInMenu.Checked = restrictions.HasFlag(Restrictions.CanBeUsedInMenu);
            checkBoxIsThrowable.Checked = restrictions.HasFlag(Restrictions.CanBeThrown);
            loading = false;
        }

        public Restrictions GetItemRestrictions()
        {
            Restrictions restrictions = 0;
            if (checkBoxIsSellable.Checked) { restrictions |= Restrictions.CanBeSold; }
            if (checkBoxUsableInBattle.Checked) { restrictions |= Restrictions.CanBeUsedInBattle; }
            if (checkBoxUsableInMenu.Checked) { restrictions |= Restrictions.CanBeUsedInMenu; }
            if (checkBoxIsThrowable.Checked) { restrictions |= Restrictions.CanBeThrown; }
            return restrictions;
        }

        private void InvokeFlagsChanged(object? sender, EventArgs e)
        {
            FlagsChanged?.Invoke(sender, e);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                InvokeFlagsChanged(sender, e);
            }
        }
    }
}
