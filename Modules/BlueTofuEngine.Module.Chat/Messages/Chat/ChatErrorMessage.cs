using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    [NetworkMessage(Id)]
    public class ChatErrorMessage : NetworkMessage
    {
        public const ushort Id = 870;

        public ChatErrorType Error { get; set; }

        public ChatErrorMessage(ChatErrorType error) : base(Id)
        {
            Error = error;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte((byte)Error);
        }

        public override string GetSummary()
        {
            return Error.ToString();
        }
    }
}
