using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
    {
        public GameRolePlayNpcWithQuestInformations() : base()
        {
            ProtocolId = 383;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            var len = reader.ReadShort();
            for (int i = 0; i < len; i++)
                reader.ReadVarShort();
            len = reader.ReadShort();
            for (int i = 0; i < len; i++)
                reader.ReadVarShort();
        }
    }
}
