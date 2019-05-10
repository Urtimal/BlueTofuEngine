using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Configuration
{
    public class DefaultConfiguration : IConfiguration
    {
        private readonly Dictionary<string, object> _configs;

        public DefaultConfiguration()
        {
            _configs = new Dictionary<string, object>();
        }

        public TValue Get<TValue>(string name)
        {
            if (!_configs.ContainsKey(name))
                return default(TValue);
            var config = _configs[name];
            if (config is TValue)
                return (TValue)config;

            return default;
        }

        public void Set<TValue>(string name, TValue value)
        {
            if (!_configs.ContainsKey(name))
                _configs.Add(name, value);
            else
                _configs[name] = value;
        }
    }
}
