using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Extensions;

namespace BlueTofuEngine.World.Context
{
    public class BaseContext : IContext
    {
        public IEnumerable<IEntity> Entities => _entities;

        private readonly List<IEntity> _entities;

        public BaseContext()
        {
            _entities = new List<IEntity>();
        }

        public void AddEntity(IEntity entity)
        {
            if (!_entities.Any(x => x.Id == entity.Id))
                _entities.Add(entity);
        }

        public void RemoveEntity(uint id)
        {
            _entities.RemoveAll(x => x.Id == id);
        }

        public void Send(INetworkMessage message)
        {
            foreach (var entity in Entities)
                entity.Send(message);
        }
    }
}
