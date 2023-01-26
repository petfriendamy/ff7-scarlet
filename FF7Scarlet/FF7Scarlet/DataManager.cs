using Shojy.FF7.Elena;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
        private static Scene[] sceneList = new Scene[SCENE_COUNT];
        private static byte[] sceneLookupTable = new byte[64];

        public const int SCENE_COUNT = 256;
        private const int COMPRESSED_BLOCK_SIZE = 0x2000, UNCOMPRESSED_BLOCK_SIZE = 7808, HEADER_COUNT = 16;
        public const ushort NULL_OFFSET_16_BIT = 0xFFFF;
        public const uint NULL_OFFSET_32_BIT = 0xFFFFFFFF;

        public static string KernelPath { get; private set; }
        public static string Kernel2Path { get; private set; }
        public static string ScenePath { get; private set; }
        public static Kernel Kernel { get; private set; }

        public static bool KernelFileIsLoaded
        {
            get { return !string.IsNullOrEmpty(KernelPath); }
        }

        public static bool SceneFileIsLoaded
        {
            get { return !string.IsNullOrEmpty(ScenePath); }
        }

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
                            Kernel = new Kernel(path);
                            KernelPath = path;
                            return true;
                        }
                        catch { return false; }
                    case FileClass.Kernel2:
                        Kernel.MergeKernel2Data(path);
                        Kernel2Path = path;
                        return true;
                    case FileClass.Scene:
                        try
                        {
                            LoadSceneBin(path);
                            return true;
                        }
                        catch { return false; }
                }
            }
            return false;
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

        public static Scene[] CopySceneList()
        {
            var copy = new Scene[SCENE_COUNT];
            for (int i = 0; i < SCENE_COUNT; ++i)
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
            for (int i = 0; i < SCENE_COUNT; ++i)
            {
                UpdateScene(caller, newScenes[i], i);
            }
        }

        public static bool LookupTableIsCorrect()
        {
            if (KernelFileIsLoaded && SceneFileIsLoaded)
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
            if (KernelFileIsLoaded && SceneFileIsLoaded)
            {
                Kernel.UpdateLookupTable(sceneLookupTable);
                CreateKernel();
            }
        }

        public static void CreateKernel()
        {
            if (!KernelFileIsLoaded)
            {
                throw new FileNotFoundException("No kernel.bin file is loaded.");
            }

            var data = new List<byte> { };
            byte[] uncompressedSection, compressedSection;
            ushort compressedLength, uncompressedLength;
            for (ushort i = 0; i < Kernel.SECTION_COUNT; ++i)
            {
                uncompressedSection = Kernel.GetSectionRawData((KernelSection)i);
                uncompressedLength = (ushort)uncompressedSection.Length;
                compressedSection = GetCompressedData(uncompressedSection);
                compressedLength = (ushort)compressedSection.Length;

                data.AddRange(BitConverter.GetBytes(compressedLength));
                data.AddRange(BitConverter.GetBytes(uncompressedLength));
                if (i >= Kernel.KERNEL_2_START)
                {
                    data.AddRange(BitConverter.GetBytes((ushort)Kernel.KERNEL_2_START));
                }
                else { data.AddRange(BitConverter.GetBytes(i)); }
                data.AddRange(compressedSection);
            }
            File.WriteAllBytes(KernelPath, data.ToArray());
            //make sure to write to kernel2 also
        }

        private static void LoadSceneBin(string path)
        {
            //based on code from SegaChief; thanks!
            var fileData = File.ReadAllBytes(path);

            int i, j, currScene = 0, currBlock = 0;
            uint currHeader, nextHeader, currOffset = 0;
            var sceneOffset = new uint[SCENE_COUNT];
            var sceneSize = new uint[SCENE_COUNT];
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
                for (i = 0; i < HEADER_COUNT; ++i)
                {
                    Array.Copy(fileData, currOffset + j, headerBytes, 0, 4);
                    currHeader = BitConverter.ToUInt32(headerBytes, 0);
                    if (currHeader != NULL_OFFSET_32_BIT) //check if offset exists first
                    {
                        //determine if the next offset exists or not
                        if (i < 15)
                        {
                            Array.Copy(fileData, currOffset + j + 4, headerBytes, 0, 4);
                            nextHeader = BitConverter.ToUInt32(headerBytes, 0);
                        }
                        else { nextHeader = NULL_OFFSET_32_BIT; }

                        //get the offset and size of this compressed file
                        sceneOffset[currScene] = (currHeader * 4) + currOffset;
                        if (nextHeader == NULL_OFFSET_32_BIT)
                        {
                            sceneSize[currScene] = COMPRESSED_BLOCK_SIZE - (currHeader * 4);
                        }
                        else
                        {
                            sceneSize[currScene] = (nextHeader - currHeader) * 4;
                        }
                        currScene++;
                    }
                    j += 4;
                }
                currOffset += COMPRESSED_BLOCK_SIZE;
                currBlock++;
            }

            //get and decompress each of the scene files
            int decompressedSize;
            for (i = 0; i < SCENE_COUNT; ++i)
            {
                compressedData = new byte[sceneSize[i]];
                Array.Copy(fileData, sceneOffset[i], compressedData, 0, sceneSize[i]);
                var uncompressedData = new byte[UNCOMPRESSED_BLOCK_SIZE];

                using (var inputStream = new MemoryStream(compressedData))
                using (var outputStream = new MemoryStream())
                using (var gzipper = new GZipStream(inputStream, CompressionMode.Decompress))
                {
                    while ((decompressedSize = gzipper.Read(uncompressedData, 0, UNCOMPRESSED_BLOCK_SIZE)) != 0)
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
            if (!SceneFileIsLoaded)
            {
                throw new FileNotFoundException("No scene.bin file is loaded.");
            }

            var compressedScenes = new List<byte[]> { };
            byte[] compressedData;
            var headers = new uint[SCENE_COUNT];
            var sceneBlock = new int[SCENE_COUNT];
            var blockSize = new List<uint> { };
            int i, j, n = 0, currBlock = 0, currScene = 0;
            uint currHeader = HEADER_COUNT * 4, calculatedSize;

            //fill the scene lookup table with 0xFF
            for (i = 0; i < 64; ++i)
            {
                sceneLookupTable[i] = 0xFF;
            }
            sceneLookupTable[0] = 0; //always 0

            //create the scene.bin
            for (i = 0; i < SCENE_COUNT; ++i)
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
                if (n >= HEADER_COUNT || calculatedSize >= COMPRESSED_BLOCK_SIZE)
                {
                    n = 0;
                    blockSize.Add(calculatedSize);
                    currBlock++;
                    currHeader = HEADER_COUNT * 4;
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
                    for (j = 0; j < HEADER_COUNT; ++j)
                    {
                        if (currScene + j < SCENE_COUNT && sceneBlock[currScene + j] == i)
                        {
                            writer.Write(headers[currScene + j]);
                        }
                        else { writer.Write(NULL_OFFSET_32_BIT); }
                    }

                    //write the scenes assigned to this block
                    while (currScene < SCENE_COUNT && sceneBlock[currScene] == i)
                    {
                        writer.Write(compressedScenes[currScene]);
                        currScene++;
                    }

                    //add padding until the block is full
                    while (fs.Length % COMPRESSED_BLOCK_SIZE != 0)
                    {
                        writer.Write((byte)0xFF);
                    }
                }
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
    }
}
