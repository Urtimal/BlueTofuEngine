using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    [NetworkMessage(Id)]
    public class GameMapMovementConfirmMessage : NetworkMessage
    {
        public const ushort Id = 952;
        
        public GameMapMovementConfirmMessage() : base(Id)
        {
        }
    }
}
