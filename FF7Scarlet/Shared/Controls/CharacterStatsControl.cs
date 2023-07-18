namespace FF7Scarlet.Shared.Controls
{
    public partial class CharacterStatsControl : UserControl
    {
        public event EventHandler? CharacterStatsChanged;
        private bool loading;

        public CharacterStatsControl()
        {
            InitializeComponent();
        }

        public void SetStats(Character chara)
        {
            loading = true;
            numericStrength.Value = chara.Strength;
            numericStrengthBonus.Value = chara.StrengthBonus;
            numericVitality.Value = chara.Vitality;
            numericVitalityBonus.Value = chara.VitalityBonus;
            numericMagic.Value = chara.Magic;
            numericMagicBonus.Value = chara.MagicBonus;
            numericSpirit.Value = chara.Spirit;
            numericSpiritBonus.Value = chara.SpiritBonus;
            numericDexterity.Value = chara.Dexterity;
            numericDexterityBonus.Value = chara.DexterityBonus;
            numericLuck.Value = chara.Luck;
            numericLuckBonus.Value = chara.LuckBonus;
            loading = false;
        }

        private void InvokeStatsChanged(object? sender, EventArgs e)
        {
            CharacterStatsChanged?.Invoke(sender, e);
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            InvokeStatsChanged(sender, e);
        }
    }
}
