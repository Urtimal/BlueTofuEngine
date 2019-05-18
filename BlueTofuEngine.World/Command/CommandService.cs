using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Command
{
    public class CommandService : Singleton<CommandService>
    {
        private readonly Dictionary<string, Action<IEntity, string>> _bothHandlers;
        private readonly Dictionary<string, Action<string>> _consoleHandlers;
        private readonly Dictionary<string, Action<IEntity, string>> _clientHandlers;

        public CommandService()
        {
            _bothHandlers = new Dictionary<string, Action<IEntity, string>>();
            _consoleHandlers = new Dictionary<string, Action<string>>();
            _clientHandlers = new Dictionary<string, Action<IEntity, string>>();
        }

        public void RegisterBoth(string commandName, Action<IEntity, string> handler)
        {
            register(_bothHandlers, commandName, handler);
        }

        public void RegisterConsole(string commandName, Action<string> handler)
        {
            register(_consoleHandlers, commandName, handler);
        }

        public void RegisterClient(string commandName, Action<IEntity, string> handler)
        {
            register(_clientHandlers, commandName, handler);
        }

        private void register(Dictionary<string, Action<IEntity, string>> dico, string commandName, Action<IEntity, string> handler)
        {
            if (!dico.ContainsKey(commandName))
                dico.Add(commandName, handler);
        }

        private void register(Dictionary<string, Action<string>> dico, string commandName, Action<string> handler)
        {
            if (!dico.ContainsKey(commandName))
                dico.Add(commandName, handler);
        }

        public bool ExecuteConsole(string commandName, string args)
        {
            if (_consoleHandlers.ContainsKey(commandName))
                _consoleHandlers[commandName].Invoke(args);
            else if (_bothHandlers.ContainsKey(commandName))
                _bothHandlers[commandName].Invoke(null, args);
            else
                return false;
            return true;
        }

        public bool ExecuteClient(IEntity entity, string commandName, string args)
        {
            if (_clientHandlers.ContainsKey(commandName))
                _clientHandlers[commandName].Invoke(entity, args);
            else if (_bothHandlers.ContainsKey(commandName))
                _bothHandlers[commandName].Invoke(entity, args);
            else
                return false;
            return true;
        }
    }
}
