using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Text;
using System.ComponentModel;

#pragma warning disable CA1416
namespace FF7Scarlet.KernelEditor
{
    public partial class CurveEditForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Unsaved { get; private set; } = false;
        private Kernel kernel;
        private NumericUpDown[] bases, gradients;
        private StatCurve curve;
        private byte curveIndex;
        private const int STAT_COUNT = 9, NUM_CURVES = 64;

        public CurveEditForm(Kernel kernel, byte curveIndex)
        {
            InitializeComponent();

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
            this.kernel = kernel;
            this.curveIndex = curveIndex;
            curve = new StatCurve();
            for (int i = 0; i < 8; ++i)
            {
                curve.Bases[i] = kernel.BattleAndGrowthData.StatCurves[curveIndex].Bases[i];
                curve.Gradients[i] = kernel.BattleAndGrowthData.StatCurves[curveIndex].Gradients[i];
                bases[i].Value = curve.Bases[i];
                gradients[i].Value = curve.Gradients[i];
            }
            labelCurveIndex.Text = $"Curve index: {curveIndex}";

            //show which stats are currently using this curve index
            var stats = new List<string>();
            for (int i = 0; i < Kernel.PLAYABLE_CHARACTER_COUNT; ++i)
            {
                for (int j = 0; j < STAT_COUNT; ++j)
                {
                    if (kernel.GetCurveIndex(i, j) == curveIndex)
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
                kernel.BattleAndGrowthData.StatCurves[curveIndex] = curve;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
