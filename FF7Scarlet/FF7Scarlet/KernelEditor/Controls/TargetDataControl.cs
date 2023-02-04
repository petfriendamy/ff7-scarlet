using Shojy.FF7.Elena.Battle;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class TargetDataControl : UserControl
    {
        public TargetDataControl()
        {
            InitializeComponent();
        }

        public void SetTargetData(TargetData data)
        {
            checkBoxEnableSelection.Checked = data.HasFlag(TargetData.EnableSelection);
            checkBoxStartOnEnemies.Checked = data.HasFlag(TargetData.StartCursorOnEnemyRow);
            checkBoxMultipleTargetDefault.Checked = data.HasFlag(TargetData.DefaultMultipleTargets);
            checkBoxSingleMultiToggle.Checked = data.HasFlag(TargetData.ToggleSingleMultiTarget);
            checkBoxOneRowOnly.Checked = data.HasFlag(TargetData.SingleRowOnly);
            checkBoxShortRange.Checked = data.HasFlag(TargetData.ShortRange);
            checkBoxAllRows.Checked = data.HasFlag(TargetData.AllRows);
            checkBoxRandomTarget.Checked = data.HasFlag(TargetData.RandomTarget);
        }
    }
}
