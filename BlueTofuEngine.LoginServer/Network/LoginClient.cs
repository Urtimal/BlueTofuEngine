﻿using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Client;
using BlueTofuEngine.Core.Utils;
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
            var accountId = (uint)RandomUtils.Next(1, byte.MaxValue);
            var entity = EntityFactory.Instance.CreateLogin(this, accountId);
            Nickname = accountId.ToString();

            Console.WriteLine("New client (" + Endpoint + ") => " + Nickname);
            entity.Notify(new ClientConnectedEventArgs());
        }
    }
}
