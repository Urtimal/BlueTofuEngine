using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.Module.GameContext
{
    public class GameContextActorInformations : NetworkType
    {
        public double ContextualId { get; set; }
        public EntityLook Look { get; set; }
        public EntityDispositionInformations Disposition { get; set; }

        public GameContextActorInformations()
        {
            ProtocolId = 150;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteDouble(ContextualId);
            Look.Serialize(writer);
            writer.WriteShort((short)Disposition.ProtocolId);
            Disposition.Serialize(writer);
        }

        public override void Initialize(IEntity entity)
        {
            ContextualId = entity.GameContext().ContextualId;
            Look = new EntityLook();
            Look.Initialize(entity);
            Disposition = new EntityDispositionInformations();
            Disposition.Initialize(entity);
        }
    }
}
