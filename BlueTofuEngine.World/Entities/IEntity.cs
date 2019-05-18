using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Context;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Entities
{
    public interface IEntity
    {
        uint Id { get; }
        Guid RefId { get; set; }
        IContext Context { get; set; }

        void AddComponent<TComponent>() where TComponent : IComponent, new();
        void AddComponent(Type type);
        TComponent GetComponent<TComponent>() where TComponent : IComponent;
        bool HasComponent<TComponent>() where TComponent : IComponent;
        void RemoveComponent<TComponent>() where TComponent : IComponent;
        void Notify(SystemEventArgs arg);
        void Notify<TSystem>(SystemEventArgs arg) where TSystem : ISystem;
    }
}
