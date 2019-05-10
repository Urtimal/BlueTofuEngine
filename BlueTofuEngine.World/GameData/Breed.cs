using BlueTofuEngine.Core.GameData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.GameData
{
    [GameData("Breeds")]
    public class Breed
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("maleLook")]
        public string MaleLook { get; set; }
        [JsonProperty("femaleLook")]
        public string FemaleLook { get; set; }
        [JsonProperty("maleColors")]
        public int[] MaleColors { get; set; }
        [JsonProperty("femaleColors")]
        public int[] FemaleColors { get; set; }
        [JsonProperty("spawnMap")]
        public int SpawnMap { get; set; }
    }
}
