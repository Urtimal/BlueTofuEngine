using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.World.GameType.Game.Context.Roleplay
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

            Name = entity.Look().EntityName;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            writer.WriteUTF(Name);
        }
    }
}
