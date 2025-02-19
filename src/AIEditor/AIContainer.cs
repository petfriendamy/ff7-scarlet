using FF7Scarlet.SceneEditor;

namespace FF7Scarlet.AIEditor
{
    public abstract class AIContainer
    {
        public const int SCRIPT_NUMBER = 16;
        protected readonly Script[] scripts = new Script[SCRIPT_NUMBER];
        public IAttackContainer Parent { get; protected set; }

        public Script[] Scripts
        {
            get { return scripts; }
        }

        public AIContainer(IAttackContainer parent)
        {
            Parent = parent;
            for (int i = 0; i < SCRIPT_NUMBER; ++i)
            {
                scripts[i] = new Script(this);
            }
        }

        public bool HasScripts()
        {
            foreach (var s in scripts)
            {
                if (!s.IsEmpty) { return true; }
            }
            return false;
        }

        public int HasOpcode(Opcodes op)
        {
            if (HasScripts())
            {
                for (int i = 0; i < SCRIPT_NUMBER; ++i)
                {
                    if (Scripts[i].HasOpcode(op))
                    {
                        return i;
                    }
                }
            }
            return -1;
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
                if (scriptOffsets[i] != HexParser.NULL_OFFSET_16_BIT) //check if the script exists
                {
                    next = -1;
                    for (j = i + 1; j < SCRIPT_NUMBER && next == -1; ++j) //check for next script (if it exists)
                    {
                        if (scriptOffsets[j] != HexParser.NULL_OFFSET_16_BIT)
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

        public byte[] GetScriptBlock()
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
                    offsets[i] = HexParser.NULL_OFFSET_16_BIT;
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

        public static byte[] GetGroupedScriptBlock(int containerCount, int blockSize, AIContainer?[] aiContainers,
            ref ushort[] offsets)
        {
            var scriptList = new List<byte[]> { };
            byte[] currData;
            int i, j, sum;
            ushort currPos = (ushort)(containerCount * 2);
            var length = new int[containerCount];
            for (i = 0; i < containerCount; ++i)
            {
                var container = aiContainers[i];
                if (container == null || !container.HasScripts())
                {
                    offsets[i] = HexParser.NULL_OFFSET_16_BIT;
                    length[i] = 0;
                    scriptList.Add(Array.Empty<byte>());
                }
                else
                {
                    offsets[i] = currPos;
                    currData = container.GetScriptBlock();
                    scriptList.Add(currData);
                    length[i] = currData.Length;
                    while (length[i] % 2 != 0) { length[i]++; }
                    currPos += (ushort)length[i];
                }
            }

            sum = length.Sum();
            if (sum > blockSize)
            {
                throw new ScriptTooLongException();
            }

            var data = new byte[blockSize];
            using (var ms = new MemoryStream(data, true))
            using (var writer = new BinaryWriter(ms))
            {
                for (i = 0; i < containerCount; ++i)
                {
                    if (scriptList[i].Length != 0)
                    {
                        writer.Write(scriptList[i]);
                        for (j = scriptList[i].Length; j < length[i]; ++j)
                        {
                            writer.Write((byte)0xFF);
                        }
                    }
                }
                bool end = false;
                while (!end)
                {
                    try
                    {
                        writer.Write((byte)0xFF);
                    }
                    catch (Exception)
                    {
                        end = true;
                    }
                }
            }
            return data;
        }
    }
}
