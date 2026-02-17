using FF7Scarlet.Shared;

namespace FF7Scarlet.AIEditor
{
    public abstract class Code
    {
        public Script Parent { get; protected set; }

        public abstract string Disassemble(bool jpText, bool verbose);
        public abstract List<CodeLine> BreakDown();
        public abstract ushort GetHeader();
        public abstract byte GetPrimaryOpcode();
        public abstract byte[] GetParameter();
        public abstract byte GetPopCount();
        public abstract void SetParent(Script parent);
        public abstract ushort SetHeader(ushort value);
        public abstract byte[] GetBytes();
        public IAttackContainer? GetTopMostParent()
        {
            return Parent.Parent.Parent;
        }
        public abstract bool HasOpcode(Opcodes op);

        public Code(Script parent)
        {
            Parent = parent;
        }
    }
}
