using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
    {
        public int DeathState { get; set; }
        public int DeathCount { get; set; }
        public int DeathMaxLevel { get; set; }

        public CharacterHardcoreOrEpicInformations() : base()
        {
            ProtocolId = 474;
        }

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            writer.WriteByte((byte)DeathState);
            writer.WriteVarShort((short)DeathCount);
            writer.WriteVarShort((short)DeathMaxLevel);
        }
    }
}
