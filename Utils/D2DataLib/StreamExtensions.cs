using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2DataLib
{
    public static class StreamExtentions
    {
        public static bool ReadBoolean(this Stream stream)
        {
            var bytes = stream.ReadBytes(1);
            return BitConverter.ToBoolean(bytes.ToArray(), 0);
        }

        #region Base

        public static sbyte ReadInt8(this Stream stream)
        {
            return (sbyte)stream.ReadByte();
        }

        public static byte ReadUInt8(this Stream stream)
        {
            return (byte)stream.ReadByte();
        }

        public static Int16 ReadInt16(this Stream stream)
        {
            var bytes = stream.ReadBytes(2);
            return BitConverter.ToInt16(bytes.ToArray(), 0);
        }

        public static UInt16 ReadUInt16(this Stream stream)
        {
            var bytes = stream.ReadBytes(2);
            return BitConverter.ToUInt16(bytes.ToArray(), 0);
        }

        public static Int32 ReadInt32(this Stream stream)
        {
            var bytes = stream.ReadBytes(4);
            return BitConverter.ToInt32(bytes.ToArray(), 0);
        }

        public static UInt32 ReadUInt32(this Stream stream)
        {
            var bytes = stream.ReadBytes(4);
            return BitConverter.ToUInt32(bytes.ToArray(), 0);
        }

        public static Int64 ReadInt64(this Stream stream)
        {
            var bytes = stream.ReadBytes(8);
            return BitConverter.ToInt64(bytes.ToArray(), 0);
        }

        public static UInt64 ReadUInt64(this Stream stream)
        {
            var bytes = stream.ReadBytes(8);
            return BitConverter.ToUInt64(bytes.ToArray(), 0);
        }

        public static Single ReadSingle(this Stream stream)
        {
            var bytes = stream.ReadBytes(4);
            return BitConverter.ToSingle(bytes.ToArray(), 0);
        }

        public static Double ReadDouble(this Stream stream)
        {
            var bytes = stream.ReadBytes(8);
            return BitConverter.ToDouble(bytes.ToArray(), 0);
        }

        public static string ReadUTF(this Stream stream)
        {
            var size = stream.ReadUInt16();
            return stream.ReadUTFBytes(size);
        }

        public static string ReadUTFBytes(this Stream stream, int size)
        {
            var bytes = stream.ReadBytes(size, false);
            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        public static string ReadString(this Stream stream, int length)
        {
            var bytes = stream.ReadBytes(length, false);
            return Encoding.ASCII.GetString(bytes.ToArray());
        }

        #endregion

        #region Alias

        public static sbyte ReadSByte(this Stream stream)
        {
            return stream.ReadInt8();
        }

        public static short ReadShort(this Stream stream)
        {
            return stream.ReadInt16();
        }
        public static ushort ReadUShort(this Stream stream)
        {
            return stream.ReadUInt16();
        }

        public static int ReadInt(this Stream stream)
        {
            return stream.ReadInt32();
        }
        public static uint ReadUInt(this Stream stream)
        {
            return stream.ReadUInt32();
        }

        public static long ReadLong(this Stream stream)
        {
            return stream.ReadInt64();
        }
        public static ulong ReadULong(this Stream stream)
        {
            return stream.ReadUInt64();
        }

        #endregion

        public static IEnumerable<byte> ReadBytes(this Stream stream, int count, bool bigEndian = true)
        {
            var buffer = new byte[count];
            int read = stream.Read(buffer, 0, count);
            var bytes = buffer.Take(read);
            return bigEndian ? bytes.Reverse() : bytes;
        }

        public static IEnumerable<byte> ReadToEnd(this Stream stream)
        {
            var list = new List<byte>();
            var buffer = new byte[1024];
            int read = 0;
            do
            {
                read = stream.Read(buffer, 0, 1024);
                list.AddRange(buffer);
            }
            while (read != 0);
            return list;
        }
    }
}
