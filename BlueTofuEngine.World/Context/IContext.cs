using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Context
{
    public interface IContext
    {
        uint Id { get; }
        IEnumerable<IEntity> Entities { get; }

        void AddEntity(IEntity entity);
        void RemoveEntity(uint id);
        Guid AddComponent<TComponent>() where TComponent : class, IContextComponent, new();
        Guid AddComponent<TComponent>(TComponent instance) where TComponent : IContextComponent;
        Guid AddComponent(Type type);
        TComponent GetComponent<TComponent>() where TComponent : IContextComponent;
        TComponent GetComponent<TComponent>(Guid instanceId) where TComponent : IContextComponent;
        IEnumerable<TComponent> GetComponents<TComponent>() where TComponent : IContextComponent;
        bool HasComponent<TComponent>() where TComponent : IContextComponent;
        void RemoveComponent(Guid id);
        void RemoveComponents<TComponent>() where TComponent : IContextComponent;
        void Send(INetworkMessage message);
        void Tick(float deltaTime);
    }
}
