using BlueTofuEngine.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterUserData : UserData
    {
        public uint AccountId { get; set; }
        public uint CharacterId { get; set; }
        public string Name { get; set; }
        public int BreedId { get; set; }
        public bool Gender { get; set; }
        public int Level { get; set; }
        public int HeadId { get; set; }
        public string Colors { get; set; }
    }
}
