using BlueTofuEngine.Core.GameData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    [GameData("Servers")]
    public class Server
    {
        [JsonProperty("id")]
        public uint Id { get; set; }
        [JsonProperty("nameId")]
        public string Name { get; set; }
        [JsonProperty("openingDate")]
        public double OpeningDate { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("populationId")]
        public int Population { get; set; }
        [JsonProperty("gameTypeId")]
        public int GameType { get; set; }
        [JsonProperty("communityId")]
        public int Community { get; set; }
        [JsonProperty("monoAccount")]
        public bool MonoAccount { get; set; }
    }
}
