using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlueTofuEngine.Module.RdmLogin
{
    [NetworkMessage(Id)]
    public class RawDataMessage : NetworkMessage
    {
        public const ushort Id = 6253;

        public RawDataMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            var swfFile = File.ReadAllBytes("RawDataMessage.swf");
            writer.WriteVarInt(swfFile.Length);
            writer.WriteBytes(swfFile);
        }
    }
}
