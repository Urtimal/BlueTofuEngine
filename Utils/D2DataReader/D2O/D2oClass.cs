using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O
{
    public class D2oClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PackageName { get; set; }
        public List<D2oField> Fields { get; set; }

        public D2oClass()
        {
            Fields = new List<D2oField>();
        }

        public void Read(Stream s)
        {
            Id = s.ReadInt();
            Name = s.ReadUTF();
            PackageName = s.ReadUTF();

            var fieldCount = s.ReadInt();
            for (int i = 0; i < fieldCount; i++)
            {
                var field = D2oField.GetFieldDef(s);
                Fields.Add(field);
            }
        }

        public override string ToString()
        {
            string str = "";
            str += "[" + Id + "] " + Name + " : " + PackageName + "\n";
            foreach (var field in Fields)
                str += "    " + field + "\n";

            return str;
        }
    }
}
