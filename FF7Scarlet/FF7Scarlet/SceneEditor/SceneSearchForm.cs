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
    public partial class SceneSearchForm : Form
    {
        public SceneSearchResult? SearchResult { get; private set; }
        public readonly Scene[] scenes;

        public SceneSearchForm(Scene[] sceneList)
        {
            InitializeComponent();
            scenes = sceneList;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageEnemy)
            {
                //find all scenes that have matching enemy names
                var foundScenes = new List<SceneSearchResult>();
                string? currentName;
                for (int i = 0; i < DataManager.SCENE_COUNT; ++i)
                {
                    for (int j = 0; j < Scene.ENEMY_COUNT; ++j)
                    {
                        var enemy = scenes[i].Enemies[j];
                        if (enemy != null)
                        {
                            currentName = enemy.Name.ToString();
                            if (currentName != null)
                            {
                                currentName = currentName.ToLower();
                                if (currentName.Contains(textBoxEnemyName.Text.ToLower()))
                                {
                                    foundScenes.Add(new SceneSearchResult(SearchType.Enemy, i, j, 0));
                                }
                            }
                        }
                    }
                }
                if (foundScenes.Count == 0)
                {
                    MessageBox.Show("No enemies found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (foundScenes.Count == 1)
                {
                    SearchResult = foundScenes[0];
                }
                else
                {
                    var names = new string[foundScenes.Count];
                    for (int i = 0; i < foundScenes.Count; ++i)
                    {
                        var enemy = scenes[foundScenes[i].SceneIndex].Enemies[foundScenes[i].EnemyPosition];
                        if (enemy != null)
                        {
                            var name = enemy.Name.ToString();
                            if (name != null)
                            {
                                names[i] = name;
                            }
                        }
                    }
                    DialogResult result;
                    SceneSearchResult? picked;
                    using (var search = new EnemySearchForm(foundScenes.ToArray(), names))
                    {
                        result = search.ShowDialog();
                        picked = search.SearchResult;
                    }
                    if (result == DialogResult.OK && picked != null)
                    {
                        SearchResult = picked;
                    }
                    else { return; }
                }
            }
            else
            {
                int scene = (int)Math.Floor(numericFormationNumber.Value / Scene.FORMATION_COUNT);
                int formation = (int)numericFormationNumber.Value % Scene.FORMATION_COUNT;
                SearchResult = new SceneSearchResult(SearchType.Formation, scene, 0, formation);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
