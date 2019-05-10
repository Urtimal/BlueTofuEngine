using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O.DataFields
{
    public class IntDataField : D2oField
    {
        public IntDataField(string name) : base(name, GameDataType.Int)
        {
        }

        public override object ReadValue(Stream s)
        {
            return s.ReadInt();
        }
    }
}
