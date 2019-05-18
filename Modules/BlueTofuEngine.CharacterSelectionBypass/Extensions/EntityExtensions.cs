using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.Character;
using BlueTofuEngine.Module.Stats;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine
{
    public static class EntityExtensions
    {
        public static IEntity CreateCharacter(this EntityFactory factory)
        {
            var entity = EntityBuilder.Create()
                            .AddComponent<LookComponent>()
                            .AddComponent<CharacterComponent>()
                            .AddComponent<StatComponent>()
                            .Build(factory.GetNextId());

            EntityManager.Instance.Add(entity);
            return entity;
        }
    }
}
