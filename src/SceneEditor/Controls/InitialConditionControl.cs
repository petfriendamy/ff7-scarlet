namespace FF7Scarlet.SceneEditor
{
    public partial class InitialConditionControl : UserControl
    {
        private CheckBox[] checkBoxes;
        private InitialConditions[] conditionFlags;
        public event EventHandler? FlagsChanged;

        public InitialConditionControl()
        {
            InitializeComponent();
            conditionFlags = Enum.GetValues<InitialConditions>();
            checkBoxes = new CheckBox[]
            {
                checkBoxVisible, checkBoxLeftSide, checkBoxUnknown, checkBoxTargetable,
                checkBoxMainScriptActive
            };
        }

        public void SetConditions(InitialConditions conditions)
        {
            for (int i = 0; i < conditionFlags.Length; ++i)
            {
                checkBoxes[i].Checked = conditions.HasFlag(conditionFlags[i]);
            }
        }

        public InitialConditions GetFlags()
        {
            InitialConditions flags = 0;
            for (int i = 0; i < conditionFlags.Length; ++i)
            {
                if (checkBoxes[i].Checked) { flags |= conditionFlags[i]; }
            }
            return flags;
        }

        private void CheckBoxChanged(object? sender, EventArgs e)
        {
            FlagsChanged?.Invoke(this, e);
        }
    }
}
