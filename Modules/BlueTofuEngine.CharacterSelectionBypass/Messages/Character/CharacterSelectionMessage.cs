using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass.Messages
{
    [NetworkMessage(Id)]
    public class CharacterSelectionMessage : NetworkMessage
    {
        public const ushort Id = 152;

        public long CharacterId { get; set; }

        public CharacterSelectionMessage() : base(Id)
        { }
        
        protected override void serializeContent(ICustomDataWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            CharacterId = reader.ReadVarLong();
        }

        public override string GetSummary()
        {
            return CharacterId.ToString();
        }
    }
}
