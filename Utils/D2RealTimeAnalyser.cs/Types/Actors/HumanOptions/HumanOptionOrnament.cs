
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types.Actors.HumanOptions
{
    public class HumanOptionOrnament : HumanOption
    {
        public HumanOptionOrnament() : base()
        {
            ProtocolId = 411;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadVarShort();
            reader.ReadVarShort();
            reader.ReadVarShort();
            reader.ReadInt();
        }
    }
}
