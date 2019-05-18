using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine.Core.Network.Message
{
    public class NetworkMessageRepository : Singleton<NetworkMessageRepository>
    {
        private readonly Dictionary<uint, Type> _messages;

        public NetworkMessageRepository()
        {
            _messages = new Dictionary<uint, Type>();
        }

        public void SearchMessagesInAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes();
            var networkMessageTypes = types.Where(x => x.GetCustomAttribute<NetworkMessageAttribute>() != null);
            foreach (var type in networkMessageTypes)
            {
                var attr = type.GetCustomAttribute<NetworkMessageAttribute>();
                if (_messages.ContainsKey(attr.MessageId))
                    _messages[attr.MessageId] = type;
                else
                    _messages.Add(attr.MessageId, type);
            }
        }

        public INetworkMessage Get(uint messageId)
        {
            if (_messages.ContainsKey(messageId))
                return (INetworkMessage)Activator.CreateInstance(_messages[messageId]);
            return null;
        }
    }
}
