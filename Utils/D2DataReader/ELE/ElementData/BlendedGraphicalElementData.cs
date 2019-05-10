using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.ELE
{
    public class BlendedGraphicalElementData : NormalGraphicalElementData
    {
        [JsonProperty("blendMode")]
        public string BlendMode { get; set; }

        public BlendedGraphicalElementData() : base(GraphicalElementTypes.Blended)
        { }

        public override void FromRaw(Stream s, int fileVersion)
        {
            base.FromRaw(s, fileVersion);

            var blendModeLength = s.ReadInt();
            BlendMode = s.ReadUTFBytes(blendModeLength);
        }
    }
}
