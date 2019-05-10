using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.GameData;
using BlueTofuEngine.World.GameType.Game.Context;
using BlueTofuEngine.World.GameType.Game.Context.Fight;
using BlueTofuEngine.World.GameType.Game.Context.Roleplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const ushort Id = 226;

        public int MapId { get; set; }
        public IEntity Entity { get; set; }

        public MapComplementaryInformationsDataMessage(int mapId, IEntity entity) : base(Id)
        {
            MapId = mapId;
            Entity = entity;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            var mapPosition = GameDataManager<MapPosition>.Instance.Get(MapId);

            writer.WriteVarShort((short)mapPosition.SubAreaId);
            writer.WriteDouble(MapId);
            writer.WriteShort(0); // House count

            //writer.WriteShort(0); // Actors count
            writer.WriteShort(1); // Actors count

            var actorInfos = new GameRolePlayCharacterInformations();
            actorInfos.Initialize(Entity);
            writer.WriteShort((short)actorInfos.ProtocolId);
            actorInfos.Serialize(writer);

            writer.WriteShort(0); // Interactive elements count
            writer.WriteShort(0); // Stated elements count
            writer.WriteShort(0); // Obstacles count
            writer.WriteShort(0); // Fights count
            writer.WriteBool(false); // Has aggressive monsters

            var fightPositions = new FightStartingPositions();
            fightPositions.Serialize(writer);
        }

        public override string GetSummary()
        {
            return MapId.ToString();
        }
    }
}
