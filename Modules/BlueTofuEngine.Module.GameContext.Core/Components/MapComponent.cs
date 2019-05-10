using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class MapComponent : IComponent
    {
        public string Name => "map";

        public long MapId { get; set; }
        public ushort CellId { get; set; }
        public Direction Direction { get; set; }
    }
}
