using System.Data;
using System.Globalization;
using System.ComponentModel;

namespace FF7Scarlet.AIEditor
{
    public partial class ParameterControl : UserControl
    {
        #region Properties

        private readonly List<OpcodeInfo> operands, modifiers, paramTypes;
        private byte operand = 0xFF, modifier = 0xFF, paramType = 0xFF;
        private bool singleParameter = false, modifyAbove = false, loading = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFirst { get; private set; } = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

            comboBoxOperand.BeginUpdate();
            foreach (var op in operands)
            {
                comboBoxOperand.Items.Add(op.ShortName);
            }
            comboBoxOperand.EndUpdate();

            comboBoxModifiers.BeginUpdate();
            comboBoxModifiers.Items.Add(" ");
            foreach (var op in modifiers)
            {
                comboBoxModifiers.Items.Add(op.ShortName);
            }
            comboBoxModifiers.EndUpdate();
            comboBoxModifiers.SelectedIndex = 0;

            comboBoxType.BeginUpdate();
            foreach (var op in paramTypes)
            {
                comboBoxType.Items.Add(op.ShortName);
            }
            comboBoxType.Items.Add("(Modify above)");
            comboBoxType.EndUpdate();

            comboBoxParameter.BeginUpdate();
            foreach (int gv in Enum.GetValues(typeof(CommonVars.Globals)))
            {
                comboBoxParameter.Items.Add($"{gv:X4} ({(CommonVars.Globals)gv})");
            }

            foreach (int gv in Enum.GetValues(typeof(CommonVars.ActorGlobals)))
            {
                comboBoxParameter.Items.Add($"{gv:X4} ({(CommonVars.ActorGlobals)gv})");
            }
            comboBoxParameter.EndUpdate();
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

        private void SetAsSingle(string param)
        {
            SuspendLayout();

            //move comboboxes over
            int offset = comboBoxType.Location.X - checkBoxEnabled.Location.X,
                x = comboBoxType.Location.X - offset, y = comboBoxType.Location.Y;
            comboBoxType.Location = new Point(x, y);

            x = comboBoxParameter.Location.X - offset;
            comboBoxParameter.Location = new Point(x, y);
            comboBoxParameter.Width += offset;

            //remove extra controls
            comboBoxModifiers.Visible = false;
            comboBoxType.Items.Clear();
            comboBoxType.Items.Add(param);
            comboBoxType.SelectedIndex = 0;
            singleParameter = true;
            PForm?.SetAsSingleParameter(this, offset);

            ResumeLayout();
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
                    SetAsSingle("Label");
                }
                else if (op.ParameterType == ParameterTypes.String || op.ParameterType == ParameterTypes.Debug)
                {
                    SetAsSingle("String");
                    comboBoxParameter.Items.Clear();
                    comboBoxParameter.DropDownHeight = 1;
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

        public void SetLabels(Opcodes code, int[] labels)
        {
            var op = OpcodeInfo.GetInfo(code);
            if (op != null && op.Group == OpcodeGroups.Jump)
            {
                int curr;
                if (int.TryParse(comboBoxParameter.Text, out curr))
                {
                    comboBoxParameter.BeginUpdate();
                    comboBoxParameter.Items.Clear();
                    if (op.EnumValue == Opcodes.Label)
                    {
                        if (curr != -1) { comboBoxParameter.Items.Add(curr); }
                    }
                    else
                    {
                        foreach (var label in labels)
                        {
                            comboBoxParameter.Items.Add(label);
                        }
                    }
                    comboBoxParameter.Items.Add("--Add new label--");
                    comboBoxParameter.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBoxParameter.EndUpdate();
                    int selected = labels.ToList().IndexOf(curr);
                    if (selected < 0) { selected = comboBoxParameter.Items.Count - 1; }
                    comboBoxParameter.SelectedIndex = selected;
                }
            }
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
            if (!loading)
            {
                Operand = operands[comboBoxOperand.SelectedIndex].Code;
            }
        }

        private void comboBoxModifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (comboBoxModifiers.SelectedIndex < 1)
                {
                    Modifier = 0xFF;
                    if (ModifyAbove) { ModifyAbove = false; }
                }
                else
                {
                    Modifier = modifiers[comboBoxModifiers.SelectedIndex - 1].Code;
                }
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
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
        }

        #endregion
    }
}
