using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class FightStartingPositions : NetworkType
    {
        public FightStartingPositions(uint protocolId = 513)
        {
            ProtocolId = protocolId;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteShort(0); // Challengers positions
            writer.WriteShort(0); // Defenders positions
        }
    }
}
