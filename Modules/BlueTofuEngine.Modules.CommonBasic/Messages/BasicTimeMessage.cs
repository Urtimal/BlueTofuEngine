using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Modules.CommonBasic
{
    [NetworkMessage(Id)]
    public class BasicTimeMessage : NetworkMessage
    {
        public const ushort Id = 175;

        public BasicTimeMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteDouble(TimestampUtils.GetFromNowLong());
            writer.WriteShort(0); // Timezone offset
        }
    }
}
