using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    [NetworkMessage(Id)]
    public class HelloConnectMessage : NetworkMessage
    {
        public const ushort Id = 3;

        public string Salt { get; set; }
        public List<byte> Key { get; set; }

        public HelloConnectMessage() : base(Id)
        { }
        
        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteUTF(Salt);
            writer.WriteVarInt(Key.Count);
            for (int i = 0; i < Key.Count; i++)
                writer.WriteByte(Key[i]);
        }
    }
}
