using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.BypassLogin.Messages
{
    [NetworkMessage(Id)]
    public class LoginQueueStatusMessage : NetworkMessage
    {
        public const ushort Id = 10;

        public short Position { get; set; }
        public short Total { get; set; }

        public LoginQueueStatusMessage(short position, short total) : base(Id)
        {
            Position = position;
            Total = total;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteShort(Position);
            writer.WriteShort(Total);
        }

        public override void Deserialize(ICustomDataReader reader)
        {
        }
    }
}
