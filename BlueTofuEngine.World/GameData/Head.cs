using BlueTofuEngine.Core.GameData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.GameData
{
    [GameData("Heads")]
    public class Head
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("skins")]
        public string Skin { get; set; }
        [JsonProperty("breed")]
        public int Breed { get; set; }
        [JsonProperty("gender")]
        public byte Gender { get; set; }
    }
}
