using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    [NetworkMessage(Id)]
    public class SelectedServerDataMessage : NetworkMessage
    {
        public const ushort Id = 42;

        public int ServerId { get; set; }
        public string Address { get; set; }
        public List<int> Ports { get; set; }
        public bool CanCreateNewCharacter { get; set; }

        public SelectedServerDataMessage(ushort messageId = Id) : base(messageId)
        {
            Ports = new List<int>();
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {

        }
    }
}
