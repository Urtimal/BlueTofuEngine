using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2I
{
    public abstract class LangText
    {
        public bool Cached { get; protected set; }

        protected int _position;

        public abstract void Initialize(Stream s);
        public abstract void Read(Stream s);
    }
}
