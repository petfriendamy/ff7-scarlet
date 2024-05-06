using System.IO.Compression;
using System.Configuration;
using Shojy.FF7.Elena;
using FF7Scarlet.Compression;
using FF7Scarlet.KernelEditor;
using FF7Scarlet.SceneEditor;
using FF7Scarlet.ExeEditor;
using FF7Scarlet.Shared;

namespace FF7Scarlet
{
    public enum FormType { KernelEditor, SceneEditor, ExeEditor }
    public enum FileClass { EXE, Kernel, Kernel2, Scene, BattleLgp }

    public static class DataManager
    {
        private static StartupForm? startupForm = null;
        private static KernelForm? kernelForm = null;
        private static SceneEditorForm? sceneEditorForm = null;
        private static ExeEditorForm? exeEditorForm = null;
        private static readonly Scene[] sceneList = new Scene[Scene.SCENE_COUNT];
        private static readonly byte[] sceneLookupTable = new byte[64];
        private static Dictionary<ushort, Attack> syncedAttacks = new();

        public static string ExePath { get; private set; } = string.Empty;
        public static string VanillaExePath { get; private set; } = string.Empty;
        public static string KernelPath { get; private set; } = string.Empty;
        public static string Kernel2Path { get; private set; } = string.Empty;
        public static string ScenePath { get; private set; } = string.Empty;
        public static string BattleLgpPath { get; private set; } = string.Empty;
        public static ExeData? VanillaExe { get; private set; }
        public static Kernel? Kernel { get; private set; }
        public static BattleLgp? BattleLgp { get; private set; }
        public static bool MultiLinkedSlotsEnabled { get; set; }
        public static ExeConfigurationFileMap ConfigFile { get; } = new ExeConfigurationFileMap();

        //clipboard
        public static Scene? CopiedScene { get; set; }
        public static Enemy? CopiedEnemy { get; set; }
        public static Attack? CopiedAttack { get; set; }
        public static Formation? CopiedFormation { get; set; }

        public static bool ExePathExists
        {
            get { return !string.IsNullOrEmpty(ExePath); }
        }

        public static bool VanillaExePathExists
        {
            get { return !string.IsNullOrEmpty(VanillaExePath); }
        }

        public static bool KernelFilePathExists
        {
            get { return !string.IsNullOrEmpty(KernelPath); }
        }

        public static bool BothKernelFilePathsExist
        {
            get { return KernelFilePathExists && !string.IsNullOrEmpty(Kernel2Path); }
        }

        public static bool SceneFilePathExists
        {
            get { return !string.IsNullOrEmpty(ScenePath); }
        }

        public static bool BattleLgpPathExists
        {
            get { return !string.IsNullOrEmpty(BattleLgpPath); }
        }

        public static void SetStartupForm(StartupForm form)
        {
            if (startupForm != null)
            {
                throw new ArgumentException("Startup form already exists.");
            }
            startupForm = form;
        }

        public static void SetFilePath(FileClass fileClass, string path, bool isSetting = false)
        {
            if (ValidateFile(fileClass, path, isSetting))
            {
                if (fileClass != FileClass.BattleLgp && !isSetting)
                {
                    var result = MessageBox.Show("Would you like to auto-detect the other files based on this one's location?",
                        "Auto-Detect Files", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string? exeDir = null, languageDir = null, kernelDir = null, battleDir = null, temp;
                        string code = "en";

                        //figure out relative file paths
                        if (fileClass == FileClass.EXE)
                        {
                            //check for region code
                            string exeName = Path.GetFileNameWithoutExtension(path);
                            if (exeName.EndsWith("es")) { code = "es"; }
                            else if (exeName.EndsWith("fr")) { code = "fr"; }
                            else if (exeName.EndsWith("de")) { code = "de"; }

                            //find kernel and scene files
                            exeDir = Directory.GetParent(path)?.FullName;
                            if (exeDir != null)
                            {
                                kernelDir = exeDir + @"\data\lang-" + code + @"\kernel";
                                battleDir = exeDir + @"\data\lang-" + code + @"\battle";
                            }
                        }
                        else //kernel/scene
                        {
                            if (fileClass == FileClass.Scene)
                            {
                                battleDir = Path.GetDirectoryName(path);
                                if (battleDir != null)
                                {
                                    languageDir = Directory.GetParent(battleDir)?.FullName;
                                    if (languageDir != null)
                                    {
                                        kernelDir = languageDir + @"\kernel";
                                    }
                                }
                            }
                            else //kernel
                            {
                                kernelDir = Path.GetDirectoryName(path);
                                if (kernelDir != null)
                                {
                                    languageDir = Directory.GetParent(kernelDir)?.FullName;
                                    if (languageDir != null)
                                    {
                                        battleDir = languageDir + @"\battle";
                                    }
                                }
                            }

                            //get EXE directory
                            if (languageDir != null)
                            {
                                //check for region code
                                string? langDirName = Path.GetDirectoryName(languageDir);
                                if (langDirName != null)
                                {
                                    if (langDirName.EndsWith("es")) { code = "es"; }
                                    else if (langDirName.EndsWith("fr")) { code = "fr"; }
                                    else if (langDirName.EndsWith("de")) { code = "de"; }
                                }

                                temp = Directory.GetParent(languageDir)?.FullName;
                                if (temp != null)
                                {
                                    exeDir = Directory.GetParent(temp)?.FullName;
                                }
                            }
                        }

                        //attempt to find the files in their directories
                        if (exeDir != null && fileClass != FileClass.EXE)
                        {
                            if (!ValidateFile(FileClass.EXE, exeDir + @"\ff7_" + code + ".exe"))
                            {
                                ValidateFile(FileClass.EXE, exeDir + @"\FF7.exe");
                            }
                        }
                        if (kernelDir != null)
                        {
                            if (fileClass != FileClass.Kernel)
                            {
                                ValidateFile(FileClass.Kernel, kernelDir + @"\KERNEL.BIN");
                            }
                            if (fileClass != FileClass.Kernel2)
                            {
                                ValidateFile(FileClass.Kernel2, kernelDir + @"\kernel2.bin");
                            }
                        }
                        if (battleDir != null &&fileClass != FileClass.Scene)
                        {
                            ValidateFile(FileClass.Scene, battleDir + @"\scene.bin");
                        }
                    }
                }
            }
            else
            {
                throw new FileFormatException($"An error occurred while reading {Path.GetFileName(path)}.");
            }
        }

        private static bool ValidateFile(FileClass fileClass, string path, bool isSetting = false)
        {
            try
            {
                if (File.Exists(path))
                {
                    switch (fileClass)
                    {
                        case FileClass.EXE:
                            if (ExeData.ValidateEXE(path))
                            {
                                if (isSetting)
                                {
                                    if (ExeData.GetLanguage(path) == Language.English)
                                    {
                                        VanillaExePath = path;
                                        LoadVanillaEXE();
                                    }
                                    else { return false; }
                                }
                                else { ExePath = path; }
                                return true;
                            }
                            return false;
                        case FileClass.Kernel:
                            try
                            {
                                Kernel = new Kernel(path);
                                KernelPath = path;
                                return true;
                            }
                            catch { return false; }
                        case FileClass.Kernel2:
                            if (Kernel != null)
                            {
                                Kernel.MergeKernel2Data(path);
                                Kernel.ReloadBattleText();
                                Kernel2Path = path;
                            }
                            return true;
                        case FileClass.Scene:
                            try
                            {
                                LoadSceneBin(path);
                                return true;
                            }
                            catch { return false; }
                        case FileClass.BattleLgp:
                            try
                            {
                                BattleLgp = new BattleLgp(path);
                                BattleLgpPath = path;
                                return true;
                            }
                            catch { return false; }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static void LoadVanillaEXE()
        {
            if (VanillaExePathExists)
            {
                VanillaExe = new ExeData(VanillaExePath);
            }
        }

        public static void OpenForm(FormType type)
        {
            switch (type)
            {
                case FormType.KernelEditor:
                    if (kernelForm == null)
                    {
                        kernelForm = new KernelForm();
                        kernelForm.FormClosed += new FormClosedEventHandler(kernelFormClosed);
                        kernelForm.Show();
                    }
                    break;
                case FormType.SceneEditor:
                    if (sceneEditorForm == null)
                    {
                        sceneEditorForm = new SceneEditorForm(syncedAttacks);
                        sceneEditorForm.FormClosed += new FormClosedEventHandler(sceneFormClosed);
                        sceneEditorForm.Show();
                    }
                    break;
                case FormType.ExeEditor:
                    if (exeEditorForm == null)
                    {
                        exeEditorForm = new ExeEditorForm();
                        exeEditorForm.FormClosed += new FormClosedEventHandler(exeFormClosed);
                        exeEditorForm.Show();
                    }
                    break;
            }
        }

        public static bool FormIsOpen(FormType type)
        {
            switch (type)
            {
                case FormType.KernelEditor:
                    return kernelForm != null;
                case FormType.SceneEditor:
                    return sceneEditorForm != null;
                case FormType.ExeEditor:
                    return exeEditorForm != null;
            }
            return false;
        }

        public static Kernel CopyKernel()
        {
            if (!KernelFilePathExists)
            {
                throw new FileNotFoundException("No kernel file is loaded.");
            }
            else
            {
                var k = new Kernel(KernelPath);
                if (BothKernelFilePathsExist)
                {
                    k.MergeKernel2Data(Kernel2Path);
                    k.ReloadBattleText();
                }
                for (int i = 0; i < Kernel.ATTACK_COUNT; ++i)
                {
                    ushort id = k.Attacks[i].ID;
                    if (AttackIsSynced(id))
                    {
                        k.Attacks[i] = syncedAttacks[id];
                    }
                }
                return k;
            }
        }

        public static Scene[] CopySceneList()
        {
            var copy = new Scene[Scene.SCENE_COUNT];
            for (int i = 0; i < Scene.SCENE_COUNT; ++i)
            {
                copy[i] = new Scene(sceneList[i]);
            }
            return copy;
        }

        public static void UpdateScene(Form caller, Scene newScene, int pos)
        {
            sceneList[pos] = new Scene(newScene);
        }

        public static void UpdateAllScenes(Form caller, Scene[] newScenes)
        {
            for (int i = 0; i < Scene.SCENE_COUNT; ++i)
            {
                UpdateScene(caller, newScenes[i], i);
            }
        }

        public static bool LookupTableIsCorrect()
        {
            if (KernelFilePathExists && SceneFilePathExists && Kernel != null)
            {
                var table = Kernel.GetLookupTable();
                for (int i = 0; i < 64; ++i)
                {
                    if (table[i] != sceneLookupTable[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void SyncLookupTable()
        {
            if (KernelFilePathExists && SceneFilePathExists && Kernel != null)
            {
                Kernel.UpdateLookupTable(sceneLookupTable);
                if (kernelForm == null) //kernel form is not open, so update lookup table quietly
                {
                    CreateKernel(false);
                }
                else //kernel form is open, so sync the lookup table over there
                {
                    kernelForm.UpdateLookupTable(sceneLookupTable);
                }
            }
        }

        public static int SyncAttack(Attack attack, bool syncInternal)
        {
            //make a copy of the attack to keep in the sync list
            var newAtk = new Attack(attack.ID, attack.Name, attack.GetRawData());
            if (syncedAttacks.ContainsKey(attack.ID)) { syncedAttacks[attack.ID] = newAtk; } 
            else { syncedAttacks.Add(attack.ID, newAtk); }

            //if the scene editor is open, sync data over there
            if (sceneEditorForm != null)
            {
                syncInternal = false;
            }

            if (syncInternal)
            {
                //make another copy of the attack to keep separate from unsaved data
                var newAtkInner = new Attack(attack.ID, attack.Name, attack.GetRawData());
                int count = 0;
                foreach (var s in sceneList)
                {
                    count += s.SyncAttack(newAtkInner);
                }
                return count;
            }
            return 1;
        }

        public static void UnsyncAttack(ushort id)
        {
            syncedAttacks.Remove(id);
        }

        public static bool AttackIsSynced(ushort id)
        {
            if (syncedAttacks.ContainsKey(id))
            {
                return true;
            }
            return false;
        }

        public static Dictionary<ushort, Attack> CopySyncedAttacks()
        {
            var copy = new Dictionary<ushort, Attack>();
            foreach (var s in syncedAttacks)
            {
                copy.Add(s.Key, s.Value);
            }
            return copy;
        }

        public static void CreateKernel(bool updateKernel2, Kernel? kernel = null)
        {
            bool reload = kernel != null;
            ushort i;
            if (!reload) //load default kernel
            {
                kernel = Kernel;
            }
            if (kernel == null) //if kernel is still null, error
            {
                throw new FileNotFoundException("No kernel.bin file is loaded.");
            }

            var data = new List<byte>();
            byte[] uncompressedSection, compressedSection;
            ushort compressedLength, uncompressedLength;
            for (i = 0; i < Kernel.SECTION_COUNT; ++i)
            {
                uncompressedSection = kernel.GetSectionRawData((KernelSection)(i + 1));
                uncompressedLength = (ushort)uncompressedSection.Length;
                compressedSection = GetCompressedData(uncompressedSection);
                compressedLength = (ushort)compressedSection.Length;

                data.AddRange(BitConverter.GetBytes(compressedLength));
                data.AddRange(BitConverter.GetBytes(uncompressedLength));
                if (i >= Kernel.KERNEL1_END)
                {
                    data.AddRange(BitConverter.GetBytes((ushort)Kernel.KERNEL1_END));
                }
                else { data.AddRange(BitConverter.GetBytes(i)); }
                data.AddRange(compressedSection);
            }
            File.WriteAllBytes(KernelPath, data.ToArray());

            if (updateKernel2 && BothKernelFilePathsExist) //create kernel2
            {
                data.Clear();
                for (i = Kernel.KERNEL1_END; i < Kernel.SECTION_COUNT; ++i)
                {
                    uncompressedSection = kernel.GetSectionRawData((KernelSection)(i + 1), true);
                    data.AddRange(BitConverter.GetBytes(uncompressedSection.Length));
                    data.AddRange(uncompressedSection);
                }

                //compress the data
                using (var ms = new MemoryStream(data.ToArray()))
                using (var compress = new MemoryStream())
                {
                    Lzs.Encode(ms, compress);
                    compressedSection = compress.ToArray();
                }

                //write it to the file
                data.Clear();
                data.AddRange(BitConverter.GetBytes(compressedSection.Length));
                data.AddRange(compressedSection);
                File.WriteAllBytes(Kernel2Path, data.ToArray());
            }

            if (reload) //reload the kernel
            {
                Kernel = new Kernel(KernelPath);
            }
        }

        private static void LoadSceneBin(string path)
        {
            //based on code from SegaChief; thanks!
            var fileData = File.ReadAllBytes(path);

            int i, j, currScene = 0, currBlock = 0;
            uint currHeader, nextHeader, currOffset = 0;
            var sceneOffset = new uint[Scene.SCENE_COUNT];
            var sceneSize = new uint[Scene.SCENE_COUNT];
            byte[] compressedData, headerBytes = new byte[4];

            //fill the scene lookup table with 0xFF
            for (i = 0; i < 64; ++i)
            {
                sceneLookupTable[i] = 0xFF;
            }

            //get headers for each of the scene files
            while (currOffset < fileData.Length)
            {
                sceneLookupTable[currBlock] = (byte)currScene;
                j = 0;
                for (i = 0; i < Scene.HEADER_COUNT; ++i)
                {
                    Array.Copy(fileData, currOffset + j, headerBytes, 0, 4);
                    currHeader = BitConverter.ToUInt32(headerBytes, 0);
                    if (currHeader != HexParser.NULL_OFFSET_32_BIT) //check if offset exists first
                    {
                        //determine if the next offset exists or not
                        if (i < 15)
                        {
                            Array.Copy(fileData, currOffset + j + 4, headerBytes, 0, 4);
                            nextHeader = BitConverter.ToUInt32(headerBytes, 0);
                        }
                        else { nextHeader = HexParser.NULL_OFFSET_32_BIT; }

                        //get the offset and size of this compressed file
                        sceneOffset[currScene] = (currHeader * 4) + currOffset;
                        if (nextHeader == HexParser.NULL_OFFSET_32_BIT)
                        {
                            sceneSize[currScene] = Scene.COMPRESSED_BLOCK_SIZE - (currHeader * 4);
                        }
                        else
                        {
                            sceneSize[currScene] = (nextHeader - currHeader) * 4;
                        }
                        currScene++;
                    }
                    j += 4;
                }
                currOffset += Scene.COMPRESSED_BLOCK_SIZE;
                currBlock++;
            }

            //get and decompress each of the scene files
            int decompressedSize;
            for (i = 0; i < Scene.SCENE_COUNT; ++i)
            {
                compressedData = new byte[sceneSize[i]];
                Array.Copy(fileData, sceneOffset[i], compressedData, 0, sceneSize[i]);
                var uncompressedData = new byte[Scene.UNCOMPRESSED_BLOCK_SIZE];

                using (var inputStream = new MemoryStream(compressedData))
                using (var outputStream = new MemoryStream())
                using (var gzipper = new GZipStream(inputStream, CompressionMode.Decompress))
                {
                    while ((decompressedSize = gzipper.Read(uncompressedData, 0, Scene.UNCOMPRESSED_BLOCK_SIZE)) != 0)
                    {
                        outputStream.Write(uncompressedData, 0, decompressedSize);
                    }
                }
                sceneList[i] = new Scene(ref uncompressedData);
            }
            ScenePath = path;
        }

        public static void CreateSceneBin()
        {
            //again, based on code from SegaChief
            if (!SceneFilePathExists || ScenePath == null)
            {
                throw new FileNotFoundException("No scene.bin file is loaded.");
            }

            var compressedScenes = new List<byte[]> { };
            byte[] compressedData;
            var headers = new uint[Scene.SCENE_COUNT];
            var sceneBlock = new int[Scene.SCENE_COUNT];
            var blockSize = new List<uint> { };
            int i, j, n = 0, currBlock = 0, currScene = 0;
            uint currHeader = Scene.HEADER_COUNT * 4, calculatedSize;

            //fill the scene lookup table with 0xFF
            for (i = 0; i < 64; ++i)
            {
                sceneLookupTable[i] = 0xFF;
            }
            sceneLookupTable[0] = 0; //always 0

            //create the scene.bin
            for (i = 0; i < Scene.SCENE_COUNT; ++i)
            {
                compressedData = GetCompressedData(sceneList[i].GetRawData());

                if (compressedData.Length % 4 != 0) //must be a multiple of 4
                {
                    var temp = compressedData.ToList();
                    do
                    {
                        temp.Add(0xFF);
                        j = temp.Count;
                    } while (j % 4 != 0);
                    compressedData = temp.ToArray();
                }
                compressedScenes.Add(compressedData);

                //calculate position of this scene
                n++;
                calculatedSize = currHeader + (uint)compressedData.Length;
                if (n >= Scene.HEADER_COUNT || calculatedSize >= Scene.COMPRESSED_BLOCK_SIZE)
                {
                    n = 0;
                    blockSize.Add(calculatedSize);
                    currBlock++;
                    currHeader = Scene.HEADER_COUNT * 4;
                    sceneLookupTable[currBlock] = (byte)i;
                }
                headers[i] = currHeader / 4;
                currHeader += (uint)compressedData.Length;
                sceneBlock[i] = currBlock;
            }
            blockSize.Add(currHeader);

            //write the compressed data to a file
            using (var fs = new FileStream(ScenePath, FileMode.Create))
            using (var writer = new BinaryWriter(fs))
            {
                for (i = 0; i < blockSize.Count; ++i)
                {
                    //write headers for this block
                    for (j = 0; j < Scene.HEADER_COUNT; ++j)
                    {
                        if (currScene + j < Scene.SCENE_COUNT && sceneBlock[currScene + j] == i)
                        {
                            writer.Write(headers[currScene + j]);
                        }
                        else { writer.Write(HexParser.NULL_OFFSET_32_BIT); }
                    }

                    //write the scenes assigned to this block
                    while (currScene < Scene.SCENE_COUNT && sceneBlock[currScene] == i)
                    {
                        writer.Write(compressedScenes[currScene]);
                        currScene++;
                    }

                    //add padding until the block is full
                    while (fs.Length % Scene.COMPRESSED_BLOCK_SIZE != 0)
                    {
                        writer.Write((byte)0xFF);
                    }
                }
            }

            //update the scene lookup table in the kernel
            if (!LookupTableIsCorrect())
            {
                SyncLookupTable();
            }
        }

        private static byte[] GetCompressedData(byte[] uncompressedData)
        {
            byte[] compressedData;
            using (var outputStream = new MemoryStream())
            {
                using (var gzipper = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    gzipper.Write(uncompressedData, 0, uncompressedData.Length);
                }
                compressedData = outputStream.ToArray();
            }
            return compressedData;
        }

        private static void kernelFormClosed(object? sender, FormClosedEventArgs e)
        {
            kernelForm = null;
            startupForm?.EnableFormButton(FormType.KernelEditor);
        }

        private static void sceneFormClosed(object? sender, FormClosedEventArgs e)
        {
            sceneEditorForm = null;
            startupForm?.EnableFormButton(FormType.SceneEditor);
        }

        private static void exeFormClosed(object? sender, FormClosedEventArgs e)
        {
            exeEditorForm = null;
            startupForm?.EnableFormButton(FormType.ExeEditor);
        }
    }
}
