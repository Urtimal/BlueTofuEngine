using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2DataLib.DLM
{
    public class Layer
    {
        public const int Ground = 0;
        public const int AdditionalGround = 1;
        public const int Decor = 2;
        public const int AdditionalDecor = 3;

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("cells")]
        public List<Cell> Cells { get; set; }

        public Layer()
        {
            Cells = new List<Cell>();
        }

        public static Layer FromRaw(Stream s, int mapVersion)
        {
            var layer = new Layer();

            if (mapVersion >= 9)
                layer.Id = s.ReadByte();
            else
                layer.Id = s.ReadInt();

            var cellsCount = s.ReadShort();
            if (cellsCount > 0)
            {
                for (int i = 0; i < cellsCount; i++)
                    layer.Cells.Add(Cell.FromRaw(s, mapVersion));
                var maxMapCellId = AtouinConstants.MapCellsCount - 1;
                var lastCell = layer.Cells.Last();
                if (lastCell.Id < maxMapCellId)
                {
                    var endCell = new Cell
                    {
                        Id = (short)maxMapCellId
                    };
                    layer.Cells.Add(endCell);
                }
            }

            return layer;
        }
    }
}
