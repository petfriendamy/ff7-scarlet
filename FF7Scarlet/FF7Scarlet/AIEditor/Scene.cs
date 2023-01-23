using FF7Scarlet.AIEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public class Scene
    {
        public const int ENEMY_COUNT = 3, FORMATION_COUNT = 4, ATTACK_COUNT = 32,
            NAME_LENGTH = 32, ENEMY_DATA_BLOCK_SIZE = 152, ATTACK_BLOCK_SIZE = 28,
            FORMATION_BLOCK_SIZE = 504, ENEMY_AI_BLOCK_SIZE = 4090;
        private readonly Enemy[] enemies = new Enemy[ENEMY_COUNT];
        private readonly Formation[] formations = new Formation[FORMATION_COUNT];
        private Attack[] attackList = new Attack[ATTACK_COUNT];
        private ushort[] formationAIoffset = new ushort[FORMATION_COUNT];
        private ushort[] enemyAIoffset = new ushort[ENEMY_COUNT];
        private byte[] formationAIRaw;
        private byte[] enemyAIraw;
        private byte[] rawData;

        public bool ScriptsLoaded { get; private set; } = false;

        public Scene(string filePath)
        {
            if (File.Exists(filePath))
            {
                rawData = File.ReadAllBytes(filePath);
                ParseData(rawData);
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
            return null;
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
                if (atk.ID == id)
                {
                    return atk.Name.ToString();
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
                        attackData.Add(reader.ReadBytes(ATTACK_BLOCK_SIZE));
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
                        if (!attackName[i].IsEmpty())
                        {
                            attackList[i] = new Attack(attackID[i], attackName[i], attackData[i]);
                        }
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
                    formationAIRaw = reader.ReadBytes(FORMATION_BLOCK_SIZE);

                    //enemy A.I. offsets
                    for (i = 0; i < ENEMY_COUNT; ++i)
                    {
                        enemyAIoffset[i] = reader.ReadUInt16();
                    }

                    //enemy A.I. scripts
                    enemyAIraw = reader.ReadBytes(ENEMY_AI_BLOCK_SIZE);
                }
            }
        }

        public void ParseAIScripts()
        {
            int i, j, next;

            //parse formation scripts
            for (i = 0; i < FORMATION_COUNT; ++i)
            {
                if (formationAIoffset[i] != Script.NULL_OFFSET)
                {
                    next = -1;
                    for (j = i + 1; j < FORMATION_COUNT && next == -1; ++j)
                    {
                        if (formationAIoffset[j] != Script.NULL_OFFSET)
                        {
                            next = formationAIoffset[j];
                        }
                    }
                    try
                    {
                        formations[i] = new Formation();
                        formations[i].ParseScripts(ref formationAIRaw, FORMATION_COUNT * 2, formationAIoffset[i], next);
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
                if (enemies[i] != null && enemyAIoffset[i] != Script.NULL_OFFSET)
                {
                    next = -1;
                    for (j = i + 1; j < ENEMY_COUNT && next == -1; ++j)
                    {
                        if (enemyAIoffset[j] != Script.NULL_OFFSET)
                        {
                            next = enemyAIoffset[j];
                        }
                    }
                    try
                    {
                        enemies[i].ParseScripts(ref enemyAIraw, ENEMY_COUNT * 2, enemyAIoffset[i], next);
                    }
                    catch (Exception ex)
                    {
                        throw new FileLoadException($"An error occurred while parsing the script for {enemies[i].Name} (enemy #{i + 1}): {ex.Message}", ex);
                    }
                }
            }
            ScriptsLoaded = true;
        }

        public void UpdateRawData()
        {
            try
            {
                using (var ms = new MemoryStream(rawData, true))
                using (var writer = new BinaryWriter(ms))
                {
                    //enemy data
                    try
                    {
                        writer.Seek(0x0298, SeekOrigin.Begin);
                        foreach (var e in enemies)
                        {
                            if (e == null) { writer.Write(GetNullBlock(ENEMY_DATA_BLOCK_SIZE + NAME_LENGTH)); }
                            else { writer.Write(e.GetRawEnemyData()); }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error parsing enemy data: {ex.Message}");
                    }

                    //attack data
                    try
                    {
                        foreach (var a in attackList)
                        {
                            if (a == null) { writer.Write(GetNullBlock(ATTACK_BLOCK_SIZE)); }
                            else { writer.Write(a.GetRawData()); }
                        }
                        foreach (var a in attackList)
                        {
                            if (a == null) { writer.Write((ushort)0xFFFF); }
                            else { writer.Write(a.ID); }
                        }
                        foreach (var a in attackList)
                        {
                            if (a == null) { writer.Write(GetNullBlock(NAME_LENGTH)); }
                            else { writer.Write(a.Name.GetBytes()); }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error parsing attack data: {ex.Message}");
                    }

                    //formation data
                    try
                    {
                        formationAIRaw = GetRawScriptData(FORMATION_COUNT, FORMATION_BLOCK_SIZE, formations,
                            ref formationAIoffset);

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
                        throw new Exception($"Error parsing formation scripts: {ex.Message}");
                    }

                    //enemy A.I. data
                    try
                    {
                        enemyAIraw = GetRawScriptData(ENEMY_COUNT, ENEMY_AI_BLOCK_SIZE, enemies,
                            ref enemyAIoffset);

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
                        throw new Exception($"Error parsing enemy scripts: {ex.Message}");
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
            return rawData;
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
                    offsets[i] = Script.NULL_OFFSET;
                    length[i] = 0;
                    scriptList.Add(null);
                }
                else
                {
                    offsets[i] = currPos;
                    currData = aiContainers[i].GetRawAIData();
                    scriptList.Add(currData);
                    length[i] = currData.Length;
                    while (length[i] % 4 != 0) { length[i]++; }
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
                    if (scriptList[i] != null)
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
