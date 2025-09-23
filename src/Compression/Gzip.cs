using FF7Scarlet.AIEditor;
using FF7Scarlet.KernelEditor;
using FF7Scarlet.SceneEditor;
using FF7Scarlet.Shared;
using SharpDX.DirectSound;
using Shojy.FF7.Elena;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.Compression
{
    public static class Gzip
    {
        public static void CreateKernel(Kernel kernel, string path, string? kernel2Path = null)
        {
            ushort i;
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
        public static Scene[] GetDecompressedSceneList(string path, ref byte[] sceneLookupTable, bool isJPoriginal)
        {
            var fileData = File.ReadAllBytes(path);

            int i, j, currScene = 0, currBlock = 0;
            uint currHeader, nextHeader, currOffset = 0;
            var sceneOffset = new uint[Scene.SCENE_COUNT];
            var sceneSize = new uint[Scene.SCENE_COUNT];
            var sceneList = new Scene[Scene.SCENE_COUNT];
            byte[] compressedData, headerBytes = new byte[4];

            //fill the scene lookup table with 0xFF
            for (i = 0; i < 64; ++i)
            {
                sceneLookupTable[i] = 0xFF;
            }

            //get headers for each of the scene files
            while (currScene < Scene.SCENE_COUNT)
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
                        if (i < Scene.HEADER_COUNT - 1)
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
                sceneList[i] = new Scene(ref uncompressedData, isJPoriginal);
            }
            return sceneList;
        }

        private static byte[][] GetCompressedScenes(ref Scene[] sceneList, int start, int count)
        {
            if (start + count > Scene.SCENE_COUNT)
            {
                count = Scene.SCENE_COUNT - start;
            }
            var compressed = new byte[count][];
            for (int i = start; i < start + count; ++i)
            {
                var temp = GetCompressedData(sceneList[i].GetRawData());
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

        public static void CreateSceneBin(Scene[] sceneList, string path, ref byte[] sceneLookupTable)
        {
            //fill the scene lookup table with 0xFF
            for (int i = 0; i < Scene.BLOCK_COUNT; ++i)
            {
                sceneLookupTable[i] = 0xFF;
            }

            //write the compressed data to a file and update lookup table
            int currScene = 0, currBlock = 0;
            using (var fs = new FileStream(path, FileMode.Create))
            using (var writer = new BinaryWriter(fs))
            {
                var compressedScenes = GetCompressedScenes(ref sceneList, 0, Scene.SCENE_COUNT);
                while (currScene < Scene.SCENE_COUNT && currBlock < Scene.BLOCK_COUNT)
                {
                    int len = GetTrimmedLength(ref compressedScenes, currScene);
                    writer.Write(MergeCompressedScenes(ref compressedScenes, currScene, len));
                    sceneLookupTable[currBlock] = (byte)currScene;
                    currScene += len;
                    currBlock++;
                }
            }
        }

        public static int CreateSceneChunk(Scene[] sceneList, string path, int start, int count)
        {
            var compressed = GetCompressedScenes(ref sceneList, start, count);
            int newCount = GetTrimmedLength(ref compressed);
            File.WriteAllBytes(path, MergeCompressedScenes(ref compressed, 0, newCount));
            return newCount;
        }

        private static byte[] GetCompressedData(byte[] uncompressedData)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var gzipper = new GZipStream(outputStream, CompressionLevel.SmallestSize))
                {
                    gzipper.Write(uncompressedData, 0, uncompressedData.Length);
                    gzipper.Flush();
                }
                return outputStream.ToArray();
            }
        }
    }
}
