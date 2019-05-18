using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.Character;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.Module.GameContext
{
    public class HumanInformations : NetworkType
    {
        public bool Gender { get; set; }
        public ActorRestrictionsInformations Restrictions { get; set; }

        public HumanInformations()
        {
            ProtocolId = 157;
        }

        public override void Initialize(IEntity entity)
        {
            Gender = entity.Character().Gender == Character.Gender.Female;
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Initialize(entity);
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            Restrictions.Serialize(writer);
            writer.WriteBool(Gender);
            writer.WriteShort(0); // Options
        }
    }
}
