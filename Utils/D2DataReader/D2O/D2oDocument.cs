using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2DataLib.D2O
{
    public class D2oDocument
    {
        public int IndexPosition { get; set; }
        public List<D2oIndexEntry> Index { get; set; }
        public List<D2oClass> Classes { get; set; }
        public Stream Stream { get; set; }

        public D2oDocument()
        {
            Index = new List<D2oIndexEntry>();
            Classes = new List<D2oClass>();
        }

        public bool Read(Stream s)
        {
            var header = s.ReadUTFBytes(3);
            if (header != "D2O")
            {
                Console.WriteLine("Not a D2O file");
                return false;
            }

            if (!readIndex(s))
                return false;
            if (!readClasses(s))
                return false;

            Stream = s;

            return true;
        }
        private bool readIndex(Stream s)
        {
            try
            {
                IndexPosition = s.ReadInt();
                s.Seek(IndexPosition, SeekOrigin.Begin);
                var indexLength = s.ReadInt();

                for (int i = 0; i < indexLength; i += 8)
                {
                    var entry = new D2oIndexEntry();
                    entry.Read(s);
                    Index.Add(entry);
                }

                return true;
            }
            catch { return false; }
        }
        private bool readClasses(Stream s)
        {
            try
            {
                var count = s.ReadInt();

                for (int i = 0; i < count; i++)
                {
                    var dataClass = new D2oClass();
                    dataClass.Read(s);
                    Classes.Add(dataClass);
                }

                return true;
            }
            catch { return false; }
        }

        public D2oObject GetEntry(int id)
        {
            var index = Index.FirstOrDefault(x => x.Key == id);
            if (index == null)
                return null;
            
            var obj = new D2oObject();

            obj.Key = id;
            Stream.Seek(index.Pointer, SeekOrigin.Begin);
            if (!obj.Read(Stream, Classes))
                return null;

            return obj;
        }

        public void ExportJson(string outputDirectory, IProgress<int> progress)
        {
            foreach (var index in Index)
            {
                var obj = GetEntry(index.Key);
                File.WriteAllText(Path.Combine(outputDirectory, index.Key + ".json"), obj.ToJson());
                progress.Report(0);
            }
        }
    }
}
