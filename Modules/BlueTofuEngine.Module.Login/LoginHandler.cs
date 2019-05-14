using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Login
{
    public static class LoginHandler
    {
        [NetworkMessageHandler(IdentificationMessage.Id)]
        public static void OnIdentificationMessage(INetworkClient client, IdentificationMessage im)
        {
            var str = string.Join("", im.Credentials.Select(x => x.ToString("x2")));
            //client.Send(new IdentificationSuccessMessage());
            //client.Send(new SelectedServerDataExtendedMessage());
            //Task.Run(async () =>
            //{
            //    await Task.Delay(TimeSpan.FromSeconds(1));
            //    client.Disconnect();
            //});
        }
    }
}
