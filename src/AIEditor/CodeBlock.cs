using FF7Scarlet.Shared;
using System.Text;
using Shojy.FF7.Elena.Battle;

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

        public override byte[] GetParameter()
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

        public override string Disassemble(bool jpText, bool verbose)
        {
            var opcode = (Opcodes)GetPrimaryOpcode();
            if (Enum.IsDefined(opcode))
            {
                CodeLine? pop1, pop2;
                var sb = new StringBuilder();
                switch (opcode)
                {
                    case Opcodes.Add:
                        sb.Append($"({block[0].Disassemble(jpText, false)} + {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.Subtract:
                        sb.Append($"({block[0].Disassemble(jpText, false)} - {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.Multiply:
                        sb.Append($"({block[0].Disassemble(jpText, false)} * {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.Divide:
                        sb.Append($"({block[0].Disassemble(jpText, false)} / {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.Modulo:
                        sb.Append($"({block[0].Disassemble(jpText, false)} % {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.BitwiseAnd:
                        sb.Append($"({block[0].Disassemble(jpText, false)} & {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.BitwiseOr:
                        sb.Append($"({block[0].Disassemble(jpText, false)} | {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.BitwiseNot:
                        sb.Append($"~({block[0].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.Equal:
                        sb.Append($"({block[0].Disassemble(jpText, false)} == {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.NotEqual:
                        sb.Append($"({block[0].Disassemble(jpText, false)} != {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.GreaterOrEqual:
                        sb.Append($"({block[0].Disassemble(jpText, false)} >= {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.LessThanOrEqual:
                        sb.Append($"({block[0].Disassemble(jpText, false)} <= {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.GreaterThan:
                        sb.Append($"({block[0].Disassemble(jpText, false)} > {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.LessThan:
                        sb.Append($"({block[0].Disassemble(jpText, false)} < {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.LogicalAnd:
                        sb.Append($"({block[0].Disassemble(jpText, false)} && {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.LogicalOr:
                        sb.Append($"({block[0].Disassemble(jpText, false)} || {block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.LogicalNot:
                        sb.Append($"(!{block[0].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.JumpEqual:
                        pop1 = block[1] as CodeLine;
                        if (pop1 != null && pop1.Parameter != null)
                        {
                            sb.Append($"If ({block[0].Disassemble(jpText, false)}) (else goto label {BitConverter.ToUInt16(pop1.Parameter)})");
                        }
                        break;
                    case Opcodes.JumpNotEqual:
                        pop1 = block[1] as CodeLine;
                        if (pop1 != null && pop1.Parameter != null)
                        {
                            sb.Append($"If (1st in Stack != {block[0].Disassemble(jpText, false)})");
                            sb.Append($" (else goto label {BitConverter.ToUInt16(pop1.Parameter)})");
                        }
                        break;
                    case Opcodes.Mask:
                        sb.Append($"({block[0].Disassemble(jpText, false)}.{block[1].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.RandomByte:
                        sb.Append($"RandomBit({block[0].Disassemble(jpText, false)})");
                        break;
                    case Opcodes.MPCost:
                        pop1 = block[0] as CodeLine;
                        if (pop1 != null && pop1.Parameter != null)
                        {
                            sb.Append($"MPCost({GetAttackName(pop1, jpText)})");
                        }
                        break;
                    case Opcodes.Assign:
                        sb.Append($"{block[0].Disassemble(jpText, false)} = {block[1].Disassemble(jpText, false)}");
                        break;
                    case Opcodes.Attack:
                        pop1 = block[0] as CodeLine;
                        pop2 = block[1] as CodeLine;
                        if (pop1 != null)
                        {
                            if (pop1.Parameter[0] == 0x24)
                            {
                                sb.Append("Wait");
                            }
                            else if (pop2 != null && pop2.Parameter != null)
                            {
                                sb.Append($"PerformAttack ({pop1.Parameter[0]:X2}, {GetAttackName(pop2, jpText)})");
                            }
                        }
                        break;
                    case Opcodes.AssignGlobal:
                        pop1 = block[0] as CodeLine;
                        if (pop1 != null)
                        {
                            if (pop1.Parameter[0] == 1)
                            {
                                sb.Append($"GlobalVar:{block[1].Disassemble(jpText, false)} = TempGlobal");
                            }
                            else
                            {
                                sb.Append($"TempGlobal = GlobalVar:{block[1].Disassemble(jpText, false)}");
                            }
                        }
                        break;
                    case Opcodes.ElementalDef:
                        var parameter = block[1].GetParameter();
                        if (parameter != null)
                        {
                            var elementName = Enum.GetName((Elements)BitConverter.ToUInt16(parameter));
                            if (elementName == null)
                            {
                                sb.Append($"GetElementDefense({block[0].Disassemble(jpText, false)}, Unknown ({block[1].Disassemble(jpText, false)}))");
                            }
                            else
                            {
                                sb.Append($"GetElementDefense({block[0].Disassemble(jpText, false)}, {elementName})");
                            }
                        }
                        break;
                    case Opcodes.DebugMessage:
                        pop1 = block[block.Count - 1] as CodeLine;
                        if (pop1 != null)
                        {
                            sb.Append($"DebugMessage \"{Encoding.ASCII.GetString(pop1.Parameter)}\"");
                        }
                            
                        break;
                    default:
                        sb.Append($"{Enum.GetName(typeof(Opcodes), opcode)}({block[0].Disassemble(jpText, false)}");
                        if (block.Count > 2)
                        {
                            sb.Append($", {block[1].Disassemble(jpText, false)}");
                        }
                        sb.Append(")");
                        break;
                }
                return sb.ToString();
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var c in block)
                {
                    sb.Append(c.Disassemble(jpText, verbose));
                }
                return sb.ToString();
            }
        }

        private string GetAttackName(CodeLine parameter, bool jpText)
        {
            string atkName = $"Unknown ({HexParser.HexNumberToText(parameter.Parameter)})";
            var op = parameter.OpcodeInfo;
            if (op != null && op.IsVariable)
            {
                atkName = parameter.Disassemble(jpText, false);
            }
            else
            {
                var parent = GetTopMostParent();
                var p = parameter.Parameter;
                if (parent != null)
                {
                    if (p.Length == 1)
                        atkName = parent.GetAttackName(p[0]);
                    else
                        atkName = parent.GetAttackName(BitConverter.ToUInt16(p));
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
