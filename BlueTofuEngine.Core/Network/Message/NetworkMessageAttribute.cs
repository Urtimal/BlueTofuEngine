using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Network.Message
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class NetworkMessageAttribute : Attribute
    {
        public uint MessageId { get; private set; }

        public NetworkMessageAttribute(uint id)
        {
            MessageId = id;
        }
    }
}
