using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    [NetworkMessage(Id)]
    public class ChatSmileyMessage : NetworkMessage
    {
        public const ushort Id = 801;

        public uint EntityId { get; set; }
        public int SmileyId { get; set; }
        public int AccountId { get; set; }

        public ChatSmileyMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteDouble(EntityId);
            writer.WriteVarShort((short)SmileyId);
            writer.WriteInt(AccountId);
        }

        public override string GetSummary()
        {
            return "[" + EntityId + "] " + SmileyId;
        }
    }
}
