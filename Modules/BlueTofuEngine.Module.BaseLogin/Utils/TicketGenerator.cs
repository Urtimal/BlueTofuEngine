using BlueTofuEngine.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin.Utils
{
    public static class TicketGenerator
    {
        public static string Generate(int size)
        {
            var ticket = new List<byte>();
            for (int i = 0; i < size; i++)
                ticket.Add((byte)RandomUtils.Next(byte.MinValue, byte.MaxValue));
            return string.Join("", ticket.Select(x => x.ToString("x2")));
        }
    }
}
