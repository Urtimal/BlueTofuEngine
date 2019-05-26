using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types.Actors.HumanOptions
{
    public class HumanOptionAlliance : HumanOption
    {
        public HumanOptionAlliance() : base()
        {
            ProtocolId = 425;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadVarUShort();
            reader.ReadInt();
            reader.ReadByte();
            reader.ReadInt();
            reader.ReadByte();
        }
    }
}
