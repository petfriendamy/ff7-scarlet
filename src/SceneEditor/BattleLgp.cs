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

                // Use skeleton header to look up p-files and textures by their expected names
                i = -1;
                string currentModel = string.Empty;

                foreach (var f in sortedFiles)
                {
                    if (f.EndsWith("aa") && f != currentModel) //new skeleton
                    {
                        if (i >= 0)
                        {
                            models[i] = BuildModelData(modelNames[i], files[modelNames[i]],
                                Array.Empty<byte>(), files);
                        }
                        currentModel = f;
                        i++;
                    }
                    else if (f.EndsWith("da")) //animation file
                    {
                        models[i] = BuildModelData(modelNames[i], files[modelNames[i]],
                            files[f], files);
                        i++;
                        if (i < modelNames.Length)
                        {
                            currentModel = modelNames[i];
                        }
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

        /// <summary>
        /// Build ModelData by reading skeleton header to determine p-file and texture counts,
        /// then looking up files by their expected names from the archive.
        /// </summary>
        private static ModelData BuildModelData(string skeletonName, byte[] skeletonData,
            byte[] animationData, Dictionary<string, byte[]> archiveFiles)
        {
            // Read nTextures and nBones from skeleton header
            int nTextures = 0;
            int nBones = 0;
            using (var ms = new MemoryStream(skeletonData))
            using (var br = new BinaryReader(ms))
            {
                br.ReadInt32(); // skeletonType
                br.ReadInt32(); // unk1
                br.ReadInt32(); // unk2
                nBones = br.ReadInt32();
                br.ReadInt32(); // unk3
                br.ReadInt32(); // nJoints
                nTextures = br.ReadInt32();
            }

            string prefix = skeletonName.Substring(0, 2);

            // Load textures by expected names: {prefix}ac, {prefix}ad, etc.
            var texturesList = new List<byte[]>();
            char texSuffix = 'c';
            for (int t = 0; t < nTextures && texSuffix <= 'z'; t++, texSuffix++)
            {
                string texName = prefix + "a" + texSuffix;
                if (archiveFiles.TryGetValue(texName, out var texData))
                {
                    texturesList.Add(texData);
                }
            }

            // Load p-files by expected bone names: {prefix}am, {prefix}an, etc.
            // Counter increments for each bone, matching BattleSkeleton constructor logic
            var pFilesList = new List<byte[]>();
            char s1 = 'a', s2 = 'm';
            for (int b = 0; b < nBones; b++)
            {
                string pFileName = prefix + s1 + s2;
                if (archiveFiles.TryGetValue(pFileName, out var pData))
                {
                    pFilesList.Add(pData);
                }

                s2++;
                if (s2 > 'z')
                {
                    s1++;
                    s2 = 'a';
                }
            }

            return new ModelData(skeletonName, skeletonData,
                pFilesList.ToArray(), animationData, texturesList.ToArray());
        }
    }
}
