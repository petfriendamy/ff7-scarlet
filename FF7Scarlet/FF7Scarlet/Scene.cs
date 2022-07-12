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
        public const int ENEMY_COUNT = 3, FORMATION_COUNT = 4, ATTACK_COUNT = 32;
        private readonly Enemy[] enemies = new Enemy[ENEMY_COUNT];
        private readonly Formation[] formations = new Formation[FORMATION_COUNT];
        private readonly List<Attack> attackList = new List<Attack> { };
        private int[] formationAIoffset = new int[FORMATION_COUNT];
        private int[] enemyAIoffset = new int[ENEMY_COUNT];
        private byte[] formationAIRaw;
        private byte[] enemyAIraw;

        public bool ScriptsLoaded { get; private set; } = false;

        public Scene(string filePath)
        {
            if (File.Exists(filePath))
            {
                ParseData(File.ReadAllBytes(filePath));
            }
        }

        public Scene(ref byte[] data)
        {
            ParseData(data);
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
                var attackID = new int[ATTACK_COUNT];
                var attackName = new FFText[ATTACK_COUNT];

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
                        enemyName[i] = new FFText(reader.ReadBytes(32));
                        if (!enemyName[i].IsEmpty())
                        {
                            enemies[i] = new Enemy(this, enemyID[i], enemyName[i]);
                        }
                        reader.ReadBytes(152);
                    }

                    //attack data
                    for (i = 0; i < ATTACK_COUNT; ++i) { reader.ReadBytes(28); }

                    //attack IDs
                    for (i = 0; i < ATTACK_COUNT; ++i)
                    {
                        attackID[i] = reader.ReadUInt16();
                    }

                    //attack names
                    for (i = 0; i < ATTACK_COUNT; ++i)
                    {
                        attackName[i] = new FFText(reader.ReadBytes(32));
                        if (!attackName[i].IsEmpty())
                        {
                            attackList.Add(new Attack(attackID[i], attackName[i]));
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
                    formationAIRaw = reader.ReadBytes(504);

                    //enemy A.I. offsets
                    for (i = 0; i < ENEMY_COUNT; ++i)
                    {
                        enemyAIoffset[i] = reader.ReadUInt16();
                    }

                    //enemy A.I. scripts
                    enemyAIraw = reader.ReadBytes(4096);
                }
            }
        }

        public void ParseAIScripts()
        {
            int i, j, next;

            //parse formation scripts
            for (i = 0; i < FORMATION_COUNT; ++i)
            {
                if (formationAIoffset[i] != 0xFFFF)
                {
                    next = -1;
                    for (j = i + 1; j < FORMATION_COUNT && next == -1; ++j)
                    {
                        if (formationAIoffset[j] != 0xFFFF)
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
                if (enemyAIoffset[i] != 0xFFFF)
                {
                    next = -1;
                    for (j = i + 1; j < ENEMY_COUNT && next == -1; ++j)
                    {
                        if (enemyAIoffset[j] != 0xFFFF)
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
    }
}
