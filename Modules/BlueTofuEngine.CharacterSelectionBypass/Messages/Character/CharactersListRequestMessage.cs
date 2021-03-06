﻿using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass.Messages
{
    [NetworkMessage(Id)]
    public class CharactersListRequestMessage : NetworkMessage
    {
        public const ushort Id = 150;

        public CharactersListRequestMessage() : base(Id)
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
