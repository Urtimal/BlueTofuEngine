using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class GameContextCreateMessage : NetworkMessage
    {
        public const ushort Id = 200;

        public GameContextType Type { get; set; }

        public GameContextCreateMessage(GameContextType type) : base(Id)
        {
            Type = type;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte((byte)Type);
        }
    }
}
