using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.ELE
{
    public class EntityGraphicalElementData : GraphicalElementData
    {
        [JsonProperty("entityLook")]
        public string EntityLook { get; set; }
        [JsonProperty("horizontalSymmetry")]
        public bool HorizontalSymmetry { get; set; }
        [JsonProperty("playAnimation")]
        public bool PlayAnimation { get; set; }
        [JsonProperty("playAnimStatic")]
        public bool PlayAnimStatic { get; set; }
        [JsonProperty("minDelay")]
        public uint MinDelay { get; set; }
        [JsonProperty("maxDelay")]
        public uint MaxDelay { get; set; }

        public EntityGraphicalElementData() : base(GraphicalElementTypes.Entity)
        { }

        public override void FromRaw(Stream s, int fileVersion)
        {
            var entityLookLength = s.ReadInt();
            EntityLook = s.ReadUTFBytes(entityLookLength);
            HorizontalSymmetry = s.ReadBoolean();
            if (fileVersion >= 7)
                PlayAnimation = s.ReadBoolean();
            if (fileVersion >= 6)
                PlayAnimStatic = s.ReadBoolean();
            if (fileVersion >= 5)
            {
                MinDelay = s.ReadUInt();
                MaxDelay = s.ReadUInt();
            }
        }
    }
}
