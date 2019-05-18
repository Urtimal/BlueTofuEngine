using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterListComponent : IComponent
    {
        public string ComponentName => "characterList";

        public List<IEntity> Characters { get; set; }

        public CharacterListComponent()
        {
            Characters = new List<IEntity>();
        }
    }
}
