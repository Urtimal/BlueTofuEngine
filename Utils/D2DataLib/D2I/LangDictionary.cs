using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2DataLib.D2I
{
    public class LangDictionary : IDisposable
    {
        public string LangId { get; set; }

        public IEnumerable<LangText> AllTexts => _texts.Values;
        public IEnumerable<NumberedLangText> NumberedTexts => _texts.Values.OfType<NumberedLangText>();
        public IEnumerable<NamedLangText> NamedTexts => _texts.Values.OfType<NamedLangText>();

        private readonly Dictionary<string, LangText> _texts;
        private int _indexPosition;
        private Stream _stream;

        public LangDictionary(string langId = "??")
        {
            LangId = langId;
            _texts = new Dictionary<string, LangText>();
        }

        public void Import(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException();
            
            Import(File.OpenRead(filename));
        }

        public void Import(Stream s)
        {
            _stream = s;
            _indexPosition = s.ReadInt();
            s.Seek(_indexPosition, SeekOrigin.Begin);

            // Numbered key
            var indexLength = s.ReadInt();
            for (int i = 0; i < indexLength; i += 9)
            {
                var entry = new NumberedLangText();
                entry.Initialize(s);
                if (entry.IsDiacritical)
                    i += 4;
                if (!_texts.ContainsKey(entry.Key.ToString()))
                    _texts.Add(entry.Key.ToString(), entry);
            }

            // Named key
            indexLength = s.ReadInt();
            while (indexLength > 0)
            {
                var beginPos = s.Position;
                var entry = new NamedLangText();
                entry.Initialize(s);
                if (!_texts.ContainsKey(entry.Key))
                    _texts.Add(entry.Key, entry);
                indexLength -= (int)(s.Position - beginPos);
            }
        }

        public string Get(int key, bool unDiacritical = false) => Get(key.ToString(), unDiacritical);

        public string Get(string key, bool unDiacritical = false)
        {
            if (!_texts.ContainsKey(key))
                return key;

            var text = _texts[key];
            if (!text.Cached)
                text.Read(_stream);

            if (text is NumberedLangText numberedText)
                return unDiacritical ? numberedText.UnDiactriticalValue : numberedText.Value;
            else if (text is NamedLangText namedText)
                return namedText.Value;
            else
                return key;
        }

        public void Dispose()
        {
            _stream.Dispose();
            _texts.Clear();
        }
    }
}
