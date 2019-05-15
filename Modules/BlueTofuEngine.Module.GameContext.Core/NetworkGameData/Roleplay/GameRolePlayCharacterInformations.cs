using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace BlueTofuEngine.Module.GameContext
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
