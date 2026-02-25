using System.Configuration;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Characters;
using FF7Scarlet.Compression;
using FF7Scarlet.KernelEditor;
using FF7Scarlet.SceneEditor;
using FF7Scarlet.ExeEditor;

namespace FF7Scarlet.Shared
{
    public enum FormType { KernelEditor, SceneEditor, ExeEditor }
    public enum FileClass { Exe, VanillaExe, Kernel, Kernel2, Scene, BattleLgp }

    public static class DataManager
    {
        private static StartupForm? startupForm = null;
        private static KernelForm? kernelForm = null;
        private static SceneEditorForm? sceneEditorForm = null;
        private static ExeEditorForm? exeEditorForm = null;
        private static Scene[] sceneList = new Scene[Scene.SCENE_COUNT];
        private static byte[] sceneLookupTable = new byte[64];
        private static Dictionary<ushort, Attack> syncedAttacks = new();

        public static StatusChangeType[] StatusChangeTypes { get; } = Enum.GetValues<StatusChangeType>();

        public static string ExePath { get; private set; } = string.Empty;
        public static string VanillaExePath { get; private set; } = string.Empty;
        public static string KernelPath { get; private set; } = string.Empty;
        public static string Kernel2Path { get; private set; } = string.Empty;
        public static string ScenePath { get; private set; } = string.Empty;
        public static string BattleLgpPath { get; private set; } = string.Empty;
        public static ExeData? ExeData { get; private set; }
        public static ExeData? VanillaExe { get; private set; }
        public static Kernel? Kernel { get; private set; }
        public static BattleLgp? BattleLgp { get; private set; }
        public static bool RememberLastOpened { get; set; } = true;
        public static CompressionType CompressionType { get; set; } = CompressionType.Standard;
        public static bool PS3TweaksEnabled { get; set; }
        public static ExeConfigurationFileMap ConfigFile { get; } = new ExeConfigurationFileMap();
        public static ScarletUpdater Updater { get; } = new ScarletUpdater();

        public const string
            REMEMBER_LAST_OPENED_KEY = "RememberLastOpened",
            COMPRESSION_TYPE_KEY = "CompressionType",
            PS3_TWEAKS_KEY = "PS3TweaksEnabled";

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

        public static void SetFilePath(FileClass fileClass, string path, bool suppressRelativeCheck = false, bool isJPoriginal = false)
        {
            int isValid = ValidateFile(fileClass, path, isJPoriginal);
            if (isValid == 1)
            {
                if (fileClass != FileClass.VanillaExe && fileClass != FileClass.BattleLgp && !suppressRelativeCheck)
                {
                    if (MessageDialog.AskYesNo("Would you like to auto-detect the other files based on this one's location?",
                        "Auto-Detect Files"))
                    {
                        string? exeDir = null,
                            parentDir = null,
                            kernelDir = null,
                            battleDir = null,
                            temp = null;
                        string code = "en";
                        EXEVersion version = EXEVersion.Steam2013;

                        //figure out relative file paths
                        if (fileClass == FileClass.Exe)
                        {
                            //check for version
                            code = ExeData.GetLanguageCode(path);
                            version = ExeData.GetEXEVersion(path);

                            //find kernel and scene files
                            exeDir = Directory.GetParent(path)?.FullName;
                            if (!string.IsNullOrEmpty(exeDir))
                            {
                                if (version == EXEVersion.Steam2026) //completely different file structure
                                {
                                    temp = Directory.GetParent(exeDir)?.FullName;
                                    if (!string.IsNullOrEmpty(temp))
                                    {
                                        temp = Directory.GetParent(temp)?.FullName;
                                        if (!string.IsNullOrEmpty(temp))
                                        {
                                            temp = Path.Combine(temp, "workingdir");
                                            if (!string.IsNullOrEmpty(temp))
                                            {
                                                kernelDir = Path.Combine(temp, "data");
                                                battleDir = Path.Combine(temp, "data");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    kernelDir = Path.Combine(exeDir, "data");
                                    battleDir = Path.Combine(exeDir, "data");
                                }
                                
                                //get the file paths
                                if (!string.IsNullOrEmpty(kernelDir) && !string.IsNullOrEmpty(battleDir))
                                {
                                    if (version != EXEVersion.Original)
                                    {
                                        kernelDir = Path.Combine(kernelDir, $"lang-{code}");
                                        battleDir = Path.Combine(battleDir, $"lang-{code}");
                                    }
                                    kernelDir = Path.Combine(kernelDir, "kernel");
                                    battleDir = Path.Combine(battleDir, "battle");
                                }
                            }
                        }
                        else //kernel/scene
                        {
                            if (fileClass == FileClass.Scene)
                            {
                                battleDir = Path.GetDirectoryName(path);
                                if (!string.IsNullOrEmpty(battleDir))
                                {
                                    parentDir = Directory.GetParent(battleDir)?.FullName;
                                    if (!string.IsNullOrEmpty(parentDir))
                                    {
                                        kernelDir = Path.Combine(parentDir, "kernel");
                                    }
                                }
                            }
                            else //kernel
                            {
                                kernelDir = Path.GetDirectoryName(path);
                                if (!string.IsNullOrEmpty(kernelDir))
                                {
                                    parentDir = Directory.GetParent(kernelDir)?.FullName;
                                    if (!string.IsNullOrEmpty(parentDir))
                                    {
                                        battleDir = Path.Combine(parentDir, "battle");
                                    }
                                }
                            }

                            //get EXE directory
                            if (!string.IsNullOrEmpty(parentDir))
                            {
                                //check for region code
                                var parentDirName = Path.GetDirectoryName(parentDir + '\\');
                                if (!string.IsNullOrEmpty(parentDirName))
                                {
                                    if (parentDirName.EndsWith("en")) { code = "en"; }
                                    else if (parentDirName.EndsWith("es")) { code = "es"; }
                                    else if (parentDirName.EndsWith("fr")) { code = "fr"; }
                                    else if (parentDirName.EndsWith("de")) { code = "de"; }
                                    else if (parentDirName.EndsWith("ja")) { code = "ja"; }
                                    else //no region code, assume 1998 version
                                    {
                                        version = EXEVersion.Original;
                                    }
                                }

                                temp = parentDir;
                                if (version != EXEVersion.Original)
                                {
                                    temp = Directory.GetParent(temp)?.FullName;
                                    if (!string.IsNullOrEmpty(temp))
                                    {
                                        //check if this is the 2026 version
                                        var temp2 = Directory.GetParent(temp)?.FullName;
                                        if (!string.IsNullOrEmpty(temp2) && temp2.EndsWith("workingdir"))
                                        {
                                            version = EXEVersion.Steam2026;
                                            temp = Directory.GetParent(temp2)?.FullName;
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(temp))
                                {
                                    if (version == EXEVersion.Steam2026)
                                    {
                                        exeDir = Path.Combine(temp, "resources", "ff7_1.02");
                                    }
                                    else
                                    {
                                        exeDir = Directory.GetParent(temp)?.FullName;
                                    }
                                }
                            }
                        }

                        //attempt to find the files in their directories
                        if (!string.IsNullOrEmpty(exeDir) && fileClass != FileClass.Exe)
                        {
                            switch (version)
                            {
                                case EXEVersion.Original:
                                    temp = Path.Combine(exeDir, "FF7.exe");
                                    break;
                                case EXEVersion.Steam2013:
                                    temp = Path.Combine(exeDir, $"ff7_{code}.exe");
                                    break;
                                case EXEVersion.Steam2026:
                                    temp = Path.Combine(exeDir, $"ff7_{code}");
                                    break;
                            }
                            ValidateFile(FileClass.Exe, temp);
                        }
                        if (!string.IsNullOrEmpty(kernelDir))
                        {
                            if (fileClass != FileClass.Kernel)
                            {
                                temp = Path.Combine(kernelDir, "KERNEL.BIN");
                                ValidateFile(FileClass.Kernel, temp);
                            }
                            if (fileClass != FileClass.Kernel2)
                            {
                                temp = Path.Combine(kernelDir, "kernel2.bin");
                                ValidateFile(FileClass.Kernel2, temp);
                            }
                        }
                        if (!string.IsNullOrEmpty(battleDir) && fileClass != FileClass.Scene)
                        {
                            temp = Path.Combine(battleDir, "scene.bin");
                            ValidateFile(FileClass.Scene, temp);
                        }
                    }
                }
            }
            else if (isValid == 2) //unsupported EXE
            {
                MessageDialog.ShowError("This version of the EXE is unsupported.");
            }
            else if (isValid == 3) //2026 EXE
            {
                MessageDialog.ShowInfo(@"This is the wrong EXE. Redirecting to ff7\resources\ff7_1.02");
                var newPath = ExeData.Get2026EXEPath(path);
                if (!string.IsNullOrEmpty(newPath))
                {
                    SetFilePath(FileClass.Exe, newPath, suppressRelativeCheck);
                }
            }
            else
            {
                MessageDialog.ShowError("The file appears to be invalid.");
            }
        }

        public static void ClearFilePath(FileClass fileClass)
        {
            switch (fileClass)
            {
                case FileClass.Kernel:
                    KernelPath = string.Empty;
                    Kernel = null;
                    break;
                case FileClass.Kernel2:
                    Kernel2Path = string.Empty;
                    break;
                case FileClass.Scene:
                    ScenePath = string.Empty;
                    sceneList = new Scene[Scene.SCENE_COUNT];
                    break;
                case FileClass.Exe:
                    ExePath = string.Empty;
                    ExeData = null;
                    break;
                case FileClass.VanillaExe:
                    VanillaExePath = string.Empty;
                    VanillaExe = null;
                    break;
                case FileClass.BattleLgp:
                    BattleLgpPath = string.Empty;
                    BattleLgp = null;
                    break;
            }
        }

        private static int ValidateFile(FileClass fileClass, string? path, bool isJPoriginal = false)
        {
            try
            {
                if (File.Exists(path))
                {
                    switch (fileClass)
                    {
                        case FileClass.Exe:
                        case FileClass.VanillaExe:
                            int isValid = ExeData.ValidateEXE(path, fileClass == FileClass.VanillaExe);
                            if (isValid == 1)
                            {
                                if (fileClass == FileClass.VanillaExe)
                                {
                                    if (ExeData.GetLanguage(path) == Language.English)
                                    {
                                        VanillaExePath = path;
                                        LoadVanillaEXE();
                                    }
                                    else { return 0; }
                                }
                                else
                                {
                                    ExeData = new ExeData(path);
                                    ExePath = path;
                                }
                            }
                            return isValid;
                        case FileClass.Kernel:
                            try
                            {
                                Kernel = new Kernel(path);
                                KernelPath = path;
                                return 1;
                            }
                            catch { return 0; }
                        case FileClass.Kernel2:
                            if (Kernel != null)
                            {
                                Kernel.MergeKernel2Data(path);
                                //Kernel.ReloadBattleText();
                                Kernel2Path = path;
                            }
                            return 1;
                        case FileClass.Scene:
                            try
                            {
                                LoadSceneBin(path, isJPoriginal);
                                return 1;
                            }
                            catch { return 0; }
                        case FileClass.BattleLgp:
                            try
                            {
                                BattleLgp = new BattleLgp(path);
                                BattleLgpPath = path;
                                return 1;
                            }
                            catch { return 0; }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
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
                        kernelForm.FormClosed += kernelFormClosed;
                        kernelForm.Show();
                    }
                    break;
                case FormType.SceneEditor:
                    if (sceneEditorForm == null)
                    {
                        sceneEditorForm = new SceneEditorForm(syncedAttacks);
                        sceneEditorForm.FormClosed += sceneFormClosed;
                        sceneEditorForm.Show();
                    }
                    break;
                case FormType.ExeEditor:
                    if (exeEditorForm == null)
                    {
                        exeEditorForm = new ExeEditorForm();
                        exeEditorForm.FormClosed += exeFormClosed;
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
                    //k.ReloadBattleText();
                }
                for (int i = 0; i < Kernel.ATTACK_COUNT; ++i)
                {
                    ushort id = (ushort)k.AttackData.Attacks[i].Index;
                    if (AttackIsSynced(id))
                    {
                        k.AttackData.Attacks[i] = syncedAttacks[id];
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

        public static byte GetChunkStart(int chunk)
        {
            if (chunk >= 0 && chunk < Scene.BLOCK_COUNT)
            {
                return sceneLookupTable[chunk];
            }
            return 0;
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

        public static void MergeCharacterData(Kernel kernel)
        {
            if (ExeData != null && ExeData.CaitSith != null && ExeData.Vincent != null)
            {
                MergeCharacters(kernel.CharacterList[6], ExeData.CaitSith);
                MergeCharacters(kernel.CharacterList[7], ExeData.Vincent);
            }
        }

        private static void MergeCharacters(Character source, Character dest)
        {
            dest.StrengthCurveIndex = source.StrengthCurveIndex;
            dest.VitalityCurveIndex = source.VitalityCurveIndex;
            dest.MagicCurveIndex = source.MagicCurveIndex;
            dest.SpiritCurveIndex = source.SpiritCurveIndex;
            dest.DexterityCurveIndex = source.DexterityCurveIndex;
            dest.LuckCurveIndex = source.LuckCurveIndex;
            dest.HPCurveIndex = source.HPCurveIndex;
            dest.MPCurveIndex = source.MPCurveIndex;
            dest.EXPCurveIndex = source.EXPCurveIndex;
        }

        public static int SyncAttack(Attack attack, bool syncInternal)
        {
            //make a copy of the attack to keep in the sync list
            var newAtk = DataParser.CopyAttack(attack);
            if (syncedAttacks.ContainsKey((ushort)attack.Index)) { syncedAttacks[(ushort)attack.Index] = newAtk; } 
            else { syncedAttacks.Add((ushort)attack.Index, newAtk); }

            //if the scene editor is open, sync data over there
            if (sceneEditorForm != null)
            {
                syncInternal = false;
            }

            if (syncInternal)
            {
                //make another copy of the attack to keep separate from unsaved data
                var newAtkInner = DataParser.CopyAttack(attack);
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
            if (!reload) //load default kernel
            {
                kernel = Kernel;
            }
            if (kernel == null) //if kernel is still null, error
            {
                throw new FileNotFoundException("No kernel.bin file is loaded.");
            }

            Gzip.CreateKernel(kernel, DataManager.CompressionType, KernelPath,
                updateKernel2 ? Kernel2Path : null);

            if (reload) //reload the kernel
            {
                Kernel = new Kernel(KernelPath);
            }
        }

        private static void LoadSceneBin(string path, bool isJPoriginal)
        {
            sceneList = Gzip.GetDecompressedSceneList(path, ref sceneLookupTable, isJPoriginal);
            ScenePath = path;
        }

        public static void CreateSceneBin()
        {
            if (SceneFilePathExists)
            {
                File.WriteAllBytes(ScenePath,
                    Gzip.CompressSceneBin(sceneList, ref sceneLookupTable, CompressionType));

                //update the scene lookup table in the kernel
                if (!LookupTableIsCorrect())
                {
                    SyncLookupTable();
                }
            }
        }

        public static void UpdateSettingsFilePath(FileClass fileClass)
        {
            var config = ConfigurationManager.OpenMappedExeConfiguration(ConfigFile,
                        ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;

            if (settings == null)
            {
                throw new FileLoadException("Config file could not be loaded.");
            }

            switch (fileClass)
            {
                case FileClass.VanillaExe:
                    if (VanillaExePathExists)
                    {
                        UpdateSetting(ref settings, ExeData.VANILLA_CONFIG_KEY, VanillaExePath);
                    }
                    break;
                case FileClass.BattleLgp:
                    if (BattleLgpPathExists)
                    {
                        UpdateSetting(ref settings, BattleLgp.CONFIG_KEY, BattleLgpPath);
                    }
                    break;
            }
            config.Save();
        }

        private static void UpdateSetting(ref KeyValueConfigurationCollection settings, string key, string? value)
        {
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
        }

        public static string GetBackupPath(string path)
        {
            string ext = Path.GetExtension(path);
            return path.Substring(0, path.LastIndexOf('.')) + $"-bak{ext}";
        }

        public static void CreateBackupFile(string path)
        {
            if (File.Exists(path))
            {
                int i = 1;
                var backup = GetBackupPath(path);
                while (File.Exists(backup))
                {
                    i++;
                    backup = path.Substring(0, path.LastIndexOf('-')) + $"-bak{i}.bin";
                }
                File.Copy(path, backup);
            }
        }

        private static void kernelFormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender is Form form)
            {
                form.FormClosed -= kernelFormClosed;
            }
            kernelForm = null;
            startupForm?.EnableFormButton(FormType.KernelEditor);
        }

        private static void sceneFormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender is Form form)
            {
                form.FormClosed -= sceneFormClosed;
            }
            sceneEditorForm = null;
            startupForm?.EnableFormButton(FormType.SceneEditor);
        }

        private static void exeFormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender is Form form)
            {
                form.FormClosed -= exeFormClosed;
            }
            exeEditorForm = null;
            startupForm?.EnableFormButton(FormType.ExeEditor);
        }
    }
}
