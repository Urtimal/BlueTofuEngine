using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2DataLib.DLM
{
    public class MapNeighbours
    {
        [JsonProperty("top")]
        public uint Top { get; set; }
        [JsonProperty("bottom")]
        public uint Bottom { get; set; }
        [JsonProperty("left")]
        public uint Left { get; set; }
        [JsonProperty("right")]
        public uint Right { get; set; }
    }
}
