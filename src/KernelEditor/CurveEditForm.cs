using FF7Scarlet.Shared;
using System.Security.Cryptography;

namespace FF7Scarlet.KernelEditor
{
    public partial class CurveEditForm : Form
    {
        //public StatCurve Curve { get; private set; }
        public bool Unsaved { get; private set; } = false;
        private BattleAndGrowthData growthData;
        private NumericUpDown[] bases, gradients;
        private StatCurve curve;
        private byte curveIndex;
        private bool loading;

        public CurveEditForm(BattleAndGrowthData growthData, byte curveIndex)
        {
            InitializeComponent();
            loading = true;

            //get bases and gradients
            bases = [
                numericBase1, numericBase2, numericBase3, numericBase4,
                numericBase5, numericBase6, numericBase7, numericBase8
            ];
            gradients = [
                numericGradient1, numericGradient2, numericGradient3, numericGradient4,
                numericGradient5, numericGradient6, numericGradient7, numericGradient8
            ];

            //fill out controls with values
            this.growthData = growthData;
            this.curveIndex = curveIndex;
            curve = new StatCurve(growthData.StatCurves[curveIndex].GetRawData());
            for (int i = 0; i < 8; ++i)
            {
                bases[i].Value = curve.Bases[i];
                gradients[i].Value = curve.Gradients[i];
            }
            labelCurveIndex.Text = $"Curve index: {curveIndex}";

            //show which stats are currently using this curve index
            var stats = new List<string>();
            for (int i = 0; i < Character.PLAYABLE_CHARACTER_COUNT; ++i)
            {
                for (int j = 0; j < StatCurve.STAT_COUNT; ++j)
                {
                    if (growthData.CharGrowth[i].CurveIndex[j] == curveIndex)
                    {
                        string? name = Enum.GetName((CharacterNames)i),
                            stat = Enum.GetName((CurveStats)j);
                        if (name != null) { name = StringParser.AddSpaces(name); }
                        if (stat != null) { stat = StringParser.AddSpaces(stat); }
                        stats.Add($"{name} - {stat}");
                    }
                }
            }
            if (stats.Count == 0)
            {
                labelUsedBy.Text = "-None";
            }
            else
            {
                labelUsedBy.Text = string.Empty;
                foreach (var s in stats)
                {
                    labelUsedBy.Text += s + Environment.NewLine;
                }
            }

            loading = false;
        }

        private void numericBase_ValueChanged(object sender, EventArgs e)
        {
            var numeric = sender as NumericUpDown;
            if (numeric != null)
            {
                int i = bases.ToList().IndexOf(numeric);
                if (i >= 0 && i < 8)
                {
                    curve.Bases[i] = (sbyte)bases[i].Value;
                    Unsaved = true;
                }
            }
        }

        private void numericGradient_ValueChanged(object sender, EventArgs e)
        {
            var numeric = sender as NumericUpDown;
            if (numeric != null)
            {
                int i = gradients.ToList().IndexOf(numeric);
                if (i >= 0 && i < 8)
                {
                    curve.Gradients[i] = (byte)gradients[i].Value;
                    Unsaved = true;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Unsaved)
            {
                growthData.StatCurves[curveIndex] = curve;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
