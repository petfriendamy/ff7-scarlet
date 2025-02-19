using FF7Scarlet.AIEditor;
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SceneSearchResult? SearchResult { get; private set; }
        public readonly Scene[] scenes;
        private readonly Opcodes[] opcodes;

        public SceneSearchForm(Scene[] sceneList)
        {
            InitializeComponent();
            scenes = sceneList;
            opcodes = Enum.GetValues<Opcodes>();

            foreach (var o in opcodes)
            {
                if (o != Opcodes.Label)
                {
                    string? name = Enum.GetName(o);
                    comboBoxEnemyOpcode.Items.Add(name == null ? "?" : name);
                    comboBoxFormationOpcode.Items.Add(name == null ? "?" : name);
                }
            }
            textBoxEnemyName.Select();
            comboBoxEnemyOpcode.SelectedIndex = 0;
            comboBoxFormationOpcode.SelectedIndex = 0;
        }

        private SearchType SearchType
        {
            get
            {
                if (tabControlMain.SelectedTab == tabPageEnemy)
                {
                    return SearchType.Enemy;
                }
                else { return SearchType.Formation; }
            }
        }

        private void checkBoxEnemyName_CheckedChanged(object sender, EventArgs e)
        {
            textBoxEnemyName.Enabled = checkBoxEnemyName.Checked;
        }

        private void checkBoxEnemyOpcode_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEnemyOpcode.Enabled = checkBoxEnemyOpcode.Checked;
        }

        private void checkBoxFormationNumber_CheckedChanged(object sender, EventArgs e)
        {
            numericFormationNumber.Enabled = checkBoxFormationNumber.Checked;
        }

        private void checkBoxFormationOpcode_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxFormationOpcode.Enabled = checkBoxFormationOpcode.Checked;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            bool found = false;
            var foundScenes = new List<SceneSearchResult>();

            if (SearchType == SearchType.Enemy) //enemy
            {
                string? currentName;
                Opcodes op = opcodes[comboBoxEnemyOpcode.SelectedIndex];

                for (int i = 0; i < Scene.SCENE_COUNT; ++i)
                {
                    //check if A.I. scripts have been loaded
                    if (checkBoxEnemyOpcode.Checked && !scenes[i].ScriptsLoaded)
                    {
                        scenes[i].ParseAIScripts();
                    }

                    for (int j = 0; j < Scene.ENEMY_COUNT; ++j)
                    {
                        var enemy = scenes[i].Enemies[j];
                        if (enemy != null)
                        {
                            found = false;
                            if (checkBoxEnemyName.Checked) //find enemy name
                            {
                                currentName = enemy.Name.ToString();
                                if (currentName != null)
                                {
                                    currentName = currentName.ToLower();
                                    if (currentName.Contains(textBoxEnemyName.Text.ToLower()))
                                    {
                                        found = true;
                                    }
                                }
                            }

                            if (checkBoxEnemyOpcode.Checked) //find opcodes
                            {
                                if (!(checkBoxEnemyName.Checked && !found))
                                {
                                    found = (enemy.HasOpcode(op) >= 0);
                                }
                            }

                            if (found) //find first (and usually only) formation with this enemy in it
                            {
                                found = false;
                                int formation = 0;
                                for (int n = 0; n < Scene.FORMATION_COUNT && !found; ++n)
                                {
                                    foreach (var fe in scenes[i].Formations[n].EnemyLocations)
                                    {
                                        if (fe.EnemyID == enemy.ModelID)
                                        {
                                            formation = n;
                                            found = true;
                                            break;
                                        }
                                    }
                                }
                                foundScenes.Add(new SceneSearchResult(SearchType.Enemy, i, j, formation));
                            }
                        }
                    }
                }
            }
            else //formation
            {
                SceneSearchResult? temp = null;

                if (checkBoxFormationNumber.Checked) //find a specific formation number
                {
                    int scene = (int)Math.Floor(numericFormationNumber.Value / Scene.FORMATION_COUNT);
                    int formation = (int)numericFormationNumber.Value % Scene.FORMATION_COUNT;
                    temp = new SceneSearchResult(SearchType.Formation, scene, 0, formation);
                }

                if (checkBoxFormationOpcode.Checked) //find opcodes
                {
                    Opcodes op = opcodes[comboBoxFormationOpcode.SelectedIndex];

                    if (temp != null) //checking if the specified formation has this opcode
                    {
                        if (!scenes[temp.SceneIndex].ScriptsLoaded)
                        {
                            scenes[temp.SceneIndex].ParseAIScripts();
                        }

                        if (scenes[temp.SceneIndex].Formations[temp.FormationPosition].HasOpcode(op) < 0)
                        {
                            temp = null;
                        }
                    }
                    else //searching for formations with this opcode
                    {
                        for (int i = 0; i < Scene.SCENE_COUNT; ++i)
                        {
                            if (!scenes[i].ScriptsLoaded)
                            {
                                scenes[i].ParseAIScripts();
                            }

                            for (int j = 0; j < Scene.FORMATION_COUNT; ++j)
                            {
                                if (scenes[i].Formations[j].HasOpcode(op) >= 0)
                                {
                                    foundScenes.Add(new SceneSearchResult(SearchType.Formation, i, 0, j));
                                }
                            }
                        }
                    }

                    if (temp != null) //add the scene if valid
                    {
                        foundScenes.Add(temp);
                    }
                }
            }
            //check if there were any results
            if (foundScenes.Count == 0)
            {
                MessageBox.Show("No results found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (foundScenes.Count == 1)
            {
                MessageBox.Show("1 result found.", "Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SearchResult = foundScenes[0];
            }
            else
            {
                var names = new string[foundScenes.Count];
                for (int i = 0; i < foundScenes.Count; ++i)
                {
                    if (SearchType == SearchType.Enemy)
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
                    else
                    {
                        int formation = (Scene.FORMATION_COUNT * foundScenes[i].SceneIndex) + foundScenes[i].FormationPosition;
                        names[i] = $"Formation #{formation}";
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
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
