using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.GameType.Character.Restriction;

namespace BlueTofuEngine.World.GameType.Game.Context.Roleplay
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
            Gender = entity.Playable().Gender;
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
