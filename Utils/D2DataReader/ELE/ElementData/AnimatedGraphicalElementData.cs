using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.ELE
{
    public class AnimatedGraphicalElementData : NormalGraphicalElementData
    {
        [JsonProperty("minDelay")]
        public uint MinDelay { get; set; }
        [JsonProperty("maxDelay")]
        public uint MaxDelay { get; set; }

        public AnimatedGraphicalElementData() : base(GraphicalElementTypes.Animated)
        { }

        public override void FromRaw(Stream s, int fileVersion)
        {
            base.FromRaw(s, fileVersion);

            if (fileVersion == 4)
            {
                MinDelay = s.ReadUInt();
                MaxDelay = s.ReadUInt();
            }
        }
    }
}
