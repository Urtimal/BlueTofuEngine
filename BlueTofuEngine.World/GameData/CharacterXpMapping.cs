using BlueTofuEngine.Core.GameData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.GameData
{
    [GameData("CharacterXPMappings")]
    public class CharacterXpMapping
    {
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("experiencePoints")]
        public double ExpD { get; set; }

        public int Exp => (int)ExpD;
    }
}
