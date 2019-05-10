using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;

namespace BlueTofuEngine.World.GameType.Game.Context.Roleplay
{
    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public uint AccountId { get; set; }
        public HumanInformations HumanInfos { get; set; }

        public GameRolePlayHumanoidInformations() : base()
        {
            ProtocolId = 159;
        }

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);

            AccountId = entity.Account().AccountId;
            HumanInfos = new HumanInformations();
            HumanInfos.Initialize(entity);
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            writer.WriteShort((short)HumanInfos.ProtocolId);
            HumanInfos.Serialize(writer);
            writer.WriteUInt(AccountId);
        }
    }
}
