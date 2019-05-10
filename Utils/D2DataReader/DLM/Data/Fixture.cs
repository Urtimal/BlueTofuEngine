using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.DLM
{
    public class Fixture
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("offset")]
        public Point Offset { get; set; }
        [JsonProperty("rotation")]
        public short Rotation { get; set; }
        [JsonProperty("scale")]
        public Point Scale { get; set; }
        [JsonProperty("color")]
        public Color Color { get; set; }

        public Fixture()
        {
            Offset = new Point();
            Scale = new Point();
            Color = new Color();
        }

        public static Fixture FromRaw(Stream s)
        {
            var fixture = new Fixture();

            fixture.Id = s.ReadInt();
            fixture.Offset.X = s.ReadShort();
            fixture.Offset.Y = s.ReadShort();
            fixture.Rotation = s.ReadShort();
            fixture.Scale.X = s.ReadShort();
            fixture.Scale.Y = s.ReadShort();
            fixture.Color.Red = (byte)s.ReadByte();
            fixture.Color.Green = (byte)s.ReadByte();
            fixture.Color.Blue = (byte)s.ReadByte();
            fixture.Color.Alpha = (byte)s.ReadByte();

            return fixture;
        }
    }
}
