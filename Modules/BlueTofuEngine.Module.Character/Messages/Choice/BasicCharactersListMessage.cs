using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class BasicCharactersListMessage : NetworkMessage
    {
        public const ushort Id = 6475;

        public List<CharacterBaseInformations> Characters { get; set; }

        public BasicCharactersListMessage(ushort protocolId = Id) : base(protocolId)
        {
            Characters = new List<CharacterBaseInformations>();
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteShort((short)Characters.Count);
            foreach (var character in Characters)
            {
                writer.WriteShort((short)character.ProtocolId);
                character.Serialize(writer);
            }
        }
    }
}
