using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Characters;
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
    public partial class LimitRequirementControl : UserControl
    {
        private Character? chara;
        private int level;
        private bool loading = false;
        public event EventHandler? DataChanged;

        public LimitRequirementControl()
        {
            InitializeComponent();
            numericHPDivisor.Maximum = uint.MaxValue;
        }

        public void SetData(string[] names, int level)
        {
            this.level = level;
            groupBoxMain.Text = $"Limit level {level}";
            if (level == 1 || level == 4)
            {
                labelKillRequirement.Visible = numericKillRequirement.Visible = false;
            }
            if (level == 4)
            {
                labelUses.Visible = numericUses.Visible = comboBoxLimit2.Enabled = false;
            }

            int i = comboBoxLimit1.SelectedIndex,
                j = comboBoxLimit2.SelectedIndex;

            comboBoxLimit1.SuspendLayout();
            comboBoxLimit2.SuspendLayout();

            comboBoxLimit1.Items.Clear();
            comboBoxLimit2.Items.Clear();

            comboBoxLimit1.Items.Add("None");
            comboBoxLimit2.Items.Add("None");

            foreach (string name in names)
            {
                comboBoxLimit1.Items.Add(name);
                comboBoxLimit2.Items.Add(name);
            }

            comboBoxLimit1.SelectedIndex = Math.Max(i, 0);
            comboBoxLimit2.SelectedIndex = Math.Max(j, 0);

            comboBoxLimit1.ResumeLayout();
            comboBoxLimit2.ResumeLayout();
        }

        public void SetCharacter(Character chara)
        {
            loading = true;
            this.chara = chara;
            byte
                limit1 = 0xFF,
                limit2 = 0xFF;
            ushort
                uses = HexParser.NULL_OFFSET_16_BIT,
                kills = HexParser.NULL_OFFSET_16_BIT;
            uint hpDivisor = HexParser.NULL_OFFSET_32_BIT;

            switch (level)
            {
                case 2:
                    limit1 = chara.Limit2_1Index;
                    limit2 = chara.Limit2_2Index;
                    uses = chara.UsesForLimit2_2;
                    kills = chara.KillsForLimitLv2;
                    hpDivisor = chara.LimitLv2HPDivisor;
                    break;
                case 3:
                    limit1 = chara.Limit3_1Index;
                    limit2 = chara.Limit3_2Index;
                    uses = chara.UsesForLimit3_2;
                    kills = chara.KillsForLimitLv3;
                    hpDivisor = chara.LimitLv3HPDivisor;
                    break;
                case 4:
                    limit1 = chara.Limit4Index;
                    hpDivisor = chara.LimitLv4HPDivisor;
                    break;
                default:
                    limit1 = chara.Limit1_1Index;
                    limit2 = chara.Limit1_2Index;
                    uses = chara.UsesForLimit1_2;
                    hpDivisor = chara.LimitLv1HPDivisor;
                    break;
            }

            labelKillRequirement.Enabled = numericKillRequirement.Enabled = limit1 != 0xFF;
            if (limit1 == 0xFF) { comboBoxLimit1.SelectedIndex = 0; }
            else { comboBoxLimit1.SelectedIndex = (limit1 - Kernel.ATTACK_COUNT + 1); }

            labelUses.Enabled = numericUses.Enabled = limit2 != 0xFF;
            if (limit2 == 0xFF) { comboBoxLimit2.SelectedIndex = 0; }
            else { comboBoxLimit2.SelectedIndex = (limit2 - Kernel.ATTACK_COUNT + 1); }

            numericUses.Value = uses;
            numericKillRequirement.Value = kills;
            numericHPDivisor.Value = hpDivisor;
            loading = false;
        }

        private void comboBoxLimit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && chara != null)
            {
                byte index = 0xFF;
                if (comboBoxLimit1.SelectedIndex > 0)
                {
                    index = (byte)(comboBoxLimit1.SelectedIndex + Kernel.ATTACK_COUNT - 1);
                }

                switch (level)
                {
                    case 1:
                        chara.Limit1_1Index = index;
                        break;
                    case 2:
                        chara.Limit2_1Index = index;
                        break;
                    case 3:
                        chara.Limit3_1Index = index;
                        break;
                    case 4:
                        chara.Limit4Index = index;
                        break;
                }
                InvokeDataChanged(this, EventArgs.Empty);
            }
        }

        private void comboBoxLimit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && chara != null)
            {
                byte index = 0xFF;
                if (comboBoxLimit2.SelectedIndex > 0)
                {
                    index = (byte)(comboBoxLimit2.SelectedIndex + Kernel.ATTACK_COUNT - 1);
                }

                switch (level)
                {
                    case 1:
                        chara.Limit1_2Index = index;
                        break;
                    case 2:
                        chara.Limit2_2Index = index;
                        break;
                    case 3:
                        chara.Limit3_2Index = index;
                        break;
                }
                InvokeDataChanged(this, EventArgs.Empty);
            }
        }

        private void numericKillRequirement_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && chara != null)
            {
                var kills = (ushort)numericKillRequirement.Value;
                switch (level)
                {
                    case 2:
                        chara.KillsForLimitLv2 = kills;
                        break;
                    case 3:
                        chara.KillsForLimitLv3 = kills;
                        break;
                }
                InvokeDataChanged(this, EventArgs.Empty);
            }
        }

        private void numericUses_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && chara != null)
            {
                var uses = (ushort)numericUses.Value;
                switch (level)
                {
                    case 1:
                        chara.UsesForLimit1_2 = uses;
                        break;
                    case 2:
                        chara.UsesForLimit2_2 = uses;
                        break;
                    case 3:
                        chara.UsesForLimit3_2 = uses;
                        break;
                }
                InvokeDataChanged(this, EventArgs.Empty);
            }
        }

        private void numericHPDivisor_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && chara != null)
            {
                var divisor = (uint)numericHPDivisor.Value;
                switch (level)
                {
                    case 1:
                        chara.LimitLv1HPDivisor = divisor;
                        break;
                    case 2:
                        chara.LimitLv2HPDivisor = divisor;
                        break;
                    case 3:
                        chara.LimitLv3HPDivisor = divisor;
                        break;
                    case 4:
                        chara.LimitLv4HPDivisor = divisor;
                        break;
                }
                InvokeDataChanged(this, EventArgs.Empty);
            }
        }

        private void InvokeDataChanged(object? sender, EventArgs e)
        {
            DataChanged?.Invoke(sender, e);
        }
    }
}
