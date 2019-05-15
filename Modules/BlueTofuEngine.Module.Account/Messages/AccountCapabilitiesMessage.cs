using BlueTofuEngine.Core;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Account
{
    [NetworkMessage(Id)]
    public class AccountCapabilitiesMessage : NetworkMessage
    {
        public const ushort Id = 6216;

        public uint AccountId { get; set; }
        public bool TutorialAvailable { get; set; }
        public uint BreedsVisible { get; set; }
        public uint BreedsAvailable { get; set; }
        public int Status { get; set; }
        public bool CanCreateNewCharacter { get; set; }

        public AccountCapabilitiesMessage() : base(Id)
        {
        }

        public static AccountCapabilitiesMessage FromUserData(AccountCapabilityUserData userData)
        {
            uint breedsVisible = 0;
            foreach (var breed in userData.BreedsVisibile.Split(',').Select(x => int.Parse(x)))
                breedsVisible |= (uint)1 << (breed - 1);
            uint breedsAvailable = 0;
            foreach (var breed in userData.BreedsAvailable.Split(',').Select(x => int.Parse(x)))
                breedsAvailable |= (uint)1 << (breed - 1);

            return new AccountCapabilitiesMessage
            {
                AccountId = userData.AccountId,
                CanCreateNewCharacter = userData.CanCreateCharacter,
                Status = userData.Status,
                TutorialAvailable = false,
                BreedsAvailable = breedsAvailable,
                BreedsVisible = breedsVisible
            };
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            var byteBox = new ByteBox();
            byteBox[0] = TutorialAvailable;
            byteBox[1] = CanCreateNewCharacter;
            writer.WriteByte(byteBox.Value);
            writer.WriteInt((int)AccountId);
            writer.WriteVarInt((int)BreedsVisible);
            writer.WriteVarInt((int)BreedsAvailable);
            writer.WriteByte((byte)Status);
            writer.WriteDouble(0); // Unlimited restat end date
        }
    }
}
