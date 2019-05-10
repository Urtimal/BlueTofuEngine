using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public class FighterComponent : IComponent
    {
        public string Name => "fighter";

        public int Level { get; set; }
    }

    public static class FighterComponentExtensions
    {
        public static FighterComponent Fighter(this IEntity entity)
        {
            return entity.GetComponent<FighterComponent>();
        }
    }
}
