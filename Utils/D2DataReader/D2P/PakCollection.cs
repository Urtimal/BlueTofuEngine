using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2P
{
    public class PakCollection
    {
        public List<PakFile> Files { get; private set; }
        public Dictionary<string, PakEntry> Entries { get; private set; }

        public PakCollection()
        {
            Files = new List<PakFile>();
            Entries = new Dictionary<string, PakEntry>();
        }

        public void Read(string filepath)
        {
            var nextFile = filepath;
            while (true)
            {
                var file = new PakFile(this);
                Console.Write("Read pak://" + Path.GetFileName(nextFile) + " ");
                if (file.Read(nextFile))
                    Files.Add(file);
                if (string.IsNullOrEmpty(file.LinkedFile))
                    break;
                else
                    nextFile = file.LinkedFile;
            }
        }

        public void ExtractAll(string destPath, IProgress<string> progress)
        {
            foreach (var entry in Entries.Values)
            {
                entry.Extract(destPath);
                progress.Report(entry.Name);
            }
        }
    }
}
