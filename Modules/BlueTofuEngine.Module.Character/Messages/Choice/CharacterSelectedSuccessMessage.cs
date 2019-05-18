using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class CharacterSelectedSuccessMessage : NetworkMessage
    {
        public const ushort Id = 153;

        public CharacterBaseInformations Infos { get; set; }
        public bool IsCollectingStats { get; set; }

        public CharacterSelectedSuccessMessage() : base(Id)
        {
            Infos = new CharacterBaseInformations();
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            Infos.Serialize(writer);
            writer.WriteBool(IsCollectingStats);
        }
    }
}
