using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Game.Character
{
    public abstract class AbstractCharacterInformation : NetworkType
    {
        public long CharacterId { get; set; }

        public AbstractCharacterInformation()
        {
            ProtocolId = 400;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarLong(CharacterId);
        }

        public override void Initialize(IEntity entity)
        {
            CharacterId = entity.Id;
        }
    }
}
