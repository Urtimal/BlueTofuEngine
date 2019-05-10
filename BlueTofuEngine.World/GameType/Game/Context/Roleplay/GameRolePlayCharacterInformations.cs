using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.GameType.Character.Alignment;

namespace BlueTofuEngine.World.GameType.Game.Context.Roleplay
{
    public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
    {
        public GameRolePlayCharacterInformations() : base()
        {
            ProtocolId = 36;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);

            var alignment = new ActorAlignmentInformations();
            alignment.Serialize(writer);
        }
    }
}
