using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    public class ToggleChatChannelEventArgs : SystemEventArgs
    {
        public ChatChannelType Channel { get; set; }
        public bool Enable { get; set; }

        public ToggleChatChannelEventArgs(ChatChannelType channel, bool enable)
        {
            Channel = channel;
            Enable = enable;
        }

        public override bool CheckIsValid()
        {
            return Channel >= ChatChannelType.General;
        }
    }
}
