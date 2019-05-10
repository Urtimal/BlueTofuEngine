using BlueTofuEngine.BypassLogin.Messages;
using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Client;
using BlueTofuEngine.Core.Network.Message;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueTofuEngine.BypassLogin
{
    public static class MessageHandler
    {
        [NetworkMessageHandler(IdentificationMessage.Id)]
        public static void OnIdentificationMessage(INetworkClient client, IdentificationMessage im)
        {
            client.Send(new IdentificationSuccessMessage());
            client.Send(new SelectedServerDataExtendedMessage());
            Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                client.Disconnect();
            });
        }
    }
}
