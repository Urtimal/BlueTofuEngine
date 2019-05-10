using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.GameData
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GameDataAttribute : Attribute
    {
        public string Name { get; set; }

        public GameDataAttribute(string name)
        {
            Name = name;
        }
    }
}
