using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat.Messages
{
    [NetworkMessage(Id)]
    public class ChatAbstractServerMessage : NetworkMessage
    {
        public const ushort Id = 880;

        public int Channel { get; set; }
        public string Content { get; set; }
        public string FingerPrint { get; set; }

        public ChatAbstractServerMessage() : base(Id)
        {
        }

        public ChatAbstractServerMessage(ushort id) : base(id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte((byte)Channel);
            writer.WriteUTF(Content);
            writer.WriteInt(TimestampUtils.GetFromNow());
            writer.WriteUTF(Content);
        }

        public override string GetSummary()
        {
            var summary = "[" + Channel + "] ";
            if (Content.Length > 70)
                return summary + Content.Substring(0, 70) + "...";
            return summary + Content;
        }
    }
}
