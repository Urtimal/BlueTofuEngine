using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O.DataFields
{
    public class NumberDataField : D2oField
    {
        public NumberDataField(string name) : base(name, GameDataType.Number)
        {
        }

        public override object ReadValue(Stream s)
        {
            return s.ReadDouble();
        }
    }
}
