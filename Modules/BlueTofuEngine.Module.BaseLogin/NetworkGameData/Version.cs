using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    public class Version : NetworkType
    {
        public byte Major { get; set; }
        public byte Minor { get; set; }
        public byte Release { get; set; }
        public int Revision { get; set; }
        public byte Patch { get; set; }
        public byte BuildType { get; set; }
        
        public Version(uint protocolId = 11)
        {
            ProtocolId = protocolId;
        }

        public override void Deserialize(ICustomDataReader reader)
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
