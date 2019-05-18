using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterSelectionEventArgs : SystemEventArgs
    {
        public uint CharacterId { get; set; }

        public CharacterSelectionEventArgs(uint characterId)
        {
            CharacterId = characterId;
        }

        public override bool CheckIsValid()
        {
            return CharacterId > 0;
        }
    }
}
