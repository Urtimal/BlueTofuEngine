using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
    {
        public GameRolePlayCharacterInformations() : base()
        {
            ProtocolId = 36;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadByte();
            reader.ReadByte();
            reader.ReadByte();
            reader.ReadDouble();
        }
    }
}
