using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Modules.CommonBasic
{
    [NetworkMessage(Id)]
    public class BasicPingMessage : NetworkMessage
    {
        public const ushort Id = 182;

        public bool Quiet { get; set; }

        public BasicPingMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            Quiet = reader.ReadBool();
        }
    }
}
