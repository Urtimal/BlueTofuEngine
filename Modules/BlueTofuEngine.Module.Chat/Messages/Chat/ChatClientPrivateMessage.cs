using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;

namespace BlueTofuEngine.Module.Chat.Messages
{
    [NetworkMessage(Id)]
    public class ChatClientPrivateMessage : ChatAbstractClientMessage
    {
        public new const ushort Id = 851;

        public string ReceiverName { get; set; }

        public ChatClientPrivateMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            ReceiverName = reader.ReadUTF();
        }

        public override string GetSummary()
        {
            return "To '" + ReceiverName + "': " + base.GetSummary();
        }
    }
}
