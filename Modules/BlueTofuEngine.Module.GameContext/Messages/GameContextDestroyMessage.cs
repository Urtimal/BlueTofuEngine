using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    [NetworkMessage(Id)]
    public class GameContextDestroyMessage : NetworkMessage
    {
        public const ushort Id = 201;

        public GameContextDestroyMessage() : base(Id)
        { }

        protected override void serializeContent(ICustomDataWriter writer)
        {

        }
    }
}
