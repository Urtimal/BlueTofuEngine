using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    [NetworkMessage(Id)]
    public class IdentificationFailedMessage : NetworkMessage
    {
        public const ushort Id = 20;

        public IdentificationFailureReason Reason { get; set; }

        public IdentificationFailedMessage(IdentificationFailureReason reason) : base(Id)
        {
            Reason = reason;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte((byte)Reason);
        }

        public override string GetSummary()
        {
            return Reason.ToString();
        }
    }
}
