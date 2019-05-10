using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Context
{
    public interface IContext
    {
        IEnumerable<IEntity> Entities { get; }
        void AddEntity(IEntity entity);
        void RemoveEntity(uint id);
        void Send(INetworkMessage message);
    }
}
