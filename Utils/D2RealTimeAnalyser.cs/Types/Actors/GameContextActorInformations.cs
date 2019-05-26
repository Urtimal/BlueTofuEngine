using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types
{
    public class GameContextActorInformations : NetworkType
    {
        public long ContextualId { get; set; }

        public GameContextActorInformations()
        {
            ProtocolId = 150;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            ContextualId = (long)reader.ReadDouble();
            var look = new EntityLook();
            look.Deserialize(reader);
            reader.ReadUShort();
            reader.ReadShort();
            reader.ReadByte();
        }
    }
}
