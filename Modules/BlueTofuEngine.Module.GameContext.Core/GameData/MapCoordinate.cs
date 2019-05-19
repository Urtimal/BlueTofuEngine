using BlueTofuEngine.Core.GameData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext.Data
{
    [GameData("MapCoordinates")]
    public class MapCoordinate
    {
        [JsonProperty("compressedCoords")]
        public int Coords { get; set; }
        public short PosX => (short)((Coords & 0xFFFF0000) >> 16);
        public short PosY => (short)(Coords & 0x0000FFFF);
        [JsonProperty("mapIds")]
        public double[] Maps { get; set; }

        public static int GetCompressed(short x, short y)
        {
            int coords = 0;
            coords |= x << 16;
            coords |= y & 0xFFFF;
            return coords;
        }
    }
}
