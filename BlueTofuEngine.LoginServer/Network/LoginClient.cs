using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Client;
using BlueTofuEngine.Core.Utils;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Events;
using ErpoowEngine.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.LoginServer.Network
{
    public class LoginClient : BaseNetworkClient
    {
        public LoginClient(EEClient client, INetworkServer server) : base(client, server)
        {
        }

        protected override void OnConnected()
        {
            var entity = EntityFactory.Instance.CreateLogin(this);
            Nickname = "Unknown";

            Console.WriteLine("New client (" + Endpoint + ")");
            entity.Notify(new ClientConnectedEventArgs());
        }

        protected override void OnDisconnect()
        {
            Console.WriteLine("Client disconnected (" + Nickname + ")");
            base.OnDisconnect();
        }
    }
}
