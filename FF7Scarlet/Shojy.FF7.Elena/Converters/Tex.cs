using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Shojy.FF7.Elena.Converters
{
    public class Tex
    {
        #region Public Constructors

        public Tex(Stream input)
        {
            this.Read(input);
        }

        #endregion Public Constructors

        #region Public Properties

        public uint AlphaBitmask { get; private set; }

        public uint AlphaMax { get; private set; }

        public uint AlphaShift { get; private set; }

        public uint BitDepth { get; private set; }

        public uint BitsPerIndex { get; private set; }

        public uint BitsPerPixel { get; private set; }

        public uint BlueBitmask { get; private set; }

        public uint BlueMax { get; private set; }

        public uint BlueShift { get; private set; }

        public uint BytesPerPixel { get; private set; }

        public uint ColorKeyArrayFlag { get; private set; }

        public uint ColorKeyFlag { get; private set; }

        public uint GreenBitmask { get; private set; }

        public uint GreenMax { get; private set; }

        public uint GreenShift { get; private set; }

        public uint Height { get; private set; }

        public byte[] ImageData { get; private set; }

        public uint IndexedTo8bit { get; private set; }

        public uint MaxAlphaBits { get; private set; }

        public uint MaxBitsPerColor { get; private set; }

        public uint MaxBitsPerPixel { get; private set; }

        public uint MinAlphaBits { get; private set; }

        public uint MinBitsPerColor { get; private set; }

        public uint MinBitsPerPixel { get; private set; }

        public uint NumberOfAlphaBits { get; private set; }

        public uint NumberOfAlphaBits8 { get; private set; }

        public uint NumberOfBlueBits { get; private set; }

        public uint NumberOfBlueBits8 { get; private set; }

        public uint NumberOfColorsPerPalette { get; private set; }

        public uint NumberOfGreenBits { get; private set; }

        public uint NumberOfGreenBits8 { get; private set; }

        public uint NumberOfPalettes { get; private set; }

        public uint NumberOfRedBits { get; private set; }

        public uint NumberOfRedBits8 { get; private set; }

        public uint NumColorsPerPalette { get; private set; }

        public byte[] PaletteData { get; private set; }

        public uint PaletteFlag { get; private set; }

        public uint PaletteIndex { get; private set; }

        public uint PaletteSize { get; private set; }

        public uint PitchOrBytesPerRow { get; private set; }

        public uint RedBitmask { get; private set; }

        public uint RedMax { get; private set; }

        public uint RedShift { get; private set; }

        public uint ReferenceAlpha { get; private set; }

        public uint RuntimeData1 { get; private set; }

        public uint RuntimeData2 { get; private set; }

        public uint RuntimeData3 { get; private set; }

        public uint RuntimeData4 { get; private set; }

        public uint RuntimeData5 { get; private set; }

        public uint Unknown1 { get; private set; }

        public uint Unknown10 { get; private set; }

        public uint Unknown2 { get; private set; }

        public uint Unknown3 { get; private set; }

        public uint Unknown4 { get; private set; }

        public uint Unknown5 { get; private set; }

        public uint Unknown6 { get; private set; }

        public uint Unknown7 { get; private set; }

        public uint Unknown8 { get; private set; }

        public uint Unknown9 { get; private set; }

        public uint Version { get; private set; }

        public uint Width { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public static Tex FromFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                var tex = new Tex(reader.BaseStream);
                return tex;
            }
        }

        public Bitmap ToBitmap(int preferPalette = 0)
        {
            // Default to the first palette if the preferred is out of range.
            if (preferPalette >= this.NumberOfPalettes || preferPalette < 0)
            {
                preferPalette = 0;
            }

            var tex = this;
            var width = (int)tex.Width;
            var height = (int)tex.Height;

            using (var str = new BinaryReader(new MemoryStream(tex.PaletteData)))
            {
                var colors = new List<Color>();
                while (str.BaseStream.Length > str.BaseStream.Position + 1)
                {
                    int b = str.ReadByte();
                    int g = str.ReadByte();
                    int r = str.ReadByte();
                    int a = str.ReadByte();

                    colors.Add(Color.FromArgb(a == 254 ? (byte)ReferenceAlpha : a, r, g, b));
                }

                var rawImageData = new List<int>(tex.ImageData.Select(x => (int)x));

                var colorsPerPalette = (int)(tex.NumberOfColorsPerPalette);
                var start = colorsPerPalette * preferPalette;

                var bitmap = new Bitmap((int)tex.Width, (int)tex.Height);

                var pixel = 0;
                for (var y = 0; y < height; ++y)
                {
                    for (var x = 0; x < width; ++x, ++pixel)
                    {
                        bitmap.SetPixel(x, y, colors[start + rawImageData[pixel]]);
                    }
                }
                return bitmap;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void Read(Stream texData)
        {
            var reader = new BinaryReader(texData);
            Version = reader.ReadUInt32();
            Unknown1 = reader.ReadUInt32();
            ColorKeyFlag = reader.ReadUInt32();
            Unknown2 = reader.ReadUInt32();
            Unknown3 = reader.ReadUInt32();
            MinBitsPerColor = reader.ReadUInt32();
            MaxBitsPerColor = reader.ReadUInt32();
            MinAlphaBits = reader.ReadUInt32();
            MaxAlphaBits = reader.ReadUInt32();
            MinBitsPerPixel = reader.ReadUInt32();
            MaxBitsPerPixel = reader.ReadUInt32();
            Unknown4 = reader.ReadUInt32();
            NumberOfPalettes = reader.ReadUInt32();
            NumberOfColorsPerPalette = reader.ReadUInt32();
            BitDepth = reader.ReadUInt32();
            Width = reader.ReadUInt32();
            Height = reader.ReadUInt32();
            PitchOrBytesPerRow = reader.ReadUInt32();
            Unknown5 = reader.ReadUInt32();
            PaletteFlag = reader.ReadUInt32();
            BitsPerIndex = reader.ReadUInt32();
            IndexedTo8bit = reader.ReadUInt32();
            PaletteSize = reader.ReadUInt32();
            NumColorsPerPalette = reader.ReadUInt32();
            RuntimeData5 = reader.ReadUInt32();
            BitsPerPixel = reader.ReadUInt32();
            BytesPerPixel = reader.ReadUInt32();
            NumberOfRedBits = reader.ReadUInt32();
            NumberOfGreenBits = reader.ReadUInt32();
            NumberOfBlueBits = reader.ReadUInt32();
            NumberOfAlphaBits = reader.ReadUInt32();
            RedBitmask = reader.ReadUInt32();
            GreenBitmask = reader.ReadUInt32();
            BlueBitmask = reader.ReadUInt32();
            AlphaBitmask = reader.ReadUInt32();
            RedShift = reader.ReadUInt32();
            GreenShift = reader.ReadUInt32();
            BlueShift = reader.ReadUInt32();
            AlphaShift = reader.ReadUInt32();
            NumberOfRedBits8 = reader.ReadUInt32();
            NumberOfGreenBits8 = reader.ReadUInt32();
            NumberOfBlueBits8 = reader.ReadUInt32();
            NumberOfAlphaBits8 = reader.ReadUInt32();
            RedMax = reader.ReadUInt32();
            GreenMax = reader.ReadUInt32();
            BlueMax = reader.ReadUInt32();
            AlphaMax = reader.ReadUInt32();
            ColorKeyArrayFlag = reader.ReadUInt32();
            RuntimeData1 = reader.ReadUInt32();
            ReferenceAlpha = reader.ReadUInt32();
            RuntimeData2 = reader.ReadUInt32();
            Unknown6 = reader.ReadUInt32();
            PaletteIndex = reader.ReadUInt32();
            RuntimeData3 = reader.ReadUInt32();
            RuntimeData4 = reader.ReadUInt32();
            Unknown7 = reader.ReadUInt32();
            Unknown8 = reader.ReadUInt32();
            Unknown9 = reader.ReadUInt32();
            Unknown10 = reader.ReadUInt32();
            PaletteData = reader.ReadBytes((int)(PaletteSize * 4));
            ImageData = reader.ReadBytes((int)((Width * Height) * BytesPerPixel));
        }

        #endregion Private Methods
    }
}