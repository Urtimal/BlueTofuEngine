using BlueTofuEngine.World.Context;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Game.GameContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public class ContextComponent : IComponent
    {
        public string Name => "context";

        public GameContextType Type { get; set; }
        public IContext Context { get; set; }
    }
}
