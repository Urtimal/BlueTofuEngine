using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MapViewer.Data
{
    public class CellData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("mov")]
        public bool Mov { get; set; }
        [JsonProperty("los")]
        public bool LineOfSight { get; set; }
    }
}
