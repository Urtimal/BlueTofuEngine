using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using D2RealTimeAnalyser.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2RealTimeAnalyser
{
    [NetworkMessage(Id)]
    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const ushort Id = 226;

        public int SubAreaId { get; set; }
        public long MapId { get; set; }
        public List<HouseInformations> Houses { get; set; }
        public List<GameRolePlayActorInformations> Actors { get; set; }

        public MapComplementaryInformationsDataMessage() : base(Id)
        {
            Houses = new List<HouseInformations>();
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            SubAreaId = reader.ReadVarUShort();
            MapId = (long)reader.ReadDouble();
            deserializeHouses(reader);
            deserializeActors(reader);
        }

        private void deserializeHouses(ICustomDataReader reader)
        {
            var count = reader.ReadUShort();
            for (int i = 0; i < count; i++)
            {
                var protocolId = reader.ReadUShort();
                var data = NetworkTypeFactory.Instance.Get<HouseInformations>(protocolId);
                data.Deserialize(reader);
                Houses.Add(data);
            }
        }

        private void deserializeActors(ICustomDataReader reader)
        {
            var count = reader.ReadUShort();
            for (int i = 0; i < count; i++)
            {
                var protocolId = reader.ReadUShort();
                var data = NetworkTypeFactory.Instance.Get<GameRolePlayActorInformations>(protocolId);
                data.Deserialize(reader);
                Actors.Add(data);
            }
        }

        #region Serialize

        protected override void serializeContent(ICustomDataWriter writer)
        {
            //var mapPosition = GameDataManager<MapPosition>.Instance.Get((int)MapContext.Map().Id);

            //writer.WriteVarShort((short)mapPosition.SubAreaId);
            //writer.WriteDouble(mapPosition.Id);

            //serializeHouses(writer);
            //serializeActors(writer);
            //serializeInteractives(writer);
            //serializeStatedElements(writer);
            //serializeObstacles(writer);
            //serializeFights(writer);

            //writer.WriteBool(false); // Has aggressive monsters

            //var fightPositions = new FightStartingPositions();
            //fightPositions.Serialize(writer);
        }

        //private void serializeHouses(ICustomDataWriter writer)
        //{
        //    writer.WriteShort(0);
        //}

        //private void serializeActors(ICustomDataWriter writer)
        //{
        //    var characters = MapContext.Entities.Where(x => x.HasComponent<CharacterComponent>());
        //    writer.WriteShort((short)characters.Count());

        //    foreach (var character in characters)
        //    {
        //        var actorInfos = new GameRolePlayCharacterInformations();
        //        actorInfos.Initialize(character);

        //        writer.WriteShort((short)actorInfos.ProtocolId);
        //        actorInfos.Serialize(writer);
        //    }
        //}

        //private void serializeInteractives(ICustomDataWriter writer)
        //{
        //    writer.WriteShort(0); // Interactives count

        //    // Astrub zaap example
        //    //writer.WriteShort(80); // NetworkGameData protocol id
        //    //writer.WriteInt(516107); // Element reference id (found in dlm)
        //    //writer.WriteInt(16); // Interactive type (found in d2o)

        //    // Enabled skills
        //    //writer.WriteShort(1); // Number of skills
        //    //writer.WriteShort(219); // NetworkGameData protocol id
        //    //writer.WriteVarInt(114); // Skill id
        //    //writer.WriteInt(10000); // instance id

        //    // Disabled skills
        //    //writer.WriteShort(0); // Number of skills

        //    //writer.WriteBool(true); // Is present on map (some interactives can be on the side maps, we can see them since the 16/9 update)
        //}

        //private void serializeStatedElements(ICustomDataWriter writer)
        //{
        //    writer.WriteShort(0);
        //}

        //private void serializeObstacles(ICustomDataWriter writer)
        //{
        //    writer.WriteShort(0);
        //}

        //private void serializeFights(ICustomDataWriter writer)
        //{
        //    writer.WriteShort(0);
        //}

        #endregion
    }
}
