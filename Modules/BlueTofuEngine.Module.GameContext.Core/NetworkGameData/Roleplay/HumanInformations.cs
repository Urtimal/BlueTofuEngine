using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.Module.GameContext
{
    public class HumanInformations : NetworkType
    {
        public bool Gender { get; set; }

        public HumanInformations()
        {
            ProtocolId = 157;
        }

        public override void Initialize(IEntity entity)
        {
            Gender = entity.Character().Gender == Character.Gender.Female;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            var restrictions = new ActorRestrictionsInformations();
            restrictions.Serialize(writer);

            writer.WriteBool(Gender);
            writer.WriteShort(0); // Options
        }
    }
}
