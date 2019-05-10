using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O.DataFields
{
    public class UIntDataField : D2oField
    {
        public UIntDataField(string name) : base(name, GameDataType.UInt)
        {
        }

        public override object ReadValue(Stream s)
        {
            return s.ReadUInt();
        }
    }
}
