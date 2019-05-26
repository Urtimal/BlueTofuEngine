using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2WorldMapViewer
{
    public class WorldMap
    {
        public int id { get; set; }
        public string nameId { get; set; }
        public int origineX { get; set; }
        public int origineY { get; set; }
        public double mapWidth { get; set; }
        public double mapHeight { get; set; }
        public double minScale { get; set; }
        public double maxScale { get; set; }
        public int totalWidth { get; set; }
        public int totalHeight { get; set; }
        public string[] zoom { get; set; }
    }
}
