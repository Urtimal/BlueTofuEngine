using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2P
{
    public class PakEntry
    {
        public string Name { get; private set; }
        public uint Offset { get; set; }
        public int Length { get; set; }
        public PakFile PakFile { get; set; }

        public PakEntry(PakFile file)
        {
            PakFile = file;
        }

        public void Read(Stream s)
        {
            Name = s.ReadUTF();
            Offset = (uint)s.ReadInt() + PakFile.DataOffset;
            Length = s.ReadInt();
        }

        public void Extract(string destFolder)
        {
            var destPath = Path.Combine(destFolder, Name.Replace('/', '\\'));
            if (!Directory.Exists(Path.GetDirectoryName(destPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(destPath));

            var s = PakFile.Stream;
            s.Seek(Offset, SeekOrigin.Begin);
            var fileBytes = new byte[Length];
            s.Read(fileBytes, 0, Length);
            File.WriteAllBytes(destPath, fileBytes);
        }
    }
}
