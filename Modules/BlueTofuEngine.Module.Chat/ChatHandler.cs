using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.GameServer;
using BlueTofuEngine.Module.Chat.Messages;
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
            client.GetEntity().Notify(new ClientChatMessageEventArgs((ChatChannelType)message.Channel, message.Content));
        }
    }
}
