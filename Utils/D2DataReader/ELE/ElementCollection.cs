using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2DataLib.ELE
{
    public class ElementCollection
    {
        public int FileVersion { get; private set; }
        public List<Element> Elements { get; private set; }
        public List<int> JpgMap { get; private set; }
        public Stream Stream { get; private set; }
        public string TmpFile { get; set; }

        public ElementCollection()
        {
            Elements = new List<Element>();
            JpgMap = new List<int>();
        }

        public void Read(Stream s)
        {
            Stream = s;
            var header = s.ReadByte();
            if (header != 69)
                return;

            FileVersion = s.ReadByte();
            var elementCount = s.ReadUInt();

            for (int i = 0; i < elementCount; i++)
            {
                var element = new Element(this);
                element.Read(s);
                Elements.Add(element);
            }

            if (FileVersion >= 8)
            {
                var gfxCount = s.ReadInt();
                for (int i = 0; i < gfxCount; i++)
                    JpgMap.Add(s.ReadInt());
            }
        }

        public Element ReadElement(int id)
        {
            var element = Elements.FirstOrDefault(x => x.Id == id);
            if (element == null)
                return null;

            element.ReadData();
            return element;
        }

        public void ReadElements()
        {
            foreach (var element in Elements)
                element.ReadData();
        }

        public void ExportToJson(string outputDir, IProgress<string> progress)
        {
            foreach (var element in Elements)
            {
                var path = Path.Combine(outputDir, element.Id + ".json");
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                var json = JsonConvert.SerializeObject(element, Formatting.Indented);
                File.WriteAllText(path, json);
                progress.Report(element.Id + ".json");
            }
        }

        public void Close()
        {
            Stream.Close();
            File.Delete(TmpFile);
        }
    }
}
