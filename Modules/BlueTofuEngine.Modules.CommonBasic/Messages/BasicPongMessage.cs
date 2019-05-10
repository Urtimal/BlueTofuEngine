using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Modules.CommonBasic
{
    [NetworkMessage(Id)]
    public class BasicPongMessage : NetworkMessage
    {
        public const ushort Id = 183;

        public bool Quiet { get; set; }

        public BasicPongMessage(bool quiet) : base(Id)
        {
            Quiet = quiet;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteBool(Quiet);
        }
    }
}
