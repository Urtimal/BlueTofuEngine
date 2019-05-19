using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class GameContextRemoveElementMessage : NetworkMessage
    {
        public const ushort Id = 251;

        public int ElementId { get; set; }

        public GameContextRemoveElementMessage(int elementId) : base(Id)
        {
            ElementId = elementId;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteDouble(ElementId);
        }

        public override string GetSummary()
        {
            return ElementId.ToString();
        }
    }
}
