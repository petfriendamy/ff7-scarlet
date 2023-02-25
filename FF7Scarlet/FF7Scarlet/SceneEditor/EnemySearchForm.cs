using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet.SceneEditor
{
    public partial class EnemySearchForm : Form
    {
        public SceneSearchResult? SearchResult { get; private set; }
        private readonly SceneSearchResult[] results;

        public EnemySearchForm(SceneSearchResult[] results, string[] names)
        {
            InitializeComponent();
            this.results = results;
            labelResults.Text = $"{results.Length} results found:";
            for (int i = 0; i < results.Length; ++i)
            {
                listBoxResults.Items.Add($"{names[i]} (scene {results[i].SceneIndex})");
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (listBoxResults.SelectedIndex == -1)
            {
                MessageBox.Show("No result selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SearchResult = results[listBoxResults.SelectedIndex];
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
