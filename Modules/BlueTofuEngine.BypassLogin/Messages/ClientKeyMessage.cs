using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.BypassLogin.Messages
{
    [NetworkMessage(Id)]
    public class ClientKeyMessage : NetworkMessage
    {
        public const ushort Id = 5607;
        
        public ClientKeyMessage() : base(Id)
        { }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(ICustomDataReader reader)
        {
        }
    }
}
