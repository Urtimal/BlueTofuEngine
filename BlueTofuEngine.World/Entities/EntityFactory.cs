using BlueTofuEngine.Core;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World
{
    public class EntityFactory : Singleton<EntityFactory>
    {
        public IEntity CreateBlank()
        {
            var entity = EntityBuilder.Create().Build(EntityManager.Instance.GetNextId());
            EntityManager.Instance.Add(entity);
            return entity;
        }

        public uint GetNextId()
        {
            return EntityManager.Instance.GetNextId();
        }
    }
}
