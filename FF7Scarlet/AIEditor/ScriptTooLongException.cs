using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.AIEditor
{
    public class ScriptTooLongException : Exception
    {
        public ScriptTooLongException() { }
        public ScriptTooLongException(string message) : base(message) { }
    }
}
