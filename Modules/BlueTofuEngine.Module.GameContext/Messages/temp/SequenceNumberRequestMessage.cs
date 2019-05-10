using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Game.GameContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class SequenceNumberRequestMessage : NetworkMessage
    {
        public const ushort Id = 6316;
        
        public SequenceNumberRequestMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
        }
    }
}
