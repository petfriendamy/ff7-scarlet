using FF7Scarlet.AIEditor;
using FF7Scarlet.Shared;

namespace FF7Scarlet.SceneEditor
{
    public class Scene
    {
        public const int ENEMY_COUNT = 3, FORMATION_COUNT = 4, ATTACK_COUNT = 32,
            NAME_LENGTH = 32, ENEMY_DATA_BLOCK_SIZE = 152,
            FORMATION_BLOCK_SIZE = 504, ENEMY_AI_BLOCK_SIZE = 4090;
        private readonly Enemy[] enemies = new Enemy[ENEMY_COUNT];
        private readonly Formation[] formations = new Formation[FORMATION_COUNT];
        private readonly Attack?[] attackList = new Attack?[ATTACK_COUNT];

        private ushort[] formationAIoffset = new ushort[FORMATION_COUNT];
        private ushort[] enemyAIoffset = new ushort[ENEMY_COUNT];
        private readonly byte[] formationAIRaw = new byte[FORMATION_BLOCK_SIZE];
        private readonly byte[] enemyAIraw = new byte[ENEMY_AI_BLOCK_SIZE];
        private byte[] rawData;

        public bool ScriptsLoaded { get; private set; } = false;

        public Scene(string filePath)
        {
            if (File.Exists(filePath))
            {
                rawData = File.ReadAllBytes(filePath);
                ParseData(rawData);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public Scene(ref byte[] data)
        {
            rawData = data;
            ParseData(rawData);
        }

        public Scene(Scene other)
        {
            rawData = other.rawData;
            ParseData(rawData);
        }

        public Enemy GetEnemyByNumber(int id)
        {
            if (id >= 1 && id <= ENEMY_COUNT)
            {
                return enemies[id - 1];
            }
            throw new ArgumentOutOfRangeException();
        }

        public bool IsEmpty()
        {
            return (enemies[0] == null && enemies[1] == null && enemies[2] == null);
        }

        public string GetEnemyNames()
        {
            if (IsEmpty())
            {
                return "EMPTY";
            }
            else
            {
                string temp = "";
                for (int i = 0; i < ENEMY_COUNT; i++)
                {
                    if (enemies[i] == null)
                    {
                        temp += "(none)";
                    }
                    else
                    {
                        temp += enemies[i].Name;
                    }
                    if (i + 1 < ENEMY_COUNT)
                    {
                        temp += ", ";
                    }
                }
                return temp;
            }
        }

        public string GetAttackName(int id)
        {
            foreach (var atk in attackList)
            {
                if (atk != null && atk.ID == id)
                {
                    var str = atk.Name.ToString();
                    if (str == null) { return $"Unnamed ({id:X4})"; }
                    else { return str; }
                }
            }
            return $"Unknown ({id:X4})";
        }

        private void ParseData(byte[] data)
        {
            using (var ms = new MemoryStream(data, false))
            using (var reader = new BinaryReader(ms))
            {
                int i, j;
                var enemyID = new int[ENEMY_COUNT];
                var enemyName = new FFText[ENEMY_COUNT];
                var attackData = new List<byte[]> { };
                var attackID = new ushort[ATTACK_COUNT];
                var attackName = new FFText[ATTACK_COUNT];
                byte[] temp;

                try
                {
                    //enemy IDs
                    for (i = 0; i < ENEMY_COUNT; ++i)
                    {
                        enemyID[i] = reader.ReadUInt16();
                    }

                    reader.ReadBytes(2); //padding
                    //battle setup data
                    for (i = 0; i < 4; ++i) { reader.ReadBytes(20); }
                    //camera placement data
                    for (i = 0; i < 4; ++i) { reader.ReadBytes(48); }
                    //battle formations
                    for (i = 0; i < 4; ++i)
                    {
                        for (j = 0; j < 6; ++j)
                        {
                            reader.ReadBytes(16);
                        }
                    }

                    //enemy data
                    for (i = 0; i < ENEMY_COUNT; ++i)
                    {
                        enemyName[i] = new FFText(reader.ReadBytes(NAME_LENGTH));
                        temp = reader.ReadBytes(ENEMY_DATA_BLOCK_SIZE);
                        if (!enemyName[i].IsEmpty())
                        {
                            enemies[i] = new Enemy(this, enemyID[i], enemyName[i], temp);
                        }
                    }

                    //attack data
                    for (i = 0; i < ATTACK_COUNT; ++i)
                    {
                        attackData.Add(reader.ReadBytes(Attack.BLOCK_SIZE));
                    }

                    //attack IDs
                    for (i = 0; i < ATTACK_COUNT; ++i)
                    {
                        attackID[i] = reader.ReadUInt16();
                    }

                    //attack names
                    for (i = 0; i < ATTACK_COUNT; ++i)
                    {
                        attackName[i] = new FFText(reader.ReadBytes(NAME_LENGTH));
                        if (attackID[i] != DataManager.NULL_OFFSET_16_BIT)
                        {
                            attackList[i] = new Attack(attackID[i], attackName[i], attackData[i]);
                        }
                        else { attackList[i] = null; }
                    }
                }
                catch (Exception ex)
                {
                    throw new FileLoadException($"An error occured while parsing the enemy data: {ex.Message}", ex);
                }

                if (IsEmpty())
                {
                    ScriptsLoaded = true;
                }
                else
                {
                    //formation offsets
                    for (i = 0; i < FORMATION_COUNT; ++i)
                    {
                        formationAIoffset[i] = reader.ReadUInt16();
                    }

                    //formations
                    Array.Copy(reader.ReadBytes(FORMATION_BLOCK_SIZE), formationAIRaw, FORMATION_BLOCK_SIZE);

                    //enemy A.I. offsets
                    for (i = 0; i < ENEMY_COUNT; ++i)
                    {
                        enemyAIoffset[i] = reader.ReadUInt16();
                    }

                    //enemy A.I. scripts
                    Array.Copy(reader.ReadBytes(ENEMY_AI_BLOCK_SIZE), enemyAIraw, ENEMY_AI_BLOCK_SIZE);
                }
            }
        }

        public void ParseAIScripts()
        {
            int i, j, next;

            //parse formation scripts
            for (i = 0; i < FORMATION_COUNT; ++i)
            {
                if (formationAIoffset[i] != DataManager.NULL_OFFSET_16_BIT)
                {
                    next = -1;
                    for (j = i + 1; j < FORMATION_COUNT && next == -1; ++j)
                    {
                        if (formationAIoffset[j] != DataManager.NULL_OFFSET_16_BIT)
                        {
                            next = formationAIoffset[j];
                        }
                    }
                    try
                    {
                        formations[i] = new Formation();
                        formations[i].ParseScripts(formationAIRaw, FORMATION_COUNT * 2, formationAIoffset[i], next);
                    }
                    catch (Exception ex)
                    {
                        throw new FileLoadException($"An error occurred while parsing the formation scripts: {ex.Message}", ex);
                    }
                }
            }

            //parse enemy scripts
            for (i = 0; i < ENEMY_COUNT; ++i)
            {
                if (enemies[i] != null && enemyAIoffset[i] != DataManager.NULL_OFFSET_16_BIT)
                {
                    next = -1;
                    for (j = i + 1; j < ENEMY_COUNT && next == -1; ++j)
                    {
                        if (enemyAIoffset[j] != DataManager.NULL_OFFSET_16_BIT)
                        {
                            next = enemyAIoffset[j];
                        }
                    }
                    try
                    {
                        enemies[i].ParseScripts(enemyAIraw, ENEMY_COUNT * 2, enemyAIoffset[i], next);
                    }
                    catch (Exception ex)
                    {
                        throw new FileLoadException($"An error occurred while parsing the script for {enemies[i].Name} (enemy #{i + 1}): {ex.Message}", ex);
                    }
                }
            }
            ScriptsLoaded = true;
        }

        public int SyncAttack(Attack attack)
        {
            int count = 0;
            for (int i = 0; i < ATTACK_COUNT; ++i)
            {
                var atk = attackList[i];
                if (atk != null)
                {
                    if (atk.ID == attack.ID)
                    {
                        attackList[i] = attack;
                        count++;
                    }
                }
            }
            return count;
        }

        public void UpdateRawData()
        {
            try
            {
                using (var ms = new MemoryStream(rawData, true))
                using (var writer = new BinaryWriter(ms))
                {
                    int i = 0;
                    //enemy data
                    try
                    {
                        writer.Seek(0x0298, SeekOrigin.Begin);
                        for (i = 0; i < ENEMY_COUNT; ++i)
                        {
                            if (enemies[i] == null)
                            {
                                writer.Write(GetNullBlock(ENEMY_DATA_BLOCK_SIZE + NAME_LENGTH));
                            }
                            else { writer.Write(enemies[i].GetRawEnemyData()); }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error in enemy data (index {i}): {ex.Message}", ex);
                    }

                    //attack data
                    try
                    {
                        Attack? atk;
                        for (i = 0; i < ATTACK_COUNT; ++i)
                        {
                            atk = attackList[i];
                            if (atk == null) { writer.Write(GetNullBlock(Attack.BLOCK_SIZE)); }
                            else { writer.Write(atk.GetRawData()); }
                        }
                        for (i = 0; i < ATTACK_COUNT; ++i)
                        {
                            atk = attackList[i];
                            if (atk == null) { writer.Write((ushort)0xFFFF); }
                            else { writer.Write(atk.ID); }
                        }
                        for (i = 0; i < ATTACK_COUNT; ++i)
                        {
                            atk = attackList[i];
                            if (atk == null) { writer.Write(GetNullBlock(NAME_LENGTH)); }
                            else
                            {
                                var name = atk.Name.GetBytes();
                                if (name == null) { writer.Write(GetNullBlock(NAME_LENGTH)); }
                                else { writer.Write(name); }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error in attack data (index {i}): {ex.Message}", ex);
                    }

                    if (ScriptsLoaded) //no need to update script data if it hasn't been changed
                    {
                        //formation data
                        try
                        {
                            Array.Copy(GetRawScriptData(FORMATION_COUNT, FORMATION_BLOCK_SIZE, formations,
                                ref formationAIoffset), formationAIRaw, FORMATION_BLOCK_SIZE);

                            foreach (var o in formationAIoffset)
                            {
                                writer.Write(o);
                            }
                            writer.Write(formationAIRaw);
                        }
                        catch (ScriptTooLongException)
                        {
                            throw new ScriptTooLongException("Formation A.I. block is too long!");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Compiler error in formation scripts: {ex.Message}", ex);
                        }

                        //enemy A.I. data
                        try
                        {
                            Array.Copy(GetRawScriptData(ENEMY_COUNT, ENEMY_AI_BLOCK_SIZE, enemies,
                                ref enemyAIoffset), enemyAIraw, ENEMY_AI_BLOCK_SIZE);

                            foreach (var o in enemyAIoffset)
                            {
                                writer.Write(o);
                            }
                            writer.Write(enemyAIraw);
                        }
                        catch (ScriptTooLongException)
                        {
                            throw new ScriptTooLongException("Enemy A.I. block is too long!");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Compiler error in enemy scripts: {ex.Message}");
                        }

                        //pad remaining data with 0xFF
                        bool end = false;
                        while (!end)
                        {
                            try
                            {
                                writer.Write((byte)0xFF);
                            }
                            catch
                            {
                                end = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FormatException(ex.Message);
            }
        }

        public byte[] GetRawData()
        {
            var copy = new byte[rawData.Length];
            Array.Copy(rawData, copy, rawData.Length);
            return copy;
        }

        private byte[] GetRawScriptData(int containerCount, int blockSize, AIContainer[] aiContainers,
            ref ushort[] offsets)
        {
            var scriptList = new List<byte[]> { };
            byte[] currData;
            int i, j, sum;
            ushort currPos = 6;
            var length = new int[containerCount];
            for (i = 0; i < containerCount; ++i)
            {
                if (aiContainers[i] == null || !aiContainers[i].HasScripts())
                {
                    offsets[i] = DataManager.NULL_OFFSET_16_BIT;
                    length[i] = 0;
                    scriptList.Add(new byte[0]);
                }
                else
                {
                    offsets[i] = currPos;
                    currData = aiContainers[i].GetRawAIData();
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

        private byte[] GetNullBlock(int size)
        {
            var data = new byte[size];
            for (int i = 0; i < size; ++i)
            {
                data[i] = 0xFF;
            }
            return data;
        }
    }
}
