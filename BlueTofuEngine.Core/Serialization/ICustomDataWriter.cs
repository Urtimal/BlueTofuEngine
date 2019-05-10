using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Serialization
{
    public interface ICustomDataWriter
    {
        byte[] GetBytes();
        void WriteBytes(byte[] value, bool inverse = false);
        void WriteByte(byte value);
        void WriteSByte(sbyte value);
        void WriteUShort(ushort value);
        void WriteShort(short value);
        void WriteUInt(uint value);
        void WriteInt(int value);
        void WriteULong(ulong value);
        void WriteLong(long value);
        void WriteSingle(float value);
        void WriteDouble(double value);
        void WriteBool(bool value);
        void WriteUTF(string value);
        void WriteUTFBytes(string value);
        void WriteVarUShort(ushort value);
        void WriteVarShort(short value);
        void WriteVarUInt(uint value);
        void WriteVarInt(int value);
        void WriteVarULong(ulong value);
        void WriteVarLong(long value);
    }
}
