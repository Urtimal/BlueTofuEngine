using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    [NetworkMessage(Id)]
    public class ChatSmileyRequestMessage : NetworkMessage
    {
        public const ushort Id = 800;

        public int SmileyId { get; set; }

        public ChatSmileyRequestMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            SmileyId = reader.ReadVarShort();
        }

        public override string GetSummary()
        {
            return SmileyId.ToString();
        }
    }
}
