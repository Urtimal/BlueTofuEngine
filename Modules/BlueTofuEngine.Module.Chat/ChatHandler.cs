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

        [NetworkMessageHandler(ChatClientPrivateMessage.Id)]
        public static void OnClientPrivateMessage(INetworkClient client, ChatClientPrivateMessage ccpm)
        {
            client.GetEntity().Notify(new ClientPrivateMessageEventArgs(ccpm.ReceiverName, ccpm.Content));
        }

        [NetworkMessageHandler(ChannelEnablingMessage.Id)]
        public static void OnChannelEnablingRequest(INetworkClient client, ChannelEnablingMessage cem)
        {
            client.GetEntity().Notify(new ToggleChatChannelEventArgs(cem.Channel, cem.Enable));
        }

        [NetworkMessageHandler(ChatSmileyRequestMessage.Id)]
        public static void OnSmileyRequest(INetworkClient client, ChatSmileyRequestMessage csrm)
        {
            client.GetEntity().Notify(new ShowSmileyEventArgs(csrm.SmileyId));
        }
    }
}
