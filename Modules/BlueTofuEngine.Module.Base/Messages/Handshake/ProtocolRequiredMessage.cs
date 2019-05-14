using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Base
{
    [NetworkMessage(Id)]
    public class ProtocolRequiredMessage : NetworkMessage
    {
        public const ushort Id = 1;

        public int Required { get; set; }
        public int Current { get; set; }

        public ProtocolRequiredMessage(int required = 1891, int current = 1923) : base(Id)
        {
            Required = required;
            Current = current;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteInt(Required); // Required version
            writer.WriteInt(Current); // Current version
        }
        
        public override string GetSummary()
        {
            return "Required:" + Required + ", Current:" + Current;
        }
    }
}
