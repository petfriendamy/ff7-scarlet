using Shojy.FF7.Elena.Sections;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.IO.Compression;
using System.Net.Mime;
using Shojy.FF7.Elena.Compression;

namespace Shojy.FF7.Elena
{
    /// <summary>
    /// Kernel reader used for accessing data from FF7's Kernel files.
    /// </summary>
    public class KernelReader
    {
        #region Private Fields

        protected Dictionary<KernelSection, byte[]> KernelData { get; set; }

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Creates a new instance of the Kernel file reader
        /// </summary>
        /// <param name="kernel">Path to the KERNEL.BIN or kernel2.bin file to open.</param>
        /// <param name="kernelFile">Whether the file is KERNEL.BIN or kernel2.bin</param>
        public KernelReader(string kernel, KernelType kernelFile = KernelType.KernelBin)
        {
            if (kernelFile == KernelType.KernelBin)
            {
                // Load file and decompress
                this.KernelData = DecompressKernel(kernel);
            }
            else if (kernelFile == KernelType.Kernel2Bin)
            {
                this.KernelData = DecompressKernel2(kernel);
            } else {
                throw new NotSupportedException("This type of kernel is not yet supported.");
            }

            // Sections
            this.LoadSections();
        }

        public KernelReader MergeKernel2Data(string kernel2)
        {
            var data = DecompressKernel2(kernel2);

            foreach(var pair in data)
            {
                if (this.KernelData.ContainsKey(pair.Key))
                {
                    this.KernelData[pair.Key] = pair.Value;
                }
                else
                {
                    this.KernelData.Add(pair.Key, pair.Value);
                }
            }

            // Reload the data
            this.LoadSections();
            return this;
        }

        protected KernelReader() { }

        private static Dictionary<KernelSection, byte[]> DecompressKernel2(string path)
        {
            // kernel2.bin uses a different format for storing information. 
            // The file is LZS-Compressed, and then uses a 4byte integer at the start of each section
            // to specify length.
            
            var kernelFile = new FileInfo(path);
            var kernelData = new Dictionary<KernelSection, byte[]>();

            using (var fileStream = kernelFile.OpenRead())
            using (var memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                var bytes = memoryStream.ToArray();

                bytes = LzsCompression.UnLzs(ref bytes);

                var length = bytes.Length;
                var offset = 0;
                for (var sectionIndex = 9; sectionIndex < 27 && offset < length; ++sectionIndex)
                {
                    // Get length of this section
                    var len = BitConverter.ToInt32(bytes, offset);
                    offset += 4;

                    // Extract
                    var temp = new byte[len];
                    Array.Copy(bytes, offset, temp, 0, temp.Length);
                    offset += len;
                    kernelData.Add((KernelSection)sectionIndex + 1, temp);
                }
            }

            return kernelData;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Kernel section 8, merged with Names (section 23) and descriptions (Section 15)
        /// </summary>
        public AccessoryData AccessoryData { get; protected set; }

        /// <summary>
        /// Kernel section 15
        /// </summary>
        public TextSection AccessoryDescriptions { get; protected set; }

        /// <summary>
        /// Kernel section 23
        /// </summary>
        public TextSection AccessoryNames { get; protected set; }

        /// <summary>
        /// Kernel section 7
        /// </summary>
        public ArmorData ArmorData { get; protected set; }

        /// <summary>
        /// Kernel section 14
        /// </summary>
        public TextSection ArmorDescriptions { get; protected set; }

        /// <summary>
        /// Kernel section 22
        /// </summary>
        public TextSection ArmorNames { get; protected set; }

        /// <summary>
        /// Kernel section 26
        /// </summary>
        public TextSection BattleText { get; protected set; }

        /// <summary>
        /// Kernel section 10
        /// </summary>
        public TextSection CommandDescriptions { get; protected set; }

        /// <summary>
        /// Kernel section 18
        /// </summary>
        public TextSection CommandNames { get; protected set; }

        /// <summary>
        /// Kernel section 5, merged with names (Section 20) and descriptions (section 12)
        /// </summary>
        public ItemData ItemData { get; set; }

        /// <summary>
        /// Kernel section 12
        /// </summary>
        public TextSection ItemDescriptions { get; protected set; }

        /// <summary>
        /// Kernel section 20
        /// </summary>
        public TextSection ItemNames { get; protected set; }

        /// <summary>
        /// Merged Section 25 (key Item Names) and 17 (Descriptions)
        /// </summary>
        public KeyItemData KeyItemData { get; protected set; }

        /// <summary>
        /// Kernel section 17
        /// </summary>
        public TextSection KeyItemDescriptions { get; protected set; }

        /// <summary>
        /// Kernel section 25
        /// </summary>
        public TextSection KeyItemNames { get; protected set; }

        /// <summary>
        /// Kernel section 19
        /// </summary>
        public TextSection MagicDescriptions { get; protected set; }

        /// <summary>
        /// Kernel section 24
        /// </summary>
        public TextSection MagicNames { get; protected set; }

        /// <summary>
        /// Kernel section 9, merged with names (section 24) and descriptions (section 16)
        /// </summary>
        public MateriaData MateriaData { get; protected set; }

        /// <summary>
        /// Kernel section 16
        /// </summary>
        public TextSection MateriaDescriptions { get; protected set; }

        /// <summary>
        /// Kernel section 24
        /// </summary>
        public TextSection MateriaNames { get; protected set; }

        /// <summary>
        /// Kernel section 27
        /// </summary>
        public TextSection SummonAttackNames { get; protected set; }

        /// <summary>
        /// Kernel section 6, merged with names (Section 21) and descriptions (section 13)
        /// </summary>
        public WeaponData WeaponData { get; protected set; }

        /// <summary>
        /// Kernel section 13
        /// </summary>
        public TextSection WeaponDescriptions { get; protected set; }

        /// <summary>
        /// Kernel section 21
        /// </summary>
        public TextSection WeaponNames { get; protected set; }

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Reads a file path to a kernel file and decompresses each section
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static Dictionary<KernelSection, byte[]> DecompressKernel(string path)
        {
            var kernelFile = new FileInfo(path);

            using (var fileStream = kernelFile.OpenRead())
            using (var memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                var bytes = memoryStream.ToArray();
                var sections = new Dictionary<KernelSection, byte[]>();
                var offset = 0;

                for (var sectionIndex = 0; sectionIndex < 27; ++sectionIndex)
                {
                    var sectionCompressedLength = BitConverter.ToUInt16(bytes, offset + 0);
                    var sectionDecompressedLength = BitConverter.ToUInt16(bytes, offset + 2);
                    var fileType = BitConverter.ToUInt16(bytes, offset + 4);

                    var compressedSection = new byte[sectionCompressedLength];
                    Array.Copy(
                        bytes,
                        offset + 6,
                        compressedSection,
                        0,
                        sectionCompressedLength);

                    var decompressedSection = DecompressSection(compressedSection);

                    Console.WriteLine($"{(KernelSection)sectionIndex + 1} C:{compressedSection.Length} D:{decompressedSection.Length}");
                    sections.Add((KernelSection)sectionIndex + 1, decompressedSection);

                    offset += 6 + sectionCompressedLength;
                }
                return sections;
            }
        }

        /// <summary>
        /// Decompresses a byte[] using the GZIP format
        /// </summary>
        /// <param name="compressedSection">Compressed data</param>
        /// <returns>Decompressed data</returns>
        private static byte[] DecompressSection(byte[] compressedSection)
        {
            using (var compressedStream = new MemoryStream(compressedSection))
            using (var gzip = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var decompressedStream = new MemoryStream())
            {
                gzip.CopyTo(decompressedStream);
                return decompressedStream.ToArray();
            }
        }

        /// <summary>
        /// Parses and loads the data of each kernel section available.
        /// </summary>
        private void LoadSections()
        {
            this.CommandDescriptions = new TextSection(this.KernelData[KernelSection.CommandDescriptions]);
            this.MagicDescriptions = new TextSection(this.KernelData[KernelSection.MagicDescriptions]);
            this.ItemDescriptions = new TextSection(this.KernelData[KernelSection.ItemDescriptions]);
            this.WeaponDescriptions = new TextSection(this.KernelData[KernelSection.WeaponDescriptions]);
            this.ArmorDescriptions = new TextSection(this.KernelData[KernelSection.ArmorDescriptions]);
            this.AccessoryDescriptions = new TextSection(this.KernelData[KernelSection.AccessoryDescriptions]);
            this.MateriaDescriptions = new TextSection(this.KernelData[KernelSection.MateriaDescriptions]);
            this.KeyItemDescriptions = new TextSection(this.KernelData[KernelSection.KeyItemDescriptions]);
            this.CommandNames = new TextSection(this.KernelData[KernelSection.CommandNames]);
            this.MagicNames = new TextSection(this.KernelData[KernelSection.MagicNames]);
            this.ItemNames = new TextSection(this.KernelData[KernelSection.ItemNames]);
            this.WeaponNames = new TextSection(this.KernelData[KernelSection.WeaponNames]);
            this.ArmorNames = new TextSection(this.KernelData[KernelSection.ArmorNames]);
            this.AccessoryNames = new TextSection(this.KernelData[KernelSection.AccessoryNames]);
            this.MateriaNames = new TextSection(this.KernelData[KernelSection.MateriaNames]);
            this.KeyItemNames = new TextSection(this.KernelData[KernelSection.KeyItemNames]);
            this.BattleText = new TextSection(this.KernelData[KernelSection.BattleText]);
            this.SummonAttackNames = new TextSection(this.KernelData[KernelSection.SummonAttackNames]);

            this.WeaponData = new WeaponData(
                this.KernelData[KernelSection.WeaponData],
                this.WeaponNames.Strings,
                this.WeaponDescriptions.Strings);

            this.ItemData = new ItemData(
                this.KernelData[KernelSection.ItemData],
                this.ItemNames.Strings,
                this.ItemDescriptions.Strings);

            this.ArmorData = new ArmorData(
                this.KernelData[KernelSection.ArmorData],
                this.ArmorNames.Strings,
                this.ArmorDescriptions.Strings);

            this.AccessoryData = new AccessoryData(
                this.KernelData[KernelSection.AccessoryData],
                this.AccessoryNames.Strings,
                this.AccessoryDescriptions.Strings);

            this.MateriaData = new MateriaData(
                this.KernelData[KernelSection.MateriaData],
                this.MateriaNames.Strings,
                this.MateriaDescriptions.Strings);

            this.KeyItemData = new KeyItemData(this.KeyItemNames.Strings, this.KeyItemDescriptions.Strings);
        }

        #endregion Private Methods
    }
}