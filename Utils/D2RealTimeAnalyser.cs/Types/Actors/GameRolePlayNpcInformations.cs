using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class GameRolePlayNpcInformations : GameRolePlayActorInformations
    {
        public GameRolePlayNpcInformations() : base()
        {
            ProtocolId = 156;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadVarShort();
            reader.ReadBool();
            reader.ReadVarShort();
        }
    }
}
