using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Items;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class EquipableListControl : UserControl
    {
        public event EventHandler? FlagsChanged;
        private bool loading;

        public EquipableListControl()
        {
            InitializeComponent();
        }

        public void SetEquipableFlags(EquipableBy equip)
        {
            loading = true;
            checkBoxCloud.Checked = equip.HasFlag(EquipableBy.Cloud);
            checkBoxBarret.Checked = equip.HasFlag(EquipableBy.Barret);
            checkBoxTifa.Checked = equip.HasFlag(EquipableBy.Tifa);
            checkBoxAerith.Checked = equip.HasFlag(EquipableBy.Aeris);
            checkBoxRedXIII.Checked = equip.HasFlag(EquipableBy.RedXIII);
            checkBoxYuffie.Checked = equip.HasFlag(EquipableBy.Yuffie);
            checkBoxCaitSith.Checked = equip.HasFlag(EquipableBy.CaitSith);
            checkBoxVincent.Checked = equip.HasFlag(EquipableBy.Vincent);
            checkBoxCid.Checked = equip.HasFlag(EquipableBy.Cid);
            checkBoxYCloud.Checked = equip.HasFlag(EquipableBy.YoungCloud);
            checkBoxSephiroth.Checked = equip.HasFlag(EquipableBy.Sephiroth);
            loading = false;
        }

        public EquipableBy GetEquipableFlags()
        {
            EquipableBy flags = 0;
            if (checkBoxCloud.Checked) { flags |= EquipableBy.Cloud; }
            if (checkBoxBarret.Checked) { flags |= EquipableBy.Barret; }
            if (checkBoxTifa.Checked) { flags |= EquipableBy.Tifa; }
            if (checkBoxAerith.Checked) { flags |= EquipableBy.Aeris; }
            if (checkBoxRedXIII.Checked) { flags |= EquipableBy.RedXIII; }
            if (checkBoxYuffie.Checked) { flags |= EquipableBy.Yuffie; }
            if (checkBoxCaitSith.Checked) { flags |= EquipableBy.CaitSith; }
            if (checkBoxVincent.Checked) { flags |= EquipableBy.Vincent; }
            if (checkBoxCid.Checked) { flags |= EquipableBy.Cid; }
            if (checkBoxYCloud.Checked) { flags |= EquipableBy.YoungCloud; }
            if (checkBoxSephiroth.Checked) { flags |= EquipableBy.Sephiroth; }
            return flags;
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
