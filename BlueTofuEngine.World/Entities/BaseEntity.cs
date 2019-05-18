using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Context;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;

namespace BlueTofuEngine.World.Entities
{
    public class BaseEntity : IEntity
    {
        public uint Id { get; private set; }
        public Guid RefId { get; set; }
        public IContext Context { get; set; }

        protected readonly List<IComponent> _components;

        public BaseEntity(uint id)
        {
            Id = id;
            _components = new List<IComponent>();
        }

        public void AddComponent<TComponent>() where TComponent : IComponent, new()
        {
            if (!_components.Any(x => x is TComponent))
                _components.Add(Activator.CreateInstance<TComponent>());
        }

        public void AddComponent(Type type)
        {
            if (typeof(IComponent).IsAssignableFrom(type))
                _components.Add((IComponent)Activator.CreateInstance(type));
        }

        public TComponent GetComponent<TComponent>() where TComponent : IComponent
        {
            return (TComponent)_components.FirstOrDefault(x => x is TComponent);
        }

        public bool HasComponent<TComponent>() where TComponent : IComponent
        {
            return _components.Any(x => x is TComponent);
        }

        public void RemoveComponent<TComponent>() where TComponent : IComponent
        {
            _components.RemoveAll(x => x is TComponent);
        }

        public void Notify(SystemEventArgs arg)
        {
            SystemManager.Instance.NotifySystems(this, arg);
        }

        public void Notify<TSystem>(SystemEventArgs arg) where TSystem : ISystem
        {
            SystemManager.Instance.NotifySystem<TSystem>(this, arg);
        }
    }
}
