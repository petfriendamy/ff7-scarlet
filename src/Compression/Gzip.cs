using FF7Scarlet.KernelEditor;
using FF7Scarlet.SceneEditor;
using Shojy.FF7.Elena;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
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

        public static Scene[] GetSceneList(string path, ref byte[] sceneLookupTable)
        {
            //based on code from SegaChief; thanks!
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
            return sceneList;
        }

        public static void CreateSceneBin(Scene[] sceneList, string path, ref byte[] sceneLookupTable)
        {
            //again, based on code from SegaChief
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
            using (var fs = new FileStream(path, FileMode.Create))
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
