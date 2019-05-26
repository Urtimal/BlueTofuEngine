using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2RealTimeAnalyser.Types
{
    public class EntityLook : NetworkType
    {
        public EntityLook()
        {
            ProtocolId = 55;
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            reader.ReadVarUShort();
            var len = reader.ReadUShort();
            for (int i = 0; i < len; i++)
                reader.ReadVarUShort();
            len = reader.ReadUShort();
            for (int i = 0; i < len; i++)
                reader.ReadInt();
            len = reader.ReadUShort();
            for (int i = 0; i < len; i++)
                reader.ReadVarShort();
            len = reader.ReadUShort();
            for (int i = 0; i < len; i++)
            {
                var subentity = new SubEntity();
                subentity.Deserialize(reader);
            }
        }
    }
}
