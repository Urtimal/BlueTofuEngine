using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Serialization
{
    public interface ISerializableData
    {
        void Serialize(ICustomDataWriter writer);
        void Deserialize(ICustomDataReader reader);
    }
}
