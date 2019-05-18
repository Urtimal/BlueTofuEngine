using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.Stats;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public static class EntityFactoryExtensions
    {
        public static IEntity CreateCharacter(this EntityFactory factory)
        {
            var entity = EntityBuilder.Create()
                                      .AddComponent<CharacterComponent>()
                                      .AddComponent<StatComponent>()
                                      .AddComponent<LookComponent>()
                                      .Build(factory.GetNextId());

            EntityManager.Instance.Add(entity);
            return entity;
        }
    }
}
