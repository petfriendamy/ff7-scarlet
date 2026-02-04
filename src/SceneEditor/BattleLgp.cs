//using Shojy.FF7.Elena;
using KimeraCS.Core;
using static KimeraCS.Core.FF7BattleAnimationsPack;
using static KimeraCS.Core.FF7BattleSkeleton;

namespace FF7Scarlet.SceneEditor
{
    public class BattleLgp
    {
        private const ushort ARENA_OFFSET = 370;

        public struct ModelData
        {
            public readonly string Name;
            public readonly byte[] Skeleton;
            public readonly byte[][] PFiles;
            public readonly byte[] Animations;
            public readonly byte[][] Textures;

            public ModelData(string name, byte[] skeleton, byte[][] pFiles, byte[] animations, byte[][] textures)
            {
                Name = name;
                Skeleton = skeleton;
                PFiles = pFiles;
                Animations = animations;
                Textures = textures;
            }
        }
        //private LgpReader reader;
        //private string[] models;
        //private ReadOnlyCollection<string> modelsFull;
        public const string CONFIG_KEY = "BattleLgpPath";
        private ModelData[] models;

        public ModelData[] Models
        {
            get { return models; }
        }

        public BattleLgp(string path)
        {
            if (Path.GetFileName(path) != "battle.lgp")
            {
                throw new ArgumentException("Invalid file.");
            }

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(stream))
            {
                reader.ReadBytes(12); //header
                int fileCount = reader.ReadInt32();
                var names = new string[fileCount];
                var pointers = new uint[fileCount];
                int i;

                //read the headers
                for (i = 0; i < fileCount; ++i)
                {
                    names[i] = new string(reader.ReadChars(20)).TrimEnd('\0');
                    pointers[i] = reader.ReadUInt32();
                    reader.ReadByte(); //options
                    reader.ReadInt16(); //dupes
                }

                //read the files
                var files = new Dictionary<string, byte[]> { };
                int fileLength;
                for (i = 0; i < fileCount; ++i)
                {
                    stream.Seek(pointers[i], SeekOrigin.Begin);
                    reader.ReadBytes(20); //names, again!
                    fileLength = reader.ReadInt32();
                    files.Add(names[i], reader.ReadBytes(fileLength));
                }

                //get the other files
                var sortedFiles =
                    (from f in files
                     orderby f.Key
                     select f.Key).ToArray();

                var modelNames =
                    (from f in sortedFiles
                     where f.EndsWith("aa")
                     select f).ToArray();

                models = new ModelData[modelNames.Count()];
                var pFilesList = new List<byte[]> { };
                var texturesList = new List<byte[]> { };
                bool processPFiles = false, processTextures = false;
                string currentModel = string.Empty;
                i = -1;
                foreach (var f in sortedFiles)
                {
                    if (f.EndsWith("da")) //animation file
                    {
                        models[i] = new ModelData(modelNames[i], files[modelNames[i]],
                            pFilesList.ToArray(), files[f], texturesList.ToArray());
                        pFilesList.Clear();
                        texturesList.Clear();
                        processPFiles = false;
                        processTextures = false;
                        i++;
                        if (i < modelNames.Length)
                        {
                            currentModel = modelNames[i];
                        }
                    }
                    else if (f.EndsWith("aa") && f != currentModel) //lacking animation data
                    {
                        if (i >= 0)
                        {
                            models[i] = new ModelData(modelNames[i], files[currentModel],
                                pFilesList.ToArray(), Array.Empty<byte>(), texturesList.ToArray());
                        }
                        pFilesList.Clear();
                        texturesList.Clear();
                        processPFiles = false;
                        processTextures = false;
                        currentModel = f;
                        i++;
                    }
                    else if (processPFiles || f.EndsWith('m')) //P file
                    {
                        processPFiles = true;
                        pFilesList.Add(files[f]);
                    }
                    else if (processTextures || f.EndsWith('c')) //textures
                    {
                        processTextures = true;
                        texturesList.Add(files[f]);
                    }
                }
            }
        }

        public BattleSkeleton? GetModelData(ushort modelID)
        {
            if (modelID < models.Length)
            {
                return new BattleSkeleton(models[modelID].Skeleton,
                    models[modelID].PFiles, models[modelID].Textures, models[modelID].Name);
                
            }
            return null;
        }

        public BattleAnimationsPack? GetAnimationData(BattleSkeleton skeleton, ushort modelID)
        {
            if (modelID < models.Length)
            {
                return new BattleAnimationsPack(skeleton, ModelType.K_AA_SKELETON, models[modelID].Animations,
                    models[modelID].Name);
            }
            return null;
        }

        public BattleSkeleton? GetBattleArena(ushort modelID)
        {
            return GetModelData((ushort)(modelID + ARENA_OFFSET));
        }
    }
}
