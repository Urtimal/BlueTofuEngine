using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.CharacterSelectionBypass
{
    public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
    {
        public EntityLook Look { get; set; }
        public int Breed { get; set; }

        public CharacterMinimalPlusLookInformations() : base()
        {
            ProtocolId = 163;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            Look.Serialize(writer);
            writer.WriteByte((byte)Breed);
        }

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);
            
            Look = entity.Look()?.Look;
            Breed = entity.Playable()?.BreedId ?? 1;
        }
    }
}
