using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace BlueTofuEngine.Module.Login
{
    public class VersionExtended : Version
    {
        public byte Install { get; set; }
        public byte Technology { get; set; }

        public VersionExtended(uint protocolId = 393) : base(protocolId)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            Install = reader.ReadByte();
            Technology = reader.ReadByte();
        }
    }
}
