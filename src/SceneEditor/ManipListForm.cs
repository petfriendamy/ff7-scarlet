using FF7Scarlet.Shared;

#pragma warning disable CA1416
namespace FF7Scarlet.SceneEditor
{
    public partial class ManipListForm : Form
    {
        public ushort[] ManipList { get; } = new ushort[Enemy.MANIP_ATTACK_COUNT];
        private int attackCount = 0;

        public ManipListForm(Scene scene, int enemyIndex, bool jpText)
        {
            InitializeComponent();

            var enemy = scene.Enemies[enemyIndex];
            if (enemy != null)
            {
                Text = $"{scene.GetEnemyName(enemy.ModelID, jpText)}'s manipulate list";
                Array.Copy(enemy.ManipAttackIDs, ManipList, Enemy.MANIP_ATTACK_COUNT);
                foreach (var atk in ManipList)
                {
                    listBoxAttacks.Items.Add(scene.GetAttackName(atk));
                    if (atk != HexParser.NULL_OFFSET_16_BIT) { attackCount++; }
                }
            }
        }

        private void listBoxAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonMoveUp.Enabled = false;
            buttonMoveDown.Enabled = false;
            buttonRemove.Enabled = false;

            int i = listBoxAttacks.SelectedIndex;
            if (i >= 0 && i < attackCount)
            {
                buttonMoveUp.Enabled = (i > 0);
                buttonMoveDown.Enabled = (i < attackCount - 1);
                buttonRemove.Enabled = true;
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            int i = listBoxAttacks.SelectedIndex;
            if (i > 0 && i < attackCount)
            {
                int j = i - 1;
                ushort tempID = ManipList[i];
                var tempString = listBoxAttacks.Items[i];
                ManipList[i] = ManipList[j];
                listBoxAttacks.Items[i] = listBoxAttacks.Items[j];
                ManipList[j] = tempID;
                listBoxAttacks.Items[j] = tempString;
                listBoxAttacks.SelectedIndex = j;
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            int i = listBoxAttacks.SelectedIndex;
            if (i >= 0 && i < attackCount - 1)
            {
                int j = i + 1;
                ushort tempID = ManipList[i];
                var tempString = listBoxAttacks.Items[i];
                ManipList[i] = ManipList[j];
                listBoxAttacks.Items[i] = listBoxAttacks.Items[j];
                ManipList[j] = tempID;
                listBoxAttacks.Items[j] = tempString;
                listBoxAttacks.SelectedIndex = j;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int i = listBoxAttacks.SelectedIndex;
            if (i >= 0 && i < attackCount)
            {
                var result = MessageBox.Show($"Remove {listBoxAttacks.Items[i]} from the manip list?",
                    "Remove attack?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int j = i + 1; j < Enemy.MANIP_ATTACK_COUNT; ++j) //shift attacks up
                    {
                        ManipList[j - 1] = ManipList[j];
                        listBoxAttacks.Items[j - 1] = listBoxAttacks.Items[j];
                    }
                    ManipList[Enemy.MANIP_ATTACK_COUNT - 1] = HexParser.NULL_OFFSET_16_BIT;
                    listBoxAttacks.Items[Enemy.MANIP_ATTACK_COUNT - 1] = "(none)";
                    attackCount--;
                    listBoxAttacks.SelectedIndex = -1;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
