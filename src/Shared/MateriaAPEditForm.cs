using Shojy.FF7.Elena.Inventory;
using Shojy.FF7.Elena.Sections;

namespace FF7Scarlet.Shared
{
    public partial class MateriaAPEditForm : Form
    {
        private const int ENEMY_SKILL_COUNT = 24, MASTERED_AP = 0xFFFFFF, NULL_AP = 0xFFFF * 100;
        private readonly CheckBox[] enemySkillCheckBoxes = new CheckBox[ENEMY_SKILL_COUNT];
        private bool loading;

        public InventoryMateria Materia { get; }
        private MateriaData MateriaData { get; }
        private EnemySkills[] ESkills { get; }

        public MateriaAPEditForm(InventoryMateria materia, MateriaData materiaData)
        {
            InitializeComponent();
            Materia = materia;
            MateriaData = materiaData;

            //get materia names
            comboBoxMateriaID.Items.Add("None");
            foreach (var m in MateriaData.Materias)
            {
                comboBoxMateriaID.Items.Add(m.Name);
            }

            //set AP limit
            numericCurrentAP.Maximum = MASTERED_AP;

            //get enemy skills
            SuspendLayout();
            ESkills = Enum.GetValues<EnemySkills>();
            int x = 3, y = 3;
            for (int i = 0; i < ENEMY_SKILL_COUNT; ++i)
            {
                //create the checkbox
                var cb = new CheckBox();
                enemySkillCheckBoxes[i] = cb;
                panelEnemySkills.Controls.Add(cb);

                //get e.skill name
                if (ESkills[i] == EnemySkills.QuestionMarks)
                {
                    cb.Text = "????";
                }
                else
                {
                    var name = Enum.GetName(ESkills[i]);
                    if (name != null)
                    {
                        cb.Text = StringParser.AddSpaces(name);
                    }
                }

                //position the checkbox
                cb.AutoSize = true;
                cb.Location = new Point(x, y);
                x += 100;
                if (x >= 300)
                {
                    y += 25;
                    x = 3;
                }

                //add the event handler
                cb.CheckedChanged += new EventHandler(EnemySkillCheckBox_CheckedChanged);
            }
            ResumeLayout();

            //set controls to match selected materia
            SetMateria();
        }

        private void SetMateria()
        {
            loading = true;
            if (Materia.Index == 0xFF) //none
            {
                comboBoxMateriaID.SelectedIndex = 0;
                numericCurrentAP.Enabled = false;
                checkBoxIsMastered.Enabled = false;
                groupBoxEnemySkills.Enabled = false;
            }
            else
            {
                comboBoxMateriaID.SelectedIndex = Materia.Index + 1;
                if (Materia.Index == 0x2C) //enemy skill
                {

                    numericCurrentAP.Enabled = false;
                    checkBoxIsMastered.Enabled = false;
                    groupBoxEnemySkills.Enabled = true;

                    var skills = (EnemySkills)Materia.CurrentAP;
                    for (int i = 0; i < ENEMY_SKILL_COUNT; ++i)
                    {
                        enemySkillCheckBoxes[i].Checked = skills.HasFlag(ESkills[i]);
                    }
                }
                else //other materia
                {
                    numericCurrentAP.Enabled = true;
                    checkBoxIsMastered.Enabled = true;
                    groupBoxEnemySkills.Enabled = false;

                    numericCurrentAP.Value = Materia.CurrentAP;
                    checkBoxIsMastered.Checked = Materia.CurrentAP == MASTERED_AP;
                }
            }
            loading = false;
        }

        private void EnemySkillCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!loading)
            {
                if (sender != null && sender is CheckBox)
                {
                    var cb = sender as CheckBox;
                    if (cb != null)
                    {
                        int i = Array.IndexOf(enemySkillCheckBoxes, cb);
                        if (i != -1)
                        {
                            if (cb.Checked) { Materia.CurrentAP += (int)ESkills[i]; }
                            else { Materia.CurrentAP -= (int)ESkills[i]; }
                            var test = (EnemySkills)Materia.CurrentAP;
                            MessageBox.Show(test.HasFlag(ESkills[i]).ToString());
                        }
                    }
                }
            }
        }

        private int GetMateriaMaxAP(InventoryMateria materia)
        {
            if (materia.Index == 0xFF) { return MASTERED_AP; }
            else
            {
                var md = MateriaData.Materias[materia.Index];
                if (md.Level2AP == NULL_AP) { return MASTERED_AP; }
                else if (md.Level3AP == NULL_AP) { return md.Level2AP; }
                else if (md.Level4AP == NULL_AP) { return md.Level3AP; }
                else if (md.Level5AP == NULL_AP) { return md.Level4AP; }
                else { return md.Level5AP; }
            }
        }

        private void comboBoxMateriaID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = comboBoxMateriaID.SelectedIndex;
                if (i == 0) { Materia.Index = 0xFF; }
                else { Materia.Index = (byte)(i - 1); }
                SetMateria();
            }
        }

        private void numericCurrentAP_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                Materia.CurrentAP = (int)numericCurrentAP.Value;
                checkBoxIsMastered.Checked = Materia.CurrentAP >= GetMateriaMaxAP(Materia);
                loading = false;
            }
        }

        private void checkBoxIsMastered_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                if (checkBoxIsMastered.Checked)
                {
                    Materia.CurrentAP = MASTERED_AP;
                }
                else
                {
                    Materia.CurrentAP = GetMateriaMaxAP(Materia) - 1;
                }
                numericCurrentAP.Value = Materia.CurrentAP;
                loading = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
