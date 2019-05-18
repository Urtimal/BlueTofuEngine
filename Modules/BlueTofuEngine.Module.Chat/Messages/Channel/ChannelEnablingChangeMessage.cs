using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    [NetworkMessage(Id)]
    public class ChannelEnablingChangeMessage : NetworkMessage
    {
        public const ushort Id = 891;

        public ChatChannelType Channel { get; set; }
        public bool Enable { get; set; }

        public ChannelEnablingChangeMessage(ChatChannelType channel, bool enable) : base(Id)
        {
            Channel = channel;
            Enable = enable;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte((byte)Channel);
            writer.WriteBool(Enable);
        }

        public override string GetSummary()
        {
            return Channel + " : " + (Enable ? "Enable" : "Disable");
        }
    }
}
