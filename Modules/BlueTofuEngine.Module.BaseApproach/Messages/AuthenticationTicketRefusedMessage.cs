using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseApproach
{
    [NetworkMessage(Id)]
    public class AuthenticationTicketRefusedMessage : NetworkMessage
    {
        public const ushort Id = 112;

        public AuthenticationTicketRefusedMessage() : base(Id)
        {
        }
    }
}
