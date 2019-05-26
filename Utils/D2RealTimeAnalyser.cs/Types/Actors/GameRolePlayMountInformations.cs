using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
    {
        public GameRolePlayMountInformations() : base()
        {
            ProtocolId = 180;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadUTF();
            reader.ReadByte();
        }
    }
}
