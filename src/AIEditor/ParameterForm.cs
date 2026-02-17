using FF7Scarlet.Shared;
using System.ComponentModel;

#pragma warning disable CA1416
namespace FF7Scarlet.AIEditor
{
    public partial class ParameterForm : Form
    {
        private readonly List<ParameterControl> paramList;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Code> Code { get; private set; }
        private readonly Script parentScript;
        private readonly int xx, yy, offset;
        private readonly ParameterTypes type;
        private bool loading = false, jpText;

        public ParameterForm(Script script, List<Code> code, Opcodes opcode, ParameterTypes type, bool jpText)
        {
            InitializeComponent();
            parentScript = script;
            Code = code;
            this.type = type;
            this.jpText = jpText;

            paramList = new List<ParameterControl> { parameterControl1, parameterControl2 };
            parameterControl1.SetAsFirst();
            foreach (var p in paramList)
            {
                p.SetAsJP(jpText);
            }

            //get position info
            xx = parameterControl1.Location.X;
            yy = parameterControl1.Location.Y;
            offset = parameterControl2.Location.Y - yy;

            SuspendLayout();
            loading = true;
            int i = 0;
            foreach (var c in Code)
            {
                var op = OpcodeInfo.GetInfo(c.GetPrimaryOpcode());
                if (op != null)
                {
                    if (op.IsParameter || op.Group == OpcodeGroups.Jump)
                    {
                        paramList[i].SetCode(c.GetPrimaryOpcode(), c.GetParameter());

                        //add more lines as needed
                        if (i == paramList.Count - 1)
                        {
                            AddParameter();
                        }

                        if (op.Group == OpcodeGroups.Jump)
                        {
                            paramList[0].SetLabels(opcode, script.GetLabels());
                        }
                    }
                    else if (op.IsModifier)
                    {
                        if (i > 0)
                        {
                            if (paramList[i - 1].Modifier != 0xFF) //already has a modifier
                            {
                                paramList[i].SetAsModifier(op.Code);

                                //add more lines as needed
                                if (i == paramList.Count - 1)
                                {
                                    AddParameter();
                                }
                            }
                            else //add modifier to the previous line
                            {
                                i--;
                                paramList[i].Modifier = op.Code;
                            }
                        }
                    }
                    else if (op.IsOperand) //add operator to the previous code block
                    {
                        i--;
                        int j = i;
                        while (j > 0 && paramList[j].Operand != 0xFF) { j--; }
                        paramList[j].SetOperand(op.Code);
                    }
                    ++i;
                }
            }
            ResumeLayout();
            loading = false;
        }

        private void AddParameter()
        {
            SuspendLayout();
            var newLine = new ParameterControl();
            newLine.SetAsJP(jpText);
            newLine.Name = $"parameterControl{paramList.Count}";
            newLine.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            newLine.Size = new Size(parameterControl1.Size.Width, parameterControl1.Size.Height);
            newLine.Location = new Point(xx, yy + (offset * paramList.Count) + panelMain.AutoScrollPosition.Y);
            panelMain.Controls.Add(newLine);
            paramList.Add(newLine);
            if (!loading) { ResumeLayout(); }
        }

        public void UpdateParamList(ParameterControl caller, bool isChecked)
        {
            int pos = paramList.IndexOf(caller);
            if (pos >= 0)
            {
                if (isChecked)
                {
                    for (int i = pos; i > 0; --i)
                    {
                        paramList[i].Checked = true;
                    }

                    //add another line if last
                    if (pos == paramList.Count - 1)
                    {
                        AddParameter();
                    }
                }
                else
                {
                    for (int i = pos; i < paramList.Count; ++i)
                    {
                        paramList[i].Checked = false;
                    }
                }
            }
        }

        public void SetAsSingleParameter(ParameterControl caller, int offset)
        {
            if (caller == parameterControl1)
            {
                SuspendLayout();
                for (int i = 1; i < paramList.Count; ++i)
                {
                    paramList[i].Visible = false;
                }
                labelOperand.Visible = false;
                labelModifier.Visible = false;
                int x = labelType.Location.X - offset, y = labelType.Location.Y;
                labelType.Location = new Point(x, y);
                x = labelParameter.Location.X - offset;
                labelParameter.Location = new Point(x, y);
                ResumeLayout();
            }
        }

        private CodeLine ValidateCode(byte opcode, byte[] parameter)
        {
            //check if opcode exists
            var op = OpcodeInfo.GetInfo(opcode);
            if (op == null)
            {
                throw new ArgumentNullException("Opcode is invalid.");
            }

            //test if the parameter is valid
            bool test = ParameterInfo.IsValid(op.ParameterType, parameter);
            if (!test)
            {
                if (op.EnumValue == Opcodes.Label) //assume this is a new label
                {
                    return new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT, opcode);
                }
                else
                {
                    throw new ArgumentException("Parameter is invalid.");
                }
            }
            return new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT, opcode, parameter);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try //convert code back into a proper script
            {
                if (type == ParameterTypes.String) //is a string
                {
                    Code = new List<Code> {
                        ValidateCode((byte)Opcodes.ShowMessage, paramList[0].Parameter)
                    };
                }
                else if (type == ParameterTypes.Label) //is a label
                {
                    Code = new List<Code>
                    {
                        ValidateCode((byte)Opcodes.Label, paramList[0].Parameter)
                    };
                }
                else
                {
                    var firstParse = new List<CodeLine> { };
                    OpcodeInfo? operand = null;
                    foreach (var p in paramList)
                    {
                        if (p.Checked || p.IsFirst)
                        {
                            if (p.ModifyAbove) //is a modifier
                            {
                                firstParse.Add(new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT,
                                        p.Modifier));
                            }
                            else //is other code
                            {
                                var op = OpcodeInfo.GetInfo(p.Operand); //check for logical operands
                                if (op != null && op.Group == OpcodeGroups.Logical)
                                {
                                    if (operand != null) //add the previously saved operand
                                    {
                                        firstParse.Add(new CodeLine(parentScript,
                                            HexParser.NULL_OFFSET_16_BIT, operand.Code));
                                    }
                                    operand = op;
                                }

                                firstParse.Add(ValidateCode(p.ParamType, p.Parameter));

                                //add modifier
                                if (p.Modifier != 0xFF)
                                {
                                    firstParse.Add(new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT,
                                        p.Modifier));
                                }

                                //add non-logical operands
                                if (!p.IsFirst && op != null && op.Group != OpcodeGroups.Logical)
                                {
                                    firstParse.Add(new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT,
                                        p.Operand));
                                }
                            }
                        }
                    }
                    if (operand != null) //if there's a saved operand, add it to the end of the block
                    {
                        firstParse.Add(new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT, operand.Code));
                    }

                    //get the parsed code block
                    Code = Script.GetParsedCode(firstParse, parentScript);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
