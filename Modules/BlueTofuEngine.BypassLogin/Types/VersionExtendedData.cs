using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace BlueTofuEngine.BypassLogin.Types
{
    public class VersionExtendedData : VersionData
    {
        public byte Install { get; set; }
        public byte Technology { get; set; }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            Install = reader.ReadByte();
            Technology = reader.ReadByte();
        }
    }
}
