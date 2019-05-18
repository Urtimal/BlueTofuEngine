using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Client;
using BlueTofuEngine.Core.Utils;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using ErpoowEngine.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.GameServer.Network
{
    public class GameClient : BaseNetworkClient
    {
        public GameClient(EEClient client, INetworkServer server) : base(client, server)
        {
        }

        protected override void OnConnected()
        {
            var entity = EntityFactory.Instance.CreateClient(this);
            Nickname = "Unknown";

            Console.WriteLine("New client (" + Endpoint + ")");
            entity.Notify(new ClientConnectedEventArgs());
        }

        protected override void OnDisconnect()
        {
            Console.WriteLine("Client disconnected (" + Nickname + ")");
            ActionQueueManager.Instance.Execute(ActionQueues.ClientDisconnected, this.GetEntity(), e => {
                EntityManager.Instance.Delete(e.Id);
                Console.WriteLine("Player '" + Nickname + "' saved");
            });
            base.OnDisconnect();
        }
    }
}
