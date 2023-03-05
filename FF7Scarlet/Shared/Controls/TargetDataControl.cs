using Shojy.FF7.Elena.Battle;
using System.Xml.Linq;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class TargetDataControl : UserControl
    {
        private CheckBox[] checkBoxes;
        private TargetData[] flagList;
        private bool loading = false;
        public event EventHandler? FlagsChanged;

        public TargetDataControl()
        {
            InitializeComponent();

            checkBoxes = new CheckBox[]
            {
                checkBoxEnableSelection, checkBoxStartOnEnemies, checkBoxMultipleTargetDefault,
                checkBoxSingleMultiToggle, checkBoxOneRowOnly, checkBoxShortRange, checkBoxAllRows,
                checkBoxRandomTarget
            };
            flagList = new TargetData[]
            {
                TargetData.EnableSelection, TargetData.StartCursorOnEnemyRow, TargetData.DefaultMultipleTargets,
                TargetData.ToggleSingleMultiTarget, TargetData.SingleRowOnly, TargetData.ShortRange,
                TargetData.AllRows, TargetData.RandomTarget
            };
        }

        public void SetTargetData(TargetData data)
        {
            loading = true;
            for (int i = 0; i < flagList.Length; ++i)
            {
                checkBoxes[i].Checked = data.HasFlag(flagList[i]);
            }
            loading = false;
        }

        public TargetData GetTargetData()
        {
            TargetData data = 0;
            for (int i = 0; i < flagList.Length; ++i)
            {
                if (checkBoxes[i].Checked)
                {
                    data |= flagList[i];
                }
            }
            return data;
        }

        private void CheckBoxChanged(object? sender, EventArgs e)
        {
            if (!loading) { FlagsChanged?.Invoke(this, e); }
        }
    }
}
