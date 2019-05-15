using BlueTofuEngine.Core;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.RdmLogin
{
    [NetworkMessage(Id)]
    public class ClearIdentificationMessage : NetworkMessage
    {
        public const ushort Id = 888;

        public bool AutoConnect { get; set; }
        public string Lang { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public short ServerId { get; set; }

        public ClearIdentificationMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            var byteBox = new ByteBox(reader.ReadByte());
            AutoConnect = byteBox[0];
            Lang = reader.ReadUTF();
            Username = reader.ReadUTF();
            Password = reader.ReadUTF();
            ServerId = reader.ReadShort();
            reader.ReadUTF(); // connected server infos
            reader.ReadUTF(); // hardware id
        }
    }
}
