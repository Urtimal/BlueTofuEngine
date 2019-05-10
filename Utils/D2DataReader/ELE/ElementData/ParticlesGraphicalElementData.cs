using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.ELE
{
    public class ParticlesGraphicalElementData : GraphicalElementData
    {
        [JsonProperty("scriptId")]
        public short ScriptId { get; set; }

        public ParticlesGraphicalElementData() : base(GraphicalElementTypes.Particles)
        { }

        public override void FromRaw(Stream s, int fileVersion)
        {
            ScriptId = s.ReadShort();
        }
    }
}
