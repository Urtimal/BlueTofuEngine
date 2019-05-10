using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World
{
    public abstract class NetworkType : ISerializableData
    {
        public uint ProtocolId { get; protected set; }

        public abstract void Serialize(ICustomDataWriter writer);
        public void Deserialize(ICustomDataReader reader) { }
        public virtual void Initialize(IEntity entity) { }
    }
}
