using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    [NetworkMessage(Id)]
    public class EnabledChannelsMessage : NetworkMessage
    {
        public const ushort Id = 892;

        public IEnumerable<ChatChannelType> Channels { get; set; }
        public IEnumerable<ChatChannelType> DisallowedChannels { get; set; }

        public EnabledChannelsMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteUShort((ushort)Channels.Count());
            foreach (var channel in Channels)
                writer.WriteByte((byte)channel);
            writer.WriteUShort((ushort)DisallowedChannels.Count());
            foreach (var channel in DisallowedChannels)
                writer.WriteByte((byte)channel);
        }
    }
}
