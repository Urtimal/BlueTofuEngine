using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O.DataFields
{
    public class VectorDataField : D2oField
    {
        public D2oField InnerField { get; set; }

        public VectorDataField(string name, Stream s) : base(name, GameDataType.Vector)
        {
            InnerField = GetFieldDef(s);
            InnerField.IsVectorType = true;
        }

        public override object ReadValue(Stream s)
        {
            throw new NotImplementedException();
        }

        public object ReadValue(Stream s, IEnumerable<D2oClass> classes)
        {
            var list = new List<object>();
            var length = s.ReadInt();
            for (int i = 0; i < length; i++)
            {
                if (InnerField is ObjectDataField obj)
                    list.Add(obj.ReadValue(s, classes));
                else if (InnerField is VectorDataField vector)
                    list.Add(vector.ReadValue(s, classes));
                else
                    list.Add(InnerField.ReadValue(s));
            }
            return list;
        }

        public override string ToString()
        {
            var str = "";
            str = Type.ToString().ToLower() + "<" + InnerField + ">";
            if (!IsVectorType)
                str += " " + Name;
            return str;
        }
    }
}
