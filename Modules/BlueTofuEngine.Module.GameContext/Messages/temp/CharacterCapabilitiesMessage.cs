using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Game.GameContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class CharacterCapabilitiesMessage : NetworkMessage
    {
        public const ushort Id = 6339;
        
        public CharacterCapabilitiesMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteVarUInt(4095); // Guild emblem symbol categories (?)
        }
    }
}
