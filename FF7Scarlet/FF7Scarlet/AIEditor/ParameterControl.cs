using System.Data;
using System.Globalization;

namespace FF7Scarlet.AIEditor
{
    public partial class ParameterControl : UserControl
    {
        private int operand = -1;
        private byte paramType = 0xFF;
        private bool singleParameter = false;
        public int Operand
        {
            get
            {
                if (IsFirst) { return -1; }
                else if (!singleParameter && comboBoxOperand.SelectedIndex != -1)
                {
                    return operands[comboBoxOperand.SelectedIndex].Code;
                }
                else { return operand; }
            }
            private set
            {
                operand = value;
            }
        }
        public byte ParamType
        {
            get
            {
                if (!singleParameter && comboBoxType.SelectedIndex != -1)
                {
                    return paramTypes[comboBoxType.SelectedIndex].Code;
                }
                else { return paramType; }
            }
            private set
            {
                paramType = value;
            }
        }
        public FFText? Parameter
        {
            get
            {
                var op = OpcodeInfo.GetInfo(paramType);
                if (op == null) { return null; }

                var type = op.ParameterType;
                if (type == ParameterTypes.Label)
                {
                    ushort temp;
                    bool test = ushort.TryParse(comboBoxParameter.Text, out temp);
                    if (test) { return new FFText(temp.ToString("X4")); }
                    else { return null; }
                }
                else if (type != ParameterTypes.String && type != ParameterTypes.Debug)
                {
                    var temp = comboBoxParameter.Text.Split(' '); //ignore variable names
                    return new FFText(temp[0]);
                }
                return new FFText(comboBoxParameter.Text);
            }
            private set
            {
                comboBoxParameter.Text = value?.ToString();
            }
        }
        public bool IsFirst { get; private set; } = false;
        public bool Checked
        {
            get { return checkBoxEnabled.Checked; }
            set { checkBoxEnabled.Checked = value; }
        }
        private ParameterForm? PForm
        {
            get
            {
                if (Parent?.Parent is ParameterForm)
                {
                    return Parent.Parent as ParameterForm;
                }
                return null;
            }
        }

        private readonly List<OpcodeInfo> operands, paramTypes;

        public ParameterControl()
        {
            InitializeComponent();
            operands = (from op in OpcodeInfo.OPCODE_LIST
                        where op.IsOperand
                        select op).ToList();

            paramTypes = (from op in OpcodeInfo.OPCODE_LIST
                          where op.IsParameter && op.Group != OpcodeGroups.Jump
                            && op.ParameterType != ParameterTypes.String
                          select op).ToList();

            foreach (var op in operands)
            {
                comboBoxOperand.Items.Add(op.ShortName);
            }

            foreach (var op in paramTypes)
            {
                comboBoxType.Items.Add(op.ShortName);
            }

            foreach (int gv in Enum.GetValues(typeof(CommonVars.Globals)))
            {
                comboBoxParameter.Items.Add($"{gv:X4} ({(CommonVars.Globals)gv})");
            }

            foreach (int gv in Enum.GetValues(typeof(CommonVars.ActorGlobals)))
            {
                comboBoxParameter.Items.Add($"{gv:X4} ({(CommonVars.ActorGlobals)gv})");
            }
        }

        public void SetAsFirst()
        {
            checkBoxEnabled.Checked = true;
            checkBoxEnabled.Visible = comboBoxOperand.Visible = false;
            IsFirst = true;
        }

        public void SetCode(byte paramType, FFText? parameter)
        {
            ParamType = paramType;
            Parameter = parameter;

            var op = OpcodeInfo.GetInfo(paramType);
            if (op != null)
            {
                //check what type of parameter it is and adjust settings appropriately
                if (op.Group == OpcodeGroups.Jump)
                {
                    comboBoxType.Items.Clear();
                    comboBoxType.Items.Add("Label");
                    comboBoxType.SelectedIndex = 0;
                    comboBoxParameter.Items.Clear();
                    comboBoxParameter.DropDownHeight = 1;
                    singleParameter = true;
                    PForm?.SetAsSingleParameter(this);
                }
                else if (op.ParameterType == ParameterTypes.String || op.ParameterType == ParameterTypes.Debug)
                {
                    comboBoxType.Items.Clear();
                    comboBoxType.Items.Add("String");
                    comboBoxType.SelectedIndex = 0;
                    comboBoxParameter.Items.Clear();
                    comboBoxParameter.DropDownHeight = 1;
                    singleParameter = true;
                    PForm?.SetAsSingleParameter(this);
                }
                else if (paramTypes.Contains(op))
                {
                    comboBoxType.SelectedIndex = paramTypes.IndexOf(op);
                }

                //set text in parameter textbox
                if (parameter != null)
                {
                    if (op.Group == OpcodeGroups.Jump)
                    {
                        comboBoxParameter.Text = parameter.ToInt().ToString();
                    }
                    else
                    {
                        comboBoxParameter.Text = parameter.ToString();
                    }

                    //add common variables to the dropdown list
                    if (op.ParameterType != ParameterTypes.String && op.ParameterType != ParameterTypes.Debug)
                    {
                        var str = parameter.ToString();
                        if (str != null)
                        {
                            var temp = int.Parse(str, NumberStyles.HexNumber);
                            if (Enum.IsDefined(typeof(CommonVars.Globals), temp))
                            {
                                comboBoxParameter.Text += $" ({(CommonVars.Globals)temp})";
                            }
                            if (Enum.IsDefined(typeof(CommonVars.ActorGlobals), temp))
                            {
                                comboBoxParameter.Text += $" ({(CommonVars.ActorGlobals)temp})";
                            }
                        }
                    }
                }
                checkBoxEnabled.Checked = true;
            }
        }

        public void SetOperand(byte operand)
        {
            var op = OpcodeInfo.GetInfo(operand);
            if (op != null)
            {
                if (operands.Contains(op))
                {
                    comboBoxOperand.SelectedIndex = operands.IndexOf(op);
                }
            }
        }

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxOperand.Enabled = comboBoxType.Enabled = comboBoxParameter.Enabled = checkBoxEnabled.Checked;
            PForm?.UpdateParamList(this, checkBoxEnabled.Checked);
        }
    }
}
