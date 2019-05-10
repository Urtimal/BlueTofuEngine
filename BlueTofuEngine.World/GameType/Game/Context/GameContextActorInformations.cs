﻿using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Game;

namespace BlueTofuEngine.World.GameType.Game.Context
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
            ContextualId = entity.Id;
            Look = entity.Look().Look;
            Disposition = new EntityDispositionInformations();
            Disposition.Initialize(entity);
        }
    }
}
