using BlueTofuEngine.Core.GameData;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BlueTofuEngine.Module.GameContext.Data
{
    [GameData("MapPositions")]
    public class MapPosition
    {
        [JsonProperty("id")]
        public double Id { get; set; }
        [JsonProperty("posX")]
        public int PosX { get; set; }
        [JsonProperty("posY")]
        public int PosY { get; set; }
        [JsonProperty("outdoor")]
        public bool Outdoor { get; set; }
        [JsonProperty("capabilities")]
        public int Capabilities { get; set; }
        [JsonProperty("worldMap")]
        public int WorldMap { get; set; }
        [JsonProperty("subAreaId")]
        public int SubAreaId { get; set; }
    }
}
