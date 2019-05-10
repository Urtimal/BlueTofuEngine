using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public class MapComponent : IComponent
    {
        public string Name => "map";

        public int MapId { get; set; }
        public int CellId { get; set; }
        public int Direction { get; set; }
    }

    public static class MapComponentExtensions
    {
        public static MapComponent Map(this IEntity entity)
        {
            return entity.GetComponent<MapComponent>();
        }
    }
}
