using FF7Scarlet.AIEditor;
using FF7Scarlet.Shared;
using Shojy.FF7.Elena.Attacks;

namespace FF7Scarlet.SceneEditor
{
    public class Scene : IAttackContainer
    {
        public const int SCENE_COUNT = 256, COMPRESSED_BLOCK_SIZE = 0x2000, UNCOMPRESSED_BLOCK_SIZE = 7808,
            HEADER_COUNT = 16, ENEMY_COUNT = 3, FORMATION_COUNT = 4, ALL_FORMATIONS_COUNT = 1024,
            ATTACK_COUNT = 32, NAME_LENGTH = 32;
        private readonly Enemy?[] enemies = new Enemy[ENEMY_COUNT];
        private readonly Formation[] formations = new Formation[FORMATION_COUNT];
        private readonly Attack?[] attackList = new Attack?[ATTACK_COUNT];

        private ushort[] formationAIoffset = new ushort[FORMATION_COUNT];
        private ushort[] enemyAIoffset = new ushort[ENEMY_COUNT];
        private readonly byte[] formationAIRaw = new byte[Formation.AI_BLOCK_SIZE];
        private readonly byte[] enemyAIraw = new byte[Enemy.AI_BLOCK_SIZE];
        private readonly byte[] rawData = new byte[UNCOMPRESSED_BLOCK_SIZE];

        public Enemy?[] Enemies
        {
            get { return enemies; }
        }
        public Formation[] Formations
        {
            get { return formations; }
        }
        public Attack?[] AttackList
        {
            get { return attackList; }
        }
        public bool ScriptsLoaded { get; private set; } = false;

        public Scene() :base()
        {
            for (int i = 0; i < FORMATION_COUNT; ++i)
            {
                Formations[i] = new Formation(this);
            }
        }

        public Scene(string filePath) :base()
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

        public Scene(ref byte[] data) :base()
        {
            rawData = data;
            ParseData(rawData);
        }

        public Scene(Scene other) :base()
        {
            rawData = other.rawData;
            ParseData(rawData);
        }

        public bool IsEmpty()
        {
            return (Enemies[0] == null && Enemies[1] == null && Enemies[2] == null);
        }

        public Enemy? GetEnemyByID(ushort id)
        {
            foreach (var e in Enemies)
            {
                if (e?.ModelID == id)
                {
                    return e;
                }
            }
            return null;
        }

        public string GetEnemyName(ushort id)
        {
            var enemy = GetEnemyByID(id);
            if (enemy == null) { return "(none)"; }
            else { return enemy.GetNameString(); }
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
                    var enemy = Enemies[i];
                    if (enemy == null)
                    {
                        temp += "(none)";
                    }
                    else
                    {
                        temp += GetEnemyName(enemy.ModelID);
                    }
                    if (i + 1 < ENEMY_COUNT)
                    {
                        temp += ", ";
                    }
                }
                return temp;
            }
        }

        public Attack? GetAttackByID(ushort id)
        {
            if (id != HexParser.NULL_OFFSET_16_BIT)
            {
                foreach (var atk in AttackList)
                {
                    if (atk?.Index == id) { return atk; }
                }
            }
            return null;
        }

        public string GetAttackName(ushort id)
        {
            var atk = GetAttackByID(id);
            if (atk != null)
            {
                return DataParser.GetAttackNameString(atk);
            }
            else if (id == HexParser.NULL_OFFSET_16_BIT)
            {
                return "(none)";
            }
            return $"Unknown ({id:X4})";
        }

        public string GetFormationEnemyNames(int formation)
        {
            if (formation < 0 || formation >= FORMATION_COUNT)
            {
                throw new ArgumentOutOfRangeException();
            }

            //get enemies in formation
            var enemyCount = new Dictionary<Enemy, int>();
            foreach (var e in Formations[formation].EnemyLocations)
            {
                var enemy = GetEnemyByID(e.EnemyID);
                if (enemy != null)
                {
                    if (enemyCount.ContainsKey(enemy))
                    {
                        enemyCount[enemy]++;
                    }
                    else
                    {
                        enemyCount.Add(enemy, 1);
                    }
                }
            }

            if (enemyCount.Count == 0) { return "(empty)"; }

            //sort the list and get the names
            var sorted =
                (from e in enemyCount
                 orderby e.Value descending
                 select e);

            string output = "";
            foreach (var e in sorted)
            {
                output += $"{e.Value}x {e.Key.GetNameString()}, ";
            }
            return output.Substring(0, output.LastIndexOf(','));
        }

        private void ParseData(byte[] data)
        {
            using (var ms = new MemoryStream(data, false))
            using (var reader = new BinaryReader(ms))
            {
                int i, j;
                var enemyModelID = new ushort[ENEMY_COUNT];
                var enemyName = new FFText[ENEMY_COUNT];
                var setupData = new BattleSetupData[FORMATION_COUNT];
                var cameraData = new CameraPlacementData[FORMATION_COUNT];
                var enemyLocations = new EnemyLocation[Formation.ENEMY_COUNT];
                var attackData = new List<byte[]>();
                var attackID = new ushort[ATTACK_COUNT];
                var attackName = new FFText[ATTACK_COUNT];
                byte[] temp;

                try
                {
                    //enemy model IDs
                    for (i = 0; i < ENEMY_COUNT; ++i)
                    {
                        enemyModelID[i] = reader.ReadUInt16();
                    }

                    reader.ReadBytes(2); //padding
                    //battle setup data
                    for (i = 0; i < FORMATION_COUNT; ++i)
                    {
                        setupData[i] = new BattleSetupData(reader.ReadBytes(BattleSetupData.BLOCK_SIZE));
                    }
                    //camera placement data
                    for (i = 0; i < FORMATION_COUNT; ++i)
                    {
                        cameraData[i] = new CameraPlacementData(reader.ReadBytes(CameraPlacementData.BLOCK_SIZE));
                    }
                    //battle formations
                    for (i = 0; i < FORMATION_COUNT; ++i)
                    {
                        for (j = 0; j < Formation.ENEMY_COUNT; ++j)
                        {
                            enemyLocations[j] = new EnemyLocation(reader.ReadBytes(EnemyLocation.BLOCK_SIZE));
                        }
                        Formations[i] = new Formation(this, setupData[i], cameraData[i], enemyLocations);
                    }

                    //enemy data
                    for (i = 0; i < ENEMY_COUNT; ++i)
                    {
                        enemyName[i] = new FFText(reader.ReadBytes(NAME_LENGTH));
                        temp = reader.ReadBytes(Enemy.DATA_BLOCK_SIZE);
                        //if (!enemyName[i].IsEmpty())
                        if (enemyModelID[i] < 65535)
                        {
                            Enemies[i] = new Enemy(this, enemyModelID[i], enemyName[i], temp);
                        }
                    }

                    //attack data
                    for (i = 0; i < ATTACK_COUNT; ++i)
                    {
                        attackData.Add(reader.ReadBytes(DataParser.ATTACK_BLOCK_SIZE));
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
                        if (attackID[i] != HexParser.NULL_OFFSET_16_BIT)
                        {
                            AttackList[i] = DataParser.ReadAttack(attackID[i], attackName[i].ToString(), attackData[i]);
                        }
                        else { AttackList[i] = null; }
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
                    Array.Copy(reader.ReadBytes(Formation.AI_BLOCK_SIZE), formationAIRaw, Formation.AI_BLOCK_SIZE);

                    //enemy A.I. offsets
                    for (i = 0; i < ENEMY_COUNT; ++i)
                    {
                        enemyAIoffset[i] = reader.ReadUInt16();
                    }

                    //enemy A.I. scripts
                    Array.Copy(reader.ReadBytes(Enemy.AI_BLOCK_SIZE), enemyAIraw, Enemy.AI_BLOCK_SIZE);
                }
            }
        }

        public void ParseAIScripts()
        {
            if (!IsEmpty()) //no need to parse an empty scene
            {
                int i, j, next;

                //parse formation scripts
                for (i = 0; i < FORMATION_COUNT; ++i)
                {
                    if (formationAIoffset[i] != HexParser.NULL_OFFSET_16_BIT)
                    {
                        next = -1;
                        for (j = i + 1; j < FORMATION_COUNT && next == -1; ++j)
                        {
                            if (formationAIoffset[j] != HexParser.NULL_OFFSET_16_BIT)
                            {
                                next = formationAIoffset[j];
                            }
                        }
                        try
                        {
                            //formations[i] = new Formation();
                            Formations[i].ParseScripts(formationAIRaw, FORMATION_COUNT * 2, formationAIoffset[i], next);
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
                    var e = Enemies[i];
                    if (e != null && enemyAIoffset[i] != HexParser.NULL_OFFSET_16_BIT)
                    {
                        next = -1;
                        for (j = i + 1; j < ENEMY_COUNT && next == -1; ++j)
                        {
                            if (enemyAIoffset[j] != HexParser.NULL_OFFSET_16_BIT)
                            {
                                next = enemyAIoffset[j];
                            }
                        }
                        try
                        {
                            e.ParseScripts(enemyAIraw, ENEMY_COUNT * 2, enemyAIoffset[i], next);
                        }
                        catch (Exception ex)
                        {
                            throw new FileLoadException($"An error occurred while parsing the script for {e.Name} (enemy #{i + 1}): {ex.Message}", ex);
                        }
                    }
                }
                ScriptsLoaded = true;
            }
        }

        public int SyncAttack(Attack attack)
        {
            int count = 0;
            for (int i = 0; i < ATTACK_COUNT; ++i)
            {
                var atk = AttackList[i];
                if (atk != null)
                {
                    if (atk.Index == attack.Index)
                    {
                        AttackList[i] = attack;
                        count++;
                    }
                }
            }
            return count;
        }

        public byte[] GetRawData()
        {
            try
            {
                using (var ms = new MemoryStream(rawData, true))
                using (var writer = new BinaryWriter(ms))
                {
                    int i = 0;
                    //enemy model IDs
                    for (i = 0; i < ENEMY_COUNT; ++i)
                    {
                        var e = Enemies[i];
                        if (e == null)
                        {
                            writer.Write(HexParser.NULL_OFFSET_16_BIT);
                        }
                        else { writer.Write(e.ModelID); }
                    }

                    writer.Write(HexParser.NULL_OFFSET_16_BIT);

                    //formation data
                    try
                    {
                        //battle setup data
                        for (i = 0; i < FORMATION_COUNT; ++i)
                        {
                            writer.Write(Formations[i].BattleSetupData.GetRawData());
                        }

                        //camera placement data
                        for (i = 0; i < FORMATION_COUNT; ++i)
                        {
                            writer.Write(Formations[i].CameraPlacementData.GetRawData());
                        }

                        //enemy placement data
                        for (i = 0; i < FORMATION_COUNT; ++i)
                        {
                            for (int j = 0; j < Formation.ENEMY_COUNT; ++j)
                            {
                                writer.Write(Formations[i].EnemyLocations[j].GetRawData());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error in formation data (index {i}): {ex.Message}", ex);
                    }

                    //enemy data
                    try
                    {
                        for (i = 0; i < ENEMY_COUNT; ++i)
                        {
                            var e = Enemies[i];
                            if (e == null)
                            {
                                writer.Write(HexParser.GetNullBlock(Enemy.DATA_BLOCK_SIZE + NAME_LENGTH));
                            }
                            else { writer.Write(e.GetRawEnemyData()); }
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
                            atk = AttackList[i];
                            if (atk == null) { writer.Write(HexParser.GetNullBlock(DataParser.ATTACK_BLOCK_SIZE)); }
                            else { writer.Write(DataParser.GetAttackBytes(atk)); }
                        }
                        for (i = 0; i < ATTACK_COUNT; ++i)
                        {
                            atk = AttackList[i];
                            if (atk == null) { writer.Write(HexParser.NULL_OFFSET_16_BIT); }
                            else { writer.Write(atk.Index); }
                        }
                        for (i = 0; i < ATTACK_COUNT; ++i)
                        {
                            atk = AttackList[i];
                            if (atk == null) { writer.Write(HexParser.GetNullBlock(NAME_LENGTH)); }
                            else
                            {
                                writer.Write(new FFText(atk.Name, NAME_LENGTH).GetBytes());
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
                            Array.Copy(AIContainer.GetGroupedScriptBlock(FORMATION_COUNT, Formation.AI_BLOCK_SIZE, formations,
                                ref formationAIoffset), formationAIRaw, Formation.AI_BLOCK_SIZE);

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
                            Array.Copy(AIContainer.GetGroupedScriptBlock(ENEMY_COUNT, Enemy.AI_BLOCK_SIZE, enemies,
                                ref enemyAIoffset), enemyAIraw, Enemy.AI_BLOCK_SIZE);

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

                //return a copy of the newly updated data
                var copy = new byte[rawData.Length];
                Array.Copy(rawData, copy, rawData.Length);
                return copy;
            }
            catch (Exception ex)
            {
                throw new FormatException(ex.Message);
            }
        }
    }
}
