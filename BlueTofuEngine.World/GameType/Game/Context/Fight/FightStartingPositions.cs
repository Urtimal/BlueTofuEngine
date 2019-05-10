using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace BlueTofuEngine.World.GameType.Game.Context.Fight
{
    public class FightStartingPositions : NetworkType
    {
        public FightStartingPositions()
        {
            ProtocolId = 513;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteShort(0); // Positions for challengers
            writer.WriteShort(0); // Positions for defenders
        }
    }
}
