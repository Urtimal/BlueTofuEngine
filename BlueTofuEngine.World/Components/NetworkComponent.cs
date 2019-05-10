using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public class NetworkComponent : IComponent
    {
        public string Name => "network";
        public INetworkClient Client { get; set; }
    }

    public static class NetworkComponentExtensions
    {
        public static NetworkComponent Network(this IEntity entity)
        {
            return entity.GetComponent<NetworkComponent>();
        }
    }
}
