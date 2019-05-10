using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Serialization
{
    public interface ICustomDataReader
    {
        byte[] ReadBytes(int count, bool reverse = false);
        byte ReadByte();
        sbyte ReadSByte();
        ushort ReadUShort();
        short ReadShort();
        uint ReadUInt();
        int ReadInt();
        ulong ReadULong();
        long ReadLong();
        float ReadSingle();
        double ReadDouble();
        bool ReadBool();
        string ReadUTF();
        string ReadUTFBytes(int count);
        ushort ReadVarUShort();
        short ReadVarShort();
        uint ReadVarUInt();
        int ReadVarInt();
        ulong ReadVarULong();
        long ReadVarLong();
    }
}
