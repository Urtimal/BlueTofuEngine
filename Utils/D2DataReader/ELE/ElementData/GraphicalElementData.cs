using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2DataLib.ELE
{
    public abstract class GraphicalElementData
    {
        [JsonProperty("type")]
        public GraphicalElementTypes Type { get; protected set; }

        public GraphicalElementData(GraphicalElementTypes type)
        {
            Type = type;
        }

        public abstract void FromRaw(Stream s, int fileVersion);

        public static GraphicalElementData FromType(GraphicalElementTypes type)
        {
            switch (type)
            {
                case GraphicalElementTypes.Normal:
                    return new NormalGraphicalElementData();
                case GraphicalElementTypes.BoundingBox:
                    return new BoundingBoxGraphicalElementData();
                case GraphicalElementTypes.Animated:
                    return new AnimatedGraphicalElementData();
                case GraphicalElementTypes.Entity:
                    return new EntityGraphicalElementData();
                case GraphicalElementTypes.Particles:
                    return new ParticlesGraphicalElementData();
                case GraphicalElementTypes.Blended:
                    return new BlendedGraphicalElementData();
                default:
                    return null;
            }
        }
    }
}
