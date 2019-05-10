using D2DataLib.DLM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.ELE
{
    public class NormalGraphicalElementData : GraphicalElementData
    {
        [JsonProperty("gfxId")]
        public int GfxId { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("horizontalSymmetry")]
        public bool HorizontalSymmetry { get; set; }
        [JsonProperty("origin")]
        public Point Origin { get; set; }
        [JsonProperty("size")]
        public Point Size { get; set; }

        public NormalGraphicalElementData(GraphicalElementTypes type = GraphicalElementTypes.Normal) : base(type)
        {
            Origin = new Point();
            Size = new Point();
        }

        public override void FromRaw(Stream s, int fileVersion)
        {
            GfxId = s.ReadInt();
            Height = s.ReadByte();
            HorizontalSymmetry = s.ReadBoolean();
            Origin.X = s.ReadShort();
            Origin.Y = s.ReadShort();
            Size.X = s.ReadShort();
            Size.Y = s.ReadShort();
        }
    }
}
