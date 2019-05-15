using BlueTofuEngine.Core;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    [NetworkMessage(Id)]
    public class IdentificationMessage : NetworkMessage
    {
        public const ushort Id = 4;

        public bool AutoConnect { get; set; }
        public bool UseCertificate { get; set; }
        public bool UseLoginToken { get; set; }
        public VersionExtended Version { get; set; }
        public string Lang { get; set; }
        public byte[] Credentials { get; set; }
        public short ServerId { get; set; }
        public long OptionalSalt { get; set; }

        public IdentificationMessage() : base(Id)
        {
            Version = new VersionExtended();
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            var byteBox = new ByteBox(reader.ReadByte());
            AutoConnect = byteBox[0];
            UseCertificate = byteBox[1];
            UseLoginToken = byteBox[2];
            Version.Deserialize(reader);
            Lang = reader.ReadUTF();
            var credentialsLength = reader.ReadVarInt();
            Credentials = reader.ReadBytes(credentialsLength);
            ServerId = reader.ReadShort();
            OptionalSalt = reader.ReadVarLong();
        }

        public override string GetSummary()
        {
            return Version.Major + "." + Version.Minor + "." + Version.Release;
        }
    }
}
