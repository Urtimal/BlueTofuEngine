using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class GameContextCreateRequestMessage : NetworkMessage
    {
        public const ushort Id = 250;

        public GameContextCreateRequestMessage() : base(Id)
        { }

        public override void Deserialize(ICustomDataReader reader)
        {
        }
    }
}
