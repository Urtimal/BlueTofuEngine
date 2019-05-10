using D2DataLib.D2I;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O.DataFields
{
    public class I18nDataField : D2oField
    {
        public I18nDataField(string name) : base(name, GameDataType.I18n)
        {
        }

        public override object ReadValue(Stream s)
        {
            var value = s.ReadInt();
            //return D2iAccessor.GetI18n(value);
            return null;
        }
    }
}
