using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O
{
    public class D2oIndexEntry
    {
        public int Key { get; set; }
        public int Pointer { get; set; }
        
        public void Read(Stream s)
        {
            Key = s.ReadInt();
            Pointer = s.ReadInt();
        }
    }
}
