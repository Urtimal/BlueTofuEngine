using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
    {
        public GameRolePlayGroupMonsterInformations() : base()
        {
            ProtocolId = 160;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            reader.ReadByte();
            var id = reader.ReadShort();
            var infos = NetworkTypeFactory.Instance.Get<GroupMonsterStaticInformations>((uint)id);
            infos.Deserialize(reader);
            reader.ReadByte();
            reader.ReadByte();
        }
    }
}
