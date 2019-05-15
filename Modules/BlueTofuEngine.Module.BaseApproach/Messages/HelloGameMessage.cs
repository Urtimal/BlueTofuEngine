using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseApproach
{
    [NetworkMessage(Id)]
    public class HelloGameMessage : NetworkMessage
    {
        public const ushort Id = 101;

        public HelloGameMessage() : base(Id)
        {
        }
    }
}
