using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass.Messages
{
    [NetworkMessage(Id)]
    public class CharacterSelectedSuccessMessage : NetworkMessage
    {
        public const ushort Id = 153;

        public IEntity Entity { get; set; }

        public CharacterSelectedSuccessMessage(IEntity entity) : base(Id)
        {
            Entity = entity;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            var characterInfos = new CharacterBaseInformations();
            characterInfos.Initialize(Entity);
            characterInfos.Serialize(writer);
            writer.WriteBool(false); // Is collecting stats
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override string GetSummary()
        {
            return Entity.Id.ToString();
        }
    }
}
