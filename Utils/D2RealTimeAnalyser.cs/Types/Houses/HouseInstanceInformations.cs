using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types
{
    public class HouseInstanceInformations : NetworkType
    {
        public HouseInstanceInformations() : base()
        {
            ProtocolId = 511;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            reader.ReadByte();
            reader.ReadInt(); // instance id
            reader.ReadUTF(); // owner
            reader.ReadVarLong(); // price
        }
    }
}
