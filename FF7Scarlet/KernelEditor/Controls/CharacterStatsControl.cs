using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet.KernelEditor.Controls
{
    public partial class CharacterStatsControl : UserControl
    {
        public CharacterStatsControl()
        {
            InitializeComponent();
        }

        public void SetStats(Character chara)
        {
            numericStrength.Value = chara.Strength;
            numericStrengthBonus.Value = chara.StrengthBonus;
            numericVitality.Value = chara.Vitality;
            numericVitalityBonus.Value = chara.VitalityBonus;
            numericMagic.Value = chara.Magic;
            numericMagicBonus.Value = chara.MagicBonus;
            numericSpirit.Value = chara.Spirit;
            numericSpiritBonus.Value = chara.SpiritBonus;
            numericDexterity.Value = chara.Dexterity;
            numericDexterityBonus.Value= chara.DexterityBonus;
            numericLuck.Value = chara.Luck;
            numericLuckBonus.Value = chara.LuckBonus;
        }
    }
}
