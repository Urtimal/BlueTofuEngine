using BlueTofuEngine.World.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.World.Context
{
    public class ContextBuilder
    {
        private readonly List<Type> _componentsToAdd;

        public static ContextBuilder Create()
        {
            return new ContextBuilder();
        }

        public ContextBuilder()
        {
            _componentsToAdd = new List<Type>();
        }

        public ContextBuilder AddComponent<T>() where T : IContextComponent
        {
            var componentType = typeof(T);
            return AddComponent(componentType);
        }

        public ContextBuilder AddComponent(Type type)
        {
            if (!_componentsToAdd.Contains(type))
                _componentsToAdd.Add(type);

            return this;
        }

        public IContext Build(uint id)
        {
            var entity = new BaseContext(id);
            foreach (var component in _componentsToAdd)
                entity.AddComponent(component);

            return entity;
        }
    }
}
