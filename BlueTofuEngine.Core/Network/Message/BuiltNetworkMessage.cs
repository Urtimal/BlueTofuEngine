using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Network.Message
{
    public class BuiltNetworkMessage : NetworkMessage
    {
        private readonly CustomDataWriter _writer;

        public BuiltNetworkMessage(ushort messageId) : base(messageId)
        {
            _writer = new CustomDataWriter();
        }
        
        public void Add(object obj, bool isVar = false)
        {
            switch (obj)
            {
                case byte byteArg:
                    _writer.WriteByte(byteArg);
                    break;
                case sbyte sbyteArg:
                    _writer.WriteSByte(sbyteArg);
                    break;
                case ushort ushortArg:
                    if (isVar)
                        _writer.WriteVarUShort(ushortArg);
                    else
                        _writer.WriteUShort(ushortArg);
                    break;
                case short shortArg:
                    if (isVar)
                        _writer.WriteVarShort(shortArg);
                    else
                        _writer.WriteShort(shortArg);
                    break;
                case uint uintArg:
                    if (isVar)
                        _writer.WriteVarUInt(uintArg);
                    else
                        _writer.WriteUInt(uintArg);
                    break;
                case int intArg:
                    if (isVar)
                        _writer.WriteVarInt(intArg);
                    else
                        _writer.WriteInt(intArg);
                    break;
                case ulong ulongArg:
                    if (isVar)
                        _writer.WriteVarULong(ulongArg);
                    else
                        _writer.WriteULong(ulongArg);
                    break;
                case long longArg:
                    if (isVar)
                        _writer.WriteVarLong(longArg);
                    else
                        _writer.WriteLong(longArg);
                    break;
                case bool boolArg:
                    _writer.WriteBool(boolArg);
                    break;
                case float singleArg:
                    _writer.WriteSingle(singleArg);
                    break;
                case double doubleArg:
                    _writer.WriteDouble(doubleArg);
                    break;
                case string utfArg:
                    _writer.WriteUTF(utfArg);
                    break;
            }
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteBytes(_writer.GetBytes());
        }
    }
}
