using System.Data;

namespace FF7Scarlet.AIEditor
{
    public partial class CodeForm : Form
    {
        public Code Code { get; private set; }
        private OpcodeInfo opcode;
        private CommandInfo? command;
        private Code? param1, param2;
        private FFText? strText;
        private int label, popCount;
        private List<OpcodeInfo> currList = new List<OpcodeInfo> { };
        private bool loading = true, unsavedChanges = false;

        public CodeForm(Code? code = null)
        {
            InitializeComponent();

            //get command list
            foreach (var command in CommandInfo.COMMAND_LIST)
            {
                comboBoxCommands.Items.Add(command.Description);
            }
            comboBoxOpcodeGroups.SelectedIndex = 0;
            comboBoxOpcodes.SelectedIndex = 0;
            comboBoxCommands.SelectedIndex = 0;

            //fill form with current code info
            if (code == null)
            {
                opcode = currList[0];
                command = CommandInfo.COMMAND_LIST[0];
                Code = command.GenerateCode();
            }
            else
            {
                Code = code;
                var op = OpcodeInfo.GetInfo(Code.GetPrimaryOpcode());
                if (op == null) { throw new ArgumentNullException(); }
                else
                {
                    opcode = op;
                    command = CommandInfo.GetInfo(op.EnumValue);
                }
            }

            if (command != null)
            {
                var cb = Code as CodeBlock;
                if (cb != null)
                {
                    comboBoxCommands.SelectedIndex = CommandInfo.COMMAND_LIST.ToList().IndexOf(command);
                    var ptype = command.ParameterType1;
                    var param = Code.GetParameter();
                    for (int i = 1; i <= 2; ++i)
                    {
                        switch (ptype)
                        {
                            case ParameterTypes.None:
                                break;
                            case ParameterTypes.Debug:
                                popCount = Code.GetPopCount();
                                break;
                            case ParameterTypes.String:
                                strText = param;
                                break;
                            case ParameterTypes.Label:
                                if (param != null)
                                {
                                    label = param.ToInt();
                                }
                                break;
                            default:
                                if (i == 1) { param1 = cb.GetCodeAtPosition(0); }
                                else { param2 = cb.GetCodeAtPosition(1); }
                                break;
                        }
                        ptype = command.ParameterType2;
                    }
                    UpdateCommandParameters();
                }
            }
            else if (Code is CodeLine)
            {
                var c = Code as CodeLine;
                if (c != null)
                {
                    var o = OpcodeInfo.GetInfo(c.Opcode);
                    if (o != null)
                    {
                        tabControlOptions.SelectedTab = tabPageManual;
                        comboBoxOpcodeGroups.SelectedIndex = (int)o.Group;
                        comboBoxOpcodes.SelectedIndex = currList.IndexOf(o);

                        if (o.ParameterType != ParameterTypes.None && c.Parameter != null)
                        {
                            comboBoxManualParameter.Text = c.Parameter.ToString();
                        }
                    }
                }
            }
            loading = false;
        }

        private void UpdateCommandParameters()
        {
            command = CommandInfo.COMMAND_LIST[comboBoxCommands.SelectedIndex];
            var op = OpcodeInfo.GetInfo(command.Opcode);
            if (op != null) { opcode = op; }
            labelParameter1.Text = command.ParameterName1;
            labelParameter2.Text = command.ParameterName2;
            SetParameterVisibility(1, false);
            SetParameterVisibility(2, false);

            var ptype = command.ParameterType1;
            var textbox = textBoxParameter1;
            var currParam = param1;
            for (int i = 1; i <= 2; ++i)
            {
                if (ptype != ParameterTypes.None)
                {
                    SetParameterVisibility(i, true);
                    switch (ptype)
                    {
                        case ParameterTypes.Debug:
                            textbox.Text = popCount.ToString();
                            break;
                        case ParameterTypes.String:
                            textbox.Text = strText?.ToString();
                            break;
                        case ParameterTypes.Label:
                            textbox.Text = label.ToString();
                            break;
                        default:
                            textbox.Text = currParam?.Disassemble(false);
                            break;
                    }
                }
                ptype = command.ParameterType2;
                textbox = textBoxParameter2;
                currParam = param2;
            }
        }

        private void UpdateOpcodesList()
        {
            int selected = comboBoxOpcodeGroups.SelectedIndex;
            if (Enum.IsDefined(typeof(OpcodeGroups), selected))
            {
                var currGroup = (OpcodeGroups)selected;
                currList =
                    (from o in OpcodeInfo.OPCODE_LIST
                     where o.Group == currGroup
                     select o).ToList();

                comboBoxOpcodes.Items.Clear();
                foreach (var opcode in currList)
                {
                    if (opcode.EnumValue == Opcodes.Label)
                    {
                        comboBoxOpcodes.Items.Add("LABEL");
                    }
                    else
                    {
                        comboBoxOpcodes.Items.Add($"{opcode.Code:X2} -- {opcode.Name}");
                    }
                }
                comboBoxOpcodes.SelectedIndex = 0;
            }
            if (!loading) { unsavedChanges = true; }
        }

        private void UpdateOpcodeParameter()
        {
            int selected = comboBoxOpcodes.SelectedIndex;
            if (selected >= 0 && selected < currList.Count)
            {
                var opcode = currList[selected];
                labelManualParameter.Visible = comboBoxManualParameter.Visible = 
                    (opcode.ParameterType != ParameterTypes.None);
            }
            if (!loading) { unsavedChanges = true; }
        }

        private void SetParameterVisibility(int parameter, bool visible)
        {
            if (parameter == 1)
            {
                labelParameter1.Visible = textBoxParameter1.Visible = buttonParameter1.Visible = visible;
            }
            else if (parameter == 2)
            {
                labelParameter2.Visible = textBoxParameter2.Visible = buttonParameter2.Visible = visible;
            }
        }

        private void EditParameter(int pos)
        {
            Code? param = null;

            //check if parameter is a string or a label
            bool isString = false, isLabel = false;

            if (opcode.EnumValue == Opcodes.DebugMessage)
            {
                if (pos == 0)
                {
                    param = new CodeLine(Code.Parent, Code.GetHeader(), (byte)Opcodes.PushConst01, new FFText(Code.GetPopCount()));
                }
                else
                {
                    param = new CodeLine(Code.Parent, Code.GetHeader(), (byte)Opcodes.ShowMessage, strText);
                    isString = true;
                }
            }
            else if (command != null)
            {
                Code? currP;
                ParameterTypes type;

                if (pos == 0)
                {
                    currP = param1;
                    type = command.ParameterType1;
                }
                else
                {
                    currP = param2;
                    type = command.ParameterType2;
                }
                if (type == ParameterTypes.String)
                {
                    param = new CodeLine(Code.Parent, Code.GetHeader(), (byte)Opcodes.ShowMessage, strText);
                    isString = true;
                }
                else if (type == ParameterTypes.Label)
                {
                    param = new CodeLine(Code.Parent, Code.GetHeader(), (byte)Opcodes.Label, new FFText(label.ToString("X4")));
                    isLabel = true;
                }
                else
                {
                    param = currP;
                }
            }
            if (param == null)
            {
                param = new CodeLine(Code.Parent, Code.GetHeader(), (byte)Opcodes.PushConst01, new FFText("0"));
            }

            //send the parameter to the parameter form for editing
            var temp = new List<Code> { };
            foreach (var p in param.BreakDown())
            {
                temp.Add(p);
            }
            using (var paramForm = new ParameterForm(temp, isString))
            {
                if (paramForm.ShowDialog() == DialogResult.OK)
                {
                    if (isString)
                    {
                        var p = paramForm.Code[0].GetParameter();
                        if (p != null)
                        {
                            if (pos == 0)
                            {
                                textBoxParameter1.Text = p.ToString();
                                comboBoxManualParameter.Text = textBoxParameter1.Text;
                            }
                            else
                            {
                                textBoxParameter2.Text = p.ToString();
                                comboBoxManualParameter.Text = textBoxParameter2.Text;
                            }
                            strText = p;
                        }
                        
                    }
                    else if (isLabel)
                    {
                        var p = paramForm.Code[0].GetParameter();
                        if (p != null)
                        {
                            int pint = p.ToInt();
                            if (pos == 0)
                            {
                                textBoxParameter1.Text = pint.ToString();
                                comboBoxManualParameter.Text = textBoxParameter1.Text;
                            }
                            else
                            {
                                textBoxParameter2.Text = pint.ToString();
                                comboBoxManualParameter.Text = textBoxParameter2.Text;
                            }
                            label = pint;
                        }
                    }
                    else
                    {
                        Code test;
                        if (paramForm.Code.Count > 1)
                        {
                            test = new CodeBlock(null, paramForm.Code);
                        }
                        else
                        {
                            test = paramForm.Code[0];
                        }

                        //update parameter text
                        if (tabControlOptions.SelectedTab == tabPageGenerate)
                        {
                            if (pos == 0)
                            {
                                param1 = test;
                                textBoxParameter1.Text = test.Disassemble(false);
                            }
                            else
                            {
                                param2 = test;
                                textBoxParameter2.Text = test.Disassemble(false);
                            }
                        }
                        else
                        {
                            param1 = test;
                            comboBoxManualParameter.Text = test.Disassemble(false);
                        }
                    }
                    unsavedChanges = true;
                }
            }
        }

        private FFText? ParseParameter(ParameterTypes type, string text)
        {
            if (type == ParameterTypes.None) { return null; }
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("Parameter cannot be empty.");
            }
            if (type == ParameterTypes.Label)
            {
                int temp = int.Parse(text);
                return new FFText(temp.ToString("X4"));
            }
            return new FFText(text);
        }

        private void comboBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                UpdateCommandParameters();
            }
        }

        private void comboBoxOpcodeGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOpcodesList();
        }

        private void comboBoxOpcodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOpcodeParameter();
        }

        private void buttonParameter1_Click(object sender, EventArgs e)
        {
            EditParameter(0);
        }

        private void buttonParameter2_Click(object sender, EventArgs e)
        {
            EditParameter(1);
        }

        private void comboBoxManualParameter_TextUpdate(object sender, EventArgs e)
        {
            if (!loading)
            {
                unsavedChanges = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (unsavedChanges || Code == null)
            {
                try
                {
                    FFText? param;
                    if (tabControlOptions.SelectedTab == tabPageGenerate)
                    {
                        if (command != null && param1 != null)
                        {
                            if (command.OpcodeInfo.PopCount > 0)
                            {
                                FFText? p = null;
                                if (command.ParameterType2 == ParameterTypes.Label)
                                {
                                    p = new FFText(label.ToString("X4"));
                                }
                                var cb = new CodeBlock(null, new CodeLine(null, 0xFFFF, (byte)command.Opcode, p));
                                if (param2 != null) { cb.AddToTop(param2); }

                                cb.AddToTop(param1);
                                Code = cb;
                            }
                            else
                            {
                                param = ParseParameter(command.ParameterType1, textBoxParameter1.Text);
                                Code = new CodeLine(null, 0xFFFF, (byte)command.Opcode, param);
                                
                            }
                        }
                    }
                    else
                    {
                        var op = currList[comboBoxOpcodes.SelectedIndex];
                        param = ParseParameter(op.ParameterType, comboBoxManualParameter.Text);
                        Code = new CodeLine(null, 0xFFFF, op.Code, param);
                    }
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
