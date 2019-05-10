using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2DataLib.DLM
{
    public class Color
    {
        [JsonProperty("alpha")]
        public byte Alpha { get; set; }
        [JsonProperty("red")]
        public byte Red { get; set; }
        [JsonProperty("green")]
        public byte Green { get; set; }
        [JsonProperty("blue")]
        public byte Blue { get; set; }
    }
}
