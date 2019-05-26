using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types
{
    public class HouseInformations : NetworkType
    {
        public uint Id { get; set; }
        public ushort ModelId { get; set; }

        public HouseInformations() : base()
        {
            ProtocolId = 111;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            Id = reader.ReadVarUInt();
            ModelId = reader.ReadVarUShort();
        }
    }
}
