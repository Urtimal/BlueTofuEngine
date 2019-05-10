using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass.Messages
{
    [NetworkMessage(Id)]
    public class AccountCapabilitiesMessage : NetworkMessage
    {
        public const ushort Id = 6216;

        public uint AccountId { get; set; }

        public AccountCapabilitiesMessage(uint accountId) : base(Id)
        {
            AccountId = accountId;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte(0b00); // Tutorial + CanCreateNewChar
            writer.WriteInt((int)AccountId);
            writer.WriteVarUInt(262143); // Breeds visible
            writer.WriteVarUInt(262143); // Breeds available
            writer.WriteByte(0); // Status
            writer.WriteDouble(0); // Unlimited restat end date
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
