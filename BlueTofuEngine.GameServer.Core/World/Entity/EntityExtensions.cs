using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Module.Stats;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World
{
    public static class EntityExtensions
    {
        public static IEntity CreateCharacter(this EntityFactory factory)
        {
            var entity = EntityBuilder.Create()
                            .AddComponent<LookComponent>()
                            .AddComponent<PlayableComponent>()
                            .AddComponent<FighterComponent>()
                            .AddComponent<StatComponent>()
                            .Build(factory.GetNextId());

            EntityManager.Instance.Add(entity);
            return entity;
        }
    }
}
