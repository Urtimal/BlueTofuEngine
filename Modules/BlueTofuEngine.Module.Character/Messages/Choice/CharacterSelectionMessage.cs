using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class CharacterSelectionMessage : NetworkMessage
    {
        public const ushort Id = 152;

        public uint CharacterId { get; set; }

        public CharacterSelectionMessage() : base(Id)
        {
        }

        public CharacterSelectionMessage(ushort id) : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            CharacterId = (uint)reader.ReadVarULong();
        }

        public override string GetSummary()
        {
            return CharacterId.ToString();
        }
    }
}
