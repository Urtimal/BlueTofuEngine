using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    public class ClientChatMessageEventArgs : SystemEventArgs
    {
        public ChatChannelType Channel { get; set; }
        public string Content { get; set; }

        public ClientChatMessageEventArgs(ChatChannelType channel, string content)
        {
            Channel = channel;
            Content = content;
        }

        public override bool CheckIsValid()
        {
            return Channel >= 0 && !string.IsNullOrEmpty(Content);
        }
    }
}
