using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    public class ClientPrivateMessageEventArgs : SystemEventArgs
    {
        public string ReceiverName { get; set; }
        public string Content { get; set; }

        public ClientPrivateMessageEventArgs(string receiverName, string content)
        {
            ReceiverName = receiverName;
            Content = content;
        }

        public override bool CheckIsValid()
        {
            return !string.IsNullOrEmpty(ReceiverName) && !string.IsNullOrEmpty(Content);
        }
    }
}
