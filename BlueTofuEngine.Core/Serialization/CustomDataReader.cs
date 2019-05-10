using BlueTofuEngine.Core.Serialization.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Core.Serialization
{
    public class CustomDataReader : ICustomDataReader
    {
        private byte[] _data;
        private readonly MemoryStream _ms;

        public CustomDataReader(byte[] data)
        {
            _data = data;
            _ms = new MemoryStream(data);
        }

        public byte[] ReadBytes(int count, bool reverse = false)
        {
            var bytes = new byte[count];
            int read = _ms.Read(bytes, 0, count);
            if (reverse)
                return bytes.Take(read).Reverse().ToArray();
            else
                return bytes.Take(read).ToArray();
        }

        #region Boolean

        public bool ReadBool()
        {
            return BitConverter.ToBoolean(ReadBytes(1), 0);
        }

        #endregion
        #region Int8

        public byte ReadByte()
        {
            return ReadBytes(1).First();
        }

        public sbyte ReadSByte()
        {
            return (sbyte)ReadBytes(1).First();
        }

        #endregion
        #region Int16

        public short ReadShort()
        {
            return BitConverter.ToInt16(ReadBytes(2, true), 0);
        }

        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16(ReadBytes(2, true), 0);
        }

        #endregion
        #region Int32

        public int ReadInt()
        {
            return BitConverter.ToInt32(ReadBytes(4, true), 0);
        }

        public uint ReadUInt()
        {
            return BitConverter.ToUInt32(ReadBytes(4, true), 0);
        }

        #endregion
        #region Int64

        public long ReadLong()
        {
            return BitConverter.ToInt64(ReadBytes(8, true), 0);
        }

        public ulong ReadULong()
        {
            return BitConverter.ToUInt64(ReadBytes(8, true), 0);
        }

        #endregion
        #region Floating point

        public float ReadSingle()
        {
            return BitConverter.ToSingle(ReadBytes(4, true), 0);
        }

        public double ReadDouble()
        {
            return BitConverter.ToDouble(ReadBytes(8, true), 0);
        }

        #endregion
        #region String

        public string ReadUTF()
        {
            var length = ReadUShort();
            var bytes = ReadBytes(length);
            return Encoding.UTF8.GetString(bytes);
        }

        public string ReadUTFBytes(int count)
        {
            var bytes = ReadBytes(count);
            return Encoding.UTF8.GetString(bytes);
        }

        #endregion
        #region VarInt

        public int ReadVarInt()
        {
            int value = 0;
            int offset = 0;
            bool hasNext;

            while (offset < 32)
            {
                var b = (byte)_ms.ReadByte();
                hasNext = (b & 0b1000_0000) != 0;
                value += (b & 0b0111_1111) << offset;
                offset += 7;

                if (!hasNext)
                    return value;
            }

            throw new OverflowException("Too much data");
        }

        public uint ReadVarUInt()
        {
            return (uint)ReadVarInt();
        }

        #endregion
        #region VarShort

        public short ReadVarShort()
        {
            int value = 0;
            int offset = 0;
            bool hasNext;

            while (offset < 16)
            {
                var b = (byte)_ms.ReadByte();
                hasNext = (b & 0b1000_0000) != 0;
                value += (b & 0b0111_1111) << offset;
                offset += 7;

                if (!hasNext)
                {
                    if (value > short.MaxValue)
                        return (short)(value - ushort.MaxValue);
                    else
                        return (short)value;
                }
            }

            throw new OverflowException("Too much data");
        }
        
        public ushort ReadVarUShort()
        {
            return (ushort)ReadVarShort();
        }

        #endregion
        #region VarLong

        public long ReadVarLong()
        {
            uint b = 0;
            CustomInt64 result = new CustomInt64();
            int i = 0;
            while (true)
            {
                b = (byte)_ms.ReadByte();
                if (i == 28)
                {
                    break;
                }
                if (b >= 128)
                {
                    result.low = result.low | (b & 127) << i;
                    i = i + 7;
                    continue;
                }
                result.low = result.low | b << i;
                return result.toNumber();
            }

            if (b >= 128)
            {
                b = b & 127;
                result.low = result.low | b << i;
                result.high = b >> 4;
                i = 3;
                while (true)
                {
                    b = (byte)_ms.ReadByte();
                    if (i < 32)
                    {
                        if (b >= 128)
                        {
                            result.high = (uint)(result.high | (b & 127) << i);
                        }
                        else
                        {
                            break;
                        }
                    }
                    i = i + 7;
                }

                result.high = (uint)(result.high | (b << i));
                return result.toNumber();
            }
            result.low = result.low | b << i;
            result.high = b >> 4;
            return result.toNumber();
        }

        public ulong ReadVarULong()
        {
            uint b = 0;
            var result = new CustomUInt64();
            int i = 0;
            while (true)
            {
                b = (byte)_ms.ReadByte();
                if (i == 28)
                {
                    break;
                }
                if (b >= 128)
                {
                    result.low = result.low | (b & 127) << i;
                    i = i + 7;
                    continue;
                }
                result.low = result.low | b << i;
                return result.toNumber();
            }

            if (b >= 128)
            {
                b = b & 127;
                result.low = result.low | b << i;
                result.high = b >> 4;
                i = 3;
                while (true)
                {
                    b = (byte)_ms.ReadByte();
                    if (i < 32)
                    {
                        if (b >= 128)
                        {
                            result.high = result.high | (b & 127) << i;
                        }
                        else
                        {
                            break;
                        }
                    }
                    i = i + 7;
                }

                result.high = result.high | b << i;
                return result.toNumber();
            }
            result.low = result.low | b << i;
            result.high = b >> 4;
            return result.toNumber();
        }

        #endregion
    }
}
