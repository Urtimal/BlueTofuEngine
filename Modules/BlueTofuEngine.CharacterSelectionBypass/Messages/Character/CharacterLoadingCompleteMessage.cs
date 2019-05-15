using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass.Messages
{
    [NetworkMessage(Id)]
    public class CharacterLoadingCompleteMessage : NetworkMessage
    {
        public const ushort Id = 6471;
        
        public CharacterLoadingCompleteMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
        }
    }
}
