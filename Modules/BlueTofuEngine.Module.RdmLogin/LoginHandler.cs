using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Module.BaseLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.RdmLogin
{
    public static class LoginHandler
    {
        [NetworkMessageHandler(ClearIdentificationMessage.Id)]
        public static void OnClearIdentificationMessage(INetworkClient client, ClearIdentificationMessage cim)
        {
            client.GetEntity().Notify(new ClientAuthentificationRequestEventArgs(cim.Username, cim.Password));
        }
    }
}
