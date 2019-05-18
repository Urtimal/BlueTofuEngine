using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.Module.GameContext
{
    public class EntityDispositionInformations : NetworkType
    {
        public int CellId { get; set; }
        public int Direction { get; set; }

        public EntityDispositionInformations()
        {
            ProtocolId = 60;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteShort((short)CellId);
            writer.WriteByte((byte)Direction);
        }

        public override void Initialize(IEntity entity)
        {
            CellId = entity.Location().CellId;
            Direction = (int)entity.Location().Direction;
        }
    }
}
