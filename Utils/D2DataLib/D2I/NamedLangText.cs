using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2I
{
    public class NamedLangText : LangText
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public override void Initialize(Stream s)
        {
            Key = s.ReadUTF();
            _position = s.ReadInt();
        }

        public override void Read(Stream s)
        {
            s.Seek(_position, SeekOrigin.Begin);
            Value = s.ReadUTF();

            Cached = true;
        }
    }
}
