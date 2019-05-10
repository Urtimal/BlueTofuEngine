using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O.DataFields
{
    public class BooleanDataField : D2oField
    {
        public BooleanDataField(string name) : base(name, GameDataType.Boolean)
        {
        }

        public override object ReadValue(Stream s)
        {
            return s.ReadBoolean();
        }
    }
}
