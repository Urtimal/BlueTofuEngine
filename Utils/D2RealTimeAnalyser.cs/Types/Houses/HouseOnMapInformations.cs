using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace D2RealTimeAnalyser.Types
{
    public class HouseOnMapInformations : HouseInformations
    {
        public List<int> DoorsOnMap { get; set; }
        public List<object> Instances { get; set; }

        public HouseOnMapInformations() : base()
        {
            ProtocolId = 510;

            DoorsOnMap = new List<int>();
            Instances = new List<object>();
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            var doorsOnMapLen = reader.ReadUShort();
            for (int i = 0; i < doorsOnMapLen; i++)
                DoorsOnMap.Add(reader.ReadInt());
            var instanceLen = reader.ReadUShort();
            for (int i = 0; i < instanceLen; i++)
            {
                var info = new HouseInstanceInformations();
                info.Deserialize(reader);
                Instances.Add(info);
            }
        }
    }
}
