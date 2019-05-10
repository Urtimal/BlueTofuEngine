using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.Stats.GameType;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Game.GameContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Stats.Messages
{
    [NetworkMessage(Id)]
    public class CharacterStatsListMessage : NetworkMessage
    {
        public const ushort Id = 500;

        public IEntity Entity { get; set; }

        public CharacterStatsListMessage(IEntity entity) : base(Id)
        {
            Entity = entity;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            var statsInfos = new CharacterCharacteristicsInformations();
            statsInfos.Initialize(Entity);
            statsInfos.Serialize(writer);

            writer.WriteShort(0); // Spell modifications
            writer.WriteInt(0); // Probation time
        }
    }
}
