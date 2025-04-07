using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Equipment;

namespace FF7Scarlet.AIEditor
{
    public class CodeBlock : Code
    {
        private readonly List<Code> block = new List<Code> { };

        public CodeBlock(Script parent, Code first) :base(parent)
        {
            AddToEnd(first);
        }

        public CodeBlock(Script parent, List<Code> list) :base(parent)
        {
            block = list;
        }

        public CodeBlock(CodeBlock other) :base(other.Parent)
        {
            foreach (var c in other.block)
            {
                if (c is CodeBlock)
                {
                    var cb = c as CodeBlock;
                    if (cb != null)
                    {
                        block.Add(new CodeBlock(cb));
                    }
                }
                else
                {
                    var cl = c as CodeLine;
                    if (cl != null)
                    {
                        block.Add(new CodeLine(cl));
                    }
                }
            }
        }

        public override bool HasOpcode(Opcodes op)
        {
            foreach (var c in block)
            {
                if (c.HasOpcode(op))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddToTop(Code code)
        {
            block.Insert(0, code);
        }

        public void AddToEnd(Code code)
        {
            block.Add(code);
        }

        public Code GetCodeAtPosition(int i)
        {
            if (i < 0 || i >= block.Count) { throw new ArgumentOutOfRangeException(); }
            else { return block[i]; }
        }

        public Code GetCodeAtEnd()
        {
            return block[block.Count - 1];
        }

        public override ushort GetHeader()
        {
            return block[0].GetHeader();
        }

        public override byte GetPrimaryOpcode()
        {
            return block[block.Count - 1].GetPrimaryOpcode();
        }

        public override FFText? GetParameter()
        {
            return block[block.Count - 1].GetParameter();
        }

        public override byte GetPopCount()
        {
            return block[block.Count - 1].GetPopCount();
        }

        public override ushort SetHeader(ushort value)
        {
            ushort currPos = value;
            for (int i = block.Count - 1; i >= 0; i--)
            {
                currPos = block[i].SetHeader(currPos);
            }
            return currPos;
        }

        public override void SetParent(Script parent)
        {
            foreach (var c in block)
            {
                c.SetParent(parent);
            }
            Parent = parent;
        }

        public override string Disassemble(bool verbose)
        {
            string output = "";
            var opcode = (Opcodes)GetPrimaryOpcode();
            if (Enum.IsDefined(opcode))
            {
                CodeLine? pop1, pop2;
                switch (opcode)
                {
                    case Opcodes.Add:
                        output += $"({block[0].Disassemble(false)} + {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.Subtract:
                        output += $"({block[0].Disassemble(false)} - {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.Multiply:
                        output += $"({block[0].Disassemble(false)} * {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.Divide:
                        output += $"({block[0].Disassemble(false)} / {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.Modulo:
                        output += $"({block[0].Disassemble(false)} % {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.BitwiseAnd:
                        output += $"({block[0].Disassemble(false)} & {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.BitwiseOr:
                        output += $"({block[0].Disassemble(false)} | {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.BitwiseNot:
                        output += $"~({block[0].Disassemble(false)})";
                        break;
                    case Opcodes.Equal:
                        output += $"({block[0].Disassemble(false)} == {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.NotEqual:
                        output += $"({block[0].Disassemble(false)} != {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.GreaterOrEqual:
                        output += $"({block[0].Disassemble(false)} >= {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LessThanOrEqual:
                        output += $"({block[0].Disassemble(false)} <= {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.GreaterThan:
                        output += $"({block[0].Disassemble(false)} > {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LessThan:
                        output += $"({block[0].Disassemble(false)} < {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LogicalAnd:
                        output += $"({block[0].Disassemble(false)} && {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LogicalOr:
                        output += $"({block[0].Disassemble(false)} || {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LogicalNot:
                        output += $"(!{block[0].Disassemble(false)})";
                        break;
                    case Opcodes.JumpEqual:
                        pop1 = block[1] as CodeLine;
                        if (pop1 != null && pop1.Parameter != null)
                        {
                            output += $"If ({block[0].Disassemble(false)}) (else goto label {pop1.Parameter.ToInt()})";
                        }
                        break;
                    case Opcodes.JumpNotEqual:
                        pop1 = block[1] as CodeLine;
                        if (pop1 != null && pop1.Parameter != null)
                        {
                            output += $"If (1st in Stack != {block[0].Disassemble(false)})";
                            output += $" (else goto label {pop1.Parameter.ToInt()})";
                        }
                        break;
                    case Opcodes.Mask:
                        output += $"({block[0].Disassemble(false)}.{block[1].Disassemble(false)})";
                        break;
                    case Opcodes.RandomByte:
                        output += $"RandomBit({block[0].Disassemble(false)})";
                        break;
                    case Opcodes.MPCost:
                        pop1 = block[0] as CodeLine;
                        if (pop1 != null && pop1.Parameter != null)
                        {
                            output += $"MPCost({GetAttackName(pop1)})";
                        }
                        break;
                    case Opcodes.Assign:
                        output += $"{block[0].Disassemble(false)} = {block[1].Disassemble(false)}";
                        break;
                    case Opcodes.Attack:
                        pop1 = block[0] as CodeLine;
                        pop2 = block[1] as CodeLine;
                        if (pop1 != null)
                        {
                            if (pop1.Parameter?.ToString() == "24")
                            {
                                output += "Wait";
                            }
                            else if (pop2 != null && pop2.Parameter != null)
                            {
                                output += $"PerformAttack ({pop1.Parameter}, {GetAttackName(pop2)})";
                            }
                        }
                        break;
                    case Opcodes.AssignGlobal:
                        pop1 = block[0] as CodeLine;
                        if (pop1 != null)
                        {
                            if (pop1.Parameter?.ToInt() == 1)
                            {
                                output += $"GlobalVar:{block[1].Disassemble(false)} = Var:2010 (TempGlobal)";
                            }
                            else
                            {
                                output += $"Var:2010 (TempGlobal) = GlobalVar:{block[1].Disassemble(false)}";
                            }
                        }
                        break;
                    case Opcodes.ElementalDef:
                        var parameter = block[1].GetParameter();
                        if (parameter != null)
                        {
                            var elementName = Enum.GetName((Elements)parameter.ToInt());
                            if (elementName == null)
                            {
                                output += $"GetElementDefense({block[0].Disassemble(false)}, Unknown ({block[1].Disassemble(false)}))";
                            }
                            else
                            {
                                output += $"GetElementDefense({block[0].Disassemble(false)}, {elementName})";
                            }
                        }
                        break;
                    case Opcodes.DebugMessage:
                        pop1 = block[block.Count - 1] as CodeLine;
                        output += $"DebugMessage \"{pop1?.Parameter}\"";
                        break;
                    default:
                        output += $"{Enum.GetName(typeof(Opcodes), opcode)}({block[0].Disassemble(false)}";
                        if (block.Count > 2)
                        {
                            output += $", {block[1].Disassemble(false)}";
                        }
                        output += ")";
                        break;
                }
            }
            else
            {
                foreach (var c in block)
                {
                    output += c.Disassemble(verbose);
                }
            }
            return output;
        }

        private string GetAttackName(CodeLine parameter)
        {
            string atkName = $"Unknown ({parameter.Parameter})";
            var op = parameter.OpcodeInfo;
            if (op != null && op.IsVariable)
            {
                atkName = parameter.Disassemble(false);
            }
            else
            {
                var parent = GetTopMostParent();
                var p = parameter.Parameter;
                if (parent != null && p != null)
                {
                    atkName = parent.GetAttackName((ushort)p.ToInt());
                }
            }
            return atkName;
        }

        public override List<CodeLine> BreakDown()
        {
            var separated = new List<CodeLine> { };
            foreach (var b in block)
            {
                foreach (var c in b.BreakDown())
                {
                    separated.Add(c);
                }
            }
            return separated;
        }

        public override byte[] GetBytes()
        {
            var data = new List<byte> { };
            foreach (var c in BreakDown())
            {
                if (c.Opcode != (byte)Opcodes.Label)
                {
                    data.AddRange(c.GetBytes());
                }
            }
            return data.ToArray();
        }
    }
}
