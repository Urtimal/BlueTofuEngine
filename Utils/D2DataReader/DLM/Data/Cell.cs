using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.DLM
{
    public class Cell
    {
        [JsonProperty("id")]
        public short Id { get; set; }
        [JsonProperty("elements")]
        public List<BasicElement> Elements { get; set; }

        public Cell()
        {
            Elements = new List<BasicElement>();
        }

        public static Cell FromRaw(Stream s, int mapVersion)
        {
            var cell = new Cell();

            cell.Id = s.ReadShort();
            var elementsCount = s.ReadShort();
            for (int i = 0; i < elementsCount; i++)
            {
                var element = BasicElement.FromType((ElementType)s.ReadByte());
                element.FromRaw(s, mapVersion);
                cell.Elements.Add(element);
            }

            return cell;
        }
    }
}
