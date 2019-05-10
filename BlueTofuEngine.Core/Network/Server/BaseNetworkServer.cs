using BlueTofuEngine.Core.Network.Client;
using ErpoowEngine.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Core.Network.Server
{
    public abstract class BaseNetworkServer<T> : INetworkServer where T : BaseNetworkClient
    {
        public IEnumerable<INetworkClient> Clients => _clients;

        protected readonly List<T> _clients;
        private EEServer _server;

        public BaseNetworkServer()
        {
            _clients = new List<T>();
        }

        public void Initialize(string host, int port)
        {
            _server = new EEServer(host, port);
            _server.ClientAccepted += OnClientAccepted;
        }

        public INetworkClient GetClientById(Guid id)
        {
            return _clients.FirstOrDefault(x => x.Id == id);
        }

        public void SendToAll(INetworkMessage message)
        {
            foreach (var client in _clients)
                client.Send(message);
        }

        public void DisconnectClient(Guid id)
        {
            var client = _clients.FirstOrDefault(x => x.Id == id);
            if (client != null)
            {
                try
                {
                    client.Close();
                }
                catch { }
                _clients.RemoveAll(x => x.Id == id);
            }
        }

        public void Start()
        {
            _server.Start();
        }

        public void Stop()
        {
            _server.Stop();
        }

        private void OnClientAccepted(EEClient client)
        {
            var newClient = (T)Activator.CreateInstance(typeof(T), client, this);
            _clients.Add(newClient);
        }
    }
}
