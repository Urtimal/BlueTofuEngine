using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Stats
{
    public class StatComponent : IComponent
    {
        public string Name => "stats";

        public StatCollection Stats { get; set; }
    }

    public static class StatComponentExtensions
    {
        public static StatComponent Stats(this IEntity entity)
        {
            return entity.GetComponent<StatComponent>();
        }
    }
}
