using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.BypassLogin.Messages
{
    [NetworkMessage(Id)]
    public class IdentificationSuccessMessage : NetworkMessage
    {
        public const ushort Id = 22;
        
        public IdentificationSuccessMessage() : base(Id)
        { }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteByte(0); // HasRights + AlreadyConnected
            writer.WriteUTF("bypass"); // Login name
            writer.WriteUTF("ByPass"); // Nickname
            writer.WriteInt(1); // Account ID
            writer.WriteByte(0); // Community ID
            writer.WriteUTF("Elle est ou la poulette ?"); // Secret Question
            writer.WriteDouble(0); // Account creation
            writer.WriteDouble(0); // Subscribtion elapsed
            writer.WriteDouble(0); // Subscription end date
            writer.WriteByte(0); // Havenbag available
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
