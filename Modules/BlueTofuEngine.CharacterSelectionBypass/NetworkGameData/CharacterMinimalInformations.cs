using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.Stats;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.CharacterSelectionBypass
{
    public class CharacterMinimalInformations : CharacterBasicMinimalInformations
    {
        public short Level { get; set; }

        public CharacterMinimalInformations() : base()
        {
            ProtocolId = 110;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            writer.WriteVarShort(Level);
        }

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);

            Level = (short)(entity.Stats()?.Stats.Get(StatType.Level) ?? 1);
        }
    }
}
