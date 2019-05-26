using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class GameRolePlayPortalInformations : GameRolePlayActorInformations
    {
        public GameRolePlayPortalInformations() : base()
        {
            ProtocolId = 467;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadUShort();
            reader.ReadInt();
            reader.ReadShort();
        }
    }
}
