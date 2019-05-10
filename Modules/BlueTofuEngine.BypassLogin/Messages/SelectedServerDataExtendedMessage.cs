using BlueTofuEngine.Core;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.BypassLogin.Messages
{
    [NetworkMessage(Id)]
    public class SelectedServerDataExtendedMessage : NetworkMessage
    {
        public const ushort Id = 6469;

        public SelectedServerDataExtendedMessage() : base(Id)
        { }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            // SelectedServerData (42)
            writer.WriteVarShort(211); // Server id
            writer.WriteUTF("127.0.0.1"); // Server address
            writer.WriteShort(1); // Number of ports
            writer.WriteInt(5556); // Game Server port
            writer.WriteBool(false); // Can create new character
            var ticket = Guid.NewGuid().ToString().Replace("-", "");
            writer.WriteVarInt(ticket.Length); // Ticket length
            writer.WriteUTFBytes(ticket); // Ticket

            //SelectedServerDataExtended
            writer.WriteUShort(1); // Number of servers

            // GameServerInformations
            var byteBox = new ByteBox();
            byteBox[0] = false; // Is Mono account
            byteBox[1] = true; // Is Selectable
            writer.WriteByte(byteBox.Value);
            writer.WriteVarShort(211); // Server id
            writer.WriteByte(0); // Type
            writer.WriteByte(3); // Status
            writer.WriteByte(0); // Completion
            writer.WriteByte(1); // Character count
            writer.WriteByte(5); // Character slots
            writer.WriteDouble(0); // Date
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
