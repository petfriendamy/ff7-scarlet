using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Shojy.FF7.Elena.Converters
{
    public class TexConverter
    {
        #region Public Methods

        public static Bitmap ToBitmap(Stream texData, int preferPalette = 0)
        {
            // Always reset the stream position just in case.
            texData.Position = 0;
            var tex = new Tex(texData);
            return tex.ToBitmap(preferPalette);
        }

        public static Bitmap ToBitmap(byte[] texData, int preferPalette = 0)
        {
            using (var ms = new MemoryStream(texData))
            {
                return ToBitmap(ms, preferPalette);
            }
        }

        public static void ToGif(Stream texData, Stream output, int preferPalette = 0)
        {
            ToBitmap(texData, preferPalette).Save(output, ImageFormat.Gif);
        }

        public static void ToGif(byte[] texData, Stream output, int preferPalette = 0)
        {
            ToBitmap(texData, preferPalette).Save(output, ImageFormat.Gif);
        }

        public static void ToJpeg(Stream texData, Stream output, int preferPalette = 0)
        {
            ToBitmap(texData, preferPalette).Save(output, ImageFormat.Jpeg);
        }

        public static void ToJpeg(byte[] texData, Stream output, int preferPalette = 0)
        {
            ToBitmap(texData, preferPalette).Save(output, ImageFormat.Jpeg);
        }

        public static void ToPng(Stream texData, Stream output, int preferPalette = 0)
        {
            ToBitmap(texData, preferPalette).Save(output, ImageFormat.Png);
        }

        public static void ToPng(byte[] texData, Stream output, int preferPalette = 0)
        {
            ToBitmap(texData, preferPalette).Save(output, ImageFormat.Png);
        }

        #endregion Public Methods
    }
}