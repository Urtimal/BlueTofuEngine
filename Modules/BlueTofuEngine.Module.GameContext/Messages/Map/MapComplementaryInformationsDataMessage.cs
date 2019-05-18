using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.Character;
using BlueTofuEngine.Module.GameContext.Data;
using BlueTofuEngine.World.Context;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Messages
{
    [NetworkMessage(Id)]
    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const ushort Id = 226;
        
        public IContext MapContext { get; set; }

        public MapComplementaryInformationsDataMessage(IContext context) : base(Id)
        {
            MapContext = context;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            var mapPosition = GameDataManager<MapPosition>.Instance.Get((int)MapContext.Map().Id);

            writer.WriteVarShort((short)mapPosition.SubAreaId);
            writer.WriteDouble(mapPosition.Id);

            serializeHouses(writer);
            serializeActors(writer);
            serializeInteractives(writer);
            serializeStatedElements(writer);
            serializeObstacles(writer);
            serializeFights(writer);

            writer.WriteBool(false); // Has aggressive monsters

            var fightPositions = new FightStartingPositions();
            fightPositions.Serialize(writer);
        }

        private void serializeHouses(ICustomDataWriter writer)
        {
            writer.WriteShort(0);
        }

        private void serializeActors(ICustomDataWriter writer)
        {
            var characters = MapContext.Entities.Where(x => x.HasComponent<CharacterComponent>());
            writer.WriteShort((short)characters.Count());

            foreach (var character in characters)
            {
                var actorInfos = new GameRolePlayCharacterInformations();
                actorInfos.Initialize(character);

                writer.WriteShort((short)actorInfos.ProtocolId);
                actorInfos.Serialize(writer);
            }
        }

        private void serializeInteractives(ICustomDataWriter writer)
        {
            writer.WriteShort(0); // Interactives count

            // Astrub zaap example
            //writer.WriteShort(80); // NetworkGameData protocol id
            //writer.WriteInt(516107); // Element reference id (found in dlm)
            //writer.WriteInt(16); // Interactive type (found in d2o)

            // Enabled skills
            //writer.WriteShort(1); // Number of skills
            //writer.WriteShort(219); // NetworkGameData protocol id
            //writer.WriteVarInt(114); // Skill id
            //writer.WriteInt(10000); // instance id

            // Disabled skills
            //writer.WriteShort(0); // Number of skills

            //writer.WriteBool(true); // Is present on map (some interactives can be on the side maps, we can see them since the 16/9 update)
        }

        private void serializeStatedElements(ICustomDataWriter writer)
        {
            writer.WriteShort(0);
        }

        private void serializeObstacles(ICustomDataWriter writer)
        {
            writer.WriteShort(0);
        }

        private void serializeFights(ICustomDataWriter writer)
        {
            writer.WriteShort(0);
        }

        public override string GetSummary()
        {
            return MapContext.Entities.Count(x => x.HasComponent<CharacterComponent>()) + " characters present";
        }
    }
}
