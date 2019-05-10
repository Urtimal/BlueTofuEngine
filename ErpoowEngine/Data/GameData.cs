using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpoowEngine.Data
{
    public abstract class GameData
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string Type { get; set; }
        [JsonIgnore]
        public bool Loaded => Id != -1;

        public GameData(string type)
        {
            Id = -1;
            Type = type;
        }
    }
}
