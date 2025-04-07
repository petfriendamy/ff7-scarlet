using Shojy.FF7.Elena.Materias;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using FF7Scarlet.Shared;

namespace FF7Scarlet.KernelEditor
{
    public partial class MateriaEffectScaleForm : Form
    {
        private List<MateriaStats> stats;
        private List<MateriaSpecialStats> specialStats;
        private List<SupportMateriaTypes> supportTypes;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UnsavedChanges { get; private set; }
        private NumericUpDown[] numerics;
        private Materia materia;
        private bool loading;

        public MateriaEffectScaleForm(Materia materia)
        {
            InitializeComponent();


            numerics =
            [
                numericLevel1, numericLevel2, numericLevel3, numericLevel4, numericLevel5
            ];

            this.materia = materia;
            loading = true;

            //check if should enable PS3 tweaks
            var type = Materia.GetMateriaType(materia.MateriaTypeByte);
            if (type == MateriaType.Support && (materia.Attributes[0] == (byte)SupportMateriaTypes.MorphAsWell
                || materia.Attributes[0] == (byte)SupportMateriaTypes.APPlus) && !DataManager.PS3TweaksEnabled)
            {
                var result = MessageBox.Show("This appears to be a custom materia type! Would you like to enable Postscriptthree Tweaks?",
                                "Enable Postscriptthree Tweaks?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataManager.PS3TweaksEnabled = true;
                }
            }

            //get stat types
            stats = Enum.GetValues<MateriaStats>().ToList();
            specialStats = Enum.GetValues<MateriaSpecialStats>().ToList();
            supportTypes = new List<SupportMateriaTypes>();
            foreach (var t in Enum.GetValues<SupportMateriaTypes>())
            {
                if ((t != SupportMateriaTypes.MorphAsWell && t != SupportMateriaTypes.APPlus) || DataManager.PS3TweaksEnabled)
                {
                    //comboBoxStatAffected.Items.Add(StringParser.AddSpaces(type.ToString()));
                    supportTypes.Add(t);
                }
            }

            //add types to the combobox
            comboBoxStatAffected.SuspendLayout();
            comboBoxStatAffected.Items.Add("None");
            if (type == MateriaType.Independent)
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
            else if (type == MateriaType.Support)
            {
                foreach (var t in supportTypes)
                {
                    if ((t != SupportMateriaTypes.MorphAsWell && t != SupportMateriaTypes.APPlus) || DataManager.PS3TweaksEnabled)
                    {
                        comboBoxStatAffected.Items.Add(StringParser.AddSpaces(t.ToString()));
                    }
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
                var type = Materia.GetMateriaType(materia.MateriaTypeByte);
                if (i == 0) //none
                {
                    materia.Attributes[0] = 0xFF;
                }
                else if (type == MateriaType.Support) //support type
                {
                    MateriaExt.SetMateriaSubtype(materia, supportTypes[i - 1]);
                }
                else if (i > stats.Count) //special stats
                {
                    MateriaExt.SetMateriaSubtype(materia, specialStats[i - stats.Count - 1]);
                }
                else //regular stats
                {
                    MateriaExt.SetMateriaSubtype(materia, stats[i - 1]);
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
