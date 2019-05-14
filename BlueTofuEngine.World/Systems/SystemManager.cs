using BlueTofuEngine.Core;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueTofuEngine.World.Systems
{
    public class SystemManager : Singleton<SystemManager>
    {
        private readonly Dictionary<Type, ISystem> _systems;
        private CancellationTokenSource _cancelSource;

        public SystemManager()
        {
            _systems = new Dictionary<Type, ISystem>();
        }

        public void Start()
        {
            _cancelSource = new CancellationTokenSource();
            Task.Run((Action)updateSystems, _cancelSource.Token);
        }

        public void Stop()
        {
            _cancelSource.Cancel();
        }

        public void Add<TSystem>() where TSystem : ISystem, new()
        {
            lock (_systems)
            {
                if (!_systems.ContainsKey(typeof(TSystem)))
                    _systems.Add(typeof(TSystem), Activator.CreateInstance<TSystem>());
            }
        }

        public void Add(Type systemType)
        {
            if (!typeof(ISystem).IsAssignableFrom(systemType))
                return;
            lock (_systems)
            {
                if (!_systems.ContainsKey(systemType))
                    _systems.Add(systemType, (ISystem)Activator.CreateInstance(systemType));
            }
        }

        public void Add<TSystem>(TSystem system) where TSystem : ISystem
        {
            lock (_systems)
            {
                if (!_systems.ContainsKey(typeof(TSystem)))
                    _systems.Add(typeof(TSystem), system);
            }
        }

        public void NotifySystem<TSystem>(IEntity sender, SystemEventArgs args) where TSystem : ISystem
        {
            lock (_systems)
            {
                if (_systems.TryGetValue(typeof(TSystem), out ISystem system))
                    system.OnNotification(sender, args);
            }
        }

        public void NotifySystems(IEntity sender, SystemEventArgs args)
        {
            lock (_systems)
            {
                foreach (var system in _systems)
                    system.Value.OnNotification(sender, args);
            }
        }

        public void DoTick(float deltaTime)
        {
            lock (_systems)
            {
                foreach (var system in _systems)
                    system.Value.OnTick(deltaTime);
            }
        }

        private void updateSystems()
        {
            float frameTime = 1 / 20;
            float deltaTime = 0;
            while (true)
            {
                var start = DateTime.Now;
                DoTick(deltaTime);
                deltaTime = (float)(DateTime.Now - start).TotalSeconds;
                if (deltaTime < frameTime)
                {
                    Thread.Sleep((int)((frameTime - deltaTime) * 1000));
                    deltaTime = frameTime;
                }
            }
        }
    }
}
