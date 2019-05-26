using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class GroupMonsterStaticInformations : NetworkType
    {
        public GroupMonsterStaticInformations()
        {
            ProtocolId = 140;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            reader.ReadInt();
            reader.ReadByte();
            reader.ReadShort();

            var len = reader.ReadShort();
            for (int i = 0; i < len; i++)
            {
                reader.ReadInt();
                reader.ReadByte();
                reader.ReadShort();
                new EntityLook().Deserialize(reader);
            }
        }
    }
}
