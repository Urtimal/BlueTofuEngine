using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public Gender Sex { get; set; }

        public CharacterBaseInformations() : base()
        {
            ProtocolId = 45;
        }

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);

            Sex = entity.Character().Gender;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            writer.WriteBool(Sex == Gender.Female);
        }
    }
}
