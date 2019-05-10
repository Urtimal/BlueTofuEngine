using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;

namespace BlueTofuEngine.Module.Chat.Messages
{
    [NetworkMessage(Id)]
    public class ChatClientMultiMessage : ChatAbstractClientMessage
    {
        public new const ushort Id = 861;

        public int Channel { get; set; }

        public ChatClientMultiMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            Channel = reader.ReadByte();
        }

        public override string GetSummary()
        {
            return "[" + Channel + "] " + base.GetSummary();
        }
    }
}
