using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core.Serialization;

namespace BlueTofuEngine.Core.Network.Message
{
    public abstract class NetworkMessage : INetworkMessage
    {
        public ushort MessageId { get; private set; }

        protected NetworkMessage(ushort messageId)
        {
            MessageId = messageId;
        }

        public string GetName()
        {
            return GetType().Name + "(" + MessageId + ")";
        }

        public virtual string GetSummary()
        {
            return string.Empty;
        }

        public void Serialize(ICustomDataWriter writer)
        {
            var dataWriter = new CustomDataWriter();
            serializeContent(dataWriter);
            var messageData = dataWriter.GetBytes();

            ushort header = (ushort)(MessageId << 2);
            if (messageData.Length == 0)
            {
                writer.WriteUShort(header);
                return;
            }
            if (messageData.Length <= byte.MaxValue)
            {
                writer.WriteUShort((ushort)(header | 1));
                writer.WriteByte((byte)messageData.Length);
            }
            else if (messageData.Length <= ushort.MaxValue)
            {
                header |= 2;
                writer.WriteUShort(header);
                writer.WriteUShort((ushort)messageData.Length);
            }
            else
            {
                return;
            }

            writer.WriteBytes(messageData);
        }

        public virtual void Deserialize(ICustomDataReader reader)
        {
            throw new NotImplementedException();
        }

        protected virtual void serializeContent(ICustomDataWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
