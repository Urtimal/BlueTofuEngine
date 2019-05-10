using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass.Messages
{
    [NetworkMessage(Id)]
    public class HelloGameMessage : NetworkMessage
    {
        public const ushort Id = 101;
        
        public HelloGameMessage() : base(Id)
        { }

        protected override void serializeContent(ICustomDataWriter writer)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
