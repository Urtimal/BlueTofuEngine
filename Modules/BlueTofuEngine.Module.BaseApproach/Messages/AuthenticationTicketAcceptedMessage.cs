using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseApproach
{
    [NetworkMessage(Id)]
    public class AuthenticationTicketAcceptedMessage : NetworkMessage
    {
        public const ushort Id = 111;

        public AuthenticationTicketAcceptedMessage() : base(Id)
        {
        }
    }
}
