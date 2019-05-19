using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    [NetworkMessage(Id)]
    public class GameMapMovementMessage : NetworkMessage
    {
        public const ushort Id = 951;

        public List<uint> Keys { get; set; }
        public Direction ForcedDirection { get; set; }
        public IEntity Entity { get; set; }

        public GameMapMovementMessage() : base(Id)
        {
            Keys = new List<uint>();
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteShort((short)Keys.Count);
            foreach (var key in Keys)
                writer.WriteShort((short)key);
            writer.WriteShort((short)ForcedDirection);
            writer.WriteDouble(Entity.ContextualId);
        }

        public override string GetSummary()
        {
            return string.Join(",", Keys);
        }
    }
}
