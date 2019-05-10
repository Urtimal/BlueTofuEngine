using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.DLM
{
    public abstract class BasicElement
    {
        [JsonProperty("type")]
        public ElementType Type { get; private set; }

        public BasicElement(ElementType type)
        {
            Type = type;
        }

        public abstract void FromRaw(Stream s, int mapVersion);

        public static BasicElement FromType(ElementType type)
        {
            switch (type)
            {
                case ElementType.Graphical:
                    return new GraphicalElement();
                case ElementType.Sound:
                    return new SoundElement();
                default:
                    throw new InvalidDataException("Element type '" + (int)type + "' doesn't exist");
            }
        }
    }
}
