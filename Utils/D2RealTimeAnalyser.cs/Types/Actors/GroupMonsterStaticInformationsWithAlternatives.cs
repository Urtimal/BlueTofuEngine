using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
    {
        public GroupMonsterStaticInformationsWithAlternatives() : base()
        {
            ProtocolId = 369;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            var len = reader.ReadShort();
            for (int i = 0; i < len; i++)
            {
                reader.ReadInt();
                var len2 = reader.ReadShort();
                for (int j = 0; j < len2; j++)
                {
                    reader.ReadInt();
                    reader.ReadByte();
                    reader.ReadShort();
                }
            }
        }
    }
}
