namespace FF7Scarlet.SceneEditor
{
    public partial class BattleFlagsControl : UserControl
    {
        private CheckBox[] checkBoxes;
        private BattleFlags[] battleFlags;
        public event EventHandler? FlagsChanged;

        public BattleFlagsControl()
        {
            InitializeComponent();

            battleFlags = Enum.GetValues<BattleFlags>();
            checkBoxes = new CheckBox[]
            {
                checkBoxUnknown, checkBoxCantEscape, checkBoxNoVictoryPoses, checkBoxNoPreemptive
            };
        }

        public void SetFlags(BattleFlags flags)
        {
            for (int i = 0; i < battleFlags.Length; ++i)
            {
                checkBoxes[i].Checked = flags.HasFlag(battleFlags[i]);
            }
        }

        public BattleFlags GetFlags()
        {
            BattleFlags flags = 0;
            for (int i = 0; i < battleFlags.Length; ++i)
            {
                if (checkBoxes[i].Checked) { flags |= battleFlags[i]; }
            }
            return flags;
        }

        private void CheckBoxChanged(object? sender, EventArgs e)
        {
            FlagsChanged?.Invoke(this, e);
        }
    }
}
