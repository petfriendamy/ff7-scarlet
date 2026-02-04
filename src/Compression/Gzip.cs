using FF7Scarlet.KernelEditor;
using FF7Scarlet.SceneEditor;
using FF7Scarlet.Shared;
using LibZopfliStandard;
using Shojy.FF7.Elena;
using System.IO.Compression;
using static System.Windows.Forms.Design.AxImporter;

namespace FF7Scarlet.Compression
{
    public enum CompressionType { Standard, Zopfli }

    public static class Gzip
    {
        public static void CreateKernel(Kernel kernel, CompressionType compressionType, string path, string? kernel2Path = null)
        {
            ushort i;
            var data = new List<byte>();
            byte[] uncompressedSection, compressedSection;
            ushort compressedLength, uncompressedLength;
            for (i = 0; i < Kernel.SECTION_COUNT; ++i)
            {
                uncompressedSection = kernel.GetSectionRawData((KernelSection)(i + 1));
                uncompressedLength = (ushort)uncompressedSection.Length;
                compressedSection = GetCompressedData(uncompressedSection, compressionType);
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

            //add 0s because this helps for some reason??
            data.Add(0);
            data.Add(0);

            File.WriteAllBytes(path, data.ToArray());

            if (!string.IsNullOrEmpty(kernel2Path)) //create kernel2
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
                File.WriteAllBytes(kernel2Path, data.ToArray());
            }
        }

        //based on code from SegaChief; thanks!
        private static Scene DecompressScene(byte[] compressedData, bool isJPoriginal)
        {
            var uncompressedData = new byte[Scene.UNCOMPRESSED_BLOCK_SIZE];
            int decompressedSize;

            using (var inputStream = new MemoryStream(compressedData))
            using (var outputStream = new MemoryStream())
            using (var gzipper = new GZipStream(inputStream, CompressionMode.Decompress))
            {
                while ((decompressedSize = gzipper.Read(uncompressedData, 0, Scene.UNCOMPRESSED_BLOCK_SIZE)) != 0)
                {
                    outputStream.Write(uncompressedData, 0, decompressedSize);
                }
            }
            return new Scene(ref uncompressedData, isJPoriginal);
        }

        public static Scene[] GetDecompressedSceneChunk(string path)
        {
            return GetDecompressedSceneChunk(File.ReadAllBytes(path), false);
        }

        private static Scene[] GetDecompressedSceneChunk(byte[] data, bool isJPoriginal)
        {
            uint
                currHeader,
                nextHeader,
                sceneOffset,
                sceneSize;
            var sceneList = new List<Scene> { };
            byte[] compressedData, headerBytes = new byte[4];

            //get headers for each of the scene files
            for (int i = 0; i < Scene.HEADER_COUNT; ++i)
            {
                Array.Copy(data, i * 4, headerBytes, 0, 4);
                currHeader = BitConverter.ToUInt32(headerBytes, 0);
                if (currHeader != HexParser.NULL_OFFSET_32_BIT) //check if offset exists first
                {
                    //determine if the next offset exists or not
                    if (i < Scene.HEADER_COUNT - 1)
                    {
                        Array.Copy(data, (i * 4) + 4, headerBytes, 0, 4);
                        nextHeader = BitConverter.ToUInt32(headerBytes, 0);
                    }
                    else { nextHeader = HexParser.NULL_OFFSET_32_BIT; }

                    //get the offset and size of this compressed file
                    sceneOffset = currHeader * 4;
                    if (nextHeader == HexParser.NULL_OFFSET_32_BIT)
                    {
                        sceneSize = Scene.COMPRESSED_BLOCK_SIZE - (currHeader * 4);
                    }
                    else
                    {
                        sceneSize = (nextHeader - currHeader) * 4;
                    }

                    //decompress the scene
                    compressedData = new byte[sceneSize];
                    Array.Copy(data, sceneOffset, compressedData, 0, sceneSize);
                    sceneList.Add(DecompressScene(compressedData, isJPoriginal));
                }
            }
            return sceneList.ToArray();
        }

        public static Scene[] GetDecompressedSceneList(string path, ref byte[] sceneLookupTable, bool isJPoriginal)
        {
            var fileData = File.ReadAllBytes(path);
            var sceneList = new Scene[Scene.SCENE_COUNT];
            var compressedData = new byte[Scene.COMPRESSED_BLOCK_SIZE];
            int currScene = 0, currBlock = 0;
            uint currOffset = 0;

            //fill the scene lookup table with 0xFF
            for (int i = 0; i < 64; ++i)
            {
                sceneLookupTable[i] = 0xFF;
            }

            //get the scene files
            while (currScene < Scene.SCENE_COUNT)
            {
                sceneLookupTable[currBlock] = (byte)currScene;
                Array.Copy(fileData, currOffset, compressedData, 0, Scene.COMPRESSED_BLOCK_SIZE);
                var scenes = GetDecompressedSceneChunk(compressedData, isJPoriginal);
                Array.Copy(scenes, 0, sceneList, currScene, scenes.Length);
                currScene += scenes.Length;
                currOffset += Scene.COMPRESSED_BLOCK_SIZE;
                currBlock++;
            }
            return sceneList;
        }

        private static byte[][] GetCompressedScenes(ref Scene[] sceneList, int start, int count, CompressionType compressionType)
        {
            if (start + count > Scene.SCENE_COUNT)
            {
                count = Scene.SCENE_COUNT - start;
            }
            var compressed = new byte[count][];
            for (int i = start; i < start + count; ++i)
            {
                var temp = GetCompressedData(sceneList[i].GetRawData(), compressionType);
                if (temp.Length % 4 != 0) //must be a multiple of 4
                {
                    int len = temp.Length + 1;
                    while (len % 4 != 0) { len++; }
                    var temp2 = HexParser.GetNullBlock(len);
                    Array.Copy(temp, temp2, temp.Length);
                    temp = temp2;
                }
                compressed[i - start] = temp.ToArray();
            }
            return compressed;
        }

        private static int GetTrimmedLength(ref byte[][] compressedScenes, int start = 0)
        {
            uint mergedSize = Scene.HEADER_COUNT * 4;
            int count = compressedScenes.Length,
                newLength = 0;

            for (int i = start; i < count && i < start + Scene.HEADER_COUNT && i < Scene.SCENE_COUNT; ++i)
            {
                if (compressedScenes[i] != null)
                {
                    mergedSize += (uint)compressedScenes[i].Length;
                    if (mergedSize < Scene.COMPRESSED_BLOCK_SIZE)
                    {
                        newLength++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return newLength;
        }

        private static byte[] MergeCompressedScenes(ref byte[][] compressedScenes, int start, int count)
        {
            //get the headers
            uint currHeader = Scene.HEADER_COUNT * 4;
            var merged = new List<byte> { };
            for (int i = 0; i < Scene.HEADER_COUNT; ++i)
            {
                if (i < count)
                {
                    merged.AddRange(BitConverter.GetBytes(currHeader / 4));
                    currHeader += (uint)compressedScenes[start + i].Length;
                }
                else
                {
                    merged.AddRange(HexParser.GetNullBlock(4));
                }
            }

            //output the compressed scenes
            for (int i = start; i < start + count; ++i)
            {
                merged.AddRange(compressedScenes[i]);
            }

            //pad with FF until chunk is correct length
            while (merged.Count < Scene.COMPRESSED_BLOCK_SIZE)
            {
                merged.Add(0xFF);
            }
            return merged.ToArray();
        }

        public static byte[] CompressSceneBin(Scene[] sceneList, ref byte[] sceneLookupTable, CompressionType compressionType)
        {
            //fill the scene lookup table with 0xFF
            for (int i = 0; i < Scene.BLOCK_COUNT; ++i)
            {
                sceneLookupTable[i] = 0xFF;
            }

            //write the compressed data to a file and update lookup table
            int currScene = 0, currBlock = 0;
            var output = new List<byte>();
            var compressedScenes = GetCompressedScenes(ref sceneList, 0, Scene.SCENE_COUNT, compressionType);
            while (currScene < Scene.SCENE_COUNT && currBlock < Scene.BLOCK_COUNT)
            {
                int len = GetTrimmedLength(ref compressedScenes, currScene);
                output.AddRange(MergeCompressedScenes(ref compressedScenes, currScene, len));
                sceneLookupTable[currBlock] = (byte)currScene;
                currScene += len;
                currBlock++;
            }
            return output.ToArray();
        }

        public static int CreateSceneChunk(Scene[] sceneList, string path, int start, int count, CompressionType compressionType)
        {
            var compressed = GetCompressedScenes(ref sceneList, start, count, compressionType);
            int newCount = GetTrimmedLength(ref compressed);
            File.WriteAllBytes(path, MergeCompressedScenes(ref compressed, 0, newCount));
            return newCount;
        }

        private static byte[] GetCompressedData(byte[] uncompressedData, CompressionType compressionType)
        {
            using (var outputStream = new MemoryStream())
            {
                if (compressionType == CompressionType.Standard)
                {
                    using (var gzipper = new GZipStream(outputStream, CompressionLevel.SmallestSize))
                    {
                        gzipper.Write(uncompressedData, 0, uncompressedData.Length);
                        gzipper.Flush();
                    }
                    return outputStream.ToArray();
                }
                else
                {
                    var options = new ZopfliOptions { verbose = 0 };
                    using (var gzipper = new ZopfliStream(outputStream, ZopfliFormat.ZOPFLI_FORMAT_GZIP, options))
                    {
                        gzipper.Write(uncompressedData, 0, uncompressedData.Length);
                        gzipper.Flush();
                    }
                    return outputStream.ToArray();
                }
            }
        }
    }
}
