using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    /*
     * Original code by SegaChief
     */
    public static class GZipper
    {
        public static Scene[] LoadSceneBin(string filePath)
        {
            var sceneList = new Scene[256];

            byte[] header = new byte[64];                       /* Stores the block header
                                                                 * [0-4] = Offset for first GZipped data file (3 enemies per file)
                                                                 * Header total size must be 40h - empty entries == FF FF FF FF
                                                                 */

            int[][] jaggedSceneInfo = new int[256][];           // An array of arrays, containing offset, size, and absoluteoffset for each scene file
            int[][][] jaggedModelAttackTypes = new int[3000][][];   // Contains all the uncompressed Attack Anim data

            long initialSize;                                   // The size of the initial scene.bin (can vary, up to 63 blocks but typically 32-33
            int size;                                           // The size of the compressed file
            int offset;                                         // Stores the current scene offset
            int nextOffset;                                     // Stores the next scene offset
            int absoluteOffset;                                 // Stores the scene's absolute offset in the scene.bin
            int finalOffset = 0;                                // Stores the scene's adjusted offset in the scene.bin
            int headerOffset = 0;                               // Offset of the current block header; goes up in 2000h (8192) increments

            byte[] padder = new byte[1];                        // Scene files, after compression, need to be FF padded to make them multiplicable by 4
            padder[0] = 255;

            byte[] kernelLookup = new byte[64];                 // Stores the new lookup table to be written to the kernel.bin; blank values are FF
            int i = 0;
            while (i < 64)
            {
                kernelLookup[i] = 255;
                i++;
            }

            int a = 0;  // The var street boys
            int b = 0;  // have broken up
            int c = 0;  // feels bad man

            // Entire file is read; offsets and sizes for scenes are extracted and placed in a jagged array (an array of arrays)
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            initialSize = fs.Length;
            fs.Close();
            while (headerOffset < initialSize) // 32 blocks of 2000h/8192 bytes each
            {
                // Opens and reads the default scene.bin
                FileStream stepOne = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                stepOne.Seek(headerOffset, SeekOrigin.Begin);
                stepOne.Read(header, 0, 64); // Header never exceeds 64 bytes
                stepOne.Close();

                // Max of 16 sections in a header (is usually less however)
                while (a < 16)
                {
                    // If the 2nd byte of the current header is FF then assume there are no more valid scene headers in this block
                    if (header[c + 1] != 0xFF)
                    {
                        // Fetches the current header
                        byte[] currentHeader = new byte[4];
                        currentHeader[0] = header[c];
                        currentHeader[1] = header[c + 1];
                        currentHeader[2] = header[c + 2];
                        currentHeader[3] = header[c + 3];

                        // Fetches the next header - ignored if we're at the end of the block header
                        byte[] nextHeader = new byte[4];
                        if (a < 15)
                        {
                            nextHeader[0] = header[c + 4];
                            nextHeader[1] = header[c + 5];
                            nextHeader[2] = header[c + 6];
                            nextHeader[3] = header[c + 7];
                        }

                        // Converts the current offset and the next offset into integer
                        offset = EndianConvert.GetLittleEndianInt(currentHeader, 0);
                        nextOffset = EndianConvert.GetLittleEndianInt(nextHeader, 0);

                        // Checks that next header is not empty or if we are at the last header
                        if (currentHeader[1] == 0xFF || nextHeader[1] == 0xFF || a == 15)
                        {
                            // If next header is FF FF FF FF, then we're at the end of file and should deduct 2000h to get current file size
                            size = 8192 - (offset * 4);
                        }
                        else
                        {
                            // Difference between this offset and next offset provides size; offsets need to be *4 to get actual offset
                            size = (nextOffset - offset) * 4;
                        }
                        // Gets absolute offset in the scene.bin for the current scene
                        absoluteOffset = (offset * 4) + headerOffset;
                        // Store our retrieved/derived information in our jagged array (watch out for the pointy bits)
                        jaggedSceneInfo[b] = new int[] { offset, size, absoluteOffset, finalOffset };
                        b++;
                    }
                    c += 4;
                    a++;
                }
                headerOffset += 8192;
                a = 0;
                c = 0;
            }
            b = 0;
            headerOffset = 0;

            for (a = 0; a < 256; ++a)
            {
                int bytesRead;
                byte[] uncompressedScene = new byte[7808]; // Used to hold the decompressed scene file

                using (BinaryReader brg = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                {
                    // Calls method to convert little endian values into an integer
                    byte[] compressedScene = new byte[jaggedSceneInfo[b][1]]; // Used to hold the compressed scene file, where [o][1] is scene size        
                    brg.BaseStream.Seek(jaggedSceneInfo[b][2], SeekOrigin.Begin); // Starts reading the compressed scene file
                    brg.Read(compressedScene, 0, compressedScene.Length);

                    using (MemoryStream inputWrapper = new MemoryStream(compressedScene))
                    {
                        using (MemoryStream decompressedOutput = new MemoryStream())
                        {
                            using (GZipStream zipInput = new GZipStream(inputWrapper, CompressionMode.Decompress, true))
                            {
                                while ((bytesRead = zipInput.Read(uncompressedScene, 0, 7808)) != 0)
                                {
                                    decompressedOutput.Write(uncompressedScene, 0, bytesRead);
                                }
                                zipInput.Close();
                            }
                            decompressedOutput.Close();
                        }
                        inputWrapper.Close();
                    }
                    brg.Close();
                }
                sceneList[a] = new Scene(ref uncompressedScene);
                b++;
            }
            return sceneList.ToArray();
        }
    }
}
