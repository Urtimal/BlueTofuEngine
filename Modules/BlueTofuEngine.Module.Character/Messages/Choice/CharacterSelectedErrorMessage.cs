using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class CharacterSelectedErrorMessage : NetworkMessage
    {
        public const ushort Id = 5836;
        
        public CharacterSelectedErrorMessage() : base(Id)
        {
        }
    }
}
