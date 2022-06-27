using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public abstract class Code
    {
        public abstract string Disassemble(bool verbose);
        public abstract List<CodeLine> BreakDown();
        public abstract int GetHeader();
        public abstract int GetPrimaryOpcode();
        public abstract FFText GetParameter();
    }
}
