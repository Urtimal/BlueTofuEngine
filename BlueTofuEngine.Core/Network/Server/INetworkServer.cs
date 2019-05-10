using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Network
{
    public interface INetworkServer
    {
        IEnumerable<INetworkClient> Clients { get; }

        INetworkClient GetClientById(Guid id);
        void SendToAll(INetworkMessage message);
        void DisconnectClient(Guid id);
        void Start();
        void Stop();
    }
}
