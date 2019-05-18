using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class CharactersListMessage : BasicCharactersListMessage
    {
        public new const ushort Id = 151;

        public bool HasStartupActions { get; set; }

        public CharactersListMessage() : base(Id)
        {
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            base.serializeContent(writer);

            writer.WriteBool(HasStartupActions);
        }
    }
}
