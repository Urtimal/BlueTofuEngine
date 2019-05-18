using BlueTofuEngine.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class CharacterLocationUserData : UserData
    {
        public uint CharacterId { get; set; }
        public long MapId { get; set; }
        public int Cell { get; set; }
        public byte Direction { get; set; }
    }
}
