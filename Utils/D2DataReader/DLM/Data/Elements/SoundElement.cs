using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.DLM
{
    public class SoundElement : BasicElement
    {
        [JsonProperty("soundId")]
        public int SoundId { get; set; }
        [JsonProperty("baseVolume")]
        public short BaseVolume { get; set; }
        [JsonProperty("fullVolumeDistance")]
        public int FullVolumeDistance { get; set; }
        [JsonProperty("nullVolumeDistance")]
        public int NullVolumeDistance { get; set; }
        [JsonProperty("minDelayBetweenLoops")]
        public short MinDelayBetweenLoops { get; set; }
        [JsonProperty("maxDelayBetweenLoops")]
        public short MaxDelayBetweenLoops { get; set; }

        public SoundElement() : base(ElementType.Sound)
        { }

        public override void FromRaw(Stream s, int mapVersion)
        {
            SoundId = s.ReadInt();
            BaseVolume = s.ReadShort();
            FullVolumeDistance = s.ReadInt();
            NullVolumeDistance = s.ReadInt();
            MinDelayBetweenLoops = s.ReadShort();
            MaxDelayBetweenLoops = s.ReadShort();
        }
    }
}
