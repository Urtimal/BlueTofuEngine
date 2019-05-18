using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    [NetworkMessage(Id)]
    public class ServerSelectionMessage : NetworkMessage
    {
        public const ushort Id = 40;

        public int ServerId { get; set; }

        public ServerSelectionMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            ServerId = reader.ReadVarShort();
        }

        public override string GetSummary()
        {
            return ServerId.ToString();
        }
    }
}
