using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types.Actors.HumanOptions
{
    public class HumanOptionFollowers : HumanOption
    {
        public HumanOptionFollowers() : base()
        {
            ProtocolId = 410;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            var len = reader.ReadUShort();
            for (int i = 0; i < len; i++)
            {
                var look = new EntityLook();
                look.Deserialize(reader);
                reader.ReadByte();
            }
        }
    }
}
