using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterComponent : IComponent
    {
        public string ComponentName => "character";

        public Breeds Breed { get; set; }
        public Gender Gender { get; set; }
    }
}
