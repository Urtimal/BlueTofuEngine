using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public class LookComponent : IComponent
    {
        public string Name => "look";
        public string EntityName { get; set; }
        public EntityLook Look { get; set; }
    }

    public static class LookComponentExtensions
    {
        public static LookComponent Look(this IEntity entity)
        {
            return entity.GetComponent<LookComponent>();
        }
    }
}
