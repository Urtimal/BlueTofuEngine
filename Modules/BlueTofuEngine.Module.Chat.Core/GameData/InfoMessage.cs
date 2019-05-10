using BlueTofuEngine.Core.GameData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat.Core
{
    [GameData("InfoMessages")]
    public class InfoMessage
    {
        [JsonProperty("typeId")]
        public int Type { get; set; }
        [JsonProperty("messageId")]
        public int Id { get; set; }
    }
}
