
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types.Actors.HumanOptions
{
    public class HumanOptionObjectUse : HumanOption
    {
        public HumanOptionObjectUse() : base()
        {
            ProtocolId = 449;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            
            reader.ReadByte();
            reader.ReadDouble();
            reader.ReadVarShort();
        }
    }
}
