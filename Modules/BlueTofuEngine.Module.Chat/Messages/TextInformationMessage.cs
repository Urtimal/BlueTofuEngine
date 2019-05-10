using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat.Messages
{
    [NetworkMessage(Id)]
    public class TextInformationMessage : NetworkMessage
    {
        public const ushort Id = 780;

        public InfoMessageType Type { get; set; }
        public short TextId { get; set; }
        public string[] Args { get; set; }
        
        public TextInformationMessage(InfoMessageType type, short id, string[] args = null) : base(Id)
        {
            Type = type;
            TextId = id;
            if (args == null)
                Args = new string[0];
            else
                Args = args;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte((byte)Type);
            writer.WriteVarShort(TextId);
            writer.WriteShort((short)Args.Length);
            for (int i = 0; i < Args.Length; i++)
                writer.WriteUTF(Args[i]);
        }

        public override string GetSummary()
        {
            return "[" + Type + "] " + TextId;
        }
    }
}
