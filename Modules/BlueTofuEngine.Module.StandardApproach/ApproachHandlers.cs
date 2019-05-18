using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Module.BaseApproach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlueTofuEngine.Module.StandardApproach
{
    public static class ApproachHandlers
    {
        [NetworkMessageHandler(AuthenticationTicketMessage.Id)]
        public static void OnAuthenticationTicket(INetworkClient client, AuthenticationTicketMessage atm)
        {
            client.GetEntity().Notify(new AuthenticationRequestEventArgs(atm.Ticket));
        }
    }
}
