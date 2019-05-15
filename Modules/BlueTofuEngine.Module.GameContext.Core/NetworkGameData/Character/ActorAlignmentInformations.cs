using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;

namespace BlueTofuEngine.Module.GameContext
{
    public class ActorAlignmentInformations : NetworkType
    {
        public ActorAlignmentInformations()
        {
            ProtocolId = 201;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteByte(0); // Side
            writer.WriteByte(0); // Value
            writer.WriteByte(0); // Grade
            writer.WriteDouble(0); // Character power
        }
    }
}
