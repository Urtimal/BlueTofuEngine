using BlueTofuEngine.Module.GameContext;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine
{
    public static class EntityExtensions
    {
        public static MapComponent Map(this IEntity entity)
        {
            return entity.GetComponent<MapComponent>();
        }
    }
}
