using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;

namespace BlueTofuEngine.World.Context
{
    public class BaseContext : IContext
    {
        public uint Id { get; private set; }
        public IEnumerable<IEntity> Entities => _entities;

        protected readonly List<IEntity> _entities;
        protected readonly List<IContextComponent> _components;

        public BaseContext(uint id)
        {
            Id = id;
            _entities = new List<IEntity>();
            _components = new List<IContextComponent>();
        }

        public void Send(INetworkMessage message)
        {
            foreach (var entity in Entities)
                entity.Send(message);
        }

        public void Tick(float deltaTime)
        {
        }

        #region Entities

        public void AddEntity(IEntity entity)
        {
            if (!_entities.Any(x => x.Id == entity.Id))
                _entities.Add(entity);
        }

        public void RemoveEntity(uint id)
        {
            _entities.RemoveAll(x => x.Id == id);
        }

        #endregion

        #region Components

        Guid IContext.AddComponent<TComponent>()
        {
            var instance = Activator.CreateInstance<TComponent>();
            instance.InstanceId = Guid.NewGuid();
            _components.Add(instance);
            return instance.InstanceId;
        }

        Guid IContext.AddComponent<TComponent>(TComponent instance)
        {
            instance.InstanceId = Guid.NewGuid();
            _components.Add(instance);
            return instance.InstanceId;
        }

        public Guid AddComponent(Type type)
        {
            var instance = (IContextComponent)Activator.CreateInstance(type);
            instance.InstanceId = Guid.NewGuid();
            _components.Add(instance);
            return instance.InstanceId;
        }

        public TComponent GetComponent<TComponent>() where TComponent : IContextComponent
        {
            return (TComponent)_components.FirstOrDefault(x => x is TComponent);
        }

        public TComponent GetComponent<TComponent>(Guid instanceId) where TComponent : IContextComponent
        {
            return (TComponent)_components.FirstOrDefault(x => x.InstanceId == instanceId && x is TComponent);
        }

        public IEnumerable<TComponent> GetComponents<TComponent>() where TComponent : IContextComponent
        {
            return _components.Where(x => x is TComponent).Cast<TComponent>();
        }

        public bool HasComponent<TComponent>() where TComponent : IContextComponent
        {
            return _components.Any(x => x is TComponent);
        }

        public void RemoveComponent(Guid id)
        {
            _components.RemoveAll(x => x.InstanceId == id);
        }

        public void RemoveComponents<TComponent>() where TComponent : IContextComponent
        {
            _components.RemoveAll(x => x is TComponent);
        }

        #endregion
    }
}
