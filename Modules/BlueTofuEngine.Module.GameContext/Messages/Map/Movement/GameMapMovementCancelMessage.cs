using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    [NetworkMessage(Id)]
    public class GameMapMovementCancelMessage : NetworkMessage
    {
        public const ushort Id = 953;
        
        public GameMapMovementCancelMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
        }
    }
}
