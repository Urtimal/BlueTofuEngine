using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Modules.CommonBasic
{
    [NetworkMessage(Id)]
    public class BasicNoOperationMessage : NetworkMessage
    {
        public const ushort Id = 176;

        public BasicNoOperationMessage() : base(Id)
        {
        }
    }
}
