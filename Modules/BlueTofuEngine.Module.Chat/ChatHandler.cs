using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.GameServer;
using BlueTofuEngine.Module.Chat.Messages;
using BlueTofuEngine.Module.Stats.Messages;
using BlueTofuEngine.World.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueTofuEngine.Module.Chat
{
    public static class ChatHandler
    {
        [NetworkMessageHandler(ChatClientMultiMessage.Id)]
        public static void OnClientMultiMessage(INetworkClient client, ChatClientMultiMessage message)
        {
            var sMessage = new ChatServerMessage
            {
                Channel = message.Channel,
                Content = message.Content,
                SenderId = client.GetEntity().Id,
                FingerPrint = message.Content,
                SenderAccountId = (int)client.GetEntity().Account().AccountId,
                SenderName = client.GetEntity().Look().EntityName
            };
            client.Send(sMessage);
        }
    }
}
