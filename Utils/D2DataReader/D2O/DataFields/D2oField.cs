using D2DataLib.D2O.DataFields;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.D2O
{
    public abstract class D2oField
    {
        public string Name { get; set; }
        public GameDataType Type { get; set; }
        public bool IsClass => Type > 0;
        public bool IsVectorType { get; set; }

        public D2oField(string name, GameDataType type)
        {
            Name = name;
            Type = type;
        }

        public abstract object ReadValue(Stream s);

        public static D2oField GetFieldDef(Stream s)
        {
            var name = s.ReadUTF();
            var type = (GameDataType)s.ReadInt();
            switch (type)
            {
                case GameDataType.Int:
                    return new IntDataField(name);
                case GameDataType.Boolean:
                    return new BooleanDataField(name);
                case GameDataType.String:
                    return new StringDataField(name);
                case GameDataType.Number:
                    return new NumberDataField(name);
                case GameDataType.I18n:
                    return new I18nDataField(name);
                case GameDataType.UInt:
                    return new UIntDataField(name);
                case GameDataType.Vector:
                    return new VectorDataField(name, s);
                default:
                    return new ObjectDataField(name, (int)type);
            }
        }

        public override string ToString()
        {
            var str = "";

            if (Type < 0)
                str = Type.ToString().ToLower();
            else
                str = "object(" + (int)Type + ")";

            if (!IsVectorType)
                str += " " + Name;

            return str;
        }
    }
}
