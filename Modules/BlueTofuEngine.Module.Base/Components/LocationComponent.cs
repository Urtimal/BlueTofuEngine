using BlueTofuEngine.Module.Base;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Base
{
    public class LocationComponent : IComponent
    {
        public string ComponentName => "map";
        
        public long MapId { get; set; }
        public ushort CellId { get; set; }
        public ushort NextCellId { get; set; }
        public Direction Direction { get; set; }
        public Direction NextDirection { get; set; }
    }
}
