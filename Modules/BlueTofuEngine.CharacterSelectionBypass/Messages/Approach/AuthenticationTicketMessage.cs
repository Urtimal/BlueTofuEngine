using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass.Messages
{
    [NetworkMessage(Id)]
    public class AuthenticationTicketMessage : NetworkMessage
    {
        public const ushort Id = 110;

        public string Lang { get; set; }
        public string Ticket { get; set; }

        public AuthenticationTicketMessage() : base(Id)
        { }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            Lang = reader.ReadUTF();
            Ticket = reader.ReadUTF();
        }

        public override string GetSummary()
        {
            return Ticket + " [" + Lang + "]";
        }
    }
}
