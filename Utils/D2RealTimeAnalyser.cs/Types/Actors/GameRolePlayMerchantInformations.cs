using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using D2RealTimeAnalyser.Types.Actors.HumanOptions;

namespace D2RealTimeAnalyser.Types
{
    public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
    {
        public GameRolePlayMerchantInformations() : base()
        {
            ProtocolId = 129;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadByte();
            var len = reader.ReadShort();
            for (int i = 0; i < len; i++)
            {
                var type = reader.ReadShort();
                var info = NetworkTypeFactory.Instance.Get<HumanOption>((uint)type);
                info.Deserialize(reader);
            }
        }
    }
}
