using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using D2RealTimeAnalyser.Types.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types
{
    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public GameRolePlayHumanoidInformations() : base()
        {
            ProtocolId = 159;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            var id = reader.ReadUShort();
            var infos = NetworkTypeFactory.Instance.Get<HumanInformations>(id);
            infos.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
