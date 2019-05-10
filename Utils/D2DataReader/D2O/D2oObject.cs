using D2DataLib.D2O.DataFields;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2DataLib.D2O
{
    public class D2oObject
    {
        public int Key { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public D2oClass ClassRef { get; set; }

        public object this[string propertyName]
        {
            get
            {
                if (Properties.ContainsKey(propertyName))
                    return Properties[propertyName];
                return null;
            }
        }

        public D2oObject()
        {
            Properties = new Dictionary<string, object>();
        }

        public bool Read(Stream s, IEnumerable<D2oClass> classes)
        {
            var classId = s.ReadInt();
            ClassRef = classes.FirstOrDefault(x => x.Id == classId);
            if (ClassRef == null)
                return false;

            foreach (var field in ClassRef.Fields)
            {
                if (field is ObjectDataField obj)
                    Properties.Add(field.Name, obj.ReadValue(s, classes));
                else if (field is VectorDataField list)
                    Properties.Add(field.Name, list.ReadValue(s, classes));
                else
                    Properties.Add(field.Name, field.ReadValue(s));
            }
            return true;
        }

        public JObject ToJsonObject()
        {
            var root = new JObject();
            foreach (var prop in Properties)
            {
                if (prop.Value is List<object> list)
                {
                    var array = toJsonArray(list);
                    root.Add(prop.Key, array);
                }
                else if (prop.Value is D2oObject obj)
                    root.Add(prop.Key, obj.ToJsonObject());
                else
                    root.Add(prop.Key, new JValue(prop.Value));
            }

            return root;
        }

        private JArray toJsonArray(List<object> list)
        {
            var array = new JArray();
            foreach (var item in list)
            {
                if (item is D2oObject obj)
                    array.Add(obj.ToJsonObject());
                else if (item is List<object> childList)
                    array.Add(toJsonArray(childList));
                else
                    array.Add(item);
            }

            return array;
        }


        public string ToJson()
        {
            return ToJsonObject().ToString(Newtonsoft.Json.Formatting.Indented);
        }
    }
}
