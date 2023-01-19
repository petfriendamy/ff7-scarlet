using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet
{
    public partial class CodeForm : Form
    {
        public Code Code { get; private set; }
        private OpcodeInfo opcode;
        private CommandInfo command;
        private Code param1, param2;
        private FFText strText;
        private int label, popCount;
        private List<OpcodeInfo> currList;
        private bool loading = true, unsavedChanges = false;

        public CodeForm(Code code = null)
        {
            InitializeComponent();
            Code = code;
        }

        private void CodeForm_Load(object sender, EventArgs e)
        {
            //get command list
            foreach (var command in CommandInfo.COMMAND_LIST)
            {
                comboBoxCommands.Items.Add(command.Description);
            }
            comboBoxOpcodeGroups.SelectedIndex = 0;
            comboBoxOpcodes.SelectedIndex = 0;
            comboBoxCommands.SelectedIndex = 0;

            //fill form with current code info
            if (Code == null)
            {
                opcode = currList[0];
                command = CommandInfo.COMMAND_LIST[0];
            }
            else
            {
                opcode = OpcodeInfo.GetInfo(Code.GetPrimaryOpcode());
                command = CommandInfo.GetInfo(opcode.EnumValue);

                if (command != null)
                {
                    var cb = Code as CodeBlock;
                    comboBoxCommands.SelectedIndex = CommandInfo.COMMAND_LIST.ToList().IndexOf(command);
                    var ptype = command.ParameterType1;
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
                                strText = Code.GetParameter();
                                break;
                            case ParameterTypes.Label:
                                label = Code.GetParameter().ToInt();
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
                else if (Code is CodeLine)
                {
                    var c = Code as CodeLine;
                    var o = OpcodeInfo.GetInfo(c.Opcode);
                    tabControlOptions.SelectedTab = tabPageManual;
                    comboBoxOpcodeGroups.SelectedIndex = (int)o.Group;
                    comboBoxOpcodes.SelectedIndex = currList.IndexOf(o);

                    if (o.ParameterType != ParameterTypes.None)
                    {
                        comboBoxManualParameter.Text = c.Parameter.ToString();
                    }
                }
            }
            loading = false;
        }

        private void UpdateCommandParameters()
        {
            command = CommandInfo.COMMAND_LIST[comboBoxCommands.SelectedIndex];
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
            Code param;

            //check if parameter is a string or not
            bool isString = false;
            if (Code is CodeBlock)
            {
                if (Code.GetPrimaryOpcode() == (int)Opcodes.DebugMessage)
                {
                    if (pos == 0)
                    {
                        param = new CodeLine(Code.Parent, Code.GetHeader(), (int)Opcodes.PushConst01, new FFText(Code.GetPopCount()));
                    }
                    else
                    {
                        param = (Code as CodeBlock).GetCodeAtEnd();
                        isString = true;
                    }
                }
                else
                {
                    param = (Code as CodeBlock).GetCodeAtPosition(pos);
                }
            }
            else
            {
                param = Code;
                if (Code.GetPrimaryOpcode() == (int)Opcodes.ShowMessage)
                {
                    isString = true;
                }
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
                        textBoxParameter1.Text = paramForm.Code[0].GetParameter().ToString();
                        comboBoxManualParameter.Text = textBoxParameter1.Text;
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

        private FFText ParseParameter(ParameterTypes type, string text)
        {
            if (type == ParameterTypes.None) { return null; }
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("Parameter cannot be empty.");
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
                    FFText param;
                    if (tabControlOptions.SelectedTab == tabPageGenerate)
                    {
                        var cmd = CommandInfo.COMMAND_LIST[comboBoxCommands.SelectedIndex];
                        if (OpcodeInfo.GetInfo(cmd.Opcode).PopCount > 0)
                        {
                            var cb = new CodeBlock(null, new CodeLine(null, -1, (int)cmd.Opcode));
                            if (param2 != null) { cb.AddToTop(param2); }
                            cb.AddToTop(param1);
                            Code = cb;
                        }
                        else
                        {
                            param = ParseParameter(ParameterTypes.Other, textBoxParameter1.Text);
                            Code = new CodeLine(null, -1, (int)cmd.Opcode, param);
                        }
                    }
                    else
                    {
                        var op = currList[comboBoxOpcodes.SelectedIndex];
                        param = ParseParameter(op.ParameterType, comboBoxManualParameter.Text);
                        Code = new CodeLine(null, -1, op.Code, param);
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
