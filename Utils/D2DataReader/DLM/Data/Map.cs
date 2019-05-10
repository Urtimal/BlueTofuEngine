using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2DataLib.DLM
{
    public class Map
    {
        [JsonProperty("id")]
        public uint Id { get; set; }
        [JsonProperty("relativeId")]
        public uint RelativeId { get; set; }
        [JsonProperty("version")]
        public int Version { get; set; }
        [JsonProperty("encrypted")]
        public bool Encrypted { get; set; }
        [JsonProperty("encryptionVersion")]
        public int EncryptionVersion { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("subAreaId")]
        public int SubAreaId { get; set; }
        [JsonProperty("neighbours")]
        public MapNeighbours Neighbours { get; set; }
        [JsonProperty("shadowBonusOnEntities")]
        public uint ShadowBonusOnEntities { get; set; }

        [JsonProperty("backgroundColor")]
        public Color BackgroundColor { get; set; }
        [JsonProperty("gridColor")]
        public Color GridColor { get; set; }

        [JsonProperty("zoomScale")]
        public float ZoomScale { get; set; }
        [JsonProperty("zoomOffsetX")]
        public short ZoomOffsetX { get; set; }
        [JsonProperty("zoomOffsetY")]
        public short ZoomOffsetY { get; set; }

        [JsonProperty("tacticalModeTemplateId")]
        public int TacticalModeTemplateId { get; set; }

        [JsonProperty("useLowPassFilter")]
        public bool UseLowPassFilter { get; set; }
        [JsonProperty("useReverb")]
        public bool UseReverb { get; set; }
        [JsonProperty("presetId")]
        public int PresetId { get; set; }

        [JsonProperty("backgroundFixtures")]
        public List<Fixture> BackgroundFixtures { get; set; }
        [JsonProperty("foregroundFixtures")]
        public List<Fixture> ForegroundFixtures { get; set; }
        [JsonProperty("layers")]
        public List<Layer> Layers { get; set; }
        [JsonProperty("cells")]
        public List<CellData> Cells { get; set; }

        [JsonProperty("topArrowCells")]
        public List<int> TopArrowCells { get; set; }
        [JsonProperty("bottomArrowCells")]
        public List<int> BottomArrowCells { get; set; }
        [JsonProperty("rightArrowCells")]
        public List<int> RightArrowCells { get; set; }
        [JsonProperty("leftArrowCells")]
        public List<int> LeftArrowCells { get; set; }

        [JsonProperty("groundCRC")]
        public int GroundCRC { get; set; }

        public Map()
        {
            Neighbours = new MapNeighbours();
            BackgroundColor = new Color();
            GridColor = new Color();
            BackgroundFixtures = new List<Fixture>();
            ForegroundFixtures = new List<Fixture>();
            Layers = new List<Layer>();
            Cells = new List<CellData>();
            TopArrowCells = new List<int>();
            BottomArrowCells = new List<int>();
            RightArrowCells = new List<int>();
            LeftArrowCells = new List<int>();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
