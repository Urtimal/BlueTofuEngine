using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
    {
        public GameRolePlayMutantInformations() : base()
        {
            ProtocolId = 3;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadVarShort();
            reader.ReadByte();
        }
    }
}
