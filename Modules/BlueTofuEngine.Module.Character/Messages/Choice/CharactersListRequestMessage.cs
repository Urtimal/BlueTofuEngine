using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class CharactersListRequestMessage : NetworkMessage
    {
        public const ushort Id = 150;

        public CharactersListRequestMessage() : base(Id)
        {
        }
    }
}
