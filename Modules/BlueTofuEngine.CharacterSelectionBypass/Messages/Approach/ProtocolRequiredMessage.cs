using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass.Messages
{
    [NetworkMessage(Id)]
    public class ProtocolRequiredMessage : NetworkMessage
    {
        public const ushort Id = 1;
        
        public ProtocolRequiredMessage() : base(Id)
        { }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteInt(1891); // Required version
            writer.WriteInt(1923); // Current version
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override string GetSummary()
        {
            return "Required:1891, Current:1923";
        }
    }
}
