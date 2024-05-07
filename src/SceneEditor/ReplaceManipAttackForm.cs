namespace FF7Scarlet.SceneEditor
{
    public partial class ReplaceManipAttackForm : Form
    {
        public int SelectedIndex
        {
            get { return listBoxAttacks.SelectedIndex; }
        }

        public ReplaceManipAttackForm(string[] names)
        {
            InitializeComponent();
            foreach (var name in names)
            {
                listBoxAttacks.Items.Add(name);
            }
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            if (SelectedIndex == -1)
            {
                MessageBox.Show("No attack selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
