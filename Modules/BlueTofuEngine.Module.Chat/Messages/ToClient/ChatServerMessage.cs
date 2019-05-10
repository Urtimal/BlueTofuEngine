using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace BlueTofuEngine.Module.Chat.Messages
{
    public class ChatServerMessage : ChatAbstractServerMessage
    {
        public new const ushort Id = 881;

        public double SenderId { get; set; }
        public string SenderName { get; set; }
        public string Prefix { get; set; }
        public int SenderAccountId { get; set; }

        public ChatServerMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            base.serializeContent(writer);

            writer.WriteDouble(SenderId);
            writer.WriteUTF(SenderName);
            writer.WriteUTF(Prefix);
            writer.WriteInt(SenderAccountId);
        }

        public override string GetSummary()
        {
            var content = Content;
            if (content.Length > 70)
                content = content.Substring(0, 70) + "...";
            return "[" + Channel + "] " + SenderName + "(" + (int)SenderId + "): " + Content;
        }
    }
}
