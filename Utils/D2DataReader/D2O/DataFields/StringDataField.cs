using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O.DataFields
{
    public class StringDataField : D2oField
    {
        public StringDataField(string name) : base(name, GameDataType.String)
        {
        }

        public override object ReadValue(Stream s)
        {
            var value = s.ReadUTF();
            return value == "null" ? null : value;
        }
    }
}
