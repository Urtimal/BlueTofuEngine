using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Network.Message
{
    public  class NetworkMessageBuilder
    {
        private BuiltNetworkMessage _message;

        public NetworkMessageBuilder(ushort messageId)
        {
            _message = new BuiltNetworkMessage(messageId);
        }

        public static NetworkMessageBuilder New(ushort messageId)
        {
            var builder = new NetworkMessageBuilder(messageId);
            return builder;
        }

        public NetworkMessageBuilder Add<T>(T value)
        {
            _message.Add(value);
            return this;
        }

        public NetworkMessageBuilder AddVar<T>(T value)
        {
            _message.Add(value, true);
            return this;
        }

        public INetworkMessage Build()
        {
            return _message;
        }
    }
}
