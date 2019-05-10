using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Game.Character.Choice
{
    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public bool Gender { get; set; }

        public CharacterBaseInformations() : base()
        {
            ProtocolId = 45;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            writer.WriteBool(Gender);
        }

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);

            Gender = entity.Playable()?.Gender ?? false;
        }
    }
}
