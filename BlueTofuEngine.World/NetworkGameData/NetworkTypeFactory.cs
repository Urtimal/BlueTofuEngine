using BlueTofuEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine.World
{
    public class NetworkTypeFactory : Singleton<NetworkTypeFactory>
    {
        private readonly Dictionary<uint, Type> _types;

        public NetworkTypeFactory()
        {
            _types = new Dictionary<uint, Type>();
        }

        public void SearchTypesInAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes();
            var networkTypes = types.Where(x => typeof(NetworkType).IsAssignableFrom(x));
            foreach (var type in networkTypes)
            {
                var instance = (NetworkType)Activator.CreateInstance(type);
                if (!_types.ContainsKey(instance.ProtocolId))
                    _types.Add(instance.ProtocolId, type);
            }
        }

        public TNetworkType Get<TNetworkType>(uint protocolId) where TNetworkType : NetworkType
        {
            if (!_types.ContainsKey(protocolId))
                return default(TNetworkType);

            var type = _types[protocolId];
            if (typeof(TNetworkType).IsAssignableFrom(type))
                return (TNetworkType)Activator.CreateInstance(type);
            return default(TNetworkType);
        }
    }
}
