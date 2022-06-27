using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public abstract class AIContainer
    {
        public const int SCRIPT_NUMBER = 16;
        protected Script[] scripts = new Script[SCRIPT_NUMBER];
        public Scene Parent { get; protected set; }

        /*public AIContainer(ref byte[] data, int offset, int nextOffset)
        {
            ParseScripts(ref data, offset, nextOffset);
        }*/

        public Script GetScriptAtPosition(int pos)
        {
            if (pos < 0 || pos >= SCRIPT_NUMBER)
            {
                return null;
            }
            return scripts[pos];
        }

        public void ParseScripts(ref byte[] data, int headerSize, int offset, int nextOffset)
        {
            int i, j;

            //get offsets
            var scriptOffsets = new int[SCRIPT_NUMBER];
            for (i = 0; i < SCRIPT_NUMBER; ++i)
            {
                scriptOffsets[i] = BitConverter.ToUInt16(data, (i * 2) + offset - headerSize);
            }

            //get script lengths
            var scriptLengths = new int[SCRIPT_NUMBER];
            for (i = 0; i < SCRIPT_NUMBER; ++i)
            {
                if (scriptOffsets[i] >= 0 && scriptOffsets[i] < data.Length)
                {
                    bool test = false;
                    for (j = i + 1; j < SCRIPT_NUMBER && !test; ++j)
                    {
                        if (scriptOffsets[j] >= 0 && scriptOffsets[j] < data.Length)
                        {
                            nextOffset = scriptOffsets[j];
                            test = true;
                        }
                    }
                    if (!test)
                    {
                        nextOffset = data.Length;
                    }
                    scriptLengths[i] = nextOffset - scriptOffsets[i];
                }
                else
                {
                    scriptLengths[i] = 0;
                }
            }

            //finally, parse A.I. scripts
            for (i = 0; i < SCRIPT_NUMBER; ++i)
            {
                if (scriptLengths[i] > 0)
                {
                    scripts[i] = new Script(this, ref data, scriptOffsets[i], scriptLengths[i]);
                }
            }
        }
    }
}
