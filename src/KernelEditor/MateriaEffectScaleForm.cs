using Shojy.FF7.Elena.Materias;
using System.Windows.Forms.VisualStyles;

namespace FF7Scarlet.KernelEditor
{
    public partial class MateriaEffectScaleForm : Form
    {
        private List<MateriaStats> stats;
        private List<MateriaSpecialStats> specialStats;
        private List<SupportMateriaTypes> supportTypes;

        public bool UnsavedChanges { get; private set; }
        private NumericUpDown[] numerics;
        private MateriaExt materia;
        private bool loading;

        public MateriaEffectScaleForm(MateriaExt materia)
        {
            InitializeComponent();


            numerics = new NumericUpDown[]
            {
                numericLevel1, numericLevel2, numericLevel3, numericLevel4, numericLevel5
            };

            this.materia = materia;
            loading = true;

            //get stat types
            stats = Enum.GetValues<MateriaStats>().ToList();
            specialStats = Enum.GetValues<MateriaSpecialStats>().ToList();
            supportTypes = Enum.GetValues<SupportMateriaTypes>().ToList();

            //add types to the combobox
            comboBoxStatAffected.SuspendLayout();
            comboBoxStatAffected.Items.Add("None");
            if (materia.MateriaType == MateriaType.Independent)
            {
                foreach (var stat in stats)
                {
                    comboBoxStatAffected.Items.Add(StringParser.AddSpaces(stat.ToString(), true));
                }
                foreach (var stat in specialStats)
                {
                    if (stat == MateriaSpecialStats.PreEmptiveChance)
                    {
                        comboBoxStatAffected.Items.Add("Pre-emptive chance");
                    }
                    else
                    {
                        comboBoxStatAffected.Items.Add(StringParser.AddSpaces(stat.ToString(), true));
                    }
                }
                if (materia.Attributes[0] == 0xFF)
                {
                    comboBoxStatAffected.SelectedIndex = 0;
                }
                else if (materia.MateriaTypeByte == (byte)MateriaByteValues.IndependentStatBoost2)
                {
                    comboBoxStatAffected.SelectedIndex = stats.Count + materia.Attributes[0] + 1;
                }
                else if (materia.MateriaTypeByte == (byte)MateriaByteValues.IndependentEXPPlus)
                {
                    comboBoxStatAffected.SelectedIndex = stats.Count + 5;
                }
                else if (materia.MateriaTypeByte == (byte)MateriaByteValues.IndependentPreEmptive)
                {
                    comboBoxStatAffected.SelectedIndex = stats.Count + 4;
                }
                else
                {
                    comboBoxStatAffected.SelectedIndex =
                        stats.IndexOf((MateriaStats)materia.Attributes[0]) + 1;
                }
            }
            else if (materia.MateriaType == MateriaType.Support)
            {
                foreach (var type in supportTypes)
                {
                    comboBoxStatAffected.Items.Add(StringParser.AddSpaces(type.ToString()));
                }
                comboBoxStatAffected.SelectedIndex =
                    supportTypes.IndexOf((SupportMateriaTypes)materia.Attributes[0]) + 1;
            }
            comboBoxStatAffected.ResumeLayout();

            //set values from attributes
            for (int i = 0; i < MateriaExt.ATTRIBUTE_COUNT - 1; ++i)
            {
                numerics[i].Value = materia.Attributes[i + 1];
            }
            loading = false;
        }

        private void DataChanged(object sender, EventArgs e)
        {
            if (!loading) { UnsavedChanges = true; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
            {
                //set affected attribute
                int i = comboBoxStatAffected.SelectedIndex;
                if (i == 0) //none
                {
                    materia.Attributes[0] = 0xFF;
                }
                else if (materia.MateriaType == MateriaType.Support) //support type
                {
                    materia.SetMateriaSubtype(supportTypes[i - 1]);
                }
                else if (i > stats.Count) //special stats
                {
                    materia.SetMateriaSubtype(specialStats[i - stats.Count - 1]);
                }
                else //regular stats
                {
                    materia.SetMateriaSubtype(stats[i - 1]);
                }

                //set other attributes
                for (int j = 0; j < MateriaExt.ATTRIBUTE_COUNT - 1; ++j)
                {
                    materia.Attributes[j + 1] = (byte)numerics[j].Value;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
