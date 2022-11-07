using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shojy.FF7.Elena
{
    public class LgpReader: IDisposable
    {
        private readonly string _path;
        private readonly ArchiveFile[] _files;
        public Stream BaseStream { get; }

        public LgpReader(string path)
        {
            this._path = path;
            var s = new StreamReader(path);
            this.BaseStream = s.BaseStream;

            this._files = this.ReadContents();
        }

        public string[] ListFiles()
        {
            return this._files.Select(
                f => f.Name + (f.FileVersion > 0 ? $"${f.FileVersion}" : "")).ToArray();
        }

        public Stream ExtractFile(string name)
        {
            var nameParts = name.Split('$');

            var version = 0;

            if (nameParts.Length > 1)
            {
                version = ushort.Parse(nameParts.Last());
            }

            var data = this._files.SingleOrDefault(f => f.Name.Equals(nameParts[0]) && f.FileVersion == version);

            this.BaseStream.Position = data.Location;

            using (var reader = new BinaryReader(this.BaseStream, Encoding.ASCII, true))
            {
                var headerName = reader.ReadBytes(20);
                var length = reader.ReadInt32();
                var ms = new MemoryStream();

                this.BaseStream.CopyTo(ms, length);
                this.BaseStream.Position = 0;

                ms.Position = 0;
                return ms;
            }
        }

        private ArchiveFile[] ReadContents()
        {
            var files = new List<ArchiveFile>();

            using (var reader = new BinaryReader(this.BaseStream, Encoding.ASCII, true))
            {
                var fileHeader = reader.ReadBytes(12);
                var numberOfFiles = reader.ReadUInt32();

                for(var i = 0; i < numberOfFiles; ++i)
                {
                    var name = new string(reader.ReadChars(20)).TrimEnd('\0');
                    var pointer = reader.ReadUInt32();
                    var options = reader.ReadByte();
                    var dupes = reader.ReadUInt16();

                    var file = new ArchiveFile
                    {
                        Name = name,
                        Location = pointer,
                        Options = options,
                        FileVersion = dupes
                    };
                    
                    files.Add(file);
                }
            };

            return files.ToArray();
        }

        public void Dispose()
        {
            this.BaseStream.Dispose();
        }
    }
}
