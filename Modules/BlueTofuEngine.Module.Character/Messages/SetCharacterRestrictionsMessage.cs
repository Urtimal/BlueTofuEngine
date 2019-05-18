using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class SetCharacterRestrictionsMessage : NetworkMessage
    {
        public const ushort Id = 170;

        public IEntity Entity { get; set; }

        public SetCharacterRestrictionsMessage(IEntity entity) : base(Id)
        {
            Entity = entity;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteDouble(Entity.Character().CharacterId);
            var restrictions = new ActorRestrictionsInformations();
            restrictions.Initialize(Entity);
            restrictions.Serialize(writer);
        }
    }
}
