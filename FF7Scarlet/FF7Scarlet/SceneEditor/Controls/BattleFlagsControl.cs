namespace FF7Scarlet.SceneEditor
{
    public partial class BattleFlagsControl : UserControl
    {
        public BattleFlagsControl()
        {
            InitializeComponent();
        }

        public void SetFlags(BattleFlags flags)
        {
            checkBoxUnknown.Checked = flags.HasFlag(BattleFlags.Unknown);
            checkBoxCantEscape.Checked = flags.HasFlag(BattleFlags.CantEscape);
            checkBoxNoVictoryPoses.Checked = flags.HasFlag(BattleFlags.NoVictoryPoses);
            checkBoxNoPreemptive.Checked = flags.HasFlag(BattleFlags.NoPreemptive);
        }
    }
}
