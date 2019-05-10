using BlueTofuEngine.Core;
using BlueTofuEngine.World.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.World.Entities
{
    public class EntityManager : Singleton<EntityManager>
    {
        private readonly Dictionary<uint, IEntity> _entities;
        private uint _idCounter = 1;

        public IEnumerable<IEntity> Entities => _entities.Values;
        public IEnumerable<IEntity> Players => _entities.Values.Where(x => x.HasComponent<NetworkComponent>());

        public EntityManager()
        {
            _entities = new Dictionary<uint, IEntity>();
        }

        public uint GetNextId()
        {
            return _idCounter++;
        }

        public void Add(IEntity entity)
        {
            _entities.Add(entity.Id, entity);
        }

        public IEntity Get(uint id)
        {
            if (_entities.TryGetValue(id, out IEntity entity))
                return entity;
            return null;
        }

        public IEntity GetByRef(Guid id)
        {
            return _entities.Values.FirstOrDefault(x => x.RefId == id);
        }

        public void Delete(uint id)
        {
            _entities.Remove(id);
        }
    }
}
