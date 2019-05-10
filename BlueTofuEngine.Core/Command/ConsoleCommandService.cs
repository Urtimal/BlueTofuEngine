using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Command
{
    public class ConsoleCommandService : Singleton<ConsoleCommandService>
    {
        private readonly Dictionary<string, Action<string>> _handlers;

        public ConsoleCommandService()
        {
            _handlers = new Dictionary<string, Action<string>>();
        }

        public void Register(string commandName, Action<string> handler)
        {
            if (!_handlers.ContainsKey(commandName))
                _handlers.Add(commandName, handler);
        }

        public bool Execute(string commandName, string args)
        {
            if (!_handlers.ContainsKey(commandName))
                return false;

            _handlers[commandName].Invoke(args);
            return true;
        }
    }
}
