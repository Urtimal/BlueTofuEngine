using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Network.Message
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class NetworkMessageHandlerAttribute : Attribute
    {
        public uint MessageId { get; private set; }

        public NetworkMessageHandlerAttribute(uint id)
        {
            MessageId = id;
        }
    }
}
