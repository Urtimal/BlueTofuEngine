using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.Chat.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    [NetworkMessage(Id)]
    public class ChatServerCopyMessage : ChatAbstractServerMessage
    {
        public new const ushort Id = 882;

        public long ReceiverId { get; set; }
        public string ReceiverName { get; set; }

        public ChatServerCopyMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            base.serializeContent(writer);

            writer.WriteVarLong(ReceiverId);
            writer.WriteUTF(ReceiverName);
        }

        public override string GetSummary()
        {
            var content = Content;
            if (content.Length > 70)
                content = content.Substring(0, 70) + "...";
            return "[" + (ChatChannelType)Channel + "] " + ReceiverName + "(" + (int)ReceiverId + "): " + Content;
        }
    }
}
