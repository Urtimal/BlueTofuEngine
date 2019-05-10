using BlueTofuEngine.Core.Network.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine.Core.Network.Message
{
    public class NetworkMessageHandlerService : Singleton<NetworkMessageHandlerService>
    {
        private readonly Dictionary<uint, List<MethodInfo>> _handlers;

        public NetworkMessageHandlerService()
        {
            _handlers = new Dictionary<uint, List<MethodInfo>>();
        }

        public void SearchHandlersInAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                foreach (var method in type.GetMethods())
                {
                    var attr = method.GetCustomAttribute<NetworkMessageHandlerAttribute>();
                    if (attr == null)
                        continue;

                    var message = NetworkMessageRepository.Instance.Get(attr.MessageId);
                    if (message == null)
                        continue;

                    var methodParams = method.GetParameters();
                    if (methodParams.Length != 2)
                        continue;
                    if (methodParams[0].ParameterType != typeof(INetworkClient) || methodParams[1].ParameterType != message.GetType())
                        continue;

                    if (!_handlers.ContainsKey(attr.MessageId))
                        _handlers.Add(attr.MessageId, new List<MethodInfo>());

                    _handlers[attr.MessageId].Add(method);
                }
            }
        }

        public void Handle(INetworkClient client, NetworkMessage message)
        {
            if (_handlers.TryGetValue(message.MessageId, out List<MethodInfo> handlers))
            {
                foreach (var handler in handlers)
                {
                    var args = new object[] { client, message };
                    handler.Invoke(null, args);
                }
            }
        }
    }
}
