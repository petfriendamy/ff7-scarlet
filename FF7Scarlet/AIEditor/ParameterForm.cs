namespace FF7Scarlet.AIEditor
{
    public partial class ParameterForm : Form
    {
        private List<ParameterControl> paramList;
        public List<Code> Code { get; private set; }
        private Script parentScript;
        private int xx, yy, offset;
        private bool isString, loading = false;

        public ParameterForm(Script script, List<Code> code, bool isString)
        {
            InitializeComponent();
            parentScript = script;
            Code = code;
            this.isString = isString;

            paramList = new List<ParameterControl> { parameterControl1, parameterControl2 };
            parameterControl1.SetAsFirst();

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
                    else if (op.IsOperand) //add operator to the previous line
                    {
                        if (i > 0 && paramList[i - 1].Operand == 0xFF)
                        {
                            i--;
                        }
                        paramList[i].SetOperand(op.Code);
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

        public void SetAsSingleParameter(ParameterControl caller)
        {
            if (caller == parameterControl1)
            {
                for (int i = 1; i < paramList.Count; ++i)
                {
                    paramList[i].Visible = false;
                }
                labelOperand.Visible = false;
            }
        }

        private CodeLine ValidateCode(byte opcode, FFText? parameter)
        {
            var op = OpcodeInfo.GetInfo(opcode);
            if (op == null)
            {
                throw new ArgumentNullException("Opcode is invalid.");
            }
            bool test = ParameterInfo.IsValid(op.ParameterType, parameter);
            if (!test)
            {
                throw new ArgumentException("Parameter is invalid.");
            }
            return new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT, opcode, parameter);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (isString)
                {
                    Code = new List<Code> {
                        ValidateCode((byte)Opcodes.ShowMessage, paramList[0].Parameter)
                    };
                }
                else //convert code back into a proper script
                {
                    var firstParse = new List<CodeLine> { };
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
                                firstParse.Add(ValidateCode(p.ParamType, p.Parameter));
                                if (!p.IsFirst && p.Operand != 0xFF) //add operand
                                {
                                    firstParse.Add(new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT,
                                        p.Operand));
                                }
                                if (p.Modifier != 0xFF) //add modifier
                                {
                                    firstParse.Add(new CodeLine(parentScript, HexParser.NULL_OFFSET_16_BIT,
                                        p.Modifier));
                                }
                            }
                        }
                    }

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
