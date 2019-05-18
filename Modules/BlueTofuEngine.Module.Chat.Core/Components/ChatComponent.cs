using BlueTofuEngine.World.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    public class ChatComponent : IComponent
    {
        public string ComponentName => "chat";

        public List<ChatChannelType> EnabledChannels { get; set; }
        public List<ChatChannelType> DisallowedChannels { get; set; }

        public ChatComponent()
        {
            EnabledChannels = new List<ChatChannelType>();
            DisallowedChannels = new List<ChatChannelType>();
        }
    }
}
