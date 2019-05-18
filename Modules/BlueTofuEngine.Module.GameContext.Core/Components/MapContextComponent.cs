using BlueTofuEngine.Module.GameContext.Data;
using BlueTofuEngine.World.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class MapContextComponent : IContextComponent
    {
        public string ComponentName => "map";
        public Guid InstanceId { get; set; }

        public long Id { get; set; }
    }
}
