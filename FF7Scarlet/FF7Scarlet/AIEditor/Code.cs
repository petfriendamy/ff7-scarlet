using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public abstract class Code
    {
        public Script Parent { get; protected set; }

        public abstract string Disassemble(bool verbose);
        public abstract List<CodeLine> BreakDown();
        public abstract ushort GetHeader();
        public abstract byte GetPrimaryOpcode();
        public abstract FFText GetParameter();
        public abstract byte GetPopCount();
        public abstract void SetParent(Script parent);
        public abstract ushort SetHeader(ushort value);
        public abstract byte[] GetBytes();
        public Scene GetParentScene()
        {
            if (Parent == null) { return null; }
            else { return Parent.Parent.Parent; }
        }
    }
}
