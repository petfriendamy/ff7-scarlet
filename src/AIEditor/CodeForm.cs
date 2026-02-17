using System.Data;
using System.ComponentModel;
using FF7Scarlet.Shared;

#pragma warning disable CA1416
namespace FF7Scarlet.AIEditor
{
    public partial class CodeForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Code Code { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CreateNewLabel { get; private set; }

        private OpcodeInfo opcode;
        private CommandInfo? command;
        private Code? param1, param2;
        private FFText? strText;
        private int label = -1, popCount;
        private List<OpcodeInfo> currList = new();
        private Script parentScript;
        private bool loading = true, unsavedChanges = false, jpText;

        public CodeForm(Script script, bool jpText, Code? code = null)
        {
            InitializeComponent();
            parentScript = script;
            this.jpText = jpText;

            //get command list
            comboBoxCommands.BeginUpdate();
            foreach (var command in CommandInfo.COMMAND_LIST)
            {
                comboBoxCommands.Items.Add(command.Description);
            }
            comboBoxCommands.EndUpdate();
            comboBoxOpcodeGroups.SelectedIndex = 0;
            comboBoxOpcodes.SelectedIndex = 0;
            comboBoxCommands.SelectedIndex = 0;

            //fill form with current code info
            if (code == null)
            {
                opcode = currList[0];
                command = CommandInfo.COMMAND_LIST[0];
                Code = command.GenerateCode(script);
                unsavedChanges = true;
            }
            else
            {
                Code = code;
                var op = OpcodeInfo.GetInfo(Code.GetPrimaryOpcode());
                if (op == null) { throw new ArgumentNullException(); }
                else
                {
                    opcode = op;
                    command = CommandInfo.GetInfo(op.Code);
                }
            }

            if (command != null) //known command
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
                            var cb = Code as CodeBlock;
                            if (cb != null)
                            {
                                if (i == 1) { param1 = cb.GetCodeAtPosition(0); }
                                else { param2 = cb.GetCodeAtPosition(1); }
                            }
                            break;
                    }
                    ptype = command.ParameterType2;
                }
                UpdateCommandParameters();

                if (Code is CodeLine) //update manual parameters too
                {
                    var c = Code as CodeLine;
                    if (c != null) { UpdateManualParameters(c); }
                }
            }
            else if (Code is CodeBlock) //unknown command
            {
                command = CommandInfo.GetInfo(0xFF);
                if (command != null)
                {
                    comboBoxCommands.SelectedIndex = CommandInfo.COMMAND_LIST.ToList().IndexOf(command);
                    param1 = Code;
                }
                UpdateCommandParameters();
            }
            else if (Code is CodeLine) //single opcode
            {
                tabControlOptions.SelectedTab = tabPageManual;
                var c = Code as CodeLine;
                if (c != null)
                {
                    UpdateManualParameters(c);
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
                            textbox.Text = strText?.ToString(jpText);
                            break;
                        case ParameterTypes.ReadWrite:
                            if (currParam?.Disassemble(jpText, false) == "01")
                            {
                                textbox.Text = "Write";
                            }
                            else
                            {
                                textbox.Text = "Read";
                            }
                            break;
                        case ParameterTypes.Label:
                            if (label == -1) { textbox.Text = "(New label)"; }
                            else { textbox.Text = label.ToString(); }
                            break;
                        default:
                            textbox.Text = currParam?.Disassemble(jpText, false);
                            break;
                    }
                }
                ptype = command.ParameterType2;
                textbox = textBoxParameter2;
                currParam = param2;
            }
        }

        private void UpdateManualParameters(CodeLine code)
        {
            var op = OpcodeInfo.GetInfo(code.Opcode);
            if (op != null)
            {
                comboBoxOpcodeGroups.SelectedIndex = (int)op.Group;
                comboBoxOpcodes.SelectedIndex = currList.IndexOf(op);

                if (op.ParameterType != ParameterTypes.None && code.Parameter != null)
                {
                    comboBoxManualParameter.Text = code.Parameter.ToString(jpText);
                }
            }
        }

        private void UpdateOpcodesList()
        {
            int selected = comboBoxOpcodeGroups.SelectedIndex;
            if (Enum.IsDefined((OpcodeGroups)selected))
            {
                var currGroup = (OpcodeGroups)selected;
                currList =
                    (from o in OpcodeInfo.OPCODE_LIST
                     where o.Group == currGroup
                     select o).ToList();

                comboBoxOpcodes.BeginUpdate();
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
                comboBoxOpcodes.EndUpdate();
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
            var textBox = textBoxParameter1;
            if (pos == 1)
            {
                textBox = textBoxParameter2;
            }

            //check if parameter is a string or a label
            ParameterTypes type = ParameterTypes.Other;

            if (opcode.EnumValue == Opcodes.DebugMessage)
            {
                if (pos == 0)
                {
                    param = new CodeLine(Code.Parent, Code.GetHeader(), (byte)Opcodes.PushConst01, new FFText(Code.GetPopCount()));
                }
                else
                {
                    param = new CodeLine(Code.Parent, Code.GetHeader(), (byte)Opcodes.ShowMessage, strText);
                    type = ParameterTypes.String;
                }
            }
            else if (command != null)
            {
                Code? currP;
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
                if (type == ParameterTypes.ReadWrite) //just flip the bit if it's a boolean
                {
                    var p = currP as CodeLine;
                    if (p != null)
                    {
                        if (p.Parameter?.ToInt() == 1)
                        {
                            p.Parameter = new FFText("00");
                            textBox.Text = "Read";
                        }
                        else
                        {
                            p.Parameter = new FFText("01");
                            textBox.Text = "Write";
                        }
                    }
                    return;
                }
                else if (type == ParameterTypes.String)
                {
                    param = new CodeLine(Code.Parent, Code.GetHeader(), (byte)Opcodes.ShowMessage, strText);
                }
                else if (type == ParameterTypes.Label)
                {
                    param = new CodeLine(Code.Parent, Code.GetHeader(), (byte)Opcodes.Label, new FFText(label.ToString("X4")));
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
            try
            {
                using (var paramForm = new ParameterForm(parentScript, temp, opcode.EnumValue, type, jpText))
                {
                    if (paramForm.ShowDialog() == DialogResult.OK)
                    {
                        if (type == ParameterTypes.String)
                        {
                            var p = paramForm.Code[0].GetParameter();
                            if (p != null)
                            {
                                textBox.Text = p.ToString(jpText);
                                comboBoxManualParameter.Text = textBox.Text;
                                strText = p;
                            }

                        }
                        else if (type == ParameterTypes.Label)
                        {
                            var p = paramForm.Code[0].GetParameter();
                            if (p == null) //new label
                            {
                                string text = "(New label)";
                                textBox.Text = text;
                                label = -1;
                            }
                            else //existing label
                            {
                                int pint = p.ToInt();
                                textBox.Text = pint.ToString();
                                comboBoxManualParameter.Text = textBox.Text;
                                label = pint;
                            }
                        }
                        else
                        {
                            Code test;
                            if (paramForm.Code.Count > 1)
                            {
                                test = new CodeBlock(parentScript, paramForm.Code);
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
                                    textBoxParameter1.Text = test.Disassemble(jpText, false);
                                }
                                else
                                {
                                    param2 = test;
                                    textBoxParameter2.Text = test.Disassemble(jpText, false);
                                }
                            }
                            else
                            {
                                param1 = test;
                                comboBoxManualParameter.Text = test.Disassemble(jpText, false);
                            }
                        }
                        unsavedChanges = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex, "LoadParameter");
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
                int temp;
                if (int.TryParse(text, out temp))
                {
                    return new FFText(temp.ToString("X4"));
                }
                throw new FormatException("Invalid label.");
            }
            return new FFText(text, isJapanese: jpText && type == ParameterTypes.String);
        }

        private int GetNewLabel()
        {
            var labels = parentScript.GetLabels().ToList();
            int newLabel = labels.Count;
            while (labels.Contains(newLabel))
            {
                newLabel++;
            }
            return newLabel;
        }

        private void comboBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                UpdateCommandParameters();
                unsavedChanges = true;
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
            if (unsavedChanges)
            {
                try
                {
                    FFText? param;
                    if (tabControlOptions.SelectedTab == tabPageGenerate)
                    {
                        if (command != null) //command
                        {
                            if ((byte)command.Opcode == 0xFF) //unknown block
                            {
                                if (param1 == null)
                                {
                                    throw new ArgumentNullException("Parameter was null.");
                                }
                                else { Code = param1; }
                            }
                            else if (command.OpcodeInfo?.PopCount > 0) //two parameters
                            {
                                if (param1 == null)
                                {
                                    throw new ArgumentNullException("Parameter was null.");
                                }
                                else
                                {
                                    FFText? p = null;
                                    if (command.ParameterType2 == ParameterTypes.Label)
                                    {
                                        if (label == -1) //new label
                                        {
                                            param = new FFText(GetNewLabel().ToString("X4"));
                                            CreateNewLabel = true;
                                        }
                                        else
                                        {
                                            p = new FFText(label.ToString("X4"));
                                        }
                                    }
                                    var cb = new CodeBlock(parentScript, new CodeLine(parentScript,
                                        HexParser.NULL_OFFSET_16_BIT, (byte)command.Opcode, p));
                                    if (param2 != null) { cb.AddToTop(param2); }

                                    cb.AddToTop(param1);
                                    Code = cb;
                                }
                            }
                            else //one parameter
                            {
                                if (command.ParameterType1 == ParameterTypes.Label && label == -1) //new label
                                {
                                    param = new FFText(GetNewLabel().ToString("X4"));
                                    CreateNewLabel = true;
                                }
                                else
                                {
                                    param = ParseParameter(command.ParameterType1, textBoxParameter1.Text);
                                }
                                Code = new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT,
                                    (byte)command.Opcode, param);
                            }
                        }
                    }
                    else //manual
                    {
                        var op = currList[comboBoxOpcodes.SelectedIndex];
                        param = ParseParameter(op.ParameterType, comboBoxManualParameter.Text);
                        Code = new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT, op.Code, param);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex, "parameter parsing");
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
