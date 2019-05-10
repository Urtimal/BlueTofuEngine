using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O.DataFields
{
    public class ObjectDataField : D2oField
    {
        public ObjectDataField(string name, int classId) : base(name, (GameDataType)classId)
        {
        }

        public override object ReadValue(Stream s)
        {
            throw new NotImplementedException();
        }

        public object ReadValue(Stream s, IEnumerable<D2oClass> classes)
        {
            var obj = new D2oObject();
            if (!obj.Read(s, classes))
                return null;
            return obj;
        }
    }
}
