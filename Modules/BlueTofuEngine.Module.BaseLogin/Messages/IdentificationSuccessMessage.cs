using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    [NetworkMessage(Id)]
    public class IdentificationSuccessMessage : NetworkMessage
    {
        public const ushort Id = 22;

        public bool HasRights { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public int AccountId { get; set; }
        public byte CommunityId { get; set; }
        public string SecretQuestion { get; set; }
        public DateTime AccountCreation { get; set; }
        public TimeSpan SubscriptionElasped { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public bool HavenBagAvailable { get; set; }

        public IdentificationSuccessMessage() : base(Id)
        { }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte((byte)(HasRights ? 1 : 0));
            writer.WriteUTF(Username);
            writer.WriteUTF(Nickname);
            writer.WriteInt(AccountId);
            writer.WriteByte(CommunityId);
            writer.WriteUTF(SecretQuestion);
            writer.WriteDouble(TimestampUtils.GetFromDateLong(AccountCreation));
            writer.WriteDouble(0); // Subscribtion elapsed
            writer.WriteDouble(0); // Subscription end date
            writer.WriteByte((byte)(HavenBagAvailable ? 1 : 0));
        }
    }
}
