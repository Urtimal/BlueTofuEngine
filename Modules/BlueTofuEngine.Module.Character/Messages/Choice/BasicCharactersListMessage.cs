using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class BasicCharactersListMessage : NetworkMessage
    {
        public const ushort Id = 6475;

        public BasicCharactersListMessage(ushort protocolId = Id) : base(protocolId)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteShort(0);
        }
    }
}
