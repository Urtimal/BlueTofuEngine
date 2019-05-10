using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MapViewer.Data
{
    public class Map
    {
        [JsonProperty("backgroundColor")]
        public Color BackgroundColor { get; set; }
        [JsonProperty("cells")]
        public List<CellData> Cells { get; set; }
        [JsonProperty("layers")]
        public List<Layer> Layers { get; set; }
    }

    public class Layer
    {
        public int id { get; set; }
        public List<Cell> cells { get; set; }
    }

    public class Cell
    {
        public int id { get; set; }
        public List<CellElement> elements { get; set; }
    }

    public class CellElement
    {
        public int type { get; set; }
        public int elementId { get; set; }
        public JsonPoint offset { get; set; }
        public JsonPoint pixelOffset { get; set; }
    }

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

    public class JsonPoint
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
