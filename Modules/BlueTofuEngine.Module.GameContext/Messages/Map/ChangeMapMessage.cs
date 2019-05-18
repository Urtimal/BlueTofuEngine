using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class ChangeMapMessage : NetworkMessage
    {
        public const ushort Id = 221;

        public long MapId { get; set; }
        public bool IsAutopilot { get; set; }

        public ChangeMapMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            MapId = (long)reader.ReadDouble();
            IsAutopilot = reader.ReadBool();
        }

        public override string GetSummary()
        {
            return null;
        }
    }
}
