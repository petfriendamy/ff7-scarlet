using Shojy.FF7.Elena.Equipment;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class EquipableListControl : UserControl
    {
        public EquipableListControl()
        {
            InitializeComponent();
        }

        public void SetEquipableFlags(EquipableBy equip)
        {
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
        }
    }
}
