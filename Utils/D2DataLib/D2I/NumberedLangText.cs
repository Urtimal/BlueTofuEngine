using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2I
{
    public class NumberedLangText : LangText
    {
        public int Key { get; private set; }
        public string Value { get; private set; }
        public string UnDiactriticalValue { get; private set; }
        public bool IsDiacritical { get; private set; }

        private int _unDiacriticalPosition;

        public override void Initialize(Stream s)
        {
            Key = s.ReadInt();
            IsDiacritical = s.ReadBoolean();
            _position = s.ReadInt();
            if (IsDiacritical)
                _unDiacriticalPosition = s.ReadInt();
        }

        public override void Read(Stream s)
        {
            s.Seek(_position, SeekOrigin.Begin);
            Value = s.ReadUTF();
            if (IsDiacritical)
            {
                s.Seek(_unDiacriticalPosition, SeekOrigin.Begin);
                UnDiactriticalValue = s.ReadUTF();
            }
            else
                UnDiactriticalValue = Value;

            Cached = true;
        }
    }
}
