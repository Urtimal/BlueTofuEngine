using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class AbstractCharacterInformation : NetworkType
    {
        public uint CharacterId { get; set; }

        public AbstractCharacterInformation()
        {
            ProtocolId = 400;
        }

        public override void Initialize(IEntity entity)
        {
            CharacterId = entity.Character().CharacterId;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarULong(CharacterId);
        }
    }
}
