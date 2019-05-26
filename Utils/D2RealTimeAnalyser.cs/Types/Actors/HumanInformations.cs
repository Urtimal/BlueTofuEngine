using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using D2RealTimeAnalyser.Types.Actors.HumanOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types.Actors
{
    public class HumanInformations : NetworkType
    {
        public HumanInformations()
        {
            ProtocolId = 157;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            reader.ReadByte();
            reader.ReadByte();
            reader.ReadByte();
            reader.ReadBool();
            var len = reader.ReadUShort();
            for (int i = 0; i < len; i++)
            {
                var id = reader.ReadUShort();
                var infos = NetworkTypeFactory.Instance.Get<HumanOption>(id);
                infos.Deserialize(reader);
            }
        }
    }
}
