using BlueTofuEngine.Core;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Systems
{
    public class SystemManager : Singleton<SystemManager>
    {
        private readonly Dictionary<Type, ISystem> _systems;

        public SystemManager()
        {
            _systems = new Dictionary<Type, ISystem>();
        }

        public void Add<TSystem>() where TSystem : ISystem, new()
        {
            if (!_systems.ContainsKey(typeof(TSystem)))
                _systems.Add(typeof(TSystem), Activator.CreateInstance<TSystem>());
        }

        public void Add(Type systemType)
        {
            if (!typeof(ISystem).IsAssignableFrom(systemType))
                return;
            if (!_systems.ContainsKey(systemType))
                _systems.Add(systemType, (ISystem)Activator.CreateInstance(systemType));
        }

        public void Add<TSystem>(TSystem system) where TSystem : ISystem
        {
            if (!_systems.ContainsKey(typeof(TSystem)))
                _systems.Add(typeof(TSystem), system);
        }

        public void NotifySystem<TSystem>(IEntity sender, SystemEventArgs args) where TSystem : ISystem
        {
            if (_systems.TryGetValue(typeof(TSystem), out ISystem system))
                system.OnNotification(sender, args);
        }

        public void NotifySystems(IEntity sender, SystemEventArgs args)
        {
            foreach (var system in _systems)
                system.Value.OnNotification(sender, args);
        }

        public void DoTick(float deltaTime)
        {
            foreach (var system in _systems)
                system.Value.OnTick(deltaTime);
        }
    }
}
