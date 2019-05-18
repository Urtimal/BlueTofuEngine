using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat.Messages
{
    [NetworkMessage(Id)]
    public class ChatAbstractClientMessage : NetworkMessage
    {
        public const ushort Id = 850;

        public string Content { get; set; }

        public ChatAbstractClientMessage() : base(Id)
        {
        }

        public ChatAbstractClientMessage(ushort messageId) : base(messageId)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            Content = reader.ReadUTF();
        }

        public override string GetSummary()
        {
            if (Content.Length > 70)
                return Content.Substring(0, 70) + "...";
            return Content;
        }
    }
}
