using Shojy.FF7.Elena;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF7Scarlet
{
    public enum FormType { KernelEditor, BattleDataEditor, BattleAIEditor }
    public enum FileClass { Kernel, Kernel2, Scene }

    public static class DataManager
    {
        private static StartupForm startupForm = null;
        private static KernelForm kernelForm = null;
        private static BattleAIForm battleAIForm = null;
        private static Scene[] sceneList;

        public static string KernelPath { get; private set; }
        public static string Kernel2Path { get; private set; }
        public static string ScenePath { get; private set; }
        public static KernelReader KernelReader { get; private set; }

        public static void SetStartupForm(StartupForm form)
        {
            if (startupForm != null)
            {
                throw new ArgumentException("Startup form already exists.");
            }
            startupForm = form;
        }

        public static void SetFilePath(FileClass fileClass, string path)
        {
            if (ValidateFile(fileClass, path))
            {
                var result = MessageBox.Show("Would you like to auto-detect the other files based on this one's location?",
                    "Auto-Detect Files", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string kernelDir, battleDir;
                    if (fileClass == FileClass.Scene)
                    {
                        battleDir = Path.GetDirectoryName(path);
                        kernelDir = Directory.GetParent(battleDir).FullName + @"\kernel";
                    }
                    else
                    {
                        kernelDir = Path.GetDirectoryName(path);
                        battleDir = Directory.GetParent(kernelDir).FullName + @"\battle";
                    }

                    if (fileClass != FileClass.Kernel)
                    {
                        ValidateFile(FileClass.Kernel, kernelDir + @"\KERNEL.BIN");
                    }
                    if (fileClass != FileClass.Kernel2)
                    {
                        ValidateFile(FileClass.Kernel2, kernelDir + @"\kernel2.bin");
                    }
                    if (fileClass != FileClass.Scene)
                    {
                        ValidateFile(FileClass.Scene, battleDir + @"\scene.bin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool ValidateFile(FileClass fileClass, string path)
        {
            if (File.Exists(path))
            {
                switch (fileClass)
                {
                    case FileClass.Kernel:
                        try
                        {
                            if (KernelReader == null)
                            {
                                KernelReader = new KernelReader(path, KernelType.KernelBin);
                            }
                            KernelPath = path;
                            return true;
                        }
                        catch { return false; }
                    case FileClass.Kernel2:
                        if (KernelReader == null)
                        {
                            KernelReader = new KernelReader(path, KernelType.Kernel2Bin);
                        }
                        Kernel2Path = path;
                        return true;
                    case FileClass.Scene:
                        try
                        {
                            sceneList = GZipper.LoadSceneBin(path);
                            ScenePath = path;
                            return true;
                        }
                        catch { return false; }
                }
            }
            return false;
        }

        public static bool KernelFilesLoaded()
        {
            return KernelPath != null && Kernel2Path != null;
        }

        public static bool SceneFileLoaded()
        {
            return ScenePath != null;
        }

        public static void OpenForm(FormType type)
        {
            switch (type)
            {
                case FormType.KernelEditor:
                    if (kernelForm == null)
                    {
                        kernelForm = new KernelForm();
                        kernelForm.Show();
                    }
                    break;
                case FormType.BattleDataEditor:
                    break;
                case FormType.BattleAIEditor:
                    if (battleAIForm == null)
                    {
                        battleAIForm = new BattleAIForm();
                        battleAIForm.Show();
                    }
                    break;
            }
        }

        public static void CloseForm(FormType type)
        {
            switch (type)
            {
                case FormType.KernelEditor:
                    kernelForm = null;
                    break;
                case FormType.BattleDataEditor:
                    break;
                case FormType.BattleAIEditor:
                    battleAIForm = null;
                    break;
            }
            startupForm.EnableFormButton(type);
        }

        public static Scene[] GetSceneList()
        {
            return sceneList;
        }
    }
}
