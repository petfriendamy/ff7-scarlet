using Shojy.FF7.Elena.Materias;

namespace FF7Scarlet.KernelEditor
{
    public partial class MateriaSpellsForm : Form
    {
        public bool UnsavedChanges { get; private set; }
        private ComboBox[] comboBoxes;
        private MateriaExt materia;
        private int offset = 0;
        private bool loading;

        public MateriaSpellsForm(MateriaExt materia, string[] names)
        {
            InitializeComponent();

            comboBoxes = new ComboBox[]
            {
                comboBoxLevel1, comboBoxLevel2, comboBoxLevel3, comboBoxLevel4, comboBoxLevel5
            };

            this.materia = materia;

            //get name offsets
            int start = 0, end = names.Length;
            if (materia.MateriaType == MateriaType.Magic)
            {
                end = Kernel.SUMMON_OFFSET;
            }
            else if (materia.MateriaType == MateriaType.Summon)
            {
                start = offset = Kernel.SUMMON_OFFSET;
                end = Kernel.ESKILL_OFFSET;
            }

            //add names to the comboboxes
            loading = true;
            for (int i = 0; i < MateriaExt.ATTRIBUTE_COUNT - 1; ++i)
            {
                if (i > 0 && materia.MateriaType == MateriaType.Summon)
                {
                    comboBoxes[i].Enabled = false;
                }
                else
                {
                    comboBoxes[i].SuspendLayout();
                    comboBoxes[i].Items.Add("None");
                    for (int j = start; j < end; ++j)
                    {
                        comboBoxes[i].Items.Add(names[j]);
                    }
                    if (materia.Attributes[i] == 0xFF) //none
                    {
                        comboBoxes[i].SelectedIndex = 0;
                    }
                    else //get index of selected spell
                    {
                        comboBoxes[i].SelectedIndex = materia.Attributes[i] - offset + 1;
                    }
                    comboBoxes[i].ResumeLayout();
                }
            }
            loading = false;
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading) { UnsavedChanges = true; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
            {
                for (byte i = 0; i < MateriaExt.ATTRIBUTE_COUNT - 1; ++i)
                {
                    if (materia.MateriaType == MateriaType.Summon && i > 0)
                    {
                        materia.Attributes[i] = i;
                    }
                    else if (comboBoxes[i].SelectedIndex < 1)
                    {
                        materia.Attributes[i] = 0xFF;
                    }
                    else
                    {
                        materia.Attributes[i] = (byte)(comboBoxes[i].SelectedIndex + offset - 1);
                    }
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
