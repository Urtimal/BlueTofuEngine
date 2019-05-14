using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Base
{
    public class CharacterComponent : IComponent
    {
        public string ComponentName => "playable";

        public int BreedId { get; set; }
        public bool Gender { get; set; }
    }
}
