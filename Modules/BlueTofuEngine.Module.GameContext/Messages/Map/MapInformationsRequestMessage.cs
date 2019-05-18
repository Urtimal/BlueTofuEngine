using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class MapInformationsRequestMessage : NetworkMessage
    {
        public const ushort Id = 225;

        public long MapId { get; set; }

        public MapInformationsRequestMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            MapId = (long)reader.ReadDouble();
        }

        public override string GetSummary()
        {
            return MapId.ToString();
        }
    }
}
