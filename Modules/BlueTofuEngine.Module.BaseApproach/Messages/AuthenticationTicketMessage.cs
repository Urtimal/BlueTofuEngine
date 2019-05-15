using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.BaseApproach
{
    [NetworkMessage(Id)]
    public class AuthenticationTicketMessage : NetworkMessage
    {
        public const ushort Id = 110;

        public string Lang { get; set; }
        public string Ticket { get; set; }

        public AuthenticationTicketMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            Lang = reader.ReadUTF();
            var ticket = reader.ReadUTF();
            Ticket = string.Join("", ticket.Split(',').Select(x => (char)int.Parse(x))); ;
        }

        public override string GetSummary()
        {
            return "(" + Lang + ") " + Ticket;
        }
    }
}
