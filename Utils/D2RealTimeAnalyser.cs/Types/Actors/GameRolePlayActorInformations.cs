using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace D2RealTimeAnalyser.Types
{
    public class GameRolePlayActorInformations : GameContextActorInformations
    {
        public GameRolePlayActorInformations() : base()
        {
            ProtocolId = 141;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
