using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterBasicMinimalInformations : AbstractCharacterInformation
    {
        public string Name { get; set; }

        public CharacterBasicMinimalInformations() : base()
        {
            ProtocolId = 503;
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
