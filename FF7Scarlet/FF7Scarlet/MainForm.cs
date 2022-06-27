using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet
{
    public partial class MainForm : Form
    {
        private const int SCRIPT_NUMBER = 16;
        private Scene currScene;
        private readonly string[] SCRIPT_LIST = new string[SCRIPT_NUMBER]
        {
            "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter",
            "Magic Counter", "Battle Victory", "Pre-Action Setup", "Custom Event 1",
            "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5",
            "Custom Event 6", "Custom Event 7", "Custom Event 8"
        };
        private List<Code> clipboard;
        private bool loading = false, unsavedChanges = false;

        private Enemy SelectedEnemy
        {
            get { return currScene.GetEnemyByNumber(SelectedEnemyIndex); }
        }
        private int SelectedEnemyIndex
        {
            get { return listBoxEnemies.SelectedIndex + 1; }
        }
        private Script SelectedScript
        {
            get
            {
                if (SelectedEnemy == null) { return null; }
                return SelectedEnemy.GetScriptAtPosition(SelectedScriptIndex);
            }
        }
        private int SelectedScriptIndex
        {
            get { return listBoxScripts.SelectedIndex; }
        }
        private Code SelectedCode
        {
            get
            {
                if (SelectedEnemy == null || SelectedScript == null) { return null; }
                return SelectedScript.GetCodeAtPosition(SelectedCodeIndex);
            }
        }
        private int SelectedCodeIndex
        {
            get { return listBoxCurrScript.SelectedIndex; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string file;

            using (var loadFile = new OpenFileDialog())
            {
                loadFile.Filter = "Scene files|scene.*.bin";
                result = loadFile.ShowDialog();
                file = loadFile.FileName;
            }

            if (result == DialogResult.OK)
            {
                if (File.Exists(file))
                {
                    currScene = new Scene(file);

                    listBoxEnemies.Items.Clear();
                    if (currScene.GetEnemyByNumber(1) != null)
                    {
                        listBoxEnemies.Items.Add(currScene.GetEnemyByNumber(1).Name.ToString());
                    }
                    if (currScene.GetEnemyByNumber(2) != null)
                    {
                        listBoxEnemies.Items.Add(currScene.GetEnemyByNumber(2).Name.ToString());
                    }
                    if (currScene.GetEnemyByNumber(3) != null)
                    {
                        listBoxEnemies.Items.Add(currScene.GetEnemyByNumber(3).Name.ToString());
                    }

                    //no enemies found
                    if (listBoxEnemies.Items.Count == 0)
                    {
                        MessageBox.Show("This scene file is empty.", "No enemies found", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        loading = true;
                        listBoxEnemies.SelectedIndex = 0;
                        listBoxScripts.Enabled = true;
                        listBoxScripts.SelectedIndex = 0;

                        UpdateScripts(1);
                        DisplayScript(1, 0);
                        loading = false;
                    }
                }
            }
        }

        private void UpdateScripts(int selectedEnemy)
        {
            Enemy enemy = currScene.GetEnemyByNumber(selectedEnemy);
            if (enemy != null)
            {
                for (int i = 0; i < SCRIPT_NUMBER; ++i)
                {
                    listBoxScripts.Items[i] = SCRIPT_LIST[i];
                    if (enemy.GetScriptAtPosition(i) != null)
                    {
                        if (!enemy.GetScriptAtPosition(i).IsEmpty)
                        {
                            listBoxScripts.Items[i] += "*";
                        }
                    }
                }
            }
            
        }

        private void DisplayScript(int enemyID, int scriptID)
        {
            var enemy = currScene.GetEnemyByNumber(enemyID);
            if (enemy == null)
            {
                throw new ArgumentNullException("Enemy doesn't exist.");
            }
            var script = enemy.GetScriptAtPosition(scriptID);
            toolStripScript.Enabled = true;
            listBoxCurrScript.Items.Clear();
            if (script == null)
            {
                listBoxCurrScript.Enabled = false;
                listBoxCurrScript.Items.Add("(Script is empty)");
            }
            else
            {
                listBoxCurrScript.Enabled = true;
                foreach (var line in script.Disassemble())
                {
                    listBoxCurrScript.Items.Add(line);
                }
            }
        }

        private void SetClipboard(bool cut)
        {
            //get indices as ints
            var indices = new List<int> { };
            foreach (int i in listBoxCurrScript.SelectedIndices)
            {
                indices.Add(i);
            }
            indices.Sort();

            //if code is selected, copy it to the clipboard
            if (indices.Count > 0)
            {
                clipboard = new List<Code> { };
                foreach (int i in indices)
                {
                    clipboard.Add(SelectedScript.GetCodeAtPosition(i));
                }

                if (cut) //remove code from the script
                {
                    RemoveSelectedLines();
                }
                toolStripButtonPaste.Enabled = true;
            }
        }

        private void RemoveSelectedLines()
        {
            //get indices as ints
            var indices = new List<int> { };
            foreach (int i in listBoxCurrScript.SelectedIndices)
            {
                indices.Add(i);
            }
            indices.Sort();
            indices.Reverse();

            //if code is selected, telete it
            if (indices.Count > 0)
            {
                foreach (int i in indices)
                {
                    SelectedScript.RemoveCodeAtPosition(i);
                    listBoxCurrScript.Items.RemoveAt(i);
                }
                if (listBoxCurrScript.Items.Count == 0)
                {
                    UpdateScripts(SelectedEnemyIndex);
                }
            }
            unsavedChanges = true;
        }

        private void MoveUp()
        {
            if (SelectedCode != null)
            {
                int temp = SelectedCodeIndex;
                loading = true;
                SelectedScript.MoveCodeUp(temp);
                DisplayScript(SelectedEnemyIndex, SelectedScriptIndex);
                listBoxCurrScript.SelectedIndex = temp - 1;
                loading = false;
                unsavedChanges = true;
            }
        }

        private void MoveDown()
        {
            if (SelectedCode != null)
            {
                int temp = SelectedCodeIndex;
                loading = true;
                SelectedScript.MoveCodeDown(temp);
                DisplayScript(SelectedEnemyIndex, SelectedScriptIndex);
                listBoxCurrScript.SelectedIndex = temp + 1;
                loading = false;
                unsavedChanges = true;
            }
        }

        private void listBoxEnemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                UpdateScripts(SelectedEnemyIndex);
                DisplayScript(SelectedEnemyIndex, SelectedScriptIndex);
            }
        }

        private void listBoxScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                DisplayScript(SelectedEnemyIndex, SelectedScriptIndex);
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            using (var codeForm = new CodeForm())
            {
                codeForm.ShowDialog();
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (SelectedCode != null)
            {
                using (var codeForm = new CodeForm(SelectedCode))
                {
                    codeForm.ShowDialog();
                }
            }
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            SetClipboard(true);
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            SetClipboard(false);
        }

        private void toolStripButtonPaste_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonMoveUp_Click(object sender, EventArgs e)
        {
            MoveUp();
        }

        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            MoveDown();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            RemoveSelectedLines();
        }

        private void listBoxCurrScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        SetClipboard(false);
                        break;
                    case Keys.X:
                        SetClipboard(true);
                        break;
                    case Keys.V:
                        //to add
                        break;
                    case Keys.Up:
                        e.SuppressKeyPress = true;
                        MoveUp();
                        break;
                    case Keys.Down:
                        e.SuppressKeyPress = true;
                        MoveDown();
                        break;
                }
            }
            else if (e.Modifiers == Keys.None)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    RemoveSelectedLines();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show("There are unsaved changes! Quit anyway?", "Unsaved changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                e.Cancel = result == DialogResult.No;
            }
        }
    }
}
