using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.World.Entities
{
    public class EntityBuilder
    {
        private readonly List<Type> _componentsToAdd;

        public static EntityBuilder Create()
        {
            return new EntityBuilder();
        }

        public EntityBuilder()
        {
            _componentsToAdd = new List<Type>();
        }

        public EntityBuilder AddComponent<T>()
        {
            var componentType = typeof(T);
            return AddComponent(componentType);
        }

        public EntityBuilder AddComponent(Type type)
        {
            if (!_componentsToAdd.Contains(type))
                _componentsToAdd.Add(type);

            return this;
        }

        public IEntity Build(uint id)
        {
            var entity = new BaseEntity(id);
            foreach (var component in _componentsToAdd)
                entity.AddComponent(component);

            return entity;
        }
    }
}
