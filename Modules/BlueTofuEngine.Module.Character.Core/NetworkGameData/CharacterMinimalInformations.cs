using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.Stats;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterMinimalInformations : CharacterBasicMinimalInformations
    {
        public int Level { get; set; }

        public CharacterMinimalInformations() : base()
        {
            ProtocolId = 110;
        }

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);

            Level = entity.Stats().Stats.Get(StatType.Level);
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            writer.WriteVarShort((short)Level);
        }
    }
}
