using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class CharacterLoadingCompleteMessage : NetworkMessage
    {
        public const ushort Id = 6471;

        public CharacterLoadingCompleteMessage() : base(Id)
        {
        }
    }
}
