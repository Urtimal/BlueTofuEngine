using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using D2DataReader;

namespace D2DataLib.D2P
{
    public class PakFile
    {
        public PakCollection Collection { get; private set; }
        public string Name { get; private set; }
        public Stream Stream { get; set; }
        public string LinkedFile { get; set; }
        public uint DataOffset { get; set; }

        public PakFile(PakCollection collection)
        {
            Collection = collection;
        }

        public bool Read(string filepath)
        {
            Name = Path.GetFileName(filepath);
            if (!File.Exists(filepath))
            {
                ConsoleExtensions.WriteLine("File not found", ConsoleColor.Red);
                return false;
            }
            var s = File.OpenRead(filepath);
            Stream = s;
            var vMax = s.ReadByte();
            var vMin = s.ReadByte();

            if (vMax != 2 && vMin != 1)
            {
                ConsoleExtensions.WriteLine("Not a D2P file", ConsoleColor.Red);
                return false;
            }

            s.Seek(-24, SeekOrigin.End);
            DataOffset = s.ReadUInt();
            var dataCount = s.ReadUInt();
            var indexOffset = s.ReadUInt();
            var indexCount = s.ReadUInt();
            var propertiesOffset = s.ReadUInt();
            var propertiesCount = s.ReadUInt();

            s.Seek(propertiesOffset, SeekOrigin.Begin);
            for (int i = 0; i < propertiesCount; i++)
            {
                var propertyName = s.ReadUTF();
                var propertyValue = s.ReadUTF();
                if (propertyName.Equals("link"))
                    LinkedFile = Path.Combine(Path.GetDirectoryName(filepath), propertyValue);
            }

            s.Seek(indexOffset, SeekOrigin.Begin);
            for (int i = 0; i < indexCount; i++)
            {
                var entry = new PakEntry(this);
                entry.Read(s);
                Collection.Entries.Add(entry.Name, entry);
            }

            ConsoleExtensions.WriteLine(indexCount + " entries", ConsoleColor.Green);
            return true;
        }
    }
}
