using FF7Scarlet.SceneEditor;

namespace FF7Scarlet.AIEditor
{
    public abstract class AIContainer
    {
        public const int SCRIPT_NUMBER = 16;
        protected Script[] scripts = new Script[SCRIPT_NUMBER];
        public Scene? Parent { get; protected set; }

        public void CreateNewScript(int pos, Code startingCode)
        {
            if (pos < 0 || pos >= SCRIPT_NUMBER)
            {
                throw new ArgumentOutOfRangeException("Script is out of range.");
            }
            if (scripts[pos] != null)
            {
                throw new ArgumentException("Script already exists.");
            }
            scripts[pos] = new Script(this, startingCode);
        }

        public Script? GetScriptAtPosition(int pos)
        {
            if (pos < 0 || pos >= SCRIPT_NUMBER)
            {
                return null;
            }
            return scripts[pos];
        }

        public bool HasScripts()
        {
            foreach (var s in scripts)
            {
                if (s != null && !s.IsEmpty) { return true; }
            }
            return false;
        }

        public void ParseScripts(byte[] data, int headerSize, int offset, int nextOffset)
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
                if (scriptOffsets[i] != DataManager.NULL_OFFSET_16_BIT) //check if script exists
                {
                    next = -1;
                    for (j = i + 1; j < SCRIPT_NUMBER && next == -1; ++j) //check for next script (if it exists)
                    {
                        if (scriptOffsets[j] != DataManager.NULL_OFFSET_16_BIT)
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
                        if (start + length > data.Length)
                        {
                            length = data.Length - start;
                        }
                    }

                    //parse the script
                    scripts[i] = new Script(this, ref data, start, length);
                }
            }
        }

        public byte[] GetRawAIData()
        {
            ushort currPos = SCRIPT_NUMBER * 2;
            var offsets = new ushort[SCRIPT_NUMBER];
            var data = new List<byte> { };
            byte[] currScript;
            int i;

            //reserve space for offsets
            foreach (var o in offsets)
            {
                data.Add(0xFF);
                data.Add(0xFF);
            }

            //get raw data for scripts
            for (i = 0; i < SCRIPT_NUMBER; ++i)
            {
                if (scripts[i] == null || scripts[i].IsEmpty)
                {
                    offsets[i] = DataManager.NULL_OFFSET_16_BIT;
                }
                else
                {
                    offsets[i] = currPos;
                    currScript = scripts[i].GetRawData();
                    data.AddRange(currScript);
                    currPos += (ushort)currScript.Length;
                }
            }

            //add the offsets
            i = 0;
            foreach (var o in offsets)
            {
                currScript = BitConverter.GetBytes(o);
                data[i] = currScript[0];
                i++;
                data[i] = currScript[1];
                i++;
            }
            return data.ToArray();
        }
    }
}
