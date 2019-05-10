using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.DLM
{
    public class CellData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("floor")]
        public int Floor { get; set; }
        [JsonProperty("mov")]
        public bool Mov { get; set; }
        [JsonProperty("nonWalkableDuringFight")]
        public bool NonWalkableDuringFight { get; set; }
        [JsonProperty("nonWalkableDuringRp")]
        public bool NonWalkableDuringRp { get; set; }
        [JsonProperty("los")]
        public bool Los { get; set; }
        [JsonProperty("blue")]
        public bool Blue { get; set; }
        [JsonProperty("red")]
        public bool Red { get; set; }
        [JsonProperty("visible")]
        public bool Visible { get; set; }
        [JsonProperty("farmCell")]
        public bool FarmCell { get; set; }
        [JsonProperty("havenbagCell")]
        public bool HavenbagCell { get; set; }
        [JsonProperty("topArrow")]
        public bool TopArrow { get; set; }
        [JsonProperty("bottomArrow")]
        public bool BottomArrow { get; set; }
        [JsonProperty("rightArrow")]
        public bool RightArrow { get; set; }
        [JsonProperty("leftArrow")]
        public bool LeftArrow { get; set; }
        [JsonProperty("speed")]
        public int Speed { get; set; }
        [JsonProperty("mapChangeData")]
        public int MapChangeData { get; set; }
        [JsonProperty("moveZone")]
        public int MoveZone { get; set; }
        [JsonProperty("linkedZone")]
        public int LinkedZone { get; set; }
        [JsonProperty("arrow")]
        public int Arrow { get; set; }

        [JsonIgnore()]
        public bool HasLinkedZoneRP => Mov && !FarmCell;
        [JsonIgnore()]
        public bool HasLinkedZoneFight => Mov && !NonWalkableDuringFight && !FarmCell && !HavenbagCell;

        public CellData(int id)
        {
            Id = id;
        }

        public static CellData FromRaw(Stream s, Map map, int cellId)
        {
            var cell = new CellData(cellId);

            cell.Floor = s.ReadByte() * 10;
            if (cell.Floor == -1280)
                return cell;

            if (map.Version >= 9)
            {
                var tmpbytesv9 = s.ReadShort();
                cell.Mov = (tmpbytesv9 & 1) == 0;
                cell.NonWalkableDuringFight = (tmpbytesv9 & 2) != 0;
                cell.NonWalkableDuringRp = (tmpbytesv9 & 4) != 0;
                cell.Los = (tmpbytesv9 & 8) == 0;
                cell.Blue = (tmpbytesv9 & 16) != 0;
                cell.Red = (tmpbytesv9 & 32) != 0;
                cell.Visible = (tmpbytesv9 & 64) != 0;
                cell.FarmCell = (tmpbytesv9 & 128) != 0;

                if (map.Version >= 10)
                {
                    cell.HavenbagCell = (tmpbytesv9 & 256) != 0;
                    cell.TopArrow = (tmpbytesv9 & 512) != 0;
                    cell.BottomArrow = (tmpbytesv9 & 1024) != 0;
                    cell.RightArrow = (tmpbytesv9 & 2048) != 0;
                    cell.LeftArrow = (tmpbytesv9 & 4096) != 0;
                }
                else
                {
                    cell.TopArrow = (tmpbytesv9 & 256) != 0;
                    cell.BottomArrow = (tmpbytesv9 & 512) != 0;
                    cell.RightArrow = (tmpbytesv9 & 1024) != 0;
                    cell.LeftArrow = (tmpbytesv9 & 2048) != 0;
                }

                if (cell.TopArrow)
                    map.TopArrowCells.Add(cell.Id);
                if (cell.BottomArrow)
                    map.BottomArrowCells.Add(cell.Id);
                if (cell.RightArrow)
                    map.RightArrowCells.Add(cell.Id);
                if (cell.LeftArrow)
                    map.LeftArrowCells.Add(cell.Id);
            }
            else
            {
                var losmov = s.ReadByte();
                cell.Los = (losmov & 2) >> 1 == 1;
                cell.Mov = (losmov & 1) == 1;
                cell.Visible = (losmov & 64) >> 6 == 1;
                cell.FarmCell = (losmov & 32) >> 5 == 1;
                cell.Blue = (losmov & 16) >> 4 == 1;
                cell.Red = (losmov & 8) >> 3 == 1;
                cell.NonWalkableDuringRp = (losmov & 128) >> 7 == 1;
                cell.NonWalkableDuringFight = (losmov & 4) >> 2 == 1;
            }

            cell.Speed = s.ReadByte();
            cell.MapChangeData = s.ReadByte();

            if (map.Version > 5)
                cell.MoveZone = s.ReadByte();
            if (map.Version > 10 && (cell.HasLinkedZoneRP || cell.HasLinkedZoneFight))
                cell.LinkedZone = s.ReadByte();
            if (map.Version > 7 && map.Version < 9)
            {
                var tmpBits = s.ReadByte();
                cell.Arrow = 15 & tmpBits;
                if ((cell.Arrow & 1) != 0)
                    map.TopArrowCells.Add(cell.Id);
                if ((cell.Arrow & 2) != 0)
                    map.BottomArrowCells.Add(cell.Id);
                if ((cell.Arrow & 4) != 0)
                    map.RightArrowCells.Add(cell.Id);
                if ((cell.Arrow & 8) != 0)
                    map.LeftArrowCells.Add(cell.Id);
            }

            return cell;
        }
    }
}
