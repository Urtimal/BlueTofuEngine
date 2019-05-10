using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2DataLib.DLM
{
    public class Point
    {
        [JsonProperty("x")]
        public short X { get; set; }
        [JsonProperty("y")]
        public short Y { get; set; }
    }
}
