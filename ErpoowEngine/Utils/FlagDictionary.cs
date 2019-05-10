using System;
using System.Collections.Generic;
using System.Text;

namespace ErpoowEngine.Utils
{
    public class FlagDictionary
    {
        private readonly List<string> _flags;

        public FlagDictionary()
        {
            _flags = new List<string>();
        }

        public void Set(string flagName, bool value)
        {
            if (value && !_flags.Contains(flagName))
                _flags.Add(flagName);
            if (!value && _flags.Contains(flagName))
                _flags.Remove(flagName);
        }

        public bool Get(string flagName)
        {
            return _flags.Contains(flagName);
        }
    }
}
