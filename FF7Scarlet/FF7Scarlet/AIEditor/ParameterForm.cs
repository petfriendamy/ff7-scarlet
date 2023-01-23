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
    public partial class ParameterForm : Form
    {
        private List<ParameterControl> paramList;
        public List<Code> Code { get; private set; }
        private int xx, yy, offset;
        private bool isString;

        public ParameterForm(List<Code> code, bool isString)
        {
            InitializeComponent();
            Code = code;
            this.isString = isString;
        }

        private void ParameterForm_Load(object sender, EventArgs e)
        {
            
            paramList = new List<ParameterControl> { parameterControl1, parameterControl2 };
            parameterControl1.SetAsFirst();

            //get position info
            xx = parameterControl1.Location.X;
            yy = parameterControl1.Location.Y;
            offset = parameterControl2.Location.Y - yy;

            int i = 0;
            foreach (var c in Code)
            {
                var op = OpcodeInfo.GetInfo(c.GetPrimaryOpcode());
                if (op.IsParameter() || op.Group == OpcodeGroups.Jump)
                {
                    paramList[i].SetCode(c.GetPrimaryOpcode(), c.GetParameter());

                    //add more lines as needed
                    if (i == paramList.Count - 1)
                    {
                        AddParameter();
                    }
                }
                else if (op.IsOperand())
                {
                    if (i > 0 && paramList[i - 1].Operand == -1)
                    {
                        i--;
                    }
                    paramList[i].SetOperand(c.GetPrimaryOpcode());
                }
                ++i;
            }
        }

        private void AddParameter()
        {
            var newLine = new ParameterControl();
            newLine.Name = $"parameterControl{paramList.Count}";
            newLine.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            newLine.Location = new Point(xx, yy + (offset * (paramList.Count)));
            newLine.Size = new Size(parameterControl1.Size.Width, parameterControl1.Size.Height);
            panelMain.Controls.Add(newLine);
            paramList.Add(newLine);
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

        public void SetSingleParameter(ParameterControl caller)
        {
            if (caller == parameterControl1)
            {
                for (int i = 1; i < paramList.Count; ++i)
                {
                    paramList[i].Visible = false;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (isString)
            {
                Code = new List<Code> {
                    new CodeLine(null, 0xFFFF, (byte)Opcodes.ShowMessage, paramList[0].Parameter)
                };
            }
            else //convert code back into a proper script
            {
                var firstParse = new List<CodeLine> { };
                foreach (var p in paramList)
                {
                    if (p.Checked || p.IsFirst)
                    {
                        firstParse.Add(new CodeLine(null, 0xFFFF, p.ParamType, p.Parameter));
                        if (!p.IsFirst && p.Operand != -1)
                        {
                            firstParse.Add(new CodeLine(null, 0xFFFF, (byte)p.Operand));
                        }
                    }
                }

                Code = Script.GetParsedCode(firstParse);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
