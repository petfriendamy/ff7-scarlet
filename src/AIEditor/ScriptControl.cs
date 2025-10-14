using FF7Scarlet.Shared;
using System.ComponentModel;

namespace FF7Scarlet.AIEditor
{
    public partial class ScriptControl : UserControl
    {
        private AIContainer? aiContainer;
        private int selectedScriptIndex = -1;
        private List<Code>? clipboard;

        public event EventHandler? DataChanged, ScriptAdded, ScriptRemoved;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AIContainer? AIContainer
        {
            get { return aiContainer; }
            set
            {
                aiContainer = value;
                DisplayScript(SelectedScriptIndex);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedScriptIndex
        {
            get { return selectedScriptIndex; }
            set
            {
                selectedScriptIndex = value;
                DisplayScript(SelectedScriptIndex);
            }
        }
        public Script? SelectedScript
        {
            get { return AIContainer?.Scripts[SelectedScriptIndex]; }
        }
        private Code? SelectedCode
        {
            get
            {
                if (AIContainer == null || SelectedScript == null || SelectedCodeIndices.Length == 0)
                {
                    return null;
                }
                return SelectedScript.GetCodeAtPosition(SelectedCodeIndices[0]);
            }
        }
        private int[] SelectedCodeIndices
        {
            get
            {
                int count = listBoxCurrScript.SelectedIndices.Count;
                if (count == 0)
                {
                    return Array.Empty<int>();
                }
                else
                {
                    var indices = new List<int>();
                    for (int i = 0; i < count; ++i)
                    {
                        indices.Add(listBoxCurrScript.SelectedIndices[i]);
                    }
                    indices.Sort();
                    return indices.ToArray();
                }
            }
        }

        public bool CodeIsSelected
        {
            get { return SelectedCode != null; }
        }

        public ScriptControl()
        {
            InitializeComponent();
        }

        private void DisplayScript(int scriptID)
        {
            listBoxCurrScript.BeginUpdate();
            listBoxCurrScript.Items.Clear();
            if (scriptID >= 0 && scriptID < Script.SCRIPT_COUNT)
            {
                if (AIContainer == null)
                {
                    listBoxCurrScript.Enabled = false;
                    listBoxCurrScript.Items.Add("(Enemy doesn't exist.)");
                    toolStripScript.Enabled = false;
                }
                else
                {
                    var script = AIContainer.Scripts[scriptID];
                    toolStripScript.Enabled = true;
                    if (script == null || script.IsEmpty)
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
            }
            listBoxCurrScript.EndUpdate();
            UpdateToolStrip();
        }

        private void ReloadScript(int selected)
        {
            DisplayScript(SelectedScriptIndex);
            listBoxCurrScript.SelectedIndex = selected;
        }

        private void UpdateToolStrip()
        {
            foreach (ToolStripItem b in toolStripScript.Items)
            {
                if (b != toolStripButtonAdd && b != toolStripButtonPaste)
                {
                    b.Enabled = SelectedCodeIndices.Length > 0;
                }
            }
        }

        private void SetClipboard(bool cut)
        {
            if (SelectedScript != null)
            {
                //if code is selected, copy it to the clipboard
                if (SelectedCodeIndices.Length > 0)
                {
                    clipboard = new List<Code> { };
                    foreach (int i in SelectedCodeIndices)
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
        }

        public void PasteFromClipboard()
        {
            if (SelectedScript != null && clipboard != null)
            {
                int pos = 0;
                if (SelectedCodeIndices.Length > 0)
                {
                    pos = SelectedCodeIndices[SelectedCodeIndices.Length - 1];
                }

                SelectedScript.InsertCodeAtPosition(pos, clipboard);
                ReloadScript(pos);
                InvokeDataChanged();
            }
        }

        private void RemoveSelectedLines()
        {
            if (SelectedScript != null)
            {
                //get indices as ints
                var indices = SelectedCodeIndices.ToList();
                indices.Reverse();

                //if code is selected, delete it
                if (indices.Count > 0)
                {
                    foreach (int i in indices)
                    {
                        SelectedScript.RemoveCodeAtPosition(i);
                        listBoxCurrScript.Items.RemoveAt(i);
                    }

                    if (listBoxCurrScript.Items.Count == 0)
                    {
                        InvokeScriptRemoved();
                    }
                }
                InvokeDataChanged();
            }
        }

        private void MoveUp()
        {
            if (SelectedCode != null && SelectedScript != null)
            {
                int temp = SelectedCodeIndices[0];
                SelectedScript.MoveCodeUp(temp);
                ReloadScript(temp - 1);
                InvokeDataChanged();
            }
        }

        private void MoveDown()
        {
            if (SelectedCode != null && SelectedScript != null)
            {
                int temp = SelectedCodeIndices[0];
                SelectedScript.MoveCodeDown(temp);
                ReloadScript(temp + 1);
                InvokeDataChanged();
            }
        }

        private void CreateLabelAtPosition(byte opcode, FFText label, int pos)
        {
            if (SelectedScript != null)
            {
                if (opcode != (byte)Opcodes.Label) //don't add the label if it's already been added
                {
                    SelectedScript.InsertCodeAtPosition(pos, new CodeLine(SelectedScript,
                        HexParser.NULL_OFFSET_16_BIT, (byte)Opcodes.Label, label));
                }
                SelectedScript.AddLabel(label.ToInt());
            }
        }

        private void listBoxCurrScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateToolStrip();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            if (AIContainer == null)
            {
                MessageBox.Show("The script container does not exist.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (SelectedScript == null)
            {
                MessageBox.Show("No script selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result;
                Code newCode;
                bool createLabel;

                using (var codeForm = new CodeForm(SelectedScript))
                {
                    result = codeForm.ShowDialog();
                    newCode = codeForm.Code;
                    createLabel = codeForm.CreateNewLabel;
                }

                if (result == DialogResult.OK)
                {
                    int i = 0;
                    if (SelectedScript.IsEmpty)
                    {
                        AIContainer.Scripts[SelectedScriptIndex] = new Script(AIContainer, newCode);
                        listBoxCurrScript.SelectedIndex = 0;
                        InvokeScriptAdded();
                    }
                    else
                    {
                        i = SelectedCodeIndices[0] + 1;
                        SelectedScript.InsertCodeAtPosition(i, newCode);
                    }
                    if (createLabel)
                    {
                        var param = newCode.GetParameter();
                        if (param != null)
                        {
                            CreateLabelAtPosition(newCode.GetPrimaryOpcode(), param, i + 1);
                        }
                    }
                    ReloadScript(i);
                    InvokeDataChanged();
                }
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (AIContainer != null && SelectedScript != null && SelectedCode != null)
            {
                DialogResult result;
                Code newCode;
                bool createLabel;

                using (var codeForm = new CodeForm(SelectedScript, SelectedCode))
                {
                    result = codeForm.ShowDialog();
                    newCode = codeForm.Code;
                    createLabel = codeForm.CreateNewLabel;
                }

                if (result == DialogResult.OK)
                {
                    int i = SelectedCodeIndices[0];
                    newCode.SetParent(SelectedScript);
                    SelectedScript.ReplaceCodeAtPosition(i, newCode);

                    if (createLabel)
                    {
                        var param = newCode.GetParameter();
                        if (param != null)
                        {
                            CreateLabelAtPosition(newCode.GetPrimaryOpcode(), param, i + 1);
                        }
                    }
                    ReloadScript(i);
                    InvokeDataChanged();
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
            PasteFromClipboard();
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
                    case Keys.A:
                        e.SuppressKeyPress = true;
                        for (int i = 0; i < listBoxCurrScript.Items.Count; ++i)
                        {
                            listBoxCurrScript.SetSelected(i, true);
                        }
                        break;
                    case Keys.C:
                        e.SuppressKeyPress = true;
                        SetClipboard(false);
                        break;
                    case Keys.X:
                        e.SuppressKeyPress = true;
                        SetClipboard(true);
                        break;
                    case Keys.V:
                        e.SuppressKeyPress = true;
                        PasteFromClipboard();
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

        private void InvokeDataChanged()
        {
            DataChanged?.Invoke(this, new EventArgs());
        }

        private void InvokeScriptAdded()
        {
            ScriptAdded?.Invoke(this, new EventArgs());
        }

        private void InvokeScriptRemoved()
        {
            ScriptRemoved?.Invoke(this, new EventArgs());
        }
    }
}
