using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL.Compatibility;

namespace KimeraCS.Core
{
    public static class FF7TEXTexture
    {
        public struct TEX
        {
            public string TEXfileName;
            public uint texID;
            public Bitmap bitmap;

            // TEX file format by Mirex and Aali
            // http://wiki.qhimm.com/FF7/TEX_format
            public int version;                // Must be 1 for FF7 to load it
            public int unk1;
            public int ColorKeyFlag;           // Set to 1 to enable the transparent color
            public int unk2;
            public int unk3;
            public int minBitsPerColor;    // D3D driver uses these to determine which texture
                                           // format to convert to on load
            public int maxBitsPerColor;
            public int minAlphaBits;
            public int maxAlphaBits;
            public int minBitsPerPixel;
            public int maxBitsPerPixel;
            public int unk4;
            public int numPalettes;
            public int numColorsPerPalette;
            public int bitDepth;
            public int width;
            public int height;
            public int pitch;            //  Rarelly used. Usually assumed to be BytesperPixel*Width
            public int unk5;
            public int hasPal;
            public int bitsPerIndex;
            public int indexedTo8BitsFlag;     //  Never used in FF7
            public int paletteSize;            //  Must be NumPalletes*NumColorsPerPallete
            public int numColorsPerPalette2;   //  Can be the same or 0. Doesn't really matter
            public int runtimeData;            //  Placeholder for some information. Doesn't matter
            public int bitsPerPixel;
            public int bytesPerPixel;          //  Should be trusted over BitsPerPixel
            ////////////////////////////////////////////////////////////////////////////////////
            //Pixel format (all 0 for palletized images)
            public int numRedBits;
            public int numGreenBits;
            public int numBlueBits;
            public int numAlphaBits;
            public int redBitMask;
            public int greenBitMask;
            public int blueBitMask;
            public uint alphaBitMask;
            public int redShift;
            public int greenShift;
            public int blueShift;
            public int alphaShift;
            //  The components values are computed by the following expresion:
            //  (((value & mask) >> shift) * 255) / max
            public int red8;       // Always 8
            public int green8;     // Always 8
            public int blue8;      // Always 8
            public int alpha8;     // Always 8
            public int redMax;
            public int greenMax;
            public int blueMax;
            public int alphaMax;
            //  End of Pixel format
            ////////////////////////////////////////////////////////////////////////////////////
            public int colorKeyArrayFlag;
            public int runtimeData2;
            public int referenceAlpha;
            public int runtimeData3;
            public int unk6;
            public int paletteIndex;
            public int runtimeData4;
            public int runtimeData5;
            public int unk7;
            public int unk8;
            public int unk9;
            public int unk10;
            //public int unk11;                // This is only for FF8

            public byte[] palette;             //  Always in 32-bit BGRA format
            public byte[] pixelData;           //  Width * Height * BytesPerPixel. Either indices or raw
                                               //  data following the specified format
            public byte[] colorKeyData;        //  NumPalettes * 1 bytes
        }

        public static int ReadTEXTexture(ref TEX inTEXTexture, string inTEXfile)
        {
            int iReadTEXTextureResult = -1;
            if (File.Exists(inTEXfile))
            {
                // Read All TEX Texture file into memory
                var fileBuffer = File.ReadAllBytes(inTEXfile);
                iReadTEXTextureResult = ReadTEXTexture(ref inTEXTexture, fileBuffer, Path.GetFileName(inTEXfile));
            }
            else
            {
                throw new FileNotFoundException("TEX texture file " + Path.GetFileName(inTEXfile) + " not found.",
                                                    inTEXfile);
            }
            return iReadTEXTextureResult;
        }
        public static int ReadTEXTexture(ref TEX inTEXTexture, byte[] data, string fileName)
        {
            int iReadTEXTextureResult = -1;
            inTEXTexture.texID = 0xFFFFFFFF;

            try
            {
                inTEXTexture.TEXfileName = fileName;

                using (var fileMemory = new MemoryStream(data))
                using (var memReader = new BinaryReader(fileMemory))
                {
                    // Read memory data into structure
                    inTEXTexture.version = memReader.ReadInt32();
                    inTEXTexture.unk1 = memReader.ReadInt32();
                    inTEXTexture.ColorKeyFlag = memReader.ReadInt32();
                    inTEXTexture.unk2 = memReader.ReadInt32();
                    inTEXTexture.unk3 = memReader.ReadInt32();
                    inTEXTexture.minBitsPerColor = memReader.ReadInt32();
                    inTEXTexture.maxBitsPerColor = memReader.ReadInt32();
                    inTEXTexture.minAlphaBits = memReader.ReadInt32();
                    inTEXTexture.maxAlphaBits = memReader.ReadInt32();
                    inTEXTexture.minBitsPerPixel = memReader.ReadInt32();
                    inTEXTexture.maxBitsPerPixel = memReader.ReadInt32();
                    inTEXTexture.unk4 = memReader.ReadInt32();
                    inTEXTexture.numPalettes = memReader.ReadInt32();
                    inTEXTexture.numColorsPerPalette = memReader.ReadInt32();
                    inTEXTexture.bitDepth = memReader.ReadInt32();
                    inTEXTexture.width = memReader.ReadInt32();
                    inTEXTexture.height = memReader.ReadInt32();
                    inTEXTexture.pitch = memReader.ReadInt32();
                    inTEXTexture.unk5 = memReader.ReadInt32();
                    inTEXTexture.hasPal = memReader.ReadInt32();
                    inTEXTexture.bitsPerIndex = memReader.ReadInt32();
                    inTEXTexture.indexedTo8BitsFlag = memReader.ReadInt32();
                    inTEXTexture.paletteSize = memReader.ReadInt32();
                    inTEXTexture.numColorsPerPalette2 = memReader.ReadInt32();
                    inTEXTexture.runtimeData = memReader.ReadInt32();
                    inTEXTexture.bitsPerPixel = memReader.ReadInt32();
                    inTEXTexture.bytesPerPixel = memReader.ReadInt32();
                    inTEXTexture.numRedBits = memReader.ReadInt32();
                    inTEXTexture.numGreenBits = memReader.ReadInt32();
                    inTEXTexture.numBlueBits = memReader.ReadInt32();
                    inTEXTexture.numAlphaBits = memReader.ReadInt32();
                    inTEXTexture.redBitMask = memReader.ReadInt32();
                    inTEXTexture.greenBitMask = memReader.ReadInt32();
                    inTEXTexture.blueBitMask = memReader.ReadInt32();
                    inTEXTexture.alphaBitMask = memReader.ReadUInt32();
                    inTEXTexture.redShift = memReader.ReadInt32();
                    inTEXTexture.greenShift = memReader.ReadInt32();
                    inTEXTexture.blueShift = memReader.ReadInt32();
                    inTEXTexture.alphaShift = memReader.ReadInt32();
                    inTEXTexture.red8 = memReader.ReadInt32();
                    inTEXTexture.green8 = memReader.ReadInt32();
                    inTEXTexture.blue8 = memReader.ReadInt32();
                    inTEXTexture.alpha8 = memReader.ReadInt32();
                    inTEXTexture.redMax = memReader.ReadInt32();
                    inTEXTexture.greenMax = memReader.ReadInt32();
                    inTEXTexture.blueMax = memReader.ReadInt32();
                    inTEXTexture.alphaMax = memReader.ReadInt32();
                    inTEXTexture.colorKeyArrayFlag = memReader.ReadInt32();
                    inTEXTexture.runtimeData2 = memReader.ReadInt32();
                    inTEXTexture.referenceAlpha = memReader.ReadInt32();
                    inTEXTexture.runtimeData3 = memReader.ReadInt32();
                    inTEXTexture.unk6 = memReader.ReadInt32();                           
                    inTEXTexture.paletteIndex = memReader.ReadInt32();
                    inTEXTexture.runtimeData4 = memReader.ReadInt32();
                    inTEXTexture.runtimeData5 = memReader.ReadInt32();
                    inTEXTexture.unk7 = memReader.ReadInt32();
                    inTEXTexture.unk8 = memReader.ReadInt32();
                    inTEXTexture.unk9 = memReader.ReadInt32();
                    inTEXTexture.unk10 = memReader.ReadInt32();

                    if (inTEXTexture.hasPal == 1)
                    {
                        inTEXTexture.palette = new byte[inTEXTexture.paletteSize * 4];
                        inTEXTexture.palette = memReader.ReadBytes(inTEXTexture.paletteSize * 4);
                    }

                    inTEXTexture.pixelData = new byte[inTEXTexture.width * inTEXTexture.height * inTEXTexture.bytesPerPixel];
                    inTEXTexture.pixelData = memReader.ReadBytes(inTEXTexture.width * inTEXTexture.height * inTEXTexture.bytesPerPixel);

                    if (inTEXTexture.colorKeyArrayFlag == 1)
                    {
                        inTEXTexture.colorKeyData = new byte[inTEXTexture.numPalettes];
                        inTEXTexture.colorKeyData = memReader.ReadBytes(inTEXTexture.numPalettes);
                    }
                }

                iReadTEXTextureResult = 0;
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Error reading TEX texture file " + fileName + ".",
                                            fileName, ex);
            }

            return iReadTEXTextureResult;
        }

        //  Get a 32 bits BGRA (or BGR for 24 bits) version of the image
        public static void GetTEXTexturev(ref TEX inTEXTexture, ref byte[]? textureImg)
        {
            int imageBytesSize, imageSize, offsetBit, ti, color_offset;
            int col16, b1, b2;

            offsetBit = 0;
            ti = 0;

            if (inTEXTexture.hasPal == 1)
            {
                textureImg = new byte[inTEXTexture.width * inTEXTexture.height * 4];

                imageBytesSize = inTEXTexture.width * inTEXTexture.height * inTEXTexture.bytesPerPixel;

                while (offsetBit < imageBytesSize)
                {
                    color_offset = 4 * inTEXTexture.pixelData[offsetBit];
                    offsetBit++;

                    textureImg[ti] = inTEXTexture.palette[color_offset];
                    textureImg[ti + 1] = inTEXTexture.palette[color_offset + 1];
                    textureImg[ti + 2] = inTEXTexture.palette[color_offset + 2];

                    if (color_offset == 0 && inTEXTexture.ColorKeyFlag == 1) textureImg[ti + 3] = 0;
                    else textureImg[ti + 3] = 255;

                    ti += 4;
                }
            }
            else 
            {
                if (inTEXTexture.bitDepth == 16)
                {
                    imageSize = inTEXTexture.width * inTEXTexture.height * inTEXTexture.bytesPerPixel;

                    textureImg = new byte[inTEXTexture.width * inTEXTexture.height * 4];

                    while (offsetBit < imageSize)
                    {
                        b1 = inTEXTexture.pixelData[offsetBit];
                        b2 = inTEXTexture.pixelData[offsetBit + 1];
                        col16 = (b1 & 255) | ((b2 & 255) * 256);

                        textureImg[ti + 2] = Convert.ToByte((col16 & 31) * 255 / 31);
                        textureImg[ti + 1] = Convert.ToByte(((int)Math.Pow(col16 / 2, 5) & 31) * 255 / 31);
                        textureImg[ti] = Convert.ToByte(((int)Math.Pow(col16 / 2, 10) & 31) * 255 / 31);

                        if (textureImg[ti] == 0 && textureImg[ti + 1] == 0 && textureImg[ti + 2] == 0 && inTEXTexture.ColorKeyFlag == 1)
                            textureImg[ti + 3] = 0;
                        else
                            textureImg[ti + 3] = 255;

                        ti += 4;
                        offsetBit += 2;
                    }
                }
                else if (inTEXTexture.bitDepth == 24)
                {
                    // Expand 24-bit BGR to 32-bit BGRA
                    imageSize = inTEXTexture.width * inTEXTexture.height * 3;
                    textureImg = new byte[inTEXTexture.width * inTEXTexture.height * 4];

                    while (offsetBit < imageSize)
                    {
                        textureImg[ti] = inTEXTexture.pixelData[offsetBit];         // B
                        textureImg[ti + 1] = inTEXTexture.pixelData[offsetBit + 1]; // G
                        textureImg[ti + 2] = inTEXTexture.pixelData[offsetBit + 2]; // R
                        textureImg[ti + 3] = 255;                                    // A (fully opaque)

                        ti += 4;
                        offsetBit += 3;
                    }
                }
                else textureImg = inTEXTexture.pixelData;
            }
        }

        //  Create the OpenGL Texture object
        public static void LoadTEXTexture(ref TEX inTEXTexture)
        {
            byte[]? textureImg = null;

            OpenTK.Graphics.OpenGL.Compatibility.PixelFormat format = 0x0;
            InternalFormat internalformat = 0x0;

            int texId = GL.GenTexture();
            inTEXTexture.texID = (uint)texId;
            GL.BindTexture(TextureTarget.Texture2d, texId);

            GL.TexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            switch (inTEXTexture.bitDepth)
            {
                case 1:
                case 2:
                case 4:
                case 8:
                case 32:
                    format = OpenTK.Graphics.OpenGL.Compatibility.PixelFormat.Bgra;
                    internalformat = InternalFormat.Rgba;
                    break;

                case 16:
                    format = OpenTK.Graphics.OpenGL.Compatibility.PixelFormat.Bgra;
                    internalformat = InternalFormat.Rgb5;
                    break;

                case 24:
                    format = OpenTK.Graphics.OpenGL.Compatibility.PixelFormat.Bgr;
                    internalformat = InternalFormat.Rgb;
                    break;

            }

            GL.PixelStorei(PixelStoreParameter.UnpackAlignment, 1);

            GetTEXTexturev(ref inTEXTexture, ref textureImg);

            if (textureImg != null)
            {
                GL.TexImage2D(TextureTarget.Texture2d, 0, internalformat,
                    inTEXTexture.width, inTEXTexture.height, 0, format,
                    PixelType.UnsignedByte, textureImg);
            }
        }


        public static void LoadBitmapFromTEXTexture(ref TEX inTEXTexture)
        {
            try
            {
                // Get 32-bit BGRA pixel data using existing conversion function
                byte[]? textureImg = null;
                GetTEXTexturev(ref inTEXTexture, ref textureImg);

                // Create managed bitmap
                inTEXTexture.bitmap = new Bitmap(inTEXTexture.width, inTEXTexture.height,
                                                  System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                // Lock bitmap memory and copy pixel data
                Rectangle rect = new Rectangle(0, 0, inTEXTexture.width, inTEXTexture.height);
                BitmapData bmpData = inTEXTexture.bitmap.LockBits(rect, ImageLockMode.WriteOnly,
                                                                   System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                // Both TEX and .NET Bitmap store pixels top-to-bottom, so copy directly
                int stride = bmpData.Stride;
                int rowBytes = inTEXTexture.width * 4;

                for (int y = 0; y < inTEXTexture.height; y++)
                {
                    int srcOffset = y * rowBytes;
                    IntPtr dstRow = bmpData.Scan0 + y * stride;
                    Marshal.Copy(textureImg!, srcOffset, dstRow, rowBytes);
                }

                inTEXTexture.bitmap.UnlockBits(bmpData);
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Error loading Bitmap from TEXTexture: " + ex.Message,
                                            inTEXTexture.TEXfileName ?? "unknown", ex);
            }
        }
    }
}
