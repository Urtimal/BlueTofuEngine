using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.BypassLogin.Types
{
    public class VersionData : ISerializableData
    {
        public byte Major { get; set; }
        public byte Minor { get; set; }
        public byte Release { get; set; }
        public int Revision { get; set; }
        public byte Patch { get; set; }
        public byte BuildType { get; set; }

        public void Serialize(ICustomDataWriter writer)
        {
            throw new NotImplementedException();
        }

        public virtual void Deserialize(ICustomDataReader reader)
        {
            Major = reader.ReadByte();
            Minor = reader.ReadByte();
            Release = reader.ReadByte();
            Revision = reader.ReadInt();
            Patch = reader.ReadByte();
            BuildType = reader.ReadByte();
        }   
    }
}
