using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Modules.CommonBasic
{
    public static class CommonBasicHandler
    {
        [NetworkMessageHandler(BasicPingMessage.Id)]
        public static void OnBasicPing(INetworkClient client, BasicPingMessage bpm)
        {
            client.Send(new BasicPongMessage(bpm.Quiet));
        }
    }
}
