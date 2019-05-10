using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MapViewer.Data
{
    public class Element
    {
        public int id { get; set; }
        public ElementData data { get; set; }
    }

    public class ElementData
    {
        public int gfxId { get; set; }
        public int height { get; set; }
        public bool horizontalSymmetry { get; set; }
        public JsonPoint origin { get; set; }
        public JsonPoint size { get; set; }
        public int type { get; set; }
    }
}
