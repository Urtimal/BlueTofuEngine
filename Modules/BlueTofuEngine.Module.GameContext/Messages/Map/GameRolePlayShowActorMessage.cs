using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.Character;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class GameRolePlayShowActorMessage : NetworkMessage
    {
        public const ushort Id = 5632;

        public IEntity Entity { get; set; }

        public GameRolePlayShowActorMessage(IEntity entity) : base(Id)
        {
            Entity = entity;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            var infos = getCorrectNetworkType(Entity);
            infos.Initialize(Entity);

            writer.WriteShort((short)infos.ProtocolId);
            infos.Serialize(writer);
        }

        private GameRolePlayActorInformations getCorrectNetworkType(IEntity entity)
        {
            if (entity.HasComponent<CharacterComponent>())
                return new GameRolePlayCharacterInformations();

            return new GameRolePlayActorInformations();
        }

        public override string GetSummary()
        {
            return Entity.Character().CharacterId.ToString();
        }
    }
}
