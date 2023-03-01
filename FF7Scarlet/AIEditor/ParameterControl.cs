using System.Data;
using System.Globalization;
using System.Linq.Expressions;

namespace FF7Scarlet.AIEditor
{
    public partial class ParameterControl : UserControl
    {
        #region Properties

        private readonly List<OpcodeInfo> operands, modifiers, paramTypes;
        private byte operand = 0xFF, modifier = 0xFF, paramType = 0xFF;
        private bool singleParameter = false, modifyAbove = false, loading = true;

        public byte Operand
        {
            get
            {
                if (IsFirst) { return 0xFF; }
                else if (!singleParameter && comboBoxOperand.SelectedIndex != -1)
                {
                    return operands[comboBoxOperand.SelectedIndex].Code;
                }
                else { return operand; }
            }
            set
            {
                operand = value;
            }
        }
        public byte Modifier
        {
            get { return modifier; }
            set
            {
                var op = OpcodeInfo.GetInfo(value);
                if (op != null && op.IsModifier)
                {
                    modifier = value;
                    comboBoxModifiers.SelectedIndex = modifiers.IndexOf(op) + 1;
                }
                else
                {
                    modifier = 0xFF;
                    comboBoxModifiers.SelectedIndex = 0;
                }
            }
        }
        public byte ParamType
        {
            get
            {
                if (ModifyAbove)
                {
                    return 0xFF;
                }
                else if (!singleParameter && comboBoxType.SelectedIndex != -1)
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
                var op = OpcodeInfo.GetInfo(ParamType);
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
        public bool ModifyAbove
        {
            get { return modifyAbove; }
            private set
            {
                modifyAbove = value;
                comboBoxParameter.Enabled = !value;
                if (modifyAbove && comboBoxModifiers.SelectedIndex < 1)
                {
                    comboBoxModifiers.SelectedIndex = 1;
                }
            }
        }
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

        #endregion

        #region Constructor

        public ParameterControl()
        {
            InitializeComponent();
            operands = (from op in OpcodeInfo.OPCODE_LIST
                        where op.IsOperand && !op.IsModifier
                        select op).ToList();

            modifiers = (from op in OpcodeInfo.OPCODE_LIST
                         where op.IsModifier
                         select op).ToList();

            paramTypes = (from op in OpcodeInfo.OPCODE_LIST
                          where (op.IsParameter && op.Group != OpcodeGroups.Jump
                            && op.ParameterType != ParameterTypes.String
                            && op.ParameterType != ParameterTypes.Debug)
                          select op).ToList();

            foreach (var op in operands)
            {
                comboBoxOperand.Items.Add(op.ShortName);
            }
            comboBoxModifiers.Items.Add(" ");
            foreach (var op in modifiers)
            {
                comboBoxModifiers.Items.Add(op.ShortName);
            }
            comboBoxModifiers.SelectedIndex = 0;
            foreach (var op in paramTypes)
            {
                comboBoxType.Items.Add(op.ShortName);
            }
            comboBoxType.Items.Add("(Modify above)");

            foreach (int gv in Enum.GetValues(typeof(CommonVars.Globals)))
            {
                comboBoxParameter.Items.Add($"{gv:X4} ({(CommonVars.Globals)gv})");
            }

            foreach (int gv in Enum.GetValues(typeof(CommonVars.ActorGlobals)))
            {
                comboBoxParameter.Items.Add($"{gv:X4} ({(CommonVars.ActorGlobals)gv})");
            }
            loading = false;
        }

        #endregion

        #region User Methods

        public void SetAsFirst()
        {
            checkBoxEnabled.Checked = true;
            checkBoxEnabled.Visible = comboBoxOperand.Visible = false;
            IsFirst = true;
        }

        public void SetCode(byte paramType, FFText? parameter, bool isModifier = false)
        {
            loading = true;
            ParamType = paramType;
            Parameter = parameter;
            Modifier = 0xFF;
            ModifyAbove = isModifier;

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
            loading = false;
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

        public void SetAsModifier(byte opcode)
        {
            Modifier = opcode;
            comboBoxType.SelectedIndex = paramTypes.Count;
            checkBoxEnabled.Checked = true;
        }

        #endregion

        #region Event Methods

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBoxEnabled.Checked;
            comboBoxModifiers.Enabled = comboBoxType.Enabled = check;
            if (!ModifyAbove)
            {
                comboBoxOperand.Enabled = comboBoxParameter.Enabled = check;
            }
            PForm?.UpdateParamList(this, check);
        }

        private void comboBoxOperand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Operand = operands[comboBoxOperand.SelectedIndex].Code;
        }

        private void comboBoxModifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModifiers.SelectedIndex < 1)
            {
                modifier = 0xFF;
                if (ModifyAbove) { ModifyAbove = false; }
            }
            else
            {
                modifier = modifiers[comboBoxModifiers.SelectedIndex - 1].Code;
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex >= paramTypes.Count)
            {
                ModifyAbove = true;
            }
            else
            {
                ParamType = (byte)paramTypes[comboBoxType.SelectedIndex].ParameterType;
                ModifyAbove = false;
            }
        }

        #endregion
    }
}
