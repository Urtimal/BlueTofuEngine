using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types
{
    public class SubEntity : NetworkType
    {
        public SubEntity()
        {
            ProtocolId = 54;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            reader.ReadByte();
            reader.ReadByte();
            var look = new EntityLook();
            look.Deserialize(reader);
        }
    }
}
