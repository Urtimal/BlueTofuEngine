using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Game
{
    public class EntityLook : NetworkType
    {
        public const uint TypeId = 55;

        public short BonesId { get; set; }
        public List<short> Skins { get; set; }
        public List<int> IndexedColors { get; set; }
        public List<short> Scales { get; set; }

        // TODO: SubEntities

        public EntityLook()
        {
            ProtocolId = TypeId;
            Skins = new List<short>();
            IndexedColors = new List<int>();
            Scales = new List<short>();
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarShort(BonesId);

            writer.WriteShort((short)Skins.Count);
            foreach (var skin in Skins)
                writer.WriteVarShort(skin);

            writer.WriteShort((short)IndexedColors.Count);
            for (int i = 0; i < IndexedColors.Count; i++)
                writer.WriteInt(IndexedColors[i] | ((i + 1) << 24));

            writer.WriteShort((short)Scales.Count);
            foreach (var scale in Scales)
                writer.WriteVarShort(scale);

            writer.WriteShort(0); // Sub entities
        }
    }
}
