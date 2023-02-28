namespace FF7Scarlet.SceneEditor
{
    public partial class InitialConditionControl : UserControl
    {
        public InitialConditionControl()
        {
            InitializeComponent();
        }

        public void SetConditions(InitialConditions conditions)
        {
            checkBoxVisible.Checked = conditions.HasFlag(InitialConditions.Visble);
            checkBoxLeftSide.Checked = conditions.HasFlag(InitialConditions.LeftSide);
            checkBoxUnknown.Checked = conditions.HasFlag(InitialConditions.Unknown);
            checkBoxTargetable.Checked = conditions.HasFlag(InitialConditions.Targetable);
            checkBoxMainScriptActive.Checked = conditions.HasFlag(InitialConditions.MainScriptActive);
        }
    }
}
