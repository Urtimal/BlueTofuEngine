using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types
{
    public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
    {
        public string Name { get; set; }

        public GameRolePlayNamedActorInformations() : base()
        {
            ProtocolId = 154;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            Name = reader.ReadUTF();
        }
    }
}
