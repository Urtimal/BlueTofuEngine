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
}
