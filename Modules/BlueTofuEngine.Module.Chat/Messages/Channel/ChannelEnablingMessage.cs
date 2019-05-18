using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    [NetworkMessage(Id)]
    public class ChannelEnablingMessage : NetworkMessage
    {
        public const ushort Id = 890;

        public ChatChannelType Channel { get; set; }
        public bool Enable { get; set; }

        public ChannelEnablingMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            Channel = (ChatChannelType)reader.ReadByte();
            Enable = reader.ReadBool();
        }

        public override string GetSummary()
        {
            return Channel + " : " + (Enable ? "Enable" : "Disable");
        }
    }
}
