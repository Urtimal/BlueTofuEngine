using BlueTofuEngine.BypassLogin.Types;
using BlueTofuEngine.Core;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.BypassLogin.Messages
{
    [NetworkMessage(Id)]
    public class IdentificationMessage : NetworkMessage
    {
        public const ushort Id = 4;

        public bool AutoConnect { get; set; }
        public bool UseCertificate { get; set; }
        public bool UseLoginToken { get; set; }
        public VersionExtendedData Version { get; set; }

        public IdentificationMessage() : base(Id)
        {
            Version = new VersionExtendedData();
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            var byteBox = new ByteBox(reader.ReadByte());
            AutoConnect = byteBox[0];
            UseCertificate = byteBox[1];
            UseLoginToken = byteBox[2];
            Version.Deserialize(reader);
        }

        public override string GetSummary()
        {
            return Version.Major + "." + Version.Minor + "." + Version.Release;
        }
    }
}
