using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class CharacterCreationResultMessage : NetworkMessage
    {
        public const ushort Id = 161;

        public CharacterCreationResult Result { get; set; }

        public CharacterCreationResultMessage(CharacterCreationResult result = CharacterCreationResult.Ok) : base(Id)
        {
            Result = result;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte((byte)Result);
        }
    }
}
