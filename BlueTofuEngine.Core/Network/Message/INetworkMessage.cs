using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Network
{
    public interface INetworkMessage
    {
        string GetName();
        string GetSummary();
        void Serialize(ICustomDataWriter writer);
        void Deserialize(ICustomDataReader reader);
    }
}
