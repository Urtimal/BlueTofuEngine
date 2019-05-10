using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.ELE
{
    public class Element
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonIgnore]
        public uint Position { get; set; }
        [JsonIgnore]
        public ElementCollection Collection { get; set; }
        [JsonProperty("data")]
        public GraphicalElementData Data { get; set; }
        [JsonIgnore]
        public bool Loaded { get; set; }

        public Element(ElementCollection collection)
        {
            Collection = collection;
        }

        public void Read(Stream s)
        {
            var skyplen = 0;
            if (Collection.FileVersion >= 9)
                skyplen = s.ReadUShort();
            Id = s.ReadInt();
            Position = (uint)s.Position;
            if (Collection.FileVersion <= 8)
                ReadData();
            else
                s.Seek(skyplen - 4, SeekOrigin.Current);
        }

        public void ReadData()
        {
            if (Loaded)
                return;

            var s = Collection.Stream;
            s.Seek(Position, SeekOrigin.Begin);
            var type = s.ReadByte();
            Data = GraphicalElementData.FromType((GraphicalElementTypes)type);
            if (Data != null)
                Data.FromRaw(s, Collection.FileVersion);
            Loaded = true;
        }
    }
}
