using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2DataLib.SWL
{
    public class SwlFile
    {
        public int Version { get; set; }
        public int Framerate { get; set; }
        public List<string> ClassesName { get; set; }
        public Stream Stream { get; set; }

        public SwlFile()
        {
            ClassesName = new List<string>();
        }

        public bool Read(string filename)
        {
            var s = File.OpenRead(filename);

            var header = s.ReadByte();
            if (header != 76)
                return false;

            Version = s.ReadByte();
            Framerate = (int)s.ReadUInt();
            var classesCount = s.ReadInt();
            for (int i = 0; i < classesCount; i++)
                ClassesName.Add(s.ReadUTF());
            Stream = s;
            return true;
        }

        public void ExtractSwf(string filepath)
        {
            var bytes = Stream.ReadToEnd();
            Stream.Close();
            File.WriteAllBytes(filepath, bytes.ToArray());
        }
    }
}
