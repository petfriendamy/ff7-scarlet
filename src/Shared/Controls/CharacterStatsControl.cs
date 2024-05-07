using System;

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

        public void SetStatsFromCharacter(Character chara)
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

        public void CopyStatsToCharacter(Character chara)
        {
            chara.Strength = (byte)numericStrength.Value;
            chara.StrengthBonus = (byte)numericStrengthBonus.Value;
            chara.Vitality = (byte)numericVitality.Value;
            chara.VitalityBonus = (byte)numericVitalityBonus.Value;
            chara.Magic = (byte)numericMagic.Value;
            chara.MagicBonus = (byte)numericMagicBonus.Value;
            chara.Spirit = (byte)numericSpirit.Value;
            chara.SpiritBonus = (byte)numericSpiritBonus.Value;
            chara.Dexterity = (byte)numericDexterity.Value;
            chara.DexterityBonus = (byte)numericDexterityBonus.Value;
            chara.Luck = (byte)numericLuck.Value;
            chara.LuckBonus = (byte)numericLuckBonus.Value;
        }

        private void InvokeStatsChanged(object? sender, EventArgs e)
        {
            CharacterStatsChanged?.Invoke(sender, e);
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                InvokeStatsChanged(sender, e);
            }
        }
    }
}
