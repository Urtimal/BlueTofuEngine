using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class CurrentMapMessage : NetworkMessage
    {
        public const ushort Id = 220;

        public int MapId { get; set; }

        public CurrentMapMessage(int mapId) : base(Id)
        {
            MapId = mapId;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteUTF("649ae451ca33ec53bbcbcc33becf15f4");
        }

        public override string GetSummary()
        {
            return MapId.ToString();
        }
    }
}
