using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.Module.GameContext
{
    public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
    {
        public string Name { get; set; }

        public GameRolePlayNamedActorInformations() : base()
        {
            ProtocolId = 154;
        }

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);

            Name = entity.Look().Name;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            writer.WriteUTF(Name);
        }
    }
}
