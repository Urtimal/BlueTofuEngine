using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.DLM
{
    public class GraphicalElement : BasicElement
    {
        [JsonProperty("elementId")]
        public uint ElementId { get; set; }
        [JsonProperty("hue")]
        public Color Hue { get; set; }
        [JsonProperty("shadow")]
        public Color Shadow { get; set; }
        [JsonProperty("offset")]
        public Point Offset { get; set; }
        [JsonProperty("pixelOffset")]
        public Point PixelOffset { get; set; }
        [JsonProperty("altitude")]
        public byte Altitude { get; set; }
        [JsonProperty("identifier")]
        public uint Identifier { get; set; }

        public GraphicalElement() : base(ElementType.Graphical)
        {
            Hue = new Color();
            Shadow = new Color();
            Offset = new Point();
            PixelOffset = new Point();
        }

        public override void FromRaw(Stream s, int mapVersion)
        {
            ElementId = s.ReadUInt();
            Hue.Red = (byte)s.ReadByte();
            Hue.Green = (byte)s.ReadByte();
            Hue.Blue = (byte)s.ReadByte();
            Shadow.Red = (byte)s.ReadByte();
            Shadow.Green = (byte)s.ReadByte();
            Shadow.Blue = (byte)s.ReadByte();

            if (mapVersion <= 4)
            {
                Offset.X = (short)s.ReadByte();
                Offset.Y = (short)s.ReadByte();
                PixelOffset.X = (short)(Offset.X * AtouinConstants.CellHalfWidth);
                PixelOffset.Y = (short)(Offset.Y * AtouinConstants.CellHalfHeight);
            }
            else
            {
                PixelOffset.X = s.ReadShort();
                PixelOffset.Y = s.ReadShort();
                Offset.X = (short)(PixelOffset.X / AtouinConstants.CellHalfWidth);
                Offset.Y = (short)(PixelOffset.Y / AtouinConstants.CellHalfHeight);
            }

            Altitude = (byte)s.ReadByte();
            Identifier = s.ReadUInt();
        }
    }
}
