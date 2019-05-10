using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Stats.GameType
{
    public class CharacterBaseCharacteristic : NetworkType
    {
        public StatDefinition Stat { get; private set; }

        public CharacterBaseCharacteristic(StatDefinition stat)
        {
            ProtocolId = 4;
            Stat = stat;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarShort((short)Stat.Base);
            writer.WriteVarShort((short)Stat.Additionnal);
            writer.WriteVarShort((short)Stat.Equipment);
            writer.WriteVarShort((short)Stat.AlignGift);
            writer.WriteVarShort((short)Stat.Context);
        }
    }
}
