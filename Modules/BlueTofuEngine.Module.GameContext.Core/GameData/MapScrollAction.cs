using BlueTofuEngine.Core.GameData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Data
{
    [GameData("MapScrollActions")]
    public class MapScrollAction
    {
        [JsonProperty("id")]
        public double Id { get; set; }
        [JsonProperty("rightExists")]
        public bool RightMapExists { get; set; }
        [JsonProperty("rightMapId")]
        public double RightMapId { get; set; }
        [JsonProperty("leftExists")]
        public bool LeftMapExists { get; set; }
        [JsonProperty("leftMapId")]
        public double LeftMapId { get; set; }
        [JsonProperty("topExists")]
        public bool TopMapExists { get; set; }
        [JsonProperty("topMapId")]
        public double TopMapId { get; set; }
        [JsonProperty("bottomExists")]
        public bool BottomMapExists { get; set; }
        [JsonProperty("bottomMapId")]
        public double BottomMapId { get; set; }
    }
}
