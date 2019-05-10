using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace BlueTofuEngine.Core.Network
{
    public interface INetworkClient
    {
        Guid Id { get; }
        string Nickname { get; set; }
        INetworkServer Server { get; }
        string Endpoint { get; }

        void Send(byte[] message);
        void Send(INetworkMessage message);
        void Handle(byte[] message);
        void Disconnect();
    }
}