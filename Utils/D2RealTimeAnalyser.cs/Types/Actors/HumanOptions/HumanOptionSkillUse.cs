
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types.Actors.HumanOptions
{
    public class HumanOptionSkillUse : HumanOption
    {
        public HumanOptionSkillUse() : base()
        {
            ProtocolId = 495;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadVarInt();
            reader.ReadVarShort();
            reader.ReadDouble();
        }
    }
}
