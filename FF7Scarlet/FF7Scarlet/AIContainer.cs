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
            int i, j, next, start, length;

            //get script offsets
            var scriptOffsets = new int[SCRIPT_NUMBER];
            for (i = 0; i < SCRIPT_NUMBER; ++i)
            {
                scriptOffsets[i] = BitConverter.ToUInt16(data, (i * 2) + offset - headerSize);
            }

            //get scripts
            for (i = 0; i < SCRIPT_NUMBER; ++i)
            {
                if (scriptOffsets[i] != 0xFFFF) //check if script exists
                {
                    next = -1;
                    for (j = i + 1; j < SCRIPT_NUMBER && next == -1; ++j) //check for next script (if it exists)
                    {
                        if (scriptOffsets[j] != 0xFFFF)
                        {
                            next = scriptOffsets[j];
                        }
                    }
                    if (next == -1) //no more scripts after this one
                    {
                        next = nextOffset;
                    }

                    //figure out script position and length
                    start = offset + scriptOffsets[i] - headerSize;
                    if (next == -1)
                    {
                        length = data.Length - start;
                    }
                    else
                    {
                        length = next + offset - headerSize - start;
                    }

                    //parse the script
                    scripts[i] = new Script(this, ref data, start, length);
                }
            }
        }
    }
}
