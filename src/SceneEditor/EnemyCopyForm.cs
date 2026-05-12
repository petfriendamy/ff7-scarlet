using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Attacks;
using System.Data;

namespace FF7Scarlet.SceneEditor
{
    public partial class EnemyCopyForm : Form
    {
        private Scene scene;
        private Formation formation;
        private Enemy? enemy;
        private Attack?[] attacks;
        private Enemy[] enemyList;
        private ushort enemyID;

        public bool AddedEnemy { get; private set; }

        public EnemyCopyForm(Scene scene, Formation formation, Enemy? enemy, Attack?[] attacks, bool isJapanese)
        {
            InitializeComponent();
            this.scene = scene;
            this.formation = formation;
            this.enemy = enemy;
            this.attacks = attacks;
            string name = "(unknown enemy)";
            enemyID = HexParser.NULL_OFFSET_16_BIT;
            if (enemy != null)
            {
                name = enemy.Name.ToString(isJapanese);
                enemyID = enemy.ModelID;
            }

            enemyList =
                (from e in scene.Enemies
                 where e != null
                 select e).ToArray();

            labelAlert.Text = $"{name} not found in this scene.{Environment.NewLine}Please select an option:";
            comboBoxReplacementEnemy.SuspendLayout();
            comboBoxReplacementEnemy.Items.Add("Remove from formation");
            foreach (var e in enemyList)
            {
                comboBoxReplacementEnemy.Items.Add($"Replace with {e.Name.ToString(isJapanese)}");
            }
            if (enemy != null && enemyList.Length < Scene.ENEMY_COUNT)
            {
                comboBoxReplacementEnemy.Items.Add($"Insert {name} into empty slot");
            }
            comboBoxReplacementEnemy.ResumeLayout();
            comboBoxReplacementEnemy.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ushort newID = HexParser.NULL_OFFSET_16_BIT;
            int i = comboBoxReplacementEnemy.SelectedIndex - 1;
            if (i == enemyList.Length && enemy != null) //insert into scene
            {
                //get the first empty slot
                for (int j = 0; j < Scene.ENEMY_COUNT; ++j)
                {
                    if (scene.Enemies[j] == null || scene.Enemies[j]?.ModelID == HexParser.NULL_OFFSET_16_BIT)
                    {
                        bool success = scene.ChangeEnemyAtSlot(enemy, attacks, j, false);
                        if (!success)
                        {
                            MessageDialog.ShowWarning("Unable to copy all enemy attacks. There may be errors.");
                        }
                        AddedEnemy = true;
                        break;
                    }
                }
            }
            else //replace enemy in formation
            {
                if (i >= 0) { newID = enemyList[i].ModelID; }

                for (int j = 0; j < Formation.ENEMY_COUNT; ++j)
                {
                    if (formation.EnemyLocations[j].EnemyID == enemyID)
                    {
                        formation.EnemyLocations[j].EnemyID = newID;
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
